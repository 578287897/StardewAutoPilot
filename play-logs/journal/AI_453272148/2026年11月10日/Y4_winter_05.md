# 第4年 winter 5 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（08:04 开始）
- 天气：snow　金钱：52221g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y4_winter_05）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床先 load 铁矿石进空炉（12:00 前，busy 即跳过）
- 清背包到空格 ≥8：ship_produce 卖杂鱼/杂项并验证
- 补食物到 ≥3（Forest 钓鱼 ≤2 轮）
- 电梯直达 75 层拿铁矿石+煤，≤2 次 mine，成功一次即回农场 store_items
- 回农场 collect 收锭，铁锭 ≥5 且 <15:30 去 Blacksmith 升 hoe（走不到即跳过）
- craft 洒水器（Iron Bar 够才做）
- 傍晚回农场浇水/出货，22:00 前 sleep
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
4. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash", "Green Algae", "Copper Bar"]）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash"]）
11. `mine`（floors=5）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `upgrade_tool`（tool="hoe"）
15. `craft`（item="Sprinkler"）
16. `water_crops`
17. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
18. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：d08d3badf96d46ecb4383ee5c8777663
  - 耗时：15.328 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：1560e8f0c45d43278a909c225afdaba7
  - 耗时：16.812 秒 / 游戏 30 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：b81a93bd0e704bbc9295deb977ffe674
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：bf5e7c93dde141d19d2e92c1705b663c
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 5 stacks worth ~1288g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：d2a8682bc02f4caf8ebf2c14d74277e5
  - 耗时：0.703 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：5fc137223a4148dcaba879c9124270cf
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：5ac09b87079a4ac8b7b4a92b09a2cd41
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：4ad73f7059c94cb39aefc88a5cad5861
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash", "Green Algae", "Copper Bar"]）
  - 结果：stored in chest at (74,15): 1x Coal, 4x Green Algae
  - 执行状态：SUCCESS · 操作编号：db267d86d6334828aad2dd69d05a4cfb
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：eeeed07612704bcea062d00bd141b100
  - 耗时：25.188 秒 / 游戏 30 分钟
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Perch, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：291aec46ca0a4471bbb77622bf039483
  - 耗时：65.329 秒 / 游戏 40 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
- **07:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：694a4630e3044f3ab9b274036193d15c
  - 耗时：73.266 秒 / 游戏 100 分钟
- **09:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 75 to 79 (4 floors down, 43 stones broken); stopped at floor 79: weapon too weak for floor 80+ (Silver Saber 8-15; need average damage 14+): buy_weapon at the Adventurer's Guild
  - 执行状态：SUCCESS · 操作编号：8cf9ca8ba70443608d65333fa73d99fe
  - 耗时：71.828 秒 / 游戏 90 分钟
  - 🗨️ [hud] Diamond
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Frozen Geode
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bat Wing
- **11:00** UndergroundMine79 ✅ `mine`（floors=5）
  - 结果：mined from floor 79 to 79 (0 floors down, 0 stones broken); stopped at floor 79: weapon too weak for floor 80+ (Silver Saber 8-15; need average damage 14+): buy_weapon at the Adventurer's Guild
  - 执行状态：SUCCESS · 操作编号：d4f07bbf146b4b2ea595e44947f305d2
  - 耗时：0.328 秒 / 游戏 0 分钟
- **11:00** UndergroundMine79 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：c47ce11a69a0454fb58e6665629acbb9
  - 耗时：37.422 秒 / 游戏 50 分钟
  - 🗨️ [question] 
- **11:50** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
  - 结果：shipped 2 stacks worth ~780g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3b8362012a0d4572bb88b4ee91b30459
  - 耗时：11.25 秒 / 游戏 10 分钟
- **12:00** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash"]）
  - 结果：stored in chest at (74,15): 1x Frozen Geode
  - 执行状态：SUCCESS · 操作编号：733edd8e06224d0f99e336e5a4ccdc37
  - 耗时：4.672 秒 / 游戏 10 分钟
- **12:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：cc426f6d038f462bb4c315cef2dfef55
  - 耗时：13.422 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **12:30** Farm ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：7946e0c1ce8948eab2bef0d37ff5818c
  - 耗时：52.609 秒 / 游戏 60 分钟

### 🔁 脚本重写：重写#1：升级失败因铁锭为 0，改回农场把 7 铁矿石装炉炼锭并落地洒水器，不再重试升级。
1. `donate`
2. `goto_location`（location="Farm"）
3. `load_machines`（item="Iron Ore"）
4. `craft`（item="Sprinkler"）
5. `place`（item="Sprinkler", x=51, y=14）
6. `water_crops`
7. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
8. `sleep`
- **13:30** Blacksmith ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：86163d51120a4e5b8f539d1a6edfcfc2
  - 耗时：0.328 秒 / 游戏 0 分钟
- **13:30** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：12cea41288e74412965f6f264563281f
  - 耗时：38.984 秒 / 游戏 50 分钟
- **14:20** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：9af4ea1e2ddf43ee95980bad07df8238
  - 耗时：11.984 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **14:40** Farm ❌ `craft`（item="Sprinkler"）
  - 结果：can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1
  - 执行状态：ACTION_FAILED · 操作编号：8e680567205b426dbd29666983723152
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：craft 洒水器因缺铁锭失败，改为装炉炼铁并浇水出货后睡觉，不再重试 craft。
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `water_crops`
4. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
5. `sleep`
- **14:40** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：974d64433e1749eb98664494f6f97d6e
  - 耗时：0.312 秒 / 游戏 0 分钟
- **14:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e1c996521353480685b5b45b255d1e8c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **14:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：b0e2ee91c52d49439941f33a0a66ed8f
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:40** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch", "Lingcod", "Chub"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：d086bbda6dc04134bd4ac53f91a3f3be
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:40** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：67a9880615034eafbd45e89f59941e5d
  - 耗时：4.953 秒 / 游戏 0 分钟
- **14:40** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：461f1f9ced4a4fd78ef63b755753685c
  - 耗时：0.344 秒 / 游戏 0 分钟
- **14:40** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：61174d616dab491fb4884566a5b1769e
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:40** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：9e6ea43df2264606bf27e36a6af2eb4c
  - 耗时：300.313 秒 / 游戏 100 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Bone Fragment
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
- **16:20** UndergroundMine78 ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：fc79bda36eb9482c8f31f2ef1a436f04
  - 耗时：47.187 秒 / 游戏 60 分钟
  - 🗨️ [hud] +75 Energy
  - 🗨️ [hud] +33 Health
  - 🗨️ [question] 
  - 🗨️ [hud] Copper Bar
- **17:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7d7b374c485b4945b17874f69d4a414d
  - 耗时：16.969 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：52221 → 54289（+2068g）
- 出货估值：2068g　动作：33 个　失败：6 个
- 模型调用：4 次　tokens：50923
- 有效动作率：0.6562　空转：8　熔断跳过：0
- 失败耗时：355.936 秒 / 游戏 160 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主线（铁锭→钢锄头）零推进：铁矿石只 load 1 次、铁锭仍 0；下矿在 79 层因武器弱被拦，重试 1 次纯浪费；craft 洒水器因缺 Iron Bar 失败；upgrade 因缺锭失败。有效：钓鱼稳定出货、熔炉铜锭产出、sleep 及时。今天唯一硬指标是铁锭，先买武器再下矿，且 load/collect 严格错时。

**新教训：**
- mine 在 79 层因武器 avg 8-15 不足 14 被拒，重试 1 次仍被拒：下矿前应读武器伤害，avg<14 时先买 Claymore（2000g）再下矿，或只下电梯可达的 75-79 层。
- craft 洒水器前未读背包确认 Iron Bar，导致 Iron Bar=0 时仍生成 craft 分支：craft 前必须读背包确认 Copper Bar ≥1 且 Iron Bar ≥1，缺任一直接跳过。
- load_machines 返回 busy 后当天又调 2 次 load 全失败：两炉都在炼时应先 collect 收成品再 load，或当天永久跳过 load，不连续调。
- upgrade_tool 在 Iron Bar=0 时仍被调用：升级前必须读背包确认 Iron Bar ≥5，不够直接跳过，不要靠失败反馈判断。
- mine 的 HTTP timeout 不是游戏内失败，重试仍会超时：超时一次即当天不再调 mine，1 个动作内转 Forest 钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 6）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 52221g 充足，Iron Bar 仍为 0，差 5 锭（≈15 铁矿石 + 5 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是唯一主线。

离完成还差：15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 6）**：起床 load 铁矿石 → 清背包到 ≥10 格 → 冒险家公会买 Claymore（2000g，20-32 伤害）→ 电梯直达 75 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 7）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 8）**：洒水器 craft+place 落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：load 铁矿石**（不是 collect）。若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load，不重试。
2. **清背包到空格 ≥10（最高优先，先于一切下矿/采集）**：`ship_produce` 显式卖鱼组（Green Algae、Trash、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola、Pike、Perch 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Cobblestone Path）。卖完**立即读背包验证空格 ≥10**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。**食物 <3 时禁止下 20 层以下；食物 <5 时禁止下 40 层以下。**
4. **买武器（今天必做，仅当现金 ≥2000 且时间 14:00-21:30）**：goto Adventurer's Guild → `buy` Claymore（2000g，20-32 伤害）。**买前读背包确认现金 ≥2000；买后读背包确认武器已换。** 若 goto 或 buy 失败一次，当天永久跳过，不重试。武器升级后 mine 可下 80 层以下。
5. **下矿（仅当空格 ≥10 且食物 ≥3 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**优先电梯直达 75 层**（已有电梯，不受食物 <5 限制），`mine` 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。**若 goto Blacksmith 或 upgrade_tool 返回 could not reach，当天永久跳过升级，不重试、不换坐标。**
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
10. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
11. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：ship_produce 卖 ≥3 组后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
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
1. 起床：load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
2. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥10
3. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
4. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30；失败即跳过）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥3、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主线（铁锭→钢锄头）零推进：铁矿石只 load 1 次、铁锭仍 0；下矿在 79 层因武器弱被拦，重试 1 次纯浪费；craft 洒水器因缺 Iron Bar 失败；upgrade 因缺锭失败。有效：钓鱼稳定出货、熔炉铜锭产出、sleep 及时。今天唯一硬指标是铁锭，先买武器再下矿，且 load/collect 严格错时。
- 06:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:30 动作 `upgrade_tool` 失败 @ Farm — Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests) 〔自动〕
- 14:40 动作 `craft` 失败 @ Farm — can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1 〔自动〕
- 14:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 14:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 14:40 动作 `mine` 失败 @ Farm — cancelled: HTTP timeout | 游戏消息: [hud] Stone / [hud] Iron Ore / [hud] Bone Fragment / [hud] Stone / [hud] Stone / [hud] Iron Ore 〔自动〕
- 铁锭全天零产出，钢锄头升级连续多天卡住 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy；collect_machines 只收到 Copper Bar，Iron Bar 始终 0（做不了：钢锄头差 5 铁锭无法升级，洒水器也因缺 Iron Bar 无法 craft） 〔复盘〕
- 下矿在 79 层因武器太弱被拦，重试 1 次仍被拦 @ Mine 79 层 — mine -> stopped at floor 79: weapon too weak for floor 80+ (Silver Saber 8-15; need average damage 14+)（做不了：无法下 80 层以下拿更多铁矿石，铁锭产出受限） 〔复盘〕
- craft 洒水器失败，Iron Bar 为 0 仍生成 craft 分支 @ Farm — craft -> FAIL: can't craft Sprinkler: not enough ingredients: Copper Bar x1, Iron Bar x1（做不了：洒水器未做出，仍需手动浇水） 〔复盘〕
- upgrade_tool 在 Iron Bar=0 时被调用 @ Farm / Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)（做不了：钢锄头升级无法完成） 〔复盘〕
- load_machines 连续 3 次返回 busy，浪费动作 @ Farm 熔炉旁 — no empty machine accepts that, and the rest are busy; try again after they finish（做不了：铁矿石无法入炉，铁锭产出为零） 〔复盘〕
- mine 动作 HTTP timeout 被取消 @ Mine — cancelled: HTTP timeout（做不了：当次下矿中断，损失游戏时间） 〔复盘〕
