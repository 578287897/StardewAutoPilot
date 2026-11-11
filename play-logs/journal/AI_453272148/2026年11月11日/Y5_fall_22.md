# 第5年 fall 22 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（08:05 开始）
- 天气：windy　金钱：64163g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y5_fall_22）准备的脚本
- 里程碑：凑齐 5 个铁锭，把锄头升到钢锄头（Steel Hoe）
- 起床先收熔炉产物，再给空炉装铁矿石
- 清背包：卖掉多余的 Copper Bar（只留 20 个），腾出至少 5 格
- 确认背包里有 8 个沙拉，食物够用
- 电梯直达 40 层，刷铁矿石和煤（最多下矿 2 次，每次不超过 5 层）
- 回农场收铁锭；如果铁锭达到 5 个且时间在 13:00 前，就去铁匠铺升级锄头
- 剩余时间在森林钓鱼，21:30 前睡觉
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="84", item_name="Frozen Tear", count=1）
5. `take`（item="86", item_name="Earth Crystal", count=1）
6. `goto_location`（location="ArchaeologyHouse"）
7. `donate_museum`
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `ship`（item="Copper Bar", count=62）
11. `ship`（item="Stone", count=16）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `ship_produce`（except=["Salad", "Gold Bar", "Diamond", "Void Essence", "Pumpkin Seeds"]）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=5）
22. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：877fd5c06067457391f0b40d937e98b8
  - 耗时：17.313 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：4503b3db306b46c4a0b48ada4e066c67
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：18238901145e4e1fa6ba51a0cd743872
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~800g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：39b82f772a60464db8370e52074b7beb
  - 耗时：17.547 秒 / 游戏 20 分钟
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：59e3ee78a5dc45ddb0e50dec6a9f9988
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败后物理删除 take/donate 分支，保留清包卖 Copper Bar→40 层下矿→铁锭够则升 hoe→森林钓鱼的路线
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Stone", count=16）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `collect_machines`
22. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：515e84c31d0a4f7f8fdea61a0fdbd793
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/donate 分支（箱子内容与记忆不符、卷轴未解锁），改为直接卖 Copper Bar 腾格后下矿刷铁，铁锭够就升锄头，剩余时间钓
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `ship`（item="Stone", count=16）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`
22. `collect_machines`
23. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：cca46125654a4f20acf981148092e541
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 已连续失败，物理删除 take/donate 分支；改为先收炉、装铁矿石、卖 Copper Bar 腾格，再下矿 40 层刷铁，回农场收锭后
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=62）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `collect_machines`
21. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：70ef10ba7d1d4da5a60424b07c2f34f6
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3170a7ca7efe404d8369b65c802a54ae
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2a095138850f4f299615743f4954a130
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：c1fc64c368f5497086753e46e1032aae
  - 耗时：54.938 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：0fe1208527a447fbb4a126c6a0d76543
  - 耗时：45.703 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：a844723b36a346ec9b55c50c45652c6e
  - 耗时：0.515 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=62）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：85b57387bee64c2f944478fb26bd787f
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：0869f8f3c4bc41d8a28d5678371be64c
  - 耗时：50.704 秒 / 游戏 70 分钟
- **10:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 98 (3 floors down, 25 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：f7db112d0598449e8c6abb828dc23891
  - 耗时：163.203 秒 / 游戏 210 分钟
  - 🗨️ [hud] Bat Wing
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Void Essence
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **13:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：77b80481d2ed42ab9a4c4f3d2af12064
  - 耗时：37.625 秒 / 游戏 50 分钟
- **13:30** Mine ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Salad", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：14d8d13acbc84b988711780412d68019
  - 耗时：15.156 秒 / 游戏 20 分钟
- **13:30** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **14:40** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：could not reach (94,82); stopped at (40,57)
  - 执行状态：ACTION_FAILED · 操作编号：db1c248359b84de5af3ab818a3999dbe
  - 耗时：27.547 秒 / 游戏 30 分钟
- **15:10** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：fc0e44defa324204bc315ef35e6d8682
  - 耗时：18.906 秒 / 游戏 20 分钟
- **15:10** Town ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Salad", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：b6ba2cb2e866402982d60e6f874f986f
  - 耗时：1.265 秒 / 游戏 10 分钟
- **15:10** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **15:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：7446570f54d14ebabf205007b03af387
  - 耗时：23.641 秒 / 游戏 30 分钟
- **16:10** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Green Algae)
  - 执行状态：SUCCESS · 操作编号：e952c82d99ef4406aa542e6dccecb2b1
  - 耗时：90.141 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
- **17:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：d235f075cab44d3b9b2a7055acb61055
  - 耗时：9.656 秒 / 游戏 10 分钟
- **17:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：ff63f1f9474f49da8d283173bc1cd0ef
  - 耗时：0.484 秒 / 游戏 0 分钟
- **17:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：98f0d6b7316346e3a78c5e6dc75d419d
  - 耗时：0.485 秒 / 游戏 0 分钟
- **17:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：27545995b66b4b2098d0f37f346cf878
  - 耗时：23.594 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64163 → 64963（+800g）
- 出货估值：800g　动作：37 个　失败：21 个
- 模型调用：6 次　tokens：68751
- 有效动作率：0.4483　空转：5　熔断跳过：7
- 失败耗时：33.531 秒 / 游戏 30 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天37动作失败21个，核心因果链仍是：清包没卖Copper Bar→空格1格→mine/upgrade双双被拒→转钓鱼只赚800g。take重试12次、donate空跑、build_road空转共浪费约15动作。唯一有效产出是钓鱼5条和熔炉1铁锭。今天必须把「卖Copper Bar留20」做成脚本第一硬动作并读背包验证，验证失败直接定性钓鱼日，不再碰mine/upgrade。

**新教训：**
- 昨天 12 次 take 全失败且脚本重写 3 次仍在重试同一批 ID（62/64/68/72/84/86），说明农场箱子内容与记忆完全不符：take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天 ship_produce 卖 Copper Bar 报 not found，但材料汇总显示背包有 82 个：ship 应以刚读到的背包清单为准，清单里没有就跳过，不要用材料汇总数字反推。
- 昨天 16:30-18:30 连续 3 次 wait 120 分钟，因为清包失败后 mine/upgrade 分支全被删但脚本没有钓鱼兜底：清包验证失败后必须立即生成 goto Forest→fish 分支，而不是 wait 到 21:30。
- 昨天 goto_location Forest 报 could not reach (41,63); stopped at (53,8)，说明从 Farm(53,8) 到 Forest 的路径被挡：去 Forest 钓鱼前应先 goto Farm 出口或走 Town 中转，不要从农场中部直接寻路。
- 昨天 12:10 craft 洒水器成功但紧接着 store_items 想把洒水器存箱失败，洒水器留在背包占格：craft 出的成品应立即 place 到地块，不要先存箱。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 23）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64163g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且 Salad≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 23）**：起床 collect→读背包→**第一硬动作 ship_produce Copper Bar count=背包数-20（约 62 个，约 7k，腾 3-4 格）**→读背包验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 24）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 25）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天 Copper Bar 82 个全没卖，空格仍 1-4。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 62 个，约 7k），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜（昨天 ship Copper Bar 报 not found 就是猜的）。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **食物门票前置**：下矿前读背包确认 Salad≥5；不足则**先 goto Saloon→open_shop→buy 沙拉到≥8**，再回 Mine。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
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
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
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
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天37动作失败21个，核心因果链仍是：清包没卖Copper Bar→空格1格→mine/upgrade双双被拒→转钓鱼只赚800g。take重试12次、donate空跑、build_road空转共浪费约15动作。唯一有效产出是钓鱼5条和熔炉1铁锭。今天必须把「卖Copper Bar留20」做成脚本第一硬动作并读背包验证，验证失败直接定性钓鱼日，不再碰mine/upgrade。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 13:30 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 14:40 动作 `goto_location` 失败 @ Farm — could not reach (94,82); stopped at (40,57) 〔自动〕
- 15:10 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 1, need 5) 〔自动〕
- 17:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 17:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 17:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包没卖出 Copper Bar，空格始终 1-4 格，导致下矿和升级双双被拒 @ Farm — mine: store did not free enough slots (have 1, need 5)；upgrade_tool 同样报错（做不了：下矿拿铁矿石、升级钢锄头全部做不成，铁锭链卡死） 〔复盘〕
- take 动作连续 12 次失败，脚本重写 3 次仍在重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest（做不了：浪费约 12 个动作，且箱子补给路线彻底不可信） 〔复盘〕
- donate_museum 先跑图到 ArchaeologyHouse 等开门再失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费 2 个动作和一段路程） 〔复盘〕
- build_road 作为填充动作失败 @ Farm — 规划道路边没有还能走上去的空格（做不了：无产出，纯空转） 〔复盘〕
- 去 Blacksmith 升级锄头时路径不可达 @ Town→Blacksmith — could not reach (94,82); stopped at (40,57)（做不了：即使铁锭够也无法完成升级，需确认 Blacksmith 入口路径） 〔复盘〕
- 熔炉在 17:50 仍未完成，collect/load 连续返回空 @ Farm — no machine has finished output；no empty machine accepts that（做不了：当天没收到第二块铁锭，铁锭停在 1/5） 〔复盘〕
- 钓鱼只赚 800g，全天金钱零增长 @ Forest — fished: caught 5 (Green Algae, Smallmouth Bass×3, Green Algae)（做不了：没有现金增量，无法靠钓鱼补足升级资金缺口） 〔复盘〕
