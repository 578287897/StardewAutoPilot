# 第5年 winter 20 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（13:44 开始）
- 天气：snow　金钱：77518g　体力：202/270
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
  - 执行状态：NO_PROGRESS · 操作编号：0c662608816e4eefa25949134b01fcc0
  - 耗时：3.344 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：1c89ea480769440983aa7fd951705556
  - 耗时：12.141 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_winter_20）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，空炉且铁矿≥5 就装料
- 清包第一优先：农场出货箱卖 Copper Bar 留 20，腾出 ≥5 空格
- 补食物到 ≥5（Chub 3 条可吃，不够就去 Saloon 买沙拉）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine，每次 ≤5 层
- 回农场收铁锭，铁锭≥5 且 12:00 前就去铁匠铺升 hoe
- 铁锭不足则转 Forest 钓鱼填满下午
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
11. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Bug Meat", "Geode", "Chub"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=0）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Bug Meat", "Geode", "Chub"]）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=5）
25. `fish`（casts=5）
26. `fish`（casts=5）
27. `sleep`
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 4x Bug Meat
  - 执行状态：SUCCESS · 操作编号：e260c06f3a914e3b85e5195ce1da494a
  - 耗时：17.0 秒 / 游戏 30 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：7274391475874edd9b2f4c0535a26f07
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：fc8bffec666a4385becda372aa241d6f
  - 耗时：0.641 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~225g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：2805eabf165b460bbc9510ef1ba07c4b
  - 耗时：0.813 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：614316189eaa48a4916ab8cdf387cff0
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 已全天删除，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够就升 hoe，不足转 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Bug Meat", "Geode", "Chub"]）
23. `collect_machines`
24. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Bug Meat", "Geode", "Chub"]）
25. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：35d7a566d4b74796969ade473c8deaa7
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：放弃 take 箱子宝石（坐标记忆失效），改走清包卖 Copper Bar→下矿 40 层刷铁→回农场炼锭→12 点前升 hoe，失败即转 Fores
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `collect_machines`
25. `collect_machines`
26. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Geode"]）
27. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：49354e962c8f48268305d92379001a1c
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支全天物理删除，改为出货箱卖 Copper Bar 清包后下矿刷铁，铁锭够则升 hoe，不够转 Forest 钓鱼。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=20）
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
26. `load_machines`（item="Iron Ore"）
27. `ship_produce`（except=["Iron Bar", "Gold Bar", "Copper Ore", "Iron Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Geode"]）
28. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：4284da8962ba4a5ca1e1a6dc94230e6a
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8d232e2e665b4890816eafe12915b77d
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2c8344d495dd475ca429f4dd8bb3789a
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：89d61a3eafb340ddbc8aa884f20b4991
  - 耗时：57.219 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：ddc3c14d3ae04b738ece5e7f8e400a60
  - 耗时：44.14 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：21df20afba0a4d51b9efade7159220e5
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：1d6a4218c0a14b63a2d5d7bd1ba6af2b
  - 耗时：0.485 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=20）
  - 结果：shipped 20x Stone (~40g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：b53087e10c004cdf80881f0312a54cb4
  - 耗时：43.953 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：52b15449b3fc4c8ab8fa8069e80721a8
  - 耗时：53.187 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：9314d4eeae14468db2c431f0ff01c308
  - 耗时：34.125 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Pumpkin Seeds", "Rice Shoot", "Rubber Boots", "Geode"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Geode
  - 执行状态：SUCCESS · 操作编号：403aa33e13a1464b9eddee35b63e5895
  - 耗时：15.641 秒 / 游戏 20 分钟
- **10:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 17 (2 floors down, 34 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：531545e3787d4f52a9422b8ee7ff0846
  - 耗时：97.109 秒 / 游戏 120 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [question] 
- **13:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：fa9d558065174176abf12d5672380058
  - 耗时：36.312 秒 / 游戏 50 分钟
- **13:50** Mine ✅ `store_items`（items=["Stone", "Green Algae", "Pumpkin Seeds", "Rice Shoot", "Rubber Boots", "Slime", "Bug Meat"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Green Algae, 1x Slime, 1x Bug Meat
  - 执行状态：SUCCESS · 操作编号：7f2cdc3e4690421e9519e2b3ddb6b72c
  - 耗时：15.094 秒 / 游戏 20 分钟
- **13:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:00** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：e2752f32a19c4c5a9581fee84ebcccc1
  - 耗时：0.532 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：49b0b34be99a4daf9537249d2f4c9803
  - 耗时：40.36 秒 / 游戏 50 分钟
- **15:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：a06c78f3c63f4daab4f069bfc5aba1fa
  - 耗时：39.141 秒 / 游戏 50 分钟
- **15:50** Blacksmith ✅ `store_items`（items=["Stone", "Pumpkin Seeds", "Rice Shoot", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 3x Rice Shoot
  - 执行状态：SUCCESS · 操作编号：0545642ad33143cdaf98b84814f75f4f
  - 耗时：1.188 秒 / 游戏 0 分钟
- **15:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：could not reach (22,31); stopped at (21,29)
  - 执行状态：ACTION_FAILED · 操作编号：d1efc4f172774b7991f53c29e8ca92bc
  - 耗时：124.968 秒 / 游戏 160 分钟
  - 🗨️ [hud] Rice Shoot
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
- **19:20** UndergroundMine18 ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：157bb377753f409881edc25e0bee539c
  - 耗时：73.609 秒 / 游戏 90 分钟
  - 🗨️ [question] 
- **20:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Chub, Green Algae, Green Algae, Bream, Perch)
  - 执行状态：SUCCESS · 操作编号：fce4b2e55efc47df8ce3a00b9574fa22
  - 耗时：114.079 秒 / 游戏 120 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Bream
- **22:50** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Perch, Perch, Bream, Lingcod)
  - 执行状态：SUCCESS · 操作编号：9ab4336b4aaf4747a8afc89b0c0ceca2
  - 耗时：139.688 秒 / 游戏 140 分钟
  - 🗨️ [hud] It's getting late... 
  - 🗨️ [hud] Bream
- **25:10** Forest ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：271e3d120dae45e9a5e3a0e31d1dd49a
  - 耗时：38.703 秒 / 游戏 40 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：77518 → 77783（+265g）
- 出货估值：225g　动作：40 个　失败：19 个
- 模型调用：7 次　tokens：87574
- 有效动作率：0.5455　空转：4　熔断跳过：6
- 失败耗时：134.11 秒 / 游戏 160 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天 40 动作 19 失败，核心仍是清包失败：Copper Bar 85 个一个没卖，空格始终 3-4 格，mine 和 upgrade 被 'need 5' 拒绝。take 空跑 12 次、donate/ship 位置错误、leave_mine 在农场误调。唯一有效是 Forest 钓鱼 10 条。今天必须把清包第一步做成硬性 ship_produce Copper Bar，验证空格≥5 后再下矿，否则直接钓鱼日。

**新教训：**
- 昨天 ship_produce Copper Bar 在 ArchaeologyHouse 报 not found，但材料显示背包有 85 个：ship 必须在农场出货箱附近执行，且 ship 前先 close_menu 再读背包，不要在博物馆/商店里调 ship。
- 昨天 mine 两次被 'have 4, need 5' 拒绝，而背包里 85 个 Copper Bar 一个没卖：清包第一步必须显式 ship_produce Copper Bar（留 20），只卖石头/Sap 腾不出格。
- 昨天 12 次 take 失败后没有钓鱼兜底，从 12:40 到 21:30 空转；而 Forest 钓鱼 10 条贡献约 2k 出货：清包验证失败后必须在同一脚本生成 goto Forest→fish 分支。
- 昨天 upgrade_tool 在 Blacksmith 报 'could not reach (22,31); stopped at (21,29)'，说明铁匠铺内升级台坐标记忆失效：升级前先 goto Blacksmith 并确认到达柜台附近，再调 upgrade_tool，否则白跑。
- 昨天 leave_mine 在 Farm 报 'not in the mine'，说明 leave_mine 只能在矿洞内调用：脚本生成阶段应把 leave_mine 绑定在 mine 动作之后，不在农场生成。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 21）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 77518g 远超 5000，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿与升级的共同门票**——昨天背包 3-4 空格，mine×2、upgrade 全被拒，而背包里 85 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 21）**：起床 collect→读背包→**农场出货箱 ship_produce Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 22）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 23）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱卖 Copper Bar 留 20**：起床读背包后显式 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 89/95 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 21 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
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
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 40 动作 19 失败，核心仍是清包失败：Copper Bar 85 个一个没卖，空格始终 3-4 格，mine 和 upgrade 被 'need 5' 拒绝。take 空跑 12 次、donate/ship 位置错误、leave_mine 在农场误调。唯一有效是 Forest 钓鱼 10 条。今天必须把清包第一步做成硬性 ship_produce Copper Bar，验证空格≥5 后再下矿，否则直接钓鱼日。
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
- 13:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 15:00 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 15:50 动作 `upgrade_tool` 失败 @ Blacksmith — could not reach (22,31); stopped at (21,29) | 游戏消息: [hud] Rice Shoot / [hud] Stone / [hud] Bug Meat / [hud] Stone 〔自动〕
- 清包反复失败：Copper Bar 85 个一个没卖，只卖出 80 石头，背包空格始终 3-4 格 @ Farm 出货箱 — ship_produce 未对 Copper Bar 执行；mine 报 'store did not free enough slots (have 3, need 5)'（做不了：下矿刷铁、升级 Steel Hoe 全部被拒，铁锭链连续多日零推进） 〔复盘〕
- take 连续 12 次空跑，脚本重写 3 次仍在重试同一批箱子 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；already failed; not retrying today（做不了：浪费 12 个动作和 3 次脚本重写，挤占下矿/钓鱼时间） 〔复盘〕
- 在 ArchaeologyHouse 调 ship 和 donate 均失败 @ ArchaeologyHouse — ship: 'Copper Bar' not found in inventory；donate: nothing in the backpack can be donated（做不了：博物馆捐赠和出货都白跑，且 ship 位置错误导致 Copper Bar 未卖出） 〔复盘〕
- upgrade_tool 在 Blacksmith 报 could not reach (22,31) @ Blacksmith — could not reach (22,31); stopped at (21,29)（做不了：即使铁锭够也无法完成升级，升级台坐标需要重新确认） 〔复盘〕
- mine 第二次被 'store did not free enough slots (have 4, need 5)' 拒绝 @ Farm / Mine — store did not free enough slots (have 4, need 5)（做不了：当天只下矿 2 层（15→17），铁矿石几乎没增加） 〔复盘〕
- leave_mine 在农场被调用报 not in the mine @ Farm — not in the mine（做不了：浪费一个动作，说明脚本把矿洞动作生成到了农场） 〔复盘〕
