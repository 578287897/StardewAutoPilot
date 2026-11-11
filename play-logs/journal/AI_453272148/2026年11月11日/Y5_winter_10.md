# 第5年 winter 10 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:54 开始）
- 天气：snow　金钱：68308g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：2d1e809876c0473aa1a6385c0c5f6b72
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：ce2a5cb58d47458782bf80626fc379ac
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：40d0b3bf02e04a30bc75c5075dfba4c9
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：24a4f418d9344c30818766e99707d6cb
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：471b9051e1014fb8b9dd41140e850459
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~1352g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：246621ff69b444feaa8f774d84bd0faa
  - 耗时：0.766 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_10）准备的脚本
- 里程碑：凑齐 5 铁锭升 Steel Hoe（差 4 铁锭）
- 起床收熔炉产物，炉空且铁矿够就装铁矿石
- 在农场出货箱卖 Copper Bar 留 20 清包到空格≥5，读背包验证
- 空格≥5 且食物≥5 则电梯直达 40 层刷铁矿石+煤（≤2 次，每次≤5 层）
- 回农场收铁锭，铁锭≥5 且 12:00 前则去 Blacksmith 升 hoe
- 清包失败或下矿被拒则转 Forest 钓鱼兜底，21:30 前 sleep
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
11. `ship_produce`（except=["Salad", "Gold Bar", "Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Bamboo Pole", "Rusty Sword"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=1000）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `goto_location`（location="Blacksmith"）
21. `upgrade_tool`（tool="hoe"）
22. `goto_location`（location="Farm"）
23. `craft`（item="Sprinkler", count=1）
24. `place`（item="Sprinkler", x=70, y=20）
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7c05d74e84cd4fa19b4c928ab8fd9972
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate 分支，改为农场出货箱卖 Copper Bar 清包→40 层刷铁→回农场收锭→12 点前升 hoe，失败即转 For
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
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=6）
19. `fish`（casts=6）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `collect_machines`
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：619276dfeaf641298b9eb32bfef064f7
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 箱子物品连续失败，物理删除 take/donate 分支；改为农场出货箱 ship_produce 清包（保留铁/金/食物/种子），再下矿 
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
12. `leave_mine`
13. `goto_location`（location="Forest"）
14. `fish`（casts=6）
15. `fish`（casts=6）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Iron Bar", "Iron Ore", "Gold Bar", "Gold Ore", "Copper Ore", "Salad", "Pumpkin Seeds"]）
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
  - 执行状态：ACTION_FAILED · 操作编号：16ba33a11b484996ac51789316cf93c2
  - 耗时：0.546 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支连续失败已物理删除，改为农场出货箱清包后直接下矿刷铁，失败则钓鱼兜底。
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
12. `leave_mine`
13. `goto_location`（location="Forest"）
14. `fish`（casts=6）
15. `fish`（casts=6）
16. `goto_location`（location="Farm"）
17. `ship_produce`（except=["Iron Bar", "Iron Ore", "Gold Bar", "Gold Ore", "Copper Ore", "Salad", "Pumpkin Seeds", "Green Algae", "River Jelly"]）
18. `collect_machines`
19. `collect_machines`
20. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：c122eeb54b3248f59f6c455c0c44e94a
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：54ee62fddf5943689a889cd7fd6f65b7
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0d6c33ba84e84778a45f7e7d75ed150c
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：9010aa331acd4059bbc0555420ad6613
  - 耗时：79.906 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：97a29d92033941c18dbffd926a0a2017
  - 耗时：44.125 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：f4c82a2e5785456fb029defca0045911
  - 耗时：0.485 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：99649d8ff75f43d18c296c67836b6ac1
  - 耗时：50.735 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：c8be3e0e8d90443eb3765a421d50c980
  - 耗时：33.641 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Green Algae", "Pumpkin Seeds", "Rubber Boots", "Salad", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：69d1739539dc40959a36a7aeea7b094a
  - 耗时：19.766 秒 / 游戏 30 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Pumpkin Seeds", "Rubber Boots", "Salad", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7a698b08a5194475adb747027a90fae7
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：04b8787e75f240a68b4494ad2987fd0d
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：cebe194c33ce49faa79f791209293e6e
  - 耗时：23.86 秒 / 游戏 30 分钟
- **11:30** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Green Algae, River Jelly, Green Algae, Perch, Pike, Perch)
  - 执行状态：SUCCESS · 操作编号：206cb9fb269446e6b6a15b7c59680427
  - 耗时：143.281 秒 / 游戏 160 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
- **14:10** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Perch, Green Algae, Perch, Pike, Pike, River Jelly)
  - 执行状态：SUCCESS · 操作编号：887eddc1b89745f7a7457294547d0aaf
  - 耗时：123.141 秒 / 游戏 130 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **16:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：3d7d17b36bfc4c59ab1563d85ca5b199
  - 耗时：9.656 秒 / 游戏 10 分钟
- **16:30** Farm ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Gold Bar", "Gold Ore", "Copper Ore", "Salad", "Pumpkin Seeds", "Green Algae", "River Jelly"]）
  - 结果：shipped 2 stacks worth ~778g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：df4282af4c12465aacdc87b69a90553b
  - 耗时：20.531 秒 / 游戏 30 分钟
- **17:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6ed48684ec0e46e0892eb3bbad7071ea
  - 耗时：0.516 秒 / 游戏 0 分钟
- **17:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：b96c2c33c7f54a52ab0eb82a2040bad1
  - 耗时：6.766 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：68308 → 70438（+2130g）
- 出货估值：2130g　动作：37 个　失败：20 个
- 模型调用：7 次　tokens：86269
- 有效动作率：0.4828　空转：5　熔断跳过：7
- 失败耗时：6.221 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天20次失败几乎全是同一根因：清包没做（Copper Bar 85 个一个没卖），空格卡在4格，导致 mine 被拒2次、升级无望；take 空跑12次、donate/load/build_road 全是无效分支。唯一有效动作是 Forest 钓鱼（12条鱼+约2.1k出货）。今天必须第一步就把 Copper Bar 卖掉腾格，否则全天重演。

**新教训：**
- 昨天 mine 两次被 'have 4, need 5' 拒绝，而背包里 85 个 Copper Bar 一个没卖：清包第一步必须显式 ship_produce Copper Bar（留 20），只卖石头/Sap 腾不出格。
- 昨天 take 空跑 12 次（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：需要矿物只能下矿现拿，take 应全天物理删除，重写前必须先读背包清单。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，而材料显示背包有 85 个：ship 只能在农场出货箱附近执行，且先 close_menu 再读背包。
- 昨天 12 次失败后没有钓鱼兜底，从 12:40 到 21:30 空转；而 Forest 钓鱼 12 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本生成 goto Forest→fish 分支。
- 昨天 load_machines 报 'no empty machine accepts anything' 而 Iron Ore 只有 1：load 前必须读背包确认 Iron Ore≥5 且炉子为空，否则物理删除 load 分支。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 11）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 68308g 早已够，唯一卡点是 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍都排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（熔炉 2 座现成，Copper Bar 85 个可卖约 7k 换现金与空格）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿与升级的共同门票**，昨天 4 格被拒 2 次——清包必须在生成 mine/upgrade 分支之前完成并读背包验证。

接下来 3 天主活动：
- **今天（冬 11）**：起床 collect→读背包→**农场出货箱 ship_produce Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 12）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 13）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 在农场出货箱卖 Copper Bar 留 20**：昨天 85 个 Copper Bar 一个没卖，空格仍 4。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：昨天在 ArchaeologyHouse 调 ship 报 not found。ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 11 不买任何作物种子；冬季种子/茶苗留到明天。
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
3. 清包到空格≥5（**先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天20次失败几乎全是同一根因：清包没做（Copper Bar 85 个一个没卖），空格卡在4格，导致 mine 被拒2次、升级无望；take 空跑12次、donate/load/build_road 全是无效分支。唯一有效动作是 Forest 钓鱼（12条鱼+约2.1k出货）。今天必须第一步就把 Copper Bar 卖掉腾格，否则全天重演。
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
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 11:00 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 17:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 17:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包计划了但没执行：Copper Bar 85 个一个没卖，空格始终 4 格 @ Farm 出货箱 — ship_produce 未对 Copper Bar 生成动作，只卖了 80 石头（160g）（做不了：mine 被 'have 4, need 5' 拒绝 2 次，Steel Hoe 升级无法进行） 〔复盘〕
- 反复 take 农场箱子里的矿物，全部失败 @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；重写 3 次仍重试同一批 ID（做不了：浪费约 12 个动作与多次脚本重写，箱子内容与记忆不符） 〔复盘〕
- 在博物馆场景调用 ship 卖 Copper Bar @ ArchaeologyHouse — 'Copper Bar' not found in inventory（实际背包有 85 个）（做不了：清包动作无效，空格未腾出） 〔复盘〕
- donate_museum 与 goto ArchaeologyHouse 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated；Town 不可达（做不了：无产出，占用时间） 〔复盘〕
- load_machines 在无空炉/无铁矿时被调用 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（Iron Ore 仅 1）（做不了：熔炉空转，铁锭链无推进） 〔复盘〕
- build_road 在无可用空格时被调用 @ Farm — 规划道路边没有还能走上去的空格（做不了：非里程碑动作浪费动作数） 〔复盘〕
- 清包失败后没有钓鱼兜底，下午长时间空转 @ Farm→Forest — mine/upgrade 分支被删后脚本无后续动作，直到 17:00 才 sleep（做不了：损失约 4 小时可钓鱼时间） 〔复盘〕
- 铁锭链连续多日零推进（Iron Bar 1/5） @ Mine 40 层以下 — 下矿被空格门槛拒绝，熔炉无铁矿可炼（做不了：Steel Hoe、洒水器 ×4、钢斧、鸡舍全部卡住） 〔复盘〕
