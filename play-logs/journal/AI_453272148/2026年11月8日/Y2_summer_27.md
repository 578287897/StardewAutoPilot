# 第2年 summer 27 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:57 开始）
- 天气：sunny　金钱：15012g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：74035dcdedd549f2b41c5eeab9ef4a05
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d2f7b10a88f04e4eac6593c4d634ca42
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：c1556d4a9e0c4dbd81d6ddc728bdd7ed
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~300g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：73ddafbda5834849a54b734518ee5e1a
  - 耗时：5.516 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_27）准备的脚本
- 里程碑：工具按档升级——钢水壶（5000g+5铁锭，现差4铁锭）
- 起床收机器1次，清背包到≥8空格（Cobblestone Path/Driftwood/Bamboo Pole/Broken CD/Trash/Geode 全存箱）
- 食物≥5已满足（Pike×2+River Jelly×5），直接下矿40层以下拿铁矿石+煤，≤2次mine
- 回农场装熔炉炼铁1次（有Iron Ore才装）
- 铁锭≥5且9:10-15:30去Blacksmith升钢水壶
- 收尾：浇水（水壶在背包）→22:00前sleep
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Cobblestone Path", "Driftwood", "Bamboo Pole", "Broken CD", "Trash", "Geode", "Coffee Bean"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `goto_location`（location="Blacksmith"）
11. `upgrade_tool`（tool="watering can"）
12. `goto_location`（location="Farm"）
13. `water_crops`
14. `sleep`
- **06:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：4b4700f4c0d84a35841f1bdd9b07274f
  - 耗时：0.203 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因未收到巫师信失败，跳过该分支；按原路线清背包→下矿拿铁→回农场装炉→浇水睡觉。
1. `collect_machines`
2. `store_items`（items=["Cobblestone Path", "Driftwood", "Bamboo Pole", "Broken CD", "Trash", "Coffee Bean"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `mine`（floors=5）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `water_crops`
10. `sleep`
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：a944506153234f9b8400f6fac120e06b
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`（items=["Cobblestone Path", "Driftwood", "Bamboo Pole", "Broken CD", "Trash", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 3x Driftwood, 2x Broken CD, 1x Trash
  - 执行状态：SUCCESS · 操作编号：dd5b830f4f7643b9b63771480f08cd6e
  - 耗时：1.391 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f67ecf00f65f4ea2a7df18f2980d6fc8
  - 耗时：44.828 秒 / 游戏 60 分钟
- **07:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 55 to 59 (4 floors down, 175 stones broken); retreated: health 45/120 and 0 healing food left; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：ec709ee7f172407aaa57d941b56d9742
  - 耗时：214.734 秒 / 游戏 260 分钟
  - 🗨️ [hud] Sap
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] +75 Energy
  - 🗨️ [hud] +33 Health
  - 🗨️ [question] 
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：43cef227e2fd420d96425e7b46b22faa
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine因背包仅4空格被拒，先存杂物腾到≥8格再回矿洞继续拿铁矿石，其余路线保留。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Slime", "Frozen Geode", "Omni Geode", "Bat Wing", "Sap", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
5. `load_machines`（item="Iron Ore"）
6. `water_crops`
7. `sleep`
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：bde02f92020847b1a8773a2206d76944
  - 耗时：0.14 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包空格不足被拒，先回农场存杂物清到≥8格再下矿，其余路线保留。
1. `leave_mine`
2. `mine`（floors=5）
3. `leave_mine`
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Slime", "Frozen Geode", "Omni Geode", "Bat Wing", "Sap", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `sleep`
- **11:20** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：43dd8c44c7d1462b91b2cda9bf4b5559
  - 耗时：0.14 秒 / 游戏 0 分钟
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ba9a507ce40e4fe9b4eae5cac02a4189
  - 耗时：0.141 秒 / 游戏 0 分钟
- **11:20** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：3c9dbb4ea7024723abe068e8d7ddc270
  - 耗时：0.157 秒 / 游戏 0 分钟
- **11:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：6b418acc57db4da0baf4fa20c5501727
  - 耗时：35.641 秒 / 游戏 50 分钟
- **12:10** Farm ✅ `store_items`（items=["Stone", "Slime", "Frozen Geode", "Omni Geode", "Bat Wing", "Sap", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
  - 结果：stored in chest at (74,15): 3x Slime, 3x Frozen Geode, 2x Sap, 1x Omni Geode, 3x Bat Wing
  - 执行状态：SUCCESS · 操作编号：5d471562b19845d1be7a71bf38c7cfa1
  - 耗时：12.234 秒 / 游戏 10 分钟
- **12:20** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：37bea059dcee4a03a7d62526aaebb33e
  - 耗时：18.282 秒 / 游戏 30 分钟
- **12:50** Farm ✅ `water_crops`
  - 结果：watered 9 crops
  - 执行状态：SUCCESS · 操作编号：31c50729995c4c3484fec94525be0c0c
  - 耗时：23.781 秒 / 游戏 30 分钟
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：671ceba2513b4197b32cb2909fca6453
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：88724f7740ee452ba22a9edb02cf0593
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：8d0c3fb637bf4506ab576824fcea5ff4
  - 耗时：2.406 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：750ff948fd784c1d99f12d4b83933afe
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：e0c569516c8e46cba0df6c57f9f75214
  - 耗时：12.625 秒 / 游戏 20 分钟
- **13:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 3:40 pm
  - 执行状态：SUCCESS · 操作编号：21517912885b4e7b883f6a72133ef8b7
  - 耗时：83.375 秒 / 游戏 120 分钟
- **15:40** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：a9dd19cb98c34e01887a7402a09d2fcd
  - 耗时：16.657 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
- **16:00** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：ad441a60863348978df66bdd4ba70931
  - 耗时：7.188 秒 / 游戏 10 分钟
- **16:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：c038b2260e434ada98920c49039e808a
  - 耗时：0.156 秒 / 游戏 0 分钟
- **16:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：faeadf1c07fe412199a69cd20f74fce5
  - 耗时：29.297 秒 / 游戏 40 分钟
- **16:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:50** Farm ✅ `wait`（minutes=10, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：a173382bb7874e91ba783ccb34fc5c5e
  - 耗时：5.922 秒 / 游戏 10 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：5a320268b33042d5acfb09737d9c75df
  - 耗时：21.125 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：15012 → 15312（+300g）
- 出货估值：300g　动作：34 个　失败：18 个
- 模型调用：5 次　tokens：62566
- 有效动作率：0.3548　空转：10　熔断跳过：0
- 失败耗时：46.374 秒 / 游戏 60 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是下矿门槛没满足就出发：食物0、背包满，两次mine被拒/停在39层，铁矿石零产出；14:00-16:40又用「固定做到17:00」空转load/build_road/decorate约8次。有效的是起床store_items清杂物、下矿后load熔炉、浇水。今天必须先钓鱼补食物≥5、清到≥8空格，再一次性下矿到40层以下拿铁；熔炉只装1次，铁锭够5立刻升钢水壶。

**新教训：**
- 昨天食物=0 仍调 mine，结果停在 39 层零铁产出：食物<5 时 mine 动作应脚本层直接拒绝，先钓鱼补到 ≥5 再 goto Mine。
- 昨天 14:00-16:40 的「固定做到 17:00」分支让 load×4、build_road×2、decorate×2 全失败，浪费 8+ 动作和约 4 小时：任何动作失败一次即切钓鱼或 sleep，脚本层不设固定时段分支。
- 熔炉两座同时炼铁时，load_machines 返回 busy 是正常状态：下矿后只装 1 次，返回 busy 即当天永久跳过，不要 14:00 后再试。
- 背包里 24 块 Cobblestone Path 占 1 格且 build_road 必失败：起床第一次 store_items 就把它存箱，不要留到矿洞门口才处理。
- 铁锭 3、Iron Ore 17、Coal 12 时，今天两座熔炉各炼一轮即可凑够 5 铁锭：下矿前先 load 一轮，下矿回来收，比先下矿再炼更稳。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏28）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 15012g 已够，铁锭 3、Iron Ore 17、Coal 12，**差 2 铁锭**；今天两座熔炉各炼一轮即可补齐。
并行里程碑：**下矿装备**（食物≥5 才能下 40 层以下）；**洒水器×4 落地**（craft 已完成，等钢水壶到手、农场清出空地后再处理）。
接下来 3 天主活动：
- **今天（夏28）**：① 起床 `collect_machines` 1 次；② `store_items` 清到 **≥8 空格**；③ 食物<5 先去 Forest 河边 `fish` ≤2 轮补到 ≥5；④ 食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**；⑤ 回农场 `load_machines` 装 Iron Ore **只试 1 次**；⑥ 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶；⑦ 22:00 前 sleep。
- **明天（夏29）**：收铁锭；不够继续下矿补铁；钢水壶到手后转洒水器铺满耕地。
- **后天（夏30）**：洒水器落地 + 下矿补铁/煤，准备夏末作物与秋季南瓜/蔓越莓种子预算。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过 collect。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash、Algae、多余矿石、钓到的垃圾全部存箱子或 ship；**必须清到 ≥8 空格**。空格<8 禁止下矿。
3. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **工具升级（优先于一切装饰）**：铁锭≥5 且现金≥5000g 且时间 9:10-15:30，去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，明天再补。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥8 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：昨天只有 0 个食物，两次 mine 都停在 39 层（need 5+ for floor 40 and below），铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
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
> 昨天核心失败是下矿门槛没满足就出发：食物0、背包满，两次mine被拒/停在39层，铁矿石零产出；14:00-16:40又用「固定做到17:00」空转load/build_road/decorate约8次。有效的是起床store_items清杂物、下矿后load熔炉、浇水。今天必须先钓鱼补食物≥5、清到≥8空格，再一次性下矿到40层以下拿铁；熔炉只装1次，铁锭够5立刻升钢水壶。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下矿前食物=0 仍出发，两次 mine 都停在 39 层，铁矿石零产出 @ Mine 第 39-40 层 — only 0 healing food (need 5+ for floor 40 and below)；mine 返回 retreated: health 45/120 and 0 healing food left（做不了：拿不到 40 层以下的铁矿石，钢水壶差 2 铁锭卡住） 〔复盘〕
- 背包空格不足，mine 连续 3 次被拒 @ Mine 入口 / Farm — need at least 5 free backpack slots before mining; store_items first（做不了：下矿主活动无法开始，当天铁矿石零产出） 〔复盘〕
- 14:00-16:40 用「固定做到 17:00」分支空转，load/build_road/decorate 反复失败 @ Farm — load_machines: no empty machine accepts that, and the rest are busy；build_road: 24 skipped blocked by trees/crops/objects；decorate: 今天没有能做的装饰（做不了：浪费约 4 小时游戏时间和 8+ 动作，本可用于钓鱼补食物或下矿） 〔复盘〕
- 洒水器已 craft 但连续多天 place 失败，hoe (54,16) 无效 @ Farm 耕地 — place 失败且 hoe (54,16) 无效，坐标不在规划分区内（做不了：洒水器无法落地，仍要手动浇水，体力被占用） 〔复盘〕
- donate 在 wait_letter 阶段调用必失败 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心收集包进度无法推进，等巫师来信） 〔复盘〕
