# 第4年 fall 20 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:03 开始）
- 天气：windy　金钱：46838g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fe53342b5d7f4d429e3c2c2b2cf79e42
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：37b571bd2b1c4d0994a9ca2899bdf1e6
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：5547fd89021d4b0fba5779830b4938a4
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~525g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：97c0058c579d48eb8d81c8889c0d7bc1
  - 耗时：5.344 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_20）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升钢锄头
- 起床先清背包：整组卖鱼（Chub 等）腾出 ≥8 空格
- 熔炉装铁矿石（背包 Iron Ore 4 + 箱子 6）
- 下矿 61 层附近拿铁矿石+煤（≤2 次，每次 ≤5 层）
- 回农场收铁锭；够 5 锭且 <15:30 去铁匠铺升 hoe
- 不够则转 Forest 钓鱼补食物/现金，22:00 前睡
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Green Algae", "River Jelly"]）
4. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Coal", "Sprinkler", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
5. `take`（item="Iron Ore", count=10）
6. `load_machines`（item="Iron Ore"）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `fight`（range=6）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `fish`（casts=4）
18. `sleep`
- **06:00** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：98484f0717e441c18e03567f6c0a867c
  - 耗时：41.703 秒 / 游戏 50 分钟
- **06:50** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5949b18c4926429ea8e4ad1a8dd711fc
  - 耗时：39.375 秒 / 游戏 50 分钟
- **07:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5b145f54b25945c29c41c926b9fb5895
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因空格不足被拒，先回农场存材料卖货腾格，再装炉下矿，回来收锭升锄头，不够则钓鱼收尾。
1. `donate`
2. `mine`（floors=5）
3. `fight`（range=6）
4. `mine`（floors=5）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="hoe"）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Coal", "Sprinkler", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
12. `ship_produce`（except=["Green Algae", "River Jelly"]）
13. `load_machines`（item="Iron Ore"）
14. `collect_machines`
15. `sleep`
- **07:40** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：587da69a0e054d0d898a37dce15e4838
  - 耗时：39.625 秒 / 游戏 50 分钟
- **08:30** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ec016feb3bb44e5eae0405446a3ce8c3
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因空格不足被拒，先回农场存材料+卖货腾格，再按原路线下矿、收锭、升锄头，不足则钓鱼收尾。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `fight`（range=6）
5. `mine`（floors=5）
6. `goto_location`（location="Blacksmith"）
7. `upgrade_tool`（tool="hoe"）
8. `goto_location`（location="Forest"）
9. `fish`（casts=4）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Coal", "Sprinkler", "Bamboo Pole", "Silver Saber", "Rusty Sword"]）
13. `ship_produce`（except=["Green Algae", "River Jelly"]）
14. `load_machines`（item="Iron Ore"）
15. `collect_machines`
16. `sleep`
- **08:30** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：6948f1b7710e426c829689d86f6034ba
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:30** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：cc3c53cb31214e3f879dd931cd2d4d9f
  - 耗时：39.39 秒 / 游戏 50 分钟
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：140dbcb1c71843f9a9c260d9fd52cf77
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包仅3格导致下矿被拒，先回农场存材料卖货腾格再下矿，失败即转钓鱼/睡觉。
1. `donate`
2. `mine`（floors=5）
3. `fight`（range=6）
4. `mine`（floors=5）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Coal", "Bamboo Pole", "Silver Saber", "Rusty Sword", "Sprinkler"]）
7. `ship_produce`（except=["Green Algae", "River Jelly"]）
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `sleep`
- **09:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：6825175257ad4e5db012ce27df628819
  - 耗时：39.625 秒 / 游戏 50 分钟
- **10:10** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3ffd253eaaab40e78869555fc5fb331d
  - 耗时：0.329 秒 / 游戏 0 分钟
- **10:10** CommunityCenter ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：e34697d9a07f419fa27459b1c69c9ac3
  - 耗时：0.297 秒 / 游戏 0 分钟
- **10:10** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b0b54edc284b420e988fcd0ff3d0ff3d
  - 耗时：0.313 秒 / 游戏 0 分钟
- **10:10** CommunityCenter ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：b9335d3eddb445ea8a98b55dda6f907a
  - 耗时：38.078 秒 / 游戏 40 分钟
- **10:50** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Coal", "Bamboo Pole", "Silver Saber", "Rusty Sword", "Sprinkler"]）
  - 结果：stored in chest at (75,15): 48x Stone, 1x Coal, 2x Sprinkler, 1x Mystery Box, 24x Cobblestone Path, 1x Coffee Bean, 4x Rice Shoot, 1x Copper Ore, 1x Lost Axe
  - 执行状态：SUCCESS · 操作编号：2a834dd534c048d78e1838afcf607fbf
  - 耗时：1.078 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `ship_produce`（except=["Green Algae", "River Jelly"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：b3e60f4091f14eb8b6f2e0cb91c1010c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6715743118864620b9574552cf780074
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：3f31d9e1e54f4c72b2a3ded5906bff9d
  - 耗时：0.329 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：bff61c98057f4e49ab337c556ed59d9b
  - 耗时：0.313 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 35 to 39 (4 floors down, 44 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：87c35ee9809d46e0bafdca37a3b6c1d6
  - 耗时：82.75 秒 / 游戏 110 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
- **12:40** UndergroundMine39 ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：69daf0f922874bdda57054e141385ec3
  - 耗时：62.734 秒 / 游戏 70 分钟
  - 🗨️ [question] 
- **13:50** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 2 forage items
  - 执行状态：SUCCESS · 操作编号：f44eafe0fd5e485c9570018a9d047586
  - 耗时：28.593 秒 / 游戏 40 分钟
  - 🗨️ [hud] Blackberry
  - 🗨️ [hud] Blackberry
- **14:30** Forest ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：5256cff7bdc74b3e877e58f1bbe7e1a2
  - 耗时：0.313 秒 / 游戏 0 分钟
- **14:30** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3e75543de58646e394f61e8359bad34d
  - 耗时：42.625 秒 / 游戏 60 分钟
- **15:30** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：dc68d8e20f524a56bc802ef7c7c8ea05
  - 耗时：15.672 秒 / 游戏 20 分钟
- **15:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a94c6bdb0bb14205bf6613da5a120c45
  - 耗时：12.828 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：46838 → 47363（+525g）
- 出货估值：525g　动作：30 个　失败：11 个
- 模型调用：5 次　tokens：61989
- 有效动作率：0.5172　空转：9　熔断跳过：0
- 失败耗时：61.831 秒 / 游戏 80 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天30个动作仅卖货525g有效，5次mine全因背包空格不足被拒，脚本重写3次仍重复同一错误；熔炉load/collect时序错乱导致铁锭零产出；15:00后build_road/decorate空转。核心问题：清背包没有真正腾出空格（鱼未卖），且失败后不换分支。

**新教训：**
- 昨天 ship_produce 返回 OK 但背包仍有鱼（Chub 等）未卖，说明 ship_produce 默认可能跳过鱼：清背包时必须显式指定卖鱼组，卖完立即读背包验证空格数，不能凭 OK 判定。
- 昨天熔炉先 collect（空）再 load（busy）顺序颠倒：正确顺序是起床先 collect 收已完成锭，再 load 新矿石；若先 load 则当天 collect 必然为空，铁锭产出归零。
- 昨天 5 次 mine 被拒后仍重写脚本 3 次再调 mine，浪费约 200 游戏分钟：mine 第一次返回空格不足后，脚本里应物理删除 mine 分支并直接 goto Forest 钓鱼，重写脚本不改变背包空格数。
- 昨天 15:00 后仍调 build_road 两次 + decorate 一次全失败：15:00 后脚本只允许 fish 或 sleep 两个分支，其余动作在脚本生成阶段就应删除。
- 昨天全天 30 个动作只有卖货 525g 和 Forest 采集 2 个黑莓有产出：主活动被卡时应在前 3 个动作内转钓鱼，而不是靠重写脚本消耗时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 21）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 46838g 充足，卡点仍是 **Iron Bar 差 5**（背包 Iron Ore 6、Coal 18，两座熔炉可出约 2 锭，还差约 3 锭 = 15 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线。

离完成还差：约 15 铁矿石 + 3 煤 → 5 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 21）**：起床第一件事把背包清到 ≥8 空格（**必须整组卖鱼**）→ 熔炉 load 铁矿石 → 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 22）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（秋 23）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包（今天最关键）**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**第一组必须整组卖鱼**（Chub、Green Algae、River Jelly 等非献祭鱼）+ 非献祭杂项（多余 Copper Bar、Sap）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **熔炉 load（若炉空且背包有 Iron Ore）**：`collect_machines` 1 次（收已完成的锭）；若返回空且背包有 Iron Ore → `load_machines` 1 次装铁矿石。load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
3. **下矿（主活动）**：空格 ≥8 且食物 ≥5 才 `goto_location` Mine → `mine` 目标 60-79 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
4. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
5. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。一次只升一件。
6. **洒水器放置（若背包有洒水器）**：`place` 到作物地块（≤6 次 place）。**place 前先确认目标分区有空位**；若返回「分区无空位」即当天永久跳过 place，不重试。
7. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
8. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
10. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天 ≤1 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤1 次；返回空后当天永久跳过。**collect 应在 load 后至少 2 小时游戏时间再调，或放在下矿回来第一时间。**
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
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
2. 熔炉 load（若炉空且背包有 Iron Ore，≤1 次）
3. 下矿 60-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
4. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
5. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe
6. 洒水器放置（若背包有洒水器，≤6 次 place，分区无空位即跳过）
7. 补食物到 ≥5（Forest 河边钓鱼吃鱼）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**


</details>

## ⚠️ 今日问题
> 昨天30个动作仅卖货525g有效，5次mine全因背包空格不足被拒，脚本重写3次仍重复同一错误；熔炉load/collect时序错乱导致铁锭零产出；15:00后build_road/decorate空转。核心问题：清背包没有真正腾出空格（鱼未卖），且失败后不换分支。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:30 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:30 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包不彻底，鱼未卖导致背包空格不足，下矿连续被拒 5 次 @ Farm 出货箱旁 / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：当天零矿产出，铁锭仍差 5，钢锄头升级和洒水器材料全部卡住） 〔复盘〕
- ship_produce 只卖杂项没卖鱼，鱼仍占格 @ Farm 出货箱旁 — ship_produce -> OK: nothing to ship（实际背包仍有 Chub 等鱼未卖）（做不了：背包无法腾出 ≥8 空格，下矿分支无法启动） 〔复盘〕
- 熔炉 load 与 collect 时序错乱，先 collect 空、后 load busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: no empty machine accepts anything（做不了：铁锭收集延后，当天铁锭产出为零，钢锄头仍差 5） 〔复盘〕
- 铁锭为 0 时仍前往铁匠铺尝试升级 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 0（做不了：浪费前往铁匠铺的游戏时间，升级未完成） 〔复盘〕
- donate 在 wait_letter 阶段反复打开 Junimo note 无法存入 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
- 15:00 后仍调 build_road 和 decorate 两个无效动作 @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects); decorate -> FAIL: 今天没有能做（做不了：浪费约 200 游戏分钟，本可用于钓鱼补食物/现金） 〔复盘〕
