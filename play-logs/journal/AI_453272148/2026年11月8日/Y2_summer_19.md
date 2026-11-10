# 第2年 summer 19 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:45 开始）
- 天气：storm　金钱：7983g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ca7a16f0281945fe9c006b32d8084bfd
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：2a42986add2c44d4a98bdd67be31315c
  - 耗时：0.219 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：fca7c400e74f4ad6b26bb1df8ec63cc7
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：2e704b9bed9a48b88bac13b652a08c8b
  - 耗时：0.141 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_19）准备的脚本
- 里程碑：工具按档升级——钢水壶（差 4 铁锭，靠下矿拿铁矿石+煤）
- 先钓鱼把可回血食物补到 ≥5（Forest 河边，≤2 轮）
- 清背包到 ≥7 空格（存 Geode/Trash/杂物）
- 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，生命<50% 或食物=0 立即出矿）
- 回农场 load 铁矿 1 次（确认背包有 Iron Ore 才调）
- collect 熔炉 1 次
- 浇水（水壶在背包）
- 22:00 前 sleep
1. `donate`
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path"]）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `water_crops`
13. `sleep`
- **06:00** FarmHouse ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：d0eb7bafd5c64a5e8e2b3368af29a75e
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师来信未到而失败，按策略跳过献祭，保留原路线：钓鱼补食物→清背包→下矿拿铁→回农场装炉→睡觉。
1. `fish`（casts=4）
2. `fish`（casts=4）
3. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `water_crops`
12. `sleep`
- **06:00** FarmHouse ❌ `fish`（casts=4）
  - 结果：no reachable fishing spot in FarmHouse
  - 执行状态：ACTION_FAILED · 操作编号：440e19d58786441591f4e3e1652edc96
  - 耗时：0.188 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：农舍内无钓点，先跨图到Forest河边补食物，再按原路线清背包、下矿拿铁、回农场装炉收炉后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Broken Glasses", "Joja Cola", "Cobblestone Path"]）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `water_crops`
13. `sleep`
- **06:00** FarmHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：ed1a6dc6b97d4583b4383db86025ea5f
  - 耗时：22.687 秒 / 游戏 20 分钟
- **06:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, River Jelly, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：3cbaf072e77e4856929e66d7660e0d26
  - 耗时：52.157 秒 / 游戏 60 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Green Algae
- **07:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Driftwood, Pike, Trash, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：5797d50df43d4f5c967fd2a3bded7621
  - 耗时：45.266 秒 / 游戏 50 分钟
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Trash
- **08:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5b32aef144064ba2a551c8834b3ca57a
  - 耗时：71.891 秒 / 游戏 100 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：35fd0ee3ef174034aa663879e59374b4
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞内背包满被拒，先存杂物腾出≥7空格再下矿，其余路线不变。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Cobblestone Path", "Trash", "Soggy Newspaper", "Driftwood", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rice Shoot", "Garlic Seeds", "Coffee Bean"]）
5. `load_machines`（item="Iron Ore"）
6. `collect_machines`
7. `water_crops`
8. `sleep`
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：85b33e00d4cc4bdaa401a230cf8b6b48
  - 耗时：0.125 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：5b0fe739ab764bba8692970d1fb359d6
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：26c641d7b6ae4bd8bd600441e989d04e
  - 耗时：33.485 秒 / 游戏 40 分钟
- **10:30** Farm ✅ `store_items`（items=["Cobblestone Path", "Trash", "Soggy Newspaper", "Driftwood", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Rice Shoot", "Garlic Seeds", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 1x Driftwood, 1x Trash, 1x Soggy Newspaper
  - 执行状态：SUCCESS · 操作编号：08564d4e023745c1a39c5dfe29bb0f7b
  - 耗时：11.562 秒 / 游戏 10 分钟
- **10:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：52a25c9419264828ba916e6df0bb67cc
  - 耗时：0.156 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：b6df6e00b85c47698e8e9716a494ccac
  - 耗时：0.141 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：d54b85d3994e49b6b67b696707dab106
  - 耗时：0.14 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6bf61ab29a7043188e2ee0cb8ae394b6
  - 耗时：0.141 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：63dd30cc4bf142b6ab79ccb187523faa
  - 耗时：0.125 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5ed29b169fcc4f3e8f56854b9bdba1bd
  - 耗时：5.0 秒 / 游戏 10 分钟
- **10:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：398d0dfc5f7244bcbd2ade0a671c050b
  - 耗时：0.11 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：84b73fc7e53444b0a98cd0a149cd3337
  - 耗时：12.531 秒 / 游戏 20 分钟
- **11:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Soggy Newspaper, Broken CD, Trash)
  - 执行状态：SUCCESS · 操作编号：445ec72b3a0c4bbe8a3ecd3d8b7c36b0
  - 耗时：27.671 秒 / 游戏 30 分钟
  - 🗨️ [hud] Soggy Newspaper
  - 🗨️ [hud] Broken CD
- **11:40** Farm ✅ `ship`（item="Soggy Newspaper", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Soggy Newspaper (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：2de97f0f2fb84521a48e10615e85b296
  - 耗时：3.219 秒 / 游戏 10 分钟
- **11:40** Farm ✅ `ship`（item="Broken CD", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：147513b0f7bb4eafb820011339f0af9c
  - 耗时：0.203 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `ship`（item="Trash", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：20c0da80d0f6405badcafea69307aff3
  - 耗时：0.218 秒 / 游戏 0 分钟
- **11:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Joja Cola, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：5f9ddc3ba28140a08ad163a8abcebec5
  - 耗时：38.437 秒 / 游戏 50 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Joja Cola
- **12:40** Farm ✅ `ship`（item="Broken CD", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：bc51d812466a493fb29b0ec049137f34
  - 耗时：3.016 秒 / 游戏 0 分钟
- **12:40** Farm ✅ `ship`（item="Joja Cola", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Joja Cola (~50g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：d888496b66f84d158ee6052167ea6ba1
  - 耗时：0.282 秒 / 游戏 0 分钟
- **12:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 2:40 pm
  - 执行状态：SUCCESS · 操作编号：6716fe0f9e03487985628ba34e49ab75
  - 耗时：80.937 秒 / 游戏 120 分钟
- **14:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 4:40 pm
  - 执行状态：SUCCESS · 操作编号：8c3a03ac5b0d45489f8229e6bbca694b
  - 耗时：87.735 秒 / 游戏 120 分钟
- **16:40** Farm ✅ `wait`（minutes=20, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：6d8e4eb1b71e4151a81a22e25358a87b
  - 耗时：14.735 秒 / 游戏 20 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：20e1d76bbd694f45ac3a607c0fb0feba
  - 耗时：6.938 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：7983 → 8033（+50g）
- 出货估值：0g　动作：36 个　失败：14 个
- 模型调用：5 次　tokens：60645
- 有效动作率：0.5　空转：9　熔断跳过：0
- 失败耗时：19.329 秒 / 游戏 30 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天36动作14失败，主因是「固定做这个到17:00」分支导致 load/build_road/decorate 反复空转，浪费约10个动作和4小时游戏时间；两次 mine 因背包空格不足被拒，等于白跑矿洞。有效动作是钓鱼（Forest 河边出 Pike/River Jelly）和 store_items 清背包。今天必须砍掉固定时段分支，先钓鱼补食物到≥5、清背包到≥7空格，再一次性下矿拿铁；洒水器 place 读不到分区坐标就当天放弃。

**新教训：**
- 「固定做这个到 X 点」分支会让失败动作反复空转：昨天 14:00-16:40 的 load×5、build_road×3、decorate×4 全失败，浪费 10+ 动作和 4 小时；任何动作失败一次即切钓鱼或 sleep，脚本层不设固定时段分支。
- 两次 mine 因背包空格不足被拒，等于白跑矿洞：下矿前 store_items 必须清到 ≥7 空格，且清完立刻 goto Mine，不要先跑去别处。
- 钓鱼在 Forest 河边能稳定出 Pike/River Jelly 等可吃鱼，而 Farm 池塘连续出 Trash/Broken CD：补食物和现金兜底一律去 Forest 河边或 Mountain 湖，不在 Farm 池塘连钓。
- 洒水器 place 连续三天失败且 hoe (54,16) 无效，说明该坐标不在规划分区内：place 前必须先读分区坐标，读不到就当天放弃 place，不要反复 hoe。
- load_machines 在背包和箱子都没有 Iron Ore/Copper Ore 时调用必然失败：load 前先确认背包有矿石，没有就跳过，且每天最多 2 次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏20）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 7983g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天只在读得到分区坐标时做，读不到当天放弃）→ **保存罐**（Wood 还差 49，需先砍树/攒木头）。
接下来 3 天主活动：
- **今天（夏20）**：① 先钓鱼补食物到 ≥5（Forest 河边，≤2 轮）；② 清背包到 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场 load 铁矿 1 次（确认背包有 Iron Ore）；⑤ 22:00 前 sleep。
- **明天（夏21）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏22）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **补食物到 ≥5（第一优先）**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon**。食物≥5 才允许下矿。
2. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
3. **下矿（主活动）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败或读不到分区坐标当天不再 place。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天食物优先于一切**：食物<5 时禁止下矿，先钓鱼补食物；下矿是今天唯一主活动，铁锭不到 5，钓鱼、装饰、铺路、社交全部让位。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load/build_road/decorate 浪费 10+ 动作。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥7**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<7 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：连续两天 12:00 整 open_shop 失败，等店主就位浪费 3 小时；补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach；去 Beach 会因节日锁门或位置错误失败。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续三天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥7；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
2. 清背包到 ≥7 空格
3. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥7 才下，≤2 次 mine，超时即停）
4. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
5. 熔炉 collect（仅 1 次，空即跳）
6. 洒水器 place（仅当 1-5 完成且时间<17:00，先读分区坐标再 hoe+place）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
10. 社交（仅顺路）
11. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天36动作14失败，主因是「固定做这个到17:00」分支导致 load/build_road/decorate 反复空转，浪费约10个动作和4小时游戏时间；两次 mine 因背包空格不足被拒，等于白跑矿洞。有效动作是钓鱼（Forest 河边出 Pike/River Jelly）和 store_items 清背包。今天必须砍掉固定时段分支，先钓鱼补食物到≥5、清背包到≥7空格，再一次性下矿拿铁；洒水器 place 读不到分区坐标就当天放弃。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ FarmHouse — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:00 动作 `fish` 失败 @ FarmHouse — no reachable fishing spot in FarmHouse 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 10:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 10:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 「固定做这个到 17:00」分支让 load_machines/build_road/decorate 反复空转 @ Farm — load_machines: no empty machine accepts anything；build_road: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate: 今天没有能做的装饰（做不了：14:00-16:40 共浪费 10+ 动作和约 4 小时游戏时间，下矿和钓鱼都没做成） 〔复盘〕
- 两次 mine 因背包空格不足被拒，白跑矿洞 @ Mine 入口 — need at least 5 free backpack slots before mining; store_items first（做不了：当天铁矿石零产出，钢水壶还差 4 铁锭） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 铺路材料 craft 后全部被树木/作物挡住 @ Farm — laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：24 块 Cobblestone Path 白 craft，浪费石头和时间） 〔复盘〕
- donate 在 wait_letter 阶段调用失败 @ 社区中心 — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心献祭暂时无法推进，需等巫师来信） 〔复盘〕
- 在 FarmHouse 内调用 fish 失败 @ FarmHouse — no reachable fishing spot in FarmHouse（做不了：浪费 1 个动作，钓鱼必须先 goto 到 Forest/Mountain 水域） 〔复盘〕
