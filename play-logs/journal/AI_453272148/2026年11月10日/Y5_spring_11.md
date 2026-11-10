# 第5年 spring 11 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（15:29 开始）
- 天气：sunny　金钱：62577g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：71b08f6c7f494f6fb7f0f647eb5cd0a8
  - 耗时：20.688 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0f7dd8e1547244e8850a4445459a875b
  - 耗时：0.422 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_spring_11）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——起床收炉、投铁矿石、清包到空格≥15
- Forest 河边钓鱼补食物到≥6
- 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）
- 回农场收铁锭，铁锭≥5 且 13:00 前到 Blacksmith 升 hoe
- 买春季种子（土豆/花椰菜）并当天种下
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
17. `goto_location`（location="Mine"）
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `collect_machines`
22. `mine`（floors=5）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `goto_location`（location="Blacksmith"）
26. `upgrade_tool`（tool="hoe"）
27. `goto_location`（location="SeedShop"）
28. `open_shop`（shop_id="SeedShop"）
29. `buy`（item="Potato Seeds", count=20）
30. `buy`（item="Cauliflower Seeds", count=10）
31. `close_menu`
32. `goto_location`（location="Farm"）
33. `plant_seeds`（item="Potato Seeds", count=20）
34. `sleep`
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 1 crops
  - 执行状态：SUCCESS · 操作编号：7ebe8cbf43b44489a5bc752bb4726c89
  - 耗时：10.609 秒 / 游戏 20 分钟
  - 🗨️ [hud] Potato
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 9 crops
  - 执行状态：SUCCESS · 操作编号：4a1666832c204eda86c33e1e85e0a397
  - 耗时：13.265 秒 / 游戏 10 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~88g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：f738404556cc4e838c37b0a1dc80efe7
  - 耗时：9.906 秒 / 游戏 20 分钟
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：80c8e12c61514c74b71045ee89717198
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take 分支，改为起床收炉+清包（store+ship 双管齐下）→Forest 钓鱼补食物→电梯下矿 80 层挖铁→回农场收铁锭→Bla
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="SeedShop"）
17. `open_shop`（shop_id="SeedShop"）
18. `buy`（item="Potato Seeds", count=20）
19. `buy`（item="Cauliflower Seeds", count=10）
20. `close_menu`
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `store_items`
24. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
25. `collect_machines`
26. `store_items`
27. `plant_seeds`（item="Potato Seeds", count=20）
28. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：88abfc7ea0df41a5bac2eea8f71ab88b
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take 分支（箱子无宝石），改为起床 collect+投铁矿石+store/ship 双管清包到空格≥15，再 Forest 钓鱼补食物、
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="SeedShop"）
17. `open_shop`（shop_id="SeedShop"）
18. `buy`（item="Potato Seeds", count=20）
19. `buy`（item="Cauliflower Seeds", count=10）
20. `close_menu`
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `store_items`
25. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
26. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
27. `store_items`
28. `collect_machines`
29. `plant_seeds`（item="Potato Seeds", count=20）
30. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：18f6cda7e3814734ad70fb51dbf746a9
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 与 donate 分支，改为起床收炉投铁矿石、清包后 Forest 钓鱼补食物、电梯下矿 80→84 挖铁，回农场收锭后升 hoe
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="SeedShop"）
17. `open_shop`（shop_id="SeedShop"）
18. `buy`（item="Potato Seeds", count=20）
19. `buy`（item="Cauliflower Seeds", count=10）
20. `close_menu`
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `store_items`
25. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
26. `store_items`
27. `collect_machines`
28. `plant_seeds`（item="Potato Seeds", count=20）
29. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a3d2ddee822b4af2817b37813d29d350
  - 耗时：0.391 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f73f6fd169924680aa6e9d6f9951fdcf
  - 耗时：0.421 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：680b38802044440faa05ba7f611c7b31
  - 耗时：0.375 秒 / 游戏 0 分钟
- **07:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：6cdb0059d6f042c49018067a9c371237
  - 耗时：35.625 秒 / 游戏 50 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：d116db0455694d258e00daa15426fa2a
  - 耗时：45.672 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：4a5f8cbe5a804dcd9f1c832023dad8c5
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：0dba857bf83b46949f8337400efe8f18
  - 耗时：26.407 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Chub, Chub, Green Algae)
  - 执行状态：SUCCESS · 操作编号：752f3b9154564a9999a738ca29074f52
  - 耗时：105.468 秒 / 游戏 120 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
- **11:20** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a866f6a1987346f892232b1c6d0be6e9
  - 耗时：63.61 秒 / 游戏 80 分钟
- **12:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：dc1ba0c4ff014208a82b2520cb0d607d
  - 耗时：33.594 秒 / 游戏 40 分钟
- **12:40** Mine ✅ `store_items`（items=["Sprinkler", "River Jelly", "Green Algae", "Rice Shoot", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Sprinkler, 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：4a3e2e7296594d11be579b154eadeb33
  - 耗时：15.063 秒 / 游戏 20 分钟
- **12:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 85 to 85 (0 floors down, 38 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：dff8f8f5c48d49ba9569378965f2a1d1
  - 耗时：138.281 秒 / 游戏 180 分钟
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Omni Geode
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **16:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：cb9e013bdfc6437cbcecd49e2292a491
  - 耗时：35.734 秒 / 游戏 40 分钟
- **16:40** Mine ✅ `store_items`（items=["Stone", "River Jelly", "Slime", "Rice Shoot", "Strange Bun", "Omni Geode", "Magma Geode"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Slime, 1x Omni Geode
  - 执行状态：SUCCESS · 操作编号：1b1df341b9734c2f9b9c2e508f98135e
  - 耗时：15.031 秒 / 游戏 20 分钟
- **16:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **17:40** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：07982aa4b1be435382fbb9228d61e6f9
  - 耗时：43.953 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 4:00pm)
- **18:40** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：db136d5f06ed4c41b6fdf4b6bedd42ef
  - 耗时：37.578 秒 / 游戏 40 分钟
- **18:40** Town ✅ `store_items`（items=["Stone", "River Jelly", "Rice Shoot", "Strange Bun", "Magma Geode"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 28x Stone, 2x River Jelly, 1x Rice Shoot, 1x Magma Geode
  - 执行状态：SUCCESS · 操作编号：342d86c48a044241af2ffcbf26d229fc
  - 耗时：1.093 秒 / 游戏 0 分钟
- **18:40** Town ✅ `upgrade_tool`（tool="hoe"）
  - 结果：mined from floor 35 to 37 (2 floors down, 82 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：51bc415181604069adfbc36ad5483c2a
  - 耗时：127.625 秒 / 游戏 170 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Quartz
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bat Wing
  - 🗨️ [question] 
- **22:10** Mine ❌ `goto_location`（location="SeedShop"）
  - 结果：exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 9:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：7ac3b63ee92942dd83a0dd054900276a
  - 耗时：46.313 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 9:00pm)
- **23:10** Town ❌ `open_shop`（shop_id="SeedShop"）
  - 结果：can't open shop 'SeedShop' at Town; the counter is in SeedShop
  - 执行状态：ACTION_FAILED · 操作编号：efeea14801914f17809656d0eedd56f5
  - 耗时：0.36 秒 / 游戏 0 分钟
- **23:10** Town ❌ `buy`（item="Potato Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：ea9c3421936b4392b2b92ae9a1382626
  - 耗时：0.406 秒 / 游戏 0 分钟
- **23:10** Town ❌ `buy`（item="Cauliflower Seeds", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：e6ea5969ed82451ea4f9180d93b68e8e
  - 耗时：0.375 秒 / 游戏 0 分钟
- **23:10** Town ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：1821d348b3d249f7a765d0532070fb21
  - 耗时：0.375 秒 / 游戏 0 分钟
- **23:10** Town ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：97fdfb1d84bd447a943cdc814de23664
  - 耗时：19.688 秒 / 游戏 20 分钟
- **23:30** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：e5e7bb704bea4a2098f2452fbd690977
  - 耗时：12.016 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **23:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0692f7d7d7d04f528c625876b7b90014
  - 耗时：0.375 秒 / 游戏 0 分钟
- **23:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 4x Copper Bar, 3x Coal, 1x Bug Meat, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：0f85359270b24d2c99c790bfbf118f97
  - 耗时：13.36 秒 / 游戏 10 分钟
  - 🗨️ [hud] It's getting late... 
- **24:00** Farm ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：f8621ad6f0dd41fd9879605754adffe5
  - 耗时：10.375 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：62577 → 62665（+88g）
- 出货估值：88g　动作：44 个　失败：22 个
- 模型调用：7 次　tokens：88685
- 有效动作率：0.5676　空转：2　熔断跳过：6
- 失败耗时：94.844 秒 / 游戏 120 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天44动作22失败，核心问题仍是清包只存不卖导致背包满、下矿被拒，钢锄头里程碑连续多天零推进。take宝石全失败说明箱子内容与记忆不符。熔炉炼铜不炼铁，铁矿石1个未动。商店时间外发起goto被锁门。有效做法：Forest钓鱼补食物、电梯直达80层方向正确但被背包卡住。

**新教训：**
- 昨天 mine 返回「store did not free enough slots (have 2, need 5)」而 store_items 返回 OK 只腾出 2 格：清包必须 store_items + ship_produce 双管齐下，且 ship 后立即读背包验证空格数，验证通过前不得调 mine。
- 昨天 goto Blacksmith 在 17:40 被锁门（Open 9:00am-4:00pm）、goto SeedShop 在 22:10 被锁门（Open 9:00am-9:00pm）：所有 goto 商店前必须先读游戏时间，Blacksmith 只在 9:00-16:00、SeedShop 只在 9:00-17:00 内发起。
- 昨天 open_shop 在 Town 调用返回「the counter is in SeedShop」：open_shop 必须在 SeedShop 地图内调用，goto SeedShop 成功后再 open_shop，不能在 Town 或 Farm 直接开。
- 昨天 upgrade_tool 返回「mined from floor 35 to 37」说明该动作被错误路由到挖矿：升级前必须确认当前地图是 Blacksmith 且带 tool=hoe 参数，否则当天视为升级失败并跳过。
- 昨天 load_machines 在 23:50 返回「no empty machine accepts anything」，而 23:30 刚 collect 出铜锭：投料应在 collect 后立即确认炉空，若两炉都在忙则当天不再 load，不要拖到深夜再试。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 12）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 62577g 充足，铁锭 0、铁矿石 1、煤 34，瓶颈是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 12）**：起床 collect → 空炉投 Iron Ore（铁矿石≥5 才投）→ **清包到空格≥15（store+ship 双管齐下，必须卖货）** → 补食物到≥6 → 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 13）**：复活节买草莓种子，节日结束后当天种下；若 hoe 已升，转钢斧（5000g+5 铁锭）。
- **后天（春 14）**：继续下矿炼铁/升级下一件工具，或补种春季作物。

## 今日核心修正
1. **take 全天物理删除**：连续多天 take 宝石全失败，脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **熔炉投铁矿石，不投铜**：起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。**投料必须在 collect 后 1 个动作内完成**。
3. **清包一次到空格≥15（关键修正）**：起床 goto Farm → store_items（**不指定坐标**）→ **ship_produce 卖鱼/杂矿/低价值物（Stone/Coal/矿石/锭除外）** → 读背包验证。**仅靠 store_items 不够，必须 ship_produce 卖货**。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包成功后全天禁止任何 take。
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
> 昨天44动作22失败，核心问题仍是清包只存不卖导致背包满、下矿被拒，钢锄头里程碑连续多天零推进。take宝石全失败说明箱子内容与记忆不符。熔炉炼铜不炼铁，铁矿石1个未动。商店时间外发起goto被锁门。有效做法：Forest钓鱼补食物、电梯直达80层方向正确但被背包卡住。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 16:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 17:40 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 4:00pm) 〔自动〕
- 22:10 动作 `goto_location` 失败 @ Mine — exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 9:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 9:00pm) 〔自动〕
- 23:10 动作 `open_shop` 失败 @ Town — can't open shop 'SeedShop' at Town; the counter is in SeedShop 〔自动〕
- 23:10 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 23:10 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 23:10 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 23:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 清包只靠 store_items 存箱子，返回 OK 却只腾出 2 格，mine 仍被拒 @ Farm 箱子旁 — store did not free enough slots (have 2, need 5)；store_items 返回 OK 但只存了少量物品，未 ship 低价值物（做不了：下矿拿铁矿石，钢锄头里程碑连续多天零推进） 〔复盘〕
- 6 次 take 宝石全部失败，箱子内容与记忆不符 @ Farm 箱子 — '62'/'64'/'68'/'72'/'80'/'84' is not in any farm chest（做不了：无法取出献祭用宝石，博物馆捐赠也空跑） 〔复盘〕
- goto Blacksmith 在 17:40 被锁门、goto SeedShop 在 22:10 被锁门 @ Town / Mountain — It's locked... (Open 9:00am - 4:00pm) / (Open 9:00am - 9:00pm)（做不了：无法升级工具、无法买种子） 〔复盘〕
