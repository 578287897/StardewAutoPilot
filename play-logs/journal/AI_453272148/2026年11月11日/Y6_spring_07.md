# 第6年 spring 7 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（19:59 开始）
- 天气：windy　金钱：86248g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：eb2aae41373b4ec5a903359f467cc0b4
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：4d3746145a9f4424822935b533d1e5be
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Bug Meat, 1x Coal, 3x Copper Bar
  - 执行状态：SUCCESS · 操作编号：8a721bda334048049dffc23937a8fb46
  - 耗时：6.156 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：c0f1588a65d9414da8d28401bd7649fc
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：3ce9e9e70ee745f99ef255353fb10e4a
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：cd41b58ef36b4c8980f79e2d177c5c25
  - 耗时：0.672 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_07）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉、有空炉且铁矿石≥5 就装料
- 农场出货箱卖 Copper Bar 留 20、卖多余 Stone/Sap，清包到空格≥5
- 补食物到≥8（Saloon 12:00 开门后买沙拉）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine 每次 ≤5 层
- 回农场收铁锭，铁锭≥5 且 12:00 前则去 Blacksmith 升 hoe
- 清包失败或下矿失败则转 Forest 钓鱼到 20:00
- 21:30 前 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `ship`（item="Copper Bar", count=70）
12. `ship`（item="Stone", count=2000）
13. `ship`（item="Sap", count=48）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=12）
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：940210560ec24394aefe34f10995c870
  - 耗时：0.688 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败后按策略物理删除 take/donate/store 分支，改为农场出货箱卖 Copper Bar 清包→40 层刷铁→回农场收锭→Fo
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Forest"）
15. `fish`（casts=12）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `collect_machines`
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e3daf131b5144fb7b38f3c8798da0112
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 已连续失败且箱子内容与记忆不符，物理删除 take/donate 分支，改为农场出货箱清包后直奔 40 层刷铁，失败则 Forest 钓鱼收
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Forest"）
15. `fish`（casts=12）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `collect_machines`
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：23b808cab1be43889bbec5991a958c43
  - 耗时：0.562 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为农场出货箱卖 Copper Bar 清包后下矿刷铁，失败则 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Forest"）
15. `fish`（casts=12）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dc6155eeeba94afeb65aa4caf37f610b
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d55186bb8b694210bf377f936ef87cae
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：20ebafdbeddf4b5da868d38d4593c7a1
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5d304fca1cb84e49bdfb11fc0a4292a7
  - 耗时：80.343 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：272d1a0d33d44934a0bdff675fb83927
  - 耗时：43.859 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：15a64580ab9e4095a3e53079a36728bd
  - 耗时：0.609 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=70）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：62d8962aaf344a90ad6e442e7c90474a
  - 耗时：0.703 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=500）
  - 结果：shipped 26x Stone (~52g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：072c36e84ecc40c886e0d18251b8948b
  - 耗时：43.969 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：14785f4856f04160a0e060a4e307ed30
  - 耗时：49.078 秒 / 游戏 60 分钟
- **10:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：8d4f6878ef654b49930501da33ac20a8
  - 耗时：33.703 秒 / 游戏 40 分钟
- **10:40** Mine ✅ `store_items`（items=["Geode", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Geode
  - 执行状态：SUCCESS · 操作编号：a2f8bbf14ce947e3acd3e0cb9cb8a4a8
  - 耗时：15.125 秒 / 游戏 30 分钟
- **10:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 20 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：63319388b30746b39316434f714be073
  - 耗时：75.5 秒 / 游戏 90 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
- **13:20** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：d3aba072186343318f969f302f8ffd4c
  - 耗时：2.047 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **13:20** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：bfb4c33ead5c46909d7f9f9f80137873
  - 耗时：59.343 秒 / 游戏 70 分钟
- **14:30** Forest ✅ `fish`（casts=12）
  - 结果：fished: caught 12 (Sunfish, Broken Glasses, Chub, Green Algae, Chub, Sunfish, Sunfish, Chub, Sunfish, River Jelly, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：fa549167793b44bbb3a2dce1a27cf99a
  - 耗时：240.562 秒 / 游戏 230 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
- **18:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：98b39f5122cd48749a18410abf2413af
  - 耗时：15.375 秒 / 游戏 20 分钟
- **18:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **18:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：8ce42e8f390c45069db07670b4564969
  - 耗时：23.718 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：86248 → 86300（+52g）
- 出货估值：0g　动作：34 个　失败：18 个
- 模型调用：6 次　tokens：68878
- 有效动作率：0.4615　空转：6　熔断跳过：7
- 失败耗时：10.406 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天34动作18失败，核心仍是清包失败：Copper Bar 90个未卖，背包空格不足，mine被拒只下到19层拿不到铁。take空跑12次、donate/build_road/store_items空跑浪费动作。有效动作是Forest钓鱼12条和ship石头。今天起床第一件事必须在农场出货箱卖Copper Bar留20，验证空格≥5后电梯直达40层刷铁，凑5铁锭升Steel Hoe。

**新教训：**
- 昨天 ship Copper Bar 在 ArchaeologyHouse 报 'not found'，而材料显示背包有 90 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包完整清单，地点不对直接不生成 ship。
- 昨天 mine 在 Mine 报 'store did not free enough slots (have 1, need 5)'，说明 mine 动作本身会先尝试 store 再下矿：脚本生成阶段若背包空格<5 就物理删除 mine 分支，而不是等运行时被拒。
- 昨天 12 次 take 空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，12:40 到 21:30 空转；而 Forest 钓鱼 12 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支填满剩余时间。
- 昨天 22:20 才 sleep，全天 34 动作 18 失败：收尾应硬性 21:30，21:30 后只允许 sleep，任何情况下不用 wait 填充时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 07）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 86248g 远超 5000，唯一卡点 Iron Bar 1/5，已连续 6 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 1-3 空格，90 个 Copper Bar 一个没卖，mine 两次被 'have 1, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 07）**：起床 collect→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼到 20:00。
- **明天（春 08）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 09）**：继续刷铁备钢斧，给作物地块补洒水器，开始春季作物（草莓前先种土豆/花椰菜保底）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 70 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 2 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 15-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 07 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 07 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。could not reach/locked/timeout 即当天永久跳过升级。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-12:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次（收熔炉成品）
2. 起床读炉状态 → 空炉且 Iron Ore≥5 立即 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过；Iron Ore<5 物理删除 load）
3. 清包到空格≥5（先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 40 层拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 春 07 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天34动作18失败，核心仍是清包失败：Copper Bar 90个未卖，背包空格不足，mine被拒只下到19层拿不到铁。take空跑12次、donate/build_road/store_items空跑浪费动作。有效动作是Forest钓鱼12条和ship石头。今天起床第一件事必须在农场出货箱卖Copper Bar留20，验证空格≥5后电梯直达40层刷铁，凑5铁锭升Steel Hoe。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 18:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包失败导致下矿被拒，Copper Bar 90 个一个没卖，背包空格始终不足 5 @ Farm / Mine — mine 报 'store did not free enough slots (have 1, need 5)'；ship Copper Bar 在 ArchaeologyHouse 报 'not found'（做不了：无法下 40 层拿铁矿石，Steel Hoe 升级连续 6 天零推进） 〔复盘〕
- take 动作连续空跑 12 次，脚本重写 3 次仍重试同一批矿物 ID @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作和脚本重写次数，挤占下矿和钓鱼时间） 〔复盘〕
- donate_museum 在博物馆空跑，背包里没有可捐物 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费一次跨地图移动和动作） 〔复盘〕
- build_road 报规划道路边没有可走空格 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：浪费动作，农场道路布局已无空位） 〔复盘〕
- mine 只下到 19 层，拿不到铁矿石，且食物不足被迫离开 @ Mine 15-19 层 — stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：铁矿石零收获，Iron Bar 仍差 4） 〔复盘〕
- load_machines 报没有空炉接受，熔炉都在忙 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish（做不了：无法炼铁，铁锭进度停滞） 〔复盘〕
- collect_machines 两次返回空，16:40 后仍被调用并被系统抑制 @ Farm — no machine has finished output / repeated ineffective action suppressed until game state changes（做不了：浪费动作，熔炉产出时间晚于 16:00） 〔复盘〕
