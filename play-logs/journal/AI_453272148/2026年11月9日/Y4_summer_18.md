# 第4年 summer 18 日 — AI 游玩日志
（写入日期：2026年11月9日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（23:51 开始）
- 天气：storm　金钱：21821g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：cae95261b3f041bf98d803e289f3b45d
  - 耗时：3.235 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：35c43837d9274ecbb50b3be7be6a0c47
  - 耗时：8.438 秒 / 游戏 10 分钟

## 🌙 为明天（Y4_summer_18）准备的脚本
- 里程碑：工具按档升级（钢锄头，差5铁锭）——今天主活动=下矿40-59层拿铁矿石+煤
- 起床先彻底腾背包：Stone 存到1组、Cobblestone Path 全存、Bamboo Pole/Rice Shoot/Coffee Bean/Green Algae/Lost Axe/Cherry Bomb 全存，验证≥8空格
- 食物<5 先 Forest 河边钓鱼补到≥5（鱼留着吃）
- 空格≥8且食物≥5 才下矿，跳过18层infested，≤2次mine，生命<50%或食物=0立即出矿
- 回农场先 collect_machines 确认炉空，再 load_machines 装铁矿石（只试1次）
- 剩余洒水器落地（place 失败1次换空地再试1次）
- 水壶在背包则 water_crops 1次
- 22:00 前 sleep，禁止 wait 填充
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Green Algae", "Lost Axe", "Cherry Bomb", "Mystery Box"]）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `place`（item="Sprinkler"）
14. `water_crops`
15. `sleep`
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Bug Meat, 2x Slime, 1x Coal
  - 执行状态：SUCCESS · 操作编号：f0889010aa3d445d8bd77faa1912e791
  - 耗时：13.25 秒 / 游戏 20 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：f24f101f79e04b6eb6835ef82395a997
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：541949d1f359478e98560aac7559f3b5
  - 耗时：0.265 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~155g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：80fd179e746d4db68721ac6cc40af9df
  - 耗时：0.641 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：91f5330f8abd4bca93c573b93396bc84
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师信未到必失败，直接跳过该分支，保留原路线：存 Stone/Cobblestone Path 腾格→Forest 钓鱼补食物→下矿拿
1. `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Green Algae", "Lost Axe", "Cherry Bomb", "Mystery Box"]）
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `place`（item="Sprinkler"）
12. `water_crops`
13. `sleep`
- **06:30** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Green Algae", "Lost Axe", "Cherry Bomb", "Mystery Box"]）
  - 结果：stored in chest at (74,15): 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：23f5cd52daac4daabfbe495615c3a443
  - 耗时：0.281 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：a5e7e88a97114063930f82cf9f493995
  - 耗时：25.188 秒 / 游戏 30 分钟
- **07:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Pike, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：9f42585526864a07a757d88bb5d54cc7
  - 耗时：102.344 秒 / 游戏 110 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **08:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Driftwood, Pike, Pike)
  - 执行状态：SUCCESS · 操作编号：d6b2a973d20f4ce1937da1219fac4650
  - 耗时：62.797 秒 / 游戏 60 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Pike
- **09:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e738d8faaed542c387b3add63445ff53
  - 耗时：74.156 秒 / 游戏 90 分钟
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f844d9cda21e4f92a8acdd9ef7731480
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包空格不足被拒，先按策略把 Stone/Cobblestone Path 等大件存箱腾出≥5格，再继续原路线下矿，其余步骤保持不变。
1. `mine`（floors=5）
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Driftwood"]）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `place`（item="Sprinkler"）
7. `water_crops`
8. `sleep`
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4033d551b53b415bbeac3d73d86ebcd7
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因空格不足被拒，先回农场彻底存 Stone 与 Cobblestone Path 腾出空格，再下矿，其余路线保留。
1. `mine`（floors=5）
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Driftwood"]）
4. `store_items`（items=["Stone"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `place`（item="Sprinkler"）
8. `water_crops`
9. `sleep`
- **11:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：caa739fd34d6468199663e19973bc14f
  - 耗时：0.297 秒 / 游戏 0 分钟
- **11:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：cbebd992925f4b32be002af6f1a667f8
  - 耗时：33.625 秒 / 游戏 50 分钟
- **12:10** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path", "Bamboo Pole", "Rice Shoot", "Coffee Bean", "Lost Axe", "Cherry Bomb", "Mystery Box", "Driftwood"]）
  - 结果：stored in chest at (74,15): 1x Driftwood
  - 执行状态：SUCCESS · 操作编号：4a2c478304b64487bea79dff05d69b70
  - 耗时：15.0 秒 / 游戏 20 分钟
- **12:30** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：b8048a45b8c9498c93730e8bf86da374
  - 耗时：0.297 秒 / 游戏 0 分钟
- **12:30** Farm ✅ `collect_machines`
  - 结果：collected: Spice Berry Jelly from Preserves Jar, Copper Bar from Furnace, Spice Berry Jelly from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：e0044227c8204da88bd5eb2b79e7dd87
  - 耗时：25.25 秒 / 游戏 30 分钟
  - 🗨️ [hud] Spice Berry Jelly
  - 🗨️ [hud] Copper Bar
  - 🗨️ [hud] Spice Berry Jelly
- **13:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：9812e8da21e4403faa8eabf28faba0ed
  - 耗时：0.313 秒 / 游戏 0 分钟
- **13:00** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **13:00** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：2154b72abf7f47c0a4992680da8dc8dc
  - 耗时：0.328 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：8d05718d5dc74cb6ba42f31921262c90
  - 耗时：2.984 秒 / 游戏 0 分钟
- **13:00** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：551ab1fe241f440fa0b072f29c13e861
  - 耗时：0.329 秒 / 游戏 0 分钟
- **13:00** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：3db17e3dc7ee4ee1bb10e43262fd601c
  - 耗时：0.328 秒 / 游戏 0 分钟
- **13:00** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f0dddae179cb4918964ff371c0f7e6be
  - 耗时：0.297 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：fe852819e1dc423aa6690f9daadad05c
  - 耗时：19.813 秒 / 游戏 30 分钟
- **13:30** Forest ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：a39a32b883954aa5830eafb39f7e8b5a
  - 耗时：20.032 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **13:50** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fb14705628a64a1795a06e9f9c0caa64
  - 耗时：0.344 秒 / 游戏 0 分钟
- **13:50** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Copper Bar, 1x Coal
  - 执行状态：SUCCESS · 操作编号：ab7367750823421c837a8b9f0a738fb5
  - 耗时：15.047 秒 / 游戏 20 分钟
- **13:50** Farm ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：6aaa4d68329741f1baf43c2e63e309d5
  - 耗时：0.312 秒 / 游戏 0 分钟
- **14:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5b09248ed24b4c98993c1605a802a515
  - 耗时：8.891 秒 / 游戏 20 分钟
- **14:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **14:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4a00e7f3261f43f9898e3b820a366ba2
  - 耗时：12.656 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：21821 → 21976（+155g）
- 出货估值：155g　动作：34 个　失败：13 个
- 模型调用：5 次　tokens：62177
- 有效动作率：0.5758　空转：7　熔断跳过：0
- 失败耗时：15.315 秒 / 游戏 20 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天核心失败是清背包假成功：store_items 只存了小件，Stone 2407 和 Cobblestone Path 仍占格，导致 4 次 mine 被拒、全天零铁矿。其次熔炉忙时反复 load、donate 在 wait_letter 阶段硬试、铺路/装饰空转。有效动作是钓鱼（Pike 稳定）和收炉（铜锭已 74）。今天必须先把 Stone 压到 1 组并显式验证空格，再下矿。

**新教训：**
- store_items 一次只存小件（Coal/Green Algae/Driftwood）不解决空格问题：应把 Stone 压到 1 组、Cobblestone Path 全存作为同一次调用的首要目标，否则 mine 仍被拒。
- 熔炉忙时 load_machines 返回 no empty machine 后重试仍失败：应先 collect_machines 收炉，把 Iron Ore 留到炉空后再装，而不是在炉忙时反复 load。
- 洒水器 place 返回「规划分区无空位」时，说明分区已被占满：应先清出空地（axe/hoe）再 place，或当天放弃，不要换位置盲试。
- 钓鱼在 Forest 河边稳定产出 Pike（4 cast 约 3-4 条），是食物和现金的可靠来源：食物<5 时优先钓鱼而不是空转或 wait。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏19）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 21821g 足够，**Iron Bar 差 5，Iron Ore 仅 2、Coal 10**。这是唯一硬卡点，一切主活动服务于「拿到 5 块铁锭」。
并行前置：**洒水器 ×4**（各 1 铜锭 + 1 铁锭，铜锭 74 已够，铁锭同一瓶颈）；**钓鱼 2 级已达成**，玻璃纤维钓竿 1800g 可买但非今天优先。
接下来 3 天：
- **今天（夏19）**：起床先真清背包（Stone 压到 1 组、Cobblestone Path 全存）→ 读背包验证 ≥8 空格 → 食物<5 先 Forest 钓鱼补 → 下矿 40-59 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 后 load 铁矿石。
- **明天（夏20）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（夏21）**：钢锄头到手转钢斧；攒铁锭给洒水器。

## 每日固定流程（严格按序，失败一次即跳下一步，绝不重写脚本重跑）
1. **起床 collect_machines 1 次**：返回空当天永久跳过。
2. **真清背包（第一硬前置）**：一次 `store_items` 把 **Stone 存到只剩 1 组（≤999）**、Cobblestone Path 全部、Bamboo Pole、Rice Shoot、Coffee Bean、Green Algae、Lost Axe、Cherry Bomb、Driftwood、Geode 全存箱。**存完必须再读背包确认空格 ≥8**；不足则第二次只存 Stone 剩余；仍不足则放弃下矿转钓鱼。清完立刻 goto Mine，不先跑去别处。
3. **补食物到 ≥5（第二硬前置）**：食物<5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格≥8、食物≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。**从 19 层以下开始，跳过 18 层 infested 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉子已空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金<700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **腾背包是今天第一动作**：昨天 4 次 mine 被拒全是空格不足，而 Stone 2407 块、Cobblestone Path 24 块是最大占格源。起床第一件事就是存这两样，存完读背包验证 ≥8 空格。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认 ≥8 空格；不足则第二次只存 Stone（2407 块占格最多），仍不足则放弃下矿转钓鱼。
- **食物≥5 才下矿**：食物=2 时下矿会停在 39 层，铁矿石零产出。食物<5 先钓鱼 2 轮。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天≤2 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。18 层已确认 infested，直接从 19 层以下开始。
- **upgrade_tool 必须带 tool 参数**：调用时传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **build_road / decorate 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败；农场未整理前完全禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 真清背包到 ≥8 空格并验证（Stone 存到 1 组、Cobblestone Path 全存，清完立刻去矿洞）
3. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
4. 下矿 40-59 层拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停，跳过 18 层）
5. 回农场先 collect 再 load（炉空且背包有 Iron Ore 才装，只试 1 次）
6. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是清背包假成功：store_items 只存了小件，Stone 2407 和 Cobblestone Path 仍占格，导致 4 次 mine 被拒、全天零铁矿。其次熔炉忙时反复 load、donate 在 wait_letter 阶段硬试、铺路/装饰空转。有效动作是钓鱼（Pike 稳定）和收炉（铜锭已 74）。今天必须先把 Stone 压到 1 组并显式验证空格，再下矿。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:30 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:00 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 13:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 13:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 13:00 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功：store_items 只存了 Coal/Green Algae/Driftwood 等小件，Stone 2407 块和 Cobblestone Path 24 块仍占格，随后 4 次 mine 全被拒 @ Farm 箱子旁 / Mine 入口 — store_items -> OK: stored 1x Green Algae / 1x Driftwood；mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 3 次（1/5、1/8、1/9 等），每次重写又调 mine 再失败 @ Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining（重复 4 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything / no empty machine accepts that, and the rest are busy（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- donate 在 wait_letter 阶段仍被调用两次 @ Farm — donate -> FAIL: can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心捐赠进度无法推进（需等巫师来信）） 〔复盘〕
- build_road 铺 24 块 Cobblestone Path 全被树/作物挡住，0 块铺成；decorate 也无可用材料 @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate -> FAIL: 今天没有能做的装饰（做不了：铺路零进展，且 Cobblestone Path 继续占背包格，加剧空格不足） 〔复盘〕
- 洒水器 place 失败：规划分区已无空位 @ Farm 农田分区 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：剩余 2 个洒水器无法落地，手动浇水负担未解除） 〔复盘〕
- 主活动（下矿）失败后没有立即转钓鱼，而是继续空转收尾动作 @ Farm / Forest — 日志显示 13:00-14:30 连续无效动作（load 失败、donate 失败、mine 失败、build_road 失败、decorate 失败）（做不了：下午时段未转化为钓鱼收入/食物，全天有效动作仅 9/22） 〔复盘〕
