"""Download pixelharvestwiki datasets and write mod/wiki.txt.

The game mod and the agent read that text file. They do not call the website.
"""
import json
import urllib.request
from pathlib import Path

BASE = "https://pixelharvestwiki.com"
DATASETS = [
    "crops", "fish", "villagers", "cooking", "items",
    "skills", "quests", "festivals", "locations", "catalog",
]
OUT = Path(__file__).resolve().parent.parent / "mod" / "wiki.txt"
DROP_KEYS = {"links", "原名", "英文名", "assetName", "english", "en", "原版编号"}
# Advice paragraphs are not fields the mod matches on. Facts stay.
DROP_PROSE = {"新手建议", "关联规划", "使用限制"}


def get_json(url):
    req = urllib.request.Request(url, headers={"User-Agent": "StardewAutoPilot-wiki-text/1", "Accept": "application/json"})
    with urllib.request.urlopen(req, timeout=60) as resp:
        return json.loads(resp.read().decode("utf-8"))


def english_name(slug, attrs):
    for key in ("原名", "英文名", "assetName", "english", "en", "原版编号"):
        value = attrs.get(key)
        if isinstance(value, str) and value.strip():
            return value.strip()
    stem = slug[:-5] if slug.endswith("-icon") else slug
    return " ".join(part.capitalize() for part in stem.split("-") if part)


def flat(value):
    if isinstance(value, list):
        value = "、".join(str(v) for v in value)
    text = str(value).replace("\t", " ").replace("\r", " ").replace("\n", " ")
    text = " ".join(text.split())
    return text[:300]


def records(dataset):
    page = 1
    while True:
        data = get_json(f"{BASE}/api/datasets/{dataset}/entries?page={page}&pageSize=100")
        items = data.get("items") or []
        for item in items:
            attrs = item.get("attributes") or {}
            if not isinstance(attrs, dict):
                attrs = {}
            en = english_name(item.get("slug") or "", attrs)
            fields = []
            for key, value in attrs.items():
                if key in DROP_KEYS or key in DROP_PROSE or value in (None, "", []):
                    continue
                fields.append(f"{key}={flat(value)}")
            yield "\t".join([
                dataset,
                item.get("slug") or "",
                flat(item.get("name") or ""),
                flat(en),
                flat(item.get("summary") or ""),
                *fields,
            ])
        pagination = data.get("pagination") or {}
        pages = int(pagination.get("pages") or 1)
        if page >= pages or not items:
            return
        page += 1


def main():
    lines = [
        "# pixelharvestwiki 1.6.15 offline text for StardewAutoPilot",
        "# columns: dataset, slug, zh, en, summary, then key=value facts",
        "# lookup keys: zh name, en name (原名 or slug), slug. Do not fetch the website at runtime.",
    ]
    count = 0
    for dataset in DATASETS:
        n = 0
        for line in records(dataset):
            lines.append(line)
            n += 1
        count += n
        print(f"{dataset}: {n}")
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"wrote {count} entries -> {OUT}")


if __name__ == "__main__":
    main()
