# 第2年 summer 9 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（03:03 开始）
- 天气：sunny　金钱：3155g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7c4240d637984f5898ca060d1b9ea67a
  - 耗时：0.11 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：592ff53bd1244e0fba71307d63453185
  - 耗时：0.157 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：6aaba7aa9514482d82e4af568c90da90
  - 耗时：0.109 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_09）准备的脚本
- 里程碑：钢水壶（凑 5 铁锭 + 5000g）
- 先清背包到 ≥5 空格并取出箱子里的铁矿石
- 下矿 40 层以下拿铁矿石+煤（≤2 次，超时即停）
- 回农场 collect 熔炉并 load 铁矿
- 现金不足则去 Forest 河边钓鱼补钱
- 买鱼饵 20 个
- 22:00 前 sleep
1. `donate`
2. `store_items`（items=["Cobblestone Path", "Copper Ore", "Coal", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
3. `take`（item="Iron Ore", count=13）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `goto_location`（location="Mine"）
7. `mine`（floors=5）
8. `mine`（floors=5）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar"]）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `fish`（casts=4）
17. `goto_location`（location="Mountain"）
18. `goto_location`（location="FishShop"）
19. `open_shop`（shop_id="FishShop"）
20. `buy`（item="Bait", count=20）
21. `close_menu`
22. `sleep`
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~604g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：db465abb1e32441c903089dfaffb26ec
  - 耗时：5.437 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：46e2caf4e5754c8a8f7448ef39324229
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：捐不了（等巫师信），跳过donate；先放洒水器、装炉，再下矿补铁，回农场装炉后钓鱼买饵睡觉。
1. `place`（item="Sprinkler"）
2. `place`（item="Sprinkler"）
3. `collect_machines`
4. `load_machines`（item="Iron Ore"）
5. `store_items`（items=["Cobblestone Path", "Copper Ore", "Coal", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
6. `goto_location`（location="Mine"）
7. `mine`（floors=5）
8. `mine`（floors=5）
9. `leave_mine`
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `fish`（casts=4）
13. `goto_location`（location="Mountain"）
14. `goto_location`（location="FishShop"）
15. `open_shop`（shop_id="FishShop"）
16. `buy`（item="Bait", count=20）
17. `close_menu`
18. `goto_location`（location="Farm"）
19. `load_machines`（item="Iron Ore"）
20. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar"]）
21. `sleep`
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **06:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **06:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：cd00672f2ec74ba398440a2535e03dd1
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b30c03a9347f4ff7827d66735ccd8320
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `store_items`（items=["Cobblestone Path", "Copper Ore", "Coal", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 1x Coal
  - 执行状态：SUCCESS · 操作编号：ff576dff88e24527ae88da7aa899b32e
  - 耗时：1.406 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：22b097b6a1e048e1b133b241dcc460ed
  - 耗时：83.359 秒 / 游戏 110 分钟
- **08:00** Mine ❌ `mine`（floors=5）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：67f3a53002f54e8b8193a578c0c27d48
  - 耗时：2.984 秒 / 游戏 0 分钟
  - 🗨️ [hud] This area is infested... 

### 🔁 脚本重写：重写#2：矿洞16层无石无梯先清怪再试一次下矿，超时即出矿回农场装炉，转Forest钓鱼补现金并买鱼饵。
1. `fight`（range=6）
2. `fight`（range=6）
3. `mine`（floors=3）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mountain"）
9. `goto_location`（location="FishShop"）
10. `open_shop`（shop_id="FishShop"）
11. `buy`（item="Bait", count=20）
12. `close_menu`
13. `goto_location`（location="Farm"）
14. `load_machines`（item="Iron Ore"）
15. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar"]）
16. `sleep`
- **08:00** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：837b2b21cc6d42f8b31bac5788b4551b
  - 耗时：22.734 秒 / 游戏 30 分钟
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Slime
- **08:30** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：53a48a5387f14f2fa5bc8d1b849d070d
  - 耗时：0.109 秒 / 游戏 0 分钟
- **08:30** UndergroundMine16 ❌ `mine`（floors=3）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：9e2884fc1d8942179d4086a843d5fc3c
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞16层无石无梯，清怪两次仍无梯即出矿，回农场放洒水器并装炉，转Forest钓鱼补现金后买鱼饵睡觉。
1. `fight`（range=6）
2. `fight`（range=6）
3. `leave_mine`
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Mountain"）
8. `goto_location`（location="FishShop"）
9. `open_shop`（shop_id="FishShop"）
10. `buy`（item="Bait", count=20）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `place`（item="Sprinkler"）
14. `place`（item="Sprinkler"）
15. `load_machines`（item="Iron Ore"）
16. `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler"]）
17. `sleep`
- **08:30** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：597edeb5f407416e88f41e6a0ea870cb
  - 耗时：0.125 秒 / 游戏 0 分钟
- **08:30** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：21e4ed734cca4428bdba21353876d921
  - 耗时：0.156 秒 / 游戏 0 分钟
- **08:30** UndergroundMine16 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：bc2ad26795ba41fbbe61f17a7c8751a3
  - 耗时：5.547 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **08:30** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：e481a907dc4c4d1eb196a8c2eb36a733
  - 耗时：59.125 秒 / 游戏 80 分钟
- **09:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Dorado, Sunfish, Chub, Sunfish)
  - 执行状态：SUCCESS · 操作编号：09da047ba57944a9a865adca49eeb8c5
  - 耗时：103.14 秒 / 游戏 90 分钟
  - 🗨️ [hud] Dorado
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Chub
- **11:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Rainbow Trout, Rainbow Trout, Green Algae)
  - 执行状态：SUCCESS · 操作编号：0c2ae736fd344f8c901cc06cf434d777
  - 耗时：89.391 秒 / 游戏 90 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Rainbow Trout
- **12:50** Forest ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：7c4af065bf1043acb08cf2ed879d4e8c
  - 耗时：45.953 秒 / 游戏 60 分钟
- **13:50** Mountain ✅ `goto_location`（location="FishShop"）
  - 结果：arrived at FishShop (5,9)
  - 执行状态：SUCCESS · 操作编号：e0ba5f5a65a24557a82b8ffd7bf806af
  - 耗时：44.906 秒 / 游戏 60 分钟
- **14:50** FishShop ✅ `open_shop`（shop_id="FishShop"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：05028263c772464091d91900d813e2a4
  - 耗时：0.359 秒 / 游戏 0 分钟
- **14:50** FishShop ❌ `buy`（item="Bait", count=20）
  - 💭 背包满0空格，先买鱼饵20个再关菜单，然后回农场放洒水器
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：25eb6802fa9d445e83921f354a746ebd
  - 耗时：0.125 秒 / 游戏 0 分钟
- **14:50** FishShop ✅ `close_menu`
  - 💭 背包满买不了鱼饵，先关菜单回农场放洒水器、清背包
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：20c31cce004d4ef5bf0c0e14a837dc40
  - 耗时：0.266 秒 / 游戏 0 分钟
- **14:50** FishShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：01aedfec15c84b0682014fc3b1bb0b17
  - 耗时：46.641 秒 / 游戏 50 分钟
- **15:40** Farm ❌ `buy`（item="Bait", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：2203eaee9ecf4072994834a7861553f9
  - 耗时：0.14 秒 / 游戏 0 分钟
- **15:40** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：6fe29551d6284134ae61b8a56ef81a58
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:40** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：44fdfb49055b432482a0c2f52394eaa3
  - 耗时：0.125 秒 / 游戏 0 分钟
- **15:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **15:40** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **15:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bc47a8a898e54b588551fae6bf4d5b20
  - 耗时：0.14 秒 / 游戏 0 分钟
- **15:40** Farm ✅ `ship_produce`（except=["Sunfish", "Pike", "Rainbow Trout", "Copper Bar", "Iron Bar", "Sprinkler"]）
  - 结果：shipped 3 stacks worth ~232g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：6d017461722c44f58c6836f7ddde496b
  - 耗时：2.156 秒 / 游戏 10 分钟
- **15:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：100ea26e82464acfadaec0e7b73c8e94
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:50** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：34b22eacce224bf7ba42c471a805f7bb
  - 耗时：0.125 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：bfe3b901b0544c5cafb98a7a64119635
  - 耗时：4.656 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a83be45b3f7d44a5a2b289fd41edad05
  - 耗时：0.141 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c77b2a08f61f4bb4ae05c2801de93e54
  - 耗时：12.547 秒 / 游戏 20 分钟
- **16:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **16:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Broken Glasses, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：6747ad9a09c644fcb15e278d829f7319
  - 耗时：41.234 秒 / 游戏 60 分钟
  - 🗨️ [hud] Joja Cola
- **17:10** Farm ✅ `ship`（item="Joja Cola", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Joja Cola (~50g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：6c94f90eeeec47cd8fc1b3c13237d93b
  - 耗时：3.187 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：e178c56d48a84ab19faa0be9f815a960
  - 耗时：6.875 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：3155 → 4041（+886g）
- 出货估值：836g　动作：44 个　失败：20 个
- 模型调用：6 次　tokens：70579
- 有效动作率：0.4884　空转：10　熔断跳过：0
- 失败耗时：21.922 秒 / 游戏 20 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是洒水器craft成功却全天没place（分区无空位未清格）、熔炉load全失败导致铁锭零产出、矿洞16层被怪卡住两次mine超时、背包满买不了鱼饵、14:00后脚本空转load/build_road/decorate浪费20+动作。有效做法：Forest河边钓鱼稳定出货（8条）、ship_produce清背包。今天必须先清格放洒水器、collect后立刻load铁矿、下矿前清空格、买鱼饵前先清背包。

**新教训：**
- 洒水器 place 返回「分区无空位」时，必须用 use_tool hoe 清一格耕地再 place，最多 3 次；昨天 2 个洒水器 craft 成功却全天没放下去，今天第一件事就是清格放下。
- 买鱼饵前必须先 store_items 清背包到 ≥3 空格：昨天背包满导致 buy Bait 失败，之后 close_menu 再 buy 又报 no shop is open，浪费 3 个动作。
- 矿洞 16 层是 infested 层，mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；昨天 fight 4 次后仍无梯子，说明该层需要清完所有怪才出梯，清怪 2 次无果即 leave_mine 换层，不要在同一层连调 mine。
- 脚本分支做完后不应「固定做这个到 17:00」：昨天 14:00-16:40 反复空转 load/build_road/decorate，应直接转钓鱼或提前 sleep。
- collect_machines 返回空后当天必须立刻 load 铁矿，不要等下午：昨天 collect 空后全天 load 全失败，铁锭零产出，钢水壶里程碑原地踏步。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏10）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金约 3155g（今早出货到账后约 3990g），铁锭 1，Iron Ore 3，Coal 15，Copper Bar 56，Stone 2372，Wood 1。差约 1000g + 4 铁锭。
并行里程碑：**洒水器×4**——已 craft 2 个但连续两天没 place 下去，今天第一件事必须清格放下；材料够再做 2 个（铜锭 56、铁锭 1），craft 后立即 place。
之后：钓鱼 9 级缺鱼饵，去威利店买 Bait（5g/个，≤20 个），**买前先清背包到 ≥3 空格**。
接下来 3 天主活动：
- **今天（夏10）**：① 清耕地放已 craft 的 2 个洒水器（hoe 清格再 place，最多 3 次）；② craft 剩余洒水器并 place；③ collect 熔炉 1 次，炉空则立刻 load Iron Ore 5 块（只 1 次）；④ 清背包到 ≥5 空格后下矿 40 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；⑤ 回农场再 load 铁矿 1 次（仅炉空）；⑥ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑦ 22:00 前 sleep。
- **明天（夏11）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏12）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则 `use_tool` hoe 清一格耕地再 place，最多试 3 次，失败即跳过。**place 前先读背包确认有 Sprinkler。**
2. **洒水器 craft+place**：实时读材料，铁锭≥1 且铜锭≥1 就 `craft` 洒水器（最多 2 个）并立即 `place`；craft 前先确认背包空格≥1，否则先 `store_items` 清格。
3. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 4 步。
4. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
5. **清背包到 ≥5 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<5 时禁止下矿。**买鱼饵前也先清到 ≥3 空格。**
6. **下矿（主活动）**：食物≥5、空格≥5 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
9. **备食物**：背包回血食物<5 且现金≥400g 时，**12:10 后**才去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃转钓鱼。
10. **买鱼饵**：先清背包到 ≥3 空格，再去威利店 `open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
12. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
13. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 3 次，不在地图外乱放。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥5**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<5 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：昨天铺路/装饰浪费 10+ 动作，全部失败或低效。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤4、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. place 已 craft 的洒水器（今天第一件事，hoe 清格再放）
2. craft+place 剩余洒水器（材料齐当天做）
3. collect 熔炉取锭（仅 1 次，空即跳第 4 步）
4. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
5. 清背包到 ≥5 空格
6. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥5 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 备食物≥5（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
10. 买鱼饵（先清背包 ≥3 空格，威利店 ≤20 个）
11. 浇水（水壶在背包时）
12. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
13. 社交（仅顺路）
14. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是洒水器craft成功却全天没place（分区无空位未清格）、熔炉load全失败导致铁锭零产出、矿洞16层被怪卡住两次mine超时、背包满买不了鱼饵、14:00后脚本空转load/build_road/decorate浪费20+动作。有效做法：Forest河边钓鱼稳定出货（8条）、ship_produce清背包。今天必须先清格放洒水器、collect后立刻load铁矿、下矿前清空格、买鱼饵前先清背包。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 06:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 06:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:00 动作 `mine` 失败 @ Mine — floor 16: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] This area is infested...  〔自动〕
- 08:30 动作 `mine` 失败 @ UndergroundMine16 — floor 16: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 14:50 动作 `buy` 失败 @ FishShop — inventory full 〔自动〕
- 15:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 15:40 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 15:40 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 15:40 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 15:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 洒水器 craft 成功但连续两天没 place 下去 @ Farm 耕地 — place 返回「Sprinkler 今天已确认分区无空位」/「在规划的分区里没有空位了」，脚本没有先 hoe 清格（做不了：洒水器无法铺开，继续手动浇水，体力无法全部用于下矿/钓鱼） 〔复盘〕
- 熔炉全天 load 失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything」/「all machines are busy」，collect 后没有立刻 load，下午再调已 busy（做不了：钢水壶里程碑差 4 铁锭，无法推进工具升级） 〔复盘〕
- 矿洞 16 层被怪卡住，两次 mine 超时 @ Mine 16 层 — mine 返回「floor 16: no stones left and no ladder found (kill remaining monsters?)」，fight 4 次后仍无梯子（做不了：无法下到 40 层以下拿铁矿石，铁矿来源被卡） 〔复盘〕
- 背包满导致买鱼饵失败，之后 close_menu 再 buy 报 no shop is open @ FishShop — buy 返回「inventory full」；close_menu 后 buy 返回「no shop is open; use open_shop first」（做不了：钓鱼 9 级缺鱼饵，Forest 钓鱼效率下降） 〔复盘〕
- 14:00-16:40 脚本空转 load/build_road/decorate 浪费 20+ 动作 @ Farm — 「固定做这个到 17:00」分支反复调 load_machines（busy）、build_road（laid 0 tiles）、decorate（没有能做的装饰）（做不了：步数上限被空转耗尽，主活动（下矿/钓鱼）时间被挤掉） 〔复盘〕
- 铺路 24 块 Cobblestone Path 全部被树木/作物挡住 @ Farm — build_road 返回「laid 0 tiles (24 skipped: blocked by trees/crops/objects)」（做不了：铺路计划完全落空，还浪费 2 个动作） 〔复盘〕
