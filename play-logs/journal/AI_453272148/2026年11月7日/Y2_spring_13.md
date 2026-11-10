# 第2年 spring 13 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（21:52 开始）
- 天气：sunny　金钱：9696g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 🗨️ [mail] Dear AutoPilot,   I saw an article about you in the local paper! It sounds like the country life is a good fit for you! I'm so proud of you. Take care, sweety. Love, Mom
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship

## 🌙 为明天（Y2_spring_13）准备的脚本
- 里程碑：钢斧头（5000g+5铁锭）——今天先确保熔炉炼出铁，再下矿40-44层拿铁矿
- 复活节：9:00-14:00 去镇上参加 Egg Festival，买草莓种子（约100g/个）
- 节日结束后回农场把草莓种子种下
- 傍晚白名单出货，留铁锭/铜锭/煤/铁矿/种子/洒水器
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `water_crops`
4. `goto_location`（location="Town"）
5. `festival`（activity="start"）
6. `goto_location`（location="SeedShop"）
7. `open_shop`（shop_id="SeedShop"）
8. `buy`（item="Strawberry Seeds", count=20）
9. `close_menu`
10. `goto_location`（location="Farm"）
11. `plant_seeds`（item="Strawberry Seeds", count=20）
12. `goto_location`（location="Mine"）
13. `mine`（floors=4）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `ship_produce`（except=["Iron Bar", "Copper Bar", "Coal", "Iron Ore", "Strawberry Seeds", "Sprinkler", "Garlic Seeds", "Kale Seeds", "Potato Seeds", "Rice Shoot", "Mixed Seeds"]）
18. `sleep`
- **06:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:00** Farm ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：节日尚未开放，先回农场炼铁/放洒水器/下矿拿铁，9点后再进城参加复活节买草莓种子并种下。
1. `goto_location`（location="Mine"）
2. `mine`（floors=4）
3. `leave_mine`
4. `goto_location`（location="Town"）
5. `festival`（activity="start"）
6. `goto_location`（location="SeedShop"）
7. `open_shop`（shop_id="SeedShop"）
8. `buy`（item="Strawberry Seeds", count=20）
9. `close_menu`
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `water_crops`
14. `place`（item="Sprinkler", x=51, y=14）
15. `place`（item="Sprinkler", x=52, y=14）
16. `plant_seeds`（item="Strawberry Seeds", count=20）
17. `collect_machines`
18. `ship_produce`（except=["Iron Bar", "Copper Bar", "Coal", "Iron Ore", "Strawberry Seeds", "Sprinkler", "Garlic Seeds", "Kale Seeds", "Potato Seeds", "Rice Shoot", "Mixed Seeds"]）
19. `sleep`
- **06:20** BusStop ❌ `goto_location`（location="Mine"）
  - 结果：no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town)
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#2：去矿洞路线被节日封锁，改为回农场炼铁、浇水、放洒水器，9点后参加复活节买草莓种子并当天种下。
1. `goto_location`（location="Town"）
2. `festival`（activity="start"）
3. `goto_location`（location="SeedShop"）
4. `open_shop`（shop_id="SeedShop"）
5. `buy`（item="Strawberry Seeds", count=20）
6. `close_menu`
7. `goto_location`（location="Farm"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `water_crops`
11. `place`（item="Sprinkler", x=51, y=14）
12. `place`（item="Sprinkler", x=52, y=14）
13. `plant_seeds`（item="Strawberry Seeds", count=20）
14. `collect_machines`
15. `ship_produce`（except=["Iron Bar", "Copper Bar", "Coal", "Iron Ore", "Strawberry Seeds", "Sprinkler", "Garlic Seeds", "Kale Seeds", "Potato Seeds", "Rice Shoot", "Mixed Seeds"]）
16. `sleep`
- **07:50** Forest ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#3：节日布置中镇门锁死，改回农场炼铁、浇水、落地洒水器并种下现有种子，傍晚出货后睡觉。
1. `goto_location`（location="Farm"）
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `water_crops`
5. `place`（item="Sprinkler", x=51, y=14）
6. `place`（item="Sprinkler", x=52, y=14）
7. `plant_seeds`（item="Potato Seeds", count=10）
8. `plant_seeds`（item="Kale Seeds", count=5）
9. `ship_produce`（except=["Iron Bar", "Copper Bar", "Coal", "Iron Ore", "Strawberry Seeds", "Sprinkler", "Garlic Seeds", "Kale Seeds", "Potato Seeds", "Rice Shoot", "Mixed Seeds"]）
10. `sleep`
- **07:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
- **08:10** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **08:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **08:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **08:10** Farm ❌ `place`（item="Sprinkler", x=51, y=14）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
- **08:10** Farm ❌ `place`（item="Sprinkler", x=52, y=14）
  - 结果：Sprinkler 今天已确认分区无空位
- **08:10** Farm ✅ `plant_seeds`（item="Potato Seeds", count=10）
  - 结果：planted 10x Potato Seeds in plot (51,14) 6x4, 4 tiles unusable
- **08:40** Farm ✅ `plant_seeds`（item="Kale Seeds", count=5）
  - 结果：planted 5x Kale Seeds in plot (51,14) 6x4, 5 tiles unusable
- **08:40** Farm ✅ `ship_produce`（except=["Iron Bar", "Copper Bar", "Coal", "Iron Ore", "Strawberry Seeds", "Sprinkler", "Garlic Seeds", "Kale Seeds", "Potato Seeds", "Rice Shoot", "Mixed Seeds"]）
  - 结果：nothing to ship
- **08:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **08:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
- **08:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Joja Cola, Joja Cola)
  - 🗨️ [hud] The Egg Festival has 
begun in the town 
square. 
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Joja Cola
- **10:00** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
- **10:00** Farm ✅ `ship`（item="Joja Cola", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Joja Cola (~50g, paid overnight)
- **10:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Joja Cola, Broken Glasses)
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Joja Cola
- **11:10** Farm ✅ `ship`（item="Trash", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Trash (~0g, paid overnight)
- **11:10** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
- **11:10** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
- **11:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 1:10 pm
- **13:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 3:10 pm
- **15:10** Farm ✅ `wait`（minutes=110, filler=true）
  - 结果：waited until 5:00 pm
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：9696 → 9771（+75g）
- 出货估值：0g　动作：33 个　失败：10 个
- 模型调用：5 次　tokens：58057

## 🧠 夜间复盘
昨天节日锁镇导致 goto Town/Mine 全失败，脚本重写3次仍空转，wait 浪费4小时；熔炉装料失败根因是炉内铜矿未取出，铁锭停在1/5；洒水器分区无空位，place 失败后未清障；钓鱼全是垃圾低值。今天必须：先取炉内铜矿再装铁、清障放洒水器、主活动下矿拿铁，节日锁门直接跳过不重试。

**新教训：**
- 节日当天（如复活节）Town 所有出口锁死，goto Town/Mine 必失败；脚本层应直接禁用所有 goto Town 分支，主活动改为农场/森林/矿洞（矿洞入口在 Mountain，但需经 Town 中转时也走不通，应改走 Farm→Backwoods→Mountain 或直接放弃下矿改钓鱼）。
- 熔炉 load_machines 返回 'no empty machine accepts anything' 且 collect 返回 'no machine has finished output' 时，说明炉内被铜矿占满：必须先取出炉内铜矿（用 collect 或手动），再装铁矿，不能只靠 collect 判断空炉。
- 洒水器 place 返回 'Sprinkler 在规划的分区里没有空位了' 时，继续在同一分区 place 只会重复失败；应先 chop_tree/清杂物腾出空位或换锚点，再 place，且必须带 x,y 坐标。
- wait(filler) 把时间推到 17:00 不产生任何金钱或材料，昨天因此浪费4小时；脚本做完主活动后应直接 sleep 或转钓鱼，禁止用 wait 填充时间。
- Mountain 湖钓鱼大量产出 Carp/Green Algae/Joja Cola 等低值物，现金缺口大时应优先下矿拿铁或换 River/海边，而不是全天低值钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春14）

## 长期目标
当前里程碑：**工具按档升级——钢斧头（5000g+5铁锭）**。现状：铁锭1/5，背包 Iron Ore 3、Coal 13、现金9696g（钱已够），只差4铁锭。并行里程碑：**洒水器×4落地**（已craft但分区无空位）、**钓鱼2级+玻璃纤维竿+鱼饵**（竿已买，饵用完）。
- 钢斧头：铁锭≥5且现金≥5000g 才去 Blacksmith；今天必须让熔炉真正炼出铁（先取铜矿再装铁矿）。
- 洒水器×4：今天清出分区空位并 place，不再 craft。
- 鱼饵：现金≥150g 且时间<16:30 去威利店买20个，open_shop 后一次性买完。

接下来3天主活动：
- **今天（春14，复活节）**：节日锁镇，Town 全禁。① collect_machines 取炉内铜矿（若满）→ 显式装 Iron Ore 炼铁 → ② 清障后 place 洒水器（带 x,y）→ ③ 主活动：Mountain 湖边钓鱼4轮（若时间<15:00 且体力≥30，改下矿40-44层拿铁矿，目标5块）→ ④ 傍晚白名单出货。
- **明天（春15）**：铁锭够5且现金≥5000g 去 Blacksmith 升钢斧头；不够则继续下矿/炼铁。
- **后天（春16）**：确认洒水器全部落地，开始规划夏季啤酒花/蓝莓地块。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. **熔炉**：`collect_machines`（≤2次）→ 若返回有铜锭/铜矿产出先取出；确认炉空且背包有 Iron Ore 时 `load_machines` 显式 item=Iron Ore 装1次；返回 "no empty machine" 或 "all machines are busy" 立即熔断，当天不再调用。**熔炉只装铁矿，铜矿全部存箱子**。若 collect 返回 "no machine has finished output" 但仍 load 失败，说明炉内被铜矿占满：先取出炉内铜矿（用 collect 或手动），再装铁。
2. **浇水**：水壶在背包则 `water_crops` 1次；返回 "no watering can" 说明水壶在升级，跳过。
3. **洒水器落地**：先检查规划分区是否有空位；无空位先 `chop_tree`/清杂物或换锚点，再 `place` 已craft的洒水器（≤2次，**必须带 x,y 坐标**）。place 失败即换锚点，不在同一位置重试。
4. **清背包**：空格<5 时先 `ship_produce` 白名单清出≥5格，再进商店或钓鱼。
5. **买鱼饵（仅当现金≥150g 且时间<16:30）**：`goto_location` FishShop → 确认返回 arrived 且时间≥9:00 → `open_shop` 确认 OK → `buy` Bait 20个 → `close_menu`。现金<150g 跳过。**FishShop 9:00-17:00，16:30后不去**。**买饵必须在 open_shop 后一次性完成，关菜单后不再 buy**。
6. **主活动=钓鱼攒钱**：`goto_location` Mountain 湖边 → `fish casts=6`，最多4轮（≤4次 fish 调用）。**fish 必须放流程最后单独执行**；fish 返回后先确认状态再发下一个动作。
7. **下矿拿铁（仅当时间<15:00 且体力≥30）**：`goto_location` Mine 入口 → `mine` 目标40-44层，到45层无产出立即 leave_mine；生命<50% 或食物=0 立即 leave_mine。**下矿前确认背包有食物≥5**。
8. **买种子（仅当现金≥2200g 且空格≥5）**：只买已解锁春季作物（土豆/花椰菜/大蒜/Kale），单次 buy≤2次，现金留≥1800g。现金<2200g 当天不买种子。
9. 回农场 `plant_seeds`（≤2次，**失败换锚点或先清杂物，不在同一锚点重试**）。
10. 体力<15 或时间≥22:00 `sleep`；**22:00 强制 sleep**。

## 规则
- **钓鱼并发熔断**：任何动作返回 "busy with 'fish'" 时，脚本层立即停止发新动作，等 fish 返回；`close_menu` 不能中断钓鱼，禁止用它。**禁止在 fish 未结束时连发 collect/load/ship/goto**。
- **熔炉优先**：每天第一步先 `collect_machines` 确认熔炉空，再显式装 Iron Ore。load_machines 每天≤2次，返回 "no empty machine" 或 "all machines are busy" 即熔断。**熔炉只炼铁，铜矿全部存箱子**。
- **现金目标**：每天结束现金≥当天开始+100g，否则第二天主活动强制改为钓鱼。
- **空转硬熔断**：任何动作返回 "no empty machine accepts anything"、"all machines are busy"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"none of the ... is reachable"、"inventory full"、"no free soil near the anchor"、"Sprinkler 在规划的分区里没有空位" 等，脚本层立即永久跳过该分支，当天不再调用，转去钓鱼或砍树。**禁止 wait**。
- **place 必须带坐标**：place 洒水器/种子前先确定目标格 (x,y)，缺参数直接不调用，避免空失败。
- **18层永久拉黑**；**45层以上不追**：mine 目标锁定40-44层，到45层无产出立即 leave_mine；体力<30 不调 mine。
- **工具升级**：一次只升一件；升级期间（2天）不调 mine（无镐）也不调 water_crops（无水壶）。**升级中不重复交付**；升级前显式检查现金≥费用且锭够，不足直接跳过。
- **clear_debris / build_road / decorate 禁用**。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait。节日当天主活动=下矿/钓鱼/砍树。**节日当天不跑 Blacksmith**。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅9:10-15:30）、`interact` 同一NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会14:00-22:00；皮埃尔9-17（周三休）；Saloon12:00-24:00；Blacksmith9:00-16:00；**FishShop 9:00-17:00，16:30后不去**。营业时间前不调用 goto/open_shop/buy。**16:00后不再去 Blacksmith**。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；**Backwoods 不作为中转**。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下。
- **季末规划**：春季作物在夏季第1天枯死；季末只种能在28日前成熟的作物。
- **社交**：顺路2-4人，不专门跑图。
- **每20动作自检**：若今天金钱或材料增量为0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. collect 熔炉+装 Iron Ore 炼铁锭（≤2次，只炼铁）
2. 浇水（水壶在背包时）
3. 洒水器落地（先清空位/换锚点，带坐标）
4. 清背包+白名单出货
5. 买鱼饵（现金≥150g，<16:30）
6. 钓鱼攒钱（Mountain 湖边，放最后单独执行，4轮）
7. 下矿拿铁（时间<15:00 且体力≥30，目标40-44层）
8. 现金≥2200g 且空格≥5 买已解锁春季种子
9. 种下（失败换锚点）
10. 砍树攒木头到150
11. 社交（仅顺路）

</details>

## ⚠️ 今日问题
> 昨天节日锁镇导致 goto Town/Mine 全失败，脚本重写3次仍空转，wait 浪费4小时；熔炉装料失败根因是炉内铜矿未取出，铁锭停在1/5；洒水器分区无空位，place 失败后未清障；钓鱼全是垃圾低值。今天必须：先取炉内铜矿再装铁、清障放洒水器、主活动下矿拿铁，节日锁门直接跳过不重试。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `goto_location` 失败 @ Farm — exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 06:20 动作 `goto_location` 失败 @ BusStop — no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set u 〔自动〕
- 07:50 动作 `goto_location` 失败 @ Forest — exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 08:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 08:10 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 08:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 08:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 08:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 节日锁镇导致 goto Town/Mine 全部失败，脚本重写3次仍反复尝试 @ Town 出口 / Forest→Mine 路径 — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. / no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town)（做不了：无法进镇买饵、去 Blacksmith、下矿，全天只能困在农场/森林） 〔复盘〕
- 熔炉装料连续失败，铁锭停在1/5，钢斧头升级卡住 @ Farm 熔炉 — load_machines 返回 'no empty machine accepts anything in the backpack or the farm chests'，炉内被铜矿占满或仍在工作（做不了：铁锭无法增加，钢斧头升级延后，大树桩砍不了） 〔复盘〕
- 洒水器已craft 4个但分区无空位，place 连续失败 @ Farm 田地分区 (51,14) — place 返回 'Sprinkler 在规划的分区里没有空位了（不在分区外乱放）' / 'Sprinkler 今天已确认分区无空位'（做不了：洒水器放不下，无法自动化浇水，体力仍被手动浇水占用） 〔复盘〕
- wait(filler) 连续3次把时间从11:10推到17:00，全天无产出 @ Farm — wait 返回 OK 但只推进时间，不产生金钱或材料（做不了：浪费4小时本可用于钓鱼/下矿/砍树，当天金钱增量为0） 〔复盘〕
- 钓鱼全是垃圾低值物（Broken Glasses/Joja Cola/Trash），收入极低 @ Mountain 湖边 — fished: caught 3 (Broken Glasses, Joja Cola, Joja Cola) / (Trash, Joja Cola, Broken Glasses)（做不了：钓鱼攒钱效率低，现金增长慢） 〔复盘〕
- build_road 和 decorate 被排进流程但必然失败 @ Farm — build_road: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate: 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：浪费动作次数，且铺路材料白做） 〔复盘〕
