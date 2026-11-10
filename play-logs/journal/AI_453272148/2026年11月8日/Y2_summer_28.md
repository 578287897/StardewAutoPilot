# 第2年 summer 28 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（06:07 开始）
- 天气：sunny　金钱：15312g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：846b9297fdbc475582d2ae164d838dd2
  - 耗时：4.938 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tonight at around 10 o'clock PM, a rare and beautiful event will take place.  The moonlight jellies will be passing by Pelican Town on their long journey south for the winter.  We're all gathering at the beach to watch. You don't want to miss this! See you tonight,  -Demetrius

## 🌙 为明天（Y2_summer_28）准备的脚本
- 里程碑：工具按档升级——钢水壶（差2铁锭，今天两座熔炉各炼一轮补齐）
- 起床 collect_machines 1 次收铁锭
- 清背包到 ≥8 空格（Cobblestone Path、Bamboo Pole、Rice Shoot、Geode 等存箱）
- 食物<5 先去 Forest 河边钓鱼补到 ≥5
- 食物≥5、空格≥8 后下矿 40 层以下拿铁矿石+煤（≤2 次 mine）
- 回农场 load_machines 装 Iron Ore 1 次
- 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶
- 22:00 前 sleep
1. `goto_location`（location="Beach"）
2. `festival`（activity="start"）
3. `collect_machines`
4. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Copper Ore"]）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="watering_can"）
15. `goto_location`（location="Farm"）
16. `water_crops`
17. `sleep`
- **06:00** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：9cd1833c742a4995b6cdbb92f0244a68
  - 耗时：18.312 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：912adc0892254397afd93f5292604b78
  - 耗时：7.187 秒 / 游戏 10 分钟
- **06:30** Farm ✅ `harvest_crops`
  - 结果：harvested 7 crops
  - 执行状态：SUCCESS · 操作编号：6dc9e39f106645bbaf27d17d7b7b1bf0
  - 耗时：14.75 秒 / 游戏 20 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Hops
- **06:50** Farm ✅ `water_crops`
  - 结果：watered 12 crops
  - 执行状态：SUCCESS · 操作编号：751058b0becb42cda4927cd6dc070162
  - 耗时：12.688 秒 / 游戏 20 分钟
- **07:10** Farm ✅ `ship_produce`
  - 结果：shipped 4 stacks worth ~360g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：0e2e5952b9bb49519e2fefa3952c0ba2
  - 耗时：10.563 秒 / 游戏 10 分钟
- **07:20** Farm ❌ `goto_location`（location="Beach"）
  - 结果：exit to Beach did not open (closed? locked? check opening hours). Recent messages: Hops | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：afe9b9bb37e24ca197b501a6c4d53998
  - 耗时：40.157 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：海滩节日未开门，放弃节日分支；铁锭已够5，按原路线清背包→Forest钓鱼补食物→下矿→回农场装铁→Blacksmith升钢水壶→浇水睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="watering_can"）
9. `goto_location`（location="Farm"）
10. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Copper Ore"]）
11. `load_machines`（item="Iron Ore"）
12. `water_crops`
13. `sleep`
- **08:10** Town ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：9a86161d371c4cc3b7173656ca77bb54
  - 耗时：16.25 秒 / 游戏 20 分钟
- **08:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Chub, Green Algae, Chub)
  - 执行状态：SUCCESS · 操作编号：4dd14ebeb5ef4b72b7436546f581af2c
  - 耗时：94.625 秒 / 游戏 110 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Chub, Pike, Dorado)
  - 执行状态：SUCCESS · 操作编号：609e9d50088647ca8b373a882ea026fc
  - 耗时：112.828 秒 / 游戏 100 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Pike
- **12:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：bf9029c41d24433eac8c4945d66789f7
  - 耗时：64.406 秒 / 游戏 80 分钟
- **13:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：315c47fbb5784263837d473a88aaf709
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine因背包空格不足失败，先store_items清到≥8格再下矿，其余按原路线保留（下矿→回农场装铁→铁匠铺升钢水壶→浇水→睡觉）。
1. `mine`（floors=5）
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="watering_can"）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Green Algae", "Copper Ore", "Stone"]）
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `sleep`
- **13:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：46834275f4be4f2eae6f65cff30ef77c
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包满被拒，先回农场清格并装炉，铁锭已够5块直接去铁匠铺升钢水壶，再浇水睡觉。
1. `goto_location`（location="Blacksmith"）
2. `upgrade_tool`（tool="watering_can"）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Green Algae", "Copper Ore", "Stone"]）
5. `load_machines`（item="Iron Ore"）
6. `water_crops`
7. `sleep`
- **13:20** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：8f3dd9d4d1b1488caf064dc1b1ac8b0b
  - 耗时：47.063 秒 / 游戏 60 分钟
- **14:20** Blacksmith ✅ `upgrade_tool`（tool="watering_can"）
  - 结果：Clint is upgrading to Steel Watering Can for 5000g + 5x Iron Bar: ready in 2 days (come back with upgrade_tool to collect)
  - 执行状态：SUCCESS · 操作编号：8bc58cbd92e541ed9bfcfdd943135a54
  - 耗时：1.14 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] Clint: Thanks. I'll get started on this as soon as I can. It should be ready in a couple days.
- **14:20** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：318eef46687547999e36e5a04709e6e4
  - 耗时：39.407 秒 / 游戏 50 分钟
- **15:10** Farm ✅ `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Green Algae", "Copper Ore", "Stone"]）
  - 结果：stored in chest at (75,15): 42x Stone, 24x Cobblestone Path, 2x Green Algae, 4x Copper Ore
  - 执行状态：SUCCESS · 操作编号：4b624dfcc9704a5d91e4bf27ba1f2de8
  - 耗时：0.985 秒 / 游戏 0 分钟
- **15:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：fda651f5eadf47f4be321d09c06a8c8d
  - 耗时：0.172 秒 / 游戏 0 分钟
- **15:10** Farm ❌ `water_crops`
  - 结果：no watering can
  - 执行状态：ACTION_FAILED · 操作编号：05997c2b5bcb4ca7b26c46a712da04da
  - 耗时：0.156 秒 / 游戏 0 分钟
- **15:10** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：41c8e1357e1945618da8ce218573a2c5
  - 耗时：19.188 秒 / 游戏 30 分钟
  - 🗨️ [hud] Iron Bar
- **15:40** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：f76659e4c08d4571ac9aa0d6fea02418
  - 耗时：7.203 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Ore
- **15:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：0f08c1caf8494e40be721790de02260a
  - 耗时：0.203 秒 / 游戏 0 分钟
- **15:50** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：3b184728d0874070a9546d2c80b4e242
  - 耗时：0.14 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：def0f9bb703a457aba82507d2b6f853c
  - 耗时：6.734 秒 / 游戏 10 分钟
- **16:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：786662e678684a54b99935b05497afd2
  - 耗时：0.141 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：274e910ca4c443df8ab2f50fc9bf4287
  - 耗时：12.719 秒 / 游戏 10 分钟
- **16:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Joja Cola, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：a202b81a6efc408088b9ef574a7585bf
  - 耗时：46.766 秒 / 游戏 70 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Joja Cola
- **17:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4ecab79fef51447a930f5fb729e170ed
  - 耗时：8.36 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：15312 → 10672（-4640g）
- 出货估值：360g　动作：30 个　失败：11 个
- 模型调用：5 次　tokens：62566
- 有效动作率：0.6207　空转：5　熔断跳过：0
- 失败耗时：60.595 秒 / 游戏 70 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天成功把钢水壶交给克林特（2天后取），但主活动下矿因背包空格不足被拒两次，14:00-16:40 又陷入 load/build_road/decorate 空转约 4 小时。核心问题：清背包没清到 ≥8 格、失败后没有立即转产、把时间浪费在农场装饰类动作上。今天水壶在升级中，主活动应改为下矿拿铁/煤 + 钓鱼补现金，为洒水器和后续工具升级铺路。

**新教训：**
- 水壶在克林特处升级期间（2 天），water_crops 必然返回「no watering can」——升级当天脚本层应直接跳过浇水分支，不要浪费动作试探。
- 钢水壶升级已交付后，今天 upgrade_tool 全天禁用（一次只能升一件），应把时间全部投入下矿备料，而不是再跑 Blacksmith。
- 昨天 14:00-16:40 的「固定做到 17:00」分支让 load×4、build_road×2、decorate×2 全失败，浪费 8+ 动作和约 4 小时；任何动作失败一次即切钓鱼或 sleep，脚本层不设固定时段分支。
- Bait 已用完（背包 Bait=0）时，钓鱼效率会下降；今天若要去 Forest 钓鱼补食物/现金，应先顺路去 Mountain 的 FishShop 买 20-40 个 Bait（5g 一个），再钓鱼。
- 昨天 mine 被拒两次都是背包空格不足，而 store_items 只清到 5 格仍不够：清背包必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏29）

## 长期目标
当前里程碑：**工具按档升级**——钢水壶正在克林特处升级（还需 1 天，明天取）。今天无法再升第二件（一次只能升一件），所以今天的主活动是**为下一件工具（钢斧/钢镐）和洒水器备料**：铁锭≥5、现金≥5000g。
材料现状：Iron Bar 2、Iron Ore 2、Coal 8、Copper Bar 69、Stone 2279；现金 10312g（够升级费）。**差 3 铁锭 + 铁矿石/煤**。
并行里程碑：**洒水器×4 落地**（craft 已完成，等农场清出空地）；**钓鱼 2 级已达成，玻璃纤维钓竿 1800g 可买，鱼饵已用完需补 Bait**。
接下来 3 天主活动：
- **今天（夏29）**：下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine）；回农场装炉炼铁；现金兜底钓鱼。
- **明天（夏30）**：取钢水壶 → 洒水器落地 → 下矿补铁/煤，准备秋季种子预算。
- **后天（秋1）**：买南瓜/蔓越莓种子，铺洒水器，开始秋季种植。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Bamboo Pole、Green Algae、多余矿石、钓到的垃圾全部存箱或 ship；**必须清到 ≥8 空格**。空格<8 禁止下矿。
3. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
7. **补鱼饵**：若今天要钓鱼且 Bait=0，顺路去 Mountain 的 FishShop 买 Bait（5g 一个，买 20-40 个），16:30 后不去。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过（今天水壶在升级中，必然跳过）。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥8 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：食物<5 时 mine 会停在 39 层，铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load×4、build_road×2、decorate×2 浪费 8+ 动作。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **洒水器 place 今天禁用**：连续三天 place 失败且 hoe (54,16) 无效，今天不调 place/hoe 试探，把时间全给下矿。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。今天水壶在升级中，**upgrade_tool 全天禁用**。
- **工具升级期间禁下矿**：镐在升级中时 `mine` 脚本层直接禁用；水壶升级不影响下矿。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥8；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 清背包到 ≥8 空格
3. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
4. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停）
5. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
6. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
7. 补鱼饵（Bait=0 且要钓鱼时，顺路 FishShop 买）
8. 浇水（水壶在背包时；今天在升级中，跳过）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天成功把钢水壶交给克林特（2天后取），但主活动下矿因背包空格不足被拒两次，14:00-16:40 又陷入 load/build_road/decorate 空转约 4 小时。核心问题：清背包没清到 ≥8 格、失败后没有立即转产、把时间浪费在农场装饰类动作上。今天水壶在升级中，主活动应改为下矿拿铁/煤 + 钓鱼补现金，为洒水器和后续工具升级铺路。
- 07:20 动作 `goto_location` 失败 @ Farm — exit to Beach did not open (closed? locked? check opening hours). Recent messages: Hops | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 13:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:10 动作 `water_crops` 失败 @ Farm — no watering can 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下矿主活动因背包空格不足被拒两次，当天铁矿石零产出 @ Mine 入口 / Farm — need at least 5 free backpack slots before mining; store_items first（清到 5 格仍不够）（做不了：拿不到 40 层以下的铁矿石，钢水壶差 2 铁锭卡住，下一件工具升级也备不了料） 〔复盘〕
- 14:00-16:40 陷入「固定做到 17:00」空转分支，load/build_road/decorate 反复失败 @ Farm — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects；decorate: 今天没有能做的装饰（做不了：浪费约 4 小时游戏时间和 8+ 动作，本可用于钓鱼补现金或下矿） 〔复盘〕
- 水壶在克林特处升级，浇水动作失败 @ Farm — water_crops: no watering can（做不了：当天无法浇水，作物生长受影响（但升级本身是里程碑推进，可接受）） 〔复盘〕
- 节日当天 Beach 锁门，goto_location 失败 @ Beach — exit to Beach did not open；Today's festival is being set up. Come back later.（做不了：无法去海滩参加月光水母节，浪费 1 个动作） 〔复盘〕
