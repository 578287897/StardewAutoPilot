# 第4年 fall 11 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（03:18 开始）
- 天气：rain　金钱：35572g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b208fcb5983c4fadadfb4923f1f1d5ba
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：0a8a58ceb1be4d03a582e9a2b15111ae
  - 耗时：3.234 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：8ac57ecb9019468395287b494d5e1ebb
  - 耗时：6.031 秒 / 游戏 10 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d1825599ba8743058bd000af5953f0b3
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：1f8bf49148de477fbb1ba3023363e4d5
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~636g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ba15be354a6042d3b08fea27b99b364a
  - 耗时：0.672 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_11）准备的脚本
- 里程碑：工具按档升级——凑 5 铁锭升钢锄头
- 起床先到出货箱卖 Copper Bar 整组+鱼整组，验证背包空格≥8
- 空格够则下矿 40-59 层拿铁矿石+煤（≤2 次 mine）
- 矿被拒或超时立刻转 Forest 钓鱼，当天定性钓鱼日
- 傍晚回农场 collect 一次确认炉空，有 Iron Ore 才 load 一次
- 铁锭够 5 就去铁匠铺 upgrade_tool hoe（9-16 点）
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `goto_location`（location="Farm"）
4. `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
5. `ship`（item="Copper Bar", count=40）
6. `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `goto_location`（location="Forest"）
11. `fish`（casts=4）
12. `fish`（casts=4）
13. `fish`（casts=4）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
18. `sleep`
- **06:10** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：bf74141be4df4a73a437b82b0ac5999b
  - 耗时：40.094 秒 / 游戏 50 分钟
- **07:00** CommunityCenter ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：fc12ca1d18774aa7b63433abf019158c
  - 耗时：0.297 秒 / 游戏 0 分钟
- **07:00** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：d670de5a008a44a2895e67de488bd7b2
  - 耗时：39.407 秒 / 游戏 40 分钟
- **07:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f9b0c871df0042dfbe9effd160774a76
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：mine 因空格不足被拒，按策略立即转 Forest 钓鱼兜底，傍晚回农场卖鱼并确认熔炉状态后睡觉。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
9. `ship`（item="Copper Bar", count=40）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `sleep`
- **07:40** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：c93b9ef3b901483e9cea33409c035110
  - 耗时：39.641 秒 / 游戏 50 分钟
- **08:30** CommunityCenter ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：cce19f2611be488384b399b20cda1a2a
  - 耗时：37.86 秒 / 游戏 50 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Catfish, Tiger Trout, Shad, Shad)
  - 执行状态：SUCCESS · 操作编号：0d8af642958f448fbdbe53246b697485
  - 耗时：84.844 秒 / 游戏 70 分钟
  - 🗨️ [hud] Catfish
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Shad
- **10:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, River Jelly, Salmon, Tiger Trout)
  - 执行状态：SUCCESS · 操作编号：78f29139107549a7b7e03df586b4d30c
  - 耗时：88.594 秒 / 游戏 90 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] River Jelly
- **12:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Walleye, Chub, Salmon)
  - 执行状态：SUCCESS · 操作编号：385a79ef1bd245bf8a264f8a83a01c50
  - 耗时：86.0 秒 / 游戏 80 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
- **13:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Tiger Trout, Tiger Trout, Walleye)
  - 执行状态：SUCCESS · 操作编号：753e14545e9a460396ec2515eeda8029
  - 耗时：93.625 秒 / 游戏 80 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Tiger Trout
- **14:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：c03cbeab6d7f46048cf289337b6d7f3b
  - 耗时：15.266 秒 / 游戏 20 分钟
- **15:00** Farm ✅ `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
  - 结果：shipped 3 stacks worth ~1380g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：db542fc4cfe041c5bcaef1f4b0eeb766
  - 耗时：20.422 秒 / 游戏 30 分钟
- **15:30** Farm ❌ `ship`（item="Copper Bar", count=40）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：ae06ead593b14897843a5527da26bc53
  - 耗时：0.281 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：Copper Bar 在箱子里，先 take 再出货腾格；背包仍紧则按硬规则转 Forest 钓鱼，傍晚回农场卖鱼收炉后睡觉。
1. `donate`
2. `take`（item="Copper Bar", count=40）
3. `ship`（item="Copper Bar", count=40）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
9. `collect_machines`
10. `sleep`
- **15:30** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：1eb381349b754295b26248c9ef0ed780
  - 耗时：41.672 秒 / 游戏 50 分钟
- **16:20** CommunityCenter ✅ `take`（item="Copper Bar", count=40）
  - 结果：took 40x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：6c7215b4dcc34cdf8d0a324a9557dd83
  - 耗时：39.188 秒 / 游戏 50 分钟
- **17:10** Farm ✅ `ship`（item="Copper Bar", count=40）
  - 结果：shipped 40x Copper Bar (~2400g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：89a8d20debdf4fb892e64948fe098f25
  - 耗时：0.641 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：46d6498efebb4f04a737b70c50f37093
  - 耗时：25.156 秒 / 游戏 30 分钟
- **17:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Walleye, Walleye, Walleye, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：e111b92c18694b0e93faf8b767ebde43
  - 耗时：112.469 秒 / 游戏 110 分钟
  - 🗨️ [hud] Walleye
  - 🗨️ [hud] Walleye
  - 🗨️ [hud] Walleye
- **19:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 5 (Walleye, Walleye, Walleye, treasure: Copper Ore, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：bee6744d44b447b08260baf04b396418
  - 耗时：101.39 秒 / 游戏 100 分钟
  - 🗨️ [hud] Walleye
  - 🗨️ [hud] Walleye
  - 🗨️ [hud] Walleye
- **21:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：548d9f2da0d34d79906ec9b32649a918
  - 耗时：9.562 秒 / 游戏 10 分钟
- **21:20** Farm ✅ `ship_produce`（except=["Salmon", "Chub", "Green Algae", "River Jelly", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Copper Bar"]）
  - 结果：shipped 2 stacks worth ~1092g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：d5bd7929cc4842aaa0f487eac3797d4f
  - 耗时：20.422 秒 / 游戏 30 分钟
- **21:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **21:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ffaaa2c5182f4a918b0211c34f13745e
  - 耗时：6.75 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：35572 → 41080（+5508g）
- 出货估值：3108g　动作：29 个　失败：5 个
- 模型调用：4 次　tokens：50610
- 有效动作率：0.8148　空转：3　熔断跳过：1
- 失败耗时：1.5 秒 / 游戏 0 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天钓鱼与卖铜锭是有效动作（收入2360g，出货估值3108g），但起床顺序仍错：先load/collect/donate/water再卖货，导致背包空格不足、mine被拒，下午又浪费在collect抑制上。核心问题不是策略缺失，而是执行顺序：清背包必须绝对第一，且卖完必须验证空格≥8再决定下矿。铁锭仍差5，钢锄头卡住。

**新教训：**
- 昨天起床后先 load/collect/donate/water 再卖货，导致背包空格不足、mine 被拒：清背包必须是起床后第一个动作，且卖完立即读背包验证空格 ≥8，验证通过前脚本里不得出现任何其他动作。
- 昨天 21:50 在已收完炉后又调 collect_machines，触发 repeated ineffective action suppressed：collect 每天 ≤1 次，收完即停，不要为确认再调一次。
- 昨天 ship 传 item=Copper Bar 时背包里没有（在箱子里），返回 not found：卖箱内物品必须先 take 到背包再 ship，两步分开，不能一步 ship 箱子里的东西。
- 昨天 4 轮钓鱼共 16 条鱼但只卖了 2 组 ~2472g，仍有鱼在背包：钓鱼后应把非献祭鱼整组一次 ship_produce 卖 ≥3 组，鱼是当天最大现金流。
- 昨天 mine 被拒后脚本重写 2 次仍调 mine，浪费约 200 游戏分钟：重写前必须先读背包空格数，<8 时脚本里不得出现 mine 动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 12）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 35572g 已远超，唯一卡点是 **Iron Bar 差 5**（Iron Ore 2、Coal 10）。铁锭同时是洒水器 ×4 的材料，所以「下矿拿铁矿石+煤」是主线，钓鱼是兜底与现金流。

离完成还差：约 10 铁矿石 + 5 煤 → 两座熔炉 2 轮 → 5 铁锭 → 铁匠铺升锄头（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 12）**：起床第一动作 goto Farm 出货箱 → `ship_produce` 一次卖 ≥3 组（鱼整组 + 非必需杂项）→ 读背包确认空格 ≥8 → 通过则 goto Mine 下 40-59 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭够 5 就明天升级。
- **明天（秋 13）**：铁锭 ≥5 → `upgrade_tool tool=hoe`；不够继续下矿。
- **后天（秋 14）**：钢锄头到手转钢斧；铁锭余量给洒水器。秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包（今天唯一重点）**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组（鱼整组 + 非献祭杂项；Copper Bar 若背包有则整组卖，昨天已卖 40 个，剩余按需）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖 Refined Quartz/Sap 小堆，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 Stone 整组**（连续多天假成功）。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **下矿（今天唯一主活动）**：空格 ≥8 且食物 ≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
3. **回农场收炉**：`collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。炉空且背包有 Iron Ore 才 `load_machines` 1 次；返回 busy/no empty 即当天永久跳过 load。
4. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
5. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
6. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
7. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
8. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组，卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。这是连续多天 mine 被拒的根因。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天 ≤1 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤1 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。18 层已确认 infested，从 19 层以下开始。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组 + 读背包验证空格 ≥8
2. 下矿 40-59 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，超时即停，跳过 18 层）
3. 回农场 collect 收铁锭（≤1 次），炉空且背包有 Iron Ore 才 load（≤1 次）
4. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
5. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
6. 浇水（水壶在背包时）
7. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
8. 社交（仅顺路）
9. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天钓鱼与卖铜锭是有效动作（收入2360g，出货估值3108g），但起床顺序仍错：先load/collect/donate/water再卖货，导致背包空格不足、mine被拒，下午又浪费在collect抑制上。核心问题不是策略缺失，而是执行顺序：清背包必须绝对第一，且卖完必须验证空格≥8再决定下矿。铁锭仍差5，钢锄头卡住。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:00 动作 `collect_machines` 失败 @ CommunityCenter — no machine has finished output 〔自动〕
- 07:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:30 动作 `ship` 失败 @ Farm — 'Copper Bar' not found in inventory 〔自动〕
- 21:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 起床后先 load/collect/donate/water 再卖货，背包空格始终不足 8，下矿被拒 @ Farm 出货箱旁 / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：5 铁锭凑不齐，钢锄头升级无法开始，洒水器材料也拿不到） 〔复盘〕
- 卖 Copper Bar 时背包里没有（在箱子里），ship 直接失败 @ Farm 出货箱旁 — ship -> FAIL: 'Copper Bar' not found in inventory（做不了：需先 take 到背包再 ship，多花 2 个动作） 〔复盘〕
- 熔炉刚收完又调 collect，触发抑制 @ Farm 熔炉旁 — collect_machines -> FAIL: repeated ineffective action suppressed until game state changes（做不了：无，但浪费动作；collect 每天 ≤1 次，收完即停） 〔复盘〕
- 钓鱼收获 16 条鱼但只卖 2 组 ~2472g，仍有鱼在背包 @ Forest 河边 / Farm 出货箱 — ship_produce 只卖 2 组，背包仍有鱼（做不了：当天现金流未最大化，背包未彻底清空） 〔复盘〕
- mine 被拒后脚本重写 2 次仍调 mine @ Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining（做不了：浪费约 200 游戏分钟，铁锭进度零推进） 〔复盘〕
- 起床后先 donate 再卖货，donate 在 wait_letter 阶段失败 @ Community Center — donate -> OK 打开 Junimo note，但 wizardJunimoNote is now pending（做不了：无，但浪费 2 个动作，且挤占了清背包时间） 〔复盘〕
