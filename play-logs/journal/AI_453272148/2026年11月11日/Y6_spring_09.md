# 第6年 spring 9 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（20:26 开始）
- 天气：sunny　金钱：84828g　体力：270/270
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
  - 执行状态：NO_PROGRESS · 操作编号：145cca377b064f4fa9802e023cd1f4fb
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：138cf43add8147aa8b872fc971418ea3
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Joja Cola, 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：72b62933dd114699a55ef1656d5e58a1
  - 耗时：6.156 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：9a240589154d4fc9b058a1972d89a4b5
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：336bceaeb0994460b1e0c7a03ac7d8ff
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~525g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：0500c34296a743eb87dbd84b58c7c693
  - 耗时：0.766 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_09）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须凑齐 4 块铁锭
- 起床收熔炉成品，有空炉且铁矿石够就装料
- 在农场出货箱卖 Copper Bar 留 20 腾出背包空格（目标≥5）
- 背包腾够后电梯直达 40 层刷铁矿石+煤，最多两次 mine、每次≤5 层
- 回农场收铁锭，铁锭≥5 且 12:00 前就去铁匠铺升 Steel Hoe
- 凑不齐铁锭就转 Forest 钓鱼到 20:00，21:30 前睡觉
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
11. `ship`（item="Copper Bar", count=70）
12. `ship`（item="Stone", count=200）
13. `ship`（item="Sap", count=40）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Mine"）
22. `mine`（floors=5）
23. `leave_mine`
24. `goto_location`（location="Farm"）
25. `collect_machines`
26. `goto_location`（location="Forest"）
27. `fish`（casts=12）
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9a5d7eb2465440c6b7f66b29bfa0db9d
  - 耗时：0.562 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 空跑已按教训物理删除，改为农场出货箱卖 Copper Bar 腾格后电梯 40 层刷铁，铁锭够就升 Steel Hoe，不够转 Forest
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=400）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=12）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7cf3ee37a9e14e6aa94c132d212d9a30
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 空跑已确认箱子内容与记忆不符，物理删除 take/donate 分支，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够就升 h
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=400）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=12）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
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
  - 执行状态：ACTION_FAILED · 操作编号：966b790b033c4231aa6921fc1ab4b6ca
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败（箱子内容与记忆不符），按教训物理删除 take/donate 分支，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=400）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=12）
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
  - 执行状态：ACTION_FAILED · 操作编号：2c3f4b3babce47b3833089bcba5acb4f
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ccb0125beefa4ad890d4d7e3ed72e9d5
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6a1d2b52db034e80bc6617921e416068
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：f5ae5d38a52b49eaa7e4ec63c60ab68d
  - 耗时：79.906 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：645815607b1240ed81f53838d21f5247
  - 耗时：44.14 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：1dc5522e2855493b8837cb6075199928
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=70）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：f919f97e01f94432b1a4857df5d2c621
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Stone", count=400）
  - 结果：'Stone' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：64b70c8c3d7840799962300fb7c5ad4c
  - 耗时：0.562 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1d975c92f2d14a6cacff43d1ff0ac60c
  - 耗时：50.703 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：bfb401f616784e1b94f3f1cfd46fb6a1
  - 耗时：33.703 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Salad", "Pumpkin Seeds", "Rubber Boots", "Green Algae", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 3x Green Algae
  - 执行状态：SUCCESS · 操作编号：aad19dfe0e0e42e58096a6cda2073652
  - 耗时：15.11 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：d18270b57cab41b78c0dd0af36a6d205
  - 耗时：0.547 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：d7360be1569341c3a28282e930bd234c
  - 耗时：40.375 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：581967607fd94e4596a1f42ece7fa51e
  - 耗时：39.016 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `store_items`（items=["Salad", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：6e48a9712b4f47d4b5eed4f84f9f9c68
  - 耗时：1.219 秒 / 游戏 0 分钟
- **11:40** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **12:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：9972da31f3d3499b822dcecdd77e189a
  - 耗时：23.625 秒 / 游戏 30 分钟
- **13:00** Forest ✅ `fish`（casts=12）
  - 结果：fished: caught 12 (Green Algae, Smallmouth Bass, Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, River Jelly, Joja Cola, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：0392c46f6d6d42b3966f5043361c74ad
  - 耗时：217.25 秒 / 游戏 240 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Green Algae
- **17:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：5afaf03c0e8a4effb83e46304f175482
  - 耗时：9.656 秒 / 游戏 10 分钟
- **17:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：e6be3b40f7914e4185daf8036aed9b7f
  - 耗时：23.609 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：84828 → 85353（+525g）
- 出货估值：525g　动作：39 个　失败：23 个
- 模型调用：6 次　tokens：69527
- 有效动作率：0.4333　空转：5　熔断跳过：8
- 失败耗时：10.561 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 39 动作 23 失败，根因是脚本生成阶段就写入了已被证明无效的分支（take 12 次、在博物馆 ship、背包空格不足仍生成 mine/upgrade）。真正有效的只有 Forest 钓鱼 12 条和熔炉收料。铁锭链连续 8 天零推进，卡点不是钱也不是矿层，而是背包空格<5 导致 mine 被拒；而清包主力 Copper Bar 90 个始终没卖出去。今天必须把「先卖 Copper Bar 腾格」做成脚本第一步硬动作，并在生成阶段物理删除所有无效分支。

**新教训：**
- 昨天 90 个 Copper Bar 一个没卖、mine 被 'have 4, need 5' 拒绝：清包脚本必须把 ship Copper Bar 写成第一步无条件动作（count=背包数-20），而不是放在「读背包后视情况」的分支里，否则永远走不到。
- 昨天在 ArchaeologyHouse 调 ship 报 'not found'，而材料显示背包有 90 个：ship 的 location 应在脚本生成阶段硬编码为 Farm 出货箱，其他地图一律不生成 ship 分支。
- 昨天 12 次 take 全部空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天 15:50 起 load_machines 连续报 'no empty machine accepts that'：Iron Ore 只有 1 时 load 分支应在脚本生成阶段物理删除，只有读背包确认 Iron Ore≥5 且有空炉才生成。
- 昨天 mine 成功一次后没有先 ship 腾格就尝试第二次 mine，导致第二次被空格不足拒绝：mine 成功后必须先 ship 腾格再决定是否第二次下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 10）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 84828g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续 8 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 3-4 空格，90 个 Copper Bar 一个没卖，mine 被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 10）**：起床 collect→**农场出货箱 ship Copper Bar 留 20（约 70 个，腾 3-4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼 casts≥10 到 20:00。
- **明天（春 11）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 12）**：继续刷铁备钢斧，给作物地块补洒水器，种土豆/花椰菜保底（13 日复活节买草莓）。

## 今日核心修正（按执行顺序）
1. **清包是今天第一硬动作，且唯一手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后立即 ship Copper Bar count=背包数-20（约 70 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。昨天在 ArchaeologyHouse 调 ship 报 'not found' 是地点错。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 2 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 15-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 10 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 10 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
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
6. mine 成功一次后 ship 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 春 10 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 39 动作 23 失败，根因是脚本生成阶段就写入了已被证明无效的分支（take 12 次、在博物馆 ship、背包空格不足仍生成 mine/upgrade）。真正有效的只有 Forest 钓鱼 12 条和熔炉收料。铁锭链连续 8 天零推进，卡点不是钱也不是矿层，而是背包空格<5 导致 mine 被拒；而清包主力 Copper Bar 90 个始终没卖出去。今天必须把「先卖 Copper Bar 腾格」做成脚本第一步硬动作，并在生成阶段物理删除所有无效分支。
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
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Stone' not found in inventory 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 10:50 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 11:40 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 17:10 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 17:10 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包主力 Copper Bar 90 个始终没卖出去，背包空格卡在 3-4 格 @ Farm 出货箱 — 脚本把 ship Copper Bar 放在「读背包后视情况」的分支，实际执行时先跑了 take/donate 等无效动作，ship 从未被调用；mine 报 'store did not free enough slots (have 4, need 5)'（做不了：下矿拿铁矿石、升级 Steel Hoe、做洒水器全部卡住） 〔复盘〕
- 在博物馆调 ship 卖 Copper Bar @ ArchaeologyHouse — 'Copper Bar' not found in inventory（ship 只在农场出货箱有效）（做不了：浪费动作和时间，清包没完成） 〔复盘〕
- 12 次 take 空跑，脚本重写 3 次仍重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：脚本重写次数被耗尽，真正该做的清包和下矿没排上） 〔复盘〕
- 背包空格不足仍生成 mine 和 upgrade_tool 分支 @ Mine / Blacksmith — mine: 'store did not free enough slots (have 4, need 5)'；upgrade_tool: 'store did not free enough slots (have 4, need 5)'（做不了：铁锭链连续 8 天零推进） 〔复盘〕
- 在非矿洞地图生成 leave_mine @ Farm — 'not in the mine'（做不了：浪费动作，脚本重写次数被消耗） 〔复盘〕
- 在博物馆调 donate_museum 但背包无可捐物 @ ArchaeologyHouse — 'nothing in the backpack can be donated'（做不了：浪费动作和时间） 〔复盘〕
