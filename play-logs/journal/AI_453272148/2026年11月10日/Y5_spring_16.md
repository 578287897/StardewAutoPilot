# 第5年 spring 16 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（16:36 开始）
- 天气：windy　金钱：63421g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Pickled Kale from Preserves Jar, Pickled Kale from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：192ad62665874afda77a7a8b3d17533b
  - 耗时：17.562 秒 / 游戏 20 分钟
  - 🗨️ [hud] Pickled Kale
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：4fa0418254e94139a514bf285214fa86
  - 耗时：3.985 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 2 crops
  - 执行状态：SUCCESS · 操作编号：992c74299cb4460c88a888c6b04e5633
  - 耗时：7.234 秒 / 游戏 10 分钟
  - 🗨️ [hud] Potato
  - 🗨️ [hud] Cauliflower

## 🌙 为明天（Y5_spring_16）准备的脚本
- 里程碑：凑齐 5 铁锭升级钢锄头（Steel Hoe）
- 起床收熔炉、投铁矿石，清包到空格≥15
- Forest 钓鱼补食物到≥6
- 电梯直达 80 层下矿 80→84 挖铁矿石+煤
- 回农场收铁锭，铁锭≥5 且 13:00 前去 Blacksmith 升 hoe
- 顺路 SeedShop 买土豆/花椰菜种子并当天种下
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
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar"]）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Mine"）
17. `mine`（floors=4）
18. `goto_location`（location="Farm"）
19. `store_items`
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="SeedShop"）
24. `open_shop`（shop_id="SeedShop"）
25. `buy`（item="Potato Seeds", count=20）
26. `buy`（item="Cauliflower Seeds", count=10）
27. `close_menu`
28. `goto_location`（location="Farm"）
29. `plant_seeds`（item="Potato Seeds", count=20）
30. `sleep`
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 11 crops
  - 执行状态：SUCCESS · 操作编号：751581c85e844415bcfb27f369f5f4c7
  - 耗时：29.703 秒 / 游戏 40 分钟
  - 🗨️ [hud] Potato
- **07:10** Farm ❌ `ship_produce`
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：cd466d36add442d6bee5e50d06109486
  - 耗时：10.922 秒 / 游戏 20 分钟

### 🔁 脚本重写：重写#1：出货箱路径不可达，改用 store_items 清包后直接去 Forest 钓鱼补食物，再下矿 80 层挖铁，回农场收锭后升 hoe 并买种。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=4）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar"]）
23. `collect_machines`
24. `store_items`
25. `plant_seeds`（item="Potato Seeds", count=20）
26. `sleep`
- **07:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：34c3fd52a83142b09eddd3b72dccf3d6
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部take（箱子无宝石），改为store+ship清包→Forest补食物→80层挖铁→回农场收锭→13点前升hoe→买种当天种下。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=4）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar"]）
23. `collect_machines`
24. `store_items`
25. `collect_machines`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `sleep`
- **07:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1fe315a265224bc5b5fc023e67158398
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：放弃失败的 take 分支，改为清包→钓鱼补食物→80层下矿挖铁→回农场收锭→13点前升钢锄头→买种当天种下。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=4）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Pickled Kale", "Cauliflower"]）
23. `collect_machines`
24. `store_items`
25. `collect_machines`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `sleep`
- **07:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:30** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：082fef80134c4d5b84d0997c0b0b3218
  - 耗时：0.391 秒 / 游戏 0 分钟
- **07:30** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4598ccea389a4322b14e9ec39799e639
  - 耗时：0.406 秒 / 游戏 0 分钟
- **07:30** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：26214707ebb94ca3a5d528b9bd131a53
  - 耗时：0.36 秒 / 游戏 0 分钟
- **07:30** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6f514c27af1c4c32bf3db8a5a6e2ebd1
  - 耗时：0.375 秒 / 游戏 0 分钟
- **07:30** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：3320a7646dbc48b4b96d32436910793f
  - 耗时：21.64 秒 / 游戏 30 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：a7df7084a5fd42c3a2293553634737e8
  - 耗时：77.438 秒 / 游戏 90 分钟
- **09:30** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：f6f095739a5c4af7abce0700b7b5a469
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:30** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：8fa21b4d33cd45658c5348fdf470e757
  - 耗时：30.875 秒 / 游戏 40 分钟
- **10:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Sunfish, Green Algae, Sunfish)
  - 执行状态：SUCCESS · 操作编号：80f958e99f03492286bc73a2511812ba
  - 耗时：96.922 秒 / 游戏 100 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Green Algae
- **11:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：b5b25509f77a4f0b8ba6b912194f96e0
  - 耗时：63.375 秒 / 游戏 80 分钟
- **13:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：5fa354c0eb374d96b04d2fa3d10b73e9
  - 耗时：33.609 秒 / 游戏 40 分钟
- **13:10** Mine ✅ `store_items`（items=["Pickled Kale", "Green Algae", "Stone", "Magma Geode", "Potato Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：0063d74a951f49a9bc20a7d737efbcfc
  - 耗时：15.062 秒 / 游戏 20 分钟
- **13:10** Mine ❌ `mine`（floors=4）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **14:10** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：cde02327e49a4297b1a8842f3006c9bd
  - 耗时：40.313 秒 / 游戏 50 分钟
- **15:00** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：9ecda04f8b0d4d8eaf0af38039d44dde
  - 耗时：39.0 秒 / 游戏 50 分钟
- **15:00** Blacksmith ✅ `store_items`（items=["Pickled Kale", "Stone", "Magma Geode", "Potato Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 46x Stone, 2x Magma Geode
  - 执行状态：SUCCESS · 操作编号：85ebbcfb9ba4474fa49839157848ea2f
  - 耗时：1.109 秒 / 游戏 0 分钟
- **15:00** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **15:50** Farm ✅ `goto_location`（location="SeedShop"）
  - 结果：arrived at SeedShop (6,29)
  - 执行状态：SUCCESS · 操作编号：32d93ed3313a4e5aa7e178113f4db035
  - 耗时：21.984 秒 / 游戏 30 分钟
- **16:20** SeedShop ✅ `open_shop`（shop_id="SeedShop"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：5af162e8cc764cd8b25dbfdc008bfe20
  - 耗时：0.437 秒 / 游戏 0 分钟
- **16:20** SeedShop ✅ `buy`（item="Potato Seeds", count=5）
  - 💭 商店已开，先买土豆种子补满地块，再买花椰菜；背包仅3格，先买少量。
  - 结果：bought 5x Potato Seeds for 250g
  - 执行状态：SUCCESS · 操作编号：ad2c27cb431d4509b2190b7a79b9c504
  - 耗时：0.375 秒 / 游戏 0 分钟
- **16:20** SeedShop ✅ `buy`（item="Cauliflower Seeds", count=3）
  - 💭 商店已开，背包3格。先买少量花椰菜种子，再关菜单清包。
  - 结果：bought 3x Cauliflower Seeds for 240g
  - 执行状态：SUCCESS · 操作编号：cb8c47935c084adcab8bb991af5281e6
  - 耗时：0.391 秒 / 游戏 0 分钟
- **16:20** SeedShop ✅ `close_menu`
  - 💭 商店已开，背包仅2空格，先买少量种子后关菜单，回农场清包腾格再种。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：b5771c014a9f4d938d05177fcb3e3844
  - 耗时：0.407 秒 / 游戏 0 分钟
- **16:20** SeedShop ❌ `buy`（item="Potato Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：876f57a45c3f456e904fdd1e4257287d
  - 耗时：0.39 秒 / 游戏 0 分钟
- **16:20** SeedShop ❌ `buy`（item="Cauliflower Seeds", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：e82ff97029a14b64bc19eb7c44c6cc26
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:20** SeedShop ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：b538767f61024725b9ae869fa1e3fbe2
  - 耗时：0.343 秒 / 游戏 0 分钟
- **16:20** SeedShop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：c28e21644f564e3eb3ced9889763ebae
  - 耗时：20.828 秒 / 游戏 20 分钟
- **16:40** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：d12f41da49cb4cb39ed222dd4b988fd9
  - 耗时：1.109 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Iron Bar", "Pickled Kale", "Cauliflower"]）
  - 结果：shipped 4 stacks worth ~363g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3d28ebedd0f04ab1960f8e6009fd6dad
  - 耗时：0.891 秒 / 游戏 0 分钟
- **16:40** Farm ❌ `collect_machines`
  - 结果：could not reach (40,9); stopped at (41,8)
  - 执行状态：ACTION_FAILED · 操作编号：9405f9e18de74ad4aba7d59b38f2a2cb
  - 耗时：21.688 秒 / 游戏 30 分钟
- **17:10** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：bbc992de01254806903005a8df206cba
  - 耗时：12.828 秒 / 游戏 20 分钟
- **17:30** Farm ❌ `collect_machines`
  - 结果：could not reach (40,9); stopped at (41,8)
  - 执行状态：ACTION_FAILED · 操作编号：1602092b670d42c5a00dc9c456e04783
  - 耗时：20.14 秒 / 游戏 20 分钟
- **17:50** Farm ✅ `plant_seeds`（item="Potato Seeds", count=20）
  - 结果：planted 1x Potato Seeds in plot (51,14) 6x4, 10 tiles unusable
  - 执行状态：SUCCESS · 操作编号：f1b219eb094940f885ecab59003c7a82
  - 耗时：4.328 秒 / 游戏 10 分钟
- **18:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：1ffe3743a50b44229c774df0fce7be3a
  - 耗时：9.578 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：63421 → 63294（-127g）
- 出货估值：363g　动作：44 个　失败：19 个
- 模型调用：10 次　tokens：126907
- 有效动作率：0.6　空转：1　熔断跳过：3
- 失败耗时：56.53 秒 / 游戏 70 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包不彻底：store_items 只腾出 1-3 格，导致 mine 和 upgrade_tool 都被拒；take 宝石 6 次全失败纯浪费；买种子后关菜单再 buy 失败。有效的是钓鱼补食物和电梯下矿思路，但被清包卡死。今天必须把清包做成硬门槛：store+ship 双管齐下并验证空格≥15，否则全天降级为钓鱼日。

**新教训：**
- 昨天 store_items 返回 OK 但只腾出 1-3 格，导致 mine 和 upgrade_tool 都被拒：清包必须 store_items + ship_produce 双管齐下，且 ship 后立即读背包验证空格数，验证通过前不得调 mine/upgrade。
- 昨天 6 次 take 宝石（62/64/68/72/84/86）全失败，说明箱子内容与记忆完全不符：任何需要特定物品的动作前必须先读箱子实际内容，不能凭 ID 猜；今天直接物理删除 take。
- 昨天 buy 成功一次后 close_menu 再 buy 返回「no shop is open」，吃掉 2 个动作：buy 成功后应不关菜单继续买，买够再关；关菜单后当天不再 buy。
- 昨天 collect_machines 两次在 (40,9) 返回 could not reach，停在 (41,8)：熔炉被障碍物挡住时不要重试同一坐标，改从另一侧接近或等下次 collect。
- 昨天 plant_seeds 只种下 1 个土豆（10 tiles unusable），说明地块被障碍物占满：种植前先读分区可用格数，可用格<5 时先清障或换地块，不要空跑 plant。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 17）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 62931g 充足，但 Iron Bar 还差 5，铁矿石仅 2、煤 36。瓶颈仍是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 17）**：起床 collect → 空炉且铁矿石≥5 才 load Iron Ore → **清包到空格≥15（store+ship 双管齐下并验证）** → 补食物到≥6 → 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 18）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续下矿炼铁。
- **后天（春 19）**：继续炼铁/升级下一件工具，或补种春季作物。

## 今日核心修正
1. **take 全天物理删除**：连续多天 take 宝石全失败，箱子内容与记忆不符。脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **清包做成硬门槛（最关键）**：起床 goto Farm → store_items（不指定坐标，存 Stone/Geode/多余矿石/种子）→ **ship_produce 卖鱼/杂矿/低价值物（Stone/Coal/矿石/锭除外）** → 读背包验证空格。**两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支**。清包成功后全天禁止任何 take。
3. **熔炉投铁矿石，不投铜**：起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。投料必须在 collect 后 1 个动作内完成。
4. **补食物到≥6**：Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。食物<6 不下 40 层以下。
5. **下矿目标 80→84**：电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从 89 层往下爬**。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。**upgrade_tool 必须带 tool=hoe 参数**，并在日志确认返回的是升级结果而非挖矿结果。
8. **买种子顺序硬约束**：先 goto SeedShop → open_shop 成功 → **buy 一次成功后再决定是否继续买，中间不关菜单**；buy 返回「no shop is open」说明 open_shop 未生效，立即重开一次，不连续 buy。**买前读背包确认空格≥5，不足先 store_items**。**17:00 后不再去 SeedShop**。**买完种子后若背包有种子且时间<18:00，立即 plant_seeds 种下，不拖到第二天**。
9. **路径失败即换路**：store_items/ship_produce 返回 could not reach 时，立即改不指定坐标或直接 ship_produce，**不重试同一坐标**。
10. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
11. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥15**：goto Farm → store_items（不指定坐标）→ **ship_produce 卖低价值物** → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥6**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥15 且食物 ≥6 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **买春季种子（仅当时间 <17:00 且背包空格 ≥5）**：goto SeedShop → open_shop → buy Potato Seeds 20 / Cauliflower Seeds 10；**buy 成功一次后不关菜单，继续 buy 直到买够或空格不足**；buy 失败一次即跳过，不连续 buy。**买完立即 plant_seeds 种下**。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥6 且空格 ≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：连续多天 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥6 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床 collect_machines 1 次**（收熔炉成品）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. **一次性清包到空格 ≥15**（store_items 不指定坐标 + **ship_produce 卖低价值物** + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥6**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥15、食物 ≥6、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买春季种子（open_shop 成功后再 buy，**buy 成功后不关菜单继续买**，背包空格 ≥5，buy 失败一次即跳过；**买完立即 plant_seeds**）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包不彻底：store_items 只腾出 1-3 格，导致 mine 和 upgrade_tool 都被拒；take 宝石 6 次全失败纯浪费；买种子后关菜单再 buy 失败。有效的是钓鱼补食物和电梯下矿思路，但被清包卡死。今天必须把清包做成硬门槛：store+ship 双管齐下并验证空格≥15，否则全天降级为钓鱼日。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:10 动作 `ship_produce` 失败 @ Farm — could not reach (70,15); stopped at (53,8) 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:30 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 09:30 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 13:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 15:00 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 3, need 5) 〔自动〕
- 16:20 动作 `buy` 失败 @ SeedShop — no shop is open; use open_shop first 〔自动〕
- 16:20 动作 `buy` 失败 @ SeedShop — no shop is open; use open_shop first 〔自动〕
- 16:20 动作 `close_menu` 失败 @ SeedShop — no menu is open 〔自动〕
- 16:40 动作 `collect_machines` 失败 @ Farm — could not reach (40,9); stopped at (41,8) 〔自动〕
- 17:30 动作 `collect_machines` 失败 @ Farm — could not reach (40,9); stopped at (41,8) 〔自动〕
- 清包不彻底，store_items 返回 OK 但只腾出 1-3 格 @ Farm 箱子 (74,15)/(75,15) — mine 返回「store did not free enough slots (have 1, need 5)」，upgrade_tool 返回「have 3, need 5」（做不了：下矿挖铁矿石和升级钢锄头都被卡死，里程碑零推进） 〔复盘〕
- take 宝石连续 6 次全失败 @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest（做不了：浪费 6 个动作，且说明箱子内容与记忆不符，后续依赖物品的动作不可信） 〔复盘〕
- 买种子后关菜单再 buy 失败 @ SeedShop — buy 返回「no shop is open; use open_shop first」（做不了：没能买够土豆/花椰菜种子，只买到 5+3 个） 〔复盘〕
- collect_machines 两次无法到达熔炉 @ Farm (40,9) — could not reach (40,9); stopped at (41,8)（做不了：铁锭没收上来，升级钢锄头缺锭） 〔复盘〕
- plant_seeds 只种下 1 个土豆，10 格不可用 @ Farm (51,14) 6x4 地块 — planted 1x Potato Seeds, 10 tiles unusable（做不了：春季作物没种满，浪费种子和季节时间） 〔复盘〕
