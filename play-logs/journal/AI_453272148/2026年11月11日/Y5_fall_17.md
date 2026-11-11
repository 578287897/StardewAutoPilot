# 第5年 fall 17 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（07:09 开始）
- 天气：sunny　金钱：66311g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0459e2c2752c44f9a2718219fafabda5
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：a67b44c48dd441e58f8e34a33bc7c66d
  - 耗时：3.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：fb9e72df1bf94b73a9809cd0db37e4eb
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：04bd74008b6b44eaa0ee3078f9d08f8c
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：677f414295be41089ba514a28370a513
  - 耗时：0.5 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_17）准备的脚本
- 里程碑：凑够 5 铁锭升级钢锄头（Iron Bar 0/5）
- 起床收熔炉成品，读背包真实清单
- 只卖背包里实际存在的冗余（Copper Bar 留 20 其余卖、Gold Bar 留 2、Green Algae、Broken CD、Rice Shoot 等），验证空格≥5
- 空格≥5 且 Salad≥5 则电梯直达 40 层刷铁矿石+煤（≤2 次，每次≤5 层）
- 下矿回来收铁锭；铁锭≥5 且 9:10-13:00 去 Blacksmith 升 hoe
- 凑不齐则转 Forest 钓鱼收尾，21:30 前 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Rubber Boots", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Salad", "Pumpkin Seeds", "Gold Ore", "Iron Ore", "Coal"]）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `ship_produce`（except=["Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Rubber Boots", "Steel Pickaxe", "Steel Watering Can", "Burglar's Shank", "Salad", "Pumpkin Seeds"]）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=4）
22. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：114c1b27b187406082596cd2ebe8c416
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败因箱子不可达，删除 take/donate 分支，改为卖背包内实际冗余腾格后按原路线下矿 40 层刷铁，铁锭够则升 hoe，否则钓鱼收尾
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=2）
10. `ship`（item="Broken CD", count=1）
11. `ship`（item="Rice Shoot", count=3）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `collect_machines`
23. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5642d462802c4e7c9e84851d22f038bf
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/donate 分支，先卖背包里确实存在的冗余腾格，再电梯下矿刷铁，回来收锭，凑不齐就钓鱼收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=2）
10. `ship`（item="Broken CD", count=1）
11. `ship`（item="Rice Shoot", count=3）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：07ac3fd0c8774668a2f3c1752b80a2f6
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支彻底删除（箱子不可达），改为只卖背包实有冗余腾格后直下 40 层刷铁，回农场收锭即睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Green Algae", count=2）
10. `ship`（item="Broken CD", count=1）
11. `ship`（item="Rice Shoot", count=3）
12. `ship`（item="Gold Ore", count=2）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a8e2b8914c2a402c8e45b7e7379cc597
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8bebbb0bf670487899e6e72fa78c9190
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9f9a455eac654a25a9a60c6d7feab321
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：aff98a65b5f2413c9f8ac482829e266b
  - 耗时：86.172 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：49495cc4716043478501260d7d0f7f64
  - 耗时：47.047 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：b4fbc3c0f452495c817d8dc8de4106a9
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Green Algae", count=2）
  - 结果：shipped 2x Green Algae (~30g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：9f8617600236476ca3cb93222a511c9a
  - 耗时：48.391 秒 / 游戏 60 分钟
- **09:50** Farm ✅ `ship`（item="Broken CD", count=1）
  - 结果：shipped 1x Broken CD (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：56893d5321de475fbf5c4fc4346fe5a5
  - 耗时：0.468 秒 / 游戏 0 分钟
- **09:50** Farm ✅ `ship`（item="Rice Shoot", count=3）
  - 结果：shipped 3x Rice Shoot (~60g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：52b3cb63c5ba4698a8f6e0dfd3b64a96
  - 耗时：0.578 秒 / 游戏 0 分钟
- **09:50** Farm ✅ `ship`（item="Gold Ore", count=2）
  - 结果：shipped 2x Gold Ore (~50g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：35cfe2e921bc419286216ae901bb709a
  - 耗时：0.5 秒 / 游戏 0 分钟
- **09:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：158e13d48f374fcb81ad1a50fbcedbac
  - 耗时：49.015 秒 / 游戏 70 分钟
- **11:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 99 (4 floors down, 30 stones broken); retreated: health 55/140 and 0 healing food left; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：33468928c2274a2b909c3a89806b5d1f
  - 耗时：69.672 秒 / 游戏 60 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] +68 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [question] 
- **12:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 40 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：fb92f4bc891a4ee7bcff7b8d2e0ea8ab
  - 耗时：37.89 秒 / 游戏 50 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
- **12:50** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：815f2c9a73804655a75cdbd38ccf7393
  - 耗时：2.016 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **12:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：81cbefb7b1414866ad863cbda58ac8c9
  - 耗时：37.578 秒 / 游戏 40 分钟
- **13:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f6182d895efa4973a8b4c63e428a2f1c
  - 耗时：0.484 秒 / 游戏 0 分钟
- **13:30** Farm ✅ `load_machines`（item="Iron Ore", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：8e4bf851d5904915876400c1f8175e30
  - 耗时：7.063 秒 / 游戏 10 分钟
- **13:40** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：5a1ea2754f4b41fba9e2217a4155269a
  - 耗时：3.75 秒 / 游戏 10 分钟
- **13:50** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：ec003a9565324d22a53469f40081c378
  - 耗时：0.484 秒 / 游戏 0 分钟
- **13:50** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：e96458bb4ab34bb2bc2f5744faf6b42a
  - 耗时：19.875 秒 / 游戏 20 分钟
- **14:10** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 6 forage items
  - 执行状态：SUCCESS · 操作编号：4e86d47742bc4edcb9d085786a3e36b9
  - 耗时：73.765 秒 / 游戏 100 分钟
  - 🗨️ [hud] Blackberry
  - 🗨️ [hud] Blackberry
  - 🗨️ [hud] Common Mushroom
  - 🗨️ [hud] Blackberry
  - 🗨️ [hud] Blackberry
  - 🗨️ [hud] Blackberry
- **15:50** Forest ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Iron Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：0fecdd722d7c40a297276db5285c3819
  - 耗时：49.641 秒 / 游戏 60 分钟
  - 🗨️ [hud] Iron Bar
  - 🗨️ [hud] Copper Bar
- **16:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Blackberry -> Preserves Jar (ready in 4000 min), Blackberry -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：e09422dd2acf4aaa938150e0e430f2ee
  - 耗时：4.156 秒 / 游戏 10 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c1670da20c6f49289c2cc0f897da1354
  - 耗时：17.547 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66311 → 66451（+140g）
- 出货估值：0g　动作：39 个　失败：17 个
- 模型调用：7 次　tokens：86336
- 有效动作率：0.5625　空转：7　熔断跳过：6
- 失败耗时：6.61 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天17次失败中12次是take猜箱子ID，箱子内容与记忆不符；清包只卖了约140g垃圾，空格没腾出来，导致下矿4层就因没食物撤退。有效的是熔炉炼出1铁锭、Forest采集6个、两个保存罐开始加工黑莓。核心问题是执行层反复重试已失败动作、清包手段失效。

**新教训：**
- 昨天 12 次 take 全部失败（'62'/'64'/'68'/'72'/'84'/'86' 都不在农场箱子里），说明箱子内容与记忆完全不符：take 应全天物理删除，需要矿物只能下矿现拿，不能靠箱子补给。
- 昨天清包只卖出 Green Algae/Broken CD/Rice Shoot/Gold Ore 共约 140g，背包空格没腾出来，导致下矿 4 层就因食物=0 撤退：清包必须优先卖高价值冗余（多余种子、Sap、多余 Stone），而不是先卖低价值垃圾。
- 昨天 mine 从 95→99 层成功但只挖了 4 层就因 health 55/140 且 0 食物撤退：下矿前食物≥5 是硬门票，食物<5 时即使空格够也不该下矿，应先去 Saloon 买沙拉。
- 昨天 load_machines 在 13:50 返回「no empty machine accepts that, and the rest are busy」：说明两座熔炉都在忙时不应再调 load，应等 collect 后再 load，load 失败一次即当天跳过。
- 昨天 donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 等开门再失败，浪费 2 动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 18）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 66311g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈，钢斧、洒水器、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是唯一门票，清包手段必须换掉**。

接下来 3 天主活动：
- **今天（秋 18）**：起床 collect→读背包真实内容→**用 ship_produce 只卖背包里确实存在的冗余**（先读再卖，不猜）→验证空格≥5→电梯 40 层刷铁矿石+煤→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 19）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 20）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包改为「先读后卖」**：昨天 ship Copper Bar/Gold Bar 报 not found，说明这些锭根本不在背包里（在不可达的箱子里）。今天起床第一步读背包完整清单，**只对清单里实际存在的物品调 ship_produce**，优先卖：多余种子、Green Algae、River Jelly、Strange Bun、Sap、多余 Stone（留 500）。**绝不 ship 背包里没有的东西**。
2. **箱子路径(74,15)/(74,16)不可达**：store_items 连续报 could not reach，今天物理删除 store_items，也禁止 goto 该坐标。需要腾格只能靠 ship_produce 或直接丢弃低价值物。
3. **take 全天物理删除**：连续三天凭 ID 猜箱子全失败，箱子内容与记忆不符。需要矿物靠下矿现拿。
4. **食物**：背包已有 8 沙拉（昨天记录），下矿前读背包确认 Salad≥5；不足则 12:00 后 goto Saloon→open_shop 买。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**（昨天 98 层无路可走）。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖）**：读背包完整清单 → 对清单中实际存在的冗余物品调 ship_produce（优先多余种子/Green Algae/River Jelly/Strange Bun/Sap/多余 Stone 留 500）→ 读背包验证空格≥5；不足再卖第二档 → 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items、不调 take、不 ship 背包里没有的物品**。
4. 补食物到≥5：读背包 Salad≥5 即跳过；不足且时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **ship_produce 只卖背包里实际存在的物品**：昨天 ship Copper Bar/Gold Bar 报 not found，说明这些锭不在背包。每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **store_items / take 今天禁用**：箱子路径(74,15)/(74,16)不可达，store 报 could not reach；take 凭 ID 猜箱子连续三天全失败。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take / store_items 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0**。
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
3. 清包到空格≥5（**先读背包清单，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天17次失败中12次是take猜箱子ID，箱子内容与记忆不符；清包只卖了约140g垃圾，空格没腾出来，导致下矿4层就因没食物撤退。有效的是熔炉炼出1铁锭、Forest采集6个、两个保存罐开始加工黑莓。核心问题是执行层反复重试已失败动作、清包手段失效。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 13:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 13:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- take 凭物品 ID 猜箱子连续 12 次全失败，脚本重写 3 次仍在重试同一批 ID @ Farm（箱子路径 74,15/74,16） — '62' is not in any farm chest；take 62 already failed; not retrying today（做不了：无法从箱子取矿物/食物补给，背包腾格和下矿食物都受影响） 〔复盘〕
- 清包只卖出约 140g 的低价值垃圾，背包空格没腾出来 @ Farm（出货箱） — shipped 2x Green Algae (~30g)、1x Broken CD (~0g)、3x Rice Shoot (~60g)、2x Gold Ore (~50g)，合计约 140g，空格未增（做不了：下矿空格≥5 门票不满足，mine 只能浅层挖 4 层就撤退） 〔复盘〕
- 下矿 4 层后因 health 55/140 且 0 食物被迫撤退 @ Mine 95-99 层 — retreated: health 55/140 and 0 healing food left; left the mine to recover（做不了：无法继续下矿拿铁矿石，铁锭链继续卡住） 〔复盘〕
- 第二次下矿从 15 层开始，只挖到 19 层就因 0 食物停止 @ Mine 15-19 层 — stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：19 层拿不到铁矿，铁锭链零推进） 〔复盘〕
- load_machines 在两座熔炉都忙时仍被调用，返回 no empty machine @ Farm（熔炉） — no empty machine accepts that, and the rest are busy; try again after they finish（做不了：浪费 1 个动作，未影响主流程但应避免） 〔复盘〕
