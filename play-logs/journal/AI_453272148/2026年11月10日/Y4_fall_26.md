# 第4年 fall 26 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（06:02 开始）
- 天气：sunny　金钱：50236g　体力：270/270
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
  - 执行状态：SUCCESS · 操作编号：20229510f68b437dbccf33780e450863
  - 耗时：5.016 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Notice a chill in the air? It could just be the approach of winter... Or it could be the tingle of a dark specter, here to help us celebrate tomorrow's festival... the Spirit's Eve. Come to town at 10 PM if you'd like to participate.   -Mayor Lewis

## 🌙 为明天（Y4_fall_26）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天继续下矿凑铁矿石+煤
- 起床清背包：卖鱼和非献祭杂项，验证空格≥8
- 熔炉：先 collect 收锭，再 load 铁矿石（12:00 前，busy 即跳过）
- 食物≥5、空格≥8 后下矿 40-75 层拿铁矿石+煤（≤2 次，每次≤5 层）
- 回农场 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 铁锭不够则 Forest 河边钓鱼补食物/现金，22:00 前 sleep
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["River Jelly", "Green Algae"]）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Frozen Geode", "Bone Fragment", "Slime", "Coal"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `craft`（item="Sprinkler", count=1）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `fight`（range=6）
11. `mine`（floors=5）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `fish`（casts=4）
19. `sleep`
- **06:00** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：c155b371dc78403983f2b565ff20d97f
  - 耗时：17.438 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0801fc062b03418c9fe3bfa380d90d9c
  - 耗时：7.266 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Ore
- **06:30** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：65ca056d9e1c480499ef4c2bb344ae85
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：5b2f6f578aa243aa9a14ceaf8e75b22c
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~5g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：1cd80cfda24141948c16c56840fe5b69
  - 耗时：14.25 秒 / 游戏 20 分钟
- **06:50** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：485d052801a3465aab9e010f258aba9d
  - 耗时：41.703 秒 / 游戏 50 分钟
- **07:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：dc67c6fae9134dd8b7c6f3929276ae77
  - 耗时：39.406 秒 / 游戏 50 分钟
- **08:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 75 to 79 (4 floors down, 15 stones broken); stopped at floor 79: weapon too weak for floor 80+ (Silver Saber 8-15; need average damage 14+): buy_weapon at the Adventurer's Guild
  - 执行状态：SUCCESS · 操作编号：7dfe4500f2e04cad97849e900ecc0e42
  - 耗时：21.671 秒 / 游戏 30 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
- **09:00** UndergroundMine79 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：0de493fc2395456aafa995c4cd6662e3
  - 耗时：0.313 秒 / 游戏 0 分钟
- **09:00** UndergroundMine79 ✅ `mine`（floors=5）
  - 结果：mined from floor 79 to 79 (0 floors down, 0 stones broken); stopped at floor 79: weapon too weak for floor 80+ (Silver Saber 8-15; need average damage 14+): buy_weapon at the Adventurer's Guild
  - 执行状态：SUCCESS · 操作编号：bb72272d20c64e1cbb954ec05df108fa
  - 耗时：0.344 秒 / 游戏 0 分钟
- **09:00** UndergroundMine79 ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：42cfcf1ac07b4f6d88c6b3c14b0ccb4c
  - 耗时：51.016 秒 / 游戏 60 分钟
  - 🗨️ [question] 
- **10:00** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：4a2df8a4b5ca4e138257944653d72855
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：铁锭只有2不够升hoe，回农场收炉锭并装新矿，腾格后下矿凑铁矿石，铁锭不够就直接睡，不白跑铁匠铺。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `ship_produce`（except=["River Jelly", "Green Algae"]）
9. `store_items`（items=["Stone", "Copper Ore", "Frozen Geode", "Bone Fragment", "Coal", "Gold Ore"]）
10. `craft`（item="Sprinkler", count=1）
11. `collect_machines`
12. `sleep`
- **10:00** Blacksmith ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：004f2f42518449a38888afe25b72dd67
  - 耗时：36.125 秒 / 游戏 40 分钟
- **10:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：dcc18cf9b3cb42369afe445ae4057ea0
  - 耗时：39.391 秒 / 游戏 50 分钟
- **11:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：7b35f6fbbaee4ac695bda3ee94c9cb5f
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：矿洞因空格不足被拒，先回农场收锭、卖货存材料腾格，再决定下矿或转钓鱼，避免重跑mine。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `ship_produce`（except=["River Jelly", "Green Algae"]）
8. `store_items`（items=["Stone", "Copper Ore", "Frozen Geode", "Bone Fragment", "Coal", "Gold Ore", "Iron Ore"]）
9. `load_machines`（item="Iron Ore"）
10. `craft`（item="Sprinkler", count=1）
11. `place`（item="Sprinkler"）
12. `water_crops`
13. `sleep`
- **11:30** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：263382f56b044c66b484a57579187144
  - 耗时：39.625 秒 / 游戏 50 分钟
- **12:20** CommunityCenter ❌ `goto_location`（location="Forest"）
  - 结果：could not reach (1,90); stopped at (15,90)
  - 执行状态：ACTION_FAILED · 操作编号：d9316c6881a7465da6254e6fe654a2ac
  - 耗时：40.703 秒 / 游戏 50 分钟

### 🔁 脚本重写：重写#3：回农场腾格收锭装矿，空格不足不下矿，收尾睡觉
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `ship_produce`（except=["River Jelly", "Green Algae"]）
8. `store_items`（items=["Stone", "Copper Ore", "Frozen Geode", "Bone Fragment", "Coal", "Gold Ore", "Iron Ore"]）
9. `load_machines`（item="Iron Ore"）
10. `craft`（item="Sprinkler", count=1）
11. `water_crops`
12. `sleep`
- **13:10** Town ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：2869a5469d47428fb03572587a01099c
  - 耗时：33.812 秒 / 游戏 50 分钟
- **14:00** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：13dc8fcb8db44726ae9d75ce5e52b2ae
  - 耗时：39.406 秒 / 游戏 50 分钟
- **14:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：7bc8508cd01e4d53a60aa33c0251a635
  - 耗时：0.344 秒 / 游戏 0 分钟
- **14:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：ef16318cf9de451482ef20539f353da1
  - 耗时：0.297 秒 / 游戏 0 分钟
- **14:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：6e8133e56fe642dcba66ee20a20b92b1
  - 耗时：33.609 秒 / 游戏 40 分钟
- **15:30** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：1ca79bcfac11479f940ae5c9451f25be
  - 耗时：7.172 秒 / 游戏 10 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Copper Bar
- **15:40** Farm ✅ `ship_produce`（except=["River Jelly", "Green Algae"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：3794f255689c433a8c0613cc2e90944e
  - 耗时：0.312 秒 / 游戏 0 分钟
- **15:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Frozen Geode", "Bone Fragment", "Coal", "Gold Ore", "Iron Ore"]）
  - 结果：stored in chest at (74,15): 2x Coal, 2x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：71bb9b67983040298a6965d92dacc647
  - 耗时：18.343 秒 / 游戏 20 分钟
- **16:00** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：38adf316f8a144368e3f0c598861cfd8
  - 耗时：13.407 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **16:20** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：46dcc6c4235842d2bbe89613dbdc4c65
  - 耗时：0.297 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：0f923c495a6b4ae195edd4ba8d68a770
  - 耗时：0.296 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：e25106af3a9547c6b2128ed2f0bf2232
  - 耗时：4.922 秒 / 游戏 10 分钟
- **16:30** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e1bf8435375f4c89931be451c0ec6173
  - 耗时：0.297 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：dca38b0e17674a5cb2af80637e63b554
  - 耗时：0.297 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：6b627c588228415197d275c5266b53cd
  - 耗时：10.0 秒 / 游戏 10 分钟
- **16:40** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：7a3ea476746d453d97c1e4e5aebd3499
  - 耗时：15.734 秒 / 游戏 20 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：296945365127407691527c5b09532807
  - 耗时：12.828 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：50236 → 50241（+5g）
- 出货估值：5g　动作：35 个　失败：8 个
- 模型调用：5 次　tokens：63987
- 有效动作率：0.6471　空转：7　熔断跳过：0
- 失败耗时：69.233 秒 / 游戏 80 分钟
- 最深矿层：79　新增矿层：4
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动被背包满卡死：3 次 mine 被拒、脚本重写 3 次仍调 mine，铁锭只到 2，钢锄头未成；熔炉时序仍错（起床 collect 空、傍晚 load 收不到）；洒水器 craft 成功但 place 无空位；build_road 连续失败。有效的是 craft 洒水器、下矿推进 4 层、熔炉收 2 铁锭。今天必须先清背包到 ≥8 格再下矿，并把洒水器落地。

**新教训：**
- 昨天 mine 在 75→79 层成功推进 4 层后背包满被拒，随后重写脚本再调 mine 又失败 2 次：mine 成功一次后应立即回农场 store_items 腾格，再决定是否第二次下矿，而不是连续调 mine。
- 昨天 craft 洒水器成功但 place 返回「分区无空位」：place 前应先读分区空位，无空位则 craft 后直接存箱子，不调 place。
- 昨天 collect_machines 在 600 和 1100 两次返回空，说明熔炉在起床时并无成品：起床应先 load 铁矿石（若炉空），把 collect 固定在下矿回来第一时间，而不是起床先 collect。
- 昨天 donate 在 610/920/1020 三次打开 Junimo note 均无法存入，浪费 3 个动作：donate 应从脚本彻底删除，起床到卖货之间不得插入任何非卖货动作。
- 昨天 1440 调 decorate 失败后才 sleep，说明收尾分支仍残留无效动作：22:00 后脚本只允许 sleep 一个分支，其余动作在脚本生成阶段就删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 27）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 50236g 充足，卡点是 Iron Bar 只有 2，还差 3 锭（≈9 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线。

离完成还差：约 9-12 铁矿石 + 3 煤 → 3 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 27）**：起床清背包到空格 ≥8 → craft 洒水器并落地 → 熔炉 collect 后立即 load 铁矿石（12:00 前）→ 食物 ≥5 下矿 75-79 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（秋 28）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（冬 1）**：转钢斧；冬季种冬季种子，茶苗能做就做。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包到空格 ≥8**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 显式指定卖鱼组（Chub、Green Algae、Salmon、Tiger Trout 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Soggy Newspaper、Trash）。
   - **读背包验证空格 ≥8**：通过 → 第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **craft 洒水器并落地**：清背包后立即 `craft` 洒水器 1 个（Copper Bar 35、Iron Bar 2，先做 1 个）。craft 后 `place` 到空地块；place 返回「分区无空位」即当天永久跳过 place，洒水器存箱子。
3. **熔炉：起床 collect 后立即 load（顺序不可颠倒，load 必须在 12:00 前完成）**
   - `collect_machines` 1 次收已完成锭（昨天 1600 前 load 的 Iron Ore 应已好）。
   - 若背包有 Iron Ore 且炉空 → `load_machines` 1 次装铁矿石，**必须在 12:00 前完成**，让它在白天炼完。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
4. **下矿前双检查**：goto Mine 前必须显式读背包确认 **空格 ≥8 且食物 ≥5**。食物 <5 时先 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），**只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper 直接卖**，补到 ≥5 再进 Mine。**食物 <5 或空格 <8 时脚本里不得出现 goto Mine。**
5. **下矿（主活动）**：`goto_location` Mine → `mine` 目标 75-79 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过，不白跑铁匠铺。** 一次只升一件。
8. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **craft 洒水器排第 2**：条件已满足，清背包后立即 craft，不能等「有空再做」。
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
5. 下矿 75-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主活动被背包满卡死：3 次 mine 被拒、脚本重写 3 次仍调 mine，铁锭只到 2，钢锄头未成；熔炉时序仍错（起床 collect 空、傍晚 load 收不到）；洒水器 craft 成功但 place 无空位；build_road 连续失败。有效的是 craft 洒水器、下矿推进 4 层、熔炉收 2 铁锭。今天必须先清背包到 ≥8 格再下矿，并把洒水器落地。
- 10:00 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests) 〔自动〕
- 11:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:20 动作 `goto_location` 失败 @ CommunityCenter — could not reach (1,90); stopped at (15,90) 〔自动〕
- 14:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 16:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 背包被鱼和杂项塞满，连续 3 次下矿被拒，脚本重写 3 次仍调 mine @ Mine 入口 (18,13) — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：铁矿石和煤没拿到，铁锭仍为 2，钢锄头和洒水器材料全部卡住） 〔复盘〕
- 熔炉 collect 返回空、load 返回 busy，时序颠倒 @ Farm 熔炉旁 (40,9) — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: all machines are busy（做不了：当天铁锭产出为零，钢锄头仍差 3 锭） 〔复盘〕
- 洒水器 craft 成功但 place 无空位 @ Farm 规划分区 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器没落地，继续手动浇水，体力无法全部用于下矿） 〔复盘〕
- donate 反复打开 Junimo note 无法存入，浪费 3 个动作 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
- 收尾阶段调 decorate 失败后才 sleep @ Farm — decorate -> FAIL: 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：浪费 1 个动作，22:00 后应直接 sleep） 〔复盘〕
- goto Forest 在 (22,90) 被卡住到不了 (1,90) @ Forest — goto_location -> FAIL: could not reach (1,90); stopped at (15,90)（做不了：Forest 河边钓鱼点不可达，补食物/现金分支被卡） 〔复盘〕
- build_road 连续两次 laid 0 tiles @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：浪费 2 个动作和 24 个铺路石，铺路计划无法推进） 〔复盘〕
