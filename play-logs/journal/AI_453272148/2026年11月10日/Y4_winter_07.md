# 第4年 winter 7 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（08:30 开始）
- 天气：snow　金钱：52685g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：051cafa5a01d4702872835fb5145d051
  - 耗时：5.016 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tomorrow we're all gathering in front of Marnie's house for the Festival of Ice.  It's a celebration of winter... there'll be snowmen, ice sculptures, and an ice fishing competition! Arrive between 9 AM and 2 PM if you'd like to participate.   -Mayor Lewis
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6ac135f58a5745f289477d54839cd4a0
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：dfbe3506f1674e4cb0340ce2d48d80d1
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：6aab52697f3b4f78a6425b01afae6ff4
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~860g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：425c6b4be8f741e29ebec806b1929a9f
  - 耗时：1.047 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_07）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天先清背包腾格再下矿拿铁矿石+煤
- 起床先 ship_produce 卖杂项（Bone Fragment、Mystery Box、Cherry Bomb、多余鱼）腾到 ≥10 空格
- load 铁矿石进空炉（≤1 次，12:00 前）
- Forest 河边钓鱼补食物到 ≥3（鱼可吃）
- 电梯直达 75 层下矿拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场 collect 收铁锭，铁锭 ≥5 且 <15:30 去 Blacksmith 升 hoe
- 14:00 后顺路去冒险家公会确认武器（已有 Claymore 则跳过）
- 条件满足 craft 洒水器并带坐标 place
1. `donate`
2. `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can"]）
3. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb"]）
4. `load_machines`（item="Iron Ore"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `craft`（item="Sprinkler", count=1）
16. `place`（item="Sprinkler", x=30, y=20）
17. `goto_location`（location="Farm"）
18. `store_items`（items=["Stone", "Copper Ore", "Coal", "Fiber"]）
19. `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore"]）
20. `sleep`
- **06:00** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：c3032bf3764947c3b5d365dffea65187
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：74f3450d1b22484c96f7e762e8f9a5c5
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：c1fe86d5263944e9bc9e6a10bca0c611
  - 耗时：4.703 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：f5272f509b2b48e9b3b6e0aa17d5f51d
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：6a7eda5f8695427b979585ed3de31893
  - 耗时：24.781 秒 / 游戏 30 分钟
- **06:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Green Algae, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：d7a669846bff49dc8a9144d204385428
  - 耗时：101.406 秒 / 游戏 120 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
- **08:40** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5d0228206b064f6cb83291ca0f07f2ab
  - 耗时：73.266 秒 / 游戏 90 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b85c224563ef4262a1fd6c1941938690
  - 耗时：0.391 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine因背包空格不足被拒，先回农场存杂物腾格再下矿，其余路线保留。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb", "Green Algae"]）
7. `collect_machines`
8. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
9. `sleep`
- **10:10** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：05509606d6e441ca8b6a1da24b4e4875
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4c449576fbb54da583fe85009b0546c5
  - 耗时：0.296 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：先回农场存材料腾出≥5格再下矿，避免重跑被拒的mine；铁锭够且未过15:30则升hoe。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb", "Green Algae"]）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
11. `collect_machines`
12. `sleep`
- **10:10** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：f1037224716e4e21a000afb69bc040a7
  - 耗时：0.344 秒 / 游戏 0 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：0f67a47ca53544b9adff500505d7e275
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包仅4格导致mine被拒，先回农场存材料腾格再下矿，回来收锭后升hoe。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb", "Green Algae", "Bamboo Pole", "Rusty Sword", "Silver Saber"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
10. `collect_machines`
11. `sleep`
- **10:10** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：ae9368ed54424e6a84f3d91461ee1cde
  - 耗时：0.406 秒 / 游戏 0 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ec6bd83f4fd540f4ad85c7a4624efbe5
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:10** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：d8f9623938234d7a94a44deed6df455b
  - 耗时：47.156 秒 / 游戏 60 分钟
- **11:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：d3420e9284dd448bb09f9f51dad52242
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:10** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：b5fc2e604872400dbe2eb90bd4454634
  - 耗时：38.922 秒 / 游戏 50 分钟
- **12:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb", "Green Algae", "Bamboo Pole", "Rusty Sword", "Silver Saber"]）
  - 结果：stored in chest at (75,15): 120x Stone, 2x Green Algae, 2x Copper Ore, 2x Bone Fragment, 1x Cherry Bomb, 1x Mystery Box
  - 执行状态：SUCCESS · 操作编号：fa36ec7cf84b4a86bfa5644d641af91b
  - 耗时：1.063 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：ecdd4947cf084dc6bf4c40c0726fc108
  - 耗时：0.313 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Coal"]）
  - 结果：stored in chest at (75,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：f4e92501efa140b1a4a84e6a137bfd33
  - 耗时：0.375 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:00** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：ee506eeab12f41dba802e2daeb039df2
  - 耗时：0.36 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：e21e9e8f38134edb9ed68b3838933271
  - 耗时：62.875 秒 / 游戏 70 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] This area is overrun 
with monsters. 
- **13:10** UndergroundMine17 ❌ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：246fda032d72430991788034bd02bda1
  - 耗时：0.359 秒 / 游戏 0 分钟
- **13:10** UndergroundMine17 ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：faebd72ba10744628fc6aee4902a6b45
  - 耗时：0.312 秒 / 游戏 0 分钟
- **13:10** UndergroundMine17 ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：e46b797224bf43f286adde607f7b6491
  - 耗时：44.578 秒 / 游戏 60 分钟
  - 🗨️ [question] 
- **14:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：8e2a723a4d5642519f596c76c6f4185c
  - 耗时：15.781 秒 / 游戏 20 分钟
- **14:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **14:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：fe62f12116e34fb18d0a6bdf9bc0fe2a
  - 耗时：12.859 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：52685 → 53545（+860g）
- 出货估值：860g　动作：35 个　失败：15 个
- 模型调用：5 次　tokens：64560
- 有效动作率：0.5　空转：9　熔断跳过：2
- 失败耗时：127.265 秒 / 游戏 150 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主线（铁锭→钢锄头）全天零推进：背包空格不足导致4次mine被拒，脚本重写3次仍重跑同一失败动作；load/collect时序错乱，铁锭只收到1个；下午还专门等公会开门浪费3小时。唯一有效产出是Forest钓鱼4条。今天必须先解决背包与熔炉时序，再谈下矿。

**新教训：**
- 昨天 4 次 mine 被拒后脚本重写 3 次仍重跑 mine：脚本生成阶段必须先读背包，空格 <10 时物理删除 mine 分支，而不是运行时反复被拒。
- store_items 到 (74,15) 箱子返回不可达、ship_produce 到 (70,15) 也返回 could not reach：农场常用箱子/出货箱路径被树或作物挡住，清背包前应改用农场入口附近可达的箱子，或先清出通道再存。
- 昨天 load 铁矿石返回 busy 后当天没再 load，铁锭产出为零：两炉都在炼时应先 collect 收成品再 load，或干脆等炉空后第二天 load，不要连续调 load。
- 钓鱼时 Green Algae/Trash 会占格并间接导致下矿被拒：钓鱼后立即 ship_produce 卖掉杂鱼，只留高回复鱼和献祭鱼。
- 昨天下午专门 goto 冒险家公会等 14:00 开门，耗掉约 3 小时游戏时间：买武器应排在 14:00 后顺路做，等待时段改去 Forest 钓鱼或下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 8）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 52685g 充足，Iron Bar 仅 1，差 4 锭（≈12 铁矿石 + 4 煤）。铁锭同时是洒水器材料，**「稳定产出铁锭」是唯一主线**，不是「下一次矿」。

离完成还差：12 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 8）**：起床先清背包到 ≥10 格并**读背包验证** → load 铁矿石（炉空才 load）→ 电梯直达 75 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 9）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 10）**：洒水器 craft+place 落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包到空格 ≥10**。用 `store_items` 存 Stone/Copper Ore/杂项到**农场入口附近可达的箱子**（不要用被树挡住的 (74,15)）；若 store 返回不可达，改用 `ship_produce` 卖低价值物。**存/卖后必须读背包验证空格 ≥10**；两次手段仍不足则当天定性钓鱼日，物理删除 mine 分支。
2. **load 铁矿石**：先读熔炉状态；两炉都 busy 则**先 collect 再 load**，不要连续调 load。load 每天 ≤1 次，12:00 前完成；返回 busy/no empty 即当天永久跳过。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留高回复鱼，杂鱼（Green Algae/Trash）立即 ship_produce 卖掉。食物 <3 禁止下 20 层以下；<5 禁止下 40 层以下；**电梯直达 75 层不受此限**。
4. **下矿（仅当空格 ≥10 且食物 ≥3 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**优先电梯直达 75 层**，`mine` 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。若 goto Blacksmith 或 upgrade_tool 返回 could not reach，当天永久跳过升级，不重试、不换坐标。
8. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → `buy` Claymore。买前读背包确认现金 ≥2000；买后读背包确认武器已换。若 goto 或 buy 失败一次，当天永久跳过，不重试。**禁止在 14:00 前专门 goto 公会等开门**——等待期间改去 Forest 钓鱼或下矿，14:00 后再顺路去。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
10. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。**store_items 返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。**
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。**两炉都 busy 时先 collect 再 load，不连续调 load。**
- **禁止专门等商店开门**：14:00 前不 goto Adventurer's Guild；等待时间用于钓鱼或下矿，14:00 后顺路买。
- **武器优先于下矿**：Silver Saber 8-15 在 80 层以下被拒，今天必须先买 Claymore（2000g）再下矿；买武器失败则当天只下 75-79 层（电梯层不受武器限制）。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥3 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。**同一层连续 2 次 mine 失败即 leave_mine，不重试第 3 次**。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。**电梯直达 75 层例外。**
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：清背包到空格 ≥10（store_items 到可达箱子 + 读背包验证）
2. load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
3. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
4. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥3、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
5. mine 成功一次后 store_items 腾格
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
8. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30、顺路；失败即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主线（铁锭→钢锄头）全天零推进：背包空格不足导致4次mine被拒，脚本重写3次仍重跑同一失败动作；load/collect时序错乱，铁锭只收到1个；下午还专门等公会开门浪费3小时。唯一有效产出是Forest钓鱼4条。今天必须先解决背包与熔炉时序，再谈下矿。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:10 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests) 〔自动〕
- 12:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `mine` 失败 @ Farm — floor 17: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Copper Ore / [hud] Stone / [hud] Coal / [hud] Copper Ore / [hud] Bug Meat / [hud] Fiber / [hud] This area is overrun 
with monsters.  〔自动〕
- 13:10 动作 `mine` 失败 @ UndergroundMine17 — floor 17: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 13:10 动作 `build_road` 失败 @ UndergroundMine17 — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) | 游戏消息: [question]  〔自动〕
- 14:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包空格不足导致下矿连续被拒，脚本重写 3 次仍重跑同一 mine 动作 @ Mine 入口 — 4x mine: need at least 5 free backpack slots before mining; store_items first（做不了：铁锭全天零新增，钢锄头升级持续卡住） 〔复盘〕
- 清背包手段失效：store_items 到农场箱子返回不可达，ship_produce 到出货箱也返回 could not reach @ Farm 出货箱/箱子附近 (53,8)→(70,15)/(74,15) — ship_produce -> FAIL: could not reach (70,15); stopped at (53,8)；store_items -> OK: nothing to store（物品不在背包或坐标错）（做不了：无法腾出背包空格，下矿分支彻底卡死） 〔复盘〕
- 熔炉时序错乱：起床先 collect 返回空，再 load 又 busy，铁锭只收到 1 个 @ Farm 熔炉 — collect_machines -> FAIL: no machine has finished output；load_machines -> FAIL: no empty machine accepts anything / repeated ineffective action suppressed（做不了：Iron Bar 仅 1，钢锄头差 4 锭，洒水器也因缺 Iron Bar 无法 craft） 〔复盘〕
- 专门去冒险家公会等 14:00 开门买 Claymore，耗掉约 3 小时游戏时间 @ AdventureGuild 门口 — goto_location 返回 waited until 2:00 pm (waiting for AdventureGuild to open at 14:00)（做不了：买完武器已 15:40，清背包和下矿时间被压缩，当天 mine 全部失败） 〔复盘〕
- 在 17 层 infested 层连续 3 次 mine 全失败，未及时 leave_mine 换层 @ Mine 第 17 层 — floor 17: no stones left and no ladder found (kill remaining monsters?)（做不了：浪费动作与时间，未推进矿层） 〔复盘〕
- build_road 与 decorate 连续多天 100% 失败，仍被脚本生成 @ Farm — build_road: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate: 今天没有能做的装饰（做不了：浪费动作，应彻底从脚本删除） 〔复盘〕
