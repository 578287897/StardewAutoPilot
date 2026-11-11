# 第5年 winter 4 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:45 开始）
- 天气：sunny　金钱：65230g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：57c819140c5748d9807dba8826a8f045
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：010d96d344734240a1e29bf4d66a891c
  - 耗时：3.36 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Broken CD
  - 执行状态：SUCCESS · 操作编号：b6fd048f33db48d3a424f084aecf0516
  - 耗时：6.156 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：1f54706a81ba4f8b999bdc3bd01f3aec
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：8007fc33d4b348149b602e7f6d14023c
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~82g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：a60dbceec47c46f98b53c435b4489857
  - 耗时：0.797 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_04）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天必须把铁锭从 1 补到 5
- 起床 collect_machines 收熔炉成品，读炉状态，有空炉且 Iron Ore≥5 才 load
- 清包：在农场出货箱 ship_produce 卖 Copper Bar 留 20（约 65 个），再卖多余 Sap/Green Algae，读背包验证空格≥5
- 食物已有 Salad×8 够用，跳过 Saloon
- 空格≥5 且食物≥5 且武器 Claymore 20-32 达标 → goto Mine 电梯直达 40 层，mine ≤2 次每次 ≤5 层刷铁矿石+煤
- mine 成功一次后回农场 ship_produce 腾格，再决定第二次下矿
- 回农场 collect_machines 收铁锭；铁锭≥5 且时间<13:00 → Blacksmith 升 hoe
- 铁锭不够则转 Forest 钓鱼兜底，21:30 前 sleep
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
11. `ship_produce`（except=["Salad", "River Jelly", "Perch", "Iron Bar", "Gold Bar", "Gold Ore", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Squid Ink", "Green Algae", "Clay", "Broken CD"]）
12. `ship`（item="Sap", count=48）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=6）
22. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2bed189a7d3c4681ab0094686c82353f
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 在农场箱子不存在，删除全部 take/donate_museum 分支；改为出货箱卖 Copper Bar 清包后下矿刷铁，铁锭够则升 ho
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=6）
17. `goto_location`（location="Farm"）
18. `ship_produce`（except=["Salad", "River Jelly", "Perch", "Iron Bar", "Gold Bar", "Gold Ore", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Squid Ink", "Green Algae", "Clay", "Broken CD"]）
19. `collect_machines`
20. `ship_produce`（except=["Salad", "River Jelly", "Perch", "Iron Bar", "Gold Bar", "Gold Ore", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Squid Ink", "Green Algae", "Clay", "Broken CD"]）
21. `collect_machines`
22. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d25b6237cd4946fc926b997911cf49fb
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 已连续失败，全天删除 take/donate 分支；改为农场出货箱卖 Copper Bar 清包后下矿刷铁，铁锭够则升 hoe，不够则 Fo
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
15. `fish`（casts=6）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Salad", "River Jelly", "Iron Bar", "Gold Bar", "Gold Ore", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Squid Ink"]）
19. `collect_machines`
20. `ship_produce`（except=["Salad", "River Jelly", "Iron Bar", "Gold Bar", "Gold Ore", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Squid Ink"]）
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：36832156f6424ebf8f4f4efa9f30326d
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失败（箱子内容与记忆不符），删除 take/donate 分支；改为在农场出货箱卖 Copper Bar 腾格后直接下矿刷铁，铁锭够则升
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Green Algae", count=1）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=6）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：310da1b0cc51401bb3f82659b92d1405
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：64062dc96c434ee2902c57a5081a5e0f
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c8c58b4b8c874fd3ade74facbb9380ef
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5a1c93ef07724387a27bb9de58b2545f
  - 耗时：79.906 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：522d96703883427b8de52fc752c7b073
  - 耗时：44.109 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：2900f281f33c480e85868bfde8272b75
  - 耗时：0.469 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：a11554d495404be9884b352d33efa332
  - 耗时：0.454 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Green Algae", count=1）
  - 结果：shipped 1x Green Algae (~15g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：17fcfd8f07af47fc9881a435ccd46645
  - 耗时：43.969 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：455860304cde402ca8b21bcdd31ecf8d
  - 耗时：91.562 秒 / 游戏 120 分钟
- **11:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：2bac86b2e4a64ed79cbfae65f3ec6a1a
  - 耗时：33.688 秒 / 游戏 40 分钟
- **11:40** Mine ❌ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (52,8)
  - 执行状态：ACTION_FAILED · 操作编号：353e361c14a14fe990cec922b9785c73
  - 耗时：13.422 秒 / 游戏 20 分钟
- **11:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **12:40** Farm ❌ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (52,8)
  - 执行状态：ACTION_FAILED · 操作编号：8c1009d0bef647c4a3b11856f89e98b4
  - 耗时：7.657 秒 / 游戏 10 分钟
- **12:40** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **12:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：08a6c6f46e5a4996b84f055a819a392e
  - 耗时：73.578 秒 / 游戏 90 分钟
- **14:20** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：af027eefdec74d6e8d37a8bb174b381a
  - 耗时：62.281 秒 / 游戏 80 分钟
- **14:20** Blacksmith ✅ `store_items`（items=["River Jelly", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：d9e63d533285419ca408550fdc1d3638
  - 耗时：24.0 秒 / 游戏 30 分钟
- **14:20** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **16:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：fdcc5d76211a4e3fb87fe76503969735
  - 耗时：23.937 秒 / 游戏 40 分钟
- **16:50** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Perch, Perch, Perch, Pike, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：627892c3c4ca45a5a16615a658cd582a
  - 耗时：152.781 秒 / 游戏 140 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **19:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：dcb32961d8924ea88f64fa3ce63ec937
  - 耗时：9.703 秒 / 游戏 10 分钟
- **19:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：28342ef68c68486a840f2cba3008ade5
  - 耗时：0.516 秒 / 游戏 0 分钟
- **19:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：880c46ddb7d648c0b463ce81f95ecf4a
  - 耗时：23.609 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65230 → 65327（+97g）
- 出货估值：82g　动作：40 个　失败：23 个
- 模型调用：7 次　tokens：86783
- 有效动作率：0.4375　空转：5　熔断跳过：7
- 失败耗时：27.176 秒 / 游戏 30 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 23 个失败动作中，12 个是 take 空跑，2 个是 store_items 因箱子不可达失败，2 个是 mine 因空格不足被拒，1 个是 ship 在博物馆执行失败。核心问题仍是清包没有真正执行：Copper Bar 85 个一个没卖，空格始终只有 3 格，导致下矿和升级全部被卡住。钓鱼 6 条是唯一有效产出。今天必须把「卖 Copper Bar 腾格」做成唯一清包手段，并在清包失败时直接切到钓鱼。

**新教训：**
- 昨天 ship 在 ArchaeologyHouse 报 'Copper Bar' not found，但材料汇总显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包，不要在博物馆/商店里调 ship。
- 昨天 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝后，脚本又调 store_items 再 mine，连续被拒 2 次：mine 返回空格不足后应直接判定当天钓鱼日，不再调 store_items 或重试 mine。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 全部空转：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支，而不是让 mine/upgrade 分支被删后无事可做。
- 昨天 take 连续 12 次空跑（'62' is not in any farm chest / already failed），脚本重写 3 次仍在重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天 donate_museum 在 ArchaeologyHouse 报 'nothing in the backpack can be donated'，且 goto ArchaeologyHouse 因 Town 不可达失败：donate 与博物馆分支应全天物理删除，等巫师来信后再去。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 5）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65230g 早已够，卡点只有 Iron Bar 1/5，已连续 6 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票**，而连续两天被拒证明「边下边补」不成立——清包必须在生成 mine 分支之前完成并读背包验证。

接下来 3 天主活动：
- **今天（冬 5）**：起床 collect→读背包→**在农场出货箱 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格）→读背包验证空格≥5**→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。验证不过即转 Forest 钓鱼，不空转。
- **明天（冬 6）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 7）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 在农场出货箱卖 Copper Bar 留 20**：昨天 85 个 Copper Bar 一个没卖，空格仍 3。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：昨天在 ArchaeologyHouse 调 ship 报 not found。ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **换季日不买种子**：冬 5 不买任何作物种子；冬季种子/茶苗留到明天再买。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 5 不买任何作物种子；冬季种子/茶苗留到明天。
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
> 昨天 23 个失败动作中，12 个是 take 空跑，2 个是 store_items 因箱子不可达失败，2 个是 mine 因空格不足被拒，1 个是 ship 在博物馆执行失败。核心问题仍是清包没有真正执行：Copper Bar 85 个一个没卖，空格始终只有 3 格，导致下矿和升级全部被卡住。钓鱼 6 条是唯一有效产出。今天必须把「卖 Copper Bar 腾格」做成唯一清包手段，并在清包失败时直接切到钓鱼。
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
- 11:40 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (52,8) 〔自动〕
- 11:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:40 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (52,8) 〔自动〕
- 12:40 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 14:20 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 19:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 19:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包始终没有真正执行：Copper Bar 85 个一个没卖，空格始终只有 3 格 @ Farm 出货箱 — ship_produce 被跳过或未对 Copper Bar 执行；日志显示只 ship 了 Green Algae（15g），mine 被 'have 3, need 5' 拒绝（做不了：下矿拿铁矿石、升级钢锄头全部被卡住） 〔复盘〕
- take 连续 12 次空跑，脚本重写 3 次仍在重试同一批箱子物品 ID @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作和时间，挤占了下矿和钓鱼的窗口） 〔复盘〕
- store_items 因箱子坐标 (74,16) 不可达连续失败，导致 mine 被空格不足拒绝 @ Farm 箱子 (74,16) — could not reach (74,16); stopped at (52,8)（做不了：无法通过存箱腾出空格，mine 连续被拒） 〔复盘〕
- ship 在 ArchaeologyHouse 执行报 'Copper Bar' not found，但材料汇总显示背包有 85 个 @ ArchaeologyHouse — 'Copper Bar' not found in inventory（做不了：清包失败，空格没有腾出） 〔复盘〕
- donate_museum 在博物馆报 'nothing in the backpack can be donated'，且 Town 不可达时 goto ArchaeologyHouse 也失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费了去博物馆的往返时间） 〔复盘〕
- 清包失败后没有钓鱼兜底，12:40 到 21:30 之间大量空转 @ Farm — mine/upgrade 分支被删后脚本没有生成 goto Forest→fish，时间空转（做不了：当天没有额外收入，铁锭进度为零） 〔复盘〕
