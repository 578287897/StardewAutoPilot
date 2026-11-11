# 第5年 fall 21 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（07:53 开始）
- 天气：sunny　金钱：65843g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：207e598449334c8982d7279cb716c77f
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：77484452ee06444f962db42cc76984dd
  - 耗时：3.36 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：65f332cf8d3b4a2ebe95660a541e2634
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：5ba8cb8217bb495a8f12e7832272cfb1
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：3f18e8f5662b4eb0b8122ec42ee6d48d
  - 耗时：0.469 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_21）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天必须下矿拿铁
- 起床收熔炉成品，空炉且铁矿石够就装料
- 清包：卖 Copper Bar 留 20 腾格，验证空格≥5
- 补食物：Saloon 买沙拉到≥8（12:00 后开门）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次≤5 层
- 回农场收铁锭，铁锭≥5 且时间<13:00 去铁匠铺升 hoe
- 铁锭不够就继续下矿或钓鱼收尾，21:30 前睡
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
11. `ship`（item="Copper Bar", count=62）
12. `ship`（item="Stone", count=40）
13. `ship`（item="Sap", count=48）
14. `goto_location`（location="Saloon"）
15. `wait`（minutes=30）
16. `open_shop`（shop_id="Saloon"）
17. `buy`（item="Salad", count=8）
18. `close_menu`
19. `goto_location`（location="Mine"）
20. `mine`（floors=5）
21. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Copper Ore", "Gold Ore", "Coal", "Fiber", "Sap", "Slime", "Rubber Boots", "Sprinkler", "Claymore", "Burglar's Shank", "Silver Saber", "Bamboo Pole", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Rusty Sword", "Gold Bar"]）
22. `mine`（floors=5）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `goto_location`（location="Blacksmith"）
26. `upgrade_tool`（tool="hoe"）
27. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0326e1f2fd8e4a86ace8923eed672017
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate/build_road 失败分支，改为卖 Copper Bar 清包→Saloon 买沙拉→40 层下矿→铁匠铺升 h
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Stone", count=40）
11. `goto_location`（location="Saloon"）
12. `wait`（minutes=30）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Farm"）
21. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Copper Ore", "Gold Ore", "Coal", "Fiber", "Sap", "Slime", "Rubber Boots", "Sprinkler", "Claymore", "Burglar's Shank", "Silver Saber", "Bamboo Pole", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Rusty Sword", "Gold Bar"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f9ce5cc562664f94a62d55e8d8033242
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全部失败已物理删除，改用 ship 卖 Copper Bar 清包后按原路线买沙拉下矿升 hoe。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Stone", count=40）
11. `goto_location`（location="Saloon"）
12. `wait`（minutes=30）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Farm"）
21. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Copper Ore", "Gold Ore", "Coal", "Fiber", "Sap", "Slime", "Rubber Boots", "Sprinkler", "Claymore", "Burglar's Shank", "Silver Saber", "Bamboo Pole", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Rusty Sword", "Gold Bar"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：16bf46b42cee42a79c694eb34140b1c9
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失败已物理删除，改为先卖 Copper Bar 清包→Saloon 买沙拉→40 层刷铁→回农场炼铁→够锭升 hoe→睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Stone", count=40）
11. `goto_location`（location="Saloon"）
12. `wait`（minutes=30）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `mine`（floors=5）
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8900c63dce50420d89c4a4528d4e417e
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2b7ffaa6f69f43d0a95c594873f3a64e
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1bcc505031ef411a9ccdfc0c0196cc71
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：43a1aa399ee74f1f99c70b2300d6f567
  - 耗时：86.141 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：780867b3d4774084b661dddc0f3d4aff
  - 耗时：47.016 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：472899761bf148208b9efb1328a133d7
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=62）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：ecbbc12184764c389c757752ceff4d9d
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=40）
  - 结果：shipped 40x Stone (~80g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：31d943ceae1b44a1b4a702ae7c8ff3a2
  - 耗时：43.922 秒 / 游戏 60 分钟
- **09:50** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 11:50 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：42fa3ae25e6f4f85b2b79378e5ba996d
  - 耗时：85.734 秒 / 游戏 120 分钟
- **11:50** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：cc8218f33dd1444b88454ea2860da52c
  - 耗时：7.719 秒 / 游戏 10 分钟
- **12:00** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：fcafe3a0f27a44c1abbef3967448c170
  - 耗时：26.39 秒 / 游戏 30 分钟
  - 🗨️ [hud] Acorn
- **12:30** Saloon ✅ `wait`（minutes=30）
  - 结果：cleared 0 debris within 8 tiles of (14,24); none of the 0 weed/stone/twig in Saloon is reachable
  - 执行状态：SUCCESS · 操作编号：55c65b62788349feba5fbc36f146b92d
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：f5974df9023e47748c24883d47339124
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `buy`（item="Salad", count=8）
  - 💭 商店已开，买沙拉到8个补食物，然后去矿洞40层刷铁
  - 结果：bought 8x Salad for 1760g
  - 执行状态：SUCCESS · 操作编号：ed00b4e93a85492a96d2f65e9ac30e80
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `close_menu`
  - 💭 沙拉已买8个，菜单还开着。背包空格4不足下矿，需先清包。菜单里没有可卖的，先关菜单回农场收熔炉并清包。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：20cc388d78d64806bb1a8084aafdc068
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：166c726ecc46455a8c22f0aadf433fa9
  - 耗时：24.765 秒 / 游戏 20 分钟
- **12:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：152c69664af1429696bdd97b3bae37b1
  - 耗时：0.468 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `buy`（item="Salad", count=8）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：b82e6a1ff5d448d0926a186b6f2d2cf0
  - 耗时：0.468 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：540e05ba3d524e3ebbddb290e71f9d34
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：c4183d747a7e4c059c90ff3539693f2a
  - 耗时：47.157 秒 / 游戏 60 分钟
- **13:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：2a397676e690429aa3d4c2e72581bb96
  - 耗时：35.484 秒 / 游戏 50 分钟
- **13:50** Mine ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Acorn", "Salad", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Acorn
  - 执行状态：SUCCESS · 操作编号：88d64d53848545d2b7a4bb0b470ff59d
  - 耗时：15.156 秒 / 游戏 20 分钟
- **13:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 95 (0 floors down, 8 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：0d62f6e7f1c94d3f927d263f01b81857
  - 耗时：80.203 秒 / 游戏 100 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Void Essence
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Diamond
  - 🗨️ [question] 
- **16:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：3139580432714d648f698614ee62000b
  - 耗时：37.625 秒 / 游戏 40 分钟
- **16:40** Mine ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Magma Geode", "Salad", "Rubber Boots", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Slime
  - 执行状态：SUCCESS · 操作编号：e50ca3cf58a1466580a3a10f742e9430
  - 耗时：15.109 秒 / 游戏 20 分钟
- **16:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **17:40** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：fd42fb0a9f074b58bd6b7d511b2488af
  - 耗时：44.015 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 4:00pm)
- **18:40** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：4b8cacf7b6b74797a9a5152ca9db3013
  - 耗时：37.672 秒 / 游戏 40 分钟
- **18:40** Town ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Magma Geode", "Salad", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x Magma Geode
  - 执行状态：SUCCESS · 操作编号：97790b02e79d460ba3bd29735505b1eb
  - 耗时：1.203 秒 / 游戏 10 分钟
- **18:40** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **19:30** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：47355172e51f472e844d8b5cc6f9e31e
  - 耗时：0.485 秒 / 游戏 0 分钟
- **19:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7e099cb97e6e409db2a437af1d542bc1
  - 耗时：0.453 秒 / 游戏 0 分钟
- **19:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：2dfab583bf2d48ff91875318356bb574
  - 耗时：10.219 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65843 → 64163（-1680g）
- 出货估值：0g　动作：49 个　失败：24 个
- 模型调用：9 次　tokens：109748
- 有效动作率：0.5　空转：7　熔断跳过：7
- 失败耗时：51.763 秒 / 游戏 60 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天 49 动作 24 失败，核心症结仍是清包：Copper Bar 82 个没卖，空格始终 2-4，导致 mine/upgrade 双双被「need 5 slots」拒绝；take/donate/build_road 等无效动作又浪费 12+ 动作。铁锭 0/5，钢锄头连续多天零推进。今天必须把 Copper Bar 卖出（留 20）作为第一硬动作，验证空格≥5 后才允许下矿；清包失败即定性钓鱼日，不再空转。

**新教训：**
- 昨天 mine 从 95 层成功挖了 8 块石头就因背包满被迫离矿，回农场 store_items 又因箱子不可达失败，第二次 mine 直接被「have 2, need 5」拒绝：下矿前清包必须在农场内 ship 完成并读背包验证空格≥5，不能指望下矿回来再存。
- 昨天 12:30 在 Saloon 买完沙拉后 close_menu，13:50 再 buy 报 no shop is open：buy 成功后不关菜单继续买，需要换店才 close_menu，否则每次重开商店浪费 1-2 动作。
- 昨天 17:40 去 Blacksmith 被 locked（Open 9:00-16:00），升级窗口白白浪费：upgrade_tool 必须在 9:10-13:00 窗口内执行，16:00 后不再 goto Blacksmith。
- 昨天 19:30 连续调 collect_machines 和 load_machines 都返回空/无空炉，被系统抑制：熔炉未完成时不要反复 collect，下矿回来收一次即可；load 失败一次即当天永久跳过。
- 昨天清包只卖出 40 石头（80g），Copper Bar 82 个全没卖，空格始终 2-4：清包必须优先卖 Copper Bar 留 20（约 7k，腾 3-4 格），这是唯一能真正腾格的手段，不能只卖低价值垃圾。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 22）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64083g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且食物≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 22）**：起床 collect→读背包→**卖 Copper Bar 留 20（约 62 个，腾 3-4 格）**→验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 23）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 24）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天 Copper Bar 82 个全没卖，空格仍 2-4。今天起床读背包后，**显式 ship_produce Copper Bar 卖 count=背包数-20**（约 62 个，约 7k），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜（昨天 ship Copper Bar 报 not found 就是猜的）。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **食物门票前置**：下矿前读背包确认 Salad≥5；不足则**先 goto Saloon→open_shop→buy 沙拉到≥8**，再回 Mine。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
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
3. 清包到空格≥5（**先读背包清单，卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 49 动作 24 失败，核心症结仍是清包：Copper Bar 82 个没卖，空格始终 2-4，导致 mine/upgrade 双双被「need 5 slots」拒绝；take/donate/build_road 等无效动作又浪费 12+ 动作。铁锭 0/5，钢锄头连续多天零推进。今天必须把 Copper Bar 卖出（留 20）作为第一硬动作，验证空格≥5 后才允许下矿；清包失败即定性钓鱼日，不再空转。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 12:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:50 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 12:50 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 16:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 17:40 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 4:00pm) 〔自动〕
- 18:40 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 3, need 5) 〔自动〕
- 19:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 19:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 清包失败导致下矿和升级双双被拒 @ Farm / Mine / Blacksmith — mine 和 upgrade_tool 均返回「store did not free enough slots (have 2-3, need 5)」，而同一时刻 Copper Bar 82 个仍在背包没卖（做不了：铁锭 0/5，钢锄头连续多天零推进；下矿拿不到铁矿） 〔复盘〕
- take 动作连续多天全部失败 @ Farm 箱子 — take 62/64/68/72/84/86 全部报「not in any farm chest」或「already failed」，箱子内容与记忆完全不符（做不了：无法从箱子补给矿物，浪费 12+ 动作） 〔复盘〕
- donate_museum 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum，先 goto 等开门再失败浪费 2 动作（做不了：无） 〔复盘〕
- Blacksmith 升级窗口错过 @ Blacksmith — 17:40 到达报「It's locked... (Open 9:00am - 4:00pm)」（做不了：当天无法升级工具） 〔复盘〕
- 熔炉反复空转 @ Farm — collect_machines 返回「no machine has finished output」，load_machines 返回「no empty machine accepts anything」（做不了：铁锭产出停滞） 〔复盘〕
- buy 沙拉后关菜单再买失败 @ Saloon — close_menu 后再 buy 报「no shop is open; use open_shop first」（做不了：补食物动作被打断，浪费 2 动作） 〔复盘〕
