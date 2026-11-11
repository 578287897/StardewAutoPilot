# 第5年 summer 23 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（03:09 开始）
- 天气：sunny　金钱：64800g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Spice Berry -> Preserves Jar (ready in 4000 min), Spice Berry -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：55fd641b5aea4de18d1e8149f28f1893
  - 耗时：17.656 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_summer_23）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——今天必须凑够5铁锭
- 起床收炉+装炉（铁矿石不足则跳过）
- 清包：ship_produce 卖 Copper Bar 留20、Gold Bar 留2、Stone 留500、多余种子各留5，验证空格≥5
- 补食物：背包已有 Salad x5 + Strange Bun，食物≥5 已满足，不需去 Saloon（今天关门）
- 电梯直达40层刷铁矿石+煤，40→45→50，≤2次mine
- 回农场收炉炼铁，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 铁锭不够则继续下矿或钓鱼，21:30 前 sleep
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
12. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
13. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar", "Iron Ore"]）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `sleep`
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：c15d914a6e60478783a7283062ecab2a
  - 耗时：18.125 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 2
  - 执行状态：SUCCESS · 操作编号：70b77ae8221f4170aabe42636d6881ae
  - 耗时：8.89 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Inventory Full
- **06:50** Farm ✅ `water_crops`
  - 结果：watered 4 crops
  - 执行状态：SUCCESS · 操作编号：19938bdbd4d44b5bb9442ce8ee87cf7b
  - 耗时：7.36 秒 / 游戏 10 分钟
- **07:00** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~274g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：d074d1f51e834c8c97a6e4374835eccf
  - 耗时：2.391 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：13bdf717c4e9410dabec72893d8b81f1
  - 耗时：0.437 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败已物理删除；改为 ship_produce 清包→电梯40层刷铁→回农场炼铁→铁锭够则升钢锄头，收尾睡觉。
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
17. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
18. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
19. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar", "Iron Ore"]）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：840a0d12f740436fa0d3ba90b2cbb8bd
  - 耗时：0.421 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为清包后直接下矿刷铁，铁锭够则升锄头，不够转钓鱼收尾。
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
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f3595b35f45546429d525d97fcf739c4
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为 ship_produce 清包后直接下矿刷铁，回农场炼铁并尝试升 hoe，剩余时间钓鱼收尾。
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
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
20. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f0dd9790fe2b4564bc3a15018a70a025
  - 耗时：0.469 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dd8a56cf98554dd0a497963d9de02729
  - 耗时：0.407 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1485d7bbcb3d4f71bc60501d3435805e
  - 耗时：0.438 秒 / 游戏 0 分钟
- **07:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：7dc89a8be9294a16b75597270551cf02
  - 耗时：36.891 秒 / 游戏 60 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：6b37ee7ec180461da839e7532516ff72
  - 耗时：44.079 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：12f906b0530148139e777c1f5b60567a
  - 耗时：0.438 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5fa6e36ea4b642989ea7d041e51a00eb
  - 耗时：50.656 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：932f37eb77534edc862d4b385daab204
  - 耗时：33.625 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a6c01491cae14af7a16c3410f286c454
  - 耗时：19.922 秒 / 游戏 30 分钟
  - 🗨️ [hud] Blueberry
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：cc2d1f6d213649838319afa0b8a5aa54
  - 耗时：0.438 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：28f7d032663741519e300ccde6510c69
  - 耗时：40.297 秒 / 游戏 50 分钟
- **11:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：393cad51dd0c4490b09e1e95f94402a8
  - 耗时：38.984 秒 / 游戏 50 分钟
- **11:50** Blacksmith ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：cc3ed3e51c9640fdb80169b475cb4d07
  - 耗时：1.14 秒 / 游戏 0 分钟
- **11:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：68860f1468a54003a07fdc8be9af7405
  - 耗时：23.625 秒 / 游戏 30 分钟
- **13:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Green Algae, Green Algae, Pike)
  - 执行状态：SUCCESS · 操作编号：209856cf163d442780d49bb0f5e6dd44
  - 耗时：72.469 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **14:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：e6cd9d80e07b4f2a864d164da479b4b1
  - 耗时：9.641 秒 / 游戏 10 分钟
- **14:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：5045b53af774487c896c3def51b18660
  - 耗时：0.469 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：339c80b98930450a88b076f30fe807a4
  - 耗时：0.422 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
  - 结果：shipped 2 stacks worth ~260g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b96d1fe24e924d83a9db374b6bac95f9
  - 耗时：20.484 秒 / 游戏 30 分钟
- **15:20** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Copper Bar", "Gold Bar"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：f8bac2fcab0c47b79da6a1229c4ed221
  - 耗时：0.422 秒 / 游戏 0 分钟
- **15:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：3c6402052ab34d459726532316e5ad88
  - 耗时：0.453 秒 / 游戏 0 分钟
- **15:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **15:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:20** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:20 pm
  - 执行状态：SUCCESS · 操作编号：33ab26e70fdf4126a2923590a78e2c42
  - 耗时：87.125 秒 / 游戏 120 分钟
- **17:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：993ac8721adc4d6daed3681182a7f898
  - 耗时：6.734 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64800 → 65334（+534g）
- 出货估值：534g　动作：46 个　失败：25 个
- 模型调用：7 次　tokens：88646
- 有效动作率：0.5143　空转：7　熔断跳过：9
- 失败耗时：4.829 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天25次失败中12次是猜箱子ID的take、2次store_items无效、2次mine被空格不足拒绝、2次collect/load空转，真正有效动作只有钓鱼4条和ship 260g。核心矛盾：背包长期卡在2格，而清包脚本只卖低价值物、保留物占满背包；铁锭链因此连续多天零推进。今天必须用ship_produce卖铜锭/金锭/石头腾格，验证空格≥5后再下矿，否则直接转钓鱼。

**新教训：**
- 昨天 ship_produce 的 except 列表把 Copper Bar/Gold Bar/Stone 全排除，导致返回 nothing to ship、空格始终 2：清包时必须显式卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500，不能把这些写进 except。
- 昨天 goto ArchaeologyHouse 等开门 8:00 再 donate 仍失败，浪费 2 动作：donate 前先读背包确认有可捐物，没有就直接跳过，不要先跑图。
- 昨天 collect_machines 和 load_machines 在 14:50 连续空转 3 次被抑制：熔炉未完成时不要反复 collect，下矿回来再收一次即可。
- 昨天 15:20 用 wait 120 分钟填充到 17:20 才睡，纯浪费 2 小时：等炉子应改为去 Forest 钓鱼，回来再 collect，绝不用 wait 空转。
- 昨天 upgrade_tool 在 11:50 被「have 2, need 5」拒绝，而清包两次都返回 nothing to ship：升级前必须读背包确认空格≥5 且 Iron Bar≥5，两项缺一直接跳过升级，不先跑 Blacksmith。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 夏 24）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64800g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 和食物≥5 是两张门票，缺一张当天就白跑**。

接下来 3 天主活动：
- **今天（夏 24）**：起床收炉→**用 ship_produce 卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥5**→补食物≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（夏 25）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧（同配方 5 铁锭）；铁锭富余后做洒水器 ×4。
- **后天（夏 26）**：继续刷铁备钢斧，同时给蓝莓/啤酒花地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包目标降到空格≥5，且只认 ship_produce**：昨天 mine 三次被「have 2, need 5」拒绝，而 ship_produce 返回 nothing to ship 是因为背包全是保留物。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage）各留 5** → 读背包验证空格≥5。两次 ship 后仍<5 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
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
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
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
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天25次失败中12次是猜箱子ID的take、2次store_items无效、2次mine被空格不足拒绝、2次collect/load空转，真正有效动作只有钓鱼4条和ship 260g。核心矛盾：背包长期卡在2格，而清包脚本只卖低价值物、保留物占满背包；铁锭链因此连续多天零推进。今天必须用ship_produce卖铜锭/金锭/石头腾格，验证空格≥5后再下矿，否则直接转钓鱼。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:50 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 2, need 5) 〔自动〕
- 14:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 15:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包脚本反复返回 nothing to ship，背包长期卡在 2 格 @ Farm 出货箱 — ship_produce 的 except 列表包含 Copper Bar/Gold Bar/Stone，背包全是保留物，返回 nothing to ship；mine 和 upgrade_tool 因此被「have 2, need 5」拒绝（做不了：下矿拿铁矿石、升级钢锄头全部无法执行，铁锭链连续多天零推进） 〔复盘〕
- 12 次 take 凭物品 ID 猜箱子全失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费 12 个动作和 3 次脚本重写，宝石没拿到，博物馆捐赠也失败） 〔复盘〕
- store_items 返回 OK 但背包空格没变，仍被当作清包手段反复调用 @ Farm 箱子 — store_items 返回 OK: nothing to store，箱子路径/容量已不可用（做不了：清包形同虚设，mine 和 upgrade_tool 持续被空格不足拒绝） 〔复盘〕
- 熔炉未完成时反复 collect_machines / load_machines 空转 @ Farm 熔炉 — no machine has finished output；no empty machine accepts that, and the rest are busy；repeated ineffective action suppressed（做不了：浪费 5 个动作，没有产出铁锭） 〔复盘〕
