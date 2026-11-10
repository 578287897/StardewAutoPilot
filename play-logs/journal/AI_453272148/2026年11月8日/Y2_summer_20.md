# 第2年 summer 20 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:54 开始）
- 天气：sunny　金钱：8033g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：71472c98ae6f4520abfcf1f9e5812386
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：c5ef837dc626421da28f2094de0d6f84
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：f6888df2f9254baf9d07884460a736b8
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~250g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：063a4bc7af0e4e84baea6b1036370209
  - 耗时：5.468 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_20）准备的脚本
- 里程碑：工具按档升级——钢水壶（差 4 铁锭，今天下矿拿铁矿石+煤）
- 先清背包到 ≥7 空格，再下矿 40 层以下拿铁矿石
- 回农场装熔炉炼铁，铁锭够 5 就去铁匠铺升钢水壶
- 顺路收作物、浇水（今天下雨不用浇）
1. `donate`
2. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Copper Ore", "Green Algae"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `mine`（floors=5）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `harvest_crops`
11. `goto_location`（location="Town"）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="watering can"）
14. `goto_location`（location="Farm"）
15. `sleep`
- **06:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：b03adf185fa8490eb27fd9636029a4aa
  - 耗时：0.188 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 未解锁（等巫师来信），跳过献祭分支；按原路线清背包→下矿拿铁→回农场装炉收炉→收作物→睡觉，去掉失败受影响的铁匠铺升级（铁锭不足 5）。
1. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Copper Ore", "Green Algae"]）
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `leave_mine`
6. `goto_location`（location="Farm"）
7. `load_machines`（item="Iron Ore"）
8. `collect_machines`
9. `harvest_crops`
10. `sleep`
- **06:00** Farm ✅ `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Copper Ore", "Green Algae"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：6693d1ddde2c4328b5866260687aa6d5
  - 耗时：1.422 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：ba807a6a686d4bf4b697190050fa80ce
  - 耗时：45.485 秒 / 游戏 60 分钟
  - 🗨️ [hud] The Annual Trout 
Derby has begun. 
- **07:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 35 to 39 (4 floors down, 30 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：08e4bdbadca64c978da2644c5fa35ca7
  - 耗时：29.516 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Quartz
  - 🗨️ [hud] Copper Ore
- **07:30** UndergroundMine39 ✅ `mine`（floors=5）
  - 结果：mined from floor 39 to 39 (0 floors down, 0 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：e31d1716f3394976b41d7b63c3399736
  - 耗时：0.141 秒 / 游戏 0 分钟
- **07:30** UndergroundMine39 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：6eb3bb7b9fe540c8b13a23cf8ea1321f
  - 耗时：1.828 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **07:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：82199dd5922d41daa51fe74ebbe2d541
  - 耗时：35.64 秒 / 游戏 50 分钟
- **08:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4e553c1ad7ea491782351166e4af34bd
  - 耗时：0.187 秒 / 游戏 0 分钟
- **08:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6eb08ad2a11d451ba8d06de2e4edea41
  - 耗时：0.156 秒 / 游戏 0 分钟
- **08:20** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 11
  - 执行状态：SUCCESS · 操作编号：fedd511aaef945c09f6bbbe92df5115e
  - 耗时：10.016 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Melon
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Inventory Full
- **08:30** Farm ✅ `load_machines`
  - 结果：loaded: Hops -> Preserves Jar (ready in 4000 min), Quartz -> Furnace (ready in 90 min), Hops -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：e9bc758929d54c7cb76cd4914313f10f
  - 耗时：9.297 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **08:40** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：e8d40df68b07407ca7a0c766dfe47356
  - 耗时：3.547 秒 / 游戏 0 分钟
- **08:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：0c2b64d496134c3bbd96ba933dff0c33
  - 耗时：0.125 秒 / 游戏 0 分钟
- **08:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：6d8a5eccc4fd40f5b379a5f58c7d8c73
  - 耗时：6.797 秒 / 游戏 10 分钟
- **08:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：97b79da7092b4a168fb3c8bdd5a481f4
  - 耗时：12.625 秒 / 游戏 20 分钟
- **09:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：6e2256a14c11468a9d23d96d87feff48
  - 耗时：7.906 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **09:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：65beac64f7e24039a58f8fdc18a23857
  - 耗时：0.157 秒 / 游戏 0 分钟
- **09:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：fa9cca6aac334c4f81a6d40a7c1fdbf2
  - 耗时：27.469 秒 / 游戏 40 分钟
- **10:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Broken Glasses, Driftwood)
  - 执行状态：SUCCESS · 操作编号：0363ceff08f142d78f881888e9fc9ff4
  - 耗时：30.5 秒 / 游戏 40 分钟
  - 🗨️ [hud] Trash
- **10:40** Farm ✅ `ship`（item="Trash", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：e7c2401223e841219640ee97552e97c1
  - 耗时：15.156 秒 / 游戏 20 分钟
- **11:00** Farm ✅ `collect_machines`
  - 结果：collected: Refined Quartz from Furnace
  - 执行状态：SUCCESS · 操作编号：52380c741e5f4f199ba8368ad2207f78
  - 耗时：13.281 秒 / 游戏 20 分钟
  - 🗨️ [hud] Refined Quartz
- **11:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：411ba53a66694fbdb3c9b50d3f1a9ab9
  - 耗时：0.329 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：7500434b03124d6eab7320262fa743dd
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：9c563e594e284ceab711c776c0779562
  - 耗时：25.797 秒 / 游戏 30 分钟
- **11:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：8ec8af18efb54951b2b2b49a56e942f1
  - 耗时：0.141 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：3b6f8eac6c8340abb636b082b4f83ea1
  - 耗时：0.156 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Soggy Newspaper, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：1320d62acea547c6adf4d4814a5744b9
  - 耗时：29.453 秒 / 游戏 40 分钟
- **12:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 2:30 pm
  - 执行状态：SUCCESS · 操作编号：ea9616790a314289975fef40f6f6aad1
  - 耗时：82.156 秒 / 游戏 120 分钟
- **14:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 4:30 pm
  - 执行状态：SUCCESS · 操作编号：b6d5824914724908adf0cd78a5eec14e
  - 耗时：87.719 秒 / 游戏 120 分钟
- **16:30** Farm ✅ `wait`（minutes=30, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：01a955a773b84a6d87e6cf937318cb70
  - 耗时：22.047 秒 / 游戏 30 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：eae3f5de95cd4954b5264d981b46edfd
  - 耗时：18.0 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：8033 → 8283（+250g）
- 出货估值：250g　动作：39 个　失败：16 个
- 模型调用：3 次　tokens：36714
- 有效动作率：0.4857　空转：13　熔断跳过：0
- 失败耗时：74.282 秒 / 游戏 100 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是脚本里“固定做到17:00”的分支，让 load/build_road/decorate 反复空转约4小时；下矿因食物不足只到39层，铁矿石几乎零产出，钢水壶仍差4铁锭。洒水器已 craft 但连续三天 place 失败，应暂时搁置。今天应把全部体力压在下矿拿铁上，食物不足先去 Forest 河边钓鱼补齐，失败一次立即转产，绝不设固定时段分支。

**新教训：**
- 昨天两次 mine 都停在 39 层，原因是「only 3 healing food (need 5+ for floor 40 and below)」——下矿前食物必须 ≥5，否则只能停在 40 层门口，铁矿石零产出。
- 洒水器已 craft 但连续三天 place 失败，说明问题不在 craft 而在坐标：今天若读不到规划分区坐标，直接放弃 place 分支，把时间全给下矿，不要用 hoe 试探。
- 昨天 14:00-16:40 的「固定做到 17:00」分支让 load×5、build_road×3、decorate×4 全部空转，浪费约 4 小时；任何动作失败一次即转钓鱼或 sleep，脚本层不设固定时段分支。
- Farm 池塘钓鱼连续出 Trash/Broken Glasses/Driftwood，而 Forest 河边能出可吃鱼：补食物和现金兜底一律去 Forest 河边或 Mountain 湖，Farm 池塘当天不再钓。
- 昨天 harvest_crops 返回「inventory full after harvesting 11」——收获前先清背包到 ≥7 空格，否则作物收一半就卡住，还得再跑一趟。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏21）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 8033g 已够，铁锭 1、Iron Ore 3、Coal 13，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天只在读得到分区坐标时做一次，读不到当天放弃）→ **保存罐**（Wood 还差 49，需先砍树/攒木头）。
接下来 3 天主活动：
- **今天（夏21）**：① 食物<5 先去 Forest 河边钓鱼补到 ≥5（≤2 轮）；② 清背包到 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场装炉炼铁 1 次；⑤ 22:00 前 sleep。
- **明天（夏22）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏23）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **补食物到 ≥5（第一优先）**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
2. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
3. **下矿（主活动）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时或空格被拒一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败或读不到分区坐标当天不再 place。
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
> 昨天最大浪费是脚本里“固定做到17:00”的分支，让 load/build_road/decorate 反复空转约4小时；下矿因食物不足只到39层，铁矿石几乎零产出，钢水壶仍差4铁锭。洒水器已 craft 但连续三天 place 失败，应暂时搁置。今天应把全部体力压在下矿拿铁上，食物不足先去 Forest 河边钓鱼补齐，失败一次立即转产，绝不设固定时段分支。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 08:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 08:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 09:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 10:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下矿两次都停在 39 层，铁矿石几乎零产出 @ Mine 39 层 — mine 返回「stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)」（做不了：钢水壶还差 4 铁锭，今天仍无法升级） 〔复盘〕
- 脚本「固定做到 17:00」分支让失败动作反复空转 @ Farm — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops；decorate: 今天没有能做的装饰（做不了：14:00-16:40 约 4 小时游戏时间被浪费，下矿和钓鱼都没做成） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 铺路材料 craft 后全部被树木/作物挡住 @ Farm — laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：24 块 Cobblestone Path 白 craft，浪费石头和时间） 〔复盘〕
- 收获作物时背包满 @ Farm 耕地 — harvest_crops: inventory full after harvesting 11（做不了：作物没收完，需再跑一趟清背包） 〔复盘〕
- donate 在 wait_letter 阶段调用失败 @ 社区中心 — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心献祭暂时无法推进，需等巫师来信） 〔复盘〕
- Farm 池塘钓鱼连续出垃圾 @ Farm 池塘 — fished: caught 3 (Trash, Broken Glasses, Driftwood)（做不了：补食物和现金兜底效率极低，应改去 Forest 河边或 Mountain 湖） 〔复盘〕
