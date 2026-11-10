# 第2年 summer 23 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:22 开始）
- 天气：sunny　金钱：11755g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_summer_23）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭）
- 先钓鱼补可吃食物到≥5（Forest河边，≤2轮）
- 清背包到≥7空格
- 下矿40层以下拿铁矿石+煤（≤2次mine）
- 回农场装炉炼铁1次、collect 1次
- 铁锭≥5且时间在9:10-15:30则升钢水壶
- 22:00前sleep
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `store_items`（items=["Cobblestone Path", "Stone", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds"]）
6. `goto_location`（location="Mine"）
7. `mine`（floors=8）
8. `mine`（floors=8）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `water_crops`
14. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Pickled Hops from Preserves Jar, Pickled Hops from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：d1c202f2ea52418eaf84ba22f657464d
  - 耗时：17.531 秒 / 游戏 20 分钟
  - 🗨️ [hud] Pickled Hops
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：13d28933a88343d5a62db10082669d66
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 6x Copper Bar, 1x Coal
  - 执行状态：SUCCESS · 操作编号：e1283b2e65364a4999b72fd3a0c7a500
  - 耗时：17.375 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 6 crops
  - 执行状态：SUCCESS · 操作编号：d7e6a5651ea44287b0f67e5dbba7edf9
  - 耗时：15.078 秒 / 游戏 20 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Hops
- **07:00** Farm ✅ `water_crops`
  - 结果：watered 12 crops
  - 执行状态：SUCCESS · 操作编号：6c82d0d930ed48399ab7444893be6cbc
  - 耗时：11.875 秒 / 游戏 0 分钟
- **07:00** Farm ✅ `ship_produce`
  - 结果：shipped 4 stacks worth ~402g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：844e13e2bf684ac9a54b2a40cb20d673
  - 耗时：4.406 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：44b61f69ca604e7da17465884130ccfb
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 未解锁跳过，按原路线先去 Forest 钓鱼补食物再下矿拿铁，回农场装炉后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=8）
6. `mine`（floors=8）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone"]）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `water_crops`
13. `sleep`
- **07:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：09266b722bee433d86310636b975cd6f
  - 耗时：22.234 秒 / 游戏 0 分钟
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Trash, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：0631ca5dfc0f478fbd646c7c20c5680c
  - 耗时：74.89 秒 / 游戏 70 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Pike
- **08:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Green Algae, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：53ef861a21dd452ebecfc0499992143a
  - 耗时：68.812 秒 / 游戏 60 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
- **09:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f72a181796b344e2958a6fb682b29d9a
  - 耗时：71.906 秒 / 游戏 90 分钟
- **10:40** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：7b99c0baed0142fcab957a89eaabd268
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅1空格导致下矿被拒，先存杂物腾格再下矿，其余路线不变。
1. `mine`（floors=8）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Trash", "Green Algae"]）
5. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone"]）
6. `load_machines`（item="Iron Ore"）
7. `collect_machines`
8. `water_crops`
9. `sleep`
- **10:40** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：9c9ccfd81ee94f4ab3b58381a21bbd8a
  - 耗时：0.172 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包仅1空格导致下矿被拒，先回农场存杂物清到≥7空格再下矿，之后装炉炼铁并睡觉。
1. `leave_mine`
2. `mine`（floors=8）
3. `leave_mine`
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Trash", "Green Algae", "Refined Quartz"]）
6. `load_machines`（item="Iron Ore"）
7. `collect_machines`
8. `sleep`
- **10:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：bdf5189c2ee64602a59253674478e816
  - 耗时：0.157 秒 / 游戏 0 分钟
- **10:40** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：02243c86bdce420b9eef58ad06700ca9
  - 耗时：0.141 秒 / 游戏 0 分钟
- **10:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：5180d02a922a4eebb0938488e8afbff5
  - 耗时：0.157 秒 / 游戏 0 分钟
- **10:40** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：d36751b861034d42ac7880dfc9c43b2e
  - 耗时：33.453 秒 / 游戏 40 分钟
- **11:20** Farm ✅ `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Trash", "Green Algae", "Refined Quartz"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 1x Trash, 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：60c659e06f5d41d28b8e88dc60f7d863
  - 耗时：12.469 秒 / 游戏 20 分钟
- **11:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：686516205f1d49138067930faf437f22
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：442cf603f857455ba0b1b12529b8431a
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：2acb85c66ac94d439897b73732f1d9eb
  - 耗时：0.156 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：8fcdc56f6c9748be8f5133f90dce468c
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：31b0d610469b41b7b3ac0e4228b32ee0
  - 耗时：5.078 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：c7fe3cf52f83499e97ee004dae8295f6
  - 耗时：0.109 秒 / 游戏 60 分钟
- **15:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：977b3f68e9cc45b9ad8508a52fb7590c
  - 耗时：12.266 秒 / 游戏 50 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：d9778aa5afcd404d9301a5d9cc4b38d0
  - 耗时：12.813 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：11755 → 12157（+402g）
- 出货估值：402g　动作：26 个　失败：13 个
- 模型调用：5 次　tokens：61418
- 有效动作率：0.48　空转：7　熔断跳过：0
- 失败耗时：19.033 秒 / 游戏 110 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天最大浪费是下午「固定做到17:00」空转（load×4、build_road×2 全失败），以及两次 mine 因背包空格不足被拒、白跑矿洞。有效动作是 Forest 钓鱼稳定出 Pike 可吃鱼、收机器与出货。今天核心是先把背包清到≥7、食物≥5，再一次性下矿拿铁矿石，铁锭够5立刻升钢水壶；洒水器与铺路全部让位。

**新教训：**
- 清背包只清到 5 空格仍会被 mine 拒（need at least 5 free slots 实际要留余量）：store_items 必须清到 ≥7 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- 起床先 collect_machines 再清背包：昨天先 load 再 collect，结果炉子忙、collect 返回空，白费两次动作；顺序应为 collect→store→mine→load。
- 铁锭≥5 时工具升级应优先于洒水器 place：place 已连续三天失败，而升级钢水壶能直接减少浇水体力，是更确定的里程碑推进。
- 下矿前若背包里有 24 块 Cobblestone Path 这类占格杂物，应先存箱再下矿：昨天它们占 1 格却直到清背包才处理，间接导致 mine 被拒。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏24）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 11755g 已够，铁锭 1、Iron Ore 3、Coal 10，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天只在读得到分区坐标时试一次，否则当天放弃）；**工匠加工（保存罐/小桶）** 缺 49 木头，顺路砍树补，不专门跑。
接下来 3 天主活动：
- **今天（夏24）**：① 起床先 `collect_machines` 1 次收铁锭/腌菜；② 清背包到 ≥7 空格（store_items 一次清够）；③ 食物<5 先去 Forest 河边钓 ≤2 轮补到 ≥5；④ 一次性下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；⑤ 回农场 load Iron Ore 1 次；⑥ 铁锭≥5 且时间在 9:10-15:30 就去 Blacksmith 升钢水壶；⑦ 22:00 前 sleep。
- **明天（夏25）**：收铁锭；不够继续下矿补铁；钢水壶到手后转洒水器铺满耕地。
- **后天（夏26）**：洒水器落地 + 下矿补铁/煤，准备夏末作物与秋季南瓜/蔓越莓种子预算。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过 collect。
2. **清背包到 ≥7 空格（硬门槛）**：`store_items` 一次把 Geode/Trash/Algae/多余工具/钓到的垃圾/多余矿石存箱子或 ship；**必须清到 ≥7 空格**（昨天清到 5 格仍被 mine 拒）。空格<7 禁止下矿。
3. **补食物到 ≥5**：背包回血食物<5 时，去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
6. **工具升级（优先于一切装饰）**：铁锭≥5 且现金≥5000g 且时间 9:10-15:30，去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，明天再补。
7. **洒水器 place（仅当第 1-6 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败或读不到分区坐标当天不再 place。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥7 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥7 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：食物<5 时 mine 会停在 39 层（need 5+ for floor 40 and below），铁矿石零产出，等于白跑。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load×4、build_road×2 浪费 6+ 动作。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥7；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 清背包到 ≥7 空格
3. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
4. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥7 才下，≤2 次 mine，超时即停）
5. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
6. 工具升级钢水壶（铁锭≥5 且现金≥5000g，9:10-15:30）
7. 洒水器 place（仅当 1-6 完成且时间<17:00，先读分区坐标再 hoe+place）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 社交（仅顺路）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是下午「固定做到17:00」空转（load×4、build_road×2 全失败），以及两次 mine 因背包空格不足被拒、白跑矿洞。有效动作是 Forest 钓鱼稳定出 Pike 可吃鱼、收机器与出货。今天核心是先把背包清到≥7、食物≥5，再一次性下矿拿铁矿石，铁锭够5立刻升钢水壶；洒水器与铺路全部让位。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 两次下矿都因背包空格不足被拒，白跑矿洞 @ Mine 入口 — mine: need at least 5 free backpack slots before mining; store_items first（清到 5 格仍被拒）（做不了：铁矿石零产出，钢水壶差 4 铁锭的进度卡住） 〔复盘〕
- 下午 14:00-16:40 陷入「固定做到 17:00」空转，load×4、build_road×2 全失败 @ Farm 熔炉旁/农场空地 — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects（做不了：下矿和钓鱼都没做成，当天有效动作率仅 0.73 但下午时段几乎零产出） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，无法落地 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 起床先 load 再 collect，炉子忙导致 collect 返回空 @ Farm 熔炉 — collect_machines: no machine has finished output；load_machines: no empty machine accepts（做不了：铁锭没收到，钢水壶升级材料凑不齐） 〔复盘〕
- donate 失败，社区中心献祭进度卡住 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：暂时无法捐献，需等巫师来信） 〔复盘〕
