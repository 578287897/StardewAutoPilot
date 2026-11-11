# 第5年 fall 27 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:02 开始）
- 天气：sunny　金钱：64763g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：50332d6729474f3f9d1666af6f6bdb3b
  - 耗时：17.359 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：55efd2397ff24087b303f9d79c6f6517
  - 耗时：18.344 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：60046b731ecb41728c6906979e84c458
  - 耗时：0.625 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：e4096d9b5fe648a3a6bf951b31699f5a
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~75g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：30d71e8b12174e1ea2d722726ee6d783
  - 耗时：0.812 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_27）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收熔炉成品，空炉且铁矿够就装铁矿石
- 清包：卖 Copper Bar 留 20 腾格子，读背包验证空格≥5
- 确认 Salad≥5（已有 8 个，跳过买沙拉）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine 每次 ≤5 层
- 回农场收铁锭，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 今天是 Spirit's Eve 节日日，22:00 去 Town 参加节日
- 21:30 后只 sleep
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
11. `ship_produce`（except=["Salad", "Smallmouth Bass", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar", "Copper Bar"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=0）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `ship_produce`（except=["Salad", "Smallmouth Bass", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar", "Copper Bar"]）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Town"）
24. `festival`（activity="start"）
25. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：30f275c95901462fb8bd5339bc98bbe5
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败因箱子无该物品，物理删除 take/donate 分支；保留清包卖 Copper Bar→40 层刷铁→回农场收锭→Blacksmith
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
14. `goto_location`（location="Town"）
15. `festival`（activity="start"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Smallmouth Bass", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
20. `collect_machines`
21. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3439df76b74d41cbae5ea5de11d4d8eb
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 已物理删除，改为起床收炉→装铁矿→卖 Copper Bar 清包→40 层刷铁→回农场收锭→Blacksmith 升 hoe→22:00 参
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
14. `goto_location`（location="Town"）
15. `festival`（activity="start"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
20. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a9e089000388466e8a6780084eeb5cf1
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：放弃失败的 take 分支，改为卖 Copper Bar 清包后直接下 40 层刷铁，回农场收锭并赶在 13:00 前升 hoe，晚上参加 Spiri
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
14. `goto_location`（location="Town"）
15. `festival`（activity="start"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
20. `collect_machines`
21. `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
22. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：dfb6eb4cc8a34ac192dc5c66813d3f97
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：62f4e6a90e564408bca0837e433ae767
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b619543db5d342b0a2ea56ade1feffbd
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：7380c54534b54f72aa88a22cc7989acf
  - 耗时：53.703 秒 / 游戏 80 分钟
- **08:00** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：no reachable route from Mountain to ArchaeologyHouse (unreachable exits: busstop->town, forest->town, mountain->town)
  - 执行状态：ACTION_FAILED · 操作编号：9eaa7f9c9b104f62992c67a866f7238c
  - 耗时：133.421 秒 / 游戏 160 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **10:40** Mountain ❌ `donate_museum`
  - 结果：no reachable route from Farm to ArchaeologyHouse (unreachable exits: mountain->town, backwoods->busstop, farm->busstop, farm->forest)
  - 执行状态：ACTION_FAILED · 操作编号：4f08afa7d3dc4e2fbcaa92cb3aa8f617
  - 耗时：48.75 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **11:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e3d5cd92c3aa425c9b79725a8c7c04b2
  - 耗时：38.843 秒 / 游戏 50 分钟
  - 🗨️ [hud] Hazelnut
- **12:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：d7ebb576e2c64b48a79374ec12cc22a3
  - 耗时：35.484 秒 / 游戏 40 分钟
- **12:30** Mine ✅ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Green Algae", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 4x Green Algae
  - 执行状态：SUCCESS · 操作编号：7973183b4e53416381a428f0a1b44205
  - 耗时：15.078 秒 / 游戏 20 分钟
- **12:30** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **13:30** Farm ✅ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：41bdb946c2e54e50aeab4574e1c174e3
  - 耗时：0.515 秒 / 游戏 0 分钟
- **13:30** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **13:30** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：no reachable route from Mountain to Blacksmith (unreachable exits: busstop->town, forest->town, mountain->town)
  - 执行状态：ACTION_FAILED · 操作编号：aca1b9ac57ff487a93590b22a90a180f
  - 耗时：137.5 秒 / 游戏 180 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **16:30** Mountain ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：10afe1eaf8dc4541b6e0d697e4b3244b
  - 耗时：23.828 秒 / 游戏 30 分钟
- **16:30** Mountain ✅ `store_items`（items=["Stone", "Squid Ink", "Pumpkin Seeds", "Rubber Boots", "Salad"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：c82a99472365495796e463d447a36e3c
  - 耗时：15.062 秒 / 游戏 20 分钟
- **16:30** Mountain ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **17:20** Farm ❌ `goto_location`（location="Town"）
  - 结果：exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later.
  - 执行状态：ACTION_FAILED · 操作编号：6282ef41b6a54b16bba08493caabc77d
  - 耗时：14.563 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
- **17:30** BusStop ❌ `festival`（activity="start"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：6f3f9da89eab4cc99115d566e66e6f82
  - 耗时：0.485 秒 / 游戏 0 分钟
- **17:30** BusStop ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：aae05676a6d642cebefef044a54ff8ed
  - 耗时：8.859 秒 / 游戏 10 分钟
- **17:40** Farm ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：1d5c8b9a1e2c4dacaaea68c8dbd5c38c
  - 耗时：17.641 秒 / 游戏 30 分钟
  - 🗨️ [hud] Gold Bar
- **18:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：882243d66d754de895c9129419f191dd
  - 耗时：0.531 秒 / 游戏 0 分钟
- **18:10** Farm ✅ `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
  - 结果：shipped 1 stacks worth ~90g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：c4b9ec53a3004bcd8c19cf1a453159cb
  - 耗时：17.609 秒 / 游戏 20 分钟
- **18:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：2bfd024c31594b40bf2fcdeb89729449
  - 耗时：0.515 秒 / 游戏 0 分钟
- **18:30** Farm ✅ `ship_produce`（except=["Salad", "Pumpkin Seeds", "Steel Axe", "Fiberglass Rod", "Scythe", "Copper Hoe", "Steel Pickaxe", "Steel Watering Can", "Claymore", "Silver Saber", "Burglar's Shank", "Bamboo Pole", "Rusty Sword", "Rubber Boots", "Iron Bar", "Gold Bar"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：399d0cc4738546e9899deeedac7a69e0
  - 耗时：0.531 秒 / 游戏 0 分钟
- **18:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：3b11274a6f5244179176d335d3f9cf60
  - 耗时：6.782 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64763 → 64928（+165g）
- 出货估值：165g　动作：40 个　失败：23 个
- 模型调用：7 次　tokens：88512
- 有效动作率：0.3939　空转：6　熔断跳过：6
- 失败耗时：340.499 秒 / 游戏 410 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天是秋27节日日，Town 全天被 Spirit's Eve 布置封锁，导致去博物馆/铁匠铺/节日全部不可达；同时背包只剩 2 格，清包没做（Copper Bar 85 个一个没卖），mine 和 upgrade 都被「have 2, need 5」拒绝，12 次 take 空跑。核心问题是：节日日没识别、清包没执行、背包门票没满足就生成下游动作。

**新教训：**
- 节日日（如 Spirit's Eve）Town 全天被布置封锁，goto Town/Blacksmith/ArchaeologyHouse 全部不可达：脚本生成阶段先检查 Town 可达性，出现「festival is being set up」即当天永久删除所有 Town 分支，只做农场+矿洞+钓鱼。
- 背包只剩 2 格时连续调 mine/upgrade_tool 会被「store did not free enough slots (have 2, need 5)」拒绝，且 store_items 无法补格：清包必须在生成下游动作之前用 ship_produce 卖 Copper Bar 完成并读背包验证，验证失败就物理删除 mine/upgrade 分支。
- take 在农场箱子内容与记忆不符时连续 12 次空跑（'62' is not in any farm chest / already failed; not retrying today）：take 应全天物理删除，需要矿物只能下矿现拿。
- 秋 28 是季末最后一天，任何新种的作物明天都会枯死：季末不买也不种作物种子，只做下矿/炼锭/升级这类跨季有效的推进。
- 节日日 goto_location 失败后脚本仍继续生成 festival start 和 donate 分支，导致 23 个失败动作：任一 goto 因节日失败，立即重写脚本删除所有依赖该地图的分支，而不是继续按原计划执行。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 28）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64763g 早已够，唯一卡点是 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器都排在它后面。

离完成还差：4 铁锭 = 约 20 铁矿石 + 4 煤。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票，必须在脚本生成阶段校验，不能边下边补**。

接下来 3 天主活动：
- **今天（秋 28，季末最后一天）**：起床 collect→**清包（卖 Copper Bar 留 20，这是唯一真正腾格的手段）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <13:00 升 hoe。今天不种任何新作物（明天全枯）。
- **明天（夏/冬第 1 天，换季）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **节日日识别**：出现「festival is being set up」或 Town 不可达 → 当天**永久删除**所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。今天秋 28 不是节日日，但脚本生成时先检查一次 Town 是否可达。
2. **清包唯一有效手段 = 卖 Copper Bar 留 20**：昨天 85 个 Copper Bar 一个没卖，空格仍 2。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
3. **先读后卖**：每次 ship 前读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
4. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
5. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
6. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **季末不买种子**：秋 28 不买任何作物种子（明天全枯）；只买冬季种子/茶苗留到换季日。
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
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
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
9. 季末不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天是秋27节日日，Town 全天被 Spirit's Eve 布置封锁，导致去博物馆/铁匠铺/节日全部不可达；同时背包只剩 2 格，清包没做（Copper Bar 85 个一个没卖），mine 和 upgrade 都被「have 2, need 5」拒绝，12 次 take 空跑。核心问题是：节日日没识别、清包没执行、背包门票没满足就生成下游动作。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 08:00 动作 `goto_location` 失败 @ Farm — no reachable route from Mountain to ArchaeologyHouse (unreachable exits: busstop->town, forest->town, mountain->town) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set up. Come  〔自动〕
- 10:40 动作 `donate_museum` 失败 @ Mountain — no reachable route from Farm to ArchaeologyHouse (unreachable exits: mountain->town, backwoods->busstop, farm->busstop, farm->forest) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 12:30 动作 `mine` 失败 @ Mine — store did not free enough slots (have 2, need 5) 〔自动〕
- 13:30 动作 `mine` 失败 @ Farm — store did not free enough slots (have 2, need 5) 〔自动〕
- 13:30 动作 `goto_location` 失败 @ Farm — no reachable route from Mountain to Blacksmith (unreachable exits: busstop->town, forest->town, mountain->town) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [dialogue] Today's festival is being set up. Come back l 〔自动〕
- 16:30 动作 `upgrade_tool` 失败 @ Mountain — store did not free enough slots (have 2, need 5) 〔自动〕
- 17:20 动作 `goto_location` 失败 @ Farm — exit to Town did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | Today's festival is being set up. Come back later. | 游戏消息: [dialogue] Today's festival is being set up. Come back later. 〔自动〕
- 17:30 动作 `festival` 失败 @ BusStop — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 18:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 18:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 节日日 Town 全天封锁，去博物馆/铁匠铺/节日全部不可达，计划里的升级和节日都没做成 @ Town / Mountain / Farm 出口 — no reachable route ... (unreachable exits: busstop->town, forest->town, mountain->town) | 游戏消息: Today's festival is being set up. Come back later.（做不了：钢锄头升级、博物馆捐赠、Spirit's Eve 节日全部当天无法进行） 〔复盘〕
- 背包只剩 2 格，清包没执行（85 个 Copper Bar 一个没卖），下矿和升级都被空格门槛拒绝 @ Farm — mine: store did not free enough slots (have 2, need 5)；upgrade_tool: store did not free enough slots (have 2, need 5)（做不了：下矿刷铁矿、铁匠铺升级 hoe 全部做不成，铁锭链继续卡在 1/5） 〔复盘〕
- 连续 12 次 take 农场箱子里的宝石全部失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作和时间，箱子内容与记忆不符导致后续计划全乱） 〔复盘〕
- store_items 想存 Stone/Squid Ink 等腾格，但箱子不可达或没东西可存，空格始终没腾出来 @ Farm 箱子 (74,15) — stored in chest: 4x Green Algae 后 nothing to store，背包仍 2 格（做不了：清包失败直接导致 mine/upgrade 被拒） 〔复盘〕
- 熔炉在 18:10 后 load Iron Ore 报无空炉可接受，collect 又报无成品，机器空转 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests；no machine has finished output（做不了：铁锭产出停滞，钢锄头材料凑不齐） 〔复盘〕
- 秋 27 是节日日但脚本仍按普通日生成计划（下矿→升级→节日），没有识别节日封锁 @ 脚本规划阶段 — 脚本重写 3 次，23 个失败动作，有效动作仅 17 个（做不了：整天的计划基本作废，里程碑零推进） 〔复盘〕
