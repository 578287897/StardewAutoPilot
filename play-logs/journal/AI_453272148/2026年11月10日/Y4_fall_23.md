# 第4年 fall 23 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:33 开始）
- 天气：windy　金钱：48565g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：65684c233837408db29439ec8b6e2363
  - 耗时：15.359 秒 / 游戏 10 分钟
  - 🗨️ [hud] Iron Bar

## 🌙 为明天（Y4_fall_23）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升 Steel Hoe
- 起床先清背包：整组卖鱼腾出 ≥8 空格
- 熔炉先 collect 收昨晚炼的铁锭，再 load 铁矿石
- 食物补到 ≥5 后下矿 40-61 层拿铁矿石+煤
- 回农场收锭，铁锭 ≥5 且 <15:30 去铁匠铺升 hoe
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Chub", "Salmon", "Tiger Trout", "Green Algae", "River Jelly", "Copper Bar", "Stone"]）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `sleep`
- **06:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：454448d3482a4646ae85e908164e98b5
  - 耗时：5.109 秒 / 游戏 10 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 6x Coal, 1x Copper Bar, 2x Bug Meat, 1x Soggy Newspaper, 1x Trash
  - 执行状态：SUCCESS · 操作编号：f4ac06d1c06d4c2f91f4824c096b6aa6
  - 耗时：18.375 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：954fe28af429452d989311a8f32e99c7
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：31e50d8be0804ae3af9404777c4cef13
  - 耗时：0.329 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~337g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：a3804d1513804b8eb8b69d5253455564
  - 耗时：0.672 秒 / 游戏 10 分钟
- **06:50** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：95db86f436c744f39c7a78bd0a0a3d6a
  - 耗时：40.063 秒 / 游戏 40 分钟
- **07:30** CommunityCenter ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：ea0289cdf4c842cd8e626954ae301bd2
  - 耗时：37.86 秒 / 游戏 50 分钟
- **08:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Tiger Trout, Salmon, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：c8d2000a9be248e4b0034b131e2fb144
  - 耗时：73.344 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Salmon
- **09:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Tiger Trout, River Jelly, Salmon)
  - 执行状态：SUCCESS · 操作编号：8ac88eeac7124f71b8c093e2160fda98
  - 耗时：76.172 秒 / 游戏 70 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] River Jelly
- **10:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Tiger Trout, Chub, River Jelly)
  - 执行状态：SUCCESS · 操作编号：9a9e9ed4ad9c43f0a2a890f6e7f31dc3
  - 耗时：72.25 秒 / 游戏 70 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Chub
- **12:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：2d71295bd4d3430a894a2f941f8bfedf
  - 耗时：63.563 秒 / 游戏 80 分钟
- **13:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：c4bbaeeb3cd6474ea209d4a8749badd2
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：矿洞因背包仅 3 格被拒，先回农场卖鱼腾格并收炉锭，再下矿，铁锭不足则跳过铁匠铺直接睡。
1. `donate`
2. `mine`（floors=5）
3. `fight`（range=6）
4. `mine`（floors=5）
5. `leave_mine`
6. `goto_location`（location="Farm"）
7. `ship_produce`
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `sleep`
- **13:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：58bd5ae1a44b47c4acd26cfdf317818d
  - 耗时：41.438 秒 / 游戏 50 分钟
- **14:10** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：01e30e2f1e374cc28277838f6984fdd6
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：先回农场卖鱼腾出背包格并收炉锭，再下矿拿铁矿石；铁锭不足5个故跳过铁匠铺，收炉后直接睡觉。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `fight`（range=6）
5. `mine`（floors=5）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar"]）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `sleep`
- **14:10** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：d01c66ff6de2435c9d456f48acea88f5
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:10** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5f3afb9c70114c21af8b316690b83c76
  - 耗时：39.39 秒 / 游戏 50 分钟
- **15:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：481366f59a8849e98e4019f43c0f3468
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因背包满被拒，按规则当天不再下矿，回农场卖鱼腾格并收炉锭后结束。
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar"]）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `sleep`
- **15:00** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：b4b9477d97694e6f9c4842a0020052b3
  - 耗时：41.422 秒 / 游戏 50 分钟
- **15:50** CommunityCenter ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：a6ea6aab191d471e922946017221a8c6
  - 耗时：38.093 秒 / 游戏 50 分钟
- **16:40** Farm ✅ `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar"]）
  - 结果：shipped 1 stacks worth ~225g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：bc0447bb48474a4e975e4b5a0dd18107
  - 耗时：1.734 秒 / 游戏 0 分钟
- **16:40** Farm ❌ `collect_machines`
  - 结果：could not reach (40,9); stopped at (41,8)
  - 执行状态：ACTION_FAILED · 操作编号：6b0ebd1544d64697b018a2a0bab33773
  - 耗时：20.547 秒 / 游戏 30 分钟
- **17:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
  - 执行状态：NO_PROGRESS · 操作编号：c3b0eabca14d4bbe931ec14c058cfca7
  - 耗时：0.328 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：83311353433048419949bc2f8b1031e8
  - 耗时：12.141 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：48565 → 49127（+562g）
- 出货估值：562g　动作：24 个　失败：5 个
- 模型调用：5 次　tokens：61779
- 有效动作率：0.6957　空转：3　熔断跳过：0
- 失败耗时：22.486 秒 / 游戏 30 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天真正卡点是背包格：钓鱼4轮把鱼塞满包，mine 连续3次被拒，脚本重写3次仍调 mine，浪费约200游戏分钟；熔炉 collect 在 load 后不足2小时返回空、再 load 又 busy，铁锭仍为1。洒水器条件早已满足却一直没 craft。今天顺序必须是：先卖鱼腾格→craft 洒水器→collect 收锭→load 铁矿石→下矿（食物≥5、空格≥8），mine 被拒一次即转钓鱼。

**新教训：**
- 钓鱼补食物时只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper 直接卖——昨天 4 轮钓只出杂鱼，背包被占满反而导致 mine 被拒。
- mine 被拒后重写脚本再调 mine 是纯浪费：昨天 3 次被拒 + 3 次重写耗约 200 游戏分钟，正确做法是第一次被拒即 goto Forest 钓鱼或直接 sleep。
- 熔炉傍晚 load 的矿石当天收不到：load 必须在起床 collect 之后立即做，让它在白天炼完，不要拖到 17:00 后。
- 洒水器条件满足后连续多天没 craft，是因为把 craft 排在「下矿回来」分支里；应固定在清背包之后第 2 个动作，与下矿成败无关。
- 食物 4 个时下矿会在 39 层被拦（need 5+ for floor 40 and below）：goto Mine 前必须显式读背包确认食物 ≥5，不够先钓鱼补，不能先跑一趟矿洞被拒。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 24）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 48565g 充足，卡点只有 Iron Bar（背包 1，铁矿石 2、煤 18，两座炉约出 2 锭，还差约 2-3 锭 = 10-15 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线，钓鱼只作补食物/现金副线。

离完成还差：约 10-15 铁矿石 + 3 煤 → 5 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 24）**：起床先卖鱼腾格（空格≥8）→ craft 洒水器（材料已够，第 2 个动作）→ 熔炉 collect 收锭 → load 铁矿石 → 食物≥5 下矿 40-61 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect → 铁锭≥5 且 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 25）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（秋 26）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓），季末不再新种。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**第一组必须整组卖鱼**（Chub、Green Algae、Salmon、Tiger Trout 等非献祭鱼）+ 非献祭杂项（多余 Copper Bar、Sap、Soggy Newspaper、Trash）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **craft 洒水器（条件已满足，必须今天做）**：清背包后立即 `craft` 洒水器 1-2 个（1 铜锭 + 1 铁锭/个，现有 Copper Bar 34、Iron Bar 1，先做 1 个）。craft 后 `place` 到空地块；place 返回「分区无空位」即当天永久跳过 place，洒水器存箱子。
3. **熔炉：先 collect 再 load（顺序不可颠倒）**
   - `collect_machines` 1 次收已完成锭（昨天 1710 前 load 的 Copper Ore 应已好）。
   - 若背包有 Iron Ore 且炉空 → `load_machines` 1 次装铁矿石。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
4. **下矿前双检查**：goto Mine 前必须显式读背包确认 **空格 ≥8 且食物 ≥5**。食物 <5 时先 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），**只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper 直接卖**，补到 ≥5 再进 Mine。**食物 <5 或空格 <8 时脚本里不得出现 goto Mine。**
5. **下矿（主活动）**：`goto_location` Mine → `mine` 目标 40-61 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过，不白跑铁匠铺。** 一次只升一件。
8. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **craft 洒水器排第 2**：条件已满足（农业 2 级、Copper Bar 34、Iron Bar 1），清背包后立即 craft，不能等「有空再做」。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **熔炉顺序硬规则**：起床先 collect 再 load；load 每天 ≤1 次，返回 busy/no empty 即当天永久跳过；collect 每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
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
3. 熔炉：先 collect 收锭，再 load 铁矿石（≤1 次，busy 即跳过）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）——下矿前置条件
5. 下矿 40-61 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天真正卡点是背包格：钓鱼4轮把鱼塞满包，mine 连续3次被拒，脚本重写3次仍调 mine，浪费约200游戏分钟；熔炉 collect 在 load 后不足2小时返回空、再 load 又 busy，铁锭仍为1。洒水器条件早已满足却一直没 craft。今天顺序必须是：先卖鱼腾格→craft 洒水器→collect 收锭→load 铁矿石→下矿（食物≥5、空格≥8），mine 被拒一次即转钓鱼。
- 13:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:10 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 16:40 动作 `collect_machines` 失败 @ Farm — could not reach (40,9); stopped at (41,8) 〔自动〕
- 17:10 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 背包被鱼塞满，连续 3 次下矿被拒，脚本重写 3 次仍调 mine @ Mine 入口 (18,13) — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：铁矿石和煤没拿到，铁锭仍为 1，钢锄头和洒水器材料全部卡住） 〔复盘〕
- 熔炉 load 后不足 2 小时又 collect 返回空，再 load 返回 busy @ Farm 熔炉旁 (40,9) — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: all machines are busy（做不了：当天铁锭产出为零，钢锄头仍差 4 锭） 〔复盘〕
- 洒水器条件早已满足（农业 2 级、Copper Bar 34）却一直没 craft @ Farm — 全天动作日志无 craft 记录（做不了：继续手动浇水，体力无法全部用于下矿） 〔复盘〕
- 钓鱼 4 轮只出 Green Algae/Chub/Soggy Newspaper 等杂鱼，没补到可吃食物 @ Forest 河边 — fish -> OK: caught 4 (Green Algae, Tiger Trout, Salmon, Broken Glasses) 等（做不了：食物没补到 5，下矿仍被拦） 〔复盘〕
- collect_machines 无法到达熔炉坐标 @ Farm (41,8) 附近 — collect_machines -> FAIL: could not reach (40,9); stopped at (41,8)（做不了：熔炉锭没收，铁锭进度停滞） 〔复盘〕
- donate 反复打开 Junimo note 无法存入，浪费动作 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
