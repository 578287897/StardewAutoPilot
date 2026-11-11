# 第5年 fall 23 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（08:15 开始）
- 天气：sunny　金钱：64963g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：86ec3f0f860c467ebbccff1d200142ca
  - 耗时：3.422 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：d22a2cf19f354b3195bb2d58c068e864
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：ffcd9edf6752442a9226cc92a3b49dc8
  - 耗时：6.157 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：2a2a4883e6d345aebea429e607680f9d
  - 耗时：0.5 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_23）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——今天必须把铁锭从 1 补到 5
- 起床收熔炉→装铁矿石→清包（卖 Copper Bar 留 20 腾格）→确认空格≥5
- Saloon 12:00 开门后买沙拉补到≥8（背包已有 8 个，可跳过）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次 ≤5 层
- 回农场收铁锭，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 铁锭不够则下午继续 40-50 层刷铁，21:30 前 sleep
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
11. `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Void Essence", "Bat Wing", "Coal", "Copper Ore", "Gold Ore"]）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Void Essence", "Bat Wing", "Coal", "Copper Ore", "Gold Ore"]）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="SeedShop"）
22. `open_shop`（shop_id="SeedShop"）
23. `buy`（item="Eggplant Seeds", count=15）
24. `close_menu`
25. `goto_location`（location="Farm"）
26. `plant_seeds`（item="Eggplant Seeds", count=15）
27. `craft`（item="Sprinkler", count=1）
28. `sleep`
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：8ff25bd4ac59449986485e05415e2215
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~100g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：bf6fe99af2f04c828a97af34c79770bd
  - 耗时：0.75 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9cd2c513d6bb400e95865a24a247c161
  - 耗时：0.484 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败即物理删除该分支，改为清包卖 Copper Bar 腾格后直奔 40 层刷铁，回农场收锭升 hoe，顺路买秋季种子。
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
14. `goto_location`（location="SeedShop"）
15. `open_shop`（shop_id="SeedShop"）
16. `buy`（item="Eggplant Seeds", count=15）
17. `close_menu`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Void Essence", "Bat Wing", "Coal", "Copper Ore", "Gold Ore"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `plant_seeds`（item="Eggplant Seeds", count=15）
25. `craft`（item="Sprinkler", count=1）
26. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b17483975a1849578c6340ddbdd065ca
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全部失败已物理删除，改为起床收炉→装铁→卖 Copper Bar 腾格→40 层刷铁→回农场收锭升 hoe。
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
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Coal", "Copper Ore", "Gold Ore", "Stone"]）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `craft`（item="Sprinkler", count=1）
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dddb8d8a0a314e34b8603ef9f5126708
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部删除，改为起床收炉+卖 Copper Bar 腾格，再下 40 层刷铁，铁锭够就升 hoe，最后睡觉。
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
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Coal", "Copper Ore", "Gold Ore", "Stone"]）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
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
  - 执行状态：ACTION_FAILED · 操作编号：ffc0d879c1044315bb0d23238a09b744
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：44b33971cf69469c87d434bd24380e0a
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：60bd9059fcb0452884be8c52d276789b
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：e8447513859f4e0585e8aaee84ad0680
  - 耗时：79.859 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：97f6f80f36594af7914223df89ff9dd9
  - 耗时：44.093 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate_museum`
  - 结果：donated Dwarf Scroll III (98) to the museum at (26,11)
  - 执行状态：SUCCESS · 操作编号：b7e0db160027434b9923ed7ed2a09dd0
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：cb1d31209a4844fabc8ba57c89647717
  - 耗时：50.734 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：c361ac02137f410682e12b24a997bb10
  - 耗时：33.64 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Salad", "Rubber Boots", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：f2c9a3b26f2e4bbdbb4bb1226f8c9799
  - 耗时：15.078 秒 / 游戏 20 分钟
- **09:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 97 (2 floors down, 52 stones broken); retreated: health 44/140 and 0 healing food left; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：384f04537552424c91998deae5cba0d9
  - 耗时：129.844 秒 / 游戏 140 分钟
  - 🗨️ [hud] Squid Ink
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] +112 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [question] 
- **13:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：34adeaddfb6f45a5a4f85fc3abd2fcce
  - 耗时：37.625 秒 / 游戏 50 分钟
- **13:10** Mine ✅ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Magma Geode", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：e28bbe674e954ef69f5998eb185fab80
  - 耗时：15.078 秒 / 游戏 20 分钟
- **13:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **14:20** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：3bb381f4f3044d4cafabd7ee4e46cdfb
  - 耗时：40.359 秒 / 游戏 50 分钟
- **15:10** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：a9f6966482ef408a8c1ec00a3f6ec4e2
  - 耗时：39.11 秒 / 游戏 40 分钟
- **15:10** Blacksmith ✅ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Magma Geode", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x Magma Geode
  - 执行状态：SUCCESS · 操作编号：f94ad6b86e2240f89f16540c062a0200
  - 耗时：1.203 秒 / 游戏 0 分钟
- **15:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：could not reach (6,18); stopped at (6,17)
  - 执行状态：ACTION_FAILED · 操作编号：4155b19011294ba5a378ee0d52fb9cdb
  - 耗时：102.39 秒 / 游戏 140 分钟
  - 🗨️ [hud] Stone
- **18:10** UndergroundMine15 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：543bdfeedec84dbda5c2195ada3d87d5
  - 耗时：42.25 秒 / 游戏 50 分钟
  - 🗨️ [question] 
  - 🗨️ [hud] Stone
- **19:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：aedb757c351c4e5ba7955ee413684373
  - 耗时：0.5 秒 / 游戏 0 分钟
- **19:00** Farm ✅ `ship_produce`（except=["Salad", "Iron Bar", "Gold Bar", "Pumpkin Seeds", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Claymore", "Fiberglass Rod", "Scythe", "Rusty Sword", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Dwarf Scroll III", "Coal", "Copper Ore", "Gold Ore", "Stone"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：6413c1b063c7445fb213a8d768c54855
  - 耗时：0.485 秒 / 游戏 0 分钟
- **19:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：bbeef97422154b9ab8c42ea6cfd0f5f8
  - 耗时：17.016 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64963 → 65063（+100g）
- 出货估值：100g　动作：40 个　失败：21 个
- 模型调用：6 次　tokens：70461
- 有效动作率：0.5　空转：7　熔断跳过：9
- 失败耗时：111.281 秒 / 游戏 140 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包无效：Copper Bar 82 个未卖，空格始终不足，导致 mine 被拒、升级失败。take 12 次全失败仍重试，浪费大量动作。熔炉未完成时反复 collect/load 被抑制。升级窗口因路径不可达错过。今天必须把清包作为第一硬动作，卖 Copper Bar 腾格，然后电梯 40 层刷铁，铁锭够 5 立即升 hoe。

**新教训：**
- 昨天 upgrade_tool 在 Blacksmith 报 could not reach (6,18); stopped at (6,17)：铁匠铺柜台前有阻挡，升级前应先 goto_location Blacksmith 到入口，再走到柜台 (6,18) 附近，若一次不可达即当天跳过，不要重试。
- 昨天 mine 从 95→97 层成功但 health 44/140 且 0 食物撤退：深层矿洞伤害高，下矿前食物≥5 是硬门票，且每层先 fight 清怪再 mine，生命<50% 立即 leave_mine。
- 昨天 19:00 连续 collect_machines/load_machines 被系统抑制：熔炉未完成时不要反复 collect，下矿回来收一次即可；load 失败一次即当天永久跳过。
- 昨天 ship_produce 的 except 列表包含 Copper Bar，导致清包主力被排除：except 只应排除工具、武器、食物、种子和献祭留品，绝不排除 Copper Bar/Gold Bar 等冗余锭。
- 昨天 build_road 报「规划道路边没有还能走上去的空格」：道路铺设不是当前里程碑，应从脚本中彻底删除，收尾只允许 sleep 或钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 24）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64963g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且 Salad≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 24）**：起床 collect→读背包→**第一硬动作 ship_produce Copper Bar count=背包数-20（约 62 个，约 7k，腾 3-4 格）**→读背包验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 25）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 26）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天 Copper Bar 82 个全没卖，空格仍 1-4。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 62 个，约 7k），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
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
> 昨天核心失败是清包无效：Copper Bar 82 个未卖，空格始终不足，导致 mine 被拒、升级失败。take 12 次全失败仍重试，浪费大量动作。熔炉未完成时反复 collect/load 被抑制。升级窗口因路径不可达错过。今天必须把清包作为第一硬动作，卖 Copper Bar 腾格，然后电梯 40 层刷铁，铁锭够 5 立即升 hoe。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 13:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 15:10 动作 `upgrade_tool` 失败 @ Blacksmith — could not reach (6,18); stopped at (6,17) | 游戏消息: [hud] Stone 〔自动〕
- 19:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 19:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 19:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 19:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包无效，Copper Bar 82 个全没卖，背包空格始终 1-4，导致下矿和升级连续被拒 @ Farm（出货箱旁） — ship_produce 的 except 列表包含 Copper Bar，且未显式卖 Copper Bar；mine 报 store did not free enough slots (have 4, need 5)（做不了：下矿刷铁、升级钢锄头全部无法进行） 〔复盘〕
- take 动作连续 12 次失败，脚本重写 3 次仍重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费大量动作，箱子内容与记忆不符，无法靠箱子补矿物） 〔复盘〕
- 熔炉未完成时反复 collect_machines/load_machines，被系统抑制 @ Farm 熔炉 — no machine has finished output；no empty machine accepts that, and the rest are busy；repeated ineffective action suppressed（做不了：浪费动作，未推进炼铁） 〔复盘〕
- upgrade_tool 在 Blacksmith 报路径不可达，升级窗口错过 @ Blacksmith (6,18) — could not reach (6,18); stopped at (6,17)（做不了：钢锄头升级失败，铁锭链继续卡住） 〔复盘〕
- 下矿前食物=0，从 95 层挖 2 层就因 health 44/140 撤退 @ Mine 95-97 层 — retreated: health 44/140 and 0 healing food left（做不了：无法在 40 层以下持续刷铁矿石） 〔复盘〕
- 计划电梯直达 40 层刷铁，实际却从 95 层往下爬，目标与执行脱节 @ Mine 95-97 层 — mine 日志显示从 floor 95 到 97，而非电梯 40 层（做不了：铁矿产出效率低，铁锭链无法推进） 〔复盘〕
