"""Daily problem log: what failed, what couldn't be done, where it broke.

Human-readable copy is merged into the play journal:
  AI游玩日志/<save>/2026年11月7日/Y1_spring_03.md  → section「今日问题」

Agent-facing rolling summary (for tomorrow's prompts):
  memory/<profile>/problems.md
"""
from __future__ import annotations

import collections
from datetime import datetime
from pathlib import Path


def calendar_folder_name(when=None):
    """Real-world date folder, e.g. 2026年11月7日."""
    when = when or datetime.now()
    return f"{when.year}年{when.month}月{when.day}日"


def calendar_dir(base, when=None):
    """Ensure and return base/2026年11月7日/."""
    d = Path(base) / calendar_folder_name(when)
    d.mkdir(parents=True, exist_ok=True)
    return d


def from_failed_steps(steps, limit=25):
    """Turn failed action records into structured problem entries (no LLM needed)."""
    out = []
    for s in steps:
        if s.get("ok"):
            continue
        action = s.get("action") or {}
        out.append({
            "source": "auto",
            "time": s.get("time"),
            "location": s.get("location") or "",
            "action": action.get("type") or "",
            "what": f"动作 `{action.get('type')}` 失败",
            "where": s.get("location") or "未知地点",
            "error": (s.get("message") or "")[:240],
            "blocked": "",
            "detail": action,
        })
        if len(out) >= limit:
            break
    return out


def merge_llm_problems(auto_entries, llm_problems):
    """Append model-summarized problems (dedupe by what+error text)."""
    seen = {(e.get("what"), e.get("error")) for e in auto_entries}
    merged = list(auto_entries)
    for p in llm_problems or []:
        if not isinstance(p, dict):
            text = str(p).strip()
            if not text:
                continue
            p = {"what": text, "where": "", "error": "", "blocked": ""}
        what = str(p.get("what") or p.get("problem") or "").strip()
        error = str(p.get("error") or p.get("why") or "").strip()
        if not what and not error:
            continue
        key = (what, error)
        if key in seen:
            continue
        seen.add(key)
        merged.append({
            "source": "llm",
            "time": p.get("time") or "",
            "location": p.get("where") or p.get("location") or "",
            "action": p.get("action") or "",
            "what": what or "（未命名问题）",
            "where": p.get("where") or p.get("location") or "",
            "error": error,
            "blocked": str(p.get("blocked") or p.get("cannot") or "").strip(),
            "detail": p,
        })
    return merged


def format_day_markdown(day_tag, entries, analysis=""):
    lines = [f"# {day_tag} 问题日志\n"]
    if analysis:
        lines.append(f"> 复盘摘要：{analysis}\n")
    if not entries:
        lines.append("今天没有记录到失败或阻塞问题。\n")
        return "\n".join(lines)

    # group identical errors
    counts = collections.Counter()
    samples = {}
    for e in entries:
        key = (e.get("action") or "", e.get("error") or e.get("what") or "")
        counts[key] += 1
        samples.setdefault(key, e)

    lines.append(f"共 {len(entries)} 条（合并后 {len(counts)} 类）\n")
    for i, ((action, err), n) in enumerate(counts.most_common(), 1):
        e = samples[(action, err)]
        tag = "自动" if e.get("source") == "auto" else "复盘"
        title = e.get("what") or action or "问题"
        lines.append(f"## {i}. [{tag}] {title}" + (f"（×{n}）" if n > 1 else ""))
        if e.get("where") or e.get("location"):
            lines.append(f"- 地点：{e.get('where') or e.get('location')}")
        if e.get("time"):
            lines.append(f"- 时间：{e.get('time')}")
        if action:
            lines.append(f"- 动作：`{action}`")
        if err:
            lines.append(f"- 错误/原因：{err}")
        if e.get("blocked"):
            lines.append(f"- 因此做不了：{e['blocked']}")
        lines.append("")
    return "\n".join(lines)


def append_rolling(path: Path, day_tag: str, entries, analysis="", keep_days=60):
    """Append a short day section to the rolling problems.md; trim old days if too long."""
    path = Path(path)
    path.parent.mkdir(parents=True, exist_ok=True)
    if not entries and not analysis:
        return
    block = [f"\n## {day_tag}\n"]
    if analysis:
        block.append(f"- 摘要：{analysis}\n")
    for e in entries[:20]:
        bits = [e.get("what") or e.get("action") or "问题"]
        if e.get("where") or e.get("location"):
            bits.append(f"@{e.get('where') or e.get('location')}")
        if e.get("error"):
            bits.append(f"— {e['error'][:120]}")
        if e.get("blocked"):
            bits.append(f"（卡住：{e['blocked'][:80]}）")
        block.append("- " + " ".join(bits) + "\n")
    fresh = not path.exists() or path.stat().st_size == 0
    with path.open("a", encoding="utf-8") as f:
        if fresh:
            f.write("# 问题日志（自动记录每天的失败与阻塞）\n")
        f.write("".join(block))
    # trim: keep last keep_days "## Y" sections
    text = path.read_text(encoding="utf-8")
    parts = text.split("\n## ")
    if len(parts) > keep_days + 1:
        head, rest = parts[0], parts[1:]
        path.write_text(head + "\n## " + "\n## ".join(rest[-keep_days:]), encoding="utf-8")


def recent_for_prompt(path: Path, n=12):
    """Last few bullet lines for inclusion in planning prompts."""
    path = Path(path)
    if not path.exists():
        return "（暂无）"
    lines = [l for l in path.read_text(encoding="utf-8").splitlines() if l.startswith("- ")]
    return "\n".join(lines[-n:]) if lines else "（暂无）"
