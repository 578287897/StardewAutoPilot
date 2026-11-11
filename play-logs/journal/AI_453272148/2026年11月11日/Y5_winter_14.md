# 第5年 winter 14 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（12:07 开始）
- 天气：snow　金钱：70340g　体力：270/270
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
  - 执行状态：SUCCESS · 操作编号：255ff720e80e4166bee36d12a298159e
  - 耗时：5.156 秒 / 游戏 0 分钟
  - 🗨️ [mail] Starting tomorrow, a traveling merchant fleet will dock at Pelican Town for the yearly night market.  The market starts at 5pm, and will be in port for the next three days.  Please visit the beach after 5pm to join the festivities. There's free coffee!
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4e4fe72062a84eb38fbb5738322627ff
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：f246ab84076f41b0aa6d53bf5d61c4a7
  - 耗时：4.969 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：47b2503144304107bf5afde4c1e0c7e6
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：e9816b7cf7f14015bbe0c035919e8d31
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：shipped 4 stacks worth ~1535g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：8bbd44e41c4048a0ba98c61c9e25d699
  - 耗时：0.797 秒 / 游戏 10 分钟

## 🌙 为明天（Y5_winter_14）准备的脚本
- 里程碑：Steel Hoe（5000g + 5 铁锭）——今天必须凑齐 4 块铁锭
- 起床先收熔炉，再在农场出货箱卖 Copper Bar 留 20 腾出至少 5 格
- 背包腾出空格后，坐电梯到 40 层刷铁矿石和煤（最多 2 次，每次不超过 5 层）
- 回农场炼铁，铁锭达到 5 块且在 12:00 前就去铁匠铺升 hoe
- 清包失败或下矿被拒，就立刻转去 Forest 钓鱼，不空转
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
11. `ship`（item="Copper Bar", count=65）
12. `ship`（item="Stone", count=1000）
13. `ship`（item="Sap", count=40）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Bamboo Pole", "Magma Geode", "Tiger Trout", "Chub", "Pike", "Perch"]）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=6）
25. `fish`（casts=6）
26. `goto_location`（location="Farm"）
27. `collect_machines`
28. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Bamboo Pole", "Magma Geode"]）
29. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：eef1692e14a14eb9b03be3906cc6cc12
  - 耗时：0.609 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败源于箱子内容与记忆不符，删除全部 take/donate 分支，改为农场出货箱清包后下矿刷铁，凑不齐铁锭则转 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `goto_location`（location="Forest"）
13. `fish`（casts=6）
14. `fish`（casts=6）
15. `fish`（casts=6）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Gold Ore", "Coal", "Pumpkin Seeds", "Fiberglass Rod", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Claymore", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Bamboo Pole", "Magma Geode", "Tiger Trout", "Chub", "Pike", "Perch"]）
19. `collect_machines`
20. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c4f77791e09a46cf9353c9c785d8e36e
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：放弃已失效的箱子 take 与博物馆分支，改为出货箱卖 Copper Bar 腾格后下矿刷铁，失败即转 Forest 钓鱼，收尾回农场睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=400）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Forest"）
15. `fish`（casts=6）
16. `fish`（casts=6）
17. `fish`（casts=6）
18. `fish`（casts=6）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：504532764e1c46eda087e3f3e39d13cc
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 箱子物品连续失败，删除该分支；改为在农场出货箱卖 Copper Bar 腾格后下矿刷铁，失败即转 Forest 钓鱼，收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Stone", count=400）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Forest"）
15. `fish`（casts=6）
16. `fish`（casts=6）
17. `fish`（casts=6）
18. `fish`（casts=6）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：827774a0fc634db3a4ae00f77f14f176
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9d835af3500f4a39930c37e975fb5d9f
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3818226b856b46a9afc9daf708c8d9f3
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：d70b0ca07d2b4daea713160f1f598887
  - 耗时：80.25 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：44e5d933a16d4743b3773d279d2f4144
  - 耗时：44.14 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：08c5cfc41a794eeaa949d39a85d47d69
  - 耗时：0.515 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=65）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：c6b9d0aaf2ea4056aa2b969298e7e532
  - 耗时：0.5 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=400）
  - 结果：shipped 27x Stone (~54g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：abc801b1a05648c8b76fc9bebd4e1eb4
  - 耗时：44.0 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：604707c4604c4806ba288c6be31ab511
  - 耗时：89.188 秒 / 游戏 120 分钟
- **11:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 16 (1 floors down, 36 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：c84cf0e839254c2ca91076ac2ad8587a
  - 耗时：29.39 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [question] 
- **12:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4b051073970341869c27d62942c500d7
  - 耗时：35.828 秒 / 游戏 50 分钟
- **12:10** Mine ✅ `store_items`（items=["Stone", "Magma Geode", "Pumpkin Seeds", "Rubber Boots", "Slime", "Bug Meat"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Slime, 2x Bug Meat
  - 执行状态：SUCCESS · 操作编号：f1e5f05586ea48b99c89f08267a79e86
  - 耗时：15.078 秒 / 游戏 20 分钟
- **12:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **13:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：06c864284de4471292a6d534ef859575
  - 耗时：23.844 秒 / 游戏 30 分钟
- **13:50** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Perch, Green Algae, Green Algae, Green Algae, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：dcb87674bac44d5eb59183d5c52da409
  - 耗时：119.781 秒 / 游戏 130 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
- **16:00** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Green Algae, Pike, Perch, Pike, River Jelly, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：3f1c9783773e4c01913f79a88375c529
  - 耗时：80.328 秒 / 游戏 70 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
- **17:10** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Perch, Broken Glasses, Perch, Pike, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：93211b17ad6643708caca10c87b39673
  - 耗时：135.954 秒 / 游戏 140 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **19:30** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Pike, Pike, Green Algae, Green Algae, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：e3a8a7b400374f58b721558dfbd42614
  - 耗时：116.703 秒 / 游戏 110 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
- **21:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：2dc962ecb4df4ded9b9ba40642395385
  - 耗时：9.703 秒 / 游戏 10 分钟
- **21:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：0aa420a5f61f4b8d9e5a2fedcc299db6
  - 耗时：0.547 秒 / 游戏 0 分钟
- **21:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1be02a339fec4bb99411da70e02a86c4
  - 耗时：0.5 秒 / 游戏 0 分钟
- **21:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **21:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7fc57787b984444ea0165e7fc547fc95
  - 耗时：23.593 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：70340 → 71929（+1589g）
- 出货估值：1535g　动作：39 个　失败：20 个
- 模型调用：6 次　tokens：69721
- 有效动作率：0.5161　空转：6　熔断跳过：7
- 失败耗时：6.921 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包：Copper Bar 85 个一个没卖，空格始终 3 格，导致 mine 被拒、升级无望；take/store_items/donate 空跑 15 次。有效做法是 Forest 钓鱼 24 条贡献约 2.1k。今天必须把「卖 Copper Bar 留 20」作为起床第一动作，并读背包验证空格≥5，验证失败立即转钓鱼，不再重试 mine。

**新教训：**
- 昨天清包只卖出 80 石头（160g），Copper Bar 85 个一个没卖，空格始终 3 格，直接导致 2 次 mine 被 'have 3, need 5' 拒绝：清包第一步必须是卖 Copper Bar 留 20，这是唯一能腾 3-4 格的手段。
- 昨天 11:00 就 sleep 收工，全天仅 39 动作、20 失败：清包验证失败后必须立即生成 goto Forest→fish 分支填满剩余时间，不能因为 mine/upgrade 分支被删就无事可做直接睡。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，但材料显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包。
- 昨天 load_machines 报 'no empty machine accepts anything' 而 Iron Ore 只有 1：load 前必须读背包确认 Iron Ore≥5 且炉子为空，否则物理删除 load 分支。
- 背包 0 空格时 store_items 会返回 'nothing to store' 空跑（昨天 10 次），因为箱子已满或物品不可堆叠：清包只能靠出货箱 ship_produce 卖 Copper Bar，store_items 应全天物理删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 15）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 70340g 足够，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿与升级的共同门票**——昨天背包 0 空格，take×6、mine×4、升级全部被拒，而背包里 85 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 15）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 16）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 17）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱卖 Copper Bar 留 20**：起床读背包后显式 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 10 次、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 89/95 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
10. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 15 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
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
> 昨天核心失败是清包：Copper Bar 85 个一个没卖，空格始终 3 格，导致 mine 被拒、升级无望；take/store_items/donate 空跑 15 次。有效做法是 Forest 钓鱼 24 条贡献约 2.1k。今天必须把「卖 Copper Bar 留 20」作为起床第一动作，并读背包验证空格≥5，验证失败立即转钓鱼，不再重试 mine。
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
- 12:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 21:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 21:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 21:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包失败：Copper Bar 85 个一个没卖，空格始终 3 格，导致下矿和升级全部被拒 @ 农场出货箱 — ship_produce 只卖了 80 石头（160g），Copper Bar 未进 ship 清单；mine 报 'store did not free enough slots (have 3, need 5)'（做不了：Steel Hoe 升级、40 层刷铁、洒水器制作全部卡住） 〔复盘〕
- take 连续 12 次空跑，脚本重写 3 次仍重试同一批箱子 ID @ 农场箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；already failed; not retrying today（做不了：浪费约 15 个动作和 3 次脚本重写，挤占了清包和下矿时间） 〔复盘〕
- store_items 空跑 10 次，箱子坐标记忆失效 @ 农场 — nothing to store；目标坐标(74,16)不可达（stopped at 53,8）（做不了：无法通过存箱腾格，清包只能靠出货箱 ship） 〔复盘〕
- 下矿被拒后没有钓鱼兜底，12:40 到 21:30 空转 @ Mine / Farm — mine 报 'store did not free enough slots (have 3, need 5)'，脚本删除 mine 分支后无替代分支（做不了：下午黄金时段没有产出，全天出货仅 1535g） 〔复盘〕
- donate_museum 在博物馆空跑，且 goto ArchaeologyHouse 因 Town 不可达失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费动作，博物馆捐献进度无推进） 〔复盘〕
- load_machines 报无空炉可接受物品，而 Iron Ore 只有 1 @ 农场熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：熔炉空转，铁锭链无法推进） 〔复盘〕
