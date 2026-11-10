# 第2年 spring 25 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（23:47 开始）
- 天气：sunny　金钱：2606g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 🗨️ [hud] Iron Bar
- **06:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship

## 🌙 为明天（Y2_spring_25）准备的脚本
- 里程碑：工具按档升级——先砍树补 Wood≥50 并 craft 保存罐，再清位放洒水器
- 熔炉 9:00 收一次，炉空才装铁矿
- 下矿 45-49 层拿铁/煤（体力≥30、食物≥5、空格≥5 才下）
- 现金够 150g 且 16:30 前去 FishShop 买 20 鱼饵
- 体力耗尽或时间晚则钓鱼兜底，22:00 前 sleep
1. `donate`
2. `harvest_crops`
3. `water_crops`
4. `clear_debris`（radius=8, max=20, kinds=["twig", "weed"]）
5. `craft`（item="Preserves Jar", count=1）
6. `place`（item="Sprinkler", x=40, y=60）
7. `place`（item="Sprinkler", x=44, y=60）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `goto_location`（location="Mine"）
11. `mine`（floors=4）
12. `fight`（range=6）
13. `mine`（floors=3）
14. `mine`（floors=3）
15. `leave_mine`
16. `goto_location`（location="FishShop"）
17. `open_shop`（shop_id="FishShop"）
18. `buy`（item="Bait", count=20）
19. `close_menu`
20. `goto_location`（location="Forest"）
21. `fish`（casts=4）
22. `sleep`
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 未解锁跳过，按原路线补木→放洒水器→熔炉→下矿→买饵→钓鱼→睡觉
1. `clear_debris`（radius=10, max=20, kinds=["twig", "weed"]）
2. `craft`（item="Preserves Jar", count=1）
3. `place`（item="Sprinkler", x=40, y=60）
4. `place`（item="Sprinkler", x=44, y=60）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `goto_location`（location="Mine"）
8. `mine`（floors=4）
9. `fight`（range=6）
10. `mine`（floors=3）
11. `mine`（floors=3）
12. `leave_mine`
13. `goto_location`（location="FishShop"）
14. `open_shop`（shop_id="FishShop"）
15. `buy`（item="Bait", count=20）
16. `close_menu`
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `sleep`
- **06:10** Farm ✅ `clear_debris`（radius=10, max=20, kinds=["twig", "weed"]）
  - 结果：cleared 1 debris within 10 tiles of (35,8)
- **06:10** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8

### 🔁 脚本重写：重写#2：craft 因缺木失败，先砍树补 Wood 再 craft，其余路线保留。
1. `clear_debris`（radius=10, max=20, kinds=["twig", "weed"]）
2. `use_tool`（tool="axe", x=40, y=60, times=1, until_cleared=true）
3. `use_tool`（tool="axe", x=44, y=60, times=1, until_cleared=true）
4. `use_tool`（tool="axe", x=40, y=56, times=1, until_cleared=true）
5. `craft`（item="Preserves Jar", count=1）
6. `place`（item="Sprinkler", x=40, y=60）
7. `place`（item="Sprinkler", x=44, y=60）
8. `load_machines`（item="Iron Ore"）
9. `goto_location`（location="Mine"）
10. `mine`（floors=4）
11. `fight`（range=6）
12. `mine`（floors=3）
13. `mine`（floors=3）
14. `leave_mine`
15. `goto_location`（location="FishShop"）
16. `open_shop`（shop_id="FishShop"）
17. `buy`（item="Bait", count=20）
18. `close_menu`
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `goto_location`（location="Farm"）
22. `sleep`
- **06:10** Farm ✅ `clear_debris`（radius=10, max=20, kinds=["twig", "weed"]）
  - 结果：cleared 1 debris within 10 tiles of (6,8)
- **06:20** Farm ✅ `use_tool`（tool="axe", x=40, y=60, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,60), tile cleared
- **06:20** Farm ✅ `use_tool`（tool="axe", x=44, y=60, times=1, until_cleared=true）
  - 结果：used axe 0x at (44,60), tile cleared
- **06:20** Farm ✅ `use_tool`（tool="axe", x=40, y=56, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,56), tile cleared
- **06:20** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine)

### 🔁 脚本重写：重写#3：craft 因材料不足失败，改为先砍两棵树补木头再重试保存罐，其余路线保留。
1. `use_tool`（tool="axe", x=40, y=52, times=1, until_cleared=true）
2. `use_tool`（tool="axe", x=44, y=52, times=1, until_cleared=true）
3. `craft`（item="Preserves Jar", count=1）
4. `place`（item="Sprinkler", x=40, y=60）
5. `place`（item="Sprinkler", x=44, y=60）
6. `load_machines`（item="Iron Ore"）
7. `goto_location`（location="Mine"）
8. `mine`（floors=4）
9. `fight`（range=6）
10. `mine`（floors=3）
11. `mine`（floors=3）
12. `leave_mine`
13. `goto_location`（location="FishShop"）
14. `open_shop`（shop_id="FishShop"）
15. `buy`（item="Bait", count=20）
16. `close_menu`
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `sleep`
- **06:20** Farm ✅ `use_tool`（tool="axe", x=40, y=52, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,52), tile cleared
- **06:20** Farm ✅ `use_tool`（tool="axe", x=44, y=52, times=1, until_cleared=true）
  - 结果：used axe 0x at (44,52), tile cleared
- **06:20** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine)
- **06:20** Farm ❌ `place`（item="Sprinkler", x=40, y=60）
  - 结果：'Sprinkler' not found in inventory
- **06:20** Farm ❌ `place`（item="Sprinkler", x=44, y=60）
  - 结果：'Sprinkler' not found in inventory
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:20** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **07:20** Mine ✅ `mine`（floors=4）
  - 结果：mined from floor 15 to 18 (3 floors down, 180 stones broken); low stamina
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] You're starting to 
feel exhausted. 
- **11:20** UndergroundMine18 ✅ `fight`（range=6）
  - 结果：done
- **11:20** UndergroundMine18 ✅ `mine`（floors=3）
  - 结果：mined from floor 18 to 18 (0 floors down, 0 stones broken); low stamina
- **11:20** UndergroundMine18 ✅ `mine`（floors=3）
  - 结果：mined from floor 18 to 18 (0 floors down, 0 stones broken); low stamina
- **11:20** UndergroundMine18 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **11:30** Mine ✅ `goto_location`（location="FishShop"）
  - 结果：arrived at FishShop (5,9)
- **12:50** FishShop ✅ `open_shop`（shop_id="FishShop"）
  - 结果：shop opened
- **12:50** FishShop ✅ `buy`（item="Bait", count=20）
  - 💭 在鱼店菜单里，体力仅14，先买20鱼饵，再关菜单。
  - 结果：bought 20x Bait for 100g
- **12:50** FishShop ✅ `close_menu`
  - 💭 体力仅14，买完饵关菜单，回农场砍树补木到50做保存罐，再装熔炉炼铁。
  - 结果：menu closed
- **12:50** FishShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
- **13:40** Farm ❌ `chop_tree`
  - 结果：unknown action 'chop_tree'. Available: move_to, goto_location, use_tool, interact, place, select, eat, ship, ship_produce, open_shop, buy, dialog_answer, dialog_advance, menu_click, choose_profession, close_menu, wait, sleep, check_mail, craft, store, take, fish, mine, leave_mine, fight, donate, build, buy_animal, care_animals, clear_area, load_machines, collect_machines, cook, buy_backpack, buy_weapon, lay_path, upgrade_tool, upgrade_house, festival, water_crops, harvest_crops, clear_debris, plant_seeds, forage
- **13:40** Farm ❌ `buy`（item="Bait", count=20）
  - 结果：no shop is open; use open_shop first
- **13:40** Farm ❌ `close_menu`
  - 结果：no menu is open
- **13:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
- **14:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 1 (Smallmouth Bass)
- **14:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
- **15:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：2606 → 2506（-100g）
- 出货估值：0g　动作：37 个　失败：11 个
- 模型调用：7 次　tokens：81669

## 🧠 夜间复盘
昨天最大浪费是脚本反复调用不存在的 chop_tree、在无树格挥斧、craft 前置材料不足仍重试、place 洒水器但背包没有、load_machines 空转；有效动作是收熔炉铁锭、下矿 15→18 层、买饵钓鱼。今天应把「补木→craft 保存罐」「清位→放洒水器」拆成带坐标的硬前置，失败一次即跳分支，主活动固定为下矿/钓鱼。

**新教训：**
- `chop_tree` 不是有效动作，砍树必须用 `use_tool` tool=axe 带 x,y；昨天因此浪费 1 个动作并导致补木失败。
- `place` Sprinkler 前必须先确认背包/箱子有该物品；昨天背包没有洒水器仍 place 2 次全失败，应先查背包再决定是否 place。
- `craft` 返回 "not enough ingredients" 后当天不再 craft 同一物品，应先补材料；昨天连续 3 次 craft 保存罐全失败。
- `load_machines` 返回 "no empty machine accepts anything" 说明炉内仍有未取产物或背包无对应矿石，应先 collect 确认炉空再 load，失败一次即熔断。
- `use_tool` axe 返回 "used axe 0x, tile cleared" 说明该格无树，砍树前先确认目标格有树干，不要对空地反复挥斧。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春26）

## 长期目标
当前里程碑：**第二座熔炉 + 工具按档升级**。铜矿 30、石头 2268 已够第二座熔炉（20 铜矿+25 石头），今天第一件事就是 craft 第二座熔炉并放下，两座同时炼铜/铁。下一档工具是**钢水壶**：需 5000g+5 铁锭，现有 2506g、铁锭 3，差 2494g+2 铁锭——今天不下铁匠铺，先炼铁、赚钱。
并行里程碑：**保存罐×1**（Wood 49/50，差 1 木头，砍 1 棵树即可）；**洒水器落地**（背包里没有洒水器，先确认是否已 craft，没有就等农业 2 级配方材料齐再做，不再空 place）。
接下来 3 天主活动：
- **今天（春26）**：① craft 第二座熔炉并放下；② 砍 1 棵树补 Wood≥50 → craft 保存罐；③ 熔炉 collect 确认空后 load 铁矿/铜矿；④ 体力≥30 下矿 20-30 层拿铁/煤（当前只安全到 19 层，先补食物）；⑤ 22:00 前 sleep。
- **明天（春27）**：铁锭够 5 且现金够 5000g 就升钢水壶；不够继续下矿/钓鱼补钱。
- **后天（春28）**：季末检查，只种 28 日前能熟的作物；社区中心收集包留 2 个金星作物。

## 每日固定流程（按顺序，失败一次即跳下一步，不重试）
1. **第二座熔炉（今天第一硬前置）**：`craft` Furnace 1 次（铜矿 30≥20、石头 2268≥25 已够）。成功后 `place` Furnace 带 x,y 放在第一座熔炉旁空地；place 失败换锚点 1 次，再失败当天放弃。
2. **补木→保存罐**：Wood 49 差 1。用 `use_tool` axe 对**确认有树的格子**砍 1 次（先看目标格有树干，不要对空地挥斧）；Wood≥50 后 `craft` Preserves Jar 1 次。**craft 前先确认 Wood≥50，失败当天不再 craft。**
3. **熔炉炼矿**：9:00 和 15:00 各 `collect_machines` 一次（≤2 次/天）。collect 有产物后先确认炉空，再 `load_machines` 1 次：第一座装 Iron Ore，第二座装 Copper Ore。返回 "no empty machine"/"all machines are busy" 立即再 collect 一次，仍失败当天熔断。
4. **下矿（主活动，体力≥30、食物≥3、空格≥5 才下）**：`goto_location` Mine → `mine` 目标 20-30 层（当前安全上限 19 层，先补食物再往下）。≤6 次 mine。每层先 `fight` 清怪 1-2 次再 mine；返回 "no stones left and no ladder found" 先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。
5. **买鱼饵**：现金≥150g 且 9:00-16:30 → `goto_location` FishShop → `open_shop` → 一次性 `buy` Bait 20 → `close_menu`。**buy 必须在 open_shop 之后、close_menu 之前完成，关菜单后不再 buy。**
6. **钓鱼（仅现金兜底）**：下矿体力耗尽或时间>16:00 才转 River/海边钓 1-2 轮（≤3 次 fish）。鱼饵耗尽或连续 2 轮垃圾立即停钓。
7. **浇水**：水壶在背包则 `water_crops` 1 次；返回 "no watering can" 跳过。
8. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树一律用 `use_tool` tool=axe 带 x,y，且先确认目标格有树。
- **禁止对空地挥斧**：use_tool axe 返回 "used axe 0x, tile cleared" 说明该格无树，立即换格或改砍树分支，同一格不重试。
- **place 前先确认背包有该物品**：`place` Sprinkler/Furnace 前先看背包/箱子是否有；没有就跳过，不调用。
- **craft 前先确认材料**：craft 返回 "not enough ingredients" 后当天不再 craft 同一物品，先去补材料。
- **熔炉熔断**：load 返回 "no empty machine"/"all machines are busy" 即先再 collect 一次，仍失败当天不再调用。装铁前显式确认炉内无铜矿。
- **禁止连续 collect 空转**：`collect_machines` 每天≤2 次且只在 9:00/15:00 各一次；返回 "no machine has finished output" 后当天不再 collect。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示"正在升级"及现金/锭是否够；不够直接跳过，不去铁匠铺。**金镐 10000g 不够，今天不尝试。**
- **下矿清怪优先**：每层先 `fight` 清怪 1-2 次再 `mine`；返回 "no stones left and no ladder found" 时先 fight 再 mine；清怪 2 次仍无梯子才 leave_mine。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **空转硬熔断**：任何动作返回 "all machines are busy"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"inventory full"、"无空位" 等，脚本层立即永久跳过该分支，当天不再调用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy。
- **18 层永久拉黑**；**50 层以上不追**：mine 目标锁定 20-30 层（先补食物再下 40 层），到 50 层无产出立即 leave_mine；体力<30 不调 mine。
- **build_road / decorate / clear_debris 禁用**：昨天 24 块铺路石全被阻挡，白做。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤2、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤6、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **季末规划**：春季作物在夏季第 1 天枯死；季末只种能在 28 日前成熟的作物。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. craft 第二座熔炉并放下（今天第一硬前置）
2. 砍 1 棵树补 Wood≥50 → craft 保存罐
3. 熔炉先 collect 确认炉空再 load 铁/铜（9:00/15:00 各一次，≤2 次）
4. 下矿 20-30 层拿铁/煤（体力≥30、食物≥3、空格≥5 才下，≤6 次 mine）
5. 买鱼饵（现金≥150g，<16:30，open_shop 后一次性买）
6. 钓鱼（仅现金兜底，River/海边 1-2 轮，连续垃圾立即停）
7. 浇水（水壶在背包时）
8. 社交（仅顺路）
9. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是脚本反复调用不存在的 chop_tree、在无树格挥斧、craft 前置材料不足仍重试、place 洒水器但背包没有、load_machines 空转；有效动作是收熔炉铁锭、下矿 15→18 层、买饵钓鱼。今天应把「补木→craft 保存罐」「清位→放洒水器」拆成带坐标的硬前置，失败一次即跳分支，主活动固定为下矿/钓鱼。
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:10 动作 `craft` 失败 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8 〔自动〕
- 06:20 动作 `craft` 失败 @ Farm — already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine) 〔自动〕
- 06:20 动作 `craft` 失败 @ Farm — already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine) 〔自动〕
- 06:20 动作 `place` 失败 @ Farm — 'Sprinkler' not found in inventory 〔自动〕
- 06:20 动作 `place` 失败 @ Farm — 'Sprinkler' not found in inventory 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:40 动作 `chop_tree` 失败 @ Farm — unknown action 'chop_tree'. Available: move_to, goto_location, use_tool, interact, place, select, eat, ship, ship_produce, open_shop, buy, dialog_answer, dialog_advance, menu_click, choose_profession, close_menu, wait, sleep, check_mail, cr 〔自动〕
- 13:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 13:40 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 脚本反复调用不存在的 chop_tree 动作，补木计划落空 @ Farm — unknown action 'chop_tree'. Available: move_to, goto_location, use_tool, ...（做不了：Wood 停在 49，保存罐无法 craft） 〔复盘〕
- 对无树格子连续挥斧，砍树无效 @ Farm (40,60)/(44,60)/(40,56)/(40,52)/(44,52) — used axe 0x at (40,60), tile cleared（做不了：Wood 未增加，保存罐继续卡） 〔复盘〕
- 背包没有洒水器仍 place 2 次 @ Farm — 'Sprinkler' not found in inventory（做不了：洒水器落地里程碑无进展） 〔复盘〕
- 保存罐材料不足仍连续 craft 3 次 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8 / already failed crafting Preserves Jar today（做不了：保存罐未做出） 〔复盘〕
- 熔炉 load 铁矿失败，炉内仍有产物或背包无对应矿石 @ Farm — no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿未入炉，铁锭无法增加） 〔复盘〕
- 下矿 18 层后连续 2 次 mine 0 层推进，体力耗尽 @ Mine 18 层 — mined from floor 18 to 18 (0 floors down, 0 stones broken); low stamina（做不了：当天矿洞进度停在 18 层，未拿到铁/煤） 〔复盘〕
- close_menu 后再 buy 鱼饵失败 @ FishShop — no shop is open; use open_shop first（做不了：第二次买饵未成功（第一次已买 20）） 〔复盘〕
- donate 在 wait_letter 阶段必失败 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心献祭无法推进） 〔复盘〕
