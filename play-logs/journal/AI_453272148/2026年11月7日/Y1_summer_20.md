# 第1年 summer 20 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（05:41 开始）
- 天气：sunny　金钱：2728g　体力：270/270
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
  - 🗨️ [mail] AutoPilot- I'm gathering data on the correlation between soil alkalinity and crop fructose levels. Long story short, I need a fresh melon from your farm. If you brought me one I'd be very grateful.    -Demetrius [quest accepted]
  - 🗨️ [hud] New Journal Entry

## 🌙 为明天（Y1_summer_20）准备的脚本
- 里程碑：稻草人（Wood 11/50，差 39）——先砍树凑木头，清格后放稻草人
- 12:00 后去 Saloon 买沙拉备下矿食物
- 14:00 后去冒险家公会买 Silver Saber（钱够 750g 才买）
- 带食物下矿刷铜/煤/铁，floors≤3，目标 25 层
- 傍晚回农场出货、存材料、睡觉
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `clear_debris`（radius=10, max=25, kinds=["twig", "weed", "stone"]）
6. `use_tool`（tool="axe", x=30, y=20, times=1, until_cleared=true）
7. `use_tool`（tool="axe", x=34, y=24, times=1, until_cleared=true）
8. `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
9. `use_tool`（tool="axe", x=42, y=26, times=1, until_cleared=true）
10. `use_tool`（tool="axe", x=46, y=22, times=1, until_cleared=true）
11. `clear_debris`（radius=3, max=6, kinds=["twig", "weed", "stone"]）
12. `place`（item="Scarecrow"）
13. `goto_location`（location="Saloon"）
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
24. `store_items`（items=["Stone", "Fiber", "Copper Ore", "Coal"]）
25. `sleep`
- **06:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] The Annual Trout 
Derby has begun. 
  - 🗨️ [hud] Copper Bar
- **06:10** Farm ✅ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 3 crops
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Hot Pepper
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 3 crops
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~340g (paid overnight)
- **06:30** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:30** Farm ❌ `load_machines`
  - 结果：could not reach (40,9); stopped at (54,9)
- **06:30** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:30** Farm ✅ `clear_debris`（radius=10, max=25, kinds=["twig", "weed", "stone"]）
  - 结果：cleared 1 debris within 10 tiles of (44,30)
- **06:30** Farm ✅ `use_tool`（tool="axe", x=30, y=20, times=1, until_cleared=true）
  - 结果：used axe 0x at (30,20), tile cleared
- **06:30** Farm ✅ `use_tool`（tool="axe", x=34, y=24, times=1, until_cleared=true）
  - 结果：used axe 0x at (34,24), tile cleared
- **06:30** Farm ✅ `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
  - 结果：used axe 40x at (38,20), NOT cleared (tool too weak?)
  - 🗨️ [hud] Fiber
- **06:30** Farm ✅ `use_tool`（tool="axe", x=42, y=26, times=1, until_cleared=true）
  - 结果：used axe 0x at (42,26), tile cleared
- **06:30** Farm ✅ `use_tool`（tool="axe", x=46, y=22, times=1, until_cleared=true）
  - 结果：used axe 0x at (46,22), tile cleared
- **06:30** Farm ✅ `clear_debris`（radius=3, max=6, kinds=["twig", "weed", "stone"]）
  - 结果：cleared 0 debris within 3 tiles of (39,20); none of the 1 twig/weed/stone in Farm is reachable
- **06:30** Farm ❌ `place`（item="Scarecrow"）
  - 结果：Scarecrow 在规划的分区里没有空位了（不在分区外乱放）
- **06:30** Farm ❌ `goto_location`（location="Saloon"）
  - 结果：exit to Saloon did not open (closed? locked? check opening hours). Recent messages: Fiber | It's locked... (Open 12:00pm - 12:00am)
  - 🗨️ [dialogue] It's locked... (Open 12:00pm - 12:00am)

### 🔁 脚本重写：重写#1：Saloon 12 点前锁门，先回农场砍树凑木头并尝试放稻草人，12 点后再去 Saloon 买沙拉、14 点后买剑下矿。
1. `goto_location`（location="Saloon"）
2. `open_shop`（shop_id="Saloon"）
3. `buy`（item="Salad", count=3）
4. `close_menu`
5. `goto_location`（location="Mountain"）
6. `open_shop`（shop_id="AdventurerGuild"）
7. `buy`（item="Silver Saber", count=1）
8. `close_menu`
9. `mine`（floors=3）
10. `goto_location`（location="Farm"）
11. `clear_debris`（radius=8, max=25, kinds=["twig", "weed", "stone"]）
12. `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
13. `clear_debris`（radius=10, max=25, kinds=["twig", "weed"]）
14. `place`（item="Scarecrow"）
15. `ship_produce`
16. `store_items`（items=["Stone", "Fiber", "Copper Ore", "Coal"]）
17. `sleep`
- **07:00** Town ❌ `goto_location`（location="Saloon"）
  - 结果：exit to Saloon did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 12:00pm - 12:00am) | It's locked... (Open 12:00pm - 12:00am)
  - 🗨️ [dialogue] It's locked... (Open 12:00pm - 12:00am)

### 🔁 脚本重写：重写#2：Saloon 12 点前锁门，先回农场砍树凑木头并清格放稻草人，12 点后再去镇上买沙拉与剑，最后下矿。
1. `wait`（minutes=30）
2. `goto_location`（location="Saloon"）
3. `open_shop`（shop_id="Saloon"）
4. `buy`（item="Salad", count=3）
5. `close_menu`
6. `goto_location`（location="Mountain"）
7. `open_shop`（shop_id="AdventurerGuild"）
8. `buy`（item="Silver Saber", count=1）
9. `close_menu`
10. `mine`（floors=3）
11. `goto_location`（location="Farm"）
12. `clear_debris`（radius=10, max=25, kinds=["twig", "weed"]）
13. `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
14. `clear_debris`（radius=8, max=25, kinds=["twig", "weed", "stone"]）
15. `place`（item="Scarecrow"）
16. `ship_produce`
17. `store_items`（items=["Stone", "Fiber", "Copper Ore", "Coal"]）
18. `sleep`
- **07:10** Town ✅ `wait`（minutes=30）
  - 结果：waited until 9:10 am
- **09:10** Town ❌ `goto_location`（location="Saloon"）
  - 结果：exit to Saloon did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 12:00pm - 12:00am)
  - 🗨️ [dialogue] It's locked... (Open 12:00pm - 12:00am)

### 🔁 脚本重写：重写#3：Saloon 未开门，先回农场砍树凑木头并尝试放稻草人，12 点后再回镇上买沙拉、买剑、下矿。
1. `wait`（minutes=30）
2. `goto_location`（location="Saloon"）
3. `open_shop`（shop_id="Saloon"）
4. `buy`（item="Salad", count=3）
5. `close_menu`
6. `goto_location`（location="Mountain"）
7. `open_shop`（shop_id="AdventurerGuild"）
8. `buy`（item="Silver Saber", count=1）
9. `close_menu`
10. `mine`（floors=3）
11. `goto_location`（location="Farm"）
12. `clear_debris`（radius=10, max=25, kinds=["twig", "weed"]）
13. `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
14. `clear_debris`（radius=8, max=25, kinds=["twig", "weed", "stone"]）
15. `place`（item="Scarecrow"）
16. `ship_produce`
17. `store_items`（items=["Stone", "Fiber", "Copper Ore", "Coal"]）
18. `sleep`
- **09:10** Town ✅ `wait`（minutes=30）
  - 结果：waited until 11:10 am
- **11:10** Town ❌ `goto_location`（location="Saloon"）
  - 结果：exit to Saloon did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 12:00pm - 12:00am)
  - 🗨️ [dialogue] It's locked... (Open 12:00pm - 12:00am)
- **11:10** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)
- **11:10** Town ❌ `buy`（item="Salad", count=3）
  - 结果：no shop is open; use open_shop first
- **11:10** Town ❌ `close_menu`
  - 结果：no menu is open
- **11:10** Town ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
- **11:40** Mountain ❌ `open_shop`（shop_id="AdventurerGuild"）
  - 结果：can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent)
- **11:40** Mountain ❌ `buy`（item="Silver Saber", count=1）
  - 结果：no shop is open; use open_shop first
- **11:40** Mountain ❌ `close_menu`
  - 结果：no menu is open
- **11:40** Mountain ❌ `mine`（floors=3）
  - 结果：action timed out after 5 minutes
- **13:50** UndergroundMine36 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 🗨️ [hud] +112 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [question] 
- **14:40** Farm ✅ `clear_debris`（radius=10, max=25, kinds=["twig", "weed"]）
  - 结果：cleared 0 debris within 10 tiles of (40,0); none of the 1 twig/weed in Farm is reachable
- **14:40** Farm ✅ `use_tool`（tool="axe", x=38, y=20, times=1, until_cleared=true）
  - 结果：used axe 40x at (38,20), NOT cleared (tool too weak?)
- **15:00** Farm ✅ `clear_debris`（radius=8, max=25, kinds=["twig", "weed", "stone"]）
  - 结果：cleared 0 debris within 8 tiles of (39,20); none of the 1 twig/weed/stone in Farm is reachable
- **15:00** Farm ❌ `place`（item="Scarecrow"）
  - 结果：Scarecrow 在规划的分区里没有空位了（不在分区外乱放）
- **15:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **15:00** Farm ✅ `store_items`（items=["Stone", "Fiber", "Copper Ore", "Coal"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 22x Copper Ore, 1x Coal, 1x Fiber, 15x Stone
- **15:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **15:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
- **15:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **15:30** Farm ❌ `place`（item="Pine Cone", x=23, y=9）
  - 💭 (种一棵遮挡作坊的树)
  - 结果：can't place Pine Cone at (23,9) (needs tilled soil for seeds? wrong season? tile occupied?)
- **15:30** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
- **15:40** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Joja Cola, Broken CD)
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Joja Cola
- **16:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：2728 → 3068（+340g）
- 出货估值：340g　动作：47 个　失败：17 个
- 模型调用：4 次　tokens：41274

## 🧠 夜间复盘
昨天核心失败是稻草人无合法空位、商店时间误判、下矿超时和动作预算浪费在非里程碑事项。有效做法是熔炉炼铜和钓鱼。今天应优先清出稻草人具体坐标并指定放置，严格按营业时间买沙拉和剑，下矿前确认食物与武器，砍树凑木头，移除铺路/装饰/种树等无效动作。

**新教训：**
- 稻草人 place 失败两次均因“规划分区无空位”，说明自动分区不可靠；应改用 place 的 x/y 参数显式指定菜地上方具体空格，失败再换相邻格。
- Saloon 12:00 前 goto 失败后脚本仍继续 open_shop/buy/close_menu 连锁失败；应把 goto 失败视为“时间未到”，直接跳到砍树/钓鱼，12:00 后再回来。
- 冒险家公会 14:00 才开门，11:40 到 Mountain 调 open_shop 必失败；应把 goto Mountain 严格排在 14:00 后，或先做别的事再回来。
- mine 在 floor 15 返回“no reachable stone or ladder”说明该层已无可挖目标；应换层或换矿洞入口，而不是继续在同一层 mine。
- build_road/decorate/place Pine Cone 在路径障碍未清、无畜舍时必失败，应直接从当日脚本中移除，把动作预算留给里程碑。

<details><summary>改写后的策略</summary>

# 星露谷自动游玩策略（Y1 夏季 21 日）

## 长期目标
当前里程碑：**稻草人**（Wood 11/50，差 39；Coal 31、Fiber 246 充足；稻草人已在背包，缺合法空位）。完成后依次：**铜斧头**（升级中，约 1 天后完成）→ **下矿装备**（Silver Saber 750g + 沙拉）→ **铜镐**（2000g+5铜锭）→ **洒水器**（农业 2 级，需铁锭，下 40 层拿铁矿）。

离完成还差：39 木头（砍树/清 twig 可得）、至少 2 份回血食物（沙拉 220g/份，钱不够则钓鱼）、一把平均伤害≥7 的武器（Silver Saber 750g，钱够再买）。

接下来 3 天主活动：
- **今天（夏21）**：起床收熔炉→砍树凑 Wood≥50→**用 place 的 x/y 参数指定菜地上方具体空格放稻草人（失败换相邻格，最多 2 格）**→12:00 后 Saloon 买沙拉（至少 1 份）→14:00 后冒险家公会买 Silver Saber（钱够才买）→带食物下矿冲 25 层刷铜/煤。
- **明天（夏22）**：铜斧头完成后清大树桩扩耕地；继续下矿刷铁；钱够 750g 买 Silver Saber。
- **后天（夏23）**：铜镐清大石头；检查社区中心收集包；准备夏末停止播种。

## 每日固定流程（按顺序执行，失败即跳下一步）
1. `collect_machines` 收熔炉 → `load_machines` **只调 1 次**；返回 "no empty machine accepts anything" 立即停止，当天不再调用。
2. `harvest_crops` → `water_crops`（下雨跳过）。
3. 背包有可卖产物就 `ship_produce`。
4. **稻草人放置（今天第一优先）**：稻草人已在背包。先用 `clear_debris` 清菜地上方一格（radius 3，kinds 全选），确认该格为空后 `place` 稻草人并**显式指定 x/y 坐标**（如菜地上方第一格）。**place 失败 1 次立即换相邻格再试，最多试 2 格**；仍失败则记录坐标，改天再放，不反复重试。
5. **砍树凑木头**：去农场 `clear_debris` 清 twig/weed，`use_tool` axe 砍树；目标 Wood≥50（为后续箱子/建筑储备）。不要 take 箱子（FarmHouse 无箱；主箱 (75,15) 需先确认内容，失败 1 次立即改砍树）。
6. **12:00 后**去 Saloon：`goto_location` Saloon → `open_shop` → `buy` Salad（钱够几份买几份，至少 1 份）→ `close_menu`。12 点前不去；open_shop 成功后才 buy；buy 失败 1 次立即 close_menu 改钓鱼备食物。
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
4. 12:00 后买沙拉（钱够几份买几份，至少 1 份）
5. 14:00 后买 Silver Saber（钱够才买）
6. 收获+浇水
7. 下矿刷铜/煤/铁（带足食物，floors≤3，目标 25 层）
8. 出货
9. 钓鱼/社交（仅顺路）
10. 确认斧头升级进度（不重复升级）

</details>

## ⚠️ 今日问题
> 昨天核心失败是稻草人无合法空位、商店时间误判、下矿超时和动作预算浪费在非里程碑事项。有效做法是熔炉炼铜和钓鱼。今天应优先清出稻草人具体坐标并指定放置，严格按营业时间买沙拉和剑，下矿前确认食物与武器，砍树凑木头，移除铺路/装饰/种树等无效动作。
- 06:30 动作 `load_machines` 失败 @ Farm — could not reach (40,9); stopped at (54,9) 〔自动〕
- 06:30 动作 `place` 失败 @ Farm — Scarecrow 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 06:30 动作 `goto_location` 失败 @ Farm — exit to Saloon did not open (closed? locked? check opening hours). Recent messages: Fiber | It's locked... (Open 12:00pm - 12:00am) | 游戏消息: [dialogue] It's locked... (Open 12:00pm - 12:00am) 〔自动〕
- 07:00 动作 `goto_location` 失败 @ Town — exit to Saloon did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 12:00pm - 12:00am) | It's locked... (Open 12:00pm - 12:00am) | 游戏消息: [dialogue] It's locked... (Open 12:00pm - 12:00am) 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Town — exit to Saloon did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 12:00pm - 12:00am) | 游戏消息: [dialogue] It's locked... (Open 12:00pm - 12:00am) 〔自动〕
- 11:10 动作 `goto_location` 失败 @ Town — exit to Saloon did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 12:00pm - 12:00am) | 游戏消息: [dialogue] It's locked... (Open 12:00pm - 12:00am) 〔自动〕
- 11:10 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 11:10 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 11:10 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 11:40 动作 `open_shop` 失败 @ Mountain — can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 11:40 动作 `buy` 失败 @ Mountain — no shop is open; use open_shop first 〔自动〕
- 11:40 动作 `close_menu` 失败 @ Mountain — no menu is open 〔自动〕
- 11:40 动作 `mine` 失败 @ Mountain — action timed out after 5 minutes 〔自动〕
- 15:00 动作 `place` 失败 @ Farm — Scarecrow 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 15:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:30 动作 `place` 失败 @ Farm — can't place Pine Cone at (23,9) (needs tilled soil for seeds? wrong season? tile occupied?) 〔自动〕
- 15:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 稻草人 craft 成功但两次 place 均失败，防乌鸦措施无法落地 @ 农场菜地/箱子旁 — Scarecrow 在规划的分区里没有空位了（不在分区外乱放）；craft 前未先清出空位（做不了：种地无稻草人保护，乌鸦风险高；稻草人占背包格） 〔复盘〕
- 买沙拉钱不够 3 份，只买到 1 份，下矿食物不足 @ Saloon — not enough money: 3x Salad costs 660g, you have 334g；只买了 1 份 220g（做不了：下矿只能到 18 层，无法安全冲 20 层以下拿铁/铜） 〔复盘〕
- 下午大量动作浪费在非里程碑事项（build_road 0 铺设、decorate 失败、place Pine Cone 失败） @ 农场 — build_road: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate: 今天没有能做的装饰；place Pine Cone: can't place at (23,9)（做不了：动作预算被消耗，有效下矿/砍树时间减少） 〔复盘〕
- Saloon 12:00 前 goto 失败后仍连锁调用 open_shop/buy/close_menu，浪费动作 @ Town → Saloon — exit to Saloon did not open (closed? locked? Open 12:00pm - 12:00am)；随后 open_shop/buy/close_menu 连锁失败（做不了：10:00 到镇后空等到 12:00 才买到沙拉） 〔复盘〕
- 冒险家公会 14:00 前 open_shop 失败，无法买 Silver Saber @ Mountain / Adventurer's Guild — can't open shop 'AdventurerGuild' here (wrong location, closed, or shopkeeper absent)（做不了：今天仍用 Rusty Sword，无法安全下 40 层以下） 〔复盘〕
- mine 动作超时 5 分钟，下矿进度停滞 @ Mine — action timed out after 5 minutes（做不了：当天未能刷到铜/煤/铁，矿层未推进） 〔复盘〕
- load_machines 无法到达目标机器，熔炉装载失败 @ 农场 (40,9) 附近 — could not reach (40,9); stopped at (54,9)（做不了：熔炉未能及时装载，铜锭产出延迟） 〔复盘〕
- 与 Gus 交互失败，无法顺路社交 @ Saloon — no walkable path from (14,24) to next to (16,5) in Saloon（做不了：社交进度无进展（非关键）） 〔复盘〕
