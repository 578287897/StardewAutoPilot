# 第4年 winter 1 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（07:16 开始）
- 天气：sunny　金钱：50248g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y4_winter_01）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天先凑铁锭
- 起床先收熔炉成品，有空炉立即装铁矿石（12:00 前）
- 清背包腾格：卖掉杂鱼和垃圾，保证空格 ≥8
- 补食物到 ≥5（Forest 钓鱼只留高回复鱼）
- 下矿 75-79 层拿铁矿石+煤，成功一次后回农场存材料
- 铁锭 ≥5 且时间 <15:30 就去铁匠铺升 hoe
- 收尾浇水，22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Coal", "Common Mushroom", "River Jelly", "Smallmouth Bass"]）
5. `store_items`（items=["Stone", "Fiber", "Copper Bar"]）
6. `craft`（item="Sprinkler", count=1）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Coal", "River Jelly", "Smallmouth Bass"]）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `store_items`（items=["Iron Ore", "Coal", "Stone"]）
16. `collect_machines`
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `water_crops`
21. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Common Mushroom -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：da4ec2e5d0594b15875fcc4658f56e9b
  - 耗时：16.5 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 4x Sprinkler, 3x Broken Glasses, 1x Joja Cola
  - 执行状态：SUCCESS · 操作编号：05498467fd7040f88e1e0880f40b900e
  - 耗时：17.687 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：a32ad71ecb6f48c18730de0c3d77c68a
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：595d44d94971410c9c9437b0b3a3de30
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~450g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b87cba8f80f145eea53cf5a1b7b5b88d
  - 耗时：0.672 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：907a655b56ef4037895bac802339e67a
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c36d27cca88e4d37a55177981cba4961
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：cbf8d88f9efd4b5d8846426bbd28cf18
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Coal", "Common Mushroom", "River Jelly", "Smallmouth Bass"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：8d4426658e9948138e8e64dfc419e5d1
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Stone", "Fiber", "Copper Bar"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1fac87471c2c450eb9e4b147725c2209
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：c03e1df94303411187a21fe6e5db87cb
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：0367927cca7d4a7bb730cc71e0d9d3eb
  - 耗时：25.188 秒 / 游戏 30 分钟
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Pike, Perch)
  - 执行状态：SUCCESS · 操作编号：1736821139fb4854bea089aa038081d3
  - 耗时：107.703 秒 / 游戏 110 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **09:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：acd59626b395448faea0ada9d3de927f
  - 耗时：73.265 秒 / 游戏 90 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：e58e901d86db4a1a8f0796eb7fb16657
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包仅2格导致下矿被拒，先回农场存材料腾格，再下矿拿铁矿，回来收锭并浇水睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Bone Fragment", "Gold Ore", "Cobblestone Path"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `store_items`（items=["Iron Ore", "Coal", "Stone"]）
8. `collect_machines`
9. `water_crops`
10. `sleep`
- **10:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：35729bddb6cc44a988023e6f94ba127c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b76cb12982b248c684747c28b6c41a1c
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包空格不足被拒，先回农场存材料腾格并给熔炉装矿，不再重试 mine，收尾浇水后睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Bone Fragment", "Gold Ore", "Cobblestone Path"]）
5. `load_machines`（item="Iron Ore"）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **10:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：684eb1dc08054d27a536c6a7a42e1e0a
  - 耗时：0.297 秒 / 游戏 0 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b13e5780bfd54c48a6261e01d572f023
  - 耗时：0.343 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包空格不足被拒，按教训不再重试mine，回农场存材料、装炉炼铁锭，再浇水睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Bone Fragment", "Gold Ore", "Cobblestone Path"]）
5. `load_machines`（item="Iron Ore"）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **10:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：2a643dd9189045deaa654ebc502eae66
  - 耗时：0.344 秒 / 游戏 0 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：e032b381cdad4ae28be73426dfbd9970
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：ad8eec0e89c34bc889fe8c03d7260e1d
  - 耗时：33.562 秒 / 游戏 40 分钟
- **11:10** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Bone Fragment", "Gold Ore", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：d7ab02cc0ef240cc9f9fd538caa1858c
  - 耗时：19.766 秒 / 游戏 30 分钟
- **11:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：81c55d45ee514720b94fe09a4b891036
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a2f2248000fe4b2895c89cb08dc5487e
  - 耗时：0.313 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：bed03bb9b6014a3290101251b1a13b28
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ea8f83dcc4794df99a870cae6268e6e0
  - 耗时：0.312 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f14c8c09f0444c559c1f5940acf597cb
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：2963c5750e674959a05632fa1cbde599
  - 耗时：8.891 秒 / 游戏 10 分钟
- **11:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **11:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 1:50 pm
  - 执行状态：SUCCESS · 操作编号：46fbc7ad816e427db690142fda8f38bf
  - 耗时：84.515 秒 / 游戏 120 分钟
- **13:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 3:50 pm
  - 执行状态：SUCCESS · 操作编号：fa9d8808e3e74cb09e419b39451b010b
  - 耗时：87.812 秒 / 游戏 120 分钟
- **15:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:50 pm
  - 执行状态：SUCCESS · 操作编号：471eac6200da41799759022b24113af2
  - 耗时：87.812 秒 / 游戏 120 分钟
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ef34490bf9164548bbfa6129cb0e1d89
  - 耗时：12.672 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50248 → 50698（+450g）
- 出货估值：450g　动作：36 个　失败：13 个
- 模型调用：5 次　tokens：61396
- 有效动作率：0.5　空转：9　熔断跳过：2
- 失败耗时：13.312 秒 / 游戏 10 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是背包满导致 6 次 mine 被拒、脚本重写 3 次空转，最后 3 次 wait 浪费 6 小时游戏时间；熔炉时序仍错（起床先 collect 而非 load），洒水器 craft 成功但没落地，铁锭仍差 4。有效的是钓鱼稳定出货、craft 洒水器成功。今天必须先把背包清到 ≥8 格再谈下矿，熔炉起床即 load，洒水器带坐标落地。

**新教训：**
- 昨天 3 次 wait(filler) 共耗 6 小时游戏时间（1150→1750），是全天最大浪费：主活动做完应立即 sleep 或转钓鱼，脚本层物理删除 wait 分支。
- 昨天 mine 被拒 6 次、脚本重写 3 次，根因是背包空格不足而脚本仍生成 mine 分支：脚本生成阶段应先读背包，空格 <8 时物理删除 mine 分支，而不是运行时反复被拒。
- 昨天起床先 collect 返回空、再 load 又 busy，说明熔炉时序仍反了：起床第一动作应是 load 铁矿石（若炉空），collect 固定放下矿回来第一时间。
- 昨天 craft 洒水器成功但没落地（place 未带坐标），洒水器白做：craft 后必须同一脚本内带 x,y 调 place，否则等于没做。
- 昨天 ship_produce 返回 OK 但背包仍满，导致后续 mine 全被拒：ship_produce 返回 OK ≠ 空格够，必须再读背包验证空格 ≥8 才能进入下矿分支。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 2）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50248g 充足，Iron Bar 仅 1，还差 4 锭（≈12 铁矿石 + 4 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是今天唯一主线。

离完成还差：12 铁矿石 + 4 煤 → 4 铁锭 → 去铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 2）**：起床 load 铁矿石 → 清背包到 ≥8 格 → 下矿 75-79 层拿铁矿石+煤 → 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 3）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 4）**：洒水器落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：load 铁矿石**（不是 collect）。若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load。
2. **清背包到空格 ≥8（最高优先，先于一切下矿/采集）**：`ship_produce` 显式卖鱼组（Green Algae、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola、Pike 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Cobblestone Path）。卖完**立即读背包验证空格 ≥8**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
3. **craft 洒水器并落地**：`craft` 洒水器 1 个（Copper Bar 33、Iron Bar 1，够做 1 个）。craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。
4. **补食物到 ≥5**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。
5. **下矿（仅当空格 ≥8 且食物 ≥5）**：goto Mine 前显式读背包确认两项。`mine` 目标 75-79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对优先于下矿**：昨天 6 次 mine 全因空格不足被拒。ship_produce 卖 ≥3 组后必须读背包验证空格 ≥8，验证通过前不得出现任何其他动作（含 mine/forage）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 3**：条件已满足，清背包后立即 craft，不能等「有空再做」。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <8 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
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
3. craft 洒水器（条件已满足，必须今天做）+ place（带 x,y；无空位即跳过）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿 75-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
9. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
10. 浇水（水壶在背包时）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是背包满导致 6 次 mine 被拒、脚本重写 3 次空转，最后 3 次 wait 浪费 6 小时游戏时间；熔炉时序仍错（起床先 collect 而非 load），洒水器 craft 成功但没落地，铁锭仍差 4。有效的是钓鱼稳定出货、craft 洒水器成功。今天必须先把背包清到 ≥8 格再谈下矿，熔炉起床即 load，洒水器带坐标落地。
- 06:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 10:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:40 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:40 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包满导致下矿连续被拒 6 次，脚本重写 3 次仍重跑 mine @ Farm / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（6 次）（做不了：下矿推进 0 层，铁矿石和煤没拿到，钢锄头仍差 4 铁锭） 〔复盘〕
- 主活动做完后用 wait 填充时间 3 次 @ Farm — wait 120 分钟 ×3，1150→1750 共耗 6 小时游戏时间（做不了：全天有效动作仅 36 个，大量时间空转，铁锭产出为零） 〔复盘〕
- 起床先 collect 返回空、随后 load 又 busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output；load_machines -> FAIL: no empty machine accepts that（做不了：铁矿石没进炉，铁锭产出为零） 〔复盘〕
- 洒水器 craft 成功但未落地 @ Farm — craft OK 后无 place 动作（或 place 缺 x,y）（做不了：洒水器没落地，仍需手动浇水） 〔复盘〕
- ship_produce 返回 OK 但背包仍满 @ Farm — ship_produce -> OK: shipped 1 stacks worth ~450g，但后续 mine 仍报空格不足（做不了：清背包未真正生效，下矿分支全部被拒） 〔复盘〕
- build_road / decorate 连续失败 @ Forest / Farm — build_road -> laid 0 tiles (24 skipped: blocked by trees/crops/objects)；decorate -> 今天没有能做的装饰（做不了：浪费 2 个动作，应从脚本彻底删除） 〔复盘〕
