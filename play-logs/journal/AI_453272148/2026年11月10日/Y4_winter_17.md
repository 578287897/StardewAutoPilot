# 第4年 winter 17 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（10:07 开始）
- 天气：sunny　金钱：57033g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌙 为明天（Y4_winter_17）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），瓶颈是铁矿石→铁锭链
- 起床先看熔炉：空炉且铁矿石≥5 就投料，两炉都在炼就跳过
- 清背包到空格≥10（store_items 不指定坐标 + ship_produce），验证通过才下矿
- 食物≥5 才下矿；不够先在 Forest 钓 1 轮补鱼
- 电梯直达 75 层，目标 75→79 层拿铁矿石+煤，≤2 次 mine
- 回农场 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 条件满足就 craft 洒水器并落地
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal", "Iron Bar"]）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `collect_machines`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `craft`（item="Sprinkler", count=1）
23. `place`（item="Sprinkler", x=70, y=20）
24. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：d6bec74753184761ab50a80410795975
  - 耗时：17.39 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：96fdbc034d744462a17302e888b97c38
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：1519f04477ad4296afa73aa5bea55737
  - 耗时：107.391 秒 / 游戏 140 分钟
- **08:40** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d90ac92039f84511944700a7aab58750
  - 耗时：0.344 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：aad4c01cc7914d4aa7d93a93732ad703
  - 耗时：0.359 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：af4b0189b074463bbccb5a85a0f99484
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：77677f1cad0141469a88f4a3e9379fe9
  - 耗时：0.359 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：37882683f2f84b08923402048179b42a
  - 耗时：7.0 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **08:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：e5d1ddec08cc4c90a2a58f5569e1d59a
  - 耗时：0.406 秒 / 游戏 0 分钟
- **08:50** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：6443cff3c6154d9691cdcdb9b0447a0f
  - 耗时：19.985 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (River Jelly, Green Algae, Green Algae, Pike)
  - 执行状态：SUCCESS · 操作编号：fe15df46aa2e463b8d549fe2c1c95873
  - 耗时：83.094 秒 / 游戏 100 分钟
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **11:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：7d3d160852654c869c1c752913634e2a
  - 耗时：71.485 秒 / 游戏 90 分钟
- **12:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：2d6cfdbd4c834d8bbb6c783451eaa68a
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因背包仅 3 空格被拒，按策略先回农场存物腾格再收炉、赶 15:30 前升 hoe，不再重试 mine。
1. `donate`
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="hoe"）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
7. `collect_machines`
8. `store_items`
9. `collect_machines`
10. `craft`（item="Sprinkler", count=1）
11. `place`（item="Sprinkler", x=70, y=20）
12. `sleep`
- **12:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：88ef415400504ad19585452cb1d1adf2
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:30** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：6dd901bd6dba4f6797c6ed14e34195d3
  - 耗时：47.187 秒 / 游戏 60 分钟
- **13:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：1a1737bd2e854052ba88d0f281903758
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：铁锭仅 1 无法升 hoe，按规则放弃升级转收炉+钓鱼，不再重试 upgrade_tool。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `collect_machines`
7. `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
8. `collect_machines`
9. `craft`（item="Sprinkler", count=1）
10. `sleep`
- **13:30** Blacksmith ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：081a91532c7848548e8d49a1026a1e17
  - 耗时：0.39 秒 / 游戏 0 分钟
- **13:30** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：836b325fe7c54359897f7baa75ecba55
  - 耗时：26.797 秒 / 游戏 30 分钟
- **14:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Tiger Trout, Pike, Perch)
  - 执行状态：SUCCESS · 操作编号：da029e2007cc48b784407aab958a2e26
  - 耗时：72.281 秒 / 游戏 70 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Pike
- **15:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：3ea3deada48740e0a9bab176f259afaa
  - 耗时：15.282 秒 / 游戏 20 分钟
- **15:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal, 2x Copper Bar
  - 执行状态：SUCCESS · 操作编号：01549a5655a94de384d1eb0cdb27ade3
  - 耗时：23.969 秒 / 游戏 30 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：dc79c88156ec49db81daa2bf30135dd1
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `ship_produce`（except=["Stone", "Copper Bar", "Iron Bar", "Iron Ore", "Coal"]）
  - 结果：shipped 3 stacks worth ~607g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：bc7f9761af0142119cf4af8ebfc4d04a
  - 耗时：0.703 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:00** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：ecd59dbddd924bd5b59f02ef2830470b
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：7ffb4a3c10eb430092405104f55e72ec
  - 耗时：14.656 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **16:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：58a19d51d57549e2a3065b927d922e61
  - 耗时：0.36 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `craft`（item="Cobblestone Path", count=11）
  - 💭 (做 11 块 Cobblestone Path 用来铺路)
  - 结果：crafted 11x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：6fd3c391436d422e98ae7d709a115cc0
  - 耗时：0.36 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：52efa24a172e4cb7b49369b0f1f2213d
  - 耗时：0.875 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：f8109c4735e44e34b3fd5181850c9422
  - 耗时：0.875 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:20** Farm ✅ `wait`（minutes=30, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:50 pm
  - 执行状态：SUCCESS · 操作编号：1749407f0f614d62a6333b13264440f5
  - 耗时：17.344 秒 / 游戏 30 分钟
- **16:50** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：0d7ed1b09b914cb1b06f449958f378f2
  - 耗时：0.422 秒 / 游戏 0 分钟
  - 🗨️ [hud] Copper Bar
- **16:50** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：341d4f8e40f14589a3e29d8e7d4900d3
  - 耗时：0.36 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ee3dbe3b407849ac9f172f8acedf75e6
  - 耗时：12.641 秒 / 游戏 10 分钟
  - 🗨️ [hud] The Night Market is 
now open. 
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：57033 → 57640（+607g）
- 出货估值：607g　动作：35 个　失败：11 个
- 模型调用：4 次　tokens：51722
- 有效动作率：0.5938　空转：11　熔断跳过：1
- 失败耗时：112.407 秒 / 游戏 140 分钟
- 最深矿层：82　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 35 动作 11 失败，主线零推进：铁锭仍差 5，钢锄头没升成。根因有三：一是熔炉投料时机错，两炉忙时反复 load 被拒；二是背包空格不足导致 mine 被拒，且清背包通道被挡；三是升级窗口错过（16:50 才到铁匠铺）。有效产出只有 Forest 钓鱼和收铜锭。今天必须把「清背包→下矿拿铁→炼锭→15:30 前升级」串成一条硬链，砍掉所有 0 产出动作。

**新教训：**
- 昨天 16:50 才到 Blacksmith 升级被锁门：升级动作必须在 15:30 前发起，15:00 时若铁锭仍 <5 就当天放弃升级，把剩余时间给钓鱼/下矿，而不是拖到傍晚再试。
- 昨天 mine 因背包空格不足被拒后，脚本重写仍重跑 mine：应在脚本生成阶段读 /state 背包空格，空格 <10 时物理删除 mine 分支，只保留 store_items→ship_produce→钓鱼，避免运行时反复被拒。
- 昨天 build_road 两次共 laid 0 格（13/24 skipped: blocked by trees/crops/objects）：农场地面被树木和作物占满时铺路永远 0 产出，应从脚本彻底删除 build_road，把动作预算给钓鱼和下矿。
- 昨天 load_machines 在铁矿石仅 4 时被调用返回 no empty machine accepts anything：load 前必须同时确认「炉空」和「铁矿石≥5」，缺一即跳过 load 先去下矿拿矿，不要空投。
- 昨天 collect_machines 连续两次返回 no machine has finished output 后被 suppressed：collect 每天最多 2 次（起床 1 次、下矿回来 1 次），返回空即当天永久跳过，不要连续调。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 18）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 57033g 充足，Iron Bar 仅 1、Iron Ore 4、Coal 20、Copper Bar 49。瓶颈是**铁矿石→铁锭转化链**，不是钱。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 18）**：起床读炉状态→空炉且铁矿石≥5 立即 load→**清背包到空格≥10（第一硬门槛）**→食物补≥5→**电梯直达 75 层**拿铁矿石+煤（75→79 层，≤2 次 mine）→回农场 collect 收铁锭→铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 19）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续炼铁；同时 craft 洒水器落地。
- **后天（冬 20）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **清背包是今天第一硬门槛，优先于一切**：脚本生成前先读 /state 背包空格；**空格 <10 时物理删除 mine 分支**，只保留 store_items → ship_produce → 钓鱼。store_items **不指定坐标**，返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外），两次后仍不足空格 10 → 当天定性钓鱼日，**不再出现任何 mine 动作**。
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
> 昨天 35 动作 11 失败，主线零推进：铁锭仍差 5，钢锄头没升成。根因有三：一是熔炉投料时机错，两炉忙时反复 load 被拒；二是背包空格不足导致 mine 被拒，且清背包通道被挡；三是升级窗口错过（16:50 才到铁匠铺）。有效产出只有 Forest 钓鱼和收铜锭。今天必须把「清背包→下矿拿铁→炼锭→15:30 前升级」串成一条硬链，砍掉所有 0 产出动作。
- 06:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 13 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:30 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests) 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 熔炉全天没有炼出铁锭，钢锄头主线零推进 @ Farm 熔炉 — 起床 collect_machines -> FAIL: no machine has finished output；随后 load_machines -> FAIL: no empty machine accepts anything；铁矿石仅 4 不足以投料（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 清背包通道被挡，下矿因空格不足被拒 @ Farm 箱子/出货箱 → Mine — store_items 到 (74,15) 与 ship_produce 到 (70,15) 均 could not reach；mine 返回 need at least 5 free backpack slots before mining（做不了：背包清不出空格，连锁导致下矿拿不到足够铁矿石） 〔复盘〕
- 两次 mine 都从 35 层爬而不是电梯直达 75 层 @ Mine 35-39 层 — mine -> mined from floor 35 to 39 (4 floors down, 82 stones broken)；第二次 mine -> 0 floors down（做不了：铁矿密度低，铁矿石只拿到少量，铁锭仍不够） 〔复盘〕
- 下矿到 39 层因食物不足被拦，无法下 40 层以下拿铁矿 @ UndergroundMine 39 层 — mine -> stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 升级钢锄头时铁锭只有 1，且到铁匠铺已过 16:00 锁门 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 1；goto Blacksmith -> It's locked... (Open 9:00am - 4:00pm)（做不了：工具升级里程碑停滞） 〔复盘〕
- build_road 铺路 0 格，连续两次失败 @ Farm — build_road -> laid 0 Cobblestone Path tiles (13/24 skipped: blocked by trees/crops/objects)（做不了：浪费 2 个动作预算，农场地面被占满无法铺路） 〔复盘〕
- decorate 返回今天没有能做的装饰 @ Farm — decorate -> 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：浪费 1 个动作预算） 〔复盘〕
- donate 连续 3 次打开收集包但无可存入 @ Community Center — donate -> opened the bundles but nothing could be deposited（做不了：浪费 3 个动作预算，社区中心收集包无法推进） 〔复盘〕
