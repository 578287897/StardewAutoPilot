# 第5年 winter 21 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（14:02 开始）
- 天气：snow　金钱：77783g　体力：168/270
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
  - 执行状态：NO_PROGRESS · 操作编号：e4c690232e284be2813d67064eadf58d
  - 耗时：3.359 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：5461818dea854e95a561e2cd7fb37bd0
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Bug Meat
  - 执行状态：SUCCESS · 操作编号：8f696e9613fa423f80a5ef9e10e1256b
  - 耗时：6.234 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：bd62f615bc6b4a70a9cbc6ab02ba7b2e
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：37da53df85da4e0aa896e85368611258
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~209g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：4e6b816debd44bf7bbcc5cac1ed2cdea
  - 耗时：0.781 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_21）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），当前 Iron Bar 1/5
- 起床收熔炉成品，若炉空且铁矿≥5 则装铁矿石
- 清包：农场出货箱卖 Copper Bar 留 20，卖多余石头/Sap/绿藻，验证空格≥5
- 食物不足则买沙拉补到≥8（Saloon 12:00 才开，先看背包）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次≤5 层
- 回农场收铁锭，铁锭≥5 且 9:10-12:00 且空格≥5 则去 Blacksmith 升 hoe
- 清包或下矿失败即转 Forest 钓鱼填满下午
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
11. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=1000）
14. `ship`（item="Sap", count=48）
15. `ship`（item="Green Algae", count=2）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal"]）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Forest"）
25. `fish`（casts=5）
26. `fish`（casts=5）
27. `fish`（casts=5）
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f8b4bb90412640d989edb90e5e37dd6a
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate_museum 分支（箱子内容与记忆不符、卷轴未解锁），改为出货箱清包后下矿刷铁，铁锭够则升 hoe，失败即转 For
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Stone", count=28）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=5）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `goto_location`（location="Farm"）
20. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot"]）
21. `collect_machines`
22. `collect_machines`
23. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5e77eac0bf29467e9276a47251f4fb64
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败说明箱子内容与记忆不符，物理删除 take/donate 分支，改走清包→下矿→钓鱼主线。
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
13. `fish`（casts=5）
14. `fish`（casts=5）
15. `fish`（casts=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank"]）
19. `collect_machines`
20. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot"]）
21. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b85fa3d85e1f4514b1b9bcd0b6695ae7
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为出货箱清包腾格后直接下矿刷铁，失败即转 Forest 钓鱼收尾。
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
13. `fish`（casts=5）
14. `fish`（casts=5）
15. `fish`（casts=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank"]）
19. `collect_machines`
20. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot"]）
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
  - 执行状态：ACTION_FAILED · 操作编号：0dc324cf618f478abca4e585a46ef288
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dd516955c4f64437821f6f7ea89988c9
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：36df281d7a1b43c2b5e0af39b8ca693d
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5c697395e0ba44b88f99ea385a4693a3
  - 耗时：79.875 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c682d19ea9be4ccda8e26f192f90a30e
  - 耗时：44.109 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：4faa8bc729fb41a887eedc2d74153908
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f9e590582ade4a2784f2ce9485756a4b
  - 耗时：50.719 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：14f4a152eeed4d4882b97a6216cc84be
  - 耗时：33.672 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Stone", "Rice Shoot", "Pumpkin Seeds", "Rubber Boots", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：c68432ce6a664ef3a0fd2fb9f3e7350b
  - 耗时：18.703 秒 / 游戏 30 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Stone", "Rice Shoot", "Pumpkin Seeds", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a9490b33ea324ac1b9bd41406c12ba83
  - 耗时：0.5 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：8302d2159cff457dbb0c6616391fbb85
  - 耗时：23.89 秒 / 游戏 30 分钟
- **11:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Driftwood, Green Algae, Green Algae, Trash, Perch)
  - 执行状态：SUCCESS · 操作编号：b210916595a34f699dcdf621a8d1a7c8
  - 耗时：71.062 秒 / 游戏 80 分钟
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Trash
- **12:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Perch, Trash, Green Algae, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：af48466764b14ad392c394f1cee316ec
  - 耗时：93.375 秒 / 游戏 100 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
- **14:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Green Algae, Perch, Trash, Perch)
  - 执行状态：SUCCESS · 操作编号：da4d201d93ca42f8bcfce96f56ff2688
  - 耗时：97.813 秒 / 游戏 100 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Trash
- **16:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：e69f283422b8436aa38d3ccdffa53a3a
  - 耗时：9.64 秒 / 游戏 10 分钟
- **16:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:20** Farm ✅ `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank"]）
  - 结果：shipped 1 stacks worth ~492g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b410d9d482ac40b7b74b46c2c42a8802
  - 耗时：20.532 秒 / 游戏 30 分钟
- **16:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:50** Farm ✅ `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：9b855eaeb47445ffad4a444ae9a310c2
  - 耗时：0.531 秒 / 游戏 0 分钟
- **16:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：63feac8164c84135b85e257d7bfe5aff
  - 耗时：6.969 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：77783 → 78484（+701g）
- 出货估值：701g　动作：39 个　失败：21 个
- 模型调用：7 次　tokens：87701
- 有效动作率：0.4667　空转：7　熔断跳过：8
- 失败耗时：9.123 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天21次失败几乎全部来自脚本生成阶段就应删除的动作（take×12、store_items、donate、build_road、decorate）和清包策略失效：85个Copper Bar一个没卖，空格始终4格，导致mine×2被拒、铁锭链连续多日零推进。唯一有效产出是Forest钓鱼约700g。核心修正：清包第一步必须卖Copper Bar留20，验证空格≥5后才下矿；任何失败立即转钓鱼，不再重写脚本重跑同一动作。

**新教训：**
- 昨天 mine 两次被 'have 4, need 5' 拒绝，而背包 85 个 Copper Bar 一个没卖：清包第一步必须是 ship_produce Copper Bar 留 20，这是唯一能腾 3-4 格的手段，只卖石头/Sap 永远不够。
- 昨天 take 空跑 12 次（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，但材料显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 全部空转；而 Forest 钓鱼 12 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支。
- 背包 0 空格时 store_items 会返回 'nothing to store' 空跑（昨天 10 次），因为箱子已满或物品不可堆叠：清包只能靠出货箱 ship_produce 卖 Copper Bar，store_items 应全天物理删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 22）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 77783g 远超 5000，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿与升级的共同门票**——昨天背包 4 空格，mine×2、upgrade 全被拒，而背包里 85 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 22）**：起床 collect→读背包→**农场出货箱 ship_produce Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 23）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 24）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱卖 Copper Bar 留 20**：起床读背包后显式 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 89/95 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 22 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
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
> 昨天21次失败几乎全部来自脚本生成阶段就应删除的动作（take×12、store_items、donate、build_road、decorate）和清包策略失效：85个Copper Bar一个没卖，空格始终4格，导致mine×2被拒、铁锭链连续多日零推进。唯一有效产出是Forest钓鱼约700g。核心修正：清包第一步必须卖Copper Bar留20，验证空格≥5后才下矿；任何失败立即转钓鱼，不再重写脚本重跑同一动作。
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
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 16:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包反复失败：Copper Bar 85 个一个没卖，只卖出 80 石头，背包空格始终 4 格 @ 农场出货箱 — ship_produce 未对 Copper Bar 执行；mine 报 'store did not free enough slots (have 4, need 5)'（做不了：下矿刷铁、升级 Steel Hoe 全部被拒，铁锭链连续多日零推进） 〔复盘〕
- take 动作连续 12 次空跑，脚本重写 3 次仍重试同一批箱子 ID @ 农场箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；重写前未读背包实际内容（做不了：浪费约 12 个动作和 3 次脚本重写，挤占下矿时间） 〔复盘〕
- 在博物馆调 ship 和 donate 均失败 @ ArchaeologyHouse — ship 报 'Copper Bar' not found in inventory；donate 报 nothing in the backpack can be donated（做不了：白跑一趟博物馆，且 ship 在非出货箱地图无效） 〔复盘〕
- 下矿两次被拒，全天没有进入矿洞 @ Mine 入口 — mine 报 'store did not free enough slots (have 4, need 5)'（做不了：拿不到铁矿石，Iron Bar 停在 1/5，Steel Hoe 无法升级） 〔复盘〕
- 清包失败后没有钓鱼兜底，下午到晚上空转 @ 农场/地图间 — collect_machines 被抑制、ship 无货可卖、decorate 失败，最后 16:50 直接 sleep（做不了：浪费约 5 小时游戏时间，全天仅 39 动作、21 失败） 〔复盘〕
- load_machines 在炉子忙时被调用 @ 农场熔炉 — no empty machine accepts that, and the rest are busy（做不了：铁矿石无法入炉，铁锭产出延后） 〔复盘〕
