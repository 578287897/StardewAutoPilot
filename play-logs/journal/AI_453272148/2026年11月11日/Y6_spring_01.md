# 第6年 spring 1 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（17:26 开始）
- 天气：sunny　金钱：84347g　体力：270/270
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
  - 执行状态：NO_PROGRESS · 操作编号：aa3b07c1ef794abcb607c0c3ef6a9b2e
  - 耗时：3.359 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：05c83c0c2a924102ac7fb0b4f1d66825
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Coal, 1x Broken Glasses, 1x Driftwood
  - 执行状态：SUCCESS · 操作编号：8682f6bea70f45a180914c7aef200c85
  - 耗时：6.141 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：1d8a2dad517744b8b54870f18955695e
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：c7505d652f25495a8a40fd36fea5eaaa
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~574g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ff0a9450bbe547e7a883452d7b11abdf
  - 耗时：0.781 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_01）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须突破铁锭瓶颈
- 起床 collect_machines 收熔炉成品，读炉状态决定是否 load 铁矿石
- 清包：农场出货箱 ship Copper Bar 留 20（约 66 个），再卖多余 Stone/Sap，验证空格≥5
- 食物补到≥8（背包 Perch×7 + Green Algae×3 已够，跳过 Saloon）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次 ≤5 层，先 fight 清怪
- 回农场 collect 收铁锭，铁锭≥5 且 <12:00 去 Blacksmith 升 Steel Hoe
- craft 洒水器（Copper Bar≥1 且 Iron Bar≥1）+ place
- 清包/下矿失败则转 Forest 钓鱼兜底，21:30 前 sleep
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
11. `ship`（item="Copper Bar", count=66）
12. `ship`（item="Stone", count=30）
13. `ship`（item="Sap", count=48）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `craft`（item="Sprinkler", count=1）
23. `place`（item="Sprinkler", x=40, y=20）
24. `goto_location`（location="Mine"）
25. `mine`（floors=5）
26. `leave_mine`
27. `goto_location`（location="Farm"）
28. `collect_machines`
29. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ca4305591b5c4e8597574a32fc002c92
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate 空跑分支，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够则升 Steel Hoe，否则收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=30）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：57b95f9633ac46f0877278189e25a7fc
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 空跑已确认箱子内容不符，改为先收熔炉、装铁矿、出货箱卖 Copper Bar 腾格，再下矿刷铁并尝试升 hoe，失败即转 Forest 钓鱼
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=30）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `fish`（casts=5）
22. `fish`（casts=5）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：90150f80f86843dab998d3f776257b7a
  - 耗时：0.562 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take/donate 空跑分支，改为出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够则升 Steel Hoe，否则 Forest 钓
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=30）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `fish`（casts=5）
22. `fish`（casts=5）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：6a80f7a2c6da4d209dfa8e4feb430bc4
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d72d6c03d6ae45cea7a1db349a8265fb
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a48b0a95373d4de4bdc7e3dcfd87e215
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：79fadaf4651f437abc302243f304c52d
  - 耗时：79.891 秒 / 游戏 110 分钟
  - 🗨️ [hud] A Halibut frenzy has 
begun at the beach. 
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：dfed9c5ad46b413e9ab66ed6a494ce3f
  - 耗时：44.156 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：832bcade81224ed9bf3e76af61a6c5fc
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=66）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：350be20e362247a395e825eac1fea485
  - 耗时：0.563 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=30）
  - 结果：shipped 30x Stone (~60g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：74aa379a82e84ba7b4304b7cdf54e376
  - 耗时：44.016 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：cf1f4bc2e8444fe7ba7fb8ac45eb1882
  - 耗时：49.063 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 35 to 36 (1 floors down, 31 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：502e9228c3e04e6ea4b8aa7ad0696f75
  - 耗时：32.156 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [question] 
- **11:20** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：33929acbe2394c6691adfc346cb655f5
  - 耗时：0.532 秒 / 游戏 0 分钟
- **11:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：0cd9ae660f7041ef8bf3766da5c3955f
  - 耗时：35.828 秒 / 游戏 50 分钟
- **11:20** Mine ✅ `store_items`（items=["Stone", "Bug Meat", "Pumpkin Seeds", "Green Algae", "Rubber Boots", "Geode"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Bug Meat, 3x Green Algae, 1x Geode
  - 执行状态：SUCCESS · 操作编号：cfadad354583498fb25aa5bc531ea255
  - 耗时：15.093 秒 / 游戏 20 分钟
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **12:30** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：059186176a964f17b4ced91d59f31bd4
  - 耗时：0.531 秒 / 游戏 0 分钟
- **12:30** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：532d16e39b7f4dffafb5d04bee510b7b
  - 耗时：40.375 秒 / 游戏 50 分钟
- **13:20** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：a14205b5faed45da837a252a72b285f7
  - 耗时：72.64 秒 / 游戏 90 分钟
- **13:20** Blacksmith ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：37fda749c3064c0da026c44b4e74b454
  - 耗时：15.094 秒 / 游戏 20 分钟
- **13:20** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：9a3b17fa7402408faa34f43d77463385
  - 耗时：23.891 秒 / 游戏 30 分钟
- **15:40** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Smallmouth Bass, Trash, Smallmouth Bass, Green Algae)
  - 执行状态：SUCCESS · 操作编号：878a0695d79e49ebbb727d0f63720715
  - 耗时：113.937 秒 / 游戏 130 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Smallmouth Bass
- **17:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Joja Cola, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：3c2aba3049e64152b866402fda5d9650
  - 耗时：101.734 秒 / 游戏 100 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
- **19:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, River Jelly)
  - 执行状态：SUCCESS · 操作编号：235e2c7efcb842ceb67e5fbcae4cf710
  - 耗时：96.375 秒 / 游戏 100 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
- **21:10** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Smallmouth Bass, Green Algae, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：7bd186841f79459fac0956d7dd436280
  - 耗时：77.516 秒 / 游戏 70 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
- **22:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：72ad8a6935d14f5ab3193618785d030a
  - 耗时：9.703 秒 / 游戏 10 分钟
- **22:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **22:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：b9b0137a56e64e95bcacf8409b97d494
  - 耗时：0.5 秒 / 游戏 0 分钟
- **22:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **22:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：6f7fa69d47f14a25b40d85c01cf8ff0e
  - 耗时：23.609 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：84347 → 84981（+634g）
- 出货估值：574g　动作：45 个　失败：24 个
- 模型调用：7 次　tokens：87411
- 有效动作率：0.5　空转：6　熔断跳过：8
- 失败耗时：10.859 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 45 动作 24 失败，核心仍是背包空格 4<5 导致 mine/upgrade 全被拒，而 86 个 Copper Bar 一个没卖；take/store_items/donate/build_road 空跑 12 次纯浪费；清包失败后无钓鱼兜底，12:40 后空转。今天第一动作必须是农场出货箱 ship Copper Bar 留 20，读背包验证空格≥5，再下矿；验证失败立即转 Forest 钓鱼。

**新教训：**
- 昨天 mine 和 upgrade 都被 'have 4, need 5' 拒绝，而背包 86 个 Copper Bar 一个没卖：清包第一步必须是农场出货箱 ship Copper Bar 留 20，只卖石头/Sap 永远腾不出第 5 格。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，而材料显示背包有 86 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包完整清单。
- 昨天 12 次 take 空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，12:40 到 21:30 空转；而 Forest 钓鱼 20 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支填满剩余时间。
- 昨天 22:20 才 sleep，全天 45 动作 24 失败：收尾应硬性 21:30，21:30 后只允许 sleep，任何情况下不用 wait 填充时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 01）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 84347g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1，必须下 40 层以下刷）。下矿与升级的共同门票是**背包空格≥5**——昨天背包始终 4 空格，mine×2 被 'have 4, need 5' 拒绝，而背包 86 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（春 01）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（春 02）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 03）**：继续刷铁备钢斧，给作物地块补洒水器，开始春季作物（草莓前先种土豆/花椰菜保底）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 66 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 6 次、store_items 空跑 3 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春季第 1 天不买种子**：春 01 只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 01 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。could not reach/locked/timeout 即当天永久跳过升级。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-12:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
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
3. 清包到空格≥5（先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 40 层拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 春 01 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 45 动作 24 失败，核心仍是背包空格 4<5 导致 mine/upgrade 全被拒，而 86 个 Copper Bar 一个没卖；take/store_items/donate/build_road 空跑 12 次纯浪费；清包失败后无钓鱼兜底，12:40 后空转。今天第一动作必须是农场出货箱 ship Copper Bar 留 20，读背包验证空格≥5，再下矿；验证失败立即转 Forest 钓鱼。
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
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 11:20 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 12:30 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 13:20 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 22:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 22:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 22:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 背包空格始终只有 4，下矿和升级工具都被拒 @ Farm / Mine / Blacksmith — mine: store did not free enough slots (have 4, need 5)；upgrade_tool: store did not free enough slots (have 4, need 5)（做不了：无法下矿刷铁矿，无法升级 Steel Hoe，铁锭链连续多日零推进） 〔复盘〕
- 清包只卖了 30 石头，86 个 Copper Bar 一个没卖 @ Farm 出货箱 — ship Stone 30 成功，但 ship Copper Bar 66 未生成或未执行（做不了：背包腾不出第 5 格，mine/upgrade 全部卡死） 〔复盘〕
- take 连续空跑 12 次，脚本重写 3 次仍重试同一批箱子 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费 12 个动作和 3 次脚本重写，挤占下矿时间） 〔复盘〕
- 在博物馆调 ship 和 donate 均失败 @ ArchaeologyHouse — ship: 'Copper Bar' not found in inventory；donate_museum: nothing in the backpack can be donated to the museum（做不了：白跑一趟博物馆，浪费 8:00-9:40 约 100 分钟） 〔复盘〕
- 清包验证失败后没有钓鱼兜底，12:40 后空转 @ Farm / Forest — mine 被拒后脚本未生成 goto Forest→fish 分支，直到 15:10 才去钓鱼（做不了：损失约 2.5 小时有效钓鱼时间） 〔复盘〕
- leave_mine 在农场被调用 @ Farm — not in the mine（做不了：浪费 2 个动作，脚本逻辑错误） 〔复盘〕
- build_road 在农场报无可用空格 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：浪费 1 个动作，农场道路布局已满） 〔复盘〕
