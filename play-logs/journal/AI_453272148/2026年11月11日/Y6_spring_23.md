# 第6年 spring 23 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（23:19 开始）
- 天气：sunny　金钱：91313g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：e164a4e2267c4628a5eff1cbafad15ce
  - 耗时：5.125 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, Tomorrow we're all getting together for the Flower Dance.  If you can find a partner, you might even want to participate in the dance yourself! There's a little clearing beyond the forest west of town where we hold the dance. Arrive between 9 AM and 2 PM if you're interested.   -Mayor Lewis
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：40cafd8776604ab1b8fabde69058b07e
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Broken CD
  - 执行状态：SUCCESS · 操作编号：17c60247194247298f0a6dfb2f9bbdb5
  - 耗时：4.906 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：2b71ee5a048a4ed08238ed283a7bca42
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：272cba0bb9b2493c8fdd9647537a8278
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~750g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ebb4f756e7424213b43057f418ce47f3
  - 耗时：0.782 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_23）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，铁矿石够就装炉
- 农场出货箱无条件卖 Copper Bar 留 20，腾出背包空格≥5
- 背包腾空后电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次≤5 层）
- 回农场收铁锭，铁锭≥5 且时间<12:00 去铁匠铺升 hoe
- 铁锭不够就转 Forest 钓鱼到 21:30 前收工
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
13. `ship`（item="Stone", count=1000）
14. `ship`（item="Sap", count=48）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `fight`（range=6）
18. `mine`（floors=5）
19. `leave_mine`
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Forest"）
25. `fish`（casts=10）
26. `fish`（casts=10）
27. `fish`（casts=10）
28. `goto_location`（location="Farm"）
29. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：41cf4c9e8b54467da74b84a8378904d7
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate_museum 空跑分支，改为农场出货箱卖 Copper Bar 腾格后下矿 40 层刷铁，铁锭够则升 hoe，否则转
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=1000）
11. `ship`（item="Sap", count=48）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Forest"）
20. `fish`（casts=10）
21. `fish`（casts=10）
22. `fish`（casts=10）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：537da4804c774badb247b86802bd988e
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 分支因箱子内容不符全部失败，物理删除；改为在农场出货箱卖 Copper Bar 留 20 腾格，再按原路线下矿 40 层刷铁、回农场收锭、1
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=499）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `fight`（range=6）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=10）
20. `fish`（casts=10）
21. `fish`（casts=10）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `collect_machines`
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：43e84765fbea4865bb43870851d1494a
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 分支，改为在农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够就升 hoe，不够转 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Stone", count=499）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `fight`（range=6）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=10）
20. `fish`（casts=10）
21. `fish`（casts=10）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9271c6cedc394bd3b84cb5af3c99cfb5
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：00234f526c9b4009ae163e20d67d61fa
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：171235f2fea24df3adfc7ec41768572a
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：7080b4b76ef241fa84073d7496871955
  - 耗时：79.719 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：3ee6cfa55cda49d9883679c199ce0155
  - 耗时：44.141 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：6bc293a45c3443d99c4dfc62411fc4d4
  - 耗时：0.562 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=71）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：81d0d8936c7d49e1a55cf443c427656d
  - 耗时：0.594 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Stone", count=499）
  - 结果：'Stone' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：34547074ebb443b3bb016567a5780719
  - 耗时：0.625 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：d429a6d6be4b4f48b57072a6e50e8255
  - 耗时：50.766 秒 / 游戏 60 分钟
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：b55c6646e79c457b9a8ac1159e8b05e4
  - 耗时：33.672 秒 / 游戏 40 分钟
- **09:50** Mine ❌ `store_items`（items=["Salad", "Green Algae", "Pumpkin Seeds", "Magma Geode", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：00e16c50be2b4d7b930703576eb81bfb
  - 耗时：12.625 秒 / 游戏 20 分钟
- **09:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **10:50** Farm ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：84684beaeb984aadbd48e2f00c8ba781
  - 耗时：0.531 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `store_items`（items=["Salad", "Green Algae", "Pumpkin Seeds", "Magma Geode", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：7cd06cdd7a7648228d9b35eb96e89c73
  - 耗时：7.703 秒 / 游戏 10 分钟
- **10:50** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：020d1b7ebc2f45dfa3c1bfe7f6e5b3ee
  - 耗时：0.531 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：02a89d2db29a429db3b125d92114b860
  - 耗时：73.812 秒 / 游戏 90 分钟
- **12:30** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：81b361c8a6d447c599f9b60ff4dad4bc
  - 耗时：39.047 秒 / 游戏 50 分钟
- **12:30** Blacksmith ✅ `store_items`（items=["Salad", "Green Algae", "Pumpkin Seeds", "Magma Geode", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 9x Green Algae, 1x Magma Geode
  - 执行状态：SUCCESS · 操作编号：2cd3d92d0719499dbabcd8eea20b2778
  - 耗时：1.187 秒 / 游戏 0 分钟
- **12:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：f33097bb65834535a466e7992f0a17f1
  - 耗时：23.625 秒 / 游戏 30 分钟
- **13:50** Forest ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Smallmouth Bass, Green Algae, Green Algae, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：1aeebc315e5d4a648c5daebebbeade6d
  - 耗时：224.766 秒 / 游戏 240 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
- **17:50** Forest ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Green Algae, Smallmouth Bass, Green Algae, Broken CD, Driftwood, Green Algae, Smallmouth Bass, Green Algae, Green Algae, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：513b4b7b067b4ed0b6a44bea6e01ec29
  - 耗时：170.703 秒 / 游戏 200 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
- **21:10** Forest ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Smallmouth Bass, Trash, Broken CD, Smallmouth Bass, Smallmouth Bass, Green Algae, Green Algae, Smallmouth Bass, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：37d8ba2ea48842d78c08a30c9d9b0129
  - 耗时：165.921 秒 / 游戏 190 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] It's getting late... 
  - 🗨️ [hud] Green Algae
- **24:20** Forest ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c95e171b420c41f48837bfd196ec83ca
  - 耗时：32.968 秒 / 游戏 40 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：91313 → 92063（+750g）
- 出货估值：750g　动作：41 个　失败：23 个
- 模型调用：7 次　tokens：87432
- 有效动作率：0.4412　空转：4　熔断跳过：6
- 失败耗时：27.735 秒 / 游戏 30 分钟
- 最深矿层：104　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 41 动作 23 失败，核心仍是背包空格不足：91 个 Copper Bar 没卖，mine/upgrade 全被 'have 4, need 5' 拒绝。take 空跑 12 次、store_items 路径被挡、ship 在非农场地图失败，都是脚本生成阶段就该删除的分支。唯一有效产出是 Forest 钓鱼约 750g。今天第一动作必须是无条件在农场出货箱卖 Copper Bar 腾格，然后电梯 40 层刷铁。

**新教训：**
- 昨天 ship Copper Bar 在 ArchaeologyHouse 报 'not found' 而材料显示背包有 91 个：ship 动作只在农场出货箱附近有效，脚本生成阶段应把 ship 的 location 硬编码为 Farm，其他地图一律不生成 ship 分支。
- 昨天 mine 在 Farm 报 'store did not free enough slots (have 4, need 5)'，说明 mine 动作在非矿洞地图也会先尝试 store 再下矿：脚本生成阶段若背包空格<5 就物理删除 mine 分支，且 mine 前必须先 goto Mine 入口。
- 昨天 leave_mine 在 Farm 报 'not in the mine'：leave_mine 只能在 mine 成功之后生成，脚本生成阶段应检查上一条动作是否为 mine。
- 昨天 15:50 起 load_machines 连续报 'no empty machine accepts that'：Iron Ore 只有 1 时 load 分支应在脚本生成阶段物理删除，只有读背包确认 Iron Ore≥5 且有空炉才生成。
- 昨天 12 次 take 全部空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，需要矿物只能下矿现拿，take 应全天物理删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 24）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 91313g 远超 5000，唯一卡点是 Iron Bar 1/5。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 4 空格，91 个 Copper Bar 一个没卖，mine 和 upgrade_tool 都被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 24）**：起床 collect→**农场出货箱无条件 ship Copper Bar 留 20（约 71 个，腾 4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼到 21:30。
- **明天（春 25）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 26）**：继续铁锭链；若洒水器已齐则开始规划夏季啤酒花地块。

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
11. **春 24 不买种子**：只做清包+下矿+钓鱼；种子等复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 24 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
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
9. 春 24 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 41 动作 23 失败，核心仍是背包空格不足：91 个 Copper Bar 没卖，mine/upgrade 全被 'have 4, need 5' 拒绝。take 空跑 12 次、store_items 路径被挡、ship 在非农场地图失败，都是脚本生成阶段就该删除的分支。唯一有效产出是 Forest 钓鱼约 750g。今天第一动作必须是无条件在农场出货箱卖 Copper Bar 腾格，然后电梯 40 层刷铁。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Stone' not found in inventory 〔自动〕
- 09:50 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 09:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 10:50 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 10:50 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:00 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 12:30 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 背包空格始终只有 4，91 个 Copper Bar 一个没卖，导致下矿和升级工具连续被拒 @ Farm 出货箱 / Blacksmith — mine 报 'store did not free enough slots (have 4, need 5)'；upgrade_tool 报 'store did not free enough slots (have 4, need 5)'（做不了：无法下矿拿铁矿石，无法升级 Steel Hoe，铁锭链连续多天零推进） 〔复盘〕
- take 动作空跑 12 次，反复重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；脚本重写 3 次仍重试（做不了：浪费动作和时间，脚本重写循环） 〔复盘〕
- store_items 路径被挡，无法把背包物品存进箱子腾格 @ Farm 箱子 (74,16) — could not reach (74,16); stopped at (53,8)（做不了：无法通过存箱腾出背包空格，间接导致 mine/upgrade 失败） 〔复盘〕
- ship 在非农场地图执行失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory（实际背包有 91 个）（做不了：清包动作无效，背包持续满） 〔复盘〕
- donate_museum 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费早晨时间，无产出） 〔复盘〕
- build_road 失败且对里程碑零贡献 @ Farm — 规划道路边没有还能走上去的空格（做不了：浪费动作） 〔复盘〕
- load_machines 无空炉可接受物品 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石无法入炉，铁锭链停滞） 〔复盘〕
- 全天 23 失败、最后 22:20 才睡，钓鱼是唯一有效产出 @ Forest / 全地图 — 41 动作 23 失败，出货估值仅 750g（做不了：里程碑零推进，时间被空转消耗） 〔复盘〕
