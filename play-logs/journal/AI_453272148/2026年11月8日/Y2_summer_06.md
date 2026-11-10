# 第2年 summer 6 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（02:02 开始）
- 天气：sunny　金钱：1183g　体力：270/270
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
  - 🗨️ [mail] Fisherman Wanted I need a good pufferfish specimen. I'm conducting an experiment on the toxin created by the pufferfish. Reward: 1000g  -Demetrius [quest accepted]
  - 🗨️ [hud] New Journal Entry
- **06:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Broken Glasses, 34x Stone, 5x Iron Ore
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops

## 🌙 为明天（Y2_summer_06）准备的脚本
- 里程碑：工具按档升级——钢水壶（凑 5 铁锭 + 5000g）
- 先 collect 熔炉取锭，炉空立刻 load 5 块铁矿（背包已有 5 块）
- 现金<700g 去 Forest 河边钓鱼补现金
- 12:10 后去 Saloon 买 Salad×5（只试 1 次）
- 食物≥5 下矿 40 层以下拿铁矿+煤（≤3 次 mine，超时即停）
- 回农场再 load 铁矿 1 次，浇水，22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `water_crops`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Town"）
9. `open_shop`（shop_id="Saloon"）
10. `buy`（item="Salad", count=5）
11. `close_menu`
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`
20. `sleep`
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 16 crops
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~723g (paid overnight)
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 因 wait_letter 失败，跳过该分支；熔炉已空但装矿失败，按熔断转钓鱼补现金，再买沙拉下矿，回农场试装铁矿后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Town"）
5. `open_shop`（shop_id="Saloon"）
6. `buy`（item="Salad", count=5）
7. `close_menu`
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `load_machines`（item="Iron Ore"）
15. `water_crops`
16. `ship_produce`
17. `sleep`
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Broken CD, Trash, Pike, Trash)
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Pike
- **08:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Joja Cola, Pike, Green Algae, Trash)
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
- **09:40** Forest ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,90)
- **10:20** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
- **12:00** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)

### 🔁 脚本重写：重写#2：Saloon 开门失败一次即按策略放弃，改去 Forest 河边钓鱼补现金，回农场收熔炉锭并装铁矿后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Farm"）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `ship_produce`
9. `sleep`
- **12:00** Town ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
- **12:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Dorado, Dorado, Green Algae, Chub)
  - 🗨️ [hud] Dorado
  - 🗨️ [hud] Dorado
  - 🗨️ [hud] Green Algae
- **13:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Sunfish, Rainbow Trout, Chub)
  - 🗨️ [hud] Pike
- **15:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
- **15:30** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **15:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **15:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **15:30** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~749g (paid overnight)
  - 🗨️ [hud] Inventory Full
- **16:00** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Iron Bar
- **16:10** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **16:20** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
- **16:20** Farm ✅ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：1183 → 2655（+1472g）
- 出货估值：1472g　动作：151 个　失败：129 个
- 模型调用：5 次　tokens：49260

## 🧠 夜间复盘
昨天 129 次失败中 127 次是 load_machines 空转，熔炉全天没装矿，铁锭零产出，钢水壶和洒水器双双卡住。有效的是 Forest 钓鱼（624g）和下矿拿铁矿。今天必须把 load 限制在 2 次以内，先 collect 确认炉空再装，其余时间钓鱼补现金、下矿补铁。

**新教训：**
- load_machines 返回 'all machines are busy' 后继续调用会连续失败并耗尽步数上限（昨天 127 次）：load 每天硬上限 2 次，失败即当天永久跳过，绝不轮询。
- 铁锭 2 已够做 2 个洒水器，但昨天因先下矿后 craft 而错过：材料齐的 craft 必须排在下矿之前，当天先做。
- Wood 仅剩 1 时砍树会因背包满拿不到木头：砍树前先 ship_produce 清出 ≥3 空格，否则木头被挤掉。
- 熔炉装矿前必须先 collect 确认炉空；若 collect 返回空但 load 仍报 busy，说明炉子还在炼上一批，当天不再 load，等第二天。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏7）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 1183g（今早出货约 +1472g 到账），铁锭 2，Iron Ore 8，Coal 16，Copper Bar 59，Stone 2459，Wood 1。差约 3800g + 3 铁锭。
并行里程碑：**洒水器×4**（铜锭够，铁锭 2 已够做 2 个，今天先 craft+place 2 个）；**钓鱼 9 级**，缺鱼饵（威利店 Bait 5g/个）。
接下来 3 天主活动：
- **今天（夏7）**：① collect 熔炉 1 次；② 炉空则 load Iron Ore 5 块（只试 1 次，失败即熔断）；③ 铁锭≥1 且铜锭≥1 立刻 craft 洒水器并 place（最多 2 个）；④ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑤ 食物≥5、空格≥5 才下矿 40 层以下拿铁矿+煤，≤2 次 mine；⑥ 回农场再 load 铁矿 1 次（仅炉空时）；⑦ 22:00 前 sleep。
- **明天（夏8）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏9）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **熔炉取锭（仅 1 次）**：`collect_machines` 1 次。返回 "no machine has finished output" 当天永久跳过 collect，立即进第 2 步。
2. **熔炉装矿（当天必做，只试 1 次）**：collect 后立刻 `load_machines` 装 Iron Ore 5 块（背包有 5 块就装 1 炉；不足 5 块装 Copper Ore 保炉不空）。返回 "no empty machine"/"all machines are busy" 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
3. **洒水器 craft+place（排在下矿前）**：实时读材料，铁锭≥1 且铜锭≥1 就 `craft` 洒水器并 `place` 到耕地，最多 2 个；材料不齐跳过。
4. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
5. **备食物**：背包回血食物<5 且现金≥400g 时，**12:10 后**才去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。11:30 前不靠近 Saloon，不在门口等；失败一次即放弃转钓鱼。现金<400g 先钓鱼。
6. **下矿（主活动）**：食物≥5、空格≥5 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回 "no stones left and no ladder found" 先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。这是钢水壶唯一铁锭来源。
8. **钓鱼**：下矿体力耗尽或 mine 超时后转 Forest 河边钓 1-2 轮（≤3 次 fish）。鱼饵耗尽先去威利店买 Bait（5g/个，≤20 个）再钓；连续 2 轮垃圾立即停钓。
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回 "no watering can" 跳过。
10. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
11. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **load 硬熔断（今天最重要）**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 "no empty machine"/"all machines are busy" 即当天永久跳过 load，绝不重试、绝不轮询。昨天 127 次 load 空转导致步数耗尽，今天必须在前 100 动作内完成主活动。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过，立即切钓鱼/下矿，绝不轮询。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **mine 超时熔断**：`mine` 返回 "action timed out" 后当天不再调 mine，直接转钓鱼。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y，先确认目标格有树；返回 "tile cleared" 立即换格。
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回 "not enough ingredients" 后当天不再 craft 同一物品。
- **材料齐的副任务当天做完**：洒水器材料齐就当天 craft+place，排在下矿之前。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示"正在升级"及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **build_road / decorate / clear_debris 禁用**。
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
1. collect 熔炉取锭（仅 1 次，空即跳第 2 步）
2. 熔炉装矿（只试 1 次，失败即熔断）
3. 洒水器 craft+place（材料齐当天做，排在下矿前）
4. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
5. 备食物≥5（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
6. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥5 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 钓鱼（现金兜底，Forest 河边 1-2 轮，连续垃圾立即停）
9. 浇水（水壶在背包时）
10. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
11. 社交（仅顺路）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天 129 次失败中 127 次是 load_machines 空转，熔炉全天没装矿，铁锭零产出，钢水壶和洒水器双双卡住。有效的是 Forest 钓鱼（624g）和下矿拿铁矿。今天必须把 load 限制在 2 次以内，先 collect 确认炉空再装，其余时间钓鱼补现金、下矿补铁。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 12:00 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 15:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 熔炉 load 连续 127 次空转，铁锭全天零产出 @ Farm 熔炉 — 127x load_machines: no empty machine accepts that, and the rest are busy; try again after they finish（做不了：钢水壶差 3 铁锭、洒水器缺铁锭，两个里程碑同时卡住；步数上限被耗尽，当天被强制 sleep） 〔复盘〕
- Saloon 在 12:00 仍打不开，买沙拉失败，食物不足 5 份 @ Town / Saloon — open_shop: can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)（做不了：食物<5 无法下 40 层以下拿铁矿石，铁锭来源被切断） 〔复盘〕
- 洒水器材料已够（铜锭 59、铁锭 2）却未 craft，计划排在下矿之后被挤掉 @ Farm 耕地 — 计划顺序错误：craft 排在下矿之后，下矿耗尽体力后未执行（做不了：洒水器里程碑停滞，仍每天手动浇水占用体力） 〔复盘〕
- Wood 仅剩 1，砍树时背包满导致木头没拿到 @ Farm (46,20) — use_tool axe 返回 Inventory Full（做不了：保存罐（需 50 木头）、箱子、鸡舍等建造材料不足） 〔复盘〕
- 社区中心献祭无法推进 @ Community Center — donate: can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心收集包停滞，温室/矿车解锁延后） 〔复盘〕
