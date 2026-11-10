# 第4年 summer 28 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（01:24 开始）
- 天气：sunny　金钱：26387g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：8eaf30dffe6643c1a99aa094ca6578ce
  - 耗时：5.031 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tonight at around 10 o'clock PM, a rare and beautiful event will take place.  The moonlight jellies will be passing by Pelican Town on their long journey south for the winter.  We're all gathering at the beach to watch. You don't want to miss this! See you tonight,  -Demetrius
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：2f336f3540f840de99bc0ec723252c50
  - 耗时：0.281 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：9773713cc7fa419fb392f125c07ed8a7
  - 耗时：0.297 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_summer_28）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升钢锄头（今天先真清背包再下矿拿铁）
- 起床 collect_machines 一次，然后回农场出货箱旁只存 Stone 整组并验证空格≥8
- 空格够就下矿 40-59 层拿铁矿石+煤，凑 5 铁锭；不够或 mine 被拒立即转 Forest 钓鱼
- 傍晚回农场 collect 再 load 熔炉，最后 sleep
1. `goto_location`（location="Beach"）
2. `festival`（activity="start"）
3. `collect_machines`
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone"]）
6. `store_items`（items=["Stone", "Cobblestone Path"]）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `fish`（casts=4）
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `load_machines`
16. `water_crops`
17. `sleep`
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Joja Cola
  - 执行状态：SUCCESS · 操作编号：59feea1ec4064261a28033a1b73188a0
  - 耗时：4.766 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：56a3435d4bbc499696e724a72e3f2aaf
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：e64925e357ff49148f3ec63d01039ccd
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~465g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：722190a62c964119a753ee9b329ac1ce
  - 耗时：0.656 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `goto_location`（location="Beach"）
  - 结果：exit to Beach did not open (closed? locked? check opening hours). Recent messages: Inventory Full | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：dfb1ab7cfa6943a999f6a637b3ea5c82
  - 耗时：39.5 秒 / 游戏 40 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.

### 🔁 脚本重写：重写#1：Beach 因节日布置未开放，跳过节日动作，按策略回农场清 Stone 背包后下矿拿铁，失败即转 Forest 钓鱼，傍晚回农场收炉睡觉。
1. `goto_location`（location="Mine"）
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `store_items`（items=["Stone"]）
9. `store_items`（items=["Stone", "Cobblestone Path"]）
10. `collect_machines`
11. `load_machines`
12. `water_crops`
13. `sleep`
- **06:50** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：3a83741305f34dae9a08ecd48ea7bd59
  - 耗时：48.047 秒 / 游戏 70 分钟
- **08:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：faf825ca31e3467e9eed740bb8cb2ee4
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包满被拒，先回农场只存 Stone 整组清格再下矿，失败即转 Forest 钓鱼，傍晚回农场收炉装炉后睡觉。
1. `mine`（floors=5）
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone"]）
7. `store_items`（items=["Stone", "Cobblestone Path"]）
8. `collect_machines`
9. `load_machines`
10. `water_crops`
11. `sleep`
- **08:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ab22929282db4fa2b355f61a484d926f
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因空格不足被拒，按策略先回农场只存 Stone 整组清背包，再收炉装炉，不再重试 mine。
1. `mine`（floors=5）
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone"]）
4. `store_items`（items=["Stone", "Cobblestone Path"]）
5. `collect_machines`
6. `load_machines`
7. `water_crops`
8. `sleep`
- **08:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4a2ec94c9a714cca9f579fe38e64832e
  - 耗时：0.297 秒 / 游戏 0 分钟
- **08:00** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：ed6ef46fe15944809746ebf055f88ac6
  - 耗时：33.563 秒 / 游戏 40 分钟
- **08:40** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：009c8bbe5fda4d1bb745a3a119dfb867
  - 耗时：14.969 秒 / 游戏 20 分钟
- **09:00** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：8c4e625f3c4943bdb5c7812de95c8535
  - 耗时：0.328 秒 / 游戏 0 分钟
- **09:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **09:00** Farm ❌ `load_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **09:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：19c50d9272204579b4d6a1265b3caded
  - 耗时：0.281 秒 / 游戏 0 分钟
- **09:00** Farm ❌ `goto_location`（location="Beach", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：exit to Beach did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：de211b00106e4b12943e4a4f5144bcbb
  - 耗时：39.11 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **09:50** Town ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：fb1a5ff91da24481baeb88e73b5d64ab
  - 耗时：0.297 秒 / 游戏 0 分钟
- **09:50** Town ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：b3191776562d4b3ca059105011bb55d9
  - 耗时：16.328 秒 / 游戏 20 分钟
- **10:10** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 3 forage items
  - 执行状态：SUCCESS · 操作编号：14c3408cb53e42129ec9191a17290f69
  - 耗时：57.922 秒 / 游戏 70 分钟
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Sweet Pea
- **11:20** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：fb2ddeede0e74bcfb069ece37037cb40
  - 耗时：31.016 秒 / 游戏 40 分钟
- **12:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:00** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：6c7d9f21d19349b082e1ccb1c9bae0d4
  - 耗时：12.672 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：26387 → 26852（+465g）
- 出货估值：465g　动作：25 个　失败：12 个
- 模型调用：5 次　tokens：59828
- 有效动作率：0.4091　空转：7　熔断跳过：2
- 失败耗时：112.455 秒 / 游戏 130 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动再次被背包卡死：store_items 返回 OK 但 Stone 2407 块没进箱（items 列表没生效），4 次 mine 全被拒，脚本重写 3 次纯浪费；下午又空转在 build_road/decorate 上。有效动作仅 12/25。核心问题不是策略方向，而是「清背包」这一步从未真正成功过——必须换手段（先 ship_produce 卖石头或分多次单物品存）并当场验证。

**新教训：**
- store_items 的 items 列表对 Stone 这种 2400+ 的大堆连续 4 天返回 OK 但实际未存入，说明该动作对大堆整组不可靠：应改为先用 ship_produce 卖掉一部分石头（石头非献祭必需）腾出空格，再单物品 store，存完读背包验证。
- 昨天脚本重写 3 次、每次重写又调 mine 再失败，浪费约 200 游戏分钟：mine 被拒后应把当天定性为钓鱼日，直接 goto Forest，重写脚本只调整未完成分支且不得再调 mine。
- 主活动失败后下午空转在 build_road（24 块全被树/作物挡住）和 decorate（无材料）上：这两个动作在农场未清地/无材料阶段 100% 失败，应脚本层直接禁用，失败后立即转 Forest 钓鱼。
- Beach 在节日筹备日（夏28 月光水母节）全天锁门，goto Beach 两次都失败：节日当天脚本层应直接禁用 Beach/Town 等节日地点，主活动只安排下矿/钓鱼/砍树。
- 熔炉忙时 load_machines 返回 no empty machine 后重试无效：应先 collect_machines 收炉，炉空且背包有 Iron Ore 才 load，炉忙则当天跳过 load。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏29）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 26387g 已够，唯一卡点是 **Iron Bar 差 5**（Iron Ore 2、Coal 10）。铁锭同时是洒水器 ×4 的材料，所以「下矿拿铁」是主线。

离完成还差：10 铁矿石 + 5 煤 → 两座熔炉约 2 轮 → 5 铁锭 → 铁匠铺升锄头。

接下来 3 天主活动：
- **今天（夏29）**：起床先 collect 熔炉；**用新方法真清背包**（见下），验证空格 ≥8；食物 <5 去 Forest 钓鱼补；两项达标才下矿 40-59 层拿铁矿石+煤；回农场先 collect 再 load。
- **明天（夏30）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（夏31/秋1）**：钢锄头到手转钢斧；铁锭余量给洒水器。注意夏28 已过，秋季第 1 天作物枯死，季末只种能成熟的作物。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**：返回空则当天永久跳过 collect。
2. **真清背包（今天唯一重点，换手段）**：
   - 先 `goto_location` Farm 到出货箱旁。
   - **第一步：`ship_produce` 把 Stone 卖掉一部分**（石头不是献祭必需，2407 块卖 200-400 块换现金+空格完全值得；也可直接 ship 整组）。
   - **第二步：`store_items` items 列表只写 `["Stone"]` 单物品**，不要混写。
   - **第三步：立刻读背包验证**：Stone 仍在背包或空格 <8 → 再 `store_items` items=`["Cobblestone Path"]` 单物品。
   - 三次后空格仍 <8 → **放弃下矿，直接转 Forest 钓鱼**，当天定性为钓鱼日。
   - 清完立刻 goto Mine，不先绕路。
3. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物 ≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格 ≥8、食物 ≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过 load。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包换手段**：连续 4 天 store_items 返回 OK 但 Stone 未动，说明 items 列表对整组大堆不生效。今天改为**先 ship_produce 卖石头**（石头非献祭必需，卖 200-400 块换空格+现金），再 store_items 单物品，存完读背包验证。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；三次仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物=4 时下矿停在 39 层，铁矿石零产出。食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**（昨天重写 3 次全撞同一堵墙）。
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
> 昨天主活动再次被背包卡死：store_items 返回 OK 但 Stone 2407 块没进箱（items 列表没生效），4 次 mine 全被拒，脚本重写 3 次纯浪费；下午又空转在 build_road/decorate 上。有效动作仅 12/25。核心问题不是策略方向，而是「清背包」这一步从未真正成功过——必须换手段（先 ship_produce 卖石头或分多次单物品存）并当场验证。
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:10 动作 `goto_location` 失败 @ Farm — exit to Beach did not open (closed? locked? check opening hours). Recent messages: Inventory Full | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 08:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 09:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 09:00 动作 `goto_location` 失败 @ Farm — exit to Beach did not open (closed? locked? check opening hours). Recent messages: Today's festival is being set up. Come back later. | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up.  〔自动〕
- 09:50 动作 `mine` 失败 @ Town — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:20 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功：store_items 返回 OK 但 Stone 2407 块和 Cobblestone Path 仍占格，背包空格始终不足 8 @ Farm 出货箱旁 — store_items -> OK: nothing to store；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 3 次，每次重写又调 mine 再失败（共 4 次 mine 被拒） @ Mine 入口 / Farm — mine -> FAIL: need at least 5 free backpack slots before mining（重复 4 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试并被抑制 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy；repeated ineffective action suppressed（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- 节日筹备日 Beach 全天锁门，goto Beach 两次失败 @ Beach 入口 — exit to Beach did not open；Today's festival is being set up. Come back later.（做不了：无法去海滩钓鱼/参加活动，下午时段被迫空转） 〔复盘〕
- 主活动失败后下午空转在 build_road 和 decorate 上 @ Farm — build_road -> laid 0 tiles (24 skipped: blocked by trees/crops)；decorate -> 今天没有能做的装饰（做不了：没有把下午时段用于钓鱼补食物/现金，铁锭进度原地踏步） 〔复盘〕
