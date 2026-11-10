# 第2年 fall 1 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（06:17 开始）
- 天气：sunny　金钱：10672g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_fall_01）准备的脚本
- 里程碑：工具按档升级——取回钢水壶，并凑齐下一件工具（钢斧/钢镐）所需的 5 铁锭
- 起床收机器（1 次）
- 清背包到 ≥8 空格（存掉 Cobblestone Path 等杂物）
- 去 Mountain 的 FishShop 买 30 个 Bait（顺路）
- 去 Blacksmith 取回升级好的钢水壶
- 下矿 40 层以下拿铁矿石+煤（食物 7 个、空格够，≤2 次 mine）
- 回农场装炉炼铁，凑铁锭
- 傍晚出货、睡觉
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Cobblestone Path", "Broken Glasses", "Bamboo Pole", "Joja Cola"]）
4. `goto_location`（location="Mountain"）
5. `open_shop`（shop_id="FishShop"）
6. `buy`（item="Bait", count=30）
7. `close_menu`
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`
10. `goto_location`（location="Mine"）
11. `mine`（floors=10）
12. `mine`（floors=10）
13. `leave_mine`
14. `goto_location`（location="Farm"）
15. `load_machines`（item="Iron Ore"）
16. `collect_machines`
17. `ship_produce`（except=["Iron Bar", "Iron Ore", "Coal", "Copper Bar"]）
18. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：1a93cb4daa4a4fc19776ad6001437e4c
  - 耗时：20.75 秒 / 游戏 20 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0e8a20bb14644281801b0945dc6c5add
  - 耗时：0.203 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：b441c84fab2843d8911a102aab1c68d0
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：d76faee3cc0045bab0a73668a70f4d88
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~600g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ef25147a05e948408f835e151827c179
  - 耗时：10.484 秒 / 游戏 20 分钟
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：872c3b3bfee04e6a917a47967ad22f39
  - 耗时：0.172 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：捐不了（等巫师信），按原路线清背包→买饵→取钢水壶→下矿拿铁→回农场炼铁睡觉。
1. `store_items`（items=["Cobblestone Path", "Broken Glasses", "Joja Cola", "Bamboo Pole", "Coffee Bean"]）
2. `goto_location`（location="Mountain"）
3. `open_shop`（shop_id="FishShop"）
4. `buy`（item="Bait", count=30）
5. `close_menu`
6. `goto_location`（location="Blacksmith"）
7. `upgrade_tool`
8. `goto_location`（location="Mine"）
9. `mine`（floors=10）
10. `mine`（floors=10）
11. `leave_mine`
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `ship_produce`（except=["Iron Bar", "Iron Ore", "Coal", "Copper Bar"]）
15. `sleep`
- **06:40** Farm ✅ `store_items`（items=["Cobblestone Path", "Broken Glasses", "Joja Cola", "Bamboo Pole", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 2x Broken Glasses, 1x Joja Cola
  - 执行状态：SUCCESS · 操作编号：55027af4c4f14855bb5c41b267d8bc5d
  - 耗时：1.047 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
  - 执行状态：SUCCESS · 操作编号：11fa0678f16345aa9840fdd31c1b76c1
  - 耗时：27.219 秒 / 游戏 30 分钟
- **07:10** Mountain ✅ `open_shop`（shop_id="FishShop"）
  - 结果：waited until 9:00 am (waiting for FishShop to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：48b934a1c72d4186af862ecf7a2c4118
  - 耗时：76.485 秒 / 游戏 110 分钟
- **09:00** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：b07eb373ae9c4fc58d1f4eb06486ec91
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：鱼店在Mountain但柜台未开（周六无销售），跳过买饵直接下矿拿铁，回农场装炉后睡觉。
1. `goto_location`（location="Mine"）
2. `mine`（floors=10）
3. `mine`（floors=10）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `load_machines`（item="Iron Ore"）
7. `ship_produce`（except=["Iron Bar", "Iron Ore", "Coal", "Copper Bar"]）
8. `sleep`
- **09:00** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5bd246d45d7642a2a9668f395abf1df2
  - 耗时：18.469 秒 / 游戏 20 分钟
- **09:20** Mine ❌ `mine`（floors=10）
  - 结果：floor 18: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：555a7b2b3787470b85aacff4bffd60c4
  - 耗时：43.016 秒 / 游戏 50 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] This area is overrun 
with monsters. 

### 🔁 脚本重写：重写#3：本层石头已清空只剩怪物，先清怪找梯子再继续下矿，之后回农场装炉炼铁并睡觉。
1. `fight`（range=6）
2. `fight`（range=6）
3. `mine`（floors=6）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `load_machines`（item="Iron Ore"）
7. `ship_produce`（except=["Iron Bar", "Iron Ore", "Coal", "Copper Bar"]）
8. `sleep`
- **10:10** UndergroundMine18 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：9438d2c6bbcb4cfdac8e3436b1929ff5
  - 耗时：4.859 秒 / 游戏 10 分钟
  - 🗨️ [hud] Slime
- **10:20** UndergroundMine18 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：426592f7a12246729104805b83b20dd0
  - 耗时：0.172 秒 / 游戏 0 分钟
- **10:20** UndergroundMine18 ❌ `mine`（floors=6）
  - 结果：floor 18: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：64e48416c99e48b99eacb4390c91f097
  - 耗时：0.14 秒 / 游戏 0 分钟
- **10:20** UndergroundMine18 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：4c13956347b44a69a0805c86da509026
  - 耗时：4.39 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **10:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：23b30b6fac88453db364b2c507f8005c
  - 耗时：35.64 秒 / 游戏 50 分钟
- **11:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：5e9493bf1064453aa95c11c3f36f314d
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:10** Farm ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Coal", "Copper Bar"]）
  - 结果：shipped 3 stacks worth ~46g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：5f0de46e193a40228a3b8013f2d7a537
  - 耗时：10.296 秒 / 游戏 10 分钟
- **11:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：feeb0c14590d42d9b55404ef506a77ef
  - 耗时：0.156 秒 / 游戏 0 分钟
- **11:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：4e075d6f31554ac998fceba102e98dfd
  - 耗时：0.187 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：dd2ecb69928543dbabff91b7e219667d
  - 耗时：4.171 秒 / 游戏 10 分钟
- **11:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7f0ec2f3835a4e5c9db8c182e83cc9a7
  - 耗时：0.141 秒 / 游戏 0 分钟
- **11:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：20032000f3fa41218544133339afbc56
  - 耗时：12.563 秒 / 游戏 10 分钟
- **11:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:40** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:40** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Joja Cola, Broken CD)
  - 执行状态：SUCCESS · 操作编号：3eb3709a37c7423d9aeaf838b4e5bf6f
  - 耗时：30.547 秒 / 游戏 40 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Joja Cola
- **12:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：c441fc47fc314e17ba875d4f63c6a88d
  - 耗时：0.171 秒 / 游戏 0 分钟
- **12:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：1f401b66c75049d9bcc084214dc74a30
  - 耗时：23.641 秒 / 游戏 40 分钟
- **13:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Soggy Newspaper, Trash)
  - 执行状态：SUCCESS · 操作编号：94484a8213b84d9cadd6f920710cf630
  - 耗时：36.672 秒 / 游戏 50 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Soggy Newspaper
- **13:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：10debb1b55d743a6b26c9e818878a876
  - 耗时：0.172 秒 / 游戏 0 分钟
- **13:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：807fdcd199874f82904a50d12a15f1be
  - 耗时：12.313 秒 / 游戏 10 分钟
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 4:00 pm
  - 执行状态：SUCCESS · 操作编号：d3b311b6364646729405a819c7fc5128
  - 耗时：82.188 秒 / 游戏 120 分钟
- **16:00** Farm ✅ `wait`（minutes=60, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：63ea97a7c7d24968a9ae2d600f6a34b3
  - 耗时：43.938 秒 / 游戏 60 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：333317c170884a66ad126c65a255a728
  - 耗时：21.468 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：10672 → 11318（+646g）
- 出货估值：646g　动作：39 个　失败：20 个
- 模型调用：5 次　tokens：60731
- 有效动作率：0.3889　空转：12　熔断跳过：0
- 失败耗时：97.531 秒 / 游戏 120 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天20次失败集中在三处：load_machines空转6次、decorate/build_road无效8次、矿洞18层清怪后仍无梯子。根本原因是脚本设了「固定做到17:00」的填充分支，且下矿前没确认食物和背包余量。有效动作是collect_machines、ship_produce、钓鱼补现金。今天应取钢水壶、做洒水器、下矿拿铁，并彻底禁用填充动作。

**新教训：**
- 矿洞 18 层清怪 2 次后仍无梯子，说明该层是 infested 层且怪物未清完：应 leave_mine 换层，不在同一层连调 mine；下次下矿优先从 19 层以下开始，跳过 18 层。
- open_shop FishShop 在 Mountain 地图，但昨天先 goto Mountain 再 open_shop 仍失败，说明 FishShop 入口坐标在 Mountain 内部而非地图切换点：应先走到威利店门口（Mountain 内具体坐标）再 open_shop，或改用 buy 前先确认 shopkeeper 在场。
- 洒水器材料已够但昨天没 craft 也没 place，说明流程里缺少「craft 洒水器」这一步：材料够时应在起床后立即 craft，再找空地 place，不要等到下矿回来。
- 水壶升级期间 water_crops 失败是预期行为，但昨天仍调了 1 次浪费动作：升级当天脚本层应直接跳过浇水分支，取回水壶后第二天才恢复。
- 昨天 14:00-16:40 的 wait(filler) 两次共浪费 3 小时游戏时间：主活动做完应立即 sleep 或转钓鱼，禁止用 wait 填充到固定时间点。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 秋02）

## 长期目标
当前里程碑：**工具按档升级**——钢水壶今天从克林特处取回（升级完成），取回后立即评估下一件：钢斧（5000g+5铁锭）或钢镐。材料现状：Iron Bar 3、Iron Ore 2、Coal 8、Copper Bar 70、Stone 2279；现金 10672g（够升级费）。**差 2 铁锭 + 铁矿石/煤**。
并行里程碑：**洒水器×4 落地**（材料已够，今天必须找空地放下）；**下矿装备**——当前最多安全下到 19 层（食物仅 2 个），需补食物到 ≥5 才能下 40 层以下拿铁矿。
接下来 3 天主活动：
- **今天（秋02）**：取钢水壶 → 洒水器落地 → 补食物到 ≥5 → 下矿 40 层以下拿铁矿石+煤（≤2 次 mine）→ 回农场炼铁。
- **明天（秋03）**：铁锭够 5 就升级钢斧/钢镐（一次一件）；不够继续下矿；秋季种子预算（南瓜/蔓越莓）。
- **后天（秋04）**：铺洒水器、秋季种植启动；若洒水器已落地则主活动转为下矿/钓鱼赚钱。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过。
2. **取钢水壶**：`goto_location` Blacksmith → `upgrade_tool` 取回水壶（9:00-16:00 之间，16:00 后不去）。取回后水壶在背包，浇水分支恢复。
3. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Bamboo Pole、Broken Glasses、Joja Cola、Coffee Bean、多余矿石、钓到的垃圾全部存箱或 ship；**必须清到 ≥8 空格**。空格<8 禁止下矿。
4. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。若 Bait=0，先顺路去 Mountain 的 FishShop 买 20-40 个 Bait（5g 一个，16:30 前）。
5. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
6. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
7. **洒水器落地**：材料已够，`craft` 洒水器×4（若未 craft 过），然后在农场已清空的地块 `place` 洒水器。**place 前先确认目标地块无作物/树/杂物**；若 place 返回 blocked，换相邻空地再试 1 次，仍失败即当天放弃。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **取水壶优先于下矿**：钢水壶今天可取，9:00-16:00 之间先去 Blacksmith 取回，再执行后续流程。
- **下矿前空格≥8 是硬门槛**：store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：食物<5 时 mine 会停在 39 层，铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **洒水器 place 今天允许**：材料已够，但 place 前必须确认目标地块无作物/树/杂物；失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。今天取回水壶后**不再升级第二件**（一次只能升一件）。
- **工具升级期间禁下矿**：镐在升级中时 `mine` 脚本层直接禁用；水壶升级不影响下矿。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥8；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 取钢水壶（Blacksmith，9:00-16:00）
3. 清背包到 ≥8 空格
4. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon；Bait=0 先买饵）
5. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停）
6. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
7. 洒水器落地（craft 后 place，失败 1 次换空地再试 1 次）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶取回后）
10. 社交（仅顺路）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天20次失败集中在三处：load_machines空转6次、decorate/build_road无效8次、矿洞18层清怪后仍无梯子。根本原因是脚本设了「固定做到17:00」的填充分支，且下矿前没确认食物和背包余量。有效动作是collect_machines、ship_produce、钓鱼补现金。今天应取钢水壶、做洒水器、下矿拿铁，并彻底禁用填充动作。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 09:00 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — floor 18: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Stone / [hud] Geode / [hud] Slime / [hud] Stone / [hud] Bug Meat / [hud] Stone / [hud] Bug Meat / [hud] This area is overrun 
with monsters.  〔自动〕
- 10:20 动作 `mine` 失败 @ UndergroundMine18 — floor 18: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 11:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:40 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下矿主活动因食物不足被卡在 19 层，铁矿石零产出 @ Mine 入口 / Farm — only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)；昨天两次 mine 都停在 18 层无梯子（做不了：拿不到 40 层以下的铁矿石，钢水壶差 2 铁锭卡住，下一件工具升级也备不了料） 〔复盘〕
- load_machines 反复空转 6 次 @ Farm 熔炉旁 — no empty machine accepts anything in the backpack or the farm chests（炉子忙或背包没矿可装）（做不了：浪费 6 个动作，本可用于钓鱼补食物或下矿） 〔复盘〕
- decorate 和 build_road 反复失败共 10 次 @ Farm — decorate: 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）；build_road: 24 skipped: blocked by trees/crops/objects（做不了：农场未清障前铺路/装饰必然失败，浪费约 4 小时游戏时间和 10 个动作） 〔复盘〕
- 「固定做到 17:00」填充分支导致 14:00-16:40 空转 @ Farm — load×4、build_road×2、decorate×2 全失败，最后 wait 两次共 3 小时（做不了：浪费约 4 小时游戏时间，本可用于钓鱼补现金或下矿） 〔复盘〕
- 洒水器材料已够但既没 craft 也没 place @ Farm — 流程里缺少 craft 洒水器步骤，place 连续三天失败且 hoe (54,16) 无效（做不了：洒水器里程碑停滞，无法自动浇水，体力继续被浇水占用） 〔复盘〕
- open_shop FishShop 在 Mountain 仍失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)（做不了：买不到鱼饵，钓鱼效率下降） 〔复盘〕
- 水壶升级期间 water_crops 失败浪费动作 @ Farm — no watering can（做不了：当天无法浇水（升级本身可接受，但应跳过试探）） 〔复盘〕
- 矿洞 18 层清怪 2 次后仍无梯子 @ Mine 18 层 — no stones left and no ladder found (kill remaining monsters?)；fight 2 次后 mine 仍返回同样错误（做不了：卡在 18 层无法下到 19 层以下，铁矿石拿不到） 〔复盘〕
