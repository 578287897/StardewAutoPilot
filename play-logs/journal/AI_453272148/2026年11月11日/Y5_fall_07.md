# 第5年 fall 7 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:38 开始）
- 天气：windy　金钱：66013g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1f025c1d67984d0183c5c38f92bee80f
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：82f93d198d474b30814cd796314f58a8
  - 耗时：3.391 秒 / 游戏 0 分钟
  - 🗨️ [hud] The Bookseller is in 
town today. 
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：38742692714a4e0a86d58c62547b868b
  - 耗时：6.093 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：83f4ff4f37374d22a139058f3483f508
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 1 crops
  - 执行状态：SUCCESS · 操作编号：5e35081e794d4fbd9e2078af6a5bc2f2
  - 耗时：1.735 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：abc4268576d1434b9e5410b8dcdf97f7
  - 耗时：0.437 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_07）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），卡点是铁锭 0/5
- 起床收熔炉成品，有空炉且背包有铁矿石就装料
- 清包：ship_produce 显式卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，腾出≥5 格
- 补食物到≥5（背包已有 Salad x5 + Strange Bun + River Jelly，够用则跳过）
- 电梯直达 40 层刷铁矿石+煤，mine ≤2 次每次 ≤5 层，生命<50% 或食物=0 立即离开
- 回农场收铁锭；铁锭≥5 且时间<13:00 去铁匠铺升 hoe
- 剩余时间在 Forest 钓鱼补收入，21:30 前 sleep
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
12. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=4）
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9ca4ab2101ee497696467f7d3812eebe
  - 耗时：0.485 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败按教训物理删除全部 take 与 donate_museum，改为 ship_produce 清包后直接下矿刷铁，回农场收锭再视时间升 
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
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Farm"）
17. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
18. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
19. `collect_machines`
20. `collect_machines`
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a0ac38307e864ebf9f0ff974b5c94844
  - 耗时：0.484 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为 ship_produce 清包后直接下矿刷铁，回农场收锭并尝试升 hoe，剩余时间钓鱼收尾。
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
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Farm"）
17. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
18. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
19. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
20. `collect_machines`
21. `collect_machines`
22. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：cf844914b9774643b9d19f27e55a6e3b
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为 ship_produce 清包后直接下矿刷铁，铁锭够则升 hoe，剩余时间钓鱼收尾。
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
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Farm"）
17. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
18. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
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
  - 执行状态：ACTION_FAILED · 操作编号：a551b99589c14f2c819609425f1f8293
  - 耗时：0.61 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ed337211a8f74d868bcba289153d4f9a
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8ba83591da944e18ab3add407a90740b
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：490a127ae7164a35bb268b316602517d
  - 耗时：78.843 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：11864476959d4862a61fe78de67f7e14
  - 耗时：43.016 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：872e485ce0c34b0bb91bd1ac5e69f30f
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e9316ab8cf034a27bc550c25884dd6e7
  - 耗时：50.672 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：1dcd3495291c401da4d420554335c458
  - 耗时：33.641 秒 / 游戏 40 分钟
- **09:50** Mine ❌ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "River Jelly", "Hops Starter", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：c2386de1d1354978b480640edcf5a696
  - 耗时：13.859 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ❌ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "River Jelly", "Hops Starter", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：bf397e6c3de14a99b9ab2a5cadaa904c
  - 耗时：7.656 秒 / 游戏 10 分钟
- **10:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：3a5bf847c1d745a4aad1be97e3631c4b
  - 耗时：73.812 秒 / 游戏 90 分钟
- **12:30** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：27a0a69f26a84935b6d72883c94e8a55
  - 耗时：39.062 秒 / 游戏 50 分钟
- **12:30** Blacksmith ✅ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "River Jelly", "Hops Starter", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x River Jelly, 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：76195d12af364a38bed92ae84fee5394
  - 耗时：1.157 秒 / 游戏 0 分钟
- **12:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：3b5501066c134bbc89d44bdfda3c61a9
  - 耗时：23.64 秒 / 游戏 30 分钟
- **13:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：b918f48f7ea94eb38e642db5eaa8c280
  - 耗时：100.266 秒 / 游戏 110 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
- **15:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：e417a64d177f4482a5fb9bad73703e74
  - 耗时：9.625 秒 / 游戏 10 分钟
- **15:50** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
  - 结果：shipped 1 stacks worth ~225g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：fc3142b197a941dd8b65160da6bcc150
  - 耗时：20.515 秒 / 游戏 30 分钟
- **16:20** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：2174f642419246919a6ffffd7f9123b0
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c6e05a3ac6554b51994ad86d5432df52
  - 耗时：0.5 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:20** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：1a376ccaf4fd48b2b7ed7af622cb7566
  - 耗时：6.766 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66013 → 66238（+225g）
- 出货估值：225g　动作：41 个　失败：23 个
- 模型调用：6 次　tokens：71686
- 有效动作率：0.4118　空转：8　熔断跳过：6
- 失败耗时：27.406 秒 / 游戏 30 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
连续 7 天零推进，根因是背包长期卡在 1-3 格：ship_produce 的 except 列表把 Copper Bar/Gold Bar/Stone 全排除，导致清包形同虚设；store_items 返回 OK 却不腾格；take 凭 ID 猜箱子 12 次全失败；清包失败后仍硬调 mine/upgrade 被 need 5 拒绝。今天必须用「显式卖冗余金属」真正腾出 5 格，否则全天定性钓鱼。

**新教训：**
- ship_produce 的 except 列表若包含 Copper Bar/Gold Bar/Stone，会返回 nothing to ship、空格永远腾不出：清包时必须显式卖这些冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500），不能写进 except。
- store_items 连续多天返回 OK 但空格不增（昨天从 3 降到 2），说明箱子路径/容量已失效：清包唯一手段是 ship_produce，且每次 ship 后必须读背包验证空格数，未增即当天放弃下矿转钓鱼。
- take 凭物品 ID 猜箱子连续两天 12 次全失败，且脚本重写 3 次仍在重试同一批 ID：take 失败后必须当天物理删除该动作，不能靠重写脚本再试。
- 清包失败后仍连续调 mine/upgrade 被「have 1-3, need 5」拒绝 3 次：清包验证失败后应立即定性为钓鱼日，物理删除 mine/upgrade 分支，而不是继续尝试下矿。
- donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 等开门再失败，浪费 2 动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 08）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 66013g 充足，卡点 Iron Bar 0/5，已连续 7 天零推进，铁锭链是全局瓶颈（钢斧、洒水器、高级洒水器全排在后面）。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是唯一门票，今天必须先真正腾出格子**。

接下来 3 天主活动：
- **今天（秋 08）**：起床收炉→**用 ship_produce 显式卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥5**→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 09）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 10）**：继续刷铁备钢斧，给作物地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包唯一手段是 ship_produce，且必须显式卖冗余金属**：昨天返回 nothing to ship 是因为 except 列表把 Copper Bar/Gold Bar/Stone 全排除。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage）各留 5** → 读背包验证空格≥5。两次 ship 后仍<5 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。
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
3. 清包到空格≥5：goto Farm → ship_produce 卖高价值冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5）→ 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
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
3. 清包到空格≥5（**只用 ship_produce 卖高价值冗余**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 连续 7 天零推进，根因是背包长期卡在 1-3 格：ship_produce 的 except 列表把 Copper Bar/Gold Bar/Stone 全排除，导致清包形同虚设；store_items 返回 OK 却不腾格；take 凭 ID 猜箱子 12 次全失败；清包失败后仍硬调 mine/upgrade 被 need 5 拒绝。今天必须用「显式卖冗余金属」真正腾出 5 格，否则全天定性钓鱼。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
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
- 09:50 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 10:50 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 1, need 5) 〔自动〕
- 12:30 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 16:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包长期卡在 1-3 格，清包动作返回 OK 却腾不出格子，导致下矿和升级连续被拒 @ Farm 出货箱/箱子 — mine/upgrade_tool 返回 store did not free enough slots (have 1-3, need 5)；ship_produce 返回 nothing to ship（except 列表排除了 Copper Bar/Gold Bar/Stone）（做不了：无法下矿拿铁矿石，无法升钢锄头，里程碑连续 7 天零推进） 〔复盘〕
- 凭物品 ID 从农场箱子取矿物，12 次全部失败 @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；重写脚本后仍重试同一批 ID（做不了：无法凑齐献祭/升级所需矿物，浪费 12 个动作和 3 次脚本重写） 〔复盘〕
- store_items 返回 OK 但背包空格不增反降 @ Farm (74,15) 箱子 — stored 1x Coal / 1x River Jelly 后空格从 3 降到 2；另有两次 could not reach (74,16); stopped at (53,8)（做不了：清包路径不可信，下矿前空格始终不足） 〔复盘〕
- donate_museum 在背包无可捐物时仍先跑到博物馆等开门 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum；为等 8:00 开门浪费等待（做不了：浪费 2 个动作和早晨时间） 〔复盘〕
- 收尾阶段用 build_road/decorate 填充时间，连续失败 @ Farm — 规划道路边没有还能走上去的空格；今天没有能做的装饰（做不了：无产出，纯浪费动作） 〔复盘〕
- 熔炉成品未完成时反复 collect/load 空转 @ Farm — no machine has finished output；no empty machine accepts anything（做不了：无产出，浪费动作） 〔复盘〕
