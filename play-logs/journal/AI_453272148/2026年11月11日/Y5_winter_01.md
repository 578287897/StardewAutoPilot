# 第5年 winter 1 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:21 开始）
- 天气：sunny　金钱：65088g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a1df343a5b634bbf8b11557e8c055966
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：fdd6770dcd254fc99b140cce002a4548
  - 耗时：3.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：4aec7d92314c444a9432425684f2cc03
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：1c7efe7c04ab4c3ea1a9ede907a99c47
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：14eca16512f84172b662dba71b823bdd
  - 耗时：0.485 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_01）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——今天主活动下矿40层刷铁矿石和煤
- 起床收熔炉→装铁矿石→卖Copper Bar留20腾格到空格≥5
- 下矿40→45→50层，每次≤5层，拿够铁矿石
- 回农场炼铁，铁锭≥5且13:00前升hoe
- 铁锭不够就钓鱼兜底，21:30前睡
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
11. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Salad", "Gold Bar", "Iron Bar", "Pumpkin Seeds", "Rubber Boots", "Squid Ink"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=500）
14. `ship`（item="Sap", count=40）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Salad", "Gold Bar", "Iron Bar", "Pumpkin Seeds", "Rubber Boots", "Squid Ink"]）
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Farm"）
25. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ab9fa7fca9a04857a0ad7bb965632d20
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 在农场箱子连续失败，删除所有 take/donate 分支，改为先卖 Copper Bar 腾格再下矿刷铁，铁锭够就升 hoe，收尾直接睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=40）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Salad", "Gold Bar", "Iron Bar", "Pumpkin Seeds", "Rubber Boots", "Squid Ink"]）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e10705a0612d4b47a2d57901ad7e7484
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删掉全部 take/donate 分支（箱子内容与记忆不符、卷轴未解锁），改为先卖 Copper Bar 腾格再下矿 40 层刷铁，回农场炼铁后 13
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=40）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a35bb0c3b03f4e499a4d1140bdfde7ee
  - 耗时：0.579 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 已连续失败，全天物理删除 take/donate 分支；改为先卖 Copper Bar 腾格再下矿 40 层刷铁，凑够 5 铁锭在 13:0
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=40）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：c47b74e9d5cd4d4faf90a914ad9b995d
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6cfc799e103642faad6eaf40fea6b70a
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：69c23ecd1e414cf181f55db499e8cdc7
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：7973e0d629064c58a923cff136504942
  - 耗时：86.188 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：6e02524f3b9d46e2a42e6fa138ec03af
  - 耗时：47.078 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：dd16efcd923249a3bd9e74958c65380c
  - 耗时：0.515 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：599c9c81fe434d098a62d672f784e9c1
  - 耗时：0.485 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Stone", count=500）
  - 结果：'Stone' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：841808041f54460d83400c2ab80c21a4
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Sap", count=40）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：c566a7156b9f4d469af03256269a324c
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：bb64d2ee779d4fec84bce17adb181c3b
  - 耗时：50.719 秒 / 游戏 70 分钟
- **10:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：1b46a8c7d44b46f2949383ab14c341c4
  - 耗时：33.672 秒 / 游戏 40 分钟
- **10:00** Mine ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a13e33c2a00d4197bfb8a1a944c99932
  - 耗时：15.078 秒 / 游戏 20 分钟
- **10:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：ffdd2b290cd34b5eabc7096530e9a4b3
  - 耗时：0.5 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：a50311436cd640d786171dbc6aeebce1
  - 耗时：40.359 秒 / 游戏 50 分钟
- **11:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：10cfaf8a37484a66ac9d3d1001a87067
  - 耗时：39.016 秒 / 游戏 40 分钟
- **11:50** Blacksmith ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：daed47cac03140339cc75c382f548791
  - 耗时：1.188 秒 / 游戏 10 分钟
- **11:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：d30e534f2b1e4274b87b636a829d73d2
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：b2752105cf0a4a0ea5f99cbd70e7cf70
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：aa557d096c284ac08500bb35f9bf3c31
  - 耗时：0.468 秒 / 游戏 0 分钟
- **12:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：20ce36043e684e3199e955b8ac0a6dd9
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:40** Farm ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：44d2aa8cb9fb4e4abb8e13f0a7b7514d
  - 耗时：0.547 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：86f8cf13bf834dba822b175a06fde6f9
  - 耗时：0.5 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **12:40** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:40** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c01fbb040c4340b6acea88fb91317dc7
  - 耗时：10.218 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65088 → 65088（+0g）
- 出货估值：0g　动作：47 个　失败：29 个
- 模型调用：6 次　tokens：68747
- 有效动作率：0.3421　空转：10　熔断跳过：8
- 失败耗时：8.64 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天29次失败几乎全部来自同一个根因：背包只有3格，清包手段（store_items/take）全部无效，Copper Bar 85个一个没卖，导致mine/upgrade被'have 3, need 5'连续拒绝，全天零推进。同时脚本重写3次仍在重试不存在的箱子物品ID。真正要改的是：清包用ship_produce卖Copper Bar留20并读背包验证，验证不过就转钓鱼，不再空转。

**新教训：**
- 清包失败后脚本没有钓鱼兜底，昨天从 12:40 到 21:30 全部空转：清包验证空格<5 后必须在同一脚本里生成 goto Forest→fish 分支，而不是让 mine/upgrade 分支被删后无事可做。
- 昨天 ship 在 ArchaeologyHouse 报 'Copper Bar' not found，但材料汇总显示背包有 85 个：ship 前必须先 close_menu 并读背包，且 ship 只能在农场出货箱附近执行，不要在博物馆/商店里调 ship。
- 昨天脚本重写 3 次仍在重试同一批箱子物品 ID（62/64/68/72/84/86），说明重写逻辑没有读取最新背包：重写前必须先读背包完整清单，只对清单里实际存在的物品生成动作。
- 昨天 load_machines item=Iron Ore 报 'no empty machine accepts anything'，但材料里 Iron Ore 只有 1：load 前必须读背包确认 Iron Ore≥5 且炉子为空，否则物理删除 load 分支。
- 昨天 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝 4 次，每次拒绝后脚本又调 store_items 再 mine：mine 返回空格不足后应直接判定当天钓鱼日，不再调 store_items 或重试 mine。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 2）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65088g 早已够，卡点仍是 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（冬 2）**：起床 collect→**读背包→ship_produce 卖 Copper Bar 留 20（约 65 个，约 7k，腾 3-4 格）→读背包验证空格≥5**→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。验证不过即转钓鱼，不空转。
- **明天（冬 3）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 4）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天 85 个 Copper Bar 一个没卖，空格仍 3。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **换季日不买种子**：冬 2 不买任何作物种子；冬季种子/茶苗留到明天再买。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 2 不买任何作物种子；冬季种子/茶苗留到明天。
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
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
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
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天29次失败几乎全部来自同一个根因：背包只有3格，清包手段（store_items/take）全部无效，Copper Bar 85个一个没卖，导致mine/upgrade被'have 3, need 5'连续拒绝，全天零推进。同时脚本重写3次仍在重试不存在的箱子物品ID。真正要改的是：清包用ship_produce卖Copper Bar留20并读背包验证，验证不过就转钓鱼，不再空转。
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
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Stone' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Sap' not found in inventory 〔自动〕
- 10:00 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:50 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:40 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包手段全部失效，背包始终只有 3 格，Copper Bar 85 个一个没卖 @ Farm（出货箱旁） — store_items 报 'nothing to store'，take 报 'not in any farm chest'，ship 在 ArchaeologyHouse 报 'Copper Bar' not found；全天没有一次成功的 ship_produce 卖锭（做不了：mine 连续 4 次被 'have 3, need 5' 拒绝，upgrade_tool 也被同一原因拒绝，钢锄头零推进） 〔复盘〕
- 脚本重写 3 次仍在重试同一批不存在的箱子物品 ID @ Farm 箱子 — take 62/64/68/72/84/86 全部失败（'is not in any farm chest' / 'already failed; not retrying today'），重写后仍生成相同动作（做不了：浪费 12 个动作和 3 次脚本重写，挤占了本可用于清包和下矿的时间） 〔复盘〕
- 去博物馆捐物和出货，但背包里没有可捐物品且 ship 在博物馆不可用 @ ArchaeologyHouse — donate_museum 报 'nothing in the backpack can be donated'；ship 报 'Copper Bar' not found in inventory（做不了：白跑一趟博物馆，8:00 等到 8:50 才离开，错过上午下矿窗口） 〔复盘〕
- 熔炉没有成品也没有空炉接受铁矿石，反复 collect/load 被系统抑制 @ Farm 熔炉 — collect_machines 报 'no machine has finished output'；load_machines 报 'no empty machine accepts anything'（做不了：铁锭无法产出，钢锄头材料链彻底卡死） 〔复盘〕
- 收尾阶段用 build_road / decorate 填充时间，全部失败 @ Farm — build_road 报 '规划道路边没有还能走上去的空格'；decorate 报 '今天没有能做的装饰'（做不了：21:30 前的时间被浪费，没有转去钓鱼兜底） 〔复盘〕
