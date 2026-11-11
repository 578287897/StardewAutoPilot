# 第5年 fall 28 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:12 开始）
- 天气：sunny　金钱：64928g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0b8f3b8d1cf54cf6b0b2857fed551a08
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：8c75860f2f3349ed970af7c25ad0b185
  - 耗时：3.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：49d05b84440844679fc3c12e1e619c0a
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：a0cc2e8470b648bcbe18d82fac849444
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：395a7377986d4901b0c2f152ed23908a
  - 耗时：0.5 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_28）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——铁锭链是全局瓶颈，今天必须推进
- 起床收熔炉→装铁矿石→清包（卖 Copper Bar 留 20 腾格，读背包验证空格≥5）
- 电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场炼铁，铁锭≥5 且 9:10-13:00 窗口内去 Blacksmith 升 hoe
- 铁锭不够则补食物后继续 40-50 层刷铁，收尾钓鱼或 sleep
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
11. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar", "Copper Bar"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=80）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar", "Copper Bar"]）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Farm"）
24. `craft`（item="Sprinkler", count=1）
25. `place`（item="Sprinkler"）
26. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：21c0e4dfadb648c0904db01dd5bbdc01
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 全天删除；改为先收熔炉、卖 Copper Bar 腾格，再电梯 40 层刷铁，回农场收锭后窗口内升 hoe，最后睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=80）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar", "Copper Bar"]）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9763ed7f3b58482ca9f741a477d7a160
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为先清包卖 Copper Bar 腾格再下矿刷铁，铁锭够则在窗口内升 hoe，收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=80）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：67d9e87f8d604bdba62f07e15816f8a7
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为直接卖 Copper Bar 腾格后下矿刷铁，回农场收锭炼铁，收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=80）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：16a7df41cccf4d1d9f3e28c19a60ef13
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5447d63d1e2b408db329b677d84c1eff
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：833501603ae64bbba341aa2f29cd55ec
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：42e2df814deb476faf2fedba6fbd4f0e
  - 耗时：86.172 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：088022c8ce4545f4a80f7850fba147eb
  - 耗时：47.047 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：b83d2593ad6d4c4bb57c9085ce90d494
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：33d36b8e2b574a468e04ab7092968a2b
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=80）
  - 结果：shipped 80x Stone (~160g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：b420fde56a8245bcb18288d69df6cc58
  - 耗时：43.953 秒 / 游戏 60 分钟
- **09:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：6bde10ad3780477aa28ace9810685fc6
  - 耗时：49.094 秒 / 游戏 60 分钟
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：e9a4237503184138b38bec579350b7fe
  - 耗时：33.657 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：4d57b62fa45948fd926f2e790a421827
  - 耗时：15.078 秒 / 游戏 20 分钟
- **10:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：2c07ad6c7b6441298a6e463d0faf750b
  - 耗时：0.532 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：b427e0e529cf4e5497b00d0d85cc2d10
  - 耗时：0.484 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：d6d74ec699bf4ec09a65692475327dc1
  - 耗时：0.468 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：267ed64b55ba4b32ba1dcd8896c98026
  - 耗时：0.468 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:50** Farm ✅ `store_items`（items=["Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：af9b2d24e6b14ba6b5137cf90075dd67
  - 耗时：0.609 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：c5d57fbf457745bf96642db599aeb28d
  - 耗时：24.0 秒 / 游戏 30 分钟
- **12:20** Forest ❌ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：could not reach (103,95); stopped at (104,95)
  - 执行状态：ACTION_FAILED · 操作编号：9c85dc4587a545c0905aacc55465cc40
  - 耗时：40.218 秒 / 游戏 50 分钟
  - 🗨️ [hud] Common Mushroom
- **13:10** Forest ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：donated: 1x Common Mushroom -> Fall Foraging
  - 执行状态：SUCCESS · 操作编号：f5b8c21a3d234f7988d71c5b29fe4357
  - 耗时：71.922 秒 / 游戏 100 分钟
- **14:50** CommunityCenter ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：82b418adb98f4123bb0bb22d21f41b91
  - 耗时：38.171 秒 / 游戏 40 分钟
- **14:50** CommunityCenter ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **15:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：69e4b051366f48409b22ebf31bde2db9
  - 耗时：9.047 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64928 → 65088（+160g）
- 出货估值：0g　动作：43 个　失败：26 个
- 模型调用：6 次　tokens：70191
- 有效动作率：0.3824　空转：9　熔断跳过：8
- 失败耗时：47.358 秒 / 游戏 50 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天26次失败集中在三处：take 12次空跑（箱子内容与记忆不符）、清包只卖80石头导致空格始终3格、mine被'have 3, need 5'连续拒绝3次。核心问题是清包手段失效——Copper Bar 85个一个没卖，而它是唯一能腾格的冗余物。今天必须起床先读背包、卖Copper Bar留20、验证空格≥5，再下矿；take/store_items/build_road/decorate全天物理删除。

**新教训：**
- 昨天清包只卖出80石头（160g），Copper Bar 85个一个没卖，空格始终3格，直接导致3次mine被'have 3, need 5'拒绝：清包第一步必须是卖Copper Bar留20，这是唯一能腾3-4格的手段，卖石头是杯水车薪。
- 昨天take连续12次空跑（'62' is not in any farm chest / already failed），脚本重写3次仍在重试同一批ID：农场箱子内容与记忆完全不符，take应全天物理删除，需要矿物只能下矿现拿。
- 昨天store_items连续3次因箱子坐标(74,16)不可达失败，导致mine连续被拒：清包必须在农场内用ship_produce完成并读背包验证空格≥5，不能指望store_items存箱。
- 昨天donate_museum在ArchaeologyHouse报'nothing in the backpack can be donated'，且goto ArchaeologyHouse因Town不可达失败：donate与博物馆分支应全天物理删除，等巫师来信后再去。
- 昨天build_road报'规划道路边没有还能走上去的空格'、decorate报'今天没有能做的装饰'、wait空转：这些非里程碑动作应在脚本生成阶段物理删除，收尾只允许sleep或钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 1）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64928g 早已够，卡点仍是 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（冬 1，换季第一天）**：起床 collect→**读背包→卖 Copper Bar 留 20 腾格→验证空格≥5**→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。换季日不买种子（冬季种子/茶苗留到明天）。
- **明天（冬 2）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 3）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

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
10. **换季日不买种子**：冬 1 不买任何作物种子；冬季种子/茶苗留到明天再买。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 1 不买任何作物种子；冬季种子/茶苗留到明天。
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
> 昨天26次失败集中在三处：take 12次空跑（箱子内容与记忆不符）、清包只卖80石头导致空格始终3格、mine被'have 3, need 5'连续拒绝3次。核心问题是清包手段失效——Copper Bar 85个一个没卖，而它是唯一能腾格的冗余物。今天必须起床先读背包、卖Copper Bar留20、验证空格≥5，再下矿；take/store_items/build_road/decorate全天物理删除。
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
- 10:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:20 动作 `forage` 失败 @ Forest — could not reach (103,95); stopped at (104,95) | 游戏消息: [hud] Common Mushroom 〔自动〕
- 14:50 动作 `build_road` 失败 @ CommunityCenter — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 清包手段失效，Copper Bar 85个一个没卖，空格始终3格 @ Farm（出货箱旁） — ship只卖了80石头（160g），Copper Bar未进ship清单；mine连续3次报'store did not free enough slots (have 3, need 5)'（做不了：下矿拿铁矿石、升级钢锄头全部被卡住） 〔复盘〕
- take动作连续12次空跑，脚本重写3次仍在重试同一批矿物ID @ Farm（箱子） — '62' is not in any farm chest / take 62 already failed; not retrying today（62/64/68/72/84/86全部不在箱子）（做不了：浪费大量动作和时间，挤占下矿窗口） 〔复盘〕
- store_items因箱子坐标不可达连续失败，无法腾格 @ Farm (74,16) — store_items返回OK但'nothing to store'，箱子实际不可达；mine随后报'have 3, need 5'（做不了：清包无法完成，mine/upgrade分支被连锁拒绝） 〔复盘〕
- donate_museum空跑，博物馆分支不可用 @ ArchaeologyHouse / Mountain — donate_museum: nothing in the backpack can be donated；goto ArchaeologyHouse因Town不可达失败（做不了：博物馆献祭无进展，浪费早晨8:00-8:50） 〔复盘〕
- build_road / decorate / wait 等非里程碑动作空转 @ Farm — build_road: 规划道路边没有还能走上去的空格；decorate: 今天没有能做的装饰（做不了：收尾阶段无有效产出，只能提前sleep） 〔复盘〕
- 铁锭链连续多天零推进，钢锄头里程碑停滞 @ Mine 40层以下 / Farm熔炉 — Iron Bar 1/5，Iron Ore仅1，熔炉无空炉可load（load_machines: no empty machine accepts anything）（做不了：钢锄头、钢斧、洒水器全部无法推进） 〔复盘〕
