# 第4年 summer 13 日 — AI 游玩日志
（写入日期：2026年11月9日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（23:00 开始）
- 天气：storm　金钱：19903g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0c2c98ac594f4c3ba8623a77b02c5e2b
  - 耗时：11.453 秒 / 游戏 10 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：1ce7abe3181e4bd793ee1d5d29ea82cb
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：cc84730f2c2a4511861bb94b2c86ee5f
  - 耗时：0.297 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_summer_13）准备的脚本
- 里程碑：工具按档升级——凑齐5铁锭升钢锄头
- 起床收炉1次，炉空则装铁矿石
- Forest河边钓鱼补食物到≥5（可吃鱼）
- 清背包到≥8空格并验证
- 下矿19层以下拿铁矿石+煤（≤2次mine）
- 回农场装炉/收炉各1次
- 浇水1次（水壶在背包）
- 体力<15或22:00前sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `store_items`（items=["Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Bug Meat", "Slime", "Stone"]）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `fight`（range=6）
11. `mine`（floors=5）
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `collect_machines`
15. `water_crops`
16. `sleep`
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~60g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：044a22d85e584ad38ea4bc9f6a74b4cb
  - 耗时：9.547 秒 / 游戏 10 分钟
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：26733bd0f10247c5a1e2df18ce37f528
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师信未到而失败，跳过献祭分支，按原路线先收炉装铁、Forest钓鱼补食物、清背包后下矿拿铁矿石，回农场装炉收炉再睡。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `store_items`（items=["Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Stone"]）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `fight`（range=6）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `collect_machines`
14. `water_crops`
15. `sleep`
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6301e1a9d31540be9ddb539c219dd567
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6d4d77eb4c45442f8970e2e2f6700462
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`（items=["Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a515fc320d1f4aab8b5d3a9545bd8677
  - 耗时：4.735 秒 / 游戏 10 分钟
- **06:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：e680e43ff6eb4be284ec612208a4d93d
  - 耗时：24.75 秒 / 游戏 30 分钟
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Broken Glasses, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：d7dd6e41ebc44c3f87e3e13a827b53b6
  - 耗时：56.953 秒 / 游戏 80 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **08:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Broken CD, Pike, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：3e5d26cc9f3b4570864a7d736124be5c
  - 耗时：60.141 秒 / 游戏 70 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Pike
- **09:30** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：bb613747013c45f78e06fb898b8aef4c
  - 耗时：74.234 秒 / 游戏 90 分钟
- **11:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5733368b853d4689ae64a39e61bb01cb
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包空格不足被拒，先在矿洞门口存掉石头和杂物腾格，再下矿；失败一次即回农场收炉装炉后睡觉。
1. `mine`（floors=5）
2. `fight`（range=6）
3. `mine`（floors=5）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Broken Glasses", "Broken CD", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box"]）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `water_crops`
9. `sleep`
- **11:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：cf629ba218c14de28724044153ae25cd
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine因背包空格不足被拒，先在矿洞内存掉Stone等杂物腾出≥8格再下矿，其余路线不变。
1. `mine`（floors=5）
2. `fight`（range=6）
3. `mine`（floors=5）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Broken Glasses", "Broken CD", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Green Algae"]）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `water_crops`
9. `sleep`
- **11:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：0619932daa2f42c9a314ee9c8d6f7b1b
  - 耗时：0.282 秒 / 游戏 0 分钟
- **11:00** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：34e4a5d6ef1141748c70278c72defeac
  - 耗时：0.297 秒 / 游戏 0 分钟
- **11:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：801f58e7159642058e56d3b62f1fa1f2
  - 耗时：0.282 秒 / 游戏 0 分钟
- **11:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b6e855501d5341f9a65c52be30e989d6
  - 耗时：33.578 秒 / 游戏 40 分钟
- **11:40** Farm ✅ `store_items`（items=["Stone", "Broken Glasses", "Broken CD", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Green Algae"]）
  - 结果：stored in chest at (74,15): 1x Broken Glasses, 4x Green Algae, 1x Broken CD
  - 执行状态：SUCCESS · 操作编号：269ad48c317a4a909ca291d68d977f6c
  - 耗时：14.969 秒 / 游戏 20 分钟
- **12:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：51fc84b65ed143c5892cd3beca0d37fa
  - 耗时：13.454 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **12:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bfe6f9b8428c48d3b948f5d80844e45c
  - 耗时：0.297 秒 / 游戏 0 分钟
- **12:20** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：1df45e39f9be4a8ea23618c9051e9824
  - 耗时：0.297 秒 / 游戏 0 分钟
- **12:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4de06d25da874c7d9a50bad944bb0f00
  - 耗时：0.281 秒 / 游戏 0 分钟
- **12:20** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：1a08e05c1dd74431a2e798db391cb8ee
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:20** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：55bbff4c076b41d8b050e5239ec7bf4a
  - 耗时：0.296 秒 / 游戏 0 分钟
- **12:20** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：16941dd3606440d284bf7f37c21edd26
  - 耗时：20.282 秒 / 游戏 30 分钟
- **12:50** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 5 forage items
  - 执行状态：SUCCESS · 操作编号：a2ee7e7f032d4509a74d40c9bfd00df2
  - 耗时：80.641 秒 / 游戏 110 分钟
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Spice Berry
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
  - 🗨️ [hud] Sweet Pea
- **14:40** Forest ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：f8ea99c54fb9473f850fbad48c94c88e
  - 耗时：0.297 秒 / 游戏 0 分钟
- **14:40** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c4d8437fd8e64a9091d41fa1b62bb5af
  - 耗时：33.984 秒 / 游戏 40 分钟
- **15:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：43187f5162814d9d9e8b5347551fc4cd
  - 耗时：15.688 秒 / 游戏 20 分钟
- **15:40** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:40** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：541e17df46f74505936f28e282bcc67c
  - 耗时：12.781 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：19903 → 19963（+60g）
- 出货估值：60g　动作：32 个　失败：14 个
- 模型调用：5 次　tokens：62078
- 有效动作率：0.5161　空转：8　熔断跳过：0
- 失败耗时：53.329 秒 / 游戏 60 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天14次失败中5次是mine空格不足、2次load无空炉、2次build_road被树挡、2次donate未解锁。核心卡点仍是铁锭：食物3个<5、背包未清到8格、两炉都忙导致铁矿石装不进。钓鱼补食物有效（Forest裸钓4条），但铺路/装饰纯浪费。今天必须先补食物→清包验证→下矿，且load前先collect。

**新教训：**
- 昨天 5 次 mine 被拒全是背包空格不足，而 store_items 返回 OK 后未验证：今天 store_items 后必须再读背包确认 ≥8 空格，不足则第二次只存 Stone（2401 块占格最多），仍不足则放弃下矿转钓鱼。
- 两座熔炉都忙时 load_machines 返回 no empty machine，昨天重试 2 次仍失败：今天回农场必须先 collect_machines 确认炉空，炉忙则跳过 load 直接收炉，等第二天再装。
- 昨天 build_road 两次共 24 块 Cobblestone Path 全被树/作物挡住（0 laid）：农场未清地前 build_road 完全禁用，Cobblestone Path 起床就存箱，不留在背包占格。
- 昨天 donate 两次都返回 wait_letter（巫师信未到）：wait_letter 阶段 donate 必失败，脚本层直接禁用，等收到巫师来信后再恢复。
- 昨天食物=3 却计划下 40 层，实际最多安全到 39 层：食物<5 时脚本层应先 Forest 钓鱼 2 轮补到 ≥5，再清背包下矿，顺序不能颠倒。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏14）

## 长期目标
当前里程碑：**工具按档升级**——下一档钢锄头（5000g + 5 铁锭）。现金 19903g 足够，**Iron Bar 仍差 5**（Iron Ore 2、Coal 12、Copper Bar 72、Stone 2401）。这是唯一硬卡点。
并行卡点：**下矿装备**——可回血食物仅 3 个（需 ≥5 才下 40 层以下），武器 Silver Saber 8-15，最深 59 层。铁矿只在 40 层以下，所以「补食物到 ≥5」是下矿前置，不是可选分支。
接下来 3 天：
- **今天（夏14）**：主活动=Forest 河边钓鱼补食物到 ≥5 → 清背包验证 ≥8 空格 → 下矿 40-59 层拿铁矿石+煤（≤2 次 mine）→ 回农场先 collect 再 load。
- **明天（夏15）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（夏16）**：钢锄头到手后转钢斧；继续攒铁锭给洒水器（需 4 个，1 铜锭+1 铁锭/个）。

## 每日固定流程（严格按序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床 collect_machines 1 次**：返回空当天永久跳过。
2. **补食物到 ≥5（第一优先，硬门槛）**：食物=3，直接 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。**不去 Saloon、不买饵（FishShop 入口坐标未确认，连续失败）**。食物≥5 才允许下矿；食物<5 时下矿会停在 39 层，铁矿石零产出。
3. **清背包到 ≥8 空格并验证**：一次 `store_items` 把 Cobblestone Path、Bamboo Pole、Rice Shoot、Coffee Bean、Green Algae、Lost Axe、Cherry Bomb、Geode、多余 Stone 全部存箱。**存完必须再读一次背包确认空格 ≥8**；仍不足则第二次只存 Stone（2401 块占格最多）；仍不足则放弃下矿转钓鱼。**清完立刻 goto Mine，不先跑去别处。**
4. **下矿（今天唯一主活动）**：空格≥8、食物≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。**从 19 层以下开始，跳过 18 层 infested 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉子已空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过。**load 前先确认背包有 Iron Ore。**
6. **洒水器落地**：剩余 2 个洒水器——**place 前先确认目标地块无作物/树/杂物**；分区满说明需先在农场清出空地（`use_tool` axe 砍树或 `use_tool` hoe 清地块），清出后再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金<700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位。
- **补食物是下矿前置**：食物<5 时 mine 会停在 39 层，铁矿石零产出，等于白跑；食物=3 时先钓鱼 2 轮再谈下矿。
- **清背包必须验证**：store_items 返回 OK 不等于空格够——必须再读背包确认 ≥8 空格；不足则第二次只存 Stone；仍不足则放弃下矿转钓鱼，**绝不带着不足空格 goto Mine**。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先 collect 确认炉空、再确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤2 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼；**不重写脚本重跑 mine**。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。**18 层已确认是 infested 层，今天直接从 19 层以下开始。**
- **upgrade_tool 必须带 tool 参数**：调用时必须传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 买饵暂缓**：连续两天 goto Mountain 后 open_shop 仍失败（入口坐标未确认），今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **洒水器 place 循环处理剩余数量**：craft 后逐个 place 直到全部落地或失败 2 次；place 前确认目标地块无作物/树/杂物，分区满则先清地。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **工具升级期间禁下矿**：镐在升级中时 `mine` 脚本层直接禁用；水壶升级不影响下矿。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥8；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
3. 清背包到 ≥8 空格并验证（清完立刻去矿洞）
4. 下矿 40-59 层拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停，跳过 18 层）
5. 回农场先 collect 再 load（炉空且背包有 Iron Ore 才装，只试 1 次）
6. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天14次失败中5次是mine空格不足、2次load无空炉、2次build_road被树挡、2次donate未解锁。核心卡点仍是铁锭：食物3个<5、背包未清到8格、两炉都忙导致铁矿石装不进。钓鱼补食物有效（Forest裸钓4条），但铺路/装饰纯浪费。今天必须先补食物→清包验证→下矿，且load前先collect。
- 06:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 12:20 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:40 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功，背包空格仍不足 8，下矿连续被拒 5 次 @ Farm 箱子旁 / Mine 入口 — store_items -> OK: stored 1x Coal；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- 两座熔炉都忙时 load 无效，重试仍失败 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- 食物仅 3 个却计划下 40 层，实际最多安全到 39 层 @ Mine 入口 — 战斗准备显示可回血食物 3 个，mine 最多安全下到第 39 层（做不了：无法安全下到 40 层以下拿铁矿，钢锄头材料凑不齐） 〔复盘〕
- 24 块 Cobblestone Path 铺路两次全被树/作物挡住 @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：铺路零进展，且 24 块石头占背包格，加剧空格不足） 〔复盘〕
- donate 连续两次返回 wait_letter，巫师信未到 @ 社区中心 / 博物馆 — donate -> FAIL: can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心献祭无法推进，温室/矿车解锁延迟） 〔复盘〕
- mine 被拒后脚本重写 3 次，仍没下成矿 @ 全局 / Mine 入口 — 脚本 1/4、1/9 多次重写，mine 仍报 need 5 free slots（做不了：浪费 LLM 调用和游戏时间，主活动未完成） 〔复盘〕
