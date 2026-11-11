# 第6年 spring 6 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（19:49 开始）
- 天气：windy　金钱：85894g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：d1345c34237d4063807c5fb34b521426
  - 耗时：15.156 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **06:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：d63c4bef3adb42a0a04077d3bfe214e3
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `craft`（item="Cobblestone Path", count=1）
  - 💭 (做 1 块 Cobblestone Path 用来铺路)
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：5308fcc2343d4081811645fc31f18461
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `build_road`
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：5308fcc2343d4081811645fc31f18461
  - 耗时：0.562 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_06）准备的脚本
- 里程碑：Steel Hoe（5000g+5铁锭）——先清包腾出≥5空格，再下矿40-50层刷铁矿石和煤
- 起床收熔炉成品、装铁矿石；农场出货箱卖 Copper Bar 留20 腾格子
- 下矿两次（40→45→50）拿铁矿石+煤，回农场炼铁
- 铁锭≥5且时间<12:00则去铁匠铺升 hoe；否则转 Forest 钓鱼到傍晚
- 21:30 前 sleep
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
11. `ship`（item="Copper Bar", count=67）
12. `ship`（item="Stone", count=300）
13. `ship`（item="Sap", count=40）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=12）
23. `goto_location`（location="Farm"）
24. `sleep`
- **06:10** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Broken Glasses, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：626d082eea764688b1a1fed2017e05ab
  - 耗时：16.937 秒 / 游戏 30 分钟
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：a3b0777f0cb848bd9e49ab68df513f30
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：473c9a69d5924377bd293c0bff2d7785
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~300g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：7251ef114970414f972b47db0ccb823d
  - 耗时：0.86 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6b050915272a415595bd67dbf307a31f
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate 空跑分支，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够则升 hoe，否则钓鱼兜底。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=67）
10. `ship`（item="Stone", count=300）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=12）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：47eaa9fb54994118aecea2e7e0f56f8e
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/donate 分支，改为农场出货箱卖 Copper Bar 腾格后下矿刷铁，铁锭够则升 hoe，否则 Forest 钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=67）
10. `ship`（item="Stone", count=27）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=12）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a12f68be04994a5c80b02300ff9c7be9
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 空跑已确认无效，改为先收熔炉+清包（卖 Copper Bar/Stone 腾格），再下矿40层刷铁，回农场收锭，剩余时间 Forest 钓鱼
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=1）
10. `ship`（item="Stone", count=27）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Forest"）
15. `fish`（casts=12）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `collect_machines`
20. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：0373c8a9499a44179f97fb6c1f398620
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：caaae8cb999d499884f545c480c46518
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b7afabb6605141d3a995d192f2336dfc
  - 耗时：0.579 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：5da14a9aa487436a984207f9e5a59238
  - 耗时：57.328 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：6c03f337495a4f32b6e46edc17282bef
  - 耗时：44.157 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：4bc13d6b787a4a16bd4bc22196715a08
  - 耗时：0.532 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=1）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：b03e67276eb74e7a80944655d58c28e2
  - 耗时：0.546 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=27）
  - 结果：shipped 27x Stone (~54g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：e5571441cca6479d8c774d87098cd65d
  - 耗时：44.0 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e8d3449913694e34aa891439e721c025
  - 耗时：49.11 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：bdc1cf712e434644942a577fa7355e3f
  - 耗时：33.688 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Green Algae", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 7x Green Algae
  - 执行状态：SUCCESS · 操作编号：aeef95ce2d094b64b434dd8e8b1a2b1f
  - 耗时：15.125 秒 / 游戏 20 分钟
- **10:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 18 (3 floors down, 58 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：8035b489cf0f4f8d9ef90b3e17d61a58
  - 耗时：114.187 秒 / 游戏 140 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [question] 
- **14:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：15c4e689c15a48dabdee3d0fdedb0072
  - 耗时：35.828 秒 / 游戏 40 分钟
- **14:10** Mine ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Bug Meat", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (58,11)
  - 执行状态：ACTION_FAILED · 操作编号：dd8be4e72fd3466a94072cd4914d7bce
  - 耗时：14.391 秒 / 游戏 20 分钟
- **14:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **15:10** Farm ❌ `goto_location`（location="Forest"）
  - 结果：could not reach (41,63); stopped at (58,11)
  - 执行状态：ACTION_FAILED · 操作编号：4eb9b9f71a0c4b38859824ba04af512b
  - 耗时：7.703 秒 / 游戏 10 分钟
- **15:20** Farm ❌ `fish`（casts=12）
  - 结果：could not reach (64,30); stopped at (58,11)
  - 执行状态：ACTION_FAILED · 操作编号：94bbbc62d1654144ba2b8263fd387b8a
  - 耗时：7.672 秒 / 游戏 10 分钟
- **15:30** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (58,11)
  - 执行状态：SUCCESS · 操作编号：251ff188bb5e448b9a9d96e506795fa8
  - 耗时：0.516 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：81fa55ab965a417bac194843365271e0
  - 耗时：10.14 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **15:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b64085e39af6475abb41a0f876b2f856
  - 耗时：0.531 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：d3a4cb469cb845d1be2c7a4807deb747
  - 耗时：0.546 秒 / 游戏 0 分钟
- **15:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：6e824bc56b094330844e3549e5178c29
  - 耗时：3.781 秒 / 游戏 0 分钟
- **15:50** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：a56b6a71cee84feba44f532f13e4f0e2
  - 耗时：3.969 秒 / 游戏 10 分钟
- **16:00** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6c15f13dea7c4923a40f503830662246
  - 耗时：0.547 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `craft`（item="Cobblestone Path", count=1）
  - 💭 (做 1 块 Cobblestone Path 用来铺路)
  - 结果：crafted 1x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：6867046e780d4e268c4e942164bca048
  - 耗时：0.547 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 1 Cobblestone Path tiles (0 already done, 0 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：95c1bd580d424f4199810c18eec64150
  - 耗时：10.641 秒 / 游戏 10 分钟
- **16:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:10** Farm ✅ `wait`（minutes=10, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:20 pm
  - 执行状态：SUCCESS · 操作编号：c65870a6ac0d48ea9d05ce0337578312
  - 耗时：3.891 秒 / 游戏 10 分钟
- **16:20** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：3503c189a0a94c34b534a4837c25e069
  - 耗时：6.36 秒 / 游戏 0 分钟
  - 🗨️ [hud] Copper Bar
- **16:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：e518bc9c5f30487e8220b69d62e32bba
  - 耗时：0.531 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `wait`（minutes=10, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:30 pm
  - 执行状态：SUCCESS · 操作编号：6d3f2e651e5542e3856007f7662c80e1
  - 耗时：1.578 秒 / 游戏 10 分钟
- **16:30** Farm ❌ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f0873ef990954403ac80f9bd126bfde2
  - 耗时：0.532 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：470b6061dedf4de3bd185dfa71164073
  - 耗时：0.547 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：db9240e1a14b4aa78c1ad300e53c1c44
  - 耗时：5.032 秒 / 游戏 0 分钟
  - 🗨️ [hud] Copper Bar
- **16:30** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：2a0b1959523a495aa126e34140016af5
  - 耗时：0.515 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `wait`（minutes=30, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：d219df28f4f04e3f8fdec2cc091becdb
  - 耗时：17.281 秒 / 游戏 30 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：cc9aef0ded564c7198cd34130fedd640
  - 耗时：21.406 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：85894 → 86248（+354g）
- 出货估值：300g　动作：55 个　失败：29 个
- 模型调用：7 次　tokens：86200
- 有效动作率：0.4545　空转：11　熔断跳过：6
- 失败耗时：39.593 秒 / 游戏 40 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天 55 动作 29 失败，核心仍是清包失败：背包 3 格、Copper Bar 未卖出，mine 两次被 'have 1, need 5' 拒绝，铁锭仍 1/5，里程碑连续 5 天零推进。有效动作只有熔炉收/装和 1 次 15→18 层下矿。take/store_items/donate/build_road/decorate/wait 全部空跑，脚本重写 3 次仍重试同一批失败分支。今天必须把清包做成硬门槛：先卖 Copper Bar 腾格，验证空格≥5 才下矿，否则全天钓鱼。

**新教训：**
- 昨天 ship Copper Bar 在 ArchaeologyHouse 报 'not found' 而材料显示背包有 90 个：ship 只能在农场出货箱执行，且 ship 前必须先 close_menu 再读背包完整清单，地点不对直接不生成 ship。
- 昨天 15:50 起 load_machines 连续 4 次 'no empty machine accepts that'：Iron Ore 只有 1 时 load 分支应在脚本生成阶段物理删除，只有读背包确认 Iron Ore≥5 且有空炉才生成。
- 昨天 14:10 store_items 报 'could not reach (74,16); stopped at (58,11)' 后，后续 goto Forest/fish 全部卡在同一坐标失败：一旦 store/goto 返回 could not reach，当天所有跨地图动作都应跳过，直接在当前地图收尾。
- 昨天 mine 从 15 层下到 18 层只拿 58 石头、背包就满被迫离开：19 层以下无铁且石头占格，下矿必须电梯直达 40 层，不在 15-19 层浪费 mine 次数。
- 昨天 16:10-17:00 连续 wait 30 分钟填充时间，产出为 0：wait 应物理删除，空闲时间一律转 Forest 钓鱼（fish casts≥10）或提前 sleep。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 06）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 85894g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续 5 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 1-3 空格，90 个 Copper Bar 一个没卖，mine 两次被 'have 1, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 06）**：起床 collect→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼到 20:00。
- **明天（春 07）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 08）**：继续刷铁备钢斧，给作物地块补洒水器，开始春季作物（草莓前先种土豆/花椰菜保底）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 70 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 6 次、store_items 空跑 3 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 17-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 06 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 06 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 3-4 格），绝不写进 except。
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
9. 春 06 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天 55 动作 29 失败，核心仍是清包失败：背包 3 格、Copper Bar 未卖出，mine 两次被 'have 1, need 5' 拒绝，铁锭仍 1/5，里程碑连续 5 天零推进。有效动作只有熔炉收/装和 1 次 15→18 层下矿。take/store_items/donate/build_road/decorate/wait 全部空跑，脚本重写 3 次仍重试同一批失败分支。今天必须把清包做成硬门槛：先卖 Copper Bar 腾格，验证空格≥5 才下矿，否则全天钓鱼。
- 06:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:10 动作 `craft` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 06:10 动作 `build_road` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
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
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 14:10 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (58,11) 〔自动〕
- 14:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 15:10 动作 `goto_location` 失败 @ Farm — could not reach (41,63); stopped at (58,11) 〔自动〕
- 15:20 动作 `fish` 失败 @ Farm — could not reach (64,30); stopped at (58,11) 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:50 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 背包长期只有 1-3 空格，Copper Bar 90 个一个没卖，清包连续多天失败 @ Farm 出货箱 — mine 两次被 'store did not free enough slots (have 1, need 5)' 拒绝；ship 在 ArchaeologyHouse 报 'Copper Bar' not found（做不了：下矿拿铁矿、升 Steel Hoe、洒水器全部卡住，里程碑连续 5 天零推进） 〔复盘〕
- 脚本重写 3 次仍重试同一批 take ID（62/64/68/72/84/86） @ Farm 箱子 — '62' is not in any farm chest / take 64 already failed; not retrying today（做不了：浪费 12 个动作，挤占下矿和钓鱼时间） 〔复盘〕
- store_items 在 (74,16) 不可达后，后续 goto Forest/fish 全部卡在 (58,11) @ Farm — could not reach (74,16); stopped at (58,11)，随后 goto Forest 与 fish 同样 could not reach（做不了：下午钓鱼兜底完全失效，12:40 后基本空转） 〔复盘〕
- load_machines 连续 4 次报无空炉可装 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：Iron Ore 只有 1 无法炼铁，铁锭停在 1/5） 〔复盘〕
- 下矿只到 15→18 层就背包满被迫离开，没拿到铁矿石 @ Mine 15-18 层 — mined from floor 15 to 18, backpack nearly full: store items before mining again（做不了：铁矿零收获，铁锭链继续卡死） 〔复盘〕
- 16:10-17:00 连续 wait 填充时间，产出为 0 @ Farm — wait 10/30 分钟全部 OK 但无任何产出（做不了：浪费约 1 小时本可用于钓鱼的收入） 〔复盘〕
- donate_museum 在博物馆空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：无（但浪费一次跨地图移动）） 〔复盘〕
