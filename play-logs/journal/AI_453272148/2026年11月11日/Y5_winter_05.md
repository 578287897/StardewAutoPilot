# 第5年 winter 5 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:57 开始）
- 天气：snow　金钱：65327g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：af5a2d813b804c5c808b32d16e59de7d
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：6ad27265671545ad83ce00df58ed616c
  - 耗时：3.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：5ffc1aeed4ac4586886f1418697041f8
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：6079d68079ad458f98fd6e9a0f18c404
  - 耗时：0.546 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：eb04925163b041f2b28ccb352492d648
  - 耗时：0.468 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~560g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：2680c075512941858ae72aa941438257
  - 耗时：0.906 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_05）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——铁锭链是全局瓶颈
- 起床收熔炉→读背包→在农场出货箱卖 Copper Bar 留 20 腾格并验证空格≥5
- 空格≥5 且食物≥5 则电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次≤5 层）
- 回农场收铁锭，铁锭≥5 且 13:00 前则去 Blacksmith 升 hoe
- 清包失败或下矿被拒则转 Forest 钓鱼兜底，不空转
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
11. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar"]）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `craft`（item="Sprinkler", count=1）
23. `place`（item="Sprinkler"）
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dae5ce897d41413f866a79d68d55406c
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除无效的 take/donate_museum 分支，改为在农场出货箱卖 Copper Bar 清包后下矿刷铁，铁锭够则升钢锄头。
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
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar"]）
18. `collect_machines`
19. `craft`（item="Sprinkler", count=1）
20. `place`（item="Sprinkler"）
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fcb830d41b5945bd86dddf00307ec6a8
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 已连续失败且箱子内容与记忆不符，全天删除 take/donate 分支；改为在农场出货箱卖 Copper Bar 清包后电梯 40 层刷铁，
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
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore"]）
19. `collect_machines`
20. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9430cae494f343e4a4a592246707eb37
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为先收熔炉+出货箱卖 Copper Bar 腾格，再电梯下矿刷铁，铁锭够则升 hoe，不够转 Forest 钓鱼兜底。
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
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=5）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
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
  - 执行状态：ACTION_FAILED · 操作编号：d2119f9ac42c4a029516ebda433357ac
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4bcb4a8b44ec4533a7478849a526abb9
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：db42d74bf8424300ad98bac3d82108f8
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：cc0403277fd5413a815d8c3cd46c4769
  - 耗时：79.922 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c8dfaf8d0dc2499ea6a2ead0f8d068db
  - 耗时：48.594 秒 / 游戏 60 分钟
- **09:00** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：ebec856833e24a98b6b966b11c2c0624
  - 耗时：0.5 秒 / 游戏 0 分钟
- **09:00** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1ede6c19df4e42a9959dc564727b206e
  - 耗时：50.719 秒 / 游戏 60 分钟
- **10:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：112b869edf3c406084f82a25bebfbcc5
  - 耗时：33.656 秒 / 游戏 40 分钟
- **10:00** Mine ❌ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：187d523ad02c4618ac15350d1fa7c046
  - 耗时：12.625 秒 / 游戏 20 分钟
- **10:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：2f304523443b4a0f9994de905ef90501
  - 耗时：0.579 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：75a3af3c16634ac1896f6412cdf885ee
  - 耗时：7.672 秒 / 游戏 10 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：c6fe2710c695496f93a3416fd3e9d7f2
  - 耗时：73.812 秒 / 游戏 90 分钟
- **12:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：857c826c69d340acbba3154a943e93af
  - 耗时：106.734 秒 / 游戏 140 分钟
- **12:40** Blacksmith ✅ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a38b8b5bc7fd451594e5afd8c6926795
  - 耗时：19.922 秒 / 游戏 30 分钟
- **12:40** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **15:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：334f5288e1b84071b26d550817937330
  - 耗时：23.875 秒 / 游戏 30 分钟
- **16:00** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Perch, Joja Cola, Green Algae, Perch)
  - 执行状态：SUCCESS · 操作编号：181e056da2b04ba4b6055a9ba125d3e6
  - 耗时：109.875 秒 / 游戏 120 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Green Algae
- **18:00** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Perch, Perch, Pike, Driftwood, Perch)
  - 执行状态：SUCCESS · 操作编号：fa4959d7dbaf4738b2d03015bba999f3
  - 耗时：110.719 秒 / 游戏 110 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **19:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Perch, Perch, Perch, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：5b1d4b1aa55e4391a5d8a4b2e1cfaa5a
  - 耗时：118.187 秒 / 游戏 130 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **22:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：43567bfef80d4dd089fb2406cb48459e
  - 耗时：9.672 秒 / 游戏 10 分钟
- **22:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：4e8665a5d05f4f028500882c3dbf719f
  - 耗时：0.547 秒 / 游戏 0 分钟
- **22:10** Farm ✅ `ship_produce`（except=["Salad", "River Jelly", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rusty Sword", "Rubber Boots", "Pumpkin Seeds", "Gold Bar", "Iron Bar", "Copper Ore", "Iron Ore", "Gold Ore"]）
  - 结果：shipped 1 stacks worth ~656g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：487aa9507ca14f079ee2fc8293a8c47a
  - 耗时：20.547 秒 / 游戏 30 分钟
- **22:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **22:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1ac45c036be6453cae649eedac947a3f
  - 耗时：0.515 秒 / 游戏 0 分钟
- **22:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7ef45606ae1548bc9fac0347714aa845
  - 耗时：6.859 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65327 → 66543（+1216g）
- 出货估值：1216g　动作：43 个　失败：23 个
- 模型调用：7 次　tokens：86332
- 有效动作率：0.4857　空转：6　熔断跳过：7
- 失败耗时：26.452 秒 / 游戏 30 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 43 个动作中 23 个失败，核心问题仍是清包：Copper Bar 85 个一个没卖，空格始终 3 格，mine 和 upgrade 被「need 5」连续拒绝；脚本重写 3 次仍在重试不存在的箱子物品 ID，且清包失败后没有钓鱼兜底，12:40 后空转到 21:30。有效动作只有 Forest 钓鱼 3 轮（约 15 条鱼、约 1.2k 出货）。今天必须把「卖 Copper Bar 留 20」作为起床后第一个动作并读背包验证，验证失败立即转钓鱼，不再重试 mine。

**新教训：**
- 清包失败后脚本没有钓鱼兜底，昨天从 12:40 到 21:30 全部空转：清包验证空格<5 后必须在同一脚本里生成 goto Forest→fish 分支，而不是让 mine/upgrade 分支被删后无事可做。
- 昨天 ship 在 ArchaeologyHouse 报 'Copper Bar' not found，但材料汇总显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包，不要在博物馆/商店里调 ship。
- 昨天 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝后，脚本又调 store_items 再 mine，连续被拒 2 次：mine 返回空格不足后应直接判定当天钓鱼日，不再调 store_items 或重试 mine。
- 昨天脚本重写 3 次仍在重试同一批箱子物品 ID（62/64/68/72/84/86），说明重写逻辑没有读取最新背包：重写前必须先读背包完整清单，只对清单里实际存在的物品生成动作。
- 昨天 load_machines item=Iron Ore 报 'no empty machine accepts anything'，但材料里 Iron Ore 只有 1：load 前必须读背包确认 Iron Ore≥5 且炉子为空，否则物理删除 load 分支。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 6）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65327g 早已够，卡点只有 Iron Bar 1/5，已连续 7 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票**，而连续三天被拒证明「边下边补」不成立——清包必须在生成 mine 分支之前完成并读背包验证。

接下来 3 天主活动：
- **今天（冬 6）**：起床 collect→读背包→**在农场出货箱 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格）→读背包验证空格≥5**→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。验证不过即转 Forest 钓鱼，不空转。
- **明天（冬 7）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 8）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 在农场出货箱卖 Copper Bar 留 20**：连续两天 85 个 Copper Bar 一个没卖，空格仍 3。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：昨天在 ArchaeologyHouse 调 ship 报 not found。ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **换季日不买种子**：冬 6 不买任何作物种子；冬季种子/茶苗留到明天再买。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 6 不买任何作物种子；冬季种子/茶苗留到明天。
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
> 昨天 43 个动作中 23 个失败，核心问题仍是清包：Copper Bar 85 个一个没卖，空格始终 3 格，mine 和 upgrade 被「need 5」连续拒绝；脚本重写 3 次仍在重试不存在的箱子物品 ID，且清包失败后没有钓鱼兜底，12:40 后空转到 21:30。有效动作只有 Forest 钓鱼 3 轮（约 15 条鱼、约 1.2k 出货）。今天必须把「卖 Copper Bar 留 20」作为起床后第一个动作并读背包验证，验证失败立即转钓鱼，不再重试 mine。
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
- 09:00 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:00 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 10:00 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:00 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:40 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 22:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 22:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 22:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 清包计划执行了但 Copper Bar 一个没卖，空格始终 3 格，导致下矿和升级连续被拒 @ Farm 出货箱 — mine 返回 'store did not free enough slots (have 3, need 5)'，upgrade_tool 同样被拒；材料汇总显示 Copper Bar 85 个仍在背包（做不了：钢锄头升级、40 层刷铁矿全部无法开始，铁锭链连续第 7 天零推进） 〔复盘〕
- 脚本重写 3 次仍在重试农场箱子里不存在的物品 ID（62/64/68/72/84/86），take 连续空跑 12 次 @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作和时间，且重写逻辑没有读取最新背包，导致后续分支也基于错误状态生成） 〔复盘〕
- store_items 连续 3 次因箱子坐标 (74,16) 不可达失败，之后 mine 仍被调用 @ Farm / Mine 入口 — could not reach (74,16); stopped at (53,8)（做不了：清包无法通过存箱完成，mine 连续被 'need 5' 拒绝） 〔复盘〕
- 清包失败后没有钓鱼兜底，12:40 到 21:30 之间大量空转 @ Farm / Forest — 脚本删除 mine/upgrade 分支后没有生成 goto Forest→fish 分支，只做了 3 轮钓鱼和 2 次无效 collect_machines（做不了：下午到晚上约 8 小时没有产出，当天出货仅约 1.2k） 〔复盘〕
- donate_museum 在 ArchaeologyHouse 报无可捐赠物品，且 goto ArchaeologyHouse 因 Town 不可达失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：博物馆捐赠分支全天无效，浪费往返时间） 〔复盘〕
