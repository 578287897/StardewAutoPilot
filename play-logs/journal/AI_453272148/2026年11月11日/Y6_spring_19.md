# 第6年 spring 19 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（22:25 开始）
- 天气：sunny　金钱：89633g　体力：270/270
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
  - 执行状态：NO_PROGRESS · 操作编号：b55c054162744330ae177820d429a36d
  - 耗时：3.375 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_19）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须打通铁锭链
- 起床 collect_machines 收熔炉成品，有空炉且铁矿石够才 load
- 农场出货箱无条件 ship Copper Bar 留 20 腾格子，验证空格≥5
- 空格≥5 且食物≥8 才电梯直达 40 层刷铁矿石+煤（≤2 次 mine）
- mine 成功一次后回农场 ship 腾格再决定第二次
- 回农场 collect 收铁锭，铁锭≥5 且 12:00 前升 hoe
- 清包失败或下矿失败立即转 Forest 钓鱼填满到 21:30
- 21:30 前 sleep
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
11. `goto_location`（location="Farm"）
12. `ship`（item="Copper Bar", count=71）
13. `ship`（item="Stone", count=0）
14. `goto_location`（location="Mine"）
15. `fight`（range=6）
16. `mine`（floors=5）
17. `fight`（range=6）
18. `mine`（floors=5）
19. `goto_location`（location="Farm"）
20. `ship`（item="Iron Ore", count=0）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Forest"）
25. `fish`（casts=10）
26. `goto_location`（location="Farm"）
27. `sleep`
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：18f09964ddfe4b93bb25ed2feb0c24de
  - 耗时：11.375 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Driftwood
  - 执行状态：SUCCESS · 操作编号：1e11dcf292ec408f861174d8d864bf96
  - 耗时：13.422 秒 / 游戏 20 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：c759cb37f4dc4bda85f6d0263e61ebca
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：fc584c98d8a94985b593e9c301024049
  - 耗时：0.579 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~50g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：9914cf63ba614d9a841402989e86789a
  - 耗时：0.813 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3072d3841efc47fd831a66e916fd2d0b
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 空跑失败后删除全部 take/donate 分支，改为农场出货箱 ship Copper Bar 腾格→下矿 40 层刷铁→回农场收锭→12
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=28）
11. `goto_location`（location="Mine"）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=10）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `collect_machines`
23. `ship`（item="Iron Ore", count=2）
24. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1a63292beeee43b4a79a30e03ee4709e
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/donate_museum 空跑分支，改为农场出货箱 ship Copper Bar 留 20 腾格后下矿刷铁，铁锭够则升 hoe
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=28）
11. `goto_location`（location="Mine"）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=10）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `collect_machines`
24. `ship`（item="Iron Ore", count=2）
25. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：de3312d23baf471bbd456d47cfa987e8
  - 耗时：0.579 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失败且箱子内容与记忆不符，物理删除 take/donate 分支；改为农场出货箱 ship Copper Bar 腾格后直达 40 层刷
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=28）
11. `goto_location`（location="Mine"）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=10）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `collect_machines`
23. `ship`（item="Iron Ore", count=2）
24. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9fa38beaf0f74df09e575eea99874e03
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ebb4a4abf09f46de84815818ada638fb
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a0dae8437d074d27bc3b53f7023407b2
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：6f497e0281cd448b90e19deb6395a18d
  - 耗时：61.578 秒 / 游戏 90 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：9acc4b049d244a3491b055713113ebc4
  - 耗时：44.156 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：20c6cc82f885476083fcc166dac56e8b
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=71）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：cbd334af64dd49419cc0e535adc27ab9
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=28）
  - 结果：shipped 28x Stone (~56g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：af02d83a59ef4d9b9f48c2d532bd7b29
  - 耗时：48.516 秒 / 游戏 60 分钟
  - 🗨️ [hud] A train is passing 
through Stardew 
Valley. 
- **09:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：17838b8ea335464380c27285a909951a
  - 耗时：49.094 秒 / 游戏 60 分钟
- **10:50** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：2793a6310b9047e2940c3b87ffca721c
  - 耗时：0.579 秒 / 游戏 0 分钟
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：29e67fe3b0c84a1398bc9bfe3fe48cfe
  - 耗时：33.688 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Salad", "Magma Geode", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1e50346aa4ff4de3b944c97425ef051d
  - 耗时：15.109 秒 / 游戏 20 分钟
- **10:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：dc74dc1e77ce4ebc9451d9f8010b564b
  - 耗时：0.578 秒 / 游戏 0 分钟
- **11:50** Farm ✅ `store_items`（items=["Salad", "Magma Geode", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：8014a062daa94d14b9a0ce89cbb60c3f
  - 耗时：0.61 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：3ce06339e43941c2bc3785bd491592fc
  - 耗时：42.156 秒 / 游戏 50 分钟
- **12:40** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：2fe628e6287441d8b92d9e0c196d461b
  - 耗时：107.297 秒 / 游戏 140 分钟
- **12:40** Blacksmith ✅ `store_items`（items=["Salad", "Magma Geode", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：03fc75d57c004b3f8b7a2c7065f2412c
  - 耗时：15.156 秒 / 游戏 20 分钟
- **12:40** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：835bb9ebef1d4b8b9438205be53b2033
  - 耗时：23.891 秒 / 游戏 30 分钟
- **15:50** Forest ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Smallmouth Bass, Smallmouth Bass, Joja Cola, Green Algae, Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：3a8b0bc3fe15408c80c11a9cef97bb91
  - 耗时：234.875 秒 / 游戏 250 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
- **20:00** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：ff7bdde433814d23a00ff6eff311bae5
  - 耗时：9.672 秒 / 游戏 10 分钟
- **20:10** Farm ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：6a55f5a8f5084af69bff094fd5ee0f25
  - 耗时：18.828 秒 / 游戏 20 分钟
  - 🗨️ [hud] Gold Bar
- **20:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：6e1ace8134c941b8bb7d75452c192899
  - 耗时：0.547 秒 / 游戏 0 分钟
- **20:30** Farm ✅ `ship`（item="Iron Ore", count=2）
  - 结果：shipped 2x Iron Ore (~20g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：3c2b14739015428a9a807569980952ff
  - 耗时：10.61 秒 / 游戏 20 分钟
- **20:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：4264761201484e1ca18707ce9fbf81d5
  - 耗时：6.797 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：89633 → 89759（+126g）
- 出货估值：50g　动作：43 个　失败：20 个
- 模型调用：6 次　tokens：69709
- 有效动作率：0.5556　空转：5　熔断跳过：6
- 失败耗时：9.58 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天43动作20失败，核心死结仍是背包空格不足：91个Copper Bar一个没卖，mine和upgrade_tool都被'have 4, need 5'拒绝，铁锭链连续多天零推进。take空跑12次、store_items空跑、donate空跑、build_road空跑全是0产出。唯一有效的是Forest钓鱼10条约2.1k。今天必须把卖Copper Bar写成起床后第一个无条件动作，验证空格≥5后再下矿，否则直接转钓鱼。

**新教训：**
- 昨天 mine 和 upgrade_tool 都被 'have 4, need 5' 拒绝，而背包 91 个 Copper Bar 一个没卖：清包脚本必须把 ship Copper Bar 写成起床后第一个无条件动作（count=背包数-20），而不是放在「读背包后视情况」的分支里，否则永远走不到。
- 昨天 12 次 take 全部空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天在 ArchaeologyHouse 调 ship 报 'not found' 而材料显示背包有 91 个 Copper Bar：ship 的 location 必须在脚本生成阶段硬编码为 Farm 出货箱，其他地图一律不生成 ship 分支。
- 昨天 donate_museum 在 ArchaeologyHouse 报 'nothing in the backpack can be donated'：博物馆捐赠需要背包里实际有未捐的矿物/化石，脚本生成阶段应先读背包确认有可捐物才生成 donate，否则物理删除。
- 昨天 build_road 报「规划道路边没有还能走上去的空格」：铺路是纯装饰动作，对里程碑零贡献，脚本生成阶段应物理删除 build_road，把时间留给下矿/钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 20）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 89633g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 4 空格，91 个 Copper Bar 一个没卖，mine 和 upgrade_tool 都被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 2）。

接下来 3 天主活动：
- **今天（春 20）**：起床 collect→**农场出货箱无条件 ship Copper Bar 留 20（约 71 个，腾 4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼 casts≥10 到 20:00。
- **明天（春 21）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 22）**：继续铁锭链；若洒水器已齐则开始规划夏季啤酒花地块。

## 今日核心修正（按执行顺序）
1. **清包是今天第一硬动作，且唯一手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后**无条件** ship Copper Bar count=背包数-20（约 71 个，约 4k，腾 4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except，绝不放在「视情况」分支里**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。脚本生成阶段把 ship 的 location 硬编码为 Farm。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 2 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 15-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过；Iron Ore<5 物理删除 load）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 20 不买种子**：只做清包+下矿+钓鱼；种子等复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 20 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
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
9. 春 20 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天43动作20失败，核心死结仍是背包空格不足：91个Copper Bar一个没卖，mine和upgrade_tool都被'have 4, need 5'拒绝，铁锭链连续多天零推进。take空跑12次、store_items空跑、donate空跑、build_road空跑全是0产出。唯一有效的是Forest钓鱼10条约2.1k。今天必须把卖Copper Bar写成起床后第一个无条件动作，验证空格≥5后再下矿，否则直接转钓鱼。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 10:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 12:40 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 20:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 背包空格始终只有 4，mine 和 upgrade_tool 连续被拒 @ Farm / Mine — store did not free enough slots (have 4, need 5)（做不了：铁锭链完全卡死：下不了矿拿铁矿石，也升不了 Steel Hoe，洒水器/钢斧/鸡舍全部排队） 〔复盘〕
- 91 个 Copper Bar 一个没卖，清包脚本走不到 ship 分支 @ Farm 出货箱 — ship Copper Bar 报 'not found'（在 ArchaeologyHouse 调）或根本没生成 ship 动作（做不了：背包腾不出空格，下矿门票永远拿不到） 〔复盘〕
- take 反复重试同一批不存在的矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；脚本重写 3 次仍重试（做不了：浪费 12 个动作和 3 次脚本重写，挤占下矿/钓鱼时间） 〔复盘〕
- donate_museum 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：白跑一趟 Town，浪费早晨黄金时段） 〔复盘〕
- build_road 铺路失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：纯装饰动作对里程碑零贡献，浪费动作配额） 〔复盘〕
- load_machines 在 Iron Ore 只有 2 时仍生成 @ Farm 熔炉 — no empty machine accepts that / no machine has finished output（做不了：熔炉空转，铁锭产出为零） 〔复盘〕
- 收尾拖到 20:50 才 sleep，20:30 后 collect_machines 空跑 @ Farm — no machine has finished output（做不了：晚间时段没有转钓鱼，产出为零） 〔复盘〕
