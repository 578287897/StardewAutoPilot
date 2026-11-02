"""Crop profit per day, from the game's crop data (/crop_data): what to plant today, and what to buy for next season."""

SEASONS = ["spring", "summer", "fall", "winter"]
SEASON_DAYS = 28


def profit(crop, days_left):
    """Net gold per tile if planted today with `days_left` days of growing time; None if it can't be harvested in time.
    Single-harvest crops are replanted (bought again) as often as they fit; regrowing crops are bought once."""
    grow, regrow = crop["days"], crop["regrow"]
    if grow > days_left:
        return None
    value = crop["sell"] * crop["yield"]
    if regrow and regrow > 0:
        harvests = 1 + (days_left - grow) // regrow
        cost = crop["seed_price"]
    else:
        harvests = days_left // grow
        cost = crop["seed_price"] * harvests
    net = harvests * value - cost
    return {"harvests": harvests, "net": round(net), "per_day": round(net / days_left, 1)}


def table(crops, season, days_left, top=8):
    rows = []
    for c in crops:
        if season not in c.get("seasons", []) or c.get("paddy"):
            continue
        # crops that keep growing into the next season get those days too
        nxt = SEASONS[(SEASONS.index(season) + 1) % 4]
        span = days_left + (SEASON_DAYS if nxt in c["seasons"] else 0)
        p = profit(c, span)
        if p and p["net"] > 0:
            rows.append({**c, **p})
    rows.sort(key=lambda r: -r["per_day"])
    return rows[:top]


def fmt_row(r):
    regrow = f"，之后每 {r['regrow']} 天再结" if r["regrow"] and r["regrow"] > 0 else ""
    trellis = "，要搭架子（挡路，种在地块边上）" if r.get("trellis") else ""
    return (f"{r['seed']}（{r['seed_price']}g@{r['shop']}）→ {r['crop']} 卖 {r['sell']}g，{r['days']} 天成熟{regrow}{trellis}："
            f"收 {r['harvests']} 次，每格净赚 {r['net']}g（{r['per_day']}g/天）")


def describe(crops, season, day):
    """Text for the night-before plan: best crops to plant tomorrow, and next season's best when the season is ending."""
    if not isinstance(crops, list) or not crops:
        return ""
    days_left = SEASON_DAYS - day  # planting tomorrow (day + 1) leaves 28 - day growing days
    lines = [f"## 种子收益表（游戏数据计算；明天种下、本季还剩 {days_left} 天，换季没收的作物会枯死）"]
    now = table(crops, season, days_left)
    lines += [f"- {fmt_row(r)}" for r in now] or ["- 本季剩下的天数已经不够任何作物成熟：不要再买本季种子，把钱留到下一季第 1 天"]
    if days_left <= 7:
        nxt = SEASONS[(SEASONS.index(season) + 1) % 4]
        lines.append(f"## 下一季（{nxt}）第 1 天就该种的（整季 28 天）——现在开始留钱")
        lines += [f"- {fmt_row(r)}" for r in table(crops, nxt, SEASON_DAYS, top=5)]
    return "\n".join(lines)
