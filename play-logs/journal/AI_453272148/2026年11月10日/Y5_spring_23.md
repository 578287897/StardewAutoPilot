# 第5年 spring 23 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（17:59 开始）
- 天气：windy　金钱：65685g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：3e42b7d849a5462a94237a77c074654d
  - 耗时：5.078 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tomorrow we're all getting together for the Flower Dance.  If you can find a partner, you might even want to participate in the dance yourself! There's a little clearing beyond the forest west of town where we hold the dance. Arrive between 9 AM and 2 PM if you're interested.   -Mayor Lewis
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：5670aa608ff74de886c7480d8217c93c
  - 耗时：10.765 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：4b13f48367a44c0a97d4e75384e56318
  - 耗时：0.329 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_spring_23）准备的脚本
- 里程碑：凑齐 5 铁锭升级钢锄头（5000g+5 Iron Bar）
- 起床收熔炉成品，空炉且铁矿石≥5 就投铁矿石
- 清包到空格≥15（store+ship 双管齐下）
- Forest 钓鱼补食物到≥6
- 下矿 80→84 层挖铁矿石+煤（≤2 次）
- 回农场收铁锭，铁锭≥5 且 13:00 前去 Blacksmith 升 hoe
- 时间允许去 SeedShop 买蒜种并立即种下
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
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
14. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `goto_location`（location="Mine"）
18. `mine`（floors=5）
19. `store_items`
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="SeedShop"）
24. `open_shop`（shop_id="SeedShop"）
25. `buy`（item="Garlic Seeds", count=10）
26. `close_menu`
27. `goto_location`（location="Farm"）
28. `plant_seeds`（item="Garlic Seeds", count=10）
29. `sleep`
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 11 crops
  - 执行状态：SUCCESS · 操作编号：446521ac62214e2b83e11090b98b4330
  - 耗时：28.0 秒 / 游戏 40 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：7d142fa62ac74d408e417de9aa885eba
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b9ef317ac4f74e509bcd79e7fd9822dd
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take 与 donate_museum（箱子无宝石、卷轴未解锁），改为清包→钓鱼补食物→80层下矿→回农场收铁锭→13点前升 hoe→买蒜
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
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Garlic Seeds", count=10）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
24. `store_items`
25. `collect_machines`
26. `plant_seeds`（item="Garlic Seeds", count=10）
27. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：559e056cfc2143de8e092796f3d3a551
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take（箱子内容与记忆不符），改为清包后 Forest 钓鱼补食物、下矿 80 层挖铁矿石，回农场收铁锭后 13:00 前升 hoe，顺路
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
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Garlic Seeds", count=10）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `store_items`
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
24. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
25. `collect_machines`
26. `store_items`
27. `plant_seeds`（item="Garlic Seeds", count=10）
28. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ab84385b9f6c4c1bb018b094854337dd
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 与 donate 分支，改为清包→钓鱼补食物→下矿挖铁→回农场收锭→13点前升 hoe→买蒜种即种。
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
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Garlic Seeds", count=10）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `store_items`
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
24. `collect_machines`
25. `store_items`
26. `plant_seeds`（item="Garlic Seeds", count=10）
27. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：32bb17b0612f4967a67d9c55f7dbc921
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d9a28b7f557d4726818fdb22f7da640c
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ff88419d30544784b4ee62a9d0040b5c
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：0c60eddb73e54440b2289c0d12be10e0
  - 耗时：46.516 秒 / 游戏 70 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：02b6dd4b032d4107b4554fe60767a678
  - 耗时：48.812 秒 / 游戏 60 分钟
- **09:00** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：51305af215dd460f9feaa35818f49dc6
  - 耗时：0.407 秒 / 游戏 0 分钟
- **09:00** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：7b8e9964f20d44499cacf85bfdd40deb
  - 耗时：26.422 秒 / 游戏 30 分钟
- **09:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Sunfish, Chub, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：270c4c2d64154ca39646e208da24676c
  - 耗时：106.953 秒 / 游戏 100 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Sunfish
- **11:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：b6b68affc643476dbde6934dca5345f9
  - 耗时：63.578 秒 / 游戏 80 分钟
- **12:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 35 to 39 (4 floors down, 112 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：df32beb86290420e9b73cfbd026690c7
  - 耗时：89.406 秒 / 游戏 120 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Bomb
  - 🗨️ [hud] Bat Wing
  - 🗨️ [question] 
- **14:30** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：2890cf9b676b4ea886f4ec5ed3b4a7e9
  - 耗时：49.36 秒 / 游戏 60 分钟
- **15:30** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：ac62d1c0521749c4903a0244d8fb0437
  - 耗时：40.484 秒 / 游戏 50 分钟
- **15:30** Blacksmith ✅ `store_items`（items=["Cauliflower Seeds", "Stone", "Potato Seeds", "Geode", "Bug Meat", "Bomb"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 61x Stone, 2x Geode
  - 执行状态：SUCCESS · 操作编号：07bddf4e2dde492e99ff9708569bd3a1
  - 耗时：1.047 秒 / 游戏 0 分钟
- **15:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **16:20** Farm ❌ `goto_location`（location="SeedShop"）
  - 结果：exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: Maru: Have you met my mother? She's the town's carpenter. | Maru: 
  - 执行状态：ACTION_FAILED · 操作编号：37e67cb3cd3946c49cf32f7e2426c6f3
  - 耗时：26.141 秒 / 游戏 30 分钟
  - 🗨️ [dialogue] Maru: Have you met my mother? She's the town's carpenter.
  - 🗨️ [dialogue] Maru: 
- **16:50** Town ❌ `open_shop`（shop_id="SeedShop"）
  - 结果：can't open shop 'SeedShop' at Town; the counter is in SeedShop
  - 执行状态：ACTION_FAILED · 操作编号：b93ffe247c194a51940a6a3f5e1aeeca
  - 耗时：0.406 秒 / 游戏 0 分钟
- **16:50** Town ❌ `buy`（item="Garlic Seeds", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：6435f8ab94b34511a94fb1a4e7ffe0a5
  - 耗时：0.391 秒 / 游戏 0 分钟
- **16:50** Town ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：d9de526fd9b24ca28ec753f2e4df94e9
  - 耗时：0.406 秒 / 游戏 0 分钟
- **16:50** Town ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：2d1f9d9f7d204f0390782e72d29d93c2
  - 耗时：19.484 秒 / 游戏 20 分钟
- **17:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：112554eae1714d29ae109e09df0a4288
  - 耗时：12.032 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **17:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：60e5dbee9c804747817f48c4d6165794
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Coal, 1x Bug Meat, 1x Bomb, 2x Bat Wing
  - 执行状态：SUCCESS · 操作编号：ae3c456e84244434bde9ec74b1ae47d3
  - 耗时：13.344 秒 / 游戏 20 分钟
- **17:50** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
  - 结果：shipped 2 stacks worth ~210g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：9b36caace1a94d7eb0f6cf07e0155305
  - 耗时：0.703 秒 / 游戏 0 分钟
- **17:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：a8ea7decd33d4f8ab78171951a72d382
  - 耗时：0.39 秒 / 游戏 0 分钟
- **17:50** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：0a0aa78254f646e09e14b11b6b22f9ce
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:50** Farm ❌ `plant_seeds`（item="Garlic Seeds", count=10）
  - 结果：'Garlic Seeds' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：3be3f8c0e5894311909b6b67f0aa2518
  - 耗时：0.39 秒 / 游戏 0 分钟
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：d692cfe2432c499a8d19c1ac9e52ed74
  - 耗时：10.828 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65685 → 65895（+210g）
- 出货估值：210g　动作：42 个　失败：22 个
- 模型调用：7 次　tokens：90413
- 有效动作率：0.4857　空转：5　熔断跳过：6
- 失败耗时：32.014 秒 / 游戏 30 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天真正推进的只有下矿 35→39 和钓鱼 4 条，铁锭链仍零产出：铁矿石只有 3，两炉都在忙，清包只腾出 3 格导致升级被拒。22 个失败里 12 个是凭 ID 猜箱子 take、5 个是商店/菜单时序错误，全是可预测的空转。核心问题不是策略缺规则，而是执行顺序：清包和投料没在起床后立刻做，导致下午才到铁匠铺时格子和锭都不够。

**新教训：**
- 昨天 12 次 take 宝石全失败、donate_museum 也因背包无可捐物失败：箱子内容与记忆完全不符，任何需要特定物品的动作前必须先读箱子实际内容，不能凭 ID 猜；今天直接物理删除 take。
- 昨天清包只 store_items 腾出 3 格，upgrade_tool 返回「have 3, need 5」：清包必须 store_items + ship_produce 双管齐下，且 ship 后立即读背包验证空格数，验证通过前不得调 mine/upgrade。
- 昨天 16:20 在 Town 调 goto SeedShop 失败（exit did not open），随后 open_shop/buy/close_menu 连吃 3 个失败：goto 商店前必须先读游戏时间并确认当前地图能走到入口，goto 失败即当天跳过该商店，不连续调 open_shop/buy。
- 昨天 17:10 load_machines 投 Iron Ore 返回「no empty machine accepts that, and the rest are busy」：投料必须在 collect 后 1 个动作内确认炉空，两炉都忙即当天永久跳过 load，不拖到下午再试。
- 昨天 plant_seeds 在 buy 全部失败后仍被调用，返回 not found：种植分支必须由 buy 成功返回值触发，脚本生成阶段若 buy 未成功则物理删除 plant 分支。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 24）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65685g 充足，卡点纯粹是 Iron Bar 0/5、Iron Ore 仅 3。已连续多天零推进，今天必须把「铁矿石→铁锭」这条链打通，否则后续钢斧、洒水器（需铁锭）全部堵死。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 24）**：起床先收炉+投料 → 清包到空格≥15 → 电梯直达 80 层下矿拿铁矿石（≤2 次）→ 回农场投料/收锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 25）**：hoe 升完转钢斧（同配方 5 铁锭），继续炼铁；若铁锭仍不足，全天矿洞 80-90 层刷铁。
- **后天（春 26）**：铁锭富余后做洒水器 ×4（1 铜锭+1 铁锭），把浇水体力省下来。

## 今日核心修正（按执行顺序）
1. **起床三连（5 分钟内完成）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+下矿，不再纠结投料。
2. **清包是硬门槛**：goto Farm → store_items（不指定坐标，存 Stone/Geode/种子/杂矿）→ ship_produce（卖鱼/杂矿/低价值物，Stone/Coal/矿石/锭除外）→ **读背包验证空格≥15**。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包后全天禁止 take。
3. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
4. **下矿目标 80→84 层**：电梯直达 80 层，mine ≤2 次、每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**。
5. **mine 成功一次后先 store_items 腾格**，再决定是否第二次下矿，不连续调 mine。
6. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
7. **商店时序**：goto SeedShop 前先读时间（9:00-17:00，周三休）；open_shop 成功后再 buy；**buy 成功后不关菜单继续买**；buy 失败一次即跳过，不连续 buy。买完立即 plant_seeds 种下。
8. **补食物到≥6**：Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。食物<6 不下 40 层以下。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 一次性清包到空格≥15：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥6：goto Forest 河边 fish ≤1 轮（≤4 cast）。
5. 下矿（仅当空格≥15 且食物≥6 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 store_items 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买春季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物≥6 且空格≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：连续多天 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥6 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次（收熔炉成品）
2. 起床读炉状态 → 空炉且 Iron Ore≥5 立即 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过；Iron Ore<5 物理删除 load）
3. 一次性清包到空格≥15（store_items 不指定坐标 + ship_produce 卖低价值物 + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥6（Forest 河边钓鱼吃鱼）
5. 下矿：电梯直达 80 层拿铁矿石+煤（空格≥15、食物≥6、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天真正推进的只有下矿 35→39 和钓鱼 4 条，铁锭链仍零产出：铁矿石只有 3，两炉都在忙，清包只腾出 3 格导致升级被拒。22 个失败里 12 个是凭 ID 猜箱子 take、5 个是商店/菜单时序错误，全是可预测的空转。核心问题不是策略缺规则，而是执行顺序：清包和投料没在起床后立刻做，导致下午才到铁匠铺时格子和锭都不够。
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 09:00 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 15:30 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 16:20 动作 `goto_location` 失败 @ Farm — exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: Maru: Have you met my mother? She's the town's carpenter. | Maru:  | 游戏消息: [dialogue] Maru: Have you met my mother? She's the town's carpenter. / [dialogu 〔自动〕
- 16:50 动作 `open_shop` 失败 @ Town — can't open shop 'SeedShop' at Town; the counter is in SeedShop 〔自动〕
- 16:50 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 16:50 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 17:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 17:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 17:50 动作 `plant_seeds` 失败 @ Farm — 'Garlic Seeds' not found in inventory 〔自动〕
- 铁锭链连续多天零推进：Iron Bar 0/5，Iron Ore 仅 3，两炉都在忙，钢锄头升级被无限推迟 @ Farm 熔炉 / Blacksmith — load_machines 返回「no empty machine accepts that, and the rest are busy」；upgrade_tool 返回「store did not free enough slots (have 3, need 5)」（做不了：钢锄头升级、后续钢斧、洒水器（需铁锭）全部卡住） 〔复盘〕
- 清包只靠 store_items，腾不出足够空格，导致升级和下矿被拒 @ Farm 箱子 (75,15)/(74,15) — store_items 返回 OK 但只腾出 3 格；upgrade_tool 报 have 3, need 5（做不了：无法升级工具，也无法连续下矿） 〔复盘〕
- 凭 ID 猜箱子内容，12 次 take 宝石全失败 @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest（做不了：博物馆捐赠、献祭凑矿物全部做不成，浪费 12 个动作） 〔复盘〕
- 商店时序错误：goto SeedShop 失败后仍连调 open_shop/buy/close_menu @ Town → SeedShop — exit to SeedShop did not open；open_shop 报 the counter is in SeedShop；buy 报 no shop is open；close_menu 报 no menu is open（做不了：蒜种没买到，plant_seeds 空跑） 〔复盘〕
- 熔炉投料拖到下午才试，两炉都在忙 @ Farm 熔炉 — load_machines 返回 no empty machine accepts that, and the rest are busy（做不了：当天铁锭产量为 0，铁锭链继续断） 〔复盘〕
- 下矿只下 35→39 层就因背包满被迫离开，没拿到足够铁矿石 @ Mine 35-39 层 — mine 返回 backpack nearly full: store items before mining again; left the mine to recover（做不了：铁矿石没攒够，铁锭链无法启动） 〔复盘〕
- 食物 0 个，无法安全下 40 层以下拿铁矿 @ Mine 入口 / Forest — only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：无法下到 40 层以下刷铁矿，铁锭链只能靠 80 层电梯但食物不足） 〔复盘〕
- build_road 在农场铺路失败，纯浪费动作 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：无（应从脚本彻底删除）） 〔复盘〕
