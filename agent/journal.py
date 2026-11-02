"""
Human-readable play journal: one Markdown file per in-game day, e.g.
    <Stardew Valley>/AI游玩日志/<save>/Y1_spring_03.md

The agent appends to it live; `py journal.py` rebuilds every day file from runs/*/log.jsonl.
"""
import glob
import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent


def default_game_path():
    """The game folder: agent/config.json "game_path", else STARDEW_GAME_PATH, else Steam's default location."""
    try:
        cfg = json.loads((ROOT / "config.json").read_text(encoding="utf-8"))
    except (OSError, ValueError):
        cfg = {}
    import os
    return Path(cfg.get("game_path") or os.environ.get("STARDEW_GAME_PATH")
                or r"C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley")


DEFAULT_DIR = default_game_path() / "AI游玩日志"


def fmt_time(t):
    try:
        t = int(t)
    except (TypeError, ValueError):
        return "--:--"
    return f"{t // 100:02d}:{t % 100:02d}"


def fmt_action(a):
    if not isinstance(a, dict):
        return str(a)
    args = ", ".join(f"{k}={json.dumps(v, ensure_ascii=False)}" for k, v in a.items() if k != "type")
    return f"`{a.get('type')}`" + (f"（{args}）" if args else "")


def render(event):
    """Markdown for one log event (same shapes as runs/*/log.jsonl)."""
    kind = event.get("kind")
    if kind == "plan":
        lines = [f"\n## 🌅 早上的计划（{event.get('ts', '')[11:16]} 开始）"]
        if event.get("weather"):
            lines.append(f"- 天气：{event['weather']}　金钱：{event.get('money')}g　体力：{event.get('stamina')}")
        lines += [f"- {p}" for p in event.get("plan", [])]
        if event.get("script"):
            lines.append("\n**执行脚本：**")
            lines += [f"{i + 1}. {fmt_action(a)}" for i, a in enumerate(event["script"])]
        return "\n".join(lines) + "\n"
    if kind == "script":
        lines = [f"\n### 🔁 脚本重写：{event.get('source', '')}"]
        lines += [f"{i + 1}. {fmt_action(a)}" for i, a in enumerate(event.get("script", []))]
        return "\n".join(lines) + "\n"
    if kind == "step":
        ok = "✅" if event.get("ok") else "❌"
        thought = event.get("thought") or ""
        lines = [f"- **{fmt_time(event.get('time'))}** {event.get('location', '')} {ok} {fmt_action(event.get('action'))}"]
        if thought and not thought.startswith("(脚本") and not thought.startswith("(续"):
            lines.append(f"  - 💭 {thought}")
        result = event.get("result") or {}
        msg = result.get("message") or event.get("message", "")
        lines.append(f"  - 结果：{msg}")
        for m in result.get("game_messages", []) or []:
            lines.append(f"  - 🗨️ {m}")
        shown = " ".join(result.get("game_messages", []) or [])
        for letter in result.get("letters", []) or []:
            if letter[:40] not in shown:  # letters usually already appear as [mail] messages
                lines.append(f"  - ✉️ {letter}")
        return "\n".join(lines) + "\n"
    if kind == "day_summary":
        return (f"\n## 📊 当天结算（第二天早上统计）\n"
                f"- 金钱：{event.get('money_start')} → {event.get('money_next_morning')}（{event.get('income', 0):+}g）\n"
                f"- 出货估值：{event.get('shipped_value')}g　动作：{event.get('steps')} 个　失败：{event.get('failures')} 个\n"
                f"- 模型调用：{event.get('llm_calls')} 次　tokens：{event.get('tokens')}\n")
    if kind == "reflection":
        lines = ["\n## 🧠 夜间复盘", str(event.get("analysis", ""))]
        if event.get("lessons"):
            lines.append("\n**新教训：**")
            lines += [f"- {l}" for l in event["lessons"]]
        if event.get("strategy"):
            lines.append("\n<details><summary>改写后的策略</summary>\n\n" + str(event["strategy"]) + "\n\n</details>")
        return "\n".join(lines) + "\n"
    if kind == "prepared_script":
        lines = [f"\n## 🌙 为明天（{event.get('day')}）准备的脚本"]
        lines += [f"- {p}" for p in event.get("plan", [])]
        lines += [f"{i + 1}. {fmt_action(a)}" for i, a in enumerate(event.get("script", []))]
        return "\n".join(lines) + "\n"
    return ""


class Journal:
    def __init__(self, base_dir, save_name):
        self.dir = Path(base_dir) / (save_name or "unknown_save")
        self.dir.mkdir(parents=True, exist_ok=True)

    def path(self, day_tag):
        return self.dir / f"{day_tag}.md"

    def append(self, day_tag, event):
        text = render(event)
        if not text or not day_tag:
            return
        p = self.path(day_tag)
        if not p.exists():
            year, season, day = day_tag.split("_")
            p.write_text(f"# 第{year[1:]}年 {season} {int(day)} 日 — AI 游玩日志\n", encoding="utf-8")
        with p.open("a", encoding="utf-8") as f:
            f.write(text)


def day_of(event):
    """Which day file an event belongs to (night events go to the day that just ended)."""
    if event.get("kind") == "prepared_script":
        return event.get("from_day") or event.get("for_today_of")
    return event.get("day")


def rebuild(base_dir=DEFAULT_DIR, save_name=None, runs_dir=ROOT / "runs", since_run=""):
    """Regenerate every day file from runs/*/log.jsonl (only runs whose folder name sorts >= since_run)."""
    events = []
    for f in sorted(glob.glob(str(Path(runs_dir) / "*" / "log.jsonl"))):
        if Path(f).parent.name < since_run:
            continue
        for line in open(f, encoding="utf-8"):
            try:
                events.append(json.loads(line))
            except json.JSONDecodeError:
                pass
    events.sort(key=lambda e: e.get("ts", ""))
    j = Journal(base_dir, save_name)
    # only regenerate days that have records; keep other notes (e.g. days nobody played)
    for tag in {day_of(e) for e in events if day_of(e)}:
        if j.path(tag).exists():
            j.path(tag).unlink()
    last_day = None
    for e in events:
        tag = day_of(e)
        if e.get("kind") == "prepared_script":
            tag = last_day  # written the night before: belongs to the day that just ended
        if tag:
            j.append(tag, e)
            if e.get("kind") != "prepared_script":
                last_day = tag
    return j.dir


if __name__ == "__main__":
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    profile = sys.argv[1] if len(sys.argv) > 1 else "newgame1"
    save = (ROOT / "memory" / profile / "save_name.txt")
    since = sys.argv[2] if len(sys.argv) > 2 else ""
    out = rebuild(save_name=save.read_text(encoding="utf-8").strip() if save.exists() else profile, since_run=since)
    print("rebuilt:", out)
    for p in sorted(out.glob("*.md")):
        print(" ", p.name, p.stat().st_size, "bytes")
