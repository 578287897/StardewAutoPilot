# 第4年 winter 3 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（07:35 开始）
- 天气：snow　金钱：51311g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：6c7272deca3d40c79434b7e394b3eacd
  - 耗时：15.281 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：cbe3e174946742c1acde1ccf5a2042a7
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：aaf3c1c8b34e4a78a81758c3eae39b62
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~16g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：576004903c0c4a93808ec3d658ee20b6
  - 耗时：13.172 秒 / 游戏 20 分钟

## 🌙 为明天（Y4_winter_03）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床先 load 铁矿石进熔炉（12:00 前，busy 即跳过）
- ship_produce 卖杂鱼垃圾腾格子，验证空格 ≥8
- Forest 河边钓鱼补食物到 ≥5（只留高回复鱼）
- 下矿 75-79 层拿铁矿石+煤（≤2 次，每次 ≤5 层，超时即转钓鱼）
- 回农场 store_items 腾格 + collect 收铁锭
- 铁锭 ≥5 且 <15:30 → Blacksmith 升 hoe
- craft 洒水器（条件已满足）
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `goto_location`（location="Farm"）
11. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode"]）
12. `collect_machines`
13. `craft`（item="Sprinkler", count=1）
14. `goto_location`（location="Mountain"）
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `sleep`
- **06:30** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：79949dd44456481ab46f88a2b97289a4
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：ee57d3f794c944119f9ef0266b1cace3
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：4b9d50274b91446d8abec412e54efacd
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：c9ecb837938e4bd48a93053ad644d075
  - 耗时：21.625 秒 / 游戏 30 分钟
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：a4c97fd001b54d868db0575ac0c19655
  - 耗时：118.344 秒 / 游戏 120 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **09:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Green Algae, Trash, Pike)
  - 执行状态：SUCCESS · 操作编号：618a846c13064c558dc9eb159e6f75ee
  - 耗时：76.797 秒 / 游戏 80 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Trash
- **10:20** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：68aba39f47694fba8e72f838f790d0ac
  - 耗时：73.282 秒 / 游戏 100 分钟
- **12:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：43f28379af3243b59532e517663d0c2c
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因空格不足被拒，先回农场存材料腾格并收熔炉，再按锭数决定升 hoe，最后 craft 洒水器落地睡觉。
1. `donate`
2. `goto_location`（location="Mountain"）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Cobblestone Path"]）
7. `collect_machines`
8. `craft`（item="Sprinkler", count=1）
9. `place`（item="Sprinkler", x=51, y=14）
10. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
11. `sleep`
- **12:00** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：8175889dd08b4066b19723f02c769c73
  - 耗时：0.312 秒 / 游戏 0 分钟
- **12:00** Mine ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (54,5)
  - 执行状态：SUCCESS · 操作编号：f06f2fa231a4430ebca518920eaeb79c
  - 耗时：1.547 秒 / 游戏 0 分钟
- **12:00** Mountain ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：e0fdb736b1924941960cb72f75c58fbd
  - 耗时：45.812 秒 / 游戏 50 分钟
- **12:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：5662aed8a0aa446582c0467d3e51196e
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：铁锭为0无法升hoe，回农场收熔炉成品并腾背包，craft洒水器落地后收工。
1. `donate`
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Cobblestone Path"]）
4. `collect_machines`
5. `craft`（item="Sprinkler", count=1）
6. `place`（item="Sprinkler", x=51, y=14）
7. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
8. `sleep`
- **12:50** Blacksmith ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：543ede959b6a4fd7919ab37dceb4a079
  - 耗时：0.313 秒 / 游戏 0 分钟
- **12:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：443e0de0f09842b5b77d53f446703855
  - 耗时：38.922 秒 / 游戏 50 分钟
- **13:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Cobblestone Path"]）
  - 结果：stored in chest at (75,15): 1x Coal, 24x Cobblestone Path, 117x Stone, 2x Iron Ore, 5x Copper Ore, 1x Gold Ore
  - 执行状态：SUCCESS · 操作编号：ecdd6642d0374826a9facd461fd902f4
  - 耗时：1.125 秒 / 游戏 0 分钟
- **13:40** Farm ❌ `collect_machines`
  - 结果：could not reach (40,9); stopped at (41,8)
  - 执行状态：ACTION_FAILED · 操作编号：8d33f34e4aca4e6b8e757621b3653a77
  - 耗时：19.875 秒 / 游戏 30 分钟
- **14:10** Farm ❌ `craft`（item="Sprinkler", count=1）
  - 结果：can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1
  - 执行状态：ACTION_FAILED · 操作编号：18d2e741dcc54668a2b9ef100ddbb76e
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：craft 因缺铁锭失败，改为先收熔炉成品并下矿补铁矿石，不再重试 craft/place。
1. `donate`
2. `collect_machines`
3. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore"]）
8. `collect_machines`
9. `sleep`
- **14:10** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：49c7ae00103f421e9b8283d39bf7117e
  - 耗时：0.313 秒 / 游戏 0 分钟
- **14:10** Farm ❌ `collect_machines`
  - 结果：could not reach (40,9); stopped at (41,8)
  - 执行状态：ACTION_FAILED · 操作编号：a0f989479fb340bf8620cb14c028311c
  - 耗时：7.578 秒 / 游戏 10 分钟
- **14:20** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
  - 结果：shipped 2 stacks worth ~764g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：a045791e076d454eae80ca66b51183e1
  - 耗时：9.078 秒 / 游戏 10 分钟
- **14:30** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1d1a490c0f4841989608e6358860ca95
  - 耗时：84.719 秒 / 游戏 110 分钟
- **16:20** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 78 stones broken); stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：d289ba5416cd4657abee251b6d291c1e
  - 耗时：79.204 秒 / 游戏 100 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Cherry Bomb
  - 🗨️ [hud] Geode
- **18:00** UndergroundMine19 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：05521017d6ac4d1ab4f08712b78c01b7
  - 耗时：37.437 秒 / 游戏 50 分钟
  - 🗨️ [question] 
- **18:50** Farm ❌ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore"]）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：2e7d8f63d78b4ff0aa6349dcc12ae112
  - 耗时：12.516 秒 / 游戏 10 分钟
- **19:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **19:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：28e2b214f42f4fd38d3525c9d3278539
  - 耗时：11.937 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：51311 → 52091（+780g）
- 出货估值：780g　动作：30 个　失败：8 个
- 模型调用：5 次　tokens：62771
- 有效动作率：0.6429　空转：4　熔断跳过：1
- 失败耗时：42.299 秒 / 游戏 50 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动被背包空格和熔炉时序拖垮：mine 因空格不足被拒、load 返回 busy、collect 两次空转，铁锭仍为 0，钢锄头未升。钓鱼 8 条有效但杂鱼占格。真正有效的是钓鱼出货 764g 和 15→19 层推进。今天必须先把背包清到 ≥8 格、起床先 load 再下矿，且下矿前确认食物。

**新教训：**
- 昨天 mine 在 15→19 层成功推进 4 层后因食物仅 2 个被拦在 20 层：下矿前应先把食物补到 ≥3（Forest 钓鱼 1 轮即可），否则只能停在 19 层拿不到铁矿
- 昨天 collect_machines 两次返回「could not reach (40,9); stopped at (41,8)」：熔炉旁有障碍物挡住路径，应先清出熔炉周围一格通道或改用可到达的站位坐标再 collect
- 昨天 store_items 在 (53,8) 被卡住到不了 (74,16)：农场箱子路径被树/作物挡住，store_items 前应确认箱子可达，或把常用箱子移到农场入口附近
- 昨天 craft 洒水器失败是因为 Iron Bar 为 0 而脚本仍生成 craft：craft 前必须读背包确认 Copper Bar ≥1 且 Iron Bar ≥1，缺任一则跳过 craft 先炼锭
- 昨天 load 铁矿石返回 busy 后当天没再 load，铁锭产出为零：两炉都在炼时应先 collect 收成品再 load，或干脆等炉空后第二天 load，不要连续调 load

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 4）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 51311g 充足，Iron Bar 仍为 0，差 5 锭（≈15 铁矿石 + 5 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」仍是唯一主线。

离完成还差：15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 4）**：起床 load 铁矿石 → 清背包到 ≥8 格 → 补食物到 ≥3 → 下矿 19→25 层（或电梯回 75 层）拿铁矿石+煤 → 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 5）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 6）**：洒水器落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：load 铁矿石**（不是 collect）。若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load，不重试。
2. **清背包到空格 ≥8（最高优先，先于一切下矿/采集）**：`ship_produce` 显式卖鱼组（Green Algae、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola、Pike 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Cobblestone Path）。卖完**立即读背包验证空格 ≥8**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。**食物 <3 时禁止下 20 层以下；食物 <5 时禁止下 40 层以下。**
4. **下矿（仅当空格 ≥8 且食物 ≥3）**：goto Mine 前显式读背包确认两项。`mine` 目标 19→25 层（或电梯回 75 层拿铁矿石+煤），≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。
8. **craft 洒水器并落地**：条件已满足（Copper Bar 32、Iron Bar 0-1，够做 1 个）。craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：昨天 6 次 mine 全因空格不足被拒。ship_produce 卖 ≥3 组后必须读背包验证空格 ≥8，验证通过前不得出现任何其他动作（含 mine/forage）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 8**：条件已满足，清背包后立即 craft，不能等「有空再做」。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥3 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <8 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。**同一层连续 2 次 mine 失败即 leave_mine，不重试第 3 次**。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
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
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
2. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
3. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
4. 下矿 19→25 层（或电梯 75 层）拿铁矿石+煤（空格 ≥8、食物 ≥3 才下，≤2 次 mine，每次 ≤5 层，超时即停）
5. mine 成功一次后 store_items 腾格
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. craft 洒水器（条件已满足，必须今天做）+ place（带 x,y；无空位即跳过）
9. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
10. 浇水（水壶在背包时）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主活动被背包空格和熔炉时序拖垮：mine 因空格不足被拒、load 返回 busy、collect 两次空转，铁锭仍为 0，钢锄头未升。钓鱼 8 条有效但杂鱼占格。真正有效的是钓鱼出货 764g 和 15→19 层推进。今天必须先把背包清到 ≥8 格、起床先 load 再下矿，且下矿前确认食物。
- 06:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests) 〔自动〕
- 13:40 动作 `collect_machines` 失败 @ Farm — could not reach (40,9); stopped at (41,8) 〔自动〕
- 14:10 动作 `craft` 失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1 〔自动〕
- 14:10 动作 `collect_machines` 失败 @ Farm — could not reach (40,9); stopped at (41,8) 〔自动〕
- 18:50 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 19:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 熔炉时序反复错乱：起床 load 返回 busy、collect 两次返回空，铁锭全天零产出 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy；collect_machines -> FAIL: no machine has finished output（做不了：钢锄头差 5 铁锭无法升级，洒水器也因缺 Iron Bar 无法 craft） 〔复盘〕
- 背包空格不足导致下矿被拒，随后重写脚本仍调 mine @ Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：下矿推进 0 层，铁矿石和煤没拿到） 〔复盘〕
- 熔炉/箱子路径被挡，collect 和 store_items 都到不了目标坐标 @ Farm (41,8) 与 (53,8) — collect_machines -> could not reach (40,9); stopped at (41,8)；store_items -> could not reach (74,16); stopped at (53,8)（做不了：收不到铁锭、矿石无法入库，背包持续满） 〔复盘〕
- 食物只有 2 个，下矿被拦在 20 层 @ Mine 第 19 层 — stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below)（做不了：无法下到 20 层以下拿铁矿，铁锭材料凑不齐） 〔复盘〕
- craft 洒水器失败，Iron Bar 为 0 仍生成 craft 分支 @ Farm — craft -> FAIL: can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1（做不了：洒水器未做出，仍需手动浇水） 〔复盘〕
- 钓鱼 8 条中混入 Green Algae/Trash 等杂鱼占格 @ Forest 河边 — fished: caught 4 (Perch, Green Algae, Trash, Pike)（做不了：背包更快满，间接导致下矿被拒） 〔复盘〕
