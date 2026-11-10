# 第2年 summer 17 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:26 开始）
- 天气：sunny　金钱：7212g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：86e3619f553740e8b64ae8d635058cf9
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：f06b15ead9f84c55a7823adebc78dcbf
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：26f3920c8d284f8bb2c5f0a0f13a1ab9
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~421g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：f8811b4b4002473bbd6282de187293a0
  - 耗时：5.641 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_17）准备的脚本
- 里程碑：钢水壶（差 4 铁锭）——今天主活动下矿拿铁矿石+煤
- 清背包到 ≥7 空格（存 Geode/Trash/杂物/多余工具）
- 补食物到 ≥5（现有 9 个回血食物，够下矿）
- 下矿 40 层以下拿铁矿石+煤，≤2 次 mine，超时即停
- 回农场 load 铁矿 1 次（先确认背包有 Iron Ore）
- collect_machines 1 次
- 铁锭≥5 且现金≥5000g 则 9:10-15:30 升钢水壶
- 体力<15 或 22:00 前 sleep
1. `donate`
2. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=10）
5. `mine`（floors=10）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `water_crops`
11. `sleep`
- **06:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：df3acc32696c4b3bbc5a614bf86d3806
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate未解锁跳过，按原路线清背包后下矿拿铁，回农场装炉收炉浇水睡觉。
1. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
2. `goto_location`（location="Mine"）
3. `mine`（floors=10）
4. `mine`（floors=10）
5. `leave_mine`
6. `goto_location`（location="Farm"）
7. `load_machines`（item="Iron Ore"）
8. `collect_machines`
9. `water_crops`
10. `sleep`
- **06:00** Farm ✅ `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：163c3b43856c4083a68f579bbc94e33e
  - 耗时：1.5 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a8870e444ef6485482102f20555b2cb7
  - 耗时：46.063 秒 / 游戏 60 分钟
- **07:00** Mine ✅ `mine`（floors=10）
  - 结果：mined from floor 15 to 19 (4 floors down, 12 stones broken); stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：a7aabaa2eaf4421089fedc2aaca6dd6a
  - 耗时：25.406 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
- **07:30** UndergroundMine19 ✅ `mine`（floors=10）
  - 结果：mined from floor 19 to 19 (0 floors down, 0 stones broken); stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：0f38d8bcbef341199df9f25c5e2ade61
  - 耗时：0.141 秒 / 游戏 0 分钟
- **07:30** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：ab6795c5ab104b0ea64175b35a0a7acc
  - 耗时：1.813 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **07:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：335d253d73f2461e837be86088fea351
  - 耗时：35.641 秒 / 游戏 40 分钟
- **08:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bf079672f824449fa98b3384c1f739e2
  - 耗时：0.14 秒 / 游戏 0 分钟
- **08:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：4717caf0778d4813bf8dc254e778f751
  - 耗时：0.141 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `water_crops`
  - 结果：watered 4 crops
  - 执行状态：SUCCESS · 操作编号：b18a8425f3dd47b2aa510c5f23488dfc
  - 耗时：8.797 秒 / 游戏 10 分钟
- **08:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：cd2b732fd1134081b39564eb2cd415f7
  - 耗时：0.109 秒 / 游戏 0 分钟
- **08:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：24843c7e9ae14841841c9e4805715ee5
  - 耗时：0.125 秒 / 游戏 0 分钟
- **08:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：b0aa9cd5e18848969c1562bddf25ef2c
  - 耗时：2.141 秒 / 游戏 10 分钟
- **08:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：040320ec8a5344429816b314744dee16
  - 耗时：0.172 秒 / 游戏 0 分钟
- **08:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3dee6dc80b284e69957581e7cc083ba1
  - 耗时：12.594 秒 / 游戏 10 分钟
- **08:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **08:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **08:40** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Trash, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：6077d3a486834dc3b46c3579713be80c
  - 耗时：29.969 秒 / 游戏 40 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Trash
- **09:20** Farm ✅ `ship`（item="Broken CD", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：2505ac48edfe4bc8860b940a5ac476db
  - 耗时：2.875 秒 / 游戏 10 分钟
- **09:20** Farm ✅ `ship`（item="Trash", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：9298aaafcdd54bd7a5166566bc70d4fd
  - 耗时：0.172 秒 / 游戏 0 分钟
- **09:20** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：9d05cdb6611049879cb2c28eb9dd7200
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:30** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Joja Cola, Driftwood)
  - 执行状态：SUCCESS · 操作编号：4a9cfd6c7ac448ccade4161d92e987bf
  - 耗时：33.266 秒 / 游戏 40 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Joja Cola
- **10:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：2aee255b82b9487985e33f3eac8e0d09
  - 耗时：0.172 秒 / 游戏 0 分钟
- **10:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：8ffeed3993534896a755979ace9be45c
  - 耗时：23.578 秒 / 游戏 40 分钟
- **10:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 12:50 pm
  - 执行状态：SUCCESS · 操作编号：f2d4c6bfdef94fff8c5bf23524eecd92
  - 耗时：87.172 秒 / 游戏 120 分钟
- **12:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 2:50 pm
  - 执行状态：SUCCESS · 操作编号：b2440ee93e7c406b9b5653b8a378f328
  - 耗时：87.75 秒 / 游戏 120 分钟
- **14:50** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 4:50 pm
  - 执行状态：SUCCESS · 操作编号：3f6705c225a541be99390722ae7c1eba
  - 耗时：87.718 秒 / 游戏 120 分钟
- **16:50** Farm ✅ `wait`（minutes=10, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：25ae3ef81f3648eaa152038e4330c45d
  - 耗时：7.469 秒 / 游戏 10 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：11fe0328c54848c3994beffc26cc9d56
  - 耗时：21.172 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：7212 → 7658（+446g）
- 出货估值：421g　动作：35 个　失败：14 个
- 模型调用：3 次　tokens：37211
- 有效动作率：0.4667　空转：11　熔断跳过：0
- 失败耗时：39.61 秒 / 游戏 60 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是下午「固定做这个到17:00」空转：load×5、build_road×3、decorate×4 全失败，还 wait 了 4 次；下矿只到 19 层就因食物不足退出，铁矿石零产出。核心问题不是缺钱（7212g 够），而是食物<5 导致下不了 40 层，以及失败后没有立即转产。今天必须先补食物再下矿，失败一次即切钓鱼，禁止 wait/铺路/装饰。

**新教训：**
- 食物<5 时下矿只能到 19 层就退出，等于白跑：下矿前必须先钓鱼把食物补到 ≥5，再 goto Mine。
- 「固定做这个到 17:00」分支会让失败动作反复空转（昨天 load×5、build_road×3、decorate×4 全失败）：任何动作失败一次即切钓鱼或 sleep，不设固定时段分支。
- wait(filler) 在 12:50-16:50 连续 4 次共浪费 4 小时游戏时间：主活动做完直接 sleep 或转钓鱼，脚本层禁用 wait。
- craft 铺路材料前先确认目标地块已清空：昨天 24 块 Cobblestone Path 全部被树木/作物挡住 skipped，craft 本身就是浪费。
- 下矿前 store_items 清背包必须清到 ≥7 空格，且清完后立刻 goto Mine；昨天清到 5 空格仍被拒，白跑矿洞两次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏18）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 7212g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**下矿装备**——食物只有 4 个，不够下 40 层以下；今天第一优先是把食物补到 ≥5（钓鱼吃鱼，不去 Saloon），再下矿。
之后：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天先读分区坐标再 hoe+place，读不到就放弃）→ **保存罐**（Wood 还差 49）。
接下来 3 天主活动：
- **今天（夏18）**：① 先钓鱼补食物到 ≥5（Forest 河边或 Mountain 湖，≤2 轮）；② 清背包 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场 load 铁矿 1 次（确认背包有 Iron Ore）；⑤ 22:00 前 sleep。
- **明天（夏19）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏20）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **补食物到 ≥5（第一优先，今天必须先做）**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon**（连续两天 12:00 整 open_shop 失败）。食物≥5 才允许下矿。
2. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
3. **下矿（主活动，今天绝对优先）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败当天不再 place。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天食物优先于一切**：食物<5 时禁止下矿，先钓鱼补食物；下矿是今天唯一主活动，铁锭不到 5，钓鱼、装饰、铺路、社交全部让位。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load/build_road/decorate 浪费 10+ 动作。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥7**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<7 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：连续两天 12:00 整 open_shop 失败，等店主就位浪费 3 小时；补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach；去 Beach 会因节日锁门或位置错误失败。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续三天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
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
1. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
2. 清背包到 ≥7 空格
3. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥7 才下，≤2 次 mine，超时即停）
4. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
5. 熔炉 collect（仅 1 次，空即跳）
6. 洒水器 place（仅当 1-5 完成且时间<17:00，先读分区坐标再 hoe+place）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
10. 社交（仅顺路）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是下午「固定做这个到17:00」空转：load×5、build_road×3、decorate×4 全失败，还 wait 了 4 次；下矿只到 19 层就因食物不足退出，铁矿石零产出。核心问题不是缺钱（7212g 够），而是食物<5 导致下不了 40 层，以及失败后没有立即转产。今天必须先补食物再下矿，失败一次即切钓鱼，禁止 wait/铺路/装饰。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 08:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 08:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 08:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 10:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 10:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 食物只有 4 个，不够下 40 层以下，下矿只到 19 层就退出，铁矿石零产出 @ Mine 19 层 — mine 返回 only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：钢水壶差 4 铁锭，里程碑原地踏步） 〔复盘〕
- 下午「固定做这个到 17:00」分支反复空转 load/build_road/decorate 并 wait 4 次 @ Farm — load_machines 返回 no empty machine accepts anything；build_road 24 格全部 skipped；decorate 返回今天没有能做的装饰；wait 填充 12:50-16:50（做不了：14:00-16:40 浪费 10+ 动作和 4 小时游戏时间，没有推进任何里程碑） 〔复盘〕
- 熔炉 load 失败后没有可装矿石，仍反复调用 5 次 @ Farm 熔炉 — load_machines 返回 no empty machine accepts anything in the backpack or the farm chests（做不了：铁锭零产出，钢水壶差 4 铁锭） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，hoe 清 (54,16) 后仍报无空位 @ Farm 耕地 — place 返回「分区无空位」；hoe 清格坐标不在规划分区内（做不了：4 个洒水器放不下去，体力继续被手动浇水吃掉，拖慢下矿） 〔复盘〕
- 下矿前背包没清够，两次 mine 被拒，白跑矿洞 @ Mine 入口 — mine 返回 need at least 5 free backpack slots before mining; store_items first（做不了：当天完全没下矿，铁矿石零产出） 〔复盘〕
