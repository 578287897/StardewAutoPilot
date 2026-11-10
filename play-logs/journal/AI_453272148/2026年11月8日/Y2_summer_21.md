# 第2年 summer 21 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（05:03 开始）
- 天气：sunny　金钱：8283g　体力：270/270
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
  - 执行状态：SUCCESS · 操作编号：284554e36f3a4e4cb2e5726c1644d327
  - 耗时：4.953 秒 / 游戏 0 分钟
  - 🗨️ [mail] AutoPilot, I need truffle oil. Don't ask me why.  -Mayor Lewis [quest accepted]
  - 🗨️ [hud] New Journal Entry
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：0476d8c12d4a4fb0802fa5f5cde99d35
  - 耗时：0.157 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：490f68b1348b42df8cde4e0094f32875
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Coal
  - 执行状态：SUCCESS · 操作编号：1e584fd26dcd457db69c470d0b5aac03
  - 耗时：2.406 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 9 crops
  - 执行状态：SUCCESS · 操作编号：372f12ac9a3f44d8aab5b92ca583cad5
  - 耗时：11.234 秒 / 游戏 10 分钟
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Hops

## 🌙 为明天（Y2_summer_21）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭，靠下矿拿铁矿石+煤）
- 早上先收熔炉产物、装铁矿石，再清背包到≥7空格
- 去矿洞40层以下拿铁矿石和煤（食物25个充足，可下到79层）
- 回农场装炉炼铁，若铁锭≥5且时间在15:30前则去铁匠铺升钢水壶
- 傍晚浇水、收获成熟作物并出货
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Dwarf Scroll I", "Refined Quartz"]）
5. `harvest_crops`
6. `ship_produce`
7. `goto_location`（location="Mine"）
8. `mine`（floors=10）
9. `mine`（floors=10）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `collect_machines`
14. `water_crops`
15. `goto_location`（location="Town"）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="watering can"）
18. `goto_location`（location="Farm"）
19. `sleep`
- **06:10** Farm ❌ `water_crops`
  - 结果：could not reach (40,3); stopped at (54,9)
  - 执行状态：ACTION_FAILED · 操作编号：f0e16ed4d3ca4f36add6d50e71847827
  - 耗时：16.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：水壶浇水失败（走不到40,3），放弃浇水；背包0空格先出货+存材料清格，然后按计划下矿拿铁，回农场装炉炼铁后睡觉。
1. `ship_produce`
2. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rusty Sword", "Refined Quartz", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `sleep`
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 5 stacks worth ~2730g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：8be42f35ea6e461ca1b39fdea1b86e49
  - 耗时：4.734 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rusty Sword", "Refined Quartz", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：7f789afbf9dd456d90790f7ea9ad7170
  - 耗时：1.062 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：23a900dee7a24c34b42d6f5562edfc10
  - 耗时：76.687 秒 / 游戏 70 分钟
- **07:20** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 35 to 39 (4 floors down, 108 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：4c748f7024f54f13842f8583323b4a59
  - 耗时：147.672 秒 / 游戏 200 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
- **10:40** UndergroundMine39 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：c359e057f2ad4720a65f691d6bbda95b
  - 耗时：0.157 秒 / 游戏 0 分钟
- **10:40** UndergroundMine39 ✅ `mine`（floors=5）
  - 结果：mined from floor 39 to 39 (0 floors down, 0 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：fe5302691e9844a6b959aa3d6fcdfaba
  - 耗时：0.14 秒 / 游戏 0 分钟
- **10:40** UndergroundMine39 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：c0eff6aba637438c87d824d6eeed7c00
  - 耗时：1.843 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **10:40** Mine ❌ `mine`（floors=10）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b02e29bc4fdf42c49641a0f4f2d42a03
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：上次mine因背包空格不足被拒，先存材料清格；食物仅3个不足40层，先去Forest河边钓鱼补食物，再回矿洞拿铁，最后回农场装炉炼铁并浇水睡觉。
1. `mine`（floors=5）
2. `fight`（range=6）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Geode", "Stone", "Copper Ore", "Refined Quartz", "Dwarf Scroll I"]）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `water_crops`
13. `sleep`
- **10:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5b9bb5e598ff4ce9a0494c4fbd055805
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包仅3格被拒，先出矿回农场存材料清格并收炉装铁，再按食物不足去Forest钓鱼补食物，最后浇水睡觉。
1. `leave_mine`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Geode", "Copper Ore", "Refined Quartz", "Dwarf Scroll I", "Coal"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `water_crops`
10. `sleep`
- **10:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：51ccaef1389a4486938ca565290b1331
  - 耗时：0.156 秒 / 游戏 0 分钟
- **10:40** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：ffeb08f1bd3843e984a4a831c9258c36
  - 耗时：59.125 秒 / 游戏 80 分钟
- **12:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Rainbow Trout, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：7025ff09eaf6471c960718a5b073ab5e
  - 耗时：79.031 秒 / 游戏 60 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Sunfish
- **13:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Sunfish, Rainbow Trout, Sunfish)
  - 执行状态：SUCCESS · 操作编号：afb8ee3ff8b243b3b90a6163237d3660
  - 耗时：61.719 秒 / 游戏 40 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Rainbow Trout
- **13:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：ff89cd8622c54b27a5a351e8ec3b98db
  - 耗时：15.156 秒 / 游戏 20 分钟
- **14:00** Farm ✅ `store_items`（items=["Stone", "Geode", "Copper Ore", "Refined Quartz", "Dwarf Scroll I", "Coal"]）
  - 结果：stored in chest at (74,15): 2x Geode, 3x Coal
  - 执行状态：SUCCESS · 操作编号：54f6f416923140ae82fa2d333db2acd9
  - 耗时：21.796 秒 / 游戏 30 分钟
- **14:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **14:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：abd205cd9951410fade654ea7c941ba9
  - 耗时：0.172 秒 / 游戏 0 分钟
- **14:30** Farm ✅ `water_crops`
  - 结果：watered 1 crops
  - 执行状态：SUCCESS · 操作编号：d365d7395b434857968ca1b653ad51af
  - 耗时：11.453 秒 / 游戏 20 分钟
- **14:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：b8c36689c7fa4c1db4b7391988fafb46
  - 耗时：13.531 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：8283 → 11013（+2730g）
- 出货估值：2730g　动作：25 个　失败：8 个
- 模型调用：5 次　tokens：61605
- 有效动作率：0.6957　空转：3　熔断跳过：1
- 失败耗时：17.392 秒 / 游戏 0 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天两次下矿都停在39层，原因是食物只有3个（下40层需5+），铁矿石零产出，钢水壶仍差4铁锭；背包空格不足又导致两次mine被拒。洒水器连续三天place失败，问题在坐标而非craft。14:00后load/collect空转浪费约4小时。今天必须先钓鱼补食物到≥5、清背包到≥7，再一口气下矿到40层以下拿铁。

**新教训：**
- 下矿前食物<5 时 mine 会停在 39 层（need 5+ for floor 40 and below），铁矿石零产出：今天必须先钓鱼补到 ≥5 再下矿，否则等于白跑。
- 昨天两次 mine 被拒都是「need at least 5 free backpack slots」，而清背包只清到 5 格仍不够：store_items 必须清到 ≥7 空格再 goto Mine。
- 14:00 后 load/collect 反复空转（炉子忙或没矿可装）浪费约 4 小时：下矿后 load 只试 1 次，失败即转钓鱼或 sleep，不设「做到 17:00」分支。
- 洒水器连续三天 place 失败且 hoe (54,16) 无效，说明该坐标不在规划分区内：今天读不到分区坐标就直接放弃 place，把时间全给下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏22）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 8283g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天只在读得到分区坐标时做一次，读不到当天放弃）→ **保存罐**（Wood 还差 49，需先砍树/攒木头）。
接下来 3 天主活动：
- **今天（夏22）**：① 食物<5 先去 Forest 河边钓鱼补到 ≥5（≤2 轮）；② 清背包到 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场装炉炼铁 1 次；⑤ 22:00 前 sleep。
- **明天（夏23）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏24）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

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
- **下矿前食物≥5 是硬门槛**：昨天两次 mine 都停在 39 层「only 3 healing food」，等于白跑；今天钓鱼补到 ≥5 之前不调 mine。
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
> 昨天两次下矿都停在39层，原因是食物只有3个（下40层需5+），铁矿石零产出，钢水壶仍差4铁锭；背包空格不足又导致两次mine被拒。洒水器连续三天place失败，问题在坐标而非craft。14:00后load/collect空转浪费约4小时。今天必须先钓鱼补食物到≥5、清背包到≥7，再一口气下矿到40层以下拿铁。
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:10 动作 `water_crops` 失败 @ Farm — could not reach (40,3); stopped at (54,9) 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 14:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 两次下矿都停在 39 层，铁矿石几乎零产出，钢水壶仍差 4 铁锭 @ Mine 39 层 — mine 返回「stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)」（做不了：钢水壶无法升级，铁锭进度卡住） 〔复盘〕
- 背包空格不足导致两次 mine 被拒，白跑矿洞 @ Mine 入口 — mine 返回「need at least 5 free backpack slots before mining; store_items first」（做不了：下矿主活动无法执行） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 14:00 后 load/collect 反复空转，浪费约 4 小时游戏时间 @ Farm 熔炉旁 — load_machines: no empty machine accepts；collect_machines: no machine has finished output（做不了：下矿和钓鱼都没做成，当天有效动作率仅 0.49） 〔复盘〕
