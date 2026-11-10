# 第5年 summer 16 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（21:45 开始）
- 天气：storm　金钱：63191g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6e653b71f2954642abe293e091c5db87
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：dc9a35864c8a44ea85fe383add663905
  - 耗时：3.313 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 1
  - 执行状态：SUCCESS · 操作编号：45aa4ae7444e42e8906d9062eaa0b04b
  - 耗时：3.609 秒 / 游戏 0 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Inventory Full
- **06:00** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：94000d54d44f43c3abfc8c83ef961720
  - 耗时：0.454 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~137g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：c994f2d527984c1090ca16a62b9df624
  - 耗时：4.5 秒 / 游戏 10 分钟

## 🌙 为明天（Y5_summer_16）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升 Steel Hoe
- 起床收熔炉成品，有空炉且背包有铁矿石就装料
- 用 ship_produce 卖掉背包里的冗余物品（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500），腾出至少 10 格背包空间
- 食物已有 5 份沙拉，直接下矿：乘电梯到 40 层，刷铁矿石和煤（40→45→50），最多下两次矿
- 下矿回来后收熔炉，铁锭够 5 个且时间在 13:00 前就去铁匠铺升 hoe
- 傍晚回农场收获成熟作物、浇水，然后睡觉
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
11. `goto_location`（location="Farm"）
12. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `harvest_crops`
23. `water_crops`
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f1890e303ac140f2911027e5e46f6b1d
  - 耗时：0.485 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败后删除取宝石与捐博物馆分支，改为清包→40 层刷铁→收炉→升 hoe→收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
16. `collect_machines`
17. `collect_machines`
18. `harvest_crops`
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b78db42f02974c5ca49d94241dbeb5e2
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连失败已物理删除，改为先 ship 清包再电梯 40 层刷铁，回农场收炉后视铁锭升 hoe。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
16. `collect_machines`
17. `harvest_crops`
18. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：73581b4bc33e445995d5e870942d4272
  - 耗时：0.484 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连败且箱子无宝石，删除 take/donate 分支，直接清包后下矿 40 层刷铁，回来收炉并尝试升 hoe。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `harvest_crops`
19. `collect_machines`
20. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：d8181a20612a4390b003c646b0f21f60
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：710ffd96d77d4476a1322cecd4d36861
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：93da19c4506f4b1380980fc82b10f3d0
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：b7faf1aea0d440c080c6769d34f47a03
  - 耗时：79.234 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：4121cde402104467a4cd0dc735aa90fb
  - 耗时：46.985 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：60913b85728c467bbbb2675d00bf2f59
  - 耗时：0.438 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：c1fd62839f4946c1b85e2973117a2570
  - 耗时：50.734 秒 / 游戏 70 分钟
- **10:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：c26000d7def94f48be8ebfc5abc2aef5
  - 耗时：33.656 秒 / 游戏 40 分钟
- **10:00** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：163c79efbfe5494180d0a7dff489d705
  - 耗时：15.125 秒 / 游戏 20 分钟
- **10:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a114f910c4cd44689c2fdb01f66ace01
  - 耗时：0.484 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：4ba40f178faf40c6ad0f46898e9f3c29
  - 耗时：40.422 秒 / 游戏 50 分钟
- **11:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：9efa3ff4551a4575a2372acb6f64c620
  - 耗时：39.079 秒 / 游戏 40 分钟
- **11:50** Blacksmith ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：aa3c863682b9433badc22f6dadf91114
  - 耗时：1.172 秒 / 游戏 10 分钟
- **11:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：d1eff2b3568a4177958fd152a553da32
  - 耗时：0.453 秒 / 游戏 0 分钟
- **12:40** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds", "Cauliflower Seeds", "Potato Seeds"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：47102bffb2854dc88759ba3665ce2d1f
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：d9529a00950c4b8fb9f3039e1bfbcdc8
  - 耗时：0.406 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：225d7f32baf64e8e8868d9a2cdc98bbb
  - 耗时：0.422 秒 / 游戏 0 分钟
- **12:40** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 6
  - 执行状态：SUCCESS · 操作编号：8ffe6be2c4e04e10a7cffa3215d67a2d
  - 耗时：13.469 秒 / 游戏 10 分钟
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Inventory Full
- **12:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:50** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：9831455cae504a3abe860cd1ab235ce2
  - 耗时：8.563 秒 / 游戏 10 分钟
- **12:50** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **13:00** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：7bae7efa98c94c1097affbb7840807d0
  - 耗时：23.906 秒 / 游戏 30 分钟
  - 🗨️ [hud] Inventory Full
- **13:30** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：22e4ccdd478442479f4b9ac0f8f020b9
  - 耗时：87.953 秒 / 游戏 120 分钟
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full

### 🔁 脚本重写：重写#1：清包+补食物后电梯40层刷铁矿，回农场炼铁，铁锭够且时间允许则升hoe，否则收工睡觉。
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
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=10）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds", "Melon Seeds", "Hops Starter", "Salad", "Strange Bun"]）
22. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter"]）
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `sleep`

## 🌅 早上的计划（22:07 开始）
- 天气：storm　金钱：63191g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——今天主活动下矿40层刷铁矿
- 起床收炉并尝试装铁矿石
- 清包到空格≥10（只卖高价值冗余）
- 补食物≥5（12点后Saloon买沙拉）
- 电梯40层下矿刷铁矿石+煤
- 回农场炼铁，铁锭≥5且<13:00则升hoe

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="62", item_name="Aquamarine", count=1）
4. `take`（item="64", item_name="Ruby", count=1）
5. `take`（item="68", item_name="Topaz", count=1）
6. `take`（item="72", item_name="Diamond", count=1）
7. `take`（item="84", item_name="Frozen Tear", count=1）
8. `take`（item="86", item_name="Earth Crystal", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate_museum`
11. `goto_location`（location="Forest"）
12. `fish`（casts=4）
13. `goto_location`（location="Saloon"）
14. `open_shop`（shop_id="Saloon"）
15. `buy`（item="Salad", count=10）
16. `close_menu`
17. `goto_location`（location="Mine"）
18. `mine`（floors=5）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds", "Melon Seeds", "Hops Starter", "Salad", "Strange Bun"]）
24. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter"]）
25. `collect_machines`
26. `load_machines`（item="Iron Ore"）
27. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：489776a6422b4e3ba4089d50a144aac3
  - 耗时：0.953 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：42e7cca2a69040ab8b45b84763e0d743
  - 耗时：3.453 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c56d87db53a24e73b3590422972d9f26
  - 耗时：0.438 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 失败已物理删除，改为只靠 ship_produce 清包，再钓鱼补食物、12点后买沙拉、40层下矿刷铁，回农场收炉后睡觉。
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
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=10）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
21. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
22. `collect_machines`
23. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
24. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f0289f0c5ac94f6c80441749dad5b084
  - 耗时：0.422 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为先收炉+ship 清包，再 Forest 钓鱼过渡到 12 点买沙拉，电梯 40 层刷铁，回农场收锭后睡觉。
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
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=10）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
21. `collect_machines`
22. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
23. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d348d1e1ee964209835c9ecf712a7b32
  - 耗时：0.421 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e172fd842a03429bab697edbea87838b
  - 耗时：0.468 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d542a33cee6042ed8eb9381e71f6296b
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f98bc5b826084ea09369bd8abc912906
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：b6262cac6a044608883f19ea15a7fc58
  - 耗时：86.078 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：ff9c6ffa337b49698ae7a9e45b6fd640
  - 耗时：47.016 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：b32ada8bdf1f4b5da6c50c4afa170343
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：4dc7d7ee3aa242a68a7f931e4d3a5d3d
  - 耗时：26.422 秒 / 游戏 40 分钟
- **09:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Broken Glasses, Green Algae, Dorado)
  - 执行状态：SUCCESS · 操作编号：f5bd458ddee14bffa1daf0e75b68d3aa
  - 耗时：91.515 秒 / 游戏 90 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Broken Glasses
- **11:00** Forest ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：0c1e891bcd70413399ae6eefb17354e7
  - 耗时：41.297 秒 / 游戏 60 分钟
- **12:00** Forest ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：48e275e4573d48099d8ce73aaf1158c5
  - 耗时：23.172 秒 / 游戏 20 分钟
- **12:20** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：e6eceaacb556452b89532cae93b6f487
  - 耗时：0.687 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `close_menu`
  - 💭 背包0空格，先买沙拉补食物（已有5个够用），但空格0无法买。先关菜单去出货箱清包。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：abfb3186345649a8b4636c1c96cc2435
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：c890954569ec4c0b89e384dab8a4e54d
  - 耗时：24.812 秒 / 游戏 30 分钟
- **12:50** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal"]）
  - 结果：shipped 1 stacks worth ~75g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ad3c524d39a7432ea38b400067509d05
  - 耗时：1.781 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `buy`（item="Salad", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：dad5b8d6b49f473a82e3e3c975dd3c5e
  - 耗时：0.438 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：5ef36c5a1f2e4e80a50cd273b2919b35
  - 耗时：0.406 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：6e563ca7599a420bb4e7cc2a848925ef
  - 耗时：49.015 秒 / 游戏 60 分钟
- **13:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：d513020f4074450592a216ee25274acc
  - 耗时：33.688 秒 / 游戏 40 分钟
- **13:50** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter", "Broken Glasses"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：a2266356acc443f09b3f757ef816c4a3
  - 耗时：15.062 秒 / 游戏 20 分钟
- **13:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **14:50** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：88c8f6d66d1e4eb88ac57b4232bf6a33
  - 耗时：0.468 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **14:50** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：6711747cc6c54e438a00f553908f547e
  - 耗时：0.469 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：73f3846ef95c45879248c97770efef0f
  - 耗时：0.469 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：c585e7b04ca0428badc554c82431cad3
  - 耗时：0.469 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **14:50** Farm ✅ `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Iron Ore", "Coal", "Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e061e1d14a4d43a398dc7e01df4b2469
  - 耗时：0.468 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1ffb60b324c64798984cc42f004b035b
  - 耗时：0.485 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **14:50** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：26cf5face50448a0bcdf3c672a163dcd
  - 耗时：23.859 秒 / 游戏 40 分钟
- **15:30** Forest ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:30** Forest ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:30 pm
  - 执行状态：SUCCESS · 操作编号：460623e1331f47b1afb08ca721fbb1ca
  - 耗时：87.609 秒 / 游戏 120 分钟
- **17:30** Forest ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：43e860701fb84b04be280773f6e5cc77
  - 耗时：24.984 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：63191 → 63266（+75g）
- 出货估值：75g　动作：42 个　失败：20 个
- 模型调用：6 次　tokens：66008
- 有效动作率：0.5　空转：6　熔断跳过：4
- 失败耗时：6.265 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包：背包只剩2格，store_items 返回OK却不腾格，ship_produce 因保留物太多只卖了75g，导致 mine 三次被「need 5」拒绝，全天零铁矿、零铁锭，钢锄头里程碑连续多天原地踏步。take 猜箱子ID、donate 空跑、wait 填充都是纯浪费。今天必须用「卖高价值冗余」真正腾出空格，否则整条铁锭链继续卡死。

**新教训：**
- 昨天 ship_produce 只卖了 75g 就返回 OK，因为背包里全是保留物（种子/矿石/食物），清包形同虚设：清包必须显式卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，否则永远腾不出 5 格。
- 昨天 12:20 在 Saloon 打开商店后因背包 0 空格买不了沙拉，只能关菜单跑回农场清包，来回浪费 30 分钟：买食物前必须先确认背包空格≥3，否则先清包再进店。
- 昨天 mine 三次被「store did not free enough slots (have 2, need 5)」拒绝，而 store_items 返回 OK 却一格没腾：下矿前必须显式读背包确认空格≥5，不能信任 store_items 的 OK 返回，空格不够直接转钓鱼。
- 昨天 15:30 用 wait 120 分钟填充到 17:30 才睡，纯浪费 2 小时游戏时间：等炉子/等时间应改为去 Forest 钓鱼或下矿，回来再 collect，绝不用 wait 空转。
- 昨天 donate_museum 在背包无可捐物时仍先 goto ArchaeologyHouse 再失败，浪费 2 个动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 夏 17）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 63191g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**空格≥10 和食物≥5 是两张门票，缺一张当天就白跑**。

接下来 3 天主活动：
- **今天（夏 17）**：起床收炉→**用 ship_produce 卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥10**→补食物≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（夏 18）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧（同配方 5 铁锭）；铁锭富余后做洒水器 ×4。
- **后天（夏 19）**：继续刷铁备钢斧，同时给蓝莓/啤酒花地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包优先卖高价值冗余，不只卖低价值物**：昨天 ship_produce 返回 nothing to ship，因为背包里全是保留物。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage 各留 5）** → 读背包验证空格≥10。两次 ship 后仍<10 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。清包唯一手段是 ship_produce。
3. **食物提前到清包后立刻解决**：清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
4. **下矿目标 40 层，不贪 80 层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
6. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 清包到空格≥10：goto Farm → ship_produce 卖高价值冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5）→ 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥10 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥10，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包，不调 store_items，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<10 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take / store_items 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0**。
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
3. 清包到空格≥10（**只用 ship_produce 卖高价值冗余**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥10、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包：背包只剩2格，store_items 返回OK却不腾格，ship_produce 因保留物太多只卖了75g，导致 mine 三次被「need 5」拒绝，全天零铁矿、零铁锭，钢锄头里程碑连续多天原地踏步。take 猜箱子ID、donate 空跑、wait 填充都是纯浪费。今天必须用「卖高价值冗余」真正腾出空格，否则整条铁锭链继续卡死。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 12:50 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 12:50 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 13:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 14:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 14:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 15:30 动作 `decorate` 失败 @ Forest — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包反复失败，背包长期卡在 2 格，下矿和升级全被「need 5」拒绝 @ Farm 出货箱 — store_items 返回 OK 但空格未增；ship_produce 因背包全是保留物只卖 75g；mine 三次返回「store did not free enough slots (have 2, need 5)」（做不了：全天零铁矿、零铁锭，钢锄头里程碑连续多天原地踏步） 〔复盘〕
- take 凭物品 ID 猜箱子，连续 12 次全失败且脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 — 「'62' is not in any farm chest」「take 62 already failed; not retrying today」（做不了：浪费 12 个动作和 3 次脚本重写，挤掉了下矿时间） 〔复盘〕
- 在背包 0 空格时打开 Saloon 商店买沙拉，买不了只能关菜单跑回农场清包 @ Saloon — 背包 0 空格无法买；随后 buy 返回「no shop is open」、close_menu 返回「no menu is open」连吃 2 个动作（做不了：食物没补上，下矿门票缺失，来回跑图浪费 30 分钟） 〔复盘〕
- donate_museum 在背包无可捐物时仍先 goto ArchaeologyHouse 再失败 @ ArchaeologyHouse — 「nothing in the backpack can be donated to the museum」（做不了：浪费 2 个动作和一段跑图时间，博物馆捐赠进度无推进） 〔复盘〕
