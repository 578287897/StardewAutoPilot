"""Ask the in-game LLM whether a wedged farmer should reload the last save."""
import time

COOLDOWN_SECONDS = 20 * 60

DECIDE_SYSTEM = """你是星露谷代理里负责重启的判断。只输出 JSON：{"restart": true或false, "reason": "一句话"}。
重启会关掉游戏并读回上一夜已经存好的档，今天没存档的进度会丢掉。
游戏自己会把人从墙里挪出来、取消卡住的挥工具、送回农舍。这些做过了还是同一动作连着失败、门打不开、或者明显过不去，才可以 restart=true。
缺材料、商店没开门、钓鱼没钓到、铺路被挡住，都不要重启，换一个做法就行。"""


def wedged(steps):
    """Same failure repeating, or a long run of failures. One ordinary miss is not wedged."""
    if len(steps) >= 4:
        last = steps[-4:]
        types = {((s.get("action") or {}).get("type")) for s in last}
        if all(not s.get("ok") for s in last) and len(types) == 1:
            return True
        door = sum(1 for s in last if "did not open" in str(s.get("message") or "").lower())
        if door >= 3:
            return True
    if len(steps) >= 8 and all(not s.get("ok") for s in steps[-8:]):
        return True
    return False


def cooldown_active(stamp_text, now=None, seconds=COOLDOWN_SECONDS):
    now = time.time() if now is None else now
    try:
        ts = float(str(stamp_text).strip())
    except (TypeError, ValueError):
        return False
    return now - ts < seconds


def decision_prompt(steps):
    lines = []
    for s in steps[-8:]:
        action = s.get("action") or {}
        lines.append(f"{s.get('time')} {s.get('location')} {action.get('type')} {'OK' if s.get('ok') else 'FAIL'} {s.get('message')}")
    return "最近的动作：\n" + ("\n".join(lines) or "（无）")


def wants_restart(reply):
    return isinstance(reply, dict) and reply.get("restart") is True
