"""Long-term roadmap, checked against facts read from the game (/progress), not against the model's memory.

Each night the current milestone (the first one not done) is shown to the planning model with what is still
missing, and its `step` (a concrete action that advances it) is forced into tomorrow's script if the model
left out every action that would advance it.
"""


LATER = "later"  # not relevant yet (recipe not unlocked, nothing to move indoors): neither done nor current


def _m(p, name):
    return p.get("materials", {}).get(name, 0)


def _placed(p, name):
    return p.get("placed", {}).get(name, 0)


def _knows(p, recipe):
    return recipe in p.get("recipes", [])


def _lack(p, needs):
    """needs: {material: amount} -> list of 'X 还差 n'."""
    return [f"{k} 还差 {v - _m(p, k)}" for k, v in needs.items() if _m(p, k) < v]


def _craft_and_place(item):
    return [{"type": "craft", "item": item, "count": 1}, {"type": "place", "item": item}]


def chest(p):
    if _placed(p, "Chest") >= 1:
        return None
    lack = _lack(p, {"Wood": 50})
    return {"missing": lack, "step": [{"type": "store_items"}] if not lack else [{"type": "clear_debris", "max": 15}],
            "advances": {"store_items", "craft", "clear_debris"}}


def backpack(p):
    if p.get("backpack", 12) >= 24:
        return None
    short = 2000 - p.get("money", 0)
    return {"missing": [f"金钱还差 {short}g（多出货）"] if short > 0 else ["钱够了：去皮埃尔商店 buy_backpack（9:00-17:00，周三休息）"],
            "step": [{"type": "buy_backpack"}] if short <= 0 else [],
            "advances": {"buy_backpack"} if short <= 0 else {"ship_produce", "fish", "mine"}}


def furnace(p):
    if _placed(p, "Furnace") >= 1:
        return None
    lack = _lack(p, {"Copper Ore": 20, "Stone": 25})
    if not _knows(p, "Furnace"):
        lack.insert(0, "还不会熔炉配方（拿到第一块铜矿后，克林特第二天寄来）")
    if not lack:
        return {"missing": [], "step": _craft_and_place("Furnace"), "advances": {"craft"}}
    return {"missing": lack, "step": [{"type": "mine", "floors": 5}], "advances": {"mine"}}


def second_furnace(p):
    """Guide: one furnace first, a second once extra copper and stone are on hand. Do not block tools while materials are short."""
    placed = _placed(p, "Furnace")
    if placed >= 2 or placed < 1 or not _knows(p, "Furnace"):
        return None if placed >= 2 else LATER
    lack = _lack(p, {"Copper Ore": 20, "Stone": 25})
    if lack:
        return LATER
    return {"missing": ["铜矿和石头够再做第二座熔炉，两座才能同时炼铜和铁"],
            "step": _craft_and_place("Furnace"), "advances": {"craft", "place"}}


def scarecrow(p):
    if _placed(p, "Scarecrow") >= 1:
        return None
    if not _knows(p, "Scarecrow"):
        return LATER
    lack = _lack(p, {"Wood": 50, "Coal": 1, "Fiber": 20})
    if not lack:
        return {"missing": [], "step": _craft_and_place("Scarecrow"), "advances": {"craft", "place"}}
    # Wood comes from twigs/trees; fiber from weeds; coal from the mine. Never inject craft until materials are ready.
    if _m(p, "Coal") < 1:
        step = [{"type": "mine", "floors": 3}]
    elif _m(p, "Wood") < 50:
        step = [{"type": "clear_debris", "max": 25, "kinds": ["twig", "weed"]}]
    else:
        step = [{"type": "clear_debris", "max": 20, "kinds": ["weed"]}]
    return {"missing": lack, "step": step, "advances": {"mine", "clear_debris"}}


# Which held tool to advance first. Levels, prices, and bar counts come from GET /tool_upgrades.
TOOL_ORDER = ("axe", "pickaxe", "watering_can", "hoe")


def _ladder(p, ladder):
    if isinstance(ladder, dict) and ladder.get("tools"):
        return ladder
    if isinstance(p, dict) and isinstance(p.get("tool_ladder"), dict) and p["tool_ladder"].get("tools"):
        return p["tool_ladder"]
    return None


def _next_tier(info):
    current = info.get("current_level") or 0
    pending = [tier for tier in info.get("tiers") or [] if (tier.get("level") or 0) > current]
    pending.sort(key=lambda tier: tier.get("level") or 0)
    return pending[0] if pending else None


def tool_upgrades(p, ladder=None):
    """Next tool from GET /tool_upgrades. No local price table and no fixed max tier."""
    ladder = _ladder(p, ladder)
    if ladder is None:
        return LATER
    up = ladder.get("upgrading")
    if up is None and isinstance(p, dict):
        up = p.get("upgrading")
    if up:
        name = up.get("name") or up.get("tool") or "工具"
        if up.get("days_left", 1) <= 0:
            return {"missing": [f"克林特已经升级好{name}，去铁匠铺取回（9:00-16:00）"],
                    "step": [{"type": "upgrade_tool"}], "advances": {"upgrade_tool"}}
        return {"missing": [f"克林特正在升级{name}，还要 {up.get('days_left')} 天（一次只能升级一件）"],
                "step": [{"type": "ship_produce"}, {"type": "fish", "casts": 5}],
                "advances": {"ship_produce", "fish", "mine", "clear_debris", "harvest_crops"}}
    by_key = {tool.get("key"): tool for tool in ladder.get("tools") or [] if tool.get("key")}
    pending = []
    for index, key in enumerate(TOOL_ORDER):
        info = by_key.get(key)
        if not info or not info.get("held", True):
            continue
        tier = _next_tier(info)
        if tier is not None:
            pending.append((tier.get("level") or 0, index, key, tier))
    if not pending:
        return None
    _, _, key, tier = min(pending)
    price = tier.get("price")
    amount = tier.get("trade_item_amount")
    item_name = tier.get("trade_item_name") or ""
    label = tier.get("display_name") or key
    if price is None or amount is None:
        return {"missing": [f"下一档是{label}，游戏没有同时返回价格和材料数量"],
                "step": [], "advances": set()}
    owned = tier.get("owned")
    if owned is None:
        owned = _m(p, item_name) if item_name else 0
    lack = []
    if owned < amount:
        lack.append(f"{tier.get('trade_item_display') or item_name or '材料'} 还差 {amount - owned}")
    if p.get("money", 0) < price:
        lack.append(f"金钱还差 {price - p.get('money', 0)}g")
    if not lack:
        return {"missing": [f"升级要求够了：把{key}升成{label}（{price}g + {amount} 个材料，一次一件）"],
                "step": [{"type": "upgrade_tool", "tool": key}], "advances": {"upgrade_tool"}}
    if owned < amount:
        ore = {"Iron Bar": "Iron Ore", "Gold Bar": "Gold Ore", "Copper Bar": "Copper Ore"}.get(item_name)
        if ore and _m(p, ore) >= 5 and _m(p, "Coal") >= 1:
            step = [{"type": "load_machines", "item": ore}]
        else:
            step = [{"type": "mine", "floors": 5}]
        # Fishing does not make the missing bars. A fish step must not count as this milestone.
        return {"missing": [f"下一档是{label}（最高 {by_key[key].get('max_level')} 级），要求还不够"] + lack,
                "step": step, "advances": {"mine", "load_machines"}}
    return {"missing": [f"下一档是{label}（最高 {by_key[key].get('max_level')} 级），要求还不够"] + lack,
            "step": [{"type": "ship_produce"}], "advances": {"ship_produce", "mine"}}


def mine_gear(p):
    """Iron ore is below floor 40: get a weapon and food that the mine action accepts for that depth."""
    g = p.get("gear") or {}
    if g.get("safe_depth", 0) >= 79:
        return None
    reason = g.get("safe_depth_reason") or ""
    lack = [f"现在最多安全下到第 {g.get('safe_depth')} 层：{reason}"]
    guild = g.get("guild_weapons") or []
    if guild:
        lack.append("冒险家公会在卖：" + "、".join(guild))
    if "weapon" in reason:
        affordable = any(int(w.rsplit(" ", 1)[-1].rstrip("g")) <= p.get("money", 0) for w in guild if w.rsplit(" ", 1)[-1].rstrip("g").isdigit())
        step = [{"type": "buy_weapon"}] if affordable else [{"type": "mine", "floors": 5}]
        return {"missing": lack, "step": step, "advances": {"buy_weapon", "mine"}}
    # food: fish are edible, and fishing also earns money
    return {"missing": lack + ["食物：鱼可以吃（钓鱼），也可以在酒吧买沙拉"], "step": [{"type": "fish", "casts": 5}],
            "advances": {"fish", "buy", "cook"}}


def fishing(p):
    """Fishing level 2 at a river (the farm pond is mostly junk at level 0), then a Fiberglass Rod + bait from Willy."""
    level = p.get("skills", {}).get("fishing", 0)
    rod = p.get("rod") or ""
    if rod in ("Fiberglass Rod", "Iridium Rod") and p.get("bait", 0) > 0:
        return None
    if level < 2:
        return {"missing": [f"钓鱼 {level} 级：去森林的河(Forest)或海滩(Beach)钓到 2 级（农场池塘基本只出垃圾）"],
                "step": [{"type": "goto_location", "location": "Forest"}, {"type": "fish", "casts": 8}],
                "advances": {"fish"}}
    shop = [{"type": "goto_location", "location": "FishShop"}, {"type": "open_shop", "shop_id": "FishShop"}]
    if rod not in ("Fiberglass Rod", "Iridium Rod"):
        if p.get("money", 0) < 2100:
            return {"missing": [f"玻璃纤维钓竿 1800g（+鱼饵），现在 {p.get('money', 0)}g"], "step": [], "advances": {"ship_produce", "fish"}}
        return {"missing": ["去威利的鱼店买玻璃纤维钓竿和鱼饵（9-17 点）"],
                "step": shop + [{"type": "buy", "item": "Fiberglass Rod", "count": 1}, {"type": "buy", "item": "Bait", "count": 50},
                                {"type": "close_menu"}], "advances": {"buy", "open_shop"}}
    return {"missing": ["鱼饵用完了：去威利的鱼店买 Bait（5g 一个）"],
            "step": shop + [{"type": "buy", "item": "Bait", "count": 50}, {"type": "close_menu"}], "advances": {"buy", "open_shop"}}


def sprinklers(p):
    if _placed(p, "Sprinkler") + 2 * _placed(p, "Quality Sprinkler") >= 4:
        return None
    if p.get("skills", {}).get("farming", 0) < 2:
        return {"missing": ["农业 2 级才会洒水器配方（多种地、收获）"], "step": [], "advances": {"harvest_crops", "plant_seeds"}}
    bars_ok = _m(p, "Copper Bar") >= 1 and _m(p, "Iron Bar") >= 1
    if bars_ok:
        return {"missing": [], "step": _craft_and_place("Sprinkler"), "advances": {"craft"}}
    lack = []
    if _m(p, "Copper Bar") < 1:
        lack.append("铜锭（铜矿 5 + 煤 1 放进熔炉 load_machines）" if _m(p, "Copper Ore") >= 5 else "铜锭：先下矿拿铜矿")
    if _m(p, "Iron Bar") < 1:
        if _m(p, "Iron Ore") >= 5:
            lack.append("铁锭（铁矿 5 + 煤 1 放进熔炉 load_machines）")
        else:
            lack.append(f"铁矿：矿洞 40 层以下才有（现在最深 {p.get('deepest_mine', 0)} 层）")
    if any("熔炉" in x for x in lack) and _m(p, "Coal") < 1:
        lack.append("煤：矿洞里敲石头/打怪掉落")
    smelt = (_m(p, "Copper Ore") >= 5 or _m(p, "Iron Ore") >= 5) and _m(p, "Coal") >= 1
    step = [{"type": "load_machines"}] if smelt else [{"type": "mine", "floors": 5}]
    return {"missing": lack, "step": step, "advances": {"mine", "load_machines", "collect_machines"}}


def artisan(p):
    """Turn crops into artisan goods: preserves jars (farming 4), then kegs (farming 8)."""
    if _placed(p, "Preserves Jar") + _placed(p, "Keg") >= 4:
        return None
    if not _knows(p, "Preserves Jar"):
        return {"missing": [f"农业 4 级解锁保存罐（现在 {p.get('skills', {}).get('farming', 0)} 级）：多种地多收获"],
                "step": [], "advances": {"harvest_crops", "plant_seeds"}}
    lack = _lack(p, {"Wood": 50, "Stone": 40, "Coal": 8})
    if not lack:
        return {"missing": [], "step": _craft_and_place("Preserves Jar"), "advances": {"craft"}}
    return {"missing": lack, "step": [{"type": "mine", "floors": 5}] if _m(p, "Coal") < 8 else [{"type": "clear_debris", "max": 15}],
            "advances": {"mine", "clear_debris"}}


def coop(p):
    if "Coop" in p.get("buildings", []) or "Big Coop" in p.get("buildings", []):
        return None
    short = 4000 - p.get("money", 0)
    lack = _lack(p, {"Wood": 300, "Stone": 100}) + ([f"金钱还差 {short}g"] if short > 0 else [])
    if not lack:
        return {"missing": [], "step": [{"type": "build", "building": "Coop"}], "advances": {"build"}}
    return {"missing": lack, "step": [], "advances": {"clear_debris", "ship_produce", "mine"}}


def shed(p):
    """Machines move indoors before there are many of them, so the farm stays pastoral."""
    machines = sum(_placed(p, m) for m in ("Furnace", "Preserves Jar", "Keg", "Bee House", "Cask", "Cheese Press", "Mayonnaise Machine"))
    if "Shed" in p.get("buildings", []) or "Big Shed" in p.get("buildings", []):
        return None
    if machines < 6:
        return LATER
    short = 15000 - p.get("money", 0)
    lack = _lack(p, {"Wood": 300}) + ([f"金钱还差 {short}g"] if short > 0 else [])
    if not lack:
        return {"missing": [], "step": [{"type": "build", "building": "Shed"}], "advances": {"build"}}
    return {"missing": lack + [f"已经有 {machines} 台机器在户外作坊角"], "step": [], "advances": {"clear_debris", "ship_produce"}}


def house(p):
    if p.get("house_level", 0) >= 1:
        return None
    days = p.get("house_upgrade_days") or 0
    if days > 0:
        return {"missing": [f"罗宾正在升级房屋（厨房），还要 {days} 天"],
                "step": [{"type": "ship_produce"}, {"type": "fish", "casts": 5}],
                "advances": {"ship_produce", "fish", "mine", "clear_debris", "harvest_crops"}}
    short = 10000 - p.get("money", 0)
    lack = _lack(p, {"Wood": 450}) + ([f"金钱还差 {short}g"] if short > 0 else [])
    if not lack:
        return {"missing": ["材料和钱都够了：去罗宾处 upgrade_house（10000g + 450 木头，3 天）"],
                "step": [{"type": "upgrade_house"}], "advances": {"upgrade_house"}}
    step = [{"type": "clear_debris", "max": 20}] if _m(p, "Wood") < 450 else [{"type": "ship_produce"}, {"type": "fish", "casts": 5}]
    return {"missing": lack, "step": step,
            "advances": {"clear_debris", "ship_produce", "fish", "mine", "upgrade_house"}}


ROADMAP = [
    ("箱子", chest),
    ("背包升级 24 格", backpack),
    ("熔炉", furnace),
    ("第二座熔炉（材料够了才做，不挡住工具升级）", second_furnace),
    ("稻草人", scarecrow),
    ("工具按档升级（要求够了就升一件，不够就先凑钱和锭）", tool_upgrades),
    ("下矿装备（能安全下到 40 层以下拿铁矿）", mine_gear),
    ("洒水器 ×4（不再手动浇水）", sprinklers),
    ("钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵", fishing),
    ("工匠加工：保存罐/小桶 ×4（作物加工后再卖）", artisan),
    ("鸡舍", coop),
    ("大木屋（机器 6 台以上就搬进屋里）", shed),
    ("房屋升级（厨房）", house),
]


def evaluate(p):
    """-> (done names, [(name, info)] for the unfinished ones, in roadmap order)."""
    done, todo = [], []
    for name, check in ROADMAP:
        info = check(p)
        if info is None:
            done.append(name)
        elif info != LATER:
            todo.append((name, info))
    return done, todo


def describe(p):
    if not isinstance(p, dict) or "materials" not in p:
        return "## 里程碑进度\n（读取失败）"
    done, todo = evaluate(p)
    lines = ["## 里程碑进度（游戏数据实时计算，不是记忆）",
             "已完成：" + ("、".join(done) or "无")]
    for i, (name, info) in enumerate(todo[:3]):
        tag = "▶ 当前里程碑" if i == 0 else "  之后"
        lines.append(f"{tag}：{name} —— " + ("；".join(info["missing"]) or "条件都满足了，今天就做"))
    mats = {k: v for k, v in p.get("materials", {}).items() if v}
    lines.append(f"材料（背包+箱子）：{mats}；最深矿层 {p.get('deepest_mine')}；技能 {p.get('skills')}；背包 {p.get('backpack')} 格")
    g = p.get("gear") or {}
    if g:
        lines.append(f"战斗准备：武器 {g.get('weapon')}，可回血食物 {g.get('food')} 个，生命 {g.get('health')}；"
                     f"mine 动作最多会下到第 {g.get('safe_depth')} 层" + (f"（{g.get('safe_depth_reason')}）" if g.get("safe_depth_reason") else ""))
    return "\n".join(lines)


def current(p):
    if not isinstance(p, dict) or "materials" not in p:
        return None
    _, todo = evaluate(p)
    return todo[0] if todo else None
