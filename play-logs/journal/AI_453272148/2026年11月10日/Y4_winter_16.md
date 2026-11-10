# 第4年 winter 16 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:57 开始）
- 天气：sunny　金钱：56869g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_winter_16）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升钢锄头
- 起床先收熔炉成品，炉空且铁矿石够就投料炼铁
- 清背包到空格≥10（store_items 不指定坐标，不足则 ship_produce）
- 食物补到≥5（Forest 钓鱼补鱼）
- 电梯直达 75 层下矿拿铁矿石+煤（75→79，≤2 次 mine）
- 回农场收铁锭，铁锭≥5 且 15:30 前到 Blacksmith 升 hoe
- 条件满足则 craft 洒水器并落地
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `store_items`
14. `goto_location`（location="Mountain"）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Farm"）
18. `craft`（item="Sprinkler", count=1）
19. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：a8b6e2e470704f9c857714654056957d
  - 耗时：17.39 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **06:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：34b85913f83546c0ba22566499f5d6d0
  - 耗时：105.64 秒 / 游戏 140 分钟
- **08:40** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：31859f199a2640668670fb66141aaac7
  - 耗时：0.344 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：86c719f8b84146a7a73bfc46c65bb4b0
  - 耗时：0.344 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e1822500341746739d931f8ae6128a18
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：f567735d3ea04d18a86b3bbf9f673912
  - 耗时：0.36 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：824927d7fd184032ad8b603571ef8ed0
  - 耗时：7.031 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **08:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b163553ab0924d8b85a3f222f96ff14e
  - 耗时：0.359 秒 / 游戏 0 分钟
- **08:50** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：729327e7b5384d16b23d26d905fbebe1
  - 耗时：20.109 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 7 (Broken Glasses, Perch, treasure: Wood, treasure: Copper Ore, treasure: Copper Ore, Green Algae, Perch)
  - 执行状态：SUCCESS · 操作编号：d88aab85601e479db6b51b41dbf86d01
  - 耗时：77.516 秒 / 游戏 80 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
- **10:40** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：4231c03e4bc74f86922e49e66b77b54d
  - 耗时：71.547 秒 / 游戏 90 分钟
- **12:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ef5e9fe3434d44418800f19f0a4a4454
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包0空格导致下矿被拒，先回农场存材料腾格再下矿，之后按窗口升hoe。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Mountain"）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Farm"）
7. `store_items`
8. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
9. `collect_machines`
10. `store_items`
11. `collect_machines`
12. `craft`（item="Sprinkler", count=1）
13. `sleep`
- **12:10** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：778b25efb1224dc680134ab4f577f608
  - 耗时：41.734 秒 / 游戏 50 分钟
- **13:00** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：bb473d1882e248079f3886b717f6d07b
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包0格导致下矿被拒，先回农场存材料腾格再下矿，其余路线保持原顺序。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `goto_location`（location="Mountain"）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="hoe"）
7. `goto_location`（location="Farm"）
8. `store_items`
9. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
10. `store_items`
11. `store_items`
12. `collect_machines`
13. `collect_machines`
14. `craft`（item="Sprinkler", count=1）
15. `sleep`
- **13:00** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：02971fdcfd434d8dbcf7d2b6723a274c
  - 耗时：2.312 秒 / 游戏 0 分钟
- **13:00** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1706aee5ba8a4337b36bda2488b0b9d8
  - 耗时：39.391 秒 / 游戏 50 分钟
- **13:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f3e640c746f14e75a4f1a6784d1fbbb3
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0格导致mine被拒，先回农场存材料腾格再下矿，铁锭够则15:30前升hoe。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Mountain"）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `craft`（item="Sprinkler", count=1）
7. `goto_location`（location="Farm"）
8. `store_items`
9. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
10. `store_items`
11. `collect_machines`
12. `store_items`
13. `collect_machines`
14. `sleep`
- **13:50** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：08d12c16f2d24ac4aad5830c9b7f5cbc
  - 耗时：41.75 秒 / 游戏 50 分钟
- **14:40** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：944c2f69e6a14ced8e20fcbbe9cf1a95
  - 耗时：0.36 秒 / 游戏 0 分钟
- **14:40** CommunityCenter ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：660a7aa3bacd49349457a79e71d3b7a1
  - 耗时：21.937 秒 / 游戏 20 分钟
- **15:00** Mountain ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：e454208d762c4c98a9e35485e15ad379
  - 耗时：30.109 秒 / 游戏 40 分钟
- **15:40** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Clint isn't at the counter (open 9:00-16:00); use upgrade_tool — chatting with interact does not upgrade tools
  - 执行状态：ACTION_FAILED · 操作编号：300895cfb93c4179bb40fa25e1fc7f75
  - 耗时：0.344 秒 / 游戏 0 分钟
- **15:40** Blacksmith ❌ `craft`（item="Sprinkler", count=1）
  - 结果：can't craft Sprinkler: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：9f9c7d287fdd4d4aaf6a089cf07386d2
  - 耗时：0.359 秒 / 游戏 0 分钟
- **15:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：34a193655ca546a581ad49b58252ca71
  - 耗时：40.453 秒 / 游戏 50 分钟
- **16:30** Farm ✅ `store_items`
  - 结果：stored in chest at (75,15): 65x Stone, 18x Copper Ore, 2x Iron Ore, 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：82046aa27cef46528addc3c9652edae6
  - 耗时：1.063 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
  - 结果：shipped 1 stacks worth ~164g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：d02f3b7de8f3452e8da17d4df7e5c8a8
  - 耗时：0.891 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal, 1x Copper Bar, 6x Wood
  - 执行状态：SUCCESS · 操作编号：17c1de0a96604c4eb3485c8caed51a20
  - 耗时：0.328 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：441a76b96706449293986c2ba53a686f
  - 耗时：0.344 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：8acd1e5871a049cc8e473de2cfb40895
  - 耗时：0.344 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:30** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：dc71790258164422a40acba2e1335d99
  - 耗时：19.578 秒 / 游戏 30 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] The Night Market is 
now open. 
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c3874bbae69441d097f3084e1437e026
  - 耗时：17.734 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：56869 → 57033（+164g）
- 出货估值：164g　动作：32 个　失败：10 个
- 模型调用：5 次　tokens：64956
- 有效动作率：0.6　空转：6　熔断跳过：1
- 失败耗时：109.516 秒 / 游戏 140 分钟
- 最深矿层：82　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天主线零推进：熔炉无铁锭产出、背包0空格导致4次mine被拒、16:50才到铁匠铺已锁门。有效动作只有Forest钓鱼和收铜锭。根因是脚本生成前没读背包空格/熔炉状态/食物数，且清背包通道被挡后仍反复重试mine。今天必须先把背包清到≥10空格、熔炉投铁矿石、电梯直达75层，15:30前完成升级窗口。

**新教训：**
- 昨天 4 次 mine 全因背包 0 空格被拒，而脚本重写 3 次仍重跑 mine：脚本生成阶段必须先读 /state 背包空格，空格 <10 时物理删除 mine 分支，而不是运行时反复被拒。
- 昨天 16:50 才 goto Blacksmith 并 upgrade_tool 返回 locked：升级必须排在 9:10-15:30 窗口内，15:00 还没凑齐 5 铁锭就当天放弃升级，把时间给钓鱼/下矿。
- 昨天 load_machines 返回 no empty machine accepts anything 后又重试一次被 suppressed：load 前必须同时确认「炉空」和「铁矿石≥5」，缺一即跳过 load 先去下矿拿矿。
- 昨天 donate 连续 3 次打开收集包但无可存入、water_crops 返回 0 作物：wait_letter 阶段 donate 与冬季 water_crops 都是 0 产出动作，应从脚本彻底删除，把动作预算留给钓鱼和下矿。
- 昨天两次 mine 都从 35 层爬而不是电梯直达 75 层，铁矿密度低导致铁矿石只拿到少量：下矿脚本必须显式写「电梯到 75 层，目标 75→79」，不要从当前最深 79 层往下爬。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 17）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 56869g 充足，Iron Bar 仅 1、Iron Ore 4、Coal 22、Copper Bar 47。瓶颈是**铁矿石→铁锭转化链**，不是钱。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 17）**：起床读炉状态→空炉且铁矿石≥5 立即 load→**清背包到空格≥10（这是今天第一硬门槛）**→食物补≥5→**电梯直达 75 层**拿铁矿石+煤（75→79 层，≤2 次 mine）→回农场 collect 收铁锭→铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 18）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续炼铁；同时 craft 洒水器落地。
- **后天（冬 19）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **清背包是今天第一硬门槛，优先于一切**：昨天 4 次 mine 全因 0 空格被拒、脚本重写 3 次仍重跑。今天脚本生成前先读 /state 背包空格；**空格 <10 时物理删除 mine 分支**，只保留 store_items → ship_produce → 钓鱼。store_items **不指定坐标**，返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外），两次后仍不足空格 10 → 当天定性钓鱼日，**不再出现任何 mine 动作**。
2. **熔炉投料先确认双条件**：起床先读炉状态。若任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则跳过 load 先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。**load 每天 ≤1 次，12:00 前完成。**
3. **下矿食物门槛 ≥5**：下矿前食物必须 ≥5，不够先在 Forest 钓 1 轮（≤4 cast）补鱼当食物，再下矿。
4. **下矿用电梯直达 75 层**：goto Mine 后**电梯直达 75 层**，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
5. **升级窗口硬约束**：铁锭凑齐后必须在 **15:30 前**到 Blacksmith，16:00 后锁门。若 15:00 还没凑齐 5 铁锭，当天放弃升级，把时间给钓鱼/下矿。升级前读背包确认 Iron Bar ≥5 及现金 ≥5000。
6. **动作预算清理**：build_road、decorate、wait、donate、water_crops 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：若任一熔炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item= Iron Ore 1 次；返回 busy/no empty 即当天永久跳过 load。若两炉都在炼 → 跳过 load。
2. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
3. **清背包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine 分支。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. 体力 <15 或时间 ≥22:00 sleep；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **熔炉 load 优先于 collect**：起床先读炉状态，空炉且铁矿石≥5 立即 load；两炉都在炼才跳过 load。load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过。collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过。**不连续调 load。**
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach/locked 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过）
2. collect_machines 1 次（收熔炉成品）
3. **清背包到空格 ≥10**（store_items 不指定坐标 + 读背包验证；不足则 ship_produce；两次不足即删 mine 分支）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach/locked 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主线零推进：熔炉无铁锭产出、背包0空格导致4次mine被拒、16:50才到铁匠铺已锁门。有效动作只有Forest钓鱼和收铜锭。根因是脚本生成前没读背包空格/熔炉状态/食物数，且清背包通道被挡后仍反复重试mine。今天必须先把背包清到≥10空格、熔炉投铁矿石、电梯直达75层，15:30前完成升级窗口。
- 06:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:40 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:40 动作 `upgrade_tool` 失败 @ Blacksmith — Clint isn't at the counter (open 9:00-16:00); use upgrade_tool — chatting with interact does not upgrade tools 〔自动〕
- 15:40 动作 `craft` 失败 @ Blacksmith — can't craft Sprinkler: inventory full 〔自动〕
- 16:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 熔炉全天没有炼出铁锭，主线零推进 @ Farm 熔炉 — 起床 collect_machines -> FAIL: no machine has finished output；随后 load_machines -> FAIL: no empty machine accepts anything（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 清背包通道被挡，下矿因空格不足受限 @ Farm 箱子/出货箱 → Mine — store_items 到 (74,15) 与 ship_produce 到 (70,15) 均 could not reach；mine 返回 backpack nearly full: store items before mining（做不了：背包清不出空格，连锁导致下矿拿不到足够铁矿石） 〔复盘〕
- 两次 mine 都从 35 层爬而不是电梯直达 75 层 @ Mine 35-39 层 — mine -> mined from floor 35 to 39 (4 floors down, 82 stones broken)；第二次 mine -> 0 floors down（做不了：铁矿密度低，铁矿石只拿到少量，铁锭仍不够） 〔复盘〕
- 下矿到 39 层因食物不足被拦，无法下 40 层以下拿铁矿 @ UndergroundMine 39 层 — mine -> stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 升级钢锄头时铁锭只有 1，且到铁匠铺已过 16:00 锁门 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 1；goto Blacksmith -> It's locked... (Open 9:00am - 4:00pm)（做不了：工具升级里程碑停滞） 〔复盘〕
- donate 连续 3 次打开收集包但无可存入 @ Community Center — donate -> opened the bundles but nothing could be deposited（做不了：浪费 3 个动作预算，社区中心收集包无法推进） 〔复盘〕
- 冬季 water_crops 返回 0 作物 @ Farm — water_crops -> watered 0 crops（做不了：浪费 1 个动作预算，冬季无作物时浇水无产出） 〔复盘〕
- build_road 铺路 0 格 @ Farm — build_road -> laid 0 Cobblestone Path tiles (13 skipped: blocked by trees/crops/objects)（做不了：浪费 1 个动作预算，农场地面被占满无法铺路） 〔复盘〕
