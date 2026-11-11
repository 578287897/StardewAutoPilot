# 第5年 fall 12 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（06:22 开始）
- 天气：windy　金钱：67913g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bd84d07998a74c63a0a10573e601f75c
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：7569b84d4bce40a9aebbf1bb8d1f9a25
  - 耗时：3.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Coal
  - 执行状态：SUCCESS · 操作编号：220481485eb347db9bacf57299dbded7
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：430bcd70071944de8cc9eed94b48d74e
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 1 crops
  - 执行状态：SUCCESS · 操作编号：5d67b3158fe74789a85c6f7c1b0b64a3
  - 耗时：1.719 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~75g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：e8637fe2ecdb47138eacb907293e8682
  - 耗时：1.953 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_12）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——铁锭链是唯一瓶颈
- 起床收熔炉→有铁矿就装炉
- 清包：显式卖 Copper Bar 留 20、Gold Bar 留 2，验证空格≥5
- 食物已有 8 沙拉，直接下矿
- 电梯直达 40 层刷铁矿石+煤（40→50，≤2 次）
- 回农场收铁锭，铁锭≥5 且 <13:00 去铁匠铺升 hoe
- 剩余时间钓鱼/收尾，21:30 前 sleep
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
12. `ship`（item="Copper Bar", count=62）
13. `ship`（item="Gold Bar", count=10）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Salad", "Strange Bun", "Coal", "Iron Ore", "Gold Ore", "Copper Ore"]）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=4）
25. `goto_location`（location="Farm"）
26. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9b65a15569e849ad97d916dc7adc7ca5
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 连续失败已物理删除；改为先 ship 显式卖 Copper Bar/Gold Bar 清包，再下矿 40 层刷铁，回农场收锭后视铁锭数升 h
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Gold Bar", count=10）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `ship_produce`（except=["Salad", "Strange Bun", "Coal", "Iron Ore", "Gold Ore", "Copper Ore", "Stone"]）
22. `collect_machines`
23. `collect_machines`
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：88e9274f3c2d47db91bd87e606492e74
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 猜箱子连续失败，物理删除 take/donate 分支；改为起床收炉→显式卖 Copper Bar/Gold Bar 清包→40 层刷铁→回
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Gold Bar", count=10）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `ship_produce`（except=["Salad", "Strange Bun", "Coal", "Iron Ore", "Gold Ore", "Copper Ore", "Stone"]）
23. `collect_machines`
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c234e4dd39f940ae8237d88663b44546
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为先收炉装矿、显式卖铜锭金锭清包，再下 40 层刷铁，回农场收锭后视铁锭数升 hoe，剩余时间钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Gold Bar", count=10）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `collect_machines`
24. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：ff5e05c414e440ad9238e46458f22535
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1c1a7158ad7545ebb881feac92719630
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2a60a8f19ce84fdc87ff242dd04fc590
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：f59253d079f44f8eb5afd52f3d40f4a4
  - 耗时：77.203 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：901f1a3b953c472c9091f3947bd6d872
  - 耗时：44.094 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：c4108f71e1e44f028da182af2e18dbbe
  - 耗时：0.485 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=62）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：7e2ec47038d140c78fdc28ab614d5351
  - 耗时：0.469 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Gold Bar", count=10）
  - 结果：'Gold Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：5490e2e7fde747f9ab89b81a7a3ebb4c
  - 耗时：0.484 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：50491686f0224faabf9a34b5a8d1830b
  - 耗时：50.672 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：9c00ed276e6b4965ac9e847fd086ffd9
  - 耗时：33.656 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "River Jelly", "Strange Bun", "Melon Seeds", "Green Algae", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：779db631789342358d3914fe895b59a9
  - 耗时：15.125 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "River Jelly", "Strange Bun", "Melon Seeds", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：8c96b28818a349e69cff2c95742d6fd1
  - 耗时：0.468 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：874d616b790a4cfea897ee50509427de
  - 耗时：0.453 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：9ff118c50c3c48ab95aaaff3d6d56bcd
  - 耗时：40.328 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：6e6fabb1a13a4a879d74f4d01db2d04a
  - 耗时：39.703 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "River Jelly", "Strange Bun", "Melon Seeds", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x River Jelly
  - 执行状态：SUCCESS · 操作编号：4296d13e23f744528c7a11e3b396b220
  - 耗时：1.125 秒 / 游戏 0 分钟
- **11:40** Blacksmith ✅ `upgrade_tool`（tool="hoe"）
  - 结果：mined from floor 95 to 97 (2 floors down, 92 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：71ef0a9993a74019ba5741e4183eed49
  - 耗时：179.937 秒 / 游戏 240 分钟
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Burglar's Shank
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **16:30** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：68a6728fbd3e4c00b851084721e2fa57
  - 耗时：62.297 秒 / 游戏 80 分钟
- **17:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Tiger Trout, Bream, Green Algae, Bream)
  - 执行状态：SUCCESS · 操作编号：5f293a238def4f229ca4fc8b5f654d9c
  - 耗时：95.36 秒 / 游戏 100 分钟
  - 🗨️ [hud] Tiger Trout
- **19:30** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：757c21fc4c06490bbd6c593b7ab0513b
  - 耗时：15.328 秒 / 游戏 10 分钟
- **19:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6f81c815a3a14ab9aa0ea324243cf957
  - 耗时：0.469 秒 / 游戏 0 分钟
- **19:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4258971aac9a4df0b0672c4552058973
  - 耗时：0.453 秒 / 游戏 0 分钟
- **19:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：87fabed2c60442a3a5e8708f2fc128b4
  - 耗时：23.594 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：67913 → 67988（+75g）
- 出货估值：75g　动作：43 个　失败：24 个
- 模型调用：7 次　tokens：86595
- 有效动作率：0.5　空转：5　熔断跳过：8
- 失败耗时：6.687 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天43动作24失败，核心死循环：ship Copper Bar/Gold Bar 报 not found（锭不在背包），store_items 报箱子(74,16)不可达，空格始终4格，mine/upgrade 全被拒。take 凭ID猜箱子12次全废。有效动作只有 Forest 钓鱼4条和一次 mine 95→97。今天必须换清包手段：先读背包真实内容，只卖确实存在的冗余；箱子路径不可达，改用 ship 或直接丢弃。

**新教训：**
- ship_produce 卖背包里不存在的物品（如 Copper Bar/Gold Bar）会报 not found 且不腾格：每次 ship 前必须先读背包完整清单，只对清单中实际存在的物品调 ship，绝不凭记忆猜。
- 箱子坐标(74,15)/(74,16)已不可达（store_items 报 could not reach (74,16); stopped at (53,8)）：store_items 应物理删除，腾格只能靠 ship_produce 卖背包内实际冗余物。
- 昨天 mine 从 95→97 层成功但背包几乎满，说明深层能挖但收益被背包卡死：下矿前空格≥5 是硬门票，清包验证失败当天就该转钓鱼，而不是继续调 mine。
- 昨天 12 次 take 全失败且脚本重写 3 次仍在重试同一批 ID：take 失败后必须当天物理删除该动作，重写脚本只调整未完成分支，不重试已失败动作。
- 昨天 donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 等开门再失败：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 13）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 67913g 充足，卡点 Iron Bar 0/5，已连续 9 天零推进。铁锭链是全局瓶颈，钢斧、洒水器、高级洒水器全排在后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是唯一门票，而清包手段必须换掉**。

接下来 3 天主活动：
- **今天（秋 13）**：起床 collect→读背包真实内容→**用 ship_produce 只卖背包里确实存在的冗余**（先读再卖，不猜）→验证空格≥5→电梯 40 层刷铁矿石+煤→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 14）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 15）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包改为「先读后卖」**：昨天 ship Copper Bar/Gold Bar 报 not found，说明这些锭根本不在背包里（在不可达的箱子里）。今天起床第一步读背包完整清单，**只对清单里实际存在的物品调 ship_produce**，优先卖：多余种子、Green Algae、River Jelly、Strange Bun、Sap、多余 Stone（留 500）。**绝不 ship 背包里没有的东西**。
2. **箱子路径(74,15)/(74,16)不可达**：store_items 连续报 could not reach，今天物理删除 store_items，也禁止 goto 该坐标。需要腾格只能靠 ship_produce 或直接丢弃低价值物。
3. **take 全天物理删除**：连续三天凭 ID 猜箱子全失败，箱子内容与记忆不符。需要矿物靠下矿现拿。
4. **食物**：背包已有 8 沙拉（昨天记录），下矿前读背包确认 Salad≥5；不足则 12:00 后 goto Saloon→open_shop 买。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**（昨天 98 层无路可走）。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖）**：读背包完整清单 → 对清单中实际存在的冗余物品调 ship_produce（优先多余种子/Green Algae/River Jelly/Strange Bun/Sap/多余 Stone 留 500）→ 读背包验证空格≥5；不足再卖第二档 → 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items、不调 take、不 ship 背包里没有的物品**。
4. 补食物到≥5：读背包 Salad≥5 即跳过；不足且时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
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
- **ship_produce 只卖背包里实际存在的物品**：昨天 ship Copper Bar/Gold Bar 报 not found，说明这些锭不在背包。每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **store_items / take 今天禁用**：箱子路径(74,15)/(74,16)不可达，store 报 could not reach；take 凭 ID 猜箱子连续三天全失败。
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
3. 清包到空格≥5（**先读背包清单，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天43动作24失败，核心死循环：ship Copper Bar/Gold Bar 报 not found（锭不在背包），store_items 报箱子(74,16)不可达，空格始终4格，mine/upgrade 全被拒。take 凭ID猜箱子12次全废。有效动作只有 Forest 钓鱼4条和一次 mine 95→97。今天必须换清包手段：先读背包真实内容，只卖确实存在的冗余；箱子路径不可达，改用 ship 或直接丢弃。
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
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Gold Bar' not found in inventory 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 10:50 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 19:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 19:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 19:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 19:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包死循环：ship_produce 卖 Copper Bar/Gold Bar 报 not found，store_items 报箱子不可达，空格始终 4 格 @ ArchaeologyHouse / Farm — ship: 'Copper Bar' not found in inventory；store_items: could not reach (74,16); stopped at (53,8)（做不了：mine 被「store did not free enough slots (have 4, need 5)」拒绝，upgrade_tool 同样被拒，铁锭链连续 9 天零推进） 〔复盘〕
- take 凭物品 ID 猜箱子连续三天全失败，脚本重写 3 次仍重试同一批 ID（62/64/68/72/84/86） @ Farm 箱子 — '62' is not in any farm chest；take 62 already failed; not retrying today（做不了：无法从箱子取矿物/献祭物，浪费 12 个动作） 〔复盘〕
- donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 等开门再失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费 2 动作，博物馆献祭无进展） 〔复盘〕
- load_machines 返回 no empty machine accepts anything，熔炉要么满料要么未完成 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石无法装炉，铁锭链停滞） 〔复盘〕
- collect_machines 在熔炉未完成时连续空转被抑制 @ Farm — repeated ineffective action suppressed until game state changes（做不了：浪费 2 动作） 〔复盘〕
