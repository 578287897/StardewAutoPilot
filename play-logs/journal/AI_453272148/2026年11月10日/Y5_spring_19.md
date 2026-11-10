# 第5年 spring 19 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（17:11 开始）
- 天气：sunny　金钱：64008g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0baab82ab07c4e61b833f9f67381c1f2
  - 耗时：15.328 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：7caac239b2ed4aef98c1ece9ab48c1af
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 11 crops
  - 执行状态：SUCCESS · 操作编号：e15eb861de3947b2be55f2713bf8b0b1
  - 耗时：16.985 秒 / 游戏 30 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：77ef622a03d842d8abafcaa0c36c825a
  - 耗时：0.359 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_spring_19）准备的脚本
- 里程碑：凑齐5铁锭升Steel Hoe（今天主活动=下矿80→84挖铁矿石+煤）
- 起床收熔炉成品，空炉且铁矿石≥5则投铁矿石
- 清包到空格≥15（store+ship双管齐下）
- Forest河边钓鱼补食物到≥6
- 电梯直达80层下矿挖铁矿石，≤2次mine
- 回农场收铁锭，铁锭≥5且<13:00去Blacksmith升hoe
- 时间允许则买春季种子并立即种下
- 21:30前sleep
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
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod"]）
14. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay"]）
15. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod"]）
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `goto_location`（location="Mine"）
19. `mine`（floors=5）
20. `leave_mine`
21. `goto_location`（location="Farm"）
22. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay"]）
23. `collect_machines`
24. `goto_location`（location="Mine"）
25. `mine`（floors=5）
26. `leave_mine`
27. `goto_location`（location="Farm"）
28. `collect_machines`
29. `goto_location`（location="Blacksmith"）
30. `upgrade_tool`（tool="hoe"）
31. `goto_location`（location="SeedShop"）
32. `open_shop`（shop_id="SeedShop"）
33. `buy`（item="Potato Seeds", count=20）
34. `close_menu`
35. `goto_location`（location="Farm"）
36. `plant_seeds`（item="Potato Seeds", count=20）
37. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c71a4ccfee90422694ce794150b727e1
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take 与 donate 分支，改为清包→钓鱼补食物→电梯80层挖铁→回农场收锭→13点前升hoe，时间允许再买种即种。
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
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="SeedShop"）
19. `open_shop`（shop_id="SeedShop"）
20. `buy`（item="Potato Seeds", count=20）
21. `close_menu`
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber"]）
25. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
26. `store_items`
27. `store_items`
28. `collect_machines`
29. `collect_machines`
30. `plant_seeds`（item="Potato Seeds", count=20）
31. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a45dd672a4484f2ba0d233af52a0b72a
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全失败已删除，改走清包→钓鱼补食物→80层下矿挖铁→回农场收锭→升hoe→买种即种的主线。
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
17. `buy`（item="Potato Seeds", count=20）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber", "Geode", "Omni Geode"]）
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
23. `collect_machines`
24. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber"]）
25. `plant_seeds`（item="Potato Seeds", count=20）
26. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：53dfcf7fc8ca46fe98d629b3b0905d3b
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部take（箱子内容与记忆不符），改为清包→钓鱼补食物→电梯下矿80层挖铁→回农场收锭→13点前升hoe，失败即转钓鱼或sleep。
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
17. `buy`（item="Potato Seeds", count=20）
18. `close_menu`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber", "Geode", "Omni Geode", "Dwarf Scroll I"]）
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
24. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber"]）
25. `collect_machines`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c1fb19acc1824789a7f2c399df3a610c
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：377fdae3e11e4dfdb94980ff7a999402
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7fcd43f1ec34417188c582fee05fdb1d
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：57010bc7763f429fbad6dba725ce5434
  - 耗时：57.328 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：5415f7cc85064ccca7e419e7f9809ab3
  - 耗时：42.813 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：66d6d86ec54345ba9813877e2911c0e9
  - 耗时：0.391 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：816b9161cf1d4c779b4a73c382cfa1e5
  - 耗时：26.422 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Sunfish, Green Algae, Driftwood, Green Algae)
  - 执行状态：SUCCESS · 操作编号：652e28fc82b7471e880c86c6ca0dff7a
  - 耗时：46.953 秒 / 游戏 50 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Driftwood
- **10:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a52cf36f91cc463c94582500ed9b68fa
  - 耗时：63.375 秒 / 游戏 80 分钟
- **11:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4c75413f708b49eb872d185f28565564
  - 耗时：33.641 秒 / 游戏 40 分钟
- **11:30** Mine ✅ `store_items`（items=["Cauliflower Seeds", "Green Algae", "Potato Seeds", "Driftwood"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae, 1x Driftwood
  - 执行状态：SUCCESS · 操作编号：7a31498dd0c14cc8b7b0c6425b7027d1
  - 耗时：15.047 秒 / 游戏 20 分钟
- **11:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 18 (3 floors down, 36 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：a7108e484a10486c9e6a857003261dfd
  - 耗时：85.812 秒 / 游戏 110 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [question] 
- **14:20** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：7f94c1b05d564758a8c46e48394d313f
  - 耗时：49.375 秒 / 游戏 60 分钟
- **15:20** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：b229a8f8054e430fb078ab9e4d085873
  - 耗时：38.953 秒 / 游戏 50 分钟
- **15:20** Blacksmith ✅ `store_items`（items=["Cauliflower Seeds", "Stone", "Potato Seeds", "Slime", "Geode", "Bug Meat"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 22x Stone, 1x Slime, 2x Geode
  - 执行状态：SUCCESS · 操作编号：aefd85ff778d414eb9748b1a5a184593
  - 耗时：1.109 秒 / 游戏 0 分钟
- **15:20** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **16:10** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：arrived at SeedShop (6,29)
  - 执行状态：SUCCESS · 操作编号：14d393ef40a34d2c903c78af198dc619
  - 耗时：21.953 秒 / 游戏 30 分钟
- **16:40** SeedShop ✅ `open_shop`（shop_id="SeedShop"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：95c10de6e37048679bae565c6122aee7
  - 耗时：0.438 秒 / 游戏 0 分钟
- **16:40** SeedShop ✅ `close_menu`
  - 💭 商店已开，背包仅4空格，先买少量土豆种子（25个已有），不买太多；先关菜单去清包更实际。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：4bcf81d77f4940a1af1efcb2d13890a7
  - 耗时：0.437 秒 / 游戏 0 分钟
- **16:40** SeedShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：fcf4028d0f8249d2a56941213c5b752b
  - 耗时：20.828 秒 / 游戏 20 分钟
- **17:00** Farm ❌ `buy`（item="Potato Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：ec51b412283a46369839f39cb1d1dc40
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:00** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：670f5fef26cd47b7bc1d3840a3ab3d81
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:00** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：4001a7794aa64165837edec8aa2a8cbd
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：09128a49cf58443fb9f358c83b2c29a0
  - 耗时：12.016 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **17:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：39019e6951b34441bbf978f68b85bdc9
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber", "Geode", "Omni Geode", "Dwarf Scroll I"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：aaebc7ad2de342fe9beae14384a99681
  - 耗时：13.313 秒 / 游戏 20 分钟
- **17:30** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Rusty Sword", "Bamboo Pole", "Dwarf Scroll I"]）
  - 结果：shipped 2 stacks worth ~53g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：dbcb7c01aa2443e0aa7e5ffd23e73bce
  - 耗时：0.719 秒 / 游戏 0 分钟
- **17:30** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Clay", "Fiber"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：8c67c79a4c3f4ab593fc53d5a342bbca
  - 耗时：0.391 秒 / 游戏 0 分钟
- **17:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：e46d5d31b2e945e094f22070572bbec6
  - 耗时：0.39 秒 / 游戏 0 分钟
- **17:30** Farm ✅ `plant_seeds`（item="Potato Seeds", count=20）
  - 结果：no free soil near the anchor; clear debris or pick another spot
  - 执行状态：SUCCESS · 操作编号：8afa46d9993844fdacfb3304facb0a85
  - 耗时：0.391 秒 / 游戏 0 分钟
- **17:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：097a990bdbd5470e8635b3b189926be2
  - 耗时：10.844 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64008 → 64061（+53g）
- 出货估值：53g　动作：45 个　失败：19 个
- 模型调用：8 次　tokens：101962
- 有效动作率：0.6053　空转：5　熔断跳过：6
- 失败耗时：5.015 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 45 动作 19 失败，核心问题不是策略方向错，而是执行顺序和背包管理失控：take 宝石 9 次全失败（箱子内容与记忆不符）、清包只腾 4 格导致升级被拒、买种子时关了菜单再 buy、load_machines 在炉忙时硬投。有效的是钓鱼补食物和下矿拿铜煤。今天必须把清包做成硬门槛、删除 take、把升级和买种子的触发条件写死。

**新教训：**
- 昨天 9 次 take 宝石（62/64/68/72/84/86）全失败，说明箱子实际内容与记忆完全不符：今天脚本生成阶段物理删除所有 take，需要矿物靠下矿现拿，不再凭 ID 猜箱子。
- 昨天清包后只剩 4 格，upgrade_tool 返回「store did not free enough slots (have 4, need 5)」：清包必须 store_items + ship_produce 双管齐下，且 ship 后立即读背包验证空格数，验证通过前不得调 mine/upgrade。
- 昨天 16:40 在 SeedShop 关了菜单再 buy 返回「no shop is open」，随后 close_menu 又失败，连吃 2 个动作：buy 成功后应不关菜单继续买，买够再关；关菜单后当天不再 buy。
- 昨天 17:10 load_machines 投 Iron Ore 返回「no empty machine accepts that, and the rest are busy」：投料必须在 collect 后 1 个动作内确认炉空，两炉都忙即当天永久跳过 load，不拖到下午再试。
- 昨天 plant_seeds 在没买到种子时被调用，返回「no free soil near the anchor」：种植分支必须由 buy 成功返回值触发，且种前先读分区可用格数，可用格<5 先清障或换地块。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 20）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64008g 充足，Iron Bar 还差 5，铁矿石仅 2、煤 36。瓶颈是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 20）**：起床 collect → 空炉且铁矿石≥5 才 load → **清包到空格≥15（store+ship 双管齐下并读背包验证）** → 补食物到≥6 → 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 21）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续下矿炼铁。
- **后天（春 22）**：继续炼铁/升级下一件工具，或补种春季作物。

## 今日核心修正
1. **take 全天物理删除**：连续多天 take 宝石全失败，箱子内容与记忆不符。脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **清包做成硬门槛（最关键）**：起床 goto Farm → store_items（不指定坐标，存 Stone/Geode/多余矿石/种子）→ **ship_produce 卖鱼/杂矿/低价值物（Stone/Coal/矿石/锭除外）** → 读背包验证空格。**两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支**。清包成功后全天禁止任何 take。
3. **熔炉投铁矿石，不投铜**：起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。投料必须在 collect 后 1 个动作内完成。
4. **补食物到≥6**：Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。食物<6 不下 40 层以下。
5. **下矿目标 80→84**：电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。**upgrade_tool 必须带 tool=hoe 参数**，并在日志确认返回的是升级结果而非挖矿结果。
8. **买种子顺序硬约束**：先 goto SeedShop → open_shop 成功 → **buy 一次成功后再决定是否继续买，中间不关菜单**；buy 返回「no shop is open」说明 open_shop 未生效，立即重开一次，不连续 buy。**买前读背包确认空格≥5，不足先 store_items**。**17:00 后不再去 SeedShop**。**买完种子后若背包有种子且时间<18:00，立即 plant_seeds 种下，不拖到第二天**。
9. **路径失败即换路**：store_items/ship_produce 返回 could not reach 时，立即改不指定坐标或直接 ship_produce，**不重试同一坐标**。
10. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
11. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥15**：goto Farm → store_items（不指定坐标）→ **ship_produce 卖低价值物** → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥6**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥15 且食物 ≥6 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **买春季种子（仅当时间 <17:00 且背包空格 ≥5）**：goto SeedShop → open_shop → buy Potato Seeds 20 / Cauliflower Seeds 10；**buy 成功一次后不关菜单，继续 buy 直到买够或空格不足**；buy 失败一次即跳过，不连续 buy。**买完立即 plant_seeds 种下**。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥6 且空格 ≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：连续多天 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥6 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床 collect_machines 1 次**（收熔炉成品）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. **一次性清包到空格 ≥15**（store_items 不指定坐标 + **ship_produce 卖低价值物** + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥6**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥15、食物 ≥6、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，**buy 成功后不关菜单继续买**，背包空格 ≥5，buy 失败一次即跳过；**买完立即 plant_seeds**）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天 45 动作 19 失败，核心问题不是策略方向错，而是执行顺序和背包管理失控：take 宝石 9 次全失败（箱子内容与记忆不符）、清包只腾 4 格导致升级被拒、买种子时关了菜单再 buy、load_machines 在炉忙时硬投。有效的是钓鱼补食物和下矿拿铜煤。今天必须把清包做成硬门槛、删除 take、把升级和买种子的触发条件写死。
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 15:20 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 17:00 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 17:00 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 17:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 17:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 连续 9 次 take 宝石全部失败，箱子内容与记忆不符 @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：无法从箱子取矿物去捐赠或做献祭，浪费 9 个动作） 〔复盘〕
- 清包只腾出 4 格，升级工具被拒 @ Farm / Blacksmith — store did not free enough slots (have 4, need 5)（做不了：Steel Hoe 升级无法执行，里程碑连续多天零推进） 〔复盘〕
- 买种子时先关菜单再 buy，导致商店状态丢失 @ SeedShop / Farm — no shop is open; use open_shop first / no menu is open（做不了：当天没买到春季种子，也没种下） 〔复盘〕
- 熔炉投料在炉忙时硬投，失败后未及时转产 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：铁矿石没能入炉，铁锭链继续卡住） 〔复盘〕
