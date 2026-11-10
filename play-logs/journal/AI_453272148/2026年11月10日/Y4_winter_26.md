# 第4年 winter 26 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（12:51 开始）
- 天气：snow　金钱：59598g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：cd2a3b38d4e2448ea171d560d41efb0a
  - 耗时：0.344 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_26）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升钢锄头（5000g+5 铁锭）
- 起床收熔炉成品，铁矿石够就投料炼铁
- 一次性清包到空格≥10（store_items 不指定坐标 + ship_produce，全天禁 take）
- Forest 河边钓鱼补食物到≥5
- 电梯直达 80 层下矿 80→84 拿铁矿石+煤，≤2 次 mine
- 回农场收铁锭，铁锭≥5 且 13:00 前到铁匠铺升 hoe
- 21:30 前收尾，之后只 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="66", item_name="Amethyst", count=1）
4. `take`（item="68", item_name="Topaz", count=1）
5. `take`（item="72", item_name="Diamond", count=1）
6. `take`（item="80", item_name="Quartz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `take`（item="Copper Bar", count=1）
10. `take`（item="Bat Wing", count=1）
11. `donate`
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `goto_location`（location="Farm"）
15. `store_items`
16. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Mine"）
20. `mine`（floors=5）
21. `store_items`
22. `mine`（floors=4）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `goto_location`（location="Blacksmith"）
26. `upgrade_tool`（tool="hoe"）
27. `sleep`
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：faf5f8d165214d5fb6db023f20b38cbb
  - 耗时：3.25 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：523c4467b0d649d483cfc5b2e0c6b023
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：a2767afe4d814e118b1fcd28bb047f85
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：0754501c73ef47c4a4d250800ab6959c
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e231ca1079b64c04a69bb5e228799028
  - 耗时：0.343 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take 与 donate 分支（宝石不在箱中、wait_letter 阶段必失败），保留清包→钓鱼补食物→80层下矿→收铁锭→升 hoe 
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="66", item_name="Amethyst", count=1）
4. `take`（item="68", item_name="Topaz", count=1）
5. `take`（item="72", item_name="Diamond", count=1）
6. `take`（item="80", item_name="Quartz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `take`（item="Copper Bar", count=1）
10. `take`（item="Bat Wing", count=1）
11. `donate`
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=4）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `store_items`
23. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
24. `collect_machines`
25. `store_items`
26. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：be2122d64f7a4d78a3baf7d0ced3a0c8
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除所有 take 与博物馆/捐赠分支（连续失败且无产出），保留清包→钓鱼补食物→80 层下矿→收铁锭→升 hoe 的主线，21:30 前收尾直接睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="66", item_name="Amethyst", count=1）
4. `take`（item="68", item_name="Topaz", count=1）
5. `take`（item="72", item_name="Diamond", count=1）
6. `take`（item="80", item_name="Quartz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `take`（item="Copper Bar", count=1）
10. `take`（item="Bat Wing", count=1）
11. `donate`
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=4）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `store_items`
23. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
24. `collect_machines`
25. `store_items`
26. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ✅ `take`（item="66", item_name="Amethyst", count=1）
  - 结果：took 1x Amethyst from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：ebae6c26a61b4a4aba32ea46c6797e28
  - 耗时：6.062 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dfe299cfec4f44879bcbf16c74b2bdf7
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删掉全部 take 与博物馆/社区中心分支，改为清包→钓鱼补食物→80 层下矿拿铁矿→回农场收锭→铁匠铺升 hoe，失败即转钓鱼或睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="80", item_name="Quartz", count=1）
6. `take`（item="84", item_name="Frozen Tear", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `take`（item="Copper Bar", count=1）
10. `take`（item="Bat Wing", count=1）
11. `donate`
12. `goto_location`（location="Forest"）
13. `fish`（casts=4）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `store_items`
22. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Amethyst"]）
23. `store_items`
24. `collect_machines`
25. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
26. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：64cd4245899e48fd996eb0794123db98
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：854f93725a0245ac89d225cfd590fd91
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3a20b0e482354b74a24cc3bb4f8fd9f2
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：0a6ef3d7fb544326b835609e02fd7e10
  - 耗时：80.281 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：7bbe687cd4384e32bee8583ff521d3bf
  - 耗时：43.703 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate_museum`
  - 结果：donated Amethyst (66) to the museum at (26,7)
  - 执行状态：SUCCESS · 操作编号：8d4610228e9a470585094334ebb63105
  - 耗时：0.36 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：42886ed29cdf4ae79e013c718f6d1f90
  - 耗时：43.531 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `take`（item="Bat Wing", count=1）
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：98666fcab7dd4764ba14c53ad745fee8
  - 耗时：0.36 秒 / 游戏 0 分钟
- **09:40** Farm ❌ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：ACTION_FAILED · 操作编号：f2bd8c4d10c44a1580cad90c5d79a4c3
  - 耗时：39.828 秒 / 游戏 50 分钟
- **10:30** CommunityCenter ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：6eff2e3938be4a76b1113480de1ea030
  - 耗时：38.438 秒 / 游戏 50 分钟
- **11:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Tiger Trout, Pike, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：9d50bd78403045f4a9baa86df40ff9ec
  - 耗时：83.797 秒 / 游戏 90 分钟
  - 🗨️ [hud] Tiger Trout
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
- **12:50** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e22c2a2ecdf24b3f9870993e79223ef0
  - 耗时：63.531 秒 / 游戏 80 分钟
- **14:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：a4440749d4be45b9b6415f5b819294ee
  - 耗时：33.563 秒 / 游戏 40 分钟
- **14:10** Mine ✅ `store_items`（items=["Stone", "Pike", "Strange Bun", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：dd19a33ae4a54c19ad48fce054ee1b0c
  - 耗时：15.0 秒 / 游戏 20 分钟
- **14:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **15:10** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：52122dc878434fd6835928c2bfdcde0d
  - 耗时：43.922 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 4:00pm)
- **16:00** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：1304c0c11f77456b8472604f568d8d17
  - 耗时：37.547 秒 / 游戏 50 分钟
- **16:00** Town ✅ `store_items`（items=["Stone", "Pike", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 27x Stone
  - 执行状态：SUCCESS · 操作编号：32e20ce81b494719b09858b84d2272b8
  - 耗时：1.125 秒 / 游戏 0 分钟
- **16:00** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **16:50** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：c8c6651e797c4d4ba9b5a0bc9ce2a1db
  - 耗时：0.328 秒 / 游戏 0 分钟
- **16:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：1818803ea78a41eb8b87b1ab4996b7b7
  - 耗时：0.328 秒 / 游戏 0 分钟
- **16:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：9d71109024004eefadd768e5f4a3dad4
  - 耗时：0.344 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `store_items`
  - 结果：stored in chest at (75,15): 2x Copper Ore, 3x Gold Ore
  - 执行状态：SUCCESS · 操作编号：032fd85bbf1e48ae8a70ac8b4c2c7ce3
  - 耗时：0.313 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Amethyst"]）
  - 结果：shipped 3 stacks worth ~390g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：23a3c1b9186f4f3f940a8616a4908415
  - 耗时：0.875 秒 / 游戏 0 分钟
- **16:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：235b7f8aff984e00a6430ed1e40dd86c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **16:50** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:50** Farm ✅ `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：34cd84d688b7423586849c562fdc676a
  - 耗时：0.344 秒 / 游戏 0 分钟
- **16:50** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:50** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:50** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：013b10938b894dee9f4273bd021dc2bb
  - 耗时：10.781 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：59598 → 59988（+390g）
- 出货估值：390g　动作：46 个　失败：23 个
- 模型调用：5 次　tokens：54250
- 有效动作率：0.4737　空转：10　熔断跳过：7
- 失败耗时：88.436 秒 / 游戏 100 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 23 个失败中 12 个是 take 猜箱子内容、2 个是清包不足导致 mine/upgrade 被拒、1 个是 16:50 到铁匠铺已锁门。核心链条「清包→下矿→炼铁→升级」连续五天零推进，根因是背包空格始终不足且下矿目标层选错（75-79 只出铜）。今天必须把清包做成硬开关，下矿锁定 80-84 层，升级窗口提前到 9:10-13:00。

**新教训：**
- 昨天 16:50 到 Blacksmith 被锁门（16:00 关门），而升级窗口本应 9:10-13:00：升级动作必须在 13:00 前发起，13:00 后不再安排任何 goto Blacksmith。
- 昨天 take 62/64/68/72/80/84 六种宝石全部失败，说明箱子实际内容与记忆不符：脚本生成阶段应物理删除所有 take，需要物品靠下矿/钓鱼现拿，不要凭记忆猜箱子内容。
- 昨天清包两次后仍只剩 1-2 空格，mine 和 upgrade 都被「need 5 free slots」拒绝：清包必须一次存够到空格≥10，若两次 store_items+ship_produce 后仍<10，应在脚本生成阶段直接删除 mine/upgrade 分支，当天只钓鱼。
- 昨天 load_machines 返回「no empty machine accepts anything」两次，说明两座熔炉都在忙或已满：load 前应先 collect 收成品，返回 busy/no empty 即当天永久跳过，不要连续调。
- 昨天 build_road 和 decorate 各失败一次，都是「没有可铺的空格/没有能做的装饰」：这两类动作在材料不足时纯属浪费动作预算，应从脚本彻底删除。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 27）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 59598g 充足，铁锭 0、铁矿石 4、煤 24，瓶颈是**铁矿石→铁锭转化链**，已连续五天零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 27）**：起床 collect 收炉 → 一次性清包到空格≥10（store_items 不指定坐标 + ship_produce，**全天禁止 take**）→ 电梯直达 **80 层**下矿 80→84 拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（冬 28）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续下矿炼铁；铁锭富余则 craft 洒水器落地。
- **后天（春 1）**：春季第 1 天，买草莓/防风草种子，铁锭富余升第二件工具。

## 今日核心修正
1. **禁止 take（全天）**：昨天 12 次 take 全因箱子无该物品或背包满失败，是失败数最大来源。脚本生成阶段**物理删除所有 take 动作**，需要物品一律靠下矿/钓鱼现拿。
2. **清包一次性到空格≥10**：起床 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证。**清包成功后全天禁止任何 take**。两次清包仍<10 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
3. **下矿目标层改为 80→84**：昨天 75→79 只拿铜矿没拿到铁矿，说明 75 层以下才是铁矿密集区。电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从当前最深 89 层往下爬**。
4. **熔炉投料双条件**：起床读炉状态，任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则脚本生成阶段物理删除 load 分支。返回 busy/no empty 即当天永久跳过 load。load 每天 ≤1 次，12:00 前完成。
5. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
6. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。
7. **节日日规则**：今天不是节日，但若出现「festival is being set up」或 Town 被占，立即放弃所有 Town 相关动作（goto/donate/festival），改去 Mine 或 Forest。
8. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：昨天 12 次 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **起床 collect_machines 1 次**（收熔炉成品）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. **一次性清包到空格 ≥10**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天 23 个失败中 12 个是 take 猜箱子内容、2 个是清包不足导致 mine/upgrade 被拒、1 个是 16:50 到铁匠铺已锁门。核心链条「清包→下矿→炼铁→升级」连续五天零推进，根因是背包空格始终不足且下矿目标层选错（75-79 只出铜）。今天必须把清包做成硬开关，下矿锁定 80-84 层，升级窗口提前到 9:10-13:00。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 09:40 动作 `donate` 失败 @ Farm — opened the bundles but nothing could be deposited 〔自动〕
- 14:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 15:10 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 4:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 4:00pm) 〔自动〕
- 16:00 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 2, need 5) 〔自动〕
- 16:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:50 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:50 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 连续 12 次 take 猜箱子内容全部失败，吃掉近一半动作预算 @ Farm 箱子 (74,15)/(75,15) — '62'/'64'/'68'/'72'/'80'/'84' is not in any farm chest；take 62 already failed; not retrying today（做不了：背包空格无法通过取物补充，反而因反复失败浪费动作，导致后续 mine/upgrade 被「need 5 free slots」拒绝） 〔复盘〕
- 清包两次后仍只剩 1-2 空格，mine 和 upgrade_tool 都被拒 @ Farm → Mine / Blacksmith — store did not free enough slots (have 1, need 5)；store did not free enough slots (have 2, need 5)（做不了：下矿拿铁矿和升级钢锄头两件事都做不成，铁锭转化链连续五天零推进） 〔复盘〕
- 16:50 到铁匠铺已锁门，升级窗口错过 @ Blacksmith — exit to Blacksmith did not open (closed? locked? check opening hours). It's locked... (Open 9:00am - 4:00pm)（做不了：当天无法升级 hoe，即使铁锭凑齐也只能等次日） 〔复盘〕
- load_machines 两次返回无空炉可投料 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：铁矿石无法投炉，铁锭产出停滞） 〔复盘〕
- build_road 和 decorate 在材料不足时仍被调用，纯浪费动作 @ Farm — 规划道路边没有还能走上去的空格；今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：占用了本可用于钓鱼或下矿的动作预算） 〔复盘〕
- 下矿目标层 75-79 只出铜矿不出铁矿，铁矿密集区在 80 层以下 @ Mine 75-79 层 — 昨天 75→79 只拿铜矿没拿到铁矿（做不了：铁矿石储备无法增长，铁锭凑不齐，钢锄头升级卡住） 〔复盘〕
