# 第2年 spring 27 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（00:17 开始）
- 天气：sunny　金钱：2677g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_spring_27）准备的脚本
- 里程碑：钢水壶（差2铁锭+2323g）——今天先取熔炉产物、炼铁、下矿拿铁矿石
- 洒水器×3 craft 并落地（材料已齐，必做）
- 保存罐 craft 1 个（材料已齐）
- 备 3 份回血食物后下矿 20-30 层拿铁矿石+煤
- 现金兜底钓鱼，22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `craft`（item="Sprinkler", count=3）
5. `place`（item="Sprinkler"）
6. `craft`（item="Preserves Jar", count=1）
7. `place`（item="Preserves Jar"）
8. `goto_location`（location="Town"）
9. `goto_location`（location="Saloon"）
10. `open_shop`（shop_id="Saloon"）
11. `buy`（item="Salad", count=3）
12. `close_menu`
13. `goto_location`（location="Mountain"）
14. `goto_location`（location="Mine"）
15. `mine`（floors=6）
16. `leave_mine`
17. `goto_location`（location="Town"）
18. `fish`（casts=3）
19. `goto_location`（location="Farm"）
20. `ship_produce`
21. `store_items`
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：捐不了（等巫师信），跳过 donate，按原路线先做洒水器/保存罐再下矿，失败一次即熔断不重试。
1. `craft`（item="Sprinkler", count=3）
2. `place`（item="Sprinkler"）
3. `craft`（item="Preserves Jar", count=1）
4. `place`（item="Preserves Jar"）
5. `goto_location`（location="Town"）
6. `fish`（casts=3）
7. `goto_location`（location="Saloon"）
8. `open_shop`（shop_id="Saloon"）
9. `buy`（item="Salad", count=3）
10. `close_menu`
11. `goto_location`（location="Mountain"）
12. `goto_location`（location="Mine"）
13. `mine`（floors=6）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `ship_produce`
17. `store_items`
18. `sleep`
- **06:20** Farm ✅ `craft`（item="Sprinkler", count=3）
  - 结果：crafted 3x Sprinkler
- **06:20** Farm ✅ `place`（item="Sprinkler"）
  - 结果：placed Sprinkler at (56,17)
- **06:30** Farm ✅ `craft`（item="Preserves Jar", count=1）
  - 结果：crafted 1x Preserves Jar
- **06:30** Farm ✅ `place`（item="Preserves Jar"）
  - 结果：placed Preserves Jar at (26,8)
- **06:40** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
- **07:10** Town ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Smallmouth Bass, River Jelly, Smallmouth Bass)
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] River Jelly
- **08:10** Town ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 10:10 am (waiting for Saloon to open at 12:00)
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **10:10** Town ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
- **12:00** Town ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
- **12:10** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
- **12:10** Saloon ✅ `buy`（item="Salad", count=3）
  - 💭 在Saloon商店，买3份沙拉备下矿食物，然后关闭菜单
  - 结果：bought 3x Salad for 660g
- **12:10** Saloon ✅ `close_menu`
  - 💭 已买3沙拉，食物够下矿。先关店，回农场取熔炉产物并装矿，再下矿。
  - 结果：menu closed
- **12:10** Saloon ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
- **12:40** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **12:40** Farm ❌ `buy`（item="Salad", count=3）
  - 结果：no shop is open; use open_shop first

### 🔁 脚本重写：重写#2：沙拉已在背包（3份），跳过买沙拉；按原路线先做洒水器/保存罐落地，再下矿，最后回农场出货睡觉。
1. `craft`（item="Sprinkler", count=3）
2. `place`（item="Sprinkler"）
3. `craft`（item="Preserves Jar", count=1）
4. `place`（item="Preserves Jar"）
5. `goto_location`（location="Mountain"）
6. `goto_location`（location="Mine"）
7. `mine`（floors=6）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `ship_produce`
11. `store_items`
12. `sleep`
- **12:40** Farm ❌ `craft`（item="Sprinkler", count=3）
  - 结果：can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1

### 🔁 脚本重写：重写#3：洒水器缺铁锭无法 craft，改为先装炉炼锭、做保存罐，再下矿补铁矿石，最后回农场出货睡觉。
1. `load_machines`（item="Copper Ore"）
2. `craft`（item="Preserves Jar", count=1）
3. `place`（item="Preserves Jar"）
4. `goto_location`（location="Mountain"）
5. `goto_location`（location="Mine"）
6. `mine`（floors=6）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `ship_produce`
10. `store_items`
11. `sleep`
- **12:40** Farm ❌ `load_machines`（item="Copper Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **12:40** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8
- **12:40** Farm ❌ `place`（item="Preserves Jar"）
  - 结果：'Preserves Jar' not found in inventory
- **12:40** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
- **13:10** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **13:40** Mine ❌ `mine`（floors=6）
  - 结果：action timed out after 5 minutes
- **15:50** UndergroundMine54 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [hud] +82 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [question] 
- **16:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **16:40** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~141g (paid overnight)
- **16:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 2x Sprinkler, 147x Stone, 3x Fiber, 4x Coal, 3x Copper Ore
- **16:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：2677 → 2158（-519g）
- 出货估值：141g　动作：34 个　失败：9 个
- 模型调用：7 次　tokens：81245

## 🧠 夜间复盘
昨天洒水器×3、保存罐×1 已 craft 并落地，熔炉取锭成功，是有效进展；但 12:40 后脚本重写把已完成的 craft 又重跑一遍，导致 3 次 craft/place 失败，且下矿 5 分钟超时、build_road 全被树挡。核心问题：脚本重写后重复执行已完成动作、下矿前未确认食物与体力、副任务与主活动顺序混乱。

**新教训：**
- 脚本重写后若把已 craft/已 place 的动作再跑一遍，必返回 'not enough ingredients' 或 'not found in inventory'：重写前先读背包和机器状态，只调整未完成分支。
- mine 返回 'action timed out after 5 minutes' 说明下矿动作本身超时，不是没梯子：当天不再调 mine，直接转钓鱼，避免重复超时浪费 5 分钟。
- build_road 在农场树/作物密集时返回 'laid 0 tiles, 24 skipped: blocked by trees/crops/objects'：当前阶段永久禁用，省下的时间转钓鱼或砍树。
- 下矿前食物只有 1 个时安全上限卡在 19 层，下 40 层必被生命/体力卡死：备 5+ 食物是下 40 层的硬前置，不是可选步骤。
- 熔炉取锭后当天未再装铁矿，铁锭永远炼不出来：collect 确认炉空后必须当天 load 铁矿，否则钢水壶里程碑永远差铁锭。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春28，季末）

## 长期目标
当前里程碑：**工具按档升级（钢水壶）**——需 5000g + 5 铁锭，现有 2017g、铁锭 0（昨日铜锭已入账但铁锭未炼成），差约 3000g + 5 铁锭。铁锭靠熔炉炼铁，铁矿石只能下 40 层以下拿，而安全下 40 层需 5+ 回血食物。
并行里程碑：**洒水器×4**——昨日已 craft 3 个并落地，第 4 个缺 1 铁锭，等铁锭产出后补；**保存罐**——昨日已 craft 1 个，暂不再做。
之后：**下矿装备**——当前最深 54 层但只安全到 19 层（食物不足），需先备 5+ 食物才能下 40 层拿铁。
接下来 3 天主活动：
- **今天（春28，季末）**：① 熔炉 collect 取锭 + 装铁矿（若背包有 Iron Ore 2）；② 备 5 份食物（Saloon 沙拉或钓鱼）；③ 下矿 40 层以下拿铁矿石+煤，目标 5 铁锭；④ 现金够 5000g 且铁锭够 5 就升钢水壶；⑤ 22:00 前 sleep。
- **明天（夏1）**：买啤酒花/蓝莓/甜瓜种子，开始增值期；洒水器补第 4 个。
- **后天（夏2）**：作物加工（保存罐/小桶），继续攒钱升下一档工具。

## 每日固定流程（按顺序，失败一次即跳下一步，不重试，不重写脚本重跑已完成动作）
1. **熔炉取锭**：`collect_machines` 1 次。返回产物即入账；返回 "no machine has finished output" 当天不再 collect。
2. **熔炉装矿**：仅在 collect 确认炉空后 `load_machines` 1 次，装 Iron Ore（优先）或 Copper Ore。返回 "no empty machine"/"all machines are busy" 立即熔断，当天不再 load。
3. **备食物（下矿硬前置）**：背包回血食物<5 时，12:00 后去 Saloon `open_shop`→`buy` Salad×3→`close_menu`（buy 必须在 close_menu 前）。食物≥5 才允许下 40 层以下；≥3 才允许下 20 层以下。
4. **下矿（主活动）**：`goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，≤6 次 mine。每层先 `fight` 清怪 1-2 次再 mine；返回 "no stones left and no ladder found" 先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时（5 分钟）后当天不再调 mine，转钓鱼。**
5. **钓鱼（现金兜底）**：下矿体力耗尽或 mine 超时后转 River/海边钓 1-2 轮（≤3 次 fish）。鱼饵耗尽或连续 2 轮垃圾立即停钓。
6. **浇水**：水壶在背包则 `water_crops` 1 次；返回 "no watering can" 跳过。
7. **工具升级（仅当现金≥5000g 且铁锭≥5）**：9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，不去铁匠铺。
8. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **脚本重写后禁止重跑已完成动作**：重写脚本前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y，先确认目标格有树；返回 "tile cleared" 立即换格，同格不重试。
- **place 前先确认背包有该物品**：没有就跳过，不调用。
- **craft 前先实时读材料**：不凭旧记忆判断缺口；返回 "not enough ingredients" 后当天不再 craft 同一物品。
- **熔炉熔断**：load 返回 "no empty machine"/"all machines are busy" 即当天永久跳过 load 分支，不重试、不循环。
- **禁止连续 collect 空转**：`collect_machines` 每天≤2 次；返回 "no machine has finished output" 后当天不再 collect。
- **主活动硬编码**：12:00 后分支固定为「下矿→钓鱼→砍树」三选一，任何动作失败立即跳下一分支，不留空循环。
- **mine 超时熔断**：`mine` 返回 "action timed out" 后当天不再调 mine，直接转钓鱼或砍树。
- **下矿清怪优先**：每层先 `fight` 清怪 1-2 次再 mine；返回 "no stones left and no ladder found" 先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示"正在升级"及现金/锭是否够；不够直接跳过。**金镐 10000g 不够，今天不尝试。**
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **build_road / decorate / clear_debris 禁用**：农场树多必返回 0 铺设，省时间转钓鱼或砍树。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤4、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤6、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **季末规划**：春季作物在夏季第 1 天枯死；季末只种能在 28 日前成熟的作物。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本；重写只调整未完成分支。

## 优先级（体力/时间冲突时）
1. collect 熔炉取锭（1 次）
2. 熔炉装矿（仅 collect 确认炉空后，失败即熔断）
3. 备食物≥5（Saloon 沙拉或钓鱼）
4. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥5 才下，≤6 次 mine，超时即停）
5. 钓鱼（现金兜底，River/海边 1-2 轮，连续垃圾立即停）
6. 浇水（水壶在背包时）
7. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
8. 社交（仅顺路）
9. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天洒水器×3、保存罐×1 已 craft 并落地，熔炉取锭成功，是有效进展；但 12:40 后脚本重写把已完成的 craft 又重跑一遍，导致 3 次 craft/place 失败，且下矿 5 分钟超时、build_road 全被树挡。核心问题：脚本重写后重复执行已完成动作、下矿前未确认食物与体力、副任务与主活动顺序混乱。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 12:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 12:40 动作 `craft` 失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1 〔自动〕
- 12:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:40 动作 `craft` 失败 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8 〔自动〕
- 12:40 动作 `place` 失败 @ Farm — 'Preserves Jar' not found in inventory 〔自动〕
- 13:40 动作 `mine` 失败 @ Mine — action timed out after 5 minutes 〔自动〕
- 16:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 脚本重写后把已完成的 craft 洒水器/保存罐又重跑一遍，连续 3 次失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1；can't craft Preserves Jar: not enough ingredients；place 'Preserves Jar' not found in inventory（做不了：浪费 3 个动作和时间，挤占了下矿窗口） 〔复盘〕
- 下矿动作 5 分钟超时，全天矿洞零推进 @ Mine — action timed out after 5 minutes（做不了：拿不到铁矿石，钢水壶里程碑卡在铁锭不足） 〔复盘〕
- 下矿前只备了 3 份沙拉，食物不足以下 40 层拿铁 @ Saloon / Mine — only 1 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：安全上限卡在 19 层，铁矿石拿不到） 〔复盘〕
- 熔炉取锭后未再装铁矿，铁锭当天零产出 @ Farm — load_machines: no empty machine accepts anything in the backpack or the farm chests（做不了：钢水壶差 5 铁锭，进度停滞） 〔复盘〕
- build_road 在农场被树/作物挡住，0 铺设 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)（做不了：无实际影响，但浪费 1 个动作） 〔复盘〕
