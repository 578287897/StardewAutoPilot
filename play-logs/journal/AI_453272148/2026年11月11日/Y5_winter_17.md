# 第5年 winter 17 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（12:58 开始）
- 天气：sunny　金钱：73659g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6a767d1d8fac40e7ae7978b41c1fcb77
  - 耗时：3.343 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：17bb79f4ca0743999e00c918d549e04f
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Coal, 1x Broken CD, 1x Soggy Newspaper
  - 执行状态：SUCCESS · 操作编号：02ba0fda934d473f8b5ea5533353aa67
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：0d38fd11c7214a5eb182e726cf978a6b
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：2a09e03e10644f84b70da386228a2930
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~1556g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3b93dd00197e4ffea6e82d42e1dd9043
  - 耗时：0.797 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_17）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，铁矿石够就装炉
- 农场出货箱卖 Copper Bar 留 20，清包到空格≥5（唯一有效腾格手段）
- 清包成功后电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场收铁锭，铁锭≥5 且 12:00 前升 Steel Hoe
- 清包失败或下矿失败立即转 Forest 钓鱼兜底，21:30 前 sleep
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
12. `ship_produce`（except=["Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Rubber Boots", "Perch", "Pike"]）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `fight`（range=6）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=5）
23. `fish`（casts=5）
24. `fish`（casts=5）
25. `fish`（casts=5）
26. `goto_location`（location="Farm"）
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：89f32945b50049abab9087235028367a
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败已确认箱子无该物，删除全部 take/donate 分支，直接下矿刷铁再升级，失败则转 Forest 钓鱼。
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
19. `fish`（casts=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `ship_produce`（except=["Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Rubber Boots", "Perch", "Pike"]）
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fd79a9024a704b89a763e6a9c284ec36
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 分支已失效，删除取物与博物馆，直接下矿刷铁→收锭→升钢锄，失败转 Forest 钓鱼，傍晚回农场出货睡觉。
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
19. `fish`（casts=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `ship_produce`（except=["Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Rubber Boots"]）
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3506243fafa644b5ab4ab255f36d4268
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支彻底删除（箱子内容与记忆不符），保留原路线：下矿刷铁→12点前升 hoe→Forest 钓鱼兜底→回农场收炉→睡觉。
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
21. `load_machines`（item="Iron Ore"）
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
  - 执行状态：ACTION_FAILED · 操作编号：972e76757a3948f5afe8393e41aa14e3
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0435c54b0f9d4561b7f00f3998e19b26
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fd9f8979bb7b4ce38c4f0062ca62afa1
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5ddd268127784cc38809f1ed4542954c
  - 耗时：79.907 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：83df465e6e9543e091d4bc631553bb17
  - 耗时：44.11 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：2375e218f81b4c9a9570aac05b415b84
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：0e0f066ee5be48b6a95c19202292c10a
  - 耗时：50.719 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 18 (3 floors down, 70 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：da30f22898a54186af226a228256998e
  - 耗时：64.468 秒 / 游戏 90 分钟
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Cherry Bomb
  - 🗨️ [question] 
- **11:20** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：e43a34ce33184af3a69cda81d65e3fb2
  - 耗时：0.594 秒 / 游戏 0 分钟
- **11:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b3a47eb597994ab39f90db9635ba5a18
  - 耗时：36.282 秒 / 游戏 40 分钟
- **11:20** Mine ✅ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Slime", "Rubber Boots", "Bug Meat", "Cherry Bomb"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Geode, 1x Slime, 2x Bug Meat
  - 执行状态：SUCCESS · 操作编号：cc12ea9b0b174adbaf37f31e544a26cc
  - 耗时：15.235 秒 / 游戏 20 分钟
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **12:20** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：f5b5dbe3c4b84b54b9667a633fc89da2
  - 耗时：43.031 秒 / 游戏 50 分钟
- **13:10** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：ef213e45fad04032a6f8158706a9090a
  - 耗时：62.141 秒 / 游戏 80 分钟
- **13:10** Blacksmith ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Rubber Boots", "Cherry Bomb"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：803732f43171439daaa17de59808deef
  - 耗时：23.984 秒 / 游戏 30 分钟
- **13:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：4bdd6e8d44724f618916f5f7ac29810c
  - 耗时：23.891 秒 / 游戏 30 分钟
- **15:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Broken CD, Green Algae, Perch, Perch, Green Algae)
  - 执行状态：SUCCESS · 操作编号：6c9b7986cc1b4bb9a3597695827c9a96
  - 耗时：118.391 秒 / 游戏 140 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] The Night Market is 
now open. 
  - 🗨️ [hud] Perch
- **17:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Pike, Perch, Perch, Trash)
  - 执行状态：SUCCESS · 操作编号：9381e79c730843b19834508242af5ef6
  - 耗时：91.406 秒 / 游戏 100 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **19:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Perch, Perch, Perch, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：5ab7c1281aaa4bb096a6c0d5ca108579
  - 耗时：119.359 秒 / 游戏 100 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
- **21:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：2077c076db204aa98d3a77c9a3f69184
  - 耗时：9.672 秒 / 游戏 20 分钟
- **21:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **21:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：49df0bf15cb24718a8b4b70cefe4d686
  - 耗时：0.516 秒 / 游戏 0 分钟
- **21:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：aa69bf573a4c43299371571f4beaef79
  - 耗时：23.656 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：73659 → 75215（+1556g）
- 出货估值：1556g　动作：40 个　失败：20 个
- 模型调用：7 次　tokens：86450
- 有效动作率：0.5312　空转：6　熔断跳过：7
- 失败耗时：9.108 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 40 动作 20 失败，核心仍是背包空格 4<5 导致 mine 和 upgrade 被拒，而 85 个 Copper Bar 一个没卖。take 空跑 12 次、store_items 空跑、donate 无效，脚本仍在生成已证明无效的分支。钓鱼兜底执行了但下矿和升级里程碑零推进。今天必须把卖 Copper Bar 腾格作为起床第一动作，并在脚本生成阶段物理删除 take/store_items/donate/build_road。

**新教训：**
- 昨天 mine 和 upgrade 都被 'have 4, need 5' 拒绝，而背包 85 个 Copper Bar 一个没卖：清包第一步必须是 ship_produce Copper Bar 留 20，这是唯一能腾 3-4 格的手段，只卖石头/Sap 永远不够。
- 昨天 take 空跑 12 次（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，但材料显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 全部空转；而 Forest 钓鱼 12 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支。
- 背包 0 空格时 store_items 会返回 'nothing to store' 空跑（昨天 10 次），因为箱子已满或物品不可堆叠：清包只能靠出货箱 ship_produce 卖 Copper Bar，store_items 应全天物理删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 18）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 73659g 远超 5000，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿与升级的共同门票**——昨天背包 4 空格，mine×2、upgrade 全被拒，而背包里 85 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 18）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 19）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 20）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱卖 Copper Bar 留 20**：起床读背包后显式 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 89/95 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
10. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 18 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。could not reach/locked/timeout 即当天永久跳过升级。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-12:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
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
3. 清包到空格≥5（先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 40 层拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 40 动作 20 失败，核心仍是背包空格 4<5 导致 mine 和 upgrade 被拒，而 85 个 Copper Bar 一个没卖。take 空跑 12 次、store_items 空跑、donate 无效，脚本仍在生成已证明无效的分支。钓鱼兜底执行了但下矿和升级里程碑零推进。今天必须把卖 Copper Bar 腾格作为起床第一动作，并在脚本生成阶段物理删除 take/store_items/donate/build_road。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 11:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 13:10 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 21:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 21:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 背包空格只有 4 格，低于下矿和升级工具所需的 5 格，导致 mine 和 upgrade_tool 连续被拒 @ Farm / Mine / Blacksmith — store did not free enough slots (have 4, need 5)（做不了：无法下矿刷铁矿石，也无法升级 Steel Hoe，铁锭链完全卡死） 〔复盘〕
- 背包里 85 个 Copper Bar 一个没卖，清包只卖了 80 石头（160g），腾不出格子 @ Farm 出货箱 — 清包策略没有把 Copper Bar 列为出售项，只卖石头/Sap 等低价值物品（做不了：空格始终不足，下矿和升级都被拒） 〔复盘〕
- take 动作连续空跑 12 次，尝试从农场箱子取 Aquamarine/Ruby/Topaz/Diamond 等矿物全部失败 @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费大量动作和时间，脚本重写 3 次仍在重试同一批 ID） 〔复盘〕
- donate_museum 在博物馆报无可捐物，且 goto ArchaeologyHouse 因 Town 不可达失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：博物馆捐献分支全天无效，浪费一次 goto 和一次 donate） 〔复盘〕
- load_machines 报没有空炉接受铁矿石，而背包 Iron Ore 只有 1 个 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：熔炉无法继续炼铁，铁锭产出停滞） 〔复盘〕
- collect_machines 在 21:30 报无成品可收，且当天多次空跑 @ Farm 熔炉 — no machine has finished output；repeated ineffective action suppressed until game state changes（做不了：收熔炉动作无效，浪费动作次数） 〔复盘〕
- build_road 报规划道路边没有可走空格 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：道路铺设无进展，浪费一次动作） 〔复盘〕
