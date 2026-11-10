# 第4年 fall 27 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（06:11 开始）
- 天气：sunny　金钱：50241g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_fall_27）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天凑齐 3 铁锭
- 起床清背包到空格 ≥8（卖鱼+杂项）
- craft 洒水器并落地（条件已满足）
- 熔炉先 collect 再 load 铁矿石（12:00 前）
- 食物 ≥5 且空格 ≥8 才下矿 75-79 层拿铁矿石+煤
- 回农场 collect 铁锭，够 5 锭且 <15:30 去铁匠铺升 hoe
- 不够则 Forest 钓鱼补食物/现金，22:00 前 sleep
1. `goto_location`（location="Town"）
2. `festival`（activity="start"）
3. `goto_location`（location="Farm"）
4. `ship_produce`（except=["River Jelly", "Green Algae", "Iron Bar", "Copper Bar"]）
5. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Iron Ore", "Cobblestone Path"]）
6. `craft`（item="Sprinkler", count=1）
7. `place`（item="Sprinkler"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `store_items`（items=["Iron Ore", "Coal", "Stone", "Copper Ore"]）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `fish`（casts=4）
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：013d2ee7b6314caf8ee980f3f2ddfdb8
  - 耗时：20.031 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：d786beb4ead740e38b2670d9ca64df86
  - 耗时：0.375 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：27d970f8a74e4b6f86e4e7065ff22a03
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：20cc6abeb045456e939a3b01dbbf9190
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：4706ba5155a249df9e076ed2d6c08c9d
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Coal | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：c7f0c419b20f46b8854d216ef775bf8f
  - 耗时：29.953 秒 / 游戏 40 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：Town 因节日锁门，放弃去镇上升级，改回农场装铁矿石、做洒水器、下矿拿铁锭，剩余时间钓鱼补食物，22:00 前睡。
1. `goto_location`（location="Town"）
2. `festival`（activity="start"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `load_machines`（item="Iron Ore"）
12. `craft`（item="Sprinkler", count=1）
13. `place`（item="Sprinkler"）
14. `collect_machines`
15. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Iron Ore", "Cobblestone Path"]）
16. `ship_produce`（except=["River Jelly", "Green Algae", "Iron Bar", "Copper Bar"]）
17. `sleep`
- **07:00** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：6dd2ecb88fee49a2b5bfa2db721363a5
  - 耗时：5.407 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#2：Town 节日锁门，改回农场装铁矿石、做洒水器、清背包后下矿拿铁锭，够 5 锭就升 hoe，否则钓鱼收尾。
1. `goto_location`（location="Town"）
2. `festival`（activity="start"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `craft`（item="Sprinkler", count=1）
15. `place`（item="Sprinkler"）
16. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Cobblestone Path"]）
17. `ship_produce`（except=["River Jelly", "Green Algae", "Iron Bar", "Copper Bar"]）
18. `collect_machines`
19. `sleep`
- **07:00** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：aeb2aeca5b2a4c9a86102417bb7d5520
  - 耗时：5.454 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#3：Town 节日锁门，放弃进城，改回农场收熔炉铁锭并下矿凑最后 1 锭，够 5 锭再去铁匠铺升 hoe，不够则钓鱼收尾。
1. `goto_location`（location="Town"）
2. `festival`（activity="start"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `load_machines`（item="Iron Ore"）
15. `craft`（item="Sprinkler", count=1）
16. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Cobblestone Path", "Green Algae"]）
17. `collect_machines`
18. `sleep`
- **07:10** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：3873f8fa8b6a4ef0b97fd5676a340211
  - 耗时：5.234 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **07:20** BusStop ❌ `festival`（activity="start"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：6f5da96434c54b7fbfc96e636837f854
  - 耗时：0.328 秒 / 游戏 0 分钟
- **07:20** BusStop ❌ `goto_location`（location="Mine"）
  - 结果：no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：efc7834bddcf4de4aec19724932ed8fd
  - 耗时：70.812 秒 / 游戏 80 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **08:40** Forest ❌ `mine`（floors=5）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：d071e92df7cc449eb755cc0dd3bcc00f
  - 耗时：300.328 秒 / 游戏 190 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Sap
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Bone Fragment
- **11:50** UndergroundMine78 ❌ `fight`（range=6）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：2fbad6d3e8784226be2581f9043e408c
  - 耗时：300.328 秒 / 游戏 0 分钟
- **11:50** UndergroundMine78 ❌ `mine`（floors=5）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：ea7662b23c0e44509df882372d5030b0
  - 耗时：300.359 秒 / 游戏 0 分钟
- **11:50** UndergroundMine78 ❌ `goto_location`（location="Blacksmith"）
  - 结果：no reachable route from Forest to Blacksmith (unreachable exits: mountain->town, backwoods->busstop, busstop->town, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：a3d5e9e3d84649b4802ddb6ce6a1b62a
  - 耗时：134.313 秒 / 游戏 170 分钟
  - 🗨️ [hud] +52 Energy
  - 🗨️ [hud] +33 Health
  - 🗨️ [question] 
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **14:40** Forest ❌ `upgrade_tool`（tool="hoe"）
  - 结果：no reachable route from Backwoods to Blacksmith (unreachable exits: forest->town, busstop->town, backwoods->mountain)
  - 执行状态：ACTION_FAILED · 操作编号：809629e15060436c9db26d4dd25ab84c
  - 耗时：69.078 秒 / 游戏 80 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **16:00** Backwoods ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：1def4a769c8c47febf9e568c5dc12b52
  - 耗时：47.953 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **17:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：e7752f2747de463c88e36ca6b0e5e89e
  - 耗时：80.469 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
- **18:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Broken Glasses, Smallmouth Bass, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：daee0ac93464412fa3545f6f36d9d7ae
  - 耗时：45.719 秒 / 游戏 50 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Smallmouth Bass
- **19:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：8c152837f13442ca89b85e666b73d75b
  - 耗时：9.594 秒 / 游戏 10 分钟
- **19:20** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：982410634dd94c3ca1108014ee9425ba
  - 耗时：18.829 秒 / 游戏 30 分钟
  - 🗨️ [hud] Copper Bar
- **19:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：5cb1b0bcb4364fcdba7841561718ae40
  - 耗时：0.36 秒 / 游戏 0 分钟
- **19:50** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：3135c72b352f48acada65ad01cdaae09
  - 耗时：0.313 秒 / 游戏 0 分钟
- **19:50** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Cobblestone Path", "Green Algae"]）
  - 结果：stored in chest at (74,15): 7x Green Algae, 1x Coal
  - 执行状态：SUCCESS · 操作编号：d350aadc9ca7425a821bb5f2a1934cde
  - 耗时：18.532 秒 / 游戏 20 分钟
- **20:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：e370ee180cdc415ebf8d15caa2a8b55b
  - 耗时：0.328 秒 / 游戏 0 分钟
- **20:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：668e73064b6e4a19809ba994535c6576
  - 耗时：10.343 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50241 → 50241（+0g）
- 出货估值：0g　动作：26 个　失败：13 个
- 模型调用：6 次　tokens：64356
- 有效动作率：0.36　空转：5　熔断跳过：0
- 失败耗时：1223.236 秒 / 游戏 580 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是节日锁城后仍反复 goto Town/Blacksmith/Mine 共 7 次失败，加上 2 次 HTTP 超时，26 个动作只有钓鱼和 1 个洒水器有产出。有效做法：Forest 钓鱼稳定出货、熔炉 collect 成功、craft 洒水器成功。今天秋 28 仍是节日（万灵节），Town 全天锁，主活动应直接定为农场内务+Forest 钓鱼，不碰 Town/Blacksmith/Mine；铁锭缺口留到冬 1 再补。

**新教训：**
- 节日当天（如秋 28 万灵节）Town 全天锁门，goto Town/Blacksmith/Mine 全部不可达：脚本生成阶段应先查日期，节日则物理删除所有 Town/Blacksmith/Mine 分支，只保留 Farm 内务+Forest 钓鱼+节日地图。
- goto 同一地点失败一次后重写脚本再试是纯浪费：昨天 goto Town 失败 4 次、goto Blacksmith 失败 2 次、goto Mine 失败 1 次，共 7 次失败约 300 游戏分钟；正确做法是第一次失败即永久跳过该地点，转 Forest 钓鱼。
- mine/fight 返回 HTTP timeout 不是游戏内失败，重试同一动作仍会超时：超时一次即当天不再调 mine/fight，1 个动作内 goto Forest 钓鱼。
- 节日锁城时熔炉 load 仍可在农场完成，但 collect 要等 ≥2 小时：节日当天把熔炉时序放在最前，钓鱼填充等待时间，不要空等。
- 昨天 26 个动作只有钓鱼和 1 个洒水器有产出，说明节日当天应把主活动直接定为 Forest 钓鱼（稳定出货+补食物），而不是反复尝试去 Town 办事。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 28）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50241g 充足，卡点是 Iron Bar 只有 3，还差 2 锭（≈6 铁矿石 + 2 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」仍是主线，但**今天秋 28 是节日（万灵节），Town 全天锁门，铁匠铺去不了**，升级只能顺延到冬 1。

离完成还差：约 6-9 铁矿石 + 2 煤 → 2 铁锭 → 冬 1 去铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 28，节日）**：不碰 Town/Blacksmith/Mine。起床 collect 熔炉→立即 load 铁矿石→craft 第 2 个洒水器并落地→Forest 钓鱼补食物/现金→若节日地图可达则参加，否则 22:00 sleep。
- **明天（冬 1）**：Town 解锁，起床先 collect 收锭，铁锭 ≥5 且 <15:30 直接升 hoe；不够则下矿 75-79 层补铁矿石。
- **后天（冬 2）**：转钢斧；冬季种冬季种子，茶苗能做就做。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：collect 熔炉 + 立即 load 铁矿石**
   - `collect_machines` 1 次收已完成锭（昨天 1950 load 的 Copper Ore 应已好）。
   - 若背包有 Iron Ore 且炉空 → `load_machines` 1 次装铁矿石，**必须在 12:00 前完成**。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
2. **craft 洒水器并落地**：`craft` 洒水器 1 个（Copper Bar 35、Iron Bar 3，够做 1 个）。craft 后 `place` 到空地块；place 返回「分区无空位」即当天永久跳过 place，洒水器存箱子。
3. **清背包到空格 ≥8**：`ship_produce` 显式卖鱼组（Green Algae、Broken Glasses、Smallmouth Bass 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment）。卖完读背包验证空格 ≥8；不足再卖一次小堆，仍不足则当天定性钓鱼日。
4. **节日判断（今天秋 28）**：脚本生成阶段先查日期是否节日；是节日则**物理删除所有 goto Town/Blacksmith/Saloon/AdventureShop/Mine 分支**，只保留 Farm 内务 + Forest 钓鱼 + 节日地图（若可达）。
5. **补食物到 ≥5**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。
6. **下矿（仅非节日）**：goto Mine 前显式读背包确认空格 ≥8 且食物 ≥5。`mine` 目标 75-79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
7. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
8. **升级工具（仅非节日）**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **节日锁城硬规则**：日期=节日时，脚本生成阶段就删除所有 goto Town/Blacksmith/Saloon/AdventureShop/Mine 分支；节日当天主活动=农场内务+Forest 钓鱼+节日地图（若可达）。**goto 同一地点失败一次即永久跳过，不重试。**
- **熔炉顺序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 2**：条件已满足，起床 collect/load 后立即 craft，不能等「有空再做」。
- **清背包绝对优先**：ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
- **place 硬熔断**：`place` 返回「分区无空位」即当天永久跳过 place，不重试。place 前先确认目标分区有空位。
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
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：collect 熔炉 → 立即 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
2. craft 洒水器（条件已满足，必须今天做）+ place（无空位即跳过）
3. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
4. 节日判断：今天秋 28 是节日，删除所有 Town/Blacksmith/Mine 分支
5. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
6. 下矿 75-79 层拿铁矿石+煤（仅非节日；空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（仅非节日，升级前读背包确认锭数）
9. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
10. 浇水（水壶在背包时）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是节日锁城后仍反复 goto Town/Blacksmith/Mine 共 7 次失败，加上 2 次 HTTP 超时，26 个动作只有钓鱼和 1 个洒水器有产出。有效做法：Forest 钓鱼稳定出货、熔炉 collect 成功、craft 洒水器成功。今天秋 28 仍是节日（万灵节），Town 全天锁，主活动应直接定为农场内务+Forest 钓鱼，不碰 Town/Blacksmith/Mine；铁锭缺口留到冬 1 再补。
- 06:20 动作 `goto_location` 失败 @ Farm — exit to Town did not open (closed? locked? check opening hours). Recent messages: Coal | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 07:00 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:00 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:10 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:20 动作 `festival` 失败 @ BusStop — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 07:20 动作 `goto_location` 失败 @ BusStop — no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set u 〔自动〕
- 08:40 动作 `mine` 失败 @ Forest — cancelled: HTTP timeout | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [hud] Stone / [hud] Stone / [hud] Sap / [hud] Slime / [hud] Bone Fragment 〔自动〕
- 11:50 动作 `fight` 失败 @ UndergroundMine78 — cancelled: HTTP timeout 〔自动〕
- 11:50 动作 `mine` 失败 @ UndergroundMine78 — cancelled: HTTP timeout 〔自动〕
- 11:50 动作 `goto_location` 失败 @ UndergroundMine78 — no reachable route from Forest to Blacksmith (unreachable exits: mountain->town, backwoods->busstop, busstop->town, forest->town) | 游戏消息: [hud] +52 Energy / [hud] +33 Health / [question]  / [dialogue] Today's festival is being set up. Come  〔自动〕
- 14:40 动作 `upgrade_tool` 失败 @ Forest — no reachable route from Backwoods to Blacksmith (unreachable exits: forest->town, busstop->town, backwoods->mountain) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set up. Come  〔自动〕
- 19:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 20:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 节日锁城后仍反复尝试去 Town 办事 @ Farm→Town 出口 — goto_location -> FAIL: exit to Town did not open; 游戏消息: Today's festival is being set up. Come back later.（连续 4 次）（做不了：铁匠铺升级 hoe、去 Mine 下矿全部做不成，全天主活动被卡） 〔复盘〕
- 节日锁城导致去 Blacksmith 和 Mine 的路径全部不可达 @ Forest / Backwoods 中转 — goto_location -> FAIL: no reachable route from Forest to Blacksmith / Mine (unreachable exits: forest->town, busstop->town, backwoods->mountain)（做不了：钢锄头升级顺延，铁矿石和煤没拿到，铁锭仍为 3） 〔复盘〕
- mine 和 fight 动作 HTTP 超时 @ Mine — mine -> FAIL: cancelled: HTTP timeout; fight -> FAIL: cancelled: HTTP timeout（各 1 次）（做不了：下矿推进 0 层，铁矿石和煤没拿到） 〔复盘〕
- 熔炉 load 铁矿石失败，无空炉可装 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石没进炉，铁锭产出为零，钢锄头仍差 2 锭） 〔复盘〕
- 熔炉 collect 返回空，无成品可收 @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output（做不了：当天铁锭产出为零） 〔复盘〕
- 节日地图不可达，festival 动作失败 @ Farm — festival -> FAIL: not at a festival right now (goto_location the festival map during its hours first)（做不了：万灵节活动没参加，节日奖励没拿到） 〔复盘〕
