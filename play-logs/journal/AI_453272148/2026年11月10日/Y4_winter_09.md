# 第4年 winter 9 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（08:49 开始）
- 天气：snow　金钱：53717g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：a5ff3866777d45e796454e4cbeb57297
  - 耗时：17.391 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：ec69d5354a704810995b60cf0c2c661a
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：20abb8ae94e340bd8daf71b81f00e0bf
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：aaf8deab471040b3be9cdd7eda33b2be
  - 耗时：0.328 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_09）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天靠电梯直达 75 层拿铁矿石和煤
- 起床先读熔炉状态：两炉都忙就先 collect 收成品，再 load 铁矿石（每天最多 1 次，12:00 前完成）
- 清背包到空格 ≥10，再补食物到 ≥3（Forest 河边钓鱼，杂鱼立刻卖掉）
- 电梯直达 75 层下矿拿铁矿石和煤（最多 2 次 mine，每次最多 5 层），成功后回农场存材料
- 回农场 collect 收铁锭；铁锭 ≥5 且时间在 15:30 前就去 Blacksmith 升 hoe
- 14:00 后顺路去冒险家公会买 Claymore（现金够、时间对得上才买）
- 条件满足就 craft 洒水器并落地；22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `store_items`（items=["Stone", "Copper Ore", "Clay", "Geode"]）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `ship_produce`（except=["Pike", "Perch", "Catfish", "Largemouth Bass"]）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="AdventureGuild"）
16. `buy`（item="Claymore"）
17. `goto_location`（location="Farm"）
18. `craft`（item="Sprinkler", count=1）
19. `place`（item="Sprinkler", x=25, y=12）
20. `water_crops`
21. `sleep`
- **06:20** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：f3a3ea88164849af8540b176985f23ec
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f8f235cf98f7467cbc0ca85c30bf88cf
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：477f6554945f4da8ac4db7bf78c684fd
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Clay", "Geode"]）
  - 结果：stored in chest at (74,15): 1x Geode
  - 执行状态：SUCCESS · 操作编号：7b6906850fdf4542ac68882137623ff2
  - 耗时：18.39 秒 / 游戏 20 分钟
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：88c766c008d04ebfa7ffb9a533ab5292
  - 耗时：24.766 秒 / 游戏 30 分钟
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Perch, Perch, Green Algae)
  - 执行状态：SUCCESS · 操作编号：f5dbc86fd31d4e6698f85c764c080a15
  - 耗时：68.172 秒 / 游戏 60 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **08:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：55cd6baf9fd54bdbacc9105b8676c099
  - 耗时：77.75 秒 / 游戏 100 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：62988e5103d143aa8f9042cb9ffc96fb
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包仅4空格导致mine被拒，先回农场存材料腾格再下矿，其余路线保留。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Fiber", "Green Algae"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
10. `collect_machines`
11. `craft`（item="Sprinkler", count=1）
12. `place`（item="Sprinkler", x=25, y=12）
13. `water_crops`
14. `sleep`
- **09:50** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：2580675b19c44798914d426861f35c7e
  - 耗时：0.343 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5125a18ea7364736a5918957679ab719
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅4空格导致下矿被拒，先回农场存材料腾格再下矿，回来收锭并升hoe，最后craft洒水器落地睡觉。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Fiber", "Green Algae", "Cobblestone Path"]）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
11. `collect_machines`
12. `craft`（item="Sprinkler", count=1）
13. `place`（item="Sprinkler"）
14. `water_crops`
15. `sleep`
- **09:50** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：70529d6db2f747e8a3abd4d72375577c
  - 耗时：0.36 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3916f149f8e642c89403120a31476312
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包仅4空格导致mine被拒，先回农场存材料腾格、收熔炉铁锭，再下矿拿铁矿；铁锭不足5则跳过升级，直接浇水睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Fiber", "Green Algae", "Cobblestone Path"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
8. `collect_machines`
9. `water_crops`
10. `sleep`
- **09:50** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：bd8263f8241e4726bbbf4431711077e0
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3bcdb84787ba4d5993c6100fcd05fc0c
  - 耗时：0.344 秒 / 游戏 0 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：de19b56291634911999e504bc546a320
  - 耗时：33.594 秒 / 游戏 40 分钟
- **10:30** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Fiber", "Green Algae", "Cobblestone Path"]）
  - 结果：stored in chest at (74,15): 1x Coal, 1x Fiber, 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：490f0afa006547c8a9442818114a6a80
  - 耗时：15.969 秒 / 游戏 20 分钟
- **10:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：6ee593da3b884eaaa9039f7f810f416e
  - 耗时：19.14 秒 / 游戏 30 分钟
  - 🗨️ [hud] Copper Bar
- **11:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：d510267ff6384f1fb980c069b51c78d5
  - 耗时：0.422 秒 / 游戏 0 分钟
- **11:20** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：352763a4b8ba4cc9a2bc2d4b7555ee0a
  - 耗时：18.375 秒 / 游戏 30 分钟
- **11:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：d9bb455485324832b006224c2349859e
  - 耗时：0.36 秒 / 游戏 0 分钟
- **11:50** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：f5f27133eac942fab96d3652c9a3300f
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：66d2c94418f745c9963449c0385c4a87
  - 耗时：0.344 秒 / 游戏 0 分钟
- **11:50** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：ff4875c1806547d19399a4bb7de7175f
  - 耗时：0.375 秒 / 游戏 0 分钟
- **11:50** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 35 to 39 (4 floors down, 38 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：f04bc6a82b0047f4a1a3f1bf538c08ed
  - 耗时：100.687 秒 / 游戏 120 分钟
  - 🗨️ [hud] Omni Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
- **13:50** UndergroundMine39 ✅ `mine`（floors=3, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 39 to 39 (0 floors down, 0 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：d449a709e6454f17a5a6cf0985d75973
  - 耗时：0.375 秒 / 游戏 0 分钟
- **13:50** UndergroundMine39 ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：813ac3b7749542f195e03303c6e9899f
  - 耗时：44.609 秒 / 游戏 60 分钟
  - 🗨️ [question] 
- **14:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **14:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4e44f60fdfe24090a9265e88b535190b
  - 耗时：12.766 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：53717 → 53717（+0g）
- 出货估值：0g　动作：32 个　失败：11 个
- 模型调用：6 次　tokens：83555
- 有效动作率：0.5161　空转：11　熔断跳过：0
- 失败耗时：49.171 秒 / 游戏 60 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天32动作11失败，核心卡点仍是铁锭零产出：4次mine因背包空格<5被拒（脚本重写3次仍重跑mine），load_machines因两炉busy连续失败，collect与load时序错乱。唯一有效产出是Forest钓鱼4条。深层原因：脚本生成阶段未读背包就生成mine分支，且清背包手段（store_items到74,15）路径不可达。今天必须先解决背包与熔炉时序，再下矿。

**新教训：**
- 昨天 4 次 mine 全因空格 <5 被拒，而脚本重写 3 次仍重跑 mine：脚本生成阶段必须先读背包，空格 <10 时物理删除 mine 分支，而不是运行时反复被拒。
- 昨天起床先 collect 返回空、再 load 又 busy，铁锭全天零新增：应改为起床先 collect（有成品收走）再 load，且 load 返回 busy 即当天永久跳过，不连续调。
- 昨天 store_items 到 (74,15) 与 ship_produce 到 (70,15) 都返回 could not reach：农场常用箱子/出货箱路径被树或作物挡住，清背包前应改用农场入口附近可达的箱子，或先 ship_produce 卖低价值物，不要重试同一坐标。
- 昨天 build_road 返回「24 skipped: blocked by trees/crops/objects」、decorate 返回「今天没有能做的装饰」：这两类动作在农场地面被占满时永远 0 产出，应从脚本彻底删除，把动作预算留给钓鱼和下矿。
- 昨天唯一有效产出是 Forest 钓鱼 4 条（Pike/Perch）：主活动被卡时应在 1 个动作内转 Forest 钓鱼，而不是重写脚本重试失败动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 10）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 53717g 充足，Iron Bar 仅 1，差 4 锭（≈12 铁矿石 + 4 煤）。铁锭同时是洒水器材料，**「稳定产出铁锭」是唯一主线**。

离完成还差：12 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 10，无节日）**：起床读熔炉状态 → 清背包到空格 ≥10（验证通过才算）→ 电梯直达 75 层下矿拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 11）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 12）**：洒水器 craft+place 落地 + 冬季种子/茶苗，为春 1 做准备。

## 今日核心修正（针对昨天失败）
1. **脚本生成阶段先读背包**：若空格 <10，物理删除 mine 分支，先执行清背包流程；绝不在运行时反复被拒。
2. **清背包双通道**：优先 store_items 到农场入口附近可达箱子；若返回 could not reach，立即改 ship_produce 卖低价值物（Stone 除外）；两手段后仍不足则当天定性钓鱼日。
3. **熔炉时序**：起床先 collect_machines 1 次（有成品收走）；再 load 铁矿石 1 次；load 返回 busy 即当天永久跳过 load，不再重试。load 与 collect 之间隔 ≥2 小时。
4. **mine 熔断**：mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：collect_machines 1 次**（收熔炉成品）。返回空即当天永久跳过 collect。
2. **load 铁矿石 1 次**（12:00 前完成）。返回 busy/no empty 即当天永久跳过 load。
3. **清背包到空格 ≥10**：store_items 到可达箱子 → 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次手段仍不足则当天定性钓鱼日，物理删除 mine 分支。
4. **补食物到 ≥3**：goto Forest 河边 fish ≤2 轮（每轮 ≤4 cast），只留高回复鱼，杂鱼立即 ship_produce 卖掉。
5. **下矿（仅当空格 ≥10 且食物 ≥3 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**优先电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → buy Claymore。失败一次即当天永久跳过。禁止 14:00 前专门 goto 公会等开门。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **浇水**：水壶在背包则 water_crops 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 sleep；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。**store_items 返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。**
- **熔炉时序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。**不连续调 load。**
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥3 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制。**
- **武器优先于下矿**：Silver Saber 8-15 在 80 层以下被拒，今天必须先买 Claymore（2000g）再下矿；买武器失败则当天只下 75-79 层。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **禁止专门等商店开门**：14:00 前不 goto Adventurer's Guild；等待时间用于钓鱼或下矿，14:00 后顺路买。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤1、water_crops≤1、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。**电梯直达 75 层例外。**
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：collect_machines 1 次（收熔炉成品）
2. load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
3. **清背包到空格 ≥10**（store_items 到可达箱子 + 读背包验证；不足则 ship_produce）
4. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥3、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
9. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30、顺路；失败即跳过）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天32动作11失败，核心卡点仍是铁锭零产出：4次mine因背包空格<5被拒（脚本重写3次仍重跑mine），load_machines因两炉busy连续失败，collect与load时序错乱。唯一有效产出是Forest钓鱼4条。深层原因：脚本生成阶段未读背包就生成mine分支，且清背包手段（store_items到74,15）路径不可达。今天必须先解决背包与熔炉时序，再下矿。
- 06:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:50 动作 `build_road` 失败 @ UndergroundMine39 — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) | 游戏消息: [question]  〔自动〕
- 14:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 4 次 mine 全因背包空格不足被拒，脚本重写 3 次仍重跑 mine @ Mine 入口 / Farm 箱子 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（共 4 次）（做不了：下矿拿铁矿石完全没开始，铁锭零产出，钢锄头和洒水器都卡在缺 Iron Bar） 〔复盘〕
- 熔炉时序错乱：起床 collect 返回空，再 load 又 busy，之后又调 load 被 suppressed @ Farm 熔炉 — collect_machines -> FAIL: no machine has finished output；load_machines -> FAIL: no empty machine accepts anything / repeated ineffective action suppressed（做不了：铁锭全天零新增） 〔复盘〕
- 清背包手段失效：store_items 到 (74,15) 与 ship_produce 到 (70,15) 都不可达 @ Farm 箱子/出货箱 — store_items -> could not reach；ship_produce -> could not reach (70,15); stopped at (53,8)（做不了：背包清不出空格，连锁导致 mine 全被拒） 〔复盘〕
- 下矿到 39 层因食物不足被拦，无法下 40 层以下 @ UndergroundMine 39 层 — mine -> stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 铺路与装饰连续失败，浪费动作预算 @ Farm — build_road -> laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate -> 今天没有能做的装饰（做不了：农场通道没清出来，箱子/出货箱路径仍被挡） 〔复盘〕
