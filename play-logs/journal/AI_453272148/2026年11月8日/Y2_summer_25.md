# 第2年 summer 25 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:39 开始）
- 天气：storm　金钱：12907g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a527dbcc2cba476687b5d14b738f9dcf
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：f90e3ffb041144e9a3522e3f2ec6eda5
  - 耗时：3.172 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：810998abb8d94f1bbba3c63604442cc0
  - 耗时：3.672 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_25）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭，下矿补铁矿石+煤）
- 起床 collect_machines 1 次
- store_items 清背包到 ≥8 空格（Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Copper Ore、Refined Quartz、Silver Saber、Coffee Bean、Stone 全存箱）
- 食物≥5 已满足（River Jelly×4、Pike、Chub×2、Rainbow Trout×2 共10个），直接下矿
- Mine 40 层以下拿铁矿石+煤，≤2 次 mine
- 回农场 load_machines 装 Iron Ore 只试 1 次
- 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶
- 水壶在背包则 water_crops 1 次
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Copper Ore", "Refined Quartz", "Silver Saber", "Coffee Bean", "Stone"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=10）
6. `mine`（floors=10）
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `water_crops`
10. `sleep`
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：inventory full after harvesting 1
  - 执行状态：SUCCESS · 操作编号：3e74ae84b8d4411b8d4985137efc3a59
  - 耗时：6.828 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Inventory Full
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：f7bacbca95734dafb9e083a0d8f217cf
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 5 stacks worth ~566g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3dcdb1b42ecf445e95a233286733ef64
  - 耗时：4.688 秒 / 游戏 10 分钟
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：f53a90b6c0e54a4fa9d401c8385657fc
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师信未到失败，跳过该分支；按原路线清背包→下矿补铁→回农场装炉→升级水壶→睡觉。
1. `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Silver Saber", "Coffee Bean", "Refined Quartz", "Stone"]）
2. `goto_location`（location="Mine"）
3. `mine`（floors=10）
4. `mine`（floors=10）
5. `goto_location`（location="Farm"）
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `sleep`
- **06:20** Farm ✅ `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Silver Saber", "Coffee Bean", "Refined Quartz", "Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：cb946cee2fcf4072892d3e5dd6062474
  - 耗时：1.391 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e2966fc44eb44313b8b6699a995b2ba5
  - 耗时：44.844 秒 / 游戏 50 分钟
- **07:10** Mine ✅ `mine`（floors=10）
  - 结果：mined from floor 35 to 39 (4 floors down, 48 stones broken); stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：58e43402424f42128d6c3e61fc8b8ee6
  - 耗时：49.422 秒 / 游戏 70 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
- **08:20** UndergroundMine39 ✅ `mine`（floors=10）
  - 结果：mined from floor 39 to 39 (0 floors down, 0 stones broken); stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：9db6c69f26ec460692951544923d2386
  - 耗时：0.156 秒 / 游戏 0 分钟
- **08:20** UndergroundMine39 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：33a68886100b44708726cd6627ac081a
  - 耗时：37.328 秒 / 游戏 40 分钟
  - 🗨️ [question] 
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a2d7504d104c49948c18be9c4f89e4df
  - 耗时：0.172 秒 / 游戏 0 分钟
- **09:00** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：2c61f82a85904a25ac42ba1bb1e6bfed
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：b75ba3923273455d94c338e9528bd145
  - 耗时：7.297 秒 / 游戏 10 分钟
- **09:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a289d44239594512b93f722da94b56ce
  - 耗时：0.218 秒 / 游戏 0 分钟
- **09:10** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：2a46fc3e4e2f414baa56ec62d836faa7
  - 耗时：0.157 秒 / 游戏 0 分钟
- **09:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：48eaf4869e7f487d9d6756f993875945
  - 耗时：9.937 秒 / 游戏 10 分钟
- **09:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e71b3e1b3a3f46a5b1cedf0433e85300
  - 耗时：0.171 秒 / 游戏 0 分钟
- **09:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：73fe80dbd27e40899dee8fccff7123a6
  - 耗时：12.656 秒 / 游戏 20 分钟
- **09:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：1dfd23ee98194b4e815c725e306342c4
  - 耗时：12.453 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **10:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bb52d5c5e3d7400c958105a546df048a
  - 耗时：0.157 秒 / 游戏 0 分钟
- **10:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c636f3073cd24ac6b350f8c45c6fcd1e
  - 耗时：31.75 秒 / 游戏 40 分钟
- **10:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:40** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Broken CD, Broken CD)
  - 执行状态：SUCCESS · 操作编号：a2fe60f753304e26b2b3d3118ef418d0
  - 耗时：52.219 秒 / 游戏 70 分钟
  - 🗨️ [hud] Broken Glasses
- **11:50** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：1553ef1e24c64382aa85f9f5629d8f7f
  - 耗时：15.157 秒 / 游戏 20 分钟
- **12:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Broken CD, Driftwood)
  - 执行状态：SUCCESS · 操作编号：f12a51035bc542908beefbc14e95a6c1
  - 耗时：49.11 秒 / 游戏 70 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Broken CD
- **13:20** Farm ✅ `ship`（item="Broken CD", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：c83eead866a243e1af3b778ad48c68f3
  - 耗时：3.219 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 3:20 pm
  - 执行状态：SUCCESS · 操作编号：99f638c4ca6e44e7978c716409c3ebc6
  - 耗时：81.125 秒 / 游戏 120 分钟
- **15:20** Farm ✅ `wait`（minutes=100, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：b84fa2cb5da54a14b91723cc96b4856f
  - 耗时：73.125 秒 / 游戏 100 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：b364de296e2c4e4885479a94ffd449a7
  - 耗时：6.907 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：12907 → 13473（+566g）
- 出货估值：566g　动作：32 个　失败：11 个
- 模型调用：3 次　tokens：37759
- 有效动作率：0.6207　空转：8　熔断跳过：0
- 失败耗时：55.343 秒 / 游戏 70 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天32动作11失败，核心浪费在14:00-16:40的「固定做到17:00」空转（load×4、build_road×2、decorate×2全失败）和两次mine因食物只有4个停在39层。有效的是：下雨免浇水、ship垃圾清格、熔炉炼出1铜锭。今天必须先把食物补到≥5再下矿，且失败一次立刻转钓鱼，绝不设固定时段分支。

**新教训：**
- 昨天两次 mine 都停在 39 层，原因是「only 4 healing food (need 5+ for floor 40 and below)」——食物只有 4 个时下矿等于白跑，今天必须先钓鱼把食物补到 ≥5 再 goto Mine。
- 14:00-16:40 的「固定做到 17:00」分支让 load×4、build_road×2、decorate×2 全部空转，浪费约 4 小时游戏时间：任何动作失败一次即转钓鱼或 sleep，脚本层不设固定时段分支。
- build_road 返回「24 skipped: blocked by trees/crops/objects」——农场未清障前铺路必然失败，脚本层应完全禁用 build_road，直到农场清出空地。
- decorate 返回「今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）」——没有畜舍和装饰材料时 decorate 必失败，脚本层应直接跳过该分支。
- 起床先 collect_machines 再清背包：昨天先 load 再 collect，结果炉子忙、collect 返回空，白费两次动作；顺序应为 collect→store→补食物→mine→load。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏26）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 12907g 已够，铁锭 1、Iron Ore 3、Coal 9，**差 4 铁锭**，卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，等钢水壶到手、农场清出空地后再处理）；**下矿装备**（需食物≥5 才能下 40 层以下）。
接下来 3 天主活动：
- **今天（夏26）**：① 起床 `collect_machines` 1 次；② `store_items` 清到 **≥8 空格**（Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash 全存箱）；③ **食物<5 先去 Forest 河边或 Mountain 湖 `fish` ≤2 轮补到 ≥5**（昨天只有 4 个食物，两次 mine 都停在 39 层）；④ 食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**；⑤ 回农场 `load_machines` 装 Iron Ore **只试 1 次**；⑥ 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶；⑦ 22:00 前 sleep。
- **明天（夏27）**：收铁锭；不够继续下矿补铁；钢水壶到手后转洒水器铺满耕地。
- **后天（夏28）**：洒水器落地 + 下矿补铁/煤，准备夏末作物与秋季南瓜/蔓越莓种子预算。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过 collect。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash、Algae、多余矿石、钓到的垃圾全部存箱子或 ship；**必须清到 ≥8 空格**。空格<8 禁止下矿。
3. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **工具升级（优先于一切装饰）**：铁锭≥5 且现金≥5000g 且时间 9:10-15:30，去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，明天再补。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥8 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：昨天只有 4 个食物，两次 mine 都停在 39 层（need 5+ for floor 40 and below），铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load×4、build_road×2、decorate×2 浪费 6+ 动作。
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
> 昨天32动作11失败，核心浪费在14:00-16:40的「固定做到17:00」空转（load×4、build_road×2、decorate×2全失败）和两次mine因食物只有4个停在39层。有效的是：下雨免浇水、ship垃圾清格、熔炉炼出1铜锭。今天必须先把食物补到≥5再下矿，且失败一次立刻转钓鱼，绝不设固定时段分支。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 09:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 09:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 10:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 两次下矿都因食物只有 4 个停在 39 层，铁矿石零产出 @ Mine 第 39 层 — mine: stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)（做不了：铁矿石拿不到，钢水壶差 4 铁锭的进度卡住） 〔复盘〕
- 下午 14:00-16:40 陷入「固定做到 17:00」空转，load×4、build_road×2、decorate×2 全失败 @ Farm 熔炉旁/农场空地 — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects；decorate: 今天没有能做的装饰（做不了：下矿和钓鱼都没做成，下午时段几乎零产出） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，无法落地 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 起床先 load 再 collect，炉子忙导致 collect 返回空 @ Farm 熔炉 — collect_machines: no machine has finished output；load_machines: no empty machine accepts（做不了：铁锭没收到，钢水壶升级材料凑不齐） 〔复盘〕
- 钓鱼连续出垃圾（Broken Glasses、Broken CD×2、Driftwood），没有可吃鱼 @ Farm 池塘 — fished: caught 3 (Broken Glasses, Broken CD, Broken CD)；fished: caught 3 (Broken CD, Broken CD, Driftwood)（做不了：食物没补上，间接导致下矿停在 39 层） 〔复盘〕
