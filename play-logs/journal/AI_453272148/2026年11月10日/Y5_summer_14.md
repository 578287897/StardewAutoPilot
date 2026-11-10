# 第5年 summer 14 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（21:24 开始）
- 天气：sunny　金钱：61393g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Spice Berry Jelly from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：e4a0b42d54e345d2a4e4ad437ad6d0a4
  - 耗时：16.937 秒 / 游戏 20 分钟
  - 🗨️ [hud] Spice Berry Jelly
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Spice Berry -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：53fea4e3157a40488358de659f6fa214
  - 耗时：0.969 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_summer_14）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升钢锄头（Steel Hoe）
- 起床收熔炉成品，炉空且背包有铁矿石就投料
- 清包：用 ship_produce 卖掉冗余锭、石头和多余种子，把空格腾到 ≥10
- 补食物到 ≥5（背包已有 5 个沙拉，够用）
- 电梯直达 40 层，刷铁矿石和煤（40→50 层，最多 2 次下矿）
- 下矿成功后回农场收铁锭；铁锭 ≥5 且时间在 13:00 前就去铁匠铺升 hoe
- 剩余时间在 Forest 或 Beach 钓鱼，21:30 前睡觉
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
12. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Potato Seeds", "Cauliflower Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
13. `ship`（item="Copper Bar", count=60）
14. `ship`（item="Gold Bar", count=10）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Potato Seeds", "Cauliflower Seeds", "Radish Seeds", "Red Cabbage Seeds"]）
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=4）
25. `sleep`
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：c3099f4b7e724003a320b80dd1ff4b1b
  - 耗时：18.406 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 2
  - 执行状态：SUCCESS · 操作编号：7c5a6aeece8e4a3c9b8fa078731db313
  - 耗时：8.5 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Inventory Full
- **06:50** Farm ✅ `water_crops`
  - 结果：watered 3 crops
  - 执行状态：SUCCESS · 操作编号：0c047234c93a47ab9d441c0d30122fe7
  - 耗时：10.875 秒 / 游戏 20 分钟
- **07:10** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~312g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：eee99fc355d94fa1adfaf7c6f46b9502
  - 耗时：2.547 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e7e41072a01045e7be15b8de2f78000a
  - 耗时：0.438 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败因箱子无该物品，按策略物理删除 take/donate 分支，改为 ship 清包→下矿刷铁→回农场炼铁→13:00 前升 hoe→Fo
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=60）
10. `ship`（item="Stone", count=200）
11. `ship`（item="Potato Seeds", count=27）
12. `ship`（item="Cauliflower Seeds", count=3）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `goto_location`（location="Farm"）
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds"]）
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds"]）
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `collect_machines`
26. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：bde59bca30b34d04b124c22cb6846344
  - 耗时：0.454 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改用 ship 腾格后直奔 40 层刷铁，铁锭够且 13:00 前升 hoe，剩余时间钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=60）
10. `ship`（item="Stone", count=200）
11. `ship`（item="Potato Seeds", count=27）
12. `ship`（item="Cauliflower Seeds", count=3）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `goto_location`（location="Farm"）
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2a1630ec63dc46eebed959e4f10fa724
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改用 ship 卖石头和多余种子腾格，再下矿刷铁、回农场炼锭并升级锄头。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Stone", count=150）
10. `ship`（item="Potato Seeds", count=27）
11. `ship`（item="Cauliflower Seeds", count=3）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds"]）
23. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：a677008497a5444fa780a399aee704ba
  - 耗时：0.438 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：db06b93066ea4bea95aa99fa55d65b28
  - 耗时：0.437 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ba579a9ccb434930a4a19323fc6e26b7
  - 耗时：0.484 秒 / 游戏 0 分钟
- **07:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：63cde77e8ab945ffb834866760219569
  - 耗时：33.25 秒 / 游戏 50 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c67a5e0fad484727831fa64829dc39dc
  - 耗时：44.063 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：48f400566b5c4850ba5a4a5c5ce37a4f
  - 耗时：0.421 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=150）
  - 结果：shipped 150x Stone (~300g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：90caa65f388d4db3a300d74c480ea0ec
  - 耗时：43.937 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `ship`（item="Potato Seeds", count=27）
  - 结果：shipped 27x Potato Seeds (~675g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：5a8757a189c5477083d756e8716e438c
  - 耗时：0.563 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Cauliflower Seeds", count=3）
  - 结果：shipped 3x Cauliflower Seeds (~120g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：374f2b23d3d3413e82536031783e3893
  - 耗时：0.453 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：115ae8ef5991421093a7b700150ea97a
  - 耗时：49.109 秒 / 游戏 70 分钟
  - 🗨️ [hud] Blueberry
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：59f8cfd586b941d6b7fea0148c7c4fe9
  - 耗时：33.625 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：5907c97aab02417a84d9b4361514694b
  - 耗时：15.218 秒 / 游戏 20 分钟
- **10:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：13ab5e6f3a734c8190b45126cc62e13d
  - 耗时：0.422 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：86ac519ab82e42099d49c011d6dc89d2
  - 耗时：40.296 秒 / 游戏 50 分钟
- **12:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：0a0e8584e8064255884cee34df6d3d6d
  - 耗时：38.953 秒 / 游戏 40 分钟
- **12:40** Blacksmith ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：83eed49953994bfd89bb7aafa9e05593
  - 耗时：1.093 秒 / 游戏 0 分钟
- **12:40** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：d5d3f48184e94e0cbdc325e92928904c
  - 耗时：23.781 秒 / 游戏 30 分钟
- **13:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Trash, Green Algae, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：dbb1412fe7214fd38dad1b9e3ca5870a
  - 耗时：81.0 秒 / 游戏 90 分钟
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Green Algae
- **15:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：435412242abd435caf04b3cca301a712
  - 耗时：9.609 秒 / 游戏 10 分钟
- **15:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：9f09a372ba1547b08c9c2da1ae4465d2
  - 耗时：0.422 秒 / 游戏 0 分钟
- **15:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：68ae87116ece4fa1bb8afff2925fbc5d
  - 耗时：0.422 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Iron Bar", "Salad", "Strange Bun", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Melon Seeds", "Hops Starter", "Radish Seeds", "Red Cabbage Seeds"]）
  - 结果：shipped 1 stacks worth ~110g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：4c01a0e7c2e04dfeaf06a9a53f9843db
  - 耗时：20.469 秒 / 游戏 30 分钟
- **16:00** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：39ff8556a21a47058b29ff6daa1203cd
  - 耗时：0.437 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:00 pm
  - 执行状态：SUCCESS · 操作编号：3f854cbc49004ef1974bd511fb2b9f7f
  - 耗时：82.953 秒 / 游戏 120 分钟
- **18:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：29e2aebe8e0a47d4894d74e2de987030
  - 耗时：6.703 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：61393 → 62910（+1517g）
- 出货估值：422g　动作：46 个　失败：22 个
- 模型调用：7 次　tokens：89165
- 有效动作率：0.5789　空转：6　熔断跳过：6
- 失败耗时：4.453 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 46 动作 22 失败，核心浪费是 12 次 take 猜箱子 ID 全失败、store_items 返回 OK 却不腾格、清包只卖低价值物导致空格始终 2 格，mine/upgrade 全被 need 5 拒绝。有效动作是 Forest 钓鱼 4 次（2 条 Pike）和 ship_produce 卖石头/种子。铁锭链连续多天零推进，必须把清包改成卖高价值冗余并读背包验证。

**新教训：**
- 昨天 12 次 take 全失败且脚本重写 3 次仍在重试同一批 ID：take 失败后必须当天物理删除该动作，不能靠重写脚本再试，否则每次重写都浪费 4-6 个动作。
- 昨天 ship_produce 返回 nothing to ship，因为背包里全是保留物（种子/食物/矿石）：清包必须卖高价值冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500），不能只卖低价值物。
- 昨天 store_items 返回 OK 但空格从 3 降到 2，确认箱子路径/容量彻底失效：清包唯一手段是 ship_produce，且每次 ship 后必须读背包验证空格数，未增即当天放弃下矿转钓鱼。
- 昨天 mine 在 40 层前就被「store did not free enough slots (have 3, need 5)」拒绝两次，而清包动作返回 OK 却没腾格：下矿前必须显式读背包确认空格≥5，不能信任 store_items 的 OK 返回。
- 昨天 donate_museum 在背包无可捐物时仍先 goto ArchaeologyHouse 再失败，浪费 2 个动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 夏 15）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 61393g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈，钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**空格≥10 和食物≥5 是两张门票，缺一张当天就白跑**。

接下来 3 天主活动：
- **今天（夏 15）**：起床收炉→**用 ship_produce 卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥10**→补食物≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（夏 16）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧（同配方 5 铁锭）；铁锭富余后做洒水器 ×4。
- **后天（夏 17）**：继续刷铁备钢斧，同时给蓝莓/啤酒花地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包优先卖高价值冗余，不只卖低价值物**：昨天 ship_produce 返回 nothing to ship，因为背包里全是保留物。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage 各留 5）** → 读背包验证空格≥10。两次 ship 后仍<10 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。清包唯一手段是 ship_produce。
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
3. 清包到空格≥10：goto Farm → ship_produce 卖高价值冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5）→ 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥10 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥10，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包，不调 store_items，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<10 则物理删除 mine 分支。
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
3. 清包到空格≥10（**只用 ship_produce 卖高价值冗余**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥10、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 46 动作 22 失败，核心浪费是 12 次 take 猜箱子 ID 全失败、store_items 返回 OK 却不腾格、清包只卖低价值物导致空格始终 2 格，mine/upgrade 全被 need 5 拒绝。有效动作是 Forest 钓鱼 4 次（2 条 Pike）和 ship_produce 卖石头/种子。铁锭链连续多天零推进，必须把清包改成卖高价值冗余并读背包验证。
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
- 07:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 12:40 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 2, need 5) 〔自动〕
- 15:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 15:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 连续 12 次 take 宝石（Aquamarine/Ruby/Topaz/Diamond 等）全失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：无法从箱子取宝石，捐博物馆和献祭都做不成） 〔复盘〕
- store_items 返回 OK 但背包空格始终只有 2 格，没有真正腾出空间 @ Farm 箱子 — store_items -> OK: nothing to store，随后 mine/upgrade_tool 返回 store did not free enough slots (have 2, need 5)（做不了：下矿和升级工具都被空格不足拒绝，铁锭链零推进） 〔复盘〕
- 清包只卖低价值物，ship_produce 返回 nothing to ship，高价值冗余（Copper Bar 82 个、Gold Bar 12 个、Stone 4054）一直占格 @ Farm 出货箱 — ship_produce -> OK: shipped 1 stacks worth ~110g，背包仍只有 2 格（做不了：无法腾到 10 格，下矿和升级都做不了） 〔复盘〕
- 下矿连续多天被空格不足拦截，铁矿石一颗没拿到，Iron Bar 0/5 卡住钢锄头里程碑 @ Mine 入口 / Farm — mine -> FAIL: store did not free enough slots (have 2, need 5)（做不了：钢锄头、钢斧、洒水器全部无法推进） 〔复盘〕
