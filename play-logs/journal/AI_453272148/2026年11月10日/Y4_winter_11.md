# 第4年 winter 11 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（09:06 开始）
- 天气：sunny　金钱：54039g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_winter_11）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升 Steel Hoe
- 起床先收熔炉成品，再 load 铁矿石一次（busy 即当天跳过）
- 清背包到空格≥10（store_items 自选可达箱子，不足则 ship_produce）
- Forest 钓鱼补食物到≥5
- 电梯直达 75 层下矿拿铁矿石+煤，≤2 次
- 回农场收铁锭，铁锭≥5 且 <15:30 去铁匠铺升 hoe
- 14:00 后顺路买 Claymore 提升下矿安全
- 体力不足或 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Farm"）
5. `store_items`（items=["Stone", "Copper Ore", "Geode", "Cobblestone Path", "Amethyst"]）
6. `ship_produce`（except=["Pike", "Iron Ore", "Coal"]）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `store_items`（items=["Stone", "Copper Ore", "Geode"]）
12. `mine`（floors=5）
13. `goto_location`（location="Farm"）
14. `collect_machines`
15. `load_machines`（item="Iron Ore"）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="AdventureGuild"）
19. `buy_weapon`
20. `goto_location`（location="Farm"）
21. `water_crops`
22. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：93f4978a49b94c74ac3ca7ef310e08c9
  - 耗时：20.843 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：4276f5603748401c920ca36f148b63cd
  - 耗时：3.875 秒 / 游戏 10 分钟
- **06:30** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：1b2c44080a6346a4af7f2305330c29ce
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：d964a1c2e23443b582a5943db1126847
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~700g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：13ca3fa8e97a45df9069150ddfb9ce11
  - 耗时：17.407 秒 / 游戏 20 分钟
- **06:50** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：9fe74efcd60d4029a9b5ae60923fdee2
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：4fc0ea0cb69c4d5f88435b4f0ac869ff
  - 耗时：0.422 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：7cde70543dcf43c9901b71b59862c5f6
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：e162652691a7457c91c46277ed57c0d7
  - 耗时：21.625 秒 / 游戏 30 分钟
- **07:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Pike, Pike, Perch)
  - 执行状态：SUCCESS · 操作编号：549f38015c7046259b4440014bcb69d6
  - 耗时：89.156 秒 / 游戏 80 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
- **08:40** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：51b2863aca9e47ab8e6ccd4bc0b7afd7
  - 耗时：73.297 秒 / 游戏 90 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：968ba618f60d44189df59dd89ad9f047
  - 耗时：0.391 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：下矿因空格不足失败，改为回农场存材料收熔炉，铁锭够则升hoe，剩余时间钓鱼补收入后睡觉。
1. `donate`
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="hoe"）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Copper Ore", "Geode", "Cobblestone Path", "Copper Bar"]）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `water_crops`
12. `sleep`
- **10:10** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：4ce76e32c80b4e96906bb7def77dc9df
  - 耗时：0.375 秒 / 游戏 0 分钟
- **10:10** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：d0327062b0b74c9182ded76138680391
  - 耗时：48.734 秒 / 游戏 60 分钟
- **11:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：da587a5ba8504083bea961632a7cb13f
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：升级失败因铁锭为0，回农场收炉并load铁矿石推进炼锭，清背包后收尾睡觉。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `store_items`（items=["Stone", "Copper Ore", "Geode", "Cobblestone Path", "Copper Bar"]）
7. `collect_machines`
8. `water_crops`
9. `sleep`
- **11:10** Blacksmith ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：a09a7a5efaf542cbb948aacca73833f1
  - 耗时：0.344 秒 / 游戏 0 分钟
- **11:10** Blacksmith ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：e5080e32a6f4426db0ac69b3e9481fab
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：下矿因空格不足被拒，先回农场收熔炉、存材料腾格，再浇水睡觉，不再重试mine。
1. `donate`
2. `mine`（floors=5）
3. `goto_location`（location="Farm"）
4. `collect_machines`
5. `load_machines`（item="Iron Ore"）
6. `store_items`（items=["Stone", "Copper Ore", "Geode", "Cobblestone Path", "Copper Bar"]）
7. `collect_machines`
8. `water_crops`
9. `sleep`
- **11:10** Blacksmith ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：6de9efe7499d43c2a88dc81d0fdaca93
  - 耗时：0.391 秒 / 游戏 0 分钟
- **11:10** Blacksmith ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f8ebc55f5bdd43a291e97bef38be96aa
  - 耗时：0.344 秒 / 游戏 0 分钟
- **11:10** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：55574867202f4d28971256bebf20ed8f
  - 耗时：38.985 秒 / 游戏 50 分钟
- **12:00** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：4c232b4715ac41c79a3625a310fa22e2
  - 耗时：17.687 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **12:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6b8c02cc57c9470ea240054a389d5b3d
  - 耗时：0.359 秒 / 游戏 0 分钟
- **12:20** Farm ✅ `store_items`（items=["Stone", "Copper Ore", "Geode", "Cobblestone Path", "Copper Bar"]）
  - 结果：stored in chest at (74,15): 5x Copper Bar, 3x Geode
  - 执行状态：SUCCESS · 操作编号：b2ae9da46c1648bcb63c8dfe0288bb40
  - 耗时：18.469 秒 / 游戏 30 分钟
- **12:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：27a48451c5de4156b521dd7e84996800
  - 耗时：0.36 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：70323026c52c41e5ac40a4ef18afd724
  - 耗时：0.39 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：7422c5fb245f4f1a926d1d19d3df58da
  - 耗时：19.187 秒 / 游戏 20 分钟
- **13:10** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：00b94daeb23c419786febbc341e19970
  - 耗时：3.656 秒 / 游戏 10 分钟
- **13:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：5406d8a805f5476e8e1c7e989d6a2105
  - 耗时：0.391 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：ae072977fbd84224bf02ca3b0b82381c
  - 耗时：0.343 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 35 to 39 (4 floors down, 47 stones broken); stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：5ce87d46d5c2470fbbb2d6d7f6134042
  - 耗时：73.765 秒 / 游戏 90 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Topaz
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
- **14:50** UndergroundMine39 ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：a2060e20cb854c5a9d16524355fe727b
  - 耗时：47.656 秒 / 游戏 60 分钟
  - 🗨️ [question] 
  - 🗨️ [hud] Copper Bar
- **15:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：e33cf28710ed4110b09d001e12a4a3be
  - 耗时：7.359 秒 / 游戏 10 分钟
- **16:00** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：453ce39b295b4ceea9e8c3ebe544b9e0
  - 耗时：0.391 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：bd6c3fe8050a44118b74a66c7011475c
  - 耗时：8.516 秒 / 游戏 10 分钟
- **16:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:10** Farm ✅ `wait`（minutes=10, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:20 pm
  - 执行状态：SUCCESS · 操作编号：508a0991f2904ef0af0797baa594cf4f
  - 耗时：6.562 秒 / 游戏 10 分钟
- **16:20** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：7fb80c86a41a412e85b92143e068d0ac
  - 耗时：12.735 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **16:30** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：ccd8e05c1f764cb7adfac61ea6ceebec
  - 耗时：3.656 秒 / 游戏 10 分钟
- **16:40** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7de6fa677a2d4c4cad1caa02561d8cf4
  - 耗时：0.359 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：f556b84c78584ba5a4ee6175a7f30204
  - 耗时：14.64 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：54039 → 54739（+700g）
- 出货估值：700g　动作：40 个　失败：13 个
- 模型调用：5 次　tokens：63885
- 有效动作率：0.5789　空转：12　熔断跳过：0
- 失败耗时：13.752 秒 / 游戏 10 分钟
- 最深矿层：79　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天唯一有效产出是 Forest 钓鱼 4 条和熔炉收铜锭；13 次失败集中在三处：熔炉 load 在 busy 时反复调、背包清不出空格导致 mine 全被拒、升级前没确认铁锭。根因是脚本生成阶段没读背包空格/熔炉状态/食物数就排分支。今天先解决背包通道与食物，再让熔炉只走「收→炼」单次循环，铁锭够了立刻升 hoe。

**新教训：**
- 昨天两次 mine 都从 35 层爬而不是电梯直达 75 层，铁矿密度低导致铁矿石只拿到少量：下矿前应显式指定电梯到 75 层，从 75→79 层推进，而不是从当前最深 79 层往下爬。
- 熔炉两炉都在炼时 load 返回 busy，之后又调 load 被拒，铁锭全天零新增：起床 collect 为空说明炉还在炼，当天 load 应直接跳过，等第二天炉空再 load，不要在同一天反复调。
- 昨天 13 次失败中 3 次是 mine 因空格 <5 被拒，而脚本重写 3 次仍重跑 mine：脚本生成阶段必须先读 /state 的背包空格，空格 <10 时物理删除 mine 分支，而不是运行时反复被拒。
- 昨天唯一有效产出是 Forest 钓鱼 4 条和熔炉收铜锭：主活动被卡时应在 1 个动作内转 Forest 钓鱼，而不是重写脚本重试失败动作。
- 昨天 build_road、decorate、wait 各失败 1 次共浪费 3 个动作预算：这三类动作在农场地面被占满时永远 0 产出，应从脚本彻底删除，把动作留给钓鱼和下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 12）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 54039g 充足，Iron Bar 0（差 5），铁矿石 5、煤 23、铜锭 44。**「让两座熔炉持续出铁锭 + 拿到 40 层以下铁矿」是唯一主线**，洒水器、下矿装备都排在它之后。

离完成还差：约 15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 12）**：起床收炉 → 清背包通道（先解决可达箱子）→ 补食物到 ≥5 → 电梯直达 75 层下矿拿铁矿石+煤 → 回农场炼铁 → 铁锭 ≥5 且 <15:30 升 hoe。
- **明天（冬 13）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续补铁锭；同时 craft 洒水器落地。
- **后天（冬 14）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **熔炉单次循环**：起床 collect 1 次；有成品收走 → 立刻 load 铁矿石 1 次（仅当铁矿石 ≥5 且 <12:00）；load 返回 busy/no empty 即当天永久跳过 load，**绝不连续调**。下矿回来再 collect 1 次收铁锭。
2. **清背包先修通道**：昨天 (74,15) 箱子与 (70,15) 出货箱都不可达。今天**先 goto Farm 入口附近**，store_items **不指定坐标**让动作自选最近可达箱子；返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外）；两手段后仍不足空格 10 → 当天定性钓鱼日，物理删除 mine 分支。
3. **下矿食物门槛 ≥5**：39 层因只有 4 个回血食物被拦。下矿前食物必须 ≥5，不够先在 Forest 钓 1 轮（≤4 cast）补鱼当食物，再下矿。
4. **下矿用电梯直达 75 层**：昨天两次 mine 都从 35 层爬，铁矿密度低。今天 goto Mine 后**电梯直达 75 层**，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。
5. **动作预算清理**：build_road、decorate、wait 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床：collect_machines 1 次**。返回空即当天永久跳过 collect（下矿回来再试一次）。
2. **load 铁矿石 1 次**（仅当铁矿石 ≥5 且时间 <12:00）。返回 busy/no empty 即当天永久跳过 load。
3. **清背包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ 读背包验证；不足则 ship_produce 卖低价值物 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine 分支。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **买武器 Claymore（仅当现金 ≥2000 且时间 14:00-21:30 且顺路）**：goto Adventurer's Guild → buy Claymore。失败一次即当天永久跳过。禁止 14:00 前专门 goto 公会等开门。
10. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
11. **浇水**：水壶在背包则 water_crops 1 次；返回「no watering can」或 0 crops 跳过。
12. 体力 <15 或时间 ≥22:00 sleep；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **熔炉时序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。**不连续调 load。**
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。**电梯直达 75 层不受食物 <5 限制，但 40 层以下仍需 ≥5。**
- **武器优先于下矿**：Silver Saber 8-15 在 80 层以下被拒，今天必须先买 Claymore（2000g）再下矿；买武器失败则当天只下 75-79 层。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **禁止专门等商店开门**：14:00 前不 goto Adventurer's Guild；等待时间用于钓鱼或下矿，14:00 后顺路买。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。**could not reach 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、water_crops≤1、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。**电梯直达 75 层例外。**
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床：collect_machines 1 次（收熔炉成品）
2. load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
3. **清背包到空格 ≥10**（store_items 不指定坐标 + 读背包验证；不足则 ship_produce）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数；could not reach 即跳过）
9. **买武器 Claymore**（现金 ≥2000、时间 14:00-21:30、顺路；失败即跳过）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 浇水（水壶在背包时）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天唯一有效产出是 Forest 钓鱼 4 条和熔炉收铜锭；13 次失败集中在三处：熔炉 load 在 busy 时反复调、背包清不出空格导致 mine 全被拒、升级前没确认铁锭。根因是脚本生成阶段没读背包空格/熔炉状态/食物数就排分支。今天先解决背包通道与食物，再让熔炉只走「收→炼」单次循环，铁锭够了立刻升 hoe。
- 06:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:10 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests) 〔自动〕
- 11:10 动作 `mine` 失败 @ Blacksmith — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:10 动作 `mine` 失败 @ Blacksmith — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 12:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 熔炉时序错乱：起床 collect 返回空，再 load 又 busy，之后又调 load 被拒，铁锭全天零新增 @ Farm 熔炉 — collect_machines -> FAIL: no machine has finished output；load_machines -> FAIL: no empty machine accepts that, and the rest are busy（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住，主线零推进） 〔复盘〕
- 清背包通道被挡：store_items 到 (74,15) 箱子与 ship_produce 到 (70,15) 出货箱都不可达 @ Farm 箱子/出货箱 — store_items -> could not reach；ship_produce -> could not reach (70,15); stopped at (53,8)（做不了：背包清不出空格，连锁导致下矿全被拒） 〔复盘〕
- 下矿到 39 层因食物不足被拦，无法下 40 层以下拿铁矿 @ UndergroundMine 39 层 — mine -> stopped at floor 39: only 4 healing food (need 5+ for floor 40 and below)（共 3 次 mine 都停在同一层）（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 升级工具在 Iron Bar=0 时仍被调用，白跑一趟铁匠铺 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)（做不了：浪费下午时段，且升级没完成） 〔复盘〕
- 铺路与装饰连续失败，浪费动作预算 @ Farm — build_road -> laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)；decorate -> 今天没有能做的装饰（做不了：农场通道没清出来，箱子/出货箱路径仍被挡） 〔复盘〕
- 下矿次数被浪费：两次 mine 都从 35 层爬到 39 层就停，没有用电梯直达 75 层 @ Mine 35-39 层 — mine -> mined from floor 35 to 39 (4 floors down)；第二次 mine -> mined from floor 39 to 39 (0 floors down)（做不了：铁矿密度低，铁矿石只拿到少量，铁锭仍不够） 〔复盘〕
