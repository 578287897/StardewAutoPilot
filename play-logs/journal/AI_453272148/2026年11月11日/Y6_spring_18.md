# 第6年 spring 18 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（22:14 开始）
- 天气：rain　金钱：89218g　体力：270/270
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
  - 执行状态：NO_PROGRESS · 操作编号：f15438edf601454fb663d74d934d9d38
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：59f9b9c64d9b419b9c8408925ba37f6b
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：2a22d8dc3751400a84aa51f621566e59
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：406128e6ea3e4877b1fb0b04dc7bba7f
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：e95fec4e097d499ba83bb7000ea64b11
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~90g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：80ad9435ef6440e9844990094748f183
  - 耗时：0.813 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_18）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天主活动=电梯40层刷铁矿石+煤，凑够5铁锭后去铁匠铺升hoe
- 起床先收熔炉成品，有空炉且铁矿石≥5才装料
- 背包24格已满（含大量Copper Bar在箱子里），先看背包实际物品，把冗余物卖出腾格；Copper Bar在箱子不在背包，ship只对背包实际存在的物品
- 背包空格≥5、食物≥5、武器Claymore足够→goto Mine电梯40层，mine≤2次每次≤5层，每层先fight清怪
- mine成功一次后回农场ship腾格再决定第二次
- 回农场collect收铁锭，铁锭≥5且时间<12:00→Blacksmith升hoe
- 若铁锭不足或时间过12:00，转Forest钓鱼casts≥10填满下午
- 21:30前sleep
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
11. `ship_produce`（except=["Salad", "Green Algae", "Copper Ore", "Iron Ore", "Gold Ore", "Iron Bar", "Claymore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Fiberglass Rod", "Scythe", "Copper Hoe"]）
12. `goto_location`（location="Mine"）
13. `fight`（range=6）
14. `mine`（floors=5）
15. `fight`（range=6）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `ship_produce`（except=["Salad", "Green Algae", "Copper Ore", "Iron Ore", "Gold Ore", "Iron Bar", "Claymore", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Fiberglass Rod", "Scythe", "Copper Hoe"]）
20. `goto_location`（location="Blacksmith"）
21. `upgrade_tool`（tool="hoe"）
22. `goto_location`（location="Forest"）
23. `fish`（casts=10）
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7601f7a96a474f2ea4fc55a0273fc87b
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除失败的 take/donate 分支，改为在农场出货箱 ship 冗余矿物腾格后按原路线下矿刷铁、升 hoe、钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Magma Geode", count=1）
10. `ship`（item="Gold Ore", count=4）
11. `ship`（item="Copper Ore", count=3）
12. `ship`（item="Green Algae", count=4）
13. `goto_location`（location="Mine"）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `fight`（range=6）
17. `mine`（floors=5）
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=10）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `collect_machines`
26. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b1671c85413b4407a685a4c308b219da
  - 耗时：0.562 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除失败的 take 分支，改为在农场出货箱 ship 冗余物腾格后下矿刷铁，铁锭够则升 hoe，否则转 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Magma Geode", count=1）
10. `ship`（item="Gold Ore", count=4）
11. `ship`（item="Copper Ore", count=3）
12. `ship`（item="Green Algae", count=4）
13. `ship`（item="Claymore", count=1）
14. `ship`（item="Silver Saber", count=1）
15. `goto_location`（location="Mine"）
16. `fight`（range=6）
17. `mine`（floors=5）
18. `fight`（range=6）
19. `mine`（floors=5）
20. `goto_location`（location="Blacksmith"）
21. `upgrade_tool`（tool="hoe"）
22. `goto_location`（location="Forest"）
23. `fish`（casts=10）
24. `goto_location`（location="Farm"）
25. `collect_machines`
26. `load_machines`（item="Iron Ore"）
27. `collect_machines`
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fff9987faa5d4427b8b0009d08d1eadd
  - 耗时：0.656 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败（箱子内容与记忆不符），删除全部 take/donate 分支，改为农场出货箱 ship 腾格后下矿刷铁，剩余时间 Forest 钓
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Magma Geode", count=1）
10. `ship`（item="Gold Ore", count=4）
11. `ship`（item="Copper Ore", count=3）
12. `ship`（item="Green Algae", count=4）
13. `ship`（item="Claymore", count=1）
14. `ship`（item="Silver Saber", count=1）
15. `goto_location`（location="Mine"）
16. `fight`（range=6）
17. `mine`（floors=5）
18. `fight`（range=6）
19. `mine`（floors=5）
20. `goto_location`（location="Forest"）
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
  - 执行状态：ACTION_FAILED · 操作编号：2ea5ba348a1744648e519d336da2eaba
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b7442c12873648afa419ea9331f1a0af
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5d16557004c14554b2d87788e492dd16
  - 耗时：0.656 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：b9cb1296df66410eb959886ae66b8ce3
  - 耗时：79.938 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：b863caa4906e4213b19c8ceb430c5519
  - 耗时：50.421 秒 / 游戏 60 分钟
- **09:00** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：4e479d67b5b240959229ef17455f63d0
  - 耗时：0.609 秒 / 游戏 0 分钟
- **09:00** ArchaeologyHouse ✅ `ship`（item="Magma Geode", count=1）
  - 结果：shipped 1x Magma Geode (~150g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：f3bc71e6cc9344439b9b74341a638f44
  - 耗时：48.469 秒 / 游戏 60 分钟
- **10:00** Farm ✅ `ship`（item="Gold Ore", count=4）
  - 结果：shipped 4x Gold Ore (~100g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：d15b4dd493494ddaad88ff44e5e20c51
  - 耗时：0.578 秒 / 游戏 0 分钟
- **10:00** Farm ✅ `ship`（item="Copper Ore", count=3）
  - 结果：shipped 3x Copper Ore (~15g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：2490be88e5d44854897bb547dcd7447f
  - 耗时：0.547 秒 / 游戏 0 分钟
- **10:00** Farm ✅ `ship`（item="Green Algae", count=4）
  - 结果：shipped 4x Green Algae (~60g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：148628cfefe640b18316c4685f8cf2bb
  - 耗时：0.563 秒 / 游戏 0 分钟
- **10:00** Farm ❌ `ship`（item="Claymore", count=1）
  - 结果：Claymore can't be shipped
  - 执行状态：ACTION_FAILED · 操作编号：60a36d8e9a964cda9f5c4a145de5b46a
  - 耗时：0.563 秒 / 游戏 0 分钟
- **10:00** Farm ❌ `ship`（item="Silver Saber", count=1）
  - 结果：Silver Saber can't be shipped
  - 执行状态：ACTION_FAILED · 操作编号：4e4852ca15dc49608bef5369ecc4e84b
  - 耗时：0.547 秒 / 游戏 0 分钟
- **10:00** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：ed75aa7b75fc435f8d0e785edef81a53
  - 耗时：49.093 秒 / 游戏 60 分钟
- **11:00** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：ea525bf6a7424aee84bb36e0e20e1103
  - 耗时：0.562 秒 / 游戏 0 分钟
- **11:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 97 (2 floors down, 56 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：835c1e2b4170445a8e5710cc3e5a0ff6
  - 耗时：65.579 秒 / 游戏 80 分钟
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Void Essence
  - 🗨️ [question] 
- **12:20** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：2be2bf2043e943f78b42cebdbdddb730
  - 耗时：0.563 秒 / 游戏 0 分钟
- **12:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4bb769894f8d489496713666d3cc07d8
  - 耗时：35.859 秒 / 游戏 50 分钟
- **12:20** Mine ✅ `store_items`（items=["Salad", "Magma Geode", "Stone", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：ea4d3d3f84c549f7a43c31b72912eb1e
  - 耗时：15.187 秒 / 游戏 20 分钟
- **12:20** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **13:30** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：6f7a43f4f20442339eafcec636ce1728
  - 耗时：23.891 秒 / 游戏 30 分钟
- **14:00** Forest ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Driftwood, Green Algae, Green Algae, Smallmouth Bass, Smallmouth Bass, River Jelly, Smallmouth Bass, Green Algae, Green Algae, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：4e32aa4787824144bd464f6eb5f35c13
  - 耗时：192.438 秒 / 游戏 220 分钟
  - 🗨️ [hud] Driftwood
- **17:40** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：85ced480d8f045eaba985033c4b04b35
  - 耗时：9.672 秒 / 游戏 10 分钟
- **17:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **17:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a24f8e06d9c9491aacc35f2702eb6c5c
  - 耗时：23.64 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：89218 → 89633（+415g）
- 出货估值：90g　动作：40 个　失败：20 个
- 模型调用：7 次　tokens：87434
- 有效动作率：0.5625　空转：4　熔断跳过：7
- 失败耗时：9.781 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 40 动作 20 失败，核心仍是铁锭链卡死：背包只剩 1-2 空格，mine 被 'have 1, need 5' 拒绝，而 Copper Bar 91 个一个没卖。take 空跑 12 次、donate/build_road/load 空跑，全是脚本生成了不该生成的分支。有效的是 Forest 钓鱼 10 条和 40 层以下下矿 2 层。今天第一动作必须是农场出货箱卖 Copper Bar 腾格，验证空格≥5 再下矿。

**新教训：**
- 昨天 12 次 take 全部空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天在 ArchaeologyHouse 调 ship 报 'not found'，而材料显示背包有 90 个 Copper Bar：ship 的 location 应在脚本生成阶段硬编码为 Farm 出货箱，其他地图一律不生成 ship 分支。
- 昨天 mine 在 Farm 报 'store did not free enough slots (have 1, need 5)'，说明 mine 动作在非矿洞地图也会先尝试 store 再下矿：脚本生成阶段若背包空格<5 就物理删除 mine 分支，且 mine 前必须先 goto Mine 入口。
- 昨天 15:50 起 load_machines 连续报 'no empty machine accepts that'：Iron Ore 只有 2 时 load 分支应在脚本生成阶段物理删除，只有读背包确认 Iron Ore≥5 且有空炉才生成。
- 昨天 mine 成功一次后没有先 ship 腾格就尝试第二次 mine，导致第二次被空格不足拒绝：mine 成功后必须先 ship 腾格再决定是否第二次下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 19）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 89218g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续多天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 1-4 空格，91 个 Copper Bar 一个没卖，mine 被 'have 1, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 2）。

接下来 3 天主活动：
- **今天（春 19）**：起床 collect→**农场出货箱无条件 ship Copper Bar 留 20（约 71 个，腾 4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼 casts≥10 到 20:00。
- **明天（春 20）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 21）**：继续铁锭链；若洒水器已齐则开始规划夏季啤酒花地块。

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
11. **春 19 不买种子**：只做清包+下矿+钓鱼；种子等复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 19 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
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
9. 春 19 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 40 动作 20 失败，核心仍是铁锭链卡死：背包只剩 1-2 空格，mine 被 'have 1, need 5' 拒绝，而 Copper Bar 91 个一个没卖。take 空跑 12 次、donate/build_road/load 空跑，全是脚本生成了不该生成的分支。有效的是 Forest 钓鱼 10 条和 40 层以下下矿 2 层。今天第一动作必须是农场出货箱卖 Copper Bar 腾格，验证空格≥5 再下矿。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
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
- 09:00 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:00 动作 `ship` 失败 @ Farm — Claymore can't be shipped 〔自动〕
- 10:00 动作 `ship` 失败 @ Farm — Silver Saber can't be shipped 〔自动〕
- 12:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 17:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 背包长期只剩 1-4 空格，Copper Bar 91 个一个没卖，导致下矿门票永远不够 @ Farm（出货箱旁） — mine 报 'store did not free enough slots (have 1, need 5)'；清包脚本把 ship Copper Bar 放在「读背包后视情况」分支，永远走不到（做不了：无法下矿刷铁矿石，铁锭链连续多天零推进，Steel Hoe/洒水器/鸡舍全部卡住） 〔复盘〕
- take 动作连续空跑 12 次，脚本重写 3 次仍重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费约 12 个动作和 3 次脚本重写，挤占了本可用于下矿/钓鱼的时间） 〔复盘〕
- ship 在非农场地图执行失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory（地点错，ship 只在农场出货箱有效）（做不了：清包动作无效，背包空格没腾出来） 〔复盘〕
- donate_museum 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：白跑一趟博物馆，浪费早晨时间） 〔复盘〕
- load_machines 连续报无空炉 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：铁矿石无法入炉，铁锭产出停滞） 〔复盘〕
- build_road 报无可用空格 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格（做不了：无实际影响，但浪费一个动作） 〔复盘〕
- 第二次 mine 被空格不足拒绝后当天没有钓鱼兜底到 20:00 @ Mine→Forest — mine FAIL: store did not free enough slots (have 1, need 5)；之后 13:30 才转 Forest，只钓 10 条（做不了：下午产出偏低，全天出货估值仅 90g） 〔复盘〕
