# 第4年 winter 8 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（08:38 开始）
- 天气：sunny　金钱：53545g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a32e5b01c6cd4bc0a8f4e799823798ee
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d440371ac1c44cf4964de99f71653c80
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：2ec2d9119bd3438c87aa434727c7f248
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~172g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：31bc7d88ef4c4794b5aefc64a5c3468e
  - 耗时：5.406 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_08）准备的脚本
- 里程碑：凑齐 5 铁锭升级钢锄头（差 4 锭）
- 起床清背包到 ≥10 格并验证
- load 铁矿石（炉空才 load）
- Forest 钓鱼补食物到 ≥3
- 电梯直达 75 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场 collect 收锭
- 铁锭 ≥5 且 <15:30 去铁匠铺升 hoe
- 14:00 后顺路买 Claymore（若现金够）
1. `goto_location`（location="Forest"）
2. `festival`（activity="start"）
3. `store_items`（items=["Stone", "Copper Ore", "Coal", "Bug Meat", "Fiber", "Cobblestone Path", "Bamboo Pole", "Rusty Sword", "Silver Saber"]）
4. `load_machines`（item="Iron Ore"）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `ship_produce`（except=["Perch"]）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `store_items`（items=["Stone", "Copper Ore"]）
11. `mine`（floors=4）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `sleep`
- **06:00** Farm ❌ `goto_location`（location="Forest"）
  - 结果：exit to Forest did not open (closed? locked? check opening hours). Recent messages: Cobblestone Path | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：f0c2cc9ca7b246d783e301e07c85748a
  - 耗时：25.281 秒 / 游戏 30 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：Forest 因节日布置关闭，先等到 9:00 节日开放再参加冰雪节，之后回农场收锭并尝试升级锄头。
1. `wait`（minutes=150）
2. `goto_location`（location="Forest"）
3. `festival`（activity="start"）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Farm"）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `sleep`
- **06:30** Farm ✅ `wait`（minutes=150）
  - 结果：cleared 0 debris within 8 tiles of (41,63); none of the 12 weed/stone/twig in Farm is reachable
  - 执行状态：SUCCESS · 操作编号：cbd5be06cf6a4755a933c63a515becda
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `goto_location`（location="Forest"）
  - 结果：exit to Forest did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：9248892c980e49ee9b19dd22675e5b8e
  - 耗时：5.469 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#2：Forest 入口因节日布置未开，先在农场收炉装料并等 9:00 节日开放，节日后回农场收锭再升 hoe。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `craft`（item="Sprinkler", count=1）
4. `wait`（minutes=120）
5. `goto_location`（location="Forest"）
6. `festival`（activity="start"）
7. `goto_location`（location="Blacksmith"）
8. `upgrade_tool`（tool="hoe"）
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `sleep`
- **06:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f129da753467403cad5372d05e4143f5
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：277039d8286c416a8f3662ce09cea113
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：b7230697e1d24fe2b678860bc8c8bebb
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `wait`（minutes=120）
  - 结果：cleared 0 debris within 8 tiles of (41,64); none of the 12 weed/stone/twig in Farm is reachable
  - 执行状态：SUCCESS · 操作编号：6a7e1eabe90843499ba44ecfdbc2339d
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `goto_location`（location="Forest"）
  - 结果：exit to Forest did not open (closed? locked? check opening hours). Recent messages: Sprinkler | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：0f5b5cb8fb464477ade62a28cdbe6014
  - 耗时：5.234 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#3：Forest节日9点才开，先在农舍等开门再进节日，之后回农场收锭并顺路升级锄头。
1. `goto_location`（location="Forest"）
2. `festival`（activity="start"）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `wait`（minutes=140）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `sleep`
- **06:40** Farm ❌ `goto_location`（location="Forest"）
  - 结果：exit to Forest did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：a44884c8ba1447e48d3908337a2196fd
  - 耗时：5.234 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **06:50** Farm ❌ `festival`（activity="start"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：22a5f44358e044ed8b2460ad940d2457
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 8:50 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：5a7dc73212974661b7e2c8df9e483393
  - 耗时：84.156 秒 / 游戏 120 分钟
- **08:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：0846166b137947d88653542cc14b4358
  - 耗时：7.531 秒 / 游戏 10 分钟
  - 🗨️ [hud] The Festival of Ice 
has begun near 
Marnie's ranch. 
- **09:00** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: The Festival of Ice 
has begun near 
Marnie's ranch.  | It's locked...
  - 执行状态：ACTION_FAILED · 操作编号：be6701b25d784129a283d5f130ad79db
  - 耗时：64.735 秒 / 游戏 80 分钟
  - 🗨️ [dialogue] It's locked...
- **10:20** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked...
  - 执行状态：ACTION_FAILED · 操作编号：53743c5cc54d458f8ed3a0857c2bb73e
  - 耗时：5.25 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] It's locked...
- **10:20** Town ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：2f0518e38c8645a1b4d5d8a67595dc66
  - 耗时：37.578 秒 / 游戏 50 分钟
- **11:10** Farm ✅ `wait`（minutes=140）
  - 结果：cleared 0 debris within 8 tiles of (78,17); none of the 12 weed/stone/twig in Farm is reachable
  - 执行状态：SUCCESS · 操作编号：a3ccd9c0107b47faafd4e91b3d69d4f4
  - 耗时：0.36 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:10** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：d2e244975f3f4e9080153e9e1124ec0f
  - 耗时：204.765 秒 / 游戏 200 分钟
- **14:30** Forest ❌ `festival`（activity="start", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：81c819f632bc43d2bca1e834a760412c
  - 耗时：0.313 秒 / 游戏 0 分钟
- **14:30** Forest ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 15 to 19 (4 floors down, 25 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：2f36919e41644c1aa88da79c05d0c647
  - 耗时：87.813 秒 / 游戏 110 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
- **16:20** UndergroundMine19 ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：167e0380b12242cab9268989202d3a6d
  - 耗时：44.625 秒 / 游戏 50 分钟
  - 🗨️ [question] 
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7bdece9a89ca4f6f9483fef1d1bfaa3e
  - 耗时：12.75 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：53545 → 53717（+172g）
- 出货估值：172g　动作：27 个　失败：14 个
- 模型调用：5 次　tokens：65798
- 有效动作率：0.3333　空转：6　熔断跳过：2
- 失败耗时：158.281 秒 / 游戏 180 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天冰雪节是最大浪费：9:00 前反复 goto Forest 被拒 4 次、festival 空调 2 次，节日期间铁匠铺锁门导致升级失败；熔炉 load/collect 时序仍错，铁锭零产出。唯一有效产出是 15→19 层下矿和钓鱼。今天冬 9 无节日，应把「铁锭产出→升钢锄头」作为唯一主线，节日日规则写死。

**新教训：**
- 节日当天 9:00 前 goto 节日地图必返回「festival is being set up」，且节日期间 Blacksmith 锁门：节日日应把升级/购物整段删除，主线改下矿或钓鱼，等节日开始后再 goto 节日地图。
- goto_location 到 Blacksmith 返回「It's locked...」时 upgrade_tool 也必然失败：升级前应先确认当天不是节日且时间在 9:00-16:00，否则直接跳过升级，不要靠 upgrade_tool 的失败反馈判断。
- 熔炉 load 返回 busy 后当天又调 load 被 suppressed：起床应先读炉状态，两炉都 busy 先 collect 再 load，load 每天只调 1 次，返回 busy 即当天永久跳过。
- wait 在农场清 debris 返回「none of the 12 weed/stone/twig is reachable」说明障碍物被树/作物围住：wait 清障无效，应改用 use_tool axe 带坐标砍树或直接放弃清障转钓鱼。
- build_road 返回「24 skipped: blocked by trees/crops/objects」说明农场地面被占满：铺路前应先清出通道，否则永远 0 铺设，应彻底从脚本删除 build_road。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 9）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 53545g 充足，Iron Bar 仅 1，差 4 锭（≈12 铁矿石 + 4 煤）。铁锭同时是洒水器材料，**「稳定产出铁锭」是唯一主线**。

离完成还差：12 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 9，无节日）**：起床读熔炉状态 → 空炉 load 铁矿石（≤1 次）→ 电梯直达 75 层下矿拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 10）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 11）**：洒水器 craft+place 落地 + 冬季种子/茶苗，为春 1 做准备。

## 节日日规则（新增，硬规则）
- 节日当天：**节日地图开放前（通常 9:00）禁止 goto 节日地点**；日志出现「festival is being set up」即当天不再 goto 该地点。
- 节日期间 **Blacksmith/皮埃尔等商店锁门**，禁止安排升级/购物；节日日主线改为下矿/钓鱼。
- `festival start` 只在已到达节日地图后调用；goto 失败即跳过 festival，不重试。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：读熔炉状态**。两炉都 busy → 先 `collect_machines` 1 次；有成品收走，无成品则等炉空。**load 每天 ≤1 次，12:00 前完成；返回 busy/no empty 即当天永久跳过 load。**
2. **清背包到空格 ≥10**：用 `store_items` 存 Stone/Copper Ore 到**农场入口附近可达箱子**；若返回不可达，改用 `ship_produce` 卖低价值物。**存/卖后必须读背包验证空格 ≥10**；两次手段仍不足则当天定性钓鱼日，物理删除 mine 分支。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留高回复鱼，杂鱼立即 ship_produce 卖掉。食物 <3 禁止下 20 层以下；<5 禁止下 40 层以下；**电梯直达 75 层不受此限**。
4. **下矿（仅当空格 ≥10 且食物 ≥3 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**优先电梯直达 75 层**，`mine` 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。若 goto Blacksmith 或 upgrade_tool 返回 could not reach，当天永久跳过升级，不重试、不换坐标。
8. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → `buy` Claymore。买前读背包确认现金 ≥2000；买后读背包确认武器已换。若 goto 或 buy 失败一次，当天永久跳过，不重试。**禁止在 14:00 前专门 goto 公会等开门**——等待期间改去 Forest 钓鱼或下矿，14:00 后再顺路去。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
10. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。**store_items 返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。**
- **熔炉时序硬规则**：起床先读炉状态；两炉都 busy 先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。**不连续调 load。**
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
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
1. 起床：读熔炉状态 + 清背包到空格 ≥10（store_items 到可达箱子 + 读背包验证）
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
> 昨天冰雪节是最大浪费：9:00 前反复 goto Forest 被拒 4 次、festival 空调 2 次，节日期间铁匠铺锁门导致升级失败；熔炉 load/collect 时序仍错，铁锭零产出。唯一有效产出是 15→19 层下矿和钓鱼。今天冬 9 无节日，应把「铁锭产出→升钢锄头」作为唯一主线，节日日规则写死。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `goto_location` 失败 @ Farm — exit to Forest did not open (closed? locked? check opening hours). Recent messages: Cobblestone Path | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 06:30 动作 `goto_location` 失败 @ Farm — exit to Forest did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. 〔自动〕
- 06:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:40 动作 `goto_location` 失败 @ Farm — exit to Forest did not open (closed? locked? check opening hours). Recent messages: Sprinkler | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 06:40 动作 `goto_location` 失败 @ Farm — exit to Forest did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. 〔自动〕
- 06:50 动作 `festival` 失败 @ Farm — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 09:00 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: The Festival of Ice 
has begun near 
Marnie's ranch.  | It's locked... | 游戏消息: [dialogue] It's locked... 〔自动〕
- 10:20 动作 `upgrade_tool` 失败 @ Town — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... | 游戏消息: [dialogue] It's locked... 〔自动〕
- 11:10 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:10 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 14:30 动作 `festival` 失败 @ Forest — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 16:20 动作 `build_road` 失败 @ UndergroundMine19 — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) | 游戏消息: [question]  〔自动〕
- 冰雪节当天反复尝试进入 Forest 参加节日，全部被拒 @ Farm→Forest 出口 — goto_location -> FAIL: exit to Forest did not open ... Today's festival is being set up. Come back later.（共 4 次）（做不了：节日没参加成，上午 9:00-11:00 游戏时间几乎全空转） 〔复盘〕
- 节日期间去铁匠铺升级钢锄头，门锁着 @ Blacksmith — goto_location -> FAIL: It's locked...；upgrade_tool -> FAIL: exit to Blacksmith did not open（做不了：钢锄头升级当天彻底失败，Iron Bar 仍差 4） 〔复盘〕
- 熔炉时序错乱：起床先 collect 返回空，再 load 又 busy @ Farm 熔炉 — collect_machines -> FAIL: no machine has finished output；load_machines -> FAIL: no empty machine accepts anything / repeated ineffective action suppressed（做不了：铁锭全天零新增，钢锄头和洒水器都卡在缺 Iron Bar） 〔复盘〕
- 下矿到 19 层因食物不足被拦，无法下 20 层以下拿铁矿 @ UndergroundMine 19 层 — mine -> stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below)（做不了：拿不到铁矿，铁锭产出继续为零） 〔复盘〕
- wait 清农场 debris 无效，障碍物不可达 @ Farm (41,63)/(41,64)/(78,17) — wait -> cleared 0 debris ... none of the 12 weed/stone/twig in Farm is reachable（共 3 次）（做不了：农场通道没清出来，箱子/出货箱路径仍被挡） 〔复盘〕
- 铺路 24 格全被树/作物挡住 @ Farm — build_road -> laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：农场道路规划无法推进） 〔复盘〕
- 节日未到达就调 festival start @ Forest / 任意 — festival -> FAIL: not at a festival right now (goto_location the festival map during its hours first)（共 2 次）（做不了：节日活动无法开始，浪费动作） 〔复盘〕
