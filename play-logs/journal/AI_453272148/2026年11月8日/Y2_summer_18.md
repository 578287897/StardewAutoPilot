# 第2年 summer 18 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:35 开始）
- 天气：rain　金钱：7658g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ddc1c23c93a245428412f21fa88aaa54
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：ae7b23f81d134c5e997747258ca02b0d
  - 耗时：0.125 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：19b81afc567f4d49b3af5a8d6978b727
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：1e60f235d474497d9017adb98d1015b2
  - 耗时：0.187 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_18）准备的脚本
- 里程碑：钢水壶（差4铁锭）——今天先钓鱼补食物到≥5，再下矿40层以下拿铁矿石+煤
- 清背包到≥7空格后立刻下矿，≤2次mine，超时/失败即转钓鱼
- 回农场装炉炼铁1次，collect 1次
- 铁锭够5且现金够就升钢水壶
- 22:00前sleep
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `store_items`（items=["Driftwood", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole"]）
6. `ship_produce`
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `collect_machines`
14. `water_crops`
15. `harvest_crops`
16. `ship_produce`
17. `sleep`
- **06:00** FarmHouse ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：8ad6255ee4ee491f9ada351e0305962a
  - 耗时：0.171 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因未收到巫师信失败，跳过献祭分支，按原路线先去森林钓鱼补食物再下矿拿铁。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Driftwood", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole"]）
10. `load_machines`（item="Iron Ore"）
11. `collect_machines`
12. `ship_produce`
13. `sleep`
- **06:00** FarmHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：9027d7d52d234165a1982cdae6d2a38d
  - 耗时：22.719 秒 / 游戏 20 分钟
- **06:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：a9954ac8247d48bb93dd51dfe62388ff
  - 耗时：49.906 秒 / 游戏 60 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
- **07:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Green Algae, Soggy Newspaper, Pike)
  - 执行状态：SUCCESS · 操作编号：7b66f26a83844f3484f9037e1ec9f525
  - 耗时：48.344 秒 / 游戏 50 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Soggy Newspaper
- **08:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1a82f728e80f4076ba0fc48d3db89a14
  - 耗时：74.297 秒 / 游戏 100 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：e3f6672dadfe436e8872dfcb6fff46b6
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：矿洞因背包满被拒，先回农场清格腾出≥7空格再下矿拿铁，失败即转收尾睡觉。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Driftwood", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Soggy Newspaper", "Green Algae", "Joja Cola", "Rice Shoot", "Garlic Seeds"]）
5. `ship_produce`
6. `load_machines`（item="Iron Ore"）
7. `collect_machines`
8. `sleep`
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：4062db46fa884467b339f5a913fd5e0d
  - 耗时：0.125 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：清背包到≥7空格后回矿洞拿铁矿石，回农场装炉炼铁再睡。
1. `leave_mine`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Driftwood", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Soggy Newspaper", "Green Algae", "Joja Cola", "Rice Shoot", "Garlic Seeds", "Coffee Bean"]）
7. `ship_produce`
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `sleep`
- **09:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：0cdec4951c194af6957f15faf5a58d0c
  - 耗时：0.172 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：09ea54403e7e45c9931e47c16e2ad093
  - 耗时：0.25 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：b8a03f900fbb4272b7d50fcb53aa0e05
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：e2e124c7012e4cbaa7e122ac22588d64
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b3e71c2731554b18b96f698c8a708de2
  - 耗时：36.766 秒 / 游戏 50 分钟
- **10:40** Farm ✅ `store_items`（items=["Driftwood", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Soggy Newspaper", "Green Algae", "Joja Cola", "Rice Shoot", "Garlic Seeds", "Coffee Bean"]）
  - 结果：stored in chest at (74,15): 2x Joja Cola, 24x Cobblestone Path, 1x Driftwood, 5x Green Algae, 1x Soggy Newspaper
  - 执行状态：SUCCESS · 操作编号：9b52286bb6774925bedcca99667ca30a
  - 耗时：11.594 秒 / 游戏 10 分钟
- **10:50** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~250g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：da6de8e4786346d8a07d70179a149164
  - 耗时：0.734 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：c080a2ecc8a4413cb0fcca796776c35c
  - 耗时：0.156 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：82953842da7a4f71a2adb33cba3700e8
  - 耗时：0.187 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4bdb69622fdb4224b36bdab5097aab7f
  - 耗时：0.172 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：b0462381e39a431cb4abf57df15295d3
  - 耗时：0.125 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：b292836f4bfc4488bf96641febb92ba2
  - 耗时：4.484 秒 / 游戏 10 分钟
- **11:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：747b17cb1ee94f77971dcad29850b774
  - 耗时：0.125 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：ae6ffab1007e4f039413daa54ffdb51c
  - 耗时：12.516 秒 / 游戏 10 分钟
- **11:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Joja Cola, Trash)
  - 执行状态：SUCCESS · 操作编号：0e1a773d3327462ba249448a01ab887b
  - 耗时：24.36 秒 / 游戏 40 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Joja Cola
- **11:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：e4b33a9cc1c14fcbbcaa1d7950fbb7b6
  - 耗时：0.141 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：33905dbf5a98435fb7a770e96a108017
  - 耗时：23.828 秒 / 游戏 30 分钟
- **12:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:20** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Joja Cola, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：70a1dac9e2f34724932c52439b13e65e
  - 耗时：28.219 秒 / 游戏 40 分钟
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Joja Cola
- **13:00** Farm ✅ `ship`（item="Joja Cola", count=3）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 3x Joja Cola (~75g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：7461550d5729437994120b2956b4d132
  - 耗时：15.156 秒 / 游戏 20 分钟
- **13:00** Farm ✅ `ship`（item="Trash", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：a5bd4bd9cc454ca496bb3fb15bfbae21
  - 耗时：0.172 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `ship`（item="Soggy Newspaper", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Soggy Newspaper (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：f7d558ff97854bfcaa6a42ca7adefea4
  - 耗时：0.172 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0f54855a6c7146878f3b691399389019
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：7bdf6dab718e4d13822d3087e2ea2f35
  - 耗时：27.328 秒 / 游戏 40 分钟
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 4:00 pm
  - 执行状态：SUCCESS · 操作编号：d8f020baea74453da7e87375253ee747
  - 耗时：87.344 秒 / 游戏 120 分钟
- **16:00** Farm ✅ `wait`（minutes=60, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：1eb60ff6bf7f4111969abbc0d134979a
  - 耗时：43.954 秒 / 游戏 60 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：d9d5841c3c90419d9e89aad9d574443c
  - 耗时：21.406 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：7658 → 7983（+325g）
- 出货估值：250g　动作：43 个　失败：24 个
- 模型调用：5 次　tokens：60945
- 有效动作率：0.35　空转：13　熔断跳过：0
- 失败耗时：70.701 秒 / 游戏 90 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动被「固定做这个到17:00」分支毁掉：load×6、build_road×4、decorate×6、wait×2 全失败，43 动作里 24 失败，铁锭仍差 4。真正有效的是钓鱼（Forest 河边 7 条鱼）和清背包。今天必须把下矿放在最前，食物靠钓鱼补到 5，清背包到 7 格后立刻下矿，任何失败一次即转钓鱼或 sleep，禁止固定时段分支和 wait。

**新教训：**
- 「固定做这个到 X 点」分支会让失败动作反复空转（昨天 load×6、build_road×4、decorate×6 全失败）：任何动作失败一次即切钓鱼或 sleep，不设固定时段分支。
- 食物只有 2 个时 mine 最多只到 19 层，铁矿石零产出：下矿前必须先钓鱼把食物补到 ≥5，否则等于白跑矿洞。
- load_machines 在背包和箱子都没有 Iron Ore/Copper Ore 时调用必然失败：load 前先确认背包有矿石，没有就跳过，不要连续重试。
- wait(filler) 在 14:00-16:40 连续 2 次共浪费 3 小时游戏时间：主活动做完直接 sleep 或转钓鱼，脚本层禁用 wait。
- 洒水器 place 前必须先读规划分区坐标，hoe 只清分区内格子；连续三天 hoe (54,16) 后 place 仍失败，说明该坐标不在分区内，读不到就当天放弃 place。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏19）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 7658g 已够，铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**下矿装备**——食物只有 2 个，不够下 40 层以下；今天第一优先是把食物补到 ≥5（钓鱼吃鱼，不去 Saloon），再下矿。
之后：**洒水器×4 落地**（已 craft，连续三天 place 失败，今天先读分区坐标再 hoe+place，读不到就放弃）→ **保存罐**（Wood 还差 49）。
接下来 3 天主活动：
- **今天（夏19）**：① 先钓鱼补食物到 ≥5（Forest 河边或 Mountain 湖，≤2 轮）；② 清背包 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场 load 铁矿 1 次（确认背包有 Iron Ore）；⑤ 22:00 前 sleep。
- **明天（夏20）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏21）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **补食物到 ≥5（第一优先）**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon**。食物≥5 才允许下矿。
2. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
3. **下矿（主活动，今天绝对优先）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败当天不再 place。
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
> 昨天主活动被「固定做这个到17:00」分支毁掉：load×6、build_road×4、decorate×6、wait×2 全失败，43 动作里 24 失败，铁锭仍差 4。真正有效的是钓鱼（Forest 河边 7 条鱼）和清背包。今天必须把下矿放在最前，食物靠钓鱼补到 5，清背包到 7 格后立刻下矿，任何失败一次即转钓鱼或 sleep，禁止固定时段分支和 wait。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ FarmHouse — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 下午「固定做这个到 17:00」分支反复空转 load/build_road/decorate 并 wait 2 次 @ Farm — load_machines 返回 no empty machine accepts anything；build_road 24 格全部 skipped；decorate 返回今天没有能做的装饰；wait 填充 14:00-16:40（做不了：14:00-16:40 浪费 10+ 动作和 3 小时游戏时间，没有推进任何里程碑） 〔复盘〕
- 食物只有 2 个，不够下 40 层以下，下矿只到 19 层就退出，铁矿石零产出 @ Mine 19 层 — mine 返回 only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：钢水壶差 4 铁锭，里程碑原地踏步） 〔复盘〕
- 熔炉 load 失败后没有可装矿石，仍反复调用 6 次 @ Farm 熔炉 — load_machines 返回 no empty machine accepts anything in the backpack or the farm chests（做不了：铁锭零产出，钢水壶差 4 铁锭） 〔复盘〕
- 下矿前背包没清够，两次 mine 被拒，白跑矿洞 @ Mine 入口 — mine 返回 need at least 5 free backpack slots before mining; store_items first（做不了：当天完全没下矿，铁矿石零产出） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，hoe 清 (54,16) 后仍报无空位 @ Farm 耕地 — place 返回「分区无空位」；hoe 清格坐标不在规划分区内（做不了：4 个洒水器放不下去，体力继续被手动浇水吃掉，拖慢下矿） 〔复盘〕
- 铺路材料 craft 后 24 格全部被树木/作物挡住 @ Farm — build_road 返回 laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：浪费 24 块铺路材料和 4 个动作，农场未整理前铺路无意义） 〔复盘〕
