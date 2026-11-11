# 第5年 winter 6 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:12 开始）
- 天气：snow　金钱：66543g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：22ab6d3c9bf2489093ef8bc867617d14
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：137d93b66a12456794fdc7f0bf19506d
  - 耗时：3.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Joja Cola
  - 执行状态：SUCCESS · 操作编号：941e2c7208624fcc92e014e19104d632
  - 耗时：6.172 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：db6337466b7b4685bbf28d802aa8dac9
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：65c204878be64592b84e9165f0e85564
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：91d639af151c4db8a01dfa9dcef4a976
  - 耗时：0.531 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_06）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收熔炉成品，空炉且铁矿够就装料
- 在农场出货箱卖 Copper Bar 留 20 腾背包格，读背包验证空格≥5
- 空格够就电梯直达 40 层刷铁矿石+煤，两次 mine 每次 5 层
- 回农场收铁锭，铁锭≥5 且 13:00 前就去铁匠铺升 hoe
- 铁锭不够就转 Forest 钓鱼兜底，21:30 前 sleep
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
11. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore"]）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore"]）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=5）
22. `fish`（casts=5）
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：39118ba945c84e8ebb5fa32fa4e53445
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 在农场箱子连续空跑，全天物理删除 take/donate 分支；改为农场出货箱清包→40 层刷铁→回炉→13 点前升 hoe，凑不齐就 Fo
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
15. `fish`（casts=5）
16. `fish`（casts=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore", "Squid Ink"]）
21. `collect_machines`
22. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore", "Squid Ink"]）
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fed2caacd3a746fb90ebb783e0eb8519
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 分支全天删除（箱子内容与记忆不符），改为在农场出货箱卖 Copper Bar 清包后下矿刷铁，铁锭够就升钢锄头，不够转 Forest 钓鱼兜
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=20）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=5）
17. `fish`（casts=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore", "Squid Ink", "Copper Bar"]）
22. `collect_machines`
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8833f772182b4c80b715d062ae4005f9
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支连续失败已删除，改为在农场出货箱卖 Copper Bar 腾格后下矿刷铁，凑够 5 铁锭就升钢锄头，不够则钓鱼兜底收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Green Algae", count=3）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `goto_location`（location="Farm"）
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
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f390e56b272d4038b8b9303e2f3ed27a
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6833faf1987a4a1ebbffcee38eb04fa5
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e2da73a0da824b1b9c04d7e0c14a8726
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：cf7d0c59e8084145a4dcfed5268f2d3c
  - 耗时：80.344 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：5dc250ec75ef49798d381a6f0e278032
  - 耗时：43.766 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：801179b6ac8f4341a91ca6fc57645ad4
  - 耗时：0.516 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：e8d88564eeb8405e8085862fdf8769ac
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Green Algae", count=3）
  - 结果：shipped 3x Green Algae (~45g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：47fa168d012145058870c19d87734154
  - 耗时：43.968 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：01285e5b145f446892dca48e5158782b
  - 耗时：49.172 秒 / 游戏 60 分钟
- **10:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：d7c90e0b66444e03ad3005d2037ea6f1
  - 耗时：33.64 秒 / 游戏 40 分钟
- **10:40** Mine ✅ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：e96e9b7dfd154ee189fa98567e880e8f
  - 耗时：15.187 秒 / 游戏 30 分钟
- **10:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：435e29029c084298a1d7f5a84d37c601
  - 耗时：0.547 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：492ed1a4e5514a44821c8ddb7e5e3af6
  - 耗时：40.313 秒 / 游戏 40 分钟
- **12:30** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：7d8622f6022a4b7b9c68fce4eca40aa4
  - 耗时：39.032 秒 / 游戏 50 分钟
- **12:30** Blacksmith ✅ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x River Jelly
  - 执行状态：SUCCESS · 操作编号：7bc26de6883b4e79a4169055214fb2d2
  - 耗时：1.156 秒 / 游戏 0 分钟
- **12:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：fbcd4dfc5ee94f46b3da4947ffdbaa77
  - 耗时：23.688 秒 / 游戏 30 分钟
- **13:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Pike, Perch, Green Algae, Perch)
  - 执行状态：SUCCESS · 操作编号：40563bfe0d9546948200fd64fd803f86
  - 耗时：105.938 秒 / 游戏 100 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
- **15:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Green Algae, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：049455d0015f4c63974a26a96ed775f9
  - 耗时：55.031 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **16:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：836bb810cd884f6a8f25b81c7635eac4
  - 耗时：9.641 秒 / 游戏 10 分钟
- **17:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：37c8cfcd0d034654850e2fd56162b3f7
  - 耗时：0.515 秒 / 游戏 0 分钟
- **17:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：1299564fc19c4869b7eadb47ab8548ba
  - 耗时：23.656 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66543 → 66588（+45g）
- 出货估值：0g　动作：41 个　失败：21 个
- 模型调用：7 次　tokens：87406
- 有效动作率：0.4848　空转：6　熔断跳过：7
- 失败耗时：6.766 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天41动作21失败，核心仍是背包空格3格导致mine/upgrade被拒，清包计划连续三天未执行（Copper Bar 85个一个没卖）。take/donate/store_items等非里程碑动作仍被生成，浪费大量动作。钓鱼兜底有效（10条鱼）。今天必须把清包作为唯一前置：在农场出货箱卖Copper Bar留20，读背包验证空格≥5后再下矿；验证不过直接钓鱼日，不空转。

**新教训：**
- 昨天 ship_produce Copper Bar 在 ArchaeologyHouse 报 not found，但材料显示背包有 85 个：ship 必须在农场出货箱附近执行，且 ship 前先 close_menu 再读背包，不要在博物馆/商店里调 ship。
- 昨天 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝后，脚本又调 store_items 再 mine，连续被拒 2 次：mine 返回空格不足后应直接判定当天钓鱼日，不再调 store_items 或重试 mine。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 全部空转：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支，而不是让 mine/upgrade 分支被删后无事可做。
- 昨天 take 连续 12 次空跑（'62' is not in any farm chest / already failed），脚本重写 3 次仍在重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天 donate_museum 在 ArchaeologyHouse 报 'nothing in the backpack can be donated'，且 goto ArchaeologyHouse 因 Town 不可达失败：donate 与博物馆分支应全天物理删除，等巫师来信后再去。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 7）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 66543g 早已够，卡点只有 Iron Bar 1/5，已连续 8 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票**，连续四天被拒证明「边下边补」不成立——清包必须在生成 mine 分支之前完成并读背包验证。

接下来 3 天主活动：
- **今天（冬 7）**：起床 collect→读背包→**在农场出货箱 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格）→读背包验证空格≥5**→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。验证不过即转 Forest 钓鱼，不空转。
- **明天（冬 8）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 9）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 在农场出货箱卖 Copper Bar 留 20**：连续三天 85 个 Copper Bar 一个没卖，空格仍 3。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：昨天在 ArchaeologyHouse 调 ship 报 not found。ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **换季日不买种子**：冬 7 不买任何作物种子；冬季种子/茶苗留到明天再买。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 7 不买任何作物种子；冬季种子/茶苗留到明天。
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
3. 清包到空格≥5（**先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天41动作21失败，核心仍是背包空格3格导致mine/upgrade被拒，清包计划连续三天未执行（Copper Bar 85个一个没卖）。take/donate/store_items等非里程碑动作仍被生成，浪费大量动作。钓鱼兜底有效（10条鱼）。今天必须把清包作为唯一前置：在农场出货箱卖Copper Bar留20，读背包验证空格≥5后再下矿；验证不过直接钓鱼日，不空转。
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
- 10:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:30 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 17:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 17:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包计划连续三天未执行，Copper Bar 85 个一个没卖，背包空格始终 3 格 @ Farm（出货箱旁） — 计划写的是 ship_produce Copper Bar，但实际只卖了 80 石头（160g），Copper Bar 未动；随后 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝 2 次（做不了：下矿拿铁矿石、升级钢锄头全部被卡住，铁锭链连续 8 天零推进） 〔复盘〕
- take 在农场箱子连续空跑 12 次，脚本重写 3 次仍在重试同一批物品 ID @ Farm（箱子） — '62' is not in any farm chest / take 62 already failed; not retrying today，62/64/68/72/84/86 全部不存在（做不了：浪费 12 个动作和 3 次脚本重写，挤占了清包和下矿的时间） 〔复盘〕
- donate_museum 在博物馆报无可捐献物品，且 goto ArchaeologyHouse 因 Town 不可达 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum；goto ArchaeologyHouse 失败（做不了：浪费 2 个动作，且说明博物馆分支在 wait_letter 阶段不应生成） 〔复盘〕
- ship_produce Copper Bar 在博物馆调用报 not found，但材料汇总显示背包有 85 个 @ ArchaeologyHouse — 'Copper Bar' not found in inventory（菜单未关/不在出货箱旁）（做不了：清包失败，直接导致后续 mine/upgrade 被空格不足拒绝） 〔复盘〕
- mine 被空格不足拒绝后脚本又调 store_items 再 mine，连续被拒 2 次 @ Farm / Mine — store did not free enough slots (have 3, need 5)，store_items 也未能补格（做不了：下矿拿铁矿石、升级钢锄头全部被卡住） 〔复盘〕
