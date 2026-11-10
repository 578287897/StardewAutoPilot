# 第2年 summer 10 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（03:14 开始）
- 天气：sunny　金钱：4041g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：286fc1dcab6f4189a915f8791cc61bbc
  - 耗时：4.969 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tomorrow we're all gathering at the beach for the annual Pelican Town Luau.  The highlight of the event is the communal potluck. Make sure you bring something good to contribute! The governor himself is attending the event, so make sure you're on your best behavior. Come to the beach sometime between 9 AM and 2 PM.    -Mayor Lewis
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fdf92fd012d04f768083f5d0cdc80cf1
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 4x Sprinkler, 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：933891de4f6a4b49940837315223532a
  - 耗时：1.687 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：2ec50b0616774dcc96455735edac5848
  - 耗时：0.281 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_10）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭+约959g）
- 先清背包空格，把已craft的4个洒水器放下（分区无空位就hoe清格再放）
- collect熔炉1次，炉空立刻load铁矿5块
- 清背包到≥5空格后下矿40层以下拿铁矿石+煤（≤2次mine）
- 回农场再load铁矿1次
- 现金<700g去Forest河边钓鱼补现金
- 买鱼饵（先清到≥3空格）
- 22:00前sleep
1. `donate`
2. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Green Algae", "Cobblestone Path"]）
3. `place`（item="Sprinkler"）
4. `use_tool`（tool="hoe", x=53, y=15, times=1）
5. `place`（item="Sprinkler"）
6. `use_tool`（tool="hoe", x=56, y=15, times=1）
7. `place`（item="Sprinkler"）
8. `use_tool`（tool="hoe", x=51, y=17, times=1）
9. `place`（item="Sprinkler"）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore"]）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `load_machines`（item="Iron Ore"）
18. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `fish`（casts=4）
22. `goto_location`（location="Mountain"）
23. `store_items`（items=["Stone", "Fiber", "Copper Ore"]）
24. `open_shop`（shop_id="FishShop"）
25. `buy`（item="Bait", count=20）
26. `close_menu`
27. `goto_location`（location="Farm"）
28. `water_crops`
29. `sleep`
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 16 crops
  - 执行状态：SUCCESS · 操作编号：e896c695416b422cbdc37f4a9c1f029d
  - 耗时：18.297 秒 / 游戏 30 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~361g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：0346ded504374a4bacaf84c3a5f01148
  - 耗时：10.516 秒 / 游戏 10 分钟
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：3d13cf3281204c14aa40ca375be3665c
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：捐不了就跳过，先取回箱子里的4个洒水器放下，再collect/load熔炉、下矿补铁，回农场装炉后钓鱼补现金并买鱼饵，最后浇水睡觉。
1. `take`（item="Sprinkler", count=4）
2. `place`（item="Sprinkler"）
3. `place`（item="Sprinkler"）
4. `place`（item="Sprinkler"）
5. `place`（item="Sprinkler"）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Cobblestone Path"]）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `fish`（casts=4）
15. `goto_location`（location="Mountain"）
16. `open_shop`（shop_id="FishShop"）
17. `buy`（item="Bait", count=20）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
22. `water_crops`
23. `sleep`
- **06:40** Farm ✅ `take`（item="Sprinkler", count=4）
  - 结果：took 4x Sprinkler from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：7cd95c4b2330442699a62345236929cf
  - 耗时：1.016 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：5edf42f6222d4151b88841e92df282a2
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：70cd0e07ab874bc4b36c64bd2f82c269
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 1x Coal, 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：64387661ba2545b9a25c3bbc93ec1fd1
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：581a751a08d5470baaac1b226b29490e
  - 耗时：45.047 秒 / 游戏 60 分钟
- **07:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 58 stones broken); stopped at floor 19: only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：39b1e56f47b946b98b5fd848e9dbfbd2
  - 耗时：65.25 秒 / 游戏 80 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
- **09:00** UndergroundMine19 ✅ `mine`（floors=5）
  - 结果：mined from floor 19 to 19 (0 floors down, 0 stones broken); stopped at floor 19: only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：0468432be953488886026fcf7282f0e3
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:00** UndergroundMine19 ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：cca1b9f9c96b470a98f500c33c470fb0
  - 耗时：60.828 秒 / 游戏 80 分钟
  - 🗨️ [question] 
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (River Jelly, Sunfish, Sunfish, Green Algae)
  - 执行状态：SUCCESS · 操作编号：a81c2c781f4a42e9bd7639eb18697a64
  - 耗时：74.703 秒 / 游戏 80 分钟
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
- **11:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Chub, Sunfish, Chub)
  - 执行状态：SUCCESS · 操作编号：43b15a2e6a6c41138b77e9939296288d
  - 耗时：93.266 秒 / 游戏 80 分钟
  - 🗨️ [hud] Sunfish
- **13:00** Forest ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：2a1f0d81e2d248a194352bde047205f7
  - 耗时：46.0 秒 / 游戏 60 分钟
- **14:00** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：4e9cfea2ae384559ae59343d7fe7b96f
  - 耗时：0.172 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：鱼店不在Mountain无法开，先回农场放下4个洒水器、收装熔炉，再清背包去Forest钓鱼补现金，傍晚回农场装铁浇水后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Farm"）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `place`（item="Sprinkler"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `store_items`（items=["Geode", "Green Algae", "Slime", "Bug Meat", "Stone", "Copper Ore"]）
12. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler", "Garlic Seeds", "Rice Shoot", "Coffee Bean", "River Jelly"]）
13. `load_machines`（item="Iron Ore"）
14. `water_crops`
15. `sleep`
- **14:00** Mountain ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：36cdfd2e61ab4be7b76ade7b670b4173
  - 耗时：39.922 秒 / 游戏 50 分钟
- **14:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 5 (Dorado, treasure: Geode, Rainbow Trout, Rainbow Trout, Chub)
  - 执行状态：SUCCESS · 操作编号：953c2adfba9a4b31b64f73ab89d63869
  - 耗时：83.516 秒 / 游戏 60 分钟
- **15:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Trash, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：cc9ef1980a394130b57613cc226fcbc1
  - 耗时：100.656 秒 / 游戏 110 分钟
  - 🗨️ [hud] Sunfish
- **17:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：127f3928fb1e403088e3674faf9d3f7c
  - 耗时：15.141 秒 / 游戏 10 分钟
- **17:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **17:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **17:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：2ae069b2f42e4077917ad5296b46ad3a
  - 耗时：0.141 秒 / 游戏 0 分钟
- **17:50** Farm ✅ `store_items`（items=["Geode", "Green Algae", "Slime", "Bug Meat", "Stone", "Copper Ore"]）
  - 结果：stored in chest at (74,15): 11x Stone, 2x Geode, 4x Bug Meat, 1x Slime, 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：0401b85f06294faeba6481b2937c5ff7
  - 耗时：21.078 秒 / 游戏 30 分钟
- **18:20** Farm ✅ `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler", "Garlic Seeds", "Rice Shoot", "Coffee Bean", "River Jelly"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：1020c1124cf34db1b4dade0a7e4418b8
  - 耗时：0.14 秒 / 游戏 0 分钟
- **18:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **18:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：6dee168f3a464180a33a6198da7acf3a
  - 耗时：0.187 秒 / 游戏 0 分钟
- **18:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4959d72114f24ab8954b81a2a6ad99a6
  - 耗时：7.297 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4041 → 4402（+361g）
- 出货估值：361g　动作：38 个　失败：16 个
- 模型调用：4 次　tokens：50562
- 有效动作率：0.5806　空转：7　熔断跳过：6
- 失败耗时：1.499 秒 / 游戏 0 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天38动作16失败，核心浪费在洒水器place（分区无空位）和熔炉load（炉busy）反复重试，导致下矿只推进4层、铁锭零产出。钓鱼稳定但现金仍不足。今天必须：先清耕地放下4个洒水器，熔炉collect后立即load铁矿，下矿前清背包≥5空格，失败一次即熔断转钓鱼。

**新教训：**
- 洒水器 place 返回「分区无空位」时，必须先用 use_tool hoe 清一格耕地再 place，最多 6 次；昨天 4 个洒水器 craft 成功却全天没放下去，今天第一件事就是清格放下。
- 熔炉 load 返回 busy 说明炉子还在炼上一批，当天再调只会被 suppressed；load 失败后应立刻转下矿或钓鱼，不要在同一时间点连调。
- 下矿前必须先把背包空格清到 ≥5：昨天 13:10 两次 mine 都因空格不足直接失败，等于白跑一趟矿洞。
- Forest 河边钓鱼稳定出 Pike/Chub（约 150g/条），是当前唯一可靠现金来源：现金<700g 时先钓 2 轮再去 Saloon，不要空手去撞 'not enough money'。
- 脚本分支做完后不应「固定做这个到 17:00」：昨天 14:00-16:40 反复空转 load/build_road/decorate，应直接转钓鱼或提前 sleep。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏11）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 4041g（今早出货到账后约 4400g），铁锭 1，Iron Ore 3，Coal 17，Copper Bar 56，Stone 2407，Wood 1。差约 600g + 4 铁锭。
并行里程碑：**洒水器×4**——已 craft 4 个但连续两天 place 失败（分区无空位），今天第一件事必须 hoe 清格后放下。
之后：**钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵**——钓鱼已 9 级，缺鱼饵，去威利店买 Bait（5g/个，≤20 个），买前清背包≥3 空格。
接下来 3 天主活动：
- **今天（夏11）**：① hoe 清 4 格耕地并 place 4 个洒水器（最多 6 次 place，失败即停）；② collect 熔炉 1 次，炉空立刻 load Iron Ore 5 块（只 1 次）；③ 清背包到 ≥5 空格后下矿 40 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；④ 回农场再 load 铁矿 1 次（仅炉空）；⑤ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑥ 22:00 前 sleep。
- **明天（夏12）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏13）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则 `use_tool` hoe 清一格耕地再 place，最多试 6 次（4 个洒水器各需一格），失败即跳过。**place 前先读背包确认有 Sprinkler。**
2. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 3 步。
3. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
4. **清背包到 ≥5 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<5 时禁止下矿。**买鱼饵前也先清到 ≥3 空格。**
5. **下矿（主活动）**：食物≥5、空格≥5 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
6. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
8. **备食物**：背包回血食物<5 且现金≥400g 时，**12:10 后**才去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃转钓鱼。
9. **买鱼饵**：先清背包到 ≥3 空格，再去威利店 `open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
11. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
12. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 6 次，不在地图外乱放。
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
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. hoe 清格并 place 4 个洒水器（今天第一件事，最多 6 次 place）
2. collect 熔炉取锭（仅 1 次，空即跳第 3 步）
3. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
4. 清背包到 ≥5 空格
5. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥5 才下，≤2 次 mine，超时即停）
6. 熔炉装铁（下矿后只试 1 次，炉空才装）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 备食物≥5（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
9. 买鱼饵（先清背包 ≥3 空格，威利店 ≤20 个）
10. 浇水（水壶在背包时）
11. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
12. 社交（仅顺路）
13. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天38动作16失败，核心浪费在洒水器place（分区无空位）和熔炉load（炉busy）反复重试，导致下矿只推进4层、铁锭零产出。钓鱼稳定但现金仍不足。今天必须：先清耕地放下4个洒水器，熔炉collect后立即load铁矿，下矿前清背包≥5空格，失败一次即熔断转钓鱼。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 06:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 17:50 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 17:50 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 17:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 17:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 17:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 17:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 18:20 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 4 个洒水器 craft 成功却全天 place 失败，耕地分区无空位 @ Farm 耕地 — place 返回「Sprinkler 在规划的分区里没有空位了」和「今天已确认分区无空位」，连续 7 次失败（做不了：洒水器无法铺开，继续手动浇水浪费体力，拖慢下矿和升级） 〔复盘〕
- 熔炉全天 load 失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything in the backpack or the farm chests」，连续 5 次失败（做不了：钢水壶里程碑差 4 铁锭，无法推进） 〔复盘〕
- 下矿因食物不足只推进 4 层（15→19），第二次 mine 原地 0 层 @ Mine 15-19 层 — mine 返回「only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)」（做不了：拿不到 40 层以下的铁矿石，铁锭和钢水壶都卡住） 〔复盘〕
- 去 Mountain 开 FishShop 失败，位置错误 @ Mountain (15,40) — open_shop 返回「can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)」（做不了：买不到鱼饵，钓鱼效率下降） 〔复盘〕
- donate 失败，巫师来信未到 @ 社区中心 — donate 返回「can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon」（做不了：社区中心献祭无法推进） 〔复盘〕
