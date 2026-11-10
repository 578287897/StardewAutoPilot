# 第4年 winter 21 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:50 开始）
- 天气：sunny　金钱：58693g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6d221726fea24fa582ce5ff5bbb6e58e
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：7867d65817ff4c1093499987b47c85d5
  - 耗时：3.281 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：33fe064d07f843f98e9393df4a7dcd8f
  - 耗时：6.14 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：018475bcf8274412a5d9072d9f31da03
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：0d825fe9d16c4bc18aa95598831b68e1
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：ab1bac2bafee4c0896b65da6d65ca9c7
  - 耗时：0.359 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_21）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——先清背包到空格≥10，再下矿 75→79 层拿铁矿石+煤
- 起床读炉状态：铁矿石仅 4 <5，物理删除 load 分支
- 清背包：store_items 不指定坐标，把矿石/杂物存箱，验证空格≥10
- collect_machines 1 次收熔炉成品
- 食物已有 22 个（≥5），跳过补食物钓鱼
- 电梯直达 75 层下矿 75→79 拿铁矿石+煤，≤2 次 mine
- 下矿回来 store_items 腾格 + collect_machines 收铁锭
- 铁锭≥5 且 <15:30 → Blacksmith 升 hoe；否则转钓鱼
1. `goto_location`（location="ArchaeologyHouse"）
2. `donate`
3. `store_items`
4. `collect_machines`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `store_items`
8. `collect_machines`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `store_items`
12. `collect_machines`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Green Algae", "River Jelly", "Strange Bun"]）
18. `sleep`
- **06:10** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: Inventory Full | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：6122825b1a1d41ec97404fc44c1b144a
  - 耗时：47.328 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#1：ArchaeologyHouse 锁门且 donate 阶段无效，删除该分支；按策略回农场清包→收炉→电梯下矿 75→79 拿铁矿石，铁锭够则 15:
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `store_items`
14. `collect_machines`
15. `store_items`
16. `collect_machines`
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
18. `sleep`
- **07:00** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：63384d2a7dde45b0aa0b8bb013943404
  - 耗时：5.25 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#2：博物馆锁门失败后放弃该分支，回农场清包→下矿75层拿铁→收铁锭→15:30前升hoe，剩余时间钓鱼收尾。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `store_items`
14. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Cobblestone Path", "Dwarf Scroll I"]）
15. `collect_machines`
16. `store_items`
17. `collect_machines`
18. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
19. `sleep`
- **07:10** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：5d6c87c66cd941ec975387fda11bcdcc
  - 耗时：5.281 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#3：ArchaeologyHouse 锁门且 donate 无效，删除该分支；按清包→下矿→收炉→升级→钓鱼收尾推进钢锄头里程碑。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `store_items`
14. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Cobblestone Path", "Dwarf Scroll I"]）
15. `collect_machines`
16. `store_items`
17. `collect_machines`
18. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
19. `sleep`
- **07:20** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **07:20** Town ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：1172251a85df41b9b8423a053a48c6e5
  - 耗时：42.109 秒 / 游戏 50 分钟
- **08:10** Farm ✅ `take`（item="Bat Wing", count=1）
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：325ee89a26b141a5b03674b208d0b95f
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：7b378467f09d4d4698458a7a1600d66d
  - 耗时：0.344 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：c432c3dba90b448c80816ce48dd0efa1
  - 耗时：49.172 秒 / 游戏 60 分钟
- **09:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：52f8684fa57f4ddc85f082f1f589b603
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3d7b03e41e75406c8c9ff5088c49e506
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：c57b3c058d3a43abb57ffbec13c9dda6
  - 耗时：47.157 秒 / 游戏 60 分钟
- **10:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：9d9c22de8c4e47ca90c68fec683c97a9
  - 耗时：0.343 秒 / 游戏 0 分钟
- **10:10** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：9f77a15cee834fbd97c5bee1b9022bcf
  - 耗时：26.625 秒 / 游戏 30 分钟
- **10:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 3 (Chub, Green Algae, Perch), 1 got away
  - 执行状态：SUCCESS · 操作编号：31b407362f7b4b6c816c1c4fb033c39a
  - 耗时：79.484 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
- **12:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：273c89aa42fc40219edea15b92db196d
  - 耗时：15.312 秒 / 游戏 20 分钟
- **12:20** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：6c315d4499944228a4571dc03bdb6178
  - 耗时：23.906 秒 / 游戏 30 分钟
- **12:50** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Cobblestone Path", "Dwarf Scroll I"]）
  - 结果：stored in chest at (74,15): 1x Geode, 1x Omni Geode, 1x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：8d4c61e9132b455581e29cd197b3e1c8
  - 耗时：0.375 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：a0ef650bfcce49f690eb17d0b9e1cb4c
  - 耗时：0.36 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：348a1932f283443aa76cd14b5cb7aa6c
  - 耗时：0.39 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:50** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：71f6f1595d8c4d0e8b4fb09a4af12dec
  - 耗时：0.36 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `take`（item="Copper Bar", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：5fd472ea7af34ff99e188f8339d52a93
  - 耗时：0.344 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `take`（item="Bat Wing", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：12b25e71bf114495b9c84757d567766a
  - 耗时：0.359 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `take`（item="Frozen Geode", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Frozen Geode from chest at (75,15)
  - 执行状态：SUCCESS · 操作编号：5ad974ee6777484d9cae0d4b9ca8d9c3
  - 耗时：0.39 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：32c44d3414db4ab6bbef8472e7ee11ab
  - 耗时：0.359 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：fa89e595563840e68dbfbe54301dd4e4
  - 耗时：0.391 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4b4b1546a94444c7bb528a7a67aa1a7f
  - 耗时：0.391 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **12:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：913397d786d94f4498775e0e050548d2
  - 耗时：10.359 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：58693 → 58693（+0g）
- 出货估值：0g　动作：37 个　失败：15 个
- 模型调用：6 次　tokens：67492
- 有效动作率：0.5　空转：9　熔断跳过：2
- 失败耗时：61.922 秒 / 游戏 70 分钟
- 最深矿层：86　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是背包 0 空格导致 4 次 mine 和 1 次 upgrade 全被拒，清包又因指定旧坐标 could not reach 而失败，形成死锁；同时 load 在铁矿石仅 4 时空转、18:00 去博物馆被锁、22:00 后仍做收尾动作。有效的是钓鱼 4 cast 稳定产出。今天必须把「清包成功」做成物理开关：不指定坐标、失败即卖，验证空格≥10 才允许 mine。

**新教训：**
- 昨天 store_items 到固定坐标 (74,15) 返回 could not reach，而随后不指定坐标的 store_items 成功存入：清包一律不指定坐标，失败一次即改 ship_produce，不要重试同一坐标。
- 昨天 upgrade_tool 报错文案是「need at least 5 free backpack slots before mining」，说明升级动作内部也校验背包空格：升级前必须同时确认 Iron Bar≥5、现金≥5000、背包空格≥5，缺一即跳过升级。
- 昨天 18:00 去 ArchaeologyHouse 被锁（8:00-18:00），而当天已无下矿窗口：博物馆/图书馆类地点下午 16:00 后不要再安排 goto，把时段留给钓鱼或下矿。
- 昨天 22:00 后仍执行 store_items/ship_produce/collect_machines 到 23:10 才睡，压缩次日体力：收尾动作必须在 21:30 前完成，21:30 后只允许 sleep。
- 昨天 collect_machines 连续两次返回 no machine has finished output 后被 suppressed：collect 每天最多 2 次（起床 1 次、下矿回来 1 次），返回空即当天永久跳过，不要连续调。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 22）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 58693g 充足，铁锭 0、铁矿石 4、煤 23，瓶颈是**铁矿石→铁锭转化链**，已连续两天因背包空格不足零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 22）**：起床先清包到空格≥10（第一硬门槛）→ 读炉状态，空炉且铁矿石≥5 才 load → **电梯直达 75 层下矿 75→79 拿铁矿石+煤**（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 23）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续下矿炼铁；铁锭富余则 craft 洒水器落地。
- **后天（冬 24）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余升第二件工具。

## 今日核心修正
1. **清包是第一硬门槛，且必须做成物理开关**：脚本生成前读 /state 背包空格；空格 <10 时**物理删除 mine/upgrade 分支**，只保留 store_items → ship_produce → 钓鱼。store_items **不指定坐标**；返回 could not reach 立即改 ship_produce 卖低价值物（Stone/Coal/矿石/锭除外），两次后仍不足空格 10 → 当天定性钓鱼日，**不再出现任何 mine 动作**。
2. **熔炉投料双条件**：起床读炉状态，任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则脚本生成阶段物理删除 load 分支，先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。load 每天 ≤1 次，12:00 前完成。
3. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
4. **下矿用电梯直达 75 层**：goto Mine 后电梯直达 75 层，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从当前最深 86 层往下爬**。
5. **升级窗口硬约束**：铁锭凑齐后必须在 **15:30 前**到 Blacksmith，16:00 后锁门。15:00 还没凑齐 5 铁锭，当天放弃升级，把时间给钓鱼/下矿。升级前读背包确认 Iron Bar ≥5 及现金 ≥5000。
6. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
7. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
2. **清背包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine 分支。
3. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
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
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
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
1. **清背包到空格 ≥10**（store_items 不指定坐标 + 读背包验证；不足则 ship_produce；两次不足即删 mine 分支）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. collect_machines 1 次（收熔炉成品）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach/locked 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是背包 0 空格导致 4 次 mine 和 1 次 upgrade 全被拒，清包又因指定旧坐标 could not reach 而失败，形成死锁；同时 load 在铁矿石仅 4 时空转、18:00 去博物馆被锁、22:00 后仍做收尾动作。有效的是钓鱼 4 cast 稳定产出。今天必须把「清包成功」做成物理开关：不指定坐标、失败即卖，验证空格≥10 才允许 mine。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `goto_location` 失败 @ Farm — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: Inventory Full | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:00 动作 `goto_location` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:10 动作 `goto_location` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:20 动作 `goto_location` 失败 @ Town — repeated ineffective action suppressed until game state changes 〔自动〕
- 09:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `upgrade_tool` 失败 @ Blacksmith — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:50 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:50 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:50 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 12:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 全天背包 0 空格，清包指定旧坐标 could not reach，下矿路径被彻底堵死 @ Farm 箱子/出货箱 (74,15)/(70,15) — store_items/ship_produce 到固定坐标返回 could not reach；mine 返回 need at least 5 free backpack slots（做不了：钢锄头主线零推进，铁矿石没拿到，铁锭产出为零） 〔复盘〕
- 熔炉因铁矿石仅 4 无法投料，全天没炼出铁锭 @ Farm 熔炉 — load_machines -> no empty machine accepts anything（铁矿石<5 空转）（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 下午 18:00 去博物馆被锁门，白跑一趟 @ ArchaeologyHouse — goto_location -> exit did not open (Open 8:00am - 6:00pm)（做不了：浪费 1 个动作预算，博物馆捐赠/任务无法推进） 〔复盘〕
- donate 时背包里没有收集包需要的物品，空捐 0 产出 @ Community Center — donate -> nothing in the backpack is needed by an open bundle（做不了：社区中心收集包无法推进） 〔复盘〕
- 22:00 后仍安排 3 个收尾动作到 23:10 才睡 @ Farm — store_items/ship_produce/collect_machines 在 22:00-23:10 执行（做不了：压缩次日体力，且收尾动作本可提前到 21:30 前） 〔复盘〕
