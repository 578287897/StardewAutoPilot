# 第5年 spring 1 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（13:31 开始）
- 天气：sunny　金钱：60309g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y5_spring_01）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收炉 + 有空炉且铁矿石够就投铁矿石
- 一次清包到空格≥12（store_items 不指定坐标 + ship_produce）
- 去 Forest 河边钓鱼补食物到≥5
- 电梯直达 80 层下矿 80→84 专挖铁矿石+煤（≤2 次）
- 回农场收炉，铁锭≥5 且 13:00 前到铁匠铺升 hoe
- 春季第 1 天在皮埃尔买土豆/花椰菜种子并种下
- 21:30 前 sleep
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
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Iron Bar", "Gold Bar", "Frozen Geode", "Geode", "Omni Geode", "Amethyst"]）
14. `store_items`
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `goto_location`（location="Mine"）
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="SeedShop"）
25. `open_shop`（shop_id="SeedShop"）
26. `buy`（item="Potato Seeds", count=20）
27. `buy`（item="Cauliflower Seeds", count=10）
28. `close_menu`
29. `goto_location`（location="Farm"）
30. `plant_seeds`（item="Potato Seeds", count=20）
31. `plant_seeds`（item="Cauliflower Seeds", count=10）
32. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：cae84e5751c54d3895bfeb4858ea86c5
  - 耗时：20.829 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 2x Bug Meat, 1x Amethyst, 2x Fiber, 1x Sap, 1x Slime, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：81756bdb8d5740d3ba2130c14f3032f5
  - 耗时：15.187 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：99d2521003e341df9e6466ae5941da15
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：2518fc560fa84141b69f39bd679e19b7
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：b6265e07cc00407f859fced792d5c7f3
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：56250d78b2a54fb4b6edda4cf8868136
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take（箱子无宝石），改为收炉→清包→Forest 补食物→80 层挖铁→回炉→13:00 前升 hoe→买春季种子种下。
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
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `store_items`
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Iron Bar", "Gold Bar", "Frozen Geode", "Geode", "Omni Geode", "Amethyst"]）
24. `collect_machines`
25. `store_items`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `plant_seeds`（item="Cauliflower Seeds", count=10）
28. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：bb2e185526c74af1ba4cb2ad5033bb49
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take 分支（箱子内容与记忆不符），改为清包→钓鱼补食物→80 层下矿挖铁→回农场收炉→铁匠铺升 hoe→买春季种子种下。
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
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `store_items`
23. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Iron Bar", "Gold Bar", "Frozen Geode", "Geode", "Omni Geode", "Amethyst"]）
24. `collect_machines`
25. `store_items`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `plant_seeds`（item="Cauliflower Seeds", count=10）
28. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：62a0db4b06924edaa460f890cd4da1b9
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 分支，改走清包→钓鱼补食物→80层下矿拿铁矿石→买春种并种下，13:00 前若凑齐铁锭再升 hoe。
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
13. `goto_location`（location="SeedShop"）
14. `open_shop`（shop_id="SeedShop"）
15. `buy`（item="Potato Seeds", count=20）
16. `buy`（item="Cauliflower Seeds", count=10）
17. `close_menu`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `store_items`
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Iron Bar", "Gold Bar", "Frozen Geode", "Geode", "Omni Geode", "Amethyst"]）
22. `collect_machines`
23. `store_items`
24. `plant_seeds`（item="Potato Seeds", count=20）
25. `plant_seeds`（item="Cauliflower Seeds", count=10）
26. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：19b02bdd763c4dcd92c9e3437b33afb7
  - 耗时：0.407 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e0b3a35fcffd4eec868d20407c3aa51e
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8f01ecd63d474b41bb0f2cea42b3e1c1
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：f493399ea9214732800d34c520225bdf
  - 耗时：53.625 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：a4b6da11501f4dd5859bb4dd0624e3e4
  - 耗时：43.704 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：607536b19a644aa588b10f4673e62300
  - 耗时：0.39 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：bade6b0667144188a77e0b283ae57f0f
  - 耗时：26.407 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Sunfish, River Jelly, Chub)
  - 执行状态：SUCCESS · 操作编号：f0619859ee314b9ba512c06fcc4477f3
  - 耗时：67.594 秒 / 游戏 60 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] River Jelly
- **10:20** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：2d0eb6abb80c45dab1638b1ba5f7e236
  - 耗时：63.359 秒 / 游戏 80 分钟
- **11:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：47d76ee439464b1cb560b4b787eaadf8
  - 耗时：33.687 秒 / 游戏 40 分钟
- **11:40** Mine ✅ `store_items`（items=["Stone", "Geode", "River Jelly", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Geode, 1x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：b4b167a541d84691b4588a4ccfd22265
  - 耗时：15.016 秒 / 游戏 20 分钟
- **11:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 85 to 89 (4 floors down, 69 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：caf133e75c6d4302ae68fae736684510
  - 耗时：201.078 秒 / 游戏 260 分钟
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
  - 🗨️ [hud] Omni Geode
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **17:00** Mine ✅ `goto_location`（location="SeedShop"）
  - 结果：arrived at SeedShop (6,29)
  - 执行状态：SUCCESS · 操作编号：186ef8c658ea4a4eaecccfc740c9eabc
  - 耗时：42.625 秒 / 游戏 60 分钟
- **18:00** SeedShop ✅ `open_shop`（shop_id="SeedShop"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：e06559f6073f4c648a5ef2acc704b663
  - 耗时：0.593 秒 / 游戏 0 分钟
- **18:00** SeedShop ✅ `close_menu`
  - 💭 商店已开，背包仅1空格。先买种子会失败，先关菜单清包。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：09abbae1650941429820ddd79583d30f
  - 耗时：0.453 秒 / 游戏 0 分钟
- **18:00** SeedShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：cacf9dba7c424538acff542f39b2b8c3
  - 耗时：21.781 秒 / 游戏 20 分钟
- **18:20** Farm ✅ `store_items`
  - 结果：stored in chest at (75,15): 119x Stone
  - 执行状态：SUCCESS · 操作编号：356d6e503a204a2a868ed8b8d94a31e7
  - 耗时：1.125 秒 / 游戏 0 分钟
- **18:20** Farm ❌ `buy`（item="Potato Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：cd98570a7ea748599d93bdc35ca8acf0
  - 耗时：0.406 秒 / 游戏 0 分钟
- **18:20** Farm ❌ `buy`（item="Cauliflower Seeds", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：38b93ac86f764228a47dced8d68726c0
  - 耗时：0.391 秒 / 游戏 0 分钟
- **18:20** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：f9b8027a400d468eb31bbad7edbfe8c3
  - 耗时：0.453 秒 / 游戏 0 分钟
- **18:20** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：52fb84e4542643e597cb450b1434ffff
  - 耗时：0.391 秒 / 游戏 0 分钟
- **18:20** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：92a2fe133b734ea8b01ca2d8c88c1405
  - 耗时：22.39 秒 / 游戏 30 分钟
  - 🗨️ [hud] Copper Bar
- **18:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 2x Copper Bar, 4x Coal
  - 执行状态：SUCCESS · 操作编号：7c528181b3814f19923f2229344917ec
  - 耗时：15.171 秒 / 游戏 20 分钟
- **19:10** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Iron Bar", "Gold Bar", "Frozen Geode", "Geode", "Omni Geode", "Amethyst"]）
  - 结果：shipped 4 stacks worth ~335g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：e9421616503d43aea67cf01885106d2c
  - 耗时：0.75 秒 / 游戏 0 分钟
- **19:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：84784901750d44af958a77faff28ef54
  - 耗时：0.391 秒 / 游戏 0 分钟
- **19:10** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1a339aaf4fac43fcb32a6d67cf2bc500
  - 耗时：0.39 秒 / 游戏 0 分钟
- **19:10** Farm ❌ `plant_seeds`（item="Potato Seeds", count=20）
  - 结果：'Potato Seeds' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：189cdac1ea3e485a96a111933013383a
  - 耗时：0.406 秒 / 游戏 0 分钟
- **19:10** Farm ❌ `plant_seeds`（item="Cauliflower Seeds", count=10）
  - 结果：'Cauliflower Seeds' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：ffc185bc99714652b8efe20a07656d0f
  - 耗时：0.391 秒 / 游戏 0 分钟
- **19:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：bb2f697682e9444f9257fe7132121632
  - 耗时：10.781 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：60309 → 60644（+335g）
- 出货估值：335g　动作：44 个　失败：20 个
- 模型调用：7 次　tokens：80383
- 有效动作率：0.5405　空转：5　熔断跳过：6
- 失败耗时：6.345 秒 / 游戏 0 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是 12 次 take 不存在的宝石和 2 次无店铺 buy，真正有效的是钓鱼 4 cast 全成功和 85→89 层挖到金矿。铁锭链仍零推进：铁矿石只有 4，熔炉却只炼铜。今天必须把铁矿石投炉、下矿专挖铁，并修正买种子的顺序（先开店再买，且背包留空）。

**新教训：**
- 昨天两座熔炉炼的是铜而不是铁，铁矿石 4 个一直没动：load_machines 必须指定 item=Iron Ore，且投料前先确认铁矿石≥5，否则炼铜对钢锄头里程碑零贡献。
- 昨天 buy 在 close_menu 之后调用返回「no shop is open」：买种子必须 goto SeedShop → open_shop 成功 → 再 buy，中间不能关菜单；buy 失败一次即重开 open_shop，不连续 buy。
- 昨天 85→89 层只挖到金矿没铁矿，说明铁矿密集区在 80 层附近而非 89 层：下矿目标层应写 80→84，不要从 89 层继续往下爬。
- 昨天 plant_seeds 在没买到种子时被调用，返回「not found in inventory」：种植动作必须紧跟 buy 成功之后，脚本生成阶段若 buy 未成功则物理删除 plant 分支。
- 昨天 donate_museum 在背包无捐赠物时被调用失败：donate 前必须先读背包确认有可捐物品（古物/矿物），没有就物理删除 donate 分支，不要空跑。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 1）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 60309g 充足，铁锭 0、铁矿石 4、煤 25，瓶颈是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 1）**：起床收炉 → 空炉且铁矿石≥5 投铁矿石（不是铜！）→ 清包到空格≥12 → 电梯直达 80 层下矿 80→84 专挖铁矿石+煤（≤2 次 mine）→ 回农场收炉 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 2）**：春季种植启动——皮埃尔买土豆/花椰菜种子（先 open_shop 再 buy，背包留 ≥5 空格），种下；hoe 已升则转钢斧，否则继续下矿炼铁。
- **后天（春 3）**：铁锭富余则 craft 洒水器落地；13 日复活节前攒钱买草莓种子。

## 今日核心修正
1. **take 全天物理删除**：昨天 12 次 take 全失败（宝石 62/64/68/72/80/84 不在箱中）。脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **熔炉投铁矿石，不投铜**：昨天两炉炼的是铜，铁矿石 4 个一直没动。起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。
3. **清包一次到空格≥12**：起床 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证。两次仍<12 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包成功后全天禁止任何 take。
4. **买种子顺序硬约束**：先 goto SeedShop → open_shop 成功 → 再 buy；buy 返回「no shop is open」说明 open_shop 未生效，立即重开一次，不连续 buy。买前读背包确认空格≥5，不足先 store_items。
5. **下矿目标 80→84**：电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**（昨天 85→89 只拿到金矿没铁矿）。
6. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
7. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。**upgrade_tool 必须带 tool=hoe 参数**，并在日志确认返回的是升级结果而非挖矿结果。
8. **路径失败即换路**：store_items/ship_produce 返回 could not reach 时，立即改不指定坐标或直接 ship_produce，**不重试同一坐标**。
9. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
10. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥12**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥12 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **买春季种子（仅当时间 <17:00 且背包空格 ≥5）**：goto SeedShop → open_shop → buy Potato Seeds 20 / Cauliflower Seeds 10；buy 失败一次即跳过，不连续 buy。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥12，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <12 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥12 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。
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
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床 collect_machines 1 次**（收熔炉成品）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. **一次性清包到空格 ≥12**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥12、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，背包空格 ≥5，buy 失败一次即跳过）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是 12 次 take 不存在的宝石和 2 次无店铺 buy，真正有效的是钓鱼 4 cast 全成功和 85→89 层挖到金矿。铁锭链仍零推进：铁矿石只有 4，熔炉却只炼铜。今天必须把铁矿石投炉、下矿专挖铁，并修正买种子的顺序（先开店再买，且背包留空）。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 06:40 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 18:20 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 18:20 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 18:20 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 19:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 19:10 动作 `plant_seeds` 失败 @ Farm — 'Potato Seeds' not found in inventory 〔自动〕
- 19:10 动作 `plant_seeds` 失败 @ Farm — 'Cauliflower Seeds' not found in inventory 〔自动〕
- 12 次 take 宝石（62/64/68/72/80/84）全部失败，触发「already failed; not retrying today」连锁，吃掉大量动作预算 @ Farm 箱子旁 — '62'/'64'/'68'/'72'/'80'/'84' is not in any farm chest（做不了：浪费动作预算，博物馆捐赠和献祭物品无法凑齐） 〔复盘〕
- 铁锭链连续多天零推进，钢锄头卡在缺 5 铁锭 @ 矿洞 80 层以下 / 熔炉 — 铁矿石仅 4 个，两座熔炉却只炼铜；下矿目标层停在 85-89 层拿不到铁矿（做不了：钢锄头无法升级，洒水器也无法 craft（缺铁锭）） 〔复盘〕
- 买种子时先 close_menu 再 buy，导致 buy 失败 @ SeedShop — no shop is open; use open_shop first（做不了：春季第 1 天没买到土豆/花椰菜种子，种植延后） 〔复盘〕
- plant_seeds 在没买到种子时被调用 @ Farm — 'Potato Seeds' not found in inventory（做不了：春季种植无法启动） 〔复盘〕
- donate_museum 在背包无可捐物时被调用 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费动作，博物馆收集包无进展） 〔复盘〕
- collect_machines 在 19:10 返回空，收炉时机偏晚 @ Farm 熔炉 — no machine has finished output（做不了：铁锭收取延后，升级窗口错过） 〔复盘〕
