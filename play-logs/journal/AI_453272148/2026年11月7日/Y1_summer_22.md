# 第1年 summer 22 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（06:03 开始）
- 天气：storm　金钱：2408g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **06:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship

## 🌙 为明天（Y1_summer_22）准备的脚本
- 里程碑：稻草人（Wood 11/50，差39）——砍树凑木头并清格放置稻草人
- 下雨天不浇水，先收熔炉/存材料腾背包
- 14:00 后去冒险家公会买 Silver Saber（2408g 够）
- 带沙拉下矿刷铜/铁，目标当前最深+3 层内
1. `collect_machines`
2. `load_machines`
3. `store_items`（items=["Broken Glasses", "Broken CD", "Driftwood", "Geode", "Joja Cola", "Mixed Flower Seeds", "Mixed Seeds", "Pine Cone"]）
4. `clear_debris`（radius=6, max=20, kinds=["weed", "twig", "stone"]）
5. `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
6. `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
7. `use_tool`（tool="axe", x=36, y=14, times=1, until_cleared=true）
8. `use_tool`（tool="axe", x=48, y=8, times=1, until_cleared=true）
9. `craft`（item="Scarecrow", count=1）
10. `place`（item="Scarecrow", x=30, y=12）
11. `goto_location`（location="Mountain"）
12. `open_shop`（shop_id="AdventurerGuild"）
13. `buy`（item="Silver Saber", count=1）
14. `close_menu`
15. `mine`（floors=3）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `store_items`（items=["Copper Ore", "Coal", "Stone", "Fiber", "Iron Ore"]）
19. `ship_produce`
20. `sleep`
- **06:10** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:10** Farm ✅ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:10** Farm ✅ `store_items`（items=["Broken Glasses", "Broken CD", "Driftwood", "Geode", "Joja Cola", "Mixed Flower Seeds", "Mixed Seeds", "Pine Cone"]）
  - 结果：stored in chest at (74,15): 2x Broken Glasses, 3x Mixed Flower Seeds, 3x Broken CD, 3x Joja Cola, 1x Driftwood, 5x Geode, 3x Mixed Seeds, 1x Pine Cone
- **06:20** Farm ✅ `clear_debris`（radius=6, max=20, kinds=["weed", "twig", "stone"]）
  - 结果：cleared 2 debris within 6 tiles of (44,31)
  - 🗨️ [hud] Fiber
- **06:40** Farm ✅ `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,10), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
  - 结果：used axe 0x at (44,12), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=36, y=14, times=1, until_cleared=true）
  - 结果：used axe 0x at (36,14), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=48, y=8, times=1, until_cleared=true）
  - 结果：used axe 17x at (48,8), tile cleared
  - 🗨️ [hud] Wood
- **07:00** Farm ❌ `craft`（item="Scarecrow", count=1）
  - 结果：can't craft Scarecrow: not enough ingredients: Wood x50, Coal x1, Fiber x20

### 🔁 脚本重写：重写#1：craft 因木头不足失败，稻草人背包已有2个，改为继续砍树凑木头并直接放置，其余路线（14点后买剑、下矿、回农场存材料睡觉）保持不变。
1. `collect_machines`
2. `use_tool`（tool="axe", x=48, y=8, times=1, until_cleared=true）
3. `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
4. `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
5. `clear_debris`（radius=8, max=20, kinds=["weed", "twig", "stone"]）
6. `place`（item="Scarecrow", x=30, y=12）
7. `goto_location`（location="Mountain"）
8. `open_shop`（shop_id="AdventurerGuild"）
9. `buy`（item="Silver Saber", count=1）
10. `close_menu`
11. `mine`（floors=3）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `store_items`（items=["Copper Ore", "Coal", "Stone", "Fiber", "Iron Ore"]）
15. `ship_produce`
16. `sleep`
- **07:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Sap
  - 🗨️ [hud] Wood
  - 🗨️ [hud] Maple Seed
  - 🗨️ [hud] Copper Bar
- **07:00** Farm ✅ `use_tool`（tool="axe", x=48, y=8, times=1, until_cleared=true）
  - 结果：used axe 0x at (48,8), tile cleared
- **07:00** Farm ✅ `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
  - 结果：used axe 0x at (44,12), tile cleared
- **07:00** Farm ✅ `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,10), tile cleared
- **07:00** Farm ✅ `clear_debris`（radius=8, max=20, kinds=["weed", "twig", "stone"]）
  - 结果：cleared 0 debris within 8 tiles of (40,9); none of the 1 weed/twig/stone in Farm is reachable
- **07:00** Farm ❌ `place`（item="Scarecrow", x=30, y=12）
  - 结果：Scarecrow 在规划的分区里没有空位了（不在分区外乱放）
- **07:00** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
- **07:20** Mountain ❌ `open_shop`（shop_id="AdventurerGuild"）
  - 结果：can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent)

### 🔁 脚本重写：重写#2：公会14:00才开门，先等到开门再进店买剑，随后下矿并回农场收尾。
1. `wait`（minutes=30）
2. `goto_location`（location="AdventureGuild"）
3. `open_shop`（shop_id="AdventurerGuild"）
4. `buy`（item="Silver Saber", count=1）
5. `close_menu`
6. `mine`（floors=3）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Copper Ore", "Coal", "Stone", "Fiber", "Iron Ore"]）
10. `ship_produce`
11. `sleep`
- **07:20** Mountain ✅ `wait`（minutes=30）
  - 结果：cleared 0 debris within 8 tiles of (0,13); none of the 214 weed/stone/twig in Mountain is reachable
- **07:20** Mountain ❌ `goto_location`（location="AdventureGuild"）
  - 结果：exit to AdventureGuild did not open (closed? locked? check opening hours). Recent messages: Copper Bar | It's locked... (Open 2:00pm - 2:00am)
  - 🗨️ [dialogue] It's locked... (Open 2:00pm - 2:00am)

### 🔁 脚本重写：重写#3：公会 14:00 才开门，先回农场砍树凑木头并试放稻草人，12 点后买沙拉，14 点后再进公会买剑下矿。
1. `open_shop`（shop_id="AdventurerGuild"）
2. `buy`（item="Silver Saber", count=1）
3. `close_menu`
4. `goto_location`（location="Town"）
5. `goto_location`（location="Saloon"）
6. `open_shop`（shop_id="Saloon"）
7. `buy`（item="Salad", count=2）
8. `close_menu`
9. `mine`（floors=3）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
13. `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
14. `clear_debris`（radius=8, max=20, kinds=["twig", "weed"]）
15. `craft`（item="Scarecrow", count=1）
16. `place`（item="Scarecrow", x=30, y=12）
17. `store_items`（items=["Copper Ore", "Coal", "Stone", "Fiber", "Iron Ore"]）
18. `ship_produce`
19. `sleep`
- **08:00** Mountain ❌ `open_shop`（shop_id="AdventurerGuild"）
  - 结果：can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent)
- **08:00** Mountain ❌ `buy`（item="Silver Saber", count=1）
  - 结果：no shop is open; use open_shop first
- **08:00** Mountain ❌ `close_menu`
  - 结果：no menu is open
- **08:00** Mountain ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:10** Town ❌ `goto_location`（location="Saloon"）
  - 结果：exit to Saloon did not open (closed? locked? check opening hours). Recent messages: A train is passing 
through Stardew 
Valley.  | It's locked... (Open 12:00pm - 12:00am)
  - 🗨️ [dialogue] It's locked... (Open 12:00pm - 12:00am)
- **09:30** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)
- **09:30** Town ❌ `buy`（item="Salad", count=2）
  - 结果：no shop is open; use open_shop first
- **09:30** Town ❌ `close_menu`
  - 结果：no menu is open
- **09:30** Town ✅ `mine`（floors=3）
  - 结果：mined from floor 35 to 35 (0 floors down, 17 stones broken); retreated: health 38/105 and 0 healing food left; left the mine to recover
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] +59 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **12:00** Mine ❌ `leave_mine`
  - 结果：not in the mine
- **12:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **12:40** Farm ✅ `use_tool`（tool="axe", x=44, y=12, times=1, until_cleared=true）
  - 结果：used axe 0x at (44,12), tile cleared
- **12:40** Farm ✅ `use_tool`（tool="axe", x=40, y=10, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,10), tile cleared
- **12:40** Farm ✅ `clear_debris`（radius=8, max=20, kinds=["twig", "weed"]）
  - 结果：cleared 0 debris within 8 tiles of (40,0); none of the 1 twig/weed in Farm is reachable
- **12:40** Farm ❌ `craft`（item="Scarecrow", count=1）
  - 结果：can't craft Scarecrow: not enough ingredients: Wood x50, Coal x1, Fiber x20
- **12:40** Farm ❌ `place`（item="Scarecrow", x=30, y=12）
  - 结果：Scarecrow 在规划的分区里没有空位了（不在分区外乱放）
- **12:40** Farm ✅ `store_items`（items=["Copper Ore", "Coal", "Stone", "Fiber", "Iron Ore"]）
  - 结果：stored in chest at (74,15): 1x Fiber, 21x Copper Ore, 2x Iron Ore, 6x Stone
- **13:00** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~12g (paid overnight)
- **13:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **13:10** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
- **13:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **13:20** Farm ❌ `place`（item="Maple Seed", x=23, y=9）
  - 💭 (种一棵遮挡作坊的树)
  - 结果：can't place Maple Seed at (23,9) (needs tilled soil for seeds? wrong season? tile occupied?)
- **13:20** Farm ❌ `place`（item="Maple Seed", x=25, y=9）
  - 💭 (种一棵遮挡作坊的树)
  - 结果：can't place Maple Seed at (25,9) (needs tilled soil for seeds? wrong season? tile occupied?)
- **13:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
- **13:30** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Driftwood, Trash)
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
- **14:30** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **14:50** Farm ✅ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **14:50** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
- **14:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Soggy Newspaper, Broken CD)
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Soggy Newspaper
- **16:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **16:30** Farm ✅ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **16:30** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
- **16:30** Farm ✅ `wait`（minutes=30, filler=true）
  - 结果：waited until 5:00 pm
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 🧠 夜间复盘
昨天主要卡在稻草人放置（分区无空位）和商店时间误判（Saloon/公会未开门），导致买沙拉/买剑失败、下矿无食物被迫撤退。有效动作：熔炉循环、砍树、钓鱼。今天应优先清出稻草人具体坐标、严格按营业时间购物、下矿前备足食物并腾背包。

**新教训：**
- 稻草人 place 连续失败因分区无空位：应先 clear_debris 清出具体坐标并用 x/y 参数指定，失败 1 次换相邻格，最多 2 格，不反复对同一分区重试。
- Saloon 12:00 前 goto 失败后脚本仍继续 open_shop/buy/close_menu 连锁失败：应把 goto 失败视为时间未到，直接跳到砍树/钓鱼，12:00 后再回来。
- 冒险家公会 14:00 才开门，14:00 前到 Mountain 调 open_shop 必失败：应把 goto Mountain 严格排在 14:00 后，或先做别的事再回来。
- 背包满时买沙拉会失败或占满导致下矿无法捡矿：买前先 ship_produce 或 store_items 腾出至少 3 格。
- 下矿前食物只有 1 份时，应把目标层数降到当前最深+3 以内（如 18→21 层），而不是计划 25-30 层；食物不足时深层的战斗和撤退会浪费更多时间。

<details><summary>改写后的策略</summary>

# 星露谷自动游玩策略（Y1 夏季 23 日）

## 长期目标
当前里程碑：**稻草人**（Wood 28/50，差 22；Fiber 248、Coal 26 充足；稻草人已在背包）。完成后依次：**铜斧头**（升级中，约 1 天后完成）→ **下矿装备**（Silver Saber 750g）→ **铜镐**（2000g+5铜锭）→ **洒水器**（农业 2 级，需铁锭，下 40 层拿铁矿）。

离完成还差：22 木头（砍树/清 twig 可得）、至少 2 份回血食物（沙拉 220g/份或钓鱼）、一把平均伤害≥7 的武器（Silver Saber 750g，钱够再买）。

接下来 3 天主活动：
- **今天（夏23）**：起床收熔炉→砍树凑 Wood≥50→**12:00 后**去 Saloon 买沙拉（至少 2 份，先腾背包）→**14:00 后**去冒险家公会买 Silver Saber（钱够才买）→带食物下矿冲 25 层刷铜/煤。
- **明天（夏24）**：铜斧头完成后清大树桩扩耕地；继续下矿刷铁；钱够 750g 买 Silver Saber。
- **后天（夏25）**：铜镐清大石头；检查社区中心收集包；准备夏末停止播种。

## 每日固定流程（按顺序执行，失败即跳下一步）
1. `collect_machines` 收熔炉 → `load_machines` **只调 1 次**；返回 "no empty machine accepts anything" 立即停止，当天不再调用。
2. `harvest_crops` → `water_crops`（下雨跳过）。
3. 背包有可卖产物就 `ship_produce`。
4. **稻草人放置（今天第一优先）**：稻草人已在背包。先用 `clear_debris` 清菜地上方一格（radius 3，kinds 全选），确认该格为空后 `place` 稻草人并**显式指定 x/y 坐标**（如菜地上方第一格）。**place 失败 1 次立即换相邻格再试，最多试 2 格**；仍失败则记录坐标，改天再放，不反复重试。
5. **砍树凑木头**：去农场 `clear_debris` 清 twig/weed，`use_tool` axe 砍树；目标 Wood≥50（为后续箱子/建筑储备）。不要 take 箱子（FarmHouse 无箱；主箱 (75,15) 需先确认内容，失败 1 次立即改砍树）。
6. **12:00 后**去 Saloon：先 `ship_produce` 或 `store_items` 腾出至少 3 格背包 → `goto_location` Saloon → `open_shop` → `buy` Salad（钱够几份买几份，至少 2 份）→ `close_menu`。12 点前不去；open_shop 成功后才 buy；buy 失败 1 次立即 close_menu 改钓鱼备食物。
7. **14:00 后**去 Adventurer's Guild：`goto_location` Mountain → `open_shop` → `buy` Silver Saber → `close_menu`。**钱不足 750 则跳过**，用 Rusty Sword 只下到 19 层。
8. 食物≥2 且体力≥80 时 `mine`，目标=当前最深+3，上限 25 层（今天无剑，不闯 40 层以下），**floors≤3**。生命<50% 或食物=0 立即 `leave_mine`，当天不再下矿。
9. 体力<15 或时间≥22:00 `sleep`。**22:00 强制 sleep**。

## 规则
- **稻草人放置**：place 前先 clear_debris 清出目标格，并**用 x/y 参数指定具体坐标**；失败 1 次换相邻格，最多 2 格，不反复重试。
- **箱子坐标**：主箱 (75,15)；take 前先确认内容，失败 1 次立即改砍树，不重试。
- **商店时间**：Saloon 12:00-24:00；皮埃尔 9-17（周三休）；克林特 9-16；冒险家公会 14:00-22:00。**营业时间前不调用 goto/open_shop/buy**。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；无 Silver Saber 不闯 40 层以下。
- **mine 超时防护**：floors≤3，下矿前确认食物≥2；超时一次当天不再下矿。
- **不空等**：熔炉等待期间砍树/清杂物/钓鱼，不调用 wait。
- **动作收敛**：同一动作连续失败 2 次换目标/地点；load_machines 空转≤1 次/天。
- **季末规划**：夏 20 日前只种蓝莓/甜瓜/辣椒；之后不播种。
- **社交**：顺路 2-4 人，不专门跑图。
- **build_road/decorate/place Pine Cone 暂缓**：直到路径障碍清空或有畜舍/树种子；今天不调用这三类动作。

## 优先级（体力/时间冲突时）
1. 收熔炉（只 1 次）
2. 清格 → place 稻草人（指定坐标，失败 1 次换格，最多 2 格）
3. 砍树凑 Wood≥50
4. 12:00 后买沙拉（先腾背包，钱够几份买几份，至少 2 份）
5. 14:00 后买 Silver Saber（钱够才买）
6. 收获+浇水
7. 下矿刷铜/煤/铁（带足食物，floors≤3，目标 25 层）
8. 出货
9. 钓鱼/社交（仅顺路）
10. 确认斧头升级进度（不重复升级）

</details>

## ⚠️ 今日问题
> 昨天主要卡在稻草人放置（分区无空位）和商店时间误判（Saloon/公会未开门），导致买沙拉/买剑失败、下矿无食物被迫撤退。有效动作：熔炉循环、砍树、钓鱼。今天应优先清出稻草人具体坐标、严格按营业时间购物、下矿前备足食物并腾背包。
- 07:00 动作 `craft` 失败 @ Farm — can't craft Scarecrow: not enough ingredients: Wood x50, Coal x1, Fiber x20 〔自动〕
- 07:00 动作 `place` 失败 @ Farm — Scarecrow 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 07:20 动作 `open_shop` 失败 @ Mountain — can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 07:20 动作 `goto_location` 失败 @ Mountain — exit to AdventureGuild did not open (closed? locked? check opening hours). Recent messages: Copper Bar | It's locked... (Open 2:00pm - 2:00am) | 游戏消息: [dialogue] It's locked... (Open 2:00pm - 2:00am) 〔自动〕
- 08:00 动作 `open_shop` 失败 @ Mountain — can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 08:00 动作 `buy` 失败 @ Mountain — no shop is open; use open_shop first 〔自动〕
- 08:00 动作 `close_menu` 失败 @ Mountain — no menu is open 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Town — exit to Saloon did not open (closed? locked? check opening hours). Recent messages: A train is passing 
through Stardew 
Valley.  | It's locked... (Open 12:00pm - 12:00am) | 游戏消息: [dialogue] It's locked... (Open 12:00pm - 12:00am) 〔自动〕
- 09:30 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 09:30 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 09:30 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 12:00 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 12:40 动作 `craft` 失败 @ Farm — can't craft Scarecrow: not enough ingredients: Wood x50, Coal x1, Fiber x20 〔自动〕
- 12:40 动作 `place` 失败 @ Farm — Scarecrow 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 13:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:20 动作 `place` 失败 @ Farm — can't place Maple Seed at (23,9) (needs tilled soil for seeds? wrong season? tile occupied?) 〔自动〕
- 13:20 动作 `place` 失败 @ Farm — can't place Maple Seed at (25,9) (needs tilled soil for seeds? wrong season? tile occupied?) 〔自动〕
- 13:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 稻草人 craft 成功但两次 place 均失败，防乌鸦措施无法落地 @ 农场菜地/箱子旁 — Scarecrow 在规划的分区里没有空位了（不在分区外乱放）；craft 前未先清出空位（做不了：种地无稻草人保护，乌鸦风险高；稻草人占背包格） 〔复盘〕
- 12:00 前两次去 Saloon 均被锁，浪费等待时间 @ Town / Saloon — exit to Saloon did not open (closed? locked? check opening hours). It's locked... (Open 12:00pm - 12:00am)（做不了：买沙拉延后，下矿食物准备不足） 〔复盘〕
- 14:00 前到 Mountain 调 open_shop 买剑失败，冒险家公会未开门 @ Mountain / AdventurerGuild — can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent)（做不了：Silver Saber 未买到，无法安全下 40 层以下） 〔复盘〕
- 下矿仅下 2 层就体力耗尽，食物消耗快 @ Mine floor 35-37 — low stamina; You're starting to feel exhausted（做不了：无法继续下矿刷铜/煤/铁，目标 25 层未达成） 〔复盘〕
- 背包满导致下矿捡矿受阻 @ Mine floor 35-37 — Inventory Full（做不了：部分矿石无法拾取，需回农场存箱） 〔复盘〕
- 买沙拉钱不够 3 份，只买到 3 份但背包满，后续无法捡矿 @ Saloon — bought 3x Salad for 660g；背包满(空1格)（做不了：下矿时背包无空位，矿石无法拾取） 〔复盘〕

## 🌙 为明天（Y1_summer_23）准备的脚本
- 里程碑：稻草人（Wood 28/50，差22）——砍树凑够50木头
- 铜斧头升级完成，取回铜斧头
- 清大树桩扩耕地
- 下矿刷铜/煤/铁（带足食物，floors≤3，目标25层）
- 顺路买沙拉备食物
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `clear_debris`（radius=8, max=25, kinds=["twig", "weed"]）
5. `use_tool`（tool="axe", x=30, y=20, times=1, until_cleared=true）
6. `use_tool`（tool="axe", x=32, y=22, times=1, until_cleared=true）
7. `use_tool`（tool="axe", x=34, y=20, times=1, until_cleared=true）
8. `use_tool`（tool="axe", x=36, y=22, times=1, until_cleared=true）
9. `craft`（item="Scarecrow", count=1）
10. `place`（item="Scarecrow", x=20, y=8）
11. `goto_location`（location="Blacksmith"）
12. `upgrade_tool`
13. `goto_location`（location="Town"）
14. `open_shop`（shop_id="Saloon"）
15. `buy`（item="Salad", count=3）
16. `close_menu`
17. `goto_location`（location="Mountain"）
18. `open_shop`（shop_id="AdventurerGuild"）
19. `buy`（item="Silver Saber", count=1）
20. `close_menu`
21. `mine`（floors=3）
22. `goto_location`（location="Farm"）
23. `ship_produce`
24. `store_items`
25. `sleep`

## 📊 当天结算（第二天早上统计）
- 金钱：2408 → 2420（+12g）
- 出货估值：12g　动作：58 个　失败：18 个
- 模型调用：7 次　tokens：70250
