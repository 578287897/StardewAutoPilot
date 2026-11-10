# 第4年 winter 22 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:57 开始）
- 天气：snow　金钱：58693g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6658de8bde5d4a8180bf71b434b15bab
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：1a53ad0df6c949e7be13a7d1bee068e7
  - 耗时：3.281 秒 / 游戏 0 分钟
  - 🗨️ [hud] The Bookseller is in 
town today. 
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing, 1x Coal
  - 执行状态：SUCCESS · 操作编号：6fc4e6a79a7e45ba8585477190cd6e38
  - 耗时：6.078 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：ba3b3027e9db41e8b038d83a9dcba373
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：9e99af4a10eb49e39bd3641c9ee46288
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：816814250dcd405bb15fa444020310e8
  - 耗时：0.343 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_22）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床先清背包到空格≥10（store_items 不指定坐标 + ship_produce 卖低价值物），这是下矿和升级的硬门槛
- 铁矿石仅 4，物理删除 load 分支，先去矿洞拿铁矿
- 电梯直达 75 层下矿 75→79 拿铁矿石+煤（≤2 次 mine，每次≤5 层）
- 回农场 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 铁锭不够就转 Forest 钓鱼补时间，21:30 前 sleep
1. `goto_location`（location="ArchaeologyHouse"）
2. `donate`
3. `store_items`
4. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword"]）
5. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Cobblestone Path", "Dwarf Scroll I", "Clay", "Fiber"]）
6. `collect_machines`
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
10. `mine`（floors=4）
11. `goto_location`（location="Farm"）
12. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
13. `collect_machines`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
19. `sleep`
- **06:10** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: The Bookseller is in 
town today.  | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：7cd0ca7b67444e6da81d9be1e17b4a24
  - 耗时：47.36 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#1：ArchaeologyHouse 锁门失败，改回农场清包后按原路线下矿拿铁矿、收铁锭、15:30 前升 hoe，余时钓鱼收尾。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=4）
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `goto_location`（location="Farm"）
13. `store_items`
14. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword"]）
15. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber", "Cobblestone Path"]）
16. `collect_machines`
17. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
18. `collect_machines`
19. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
20. `sleep`
- **07:00** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：e8a174e1ed9f47b8bfe09095326d4d3f
  - 耗时：5.25 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#2：ArchaeologyHouse 锁门且 donate 无效，删除该分支；按策略清包→下矿75层→收铁锭→15:30前升hoe，失败即转钓鱼收尾。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword"]）
14. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber", "Cobblestone Path"]）
15. `collect_machines`
16. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
17. `collect_machines`
18. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
19. `sleep`
- **07:10** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：1460278580464c87b3ab811c7244f90a
  - 耗时：5.282 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#3：ArchaeologyHouse 锁门且 donate 在 wait_letter 阶段无效，删除该分支，改回农场清包→电梯下矿→收铁锭→升 hoe 
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword"]）
14. `collect_machines`
15. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
16. `collect_machines`
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
18. `sleep`
- **07:20** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **07:20** Town ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：64b62c3601bc47b49d215889cb9700e9
  - 耗时：42.093 秒 / 游戏 50 分钟
- **08:10** Farm ✅ `take`（item="Bat Wing", count=1）
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：891bc82775374db9ad69f882e2c99572
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：06e7b41179a944fca4129695ce03df87
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a9eb8e60c69841ae8f576af731e34a61
  - 耗时：48.547 秒 / 游戏 60 分钟
- **09:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：cb0da83a85f344d98541a32cd347464a
  - 耗时：0.39 秒 / 游戏 0 分钟
- **09:10** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：cf014c834f8849b7bf2581559a6ed6bd
  - 耗时：48.921 秒 / 游戏 60 分钟
- **10:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：dc8619a8115e449890619e7f51f7f293
  - 耗时：0.359 秒 / 游戏 0 分钟
- **10:10** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：e657dfbe94214046ad73a07a67c76a7c
  - 耗时：26.609 秒 / 游戏 30 分钟
- **10:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Lingcod, Tiger Trout, Chub)
  - 执行状态：SUCCESS · 操作编号：523b95d7ff844b0096cf1010ebbdadbd
  - 耗时：108.562 秒 / 游戏 110 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Lingcod
  - 🗨️ [hud] Tiger Trout
- **12:30** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：d6f59b79ba5a47cdad740bd8f1578437
  - 耗时：15.297 秒 / 游戏 20 分钟
- **12:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：f97d5e49b19049df8c053bb6027d02a7
  - 耗时：23.906 秒 / 游戏 30 分钟
- **13:20** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword"]）
  - 结果：shipped 2 stacks worth ~405g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：c4e57c9f50e24f868b42786af59d84a6
  - 耗时：0.688 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：37b16bcac6f44e9586bc9ad6840166e7
  - 耗时：0.344 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
  - 结果：stored in chest at (74,15): 1x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：f9074bfa1e834f46bf9705a7f0c5bd78
  - 耗时：0.359 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **13:20** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：328d6e03603e49419fb9e73c30db944d
  - 耗时：0.344 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `take`（item="Copper Bar", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：0532896db1e54225b2da6bc87cd32fc7
  - 耗时：0.359 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `take`（item="Bat Wing", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：8629daeee5844d4e87fae295dbada65f
  - 耗时：0.375 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `take`（item="Frozen Geode", count=1, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：took 1x Frozen Geode from chest at (75,15)
  - 执行状态：SUCCESS · 操作编号：5d6595c97c36494aa0817cb32987b34b
  - 耗时：0.797 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：c0e4564a290f4d32aa5fe3e060dc2332
  - 耗时：0.36 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：70ef36cb2f2a426f99402c0bd8cf21cb
  - 耗时：0.375 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：7acf15082ab7489faff0508c91bf0df4
  - 耗时：0.438 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **13:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **13:20** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4e53c102d62749ab9dddb601c78e2f13
  - 耗时：10.297 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：58693 → 59098（+405g）
- 出货估值：405g　动作：36 个　失败：14 个
- 模型调用：6 次　tokens：67786
- 有效动作率：0.5152　空转：9　熔断跳过：2
- 失败耗时：61.641 秒 / 游戏 70 分钟
- 最深矿层：86　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
连续两天零推进的根因不是策略方向错，而是「清包」这一步从未真正成功：store_items 指定旧坐标失败、take 又把东西取回背包，形成取-存循环，背包始终 0 空格，mine/upgrade 全被拒。同时铁矿石仅 4 导致熔炉空转，铁锭链断。今天必须把清包做成一次性、可验证、不可回退的动作，并禁止任何 take 回填。

**新教训：**
- 昨天 take 5 次（Copper Bar/Bat Wing/Frozen Geode）把刚 store 进箱子的东西又取回背包，是背包始终 0 空格的直接原因：清包成功后当天必须禁止任何 take，取物只在空格≥3 且明确需要该物品时安排。
- 昨天 upgrade_tool 报错文案与 mine 相同（need at least 5 free backpack slots），说明升级动作内部也校验背包空格：升级前必须同时确认 Iron Bar≥5、现金≥5000、空格≥5，缺一即跳过。
- 昨天 3 次 goto ArchaeologyHouse 在 18:00 后全部被锁（Open 8:00am-6:00pm），且 donate 也 0 产出：wait_letter 阶段博物馆/社区中心类地点应整体从脚本删除，等巫师来信后再恢复。
- 昨天 collect_machines 两次返回 no machine has finished output 后被 suppressed：collect 每天最多 2 次（起床 1 次、下矿回来 1 次），返回空即当天永久跳过，不要连续调。
- 昨天全天 36 个动作里 14 个失败、有效动作 17 个，而钓鱼 4 cast 全成功：背包满/铁矿石不足时应在 1 个动作内转钓鱼，把下矿留到清出空格后的第二天，不要在同一天反复尝试。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 23）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 58693g 充足，铁锭 0、铁矿石 4、煤 23，瓶颈是**铁矿石→铁锭转化链**，已连续两天因背包空格不足零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 23）**：起床先做**一次性清包**（store_items 不指定坐标 + ship_produce 卖低价值物，禁止任何 take 回填），验证空格≥10 → 读炉状态，空炉且铁矿石≥5 才 load → **电梯直达 75 层下矿 75→79 拿铁矿石+煤**（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 24）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续下矿炼铁；铁锭富余则 craft 洒水器落地。
- **后天（冬 25）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余升第二件工具。

## 今日核心修正
1. **清包是一次性、不可回退的动作链**：起床第一件事 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证空格≥10。**清包成功后全天禁止任何 take 动作**（昨天 take 5 次把刚存的东西取回，直接导致 0 空格）。空格 <10 且两次清包无效 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **熔炉投料双条件**：起床读炉状态，任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则脚本生成阶段物理删除 load 分支，先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。load 每天 ≤1 次，12:00 前完成。
3. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
4. **下矿用电梯直达 75 层**：goto Mine 后电梯直达 75 层，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从当前最深 86 层往下爬**。
5. **升级窗口硬约束**：铁锭凑齐后必须在 **15:30 前**到 Blacksmith，16:00 后锁门。15:00 还没凑齐 5 铁锭，当天放弃升级，把时间给钓鱼/下矿。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**（upgrade_tool 内部也校验空格）。
6. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
7. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
2. **一次性清包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
3. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。昨天 take 5 次把刚存的东西取回是零推进的直接原因。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take≤0（清包后）**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **一次性清包到空格 ≥10**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. collect_machines 1 次（收熔炉成品）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 连续两天零推进的根因不是策略方向错，而是「清包」这一步从未真正成功：store_items 指定旧坐标失败、take 又把东西取回背包，形成取-存循环，背包始终 0 空格，mine/upgrade 全被拒。同时铁矿石仅 4 导致熔炉空转，铁锭链断。今天必须把清包做成一次性、可验证、不可回退的动作，并禁止任何 take 回填。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `goto_location` 失败 @ Farm — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: The Bookseller is in 
town today.  | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:00 动作 `goto_location` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:10 动作 `goto_location` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm) | 游戏消息: [dialogue] It's locked... (Open 8:00am - 6:00pm) 〔自动〕
- 07:20 动作 `goto_location` 失败 @ Town — repeated ineffective action suppressed until game state changes 〔自动〕
- 09:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `upgrade_tool` 失败 @ Blacksmith — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 13:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 13:20 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:20 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 13:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包链条反复失败，背包始终 0 空格，下矿和升级全被拒 @ Farm 箱子/出货箱 (74,15)/(70,15) — store_items 指定旧坐标返回 could not reach；随后 take 又把刚存的东西取回；mine 返回 need at least 5 free backpack slots（做不了：钢锄头主线零推进，铁矿石没拿到，铁锭产出为零） 〔复盘〕
- 熔炉因铁矿石仅 4 无法投料，全天没炼出铁锭 @ Farm 熔炉 — load_machines -> no empty machine accepts anything（铁矿石<5 空转）（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 下午 18:00 去博物馆被锁门，白跑一趟 @ ArchaeologyHouse — goto_location -> exit did not open (Open 8:00am - 6:00pm)（做不了：浪费 1 个动作预算，博物馆捐赠/任务无法推进） 〔复盘〕
- donate 时背包里没有收集包需要的物品，空捐 0 产出 @ Community Center — donate -> nothing in the backpack is needed by an open bundle（做不了：社区中心收集包无法推进） 〔复盘〕
- 22:00 后仍安排 3 个收尾动作到 23:10 才睡 @ Farm — store_items/ship_produce/collect_machines 在 22:00-23:10 执行（做不了：压缩次日体力，且收尾动作本可提前到 21:30 前） 〔复盘〕
- build_road 两次共 laid 0 格，decorate 也 0 产出 @ Farm — 规划道路边没有还能走上去的空格；今天没有能做的装饰（做不了：浪费 3 个动作预算，本可给钓鱼或下矿） 〔复盘〕
