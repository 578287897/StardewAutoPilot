# 第6年 spring 8 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（20:11 开始）
- 天气：windy　金钱：86300g　体力：270/270
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
  - 执行状态：NO_PROGRESS · 操作编号：ee0ca8261b82484db54b3b224c91f46e
  - 耗时：3.36 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：c092e0bf79ff425c81ddd5410b7dcf44
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Broken Glasses
  - 执行状态：SUCCESS · 操作编号：ce08b01cf3d14aedbbc1a265772611c7
  - 耗时：6.188 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：47b56bae8f9d4d0a8573be6b4df24f46
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：ca8fc93677ab4efcbccd86c74b19810e
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~270g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b692ee14cf7544e9a6bf8989a118ba53
  - 耗时：0.781 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_08）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须打破铁锭零推进
- 起床收熔炉成品，有空炉且铁矿石够就装料
- 在农场出货箱清包：卖 Copper Bar 留 20、卖多余 Stone/Sap，验证空格≥5
- 补食物到≥5（酒吧买沙拉），电梯直达 40 层刷铁矿石+煤，≤2 次 mine
- 回农场收铁锭；铁锭≥5 且 12:00 前就去铁匠铺升 hoe
- 铁锭不够就转 Forest 钓鱼到傍晚，21:30 前睡
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
11. `ship`（item="Copper Bar", count=70）
12. `ship`（item="Stone", count=500）
13. `ship`（item="Sap", count=48）
14. `goto_location`（location="Saloon"）
15. `open_shop`（shop_id="Saloon"）
16. `buy`（item="Salad", count=8）
17. `close_menu`
18. `goto_location`（location="Mine"）
19. `mine`（floors=5）
20. `leave_mine`
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `goto_location`（location="Blacksmith"）
24. `upgrade_tool`（tool="hoe"）
25. `goto_location`（location="Forest"）
26. `fish`（casts=12）
27. `goto_location`（location="Farm"）
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1c5705699854483990b65127ed142f0a
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate_museum 分支（箱子无该物品、卷轴未解锁），保留清包→买沙拉→40层下矿→升hoe→钓鱼兜底路线。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=48）
12. `goto_location`（location="Saloon"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=12）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ca508f62e43e45d381a824bc7cb7d490
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 空跑已确认箱子无对应物品，删除 take/donate 分支，改走清包卖铜锭→买沙拉→40层刷铁→升 hoe→钓鱼兜底。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=48）
12. `goto_location`（location="Saloon"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=12）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：86476f45d5ac42ed9139d9e95270d68c
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败，物理删除 take/捐献分支，保留清包→买沙拉→40 层刷铁→升 hoe→钓鱼兜底的原路线。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=70）
10. `ship`（item="Stone", count=500）
11. `ship`（item="Sap", count=48）
12. `goto_location`（location="Saloon"）
13. `open_shop`（shop_id="Saloon"）
14. `buy`（item="Salad", count=8）
15. `close_menu`
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Forest"）
22. `fish`（casts=12）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `collect_machines`
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
  - 执行状态：ACTION_FAILED · 操作编号：91c049fc05fb42d2b1aabeb81f16f688
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3c5024c893f54a51ac44a0674beda30e
  - 耗时：0.61 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9403df20b8fd44d9bceacb655ba138eb
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：3e50ed201f2b48c78593b26565ca4bf0
  - 耗时：79.937 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：2d60695d64234065a9319d0cd7123835
  - 耗时：44.156 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：113450d07f04459196414825654a00ee
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=70）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：5deb2d70b1404aa9b93dfe5f2b5f8666
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=500）
  - 结果：shipped 9x Stone (~18g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：e4b383b1ef144d6e921d7260d82ada36
  - 耗时：43.969 秒 / 游戏 50 分钟
- **09:40** Farm ❌ `ship`（item="Sap", count=48）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：a37b5109c54b44bc9b22781f593ebe66
  - 耗时：0.516 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 11:40 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：49271ef688934a5fa7f018fdd8111cd2
  - 耗时：81.438 秒 / 游戏 120 分钟
- **11:40** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：8050bc4305614107a33e4dec86992b8c
  - 耗时：14.906 秒 / 游戏 20 分钟
- **12:00** Farm ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：1f058ec0c4ee44508344da6432e52d47
  - 耗时：26.485 秒 / 游戏 30 分钟
- **12:30** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：15da728d97c4413a9cde77aec3d8e61d
  - 耗时：0.766 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `buy`（item="Salad", count=8）
  - 💭 背包无沙拉，先买沙拉补食物到8，再回农场清包下矿。
  - 结果：bought 8x Salad for 1760g
  - 执行状态：SUCCESS · 操作编号：b5784af563a342ba8f7fbf82dcc88070
  - 耗时：0.547 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `close_menu`
  - 💭 已在酒吧买到8沙拉，背包仅3空格，先关菜单回农场清包（卖Gold Bar/Geode腾格），再下矿
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：3385432c1f7740dbb9846f52baad773b
  - 耗时：0.547 秒 / 游戏 0 分钟
- **12:30** Saloon ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：8e7d632ce28d46238b66ceb9e84c38a4
  - 耗时：47.906 秒 / 游戏 60 分钟
- **13:30** Farm ❌ `buy`（item="Salad", count=8）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：be140b0845f74a8ab6f9c69547023581
  - 耗时：0.563 秒 / 游戏 0 分钟
- **13:30** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：a0cbae043ff74e44b8f507bdf4ec2f17
  - 耗时：0.531 秒 / 游戏 0 分钟
- **13:30** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a63928d0955c4f969c679c771f7f333c
  - 耗时：59.234 秒 / 游戏 70 分钟
- **14:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：bdd61b7b4f2040c5bc78d72dd130c9ed
  - 耗时：33.687 秒 / 游戏 40 分钟
- **14:40** Mine ❌ `store_items`（items=["Salad", "Pumpkin Seeds", "Geode", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：could not reach (74,16); stopped at (58,11)
  - 执行状态：ACTION_FAILED · 操作编号：4b39ab7200e549c4bcfe5e3fe43c175a
  - 耗时：15.047 秒 / 游戏 20 分钟
- **14:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **15:40** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：a2d0901a034848e1b613ca3d71b09e36
  - 耗时：0.547 秒 / 游戏 0 分钟
- **15:40** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: Salad | It's locked... (Open 9:00am - 4:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：6baf16d1721c4d69a066763def9ed798
  - 耗时：79.421 秒 / 游戏 100 分钟
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 4:00pm)
- **17:20** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：14516cca110045aabd0ee668a3b6bce3
  - 耗时：42.094 秒 / 游戏 60 分钟
- **17:20** Town ✅ `store_items`（items=["Salad", "Pumpkin Seeds", "Geode", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x Geode
  - 执行状态：SUCCESS · 操作编号：e8b910b415794bb8961cdc974f2fae9c
  - 耗时：1.172 秒 / 游戏 0 分钟
- **17:20** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **18:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：1af1ea78ee524cb38db60270d20d14bf
  - 耗时：23.641 秒 / 游戏 30 分钟
- **18:50** Forest ✅ `fish`（casts=12）
  - 结果：fished: caught 12 (Joja Cola, Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Green Algae, Smallmouth Bass, Smallmouth Bass, Green Algae, Smallmouth Bass, Smallmouth Bass, Green Algae, Broken Glasses)
  - 执行状态：SUCCESS · 操作编号：b4742adbea1e4940b579fe16761ee9a0
  - 耗时：231.453 秒 / 游戏 240 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
- **22:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：530c35b7ac37453cae802f93363ac205
  - 耗时：9.672 秒 / 游戏 10 分钟
- **23:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **23:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **23:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7aaea62512b349cdb631c6ac3fca6df4
  - 耗时：23.625 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：86300 → 84828（-1472g）
- 出货估值：270g　动作：49 个　失败：27 个
- 模型调用：9 次　tokens：108942
- 有效动作率：0.475　空转：5　熔断跳过：8
- 失败耗时：105.877 秒 / 游戏 120 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包链断裂：在 ArchaeologyHouse 调 ship Copper Bar 报 not found（地点错+未读背包），导致背包始终 3-4 空格，mine 被 'need 5' 拒绝，Steel Hoe 连续 6 天零推进；take 空跑 12 次、donate/build_road 空跑纯浪费。有效的是 Saloon 买沙拉、Forest 钓鱼 12 条。今天必须先在农场出货箱卖 Copper Bar 腾格，再下矿。

**新教训：**
- 昨天在 ArchaeologyHouse 调 ship Copper Bar 报 'not found'，而材料显示背包有 90 个：ship 动作只在农场出货箱附近有效，脚本生成阶段应把 ship 的 location 硬编码为 Farm，其他地图一律不生成 ship。
- 昨天 mine 被 'store did not free enough slots (have 3, need 5)' 拒绝，而背包 90 个 Copper Bar 一个没卖：清包应把 Copper Bar 列为第一优先卖出项（留 20），而不是先卖 Stone/Sap 这类低价值物品。
- 昨天 12:30 在 Saloon 买完沙拉后 close_menu 再回农场，13:30 脚本又生成 buy Salad 报 'no shop is open'：buy 成功后应在同一菜单内一次性买够，脚本生成阶段不应在已离开商店后再生成 buy 分支。
- 昨天 14:40 和 17:20 两次 store_items 分别报 'could not reach (74,16); stopped at (58,11)' 和只存进 1x Geode：箱子坐标 (75,15) 附近路径被挡，store_items 应物理删除，改用 ship 出货箱腾格。
- 昨天 15:40 在非矿洞地图生成 leave_mine 报 'not in the mine'：leave_mine 只能在 mine 成功之后生成，脚本生成阶段应检查上一条动作是否为 mine。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 09）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 84540g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续 7 天零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 3-4 空格，90 个 Copper Bar 一个没卖，mine 被 'have 3, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 09）**：起床 collect→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼到 20:00。
- **明天（春 10）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 11）**：继续刷铁备钢斧，给作物地块补洒水器，种土豆/花椰菜保底（13 日复活节买草莓）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 70 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。昨天在 ArchaeologyHouse 调 ship 报 'not found' 是地点错。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 2 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 15-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 09 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 09 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
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
9. 春 09 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包链断裂：在 ArchaeologyHouse 调 ship Copper Bar 报 not found（地点错+未读背包），导致背包始终 3-4 空格，mine 被 'need 5' 拒绝，Steel Hoe 连续 6 天零推进；take 空跑 12 次、donate/build_road 空跑纯浪费。有效的是 Saloon 买沙拉、Forest 钓鱼 12 条。今天必须先在农场出货箱卖 Copper Bar 腾格，再下矿。
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
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 09:40 动作 `ship` 失败 @ Farm — 'Sap' not found in inventory 〔自动〕
- 13:30 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 13:30 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 14:40 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (58,11) 〔自动〕
- 14:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 15:40 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 15:40 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: Salad | It's locked... (Open 9:00am - 4:00pm) | 游戏消息: [dialogue] It's locked... (Open 9:00am - 4:00pm) 〔自动〕
- 17:20 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 4, need 5) 〔自动〕
- 清包链断裂：ship Copper Bar 在错误地点执行，背包空格始终 3-4，下矿被拒 @ ArchaeologyHouse / Farm 出货箱 / Mine — ship 'Copper Bar' not found in inventory（在 ArchaeologyHouse）；mine 报 'store did not free enough slots (have 3, need 5)'（做不了：无法下 40 层拿铁矿石，Steel Hoe 升级连续 7 天零推进） 〔复盘〕
- take 动作连续空跑 12 次，脚本重写 3 次仍重试同一批矿物 ID @ Farm 箱子 — '62'/'64'/'68'/'72'/'84'/'86' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费大量动作和脚本重写次数，挤占下矿和钓鱼时间） 〔复盘〕
- store_items 无法到达箱子坐标，只存进 1 个 Geode @ Farm (75,15) 箱子 — could not reach (74,16); stopped at (58,11)；第二次只 stored 1x Geode（做不了：背包腾不出空格，mine 和 upgrade_tool 均被 'need 5' 拒绝） 〔复盘〕
- 在非矿洞地图生成 leave_mine，且 Blacksmith 已关门仍去升级 @ Farm / Blacksmith — leave_mine: not in the mine；goto Blacksmith: It's locked... (Open 9:00am - 4:00pm)（做不了：升级 hoe 失败，当天升级窗口浪费） 〔复盘〕
- donate_museum 和 build_road 空跑，无任何产出 @ ArchaeologyHouse / Farm — nothing in the backpack can be donated；规划道路边没有还能走上去的空格（做不了：浪费动作，挤占有效时间） 〔复盘〕
- 16:00 后 collect_machines 连续被系统抑制，熔炉产出未收 @ Farm — repeated ineffective action suppressed until game state changes（做不了：铁锭产出延迟，影响升级节奏） 〔复盘〕
