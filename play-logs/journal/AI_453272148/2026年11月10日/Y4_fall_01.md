# 第4年 fall 1 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（01:30 开始）
- 天气：sunny　金钱：26852g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_fall_01）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），今天下矿拿铁矿石和煤
- 起床先收熔炉（1次，空则跳过）
- 真清背包：先 ship_produce 卖石头腾格，再单物品 store Stone，验证空格≥8
- 食物≥5 才下矿；不够先去 Forest 钓鱼补
- 下矿 40-59 层拿铁矿石+煤（≤2 次 mine，被拒即转钓鱼）
- 回农场先 collect 再 load（炉空且有铁矿才装，只试1次）
- 剩余洒水器落地（失败即放弃）
- 浇水（水壶在背包时）
1. `donate`
2. `collect_machines`
3. `goto_location`（location="Farm"）
4. `ship_produce`（except=["Sweet Pea", "Green Algae", "River Jelly", "Coffee Bean", "Rice Shoot", "Copper Ore", "Iron Ore"]）
5. `store_items`（items=["Stone"]）
6. `store_items`（items=["Cobblestone Path"]）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `fight`（range=6）
10. `mine`（floors=5）
11. `leave_mine`
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `load_machines`
15. `water_crops`
16. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Spice Berry Jelly from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：16299469ce324b979e029483f32e80d2
  - 耗时：16.828 秒 / 游戏 20 分钟
  - 🗨️ [hud] Spice Berry Jelly
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：60dffdb70907493c9d8961db6acc4ea4
  - 耗时：0.281 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：1392c0aeeb1e4f2bb860ce15ba791f81
  - 耗时：18.093 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：92edb786591740379acfe993562bcf2a
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：cff6442be4f84c0cb4b2d45ccb5f73d5
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~375g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：7b1feffa6824427bac45eae5d6df427f
  - 耗时：0.671 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：493cb5f283a54a4f8ee327d1f187cb4e
  - 耗时：0.265 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 在 wait_letter 阶段必失败，删掉该动作，其余按原路线：收炉→卖石头清背包→下矿拿铁→回农场收炉装炉→浇水睡觉。
1. `collect_machines`
2. `ship_produce`（except=["Sweet Pea", "Green Algae", "River Jelly", "Coffee Bean", "Rice Shoot", "Copper Ore", "Iron Ore"]）
3. `store_items`（items=["Stone"]）
4. `store_items`（items=["Cobblestone Path"]）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `fight`（range=6）
8. `mine`（floors=5）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`
13. `water_crops`
14. `sleep`
- **06:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：8784508f141148bda11c83219d3fbd6a
  - 耗时：0.281 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`（except=["Sweet Pea", "Green Algae", "River Jelly", "Coffee Bean", "Rice Shoot", "Copper Ore", "Iron Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：b85e198a956a4af5a0c577fc6f9fa9c7
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7b903b58fa4444f0a7da5420bd694b7e
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：fcfb7e86af524f5f95d75393a6c6e6bf
  - 耗时：0.282 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：d6de586f1082450a969373ea61b74ecb
  - 耗时：52.578 秒 / 游戏 70 分钟
- **07:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：1671619c64bd4e7a9e0f9758dd4c7d05
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因空格不足被拒一次，按策略当天不再调 mine，直接转 Forest 钓鱼补食物和现金，回农场收炉浇水后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **07:50** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：6013336c37a640a1a508d4e35a9bb596
  - 耗时：57.656 秒 / 游戏 70 分钟
- **09:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Chub, Chub, Chub)
  - 执行状态：SUCCESS · 操作编号：d711bcc87e1f490aaaa584e057aeb845
  - 耗时：87.953 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
- **10:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Salmon, Chub, Green Algae, Salmon)
  - 执行状态：SUCCESS · 操作编号：6130f3e780ca4970935f6fa450614222
  - 耗时：88.141 秒 / 游戏 90 分钟
  - 🗨️ [hud] Salmon
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
- **12:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, River Jelly, Tiger Trout, Chub)
  - 执行状态：SUCCESS · 操作编号：8895c50defcb4ad6a7e41466dd9d691a
  - 耗时：84.468 秒 / 游戏 80 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Tiger Trout
- **13:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：12228fe03a4d4e4f8685ecfccce445d8
  - 耗时：15.906 秒 / 游戏 20 分钟
- **13:40** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **13:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：4b2b72a768284d2b94554e595856bef8
  - 耗时：0.265 秒 / 游戏 0 分钟
- **13:40** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：4a6db08f72e746f2b9b25f3808035e2a
  - 耗时：0.313 秒 / 游戏 0 分钟
- **13:40** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f7adcb97733e43438f97e7ee3bba24a6
  - 耗时：0.297 秒 / 游戏 0 分钟
- **13:40** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：2e459bfa9ecc43d59f893319289226dd
  - 耗时：1.531 秒 / 游戏 0 分钟
- **13:40** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 1 forage items
  - 执行状态：SUCCESS · 操作编号：ab0917d37ebb4453a5791609c9fa2f6b
  - 耗时：38.046 秒 / 游戏 50 分钟
  - 🗨️ [hud] Common Mushroom
  - 🗨️ [hud] Inventory Full
- **14:30** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c9b8f8c5890f4b448ed85e59d4f4563b
  - 耗时：47.547 秒 / 游戏 60 分钟
- **15:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ce2a1335a91c43c58ad408ef4687a08e
  - 耗时：12.688 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：26852 → 27227（+375g）
- 出货估值：375g　动作：27 个　失败：9 个
- 模型调用：4 次　tokens：48945
- 有效动作率：0.52　空转：8　熔断跳过：1
- 失败耗时：50.513 秒 / 游戏 60 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动再次卡在背包空格：store_items 对 Stone 大堆连续多天假成功，mine 被拒 2 次后下午空转在 donate/build_road/decorate 三个必失败动作上，有效动作仅 12/27。钓鱼 12 条是唯一稳定产出。核心修正：清背包改为「先 ship_produce 卖石头」这一新手段，并彻底删除补充工作分支。

**新教训：**
- store_items 对 Stone 这种 2400+ 的大堆连续 4 天返回 OK 但实际未存入，说明该动作对大堆整组不可靠：应改为先用 ship_produce 卖掉一部分石头（石头非献祭必需）腾出空格，再单物品 store，存完读背包验证。
- 昨天脚本重写 2 次、每次重写又调 mine 再失败，浪费约 200 游戏分钟：mine 被拒后应把当天定性为钓鱼日，直接 goto Forest，重写脚本只调整未完成分支且不得再调 mine。
- 主活动失败后下午空转在 build_road（24 块全被树/作物挡住）和 decorate（无材料）上：这两个动作在农场未清地/无材料阶段 100% 失败，应脚本层直接禁用，失败后立即转 Forest 钓鱼。
- Forest 河边 4 cast 稳定出 3-4 条鱼（Chub/Salmon/Tiger Trout），是食物和现金的可靠来源：主活动失败后应立即转 Forest 钓鱼，而不是空转在 donate/build_road/decorate 上。
- collect_machines 在熔炉刚收完后再调会返回「repeated ineffective action suppressed」：每天 collect 上限 2 次，收完即停，不要为确认再调一次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 2）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 26852g 已够，唯一卡点仍是 **Iron Bar 差 5**（Iron Ore 2、Coal 10）。铁锭同时是洒水器 ×4 的材料，所以「下矿拿铁」是主线。

离完成还差：10 铁矿石 + 5 煤 → 两座熔炉约 2 轮 → 5 铁锭 → 铁匠铺升锄头。

接下来 3 天主活动：
- **今天（秋 2）**：起床 collect 熔炉；**用 ship_produce 卖石头清背包**（新手段，不再依赖 store_items 存大堆），验证空格 ≥8；食物 <5 去 Forest 钓鱼补；两项达标才下矿 40-59 层拿铁矿石+煤；回农场先 collect 再 load。
- **明天（秋 3）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（秋 4）**：钢锄头到手转钢斧；铁锭余量给洒水器。秋季已开始，只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**：返回空则当天永久跳过 collect。
2. **清背包（唯一重点，换手段）**：
   - 先 `goto_location` Farm 到出货箱旁。
   - **第一步：`ship_produce` 把 Stone 卖掉整组**（石头非献祭必需，2407 块卖一部分换现金+空格完全值得）。
   - **第二步：读背包验证**：Stone 已不在背包且空格 ≥8 → 直接进第 3 步。
   - **第三步：若 Stone 仍在背包**，`store_items` items 只写 `["Stone"]` 单物品；再读背包验证。
   - **第四步：仍不足 8 空格**，`ship_produce` 卖 Cobblestone Path / 多余矿石；三次手段后仍不足 → **放弃下矿，直接转 Forest 钓鱼**，当天定性为钓鱼日。
   - 清完立刻 goto Mine，不先绕路。
3. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物 ≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格 ≥8、食物 ≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过 load。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包换手段（今天核心修正）**：store_items 对 Stone 大堆连续多天返回 OK 但实际未存入，说明该动作对大堆不可靠。今天改为**先 ship_produce 卖石头**（石头非献祭必需），再单物品 store，存完读背包验证。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；三次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物=4 时下矿停在 39 层，铁矿石零产出。食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**（昨天重写 2 次全撞同一堵墙）。
- **load 硬熔断**：`load_machines` 每天 ≤2 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤2 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。18 层已确认 infested，从 19 层以下开始。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
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
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 真清背包到 ≥8 空格并验证（**先 ship_produce 卖石头，再单物品 store**，三次不足则放弃下矿）
3. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
4. 下矿 40-59 层拿铁矿石+煤（食物 ≥5、空格 ≥8 才下，≤2 次 mine，超时即停，跳过 18 层）
5. 回农场先 collect 再 load（炉空且背包有 Iron Ore 才装，只试 1 次）
6. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
7. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主活动再次卡在背包空格：store_items 对 Stone 大堆连续多天假成功，mine 被拒 2 次后下午空转在 donate/build_road/decorate 三个必失败动作上，有效动作仅 12/27。钓鱼 12 条是唯一稳定产出。核心修正：清背包改为「先 ship_produce 卖石头」这一新手段，并彻底删除补充工作分支。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 07:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:40 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 13:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 13:40 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:30 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功：store_items 返回 OK 但 Stone 2407 块和 Cobblestone Path 仍占格，背包空格始终不足 8 @ Farm 出货箱旁 — store_items -> OK: nothing to store；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 2 次，每次重写又调 mine 再失败（共 3 次 mine 被拒） @ Mine 入口 / Farm — mine -> FAIL: need at least 5 free backpack slots before mining（重复 3 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试并被抑制 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- 主活动失败后下午空转在 build_road 和 decorate 上 @ Farm — build_road -> laid 0 tiles (24 skipped: blocked by trees/crops)；decorate -> 今天没有能做的装饰（做不了：没有把下午时段用于钓鱼补食物/现金，铁锭进度原地踏步） 〔复盘〕
- donate 在 wait_letter 阶段再次尝试并失败 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：无，但浪费 2 个动作） 〔复盘〕
