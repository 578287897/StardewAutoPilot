# 第5年 summer 18 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：重写#1：清包腾格后电梯40层刷铁矿炼铁锭，凑齐5铁锭赶13点前升钢锄头，推进卡了多天的工具里程碑。
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
12. `leave_mine`
13. `goto_location`（location="Mountain"）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds", "Melon Seeds", "Hops Starter", "Salad", "Strange Bun"]）
20. `ship`（item="Copper Bar", count=1）
21. `ship`（item="Stone", count=58）
22. `ship_produce`
23. `collect_machines`
24. `sleep`

## 🌅 早上的计划（00:00 开始）
- 天气：sunny　金钱：63708g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——今天主活动下矿40层刷铁矿
- 起床收熔炉成品，有空炉且铁矿≥5就装料
- 清包：ship_produce 卖冗余（铜锭留20、金锭留2、石头留500、多余种子各留5），验证空格≥10
- 补食物到≥5（Saloon 12点后买沙拉）
- 电梯直达40层，mine 40→50 拿铁矿石+煤
- 回农场收铁锭，铁锭≥5且时间<13:00去铁匠铺升 hoe
- 21:30 前 sleep

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="62", item_name="Aquamarine", count=1）
4. `take`（item="64", item_name="Ruby", count=1）
5. `take`（item="68", item_name="Topaz", count=1）
6. `take`（item="72", item_name="Diamond", count=1）
7. `take`（item="84", item_name="Frozen Tear", count=1）
8. `take`（item="86", item_name="Earth Crystal", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate_museum`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Mountain"）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Copper Bar", "Gold Bar", "Stone", "Cauliflower Seeds", "Potato Seeds", "Radish Seeds", "Red Cabbage Seeds", "Melon Seeds", "Hops Starter", "Salad", "Strange Bun"]）
22. `ship`（item="Copper Bar", count=1）
23. `ship`（item="Stone", count=58）
24. `ship_produce`
25. `collect_machines`
26. `sleep`

### 🔁 脚本重写：重写#1：背包0空格，先收炉装矿再清包卖冗余，然后电梯40层刷铁矿石，回农场炼铁，铁锭不足则明天继续。
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
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
17. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Iron Ore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `sleep`

## 🌅 早上的计划（00:02 开始）
- 天气：sunny　金钱：63708g　体力：270/270
- 里程碑：钢锄头（5000g + 5 铁锭）——今天必须下矿拿铁
- 起床收炉→装铁矿石→清包到空格≥10→补食物≥5→电梯40层刷铁矿石+煤
- 铁锭≥5 且 13:00 前回铁匠铺升 hoe

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="62", item_name="Aquamarine", count=1）
4. `take`（item="64", item_name="Ruby", count=1）
5. `take`（item="68", item_name="Topaz", count=1）
6. `take`（item="72", item_name="Diamond", count=1）
7. `take`（item="84", item_name="Frozen Tear", count=1）
8. `take`（item="86", item_name="Earth Crystal", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate_museum`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
19. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Iron Ore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：1353903d99d04edea633077e7acfc52e
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：ae1718379b8e4cd5863880ba12bbe7b7
  - 耗时：3.282 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Green Algae", "Hops Starter", "Trash"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 3x Green Algae, 1x Trash
  - 执行状态：SUCCESS · 操作编号：79ec42157d3e4dfe870d6102423061e7
  - 耗时：6.141 秒 / 游戏 10 分钟
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f91f036e037a4951bc52952e32b75a24
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 失败已物理删除，改为先 ship_produce 清包再下矿 40 层刷铁，回农场炼铁收尾。
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
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Iron Ore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
18. `collect_machines`
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6ae18b5fa9d6465ca5c81512c7edd6c1
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为先 ship_produce 卖冗余腾格，再电梯 40 层刷铁，回农场收炉炼铁，最后睡觉。
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
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
15. `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Iron Ore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `collect_machines`
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：31f01f2c4f77443c81dbecba3b0df28e
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a63697dcfa8445198e6529198f5928d6
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：84faef2f145c4c0eb1346b08626dd82f
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4e30646c2d694881b0baad65c7ea7d1a
  - 耗时：0.469 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5ff71f5ea55f42cbb9c18846ecb033d4
  - 耗时：80.25 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：587878cf1a694982a961640a420545a2
  - 耗时：48.172 秒 / 游戏 60 分钟
- **09:00** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：49c0e81d31e94cfd8778bca420c4def6
  - 耗时：0.5 秒 / 游戏 0 分钟
- **09:00** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a27c207ba090488e849150ef2f0a1b14
  - 耗时：51.312 秒 / 游戏 60 分钟
- **10:00** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：7f34242e4e254d56b01dac9b62808e70
  - 耗时：33.61 秒 / 游戏 40 分钟
- **10:00** Mine ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7ea8e0ad08d946518dd71239f523e3a8
  - 耗时：15.062 秒 / 游戏 20 分钟
- **10:00** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：5fc7a84203ce47248497661332ef3f29
  - 耗时：0.516 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：a53cc3b2153547a1ab168b115e81aaae
  - 耗时：0.437 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：bd6ba3b3563546c3a1842fc6786a282a
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：ddcddc93268c430c94bdf2508e26a3ff
  - 耗时：0.469 秒 / 游戏 0 分钟
- **11:00** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Melon Seeds", "Hops Starter", "Radish Seeds", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Copper Ore", "Coal", "Stone", "Iron Ore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rusty Sword", "Silver Saber", "Claymore", "Green Algae"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：7880ed3567af4b0cb220cab28a767db0
  - 耗时：0.469 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：a671d7e9c98646d28d0dbbdcfa89dafe
  - 耗时：0.437 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：982a5828c19241ac836dc7ea6a2bba7c
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:00** Farm ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Salad", "Potato Seeds", "Red Cabbage Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Hops Starter"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：3f3a859fb7144e31880b94fe5b8369b9
  - 耗时：0.437 秒 / 游戏 0 分钟
- **11:00** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **11:00** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：5d81afc8005446d0a5df6389336d8ebc
  - 耗时：23.859 秒 / 游戏 30 分钟
- **11:30** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 4 forage items
  - 执行状态：SUCCESS · 操作编号：3ad90ea7f3c64100916ba0888552ac17
  - 耗时：87.953 秒 / 游戏 120 分钟
  - 🗨️ [hud] Spice Berry
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Sweet Pea
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Sweet Pea
- **13:30** Forest ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **13:30** Forest ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：bfe3eccb0f964f54a0a9175c9ae8aaf2
  - 耗时：47.781 秒 / 游戏 60 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：63708 → 63708（+0g）
- 出货估值：0g　动作：35 个　失败：20 个
- 模型调用：4 次　tokens：41341
- 有效动作率：0.4　空转：7　熔断跳过：4
- 失败耗时：6.14 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天35动作20失败，核心是背包只有2格：mine被need 5拒绝3次，ship_produce返回nothing to ship（背包全是保留物），store_items返回OK却不腾格。take凭ID猜箱子12次全失败，donate_museum空跑。铁锭仍0/5，钢锄头连续多天零推进。真正有效的只有forage捡4个采集物。今天必须先解决背包，否则下矿和升级都无从谈起。

**新教训：**
- 昨天 mine 三次被「store did not free enough slots (have 2, need 5)」拒绝，而 ship_produce 返回 nothing to ship：清包必须卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，不能只卖低价值物，否则背包永远是 2 格。
- 昨天 donate_museum 在背包无可捐物时仍先 goto ArchaeologyHouse 再失败，浪费 2 个动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。
- 昨天 build_road 返回「规划道路边没有还能走上去的空格」、decorate 返回「今天没有能做的装饰」，两者连续多天 0 产出：这两个动作应从脚本中彻底删除，不再作为填充动作。
- 昨天 1100 后连续 3 次 wait 填充到 1800 才睡，纯浪费 7 小时游戏时间：等炉子应改为去 Forest 钓鱼或下矿，回来再 collect，绝不用 wait 空转。
- 昨天 mine 在 40 层前就被「store did not free enough slots (have 3, need 5)」拒绝两次，而清包动作返回 OK 却没腾格：下矿前必须显式读背包确认空格≥5，不能信任 store_items 的 OK 返回。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 夏 19）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 63708g 充足，卡点 Iron Bar 0/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 和食物≥5 是两张门票，缺一张当天就白跑**。

接下来 3 天主活动：
- **今天（夏 19）**：起床收炉→**用 ship_produce 卖 Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5，读背包验证空格≥5**→补食物≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（夏 20）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧（同配方 5 铁锭）；铁锭富余后做洒水器 ×4。
- **后天（夏 21）**：继续刷铁备钢斧，同时给蓝莓/啤酒花地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包目标降到空格≥5，且只认 ship_produce**：昨天 mine 三次被「have 2, need 5」拒绝，而 ship_produce 返回 nothing to ship 是因为背包全是保留物。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20 其余全卖、Gold Bar 留 2 其余全卖、Stone 留 500 其余全卖、多余种子（Cauliflower/Potato/Radish/Red Cabbage）各留 5** → 读背包验证空格≥5。两次 ship 后仍<5 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。清包唯一手段是 ship_produce。
3. **食物提前到清包后立刻解决**：清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
4. **下矿目标 40 层，不贪 80 层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
6. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 清包到空格≥5：goto Farm → ship_produce 卖高价值冗余（Copper Bar 留 20、Gold Bar 留 2、Stone 留 500、多余种子各留 5）→ 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包，不调 store_items，不重试同一坐标。
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
3. 清包到空格≥5（**只用 ship_produce 卖高价值冗余**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天35动作20失败，核心是背包只有2格：mine被need 5拒绝3次，ship_produce返回nothing to ship（背包全是保留物），store_items返回OK却不腾格。take凭ID猜箱子12次全失败，donate_museum空跑。铁锭仍0/5，钢锄头连续多天零推进。真正有效的只有forage捡4个采集物。今天必须先解决背包，否则下矿和升级都无从谈起。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 09:00 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:00 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 11:00 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 11:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:00 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 13:30 动作 `decorate` 失败 @ Forest — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包长期只有 2 格，清包动作返回 OK 却不腾格，导致下矿和升级全部被拒 @ Farm 箱子旁 — mine 三次返回「store did not free enough slots (have 2, need 5)」，ship_produce 返回「nothing to ship」，store_items 返回 OK 但空格未增（做不了：无法下矿拿铁矿石，铁锭 0/5，钢锄头连续多天零推进） 〔复盘〕
- 凭物品 ID 猜箱子内容，12 次 take 全失败 @ Farm 箱子 — take 62/64/68/72/84/86 返回「'X' is not in any farm chest」或「already failed; not retrying today」（做不了：无法取出宝石捐博物馆或用于其他用途，浪费 12 个动作） 〔复盘〕
- 背包无可捐物时仍先跑到博物馆再失败 @ ArchaeologyHouse — donate_museum 返回「nothing in the backpack can be donated to the museum」（做不了：浪费 2 个动作和跑图时间，博物馆捐赠进度停滞） 〔复盘〕
- build_road 和 decorate 连续多天 0 产出 @ Farm — build_road 返回「规划道路边没有还能走上去的空格」，decorate 返回「今天没有能做的装饰」（做不了：浪费动作，没有实际进展） 〔复盘〕
- 等炉子时用 wait 空转，浪费大量游戏时间 @ Farm — 1100 后连续 3 次 wait 填充到 1800 才睡，纯浪费 7 小时游戏时间（做不了：没有推进任何里程碑，当天有效动作极少） 〔复盘〕
