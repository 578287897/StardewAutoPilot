# 第2年 summer 7 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（02:29 开始）
- 天气：storm　金钱：2655g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_summer_07）准备的脚本
- 里程碑：钢水壶（5000g+5铁锭）——今天先取锭、装炉、做洒水器，再下矿补铁/煤，现金不足则钓鱼补钱
- 收熔炉成品（只1次），炉空立刻装 Iron Ore 5 块（只1次）
- 材料齐就 craft 洒水器并 place（最多2个），排在下矿前
- 现金<700g 先去 Forest 河边钓鱼补现金
- 12:10 后若食物<5 且现金≥400g 去 Saloon 买 Salad×5（open_shop 只1次）
- 主活动：下矿 40 层以下拿铁矿+煤（食物≥5、空格≥5，≤2次 mine，超时即停）
- 回农场再装铁矿 1 次（炉空才装）
- 剩余时间 Forest 河边钓鱼，22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `craft`（item="Sprinkler", count=2）
5. `place`（item="Sprinkler"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Town"）
10. `open_shop`（shop_id="Saloon"）
11. `buy`（item="Salad", count=5）
12. `close_menu`
13. `goto_location`（location="Mine"）
14. `mine`（floors=3）
15. `mine`（floors=3）
16. `goto_location`（location="Farm"）
17. `load_machines`（item="Iron Ore"）
18. `water_crops`
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `fish`（casts=4）
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Broken CD, 3x Trash, 4x Iron Bar, 1x Joja Cola, 3x Iron Ore
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:30** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
- **06:30** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:30** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 因 wait_letter 失败已跳过；保留原路线：先做洒水器，Forest 钓鱼补现金，12:10 后 Saloon 买沙拉，下矿拿铁
1. `craft`（item="Sprinkler", count=2）
2. `place`（item="Sprinkler"）
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Town"）
8. `open_shop`（shop_id="Saloon"）
9. `buy`（item="Salad", count=5）
10. `close_menu`
11. `goto_location`（location="Mine"）
12. `mine`（floors=3）
13. `mine`（floors=3）
14. `goto_location`（location="Farm"）
15. `load_machines`（item="Iron Ore"）
16. `sleep`
- **06:30** Farm ✅ `craft`（item="Sprinkler", count=2）
  - 结果：crafted 2x Sprinkler
- **06:30** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
- **06:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Pike, Green Algae)
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **08:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Green Algae, Green Algae, Green Algae)
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Driftwood, Driftwood, Green Algae)
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Driftwood

### 🔁 脚本重写：重写#1：先收熔炉并装铁矿、做洒水器，再钓鱼补现金、买沙拉后下矿拿铁，回农场补装炉并浇水睡觉。
1. `collect_machines`
2. `load_machines`
3. `craft`（item="Sprinkler", count=2）
4. `place`（item="Sprinkler"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Town"）
9. `open_shop`（shop_id="Saloon"）
10. `buy`（item="Salad", count=5）
11. `close_menu`
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `load_machines`
18. `water_crops`
19. `sleep`

## 🌅 早上的计划（02:43 开始）
- 天气：storm　金钱：2655g　体力：270/270
- 里程碑：钢水壶（5000g+5铁锭）——今天先收熔炉锭、装铁矿、做洒水器、下矿补铁
- collect 熔炉 1 次，炉空则 load 铁矿 5 块（只试 1 次）
- 铁锭≥1 且铜锭≥1 就 craft 洒水器并 place（最多 2 个）
- 现金 2655g 够，先 Forest 河边钓鱼补现金到 5000g 目标
- 食物不足则 12:10 后 Saloon 买沙拉 5 份（只试 1 次）
- 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，超时即停）
- 回农场再 load 铁矿 1 次（炉空才装）
- 22:00 前 sleep

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `collect_machines`
4. `load_machines`
5. `craft`（item="Sprinkler", count=2）
6. `place`（item="Sprinkler"）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Town"）
11. `open_shop`（shop_id="Saloon"）
12. `buy`（item="Salad", count=5）
13. `close_menu`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `load_machines`
20. `water_crops`
21. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：4ee535b5b73c417fab0494769f8f7d27
  - 耗时：20.703 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：e9061529fd6e4868b17b7a77a0e8b6c3
  - 耗时：0.265 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：7cb1a37be80d46e09bdbf17d8809694e
  - 耗时：0.109 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：112b7c5d33ab46d6b5440d7b6a9a670a
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `craft`（item="Sprinkler", count=2）
  - 结果：can't craft Sprinkler: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：66d06f7f44c24a0ca7a157138c92f09a
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包满导致craft失败，先存杂物腾格再craft洒水器，其余按原路线钓鱼、买沙拉、下矿、回农场装炉。
1. `store_items`（items=["Geode", "Frozen Geode", "Broken CD", "Trash", "Joja Cola", "Green Algae", "Cobblestone Path"]）
2. `craft`（item="Sprinkler", count=2）
3. `place`（item="Sprinkler"）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Town"）
8. `open_shop`（shop_id="Saloon"）
9. `buy`（item="Salad", count=5）
10. `close_menu`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `load_machines`
17. `sleep`
- **06:20** Farm ✅ `store_items`（items=["Geode", "Frozen Geode", "Broken CD", "Trash", "Joja Cola", "Green Algae", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 1x Broken CD, 3x Trash, 6x Geode, 1x Joja Cola, 15x Green Algae, 10x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：8eb7edadcb1e4ca98ba23fb4262b5854
  - 耗时：10.468 秒 / 游戏 20 分钟
- **06:40** Farm ✅ `craft`（item="Sprinkler", count=2）
  - 结果：crafted 2x Sprinkler
  - 执行状态：SUCCESS · 操作编号：9655005dde4848e39cf6930e8a9f8f2e
  - 耗时：0.093 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：8bbe7ee45b114ad0bc5b4e99230c1517
  - 耗时：23.406 秒 / 游戏 30 分钟
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Green Algae, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：1e2e6412419e4e52a30dfc1e07afa8f2
  - 耗时：89.047 秒 / 游戏 80 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
- **08:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Driftwood, Broken CD, Pike)
  - 执行状态：SUCCESS · 操作编号：1ca4e51ae6624179b7f2d300cbb32ee5
  - 耗时：74.343 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Broken CD
- **10:00** Forest ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,90)
  - 执行状态：SUCCESS · 操作编号：11443588c94c4d0589e844dfbbbe161a
  - 耗时：18.579 秒 / 游戏 30 分钟
- **10:30** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：7cb17b6771b34599ab89b727f31879c0
  - 耗时：64.656 秒 / 游戏 90 分钟
- **12:00** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：dabe932f8a24456d9bf0b1fe67f4cc2a
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：Saloon 开门失败即放弃买沙拉，回农场收熔炉、装铁矿、腾格放洒水器后下矿拿铁，最后回农场再装一次炉并睡觉。
1. `goto_location`（location="Mine"）
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `store_items`（items=["Birch End Table", "Monster Compendium", "Driftwood", "Broken CD", "Green Algae", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
9. `place`（item="Sprinkler"）
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **12:00** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：2051bd43657d42a5b10403e492c47be9
  - 耗时：55.64 秒 / 游戏 70 分钟
- **13:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：11fc8888b104457cb5f320f8e9173528
  - 耗时：0.125 秒 / 游戏 0 分钟
- **13:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：8d16b809043a48f2a0ea9bddf184ca55
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:10** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：0bbde5ebf4a248fdb3eb6953d3220cc2
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:10** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：03a5efa766964d679fead8ac2115a881
  - 耗时：33.469 秒 / 游戏 40 分钟
- **13:50** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：43dfda192c474e19be3fb83e706cd838
  - 耗时：2.829 秒 / 游戏 0 分钟
  - 🗨️ [hud] Iron Bar
- **13:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6fa36f56ffcc4a95840444defe2b5d72
  - 耗时：0.204 秒 / 游戏 0 分钟
- **13:50** Farm ✅ `store_items`（items=["Birch End Table", "Monster Compendium", "Driftwood", "Broken CD", "Green Algae", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
  - 结果：stored in chest at (74,15): 2x Green Algae, 1x Driftwood, 1x Broken CD, 1x Birch End Table, 1x Monster Compendium
  - 执行状态：SUCCESS · 操作编号：0b64b03dbc4d471381106586153846e4
  - 耗时：9.406 秒 / 游戏 10 分钟
- **14:00** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **14:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **14:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：c9a359ced57849d0b78c8f3bd1fdba3e
  - 耗时：0.141 秒 / 游戏 0 分钟
- **14:00** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：400b15dfbb44474cbfa537b082b53a95
  - 耗时：0.125 秒 / 游戏 0 分钟
- **14:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：77d79f2ba4be4bb39880f48a034e5ffc
  - 耗时：4.657 秒 / 游戏 10 分钟
- **14:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6160c8a413bd493480d61d9808defbb6
  - 耗时：0.14 秒 / 游戏 0 分钟
- **14:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：d0261b1f36ca4c3396a96d1ffd01c9bc
  - 耗时：12.547 秒 / 游戏 20 分钟
- **14:30** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:30** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:30** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Broken Glasses, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：250672d64d0e45e5be8949a31f4bd310
  - 耗时：46.391 秒 / 游戏 60 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Broken Glasses
- **15:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：5622eb69aa26498f9243ea802381bf6f
  - 耗时：0.109 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `build_road`
  - 结果：laid 8 Cobblestone Path tiles (0 already done, 16 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：d740f90cc7774f34b840677017cc1882
  - 耗时：20.922 秒 / 游戏 30 分钟
- **16:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：27d6c796e821492ea0c54f37a8bd8bcf
  - 耗时：0.11 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `craft`（item="Cobblestone Path", count=8）
  - 💭 (做 8 块 Cobblestone Path 用来铺路)
  - 结果：crafted 8x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：39485b333c2741aeaa9a4f68bca7e95e
  - 耗时：0.141 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `build_road`
  - 结果：laid 24 Cobblestone Path tiles (0 already done, 0 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：2c601ec0d35e4ab78a565a7141ec15f8
  - 耗时：28.391 秒 / 游戏 40 分钟
- **16:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：54ae565657a04b38a3d62a7004a83f7d
  - 耗时：0.094 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：0776351af93649aa92c5bba26cead83f
  - 耗时：0.11 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `build_road`
  - 结果：laid 4 Cobblestone Path tiles (0 already done, 20 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：73ab5f2c08544d5fae075f8fab90c300
  - 耗时：4.765 秒 / 游戏 0 分钟
- **16:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：aa90e84b325646abb7b590b31d44b015
  - 耗时：0.11 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `craft`（item="Cobblestone Path", count=4）
  - 💭 (做 4 块 Cobblestone Path 用来铺路)
  - 结果：crafted 4x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：d0e5e962cc704eaca7ea9851bbd466db
  - 耗时：0.156 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `build_road`
  - 结果：laid 20 Cobblestone Path tiles (0 already done, 4 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：3d5b69b553eb47719f55045e258678ee
  - 耗时：44.516 秒 / 游戏 60 分钟
  - 🗨️ [hud] A Flounder frenzy has 
begun at the beach. 
- **17:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：f50b3dc23f76440bab1326672bf61f2a
  - 耗时：15.156 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：2655 → 2655（+0g）
- 出货估值：0g　动作：44 个　失败：21 个
- 模型调用：3 次　tokens：35005
- 有效动作率：0.5238　空转：11　熔断跳过：1
- 失败耗时：19.033 秒 / 游戏 30 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动被背包满和炉子忙拖死：洒水器craft成功但place无空位，下矿因空格<5失败两次，load空转7次，铺路/装饰浪费大量动作。唯一有效的是Forest钓鱼和熔炉取锭。今天必须先把洒水器放进耕地、清背包再下矿，load严格限2次。

**新教训：**
- 洒水器 craft 成功后 place 返回「分区无空位」时，应先用 hoe 清一格耕地再 place，而不是当天放弃：昨天 2 个洒水器 craft 成功却全天没放下去。
- 下矿前必须先把背包空格清到 ≥5：昨天 13:10 两次 mine 都因空格不足直接失败，等于白跑一趟矿洞。
- build_road/decorate 在树木和作物未清的地块上会连续返回「laid 0 tiles」或「没有能做的装饰」：这类动作在农场未整理前应完全禁用，昨天浪费 10+ 动作。
- 熔炉 load 返回 busy 说明炉子还在炼上一批，当天再调只会被 suppressed：load 失败后应立刻转下矿或钓鱼，不要在同一时间点连调。
- 铺路/装饰脚本分支做完后不应「固定做这个到 17:00」：昨天 14:00-16:40 反复空转 load/build_road/decorate，应直接转钓鱼或提前 sleep。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏8）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金约 2655g（今早出货到账后更高），铁锭 3，Iron Ore 3，Coal 15，Copper Bar 57，Stone 2399，Wood 1。差约 2345g + 2 铁锭。
并行里程碑：**洒水器×4**——已 craft 2 个但没 place 成功，今天第一件事就是把它们放进耕地；材料还够再做 2 个（铜锭 57、铁锭 3），craft 后立即 place。
之后：钓鱼 9 级缺鱼饵，去威利店买 Bait（5g/个，≤20 个）。
接下来 3 天主活动：
- **今天（夏8）**：① 先 place 已 craft 的 2 个洒水器到耕地（背包有就放，无空位则先清耕地杂物）；② 再 craft 2 个洒水器并 place；③ collect 熔炉 1 次，炉空则 load Iron Ore 5 块（只 1 次）；④ 清背包到 ≥5 空格后下矿 40 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；⑤ 回农场再 load 铁矿 1 次（仅炉空）；⑥ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑦ 22:00 前 sleep。
- **明天（夏9）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏10）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则先 `use_tool` hoe 清一格耕地再 place，最多试 2 次，失败即跳过。
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
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 2 次，不在地图外乱放。
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
1. place 已 craft 的洒水器（今天第一件事）
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
> 昨天主活动被背包满和炉子忙拖死：洒水器craft成功但place无空位，下矿因空格<5失败两次，load空转7次，铺路/装饰浪费大量动作。唯一有效的是Forest钓鱼和熔炉取锭。今天必须先把洒水器放进耕地、清背包再下矿，load严格限2次。
- 06:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:20 动作 `craft` 失败 @ Farm — can't craft Sprinkler: inventory full 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 12:00 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 13:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:10 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 13:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 14:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 15:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 洒水器 craft 成功但 place 全天失败，2 个洒水器留在背包没用上 @ Farm 耕地 — place 返回「Sprinkler 在规划的分区里没有空位了」和「今天已确认分区无空位」（做不了：洒水器×4 里程碑无法推进，明天还得手动浇水） 〔复盘〕
- 下矿两次都因背包空格不足直接失败 @ Mine 入口 — mine 返回「need at least 5 free backpack slots before mining; store_items first」（做不了：拿不到铁矿石和煤，钢水壶缺 2 铁锭无法推进） 〔复盘〕
- 熔炉 load 反复失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything」7 次，其中 1 次「all machines are busy」（做不了：铁锭停在 3，钢水壶要求 5 铁锭差 2） 〔复盘〕
- 铺路和装饰脚本分支空转，大量动作浪费 @ Farm — build_road 返回「laid 0 tiles, blocked by trees/crops/objects」2 次；decorate 返回「今天没有能做的装饰」2 次（做不了：步数被低效动作吃掉，主活动时间被压缩） 〔复盘〕
- Saloon 12:00 后 open_shop 仍失败 @ Town Saloon — open_shop 返回「can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)」（做不了：买不到沙拉，食物储备无法补到 5 份下矿阈值） 〔复盘〕
- 脚本重写 3 次后仍反复执行已失败分支 @ Farm — load_machines 被「repeated ineffective action suppressed until game state changes」（做不了：主活动（下矿/钓鱼）被拖到下午才做，步数接近上限） 〔复盘〕
