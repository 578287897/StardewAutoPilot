# 第2年 spring 1 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（19:17 开始）
- 天气：sunny　金钱：3360g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_spring_01）准备的脚本
- 里程碑：工具按档升级——去Blacksmith领取铜水壶（克林特处还剩1天）
- 收熔炉→显式装Iron Ore炼铁，凑够铁锭≥5
- 去皮埃尔买春季种子（土豆/花椰菜，留1000g以上）
- 回农场种下、放洒水器、浇水
- craft洒水器×4（铁锭≥5且铜锭≥4）
- 主活动：Mountain湖边钓鱼攒钱（放最后单独执行）
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Town"）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="watering_can"）
7. `goto_location`（location="SeedShop"）
8. `open_shop`（shop_id="SeedShop"）
9. `buy`（item="Potato Seeds", count=15）
10. `buy`（item="Cauliflower Seeds", count=5）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `plant_seeds`（item="Potato Seeds", count=15）
14. `plant_seeds`（item="Cauliflower Seeds", count=5）
15. `water_crops`
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `craft`（item="Sprinkler", count=4）
19. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
20. `goto_location`（location="Mountain"）
21. `fish`（casts=6）
22. `fish`（casts=6）
23. `goto_location`（location="Farm"）
24. `sleep`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 🗨️ [event] Skipped cutscene 63
  - 🗨️ [mail] Notice:  The price of raw materials at Robin's shop and Clint's shop has increased.
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate未解锁（等法师来信），跳过该分支，其余按原路线：领水壶→买种子→钓鱼→回农场种植浇水→炼铁→出货→睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `goto_location`（location="Town"）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="watering_can"）
6. `goto_location`（location="SeedShop"）
7. `open_shop`（shop_id="SeedShop"）
8. `buy`（item="Potato Seeds", count=15）
9. `buy`（item="Cauliflower Seeds", count=5）
10. `close_menu`
11. `goto_location`（location="Mountain"）
12. `fish`（casts=6）
13. `fish`（casts=6）
14. `goto_location`（location="Farm"）
15. `plant_seeds`（item="Potato Seeds", count=15）
16. `plant_seeds`（item="Cauliflower Seeds", count=5）
17. `water_crops`
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `craft`（item="Sprinkler", count=4）
21. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
22. `sleep`
- **06:10** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **06:10** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)

## 🌅 早上的计划（19:19 开始）
- 天气：sunny　金钱：3360g　体力：270/270

**执行脚本：**
1. `interact`（x=114, y=17）
2. `interact`（x=123, y=58）
3. `interact`（x=114, y=17）
4. `interact`（x=123, y=58）
5. `ship_produce`
6. `fish`（casts=5）
- **07:50** Town ❌ `interact`（x=114, y=17）
  - 结果：busy with 'wait'

### 🔁 脚本重写：重写#1：春1按流程：读信→收熔炉装铁矿→买蓝莓/啤酒花种子→回农场种下浇水→出货→craft洒水器→Mountain钓鱼→砍树→睡觉。
1. `check_mail`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="SeedShop"）
5. `open_shop`（shop_id="SeedShop"）
6. `buy`（item="Blueberry Seeds", count=15）
7. `buy`（item="Hops Starter", count=10）
8. `close_menu`
9. `goto_location`（location="Mountain"）
10. `fish`（casts=6）
11. `fish`（casts=6）
12. `goto_location`（location="Farm"）
13. `plant_seeds`（item="Blueberry Seeds", count=15）
14. `plant_seeds`（item="Hops Starter", count=10）
15. `water_crops`
16. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar"]）
17. `craft`（item="Sprinkler", count=1）
18. `use_tool`（tool="axe", x=10, y=1, times=1, until_cleared=true）
19. `sleep`

## 🌅 早上的计划（19:23 开始）
- 天气：sunny　金钱：3360g　体力：270/270
- 里程碑：工具按档升级（铜水壶明天领取）+ 洒水器×4
- 读信、收熔炉并显式装 Iron Ore 炼铁
- 去皮埃尔买春季种子（蓝莓/啤酒花，留≥1000g）
- 回农场种下并浇水
- 白名单出货推现金
- 铁锭够就 craft 洒水器
- Mountain 湖边钓鱼攒钱
- 砍树补木头到 150

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `check_mail`
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `goto_location`（location="SeedShop"）
7. `open_shop`（shop_id="SeedShop"）
8. `buy`（item="Blueberry Seeds", count=15）
9. `buy`（item="Hops Starter", count=10）
10. `close_menu`
11. `goto_location`（location="Mountain"）
12. `fish`（casts=6）
13. `fish`（casts=6）
14. `goto_location`（location="Farm"）
15. `plant_seeds`（item="Blueberry Seeds", count=15）
16. `plant_seeds`（item="Hops Starter", count=10）
17. `water_crops`
18. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar"]）
19. `craft`（item="Sprinkler", count=1）
20. `use_tool`（tool="axe", x=10, y=1, times=1, until_cleared=true）
21. `sleep`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 🗨️ [event] Skipped cutscene 63
  - 🗨️ [mail] Notice:  The price of raw materials at Robin's shop and Clint's shop has increased.
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **06:10** Farm ✅ `check_mail`
  - 结果：mailbox is empty
- **06:10** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **06:10** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：waited until 8:10 am (waiting for SeedShop to open at 9:00)
- **08:10** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：waited until 9:00 am (waiting for SeedShop to open at 9:00)
- **09:00** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：arrived at SeedShop (6,29)
- **09:30** SeedShop ✅ `open_shop`（shop_id="SeedShop"）
  - 结果：shop opened
- **09:30** SeedShop ✅ `buy`（item="Potato Seeds", count=20）
  - 💭 商店已开，现金3360g。买春季高收益种子：土豆+花椰菜，留1000g以上。
  - 结果：bought 20x Potato Seeds for 1000g
- **09:30** SeedShop ✅ `buy`（item="Garlic Seeds", count=10）
  - 💭 已买土豆种子，现金1360。再买大蒜种子20个（800g）补春季收益，然后回农场种植。
  - 结果：bought 10x Garlic Seeds for 400g
- **09:30** SeedShop ✅ `close_menu`
  - 💭 已买土豆+大蒜种子花1400g，现金剩560g。关店回农场种下并浇水，熔炉稍后收。
  - 结果：menu closed
- **09:30** SeedShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
- **10:00** Farm ✅ `plant_seeds`（item="Potato Seeds", count=20）
  - 结果：planted 19x Potato Seeds in plot (51,14) 6x4, 5 tiles unusable
- **10:40** Farm ❌ `buy`（item="Blueberry Seeds", count=15）
  - 结果：no shop is open; use open_shop first

### 🔁 脚本重写：重写#2：商店已关闭导致买种子失败，重新打开皮埃尔商店买蓝莓/啤酒花后回农场种下，其余按原路线保留。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `goto_location`（location="SeedShop"）
4. `open_shop`（shop_id="SeedShop"）
5. `buy`（item="Blueberry Seeds", count=15）
6. `buy`（item="Hops Starter", count=10）
7. `close_menu`
8. `goto_location`（location="Mountain"）
9. `fish`（casts=6）
10. `fish`（casts=6）
11. `goto_location`（location="Farm"）
12. `plant_seeds`（item="Blueberry Seeds", count=15）
13. `plant_seeds`（item="Hops Starter", count=10）
14. `water_crops`
15. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar"]）
16. `craft`（item="Sprinkler", count=1）
17. `use_tool`（tool="axe", x=10, y=1, times=1, until_cleared=true）
18. `sleep`
- **10:40** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 🗨️ [hud] Iron Bar
- **10:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **10:40** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：arrived at SeedShop (6,29)
- **11:20** SeedShop ✅ `open_shop`（shop_id="SeedShop"）
  - 结果：shop opened
- **11:20** SeedShop ✅ `buy`（item="Potato Seeds", count=10）
  - 💭 商店已开，现金1960。买春季高收益种子：土豆+花椰菜，留1000g以上。
  - 结果：bought 10x Potato Seeds for 500g
- **11:20** SeedShop ✅ `buy`（item="Kale Seeds", count=5）
  - 💭 商店已开，现金1460。买高收益Kale和Cauliflower种子，留1000g以上。
  - 结果：bought 5x Kale Seeds for 350g
- **11:20** SeedShop ❌ `buy`（item="Cauliflower Seeds", count=5）
  - 💭 现金1110，蓝莓未解锁，改买高收益Cauliflower/Kale补种；先买Cauliflower 5份留钱
  - 结果：inventory full
- **11:20** SeedShop ✅ `close_menu`
  - 💭 背包满，先关店回农场把种子种下腾出空间，再回来买。
  - 结果：menu closed
- **11:20** SeedShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
- **11:40** Farm ✅ `plant_seeds`（item="Potato Seeds", count=11）
  - 结果：no free soil near the anchor; clear debris or pick another spot
- **11:40** Farm ❌ `buy`（item="Blueberry Seeds", count=15）
  - 结果：no shop is open; use open_shop first

### 🔁 脚本重写：重写#3：种子已买好、商店已关，回农场种下浇水、出货炼铁后去山湖钓鱼，最后睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `plant_seeds`（item="Potato Seeds", count=10）
4. `plant_seeds`（item="Kale Seeds", count=5）
5. `water_crops`
6. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar"]）
7. `craft`（item="Sprinkler", count=1）
8. `goto_location`（location="Mountain"）
9. `fish`（casts=6）
10. `fish`（casts=6）
11. `goto_location`（location="Farm"）
12. `sleep`
- **11:40** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **11:40** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
- **12:00** Farm ✅ `plant_seeds`（item="Potato Seeds", count=10）
  - 结果：planted 10x Potato Seeds
  - 🗨️ [hud] Clay
- **12:30** Farm ✅ `plant_seeds`（item="Kale Seeds", count=5）
  - 结果：no free soil near the anchor; clear debris or pick another spot
- **12:30** Farm ❌ `water_crops`
  - 结果：no watering can
- **12:30** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar"]）
  - 结果：nothing to ship
- **12:30** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
- **12:30** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
- **12:50** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Carp, Carp, River Jelly, Bullhead, Chub, Green Algae)
  - 🗨️ [hud] River Jelly
- **15:00** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Carp, Green Algae, Bullhead, Chub, Driftwood, Carp)
  - 🗨️ [hud] Green Algae
- **17:20** Mountain ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：3360 → 1110（-2250g）
- 出货估值：0g　动作：38 个　失败：6 个
- 模型调用：10 次　tokens：106356

## 🧠 夜间复盘
Y2春1 现金被种子和钓竿规划吃掉，实际只剩 1110g；熔炉被铜矿占满、铁矿没炼成铁锭，洒水器只做出 1 个；买种子时背包满+蓝莓未解锁导致反复失败；水壶还在升级中，今天不能浇水。有效动作是 Mountain 钓鱼 12 条和出货 1975g。明天核心是领水壶、把铁矿炼成铁锭、补做洒水器、控制买种子节奏。

**新教训：**
- 蓝莓种子在 Y2 春1 未解锁，buy Blueberry Seeds 连续失败 2 次：买种子前先确认商店实际可售列表，只买已解锁作物（土豆/花椰菜/大蒜/Kale）。
- 背包 24 格满时 buy 返回 'inventory full'，导致花椰菜种子没买成：买种子前先 ship_produce 或放箱子清出 ≥5 空格，再 open_shop。
- plant_seeds 在锚点周围 5 格不可用/杂物阻挡时返回 'no free soil near the anchor'：失败后应换锚点或先清杂物，而不是同一锚点重试。
- 水壶在克林特升级期间 water_crops 返回 'no watering can'：升级当天应把浇水从流程删除，主活动改为炼铁/钓鱼。
- 熔炉被铜矿占满时 load_machines 返回 'no empty machine accepts anything'：装料前先 collect 并确认熔炉空，再显式 item=Iron Ore，否则铁矿永远炼不成铁锭。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春2）

## 长期目标
当前里程碑：**工具按档升级（铜水壶今天领取）**，并行 **洒水器×4** 与 **玻璃纤维钓竿 1800g**。
- 水壶：克林特处今天可取，9:00-15:30 去 Blacksmith 领取；领取后当天不再交付任何升级（一次只升一件）。
- 洒水器×4：现铁锭 1、铜锭 66、煤 16、铁矿 12；需再炼 4 铁锭。今天第一优先级是熔炉炼铁，不是买种子。
- 玻璃纤维钓竿 1800g：现金 1110g + 昨夜出货到账（约 0g 估值，需早上确认）——不够就先钓鱼攒，不硬买。
- 背包 24 格已满风险高：买种子前先清背包（出货/放箱子）。

接下来 3 天主活动：
- **今天（春2）**：① 早上确认现金到账 → ② 收熔炉并显式装 Iron Ore 炼铁（≤2 次）→ ③ 9:00 后去 Blacksmith 领铜水壶 → ④ 回农场把剩余土豆/大蒜种下（先清背包）→ ⑤ 铁锭≥4 就 craft 洒水器补到 4 个 → ⑥ 下午 Mountain 湖边钓鱼。
- **明天（春3）**：下矿 40-44 层补铁矿/煤；浇水（水壶已回）；收菜出货。
- **后天（春4）**：继续炼铁做高级洒水器前置；钓鱼攒 1800g 买玻璃纤维竿。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. `collect_machines`（≤2 次）→ 熔炉空且背包有 Iron Ore 时 `load_machines` **显式 item=Iron Ore** 装 1 次；返回 "no empty machine" 立即硬熔断，当天不再调用。
2. **确认现金**：读 state 的 money，不按昨日规划；现金 < 800g 时当天不买种子，主活动改钓鱼。
3. **领水壶（仅今天）**：9:00-15:30 之间 `goto_location` Blacksmith → `upgrade_tool` 领取/确认；16:00 后不去。领取后当天不再调 upgrade_tool。
4. **清背包再买种子**：背包空格 < 5 时先 `ship_produce` 白名单（留 25 铜矿/5 煤/5 铁矿，其余含多余 Copper Bar、Stone、鱼全出）或放箱子，再 `open_shop` 买种子。
5. **买种子**：只买已解锁的春季作物（土豆/花椰菜/大蒜/Kale）；**蓝莓未解锁，禁止再调 buy Blueberry**；单次 buy ≤2 次，现金留 ≥600g。
6. 回农场 `plant_seeds`（≤2 次，失败换锚点或先清杂物）→ `place` 洒水器（≤2 次）→ `water_crops`（1 次，水壶在升级中则跳过）。
7. **craft 洒水器**：显式检查铁锭≥1 且铜锭≥1，满足才 `craft Sprinkler`，目标总数 4；不满足跳过。
8. **主活动=钓鱼攒钱**：`goto_location` Mountain 湖边 → `fish casts=6` 两轮（≤4 次 fish 调用）。**fish 必须放在流程最后单独执行**；fish 返回后先确认状态再发下一个动作。
9. 体力<15 或时间≥22:00 `sleep`；**22:00 强制 sleep**。

## 规则
- **钓鱼并发熔断**：任何动作返回 "busy with 'fish'" 时，脚本层立即停止发新动作，等 fish 返回；`close_menu` 不能中断钓鱼，禁止用它。**禁止在 fish 未结束时连发 collect/load/ship/goto**。
- **熔炉优先**：每天第一步确认熔炉状态；满料先 collect，空炉立即装 Iron Ore。load_machines 每天≤2 次，返回"no empty machine"即熔断。
- **现金目标**：每天结束现金 ≥ 当天开始 + 100g，否则第二天主活动强制改为钓鱼。
- **空转硬熔断**：任何动作返回 "no empty machine accepts anything"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"none of the ... is reachable"、"inventory full" 等，脚本层立即永久跳过该分支，当天不再调用，转去钓鱼或砍树。**禁止 wait**。
- **18 层永久拉黑**；**45 层以上不追**：mine 目标锁定 40-44 层，到 45 层无产出立即 leave_mine；体力<30 不调 mine。
- **工具升级**：一次只升一件；升级期间（2 天）不调 mine（无镐）也不调 water_crops（无水壶）。升级前显式检查现金≥费用且锭够，不足直接跳过。
- **clear_debris / build_road / decorate 禁用**。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait。节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00。营业时间前不调用 goto/open_shop/buy。**16:00 后不再去 Blacksmith**。
- **路径固定**：去 Blacksmith/Mountain 一律走 Farm→Town→Mountain；**Backwoods 不作为中转**。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下。
- **季末规划**：春季作物在夏季第 1 天枯死；季末只种能在 28 日前成熟的作物。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. 收熔炉 + 装 Iron Ore 炼铁锭（≤2 次）
2. 领铜水壶（仅今天，9:00-15:30）
3. 清背包 + 买已解锁春季种子（留 ≥600g）
4. 种下 + 放洒水器
5. craft 洒水器补到 4 个
6. 白名单出货把现金推高
7. 钓鱼攒钱（Mountain 湖边，放最后单独执行）
8. 砍树攒木头到 150
9. 社交（仅顺路）

</details>

## ⚠️ 今日问题
> Y2春1 现金被种子和钓竿规划吃掉，实际只剩 1110g；熔炉被铜矿占满、铁矿没炼成铁锭，洒水器只做出 1 个；买种子时背包满+蓝莓未解锁导致反复失败；水壶还在升级中，今天不能浇水。有效动作是 Mountain 钓鱼 12 条和出货 1975g。明天核心是领水壶、把铁矿炼成铁锭、补做洒水器、控制买种子节奏。
- 06:10 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 10:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 10:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:20 动作 `buy` 失败 @ SeedShop — inventory full 〔自动〕
- 11:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 12:30 动作 `water_crops` 失败 @ Farm — no watering can 〔自动〕
- 买种子计划反复变更（土豆20+花椰菜10→土豆20+大蒜10→土豆10+花椰菜5→蓝莓15），最终只买到土豆和大蒜，花椰菜因背包满失败 @ SeedShop / Farm — buy Cauliflower Seeds 返回 'inventory full'；buy Blueberry Seeds 返回 'no shop is open'（蓝莓未解锁且脚本在关店后调用）（做不了：春季种植面积没铺满，春季收入上限被压低） 〔复盘〕
- 熔炉被铜矿占满，12 铁矿只炼出 1 铁锭，洒水器只做出 1 个 @ Farm 熔炉 — load_machines 返回 'all machines are busy' 和 'no empty machine accepts anything in the backpack or the farm chests'（做不了：洒水器×4 做不出来，明天仍要手动浇水，体力被占用） 〔复盘〕
- 水壶在克林特处升级，全天无法浇水，water_crops 直接失败 @ Farm 田地 — water_crops 返回 'no watering can'（做不了：已种下的 29 格土豆当天没浇水，生长节奏受影响） 〔复盘〕
- plant_seeds 在同一锚点连续失败，Kale 种子没种下 @ Farm 田地 (51,14) 附近 — plant_seeds 返回 'no free soil near the anchor; clear debris or pick another spot'（做不了：5 个 Kale 种子留在背包占格，进一步加剧背包满） 〔复盘〕
- 现金从 3360g 花到 1110g，玻璃纤维钓竿 1800g 买不起 @ 全局 — 买种子花 2250g（土豆20+大蒜10+土豆10+Kale5），现金 1110g < 1800g（做不了：钓鱼效率停在基础竿，攒钱速度慢） 〔复盘〕
- 出货箱当天出货估值 0g，昨夜 1975g 到账后没有新的变现动作 @ Farm 出货箱 — ship_produce 返回 'nothing to ship'（白名单排除项过多，背包里可卖物少）（做不了：现金增长停滞，明天买种子和钓竿都受限） 〔复盘〕
