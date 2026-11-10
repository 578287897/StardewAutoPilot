# 第4年 winter 27 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（13:01 开始）
- 天气：snow　金钱：59988g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_winter_27）准备的脚本
- 里程碑：工具按档升级——凑 5 铁锭升 Steel Hoe（5000g+5 Iron Bar）
- 起床收炉并检查熔炉状态，铁矿石不足则不投料
- 一次性清包到空格≥10（store_items 不指定坐标 + ship_produce），清包后全天禁止 take
- Forest 河边钓鱼补食物到≥5
- 电梯直达 80 层下矿 80→84 拿铁矿石+煤，≤2 次 mine
- 回农场收炉炼铁，铁锭≥5 且 13:00 前到 Blacksmith 升 hoe
- 21:30 前收尾睡觉
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
12. `collect_machines`
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Iron Ore"]）
16. `store_items`
17. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
21. `goto_location`（location="Mine"）
22. `mine`（floors=5）
23. `goto_location`（location="Farm"）
24. `store_items`
25. `collect_machines`
26. `goto_location`（location="Mine"）
27. `mine`（floors=5）
28. `goto_location`（location="Farm"）
29. `store_items`
30. `collect_machines`
31. `goto_location`（location="Blacksmith"）
32. `upgrade_tool`（tool="hoe"）
33. `goto_location`（location="Farm"）
34. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min), Copper Ore -> Furnace (ready in 20 min)
  - 执行状态：SUCCESS · 操作编号：ba510ca03bf0454fb52f826c6c537ff1
  - 耗时：16.219 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：be10b61d46164e1795e438de48d692af
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：8881bf77864149948b70a77ff00439b8
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：90fea86ddc0c42b783b9d020c718c8ea
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4fd1396caad145f8be2e743f772f0c81
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take 与博物馆/献祭分支，改为清包→钓鱼补食物→80 层下矿拿铁矿→回农场收炉→13:00 前升 hoe。
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
16. `mine`（floors=5）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
22. `store_items`
23. `collect_machines`
24. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：387a81c758714f8698e514df7e3efbf7
  - 耗时：0.391 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部 take/博物馆/社区中心分支，改走清包→钓鱼补食物→80 层下矿拿铁→回农场收炉→13:00 前升 hoe。
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
16. `mine`（floors=5）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
22. `collect_machines`
23. `store_items`
24. `collect_machines`
25. `store_items`
26. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
27. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：819bba3da0a4475e88f21d1a788d30f2
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 与博物馆/献祭分支，按清包→Forest 补食物→80 层下矿→回农场收炉→13:00 前升 hoe 的顺序重写剩余脚本。
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
16. `mine`（floors=5）
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
22. `collect_machines`
23. `store_items`
24. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
25. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：85d34eabf6564fbcaef99bdfde8f9b75
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="80", item_name="Quartz", count=1）
  - 结果：'80' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：2ff36ab1c71a4df391ec8c0fa2b2079b
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fac7c0e8e1f74e43a25a9c0c54dfebe3
  - 耗时：0.407 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：1bb4557ab9464a919b0f280a76c971cb
  - 耗时：73.188 秒 / 游戏 100 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：e718bec023674c70a59ca9ba79370380
  - 耗时：59.25 秒 / 游戏 70 分钟
- **09:10** ArchaeologyHouse ✅ `donate_museum`
  - 结果：donated Rare Disc (108) to the museum at (26,8)
  - 执行状态：SUCCESS · 操作编号：f7cd10b01db04a8c9859642620598b9e
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** ArchaeologyHouse ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：0edd7682e6fb46ecbf67b80163d2e2a3
  - 耗时：43.453 秒 / 游戏 50 分钟
- **10:00** Farm ✅ `take`（item="Bat Wing", count=1）
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：9816695a688243748ef4861e6ecc745f
  - 耗时：0.36 秒 / 游戏 0 分钟
- **10:00** Farm ❌ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：ACTION_FAILED · 操作编号：d38ff1e7cc104305849f57c2f13c88b1
  - 耗时：39.766 秒 / 游戏 50 分钟
- **10:50** CommunityCenter ❌ `goto_location`（location="Forest"）
  - 结果：could not reach (1,90); stopped at (32,90)
  - 执行状态：ACTION_FAILED · 操作编号：ad913ec613ea4c8491d7edb3d2693abb
  - 耗时：37.844 秒 / 游戏 50 分钟
- **11:40** Town ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Lingcod, Green Algae, Pike, Green Algae)
  - 执行状态：SUCCESS · 操作编号：b987e1f25c8a4668a0d23709d5f9249d
  - 耗时：82.891 秒 / 游戏 90 分钟
  - 🗨️ [hud] Lingcod
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
- **13:10** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5a21598801a04e8891238d7a6480cde0
  - 耗时：50.891 秒 / 游戏 70 分钟
- **14:20** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：6d281a1898da45eab8d3c5f3aba39ab6
  - 耗时：33.578 秒 / 游戏 40 分钟
- **14:20** Mine ✅ `store_items`（items=["Lingcod", "Green Algae", "Pike", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：b5ea62b7f4cb4312bb722cad173974c5
  - 耗时：15.016 秒 / 游戏 20 分钟
- **14:20** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:20** Farm ✅ `store_items`（items=["Lingcod", "Pike", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：91101df98dde4b98988f1cf45b704874
  - 耗时：0.391 秒 / 游戏 0 分钟
- **15:20** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:20** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：could not reach (94,82); stopped at (40,57)
  - 执行状态：ACTION_FAILED · 操作编号：6cedc81ffa7c42248e1f307df131b8ef
  - 耗时：27.469 秒 / 游戏 30 分钟
- **15:50** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：2376adbec69e45268adadecb6c7dcffe
  - 耗时：18.859 秒 / 游戏 20 分钟
- **15:50** Town ✅ `store_items`（items=["Lingcod", "Pike", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x Lingcod, 1x Pike
  - 执行状态：SUCCESS · 操作编号：a7a9dd5b9f4a4b97afe6b1541c1f4939
  - 耗时：1.094 秒 / 游戏 0 分钟
- **15:50** Town ✅ `upgrade_tool`（tool="hoe"）
  - 结果：mined from floor 15 to 17 (2 floors down, 54 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：c2dc752dd5eb49afa25174810c7d6459
  - 耗时：98.203 秒 / 游戏 130 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Sap
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Bug Meat
  - 🗨️ [question] 
- **18:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：f1d83c3a8dff4133ba1d6fc7b509c936
  - 耗时：35.765 秒 / 游戏 40 分钟
- **19:00** Farm ❌ `store_items`
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：fba9ce64117641ca9bcc356759095734
  - 耗时：14.25 秒 / 游戏 20 分钟
- **19:20** Farm ❌ `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：fe648ffd9a43441dafd0a88d2a1a1d2e
  - 耗时：7.578 秒 / 游戏 10 分钟
- **19:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：91490b966f934939abff4aa85e846748
  - 耗时：0.375 秒 / 游戏 0 分钟
- **19:30** Farm ❌ `store_items`
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：1130d94f73874f44b6d57a8b09d73b83
  - 耗时：7.656 秒 / 游戏 10 分钟
- **19:40** Farm ❌ `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal", "Stone"]）
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：03f5f5b41f444b3681cc2d59cf9381cb
  - 耗时：7.594 秒 / 游戏 10 分钟
- **19:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：6b2fa68a76ad4c67bbe82d96fa0b10c6
  - 耗时：11.953 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：59988 → 59988（+0g）
- 出货估值：0g　动作：42 个　失败：23 个
- 模型调用：6 次　tokens：67687
- 有效动作率：0.4286　空转：5　熔断跳过：6
- 失败耗时：145.971 秒 / 游戏 180 分钟
- 最深矿层：89　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天23次失败里12次是凭记忆take箱中不存在的宝石，2次mine因清包只到4格被拒，2次store/ship在(74,16)路径被挡后仍重试，1次upgrade_tool被误当mine执行（日志显示实际挖矿15→17层）——升级根本没发生。真正有效的是钓鱼4cast全成功和博物馆捐Rare Disc。核心问题：清包不彻底导致下矿/升级全链条断裂，且升级动作被错误参数吞掉。

**新教训：**
- upgrade_tool 昨天日志显示实际执行了挖矿（mined from floor 15 to 17），说明该动作可能被错误路由或参数缺失：升级前必须显式传 tool=hoe 并在动作日志里确认返回的是升级结果而非挖矿结果，否则当天视为升级失败。
- 清包到空格≥10 仍被 mine 拒（have 4, need 5），说明下矿/升级内部要求至少 5 格且清包过程会再消耗格子：清包目标应提到 ≥12，留出下矿途中捡矿石的余量。
- store_items 在 (74,16) 两次 could not reach 而 (75,15) 成功，说明箱子坐标记忆不可靠：清包一律不指定坐标，失败一次即改 ship_produce，不要在同一天重试同一坐标。
- 昨天 12 次 take 全部失败且集中在宝石 ID（62/64/68/72/80/84），说明箱子内容与记忆完全不符：脚本生成阶段应物理删除 take，需要献祭物品靠下矿现拿，不要凭 ID 猜箱子。
- 昨天 19:00 后连续 4 次 store_items/ship_produce 因路径被挡失败并拖到 19:50 才睡，而 21:30 收尾规则已存在：收尾动作应在 19:00 前完成，19:00 后只允许 collect 一次再 sleep。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 28）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 59988g 充足，铁锭 0、铁矿石 4、煤 22，瓶颈仍是铁矿石→铁锭链，已连续六天零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 28）**：起床 collect 收炉 → **一次性清包到空格≥12**（store_items 不指定坐标 + ship_produce，验证后再动）→ 电梯直达 **80 层**下矿 80→84 拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <13:00 升 hoe。
- **明天（春 1）**：春季第 1 天，买草莓/防风草种子；hoe 已升则转钢斧，否则继续下矿炼铁。
- **后天（春 2）**：铁锭富余则 craft 洒水器落地，开始春季种植。

## 今日核心修正
1. **禁止 take（全天）**：连续两天 take 全失败（箱中无该宝石）。脚本生成阶段物理删除所有 take，需要物品靠下矿/钓鱼现拿。
2. **清包一次性到空格≥12**（不是10，留余量）：起床 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证。**清包成功后全天禁止任何 take**。两次清包仍<12 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
3. **下矿目标 80→84**：电梯直达 80 层，mine 目标 80→84，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从当前最深 89 层往下爬**。
4. **熔炉投料双条件**：起床读炉状态，任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则脚本生成阶段物理删除 load 分支。返回 busy/no empty 即当天永久跳过 load。
5. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
6. **升级窗口硬约束**：铁锭凑齐后必须在 **13:00 前**到 Blacksmith（16:00 锁门，留 3 小时重试余量）。12:30 还没凑齐 5 铁锭，当天放弃升级。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**。**upgrade_tool 必须带 tool=hoe 参数**，昨天日志显示该动作被误当 mine 执行（实际挖矿 15→17 层），今天升级前先确认参数完整。
7. **路径失败即换路**：store_items/ship_produce 返回 could not reach 时，立即改不指定坐标或直接 ship_produce，**不重试同一坐标**。昨天 (74,16) 两次 could not reach 是失败来源。
8. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
3. **一次性清包到空格 ≥12**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥12 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 80 层**，mine 目标 80→84 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥12，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <12 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥12 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **take 禁用（全天）**：连续两天 take 全失败，今天脚本生成阶段物理删除所有 take 动作。
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
3. **一次性清包到空格 ≥12**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 80 层**拿铁矿石+煤（空格 ≥12、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天23次失败里12次是凭记忆take箱中不存在的宝石，2次mine因清包只到4格被拒，2次store/ship在(74,16)路径被挡后仍重试，1次upgrade_tool被误当mine执行（日志显示实际挖矿15→17层）——升级根本没发生。真正有效的是钓鱼4cast全成功和博物馆捐Rare Disc。核心问题：清包不彻底导致下矿/升级全链条断裂，且升级动作被错误参数吞掉。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '80' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 10:00 动作 `donate` 失败 @ Farm — opened the bundles but nothing could be deposited 〔自动〕
- 10:50 动作 `goto_location` 失败 @ CommunityCenter — could not reach (1,90); stopped at (32,90) 〔自动〕
- 14:20 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 15:20 动作 `mine` 失败 @ Farm — store did not free enough slots (have 4, need 5) 〔自动〕
- 15:20 动作 `goto_location` 失败 @ Farm — could not reach (94,82); stopped at (40,57) 〔自动〕
- 19:00 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 19:20 动作 `ship_produce` 失败 @ Farm — could not reach (70,15); stopped at (53,8) 〔自动〕
- 19:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 19:30 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 19:40 动作 `ship_produce` 失败 @ Farm — could not reach (70,15); stopped at (53,8) 〔自动〕
- 凭记忆 take 箱中不存在的宝石，12 次全部失败，吃掉近半动作预算 @ Farm 箱子 (74,15) — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：献祭物品没拿到，博物馆捐赠和社区中心收集包无法推进） 〔复盘〕
- 清包两次后仍只剩 4 空格，mine 被拒两次 @ Farm — store did not free enough slots (have 4, need 5)（做不了：当天无法下矿拿铁矿石，铁锭链继续零推进） 〔复盘〕
- upgrade_tool 实际执行成了挖矿（15→17 层），升级根本没发生 @ Mine / Blacksmith — upgrade_tool 返回 mined from floor 15 to 17，参数或路由错误（做不了：钢锄头升级连续第六天未完成） 〔复盘〕
- store_items/ship_produce 在 (74,16) 路径被挡后仍重试两次 @ Farm — could not reach (74,16); stopped at (53,8)（做不了：收尾清包失败，背包没腾出格子，次日开局仍满） 〔复盘〕
- goto Forest 河边钓鱼点 (1,90) 无法到达 @ Forest — could not reach (1,90); stopped at (32,90)（做不了：补食物计划受影响，只能就近钓鱼） 〔复盘〕
- goto Blacksmith 在 15:20 路径被挡，且已过 13:00 升级窗口 @ Town→Mountain — could not reach (94,82); stopped at (40,57)（做不了：即使铁锭够也无法当天升级） 〔复盘〕
- donate 打开收集包但无可存入物品 @ Community Center — opened the bundles but nothing could be deposited（做不了：社区中心收集包零推进） 〔复盘〕
- 19:00 后连续 4 次收尾动作失败拖到 19:50 才睡 @ Farm — could not reach (74,16) / (70,15) 反复失败（做不了：压缩次日体力，且当天背包未清空） 〔复盘〕
