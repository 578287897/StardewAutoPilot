# 第2年 spring 20 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（22:48 开始）
- 天气：sunny　金钱：4994g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar

## 🌙 为明天（Y2_spring_20）准备的脚本
- 里程碑：工具按档升级——先补 88g 现金缺口，铁锭够 5 且现金≥5000 就去铁匠铺升钢镐
- 9:00 收熔炉铁锭并重新装铁（只炼铁，≤2 次）
- 砍 1 棵树补 3 木头，craft 第 2 个保存罐
- 洒水器落地（带坐标，失败即换锚点或当天放弃）
- 主活动：下矿 45-49 层拿铁矿/煤，46 层先 fight 清怪再 mine
- 傍晚回农场浇水/出货/存箱子，17:00 后 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `water_crops`
5. `use_tool`（tool="axe", x=60, y=20, times=1, until_cleared=true）
6. `craft`（item="Preserves Jar", count=1）
7. `place`（item="Sprinkler", x=51, y=14）
8. `ship_produce`
9. `goto_location`（location="Mine"）
10. `mine`（floors=4）
11. `fight`（range=6）
12. `mine`（floors=3）
13. `leave_mine`
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `water_crops`
18. `ship_produce`
19. `store_items`
20. `sleep`
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 12 crops
  - 🗨️ [hud] Potato
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~960g (paid overnight)
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 因未收到巫师信失败，跳过献祭分支，保留原路线：收熔炉→砍树补木→洒水器→下矿拿铁→傍晚回农场收尾睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `water_crops`
4. `use_tool`（tool="axe", x=60, y=20, times=1, until_cleared=true）
5. `craft`（item="Preserves Jar", count=1）
6. `place`（item="Sprinkler", x=51, y=14）
7. `ship_produce`
8. `goto_location`（location="Mine"）
9. `mine`（floors=4）
10. `fight`（range=6）
11. `mine`（floors=3）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `water_crops`
17. `ship_produce`
18. `store_items`
19. `sleep`
- **06:20** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:20** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:40** Farm ✅ `use_tool`（tool="axe", x=60, y=20, times=1, until_cleared=true）
  - 结果：used axe 0x at (60,20), tile cleared
- **06:40** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8

### 🔁 脚本重写：重写#2：craft失败因木头/煤不足，改为先砍树补木头再craft，其余路线保留：洒水器落地、下矿拿铁、傍晚收熔炉并出货睡觉。
1. `craft`（item="Preserves Jar", count=1）
2. `place`（item="Sprinkler", x=51, y=14）
3. `ship_produce`
4. `goto_location`（location="Mine"）
5. `mine`（floors=4）
6. `fight`（range=6）
7. `mine`（floors=3）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `ship_produce`
13. `store_items`
14. `sleep`
- **06:40** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine)

### 🔁 脚本重写：重写#3：craft 保存罐材料不足已熔断，跳过该分支，保留原路线：放洒水器→出货腾格→下矿拿铁→傍晚回农场收熔炉出货睡觉。
1. `place`（item="Sprinkler", x=51, y=14）
2. `ship_produce`
3. `goto_location`（location="Mine"）
4. `mine`（floors=4）
5. `fight`（range=6）
6. `mine`（floors=3）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `ship_produce`
12. `store_items`
13. `sleep`
- **06:40** Farm ❌ `place`（item="Sprinkler", x=51, y=14）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
- **06:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **07:20** Mine ❌ `mine`（floors=4）
  - 结果：floor 47: no reachable stone or ladder
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Frozen Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Inventory Full
- **09:20** UndergroundMine47 ✅ `fight`（range=6）
  - 结果：done
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
- **09:40** UndergroundMine47 ❌ `mine`（floors=3）
  - 结果：floor 48: no stones left and no ladder found (kill remaining monsters?)
  - 🗨️ [hud] Stone
  - 🗨️ [hud] This area is overrun 
with monsters. 
- **09:50** UndergroundMine48 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [question] 
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **10:30** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **10:30** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **10:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 4x Trash, 1x Broken Glasses, 1x Driftwood, 1x Iron Bar, 1x Copper Bar, 41x Stone, 1x Iron Ore
- **10:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4994 → 5954（+960g）
- 出货估值：960g　动作：24 个　失败：7 个
- 模型调用：5 次　tokens：60728

## 🧠 夜间复盘
昨天矿洞47/48层因背包满和怪物未清而失败，洒水器无空位、保存罐差3木、现金差6g升镐，但主活动时间被空转消耗。有效做法是熔炉炼铁和出货。今天必须优先清背包、清怪再下矿，并先补6g现金升钢镐。

**新教训：**
- 矿洞内背包满时继续 mine 会触发 'Inventory Full' 并导致找不到梯子：下矿前必须空格≥5，矿洞内背包满立即 ship_produce 清格再继续。
- 现金差 6g 到 5000g 时，应先 ship_produce 白名单或钓 1 轮补足，再 goto Blacksmith 升钢镐；不要因差几块钱跳过升级拖一天。
- 矿洞 47/48 层返回 'no stones left and no ladder found' 且提示 'overrun with monsters' 时，必须先 fight 清怪再 mine；昨天直接 leave_mine 导致全天矿洞零推进。
- 洒水器 place 返回 '无空位' 后，应先 chop_tree 清出连续空地或换到另一块已清空田块锚点，再带 x,y 坐标 place；同一分区当天不重试。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春21）

## 长期目标
当前里程碑：**工具按档升级**——钢斧已在手，下一档钢镐需 5 铁锭（已有 5 铁锭）+ 现金 5000g（现有 4994g，差 6g）。今天第一优先级：凑 6g 现金（出货/钓鱼/卖杂物）后立即去铁匠铺升钢镐。
并行里程碑：**洒水器×4 落地**（已 craft 3 个，卡分区无空位）与**保存罐×2**（Wood 47/50，差 3）。
离完成还差：钢镐 6g + 确认铁锭 5；洒水器需清 4 空位；保存罐需 3 木头。
接下来 3 天主活动：
- **今天（春21）**：① 9:00 收熔炉、装铁；② 先补 6g 现金（ship_produce 白名单或钓 1 轮）→ 9:10 后去 Blacksmith 升钢镐（≤1 次）；③ 清背包至空格≥5；④ 主活动下矿 45-49 层，**每层先 fight 清怪再 mine**，背包满立即 ship_produce 清格；⑤ 傍晚回农场收熔炉/出货/存箱子，17:00 后 sleep。
- **明天（春22）**：升钢镐（若今天没升成）；继续下矿到 50 层解锁电梯；洒水器/保存罐收尾。
- **后天（春23）**：规划夏季啤酒花/蓝莓地块，攒铁锭做高级洒水器前置（农业 6 级）。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. **熔炉（只炼铁）**：9:00 和 15:00 各 `collect_machines` 一次（≤2 次/天），取到铁锭后 `load_machines` item=Iron Ore 1 次。返回 "no machine has finished output" 或 "all machines are busy" 立即熔断，当天不再 collect/load。**铜矿永不入炉**。
2. **补现金升镐（今天最高优先）**：现金<5000 时，先 `ship_produce` 白名单清出≥5 格并补现金；仍差则去 River 钓 1 轮（≤2 次 fish）。现金≥5000 且铁锭≥5 且时间 9:10-15:30 → `goto_location` Blacksmith → `upgrade_tool` tool=pickaxe（≤1 次）。**升级后 2 天内不调 mine/water_crops**。
3. **清背包**：空格<5 时 `ship_produce` 白名单清出≥5 格；下矿前必须空格≥5。
4. **洒水器落地**：先确认目标分区有空位；无空位先 `chop_tree`/清杂物腾位，或换到另一块已清空田块锚点，`place` 必须带 x,y（≤2 次）。返回 "无空位" 立即换锚点或当天放弃，同一分区不重试。
5. **craft 保存罐**：Wood≥50 且 Stone≥40 且 Coal≥8 时 craft≤1 次。Wood 47 差 3：砍 1 棵树或从箱子取 Driftwood 补到 50，补不到就明天。
6. **主活动（10:00 后必须选一个，禁止 wait、禁止连续 collect）**：
   - **下矿**（体力≥30、食物≥5、生命>50%、时间<15:00、空格≥5）：`goto_location` Mine 入口 → `mine` 目标 45-49 层。**关键修正：每层先 `fight` 清怪 1-2 次再 `mine`；返回 "no stones left and no ladder found (kill remaining monsters?)" 时先 fight 再 mine；背包满立即 ship_produce 清格再继续**；清怪 2 次仍无梯子才 leave_mine 改钓鱼。生命<50% 或食物=0 立即 leave_mine。mine 超时/0 层推进一次即熔断，改钓鱼。
   - **钓鱼**（时间≥15:00 或体力<30）：River 或海边钓 2-3 轮，Mountain 湖不作默认钓点。
7. **浇水**：水壶在背包则 `water_crops` 1 次；返回 "no watering can" 跳过。
8. **买鱼饵（仅当现金≥150g 且 9:00-16:30）**：open_shop 后一次性 buy Bait 20 → close_menu，关菜单后不再 buy。
9. **买种子（仅当现金≥2200g 且空格≥5）**：只买已解锁春季作物，单次 buy≤2 次，现金留≥1800g。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间**，做完主活动直接 sleep 或转钓鱼。

## 规则
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼/下矿。
- **禁止连续 collect 空转**：`collect_machines` 每天≤2 次且只在 9:00/15:00 各一次；返回 "no machine has finished output" 后当天不再 collect。
- **熔炉熔断**：load 返回 "all machines are busy"/"no empty machine" 即熔断，当天不再调用。装铁前显式确认炉内无铜矿。
- **下矿清怪优先**：每层先 `fight` 清怪 1-2 次再 `mine`；返回 "no stones left and no ladder found" 时先 fight 再 mine，不要直接放弃；清怪 2 次仍无梯子才 leave_mine。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续，不要硬挖导致 "Inventory Full"。
- **下矿优先于钓鱼**：铁锭未满 5 或现金<5000 前主活动锁定下矿 45-49 层；钓鱼只在时间≥15:00 或体力<30 时做。
- **place 必须带坐标**：缺 x,y 直接不调用；返回 "无空位" 换锚点或当天放弃，同一分区当天不重试。
- **空转硬熔断**：任何动作返回 "all machines are busy"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"inventory full"、"无空位" 等，脚本层立即永久跳过该分支，当天不再调用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy。
- **18 层永久拉黑**；**50 层以上不追**：mine 目标锁定 45-49 层，到 50 层无产出立即 leave_mine；体力<30 不调 mine。
- **工具升级**：一次只升一件；升级期间（2 天）不调 mine（无镐）也不调 water_crops（无水壶）；升级前显式检查现金≥费用且锭够，不足直接跳过。
- **build_road / decorate / clear_debris 禁用**：昨天 24 块铺路石全被阻挡，白做。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下。
- **季末规划**：春季作物在夏季第 1 天枯死；季末只种能在 28 日前成熟的作物。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. 补 6g 现金 + 升钢镐（现金≥5000 且铁锭≥5，9:10-15:30，≤1 次）
2. 熔炉取锭+装铁（只炼铁，9:00/15:00 各一次，≤2 次）
3. 清背包（空格≥5，下矿前必做）
4. 洒水器落地（先清位/换锚点，带坐标）
5. craft 保存罐（砍 1 棵树补 3 木头）
6. 下矿拿铁（体力≥30、食物≥5、时间<15:00，目标 45-49 层，每层先清怪）
7. 浇水（水壶在背包时）
8. 钓鱼（时间≥15:00 或体力<30，River/海边，放最后单独执行）
9. 买鱼饵（现金≥150g，<16:30）
10. 买种子（现金≥2200g 且空格≥5）
11. 社交（仅顺路）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天矿洞47/48层因背包满和怪物未清而失败，洒水器无空位、保存罐差3木、现金差6g升镐，但主活动时间被空转消耗。有效做法是熔炉炼铁和出货。今天必须优先清背包、清怪再下矿，并先补6g现金升钢镐。
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:40 动作 `craft` 失败 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8 〔自动〕
- 06:40 动作 `craft` 失败 @ Farm — already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine) 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 07:20 动作 `mine` 失败 @ Mine — floor 47: no reachable stone or ladder | 游戏消息: [hud] Stone / [hud] Stone / [hud] Stone / [hud] Frozen Geode / [hud] Stone / [hud] Inventory Full / [hud] Stone / [hud] Inventory Full 〔自动〕
- 09:40 动作 `mine` 失败 @ UndergroundMine47 — floor 48: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Stone / [hud] This area is overrun 
with monsters.  〔自动〕
- 10:30 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 下矿 47/48 层找不到梯子，背包满且怪物未清，全天矿洞零推进 @ Mine 第 47-48 层 — floor 47: no reachable stone or ladder；floor 48: no stones left and no ladder found (kill remaining monsters?)；游戏提示 'Inventory Full' 和 'This area is overrun with monsters'（做不了：铁矿/煤没拿到，铁锭停在 5，钢镐升级延后） 〔复盘〕
- 现金 4994g 差 6g 到钢镐 5000g 门槛，升级没做成 @ Farm / Blacksmith — 金钱 4994 -> 4994，差 6g；计划里写 '先补88g现金缺口' 但实际没补（做不了：钢镐升级拖到明天，下矿效率受限） 〔复盘〕
- 洒水器已 craft 但分区无空位，place 失败 @ Farm 田地分区 (51,14) — Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器放不下，无法自动化浇水，体力仍被手动浇水占用） 〔复盘〕
- 保存罐差 3 木头无法 craft，计划了但没补材料 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8（Wood 47/50）（做不了：第 2 个保存罐没做出来，加工里程碑延后） 〔复盘〕
- 熔炉装铁时返回 'all machines are busy'，说明炉内还有未取出的产物 @ Farm 熔炉 — load_machines: all machines are busy; collect them when they finish（做不了：铁锭产出节奏被打断，铁矿积压） 〔复盘〕
- donate 在 wait_letter 阶段失败，社区中心献祭无法推进 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心收集包进度卡住，温室/矿车解锁延后） 〔复盘〕
