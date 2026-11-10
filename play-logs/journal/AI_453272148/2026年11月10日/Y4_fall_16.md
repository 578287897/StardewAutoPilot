# 第4年 fall 16 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:18 开始）
- 天气：sunny　金钱：44974g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y4_fall_16）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升钢锄头（5000g+5 Iron Bar）
- 起床先清背包：出货箱卖 ≥3 组，验证空格 ≥8
- 秋16 秋季集市：9:00 后去 Town 参加 grange display 拿星之果实
- 集市后下矿 60-79 层拿铁矿石+煤（≤2 次 mine，超时即转钓鱼）
- 回农场 collect 收铁锭；铁锭 ≥5 且 <15:30 去 Blacksmith 升 hoe
- 剩余时间 Forest 钓鱼补食物/现金，22:00 前 sleep
1. `goto_location`（location="Farm"）
2. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode"]）
3. `store_items`（items=["Stone", "Fiber", "Cobblestone Path"]）
4. `goto_location`（location="Town"）
5. `festival`（activity="grange"）
6. `goto_location`（location="Farm"）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `fish`（casts=4）
20. `goto_location`（location="Farm"）
21. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode"]）
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：74404b80e83f4a129135bd7fd39a8d3f
  - 耗时：20.047 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Iron Bar
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：424cdb65220242c3920b6eda92b3ba93
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：7e15a1a34ce648829b5633ede7b7f825
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e20b1187d7d249268f3dfbe22f6b30d9
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Iron Bar | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：701020d54dd8432381519d2178eeadf2
  - 耗时：29.954 秒 / 游戏 40 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：Town 因集市布置锁门，放弃集市改下矿拿铁矿石推进钢锄头里程碑，回农场炼锭后钓鱼收尾。
1. `goto_location`（location="Town"）
2. `festival`（activity="grange"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
14. `sleep`
- **07:00** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：2e81fb91e5274204b526d881600d66ab
  - 耗时：5.437 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#2：Town 因集市布置锁门，跳过集市直接下矿拿铁矿石，回农场炼锭后钓鱼补现金流再睡。
1. `goto_location`（location="Town"）
2. `festival`（activity="grange"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
14. `sleep`
- **07:00** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：f8986789fe1f4dde9db8ae0c4a8d7efd
  - 耗时：5.469 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#3：Town 因集市布置锁住无法进入，改走原脚本的下矿→炼铁→钓鱼路线，不再重试 Town。
1. `goto_location`（location="Town"）
2. `festival`（activity="grange"）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `fight`（range=6）
6. `mine`（floors=5）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
14. `sleep`
- **07:10** BusStop ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：0c5e0cac50f34248b1ca8fe62d9251a4
  - 耗时：5.219 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **07:20** BusStop ❌ `festival`（activity="grange"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：7ea4115cd8fa42fc88c057c4ba1d64f3
  - 耗时：0.328 秒 / 游戏 0 分钟
- **07:20** BusStop ❌ `goto_location`（location="Mine"）
  - 结果：no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：a2b86aebbf9643d49827906633c088af
  - 耗时：70.813 秒 / 游戏 80 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **08:40** Forest ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：68d85ba6bad94e9dad57ec8b590546a9
  - 耗时：0.297 秒 / 游戏 0 分钟
- **08:40** Forest ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：ab977619c08e4b1fac94ad9c84ea4c8f
  - 耗时：0.297 秒 / 游戏 0 分钟
- **08:40** Forest ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：1797ee64dc09451aa0750119c30a04c5
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:40** Forest ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,24)
  - 执行状态：SUCCESS · 操作编号：f58449c8cc6b4571835503640928fbd0
  - 耗时：0.297 秒 / 游戏 0 分钟
- **08:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Trash, Green Algae, Chub, Salmon)
  - 执行状态：SUCCESS · 操作编号：d05838e4801340d59d3fbe2c204d777d
  - 耗时：73.282 秒 / 游戏 80 分钟
  - 🗨️ [hud] The Stardew Valley 
Fair has begun in the 
town square. 
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
- **10:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Salmon, Salmon, Tiger Trout)
  - 执行状态：SUCCESS · 操作编号：0abdbe2d010f4919b5a4126c1f63769e
  - 耗时：123.813 秒 / 游戏 130 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Salmon
  - 🗨️ [hud] Salmon
- **12:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：18faf474a091458f875d6ec801a045c0
  - 耗时：15.657 秒 / 游戏 10 分钟
- **12:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：332d7c76228d4837ac6e9e0bba11f0ea
  - 耗时：0.313 秒 / 游戏 0 分钟
- **12:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c8358dd42fa94feb8af1d3c7e3921722
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:20** Farm ✅ `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar"]）
  - 结果：shipped 2 stacks worth ~486g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：26cf4c4f0ebf45b2877f3b289a190512
  - 耗时：20.469 秒 / 游戏 30 分钟
- **12:50** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：748eea6e775d42fb87eddfe0b9fe0478
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `goto_location`（location="Town", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Town (81,0)
  - 执行状态：SUCCESS · 操作编号：fb7f5005b9794cd6832b053a3fe8b515
  - 耗时：264.859 秒 / 游戏 170 分钟
- **15:40** Town ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：f33c99e2977a4ecfacc2c104a8020659
  - 耗时：46.203 秒 / 游戏 60 分钟
- **16:40** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:40 pm
  - 执行状态：SUCCESS · 操作编号：54fe04fa758e4c61b710f4fddd0bfc7c
  - 耗时：84.937 秒 / 游戏 120 分钟
- **18:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a69baf5c009c4351a520d743c8399761
  - 耗时：12.641 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：44974 → 45460（+486g）
- 出货估值：486g　动作：26 个　失败：13 个
- 模型调用：6 次　tokens：62567
- 有效动作率：0.3333　空转：8　熔断跳过：0
- 失败耗时：166.015 秒 / 游戏 200 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天最大浪费是节日锁门后仍反复 goto Town（4次）并重写脚本3次，实际有效产出只有钓鱼8条+卖货486g。铁锭仍差3，洒水器条件已满足却未做。今天应：起床先清背包卖鱼腾格，直接做洒水器×4（材料已够），再下矿60-79拿铁矿石+煤，回炉炼铁，铁锭够5就升锄头。节日已过，不再考虑集市。

**新教训：**
- 节日锁门后 goto Town 连续失败 4 次（脚本重写 3 次仍重试）：节日当天 goto 同一地点失败一次即永久跳过，脚本层直接禁用该地点，不重写脚本重试。
- 洒水器条件已满足（农业 2 级、铜锭 35、铁锭 2）却整天没做：里程碑显示「条件都满足」时，craft 洒水器应排在起床清背包之后、下矿之前，作为当天第 2 优先级。
- mine 因空格不足被拒后，脚本重写 3 次仍调 mine，浪费约 200 游戏分钟：重写前必须先读背包空格数，<8 时脚本里不得出现 mine 动作，直接转 Forest 钓鱼。
- 昨天 4 次 goto Town 失败后仍调 festival(grange)，返回「not at a festival right now」：goto 节日地图失败后，festival 动作应一并跳过，不要单独重试。
- 昨天 15:00 后仍调 build_road/decorate/wait 三个动作全失败：15:00 后只保留钓鱼或 sleep 两个合法动作，补充工作分支应从脚本中彻底删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 17）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 44974g 充足，卡点是 **Iron Bar 差 3**（Iron Ore 6、Coal 12，两座熔炉 2 轮可出 4 锭）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线。

离完成还差：约 6 铁矿石 + 3 煤 → 3 铁锭 → 铁匠铺升锄头（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 17）**：起床清背包卖鱼 → 做洒水器×4（材料已够，条件已满足，优先做）→ 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次目标 ≤5 层）→ 回农场 collect 收铁锭 → 铁锭 ≥5 且时间 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 18）**：铁锭不够继续下矿；够了升 hoe，余锭给洒水器。
- **后天（秋 19）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组（鱼整组 + 非献祭杂项；Copper Bar 若背包有则整组卖）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖 Refined Quartz/Sap 小堆，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 Stone 整组**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **做洒水器（今天优先）**：材料够（1 铜锭 + 1 铁锭/个）且农业 2 级 → `craft` 洒水器 ×4（≤4 次 craft）。做完 `place` 到作物地块（≤6 次 place）。若 craft 失败一次即跳过，不重试。
3. **下矿（主活动）**：空格 ≥8 且食物 ≥5 才 `goto_location` Mine → `mine` 目标 60-79 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
4. **回农场收炉**：`collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。炉空且背包有 Iron Ore 才 `load_machines` 1 次；返回 busy/no empty 即当天永久跳过 load。
5. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。一次只升一件。
6. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组，卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
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
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组 + 读背包验证空格 ≥8
2. 做洒水器 ×4（材料已够，条件已满足）
3. 下矿 60-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
4. 回农场 collect 收铁锭（≤1 次），炉空且背包有 Iron Ore 才 load（≤1 次）
5. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe
6. 补食物到 ≥5（Forest 河边钓鱼吃鱼）
7. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是节日锁门后仍反复 goto Town（4次）并重写脚本3次，实际有效产出只有钓鱼8条+卖货486g。铁锭仍差3，洒水器条件已满足却未做。今天应：起床先清背包卖鱼腾格，直接做洒水器×4（材料已够），再下矿60-79拿铁矿石+煤，回炉炼铁，铁锭够5就升锄头。节日已过，不再考虑集市。
- 06:20 动作 `goto_location` 失败 @ Farm — exit to Town did not open (closed? locked? check opening hours). Recent messages: Iron Bar | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 07:00 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:00 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:10 动作 `goto_location` 失败 @ BusStop — exit to Town did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. C 〔自动〕
- 07:20 动作 `festival` 失败 @ BusStop — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 07:20 动作 `goto_location` 失败 @ BusStop — no reachable route from Forest to Mine (unreachable exits: busstop->town, backwoods->mountain, backwoods->farm, forest->town) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set u 〔自动〕
- 08:40 动作 `mine` 失败 @ Forest — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:40 动作 `mine` 失败 @ Forest — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:40 动作 `build_road` 失败 @ Town — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 节日锁门后反复尝试进入 Town，脚本重写 3 次仍重试同一路径 @ Farm→Town 出口 / Town 广场 — goto_location -> FAIL: exit to Town did not open (closed? locked?); 游戏消息: Today's festival is being set up. Come back later.（做不了：全天无法进 Town，集市 grange display 没参加，星之果实和集市奖励全部错过） 〔复盘〕
- mine 因背包空格不足被拒 2 次，重写脚本后仍调 mine @ Farm / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：当天零矿产出，铁锭进度停滞（仍差 3），钢锄头升级和洒水器材料都卡住） 〔复盘〕
- 洒水器条件已满足却整天没 craft，里程碑显示「条件都满足，今天就做」 @ Farm — 脚本里没有 craft 洒水器分支，优先级被下矿和节日挤掉（做不了：继续手动浇水，体力浪费，洒水器 ×4 进度为零） 〔复盘〕
- 熔炉刚 load 完 30 分钟内调 collect_machines 返回空，之后又调 load 返回 busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: no empty machine accepts that, and the rest are busy（做不了：铁锭收集延后，当天只收到 2 铁锭，仍差 3） 〔复盘〕
- 15:00 后连续调 build_road/decorate/wait 三个动作全失败，浪费约 200 游戏分钟 @ Farm / Town — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects); decorate -> FAIL: 今天没有能做的装饰; wait -> OK 但纯空转（做不了：收尾时间本可用于钓鱼补食物/现金，全部浪费） 〔复盘〕
- 节日当天 goto Town 失败后仍单独调 festival(grange)，返回不在节日现场 @ Town 广场 — festival -> FAIL: not at a festival right now (goto_location the festival map during its hours first)（做不了：集市参与彻底失败，展品未提交） 〔复盘〕
