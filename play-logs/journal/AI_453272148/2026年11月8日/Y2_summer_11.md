# 第2年 summer 11 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（03:26 开始）
- 天气：sunny　金钱：4402g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y2_summer_11）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭+约600g）
- 第一件事：hoe清一格耕地后放下4个洒水器
- collect熔炉1次，炉空立刻load铁矿5块
- 清背包≥5空格后下矿40层以下拿铁矿+煤（≤2次mine）
- 回农场load铁矿1次
- 现金<700g去Forest河边钓鱼≤2轮
- 买鱼饵（先清≥3空格，16:30前）
- 22:00前sleep
1. `goto_location`（location="Beach"）
2. `festival`（activity="soup"）
3. `use_tool`（tool="hoe", x=54, y=16, times=1）
4. `place`（item="Sprinkler"）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Cobblestone Path", "Bamboo Pole"]）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `load_machines`（item="Iron Ore"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `fish`（casts=4）
19. `goto_location`（location="Town"）
20. `goto_location`（location="Mountain"）
21. `open_shop`（shop_id="FishShop"）
22. `buy`（item="Bait", count=20）
23. `close_menu`
24. `goto_location`（location="Farm"）
25. `water_crops`
26. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0e564f8e29014944a0a506d1d30d257a
  - 耗时：17.297 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：b49d32b0d5c647739cf3afba3c346741
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 16 crops
  - 执行状态：SUCCESS · 操作编号：39c4ea5fcd2f491d95fd20f0abb47706
  - 耗时：21.016 秒 / 游戏 30 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~185g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：773da7ecb2b245b58d05ba3e571d7f09
  - 耗时：6.313 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `goto_location`（location="Beach"）
  - 结果：exit to Beach did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：1b74d9f73b374b28a0086c13672837f5
  - 耗时：40.141 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：
1. `festival`（activity="soup"）
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mountain"）
9. `open_shop`（shop_id="FishShop"）
10. `buy`（item="Bait", count=20）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `use_tool`（tool="hoe", x=51, y=14, times=1）
14. `place`（item="Sprinkler"）
15. `place`（item="Sprinkler"）
16. `place`（item="Sprinkler"）
17. `place`（item="Sprinkler"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Bamboo Pole", "River Jelly"]）
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **07:40** Town ❌ `festival`（activity="soup"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：2d02cec159084a8c8b296ffd65f779a2
  - 耗时：0.141 秒 / 游戏 0 分钟
- **07:40** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：8a189edff03945949b633b2c3aeb72e9
  - 耗时：49.5 秒 / 游戏 70 分钟
- **08:50** Mine ❌ `mine`（floors=5）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：2c7c63f28d9c4d6abb812239c091eef8
  - 耗时：8.797 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] The Luau has begun 
at the beach. 
  - 🗨️ [hud] This area is infested... 

### 🔁 脚本重写：重写#2：16层无石无梯，先清怪再下3层拿铁矿，回农场放洒水器、装炉、钓鱼补现金并买鱼饵。
1. `fight`（range=6）
2. `fight`（range=6）
3. `mine`（floors=3）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mountain"）
9. `open_shop`（shop_id="FishShop"）
10. `buy`（item="Bait", count=20）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `use_tool`（tool="hoe", x=51, y=14, times=1）
14. `place`（item="Sprinkler"）
15. `place`（item="Sprinkler"）
16. `place`（item="Sprinkler"）
17. `place`（item="Sprinkler"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Bamboo Pole", "River Jelly", "Stone"]）
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **09:00** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：b51426cefad14823bb5bc4f0c23c2102
  - 耗时：20.0 秒 / 游戏 30 分钟
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Dwarf Scroll I
  - 🗨️ [hud] Sap
- **09:30** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：3b02ea69166149f1bae655948e658991
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:30** UndergroundMine16 ✅ `mine`（floors=3）
  - 结果：mined from floor 16 to 16 (0 floors down, 0 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：29c5713c91b64af7b5fb0e7b93a5b914
  - 耗时：5.656 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **09:30** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：a47b34d1a5c64364b6ff4166083f5187
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞已自动退出，先回农场清格放下4个洒水器并收/装熔炉，再Forest钓鱼补现金、买鱼饵后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mountain"）
5. `open_shop`（shop_id="FishShop"）
6. `buy`（item="Bait", count=20）
7. `close_menu`
8. `goto_location`（location="Farm"）
9. `use_tool`（tool="hoe", x=51, y=14, times=1）
10. `place`（item="Sprinkler"）
11. `place`（item="Sprinkler"）
12. `place`（item="Sprinkler"）
13. `place`（item="Sprinkler"）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Bamboo Pole", "River Jelly", "Stone", "Slime", "Green Algae", "Sap", "Dwarf Scroll I"]）
17. `load_machines`（item="Iron Ore"）
18. `sleep`
- **09:30** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：f825f17d6ac8488f94abe53b84a636f4
  - 耗时：59.156 秒 / 游戏 80 分钟
- **10:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Dorado, Sunfish, Sunfish, Chub)
  - 执行状态：SUCCESS · 操作编号：e7da5eaa38ed4263914dbb39659a4ead
  - 耗时：90.844 秒 / 游戏 80 分钟
  - 🗨️ [hud] Dorado
- **12:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Green Algae, Chub, Sunfish)
  - 执行状态：SUCCESS · 操作编号：5d1462412b4141379d7b00070732d120
  - 耗时：71.922 秒 / 游戏 60 分钟
  - 🗨️ [hud] Green Algae
- **13:10** Forest ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：c4c03d21c79c4b459c3c7d3d6c587763
  - 耗时：45.969 秒 / 游戏 60 分钟
- **14:10** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：63fc556c065341d0a40a00229faf72b7
  - 耗时：0.141 秒 / 游戏 0 分钟
- **14:10** Mountain ❌ `buy`（item="Bait", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：284f63711d4543c3be2bedbd1ebb4e73
  - 耗时：0.141 秒 / 游戏 0 分钟
- **14:10** Mountain ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：95b5d9424b544a00b3364566fa71c90c
  - 耗时：0.157 秒 / 游戏 0 分钟
- **14:10** Mountain ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b44fbf283b434a78b95b02656480d5e8
  - 耗时：24.156 秒 / 游戏 30 分钟
- **14:40** Farm ✅ `use_tool`（tool="hoe", x=51, y=14, times=1）
  - 结果：used hoe 1x at (51,14)
  - 执行状态：SUCCESS · 操作编号：f67650f868ed46cc8ffc45acf1665f6f
  - 耗时：6.609 秒 / 游戏 10 分钟
- **14:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **14:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **14:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **14:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **14:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c1b25d7020474cf4818f68ffa62133c6
  - 耗时：0.156 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：c41d2b406d8e4bbcab6241de81e06873
  - 耗时：0.125 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Bamboo Pole", "River Jelly", "Stone", "Slime", "Green Algae", "Sap", "Dwarf Scroll I"]）
  - 结果：stored in chest at (74,15): 8x Slime, 3x Green Algae, 1x Sap
  - 执行状态：SUCCESS · 操作编号：d99d21f348984f2db26877f9df8f2793
  - 耗时：6.453 秒 / 游戏 10 分钟
- **15:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：93e012cdcfcb4cf6be357c302f0b21d9
  - 耗时：0.14 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：b49d3e3d341847fdabe97c53c5fe5792
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：7fbb1a6ca1484fa59bc3f1b8cf170024
  - 耗时：5.063 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a0ceb25eb1314c0abcd2c5d396d55d0c
  - 耗时：0.125 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：daaa591b587b4639b328352c14593c8e
  - 耗时：12.562 秒 / 游戏 20 分钟
- **15:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:20** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Trash, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：cdc828ece0104e169a722b77f859d65a
  - 耗时：60.359 秒 / 游戏 80 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Trash
- **16:40** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：15bde654ef5c4b4b8fccbf2f1fdef740
  - 耗时：3.141 秒 / 游戏 10 分钟
- **16:40** Farm ✅ `ship`（item="Trash", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：9c622687ff1146578b5eaa9f6db86d2d
  - 耗时：0.141 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Broken Glasses, Driftwood)
  - 执行状态：SUCCESS · 操作编号：39e3071b491b4a80ad68097346ecb269
  - 耗时：42.546 秒 / 游戏 60 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Broken Glasses
- **17:50** Farm ✅ `ship`（item="Broken Glasses", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：134bd0badc814181b46f942408429669
  - 耗时：2.891 秒 / 游戏 0 分钟
- **17:50** Farm ✅ `ship`（item="Driftwood", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Driftwood (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：c4fa06b1f13e4ad0bbfafec2cd1b9ecf
  - 耗时：0.156 秒 / 游戏 0 分钟
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：e38c9a890b114cdf9e96a90a2231fa2b
  - 耗时：6.906 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4402 → 4587（+185g）
- 出货估值：185g　动作：43 个　失败：20 个
- 模型调用：5 次　tokens：62583
- 有效动作率：0.5385　空转：7　熔断跳过：3
- 失败耗时：67.971 秒 / 游戏 80 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天43动作失败20，核心浪费在14:00-16:40的固定空转（load/build_road/decorate反复失败）和洒水器place无空位。有效动作是Forest钓鱼8条和熔炉collect。铁锭零产出、洒水器未落地、钢水壶原地踏步。今天必须：先hoe清格放洒水器、collect后立刻load铁矿、下矿前清背包≥5空格、FishShop在Mountain走对入口、任何分支失败即转钓鱼，禁止固定时段空转。

**新教训：**
- FishShop 在 Mountain 地图（15,40 附近），不在 Beach：去 Beach 会因节日锁门或位置错误失败，买鱼饵前先 goto Mountain。
- 任何分支做完后若下一步失败，立即转钓鱼或提前 sleep，绝不「固定做这个到 17:00」：昨天 14:00-16:40 反复空转 load/build_road/decorate 浪费 10+ 动作。
- 下矿前食物<3 时 mine 会因「need 3+ for floor 20 and below」直接失败：先 Saloon 买沙拉或钓鱼吃鱼补到 ≥3 再下矿。
- 矿洞 infested 层 mine 返回「no stones left and no ladder found」时，fight 清怪 2 次仍无梯子即 leave_mine 换层，不要在同一层连调 mine。
- 洒水器 place 返回「分区无空位」时，必须先用 use_tool hoe 清一格耕地再 place，最多 6 次；连续两天 4 个洒水器 craft 成功却全天没放下去。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏12）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 4402g，铁锭 1，Iron Ore 3，Coal 16，Copper Bar 56，Stone 2387，Wood 1。差约 600g + 4 铁锭。
并行里程碑：**洒水器×4 落地**——已 craft 4 个，连续两天 place 失败（分区无空位），今天第一件事必须 hoe 清格后放下。
之后：**下矿装备**——食物≥3 才能下 20 层以下，≥5 才下 40 层以下；当前只有 2 个回血食物，需先补食物（Saloon 沙拉或钓鱼吃鱼）再下矿。
接下来 3 天主活动：
- **今天（夏12）**：① hoe 清 4 格并 place 4 个洒水器（最多 6 次 place，失败即停）；② collect 熔炉 1 次，炉空立刻 load Iron Ore 5 块（只 1 次）；③ 清背包到 ≥5 空格；④ 补食物到 ≥3（Saloon 沙拉或钓鱼吃鱼）；⑤ 下矿 20 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；⑥ 回农场 load 铁矿 1 次（仅炉空）；⑦ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑧ 22:00 前 sleep。
- **明天（夏13）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏14）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则 `use_tool` hoe 清一格耕地再 place，最多试 6 次（4 个洒水器各需一格），失败即跳过。**place 前先读背包确认有 Sprinkler。**
2. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 3 步。
3. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
4. **清背包到 ≥5 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<5 时禁止下矿。**买鱼饵前也先清到 ≥3 空格。**
5. **补食物到 ≥3**：背包回血食物<3 且现金≥400g 时，**12:10 后**去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃，改钓鱼吃鱼补食物。
6. **下矿（主活动）**：食物≥3、空格≥5 才 `goto_location` Mine → `mine` 目标 20 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
9. **买鱼饵**：先清背包到 ≥3 空格，再去 **Mountain 的 FishShop**（威利店在 Mountain 地图，不是 Beach）`open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。open_shop 失败一次即放弃。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
11. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
12. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 6 次，不在地图外乱放。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥5**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<5 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图（15,40 附近），不在 Beach；去 Beach 会因节日锁门或位置错误失败。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续两天铺路/装饰浪费 10+ 动作，全部失败或低效。
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
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. hoe 清格并 place 4 个洒水器（今天第一件事，最多 6 次 place）
2. collect 熔炉取锭（仅 1 次，空即跳第 3 步）
3. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
4. 清背包到 ≥5 空格
5. 补食物到 ≥3（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
6. 下矿 20 层以下拿铁矿石+煤（食物≥3、空格≥5 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 买鱼饵（先清背包 ≥3 空格，Mountain 的 FishShop ≤20 个）
10. 浇水（水壶在背包时）
11. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
12. 社交（仅顺路）
13. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天43动作失败20，核心浪费在14:00-16:40的固定空转（load/build_road/decorate反复失败）和洒水器place无空位。有效动作是Forest钓鱼8条和熔炉collect。铁锭零产出、洒水器未落地、钢水壶原地踏步。今天必须：先hoe清格放洒水器、collect后立刻load铁矿、下矿前清背包≥5空格、FishShop在Mountain走对入口、任何分支失败即转钓鱼，禁止固定时段空转。
- 06:50 动作 `goto_location` 失败 @ Farm — exit to Beach did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 07:40 动作 `festival` 失败 @ Town — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 08:50 动作 `mine` 失败 @ Mine — floor 16: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Copper Ore / [hud] Stone / [hud] The Luau has begun 
at the beach.  / [hud] This area is infested...  〔自动〕
- 09:30 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 14:10 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 14:10 动作 `buy` 失败 @ Mountain — no shop is open; use open_shop first 〔自动〕
- 14:10 动作 `close_menu` 失败 @ Mountain — no menu is open 〔自动〕
- 14:50 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 14:50 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 14:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 15:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 15:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 4 个洒水器 craft 成功却全天 place 失败，耕地分区无空位 @ Farm 耕地 — place 返回「Sprinkler 在规划的分区里没有空位了」和「今天已确认分区无空位」，连续 7 次失败（做不了：洒水器无法铺开，继续手动浇水浪费体力，拖慢下矿和升级） 〔复盘〕
- 熔炉全天 load 失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything in the backpack or the farm chests」，连续 5 次失败（做不了：钢水壶里程碑差 4 铁锭，无法推进） 〔复盘〕
- 下矿因食物不足只推进 4 层（15→19），第二次 mine 原地 0 层 @ Mine 15-19 层 — mine 返回「only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)」（做不了：拿不到 40 层以下的铁矿石，铁锭和钢水壶都卡住） 〔复盘〕
- 去 Mountain 开 FishShop 失败，位置错误 @ Mountain (15,40) — open_shop 返回「can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)」（做不了：买不到鱼饵，钓鱼效率下降） 〔复盘〕
- 14:00-16:40 脚本「固定做这个到 17:00」反复空转 load/build_road/decorate @ Farm — load_machines 返回 busy、build_road 返回「laid 0 tiles」、decorate 返回「没有能做的装饰」，共 10+ 次失败（做不了：浪费步数上限，主活动无法完成，当天被强制 sleep） 〔复盘〕
- 去 Beach 参加 Luau 节日失败，节日未开始且锁门 @ Beach 入口 — goto_location 返回「exit to Beach did not open」和「Today's festival is being set up. Come back later.」；festival 动作返回「not at a festival right now」（做不了：节日活动没参加成，浪费 2 个动作） 〔复盘〕
