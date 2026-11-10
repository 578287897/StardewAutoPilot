# 第4年 fall 28 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（06:36 开始）
- 天气：windy　金钱：50241g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ce63ccfcc7814ca1abdede3009257d90
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：8da244372fa44cfea3e708bccce5388d
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：1d9a2137a59c440ea971f0269b2991a9
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~307g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：69a6cf82ee0d495887dcad531e6001c4
  - 耗时：5.313 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_28）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——今天冬 1，Town 解锁，起床先收熔炉、装铁矿石，铁锭够就直接升 hoe
- craft 洒水器并落地（条件已满足）
- 清背包腾格（卖杂鱼/杂项），验证空格 ≥8
- Forest 钓鱼补食物到 ≥5（只留高回复鱼）
- 食物和空格达标后下矿 75-79 层拿铁矿石+煤，回来收锭
- 铁锭 ≥5 且 <15:30 去 Blacksmith 升 hoe；不够则跳过不白跑
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `craft`（item="Sprinkler", count=1）
5. `place`（item="Sprinkler"）
6. `ship_produce`（except=["Iron Bar", "Copper Bar", "Stone", "Fiber", "Coal", "Iron Ore", "Gold Ore"]）
7. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Coal", "Gold Ore", "Cobblestone Path", "Sap", "Slime"]）
8. `goto_location`（location="Forest"）
9. `fish`（casts=4）
10. `fish`（casts=4）
11. `ship_produce`（except=["Iron Bar", "Copper Bar", "Stone", "Fiber", "Coal", "Iron Ore", "Gold Ore"]）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore"]）
16. `collect_machines`
17. `goto_location`（location="Town"）
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Farm"）
21. `water_crops`
22. `sleep`
- **06:00** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：f8427641f75b4d1d9c4d092818f92200
  - 耗时：41.719 秒 / 游戏 50 分钟
- **06:50** CommunityCenter ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：3933b6d751cb4a769e89351aae3808f4
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：793ff3c7883345b3b5be5faaf3b5f217
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：fe18326002994cdfbac6c75b5e1fb947
  - 耗时：0.329 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ❌ `place`（item="Sprinkler"）
  - 结果：missing operation receipt; query actual result
  - 执行状态：ACTION_UNCERTAIN · 操作编号：ae73dd29d627493c9ec2c200537704d0
  - 耗时：0.063 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：节日锁城，主活动定为农场熔炉炼铁+Forest 钓鱼补食物现金，为冬 1 升钢锄头备料。
1. `donate`
2. `craft`（item="Sprinkler", count=1）
3. `place`（item="Sprinkler"）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `ship_produce`（except=["Iron Bar", "Copper Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Stone"]）
10. `ship_produce`（except=["Iron Bar", "Copper Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Stone"]）
11. `collect_machines`
12. `water_crops`
13. `sleep`

## 🌅 早上的计划（07:02 开始）
- 天气：windy　金钱：50241g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——今天节日锁城，先炼铁锭、做洒水器、Forest 钓鱼补食物与现金
- 起床先 load 铁矿石进熔炉（12:00 前完成）
- craft 洒水器并落地
- 清背包卖杂鱼垃圾，验证空格
- Forest 钓鱼补食物≥5 与现金
- 回农场 collect 收铁锭
- 浇水、22:00 前 sleep

**执行脚本：**
1. `load_machines`
2. `donate`
3. `craft`（item="Sprinkler", count=1）
4. `place`（item="Sprinkler"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `ship_produce`（except=["Iron Bar", "Copper Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Stone"]）
11. `ship_produce`（except=["Iron Bar", "Copper Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Stone"]）
12. `collect_machines`
13. `water_crops`
14. `sleep`
- **06:50** CommunityCenter ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1a267912245941aa90e3d9c21344602a
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：d3ecd04fa6504474926a647f94b49a7b
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：45e6db257e70404bb2d792b55e9899f9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:50** CommunityCenter ❌ `place`（item="Sprinkler"）
  - 结果：missing operation receipt; query actual result
  - 执行状态：ACTION_UNCERTAIN · 操作编号：c1d24f6ccc5a44eca8f3c2ed4b44c520
  - 耗时：0.078 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：秋28万灵节锁城，删去Town/Blacksmith/Mine分支，只做农场熔炉时序+洒水器+Forest钓鱼补食物现金，最后收炉睡觉。
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `craft`（item="Sprinkler", count=1）
4. `place`（item="Sprinkler"）
5. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Farm"）
10. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
11. `collect_machines`
12. `water_crops`
13. `sleep`

## 🌅 早上的计划（07:10 开始）
- 天气：windy　金钱：50241g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——今天节日锁城，先炼铁锭
- 起床load铁矿石进熔炉，白天炼出铁锭
- craft洒水器并落地（条件已满足）
- 清背包卖杂鱼腾格
- Forest钓鱼补食物/现金
- 22:00前sleep

**执行脚本：**
1. `load_machines`
2. `donate`
3. `load_machines`（item="Iron Ore"）
4. `craft`（item="Sprinkler", count=1）
5. `place`（item="Sprinkler"）
6. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
12. `collect_machines`
13. `water_crops`
14. `sleep`
- **06:00** FarmHouse ❌ `place`（item="Sprinkler", request_id="c1d24f6ccc5a44eca8f3c2ed4b44c520"）
  - 💭 (回执缺失且动作已结束，不再整日等待)
  - 结果：no operation receipt after the action ended; not waiting forever
  - 执行状态：ACTION_FAILED · 操作编号：c1d24f6ccc5a44eca8f3c2ed4b44c520
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：cd3de21a446644d98deaeaafe869995e
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：977cc239d0484c5c961caf4493c341d3
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：34edcc33651c4e09a55362ee6158302f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：3071ccc908184830831b191ed3c1339d
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `place`（item="Sprinkler"）
  - 结果：missing arguments 'x' and 'y'
  - 执行状态：ACTION_FAILED · 操作编号：c8cf7606049443f1b8d9a993d18db13a
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
  - 结果：shipped 2 stacks worth ~7g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b12c5ef6e70a4d1ba8f782e4ab93626b
  - 耗时：5.36 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：ed1784e6969942aa9d4f024f7daf5b4a
  - 耗时：21.594 秒 / 游戏 30 分钟
- **06:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Smallmouth Bass, River Jelly, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：8b87c170b4ed4397969f0094c46e5db8
  - 耗时：79.719 秒 / 游戏 100 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] River Jelly
- **08:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Smallmouth Bass, Broken Glasses, Green Algae)
  - 执行状态：SUCCESS · 操作编号：ba09f6650a634b319a98b1148fabbe52
  - 耗时：67.187 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Broken Glasses
- **09:30** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：227c0ae914fa436799e67556af39d6e1
  - 耗时：9.578 秒 / 游戏 10 分钟
- **09:40** Farm ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Smallmouth Bass"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：32976a5a66104eef9d0265a140ca288b
  - 耗时：0.313 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：5178148c6b2244d6a5b85488f0aa135f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：f9b975ecd5b94414879c74411fb80101
  - 耗时：0.39 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：0ff301ce6fc94a139e121ff1a5b49583
  - 耗时：0.313 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4d069404711d468db6ba74d87e2e1d32
  - 耗时：0.391 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：d9743d9936e8433cb3daf1ea0b701fad
  - 耗时：1.531 秒 / 游戏 0 分钟
- **09:40** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 1 forage items
  - 执行状态：SUCCESS · 操作编号：096a9288fb834f7ca73d31203a892b25
  - 耗时：70.296 秒 / 游戏 90 分钟
  - 🗨️ [hud] Common Mushroom
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
- **11:10** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3f6bcbd1458f4ed79e7e38d70bbab928
  - 耗时：49.562 秒 / 游戏 70 分钟
- **12:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:20** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：75f75e3c66314c83a0433466f34bd559
  - 耗时：12.688 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50241 → 50248（+7g）
- 出货估值：7g　动作：21 个　失败：8 个
- 模型调用：1 次　tokens：11619
- 有效动作率：0.5　空转：7　熔断跳过：0
- 失败耗时：52.28 秒 / 游戏 70 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天节日锁城，脚本仍反复尝试去 Town/Blacksmith/Mine 导致 8 次失败、0 层下矿、铁锭零产出；洒水器 craft 成功但 place 缺坐标失败；熔炉 load 无空炉（两炉都在炼），collect 又太早返回空。有效动作只有 Forest 钓鱼和 1 次 craft。今天冬 1 解锁，核心是补 2 铁锭升钢锄头，并把洒水器落地。

**新教训：**
- place 动作必须显式带 x、y 坐标：昨天 craft 洒水器成功但 place 缺参数直接失败，应先用分区空位坐标再 place。
- 熔炉 load 返回「no empty machine」说明两炉都在炼，不是背包问题：应先 collect 或等炉空再 load，不要连续调 load。
- 节日当天 goto Town 失败 4 次、goto Blacksmith 失败 2 次、goto Mine 失败 1 次共耗约 300 游戏分钟：节日锁城时脚本生成阶段就物理删除这些分支，主活动直接定为 Forest 钓鱼。
- mine/fight HTTP 超时后重试同一动作仍会超时：超时一次即当天不再调 mine/fight，1 个动作内转 Forest 钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 1）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50241g 充足，Iron Bar 只有 2，还差 3 锭（≈9 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是今天主线。今天冬 1 Town 解锁，铁匠铺 9:00-16:00 营业。

离完成还差：约 9-12 铁矿石 + 3 煤 → 3 铁锭 → 今天或明天去铁匠铺升 hoe（一次一件）。

接下来 3 天主活动：
- **今天（冬 1）**：起床先看两座熔炉状态——有空炉立即 load 铁矿石（12:00 前完成）；下矿 75-79 层拿铁矿石+煤（背包空格 ≥8、食物 ≥5 才下）；回农场 collect 收锭；铁锭 ≥5 且时间 <15:30 直接升 hoe。
- **明天（冬 2）**：转钢斧（5000g+5 铁锭），或继续补铁锭；冬季种冬季种子。
- **后天（冬 3）**：洒水器落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：读熔炉状态**
   - `collect_machines` 1 次（收昨天炼好的锭）。
   - 若返回空且背包有 Iron Ore 且存在空炉 → `load_machines` 1 次装铁矿石，**必须在 12:00 前完成**。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
2. **craft 洒水器并落地**：`craft` 洒水器 1 个（Copper Bar 34、Iron Bar 2，够做 1 个）。craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。
3. **清背包到空格 ≥8**：`ship_produce` 显式卖鱼组（Green Algae、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap）。卖完读背包验证空格 ≥8；不足再卖一次小堆，仍不足则当天定性钓鱼日。
4. **补食物到 ≥5**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。
5. **下矿（今天冬 1 非节日）**：goto Mine 前显式读背包确认空格 ≥8 且食物 ≥5。`mine` 目标 75-79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
7. **升级工具（今天冬 1 可做）**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。
8. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
10. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **节日锁城硬规则**：日期=节日时，脚本生成阶段就删除所有 goto Town/Blacksmith/Saloon/AdventureShop/Mine 分支；节日当天主活动=农场内务+Forest 钓鱼+节日地图（若可达）。**goto 同一地点失败一次即永久跳过，不重试。**
- **熔炉顺序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 2**：条件已满足，起床 collect/load 后立即 craft，不能等「有空再做」。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **清背包绝对优先**：ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
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
1. 起床：collect 熔炉 → 有空炉立即 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
2. craft 洒水器（条件已满足，必须今天做）+ place（带 x,y；无空位即跳过）
3. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿 75-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天节日锁城，脚本仍反复尝试去 Town/Blacksmith/Mine 导致 8 次失败、0 层下矿、铁锭零产出；洒水器 craft 成功但 place 缺坐标失败；熔炉 load 无空炉（两炉都在炼），collect 又太早返回空。有效动作只有 Forest 钓鱼和 1 次 craft。今天冬 1 解锁，核心是补 2 铁锭升钢锄头，并把洒水器落地。
- 06:00 动作 `place` 失败 @ FarmHouse — no operation receipt after the action ended; not waiting forever 〔自动〕
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `place` 失败 @ FarmHouse — missing arguments 'x' and 'y' 〔自动〕
- 09:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 09:40 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:10 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 节日锁城后仍反复尝试去 Town 办事 @ Farm→Town 出口 — goto_location -> FAIL: exit to Town did not open; 游戏消息: Today's festival is being set up. Come back later.（连续 4 次）（做不了：铁匠铺升级 hoe、去 Mine 下矿全部做不成，全天主活动被卡） 〔复盘〕
- 节日锁城导致去 Blacksmith 和 Mine 的路径全部不可达 @ Forest / Backwoods 中转 — goto_location -> FAIL: no reachable route from Forest to Blacksmith / Mine (unreachable exits: forest->town, busstop->town, backwoods->mountain)（做不了：钢锄头升级顺延，铁矿石和煤没拿到，铁锭仍为 2） 〔复盘〕
- mine 和 fight 动作 HTTP 超时 @ Mine — mine -> FAIL: cancelled: HTTP timeout; fight -> FAIL: cancelled: HTTP timeout（各 1 次）（做不了：下矿推进 0 层，铁矿石和煤没拿到） 〔复盘〕
- 熔炉 load 铁矿石失败，无空炉可装 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石没进炉，铁锭产出为零，钢锄头仍差 3 锭） 〔复盘〕
- 熔炉 collect 返回空，无成品可收 @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output（做不了：当天铁锭产出为零） 〔复盘〕
- 洒水器 craft 成功但 place 缺坐标失败 @ Farm — place -> FAIL: missing arguments 'x' and 'y'（做不了：洒水器没落地，仍要手动浇水） 〔复盘〕
- 节日地图不可达，festival 动作失败 @ Farm — festival -> FAIL: not at a festival right now (goto_location the festival map during its hours first)（做不了：万灵节活动没参加，节日奖励没拿到） 〔复盘〕
- 背包满导致下矿被拒、forage 也提示 Inventory Full @ Farm / Forest — mine -> FAIL: need at least 5 free backpack slots before mining; forage 游戏消息: Inventory Full（做不了：下矿和采集都做不成，全天只钓到杂鱼） 〔复盘〕
