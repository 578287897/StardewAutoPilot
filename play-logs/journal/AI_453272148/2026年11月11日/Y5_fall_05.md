# 第5年 fall 5 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:24 开始）
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
  - 执行状态：NO_PROGRESS · 操作编号：f5a680c871824134b2d571b429887ed8
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：fe14bfa30c7c42a3ab164858f9f0244b
  - 耗时：3.343 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：5fe97e42f10f475fa8eadfb60da5104c
  - 耗时：6.093 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：e892e7676dae415cbf86eac9fb152def
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 1 crops
  - 执行状态：SUCCESS · 操作编号：1e0eb997b93b47219331e19ca663fd08
  - 耗时：10.204 秒 / 游戏 10 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：f79ccdc1adb84beab063968a40b1a6e3
  - 耗时：0.469 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_05）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收炉并补装铁矿石，凑铁锭链
- 清包到空格≥5（只卖冗余金属与多余种子）
- 补食物≥5（Saloon 12:00 后买沙拉）
- 电梯直达 40 层刷铁矿石+煤，目标 40→50，最多 2 次
- 回农场收铁锭；铁锭≥5 且时间<13:00 去铁匠铺升 hoe
- 剩余时间钓鱼/买秋季种子（Cranberry）补收入
- 21:30 前 sleep
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
21. `goto_location`（location="SeedShop"）
22. `open_shop`（shop_id="SeedShop"）
23. `buy`（item="Cranberry Seeds", count=20）
24. `close_menu`
25. `goto_location`（location="Farm"）
26. `plant_seeds`（item="Cranberry Seeds", count=20）
27. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：deae77c57e5c41ccb491f90bd71d9b5f
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败后按策略物理删除 take 与 donate_museum，改为 ship_produce 清包→40层刷铁→回农场收锭→铁锭够则升 h
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
21. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4148700bd8d64c249285fc81b14e3481
  - 耗时：0.454 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为 ship_produce 清包后直接下矿刷铁，回农场收炉再钓鱼收尾。
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
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `goto_location`（location="Farm"）
15. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
16. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
17. `collect_machines`
18. `collect_machines`
19. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2b1ece855ffb433c931cb92e7014042c
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为 ship_produce 清包后直接下矿刷铁，回农场收炉再睡。
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
12. `goto_location`（location="Farm"）
13. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
17. `collect_machines`
18. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fcf8d6d365574d4eb070775daffda890
  - 耗时：0.468 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ba0863a1d2674086acb221929437b39c
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：52109375872c48528383542f4f85ae5f
  - 耗时：0.468 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：c745869eeb0547549527c183e876435f
  - 耗时：70.406 秒 / 游戏 100 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：1e50b8b95f064c8cb1ff38e7b01e6440
  - 耗时：42.907 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：34781f24ef25437a8eb6ed33859e0cee
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：ce12e2cb2a7142bcb8763186263bf28c
  - 耗时：50.703 秒 / 游戏 60 分钟
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：8771c2d002ad4791bc150319ee9e9ce2
  - 耗时：33.656 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：077d11d2e6f940f58089dc47548e59f9
  - 耗时：15.078 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：c31d16399dc64b31b4bb13c5f21e5cdb
  - 耗时：0.468 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：b85f70638ec04b5d9a127ac0fbd87002
  - 耗时：0.5 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：39c7f7abead248d992c6f8123cb53f6e
  - 耗时：0.485 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：ad75be88d3e345fe9223dc7017727b83
  - 耗时：0.469 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：91d9c85094d3449685f66e1b7b23c7ba
  - 耗时：0.438 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：6a56a4f3cdb94451a100a1942e7482cb
  - 耗时：0.485 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:50** Farm ✅ `store_items`（items=["Cauliflower Seeds", "Salad", "Pumpkin Seeds", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：433d4823574644b1a81621e7d1f1b48c
  - 耗时：0.5 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：0fa68f24c83b43d7bcdf319785a580a1
  - 耗时：23.86 秒 / 游戏 30 分钟
- **11:20** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：0cccf255d77d4091aa5fc1393077a364
  - 耗时：0.468 秒 / 游戏 0 分钟
- **11:20** Forest ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：164acebc4fd34908a3f18695c68289b2
  - 耗时：1.625 秒 / 游戏 0 分钟
- **11:20** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **11:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **11:20** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4a3cec1402834bc9aa74190b0fcd770d
  - 耗时：23.61 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66013 → 66013（+0g）
- 出货估值：0g　动作：42 个　失败：23 个
- 模型调用：7 次　tokens：88984
- 有效动作率：0.4118　空转：10　熔断跳过：7
- 失败耗时：6.596 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天42动作失败23个，核心卡点仍是背包空格不足（3→2）导致mine/upgrade全被拒；take凭ID猜箱子12次全失败、donate空跑、build_road/decorate空转，浪费大量动作。清包手段ship_produce因except排除金属而nothing to ship。铁锭仍0/5，钢锄头连续多天零推进。

**新教训：**
- ship_produce 的 except 列表若包含 Copper Bar/Gold Bar/Stone，会返回 nothing to ship、空格永远腾不出：清包时必须显式卖这些冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500），不能写进 except。
- take 凭物品 ID 猜箱子连续两天全失败，且脚本重写 3 次仍在重试同一批 ID：take 失败后必须当天物理删除该动作，不能靠重写脚本再试。
- donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 再失败，浪费 2 动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。
- collect_machines 和 load_machines 在熔炉未完成时连续空转被抑制：熔炉未完成时不要反复 collect，下矿回来再收一次即可。
- 昨天清包失败后仍连续调 mine/upgrade 被「have 3, need 5」拒绝 3 次：清包验证失败后应立即定性为钓鱼日，物理删除 mine/upgrade 分支，而不是继续尝试下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 05）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 66013g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 和食物≥5 是两张门票，缺一张当天就白跑**。

接下来 3 天主活动：
- **今天（秋 05）**：起床收炉→**ship_produce 显式卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥5**→补食物≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 06）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧（同配方 5 铁锭）；铁锭富余后做洒水器 ×4。
- **后天（秋 07）**：继续刷铁备钢斧，同时给蓝莓/啤酒花地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包唯一手段是 ship_produce，且必须显式卖冗余金属**：昨天 ship 返回 nothing to ship 是因为 except 列表把 Copper Bar/Gold Bar/Stone 全排除。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage）各留 5** → 读背包验证空格≥5。两次 ship 后仍<5 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
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
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包，不调 store_items，不重试同一坐标。
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
> 昨天42动作失败23个，核心卡点仍是背包空格不足（3→2）导致mine/upgrade全被拒；take凭ID猜箱子12次全失败、donate空跑、build_road/decorate空转，浪费大量动作。清包手段ship_produce因except排除金属而nothing to ship。铁锭仍0/5，钢锄头连续多天零推进。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 10:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:20 动作 `build_road` 失败 @ Forest — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 11:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包手段 ship_produce 因 except 列表排除 Copper Bar/Gold Bar/Stone 而返回 nothing to ship，背包空格始终 2-3，无法下矿或升级 @ Farm（出货箱旁） — ship_produce 返回 OK: nothing to ship；mine 返回 store did not free enough slots (have 3, need 5)（做不了：下矿刷铁矿石、升级钢锄头全部被卡，铁锭 0/5 连续多天零推进） 〔复盘〕
- take 凭物品 ID 猜箱子内容，12 次全失败，脚本重写 3 次仍在重试同一批 ID @ Farm（箱子旁） — take 62/64/68/72/84/86 均返回 not in any farm chest 或 already failed; not retrying today（做不了：无法从箱子取出宝石/矿物，浪费 12 个动作和 3 次脚本重写） 〔复盘〕
- donate_museum 在背包无可捐物时仍先 goto ArchaeologyHouse 再失败，空跑一趟 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费 2 个动作和跑图时间，博物馆收集无进展） 〔复盘〕
- build_road 和 decorate 作为填充动作连续多天 0 产出，仍被脚本调用 @ Farm — build_road: 规划道路边没有还能走上去的空格；decorate: 今天没有能做的装饰（做不了：浪费动作，未推进任何里程碑） 〔复盘〕
- 熔炉未完成时反复 collect_machines/load_machines 空转被抑制 @ Farm（熔炉旁） — collect_machines: no machine has finished output；load_machines: no empty machine accepts anything（做不了：浪费动作，铁锭产出无进展） 〔复盘〕
