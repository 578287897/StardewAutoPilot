"""Stdio MCP server for the running Stardew AutoPilot mod.

Tools read localhost:8765 and the SMAPI log.
They do not call pixelharvestwiki.com. Speak MCP over Content-Length frames.
"""
import json
import os
import sys
import urllib.error
import urllib.request
from pathlib import Path

GAME = os.environ.get("STARDEW_MOD_URL", "http://localhost:8765").rstrip("/")
LOG = Path(os.environ.get("APPDATA", "")) / "StardewValley" / "ErrorLogs" / "SMAPI-latest.txt"
JOURNAL_ROOT = Path(os.environ.get("STARDEW_GAME_DIR", r"F:\steam\steamapps\common\Stardew Valley")) / "AI游玩日志"
PROTOCOL = "2024-11-05"


def send(msg):
    # Grok's stdio client reads one JSON object per line.
    sys.stdout.buffer.write(json.dumps(msg, ensure_ascii=False).encode("utf-8") + b"\n")
    sys.stdout.buffer.flush()


def read_message():
    """Accept both Content-Length frames and one-JSON-per-line."""
    while True:
        line = sys.stdin.buffer.readline()
        if not line:
            return None
        stripped = line.strip()
        if not stripped:
            continue
        if stripped.startswith(b"{"):
            return json.loads(stripped.decode("utf-8"))
        headers = {}
        while line and line.strip():
            if b":" in line:
                key, value = line.decode("ascii", "replace").split(":", 1)
                headers[key.strip().lower()] = value.strip()
            line = sys.stdin.buffer.readline()
            if not line:
                return None
        length = int(headers.get("content-length", "0"))
        if length <= 0:
            continue
        return json.loads(sys.stdin.buffer.read(length).decode("utf-8"))


def game_request(method, path, body=None, timeout=20):
    data = json.dumps(body, ensure_ascii=False).encode("utf-8") if body is not None else None
    req = urllib.request.Request(
        GAME + path, data=data, method=method,
        headers={"Content-Type": "application/json"},
    )
    try:
        with urllib.request.urlopen(req, timeout=timeout) as resp:
            return json.loads(resp.read().decode("utf-8"))
    except urllib.error.HTTPError as e:
        raw = e.read().decode("utf-8", "replace")
        try:
            return json.loads(raw)
        except json.JSONDecodeError:
            return {"ok": False, "message": f"HTTP {e.code}: {raw[:300]}"}
    except Exception as e:
        return {"ok": False, "message": f"cannot reach {GAME} ({e})"}


def tool_text(text):
    return {"content": [{"type": "text", "text": text}]}


def status(_args):
    st = game_request("GET", "/state", timeout=15)
    if not isinstance(st, dict) or "player" not in st:
        return tool_text("游戏接口没有返回状态。\n" + json.dumps(st, ensure_ascii=False)[:800])
    player = st.get("player") or {}
    job = st.get("job") or {}
    lines = [
        f"第{st.get('year')}年 {st.get('season')} {st.get('day')}日 {st.get('time')} 天气 {st.get('weather')}",
        f"地点 {st.get('location')}  ({player.get('x')},{player.get('y')})",
        f"金钱 {player.get('money')}g  体力 {player.get('stamina')}/{player.get('max_stamina')}  生命 {player.get('health')}/{player.get('max_health')}",
        f"菜单 {st.get('menu') or '无'}  动作 {job.get('type') or '空闲'} {job.get('status') or ''}".rstrip(),
    ]
    if st.get("game_messages"):
        lines.append("消息 " + " / ".join(str(m) for m in st["game_messages"][-3:]))
    return tool_text("\n".join(lines))


def problems(args):
    n = int(args.get("lines") or 80)
    if not LOG.is_file():
        return tool_text(f"没有 SMAPI 日志：{LOG}")
    text = LOG.read_text(encoding="utf-8", errors="replace").splitlines()
    keep = [line for line in text if any(k in line for k in ("ERROR", "WARN", "Exception", "Player stuck", "ActionFailed"))]
    tail = "\n".join(keep[-n:]) or "（日志里没有 ERROR / WARN / stuck）"
    return tool_text(tail[-6000:])


def journal(_args):
    if not JOURNAL_ROOT.is_dir():
        return tool_text(f"没有游玩日志目录：{JOURNAL_ROOT}")
    files = sorted(JOURNAL_ROOT.rglob("Y*.md"), key=lambda p: p.stat().st_mtime)
    if not files:
        return tool_text("游玩日志是空的")
    latest = files[-1]
    body = latest.read_text(encoding="utf-8", errors="replace")
    return tool_text(f"{latest}\n\n" + body[-4000:])


def goals(_args):
    parts = []
    for path in ("/tool_upgrades", "/actions", "/quests", "/special_orders", "/achievements"):
        payload = game_request("GET", path, timeout=30)
        text = json.dumps(payload, ensure_ascii=False)
        parts.append(f"## {path}\n" + text[:2500])
    return tool_text("\n\n".join(parts)[:8000])


def act(args):
    action = args.get("action")
    if isinstance(action, str):
        action = json.loads(action)
    if not isinstance(action, dict) or "type" not in action:
        return tool_text("action 必须是带 type 的对象，例如 {\"type\":\"sleep\"}")
    result = game_request("POST", "/act", action, timeout=330)
    return tool_text(json.dumps(result, ensure_ascii=False)[:4000])


def cancel(_args):
    return tool_text(json.dumps(game_request("POST", "/cancel", {}), ensure_ascii=False)[:1000])


TOOLS = {
    "status": {
        "description": "当前游戏时间、地点、金钱、体力、生命和正在执行的动作。读本地模组接口。",
        "schema": {"type": "object", "properties": {}},
        "fn": status,
    },
    "problems": {
        "description": "SMAPI 日志里最近的 ERROR、WARN、Exception 和 Player stuck。",
        "schema": {"type": "object", "properties": {"lines": {"type": "integer"}}},
        "fn": problems,
    },
    "journal": {
        "description": "最新一份 AI 游玩日志的末尾。",
        "schema": {"type": "object", "properties": {}},
        "fn": journal,
    },
    "goals": {
        "description": "读模组的工具阶梯、当前场面动作、任务、特殊订单和成就。不上网，不读本地百科。",
        "schema": {"type": "object", "properties": {}},
        "fn": goals,
    },
    "act": {
        "description": "向正在运行的模组提交一个动作。autopilot.py 也在跑时会抢同一个队列，只在它卡住时使用。",
        "schema": {"type": "object", "properties": {"action": {"type": "object"}}, "required": ["action"]},
        "fn": act,
    },
    "cancel": {
        "description": "取消模组里正在执行的动作。",
        "schema": {"type": "object", "properties": {}},
        "fn": cancel,
    },
}


def handle(msg):
    method = msg.get("method")
    mid = msg.get("id")
    if method == "notifications/initialized" or mid is None:
        return None
    if method == "initialize":
        return {"jsonrpc": "2.0", "id": mid, "result": {
            "protocolVersion": PROTOCOL,
            "capabilities": {"tools": {}},
            "serverInfo": {"name": "stardew-play", "version": "0.2.0"},
        }}
    if method == "tools/list":
        return {"jsonrpc": "2.0", "id": mid, "result": {"tools": [
            {"name": name, "description": spec["description"], "inputSchema": spec["schema"]}
            for name, spec in TOOLS.items()
        ]}}
    if method == "tools/call":
        params = msg.get("params") or {}
        name = params.get("name")
        spec = TOOLS.get(name)
        if spec is None:
            return {"jsonrpc": "2.0", "id": mid, "error": {"code": -32602, "message": f"unknown tool {name}"}}
        try:
            result = spec["fn"](params.get("arguments") or {})
        except Exception as e:
            result = tool_text(f"{type(e).__name__}: {e}")
        return {"jsonrpc": "2.0", "id": mid, "result": result}
    if method == "ping":
        return {"jsonrpc": "2.0", "id": mid, "result": {}}
    return {"jsonrpc": "2.0", "id": mid, "error": {"code": -32601, "message": f"unknown method {method}"}}


def main():
    while True:
        msg = read_message()
        if msg is None:
            return
        reply = handle(msg)
        if reply is not None:
            send(reply)


if __name__ == "__main__":
    main()
