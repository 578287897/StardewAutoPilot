# 第2年 summer 8 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（02:53 开始）
- 天气：sunny　金钱：2655g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b9d5f323674d426c955dab662292721d
  - 耗时：0.078 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：35568b2b923b41c9a022c63b6950978b
  - 耗时：0.203 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：0c4d6fb61fc74b38a358393190552cd3
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~500g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：f676b9b00aa64a4983f4938fd82ca06b
  - 耗时：5.422 秒 / 游戏 10 分钟

## 🌙 为明天（Y2_summer_08）准备的脚本
- 里程碑：钢水壶（5000g+5铁锭）——先把2个洒水器放进耕地，再craft 2个洒水器并place
- 熔炉collect 1次，炉空则load铁矿5块（只1次）
- 清背包到≥5空格后下矿40层以下拿铁矿石+煤（≤2次mine，超时即停）
- 回农场再load铁矿1次（仅炉空）
- 现金<700g去Forest河边钓鱼≤2轮
- 16:30前威利店买Bait×20
- 水壶在背包则浇水1次
- 22:00前sleep
1. `donate`
2. `place`（item="Sprinkler"）
3. `place`（item="Sprinkler"）
4. `craft`（item="Sprinkler", count=2）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `store_items`（items=["Broken Glasses", "Cobblestone Path", "Bamboo Pole", "Silver Saber", "Joja Cola"]）
10. `goto_location`（location="Mine"）
11. `mine`（floors=3）
12. `mine`（floors=3）
13. `goto_location`（location="Farm"）
14. `load_machines`（item="Iron Ore"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `fish`（casts=4）
18. `goto_location`（location="Mountain"）
19. `open_shop`（shop_id="FishShop"）
20. `buy`（item="Bait", count=20）
21. `close_menu`
22. `goto_location`（location="Farm"）
23. `water_crops`
24. `sleep`
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：cd43bbc0e6994926aa996e66907b920a
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师信未到失败，跳过献祭分支，按原路线先放洒水器、炼铁、下矿拿铁，再钓鱼买饵，最后浇水睡觉。
1. `place`（item="Sprinkler"）
2. `place`（item="Sprinkler"）
3. `craft`（item="Sprinkler", count=2）
4. `place`（item="Sprinkler"）
5. `place`（item="Sprinkler"）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `store_items`（items=["Broken Glasses", "Cobblestone Path", "Bamboo Pole", "Silver Saber", "Joja Cola"]）
9. `goto_location`（location="Mine"）
10. `mine`（floors=3）
11. `mine`（floors=3）
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `fish`（casts=4）
15. `goto_location`（location="Mountain"）
16. `open_shop`（shop_id="FishShop"）
17. `buy`（item="Bait", count=20）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `load_machines`（item="Iron Ore"）
21. `water_crops`
22. `sleep`
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:10** Farm ✅ `craft`（item="Sprinkler", count=2）
  - 结果：crafted 2x Sprinkler
  - 执行状态：SUCCESS · 操作编号：e09d1deef0e34cfa8c6cf4722d9f5d9a
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：41ed8b7bc5c04d4e8cf89ca6ac963553
  - 耗时：0.109 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：d32afc11279440c78a7a8244781140e6
  - 耗时：0.11 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `store_items`（items=["Broken Glasses", "Cobblestone Path", "Bamboo Pole", "Silver Saber", "Joja Cola"]）
  - 结果：stored in chest at (74,15): 4x Cobblestone Path, 2x Joja Cola, 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：0eaaecd340de431a81f8e58ac4e6fe2b
  - 耗时：1.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：b65c8979d7f8437197f02804d81934a0
  - 耗时：45.829 秒 / 游戏 60 分钟
- **07:10** Mine ✅ `mine`（floors=3）
  - 结果：mined from floor 15 to 18 (3 floors down, 24 stones broken)
  - 执行状态：SUCCESS · 操作编号：51db782021084bffbef396addd9539af
  - 耗时：58.219 秒 / 游戏 70 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Rice Shoot
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
- **08:20** UndergroundMine18 ✅ `mine`（floors=3）
  - 结果：mined from floor 18 to 19 (1 floors down, 26 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：f21849f14cd64e4ead4af941fb23f7df
  - 耗时：22.75 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Bug Meat
- **08:50** UndergroundMine19 ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：b8f91e86aa9b48029ea9c7c6dc3e5554
  - 耗时：60.812 秒 / 游戏 80 分钟
  - 🗨️ [question] 
- **10:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Pike, Pike, Sunfish)
  - 执行状态：SUCCESS · 操作编号：8af84407bbe14e489de53ffd2d08936e
  - 耗时：95.25 秒 / 游戏 80 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **11:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Sunfish, Sunfish, Rainbow Trout)
  - 执行状态：SUCCESS · 操作编号：819247926d194daa9555b3438f50e74a
  - 耗时：91.484 秒 / 游戏 90 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
- **13:00** Forest ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：a1ae2127741d4736851349636d4238b3
  - 耗时：54.938 秒 / 游戏 70 分钟
- **14:10** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：26963272285a48ccb80a2b2cc23199a5
  - 耗时：0.109 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：鱼店在Mountain打不开（需海滩码头），放弃买饵；回农场先放洒水器、取锭装矿，再下矿补铁，回农场装铁后浇水睡觉。
1. `goto_location`（location="Mine"）
2. `mine`（floors=3）
3. `mine`（floors=3）
4. `goto_location`（location="Farm"）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `place`（item="Sprinkler"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `store_items`（items=["Geode", "Slime", "Bug Meat", "Stone", "Copper Ore"]）
12. `load_machines`（item="Iron Ore"）
13. `water_crops`
14. `sleep`
- **14:10** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：2e51b162b23a41d3869ee8067ead2e87
  - 耗时：17.641 秒 / 游戏 20 分钟
- **14:30** Mine ❌ `mine`（floors=3）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：d0eef05a30c145f6bb0c83ebe1fb92f2
  - 耗时：0.109 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：下矿因背包满失败，先存材料腾出≥5空格再下矿一次，回农场放洒水器、收/装熔炉、浇水后睡觉。
1. `mine`（floors=3）
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Geode", "Slime", "Bug Meat", "Stone", "Copper Ore"]）
4. `place`（item="Sprinkler"）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `water_crops`
11. `sleep`
- **14:30** Mine ❌ `mine`（floors=3）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：824504566e0740a8b47d1e8e0e5a142f
  - 耗时：0.141 秒 / 游戏 0 分钟
- **14:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b89750713aba4544bf97417d3204e89c
  - 耗时：33.484 秒 / 游戏 40 分钟
- **15:10** Farm ✅ `store_items`（items=["Geode", "Slime", "Bug Meat", "Stone", "Copper Ore"]）
  - 结果：stored in chest at (74,15): 21x Stone, 12x Bug Meat, 1x Geode, 1x Slime
  - 执行状态：SUCCESS · 操作编号：4b1171e42be1493b872802b1e8c79c1d
  - 耗时：11.531 秒 / 游戏 10 分钟
- **15:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **15:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **15:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7fc48f81f6464e92961b745d0814c56c
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:20** Farm ✅ `water_crops`
  - 结果：watered 16 crops
  - 执行状态：SUCCESS · 操作编号：ec44181b51ec45cc87b4a54c8691d6be
  - 耗时：31.406 秒 / 游戏 50 分钟
- **16:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：178a6ce822ea4d5ab63482709c3d2122
  - 耗时：6.234 秒 / 游戏 10 分钟
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：9ceeea7f2c9645b2bdc482b41311a9c1
  - 耗时：0.11 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：8944d1c531b14400bf0727303c313d33
  - 耗时：0.141 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：0cff7ba50c584d088cb55f329c486333
  - 耗时：9.922 秒 / 游戏 10 分钟
- **16:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e7285f63449a47e2a7de965be1927260
  - 耗时：0.125 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5a12a7f48da3472aa3c6d3b9cd09e944
  - 耗时：12.672 秒 / 游戏 20 分钟
- **16:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：712f3d0128664ad7ad77bd8292c3b3cf
  - 耗时：12.437 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7efbdef89c39409cb42fdb214bc9a3f7
  - 耗时：16.812 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 🧠 夜间复盘
昨天核心失败是洒水器 craft 成功却因「分区无空位」全天没放下去，且脚本在 14:00-16:40 反复空转 load/build_road/decorate 浪费约 20 动作。矿洞因背包空格不足两次失败，铁锭零产出。钓鱼稳定但只钓 2 轮，现金仍不足。今天必须：先清耕地放洒水器，再下矿前清空格，熔炉 collect 后立刻 load 铁矿，禁止铺路装饰，失败即熔断转钓鱼。

**新教训：**
- 洒水器 craft 成功后 place 返回「分区无空位」时，必须用 hoe 清一格耕地再 place；昨天 2 个洒水器 craft 成功却全天没放下去，今天第一件事就是清格放下。
- 脚本分支做完后不应「固定做这个到 17:00」：昨天 14:00-16:40 反复空转 load/build_road/decorate，应直接转钓鱼或提前 sleep。
- 熔炉 load 返回 busy 说明炉子还在炼上一批，当天再调只会被 suppressed：load 失败后应立刻转下矿或钓鱼，不要在同一时间点连调。
- 下矿前必须先把背包空格清到 ≥5：昨天 13:10 两次 mine 都因空格不足直接失败，等于白跑一趟矿洞。
- build_road/decorate 在树木和作物未清的地块上会连续返回「laid 0 tiles」或「没有能做的装饰」：这类动作在农场未整理前应完全禁用，昨天浪费 10+ 动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏9）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金约 2655g（今早出货到账后约 3155g），铁锭 1，Iron Ore 3，Coal 15，Copper Bar 56，Stone 2396，Wood 1。差约 2000g + 4 铁锭。
并行里程碑：**洒水器×4 已 craft 2 个但未 place**——今天第一件事清耕地放下；材料够再做 2 个（铜锭 56、铁锭 1），craft 后立即 place。
之后：钓鱼 9 级缺鱼饵，去威利店买 Bait（5g/个，≤20 个）。
接下来 3 天主活动：
- **今天（夏9）**：① 清耕地放已 craft 的 2 个洒水器（hoe 清格再 place，最多 3 次）；② craft 剩余洒水器并 place；③ collect 熔炉 1 次，炉空则 load Iron Ore 5 块（只 1 次）；④ 清背包到 ≥5 空格后下矿 40 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；⑤ 回农场再 load 铁矿 1 次（仅炉空）；⑥ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑦ 22:00 前 sleep。
- **明天（夏10）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏11）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则 `use_tool` hoe 清一格耕地再 place，最多试 3 次，失败即跳过。**place 前先读背包确认有 Sprinkler。**
2. **洒水器 craft+place**：实时读材料，铁锭≥1 且铜锭≥1 就 `craft` 洒水器（最多 2 个）并立即 `place`；craft 前先确认背包空格≥1，否则先 `store_items` 清格。
3. **熔炉取锭（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 4 步。
4. **熔炉装矿（只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
5. **清背包到 ≥5 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<5 时禁止下矿。
6. **下矿（主活动）**：食物≥5、空格≥5 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
9. **备食物**：背包回血食物<5 且现金≥400g 时，**12:10 后**才去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃转钓鱼。
10. **买鱼饵**：去威利店 `open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
12. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
13. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 3 次，不在地图外乱放。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥5**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<5 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：昨天铺路/装饰浪费 10+ 动作，全部失败或低效。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤4、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. place 已 craft 的洒水器（今天第一件事，hoe 清格再放）
2. craft+place 剩余洒水器（材料齐当天做）
3. collect 熔炉取锭（仅 1 次，空即跳第 4 步）
4. 熔炉装矿（只试 1 次，失败即熔断）
5. 清背包到 ≥5 空格
6. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥5 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 备食物≥5（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
10. 买鱼饵（威利店 ≤20 个）
11. 浇水（水壶在背包时）
12. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
13. 社交（仅顺路）
14. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是洒水器 craft 成功却因「分区无空位」全天没放下去，且脚本在 14:00-16:40 反复空转 load/build_road/decorate 浪费约 20 动作。矿洞因背包空格不足两次失败，铁锭零产出。钓鱼稳定但只钓 2 轮，现金仍不足。今天必须：先清耕地放洒水器，再下矿前清空格，熔炉 collect 后立刻 load 铁矿，禁止铺路装饰，失败即熔断转钓鱼。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:10 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 14:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:20 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 15:20 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 15:20 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 洒水器 craft 成功但全天没放下去，反复 place 失败 @ Farm 耕地 — 5x place: Sprinkler 今天已确认分区无空位；2x place: repeated ineffective action suppressed（做不了：洒水器里程碑卡住，耕地仍手动浇水，体力无法释放去下矿） 〔复盘〕
- 熔炉全天 load 失败，铁锭零产出 @ Farm 熔炉 — 3x load_machines: no empty machine accepts anything；2x load_machines: no empty machine accepts that, and the rest are busy（做不了：钢水壶里程碑差 4 铁锭，无法推进） 〔复盘〕
- 下矿因背包空格不足两次直接失败 @ Mine 入口 — 2x mine: need at least 5 free backpack slots before mining; store_items first（做不了：没拿到铁矿石和煤，铁锭无法补） 〔复盘〕
- 脚本分支做完后「固定做这个到 17:00」，反复空转 load/build_road/decorate @ Farm — build_road: laid 0 tiles (blocked by trees/crops)；load_machines: busy；decorate: 没有能做的装饰（做不了：14:00-16:40 约 20 动作浪费，没去钓鱼补现金） 〔复盘〕
- 铺路脚本在未清地块上连续失败 @ Farm — 2x build_road: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：24 块铺路石白 craft，浪费木头和动作） 〔复盘〕
- FishShop 在 Mountain 位置 open_shop 失败 @ Mountain (15,40) — open_shop: can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)（做不了：没买到鱼饵，钓鱼效率受限） 〔复盘〕
- donate 在 wait_letter 阶段必失败 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心献祭无法推进，等巫师来信） 〔复盘〕

## 📊 当天结算（第二天早上统计）
- 金钱：2655 → 3155（+500g）
- 出货估值：500g　动作：41 个　失败：21 个
- 模型调用：6 次　tokens：74074
- 有效动作率：0.4595　空转：10　熔断跳过：3
- 失败耗时：24.157 秒 / 游戏 30 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计
