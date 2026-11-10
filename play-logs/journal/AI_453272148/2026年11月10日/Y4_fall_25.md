# 第4年 fall 25 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:53 开始）
- 天气：windy　金钱：50236g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：5ce7896b3f9a4f2cadfea3ac7062aedf
  - 耗时：3.25 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：d596987af1bd4d80af8b7d87f134d92f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 4x Coal, 1x Broken Glasses, 2x Copper Bar, 1x Joja Cola, 1x Soggy Newspaper
  - 执行状态：SUCCESS · 操作编号：d68c496e363143db8b99d0d4aec6eda7
  - 耗时：6.015 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：bfffbc4f8a974cf182ffd97d24879e4c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：964d9e2de2f34ecf97e3ed4eff441157
  - 耗时：0.375 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_25）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天靠下矿拿铁矿石+煤凑锭
- 起床先卖鱼腾格（整组卖鱼），验证空格≥8
- craft 洒水器 1 个并放置
- 起床先 collect 收锭，再 load 铁矿石（12:00 前）
- 食物≥5、空格≥8 才下矿 40-70 层拿铁矿石+煤（≤2 次 mine）
- 回农场 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 其余时间钓鱼补食物/现金，22:00 前 sleep
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar", "Iron Ore", "Coal", "Stone", "Copper Ore", "Copper Bar", "Omni Geode", "Frozen Geode", "Geode", "Silver Saber", "Rusty Sword", "Bamboo Pole", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe"]）
4. `ship`（item="Green Algae", count=5）
5. `ship`（item="Soggy Newspaper", count=1）
6. `ship`（item="Broken Glasses", count=1）
7. `craft`（item="Sprinkler", count=1）
8. `place`（item="Sprinkler"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `goto_location`（location="Mountain"）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Mountain"）
20. `goto_location`（location="Farm"）
21. `water_crops`
22. `sleep`
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：babbac5155844c82b250ad3a08feb2c3
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：688f2a9f9afb4925a153634a173b5abd
  - 耗时：39.719 秒 / 游戏 40 分钟
- **06:50** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：aabfa54b71c34276812f10c81ae54ef0
  - 耗时：39.406 秒 / 游戏 50 分钟
- **07:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 70 to 74 (4 floors down, 62 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：f74bdfac6be54ebbb0118484aa4106a6
  - 耗时：79.407 秒 / 游戏 100 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bone Fragment
  - 🗨️ [hud] Bat Wing
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Frozen Geode
  - 🗨️ [hud] Gold Ore
  - 🗨️ [question] 
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：0e652cec214141b99de9a3f5d0769bcd
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：矿洞因背包满被拒，先出矿回农场存材料收锭，铁锭够就升 hoe，否则浇水后睡。
1. `donate`
2. `leave_mine`
3. `goto_location`（location="Mountain"）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Geode", "Omni Geode", "Frozen Geode", "Bone Fragment", "Bat Wing", "Cobblestone Path"]）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `water_crops`
11. `sleep`
- **09:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：e970fcc14b37452a9ae12bd36cd9520c
  - 耗时：41.813 秒 / 游戏 60 分钟
- **10:20** CommunityCenter ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：17719f16771d4fcf9eb0a6488cf23286
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：出矿后背包仅剩1格，先回农场存材料腾格并收炉锭，铁锭不足5个故跳过铁匠铺，直接浇水睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Geode", "Omni Geode", "Frozen Geode", "Bone Fragment", "Bat Wing", "Cobblestone Path"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `craft`（item="Sprinkler", count=1）
8. `place`（item="Sprinkler"）
9. `water_crops`
10. `sleep`
- **10:20** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：7946210076b449e6b63bfea662c8e386
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:20** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ce8fe678277443338b70fb0f1cab01aa
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包满被拒，先回农场存材料腾格并收炉锭，craft 洒水器后浇水睡觉，不再重试 mine
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Geode", "Omni Geode", "Frozen Geode", "Bone Fragment", "Bat Wing", "Cobblestone Path"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `craft`（item="Sprinkler", count=1）
8. `place`（item="Sprinkler"）
9. `water_crops`
10. `sleep`
- **10:20** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：1da6c663728441fe9bd4b0ac2d619922
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:20** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：c0cbcd5245da4917ab4e36fa579ae36f
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:20** CommunityCenter ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：1badaac9d6444cbe9691f2c3bb74f35b
  - 耗时：38.094 秒 / 游戏 40 分钟
- **11:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Geode", "Omni Geode", "Frozen Geode", "Bone Fragment", "Bat Wing", "Cobblestone Path"]）
  - 结果：stored in chest at (75,15): 160x Stone, 9x Copper Ore, 2x Geode, 9x Iron Ore, 3x Omni Geode, 24x Cobblestone Path, 4x Bone Fragment, 5x Frozen Geode, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：f52774ec434048edad8252e68dcc6155
  - 耗时：1.078 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6e8de31701174005ba585e1e5f66041e
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：afcbc62b6f544fe3ba7755cba43f6b75
  - 耗时：0.312 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：9dee323bf1ef4c98af5c260f4e06734f
  - 耗时：0.312 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：479155666ca74868a5dcc471c141b0cd
  - 耗时：0.344 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 70 to 75 (5 floors down, 89 stones broken)
  - 执行状态：SUCCESS · 操作编号：801fd7fd32d94a51a35fe09ed59d32d6
  - 耗时：167.328 秒 / 游戏 220 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Frozen Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bone Fragment
- **14:40** UndergroundMine75 ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **14:40** UndergroundMine75 ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a83020a3289043bfac6aa52446ee05be
  - 耗时：53.359 秒 / 游戏 60 分钟
  - 🗨️ [question] 
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50236 → 50236（+0g）
- 出货估值：0g　动作：27 个　失败：10 个
- 模型调用：5 次　tokens：63206
- 有效动作率：0.48　空转：8　熔断跳过：1
- 失败耗时：6.671 秒 / 游戏 0 分钟
- 最深矿层：75　新增矿层：5
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动仍被背包格卡死：mine 被拒 3 次后重写脚本再调 mine，浪费约 200 游戏分钟；熔炉 collect/load 时序错，铁锭仍为 1；洒水器条件满足却因 place 无空位没落地。有效动作是下矿推进 5 层（70→75）和 store_items 腾格。今天必须把「卖鱼腾格→craft→起床即 load 铁矿→下矿」写死成顺序，mine 被拒一次即转钓鱼，不再重写脚本。

**新教训：**
- 昨天 mine 在 70→74 层成功推进 4 层后因背包满被拒，随后重写脚本再调 mine 又失败 2 次：mine 成功一次后应立即回农场 store_items 腾格，再决定是否第二次下矿，而不是连续调 mine。
- 昨天 craft 洒水器成功但 place 返回「分区无空位」：place 前应先读分区空位，无空位则 craft 后直接存箱子，不调 place。
- 昨天 collect_machines 在 600 和 1100 两次返回空，说明熔炉在起床时并无成品：起床应先 load 铁矿石（若炉空），把 collect 固定在下矿回来第一时间，而不是起床先 collect。
- 昨天 donate 在 610/920/1020 三次打开 Junimo note 均无法存入，浪费 3 个动作：donate 应从脚本彻底删除，起床到卖货之间不得插入任何非卖货动作。
- 昨天 1440 调 decorate 失败后才 sleep，说明收尾分支仍残留无效动作：22:00 后脚本只允许 sleep 一个分支，其余动作在脚本生成阶段就删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 26）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50236g 充足，唯一卡点是 Iron Bar（现有 1，铁矿石 16、煤 25，两座炉约出 2 锭，还差约 2-3 锭 ≈ 10-15 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线，钓鱼只作补食物/现金副线。

离完成还差：约 10-15 铁矿石 + 3 煤 → 5 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 26）**：起床卖鱼腾格（空格≥8）→ craft 洒水器 1 个 → 熔炉 collect 收锭 → 立即 load 铁矿石（12:00 前）→ 食物≥5、空格≥8 下矿 40-75 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect → 铁锭≥5 且 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 27）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（秋 28）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓），季末不再新种。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**第一组必须整组卖鱼**（Chub、Green Algae、Salmon、Tiger Trout 等非献祭鱼）+ 非献祭杂项（多余 Copper Bar、Sap、Soggy Newspaper、Trash）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **craft 洒水器（条件已满足，必须今天做）**：清背包后立即 `craft` 洒水器 1 个（1 铜锭 + 1 铁锭/个，现有 Copper Bar 35、Iron Bar 1，先做 1 个）。craft 后 `place` 到空地块；place 返回「分区无空位」即当天永久跳过 place，洒水器存箱子。
3. **熔炉：起床 collect 后立即 load（顺序不可颠倒，load 必须在上午完成）**
   - `collect_machines` 1 次收已完成锭（昨天 1600 前 load 的 Iron Ore 应已好）。
   - 若背包有 Iron Ore 且炉空 → `load_machines` 1 次装铁矿石，**必须在 12:00 前完成**，让它在白天炼完。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
4. **下矿前双检查**：goto Mine 前必须显式读背包确认 **空格 ≥8 且食物 ≥5**。食物 <5 时先 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），**只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper 直接卖**，补到 ≥5 再进 Mine。**食物 <5 或空格 <8 时脚本里不得出现 goto Mine。**
5. **下矿（主活动）**：`goto_location` Mine → `mine` 目标 40-75 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过，不白跑铁匠铺。** 一次只升一件。
8. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **craft 洒水器排第 2**：条件已满足（农业 2 级、Copper Bar 35、Iron Bar 1），清背包后立即 craft，不能等「有空再做」。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **熔炉顺序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
- **place 硬熔断**：`place` 返回「分区无空位」即当天永久跳过 place，不重试。place 前先确认目标分区有空位。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=参加集市/下矿/钓鱼。**节日锁门后 goto 同一地点失败一次即永久跳过，不重试。**
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
2. craft 洒水器（条件已满足，必须今天做）
3. 熔炉：起床先 collect 收锭，再 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）——下矿前置条件
5. 下矿 40-75 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主活动仍被背包格卡死：mine 被拒 3 次后重写脚本再调 mine，浪费约 200 游戏分钟；熔炉 collect/load 时序错，铁锭仍为 1；洒水器条件满足却因 place 无空位没落地。有效动作是下矿推进 5 层（70→75）和 store_items 腾格。今天必须把「卖鱼腾格→craft→起床即 load 铁矿→下矿」写死成顺序，mine 被拒一次即转钓鱼，不再重写脚本。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:20 动作 `leave_mine` 失败 @ CommunityCenter — not in the mine 〔自动〕
- 10:20 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:20 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:00 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 14:40 动作 `decorate` 失败 @ UndergroundMine75 — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包被鱼和杂项塞满，连续 3 次下矿被拒，脚本重写 3 次仍调 mine @ Mine 入口 (18,13) — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：铁矿石和煤没拿到，铁锭仍为 1，钢锄头和洒水器材料全部卡住） 〔复盘〕
- 熔炉 collect 返回空、load 返回 busy，时序颠倒 @ Farm 熔炉旁 (40,9) — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: all machines are busy（做不了：当天铁锭产出为零，钢锄头仍差 4 锭） 〔复盘〕
- 洒水器 craft 成功但 place 无空位 @ Farm 规划分区 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器没落地，继续手动浇水，体力无法全部用于下矿） 〔复盘〕
- donate 反复打开 Junimo note 无法存入，浪费 3 个动作 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
- 收尾阶段调 decorate 失败后才 sleep @ Farm — decorate -> FAIL: 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：浪费 1 个动作，22:00 后应直接 sleep） 〔复盘〕
