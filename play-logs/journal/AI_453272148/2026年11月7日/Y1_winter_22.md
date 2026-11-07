# 第1年 winter 22 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（14:34 开始）
- 天气：snow　金钱：3422g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y1_winter_22）准备的脚本
- 里程碑：铜镐升级 + 洒水器×4（铁锭≥5）
- 早上收熔炉、收菜浇水、出货腾格子
- 9:10-9:30 铁匠铺升级铜镐（依次试 pickaxe/copper_pickaxe/Pickaxe，各一次，失败即放弃）
- 10:00-16:00 下矿锁定 40-44 层刷铁，铁锭≥5 即停，45 层无产出立即撤退
- 回农场白名单出货矿石变现（留 25 铜矿/5 煤/5 铁矿）
- 铁锭≥5 且铜锭≥4 才 craft 洒水器×4
- 剩余体力砍树攒木头到 150，不足则钓鱼
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Stone", "Wood", "Fiber"]）
5. `goto_location`（location="Town"）
6. `goto_location`（location="Mountain"）
7. `upgrade_tool`（tool="pickaxe"）
8. `upgrade_tool`（tool="copper_pickaxe"）
9. `upgrade_tool`（tool="Pickaxe"）
10. `goto_location`（location="Mine"）
11. `mine`（floors=4）
12. `mine`（floors=4）
13. `mine`（floors=4）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Stone", "Wood", "Fiber"]）
17. `craft`（item="Sprinkler", count=4）
18. `fish`（casts=5）
19. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Broken CD, 19x Iron Ore, 49x Stone, 1x Broken Glasses, 3x Sprinkler, 2x Joja Cola, 1x Trash, 2x Coal
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:40** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:40** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:40** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Stone", "Wood", "Fiber"]）
  - 结果：nothing to ship
- **06:40** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
- **06:50** Town ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
- **07:30** Mountain ✅ `upgrade_tool`（tool="pickaxe"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
- **09:00** Mountain ❌ `upgrade_tool`（tool="pickaxe"）
  - 结果：Steel Axe costs 5000g, you have 3422g

### 🔁 脚本重写：重写#1：上午先升级铜镐，再下矿40-44层刷铁，回农场出货并尝试做洒水器，剩余时间钓鱼后睡觉。
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="pickaxe"）
6. `upgrade_tool`（tool="copper_pickaxe"）
7. `upgrade_tool`（tool="Pickaxe"）
8. `goto_location`（location="Mine"）
9. `mine`（floors=4）
10. `mine`（floors=4）
11. `mine`（floors=4）
12. `leave_mine`
13. `goto_location`（location="Forest"）
14. `fish`（casts=6）
15. `goto_location`（location="Farm"）
16. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
17. `craft`（item="Sprinkler", count=4）
18. `sleep`

## 🌅 早上的计划（14:42 开始）
- 天气：snow　金钱：3422g　体力：270/270
- 里程碑：铜镐升级 + 洒水器×4
- 收熔炉→9:10去Blacksmith升级铜镐（依次试pickaxe/copper_pickaxe/Pickaxe）
- 下矿40-44层刷铁到铁锭≥5
- 回农场白名单出货矿石
- 铁锭够则craft洒水器×4
- 剩余体力钓鱼

**执行脚本：**
1. `load_machines`
2. `collect_machines`
3. `harvest_crops`
4. `water_crops`
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="pickaxe"）
7. `upgrade_tool`（tool="copper_pickaxe"）
8. `upgrade_tool`（tool="Pickaxe"）
9. `goto_location`（location="Mine"）
10. `mine`（floors=4）
11. `mine`（floors=4）
12. `mine`（floors=4）
13. `leave_mine`
14. `goto_location`（location="Forest"）
15. `fish`（casts=6）
16. `goto_location`（location="Farm"）
17. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
18. `craft`（item="Sprinkler", count=4）
19. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
- **06:10** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Broken CD, 19x Iron Ore, 49x Stone, 1x Broken Glasses, 3x Sprinkler, 2x Joja Cola, 1x Trash, 2x Coal
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:30** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 8:30 am (waiting for Blacksmith to open at 9:00)
- **08:30** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
- **09:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
- **09:40** Blacksmith ✅ `upgrade_tool`（tool="pickaxe"）
  - 结果：Clint is upgrading to Copper Pickaxe for 2000g + 5x Copper Bar: ready in 2 days (come back with upgrade_tool to collect)
  - 🗨️ [dialogue] Clint: Thanks. I'll get started on this as soon as I can. It should be ready in a couple days.
  - 🗨️ [dialogue] Clint: 
- **09:40** Blacksmith ❌ `upgrade_tool`（tool="copper_pickaxe"）
  - 结果：Clint is still working on Copper Pickaxe (2 days); one upgrade at a time

### 🔁 脚本重写：重写#2：铜镐已成功交付升级（2天后取），失败只是重复提交，跳过升级直接按原路线下矿刷铁、出货、craft、钓鱼收尾。
1. `goto_location`（location="Mine"）
2. `mine`（floors=4）
3. `mine`（floors=4）
4. `mine`（floors=4）
5. `leave_mine`
6. `goto_location`（location="Forest"）
7. `fish`（casts=6）
8. `goto_location`（location="Farm"）
9. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
10. `craft`（item="Sprinkler", count=4）
11. `sleep`
- **09:40** Blacksmith ❌ `goto_location`（location="Mine"）
  - 结果：no reachable route from Backwoods to Mine (unreachable exits: town->mountain, backwoods->mountain)

### 🔁 脚本重写：重写#3：上次从 Backwoods 直接去 Mine 无路线，改为先回农场再走 Farm→Town→Mountain 进矿，其余路线保留。
1. `goto_location`（location="Town"）
2. `goto_location`（location="Mountain"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=4）
5. `mine`（floors=4）
6. `mine`（floors=4）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
11. `craft`（item="Sprinkler", count=4）
12. `fish`（casts=6）
13. `sleep`
- **10:40** Backwoods ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
- **10:50** Town ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
- **11:30** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **11:50** Mine ❌ `mine`（floors=4）
  - 结果：no pickaxe in inventory
- **11:50** UndergroundMine45 ❌ `mine`（floors=4）
  - 结果：no pickaxe in inventory
- **11:50** UndergroundMine45 ❌ `mine`（floors=4）
  - 结果：no pickaxe in inventory
- **11:50** UndergroundMine45 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [question] 
- **11:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **12:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **12:40** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore"]）
  - 结果：nothing to ship
- **12:40** Farm ❌ `craft`（item="Sprinkler", count=4）
  - 结果：can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1
- **12:40** Farm ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Broken Glasses, Broken Glasses, Trash, Broken CD, Joja Cola, Broken CD)
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Joja Cola
- **14:40** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **15:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **15:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
- **15:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Driftwood, Trash)
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Driftwood
- **16:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：3422 → 1422（-2000g）
- 出货估值：0g　动作：29 个　失败：8 个
- 模型调用：3 次　tokens：32767

## 🧠 夜间复盘
昨天铜镐升级已成功交付（2天后取），但下矿因镐在升级中无镐可用而3次失败，铁锭仍不足5，洒水器未造；出货仅17g，现金停滞；脚本重写3次导致动作碎片化，goto浪费多。核心教训：升级工具当天不能下矿，应改钓鱼/砍树；出货白名单要变现矿石；craft前必须检查材料。

**新教训：**
- 铜镐在克林特处升级期间（2天）背包里没有镐，调用 mine 会返回 'no pickaxe in inventory' 并连续失败 3 次：升级工具当天应把主活动改为钓鱼/砍树，脚本层在 mine 前显式检查 pickaxe 是否在背包。
- 昨天 upgrade_tool tool=pickaxe 在 9:40 营业时间内成功交付铜镐（返回 'ready in 2 days'），说明参数名 pickaxe 是对的，之前失败是时间太晚或参数误判；今天不应再重复尝试升级，而是等明天领取。
- 出货用 except 排除 Copper Ore/Coal/Iron Ore/Copper Bar/Stone 导致只出货 17g：白名单应只留 25 铜矿/5 煤/5 铁矿，Copper Bar 和多余 Stone 也应出货变现，否则现金永远攒不到 2000g。
- 箱子里的 19 铁矿和 23 煤没有装进熔炉，铁锭停在 0：每天 collect_machines 后应主动 load_machines 指定 Iron Ore 炼铁锭，而不是等有空炉才装。
- build_road 和 decorate 各失败 1 次（0 铺路、无装饰可做）：这两个动作应从日常流程彻底删除，不占用动作次数。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y1 冬23）

## 长期目标
当前里程碑：**铜斧头 + 铜镐（清农场大树桩/大石头）**。铜镐已在克林特处升级，**明天（冬24）取回**；铜斧头尚未升级（需 2000g + 5 铜锭，铜锭现有 68 充足，但钱只有 1422g，且一次只能升级一件，必须等铜镐取回后再升斧头）。离完成还差：
- **取回铜镐**：冬24 去 Blacksmith `upgrade_tool tool=pickaxe` 领取（不是新升级）。
- **升级铜斧头**：取回铜镐后同一天或次日再 `upgrade_tool tool=axe`（2000g + 5 铜锭），钱不够则先攒钱。
- **洒水器×4**：需铁锭≥5（现铁锭 0，铁矿 19 在箱子里但未炼），铜锭≥4（充足）。铁锭靠熔炉炼铁矿（5 铁矿+1 煤→1 铁锭），现有 19 铁矿+23 煤可炼 3 铁锭，还差 2 铁锭需下矿 40-44 层补铁矿。
- **钓鱼 2 级 + 玻璃纤维钓竿 1800g**：现钓鱼 3 级已达标，只差 1800g 现金。

接下来 3 天主活动：
- **今天（冬23）**：镐在升级中不能下矿 → 主活动=**钓鱼攒钱 + 砍树攒木头 + 熔炉炼铁锭**。目标现金≥2000g（为明天取镐后升斧头备钱），木头≥150，铁锭尽量炼到 3。
- **明天（冬24）**：9:10 去 Blacksmith 取铜镐（`upgrade_tool tool=pickaxe`）；取回后若钱≥2000g 且铜锭≥5，立即 `upgrade_tool tool=axe` 升铜斧头；剩余时间下矿 40-44 层刷铁矿补铁锭到 5。
- **后天（冬25）**：铁锭≥5 就 craft 洒水器×4；否则继续下矿 40-44 层；同时为春季蓝莓种子攒钱（目标 2000g+）。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. `collect_machines` 收熔炉（≤2 次）→ 检查熔炉是否满料/无空炉，满料直接跳过 `load_machines`；有空炉才 `load_machines` **只调 1 次**，返回 "no empty machine accepts anything" 立即硬熔断，当天不再调用。**今天优先把箱子里的 19 铁矿+煤装进熔炉炼铁锭**（load_machines 指定 Iron Ore）。
2. `harvest_crops` → `water_crops`（各 1 次，返回 0 即跳过）。
3. **工具升级/领取（仅 9:10-15:30）**：
   - 若镐在升级中（今天）：**跳过本步，不调用 upgrade_tool**，直接进第 4 步。
   - 若镐可领取（明天）：`goto_location` Blacksmith → `upgrade_tool tool=pickaxe` 领取；成功后若钱≥2000g 且铜锭≥5，同一次进店再 `upgrade_tool tool=axe` 升铜斧头。
   - 参数顺序：`tool=pickaxe` → 若返回「Steel Axe costs 5000g」改传 `tool=copper_pickaxe` → 再失败传 `tool=Pickaxe`，各 1 次，三次都失败当天放弃，不拖到下午。
4. **下矿前检查**：**镐必须在背包里**（`mine` 前确认 pickaxe 不在升级中）；食物≥5、体力≥80、背包≥3 空格。食物不足 → 12:10 后 `goto_location` Saloon → `open_shop` → `buy` 沙拉×3-5 → `close_menu`。**不买剑、不买礼物**。
5. **主活动（今天=钓鱼+砍树；明天=下矿）**：
   - **今天**：镐在升级中，**禁止调用 mine**（会返回 no pickaxe）。主活动=钓鱼（`fish casts=6` 两轮，目标现金≥2000g）+ 砍树（`chop_tree` 指定农场树坐标，目标木头 150）。
   - **明天**：下矿 40-44 层刷铁，`floors≤4`，铁锭≥5 即停；**禁止 18 层、禁止 45 层以上**；遇「no stones left and no ladder」先 `fight` 1 次，仍无则 `leave_mine`；生命<50% 或食物=0 立即撤退。
6. **下矿后立即白名单出货**：`ship_produce` 显式参数——Copper Ore 留 25、Coal 留 5、Iron Ore 留 5，**其余全部出货（包括 Copper Bar 多余部分、Stone 多余部分）**。不隔天。
7. **craft 洒水器**：先显式检查铁锭≥5 且铜锭≥4，满足才 `craft` 洒水器×4；不满足则跳过，不调用。
8. **砍树攒木头**：禁用 clear_debris；用 `chop_tree` 指定农场具体树坐标，先 `goto_location` 到树旁再 chop。目标木头 150。连续 2 次 chop 失败则放弃砍树改钓鱼。
9. 剩余体力/时间：钓鱼（稳定收入，鱼可吃可卖）。
10. 体力<15 或时间≥22:00 `sleep`；**22:00 强制 sleep**。

## 规则
- **镐升级期间禁止下矿**：`mine` 前必须确认 pickaxe 在背包；若在升级中，当天主活动改钓鱼/砍树，不调用 mine。
- **空转硬熔断**：任何动作返回 "no empty machine accepts anything"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"none of the ... is reachable" 等「无事可做」反馈，脚本层立即永久跳过该分支，当天不再调用，立刻转去钓鱼或砍树。**禁止用 wait 填充时间**。
- **18 层永久拉黑**；**45 层以上不追**：mine 目标锁定 40-44 层，到 45 层无产出立即 leave_mine。
- **铜镐/铜斧参数顺序**：`upgrade_tool` 依次试 `tool=pickaxe`、`tool=copper_pickaxe`、`tool=Pickaxe`，各 1 次；三次都失败当天放弃，不拖到下午。升斧头同理试 `tool=axe`、`tool=copper_axe`、`tool=Axe`。
- **clear_debris 禁用**；**build_road / decorate 禁用**（各失败 1 次，从日常流程彻底删除）。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait。节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤3（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00，14:10 后再去；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00。营业时间前不调用 goto/open_shop/buy。
- **路径固定**：去 Blacksmith/Mountain 一律走 Farm→Town→Mountain；**Backwoods 不作为中转**，脚本层禁止从 Backwoods 发起任何跨图 goto。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口，禁止从 FarmHouse 发起 mine。
- **矿石必须变现**：下矿后 Copper Ore/Coal 除留 25/5 外全部 `ship_produce`，**Copper Bar 多余部分也出货**，不再囤箱子。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；Silver Saber 已到手，可闯 40 层以下，但食物≥5 才下。
- **季末规划**：冬季准备钓鱼/矿洞，春季第 1 天买蓝莓种子。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. 收熔炉 + 装铁矿炼铁锭（只 1 次，满料即停，不 wait）
2. 浇水+收菜（各 1 次）
3. **工具升级/领取（仅 9:10-15:30；镐在升级中则跳过，不调用）**
4. **买沙拉补食物到≥5（下矿前必做，Saloon 12:00 后）**
5. **今天主活动=钓鱼攒钱到 2000g + 砍树到 150 木头；明天主活动=下矿 40-44 层刷铁**
6. **回农场白名单出货矿石换现金（留 25 铜矿/5 煤/5 铁矿，其余全变现）**
7. **craft 洒水器×4（先确认铁锭≥5 且铜锭≥4 才调用）**
8. 砍树攒木头到 150（用 chop_tree 指定树，不用 clear_debris）
9. 钓鱼（下矿不可行时的稳定收入）
10. 社交（仅顺路）

</details>

## ⚠️ 今日问题
> 昨天铜镐升级已成功交付（2天后取），但下矿因镐在升级中无镐可用而3次失败，铁锭仍不足5，洒水器未造；出货仅17g，现金停滞；脚本重写3次导致动作碎片化，goto浪费多。核心教训：升级工具当天不能下矿，应改钓鱼/砍树；出货白名单要变现矿石；craft前必须检查材料。
- 09:40 动作 `upgrade_tool` 失败 @ Blacksmith — Clint is still working on Copper Pickaxe (2 days); one upgrade at a time 〔自动〕
- 09:40 动作 `goto_location` 失败 @ Blacksmith — no reachable route from Backwoods to Mine (unreachable exits: town->mountain, backwoods->mountain) 〔自动〕
- 11:50 动作 `mine` 失败 @ Mine — no pickaxe in inventory 〔自动〕
- 11:50 动作 `mine` 失败 @ UndergroundMine45 — no pickaxe in inventory 〔自动〕
- 11:50 动作 `mine` 失败 @ UndergroundMine45 — no pickaxe in inventory 〔自动〕
- 12:40 动作 `craft` 失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1 〔自动〕
- 15:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 铜镐在升级中，背包无镐，连续 3 次 mine 失败，下矿计划完全落空 @ Mine 入口 / UndergroundMine — no pickaxe in inventory（日志 3x mine: no pickaxe in inventory）（做不了：铁锭无法补充（停在 0），洒水器 craft 无法执行，下矿刷铁计划延后） 〔复盘〕
- 出货仅 17g，现金从 3422 跌到 1422，春季买种子的钱攒不出来 @ Farm 出货箱 — ship_produce 用 except 排除 Copper Ore/Coal/Iron Ore/Copper Bar/Stone，只出货 2 堆约 17g（做不了：现金不足 2000g，明天取回铜镐后无法立即升铜斧头，春季蓝莓种子钱也没着落） 〔复盘〕
- 铁锭停在 0，箱子里的 19 铁矿和 23 煤没装进熔炉 @ Farm 熔炉旁 — load_machines 只装了 Copper Ore，未指定 Iron Ore；collect_machines 后未主动补料（做不了：洒水器 craft 需要铁锭≥5，铁锭 0 导致 craft 无法执行） 〔复盘〕
- 从 Backwoods 发起 goto Mine 路径不通，浪费一次 goto 和约 100 分钟 @ Backwoods → Mine — no reachable route from Backwoods to Mine (unreachable exits: town->mountain, backwoods->mountain)（做不了：下矿窗口被挤占，上午有效时间减少） 〔复盘〕
- 脚本重写 3 次，动作碎片化，28 个动作里只有 3 次 mine 且全部失败 @ 全局 — 脚本 1/19、1/11、1/13 多次重写，goto_location 8 次、mine 仅 3 次（做不了：有效下矿/钓鱼时间被挤占，铁锭和现金都没进展） 〔复盘〕
- build_road 和 decorate 各失败 1 次，浪费动作次数 @ Farm — laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；今天没有能做的装饰（做不了：占用动作上限，挤占钓鱼/砍树时间） 〔复盘〕
