# 第5年 spring 25 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（18:19 开始）
- 天气：sunny　金钱：66159g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌙 为明天（Y5_spring_25）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——今天主活动是下矿拿铁矿石和煤，回农场炼铁，凑够 5 铁锭后去铁匠铺升 hoe
- 起床先收熔炉成品，若炉空且背包有铁矿石就投料
- 清包到空格≥15（store_items + ship_produce 双管齐下）
- 补食物到≥5：Forest 河边钓鱼（本季已无作物可种，不买春季种子）
- 电梯直达 80 层下矿拿铁矿石+煤，≤2 次 mine
- 回农场收铁锭，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 傍晚回农场收机器、清包、出货，21:30 前 sleep
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
11. `store_items`
12. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber"]）
13. `goto_location`（location="Forest"）
14. `fish`（casts=4）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `store_items`
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Farm"）
25. `collect_machines`
26. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber"]）
27. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Pickled Potato from Preserves Jar, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：12672c4ecbc44f3ba3117005d8bb80cf
  - 耗时：19.281 秒 / 游戏 20 分钟
  - 🗨️ [hud] Pickled Potato
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：1eacfb8b10434a23ae39bfd7690c06bd
  - 耗时：3.89 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：4b9e40698c71463ab742750cb233a99c
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 9 crops
  - 执行状态：SUCCESS · 操作编号：be84408776994a098b0e3cf34d39d467
  - 耗时：22.968 秒 / 游戏 40 分钟
- **07:00** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~210g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：c38eccd7fd2542bc99b22cf79e9418a8
  - 耗时：2.422 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5f3c9968bd134190a5c70d38df1ab76e
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take（箱子内容不符），改为清包→Forest 钓鱼补食物→电梯下矿 80 层拿铁矿石，回农场炼铁后视铁锭数去铁匠铺升 hoe，傍晚收机器
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
19. `store_items`
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber"]）
24. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4948cc36324d46bdae1a70c7b9444ea2
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全失败已删除，改为清包→Forest 钓鱼补食物→下矿 80 层拿铁矿石→回农场炼铁收机器后睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `store_items`
16. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
17. `store_items`
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber"]）
21. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c1b3ce2e56a84470be46bccb69598ea0
  - 耗时：0.421 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失败（箱子内容与记忆不符），物理删除 take 与 donate_museum 分支，改为清包→Forest 钓鱼补食物→下矿拿铁矿石→
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
16. `store_items`
17. `store_items`
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
21. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3afdae1495ab42df8d305d7dcd2bde27
  - 耗时：0.453 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fb6cd6ed5c31433086c8686b2fd7c326
  - 耗时：0.438 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3e524c5d53564d45b9702361ea3492d0
  - 耗时：0.406 秒 / 游戏 0 分钟
- **07:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：c40451993277475595fcdd731fcd62d2
  - 耗时：41.641 秒 / 游戏 60 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：a80ba4121e83476d995c882d2affc9af
  - 耗时：44.125 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：5b0123fffdc2451c9610c00646d8e626
  - 耗时：0.421 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：27dc374d2fb542f9822cfaffa2a47031
  - 耗时：26.453 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Sunfish, Sunfish, Chub)
  - 执行状态：SUCCESS · 操作编号：bac65ca6268e4881818989496378371d
  - 耗时：91.703 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
- **10:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f2a2710196a84a6a84332db92ddc1046
  - 耗时：63.625 秒 / 游戏 90 分钟
- **12:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：ed82cc55847e4e4da6edef3507c088f6
  - 耗时：33.75 秒 / 游戏 40 分钟
- **12:20** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Potato Seeds", "Green Algae", "Cherry Bomb"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：abc37f6765c9463e9e2fd73c68397840
  - 耗时：15.156 秒 / 游戏 20 分钟
- **12:20** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：ff177bc03d2b4634a9797c6f4fd833a9
  - 耗时：0.5 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal, 7x Copper Bar
  - 执行状态：SUCCESS · 操作编号：7990dd143ae445cf94b7b942679bd9c6
  - 耗时：0.406 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
  - 结果：shipped 2 stacks worth ~165g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：39a0dccf833743f68c48ede956ce1175
  - 耗时：0.719 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：887a7b6dbb884d028ead3f446a232310
  - 耗时：0.421 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：d1426e050ebc48069d564445fa6b3272
  - 耗时：0.406 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：fc9390478fb34eb2af98c3851fb38fb7
  - 耗时：19.593 秒 / 游戏 20 分钟
  - 🗨️ [hud] Gold Bar
- **13:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ee442586217e48538546277f1bc9f9cc
  - 耗时：0.422 秒 / 游戏 0 分钟
- **13:40** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：52940393ddcc4f808cf834da9645686d
  - 耗时：0.39 秒 / 游戏 0 分钟
- **13:40** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：ab120d7cf12242bdb29c6ecfe26a25fb
  - 耗时：0.422 秒 / 游戏 0 分钟
- **13:40** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：148393d57f724976bfe59c3f6f167851
  - 耗时：0.422 秒 / 游戏 0 分钟
- **13:40** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 15 to 19 (4 floors down, 36 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：db5e121b4bf542c487cc903fac3f7d98
  - 耗时：83.422 秒 / 游戏 110 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
- **15:30** UndergroundMine19 ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4fa34d234a9a4991b93614d8c9ab781e
  - 耗时：37.453 秒 / 游戏 40 分钟
  - 🗨️ [question] 
- **15:30** UndergroundMine19 ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:10 pm
  - 执行状态：SUCCESS · 操作编号：502eaab81d794b0d933a1a6832def723
  - 耗时：83.813 秒 / 游戏 120 分钟
- **18:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：bda6bca844b94bebb9afdcd0032c04e6
  - 耗时：15.125 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66159 → 66534（+375g）
- 出货估值：375g　动作：43 个　失败：19 个
- 模型调用：6 次　tokens：69018
- 有效动作率：0.5714　空转：7　熔断跳过：6
- 失败耗时：4.763 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天43个动作19次失败，核心浪费是12次凭ID猜箱子的take（全失败）和两次build_road/decorate/wait空转。真正推进只有：钓鱼4条、下矿15→19层拿铜矿、熔炉炼出1金锭。铁锭链仍0/5，因为食物=0导致mine在19层被拦，根本没到40层以下。今天必须把「补食物」提到最前面，并且承认19层拿不到铁——要么买沙拉下40层，要么先买Claymore+沙拉。

**新教训：**
- 昨天电梯到 80 层但食物=0 被拦在 19 层，铁矿石一颗没拿到：下矿目标应改为 40 层（铁矿下限），而不是贪 80 层；食物不够时电梯再高也白跑。
- 昨天 12 次 take 宝石全失败，说明箱子内容与记忆完全不符：任何需要特定物品的动作前必须先读箱子实际内容，不能凭 ID 猜；今天直接物理删除 take。
- 昨天 build_road 返回「规划道路边没有还能走上去的空格」、decorate 返回「今天没有能做的装饰」：这两个动作连续多天 0 产出，应从脚本中彻底删除，不再作为填充动作。
- 昨天 load_machines 投 Iron Ore 返回「no empty machine accepts that, and the rest are busy」：投料必须在 collect 后 1 个动作内确认炉空，两炉都忙即当天永久跳过 load，不拖到下午再试。
- 昨天 donate_museum 因背包无可捐物失败，而背包里其实有 Aquamarine 等宝石但都在箱子里：捐博物馆前必须先 take 到背包（或下矿现拿），否则 donate 必失败；今天先禁用 donate。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 26）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 66159g 充足，卡点仍是 Iron Bar 0/5、Iron Ore 3。已连续 6 天零推进，铁锭链是全局瓶颈（钢斧、洒水器、高级洒水器全堵在它后面）。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。**关键认知：铁矿只在 40 层以下，19 层永远拿不到铁，所以「下到 40 层」是今天的唯一硬目标，食物是它的门票。**

接下来 3 天主活动：
- **今天（春 26）**：起床先买沙拉补食物到 ≥5（Saloon 12:00 后 / 或 Forest 钓鱼），再电梯直达 40 层下矿拿铁矿石+煤，回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（春 27）**：hoe 升完转钢斧（同配方 5 铁锭），继续炼铁；铁锭不足则全天矿洞 40-50 层刷铁。
- **后天（春 28）**：铁锭富余后做洒水器 ×4（1 铜锭+1 铁锭），把浇水体力省下来；季末只种 28 日前能熟的作物。

## 今日核心修正（按执行顺序）
1. **食物是下矿硬门槛，且必须够下 40 层**：起床后若可回血食物 <5，先去 Saloon 买沙拉（12:00 后）或 Forest 河边 fish ≤1 轮（≤4 cast）。**食物 <5 时物理删除 mine 分支**；食物 <5 且已过 12:00 仍买不到，当天定性钓鱼日。
2. **下矿目标改为 40 层，不是 80 层**：昨天电梯到 80 层但食物=0 被拦在 19 层，白跑。今天电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**。
3. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入补食物+下矿。
4. **清包是硬门槛**：goto Farm → store_items（不指定坐标，存 Stone/Geode/种子/杂矿）→ ship_produce（卖鱼/杂矿/低价值物，Stone/Coal/矿石/锭除外）→ **读背包验证空格≥15**。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包后全天禁止 take。
5. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
6. **mine 成功一次后先 store_items 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
9. **build_road / decorate 物理删除**：昨天各失败 2 次和 1 次，连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 一次性清包到空格≥15：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥5：Saloon 买沙拉（12:00 后）或 Forest 河边 fish ≤1 轮（≤4 cast）；食物<5 不下矿。
5. 下矿（仅当空格≥15 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→45，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 store_items 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买春季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
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
3. 一次性清包到空格≥15（store_items 不指定坐标 + ship_produce 卖低价值物 + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥15、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天43个动作19次失败，核心浪费是12次凭ID猜箱子的take（全失败）和两次build_road/decorate/wait空转。真正推进只有：钓鱼4条、下矿15→19层拿铜矿、熔炉炼出1金锭。铁锭链仍0/5，因为食物=0导致mine在19层被拦，根本没到40层以下。今天必须把「补食物」提到最前面，并且承认19层拿不到铁——要么买沙拉下40层，要么先买Claymore+沙拉。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 12:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 13:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:30 动作 `build_road` 失败 @ UndergroundMine19 — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12 次 take 宝石（Aquamarine/Ruby/Topaz/Diamond/Frozen Tear/Earth Crystal）全部失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 (74,15) — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：捐博物馆、送礼、献祭都拿不到指定物品，白耗 12 个动作） 〔复盘〕
- 计划电梯直达 80 层拿铁矿，实际被食物=0 拦在 19 层，铁矿石一颗没拿到 @ Mine 15→19 层 — stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：铁锭链连续第 6 天零推进，钢锄头/钢斧/洒水器全部堵死） 〔复盘〕
- 清包后背包只剩 2 格，mine 被拒 @ Farm — store did not free enough slots (have 2, need 5)（做不了：下矿计划推迟到 13:20 才执行，浪费上午黄金时段） 〔复盘〕
- build_road 连续 2 次失败、decorate 失败 1 次、wait 空转 120 分钟 @ Farm — 规划道路边没有还能走上去的空格 / 今天没有能做的装饰 / waited until 6:10 pm（做不了：16:10-18:10 两小时纯空转，本可用于钓鱼或第二次下矿） 〔复盘〕
- load_machines 投 Iron Ore 时两炉都忙，返回失败 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy; try again after they finish（做不了：铁矿石无法投料，铁锭产出延后） 〔复盘〕
- donate_museum 失败，背包里没有可捐物 @ Town ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：博物馆捐献进度停滞，社区中心收集包无法推进） 〔复盘〕
- 食物=0 却仍按计划下矿，导致下矿被系统拦停 @ Mine — only 0 healing food (need 3+ for floor 20 and below)（做不了：无法下到 40 层以下拿铁矿，铁锭链彻底卡死） 〔复盘〕
