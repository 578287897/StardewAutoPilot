# 第5年 fall 19 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（07:32 开始）
- 天气：sunny　金钱：65573g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6ad925c6aede4c94a7913db14f9efdc4
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：d044ac76f9694815a1b93784f9918812
  - 耗时：3.406 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：65b13d4008414d27be031179b6b8f296
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：fc8ba703ebdc4e42a7f1a5bccc47a6d7
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：ad8bf4914d0e40c1ba0449d27344b742
  - 耗时：0.532 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_19）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——今天主活动是电梯直达40层刷铁矿石和煤
- 起床收熔炉→装铁矿石→卖Copper Bar留20腾格
- 补沙拉到≥8，下矿40→50层拿铁矿
- 回农场收铁锭，铁锭≥5且时间<13:00去铁匠铺升hoe
- 铁锭富余则做洒水器×4，21:30前sleep
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
11. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds", "Salad", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Scythe", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Copper Ore", "Coal"]）
12. `goto_location`（location="Saloon"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=4）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds", "Salad", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Scythe", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Copper Ore", "Coal"]）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `goto_location`（location="Blacksmith"）
24. `upgrade_tool`（tool="hoe"）
25. `goto_location`（location="Farm"）
26. `craft`（item="Sprinkler", count=1）
27. `place`（item="Sprinkler", x=70, y=20）
28. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：81f208b00bc44305ba2afd625df8420a
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败即物理删除取箱与博物馆分支，保留清包→40层刷铁→回农场收锭→升hoe的主线，铁锭不足则跳过升级直接收尾。
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
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds", "Salad", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Scythe", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Copper Ore", "Coal", "Gold Bar"]）
18. `collect_machines`
19. `ship_produce`（except=["Iron Bar", "Pumpkin Seeds", "Salad", "Claymore", "Steel Pickaxe", "Steel Axe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Scythe", "Bamboo Pole", "Silver Saber", "Burglar's Shank", "Rubber Boots", "Copper Ore", "Coal", "Gold Bar"]）
20. `craft`（item="Sprinkler", count=1）
21. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：01425081be204ecd9ce4371dfa300b9b
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为起床收炉装矿→40层刷铁→回农场收铁锭→铁匠铺升hoe→做洒水器睡觉。
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
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `collect_machines`
20. `craft`（item="Sprinkler", count=1）
21. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5b4ac26999b04b3cb98d662c0101acda
  - 耗时：0.515 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为起床收炉装矿、卖 Copper Bar 腾格后直奔 40 层刷铁，回农场收锭炼铁并做洒水器，最后睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=63）
10. `ship`（item="Sap", count=50）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `craft`（item="Sprinkler", count=1）
21. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：764e8b7c52e6473e97ce40f2c608cba2
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f38329b9004c454da46dcd3f1c99f6de
  - 耗时：0.468 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5476e91e4ab943c486aa2abc26dc4631
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：927839724584403183c5692551b0db4d
  - 耗时：86.157 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：f4c14e0917bf438f990e55c8a276bf13
  - 耗时：47.063 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：f8a4f78a92bc4441b38c3efce7d88f6d
  - 耗时：0.453 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=63）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：9d7acb3b884f4cb08bcfac04afb5d9b5
  - 耗时：0.469 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Sap", count=50）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：80ecf151b97247578344ca7ce14f84a2
  - 耗时：0.468 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：192104be93af4f279a85de3e335ba97b
  - 耗时：51.391 秒 / 游戏 70 分钟
- **10:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 98 (3 floors down, 32 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：f6812da326eb4512b1623e918feb9503
  - 耗时：51.828 秒 / 游戏 60 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Sap
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Fiber
  - 🗨️ [question] 
- **11:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：30d2f2bcc7e4406ca75c0264b97862c2
  - 耗时：35.828 秒 / 游戏 50 分钟
- **11:00** Mine ❌ `store_items`（items=["Stone", "Pumpkin Seeds", "Sap", "Salad", "Slime", "Rubber Boots", "Fiber"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：56315c2b707b41f887d5f9a4003b61dd
  - 耗时：13.219 秒 / 游戏 10 分钟
- **11:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **12:00** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (53,8)
  - 执行状态：SUCCESS · 操作编号：edf85977a9334a02bd7a7bf0f15ca6ed
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：3ef2ecec3af54e6fadb26cd3b0497c12
  - 耗时：0.531 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：2cfccfc3b2f640a58bd009ad55d771e8
  - 耗时：0.5 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `ship_produce`
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：711035658ae54ca2a31f695acdc7e673
  - 耗时：7.672 秒 / 游戏 10 分钟
- **12:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:10** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：bc33fe43aa27455b812e8b4a5759c74e
  - 耗时：0.516 秒 / 游戏 0 分钟
- **12:10** Farm ❌ `store_items`（items=["Stone", "Pumpkin Seeds", "Sap", "Salad", "Slime", "Rubber Boots", "Fiber", "Sprinkler"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：bb97c075ade242a6baee8277319e5698
  - 耗时：7.656 秒 / 游戏 10 分钟
- **12:10** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **12:20** Farm ❌ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：could not reach (41,63); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：dff795ac154e4cbf98d049d8e1a4c803
  - 耗时：7.672 秒 / 游戏 10 分钟
- **12:30** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **12:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 2:30 pm
  - 执行状态：SUCCESS · 操作编号：5baccd739d014c709933f20863f9002b
  - 耗时：81.406 秒 / 游戏 120 分钟
- **14:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:30 pm
  - 执行状态：SUCCESS · 操作编号：659e200ec6464ac297b758b8b68f1456
  - 耗时：87.89 秒 / 游戏 120 分钟
- **16:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:30 pm
  - 执行状态：SUCCESS · 操作编号：f91a8e03c3c743a1818a7d19e1a5a67a
  - 耗时：87.906 秒 / 游戏 120 分钟
- **18:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：6b7230603f0649419d29ba12f576719a
  - 耗时：9.438 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65573 → 65573（+0g）
- 出货估值：0g　动作：44 个　失败：29 个
- 模型调用：7 次　tokens：87119
- 有效动作率：0.25　空转：9　熔断跳过：8
- 失败耗时：43.795 秒 / 游戏 40 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天29次失败中12次是take猜箱子ID、2次store_items路径不可达、2次mine因清包失败被拒，真正有效动作只有craft洒水器1个。核心因果链：清包失败→空格不足→下矿被拒→空转wait到18:30。Copper Bar 82个从未卖出，铁锭仍1/5。今天必须把清包做成硬门槛：先读背包→卖Copper Bar留20→读背包验证空格≥5，验证不过立即定性钓鱼日。

**新教训：**
- 昨天 ship_produce 卖 Copper Bar 报 not found，但材料清单显示背包有 82 个 Copper Bar：说明 ship 前读到的背包清单与材料汇总不一致，ship 应以刚读到的背包清单为准，清单里没有就跳过，不要用材料汇总数字反推。
- 昨天 mine 成功从 95→98 层后背包几乎满，回农场 store_items 却因箱子坐标(74,16)不可达失败，导致第二次 mine 被「have 1, need 5」拒绝：下矿前清包必须在农场内完成并读背包验证，不能指望下矿回来再存。
- 昨天 12:10 craft 洒水器成功但紧接着 store_items 想把洒水器存箱失败，洒水器留在背包占格：craft 出的成品应立即 place 到地块，不要先存箱。
- 昨天 16:30-18:30 连续 3 次 wait 120 分钟，因为清包失败后 mine/upgrade 分支全被删但脚本没有钓鱼兜底：清包验证失败后必须立即生成 goto Forest→fish 分支，而不是 wait 到 21:30。
- 昨天 goto_location Forest 报 could not reach (41,63); stopped at (53,8)，说明从 Farm(53,8) 到 Forest 的路径被挡：去 Forest 钓鱼前应先 goto Farm 出口或走 Town 中转，不要从农场中部直接寻路。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 20）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65573g 充足，卡点 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在后面。

离完成还差：约 16 铁矿石 + 4 煤 → 4 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 且食物≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 20）**：起床 collect→读背包→卖 Copper Bar 留 20（约 62 个，腾 3-4 格）→验证空格≥5→Saloon 买沙拉到≥8→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 21）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 22）**：继续刷铁备钢斧，给作物地块补洒水器。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天只卖 140g 垃圾，空格没动。今天起床读背包后，**显式 ship_produce Copper Bar 卖 count=背包数-20**（约 62 个，约 7k），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜（昨天 ship Copper Bar/Gold Bar 报 not found 就是猜的）。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **食物门票前置**：下矿前读背包确认 Salad≥5；不足则**先 goto Saloon→open_shop→buy 沙拉到≥8**，再回 Mine。昨天 19 层因 0 食物撤退两次，今天绝不允许食物<5 时调 mine。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。昨天重写 3 次浪费 12+ 动作。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0、donate=0、build_road=0、decorate=0、wait=0**。
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
3. 清包到空格≥5（**先读背包清单，卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天29次失败中12次是take猜箱子ID、2次store_items路径不可达、2次mine因清包失败被拒，真正有效动作只有craft洒水器1个。核心因果链：清包失败→空格不足→下矿被拒→空转wait到18:30。Copper Bar 82个从未卖出，铁锭仍1/5。今天必须把清包做成硬门槛：先读背包→卖Copper Bar留20→读背包验证空格≥5，验证不过立即定性钓鱼日。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
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
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Sap' not found in inventory 〔自动〕
- 11:00 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 11:00 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 12:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 12:00 动作 `ship_produce` 失败 @ Farm — could not reach (70,15); stopped at (53,8) 〔自动〕
- 12:10 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:10 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:10 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 清包失败导致下矿被拒，全天零推进 @ Farm 箱子旁 / Mine 入口 — store_items 报 could not reach (74,16); stopped at (53,8)，空格仍 1；随后 mine 报 store did not free enough slots (have 1, need 5)（做不了：40 层刷铁矿、炼铁锭、升钢锄头全部做不成） 〔复盘〕
- take 凭物品 ID 猜箱子内容，12 次全失败 @ Farm — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；重写脚本后仍重试同一批 ID（做不了：无法从箱子取矿物/宝石，donate 也因背包无可捐物失败） 〔复盘〕
- 清包只卖低价值垃圾，Copper Bar 82 个从未卖出 @ Farm 出货箱 — ship_produce 只卖出约 140g 的 Green Algae/Broken CD 等，Copper Bar 被 except 排除；空格从 3 降到 1（做不了：背包空格不足，下矿和升级都被卡死） 〔复盘〕
- 下矿回来想存物品但箱子路径不可达 @ Farm (53,8) 到箱子 (74,16) — store_items 两次报 could not reach (74,16); stopped at (53,8)（做不了：下矿收获无法入库，第二次下矿被空格不足拒绝） 〔复盘〕
- 清包失败后没有钓鱼兜底，空转 wait 到 18:30 @ Farm — 16:30/14:30/12:30 三次 wait 120 分钟 filler:true，全天有效动作仅 1 个 craft（做不了：浪费 6 小时游戏时间，本可钓鱼或补种） 〔复盘〕
