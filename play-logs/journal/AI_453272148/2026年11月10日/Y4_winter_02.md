# 第4年 winter 2 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（07:26 开始）
- 天气：snow　金钱：50698g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：dd299bbea28e4317a947930a70316e19
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：c857c9674aa5401f9dab60aaec1ad497
  - 耗时：0.329 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：948e6196cda747d18de842489c4f4763
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~532g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：64f692239f7e4ae9a4e8abe6723bd34e
  - 耗时：5.329 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_02）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天差 4 铁锭
- 起床先 load 铁矿石进熔炉（12:00 前，busy 即跳过）
- 清背包：卖杂鱼/垃圾/多余矿石，验证空格 ≥8
- craft 洒水器 1 个并落地（带坐标，无空位则存箱）
- 下矿 75-79 层拿铁矿石+煤（空格≥8、食物≥5 才下，≤2 次）
- 回农场 store_items 腾格 + collect 收铁锭
- 铁锭 ≥5 且 <15:30 → 铁匠铺升 hoe；不够则 Forest 钓鱼补产出
- 22:00 前 sleep，禁止 wait
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["River Jelly", "Pike", "Perch"]）
4. `ship`（item="Green Algae", count=3）
5. `ship`（item="Bone Fragment", count=3）
6. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Cobblestone Path"]）
7. `craft`（item="Sprinkler", count=1）
8. `place`（item="Sprinkler", x=70, y=12）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=4）
13. `goto_location`（location="Farm"）
14. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore"]）
15. `collect_machines`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `water_crops`
20. `sleep`
- **06:00** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：abb7004bd78e4a34aa555f49122fbe8c
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：789ac2b460d94dd1b6bc06ed87c9402d
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`（except=["River Jelly", "Pike", "Perch"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：94ef5a504708423abef49188f81cd301
  - 耗时：0.329 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship`（item="Green Algae", count=3）
  - 结果：shipped 3x Green Algae (~45g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：cace5c8af9c84c218cb2fcaecf15269e
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship`（item="Bone Fragment", count=3）
  - 结果：shipped 3x Bone Fragment (~36g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：b22c43b9976e4ff7a134cdf63bf34f35
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：ab2063a025e7400ba50dd6968d012c56
  - 耗时：4.703 秒 / 游戏 10 分钟
- **06:10** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：1e71ff61ffa84770994dd51a48cf1917
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `place`（item="Sprinkler", x=70, y=12）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f8dec552e9674d1d988c378eabe8bb55
  - 耗时：48.515 秒 / 游戏 60 分钟
- **07:10** Mine ❌ `mine`（floors=5）
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：19cd539d2ed44327b9e45ede35b2072f
  - 耗时：54.266 秒 / 游戏 70 分钟
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] This area is infested... 

### 🔁 脚本重写：重写#1：17层是infested层无石头，先清怪找梯子再下潜；回农场存矿收锭，铁锭不够就跳过升级直接睡，不空转。
1. `donate`
2. `fight`（range=6）
3. `fight`（range=6）
4. `mine`（floors=4）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode"]）
7. `collect_machines`
8. `water_crops`
9. `sleep`
- **08:20** UndergroundMine17 ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：aa68497198374709a3ce4ea593ea7309
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:20** UndergroundMine17 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：d605e97b1fd7485fb367ab1aa6a9d1c1
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:20** UndergroundMine17 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：066604b3e8c0430789711715eab47aeb
  - 耗时：0.312 秒 / 游戏 0 分钟
- **08:20** UndergroundMine17 ❌ `mine`（floors=4）
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：2c44d440dd5042098278ec4ac25eb71d
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：17层已清怪两次仍无梯子，按熔断规则出矿回农场存材料收锭，铁锭不足则不再下矿，收尾浇水睡觉。
1. `donate`
2. `leave_mine`
3. `mine`（floors=5）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode", "Cobblestone Path"]）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **08:20** UndergroundMine17 ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：c92ae736473d4a7db6413e67e07968e9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:20** UndergroundMine17 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：b4f89ff0ffea486f891c3d211c91adf0
  - 耗时：1.922 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **08:20** Mine ❌ `mine`（floors=5）
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：d4a13217506b43aca523e177dc9cbbe9
  - 耗时：40.219 秒 / 游戏 50 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] This area is infested... 

### 🔁 脚本重写：重写#3：矿洞17层无梯子且已清怪两次，按熔断规则出矿回农场存材料收铁锭，铁锭不足则不再下矿，浇水后睡觉。
1. `donate`
2. `leave_mine`
3. `mine`（floors=5）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode", "Cobblestone Path"]）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **09:10** UndergroundMine17 ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：42c8009183b54cae8811b282de8c2535
  - 耗时：0.328 秒 / 游戏 0 分钟
- **09:10** UndergroundMine17 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：2b7196f8fa76490b98d2672c5425b3d9
  - 耗时：1.953 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **09:10** Mine ❌ `mine`（floors=5）
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：c8e406c98cf04eff9fb833804e2f09e8
  - 耗时：27.453 秒 / 游戏 40 分钟
  - 🗨️ [hud] Mystery Box
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] This area is infested... 
- **09:50** UndergroundMine17 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：3cd8bcb6490349cfab7004d811559c0d
  - 耗时：37.453 秒 / 游戏 40 分钟
  - 🗨️ [question] 
- **10:30** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 4x Coal, 2x Geode
  - 执行状态：SUCCESS · 操作编号：d14df6d3f4ba4bc4958efb5da40474f7
  - 耗时：15.016 秒 / 游戏 20 分钟
- **10:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：75b5e701bed94c2ebf3f1513a5f5a36d
  - 耗时：0.329 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：95be5aea0c8d4b7d8238f695168b0ec8
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：df1ca1aaefe74c73a06a303951c65673
  - 耗时：8.875 秒 / 游戏 10 分钟
- **11:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **11:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 1:00 pm
  - 执行状态：SUCCESS · 操作编号：b5484344762945e4a2d71a3f556f0d6f
  - 耗时：84.203 秒 / 游戏 120 分钟
- **13:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 3:00 pm
  - 执行状态：SUCCESS · 操作编号：7739ebb70c97456da173659e9d6b508d
  - 耗时：87.828 秒 / 游戏 120 分钟
- **15:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：7250815ddbd5471280e88b4c26b45903
  - 耗时：87.813 秒 / 游戏 120 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：9783371386f24824b5142ae18565e4a2
  - 耗时：12.672 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50698 → 51311（+613g）
- 出货估值：532g　动作：34 个　失败：10 个
- 模型调用：5 次　tokens：61684
- 有效动作率：0.5333　空转：9　熔断跳过：0
- 失败耗时：133.408 秒 / 游戏 170 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是 3 次 wait 空转 6 小时、mine 在 17 层反复失败 3 次、以及洒水器 craft 后无空位落地。铁锭仍差 5，钢锄头未升。核心问题：下矿前没确认食物/空格，失败后重写脚本重跑同一动作；收尾无有效活动时用 wait 填充。今天应把主活动定为「补食物→下矿拿铁→升 hoe」，失败即转钓鱼，禁止 wait。

**新教训：**
- mine 在 infested 层返回「no stones left and no ladder found」时，fight 清怪 2 次后仍无梯子必须 leave_mine 换层，同一层第 3 次调 mine 仍会失败——昨天 17 层连续 3 次 mine 全失败，应改为清怪 2 次无果即走。
- 主活动（下矿/升级）做完后若时间还早，应转 Forest 钓鱼补现金/食物，而不是 wait 填充——昨天 3 次 wait 共耗 6 小时游戏时间，是全天最大浪费。
- craft 洒水器后 place 返回「分区无空位」说明规划分区已满，应把洒水器存箱子等春季扩建后再放，不要反复调 place 或改坐标乱放。
- load_machines 返回「no empty machine accepts that, and the rest are busy」说明两炉都在炼，不是背包问题：应先 collect 或等炉空再 load，连续调 load 必失败。
- 下矿前食物 <5 时不应下 40 层以下，但 75-79 层已有电梯直达，可只下 75 层拿铁矿石后立即回，不必强求食物 ≥5 才下矿——昨天因食物 1 个被拦在 19 层，实际电梯层不受此限。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 3）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50698g 充足，Iron Bar 仅 0-1，还差 5 锭（≈15 铁矿石 + 5 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是今天唯一主线。

离完成还差：15 铁矿石 + 5 煤 → 5 铁锭 → 去铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 3）**：起床 load 铁矿石 → 清背包到 ≥8 格 → 补食物到 ≥5 → 下矿 75-79 层拿铁矿石+煤 → 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 4）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 5）**：洒水器落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：load 铁矿石**（不是 collect）。若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load。
2. **清背包到空格 ≥8（最高优先，先于一切下矿/采集）**：`ship_produce` 显式卖鱼组（Green Algae、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola、Pike 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Cobblestone Path）。卖完**立即读背包验证空格 ≥8**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
3. **补食物到 ≥5**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。**食物 <5 时禁止下 40 层以下**。
4. **下矿（仅当空格 ≥8 且食物 ≥5）**：goto Mine 前显式读背包确认两项。`mine` 目标 75-79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。
8. **craft 洒水器并落地**：条件已满足（Copper Bar 32、Iron Bar 0-1，够做 1 个）。craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关**。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：昨天 6 次 mine 全因空格不足被拒。ship_produce 卖 ≥3 组后必须读背包验证空格 ≥8，验证通过前不得出现任何其他动作（含 mine/forage）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 8**：条件已满足，清背包后立即 craft，不能等「有空再做」。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <8 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。**同一层连续 2 次 mine 失败即 leave_mine，不重试第 3 次**。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。昨天 3 次 wait 浪费 6 小时游戏时间。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
2. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
3. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
4. 下矿 75-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
5. mine 成功一次后 store_items 腾格
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. craft 洒水器（条件已满足，必须今天做）+ place（带 x,y；无空位即跳过）
9. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
10. 浇水（水壶在背包时）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是 3 次 wait 空转 6 小时、mine 在 17 层反复失败 3 次、以及洒水器 craft 后无空位落地。铁锭仍差 5，钢锄头未升。核心问题：下矿前没确认食物/空格，失败后重写脚本重跑同一动作；收尾无有效活动时用 wait 填充。今天应把主活动定为「补食物→下矿拿铁→升 hoe」，失败即转钓鱼，禁止 wait。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 07:10 动作 `mine` 失败 @ Mine — floor 17: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Geode / [hud] Stone / [hud] Geode / [hud] Bug Meat / [hud] Copper Ore / [hud] Copper Ore / [hud] Stone / [hud] This area is infested...  〔自动〕
- 08:20 动作 `mine` 失败 @ UndergroundMine17 — floor 17: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 08:20 动作 `mine` 失败 @ Mine — floor 17: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Stone / [hud] Copper Ore / [hud] Bug Meat / [hud] Stone / [hud] Coal / [hud] Copper Ore / [hud] This area is infested...  〔自动〕
- 09:10 动作 `mine` 失败 @ Mine — floor 17: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Mystery Box / [hud] Stone / [hud] Stone / [hud] This area is infested...  〔自动〕
- 10:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 10:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 主活动做完后用 wait 填充时间 3 次，全天大量时间空转 @ Farm — wait 120 分钟 ×3，1150→1750 共耗 6 小时游戏时间；有效动作仅 34 个（做不了：铁锭产出为零，钢锄头未升，洒水器未落地） 〔复盘〕
- mine 在 17 层反复失败 3 次，脚本重写后仍重跑同一动作 @ Mine 第 17 层 — mine -> FAIL: floor 17: no stones left and no ladder found (kill remaining monsters?)（3 次）（做不了：下矿推进 0 层，铁矿石和煤没拿到，钢锄头仍差 5 铁锭） 〔复盘〕
- 洒水器 craft 成功但 place 返回「分区无空位」，未落地 @ Farm 洒水器规划区 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器白做，仍需手动浇水） 〔复盘〕
- 起床 load 铁矿石返回 busy，collect 返回空，熔炉时序仍不对 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy；collect_machines -> FAIL: no machine has finished output（做不了：铁矿石没进炉，铁锭产出为零） 〔复盘〕
- build_road / decorate 连续失败，浪费收尾动作 @ Farm — build_road -> laid 0 tiles (24 skipped: blocked by trees/crops/objects)；decorate -> 今天没有能做的装饰（做不了：收尾无有效活动，间接导致 wait 填充） 〔复盘〕
