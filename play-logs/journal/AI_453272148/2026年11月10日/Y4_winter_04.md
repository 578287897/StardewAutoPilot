# 第4年 winter 4 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（07:52 开始）
- 天气：snow　金钱：52091g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_winter_04）准备的脚本
- 里程碑：工具按档升级——凑 5 铁锭升 Steel Hoe
- 起床先 load 铁矿石进熔炉（≤1 次）
- 清背包腾格（卖杂鱼/杂物），验证空格 ≥8
- Forest 钓鱼补食物到 ≥3 并顺手卖杂鱼
- 下矿 19→25 层拿铁矿石+煤（≤2 次 mine，成功一次先回农场 store_items）
- 回农场 collect 收铁锭，够 5 锭且 <15:30 去 Blacksmith 升 hoe
- 收尾：浇水（水壶在背包）后 sleep
1. `donate`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
4. `store_items`（items=["Stone", "Copper Ore", "Geode", "Bug Meat", "Slime", "Trash", "Green Algae"]）
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `goto_location`（location="Farm"）
11. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Gold Ore", "Geode"]）
12. `collect_machines`
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `upgrade_tool`（tool="hoe"）
18. `water_crops`
19. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Pickled Common Mushroom from Preserves Jar, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：5e04a1d4c2874220b630c10b59dc78f2
  - 耗时：19.203 秒 / 游戏 20 分钟
  - 🗨️ [hud] Pickled Common Mushroom
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：19b5577a61104ad88be9e1f90eeb2c0e
  - 耗时：3.906 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Slime, 2x Sprinkler, 1x Bug Meat, 1x Trash, 1x Copper Bar, 1x Coal
  - 执行状态：SUCCESS · 操作编号：2885d61684064b73b06c3ce40b8f790b
  - 耗时：18.375 秒 / 游戏 30 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：15204a1b4b514c57869ccfa52c1e5990
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：315041f1972d4582abb2bd23f59f45c5
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~130g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：64cdb52540e94ba386232b10c364861f
  - 耗时：0.703 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：4dd36a3ac9fe420a866c12c676086fa3
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：9ecfda54d53e4fb582433165071fae72
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：d757fd5c3b0141fcaeba63de55bf23cf
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Geode", "Bug Meat", "Slime", "Trash", "Green Algae"]）
  - 结果：stored in chest at (74,15): 2x Geode, 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：048970e343a042a2ba8d6aca760eef28
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：6ba4da93dde644d2bbbb72c8fabdbee6
  - 耗时：25.218 秒 / 游戏 30 分钟
- **07:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Perch, Trash, Pike)
  - 执行状态：SUCCESS · 操作编号：18c8c0e8b40b44be90ca671be6d43284
  - 耗时：87.906 秒 / 游戏 90 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Trash
- **08:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：9f17d0ac813446c587a635d6afb2fe93
  - 耗时：73.297 秒 / 游戏 90 分钟
- **10:20** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 35 to 37 (2 floors down, 53 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：7542d029a595459291bbc664ef8961fa
  - 耗时：75.391 秒 / 游戏 100 分钟
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **12:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：09295bb45c96486fb142356732495fe0
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因空格不足被拒，先回农场存矿卖杂鱼腾格，收炉锭后够 5 铁锭则升 hoe，否则直接收尾睡觉。
1. `donate`
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash"]）
4. `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch"]）
5. `collect_machines`
6. `upgrade_tool`（tool="hoe"）
7. `water_crops`
8. `sleep`
- **12:00** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：0757829ec8bf44558661094b6b1c030c
  - 耗时：0.297 秒 / 游戏 0 分钟
- **12:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4e9881bd0f8a4a338f0275a1fa642f00
  - 耗时：35.75 秒 / 游戏 40 分钟
- **12:40** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Iron Ore", "Coal", "Geode", "Omni Geode", "Bug Meat", "Bat Wing", "Trash"]）
  - 结果：stored in chest at (74,15): 2x Coal, 1x Trash, 1x Omni Geode, 1x Bat Wing, 1x Geode, 1x Bug Meat
  - 执行状态：SUCCESS · 操作编号：bebf425d55a84097b9a2014015239fb1
  - 耗时：15.594 秒 / 游戏 20 分钟
- **13:00** Farm ✅ `ship_produce`（except=["Salmon", "Tiger Trout", "River Jelly", "Pike", "Perch"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：b31093dce38f4a19b467f51908404667
  - 耗时：0.329 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：d7e81afdb59e47f58f908752e402fe5f
  - 耗时：19.14 秒 / 游戏 30 分钟
  - 🗨️ [hud] Copper Bar
- **13:30** Farm ❌ `upgrade_tool`（tool="hoe"）
  - 结果：could not reach (94,82); stopped at (40,57)
  - 执行状态：ACTION_FAILED · 操作编号：4e28c707fc814ffdb7b9663f8b43a331
  - 耗时：43.031 秒 / 游戏 60 分钟

### 🔁 脚本重写：重写#2：Blacksmith 路径不可达，升级失败即放弃升级分支，回农场浇水收炉后转 Forest 钓鱼，不再重试 upgrade_tool。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `goto_location`（location="Farm"）
7. `water_crops`
8. `collect_machines`
9. `sleep`
- **14:30** Town ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：e193e64b64804105a0302da03af938a4
  - 耗时：0.344 秒 / 游戏 0 分钟
- **14:30** Town ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：9c8fc5b9ab48454f9112a02b23b34685
  - 耗时：17.344 秒 / 游戏 20 分钟
- **14:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：4ddafa907c3c4ce890cc2d3692e72822
  - 耗时：66.578 秒 / 游戏 80 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **16:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 3 (Green Algae, Tiger Trout, Lingcod), 1 got away
  - 执行状态：SUCCESS · 操作编号：93ecbff9fc114a81acbea8a30990938b
  - 耗时：103.313 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Tiger Trout
- **17:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 5 (Perch, Pike, Chub, Lingcod, treasure: Deluxe Bait)
  - 执行状态：SUCCESS · 操作编号：3bbd415d70dc4f70a7c43b4f6375629f
  - 耗时：100.735 秒 / 游戏 70 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Lingcod
- **18:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：edc045191c7b41bcae97013f7b69a263
  - 耗时：15.265 秒 / 游戏 20 分钟
- **19:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：64185d5caa3347eab393f7e49e5779c9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **19:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：5b88d94d8ccf470b99622eae56ef4082
  - 耗时：0.312 秒 / 游戏 0 分钟
- **19:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：5b309b4958424971a9a33fa4ed973cc3
  - 耗时：23.563 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：52091 → 52221（+130g）
- 出货估值：130g　动作：30 个　失败：4 个
- 模型调用：4 次　tokens：50738
- 有效动作率：0.6897　空转：7　熔断跳过：0
- 失败耗时：45.609 秒 / 游戏 60 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）; 钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵

## 🧠 夜间复盘
昨天主线（铁锭→钢锄头）零推进：铁矿石只 load 了 1 次、熔炉产出 2 个铜锭，铁锭仍为 0；下矿只推进 2 层就因背包满被拒，之后转钓鱼但鱼获杂（Green Algae 占格）。升级失败是路径问题（could not reach 94,82）而非材料问题，说明 Blacksmith 入口坐标/路径不可靠。有效做法：钓鱼稳定出货 130g、熔炉铜锭持续产出、sleep 及时。今天必须把「铁锭」作为唯一硬指标，下矿前先清背包到 ≥8 格，并改用电梯直达 75 层拿铁矿石。

**新教训：**
- upgrade_tool 返回 could not reach (94,82); stopped at (40,57) 说明 Blacksmith 入口坐标不可达，不是材料问题：升级前应先确认能走到 Blacksmith 门口，走不到就当天跳过升级，不要重试或换坐标。
- 电梯已解锁到 79 层时，下矿拿铁矿石应优先电梯直达 75 层，而不是从 19 层爬——75 层不受食物 <5 限制，且铁矿密度更高。
- 钓鱼时 Green Algae/Trash 会占格并间接导致下矿被拒：钓鱼后立即 ship_produce 卖掉杂鱼，只留高回复鱼和献祭鱼。
- 熔炉 load 返回 busy 后当天没再 load，铁锭产出为零：两炉都在炼时应先 collect 收成品再 load，或干脆等炉空后第二天 load，不要连续调 load。
- mine 成功推进 2 层后背包满被拒，说明下矿前空格 ≥8 仍不够：下矿前应清到 ≥10 格，或每下 2 层就 store_items 一次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 5）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 52091g 充足，Iron Bar 仍为 0，差 5 锭（≈15 铁矿石 + 5 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」仍是唯一主线。

离完成还差：15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 5）**：起床 load 铁矿石 → 清背包到 ≥8 格 → 电梯直达 75 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收锭 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 6）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续补铁锭。
- **后天（冬 7）**：洒水器落地 + 冬季种子/茶苗，为春 1 做准备。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：load 铁矿石**（不是 collect）。若背包有 Iron Ore 且有空炉 → `load_machines` 1 次，**必须在 12:00 前完成**。返回 busy/no empty 即当天永久跳过 load，不重试。
2. **清背包到空格 ≥8（最高优先，先于一切下矿/采集）**：`ship_produce` 显式卖鱼组（Green Algae、Trash、Broken Glasses、Smallmouth Bass、River Jelly、Joja Cola、Pike、Perch 等非献祭鱼）+ 杂项（多余 Copper Bar、Sap、Bone Fragment、Cobblestone Path）。卖完**立即读背包验证空格 ≥8**；不足再卖一次小堆；仍不足则当天定性钓鱼日，**物理删除 mine 分支**。
3. **补食物到 ≥3**：goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper/Broken Glasses 立即 ship_produce 卖掉，别占格。**食物 <3 时禁止下 20 层以下；食物 <5 时禁止下 40 层以下。**
4. **下矿（仅当空格 ≥8 且食物 ≥3）**：goto Mine 前显式读背包确认两项。**优先电梯直达 75 层**（已有电梯，不受食物 <5 限制），`mine` 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 `fight` 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
5. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
6. **回农场 collect 收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。load 与 collect 之间必须隔 ≥2 小时游戏时间。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过。** 一次只升一件。**若 goto Blacksmith 或 upgrade_tool 返回 could not reach，当天永久跳过升级，不重试、不换坐标。**
8. **craft 洒水器并落地**：条件已满足（Copper Bar 32、Iron Bar 0-1，够做 1 个）。craft 后 `place` 必须带 `x`、`y` 参数（先读分区空位坐标）；place 返回「分区无空位」或「missing arguments」即当天永久跳过 place，洒水器存箱子。**craft 固定在清背包后第 2 个动作，与下矿成败无关。**
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间；主活动做完直接 sleep 或转钓鱼。**

## 规则
- **清背包绝对优先于下矿**：昨天 mine 因空格不足被拒。ship_produce 卖 ≥3 组后必须读背包验证空格 ≥8，验证通过前不得出现任何其他动作（含 mine/forage）。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **熔炉时序硬规则**：起床先 load 再 collect；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **craft 洒水器排第 8**：条件已满足，清背包后立即 craft，不能等「有空再做」。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **食物 ≥3 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <8 则物理删除 mine 分支。
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
2. 清背包：ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
3. **食物补到 ≥3**（Forest 河边钓鱼吃鱼）
4. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥8、食物 ≥3 才下，≤2 次 mine，每次 ≤5 层，超时即停）
5. mine 成功一次后 store_items 腾格
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
8. craft 洒水器（条件已满足，必须今天做）+ place（带 x,y；无空位即跳过）
9. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
10. 浇水（水壶在背包时）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主线（铁锭→钢锄头）零推进：铁矿石只 load 了 1 次、熔炉产出 2 个铜锭，铁锭仍为 0；下矿只推进 2 层就因背包满被拒，之后转钓鱼但鱼获杂（Green Algae 占格）。升级失败是路径问题（could not reach 94,82）而非材料问题，说明 Blacksmith 入口坐标/路径不可靠。有效做法：钓鱼稳定出货 130g、熔炉铜锭持续产出、sleep 及时。今天必须把「铁锭」作为唯一硬指标，下矿前先清背包到 ≥8 格，并改用电梯直达 75 层拿铁矿石。
- 06:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:30 动作 `upgrade_tool` 失败 @ Farm — could not reach (94,82); stopped at (40,57) 〔自动〕
- 19:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 铁锭全天零产出，钢锄头升级连续多天卡住 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy；collect_machines -> FAIL: no machine has finished output（做不了：钢锄头差 5 铁锭无法升级，洒水器也因缺 Iron Bar 无法 craft） 〔复盘〕
- 背包空格不足导致下矿被拒，只推进 2 层 @ Mine 入口 / 35-37 层 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：下矿推进 0 层，铁矿石和煤没拿到） 〔复盘〕
- 升级工具时走不到 Blacksmith 目标坐标 @ Blacksmith (94,82) — upgrade_tool -> FAIL: could not reach (94,82); stopped at (40,57)（做不了：即使材料够也无法升级，需先确认可达路径） 〔复盘〕
- 钓鱼鱼获混入 Green Algae/Trash 占格 @ Forest 河边 — fished: caught 4 (Perch, Green Algae, Green Algae, Green Algae)（做不了：背包更快满，间接导致下矿被拒） 〔复盘〕
- 熔炉/箱子路径被挡，collect 和 store_items 到不了目标坐标 @ Farm (41,8) 与 (53,8) — collect_machines -> could not reach (40,9); stopped at (41,8)；store_items -> could not reach (74,16); stopped at (53,8)（做不了：收不到铁锭、矿石无法入库，背包持续满） 〔复盘〕
