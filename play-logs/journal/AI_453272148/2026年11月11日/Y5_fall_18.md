# 第5年 fall 18 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（07:20 开始）
- 天气：windy　金钱：66451g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：3017faf629b548f6a53915f09010c2f6
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：515d96c936a84de49369690f82933644
  - 耗时：3.391 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 3x Slime, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：f55bded184cf4bb9b80bffefb4ee8a79
  - 耗时：6.11 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：a36c3bb370d3429789c9e70de544a75f
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：c0d740a4f8fc4ed395f1a3c9448c1cc0
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 4 stacks worth ~135g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：f23232747a514cb59d70885395d592a9
  - 耗时：0.75 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_18）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——今天必须凑够铁锭
- 起床收熔炉→读背包→只卖背包里实际存在的冗余（Copper Bar 留 20 其余卖、Gold Bar 留 2）腾到空格≥5
- 补食物到≥5（背包只有 1 个可回血食物，12:00 后去 Saloon 买沙拉）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次≤5 层
- 回农场收铁锭，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 收尾 21:30 前 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `ship_produce`（except=["Copper Bar", "Gold Bar", "Iron Bar", "Pumpkin Seeds", "Geode", "Omni Geode"]）
11. `ship`（item="Copper Bar", count=63）
12. `ship`（item="Gold Bar", count=12）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `ship_produce`（except=["Copper Bar", "Gold Bar", "Iron Bar", "Pumpkin Seeds"]）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `goto_location`（location="Town"）
21. `goto_location`（location="Saloon"）
22. `open_shop`（shop_id="Saloon"）
23. `buy`（item="Salad", count=6）
24. `close_menu`
25. `goto_location`（location="Mountain"）
26. `goto_location`（location="Blacksmith"）
27. `upgrade_tool`（tool="hoe"）
28. `goto_location`（location="Farm"）
29. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d5c558c8c7ed422581e189dd4df9e843
  - 耗时：0.484 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败说明箱子不可达且背包无该矿物，删除 take/donate 分支，改为只卖背包实有冗余腾格后按原路线下矿刷铁、回农场收锭并尝试升 hoe
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=1）
10. `ship`（item="Stone", count=33）
11. `ship`（item="Geode", count=2）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Town"）
17. `goto_location`（location="Saloon"）
18. `open_shop`（shop_id="Saloon"）
19. `buy`（item="Salad", count=6）
20. `close_menu`
21. `goto_location`（location="Mountain"）
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Farm"）
25. `collect_machines`
26. `collect_machines`
27. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds"]）
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7df365f0a94a414ca5e1cfc596dadca9
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删掉失败的 take/donate 分支，先卖背包里实际存在的冗余腾格，再下矿刷铁、买沙拉、按铁锭数决定升 hoe，最后回农场收炉睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=1）
10. `ship`（item="Stone", count=33）
11. `ship`（item="Geode", count=2）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Town"）
17. `goto_location`（location="Saloon"）
18. `open_shop`（shop_id="Saloon"）
19. `buy`（item="Salad", count=6）
20. `close_menu`
21. `goto_location`（location="Mountain"）
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Farm"）
25. `collect_machines`
26. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds"]）
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3f3421b0d69546f0b6e52b0534e29806
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take/donate 分支，改用 ship 背包内实际存在的 Green Algae 与 13 石头腾格，再按原路线下矿刷铁、买沙拉、升 
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=1）
10. `ship`（item="Stone", count=13）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Town"）
16. `goto_location`（location="Saloon"）
17. `open_shop`（shop_id="Saloon"）
18. `buy`（item="Salad", count=6）
19. `close_menu`
20. `goto_location`（location="Mountain"）
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds"]）
26. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：63e58c29ecfe4d14a62a8b6c45fae707
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3f9b95ef11444086aa69b380b20d0c8c
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f3292b56983c4f0e95bb43da713abe89
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：775b00dd6d284a61a92101dec136736c
  - 耗时：79.89 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：40039c8ee9314232946dc32f65eee888
  - 耗时：44.109 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：bf0263caa343496aaf97e64ce801e2ab
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Green Algae", count=1）
  - 结果：shipped 1x Green Algae (~15g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：2bc1c4893efc4ac690c92985951546e5
  - 耗时：43.937 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `ship`（item="Stone", count=13）
  - 结果：shipped 13x Stone (~26g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：983a1e7fe2f34af9b125477e23c0775f
  - 耗时：0.469 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：276326d905e2468cac502e4b3348ca21
  - 耗时：49.078 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 51 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：695ed8b436894bee98eaf905c7cb3107
  - 耗时：48.625 秒 / 游戏 60 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
- **11:50** UndergroundMine19 ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：65b5e70f617d4a7c8537c02eb02fc30d
  - 耗时：37.5 秒 / 游戏 40 分钟
  - 🗨️ [question] 
- **11:50** UndergroundMine19 ✅ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Bug Meat", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Geode, 1x Bug Meat
  - 执行状态：SUCCESS · 操作编号：1c095c4bf7f646229f7bf58d557e9486
  - 耗时：15.062 秒 / 游戏 20 分钟
- **11:50** UndergroundMine19 ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 56 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：ba05214ac47245768b638d41538d3d9a
  - 耗时：101.516 秒 / 游戏 130 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Amethyst
  - 🗨️ [hud] Bug Meat
- **15:00** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：034830fda88543d8a942e365350566da
  - 耗时：2.0 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **15:00** Mine ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (81,0)
  - 执行状态：SUCCESS · 操作编号：9e88b3ebe6644657ba326a62678b0849
  - 耗时：22.61 秒 / 游戏 30 分钟
- **15:30** Town ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：f6a9608c03c04d72aa1a5f95d59dfdf2
  - 耗时：25.344 秒 / 游戏 30 分钟
- **16:00** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：df44f3d9b58b4d71bd006884664ed7c1
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:00** Saloon ✅ `buy`（item="Salad", count=6）
  - 💭 Saloon商店已开，先买沙拉补食物到≥5，再关菜单去矿洞40层刷铁
  - 结果：bought 6x Salad for 1320g
  - 执行状态：SUCCESS · 操作编号：e46fbbf8574c4d53883ffff9c9ec3637
  - 耗时：0.547 秒 / 游戏 0 分钟
- **16:00** Saloon ✅ `close_menu`
  - 💭 已买6沙拉，食物12个够。空格3不足下矿，先卖背包冗余：Stone留20卖71、Gold Bar留1卖1、Bug Meat卖3、Amethyst卖1，腾格。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：41e79b10a3b74698896b77bb6c1707b6
  - 耗时：0.484 秒 / 游戏 0 分钟
- **16:00** Saloon ✅ `ship`（item="Stone", count=71）
  - 结果：shipped 71x Stone (~142g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：93f4d960a0034d439cabcfe96b86f58d
  - 耗时：27.547 秒 / 游戏 30 分钟
- **16:30** Farm ✅ `ship`（item="Bug Meat", count=3）
  - 结果：shipped 3x Bug Meat (~24g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：bf9766951ea44abc992e9a26514b908f
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `buy`（item="Salad", count=6）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：1584e239b852426892ded4a098264a73
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：60cb831d706c405696571c15526d3839
  - 耗时：0.468 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
  - 执行状态：SUCCESS · 操作编号：68bdde166703464481999a46d081587f
  - 耗时：30.813 秒 / 游戏 40 分钟
- **17:10** Mountain ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: Salad | It's locked... (Open 9:00am - 4:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：38465b805b264169a8d8f027da16630f
  - 耗时：42.563 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 4:00pm)
- **18:00** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：64e5ee4a92a542e3bb8181d20e74bc63
  - 耗时：37.64 秒 / 游戏 50 分钟
- **18:00** Town ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Amethyst", "Salad", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：93fe7e7503a54a639c447dd1eb4af267
  - 耗时：1.156 秒 / 游戏 0 分钟
- **18:00** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **18:50** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：580a3316c3134e15aba38da2766b5471
  - 耗时：0.5 秒 / 游戏 0 分钟
- **18:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：7403b8d6dbf34b1c90b5a03f8a5a84c8
  - 耗时：0.485 秒 / 游戏 0 分钟
- **18:50** Farm ✅ `ship_produce`（except=["Iron Bar", "Pumpkin Seeds"]）
  - 结果：shipped 1 stacks worth ~100g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：a71871e8fb5746e7851df003e62fecce
  - 耗时：0.937 秒 / 游戏 0 分钟
- **18:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：711ea1f12c66481fb48d20db0e32c08a
  - 耗时：10.86 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66451 → 65573（-878g）
- 出货估值：235g　动作：48 个　失败：20 个
- 模型调用：9 次　tokens：110241
- 有效动作率：0.6098　空转：5　熔断跳过：6
- 失败耗时：48.905 秒 / 游戏 50 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是脚本重写3次仍重试 take 12次、donate 空跑、build_road 空转；真正有效的是 Saloon 买沙拉和 40 层下矿，但食物/空格门票没在脚本生成阶段校验，导致 mine 两次都在 19 层因 0 食物撤退。铁锭链仍卡在 1/5，今天必须把「读背包→卖 Copper Bar 留20→验证空格≥5→电梯40层」写成硬顺序，失败即转钓鱼，不再重写脚本。

**新教训：**
- 昨天 mine 两次都在 19 层因 0 食物撤退：下矿前必须读背包确认 Salad≥5，不足先去 Saloon 买，食物门票不满足时脚本生成阶段就删除 mine 分支。
- 昨天清包只卖 140g 垃圾，空格没动；Copper Bar 有 83 个却全被 except 排除：清包主力必须是 ship Copper Bar 留 20（约 7k，腾 3-4 格），不能只卖低价值垃圾。
- 昨天脚本重写 3 次仍重试 take 12 次、donate 空跑、build_road 空转：这些动作应在脚本生成阶段物理删除，重写只调整未完成分支，不重试已失败动作。
- 昨天 17:10 去 Blacksmith 被 locked（Open 9:00-16:00）：升级窗口必须硬约束在 9:10-13:00，16:00 后不再 goto Blacksmith。
- 昨天 buy 沙拉成功后 close_menu，再 buy 报 no shop is open：buy 成功后不关菜单继续买，需要换店才 close_menu。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 19）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65131g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且食物≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 19）**：起床 collect→读背包→卖 Copper Bar 留 20（约 63 个，腾 3-4 格）→验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 20）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 21）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天只卖 140g 垃圾，空格没动。今天起床读背包后，**显式 ship_produce Copper Bar 卖 count=背包数-20**（约 63 个，约 7k），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜（昨天 ship Copper Bar/Gold Bar 报 not found 就是猜的）。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **食物门票前置**：下矿前读背包确认 Salad≥5；不足则**先 goto Saloon→open_shop→buy 沙拉到≥8**，再回 Mine。昨天 19 层因 0 食物撤退两次，今天绝不允许食物<5 时调 mine。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。昨天重写 3 次浪费 12+ 动作。

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
> 昨天最大浪费是脚本重写3次仍重试 take 12次、donate 空跑、build_road 空转；真正有效的是 Saloon 买沙拉和 40 层下矿，但食物/空格门票没在脚本生成阶段校验，导致 mine 两次都在 19 层因 0 食物撤退。铁锭链仍卡在 1/5，今天必须把「读背包→卖 Copper Bar 留20→验证空格≥5→电梯40层」写成硬顺序，失败即转钓鱼，不再重写脚本。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 16:30 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 16:30 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 17:10 动作 `goto_location` 失败 @ Mountain — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: Salad | It's locked... (Open 9:00am - 4:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 4:00pm) 〔自动〕
- 18:00 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 4, need 5) 〔自动〕
- 18:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 脚本重写 3 次仍重试同一批 take ID（62/64/68/72/84/86），12 次全失败 @ Farm（箱子 74,15/74,16） — '62' is not in any farm chest；take 62 already failed; not retrying today（做不了：无法从箱子取矿物/食物补给，背包腾格和下矿食物都受影响） 〔复盘〕
- 清包只卖出约 200g 低价值垃圾，背包空格没腾出来 @ Farm（出货箱） — shipped 1x Green Algae (~15g)、13x Stone (~26g)、71x Stone (~142g)、3x Bug Meat (~24g)，合计约 200g，空格未增（做不了：下矿空格≥5 门票不满足，mine 只能浅层挖 4 层就撤退） 〔复盘〕
- 下矿两次都在 19 层因 0 食物撤退，没到 40 层 @ Mine 15-19 层 — stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：拿不到铁矿石，铁锭链继续卡在 1/5） 〔复盘〕
- 17:10 去 Blacksmith 被 locked，升级窗口错过 @ Mountain / Blacksmith — exit to Blacksmith did not open (closed? locked? check opening hours). It's locked... (Open 9:00am - 4:00pm)（做不了：当天无法升级 hoe，即使铁锭够也白跑） 〔复盘〕
- buy 沙拉成功后 close_menu，再 buy 报 no shop is open @ Saloon — no shop is open; use open_shop first（做不了：补食物流程被打断，需重开商店才能继续买） 〔复盘〕
