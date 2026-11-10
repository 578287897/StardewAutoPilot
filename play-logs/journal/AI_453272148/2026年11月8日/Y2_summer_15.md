# 第2年 summer 15 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（04:07 开始）
- 天气：sunny　金钱：6218g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：4eb6e5adb7794b6d8dde3422cb5394ba
  - 耗时：4.968 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear Farmer AutoPilot, I'd like to give my wife a starfruit for our anniversary. Are you growing any on your farm? If you brought me one, I'd be very grateful.    -Kent [quest accepted]
  - 🗨️ [hud] New Journal Entry
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：73f120bea42b490386573eb1430758e6
  - 耗时：0.172 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_15）准备的脚本
- 里程碑：钢水壶（差4铁锭）——今天主活动下矿拿铁矿石+煤
- 洒水器落地（hoe清格+place，最多6次）
- 熔炉collect 1次后立刻load铁矿
- 清背包到≥7空格
- 补食物到≥5（Saloon 12:10后沙拉×5，只试1次）
- 下矿≤2次，目标铁矿石5+
- 回农场load铁矿1次
- 铁锭≥5且现金≥5000g则升钢水壶
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `place`（item="Sprinkler"）
5. `use_tool`（tool="hoe", x=54, y=16, times=1）
6. `place`（item="Sprinkler"）
7. `use_tool`（tool="hoe", x=55, y=16, times=1）
8. `place`（item="Sprinkler"）
9. `water_crops`
10. `harvest_crops`
11. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole"]）
12. `goto_location`（location="Town"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=5）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=10）
18. `mine`（floors=10）
19. `leave_mine`
20. `goto_location`（location="Farm"）
21. `load_machines`（item="Iron Ore"）
22. `upgrade_tool`（tool="watering can"）
23. `sleep`
- **06:00** Farm ✅ `harvest_crops`
  - 结果：inventory full after harvesting 6
  - 执行状态：SUCCESS · 操作编号：129d25adea0741d59fc68d195e76c530
  - 耗时：7.375 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Melon
  - 🗨️ [hud] Inventory Full
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 4 crops
  - 执行状态：SUCCESS · 操作编号：0a496881da3a46d88bb84cc37009d98a
  - 耗时：2.907 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~969g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：67c22bd2729e4b7fb66ae0249fb89974
  - 耗时：4.391 秒 / 游戏 10 分钟
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：f34a1347ec8d46f9b5d700c45dba62e0
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate因巫师信未到失败，跳过献祭分支，按原路线先放洒水器、清背包、买沙拉再下矿拿铁。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `place`（item="Sprinkler"）
4. `use_tool`（tool="hoe", x=54, y=16, times=1）
5. `place`（item="Sprinkler"）
6. `use_tool`（tool="hoe", x=55, y=16, times=1）
7. `place`（item="Sprinkler"）
8. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds"]）
9. `goto_location`（location="Town"）
10. `open_shop`（shop_id="Saloon"）
11. `buy`（item="Salad", count=5）
12. `close_menu`
13. `goto_location`（location="Mine"）
14. `mine`（floors=10）
15. `mine`（floors=10）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `load_machines`（item="Iron Ore"）
19. `sleep`
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f5e592fe7b264e8998d8f268b078cf50
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：cfc95229fb9c4ff7af0212ca9bb07a2b
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:20** Farm ✅ `use_tool`（tool="hoe", x=54, y=16, times=1）
  - 结果：used hoe 1x at (54,16)
  - 执行状态：SUCCESS · 操作编号：81ebe67950724731a413a66f01bf7c36
  - 耗时：6.719 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:20** Farm ✅ `use_tool`（tool="hoe", x=55, y=16, times=1）
  - 结果：used hoe 1x at (55,16)
  - 执行状态：SUCCESS · 操作编号：24ff0028f9f843d3a267a232416ee425
  - 耗时：3.562 秒 / 游戏 10 分钟
- **06:30** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ✅ `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds"]）
  - 结果：stored in chest at (74,15): 22x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：b2def02f580e4a0a8a1bfecb21b24ffa
  - 耗时：5.578 秒 / 游戏 10 分钟
- **06:40** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
  - 执行状态：SUCCESS · 操作编号：d2972eb5b7d342b49341b4a3ddb7ccf4
  - 耗时：11.203 秒 / 游戏 10 分钟
- **06:50** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 8:50 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：8ad9a45be5f74680ac40952b2fae1347
  - 耗时：85.031 秒 / 游戏 120 分钟
- **08:50** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 10:50 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：fdc2af434ae04e60bba595d1fd101dc9
  - 耗时：87.719 秒 / 游戏 120 分钟
- **10:50** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：b501fb48fd2143a1b2aa8a6a0a00fda3
  - 耗时：51.234 秒 / 游戏 70 分钟
- **12:00** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：ed2e5141ea5f41068a0932700bd4b8d7
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：Saloon 打不开已熔断，直接按优先级转下矿拿铁矿石，回农场装炉后睡觉。
1. `goto_location`（location="Mine"）
2. `mine`（floors=10）
3. `mine`（floors=10）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `load_machines`（item="Iron Ore"）
7. `sleep`
- **12:00** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：41fe67f45d614e9080400db6e440c560
  - 耗时：47.766 秒 / 游戏 60 分钟
- **13:00** Mine ❌ `mine`（floors=10）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：148c06f7c847423783411a2fb9bd04ba
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：下矿因背包空格不足失败，先存杂物腾到≥7格再下矿，其余路线不变。
1. `mine`（floors=10）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Silver Saber", "Bamboo Pole"]）
5. `load_machines`（item="Iron Ore"）
6. `sleep`
- **13:00** Mine ❌ `mine`（floors=10）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：c6cc36dd954042f396460886a85c2d94
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:00** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：ef7bb82678754483a88dd5d41d54a506
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：71243c0bc37e4586b8eb76278407d0be
  - 耗时：33.516 秒 / 游戏 40 分钟
- **13:40** Farm ✅ `store_items`（items=["Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Silver Saber", "Bamboo Pole"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7e82f621b8ea497fb36fc89d27ae33db
  - 耗时：11.531 秒 / 游戏 10 分钟
- **13:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **13:50** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：b58573cf7f7b4e2fae4f8a86616039b7
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：d948d45e6e02488f94d154890a90724e
  - 耗时：5.0 秒 / 游戏 10 分钟
- **14:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：381daebdd01847d2b54ec4b2a0bb1c48
  - 耗时：0.125 秒 / 游戏 0 分钟
- **14:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：49b0cb620f5440d3b9965d433adf93d5
  - 耗时：12.547 秒 / 游戏 20 分钟
- **14:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:20** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Joja Cola, Broken CD)
  - 执行状态：SUCCESS · 操作编号：7001c4b89d7e49e2acf9ccd8ea402618
  - 耗时：36.625 秒 / 游戏 50 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Joja Cola
- **15:10** Farm ✅ `ship`（item="Broken CD", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：f72fa74dbaee4aae80ec1e6b6233414f
  - 耗时：2.875 秒 / 游戏 0 分钟
- **15:10** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：34bdc79c31af4398afab0ef285c8fefb
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Trash, Trash)
  - 执行状态：SUCCESS · 操作编号：14e880ade4094e9c9c1e0d6807e98d90
  - 耗时：24.375 秒 / 游戏 30 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Trash
- **15:40** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：dc7168597d74475d91e76ef57356e8b7
  - 耗时：2.875 秒 / 游戏 10 分钟
- **15:40** Farm ✅ `ship`（item="Trash", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：b9c1e3df5e914f9781103aa877f3a296
  - 耗时：0.157 秒 / 游戏 0 分钟
- **15:50** Farm ✅ `wait`（minutes=70, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：c5306af0c1a3415abf84bd49e93ba632
  - 耗时：50.407 秒 / 游戏 70 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7161ac427840472fabf217e64114c75c
  - 耗时：6.812 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：6218 → 7212（+994g）
- 出货估值：969g　动作：40 个　失败：17 个
- 模型调用：5 次　tokens：63130
- 有效动作率：0.5833　空转：6　熔断跳过：2
- 失败耗时：18.829 秒 / 游戏 30 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天40动作17失败，核心浪费在：Saloon等3小时仍失败、背包满导致两次下矿被拒、洒水器hoe清格不在分区内、铺路/装饰空转。有效动作是出货969g和钓鱼补现金。今天必须把下矿拿铁放在绝对首位，所有非下矿动作让位。

**新教训：**
- Saloon 12:00 整 open_shop 连续两天失败，等店主就位浪费 3 小时：补食物一律改钓鱼吃鱼，不去 Saloon。
- 下矿前背包满导致两次 mine 被拒，等于白跑矿洞：下矿前必须 store_items 清到 ≥7 空格，且矿洞内背包满立即 ship_produce。
- 洒水器 hoe 清格 (54,16) 后 place 仍报无空位，说明清格坐标不在规划分区内：place 前必须先读分区坐标，读不到就当天放弃 place，不要反复 hoe。
- 现金 6218g 已够钢水壶，唯一卡点是铁锭：今天所有非下矿动作（钓鱼、装饰、铺路、社交）都应让位于下矿拿铁，铁锭不到 5 不碰其他分支。
- load_machines 返回「no empty machine accepts anything」时，若背包和箱子都没有可装矿石，调用必然失败：load 前先确认背包有 Iron Ore/Copper Ore，没有就跳过。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏16）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 6218g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点就是铁矿石和煤。
并行里程碑：**洒水器×4 落地**——已 craft 但连续三天没放下；今天若下矿前有余力，先读分区坐标再 hoe+place，否则让位于下矿。
之后：**下矿装备**（食物≥5、武器升级）→ 安全下 40 层以下稳定拿铁；再往后 **洒水器铺满 + 保存罐**。
接下来 3 天主活动：
- **今天（夏16）**：① 清背包≥7 空格；② 补食物到≥5（钓鱼吃鱼，不去 Saloon）；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场 load 铁矿 1 次；⑤ 22:00 前 sleep。
- **明天（夏17）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏18）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **清背包到 ≥7 空格（第一优先）**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
2. **补食物到 ≥5**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon**（连续两天 12:00 整 open_shop 失败，等店主就位浪费 3 小时）。
3. **下矿（主活动，今天绝对优先）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败当天不再 place。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **下矿是今天唯一主活动**：铁锭不到 5，钓鱼、装饰、铺路、社交全部让位；每 20 动作自检，若铁矿石增量=0 强制回矿洞或钓鱼补食物。
- **place 前先读分区坐标**：hoe 只清分区内格子；连续三天 hoe 了 (54,16) 仍 place 失败，说明坐标不在分区内，今天先读坐标再清，读不到就当天放弃 place。
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
- **禁止「固定做这个到 X 点」分支**：任何分支做完后若下一步失败，立即转钓鱼或提前 sleep，绝不固定时段空转。
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
1. 清背包到 ≥7 空格
2. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
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
> 昨天40动作17失败，核心浪费在：Saloon等3小时仍失败、背包满导致两次下矿被拒、洒水器hoe清格不在分区内、铺路/装饰空转。有效动作是出货969g和钓鱼补现金。今天必须把下矿拿铁放在绝对首位，所有非下矿动作让位。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:20 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 06:20 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:30 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 13:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 13:50 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 13:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- Saloon 等店主就位浪费 3 小时，open_shop 仍失败 @ Town / Saloon — open_shop 返回 can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)；脚本从 8:50 等到 12:00 共 3 次 wait（做不了：买沙拉补食物失败，食物不足导致下矿受限） 〔复盘〕
- 背包满导致两次下矿被拒，白跑矿洞 @ Mine 入口 — mine 返回 need at least 5 free backpack slots before mining; store_items first（做不了：当天完全没下矿，铁矿石零产出，钢水壶里程碑原地踏步） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败 @ Farm 耕地 — place 返回「分区无空位」；hoe 清 (54,16) 后 place 仍失败，说明清格坐标不在规划分区内（做不了：4 个洒水器放不下去，体力继续被手动浇水吃掉，拖慢下矿） 〔复盘〕
- 铺路/装饰分支空转 2 小时 @ Farm — build_road 返回 laid 0 tiles (24 skipped: blocked by trees/crops/objects)；decorate 返回「今天没有能做的装饰」（做不了：14:00-16:40 反复空转 load/build_road/decorate，浪费 10+ 动作） 〔复盘〕
- 熔炉 load 反复失败 @ Farm 熔炉 — load_machines 返回 no empty machine accepts anything in the backpack or the farm chests；背包和箱子都没有可装矿石（做不了：铁锭零产出，钢水壶差 4 铁锭无法推进） 〔复盘〕
- 钓鱼连续两轮只出垃圾 @ Farm 池塘/河边 — fish 返回 Broken CD、Joja Cola、Broken Glasses、Trash、Soggy Newspaper（做不了：现金兜底失败，浪费体力与时间） 〔复盘〕
