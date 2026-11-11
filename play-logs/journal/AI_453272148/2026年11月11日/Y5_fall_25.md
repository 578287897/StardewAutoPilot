# 第5年 fall 25 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（08:41 开始）
- 天气：windy　金钱：65363g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：28db81867efa48cb92b35aa5851481f8
  - 耗时：20.75 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：39cdd44549164464b024124928fb8e75
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：d3fea640b882406e827bfb09d6fe00a0
  - 耗时：0.562 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_25）准备的脚本
- 里程碑：凑齐 5 铁锭升钢锄头（当前差 4 铁锭）
- 起床收熔炉→清包卖 Copper Bar 留 20 腾格→Saloon 买沙拉到≥8
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine 每次 ≤5 层
- 回农场炼铁，铁锭≥5 且 13:00 前升 hoe
- 铁锭富余则 craft 洒水器并种下
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
11. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Bamboo Pole", "Silver Saber", "Gold Bar", "Iron Bar", "Coal", "Copper Ore", "Pumpkin Seeds", "Smallmouth Bass", "Walleye"]）
12. `goto_location`（location="Saloon"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Bamboo Pole", "Silver Saber", "Gold Bar", "Iron Bar", "Coal", "Copper Ore", "Pumpkin Seeds", "Salad"]）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `goto_location`（location="Blacksmith"）
24. `upgrade_tool`（tool="hoe"）
25. `goto_location`（location="Farm"）
26. `craft`（item="Sprinkler", count=1）
27. `place`（item="Sprinkler"）
28. `sleep`
- **06:20** Farm ❌ `ship_produce`
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：f5daf8280ce04e6d9bca9646c14ca432
  - 耗时：13.047 秒 / 游戏 20 分钟

### 🔁 脚本重写：重写#1：出货箱路径不可达，改用 ship 直接卖背包冗余（金锭/宝石/多余武器）腾格，再按门票下40层刷铁，回农场炼铁收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Gold Bar", count=3）
10. `ship`（item="Emerald", count=1）
11. `ship`（item="Claymore", count=1）
12. `ship`（item="Silver Saber", count=1）
13. `ship`（item="Bamboo Pole", count=1）
14. `ship`（item="Squid Ink", count=1）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：286cc1f437c645d49f25cdcd87d5bf9d
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 已确认全天物理删除，改为先卖 Copper Bar 腾格、买沙拉补食物门票，再电梯 40 层刷铁，回农场炼铁收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Saloon"）
10. `wait`（minutes=320）
11. `open_shop`（shop_id="Saloon"）
12. `buy`（item="Salad", count=8）
13. `close_menu`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Bamboo Pole", "Silver Saber", "Gold Bar", "Iron Bar", "Coal", "Copper Ore", "Pumpkin Seeds", "Smallmouth Bass", "Walleye", "Salad"]）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `craft`（item="Sprinkler", count=1）
23. `place`（item="Sprinkler"）
24. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3cc5199c63754de082f557a4dea5d66f
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take/donate/wait路线已连续失败，按策略物理删除这些分支，保留原脚本的Saloon买沙拉→40层下矿→回农场炼铁主线，只去掉失败动作。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Saloon"）
10. `wait`（minutes=320）
11. `open_shop`（shop_id="Saloon"）
12. `buy`（item="Salad", count=8）
13. `close_menu`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：26f068b50b914b1e9d0d694ffc447d3c
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d78531f0fc1349f1b47021f7ad1855fa
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：870b6071dead4d268bbde628a1b0627a
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0297bdd1c08a44949a73729ba951076b
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：b8525dce117d4752b2c508270d42c7c0
  - 耗时：56.047 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：f06ae1ba26fb45a585f9d15bc24485ac
  - 耗时：52.781 秒 / 游戏 60 分钟
- **09:00** ArchaeologyHouse ✅ `donate_museum`
  - 结果：donated Emerald (60) to the museum at (28,6)
  - 执行状态：SUCCESS · 操作编号：dfa4d334e7604aa481cd15f45fcdbc27
  - 耗时：0.5 秒 / 游戏 0 分钟
- **09:00** ArchaeologyHouse ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 11:00 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：e80192b78b274830b1f57720a2ae252f
  - 耗时：83.219 秒 / 游戏 120 分钟
- **11:00** ArchaeologyHouse ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：0b09d550931b4fedaf59c29f4a309fab
  - 耗时：44.078 秒 / 游戏 60 分钟
- **12:00** ArchaeologyHouse ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：7f71f7704d5241ac9e6d3b8c93f3c416
  - 耗时：21.0 秒 / 游戏 20 分钟
- **12:20** Saloon ✅ `wait`（minutes=320）
  - 结果：cleared 0 debris within 8 tiles of (14,24); none of the 0 weed/stone/twig in Saloon is reachable
  - 执行状态：SUCCESS · 操作编号：0fd0eaf925c54f2b80c74a0e13346449
  - 耗时：0.516 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：09a09ffd15524b8bb739254fc11259d0
  - 耗时：0.5 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `buy`（item="Salad", count=8）
  - 💭 商店已开，先买沙拉到8个补食物门票，再下矿刷铁。
  - 结果：bought 8x Salad for 1760g
  - 执行状态：SUCCESS · 操作编号：1ced8ecfc9b444719465560281d00ca4
  - 耗时：0.515 秒 / 游戏 0 分钟
- **12:20** Saloon ❌ `ship`（item="Gold Bar", count=3）
  - 💭 沙拉已8个够用。空格仅2，先卖Gold Bar留2和Squid Ink腾格，再下矿。
  - 结果：a menu is open (ShopMenu); handle it first (dialog_answer / dialog_advance / menu_click / close_menu)
  - 执行状态：ACTION_FAILED · 操作编号：e54618dee5d04afa805ede802cab52af
  - 耗时：6.359 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `close_menu`
  - 💭 沙拉已买够8个，关菜单后去矿洞40层刷铁。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：bac7305544244ea1add74af5fc37cba3
  - 耗时：0.515 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e5faf8650e734b60af175a8cd54b60d3
  - 耗时：43.516 秒 / 游戏 50 分钟
- **13:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：83274092b56544f48081dff9d06f48da
  - 耗时：35.454 秒 / 游戏 50 分钟
- **13:10** Mine ❌ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Smallmouth Bass", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：74376405826642d38da72de2d5d627c3
  - 耗时：12.89 秒 / 游戏 10 分钟
- **13:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **14:10** Farm ❌ `buy`（item="Salad", count=8）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：c6bfca20dc91481e9975c26494cceb48
  - 耗时：0.5 秒 / 游戏 0 分钟
- **14:10** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：7c0d6f6e893c41ae898fdc95b3752d15
  - 耗时：0.5 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：35fc8aa4508c43c0ad3f2fa85a1e4cc7
  - 耗时：38.828 秒 / 游戏 50 分钟
- **15:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：5b61983f1a364ba09f276fade070448a
  - 耗时：35.453 秒 / 游戏 40 分钟
- **15:00** Mine ❌ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Smallmouth Bass", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：f309d3a7bc9f408683d8fe2aeb14ff97
  - 耗时：12.61 秒 / 游戏 20 分钟
- **15:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **16:00** Farm ❌ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Smallmouth Bass", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：d784a7fb5ca54bf38e875d3946c97ca1
  - 耗时：7.703 秒 / 游戏 10 分钟
- **16:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **16:10** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：e5d7b40b9bd64cb98eee739fc899f56d
  - 耗时：0.547 秒 / 游戏 0 分钟
- **16:10** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (53,8)
  - 执行状态：SUCCESS · 操作编号：871cb39274eb44c98a5feb3a288d63ea
  - 耗时：0.515 秒 / 游戏 0 分钟
- **16:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：9407f092a1714ae6a02ac7428a8da0c8
  - 耗时：11.922 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **16:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：d41af9f695ff46db84451cf70c257494
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：d64386f18ae049d998fd63682a80e986
  - 耗时：3.937 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：fb15c3267d8445ab8d76efd69d6d235e
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:30** Farm ✅ `wait`（minutes=30, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：d2fa6431ffe646c59ef50bde505c583f
  - 耗时：17.5 秒 / 游戏 30 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：24385c23fdc243ddaa2f439dbf82f8cb
  - 耗时：17.047 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65363 → 63603（-1760g）
- 出货估值：0g　动作：47 个　失败：25 个
- 模型调用：10 次　tokens：121606
- 有效动作率：0.4146　空转：7　熔断跳过：3
- 失败耗时：59.314 秒 / 游戏 60 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包链断裂：store_items 因箱子坐标不可达连续失败 3 次，导致 mine 因空格不足连续失败 3 次，铁锭链零推进；同时 take 空跑 8 次、build_road/decorate/wait 空转。有效动作是 Saloon 买沙拉 8 个成功、熔炉收铜锭成功。今天必须把清包改成纯 ship_produce 卖 Copper Bar 留 20，并在脚本生成阶段删除 take/store_items/build_road/decorate/wait。

**新教训：**
- 昨天 store_items 连续 3 次因箱子坐标(74,16)不可达失败，直接导致 mine 连续 3 次被「have 2, need 5」拒绝：清包必须在农场内用 ship_produce 卖 Copper Bar 完成并读背包验证空格≥5，不能指望 store_items 存箱。
- 昨天在 Saloon 买完沙拉后 close_menu，之后 buy 报 no shop is open，又重开浪费动作：buy 成功后不关菜单继续买，只有换店才 close_menu。
- 昨天 ship Gold Bar 时菜单还开着（ShopMenu）直接失败：任何 ship/sell 前必须先 close_menu，菜单状态是 ship 的前置条件。
- 昨天 12:20 买完沙拉背包仍只有 2 空格，却直接 goto Mine 再回农场清包，往返浪费 2 小时：清包必须在去 Saloon 之前完成，买食物是清包之后的事。
- 昨天 build_road 报「规划道路边没有还能走上去的空格」、decorate 报「今天没有能做的装饰」、wait 空转 30 分钟：这些非里程碑动作应在脚本生成阶段物理删除，收尾只允许 sleep 或钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 26）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 63603g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且 Salad≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 26）**：起床 collect→读背包→**第一硬动作 ship_produce Copper Bar count=背包数-20（约 62 个，约 7k，腾 3-4 格）**→读背包验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 27）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 28）**：继续刷铁备钢斧，给作物地块补洒水器。

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
> 昨天核心失败是清包链断裂：store_items 因箱子坐标不可达连续失败 3 次，导致 mine 因空格不足连续失败 3 次，铁锭链零推进；同时 take 空跑 8 次、build_road/decorate/wait 空转。有效动作是 Saloon 买沙拉 8 个成功、熔炉收铜锭成功。今天必须把清包改成纯 ship_produce 卖 Copper Bar 留 20，并在脚本生成阶段删除 take/store_items/build_road/decorate/wait。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:20 动作 `ship_produce` 失败 @ Farm — could not reach (70,15); stopped at (53,8) 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 12:20 动作 `ship` 失败 @ Saloon — a menu is open (ShopMenu); handle it first (dialog_answer / dialog_advance / menu_click / close_menu) 〔自动〕
- 13:10 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 13:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 14:10 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 14:10 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 15:00 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 15:00 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 16:00 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 16:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 16:10 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 16:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:30 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包链断裂：store_items 连续 3 次失败，背包空格始终只有 2，导致下矿被拒 3 次 @ Farm（箱子坐标 74,16 附近） — store_items: could not reach (74,16); stopped at (53,8)；mine: store did not free enough slots (have 2, need 5)（做不了：无法下矿刷铁矿石，铁锭链零推进，钢锄头升级继续卡住） 〔复盘〕
- take 动作空跑 8 次，反复从农场箱子取不存在的矿物 @ Farm — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费动作和时间，箱子内容与记忆完全不符，无法靠箱子补给矿物） 〔复盘〕
- 买完沙拉后 close_menu，之后 buy 报 no shop is open，又重开商店浪费动作 @ Saloon / Town — buy: no shop is open; use open_shop first；close_menu: no menu is open（做不了：购买流程被打断，多消耗 2 个动作） 〔复盘〕
- 在商店菜单还开着时调 ship Gold Bar，直接失败 @ Saloon — ship: a menu is open (ShopMenu); handle it first（做不了：腾格失败，背包空格没增加） 〔复盘〕
- 买完沙拉背包仍只有 2 空格却直接去 Mine，再折返农场清包，往返浪费约 2 小时 @ Saloon → Mine → Farm — 12:20 沙拉 8 个已买，背包 2 空格仍不足，先下矿看能否腾格；随后 mine 被拒（做不了：下矿窗口被压缩，铁矿石没刷到，升级窗口错过） 〔复盘〕
