# 第4年 fall 17 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:31 开始）
- 天气：windy　金钱：45460g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：acf8f14c27c248a494b6959bb142b066
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：93bf2949e2e34908a62e87389ee012ef
  - 耗时：3.25 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_17）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升 Steel Hoe（当前差 3 铁锭）
- 起床先清背包：Farm 出货箱 ship_produce 卖 ≥3 组，验证空格 ≥8
- 做洒水器 ×4（材料已够，农业 2 级）并摆到菜地
- 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层），被拒即转 Forest 钓鱼
- 回农场 collect 收铁锭 1 次，炉空且有 Iron Ore 才 load 1 次
- 铁锭 ≥5 且时间 <15:30 去 Blacksmith 升 hoe
- 剩余时间 Forest 钓鱼补食物/现金，22:00 前 sleep
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
4. `craft`（item="Sprinkler", count=2）
5. `place`（item="Sprinkler"）
6. `goto_location`（location="Mine"）
7. `mine`（floors=5）
8. `mine`（floors=5）
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `fish`（casts=4）
17. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
18. `sleep`
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Trash, 1x Coal, 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：b74d59ad8b474afea1b006b1ae805cc1
  - 耗时：6.016 秒 / 游戏 10 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：a21fe9a6c1fb4c549b341398186475fa
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：240c7efc8d9547258cd6c495b808036a
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e1568fab611647dea46b5bfed7306ab7
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：5b4319ac7d8348f68e0f83e7ac33747c
  - 耗时：39.781 秒 / 游戏 40 分钟
- **06:50** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：0857f26391524d74a3a24833c77710d2
  - 耗时：39.734 秒 / 游戏 50 分钟
- **07:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：a23169b842a142cb95b9c4540206a92a
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine因空格不足被拒，先回农场存材料腾出≥5格再下矿，其余路线保留。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Farm"）
10. `store_items`（items=["Stone", "Cobblestone Path", "Frozen Geode", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Copper Hoe"]）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
14. `sleep`
- **07:40** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：0c6ab6304d4843459cc38c9597011c2d
  - 耗时：40.031 秒 / 游戏 50 分钟
- **08:30** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5d60157499c74ad8af5c0f03cdd6f17b
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅4空格导致mine被拒，先回农场存材料腾格再下矿，其余路线保留。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="hoe"）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `store_items`（items=["Stone", "Cobblestone Path", "Frozen Geode", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Copper Hoe"]）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
15. `sleep`
- **08:30** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：742b758424a64c748e56ff585ec72e88
  - 耗时：0.313 秒 / 游戏 0 分钟
- **08:30** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5743672f7242470aafc24fdb539b6b7a
  - 耗时：39.735 秒 / 游戏 50 分钟
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b3b446ed45b1472f9aab9d199e9f562d
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因空格不足被拒，先回农场 store_items 腾出 ≥5 空格再下矿，其余路线保留。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Farm"）
10. `store_items`（items=["Stone", "Cobblestone Path", "Frozen Geode", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Copper Hoe", "Green Algae"]）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
14. `sleep`
- **09:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：9aa2eab6761b4c8f96411474b94088a7
  - 耗时：40.047 秒 / 游戏 50 分钟
- **10:10** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：1151b79cc90d4576860aaba0c5539315
  - 耗时：0.36 秒 / 游戏 0 分钟
- **10:10** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ec75b63d427d46ec8a50ecbf69e73df2
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:10** CommunityCenter ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：b10621b51d7c46b2bd08f41c9bcf4d00
  - 耗时：35.813 秒 / 游戏 40 分钟
- **10:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：d51c86b2b8ed46008f9e66fda7e39682
  - 耗时：0.375 秒 / 游戏 0 分钟
- **10:50** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：69bafc51244f47f9865c67ef87dd890f
  - 耗时：26.578 秒 / 游戏 40 分钟
- **11:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (River Jelly, Green Algae, Green Algae, Tiger Trout)
  - 执行状态：SUCCESS · 操作编号：8e9ab7e668b84f7a9c146eeca7608d84
  - 耗时：59.625 秒 / 游戏 70 分钟
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **12:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Tiger Trout, Tiger Trout, Salmon)
  - 执行状态：SUCCESS · 操作编号：cf3588859e334d838e027d31f31268b7
  - 耗时：91.609 秒 / 游戏 80 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Tiger Trout
- **14:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：d8c149602bd3451e8e3743cd5b29e0e8
  - 耗时：15.219 秒 / 游戏 20 分钟
- **14:20** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path", "Frozen Geode", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Copper Hoe", "Green Algae"]）
  - 结果：stored in chest at (74,15): 38x Green Algae, 2x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：a752c6e065274b448ab6ac1fb95829c5
  - 耗时：23.906 秒 / 游戏 30 分钟
- **14:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：8e776791a543457cadc64f079f5f67e1
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e1abe487017c49a99e2ddc22b7357e10
  - 耗时：0.297 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
  - 结果：shipped 3 stacks worth ~862g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：bea0fd06135f410ab6ffd1d0a02bac70
  - 耗时：0.672 秒 / 游戏 0 分钟
- **14:50** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：4c96b1332942454eb3be7648f06d47b4
  - 耗时：40.11 秒 / 游戏 50 分钟
- **15:40** CommunityCenter ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c22deec7ead84f29b51a0e96ddaa9c7c
  - 耗时：46.735 秒 / 游戏 60 分钟
- **16:40** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:40 pm
  - 执行状态：SUCCESS · 操作编号：cd043b4dee2a4598a4b8d986b1676480
  - 耗时：86.031 秒 / 游戏 120 分钟
- **18:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：3f41f8a521754a3992e4b9a21f15b2b9
  - 耗时：12.64 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：45460 → 46322（+862g）
- 出货估值：862g　动作：32 个　失败：11 个
- 模型调用：5 次　tokens：62844
- 有效动作率：0.5333　空转：8　熔断跳过：0
- 失败耗时：50.671 秒 / 游戏 60 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清背包不彻底：只卖了3组杂项，背包仍满，导致5次mine全被拒，铁锭进度停滞。洒水器条件已满足却整天没craft。15:00后build_road/decorate/wait全失败浪费200分钟。有效做法是Forest钓鱼4轮和卖货862g。今天必须：起床先卖鱼+杂项到空格≥8并验证，然后craft洒水器×4，再下矿。

**新教训：**
- 昨天只卖 3 组杂项（862g）没卖鱼，背包仍满导致 5 次 mine 全被拒：清背包时 ship_produce 必须优先整组卖鱼（昨天钓的 Chub/Tiger Trout/Salmon），鱼是最大现金流也是最大占格来源。
- 洒水器条件已满足（农业 2 级、Copper Bar 35、Iron Bar 2）却连续两天没 craft：craft 洒水器必须排在清背包之后、下矿之前，作为当天第 2 个动作，不能等「有空再做」。
- 昨天 15:00 后 build_road/decorate/wait 三连失败浪费约 200 游戏分钟：15:00 后脚本只允许 fish 或 sleep 两个分支，其余动作在脚本生成阶段就删除。
- 昨天 mine 被拒 5 次、脚本重写 3 次仍调 mine：mine 第一次返回空格不足后，当天 mine 分支应从脚本中物理删除，不是靠重写脚本「再试一次」。
- 昨天 collect_machines 在 load 后 30 分钟内调用返回空：collect 应在下矿回来第一时间调（load 后已过 ≥2 小时游戏时间），当天只调一次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 18）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 45460g 充足，卡点是 **Iron Bar 差 3**（Iron Ore 6、Coal 12，两座熔炉 2 轮可出 4 锭）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线。

离完成还差：约 6 铁矿石 + 3 煤 → 3 铁锭 → 铁匠铺升锄头（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 18）**：起床清背包到空格 ≥8（卖鱼+杂项，验证通过）→ craft 洒水器 ×4 并放置 → 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）→ 回农场 collect 收铁锭 → 铁锭 ≥5 且时间 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 19）**：铁锭不够继续下矿；够了升 hoe，余锭给洒水器。
- **后天（秋 20）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包（今天最关键）**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**优先整组卖鱼**（昨天钓的 Chub/Tiger Trout/Salmon 等非献祭鱼）+ 非献祭杂项。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖 Green Algae/Sap/Refined Quartz/多余 Copper Bar 小堆，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **做洒水器（今天第 2 优先级，昨天漏做）**：材料够（1 铜锭 + 1 铁锭/个，现有 Copper Bar 35、Iron Bar 2）且农业 2 级 → `craft` 洒水器 ×4（≤4 次 craft）。做完 `place` 到作物地块（≤6 次 place）。若 craft 失败一次即跳过，不重试。
3. **下矿（主活动）**：空格 ≥8 且食物 ≥5 才 `goto_location` Mine → `mine` 目标 60-79 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
4. **回农场收炉**：`collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。炉空且背包有 Iron Ore 才 `load_machines` 1 次；返回 busy/no empty 即当天永久跳过 load。
5. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。一次只升一件。
6. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（优先鱼），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天 ≤1 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤1 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
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
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组（优先鱼）+ 读背包验证空格 ≥8
2. 做洒水器 ×4（材料已够，条件已满足，昨天漏做，今天必须做）
3. 下矿 60-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
4. 回农场 collect 收铁锭（≤1 次），炉空且背包有 Iron Ore 才 load（≤1 次）
5. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe
6. 补食物到 ≥5（Forest 河边钓鱼吃鱼）
7. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是清背包不彻底：只卖了3组杂项，背包仍满，导致5次mine全被拒，铁锭进度停滞。洒水器条件已满足却整天没craft。15:00后build_road/decorate/wait全失败浪费200分钟。有效做法是Forest钓鱼4轮和卖货862g。今天必须：起床先卖鱼+杂项到空格≥8并验证，然后craft洒水器×4，再下矿。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 07:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:30 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests) 〔自动〕
- 14:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:40 动作 `build_road` 失败 @ CommunityCenter — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包不彻底，5 次 mine 全部因空格不足被拒 @ Farm 出货箱旁 / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（连续 5 次）（做不了：当天零矿产出，铁锭仍差 3，钢锄头升级和洒水器材料都卡住） 〔复盘〕
- 洒水器条件已满足却整天没 craft @ Farm — 脚本里没有 craft 洒水器分支，优先级被下矿挤掉；里程碑显示「条件都满足，今天就做」（做不了：继续手动浇水浪费体力，洒水器 ×4 进度为零（连续两天）） 〔复盘〕
- mine 被拒后脚本重写 3 次仍调 mine @ Mine 入口 — 脚本重写 3 次，每次仍包含 mine 动作，浪费约 200 游戏分钟（做不了：本可用于钓鱼补食物/现金的时间全部浪费） 〔复盘〕
- 15:00 后连续调 build_road/decorate/wait 三个动作全失败 @ Farm / Town — build_road -> laid 0 tiles (24 skipped: blocked by trees/crops/objects); decorate -> 缺树种子/木头/花种; wait -> 空转 120 分钟（做不了：收尾时间本可用于钓鱼，全部浪费） 〔复盘〕
- 熔炉刚 load 完 30 分钟内调 collect 返回空，之后又调 load 返回 busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: no empty machine accepts that（做不了：铁锭收集延后，当天只收到 2 铁锭，仍差 3） 〔复盘〕
- donate 打开 Junimo note 无法存入，仍反复调用 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
