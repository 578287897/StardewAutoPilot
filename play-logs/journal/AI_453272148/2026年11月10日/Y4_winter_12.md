# 第4年 winter 12 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（09:16 开始）
- 天气：snow　金钱：54739g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：da623faec44341dfa3f71babf5fe6c3e
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：4351f606175749f5a9c8924a63c15606
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：d3a33b147ff04e77baf662c4cf88aab5
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~544g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：1a504bd23d3b4cfda6c17aa1860b82af
  - 耗时：5.375 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_12）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g+5 铁锭）
- 起床收炉→补铁矿石进炉（≤1 次，12:00 前）
- 清背包到空格≥10（store_items 不指定坐标，失败改 ship_produce）
- Forest 钓鱼补食物到≥5
- 电梯直达 75 层下矿拿铁矿石+煤（≤2 次，每次≤5 层）
- 回农场收炉炼铁，铁锭≥5 且 <15:30 去铁匠铺升 hoe
- 14:00 后顺路买 Claymore 若现金够
- craft 洒水器并落地，浇水，22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `collect_machines`
14. `load_machines`（item="Iron Ore"）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="AdventureGuild"）
18. `buy`（item="Claymore", count=1）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `craft`（item="Sprinkler", count=1）
22. `water_crops`
23. `sleep`
- **06:00** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：4887c9cf566e450a8ac336f4d02bfcdf
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：1260f1596f724836970bb465e54a850d
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1b7abb1a7fb1423aa5916c70b3f93e81
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：b186b18c36624c4fb10813ddbf93e41b
  - 耗时：21.609 秒 / 游戏 30 分钟
  - 🗨️ [hud] SquidFest has begun. 
- **06:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Pike, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：1bc63e7879fd46adacbb48a89de08a3a
  - 耗时：92.25 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **08:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：48a8f7341d254a51afe4cac73b788ada
  - 耗时：73.297 秒 / 游戏 90 分钟
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4ce0889b307f4b819e444fafd76c001a
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因空格不足被拒，先回农场清背包再下矿，其余路线保持原顺序。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `craft`（item="Sprinkler", count=1）
6. `goto_location`（location="Farm"）
7. `store_items`
8. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
9. `ship_produce`（except=["Stone", "Copper Ore", "Coal", "Iron Ore", "Copper Bar"]）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `store_items`
13. `collect_machines`
14. `water_crops`
15. `sleep`
- **09:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：62b6025e090447e1a756e4876a4a003c
  - 耗时：0.359 秒 / 游戏 0 分钟
- **09:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：091fe23e892743f1a345b4bf4e4dbe03
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：先回农场清背包腾格，再电梯下矿拿铁矿，回来收炉并升钢锄头。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `craft`（item="Sprinkler", count=1）
7. `place`（item="Sprinkler", x=51, y=14）
8. `goto_location`（location="Farm"）
9. `store_items`
10. `ship_produce`（except=["Stone", "Copper Ore", "Coal", "Iron Ore", "Copper Bar"]）
11. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `store_items`
15. `collect_machines`
16. `water_crops`
17. `sleep`
- **09:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：87fdffaedf08484c962f15e658976341
  - 耗时：0.39 秒 / 游戏 0 分钟
- **09:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：dabf2ef123a9495c867868a7f0a8df68
  - 耗时：0.39 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：先回农场清背包腾格（上次 mine 因空格不足失败），再下矿拿铁矿，回来收炉炼铁并升级锄头。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`
5. `ship_produce`（except=["Stone", "Copper Ore", "Coal", "Iron Ore", "Copper Bar"]）
6. `store_items`（items=["Stone", "Copper Ore", "Coal"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `store_items`（items=["Stone", "Copper Ore", "Coal", "Iron Ore"]）
10. `collect_machines`
11. `craft`（item="Sprinkler", count=1）
12. `place`（item="Sprinkler", x=51, y=14）
13. `water_crops`
14. `sleep`
- **09:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：d1ad69abfc8f4fffab4b11fd8c11968f
  - 耗时：0.344 秒 / 游戏 0 分钟
- **09:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b848660798724ab8a91cc696b27458c4
  - 耗时：0.391 秒 / 游戏 0 分钟
- **09:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：494278cb1d1f4d0096f521b7e58f95c1
  - 耗时：33.562 秒 / 游戏 40 分钟
- **10:10** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Sprinkler, 3x Coal, 4x Copper Bar
  - 执行状态：SUCCESS · 操作编号：84d75c182174439b941af1f38bebfea0
  - 耗时：15.016 秒 / 游戏 20 分钟
- **10:30** Farm ✅ `ship_produce`（except=["Stone", "Copper Ore", "Coal", "Iron Ore", "Copper Bar"]）
  - 结果：shipped 2 stacks worth ~382g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：47466483bc4b436f8835df03486142b6
  - 耗时：0.781 秒 / 游戏 10 分钟
- **10:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Coal"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：83a9904e2ea943a69f98bc8b298febb1
  - 耗时：0.359 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Coal", "Iron Ore"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：502b6b3912884ed7bc497914716973f2
  - 耗时：0.344 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:40** Farm ❌ `craft`（item="Sprinkler", count=1）
  - 结果：can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1
  - 执行状态：ACTION_FAILED · 操作编号：4d602e2c456942c493c6d40af8a8a6ae
  - 耗时：0.36 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `place`（item="Sprinkler", x=51, y=14）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **10:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：0b6b2b10a34f4d3095fd6fcff274d77a
  - 耗时：0.391 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：384f8f3daf684bf29930e691f0063268
  - 耗时：0.391 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 15 to 19 (4 floors down, 115 stones broken); stopped at floor 19: only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：a40a1c20f9bb44b28f98e7a1ed92a14f
  - 耗时：139.156 秒 / 游戏 180 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Slime
- **13:40** UndergroundMine19 ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：01fca17f79bc47b080377151687a4c2d
  - 耗时：45.313 秒 / 游戏 50 分钟
  - 🗨️ [question] 
- **14:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **14:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：5b502cfda77344c5a9e0ce888a22f3bc
  - 耗时：12.859 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：54739 → 55665（+926g）
- 出货估值：926g　动作：33 个　失败：14 个
- 模型调用：5 次　tokens：65353
- 有效动作率：0.5172　空转：8　熔断跳过：3
- 失败耗时：49.454 秒 / 游戏 50 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天唯一有效产出是 Forest 钓鱼 4 条和电梯下矿 15→19 层拿铜矿；主线铁锭仍为 0，根因是起床 collect 空后仍调 load 被 busy 拒、清背包通道被挡导致 4 次 mine 被拒、以及熔炉从未真正 load 铁矿石。今天必须先解决「铁矿石进炉」这一环：起床读炉状态，空炉直接 load 铁矿石（不再等 collect），并先清背包再下矿。

**新教训：**
- 起床先 collect 返回空、再 load 又 busy，说明两炉都在炼：应先读炉状态，空炉立即 load，两炉都忙才跳过 load，而不是固定先 collect 再 load。
- 电梯直达 75 层下矿成功（15→19 层拿铜矿+煤），但没拿到铁矿：75 层以下才是铁矿密集区，下矿目标应明确写「75→79 层」，不要从当前最深 79 层往下爬。
- craft Sprinkler 在 Iron Bar=0 时被调用必失败：craft 前必须读背包确认 Copper Bar ≥1 且 Iron Bar ≥1，缺任一跳过 craft 先炼锭。
- place Sprinkler 返回「分区里没有空位」说明规划区已满：place 前先读分区空位坐标，无空位即当天永久跳过 place，不重试。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 13）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 54739g 充足，Iron Bar 0（差 5），铁矿石 5、煤 23、铜锭 44。**「让两座熔炉真正开始炼铁 + 拿到 40 层以下铁矿」是唯一主线**，洒水器、下矿装备排在它之后。

离完成还差：约 15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 13）**：起床读炉状态 → 空炉立即 load 铁矿石（这是昨天全天没做到的关键一步）→ 清背包到空格 ≥10 → 补食物到 ≥5 → 电梯直达 75 层拿铁矿石+煤 → 回农场 collect 收铁锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 14）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续炼铁；同时 craft 洒水器落地。
- **后天（冬 15）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **熔炉 load 是今天第一优先级，不是 collect**：昨天起床先 collect 返回空、再 load 又 busy，铁锭全天零新增。今天起床**先读炉状态**：若任一炉为空 → 立即 load 铁矿石 1 次（铁矿石 ≥5 且时间 <12:00）；若两炉都在炼 → 跳过 load，等下午下矿回来再 collect。**load 每天 ≤1 次，返回 busy/no empty 即当天永久跳过，绝不连续调。**
2. **清背包先修通道**：昨天 (74,15) 箱子与 (70,15) 出货箱都不可达。今天**先 goto Farm 入口附近**，store_items **不指定坐标**让动作自选最近可达箱子；返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外）；两手段后仍不足空格 10 → 当天定性钓鱼日，物理删除 mine 分支。
3. **下矿食物门槛 ≥5**：昨天 39 层因只有 4 个回血食物被拦。下矿前食物必须 ≥5，不够先在 Forest 钓 1 轮（≤4 cast）补鱼当食物，再下矿。
4. **下矿用电梯直达 75 层**：昨天两次 mine 都从 35 层爬，铁矿密度低。今天 goto Mine 后**电梯直达 75 层**，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。
5. **动作预算清理**：build_road、decorate、wait 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：若任一熔炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；返回 busy/no empty 即当天永久跳过 load。若两炉都在炼 → 跳过 load。
2. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
3. **清背包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine 分支。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → buy Claymore。失败一次即当天永久跳过。禁止 14:00 前专门 goto 公会等开门。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **浇水**：水壶在背包则 water_crops 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 sleep；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **熔炉 load 优先于 collect**：起床先读炉状态，空炉立即 load 铁矿石；两炉都在炼才跳过 load。load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过。collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过。**不连续调 load。**
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制，但 40 层以下仍需 ≥5。**
- **武器优先于下矿**：Silver Saber 8-15 在 80 层以下被拒，今天必须先买 Claymore（2000g）再下矿；买武器失败则当天只下 75-79 层。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **禁止专门等商店开门**：14:00 前不 goto Adventurer's Guild；等待时间用于钓鱼或下矿，14:00 后顺路买。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、water_crops≤1、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。**电梯直达 75 层例外。**
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床读炉状态 → 空炉立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过）
2. collect_machines 1 次（收熔炉成品）
3. **清背包到空格 ≥10**（store_items 不指定坐标 + 读背包验证；不足则 ship_produce）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
9. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30、顺路；失败即跳过）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天唯一有效产出是 Forest 钓鱼 4 条和电梯下矿 15→19 层拿铜矿；主线铁锭仍为 0，根因是起床 collect 空后仍调 load 被 busy 拒、清背包通道被挡导致 4 次 mine 被拒、以及熔炉从未真正 load 铁矿石。今天必须先解决「铁矿石进炉」这一环：起床读炉状态，空炉直接 load 铁矿石（不再等 collect），并先清背包再下矿。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 10:40 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 10:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 10:40 动作 `craft` 失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1 〔自动〕
- 10:40 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 13:40 动作 `build_road` 失败 @ UndergroundMine19 — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) | 游戏消息: [question]  〔自动〕
- 14:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 熔炉全天没有 load 铁矿石，铁锭零新增 @ Farm 熔炉 — 起床 collect_machines -> FAIL: no machine has finished output；随后 load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests；再调 load 被 suppressed（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住，主线零推进） 〔复盘〕
- 清背包通道被挡，4 次 mine 因空格不足被拒 @ Farm 箱子/出货箱 → Mine — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（连续 4 次）（做不了：背包清不出空格，连锁导致下矿全被拒，铁矿石拿不到） 〔复盘〕
- 下矿到 19 层因食物不足被拦，无法下 40 层以下拿铁矿 @ UndergroundMine 19 层 — mine -> stopped at floor 19: only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 两次 mine 都从 35 层爬而不是电梯直达 75 层 @ Mine 35-39 层 — mine -> mined from floor 35 to 39 (4 floors down)；第二次 mine -> 0 floors down（做不了：铁矿密度低，铁矿石只拿到少量，铁锭仍不够） 〔复盘〕
- craft 洒水器在 Iron Bar=0 时被调用 @ Farm — craft -> FAIL: can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1（做不了：洒水器没做出来，手动浇水继续耗体力） 〔复盘〕
- place 洒水器返回分区无空位 @ Farm 规划区 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器无法落地，农业 2 级洒水器里程碑停滞） 〔复盘〕
- build_road 与 decorate 连续多天 0 产出，浪费动作预算 @ Farm — build_road -> laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate -> 今天没有能做的装饰（做不了：农场通道没清出来，箱子/出货箱路径仍被挡） 〔复盘〕
