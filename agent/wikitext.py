"""Read mod/wiki.txt. That file is the downloaded wiki, edited into one record per line.

Nothing here contacts pixelharvestwiki.com. Rebuild the file with build_wiki_text.py.
"""
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parent
WIKI_PATH = ROOT.parent / "mod" / "wiki.txt"
_CACHE = None


def parse(text):
    rows = []
    for line in text.splitlines():
        if not line or line.startswith("#"):
            continue
        parts = line.split("\t")
        if len(parts) < 5:
            continue
        attrs = {}
        for field in parts[5:]:
            if "=" in field:
                key, value = field.split("=", 1)
                attrs[key] = value
        rows.append({
            "dataset": parts[0],
            "slug": parts[1],
            "zh": parts[2],
            "en": parts[3],
            "summary": parts[4],
            "attrs": attrs,
        })
    return rows


def load(path=None):
    global _CACHE
    path = Path(path) if path else WIKI_PATH
    if _CACHE and _CACHE[0] == path:
        return _CACHE[1]
    rows = parse(path.read_text(encoding="utf-8")) if path.is_file() else []
    if path == WIKI_PATH:
        _CACHE = (path, rows)
    return rows


def _cjk(text):
    return [ch for ch in text if "\u4e00" <= ch <= "\u9fff"]


def _words(text):
    return re.findall(r"[a-z0-9]+", text.lower())


def _subseq_len(needle, hay):
    i = 0
    for ch in hay:
        if i < len(needle) and needle[i] == ch:
            i += 1
    return i


def score(row, query):
    zh, en, slug = row["zh"], row["en"], row["slug"]
    folded = query.strip().lower()
    if folded and folded in (zh.lower(), en.lower(), slug.lower()):
        return 100
    q_cjk = _cjk(query)
    if q_cjk:
        covered = _subseq_len(q_cjk, _cjk(zh))
        if covered == len(q_cjk) and covered >= 2:
            return 80
        if covered >= 2:
            return 40 + covered
    q_words = _words(query)
    names = set(_words(en) + _words(slug.replace("-", " ")))
    if q_words and all(word in names for word in q_words):
        return 70
    return 0


def search(rows, query, limit=4):
    if not query or len(query.strip()) < 2:
        return []
    ranked = []
    for row in rows:
        value = score(row, query)
        if value:
            catalog = 1 if row["dataset"] == "catalog" else 0
            ranked.append((-value, catalog, len(row["zh"]), row))
    ranked.sort(key=lambda item: item[:3])
    return [item[3] for item in ranked[:limit]]


def format_hits(rows):
    if not rows:
        return "（本地资料库没有对上的条目）"
    lines = []
    for row in rows:
        facts = []
        for key in ("升级费用", "所需材料", "season", "days", "sellPrice", "source", "获取方式", "loves", "birthday"):
            if row["attrs"].get(key):
                facts.append(f"{key}={row['attrs'][key]}")
        if not facts:
            facts.append(row["summary"])
        lines.append(f"- {row['zh']} / {row['en']}：{'；'.join(facts)}")
    return "\n".join(lines)


def consult(queries, limit=8):
    rows = load()
    seen = set()
    hits = []
    for query in queries:
        if not query:
            continue
        for part in re.split(r"[\s,，、+/（）()：:]+", str(query)):
            part = part.strip()
            if len(part) < 2:
                continue
            for row in search(rows, part, limit=2):
                key = (row["dataset"], row["slug"])
                if key in seen:
                    continue
                seen.add(key)
                hits.append(row)
                if len(hits) >= limit:
                    return format_hits(hits)
    return format_hits(hits)
