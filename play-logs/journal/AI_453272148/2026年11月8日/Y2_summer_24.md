# 第2年 summer 24 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:28 开始）
- 天气：sunny　金钱：12157g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7d0c0323a8e644b89c6d5d2dba429e8e
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：559574c35dcb48f2afd6cb61153c1270
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：0f72efddcbd848e5b97da72ba3d5a90f
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~750g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：8b1beaef8d5041bba465382e1beed77e
  - 耗时：5.453 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_24）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭，靠下矿拿铁矿石+煤）
- 起床先 collect_machines 一次，再清背包到≥7空格
- 食物已够9个，直接下矿40层以下拿铁矿石+煤（≤2次mine）
- 回农场 load Iron Ore 一次（仅炉空且背包有矿）
- 铁锭≥5且时间9:10-15:30去Blacksmith升钢水壶
- 剩余时间Forest河边钓鱼补现金/食物，22:00前sleep
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=8）
6. `mine`（floors=8）
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `goto_location`（location="Blacksmith"）
10. `upgrade_tool`（tool="watering_can"）
11. `goto_location`（location="Forest"）
12. `fish`（casts=4）
13. `fish`（casts=4）
14. `sleep`
- **06:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：70e276f3b4c04ada9fc6880e3be3cadb
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：去掉无法执行的 donate，保留原路线：收机器→清背包→下矿拿铁→升级钢水壶→钓鱼→回农场装炉→睡觉。
1. `collect_machines`
2. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=8）
5. `mine`（floors=8）
6. `goto_location`（location="Blacksmith"）
7. `upgrade_tool`（tool="watering_can"）
8. `goto_location`（location="Forest"）
9. `fish`（casts=4）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `sleep`
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：ade65eb9f35840638a1cbc2ba5a3f2b7
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：cf0131f0bf0c41ca87104c040a202cf9
  - 耗时：1.375 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：7b73962bc844434283c933a012eac8b5
  - 耗时：44.797 秒 / 游戏 60 分钟
- **07:00** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：50d0ace117304e18a4e83a9e72b9746a
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：先清背包到≥7空格再下矿拿铁矿石，回农场装炉后去铁匠铺升钢水壶，剩余时间森林钓鱼。
1. `mine`（floors=8）
2. `mine`（floors=8）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="watering_can"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore", "Silver Saber"]）
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **07:00** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：654e52df91d3409a9568722fca3dbc3e
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：先清背包到≥7空格再下矿拿铁矿石，回农场装炉后视铁锭去升钢水壶，剩余时间森林钓鱼，22点前睡。
1. `mine`（floors=8）
2. `mine`（floors=8）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="watering_can"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore", "Silver Saber", "Coffee Bean"]）
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **07:00** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：76893e9f112a45b08b6dc5630ca73bac
  - 耗时：0.141 秒 / 游戏 0 分钟
- **07:00** Mine ❌ `mine`（floors=8）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：98f04c3fd93c421286c5cc69c65add04
  - 耗时：0.203 秒 / 游戏 0 分钟
- **07:00** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：3d2665ad93914ed39905144fa06c9934
  - 耗时：85.562 秒 / 游戏 120 分钟
- **09:00** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：1d4f4b6fe87d4a749fc4bd56c649d35e
  - 耗时：47.046 秒 / 游戏 50 分钟
- **09:50** Blacksmith ❌ `upgrade_tool`（tool="watering_can"）
  - 结果：Steel Watering Can needs 5x Iron Bar, you have 1 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：8229d60500da492ab5efd85c005c5b55
  - 耗时：0.203 秒 / 游戏 0 分钟
- **09:50** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：a195bc082822457aae81bb7eaf6d563f
  - 耗时：28.063 秒 / 游戏 40 分钟
- **10:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Sunfish, Pike, Chub)
  - 执行状态：SUCCESS · 操作编号：1f867b9e7dff46079191e948891b0fee
  - 耗时：85.156 秒 / 游戏 70 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Pike
- **11:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Dorado, Chub, River Jelly, Rainbow Trout)
  - 执行状态：SUCCESS · 操作编号：528dd783f82c459bbd306f4a1576fa4c
  - 耗时：68.579 秒 / 游戏 50 分钟
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
  - 🗨️ [hud] Chub
  - 🗨️ [hud] River Jelly
- **12:30** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：e53cca3c4f724f519ffaf672f35bf5bd
  - 耗时：15.172 秒 / 游戏 20 分钟
- **12:50** Farm ✅ `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Refined Quartz", "Copper Ore", "Silver Saber", "Coffee Bean"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：b27fcee19d2a492faa33cd1755437a68
  - 耗时：21.813 秒 / 游戏 30 分钟
- **13:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：eb739f2d45664e93807f5522fc191e3b
  - 耗时：0.157 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：8762b8bd2bbf4ac395d4a3748518fbed
  - 耗时：0.172 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：f6ddfaa86c574f9aa25b73fcbe1cd72f
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：f6ddfaa86c574f9aa25b73fcbe1cd72f
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：d81e1256ce0f4a50aa4b0f28e910dea6
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：d81e1256ce0f4a50aa4b0f28e910dea6
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Soggy Newspaper, Trash)
  - 执行状态：SUCCESS · 操作编号：77d78327e930467a87e6ed3effafffc4
  - 耗时：31.703 秒 / 游戏 40 分钟
- **14:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Broken CD, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：edaf44437bdf4ceb9eb773dd590bf7d2
  - 耗时：50.218 秒 / 游戏 70 分钟
  - 🗨️ [hud] You've used your last 
piece of bait. 
- **15:10** Farm ✅ `wait`（minutes=110, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：887d24f1b78d41309a1c666fb45c664f
  - 耗时：76.188 秒 / 游戏 110 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c2982a9fadd9404b8cb5f646ac3cad9e
  - 耗时：8.593 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：12157 → 12907（+750g）
- 出货估值：750g　动作：32 个　失败：16 个
- 模型调用：7 次　tokens：61304
- 有效动作率：0.4286　空转：6　熔断跳过：0
- 失败耗时：2.205 秒 / 游戏 0 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是背包满导致4次mine被拒、下午空转load/build_road/decorate。铁锭仍差4，钢水壶未升。洒水器place连续失败应放弃。今天核心：起床先collect→一次清背包到≥8空格→下矿拿铁矿石，失败即转Forest钓鱼，绝不设固定时段分支。

**新教训：**
- store_items 清背包必须清到 ≥8 空格再 goto Mine：昨天清到 5 格仍被「need at least 5 free backpack slots」拒，留余量才能一次下矿成功。
- 背包里有 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds 这类占格杂物时，应在起床后第一次 store_items 就全部存箱，不要留到矿洞门口才处理。
- 洒水器 place 连续三天失败且 hoe (54,16) 无效，说明该坐标不在规划分区内：今天完全禁用 place/hoe 试探，把时间全给下矿，等钢水壶到手后再处理。
- load_machines 返回「no empty machine accepts」时炉子忙或没矿可装，当天最多试 2 次（起床后 1 次、下矿后 1 次），失败即永久跳过，不设「做到 17:00」分支。
- 下矿前食物<5 时 mine 会停在 39 层（need 5+ for floor 40 and below），铁矿石零产出：今天必须先钓鱼补到 ≥5 再下矿，否则等于白跑。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏25）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 12157g 已够，铁锭 1、Iron Ore 3、Coal 10，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**——已 craft 但连续三天 place 失败，今天**完全放弃 place 分支**，把时间全给下矿；等钢水壶到手、农场清出空地后再处理。
接下来 3 天主活动：
- **今天（夏25）**：① 起床 `collect_machines` 1 次；② `store_items` 一次清到 **≥8 空格**（把 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、多余矿石全部存箱）；③ 食物<5 先去 Forest 河边钓 ≤2 轮补到 ≥5；④ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；⑤ 回农场 `load_machines` 装 Iron Ore **只试 1 次**；⑥ 铁锭≥5 且时间 9:10-15:30 去 Blacksmith 升钢水壶；⑦ 22:00 前 sleep。
- **明天（夏26）**：收铁锭；不够继续下矿补铁；钢水壶到手后转洒水器铺满耕地。
- **后天（夏27）**：洒水器落地 + 下矿补铁/煤，准备夏末作物与秋季南瓜/蔓越莓种子预算。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过 collect。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash、Algae、多余矿石、钓到的垃圾全部存箱子或 ship；**必须清到 ≥8 空格**（昨天清到 5 格仍被 mine 拒，留余量）。空格<8 禁止下矿。
3. **补食物到 ≥5**：背包回血食物<5 时，去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **工具升级（优先于一切装饰）**：铁锭≥5 且现金≥5000g 且时间 9:10-15:30，去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，明天再补。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥8 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
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
- **洒水器 place 今天禁用**：连续三天 place 失败且 hoe (54,16) 无效，今天不调 place/hoe 试探，把时间全给下矿。
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
6. 工具升级钢水壶（铁锭≥5 且现金≥5000g，9:10-15:30）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是背包满导致4次mine被拒、下午空转load/build_road/decorate。铁锭仍差4，钢水壶未升。洒水器place连续失败应放弃。今天核心：起床先collect→一次清背包到≥8空格→下矿拿铁矿石，失败即转Forest钓鱼，绝不设固定时段分支。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 07:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Watering Can needs 5x Iron Bar, you have 1 (backpack + chests) 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:20 动作 `craft` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 13:20 动作 `craft` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 13:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 两次下矿都因背包空格不足被拒，白跑矿洞 @ Mine 入口 — mine: need at least 5 free backpack slots before mining; store_items first（清到 5 格仍被拒）（做不了：铁矿石零产出，钢水壶差 4 铁锭的进度卡住） 〔复盘〕
- 下午 14:00-16:40 陷入「固定做到 17:00」空转，load×4、build_road×2 全失败 @ Farm 熔炉旁/农场空地 — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects（做不了：下矿和钓鱼都没做成，下午时段几乎零产出） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，无法落地 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 起床先 load 再 collect，炉子忙导致 collect 返回空 @ Farm 熔炉 — collect_machines: no machine has finished output；load_machines: no empty machine accepts（做不了：铁锭没收到，钢水壶升级材料凑不齐） 〔复盘〕
- donate 失败，社区中心献祭进度卡住 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：暂时无法捐献，需等巫师来信） 〔复盘〕
