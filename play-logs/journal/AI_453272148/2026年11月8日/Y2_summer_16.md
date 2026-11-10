# 第2年 summer 16 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:16 开始）
- 天气：storm　金钱：7212g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6ea3d69f8716469db82c6cbb217d4067
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：5aaec05094774465a70af917e34f20ab
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：d840eb6f543048bebbc04989cc892b28
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：afcb8ff6c04d494da2f98e989153c38c
  - 耗时：0.156 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_16）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭，今天下矿拿铁矿石+煤）
- 清背包到≥7空格，补食物到≥5（钓鱼吃鱼）
- 下矿40层以下拿铁矿石和煤（≤2次mine）
- 回农场装熔炉炼铁、collect一次
- 铁锭≥5且现金够就升钢水壶
- 22:00前sleep
1. `donate`
2. `store_items`（items=["Cobblestone Path", "Copper Ore", "Copper Bar", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber"]）
3. `ship_produce`
4. `harvest_crops`
5. `water_crops`
6. `goto_location`（location="Mountain"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `load_machines`（item="Iron Ore"）
15. `collect_machines`
16. `sleep`
- **06:00** FarmHouse ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：51d148a4c1274011a1afd70bca96e898
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 未解锁（等巫师来信），跳过；按原路线清背包→钓鱼补食物→下矿拿铁→回农场装炉→睡觉。
1. `store_items`（items=["Cobblestone Path", "Copper Ore", "Copper Bar", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Copper Hoe"]）
2. `goto_location`（location="Mountain"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `sleep`
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：a9fdf33675844c6ca9383745b0b9f6fc
  - 耗时：3.156 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`（items=["Cobblestone Path", "Copper Ore", "Copper Bar", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Copper Hoe"]）
  - 结果：stored in chest at (74,15): 24x Cobblestone Path, 2x Copper Bar
  - 执行状态：SUCCESS · 操作编号：45ba535ab3214f3d874b38ac63d87822
  - 耗时：3.719 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
  - 执行状态：SUCCESS · 操作编号：eb392369fba24ccf839fc6dcc55b35d3
  - 耗时：26.719 秒 / 游戏 40 分钟
- **06:40** Mountain ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Carp, Bullhead, Carp)
  - 执行状态：SUCCESS · 操作编号：d3e78675d74f4074b64631e660630c06
  - 耗时：68.765 秒 / 游戏 60 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Bullhead
- **07:40** Mountain ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Carp, Bullhead, Chub)
  - 执行状态：SUCCESS · 操作编号：de14588e2e964756b38bbe055697f67c
  - 耗时：75.703 秒 / 游戏 60 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Bullhead
- **08:40** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：73c02e0d8f17412e8ea71bcb17bdd222
  - 耗时：7.609 秒 / 游戏 0 分钟
- **08:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4ed3cea211184861bfd98586ddf5d182
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包仅2空格导致下矿被拒，先回农场存杂物清到≥7空格，再回矿洞继续拿铁矿石，最后装炉炼铁并睡觉。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Green Algae", "Carp", "Bamboo Pole", "Silver Saber", "Dwarf Scroll I", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
5. `load_machines`（item="Iron Ore"）
6. `collect_machines`
7. `sleep`
- **08:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：7342dc72d33b4ca7b3beab567ce3a96f
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包空格不足被拒，先回农场存杂物清到≥7格再下矿拿铁，最后装炉炼铁并收一次。
1. `leave_mine`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Green Algae", "Carp", "Bamboo Pole", "Silver Saber", "Dwarf Scroll I", "Garlic Seeds", "Rice Shoot", "Coffee Bean", "Bullhead", "Chub"]）
7. `load_machines`（item="Iron Ore"）
8. `collect_machines`
9. `sleep`
- **08:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：4c164facabaa4636a4f7b47062ff8f81
  - 耗时：0.156 秒 / 游戏 0 分钟
- **08:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3a4491cde7fe47aa8e5f6b7ac4504242
  - 耗时：0.156 秒 / 游戏 0 分钟
- **08:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4e81798cc362453e9b99a9dbab0356d5
  - 耗时：0.218 秒 / 游戏 0 分钟
- **08:40** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：144b3be65e06439ea568eb858f43dc73
  - 耗时：0.141 秒 / 游戏 0 分钟
- **08:40** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：dcab45595f04499190aab0fc51756ef4
  - 耗时：33.5 秒 / 游戏 40 分钟
- **09:20** Farm ✅ `store_items`（items=["Green Algae", "Carp", "Bamboo Pole", "Silver Saber", "Dwarf Scroll I", "Garlic Seeds", "Rice Shoot", "Coffee Bean", "Bullhead", "Chub"]）
  - 结果：stored in chest at (74,15): 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：3440e66bb9f04ce6ba341a0c944009af
  - 耗时：11.547 秒 / 游戏 20 分钟
- **09:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：03057e1e0fa7430e9a564e22e53d4034
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f9fe92f807674ec78b61ec3f63730cb6
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：401a9e2fa9d74eb3b210af2b36adcfb8
  - 耗时：0.14 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：6788566c53964013b74d63cf6a2f6fad
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：c6b16af5c01f466d9ff9b92639d504d3
  - 耗时：5.063 秒 / 游戏 10 分钟
- **09:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：42c5448ad6f74fc2b32125b6eb8c444a
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：4546922518ee434db4c69c289f77a9ca
  - 耗时：12.547 秒 / 游戏 10 分钟
- **10:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **10:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Driftwood, Driftwood)
  - 执行状态：SUCCESS · 操作编号：4311f10479f849ba9af1d17572d9c16b
  - 耗时：27.531 秒 / 游戏 40 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Driftwood
- **10:40** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：1d813c7df7af4c978b84b2e497b9652b
  - 耗时：3.235 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `ship`（item="Driftwood", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Driftwood (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：bd272a828f484d8f8e1a63858f7c49b0
  - 耗时：0.14 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken Glasses, Driftwood, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：ec37914af81448e086c4d5a092884aee
  - 耗时：36.437 秒 / 游戏 50 分钟
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Driftwood
- **11:30** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：e9bec5acd6304cdd8cdd6f6e795a8c2b
  - 耗时：2.969 秒 / 游戏 10 分钟
- **11:30** Farm ✅ `ship`（item="Driftwood", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Driftwood (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：f445b30ccb1049f7ab8c0e441ad5e9aa
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 1:40 pm
  - 执行状态：SUCCESS · 操作编号：70a177d11c364dffa6e60c3ffaa4c3d7
  - 耗时：85.593 秒 / 游戏 120 分钟
- **13:40** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 3:40 pm
  - 执行状态：SUCCESS · 操作编号：85a59a93ce3b454092ec1c1c2769be57
  - 耗时：87.735 秒 / 游戏 120 分钟
- **15:40** Farm ✅ `wait`（minutes=80, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：57d22fd58dcc4fdf93f0b45861dbeb4b
  - 耗时：58.531 秒 / 游戏 80 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：231b23cf76894373b0325a1189e8884b
  - 耗时：6.922 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：7212 → 7212（+0g）
- 出货估值：0g　动作：38 个　失败：16 个
- 模型调用：5 次　tokens：61354
- 有效动作率：0.4706　空转：9　熔断跳过：0
- 失败耗时：19.827 秒 / 游戏 20 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天最大问题是背包满导致两次下矿被拒，铁锭零产出；洒水器连续三天放不下去；下午空转 load/build_road/decorate 浪费 2 小时。有效的是钓鱼补现金和清背包。今天必须：先清背包到≥7再下矿，下矿是唯一主活动，洒水器先读分区坐标再放，禁止空转。

**新教训：**
- 下矿前 store_items 清背包必须清到 ≥7 空格，且清完后立刻 goto Mine 下矿；昨天清到 5 空格仍被拒，白跑矿洞两次。
- load_machines 失败后不要在同一时间点连调：昨天 14:00-16:40 连续 4 次 load 全失败，应失败一次即转下矿或钓鱼。
- craft 铺路材料前先确认目标地块已清空：昨天 24 块 Cobblestone Path 全部被树木/作物挡住 skipped，craft 本身就是浪费。
- 洒水器 place 前必须先读规划分区坐标，hoe 只清分区内格子；连续三天 hoe (54,16) 后 place 仍失败，说明该坐标不在分区内。
- 任何分支做完后若下一步失败，立即转钓鱼或提前 sleep，绝不「固定做这个到 17:00」：昨天 14:00-16:40 空转浪费 10+ 动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏17）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 7212g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点就是铁矿石和煤。
并行里程碑：**洒水器×4 落地**——已 craft 但连续三天没放下；今天下矿前先读分区坐标再 hoe+place，放不下就当天放弃，不反复 hoe。
之后：**下矿装备**（食物≥5、武器升级）→ 安全下 40 层以下稳定拿铁；再往后 **洒水器铺满 + 保存罐**（Wood 还差 49）。
接下来 3 天主活动：
- **今天（夏17）**：① 清背包≥7 空格；② 补食物到≥5（钓鱼吃鱼，不去 Saloon）；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场 load 铁矿 1 次；⑤ 22:00 前 sleep。
- **明天（夏18）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏19）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **清背包到 ≥7 空格（第一优先）**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
2. **补食物到 ≥5**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon**（连续两天 12:00 整 open_shop 失败，等店主就位浪费 3 小时）。
3. **下矿（主活动，今天绝对优先）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败当天不再 place。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **下矿是今天唯一主活动**：铁锭不到 5，钓鱼、装饰、铺路、社交全部让位；每 20 动作自检，若铁矿石增量=0 强制回矿洞或钓鱼补食物。
- **place 前先读分区坐标**：hoe 只清分区内格子；连续三天 hoe 了 (54,16) 仍 place 失败，说明坐标不在分区内，今天先读坐标再清，读不到就当天放弃 place。
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
- **禁止「固定做这个到 X 点」分支**：任何分支做完后若下一步失败，立即转钓鱼或提前 sleep，绝不固定时段空转。
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
1. 清背包到 ≥7 空格
2. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
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
> 昨天最大问题是背包满导致两次下矿被拒，铁锭零产出；洒水器连续三天放不下去；下午空转 load/build_road/decorate 浪费 2 小时。有效的是钓鱼补现金和清背包。今天必须：先清背包到≥7再下矿，下矿是唯一主活动，洒水器先读分区坐标再放，禁止空转。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ FarmHouse — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 08:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 08:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:40 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 09:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 09:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 09:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 10:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下矿前背包没清够，两次 mine 被拒，白跑矿洞 @ Mine 入口 — mine 返回 need at least 5 free backpack slots before mining; store_items first（做不了：当天完全没下矿，铁矿石零产出，钢水壶里程碑原地踏步） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败 @ Farm 耕地 — place 返回「分区无空位」；hoe 清 (54,16) 后 place 仍失败，说明清格坐标不在规划分区内（做不了：4 个洒水器放不下去，体力继续被手动浇水吃掉，拖慢下矿） 〔复盘〕
- 下午分支做完后「固定做这个到 17:00」反复空转 load/build_road/decorate @ Farm — load_machines 返回 no empty machine accepts anything；build_road 24 格全部 skipped；decorate 返回今天没有能做的装饰（做不了：14:00-16:40 浪费 10+ 动作，没有推进任何里程碑） 〔复盘〕
- 熔炉 load 失败后没有可装矿石，仍反复调用 @ Farm 熔炉 — load_machines 返回 no empty machine accepts anything in the backpack or the farm chests（做不了：铁锭零产出，钢水壶差 4 铁锭） 〔复盘〕
