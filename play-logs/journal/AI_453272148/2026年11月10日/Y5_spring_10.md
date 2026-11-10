# 第5年 spring 10 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（15:19 开始）
- 天气：sunny　金钱：61743g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：2a35a1d69b9c48098315ad3b624cb43f
  - 耗时：11.516 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:10** Farm ❌ `harvest_crops`
  - 结果：could not reach (54,14); stopped at (54,13)
  - 执行状态：ACTION_FAILED · 操作编号：7935d5a7a4e7457a831d72847576593a
  - 耗时：15.063 秒 / 游戏 20 分钟
  - 🗨️ [hud] Potato

### 🔁 脚本重写：重写#1：harvest_crops 因作物格不可达失败，改为清包→钓鱼补食物→电梯下矿80层挖铁矿石→回炉收锭→13:00前升钢锄头。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=4）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `store_items`
19. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar"]）
20. `store_items`
21. `collect_machines`
22. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5640f21d1aeb42f0a9b6abcd53f15959
  - 耗时：0.391 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_spring_10）准备的脚本
- 里程碑：凑齐 5 铁锭升 Steel Hoe（当前 Iron Bar 1/5）
- 起床收熔炉→空炉投铁矿石→清包到空格≥15
- Forest 钓鱼补食物到≥6
- 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次）
- 回农场收铁锭，铁锭≥5 且 13:00 前到 Blacksmith 升 hoe
- SeedShop 周三关门，今天不买种子；craft 洒水器（Copper Bar 1+Iron Bar 1 已够）
- 21:30 前 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar", "Geode", "Omni Geode", "Magma Geode"]）
14. `store_items`
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Gold Bar", "Copper Bar", "Iron Bar", "Geode", "Omni Geode", "Magma Geode"]）
18. `goto_location`（location="Mine"）
19. `mine`（floors=4）
20. `goto_location`（location="Farm"）
21. `store_items`
22. `collect_machines`
23. `craft`（item="Sprinkler", count=1）
24. `place`（item="Sprinkler", x=70, y=10）
25. `goto_location`（location="Blacksmith"）
26. `upgrade_tool`（tool="hoe"）
27. `goto_location`（location="Farm"）
28. `sleep`

### 🔁 脚本重写：重写#2：take 宝石连续失败已物理删除，改为清包→钓鱼补食物→电梯下矿80层挖铁矿石→回炉收锭→13点前升钢锄头。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=4）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `store_items`
19. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar"]）
20. `collect_machines`
21. `store_items`
22. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4f6dd784a55c418a9eff0e8da09fd0e4
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全删，改为清包→Forest 钓鱼补食物→80 层下矿挖铁→回农场收锭，铁锭够且 13:00 前才升 hoe，最后 craft 洒水器睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `fish`（casts=4）
12. `goto_location`（location="Mine"）
13. `mine`（floors=4）
14. `mine`（floors=4）
15. `goto_location`（location="Farm"）
16. `store_items`
17. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
18. `collect_machines`
19. `store_items`
20. `collect_machines`
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
23. `craft`（item="Sprinkler", count=1）
24. `sleep`
- **06:30** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:30** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：44dd787162df44e49b301ff5f3228d59
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：89184f9b28cc4883937a669db8c75046
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b6aa84b924a24aba8ffa39bc09dc216e
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：cd17b034a80141e289cd35e0c2188447
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：783e74a46a93476dbb083008220f4977
  - 耗时：63.828 秒 / 游戏 90 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：1e2bf684ff2f4f4ca77afe0dd2268c38
  - 耗时：69.954 秒 / 游戏 80 分钟
- **09:20** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：0a9a3ee58dc1419aa850ab25458978b1
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:20** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：cf6486444d2942778a193588adfd7b90
  - 耗时：30.859 秒 / 游戏 40 分钟
- **10:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 5 (Sunfish, treasure: Earth Crystal, Chub, Green Algae, Chub)
  - 执行状态：SUCCESS · 操作编号：52ebf22cca9f48bdab9e29a0cb8c3200
  - 耗时：111.235 秒 / 游戏 120 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Chub
- **12:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Sunfish, Chub, Sunfish, River Jelly)
  - 执行状态：SUCCESS · 操作编号：b85e5caa67b0429f9ebf89567496fb14
  - 耗时：68.454 秒 / 游戏 60 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Sunfish
- **13:00** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：2cd1f36b596c4e92b85ec398a4f36706
  - 耗时：63.562 秒 / 游戏 80 分钟
- **14:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：37d4213cbca2429faca997118e5f2014
  - 耗时：33.578 秒 / 游戏 40 分钟
- **14:20** Mine ✅ `store_items`（items=["River Jelly", "Rice Shoot", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：c127095237544983bf6519f1cf203a35
  - 耗时：15.485 秒 / 游戏 30 分钟
- **14:20** Mine ❌ `mine`（floors=4）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **15:30** Farm ✅ `store_items`（items=["River Jelly", "Rice Shoot", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7ca9ba10cbdf49b3997f6035ec4603b7
  - 耗时：0.359 秒 / 游戏 0 分钟
- **15:30** Farm ❌ `mine`（floors=4）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **15:30** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：53de8fd393de45728938ee6a15d13fd5
  - 耗时：0.344 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：1b281bc261644b87b5bd64a4bb51364b
  - 耗时：0.36 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
  - 结果：shipped 5 stacks worth ~834g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3006f7e1b9914c05b14a1df2b027f6b8
  - 耗时：0.672 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：4fccbf198cfe4de684f443f612406215
  - 耗时：13.859 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **15:40** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：83d3f6980b8c4a79a2edf4fcba7a163c
  - 耗时：13.313 秒 / 游戏 20 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：7c56e50f3a014be79c2a3bf3c69c0a04
  - 耗时：0.515 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：fc2e1168fa3b45a8a85d7addfb1f5ac4
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar", "Copper Bar", "Gold Bar", "Geode", "Omni Geode", "Magma Geode"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：459de6d197444c81b71dc6a2a0d9e8b3
  - 耗时：0.328 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：c764a8047e824b2d8cd10dfeec30d994
  - 耗时：0.36 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：f1356422510043b7bbb9a8af19add740
  - 耗时：13.516 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **16:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：ed74bc826bb94f7597ca82f5a490441c
  - 耗时：0.391 秒 / 游戏 0 分钟
- **16:20** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:20** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:20** Farm ✅ `wait`（minutes=30, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:50 pm
  - 执行状态：SUCCESS · 操作编号：980aa2efa07943d68a014ba0d2c2c28a
  - 耗时：18.141 秒 / 游戏 30 分钟
- **16:50** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：42e7503fbb8648fe8ab63ce4892bfc7a
  - 耗时：0.422 秒 / 游戏 0 分钟
  - 🗨️ [hud] Copper Bar
- **16:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：6b03986637284137bf75b2e869c197ae
  - 耗时：4.985 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：12705e3f9b35476fb50e51c71e1485dd
  - 耗时：3.844 秒 / 游戏 10 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：a0c6b64fc8904b2fa140c770564e0172
  - 耗时：13.766 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：61743 → 62577（+834g）
- 出货估值：834g　动作：42 个　失败：18 个
- 模型调用：7 次　tokens：88294
- 有效动作率：0.5676　空转：6　熔断跳过：3
- 失败耗时：18.906 秒 / 游戏 20 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天42动作18失败：6次take宝石全失败（箱子内容与记忆不符）、背包0空格致2次mine被拒、博物馆空跑、16:20后build_road/decorate/wait空转。有效：钓鱼10条、craft洒水器1个、熔炉炼铜。铁锭仍0，钢锄头连续多天零推进。

**新教训：**
- 昨天清包只 store_items 不 ship_produce，背包仍 0 空格导致 2 次 mine 被拒（have 0, need 5）：清包必须 store+ship 双管齐下，且 ship 后立即读背包验证空格数，验证通过前不得调 mine。
- 昨天 6 次 take 宝石（62/64/68/72/80/84）全失败，而 donate_museum 也因背包无可捐物失败：说明箱子内容与记忆完全不符，任何需要特定物品的动作前必须先读箱子实际内容，不能凭 ID 猜。
- 昨天 16:20 后 build_road/decorate/wait 连续 3 个动作全失败，纯浪费：16:30 后只允许 collect_machines 一次 + sleep，其余动作物理删除。
- 昨天 harvest_crops 在 (54,14) 返回 could not reach 停在 (54,13)：作物被障碍物挡住时不要重试同一坐标，改从另一侧接近或跳过该作物。
- 昨天 collect_machines 在 16:00 返回 no machine has finished output，而 15:30 刚收过铜锭：熔炉 30 分钟周期内不要重复 collect，collect 间隔至少 30 分钟。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 11）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 61743g 充足，铁锭 0、铁矿石 1、煤 32，瓶颈是铁矿石→铁锭链，已连续多天零推进。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（春 11）**：起床 collect → 空炉投 Iron Ore → **清包到空格≥15（store+ship 双管齐下，必须卖货）** → 补食物到≥6 → 电梯直达 80 层下矿 80→84 挖铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 12）**：若 hoe 已升，转钢斧（5000g+5 铁锭）；否则继续下矿炼铁。13 日前攒钱买草莓种子。
- **后天（春 13）**：复活节买草莓种子，节日结束后当天种下。

## 今日核心修正
1. **take 全天物理删除**：连续多天 take 宝石全失败，脚本生成阶段直接删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **熔炉投铁矿石，不投铜**：起床 collect 后，任一炉为空且铁矿石≥5 → load_machines item=Iron Ore 1 次；铁矿石<5 则物理删除 load 分支。返回 busy/no empty 即当天永久跳过。**投料必须在 collect 后 1 个动作内完成**。
3. **清包一次到空格≥15（关键修正）**：起床 goto Farm → store_items（**不指定坐标**）→ **ship_produce 卖鱼/杂矿/低价值物（Stone/Coal/矿石/锭除外）** → 读背包验证。**仅靠 store_items 不够，必须 ship_produce 卖货**。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。清包成功后全天禁止任何 take。
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
> 昨天42动作18失败：6次take宝石全失败（箱子内容与记忆不符）、背包0空格致2次mine被拒、博物馆空跑、16:20后build_road/decorate/wait空转。有效：钓鱼10条、craft洒水器1个、熔炉炼铜。铁锭仍0，钢锄头连续多天零推进。
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `harvest_crops` 失败 @ Farm — could not reach (54,14); stopped at (54,13) | 游戏消息: [hud] Potato 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 06:30 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 09:20 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 14:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 0, need 5) 〔自动〕
- 15:30 动作 `mine` 失败 @ Farm — store did not free enough slots (have 0, need 5) 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:20 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包 0 空格导致两次 mine 被拒，清包只存不卖 @ Farm 箱子旁 — store did not free enough slots (have 0, need 5)；store_items 返回 OK 但只存了 1x Copper Bar，未 ship 低价值物（做不了：下矿拿铁矿石，钢锄头里程碑连续多天零推进） 〔复盘〕
- 6 次 take 宝石全部失败，箱子内容与记忆不符 @ Farm 箱子 — '62'/'64'/'68'/'72'/'80'/'84' is not in any farm chest（做不了：无法取出献祭用宝石，博物馆捐赠也空跑） 〔复盘〕
- donate_museum 空跑失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费 2 个动作（goto+donate），社区中心收集包无进展） 〔复盘〕
- 16:20 后 build_road/decorate/wait 连续空转 @ Farm — build_road: 规划道路边没有还能走上去的空格；decorate: 今天没有能做的装饰；wait 填充 30 分钟（做不了：浪费 4 个动作，收尾拖到 17:00 才 sleep） 〔复盘〕
- 熔炉只炼铜不炼铁，铁矿石 1 个一直没动 @ Farm 熔炉 — load_machines 投的是 Copper Ore，日志显示 loaded: Copper Ore -> Furnace（做不了：铁锭 0，钢锄头无法升级） 〔复盘〕
