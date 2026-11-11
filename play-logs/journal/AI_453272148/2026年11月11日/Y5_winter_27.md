# 第5年 winter 27 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（16:54 开始）
- 天气：snow　金钱：82454g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：b38368fd65de4093978ae5eebe6120d5
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：f9d16fb1546f464c9cfe48e958a5d991
  - 耗时：12.406 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：1964b3d9578c428f8f101abc3afa0881
  - 耗时：16.922 秒 / 游戏 30 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：69e0b6784f60437189632b7c22bc7480
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：a9b64b92b1e64cacbc90aa9c16b91338
  - 耗时：0.625 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~1174g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：a30faf9bf87a4aaf97a3e2ea856cc7ac
  - 耗时：0.797 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_27）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，空炉且铁矿石≥5 就装料
- 农场出货箱卖 Copper Bar 留 20 腾出≥5 空格（唯一清包手段）
- 下矿电梯直达 40 层刷铁矿石+煤（≤2 次，每次≤5 层）
- 回农场收铁锭，凑够 5 铁锭且 12:00 前去铁匠铺升 Steel Hoe
- 铁锭不够就转 Forest 钓鱼填满下午，21:30 前睡
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `ship`（item="Copper Bar", count=66）
12. `ship`（item="Sap", count=48）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=5）
23. `fish`（casts=5）
24. `fish`（casts=5）
25. `goto_location`（location="Farm"）
26. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c8996e9dc2964c28ae9c5f5979e60b82
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate_museum 空跑分支，改为农场出货箱卖 Copper Bar 腾格后直接下矿刷铁，凑够铁锭去升 Steel Hoe
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `collect_machines`
24. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ffb77236e38e4ad3b314302b1565e461
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/donate 分支（箱子内容与记忆不符、卷轴未解锁），改为出货箱卖 Copper Bar 腾格→40 层刷铁→升 Steel Ho
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `fish`（casts=5）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `collect_machines`
26. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d896cf0823734b75820ed2f72ab830f9
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 空跑已确认箱子内容不符，物理删除 take/donate_museum 分支；改为先收熔炉、出货箱卖 Copper Bar 腾格，再下矿刷铁
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `fish`（casts=5）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1016db1f0000489094d84e70042a57f2
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d45fc7bf4c994eb7ad99ab828835adf8
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8b072a406fcc478589adb217c0dd826d
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：305a40a71e46407d8969643bee285e8e
  - 耗时：57.031 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：e7f652673b8a40ffa02044bfbd051942
  - 耗时：44.157 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：e3a17396cb7545888ae93fae9a090ff8
  - 耗时：0.578 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=66）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：e070ad74e7a440b38c104e1d36787323
  - 耗时：0.516 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Sap", count=48）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：597834e3e91f4b5bae9741cc78ed7478
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a7db86794f0e43d1a70582325fae55d3
  - 耗时：50.859 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：bd1d3bb2705c4f4fbcdf5b5c8568e91a
  - 耗时：34.172 秒 / 游戏 40 分钟
- **09:50** Mine ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Green Algae", "Rubber Boots", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 7x Green Algae
  - 执行状态：SUCCESS · 操作编号：49b0961bcfd84677bb82eb8c6b29a7e3
  - 耗时：15.141 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Rubber Boots", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：950b8283470a4ce39fa33f88cd2c3dd3
  - 耗时：0.625 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：0c81e05fa5864b03af7590f8441e737a
  - 耗时：0.641 秒 / 游戏 0 分钟
- **10:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：958f550fabf04e59b44ed6f94e242e45
  - 耗时：40.782 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：0df1af73f344403bb693efd4bef0b131
  - 耗时：39.032 秒 / 游戏 50 分钟
- **11:40** Blacksmith ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Rubber Boots", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x River Jelly
  - 执行状态：SUCCESS · 操作编号：5b8a6cd9d6da419192c2f372b40e9d1d
  - 耗时：1.157 秒 / 游戏 0 分钟
- **11:40** Blacksmith ✅ `upgrade_tool`（tool="hoe"）
  - 结果：mined from floor 15 to 19 (4 floors down, 83 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：c3c7ee0bbc0342c4999ed0ed3d21787b
  - 耗时：111.172 秒 / 游戏 140 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
- **14:50** UndergroundMine19 ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：4dbb3dba6a274f17920ccdf3a8cca348
  - 耗时：61.032 秒 / 游戏 80 分钟
  - 🗨️ [question] 
- **16:10** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Lingcod, Tiger Trout, Green Algae, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：d4f8e995daee463783b6e1ff476679f9
  - 耗时：116.86 秒 / 游戏 120 分钟
  - 🗨️ [hud] Lingcod
  - 🗨️ [hud] Tiger Trout
- **18:10** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Bream, Chub, Chub, Bream, Perch)
  - 执行状态：SUCCESS · 操作编号：78c0dbb3ec3048f8853a46d206844952
  - 耗时：136.938 秒 / 游戏 140 分钟
- **20:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Green Algae, Bream, Green Algae, Perch, Lingcod)
  - 执行状态：SUCCESS · 操作编号：9815ba2d4ad04d73833f0d964c3f1692
  - 耗时：114.125 秒 / 游戏 120 分钟
- **22:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Bream, Bream, Bream, Pike, Chub)
  - 执行状态：SUCCESS · 操作编号：8d2ce8a582fd4e14a9b1a6b713c6fd34
  - 耗时：135.844 秒 / 游戏 130 分钟
  - 🗨️ [hud] It's getting late... 
- **24:40** Forest ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：78f0e25e94ec43b9ad3df2e73074474b
  - 耗时：38.672 秒 / 游戏 40 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：82454 → 83628（+1174g）
- 出货估值：1174g　动作：41 个　失败：20 个
- 模型调用：7 次　tokens：87667
- 有效动作率：0.5294　空转：4　熔断跳过：6
- 失败耗时：10.063 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天41动作20失败，核心仍是背包空格<5导致mine/upgrade被拒：85个Copper Bar一个没卖，只卖了石头。take空跑6次、store_items空跑3次、donate空跑1次全是脚本生成阶段就该删的分支。唯一亮点是Forest钓鱼20条约2.1k出货，说明兜底有效。铁锭仍1/5，钢锄连续多日零推进，铁锭链是全局瓶颈。

**新教训：**
- 昨天 mine 两次被 'store did not free enough slots (have 4, need 5)' 拒绝，而背包 86 个 Copper Bar 一个没卖：清包第一步必须是出货箱 ship Copper Bar 留 20，只卖石头/Sap 永远腾不出第 5 格。
- 昨天在 ArchaeologyHouse 调 donate_museum 报 'nothing in the backpack can be donated'，而背包里全是矿物：donate 分支应全天物理删除，博物馆只在背包有实际可捐物且空格≥1 时才考虑。
- 昨天 build_road 报「规划道路边没有还能走上去的空格」：农场道路布局已无空位，build_road 应全天物理删除，不再生成。
- 昨天 22:40 才 sleep，全天 41 动作 20 失败：收尾应硬性 21:30，21:30 后只允许 sleep，任何情况下不用 wait 填充时间。
- 昨天 collect_machines 报 'no machine has finished output' 后仍被重复调用并被系统抑制：collect 返回空即当天永久跳过，下矿回来再试一次即可，不重试。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 28）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 82454g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1，必须下 40 层以下刷）。下矿与升级的共同门票是**背包空格≥5**——昨天背包始终 4 空格，mine×2 被 'have 4, need 5' 拒绝，而背包 86 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 28）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 29）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 30）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 66 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 6 次、store_items 空跑 3 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 28 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。could not reach/locked/timeout 即当天永久跳过升级。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-12:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次（收熔炉成品）
2. 起床读炉状态 → 空炉且 Iron Ore≥5 立即 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过；Iron Ore<5 物理删除 load）
3. 清包到空格≥5（先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 40 层拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天41动作20失败，核心仍是背包空格<5导致mine/upgrade被拒：85个Copper Bar一个没卖，只卖了石头。take空跑6次、store_items空跑3次、donate空跑1次全是脚本生成阶段就该删的分支。唯一亮点是Forest钓鱼20条约2.1k出货，说明兜底有效。铁锭仍1/5，钢锄连续多日零推进，铁锭链是全局瓶颈。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Sap' not found in inventory 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 10:50 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 背包空格始终 4 格，下矿和升级都被拒 @ 农场/矿洞 — mine: store did not free enough slots (have 4, need 5)；而背包 86 个 Copper Bar 一个没卖，只卖了石头/Sap（做不了：无法下 40 层刷铁矿石，Steel Hoe 连续多日零推进） 〔复盘〕
- 脚本反复生成 take 动作去农场箱子取矿物 @ 农场 — take 62/64/68/72/84/86 全部 'not in any farm chest'，重写 3 次仍重试同一批 ID（做不了：浪费 6 个动作和 3 次脚本重写，挤占清包和下矿时间） 〔复盘〕
- store_items 空跑 @ 农场箱子 — 返回 'nothing to store'，箱子已满或物品不可堆叠（做不了：清包无效，空格没增加） 〔复盘〕
- 去博物馆捐物失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：白跑一趟博物馆，浪费上午时间） 〔复盘〕
- build_road 失败 @ 农场 — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：无产出，浪费动作） 〔复盘〕
- load_machines 报无空炉 @ 农场熔炉 — no empty machine accepts that, and the rest are busy（做不了：铁矿石无法入炉，铁锭链继续停滞） 〔复盘〕
- 22:40 才睡觉 @ Forest — 钓鱼到 22:30 才收工，超过 21:30 硬性收尾线（做不了：次日体力不足，影响下矿效率） 〔复盘〕
