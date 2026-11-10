# 第4年 winter 13 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（09:25 开始）
- 天气：sunny　金钱：55665g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：e25b1dc9132e4312ab90ca82ebbef73c
  - 耗时：11.5 秒 / 游戏 10 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：d059423d9e04425f875d6347fec91ca7
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：fd05f38e59184ab3a382f22587feb71c
  - 耗时：0.406 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_13）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——起床先读熔炉状态，空炉立即 load 铁矿石
- 清背包到空格 ≥10（store_items 不指定坐标，失败改 ship_produce）
- Forest 河边钓鱼补食物到 ≥5
- 电梯直达 75 层下矿 75→79 拿铁矿石+煤（空格≥10、食物≥5 才下）
- 回农场 collect 收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 14:00 后顺路买 Claymore（现金够且顺路）
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Farm"）
5. `store_items`
6. `ship_produce`（except=["Stone", "Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar"]）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `store_items`（items=["Stone", "Copper Ore", "Coal", "Iron Ore"]）
13. `collect_machines`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="AdventureGuild"）
17. `buy_weapon`
18. `goto_location`（location="Farm"）
19. `water_crops`
20. `sleep`
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~47g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：de983b8b107149ecb50983392c7c3830
  - 耗时：9.562 秒 / 游戏 10 分钟
- **06:20** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：07a27dc36aa64295a6d5b461dc3b3306
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：b58b2d5036314f85af7dbcb302cbee5c
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：da424cae55394bf1891ad04c31f442f4
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：66cae3c57af441228f8ce7bb762ff2f8
  - 耗时：21.641 秒 / 游戏 30 分钟
- **06:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Green Algae, Perch, Perch)
  - 执行状态：SUCCESS · 操作编号：2af1b5e2a2154f27993537da7fa7c720
  - 耗时：64.516 秒 / 游戏 70 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch

### 🔁 脚本重写：重写#1：先收炉+装铁矿，清包补食物后电梯下75层拿铁矿，回农场收铁锭够5锭即升hoe。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Blacksmith"）
9. `upgrade_tool`（tool="hoe"）
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `store_items`
14. `ship_produce`（except=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
15. `store_items`
16. `collect_machines`
17. `water_crops`
18. `sleep`

## 🌅 早上的计划（09:27 开始）
- 天气：sunny　金钱：55665g　体力：242/270
- 里程碑：钢锄头（5000g+5铁锭）——先收熔炉成品、装铁矿石，再下矿75层拿铁矿
- 清背包到空格≥10，食物补到≥5
- 回农场收铁锭，够5锭且时间允许则去铁匠铺升hoe

**执行脚本：**
1. `interact`（x=114, y=17）
2. `interact`（x=123, y=58）
3. `collect_machines`
4. `load_machines`
5. `donate`
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `leave_mine`
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `store_items`
18. `ship_produce`（except=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
19. `store_items`
20. `collect_machines`
21. `water_crops`
22. `sleep`
- **09:30** Mine ✅ `goto_location`（location="Mine", request_id="7766228efe9c467d8da7da37bc2f64e1"）
  - 💭 (查询先前动作的实际结果，不重放)
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：7766228efe9c467d8da7da37bc2f64e1
- **09:30** Mine ❌ `interact`（x=114, y=17）
  - 结果：no walkable path from (18,13) to next to (114,17) in Mine
  - 执行状态：ACTION_FAILED · 操作编号：887ad385ab314918aa34df7a351f7677
  - 耗时：0.422 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：矿洞内坐标不可达，改为回农场收炉/装炉/清背包，再电梯下矿75层拿铁矿，够锭则升hoe。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="hoe"）
7. `goto_location`（location="Farm"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `store_items`
11. `ship_produce`（except=["Stone", "Copper Ore", "Iron Ore", "Coal"]）
12. `collect_machines`
13. `store_items`
14. `water_crops`
15. `sleep`
- **09:30** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：619aee7ec75c49898695aa4375c21a7f
  - 耗时：0.359 秒 / 游戏 0 分钟
- **09:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 75 to 80 (5 floors down, 76 stones broken)
  - 执行状态：SUCCESS · 操作编号：ef3851f496794b1aafda6b64a1c9cf5d
  - 耗时：90.562 秒 / 游戏 120 分钟
  - 🗨️ [hud] Bat Wing
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bat Wing
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
- **11:30** UndergroundMine80 ✅ `mine`（floors=5）
  - 结果：mined from floor 80 to 81 (1 floors down, 4 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：881e7e57204e480381278481855dad87
  - 耗时：16.312 秒 / 游戏 20 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Solar Essence
  - 🗨️ [question] 
- **11:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：1e2762a13f46443690d28a0a1863e0b5
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：已出矿（leave_mine 报不在矿内属正常），背包仅1格，先回农场收熔炉、存材料腾格，铁锭够5且时间在16点前则升钢锄头，否则浇水后睡。
1. `donate`
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="hoe"）
4. `goto_location`（location="Farm"）
5. `collect_machines`
6. `store_items`
7. `ship_produce`（except=["Stone", "Copper Ore", "Iron Ore", "Coal", "Amethyst"]）
8. `collect_machines`
9. `store_items`
10. `water_crops`
11. `sleep`
- **11:50** Mine ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：c114b6335fa447f79726b1e3f302c2cb
  - 耗时：0.359 秒 / 游戏 0 分钟
- **11:50** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：3cda9f1dfd1c4e8284964ad92eb8a95e
  - 耗时：49.375 秒 / 游戏 60 分钟
- **12:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：976d5e7032be434b89ae24cc055d7662
  - 耗时：0.422 秒 / 游戏 0 分钟
- **12:50** Blacksmith ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：d83ab3a136fe4561bb912aba33426a2f
  - 耗时：40.656 秒 / 游戏 50 分钟
- **13:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：364e1892321e4579b4da3f0cf80c74b7
  - 耗时：12.047 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **13:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 3x Coal, 1x Amethyst, 2x Bat Wing, 1x Fiber, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：0b5e2116d6f94ede9e91dd1868e2d585
  - 耗时：13.297 秒 / 游戏 20 分钟
- **14:10** Farm ✅ `ship_produce`（except=["Stone", "Copper Ore", "Iron Ore", "Coal", "Amethyst"]）
  - 结果：shipped 2 stacks worth ~204g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3da71de840664847b09c4a295b7ae7e8
  - 耗时：0.734 秒 / 游戏 0 分钟
- **14:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c0405becf47c4f43965b31f793ed5cae
  - 耗时：0.359 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1dd636eaeef74951b5e6de2be7b154bd
  - 耗时：0.343 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：41451ed101ea480da4fa9014268b9a8e
  - 耗时：0.344 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：964b376043374b2998f59fd631e4259e
  - 耗时：13.891 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **14:30** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e885084c586549109ba8a015e603cae6
  - 耗时：0.375 秒 / 游戏 0 分钟
- **14:30** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：2704c75ab4bf492f83d192055f8ea584
  - 耗时：0.375 秒 / 游戏 0 分钟
- **14:30** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 35 to 39 (4 floors down, 12 stones broken); stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)
  - 执行状态：SUCCESS · 操作编号：081398813fa54df8806165c01b67638a
  - 耗时：60.031 秒 / 游戏 70 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Dwarf Scroll I
- **15:40** UndergroundMine39 ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：bb40ac7e472c443b92d6893da4f66898
  - 耗时：39.703 秒 / 游戏 50 分钟
  - 🗨️ [question] 
  - 🗨️ [hud] Copper Bar
- **16:30** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：95259bfb356940078bbbfc9b563f9db4
  - 耗时：4.953 秒 / 游戏 10 分钟
- **16:40** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：362ab0819c084b97b4a6ffca890fc5e8
  - 耗时：0.375 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `use_tool`（tool="axe", x=64, y=31, until_cleared=true）
  - 💭 (规划道路上的树 (64,31))
  - 结果：used axe 3x at (64,31), tile cleared
  - 执行状态：SUCCESS · 操作编号：ca3de286a6c3421db371a1f0d08e2cc8
  - 耗时：16.203 秒 / 游戏 20 分钟
- **17:00** Farm ✅ `use_tool`（tool="axe", x=64, y=32, until_cleared=true）
  - 💭 (规划道路上的树 (64,32))
  - 结果：used axe 15x at (64,32), tile cleared
  - 执行状态：SUCCESS · 操作编号：925fc0aedd90485c81d6fc6538471759
  - 耗时：3.453 秒 / 游戏 0 分钟
  - 🗨️ [hud] Sap
- **17:00** Farm ✅ `use_tool`（tool="axe", x=64, y=35, until_cleared=true）
  - 💭 (规划道路上的树 (64,35))
  - 结果：used axe 3x at (64,35), tile cleared
  - 执行状态：SUCCESS · 操作编号：b19d67449ac94ca6bc6157e7b15aff8f
  - 耗时：1.484 秒 / 游戏 0 分钟
- **17:00** Farm ✅ `use_tool`（tool="axe", x=64, y=36, until_cleared=true）
  - 💭 (规划道路上的树 (64,36))
  - 结果：used axe 15x at (64,36), tile cleared
  - 执行状态：SUCCESS · 操作编号：00583f6f7a1a4fe987fabb9dae933775
  - 耗时：3.5 秒 / 游戏 10 分钟
  - 🗨️ [hud] Sap
- **17:10** Farm ✅ `use_tool`（tool="axe", x=64, y=45, until_cleared=true）
  - 💭 (规划道路上的树 (64,45))
  - 结果：used axe 15x at (64,45), tile cleared
  - 执行状态：SUCCESS · 操作编号：ae72377706a0484daf5c08c017a7e669
  - 耗时：5.172 秒 / 游戏 10 分钟
  - 🗨️ [hud] Maple Seed
  - 🗨️ [hud] Sap
- **17:20** Farm ✅ `clear_debris`（x=65, y=31, max=4）
  - 💭 (规划道路上的杂物 (65,31))
  - 结果：cleared 0 debris within 8 tiles of (65,31); none of the 12 weed/stone/twig in Farm is reachable
  - 执行状态：SUCCESS · 操作编号：5b56077cf7be4754bc6006014b45ea18
  - 耗时：0.406 秒 / 游戏 0 分钟
- **17:20** Farm ✅ `use_tool`（tool="axe", x=65, y=36, until_cleared=true）
  - 💭 (规划道路上的树 (65,36))
  - 结果：used axe 3x at (65,36), tile cleared
  - 执行状态：SUCCESS · 操作编号：7824be0231d046e586e700abf7b2dd36
  - 耗时：2.5 秒 / 游戏 0 分钟
- **16:40** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3c7abaf958d041f5a326224d97d30ffd
  - 耗时：7.719 秒 / 游戏 10 分钟
- **17:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：00ec981e05bd430db3de236f1f650004
  - 耗时：12.641 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：55665 → 55916（+251g）
- 出货估值：204g　动作：32 个　失败：7 个
- 模型调用：3 次　tokens：37124
- 有效动作率：0.7419　空转：5　熔断跳过：0
- 失败耗时：10.36 秒 / 游戏 10 分钟
- 最深矿层：81　新增矿层：2
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天32动作7失败，主线（钢锄头）零推进：熔炉没炼铁（起床先collect空、再load busy），背包清不出空格导致下矿受限，两次mine从35层爬而非电梯直达75层，铁矿只拿到2个。唯一有效产出是砍树清路和收铜锭。核心问题：铁矿石来源和熔炉投料都没打通，铁锭永远为0。

**新教训：**
- 铁矿石<5 时 load_machines 会因无料可投而空转：load 前必须同时确认「炉空」和「铁矿石≥5」，缺一即跳过 load 先去下矿拿矿。
- 昨天两次 mine 从 35 层爬只拿到少量铁矿，而电梯直达 75 层才是铁矿密集区：下矿脚本必须显式写「电梯到 75 层，目标 75→79」，不要从当前最深 79 层往下爬。
- interact 到 (114,17) 返回 no walkable path：矿洞内交互点必须先用 goto_location 到该层再取坐标，不要用跨层坐标直接 interact。
- leave_mine 在已自动离开矿洞后调用返回 not in the mine：mine 返回「left the mine to recover」后当天不再调 leave_mine。
- build_road 返回「24 skipped: blocked by trees/crops/objects」说明农场地面被占满：铺路前必须先清出通道，否则永远 0 铺设，应彻底从脚本删除 build_road。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 14）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 55665g 充足，Iron Bar 0，铁矿石仅 2、煤 22、铜锭 46。**「让熔炉真正炼出铁锭」是唯一主线**：铁矿石→铁锭→升 hoe，洒水器、下矿装备都排在它之后。

离完成还差：约 15 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 14）**：起床读炉状态→空炉立即 load 铁矿石（铁矿石≥5 才 load，否则跳过）→清背包到空格≥10→补食物≥5→**电梯直达 75 层**拿铁矿石+煤（75→79 层）→回农场 collect 收铁锭→铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 15）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续炼铁；同时 craft 洒水器落地。
- **后天（冬 16）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余则升第二件工具。

## 今日核心修正
1. **熔炉投料是今天第一优先级**：起床先读炉状态。若任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则跳过 load，先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。**load 每天 ≤1 次，12:00 前完成。**
2. **清背包先修通道**：昨天 (74,15) 箱子与 (70,15) 出货箱都不可达。今天**先 goto Farm 入口附近**，store_items **不指定坐标**让动作自选最近可达箱子；返回 could not reach 立即改 ship_produce 卖低价值物（Stone 除外）；两手段后仍不足空格 10 → 当天定性钓鱼日，物理删除 mine 分支。
3. **下矿食物门槛 ≥5**：昨天 39 层因只有 3 个回血食物被拦。下矿前食物必须 ≥5，不够先在 Forest 钓 1 轮（≤4 cast）补鱼当食物，再下矿。
4. **下矿用电梯直达 75 层**：昨天两次 mine 都从 35 层爬，铁矿密度低。今天 goto Mine 后**电梯直达 75 层**，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。
5. **动作预算清理**：build_road、decorate、wait 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：若任一熔炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；返回 busy/no empty 即当天永久跳过 load。若两炉都在炼 → 跳过 load。
2. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
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
- **熔炉 load 优先于 collect**：起床先读炉状态，空炉且铁矿石≥5 立即 load；两炉都在炼才跳过 load。load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过。collect 固定放在下矿回来第一时间，每天 ≤1 次，返回空后当天永久跳过。**不连续调 load。**
- **清背包绝对优先于下矿**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
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
1. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过）
2. collect_machines 1 次（收熔炉成品）
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
> 昨天32动作7失败，主线（钢锄头）零推进：熔炉没炼铁（起床先collect空、再load busy），背包清不出空格导致下矿受限，两次mine从35层爬而非电梯直达75层，铁矿只拿到2个。唯一有效产出是砍树清路和收铜锭。核心问题：铁矿石来源和熔炉投料都没打通，铁锭永远为0。
- 09:30 动作 `interact` 失败 @ Mine — no walkable path from (18,13) to next to (114,17) in Mine 〔自动〕
- 11:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 12:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests) 〔自动〕
- 14:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 14:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 熔炉全天没有炼出铁锭（主线零推进） @ Farm 熔炉 — 起床 collect_machines -> FAIL: no machine has finished output；随后 load_machines -> FAIL: no empty machine accepts anything（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- 清背包通道被挡，下矿因空格不足受限 @ Farm 箱子/出货箱 → Mine — store_items 到 (74,15) 与 ship_produce 到 (70,15) 均 could not reach；mine 返回 backpack nearly full（做不了：背包清不出空格，连锁导致下矿拿不到足够铁矿石） 〔复盘〕
- 两次 mine 都从 35 层爬而不是电梯直达 75 层 @ Mine 35-39 层 — mine -> mined from floor 35 to 39 (4 floors down)；第二次 mine -> 0 floors down（做不了：铁矿密度低，铁矿石只拿到少量，铁锭仍不够） 〔复盘〕
- 下矿到 39 层因食物不足被拦，无法下 40 层以下拿铁矿 @ UndergroundMine 39 层 — mine -> stopped at floor 39: only 3 healing food (need 5+ for floor 40 and below)（做不了：拿不到 40 层以下铁矿，铁锭产出继续为零） 〔复盘〕
- 升级钢锄头时铁锭为 0 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)（做不了：工具升级里程碑停滞） 〔复盘〕
- 矿洞内 interact 目标不可达 @ Mine (18,13) → (114,17) — interact -> FAIL: no walkable path from (18,13) to next to (114,17) in Mine（做不了：浪费 1 个动作预算） 〔复盘〕
- 铺路 0 铺设 @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：道路规划无法推进） 〔复盘〕
