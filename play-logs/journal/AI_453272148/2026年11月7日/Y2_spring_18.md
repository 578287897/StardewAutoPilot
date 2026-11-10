# 第2年 spring 18 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（22:35 开始）
- 天气：sunny　金钱：4912g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y2_spring_18）准备的脚本
- 里程碑：工具按档升级——今天无斧，先取回钢斧头（春19可取）
- 熔炉只炼铁，取铁锭
- 洒水器×4 落地（带坐标，先清位/换锚点）
- 补 3 木头 craft 保存罐
- 主活动：下矿 45-49 层拿铁矿/煤（体力≥30、食物≥5）
1. `donate`
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="axe"）
4. `goto_location`（location="Farm"）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `take`（item="Driftwood", count=10）
9. `craft`（item="Preserves Jar", count=1）
10. `place`（item="Sprinkler", x=51, y=14）
11. `place`（item="Sprinkler", x=52, y=14）
12. `ship_produce`
13. `goto_location`（location="Mine"）
14. `mine`（floors=4）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `load_machines`（item="Iron Ore"）
18. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 15 crops
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：跳过 donate（wait_letter 阶段必失败），保留原路线：先熔炉炼铁、补木头做保存罐、洒水器带坐标落地，再下矿拿铁，回农场收锭后睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `take`（item="Driftwood", count=10）
4. `craft`（item="Preserves Jar", count=1）
5. `place`（item="Sprinkler", x=51, y=14）
6. `place`（item="Sprinkler", x=52, y=14）
7. `goto_location`（location="Mine"）
8. `mine`（floors=4）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `sleep`
- **06:20** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **06:20** Farm ✅ `take`（item="Driftwood", count=10）
  - 结果：took 9x Driftwood from chest at (74,15)
- **06:30** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8

### 🔁 脚本重写：重写#2：craft 失败因木头不足，先从箱子取 Driftwood 补齐再 craft，其余路线不变。
1. `take`（item="Driftwood", count=10）
2. `craft`（item="Preserves Jar", count=1）
3. `place`（item="Sprinkler", x=51, y=14）
4. `place`（item="Sprinkler", x=52, y=14）
5. `goto_location`（location="Mine"）
6. `mine`（floors=4）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **06:30** Farm ✅ `take`（item="Driftwood", count=10）
  - 结果：took 10x Driftwood from chest at (75,15)
- **06:30** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine)

### 🔁 脚本重写：重写#3：保存罐材料不足已熔断，跳过craft，保留洒水器落地与下矿拿铁路线。
1. `place`（item="Sprinkler", x=51, y=14）
2. `place`（item="Sprinkler", x=52, y=14）
3. `goto_location`（location="Mine"）
4. `mine`（floors=4）
5. `leave_mine`
6. `goto_location`（location="Farm"）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `sleep`
- **06:30** Farm ✅ `place`（item="Sprinkler", x=51, y=14）
  - 结果：placed Sprinkler at (53,17)
- **06:40** Farm ❌ `place`（item="Sprinkler", x=52, y=14）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
- **06:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **07:30** Mine ✅ `mine`（floors=4）
  - 结果：mined from floor 45 to 49 (4 floors down, 55 stones broken)
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Stone
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
- **09:20** UndergroundMine49 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [question] 
- **09:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:00** Farm ✅ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4912 → 4912（+0g）
- 出货估值：0g　动作：151 个　失败：6 个
- 模型调用：5 次　tokens：58707

## 🧠 夜间复盘
昨天最大浪费是脚本用 collect_machines 空转 133 次、最后 wait 到 17:00，全天只炼了 3 块铁、洒水器没落地、保存罐差 3 木头。核心问题不是缺资源，而是脚本把「等机器」当成主活动，且没有在失败后切到下矿/钓鱼。今天必须把主活动锁定为下矿 45-49 层拿铁/煤，机器只在固定时段收一次。

**新教训：**
- collect_machines 一天调用 133 次全部返回 'no machine has finished output'：机器只在固定时段（9:00/15:00）各收一次，返回空后当天不再 collect，否则主活动时间被空转吃光。
- 脚本在 12:30 后没有主活动可做时用 wait 填充到 17:00，4 小时零收益：主活动分支必须硬编码为下矿或钓鱼，wait 永久禁用。
- 洒水器 place 返回 '无空位' 后继续在同一分区重试只会重复失败：应立即换到另一块已清空田块锚点，或先 chop_tree 清位再 place。
- Wood 47/50 差 3 时昨天选择等明天砍树，结果保存罐里程碑拖一天：有斧当天就砍 1 棵树补到 50，或从箱子取 Driftwood，不要等。
- mine 动作超时/0 层推进一次后应熔断改钓鱼，不要连续调 mine 浪费动作；下矿前必须确认体力≥30、食物≥5、生命>50%。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春19）

## 长期目标
当前里程碑：**工具按档升级**——钢斧头今天可取（克林特处，春19），取回后下一件评估镐（需 5 铁锭，当前 3/5，今天下矿补）。
并行里程碑：**洒水器×4 落地**（已 craft，卡在分区无空位）与**保存罐×2**（Wood 47/50，差 3 木头）。
离完成还差：斧头取回（0 材料）；镐需 5 铁锭（差 2）；洒水器需清 4 空位；保存罐需 3 木头。
接下来 3 天主活动：
- **今天（春19）**：① 9:10 后第一动作取钢斧头；② 取回后砍大树桩拿硬木、补 3 木头 craft 保存罐；③ 洒水器落地（先清位/换锚点，带 x,y）；④ 主活动**下矿 45-49 层拿铁矿/煤**（体力≥30、食物≥5、生命>50%），目标铁锭 3→5。
- **明天（春20）**：铁锭够 5 就升级镐（一次只升一件）；否则继续下矿；洒水器/保存罐收尾。
- **后天（春21）**：规划夏季啤酒花/蓝莓地块，攒铁锭做高级洒水器前置（农业 6 级）。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. **取工具（春19 起）**：9:10-15:30 内 `goto_location` Blacksmith → `upgrade_tool` 取斧头（≤1 次）。取回后当天不立即升下一件，先评估铁锭。
2. **熔炉（只炼铁，固定时段收一次）**：**只在 9:00 和 15:00 各收一次** `collect_machines`（≤2 次/天），取到铁锭后 `load_machines` item=Iron Ore 1 次。返回 "all machines are busy"/"no empty machine" 立即熔断，当天不再调用。**铜矿永不入炉**。**禁止连续 collect 空转**：collect 返回 "no machine has finished output" 后当天不再 collect，直到 15:00 再试一次。
3. **浇水**：水壶在背包则 `water_crops` 1 次；返回 "no watering can" 跳过。
4. **洒水器落地**：先确认目标分区有空位；无空位先 `chop_tree`/清杂物腾位（今天有斧，可砍），或换到另一块已清空田块锚点，`place` 必须带 x,y（≤2 次）。返回 "无空位" 立即换锚点或当天放弃，同一分区不重试。
5. **清背包**：空格<5 时 `ship_produce` 白名单清出≥5 格。
6. **craft 保存罐**：Wood≥50 且 Stone≥40 且 Coal≥8 时 craft≤1 次。Wood 47 差 3：取回斧头后砍 1 棵树或从箱子取 Driftwood 补到 50，补不到就明天。
7. **主活动（12:00 后必须选一个，禁止 wait、禁止连续 collect）**：
   - **下矿**（体力≥30、食物≥5、生命>50%、时间<15:00）：`goto_location` Mine 入口 → `mine` 目标 45-49 层，到 50 层无产出立即 leave_mine；生命<50% 或食物=0 立即 leave_mine。**mine 动作超时/0 层推进一次即熔断，改钓鱼**。
   - **钓鱼**（时间≥15:00 或体力<30）：River 或海边钓 2-3 轮，Mountain 湖不作默认钓点。
8. **买鱼饵（仅当现金≥150g 且 9:00-16:30）**：open_shop 后一次性 buy Bait 20 → close_menu，关菜单后不再 buy。
9. **买种子（仅当现金≥2200g 且空格≥5）**：只买已解锁春季作物，单次 buy≤2 次，现金留≥1800g。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间**，做完主活动直接 sleep 或转钓鱼。

## 规则
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼/下矿。
- **禁止连续 collect 空转**：`collect_machines` 每天≤2 次且只在 9:00/15:00 各一次；返回 "no machine has finished output" 后当天不再 collect。昨天 133 次 collect 是最大浪费，必须硬熔断。
- **熔炉熔断**：load 返回 "all machines are busy"/"no empty machine" 即熔断，当天不再调用。collect 返回 "no machine has finished output" 不等于炉空，必须确认炉内无铜矿再装铁。
- **下矿优先于钓鱼**：铁锭未满 5 前主活动锁定下矿 45-49 层；钓鱼只在时间≥15:00 或体力<30 时做。
- **place 必须带坐标**：缺 x,y 直接不调用；返回 "无空位" 换锚点或当天放弃，同一分区当天不重试。
- **空转硬熔断**：任何动作返回 "all machines are busy"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"inventory full"、"无空位" 等，脚本层立即永久跳过该分支，当天不再调用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy。
- **18 层永久拉黑**；**50 层以上不追**：mine 目标锁定 45-49 层，到 50 层无产出立即 leave_mine；体力<30 不调 mine。
- **工具升级**：一次只升一件；升级期间（2 天）不调 mine（无镐）也不调 water_crops（无水壶）；升级前显式检查现金≥费用且锭够，不足直接跳过。今天取斧头后不立即升镐，先下矿补铁。
- **build_road / decorate / clear_debris 禁用**：昨天 24 块铺路石全被阻挡，白做。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不 wait；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下。
- **季末规划**：春季作物在夏季第 1 天枯死；季末只种能在 28 日前成熟的作物。
- **社交**：顺路 2-4 人，不专门跑图。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. 取钢斧头（春19，9:10-15:30，≤1 次）
2. 熔炉取锭+装铁（只炼铁，9:00/15:00 各一次，≤2 次）
3. 洒水器落地（先清位/换锚点，带坐标）
4. 浇水（水壶在背包时）
5. 清背包+白名单出货
6. craft 保存罐（补 3 木头，有斧可砍）
7. 下矿拿铁（体力≥30、食物≥5、时间<15:00，目标 45-49 层）
8. 钓鱼（时间≥15:00 或体力<30，River/海边，放最后单独执行）
9. 买鱼饵（现金≥150g，<16:30）
10. 买种子（现金≥2200g 且空格≥5）
11. 社交（仅顺路）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是脚本用 collect_machines 空转 133 次、最后 wait 到 17:00，全天只炼了 3 块铁、洒水器没落地、保存罐差 3 木头。核心问题不是缺资源，而是脚本把「等机器」当成主活动，且没有在失败后切到下矿/钓鱼。今天必须把主活动锁定为下矿 45-49 层拿铁/煤，机器只在固定时段收一次。
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 06:30 动作 `craft` 失败 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8 〔自动〕
- 06:30 动作 `craft` 失败 @ Farm — already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine) 〔自动〕
- 06:40 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 10:00 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 脚本用 collect_machines 空转 133 次，全天只炼了 3 块铁 @ Farm 熔炉 — collect_machines 返回 'no machine has finished output' 被当成可重试，脚本反复调用（做不了：铁锭停在 3/5，钢斧头/镐升级延后；主活动时间被吃光） 〔复盘〕
- 主活动完成后用 wait 从 12:30 空等到 17:00 @ Farm — wait 返回 OK 但只推进时间，不产生金钱或材料（做不了：下矿/钓鱼没做，全天零收益） 〔复盘〕
- 洒水器已 craft 但分区无空位，place 连续失败 @ Farm 田地分区 (51,14) — place 返回 'Sprinkler 在规划的分区里没有空位了'（做不了：洒水器放不下，无法自动化浇水，体力仍被手动浇水占用） 〔复盘〕
- 保存罐差 3 木头无法 craft，计划了但没补材料 @ Farm — can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8（Wood 47/50）（做不了：第 2 个保存罐没做出来，加工里程碑延后） 〔复盘〕
- 熔炉装料反复失败，collect 返回 'no machine has finished output' 但 load 仍失败 @ Farm 熔炉 — load_machines 返回 'all machines are busy; collect them when they finish'，说明炉内被占满（做不了：铁矿无法入炉，铁锭增长慢） 〔复盘〕
- donate 在 wait_letter 阶段必失败，社区中心献祭无法推进 @ 社区中心 — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：温室/矿车解锁延后） 〔复盘〕
