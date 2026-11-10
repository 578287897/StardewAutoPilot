# 第2年 summer 22 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（05:13 开始）
- 天气：storm　金钱：11013g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_summer_22）准备的脚本
- 里程碑：钢水壶升级（差4铁锭）——今天主活动下矿40层以下拿铁矿石+煤
- 补食物≥5（现有11个可回血食物，已达标，跳过钓鱼）
- 清背包到≥7空格再下矿
- 下矿≤2次，目标5+铁矿石
- 回农场装炉炼铁1次（有矿才装）
- 铁锭≥5且现金≥5000g 则9:10-15:30去Blacksmith升钢水壶
- 傍晚浇水/收机器，22:00前sleep
1. `donate`
2. `store_items`（items=["Stone", "Copper Ore", "Geode", "Dwarf Scroll I", "Refined Quartz", "Bamboo Pole", "Silver Saber", "Garlic Seeds", "Rice Shoot"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=10）
5. `fight`（range=6）
6. `mine`（floors=10）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `water_crops`
12. `goto_location`（location="Mountain"）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="watering can"）
15. `goto_location`（location="Farm"）
16. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：b0eb7fe59ae0482fa17eae9e2ea3736a
  - 耗时：17.265 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：8abefb0e7f914d39806c46676bec34c7
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：3b8df66237b448ab80ea10f2cb95a10d
  - 耗时：13.75 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 6 crops
  - 执行状态：SUCCESS · 操作编号：9e781e65fde54d8d81f2057bf5f4845d
  - 耗时：15.125 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Hops
- **06:50** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：ccad33f48403450fb2b746225e706117
  - 耗时：0.156 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 5 stacks worth ~692g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：68f9ac556bc94de78cb12e156816311a
  - 耗时：9.5 秒 / 游戏 20 分钟
- **07:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：d03c9f9b07d24963b64804a522c3bbcc
  - 耗时：0.14 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因巫师信未到必失败，跳过献祭分支；按原路线清背包到≥7格后下矿拿铁，回农场装炉收机器再睡。
1. `store_items`（items=["Stone", "Geode", "Dwarf Scroll I", "Refined Quartz", "Bamboo Pole", "Silver Saber", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
2. `goto_location`（location="Mine"）
3. `mine`（floors=10）
4. `fight`（range=6）
5. `mine`（floors=10）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `load_machines`（item="Iron Ore"）
9. `collect_machines`
10. `sleep`
- **07:10** Farm ✅ `store_items`（items=["Stone", "Geode", "Dwarf Scroll I", "Refined Quartz", "Bamboo Pole", "Silver Saber", "Garlic Seeds", "Rice Shoot", "Coffee Bean"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：903d5e54616c4648a89873602b2b5123
  - 耗时：1.015 秒 / 游戏 0 分钟
- **07:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：aef84d4d8b4b4862b6e206af1c7b2052
  - 耗时：44.828 秒 / 游戏 50 分钟
- **08:00** Mine ✅ `mine`（floors=10）
  - 结果：mined from floor 35 to 39 (4 floors down, 12 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：2be1f081aa27402390c418ad82e2ca5c
  - 耗时：18.094 秒 / 游戏 20 分钟
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
- **08:20** UndergroundMine39 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：14a1f48821cc4d82921d3315b975dba9
  - 耗时：0.14 秒 / 游戏 0 分钟
- **08:20** UndergroundMine39 ✅ `mine`（floors=10）
  - 结果：mined from floor 39 to 39 (0 floors down, 0 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：9711a252d7264a67958a69dd60c18856
  - 耗时：0.125 秒 / 游戏 0 分钟
- **08:20** UndergroundMine39 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：775fe5cb3b8f4f00a22699a4c435b388
  - 耗时：1.844 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **08:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：8f753efb56784f35aa31f8378a7d9410
  - 耗时：35.641 秒 / 游戏 50 分钟
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：25ce55cdb67b4cc49082423905e58fe3
  - 耗时：0.157 秒 / 游戏 0 分钟
- **09:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：8b89fa9563d24e4da02efba3f6b8be4d
  - 耗时：7.328 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **09:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：0c3ec1e55ef74f7fa7690eb13130cf9c
  - 耗时：0.313 秒 / 游戏 0 分钟
- **09:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：f95aa92edcb74b45b00b147f0458e1d5
  - 耗时：3.531 秒 / 游戏 0 分钟
- **09:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：5ca7b8f83d0d4a8a9b2e6b98c90eee8e
  - 耗时：0.125 秒 / 游戏 0 分钟
- **09:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3122525a237a46f086af69531b7956e9
  - 耗时：6.735 秒 / 游戏 10 分钟
- **09:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：14b34e3971fe40dcb7ac6e7ca1372f5b
  - 耗时：12.454 秒 / 游戏 20 分钟
- **09:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：845bd83262444ef8ae91afcaaebd85b4
  - 耗时：15.937 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **10:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：e247b094e8be4f8e950c538e82c45a4e
  - 耗时：0.328 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **10:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：5f5a726c56cd44fa9fdf05c6775f6e02
  - 耗时：0.188 秒 / 游戏 0 分钟
- **10:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：28e936970e3f448d91af109e27a1c774
  - 耗时：28.469 秒 / 游戏 40 分钟
- **10:50** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：d6e6ef9efa384c9fa7fd44c2087a8ea7
  - 耗时：20.078 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **11:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：2223e57461274627be6176a8fef5a489
  - 耗时：4.75 秒 / 游戏 10 分钟
- **11:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：3b99dd190f9e44d9b45c13569e0f37ca
  - 耗时：3.672 秒 / 游戏 10 分钟
- **11:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：b037ffd478e140a9927ac85d4d05fcfe
  - 耗时：25.609 秒 / 游戏 30 分钟
- **12:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：ec99372d96ef40cab83de433e943a57c
  - 耗时：27.969 秒 / 游戏 40 分钟
  - 🗨️ [hud] Copper Bar
- **12:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：4a7179cf8c564baca94f51d8c9804fcd
  - 耗时：0.172 秒 / 游戏 0 分钟
- **12:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：165cdae6072e4a0db6e604e3ebd21613
  - 耗时：19.0 秒 / 游戏 20 分钟
- **13:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **13:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Joja Cola, Soggy Newspaper, Soggy Newspaper)
  - 执行状态：SUCCESS · 操作编号：b3a3577c6d5c48e89d005c23d15244a5
  - 耗时：26.375 秒 / 游戏 40 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Soggy Newspaper
- **13:40** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：a1319f9c49d74162a33ecf4525537aec
  - 耗时：20.016 秒 / 游戏 30 分钟
- **13:40** Farm ✅ `ship`（item="Soggy Newspaper", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Soggy Newspaper (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：da7066cca20a42e799fe6788ba4948b7
  - 耗时：0.14 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Broken CD, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：c6f58f827ef249b28fd3562e5c14e706
  - 耗时：37.625 秒 / 游戏 50 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Broken CD
- **15:00** Farm ✅ `ship`（item="Broken CD", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：1acc8b81f8234c76b62e0fc61315f69e
  - 耗时：2.875 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：3f51d481797b4ff5b360e7d041a5149b
  - 耗时：0.156 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `wait`（minutes=120, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：8c5f4fa96a8c42f1a8af591b71b6b1e5
  - 耗时：82.015 秒 / 游戏 120 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：70967a6c53554acf8fe8aef44f908728
  - 耗时：7.594 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：11013 → 11755（+742g）
- 出货估值：692g　动作：42 个　失败：11 个
- 模型调用：3 次　tokens：36571
- 有效动作率：0.725　空转：8　熔断跳过：0
- 失败耗时：92.924 秒 / 游戏 120 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动下矿因食物不足停在39层，铁矿石零产出；下午陷入「固定做到17:00」空转，load×3、build_road×5、decorate×2 全失败，浪费约4小时。有效动作集中在上午收机器和出货。今天必须先把食物补到≥5、背包清到≥7，再一次性下矿冲40层以下；机器只做一轮，失败即转钓鱼，绝不设固定时段分支。

**新教训：**
- 昨天两次 mine 都停在 39 层，原因是「only 3 healing food (need 5+ for floor 40 and below)」——下矿前食物必须 ≥5，否则只能停在 40 层门口，铁矿石零产出。
- 昨天 14:00-16:40 的「固定做到 17:00」分支让 load×3、build_road×5、decorate×2 全部空转，浪费约 4 小时；任何动作失败一次即转钓鱼或 sleep，脚本层不设固定时段分支。
- build_road 连续 5 次返回「24 skipped: blocked by trees/crops/objects」——农场未清障前铺路必然失败，应完全禁用 build_road，直到农场清出空地。
- decorate 返回「今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）」——没有畜舍和装饰材料时 decorate 必失败，脚本层应直接跳过该分支。
- 洒水器已 craft 但连续三天 place 失败，说明问题不在 craft 而在坐标：今天若读不到规划分区坐标，直接放弃 place 分支，把时间全给下矿，不要用 hoe 试探。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏23）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 11013g 已够，铁锭 1、Iron Ore 3、Coal 10，**差 4 铁锭**，唯一卡点是铁矿石+煤。
并行里程碑：**下矿装备（安全下 40 层以下）**——现在食物只有 3 个，必须先补到 ≥5；**洒水器×4 落地**——已 craft，连续三天 place 失败，今天只在读得到分区坐标时做一次，读不到当天放弃。
接下来 3 天主活动：
- **今天（夏23）**：① 先去 Forest 河边钓鱼把可吃食物补到 ≥5（≤2 轮）；② 清背包到 ≥7 空格；③ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；④ 回农场装炉炼铁 1 次；⑤ 22:00 前 sleep。
- **明天（夏24）**：收铁锭；铁锭≥5 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏25）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **补食物到 ≥5（第一优先）**：背包回血食物<5 时，直接去 **Forest 河边或 Mountain 湖** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
2. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具/钓到的垃圾存箱子或 ship；空格<7 禁止下矿。
3. **下矿（主活动）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时或空格被拒一次即当天不再调 mine，转钓鱼。**
4. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。
5. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect。
6. **洒水器 place（仅当第 1-5 步都完成且时间<17:00）**：先读规划分区坐标，`use_tool` hoe 清**分区内**一格 → `place` 同一格；最多 6 次，连续 3 次失败或读不到分区坐标当天不再 place。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
10. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天食物优先于一切**：食物<5 时禁止下矿，先钓鱼补食物；下矿是今天唯一主活动，铁锭不到 5，钓鱼、装饰、铺路、社交全部让位。
- **下矿前食物≥5 是硬门槛**：昨天两次 mine 都停在 39 层「only 3 healing food」，等于白跑；今天钓鱼补到 ≥5 之前不调 mine。
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
> 昨天主活动下矿因食物不足停在39层，铁矿石零产出；下午陷入「固定做到17:00」空转，load×3、build_road×5、decorate×2 全失败，浪费约4小时。有效动作集中在上午收机器和出货。今天必须先把食物补到≥5、背包清到≥7，再一次性下矿冲40层以下；机器只做一轮，失败即转钓鱼，绝不设固定时段分支。
- 07:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 09:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 09:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 09:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 10:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 两次下矿都停在 39 层，铁矿石几乎零产出，钢水壶仍差 4 铁锭 @ Mine 39 层 — mine 返回「stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)」（做不了：钢水壶无法升级，铁锭进度卡住） 〔复盘〕
- 下午 14:00-16:40 陷入「固定做到 17:00」空转，load×3、build_road×5、decorate×2 全失败，浪费约 4 小时游戏时间 @ Farm 熔炉旁/农场空地 — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects；decorate: 今天没有能做的装饰（做不了：下矿和钓鱼都没做成，当天有效动作率仅 0.49） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，无法落地 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- donate 失败，社区中心献祭进度卡住 @ Community Center — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：暂时无法捐献，需等巫师来信） 〔复盘〕
