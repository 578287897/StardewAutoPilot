# 第4年 winter 19 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:27 开始）
- 天气：snow　金钱：58643g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b63e8b3ff2214400957a88cfef31647a
  - 耗时：0.328 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_19）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床先清背包到空格≥10（store_items 不指定坐标 + ship_produce 卖低价值物），这是下矿的硬门槛
- 铁矿石仅 4（<5），物理删除 load 分支，直接下矿拿矿
- 食物 17 个已 ≥5，无需钓鱼补食物
- 电梯直达 75 层，目标 75→79 层拿铁矿石+煤，≤2 次 mine
- 下矿回来 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 凑不齐铁锭则把剩余时间给 Forest 钓鱼，22:00 前 sleep
1. `donate`
2. `store_items`
3. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal", "Geode", "Magma Geode", "Omni Geode"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `store_items`
7. `mine`（floors=5）
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `goto_location`（location="Blacksmith"）
11. `upgrade_tool`（tool="hoe"）
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `fish`（casts=4）
15. `goto_location`（location="Farm"）
16. `sleep`
- **06:00** FarmHouse ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：cb2a62e0d48b4dd18d8e6417fdfa6d2e
  - 耗时：100.657 秒 / 游戏 130 分钟
- **08:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：08d41b09363b421798796849a2ecc174
  - 耗时：0.343 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：1fe1ab99beaf4ff0899dc96fba411a0b
  - 耗时：0.359 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：70a29db321a641d796231241c305f04f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：bb5273a5b0494cc6b9aff6f916192754
  - 耗时：0.344 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：1c5e628f496f44138ba1d3d75e375e2c
  - 耗时：15.765 秒 / 游戏 20 分钟
- **08:30** Farm ✅ `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal", "Geode", "Magma Geode", "Omni Geode"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：185a0925ed09426f9717608506a1b4bf
  - 耗时：0.391 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包仅7空格，先回农场存材料腾格并收炉，再电梯下矿75层拿铁矿，铁锭够就升hoe，余时钓鱼。
1. `mine`（floors=4）
2. `mine`（floors=4）
3. `goto_location`（location="ArchaeologyHouse"）
4. `take`（item="Copper Bar", count=1）
5. `take`（item="Bat Wing", count=1）
6. `take`（item="Frozen Geode", count=1）
7. `donate`
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `store_items`
14. `collect_machines`
15. `store_items`
16. `collect_machines`
17. `sleep`

## 🌅 早上的计划（10:30 开始）
- 天气：snow　金钱：58643g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——清背包到空格≥10
- 电梯直达75层下矿75→79拿铁矿石+煤
- 回农场收熔炉铁锭，铁锭≥5且<15:30则升hoe
- 剩余时间钓鱼补食物/收入

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `mine`（floors=4）
4. `mine`（floors=4）
5. `goto_location`（location="ArchaeologyHouse"）
6. `take`（item="Copper Bar", count=1）
7. `take`（item="Bat Wing", count=1）
8. `take`（item="Frozen Geode", count=1）
9. `donate`
10. `goto_location`（location="Blacksmith"）
11. `upgrade_tool`（tool="hoe"）
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `goto_location`（location="Farm"）
15. `store_items`
16. `collect_machines`
17. `store_items`
18. `collect_machines`
19. `sleep`
- **09:30** Mine ✅ `goto_location`（location="Mine", request_id="3a0faf0178e34aef807de2c5cd324a1d"）
  - 💭 (查询先前动作的实际结果，不重放)
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：3a0faf0178e34aef807de2c5cd324a1d
- **09:30** Mine ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：97b9fe1027c94ed1ae9a86a63820114e
  - 耗时：0.422 秒 / 游戏 0 分钟
- **09:30** Mine ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：330461c6b43d4bbaa593dc616455856d
  - 耗时：136.562 秒 / 游戏 190 分钟
- **12:40** Farm ✅ `mine`（floors=4）
  - 结果：mined from floor 80 to 84 (4 floors down, 21 stones broken)
  - 执行状态：SUCCESS · 操作编号：34a9e2fc301949039f03757d1ff7e285
  - 耗时：59.594 秒 / 游戏 70 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore

### 🔁 脚本重写：重写#1：背包仅1格，先回农场存/卖腾格并收炉，再电梯下矿75层拿铁矿，回农场收锭后15:30前升hoe，剩余时间钓鱼睡觉。
1. `mine`（floors=4）
2. `goto_location`（location="ArchaeologyHouse"）
3. `take`（item="Copper Bar", count=1）
4. `take`（item="Bat Wing", count=1）
5. `take`（item="Frozen Geode", count=1）
6. `donate`
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore"]）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `store_items`
17. `collect_machines`
18. `sleep`

## 🌅 早上的计划（10:34 开始）
- 天气：snow　金钱：58643g　体力：100/270
- 里程碑：凑齐5铁锭升级钢锄头
- 清背包腾出空格（当前仅1格）
- 下矿75→79层拿铁矿石+煤
- 回农场收熔炉铁锭
- 15:30前到铁匠铺升hoe

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `mine`（floors=4）
4. `goto_location`（location="ArchaeologyHouse"）
5. `take`（item="Copper Bar", count=1）
6. `take`（item="Bat Wing", count=1）
7. `take`（item="Frozen Geode", count=1）
8. `donate`
9. `goto_location`（location="Blacksmith"）
10. `upgrade_tool`（tool="hoe"）
11. `goto_location`（location="Forest"）
12. `fish`（casts=4）
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore"]）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `store_items`
19. `collect_machines`
20. `sleep`
- **15:00** Mine ✅ `mine`（floors=4, request_id="c2fbd7b9a51441cc8b8e0102b91d0cd5"）
  - 💭 (查询先前动作的实际结果，不重放)
  - 结果：mined from floor 84 to 86 (2 floors down, 51 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：c2fbd7b9a51441cc8b8e0102b91d0cd5
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Void Essence
  - 🗨️ [hud] Strange Bun
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Omni Geode
  - 🗨️ [question] 
- **15:00** Mine ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：490d0262fdec42c0bc53a67e7d9c1f17
  - 耗时：42.562 秒 / 游戏 60 分钟
- **16:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:00** Farm ❌ `mine`（floors=4）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b25e0a1040c844e9baf34fc30b3af293
  - 耗时：0.422 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅1格被拒下矿，先存材料卖杂物腾格，收熔炉铁锭后趁16点前赶铁匠铺升hoe，失败则转钓鱼收尾。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `take`（item="Frozen Geode", count=1）
5. `donate`
6. `goto_location`（location="Blacksmith"）
7. `upgrade_tool`（tool="hoe"）
8. `goto_location`（location="Forest"）
9. `fish`（casts=4）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore"]）
14. `collect_machines`
15. `sleep`
- **16:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c9c232a93e984b89b5e47653dc034b38
  - 耗时：61.063 秒 / 游戏 70 分钟
  - 🗨️ [hud] Journal Updated
  - 🗨️ [hud] New Journal Entry
  - 🗨️ [event] Skipped cutscene 0
- **17:10** ArchaeologyHouse ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：2eb411535c344598a4957e449690f697
  - 耗时：43.469 秒 / 游戏 50 分钟
- **18:00** Farm ❌ `take`（item="Bat Wing", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：3291c10d8012469e80a3fb164004fe63
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0格且已18:00铁匠铺关门，先存物卖货腾格、收熔炉成品，再转钓鱼收尾，放弃今日升级。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Bat Wing", count=1）
3. `take`（item="Frozen Geode", count=1）
4. `donate`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `mine`（floors=5）
8. `goto_location`（location="Farm"）
9. `store_items`
10. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar"]）
11. `collect_machines`
12. `sleep`
- **18:00** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: Copper Bar | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：1b54c0e2fe284c4faa38f08278ac320c
  - 耗时：47.375 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)
- **19:00** Town ❌ `take`（item="Bat Wing", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：2638999886674202b404de93568d235c
  - 耗时：41.828 秒 / 游戏 60 分钟
- **20:00** Farm ❌ `take`（item="Frozen Geode", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：8a96197bb03a469f8da57284d8399461
  - 耗时：0.36 秒 / 游戏 0 分钟
- **20:00** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：bfce0e08d7b547a4b96e5179d9e37d97
  - 耗时：0.36 秒 / 游戏 0 分钟
- **20:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：ac48d48f0cc34b19b841b4aeb0b17fc8
  - 耗时：23.547 秒 / 游戏 30 分钟
- **20:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Perch, Pike, Perch)
  - 执行状态：SUCCESS · 操作编号：ad64aa1d57da429b934a7251029ef083
  - 耗时：93.563 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
- **22:00** Forest ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：e1074f5960234c9a92326d4f58d03c67
  - 耗时：0.344 秒 / 游戏 0 分钟
- **22:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：3a0c36b5274845c58998fa5578140563
  - 耗时：9.562 秒 / 游戏 10 分钟
- **22:10** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 4x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：60dcd4eafd7d46378850684b55a101a4
  - 耗时：23.906 秒 / 游戏 40 分钟
- **22:50** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar"]）
  - 结果：shipped 1 stacks worth ~50g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：288a205ce29b4f52872315cfca0abc59
  - 耗时：0.703 秒 / 游戏 0 分钟
- **22:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：828fac3b25da4998a42abbd9a0070cb4
  - 耗时：19.579 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **23:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ab6e7710d6db4d98b3ca8b73fe29a2de
  - 耗时：16.953 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：58643 → 58693（+50g）
- 出货估值：50g　动作：19 个　失败：7 个
- 模型调用：3 次　tokens：38040
- 有效动作率：0.6111　空转：1　熔断跳过：0
- 失败耗时：90.735 秒 / 游戏 120 分钟
- 最深矿层：86　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天18动作7失败，核心堵点是背包0空格导致3次take、2次mine被拒，且store/ship指定旧坐标could not reach；熔炉因铁矿石仅4空转，钢锄头主线零推进。钓鱼4cast全成功是唯一稳定产出。今天必须先无坐标清包到≥10空格，再电梯75层拿铁矿，15:30前凑5铁锭升hoe。

**新教训：**
- 昨天 3 次 take 全因 inventory full 失败，且发生在 17:00-20:00 已无下矿窗口时：背包满时不要再去箱子取物，应直接 ship_produce 卖低价值物或结束当天，取物动作只在空格≥3 时安排。
- 昨天 18:00 去 ArchaeologyHouse 被锁（8:00-18:00），而 16:00 已过：博物馆/图书馆类地点 18:00 关门，下午 16:00 后不要再安排 goto ArchaeologyHouse，把该时段留给钓鱼或下矿。
- 昨天 donate 返回「nothing in the backpack is needed by an open bundle」说明背包里没有收集包需要的物品：donate 前应先从箱子取出收集包所需物品再捐，空背包捐必 0 产出。
- 昨天 mine 从 84→86 层只拿 2 层就因背包近满被迫离开：下矿前空格应≥10 而非 5，5 格只够 2 层，拿不到足够铁矿。
- 昨天 22:00 后仍安排 store_items/ship_produce/collect_machines 共 3 个动作到 23:10 才睡：22:00 后应直接 sleep，收尾动作必须在 21:30 前完成。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 20）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 58643g 充足，铁锭 0-1、铁矿石 4、煤 23。瓶颈是**铁矿石→铁锭转化链**，而昨天背包 0 空格把下矿路径彻底堵死。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 20）**：起床先无坐标清背包到空格≥10（第一硬门槛）→ 读炉状态，空炉且铁矿石≥5 才 load → 食物≥5 → **电梯直达 75 层下矿 75→79 拿铁矿石+煤**（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 21）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续下矿炼铁；同时 craft 洒水器落地。
- **后天（冬 22）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **清背包是今天第一硬门槛，优先于一切**：脚本生成前先读 /state 背包空格；**空格 <10 时物理删除 mine 分支**，只保留 store_items → ship_produce → 钓鱼。store_items **不指定坐标**，返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外），两次后仍不足空格 10 → 当天定性钓鱼日，**不再出现任何 mine 动作**。昨天 store_items 到 (74,15) 与 ship_produce 到 (70,15) 均 could not reach，今天**不指定坐标**，让系统自动找可达箱子/出货箱。
2. **熔炉投料先确认双条件**：起床先读炉状态。若任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则跳过 load 先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。**load 每天 ≤1 次，12:00 前完成。** 昨天铁矿石仅 4 就调 load 空转，今天铁矿石<5 时**物理删除 load 分支**。
3. **下矿食物门槛 ≥5**：下矿前食物必须 ≥5，不够先在 Forest 钓 1 轮（≤4 cast）补鱼当食物，再下矿。昨天 39 层因只有 4 个食物被拦，今天先补足再下。
4. **下矿用电梯直达 75 层**：goto Mine 后**电梯直达 75 层**，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。昨天两次从 35 层爬只拿到少量铁矿，今天**禁止从当前最深 86 层往下爬**，必须电梯到 75 层。
5. **升级窗口硬约束**：铁锭凑齐后必须在 **15:30 前**到 Blacksmith，16:00 后锁门。若 15:00 还没凑齐 5 铁锭，当天放弃升级，把时间给钓鱼/下矿。升级前读背包确认 Iron Bar ≥5 及现金 ≥5000。
6. **动作预算清理**：build_road、decorate、wait、donate、water_crops 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：若任一熔炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item= Iron Ore 1 次；返回 busy/no empty 即当天永久跳过 load。若两炉都在炼 → 跳过 load。铁矿石<5 → 跳过 load。
2. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
3. **清背包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine 分支。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. 体力 <15 或时间 ≥22:00 sleep；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **熔炉 load 优先于 collect**：起床先读炉状态，空炉且铁矿石≥5 立即 load；两炉都在炼才跳过 load。load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过。collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过。**不连续调 load。铁矿石<5 时物理删除 load 分支。**
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach/locked 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
2. collect_machines 1 次（收熔炉成品）
3. **清背包到空格 ≥10**（store_items 不指定坐标 + 读背包验证；不足则 ship_produce；两次不足即删 mine 分支）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach/locked 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 22:00 强制 sleep，**禁止 wait**


</details>

## ⚠️ 今日问题
> 昨天18动作7失败，核心堵点是背包0空格导致3次take、2次mine被拒，且store/ship指定旧坐标could not reach；熔炉因铁矿石仅4空转，钢锄头主线零推进。钓鱼4cast全成功是唯一稳定产出。今天必须先无坐标清包到≥10空格，再电梯75层拿铁矿，15:30前凑5铁锭升hoe。
- 16:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:00 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 18:00 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 18:00 动作 `goto_location` 失败 @ Farm — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: Copper Bar | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 19:00 动作 `take` 失败 @ Town — inventory full 〔自动〕
- 20:00 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 22:00 动作 `mine` 失败 @ Forest — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 背包全天 0 空格，3 次 take 和 2 次 mine 被拒，清包动作指定旧坐标 could not reach @ Farm 箱子/出货箱 → Mine — take -> FAIL: inventory full；mine -> need at least 5 free backpack slots；store_items/ship_produce 到 (74,15)/(70,15) could not reach（做不了：下矿拿铁矿路径被堵死，钢锄头主线零推进） 〔复盘〕
- 熔炉因铁矿石仅 4 无法投料，全天没炼出铁锭 @ Farm 熔炉 — load_machines -> no empty machine accepts anything（铁矿石<5 空转）（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 下午 18:00 去博物馆被锁门，白跑一趟 @ ArchaeologyHouse — goto_location -> exit did not open (Open 8:00am - 6:00pm)（做不了：浪费 1 个动作预算，博物馆捐赠/任务无法推进） 〔复盘〕
- donate 时背包里没有收集包需要的物品，空捐 0 产出 @ Community Center — donate -> nothing in the backpack is needed by an open bundle（做不了：社区中心收集包无法推进） 〔复盘〕
- 下矿到 86 层背包近满被迫离开，只拿 2 层矿 @ Mine 84-86 层 — mine -> backpack nearly full: store items before mining again; left the mine to recover（做不了：铁矿石只拿到 4，铁锭产出为零） 〔复盘〕
- 22:00 后仍安排 3 个收尾动作到 23:10 才睡 @ Farm — store_items/ship_produce/collect_machines 在 22:00-23:10 执行（做不了：压缩次日体力，且收尾动作本可提前到 21:30 前） 〔复盘〕
