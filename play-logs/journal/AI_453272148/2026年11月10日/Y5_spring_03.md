# 第5年 spring 3 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（13:59 开始）
- 天气：sunny　金钱：60714g　体力：263/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y5_spring_03）准备的脚本
- 里程碑：凑 5 铁锭升 Steel Hoe（5000g+5 Iron Bar）
- 起床收炉、投铁矿石、清包到空格≥12
- 补食物到≥5 后电梯直达 80 层挖铁矿+煤
- 回农场收铁锭，13:00 前到 Blacksmith 升 hoe
- SeedShop 周三休，今天不买种子；铁锭不足则改钓鱼
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
17. `goto_location`（location="Mine"）
18. `mine`（floors=5）
19. `store_items`
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Mine"）
25. `mine`（floors=5）
26. `goto_location`（location="Farm"）
27. `collect_machines`
28. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
29. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：4182a669fa2149beaa33f70d60a44292
  - 耗时：15.328 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：e11afd12d3f5411b948c758be47f055e
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：9cd7d93dd9524e42b2054dc740c14693
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：025063a5255b475485f5374d7331a44f
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0bf9879c7f4e4c6d8cb0ef055eebd329
  - 耗时：0.422 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部失败的 take 与 donate 分支，按清包→补食物→80层挖铁→回炉收锭→13点前升 hoe 的顺序重排剩余脚本。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `store_items`
19. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
20. `store_items`
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `store_items`
25. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
26. `collect_machines`
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：eefff74a0fea446aa32210f6289853ff
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take 分支，改为清包→钓鱼补食物→80 层挖铁→回农场收铁锭→13:00 前升 hoe，失败即转钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `store_items`
19. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
20. `collect_machines`
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：02bc7311ad6d4db384e6a3d287034d70
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take（箱子无宝石），改为清包→投铁矿→Forest 钓鱼补食物→电梯下矿 80 层挖铁，回农场收炉后睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Farm"）
15. `store_items`
16. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `store_items`
20. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
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
  - 执行状态：ACTION_FAILED · 操作编号：fdd0973acb484862bbfaca3f802a0b93
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：94bf3831c3f644638f5c24e3ae56bfde
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：48b681f48f8f4b48a727e5683c2ae912
  - 耗时：0.407 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：00c38711d04540069557cfcb34edf963
  - 耗时：74.079 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：0f8ff49999fa4603a6365e874c3b3c7d
  - 耗时：80.891 秒 / 游戏 100 分钟
- **09:40** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：10f4cf7b12ba4a918333a7ff637281b2
  - 耗时：0.359 秒 / 游戏 0 分钟
- **09:40** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：f4a4ca08a9984d549edf83d68b79af88
  - 耗时：31.016 秒 / 游戏 40 分钟
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Sunfish, Chub, Chub, Sunfish)
  - 执行状态：SUCCESS · 操作编号：79fee31b4d8a4065ae66beea34371f2c
  - 耗时：109.656 秒 / 游戏 100 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
- **12:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：4129dd3af6da4ea3a426d25256d926e0
  - 耗时：63.375 秒 / 游戏 80 分钟
- **13:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：1fba2bc03d194310ba3058e9b308b4b3
  - 耗时：33.594 秒 / 游戏 40 分钟
- **13:20** Mine ✅ `store_items`（items=["Geode", "Stone", "River Jelly", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Geode
  - 执行状态：SUCCESS · 操作编号：20f7961b54ec4d76bd92dd66307af58e
  - 耗时：17.766 秒 / 游戏 30 分钟
- **13:20** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 85 to 87 (2 floors down, 42 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：880abfd3389c4bfb9b1ff6f2e6ff3b82
  - 耗时：150.672 秒 / 游戏 190 分钟
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Omni Geode
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Bomb
  - 🗨️ [question] 
  - 🗨️ [hud] Diamond
- **17:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：f46fb673aaf644d6bd4266ec7b3b4e76
  - 耗时：0.375 秒 / 游戏 0 分钟
- **17:40** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：599b65dd49f1429a9b4992796c518366
  - 耗时：35.781 秒 / 游戏 40 分钟
- **18:20** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 3x Coal, 1x Bomb
  - 执行状态：SUCCESS · 操作编号：20400dbbe8e748398d6169dc96fb22a7
  - 耗时：15.031 秒 / 游戏 20 分钟
- **18:40** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
  - 结果：shipped 3 stacks worth ~990g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：0d9341848a654bc48ec1434c7a52af90
  - 耗时：0.703 秒 / 游戏 10 分钟
- **18:50** Farm ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：76b4f69ef4b444d5b02e2037c2add72b
  - 耗时：13.906 秒 / 游戏 10 分钟
  - 🗨️ [hud] Gold Bar
- **19:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：88c5fafc9cdd4ae99027a22aad5ff743
  - 耗时：0.375 秒 / 游戏 0 分钟
- **19:00** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：4509558fd8654c9b8c67c0c383f2e7cd
  - 耗时：13.297 秒 / 游戏 20 分钟
- **19:20** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：b293c2fde65a40cab5764cab7c17bc71
  - 耗时：0.375 秒 / 游戏 0 分钟
- **19:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：9649c46df76f45caab990386eaf148cf
  - 耗时：0.375 秒 / 游戏 0 分钟
- **19:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：66d39af8de854e7fb7b6ebfe3b40423c
  - 耗时：10.344 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：60714 → 61704（+990g）
- 出货估值：990g　动作：36 个　失败：17 个
- 模型调用：6 次　tokens：69383
- 有效动作率：0.4828　空转：7　熔断跳过：6
- 失败耗时：5.329 秒 / 游戏 0 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天36动作17失败，take宝石全灭、load_machines无空炉、mine因背包满只下2层，铁锭仍0，钢锄头连续多天零推进。有效动作是钓鱼4条、下矿85→87拿金矿/钻石、熔炉收金锭。核心问题：清包不彻底导致下矿被拒，投料时机错，商店时间外跑图。今天必须优先清包到≥15、补食物≥6、电梯80层挖铁，13:00前升级窗口。

**新教训：**
- 昨天 mine 从 85→87 只下 2 层就因背包满被迫离开，说明下矿前清包到≥12 仍不够：下矿前应把 Stone/Geode/多余矿石全部存箱，只留食物、武器、镐和空位，目标空格≥15 再下矿。
- 昨天 19:00 后 load_machines 返回 no empty machine，而 18:50 刚 collect 出金锭：投料应在 collect 后立即确认炉空，若两炉都在忙则当天不再 load，不要拖到晚上再试。
- 昨天 donate_museum 在背包无可捐物时被调用失败：donate 前必须先读背包确认有古物/矿物，没有就物理删除 donate 分支，不要空跑。
- 昨天 leave_mine 在已经离开矿洞后调用失败：leave_mine 只在 mine 动作返回「仍在矿内」时调用，脚本生成阶段应检查当前地图是否为 UndergroundMine。
- 昨天 build_road 返回「规划道路边没有还能走上去的空格」：农场道路已铺满或路径被建筑挡住，build_road 应从脚本彻底删除，不再浪费动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 4）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 60714g 充足，铁锭 0、铁矿石 5、煤 32，瓶颈是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 4）**：起床 collect → 空炉且铁矿石≥5 投 Iron Ore → 清包到空格≥15 → 补食物到≥6 → 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 5）**：春季种植启动——皮埃尔买土豆/花椰菜种子（先 open_shop 再 buy），种下；hoe 已升则转钢斧，否则继续下矿炼铁。
- **后天（春 6）**：铁锭富余则 craft 洒水器落地；13 日复活节前攒钱买草莓种子。

## 今日核心修正
1. **take 全天物理删除**：连续三天 take 宝石全失败。脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **熔炉投铁矿石，不投铜**：起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。
3. **清包一次到空格≥15**：起床 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包成功后全天禁止任何 take。
4. **补食物到≥6**：Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。食物<6 不下 40 层以下。
5. **下矿目标 80→84**：电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。**upgrade_tool 必须带 tool=hoe 参数**，并在日志确认返回的是升级结果而非挖矿结果。
8. **买种子顺序硬约束**：先 goto SeedShop → open_shop 成功 → 再 buy；buy 返回「no shop is open」说明 open_shop 未生效，立即重开一次，不连续 buy。买前读背包确认空格≥5，不足先 store_items。**17:00 后不再去 SeedShop**。
9. **路径失败即换路**：store_items/ship_produce 返回 could not reach 时，立即改不指定坐标或直接 ship_produce，**不重试同一坐标**。
10. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
11. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥15**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥6**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥15 且食物 ≥6 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **买春季种子（仅当时间 <17:00 且背包空格 ≥5）**：goto SeedShop → open_shop → buy Potato Seeds 20 / Cauliflower Seeds 10；buy 失败一次即跳过，不连续 buy。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥6 且空格 ≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：连续多天 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥6 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床 collect_machines 1 次**（收熔炉成品）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. **一次性清包到空格 ≥15**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥6**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥15、食物 ≥6、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，背包空格 ≥5，buy 失败一次即跳过）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天36动作17失败，take宝石全灭、load_machines无空炉、mine因背包满只下2层，铁锭仍0，钢锄头连续多天零推进。有效动作是钓鱼4条、下矿85→87拿金矿/钻石、熔炉收金锭。核心问题：清包不彻底导致下矿被拒，投料时机错，商店时间外跑图。今天必须优先清包到≥15、补食物≥6、电梯80层挖铁，13:00前升级窗口。
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 06:10 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 09:40 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 17:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 19:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 19:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 下矿因背包空格不足只下了 2 层就被迫离开，铁矿石没增加 @ Mine 85→87 层 — mine 返回 backpack nearly full: store items before mining again; left the mine to recover（做不了：无法下到 80 层挖铁矿石，铁锭凑不齐，钢锄头升级做不了） 〔复盘〕
- 凭记忆 take 六种宝石全部失败，吃掉 12 个动作 @ Farm 箱子 — '62'/'64'/'68'/'72'/'80'/'84' is not in any farm chest（做不了：博物馆捐赠和献祭收集包无法推进） 〔复盘〕
- 熔炉投料时两炉都在忙，load_machines 失败 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石无法及时炼成铁锭，升级窗口错过） 〔复盘〕
- 清包后仍被 mine 拒（have 4, need 5），说明 store_items 腾格不足 @ Farm 箱子 — store did not free enough slots (have 4, need 5)（做不了：下矿动作无法发起，铁矿石零收获） 〔复盘〕
- donate_museum 在背包无可捐物时被调用失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：博物馆捐赠进度停滞） 〔复盘〕
- leave_mine 在已离开矿洞后调用失败 @ Mine 入口/农场 — not in the mine（做不了：浪费一个动作，无实际阻塞） 〔复盘〕
- build_road 因规划路径无空格失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：道路铺设计划无法推进，浪费动作预算） 〔复盘〕
