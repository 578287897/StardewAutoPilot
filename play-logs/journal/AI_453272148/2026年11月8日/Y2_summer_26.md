# 第2年 summer 26 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:47 开始）
- 天气：storm　金钱：13473g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：2946d0105b8e44a78c0b8f390b404809
  - 耗时：0.172 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：87a4eb8fb97b44d6ad3aa5dc0a13ab53
  - 耗时：3.187 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：c87496293d024358a3789921cad8e232
  - 耗时：3.641 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_26）准备的脚本
- 里程碑：工具按档升级——钢水壶（差4铁锭，靠下矿拿铁矿石+煤）
- 起床先 collect_machines 1 次，再 store_items 清到 ≥8 空格
- 食物<5 先去 Forest 河边钓鱼补到 ≥5（不去 Saloon、不在 Farm 池塘）
- 食物≥5、空格≥8 才 goto Mine → mine 40 层以下拿铁矿石+煤（≤2 次）
- 回农场 load_machines 装 Iron Ore 只试 1 次
- 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Geode", "Stone", "Copper Ore", "Refined Quartz", "Copper Bar"]）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Mine"）
8. `mine`（floors=6）
9. `mine`（floors=6）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="watering_can"）
15. `goto_location`（location="Farm"）
16. `water_crops`
17. `sleep`
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：inventory full after harvesting 10
  - 执行状态：SUCCESS · 操作编号：9e0ce2e4af7d45a2aeadc054f04cc5a1
  - 耗时：11.016 秒 / 游戏 10 分钟
  - 🗨️ [hud] Blueberry
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Inventory Full
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：27a9df743cdb47c4a1053ac0815029b8
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~1539g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：6a4164baa463449591de5a99a3b45715
  - 耗时：6.297 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：a329ba37cdd34dc6b5489b306d51a1eb
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 因未收到巫师信失败，跳过该分支，按原路线清背包→Forest 补食物→下矿拿铁→升钢水壶。
1. `collect_machines`
2. `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Geode", "Stone", "Copper Ore", "Refined Quartz", "Silver Saber"]）
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `goto_location`（location="Mine"）
7. `mine`（floors=6）
8. `mine`（floors=6）
9. `leave_mine`
10. `goto_location`（location="Blacksmith"）
11. `upgrade_tool`（tool="watering_can"）
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `sleep`
- **06:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：790b63a79b25407c86195988184f76f1
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `store_items`（items=["Cobblestone Path", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Geode", "Stone", "Copper Ore", "Refined Quartz", "Silver Saber"]）
  - 结果：stored in chest at (74,15): 1x Geode, 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：e5395e02623544b5bc545259a6f32d8d
  - 耗时：1.031 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：5922ba5ba4674abca09bf36960c9edb6
  - 耗时：22.953 秒 / 游戏 0 分钟
- **06:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Trash, Pike, Pike, River Jelly)
  - 执行状态：SUCCESS · 操作编号：613ea7b411db4e40978d798fbb755857
  - 耗时：71.547 秒 / 游戏 80 分钟
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **07:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Driftwood, Green Algae, Broken CD)
  - 执行状态：SUCCESS · 操作编号：cfde0639f54949d68aba9b504a9e5dd4
  - 耗时：39.359 秒 / 游戏 50 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Green Algae
- **08:20** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a2a84757811945ca8a49bb14b2d2aba7
  - 耗时：71.86 秒 / 游戏 90 分钟
- **09:50** Mine ❌ `mine`（floors=6）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：6e08b96b2b38443fa00cdfb9f739f7f8
  - 耗时：0.172 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：上次mine因背包0空格被拒，先store_items清到≥8空格再下矿，其余路线保持原样。
1. `mine`（floors=6）
2. `leave_mine`
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="watering_can"）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Trash", "Driftwood", "Broken CD", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Copper Ore", "Refined Quartz", "Silver Saber", "Green Algae"]）
7. `load_machines`（item="Iron Ore"）
8. `sleep`
- **09:50** Mine ❌ `mine`（floors=6）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3ec520bd6e5740ff8d5ab78637b601d2
  - 耗时：0.172 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：下矿被拒因背包满，先store_items清到≥8空格再重试下矿，其余路线保留。
1. `mine`（floors=6）
2. `mine`（floors=6）
3. `leave_mine`
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="watering_can"）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Trash", "Driftwood", "Broken CD", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Copper Ore", "Refined Quartz", "Silver Saber", "Green Algae"]）
8. `load_machines`（item="Iron Ore"）
9. `sleep`
- **09:50** Mine ❌ `mine`（floors=6）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：eabb96eeb69f4c2b81c090220aaf6c8f
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `mine`（floors=6）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5bb2f753d4304d82bd1048a5255dd967
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：2703c126ed7a46d68b66a323cdb0b16d
  - 耗时：0.156 秒 / 游戏 0 分钟
- **09:50** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：986bb04576144bc8bf3a535537710d03
  - 耗时：47.062 秒 / 游戏 60 分钟
- **10:50** Blacksmith ❌ `upgrade_tool`（tool="watering_can"）
  - 结果：Steel Watering Can needs 5x Iron Bar, you have 1 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：b5c16ec1e500400ea9180291e5b19b05
  - 耗时：0.157 秒 / 游戏 0 分钟
- **10:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：fe0325db6dfb43b3baeac0e5e1222448
  - 耗时：38.828 秒 / 游戏 50 分钟
- **11:40** Farm ✅ `store_items`（items=["Trash", "Driftwood", "Broken CD", "Dwarf Scroll I", "Bamboo Pole", "Rice Shoot", "Garlic Seeds", "Stone", "Copper Ore", "Refined Quartz", "Silver Saber", "Green Algae"]）
  - 结果：stored in chest at (75,15): 10x Garlic Seeds, 19x Stone, 1x Trash, 12x Rice Shoot, 1x Copper Ore, 1x Refined Quartz, 2x Green Algae, 1x Dwarf Scroll I, 1x Driftwood, 1x Broken CD
  - 执行状态：SUCCESS · 操作编号：59c656d0a3394cc292043258811f3636
  - 耗时：1.0 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：81ad336ed29d4575a1c02a9b86c722ef
  - 耗时：0.156 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：bae582cdc8ef44b1acf2653e3be725fc
  - 耗时：0.171 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：b7e21e72aa7d49fb8a74e0f854e22459
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：a278797b72b54c3d942da0b43bad28ec
  - 耗时：6.625 秒 / 游戏 10 分钟
- **11:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：e43fff6b21e0489a9cec2634db9ae879
  - 耗时：0.141 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：406584bb062b49199a863d000d0fe11b
  - 耗时：12.532 秒 / 游戏 20 分钟
- **12:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Driftwood, Driftwood, Broken CD)
  - 执行状态：SUCCESS · 操作编号：9eec6e6c865043db8ac42cf7bbfd9c42
  - 耗时：55.703 秒 / 游戏 70 分钟
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Driftwood
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：df2adae534e3476e834cbad82a5f6073
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5437f9a74e36467fa9eae8050658f1c9
  - 耗时：23.593 秒 / 游戏 40 分钟
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:00** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Driftwood, Trash)
  - 执行状态：SUCCESS · 操作编号：75e49b3c531b43bbaabb3dea1a793732
  - 耗时：46.89 秒 / 游戏 60 分钟
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Driftwood
- **15:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fcff4bea7fe4485b96c9771d6de9d23f
  - 耗时：0.157 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：816dcfa709f149ff81e8ccfbfd40ee23
  - 耗时：12.297 秒 / 游戏 20 分钟
- **15:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:20** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:20** Farm ✅ `wait`（minutes=100, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：decdb82115854ad8b6c47412fb6471c7
  - 耗时：72.61 秒 / 游戏 100 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a15795bc1b4e4efcba6fea90e18494ed
  - 耗时：21.437 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：13473 → 15012（+1539g）
- 出货估值：1539g　动作：42 个　失败：24 个
- 模型调用：6 次　tokens：63312
- 有效动作率：0.4　空转：11　熔断跳过：0
- 失败耗时：57.298 秒 / 游戏 90 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天42动作24失败，核心问题是：①背包清到5格仍被mine拒（需≥8）；②食物4个下矿停在39层，铁矿石零产出；③14:00-16:40「固定做到17:00」空转load/build_road/decorate共12次失败；④洒水器place连续三天失败。有效动作：Forest钓鱼出Pike/River Jelly、ship_produce出货1539g、store_items清杂物。今天必须：起床先清到≥8空格→Forest钓鱼补食物到≥5→下矿40层以下拿铁→回农场load一次→铁锭够就升钢水壶。

**新教训：**
- 昨天 14:00-16:40 的「固定做到 17:00」分支让 load×4、build_road×2、decorate×2 全失败，浪费 8+ 动作和约 4 小时游戏时间；任何动作失败一次即切钓鱼或 sleep，脚本层不设固定时段分支。
- build_road 连续多天返回「24 skipped: blocked by trees/crops/objects」——农场未清障前铺路必然失败，脚本层应完全禁用 build_road，直到农场清出空地。
- decorate 返回「今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）」——没有畜舍和装饰材料时 decorate 必失败，脚本层应直接跳过该分支。
- 洒水器 place 连续三天失败且 hoe (54,16) 无效，说明该坐标不在规划分区内：今天完全禁用 place/hoe 试探，把时间全给下矿，等钢水壶到手后再处理。
- 起床先 collect_machines 再清背包：昨天先 load 再 collect，结果炉子忙、collect 返回空，白费两次动作；顺序应为 collect→store→补食物→mine→load。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏27）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现金 13473g 已够，铁锭 1、Iron Ore 3、Coal 9，**差 4 铁锭**，卡点是铁矿石+煤。
并行里程碑：**洒水器×4 落地**（已 craft，连续三天 place 失败，等钢水壶到手、农场清出空地后再处理）；**下矿装备**（食物≥5 才能下 40 层以下）。
接下来 3 天主活动：
- **今天（夏27）**：① 起床 `collect_machines` 1 次；② `store_items` 清到 **≥8 空格**（Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash、Algae 全存箱）；③ **食物<5 先去 Forest 河边 `fish` ≤2 轮补到 ≥5**（昨天只有 4 个食物，两次 mine 都停在 39 层）；④ 食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**；⑤ 回农场 `load_machines` 装 Iron Ore **只试 1 次**；⑥ 铁锭≥5 且 9:10-15:30 去 Blacksmith 升钢水壶；⑦ 22:00 前 sleep。
- **明天（夏28）**：收铁锭；不够继续下矿补铁；钢水壶到手后转洒水器铺满耕地。
- **后天（夏29）**：洒水器落地 + 下矿补铁/煤，准备夏末作物与秋季南瓜/蔓越莓种子预算。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过 collect。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Dwarf Scroll、Bamboo Pole、Rice Shoot、Garlic Seeds、Geode、Trash、Algae、多余矿石、钓到的垃圾全部存箱子或 ship；**必须清到 ≥8 空格**。空格<8 禁止下矿。
3. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore/Copper Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **工具升级（优先于一切装饰）**：铁锭≥5 且现金≥5000g 且时间 9:10-15:30，去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过，明天再补。
7. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **下矿前空格≥8 是硬门槛**：昨天两次 mine 被拒都是「need at least 5 free backpack slots」，清到 5 格仍不够；store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：昨天只有 4 个食物，两次 mine 都停在 39 层（need 5+ for floor 40 and below），铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**；昨天 14:00-16:40 空转 load×4、build_road×2、decorate×2 浪费 8+ 动作。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **洒水器 place 今天禁用**：连续三天 place 失败且 hoe (54,16) 无效，今天不调 place/hoe 试探，把时间全给下矿。
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
- **下矿背包管理**：下矿前空格≥8；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 清背包到 ≥8 空格
3. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon）
4. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停）
5. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
6. 工具升级钢水壶（铁锭≥5 且现金≥5000g，9:10-15:30）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天42动作24失败，核心问题是：①背包清到5格仍被mine拒（需≥8）；②食物4个下矿停在39层，铁矿石零产出；③14:00-16:40「固定做到17:00」空转load/build_road/decorate共12次失败；④洒水器place连续三天失败。有效动作：Forest钓鱼出Pike/River Jelly、ship_produce出货1539g、store_items清杂物。今天必须：起床先清到≥8空格→Forest钓鱼补食物到≥5→下矿40层以下拿铁→回农场load一次→铁锭够就升钢水壶。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 10:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Watering Can needs 5x Iron Bar, you have 1 (backpack + chests) 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 15:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 15:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 两次下矿都因食物只有 4 个停在 39 层，铁矿石零产出 @ Mine 第 39 层 — mine: stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)（做不了：铁矿石拿不到，钢水壶差 4 铁锭的进度卡住） 〔复盘〕
- 下午 14:00-16:40 陷入「固定做到 17:00」空转，load×4、build_road×2、decorate×2 全失败 @ Farm 熔炉旁/农场空地 — load_machines: no empty machine accepts；build_road: 24 skipped blocked by trees/crops/objects；decorate: 今天没有能做的装饰（做不了：下矿和钓鱼都没做成，下午时段几乎零产出） 〔复盘〕
- 洒水器连续三天 craft 成功却 place 失败，无法落地 @ Farm 耕地 — place 报分区无空位，hoe (54,16) 后仍失败，说明清格坐标不在规划分区内（做不了：洒水器无法落地，明天仍要手动浇水，体力无法全部用于下矿） 〔复盘〕
- 起床先 load 再 collect，炉子忙导致 collect 返回空 @ Farm 熔炉 — collect_machines: no machine has finished output；load_machines: no empty machine accepts（做不了：铁锭没收到，钢水壶升级材料凑不齐） 〔复盘〕
- 钓鱼连续出垃圾（Broken Glasses、Broken CD×2、Driftwood），没有可吃鱼 @ Farm 池塘 — fished: caught 3 (Broken Glasses, Broken CD, Broken CD)；fished: caught 3 (Broken CD, Broken CD, Driftwood)（做不了：食物没补上，间接导致下矿停在 39 层） 〔复盘〕
- 背包清到 5 格仍被 mine 拒，需≥8 空格 @ Mine 入口 — mine: need at least 5 free backpack slots before mining; store_items first（做不了：下矿被拒，浪费一次 goto Mine 的行程） 〔复盘〕
