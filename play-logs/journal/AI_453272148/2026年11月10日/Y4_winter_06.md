# 第4年 winter 6 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（08:18 开始）
- 天气：sunny　金钱：54289g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_winter_06）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭），今天靠下矿拿铁矿石+煤炼锭
- 起床先 load 铁矿石入炉（12:00 前，busy 即跳过）
- 清背包：卖鱼和杂项，验证空格 ≥10
- Forest 钓鱼补食物到 ≥3（顺带补现金）
- 14:00 后去冒险家公会买 Claymore（2000g）提升武器
- 电梯直达 75 层拿铁矿石+煤，≤2 次 mine
- 回农场 collect 收铁锭，铁锭 ≥5 且 <15:30 升 hoe
- 剩余时间 Forest 钓鱼，22:00 前 sleep
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["Salmon", "Tiger Trout", "Pike", "Perch", "Lingcod", "Chub"]）
4. `store_items`（items=["Stone", "Copper Bar", "Copper Ore", "Bone Fragment"]）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `ship_produce`（except=["Salmon", "Tiger Trout", "Pike", "Perch", "Lingcod", "Chub"]）
8. `goto_location`（location="AdventureGuild"）
9. `open_shop`（shop_id="AdventureShop"）
10. `buy`（item="Claymore", count=1）
11. `close_menu`
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment"]）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=4）
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：58e5a05c67ac4d8cad5a0a51537148ab
  - 耗时：11.5 秒 / 游戏 10 分钟
  - 🗨️ [hud] Iron Bar
- **06:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：43e44f67082749d38e243c472c27304e
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d55d36f425364cd7ad7d9997aa0f362c
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：8963190b71674087910df27a0c3d320f
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~396g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：82a898d1a1784cd2a902d5ed13170f11
  - 耗时：9.531 秒 / 游戏 10 分钟
- **06:20** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：3ccd511251764bc6abbc54ef1dddd912
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ca24432d0776454d893c84ea6efef96d
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "Pike", "Perch", "Lingcod", "Chub"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：188e296f65da4ec7b19c79c32e8cd22f
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`（items=["Stone", "Copper Bar", "Copper Ore", "Bone Fragment"]）
  - 结果：stored in chest at (74,15): 2x Copper Bar
  - 执行状态：SUCCESS · 操作编号：c63eb5fdc6a046b9921d4af053823454
  - 耗时：4.719 秒 / 游戏 10 分钟
- **06:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：d587d7cd32b2483994c8e85aa7ccfcf7
  - 耗时：24.781 秒 / 游戏 30 分钟
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：625b26ce0f4847ee9e72d2ad3d394211
  - 耗时：101.438 秒 / 游戏 90 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] You've used your last 
piece of bait. 
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **08:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Perch, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：84f134ca7efa460489c96cc070300b26
  - 耗时：67.469 秒 / 游戏 50 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **09:20** Forest ✅ `goto_location`（location="AdventureGuild"）
  - 结果：waited until 11:20 am (waiting for AdventureGuild to open at 14:00)
  - 执行状态：SUCCESS · 操作编号：0fb81cfdfc4448778f356d74b8057cf0
  - 耗时：82.672 秒 / 游戏 120 分钟
- **11:20** Forest ✅ `goto_location`（location="AdventureGuild"）
  - 结果：waited until 1:20 pm (waiting for AdventureGuild to open at 14:00)
  - 执行状态：SUCCESS · 操作编号：0c59324c8ed44192a24617867e388554
  - 耗时：87.812 秒 / 游戏 120 分钟
- **13:20** Forest ✅ `goto_location`（location="AdventureGuild"）
  - 结果：waited until 2:00 pm (waiting for AdventureGuild to open at 14:00)
  - 执行状态：SUCCESS · 操作编号：03c3937cff0145b7b8e98be69324400b
  - 耗时：29.391 秒 / 游戏 40 分钟
- **14:00** Forest ✅ `goto_location`（location="AdventureGuild"）
  - 结果：arrived at AdventureGuild (6,19)
  - 执行状态：SUCCESS · 操作编号：64fadaf806b24c0a925b30888a075035
  - 耗时：78.656 秒 / 游戏 100 分钟
- **15:40** AdventureGuild ✅ `open_shop`（shop_id="AdventureShop"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：9d68189d398f4ee396acb091700cab10
  - 耗时：0.516 秒 / 游戏 0 分钟
- **15:40** AdventureGuild ✅ `buy`（item="Claymore", count=1）
  - 💭 商店已开，先买Claymore升级武器，再关菜单清背包下矿
  - 结果：bought 1x Claymore for 2000g
  - 执行状态：SUCCESS · 操作编号：1b39d64f6daa4a508755021f658e87b7
  - 耗时：0.328 秒 / 游戏 0 分钟
- **15:40** AdventureGuild ✅ `close_menu`
  - 💭 Claymore 已买。关店，清背包卖鱼腾格，再去矿洞75层拿铁矿。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：4338c229a9c2400cafa128008d126b12
  - 耗时：0.375 秒 / 游戏 0 分钟
- **15:40** AdventureGuild ❌ `ship_produce`（except=["Pike", "Iron Bar", "Iron Ore", "Coal"]）
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：911b0c16963f4668b80f60abb070723f
  - 耗时：51.719 秒 / 游戏 60 分钟
- **16:40** Farm ❌ `buy`（item="Claymore", count=1）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：ef236fa703c74d28bc70d8c19a7ea025
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：Claymore 已买到，失败只是重复购买；回农场卖杂鱼腾格后电梯下 75 层拿铁矿，回来收锭，时间不够升级则钓鱼收尾。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `goto_location`（location="Farm"）
7. `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore"]）
8. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment"]）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **16:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：a8e1153d8652499a98ef0f11531ef21f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：ac15b63c254f46d9bf4f952b276ef79d
  - 耗时：38.75 秒 / 游戏 50 分钟
- **17:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：edfdd96d5759490e896215e9f99b19a3
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅4格导致下矿被拒，先回农场存材料卖杂鱼腾格，再下75层拿铁矿，收炉后睡觉（已17:30，铁匠铺关门无法升hoe）。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb"]）
5. `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore"]）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `collect_machines`
9. `sleep`
- **17:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：88ee83ba02484b01af06f3b5ab34d90b
  - 耗时：0.359 秒 / 游戏 0 分钟
- **17:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4f50f241f4c647249882a9d37c542ee5
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因背包空格不足被拒，先回农场存材料腾格再下矿，其余路线不变。
1. `donate`
2. `mine`（floors=5）
3. `leave_mine`
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb"]）
6. `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `sleep`
- **17:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：fe6c922a86fa41ec94c24663e878fba9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **17:30** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：0cef4d66da8d4b5bbad1130ca1ee7c27
  - 耗时：0.328 秒 / 游戏 0 分钟
- **17:30** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：9b2e7832521241b2855b4768b63481bd
  - 耗时：0.343 秒 / 游戏 0 分钟
- **17:30** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：6035565e51da474c86d802c27a465189
  - 耗时：33.609 秒 / 游戏 40 分钟
- **18:10** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Bone Fragment", "Mystery Box", "Cherry Bomb"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：b7b6a74f5dc9434b8df936dcd851e74a
  - 耗时：15.0 秒 / 游戏 20 分钟
- **18:30** Farm ✅ `ship_produce`（except=["Pike", "Perch", "Iron Bar", "Iron Ore", "Coal", "Claymore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e03883b2f3be4841bc4d6f31bfb1f84a
  - 耗时：0.313 秒 / 游戏 0 分钟
- **18:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：504d008c41cd4eb680f33e91fd922596
  - 耗时：0.328 秒 / 游戏 0 分钟
- **18:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **18:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **18:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：fa16db24d6a245edaee32d66868ef0c5
  - 耗时：10.329 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：54289 → 52685（-1604g）
- 出货估值：396g　动作：36 个　失败：11 个
- 模型调用：7 次　tokens：87107
- 有效动作率：0.6061　空转：7　熔断跳过：2
- 失败耗时：55.735 秒 / 游戏 60 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天最大浪费是等待冒险家公会开门耗掉约3小时游戏时间（9:20→14:00），买完 Claymore 后已 15:40，清背包 ship_produce 又因路径不可达失败，导致 3 次 mine 全被空格不足拒绝，铁锭仍为 0。有效做法：Forest 钓鱼 8 条稳定补现金/食物、熔炉收到 1 铁锭、买武器成功。核心修正：把「清背包到 ≥10 格」提到起床第一动作、买武器改在 14:00 后顺路做而非专门等、下矿前必须读背包验证。

**新教训：**
- 专门 goto Adventurer's Guild 等 14:00 开门会耗掉约 3 小时游戏时间（昨天 9:20 等到 14:00）：应把买武器排在 14:00 后顺路做，等待时段改去 Forest 钓鱼或下矿。
- ship_produce 返回「could not reach (70,15); stopped at (53,8)」说明出货箱/箱子路径被挡：应改卖到可达的出货箱或直接丢弃低价值物，不要重试同一坐标，否则清背包失败会连锁导致 mine 全被拒。
- 买完武器后已 15:40，再清背包+下矿已来不及：买武器应放在下矿之后或与下矿同区域顺路，不要在下午中段插入 2000g 采购打断主线。
- 昨天 3 次 mine 全因空格不足被拒（脚本重写 3 次仍重跑 mine）：脚本生成阶段必须先读背包，空格 <10 时物理删除 mine 分支，而不是运行时反复被拒。
- 钓鱼 8 条（Pike/Perch）稳定补现金和食物，是昨天唯一有效产出：主活动被卡时应在 1 个动作内转 Forest 钓鱼，而不是重写脚本重试失败动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 7）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 52289g 充足，Iron Bar 仅 1，差 4 锭（≈12 铁矿石 + 4 煤）。铁锭同时是洒水器材料，「下矿拿铁矿石+煤」是唯一主线。

离完成还差：12 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 7）**：起床先清背包到 ≥10 格 → load 铁矿石 → 电梯直达 75 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 8）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 9）**：洒水器 craft+place 落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包到空格 ≥10（最高优先，先于 load/下矿/采集）**：`ship_produce` 显式卖鱼组（Pike、Perch、Chub、Lingcod 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Mystery Box、Cherry Bomb）。卖完**立即读背包验证空格 ≥10**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
2. **load 铁矿石**：若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load，不重试。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留高回复鱼，杂鱼立即 ship_produce 卖掉。**食物 <3 时禁止下 20 层以下；食物 <5 时禁止下 40 层以下。**
4. **下矿（仅当空格 ≥10 且食物 ≥3 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**优先电梯直达 75 层**（已有电梯，不受食物 <5 限制），`mine` 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。**若 goto Blacksmith 或 upgrade_tool 返回 could not reach，当天永久跳过升级，不重试、不换坐标。**
8. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → `buy` Claymore。**买前读背包确认现金 ≥2000；买后读背包确认武器已换。** 若 goto 或 buy 失败一次，当天永久跳过，不重试。**禁止在 14:00 前专门 goto 公会等开门**——等待期间改去 Forest 钓鱼或下矿，14:00 后再顺路去。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
10. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：ship_produce 卖 ≥3 组后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。**ship_produce 返回 could not reach 说明箱子路径被挡，改卖到出货箱或直接丢弃低价值物，不要重试同一坐标。**
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **禁止专门等商店开门**：14:00 前不 goto Adventurer's Guild；等待时间用于钓鱼或下矿，14:00 后顺路买。
- **武器优先于下矿**：Silver Saber 8-15 在 80 层以下被拒，今天必须先买 Claymore（2000g）再下矿；买武器失败则当天只下 75-79 层（电梯层不受武器限制）。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥3 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。**同一层连续 2 次 mine 失败即 leave_mine，不重试第 3 次**。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。**电梯直达 75 层例外。**
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：清背包到空格 ≥10（ship_produce 卖 ≥3 组 + 读背包验证）
2. load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
3. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
4. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥3、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
5. mine 成功一次后 store_items 腾格
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
8. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30、顺路；失败即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天最大浪费是等待冒险家公会开门耗掉约3小时游戏时间（9:20→14:00），买完 Claymore 后已 15:40，清背包 ship_produce 又因路径不可达失败，导致 3 次 mine 全被空格不足拒绝，铁锭仍为 0。有效做法：Forest 钓鱼 8 条稳定补现金/食物、熔炉收到 1 铁锭、买武器成功。核心修正：把「清背包到 ≥10 格」提到起床第一动作、买武器改在 14:00 后顺路做而非专门等、下矿前必须读背包验证。
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:40 动作 `ship_produce` 失败 @ AdventureGuild — could not reach (70,15); stopped at (53,8) 〔自动〕
- 16:40 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 17:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 17:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 17:30 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 17:30 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 18:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 18:30 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 18:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 专门去冒险家公会等开门，从 9:20 等到 14:00 才买到 Claymore @ AdventureGuild 门口 — goto_location 返回 waited until 2:00 pm (waiting for AdventureGuild to open at 14:00)，共耗约 280 游戏分钟（做不了：买完武器已 15:40，清背包和下矿时间被压缩，当天 mine 全部失败） 〔复盘〕
- 清背包 ship_produce 因路径不可达失败，背包空格始终不足 @ Farm 出货箱附近 (53,8)→(70,15) — ship_produce -> FAIL: could not reach (70,15); stopped at (53,8)（做不了：背包空格 <10，3 次 mine 全被拒（need at least 5 free backpack slots）） 〔复盘〕
- 同一 mine 动作在脚本重写后连续重跑 3 次，全部同一原因失败 @ Mine 入口 — 3x mine: need at least 5 free backpack slots before mining; store_items first（做不了：浪费动作与脚本重写次数（3 次重写），铁锭全天零新增） 〔复盘〕
- store_items 到农场箱子返回「nothing to store」但背包仍满，说明要存的物品不在背包或坐标错 @ Farm 箱子 (74,15) — store_items -> OK: nothing to store（items 列表 Stone/Copper Ore/Bone Fragment/Mystery Box/Cherry Bomb 均未在背包）（做不了：无法通过 store_items 腾格，下矿分支彻底卡死） 〔复盘〕
- 铁锭连续多天零产出，钢锄头升级持续卡住 @ Farm 熔炉 — Iron Bar 仅 1（collect 只收到 1 个），load_machines 多次 busy/no empty（做不了：钢锄头差 4 铁锭无法升级，洒水器也因缺 Iron Bar 无法 craft） 〔复盘〕
