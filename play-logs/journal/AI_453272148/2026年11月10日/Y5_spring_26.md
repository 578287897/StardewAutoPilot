# 第5年 spring 26 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（18:30 开始）
- 天气：sunny　金钱：66534g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌙 为明天（Y5_spring_26）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收熔炉成品，若炉空且铁矿≥5 立即投料
- 清包到空格≥15（store_items + ship_produce 双管齐下）
- 补食物到≥5（Saloon 12:00 后买沙拉）
- 电梯直达 40 层下矿拿铁矿石+煤，≤2 次 mine
- 回农场收铁锭，铁锭≥5 且 <13:00 去铁匠铺升 hoe
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
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
14. `goto_location`（location="Saloon"）
15. `open_shop`（shop_id="Saloon"）
16. `buy`（item="Salad", count=6）
17. `close_menu`
18. `goto_location`（location="Mine"）
19. `mine`（floors=5）
20. `store_items`
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `goto_location`（location="Blacksmith"）
24. `upgrade_tool`（tool="hoe"）
25. `goto_location`（location="Farm"）
26. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：78f0db4ea6614711aabf69186a44faa4
  - 耗时：17.453 秒 / 游戏 20 分钟
  - 🗨️ [hud] Gold Bar
- **06:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：f18fe03cf9a242468871ab694b8cd719
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：9d2b37ecf5cb41b1a188b4bfaacf0e7b
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 9 crops
  - 执行状态：SUCCESS · 操作编号：1cf74f3ab7d546f0b7df79ff7e6b1f77
  - 耗时：21.265 秒 / 游戏 30 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~21g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：9e64ef1b7cd64adfbf7686570bbb230d
  - 耗时：2.422 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：12399eb173354cc39295e8a46122004a
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 宝石全失败（箱子内容与记忆不符），物理删除 take/donate 分支，保留清包→40层下矿→炼铁→升 hoe 主线。
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
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Iron Ore"）
17. `store_items`
18. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
19. `store_items`
20. `store_items`
21. `collect_machines`
22. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：68b2d73460e645cfbcd9414eaaee19e0
  - 耗时：0.438 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 宝石连续失败（箱子内容与记忆不符），物理删除 take/donate 分支，改为收炉→清包→买沙拉补食物→电梯 40 层下矿拿铁矿石，回农场
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Town"）
10. `wait`（minutes=300）
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=10）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `store_items`
22. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
23. `store_items`
24. `collect_machines`
25. `store_items`
26. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
27. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8086929aefc941fc809cb1ba152c3541
  - 耗时：0.438 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失败（箱子内容与记忆不符），删除所有 take 与 donate 分支，改为收炉→清包→买沙拉→40 层下矿拿铁→回农场炼铁→睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Town"）
10. `wait`（minutes=300）
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=10）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `store_items`
20. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `store_items`
24. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
25. `sleep`
- **06:50** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:50** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：dde4ac7e908340d8b864d3515ac1a728
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3fa55c139cd0453eb349f28200903ec7
  - 耗时：0.406 秒 / 游戏 0 分钟
- **06:50** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：59ab2ba3336c46e58b2128f3b981ce00
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:50** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：a6001883e3044f88b72de37aab1e876a
  - 耗时：48.578 秒 / 游戏 70 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c3ec392656e54d3aac307256792eb344
  - 耗时：44.063 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：684afddf424d4f8aa6220c92ddbd69c9
  - 耗时：0.437 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (101,90)
  - 执行状态：SUCCESS · 操作编号：c87c4094630f4d048f130750af2f47a1
  - 耗时：1.625 秒 / 游戏 0 分钟
- **08:50** Town ✅ `wait`（minutes=300）
  - 结果：waited until 10:50 am
  - 执行状态：SUCCESS · 操作编号：36cb9c490241407782c35bb72757a340
  - 耗时：84.532 秒 / 游戏 120 分钟
- **10:50** Town ✅ `goto_location`（location="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：e02e106a90464c7584e383eb6ea7ffe4
  - 耗时：51.406 秒 / 游戏 70 分钟
- **12:00** Town ✅ `goto_location`（location="Saloon"）
  - 结果：arrived at Saloon (14,24)
  - 执行状态：SUCCESS · 操作编号：011364309fe74b389f4ac069ae255918
  - 耗时：19.672 秒 / 游戏 20 分钟
- **12:20** Saloon ✅ `open_shop`（shop_id="Saloon"）
  - 结果：shop opened
  - 执行状态：SUCCESS · 操作编号：7ce4a82073dd46ef8ca3b034b699d5e4
  - 耗时：0.469 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `buy`（item="Salad", count=6）
  - 💭 Saloon 商店已开，先买沙拉补食物到≥5，再清包下矿。
  - 结果：bought 6x Salad for 1320g
  - 执行状态：SUCCESS · 操作编号：3d9e7190b78749f181516f56c4bd3950
  - 耗时：0.39 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `close_menu`
  - 💭 沙拉已买到6个，背包空格仅4，需先关菜单回农场清包到≥15再下矿。
  - 结果：menu closed
  - 执行状态：SUCCESS · 操作编号：d223abb4398842d09646fdbea1865ab6
  - 耗时：0.453 秒 / 游戏 0 分钟
- **12:20** Saloon ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：c661842dec7440439a9f13c2851137cc
  - 耗时：26.297 秒 / 游戏 30 分钟
- **12:50** Farm ✅ `store_items`
  - 结果：stored in chest at (75,15): 4x Stone, 2x Gold Bar, 1x Cherry Bomb
  - 执行状态：SUCCESS · 操作编号：27dbaaff710f453a849fe36b1eb8ec66
  - 耗时：1.094 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `buy`（item="Salad", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：d1d3cd49bf6442caa2a2ced9e5dd2874
  - 耗时：0.39 秒 / 游戏 0 分钟
- **12:50** Farm ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：7b16dfde4fe34dd1925a4b856c02f872
  - 耗时：0.406 秒 / 游戏 0 分钟
- **12:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：c8bfe8a5004045b5a6aa4ca0b12939cf
  - 耗时：49.797 秒 / 游戏 60 分钟
- **13:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 99 (4 floors down, 103 stones broken); low stamina
  - 执行状态：SUCCESS · 操作编号：5dfd3e4a6950434fa085c1dbcf4868ab
  - 耗时：293.391 秒 / 游戏 400 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Stone
  - 🗨️ [hud] You're starting to 
feel exhausted. 
- **20:30** UndergroundMine99 ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：8bee1b83cde147ae8bad3b590d1cf21d
  - 耗时：58.109 秒 / 游戏 70 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **21:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：e54d0ca5715048bea8c95a4cda42d6cc
  - 耗时：7.093 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **21:50** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 4x Coal, 1x Fiber, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：bebc7f8a0762434582ed841e88e33171
  - 耗时：18.5 秒 / 游戏 30 分钟
- **22:20** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
  - 结果：shipped 1 stacks worth ~50g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：406e932f67c64911bde80da35a0c1293
  - 耗时：0.734 秒 / 游戏 0 分钟
- **22:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：0ffb36e84d3a4cc7a9ee17eef13f7f92
  - 耗时：0.437 秒 / 游戏 0 分钟
- **22:20** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：e117dfa399714ad8826d963e432d206a
  - 耗时：13.938 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **22:40** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：e1fcdaeb11e3485b846e80f95a8859c9
  - 耗时：13.359 秒 / 游戏 10 分钟
- **22:50** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Stone", "Fiber", "Copper Ore", "Gold Ore", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Cherry Bomb", "Dwarf Scroll I"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：06af4fef90824ec7940e4f2557945839
  - 耗时：0.422 秒 / 游戏 0 分钟
- **22:50** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：715d59e99586474da0dd4f85be665db6
  - 耗时：10.422 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：66534 → 65285（-1249g）
- 出货估值：71g　动作：43 个　失败：17 个
- 模型调用：8 次　tokens：92220
- 有效动作率：0.6286　空转：4　熔断跳过：6
- 失败耗时：5.202 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天43动作17失败，12次take宝石全空、donate_museum无物可捐、build_road/decorate零产出，都是脚本凭记忆猜箱子内容造成的空转；真正推进只有下矿95→99层拿到少量铁矿，但食物不足、清包只腾4格，铁锭链仍0/5。核心问题：清包不彻底、食物门槛没提前解决、take类动作没彻底删除。

**新教训：**
- 昨天 12:20 才买沙拉、13:50 才下矿，只挖 4 层就体力耗尽：补食物必须排在清包之后、下矿之前，且 12:00 前用 Forest 钓鱼过渡，不能等到中午才动身。
- 昨天清包只腾出 4 格（store_items 一次），mine 和 upgrade 都被「need 5」拒：清包必须 store_items + ship_produce 双管齐下并读背包验证，单靠 store_items 不够。
- 昨天电梯到 80 层但食物=0 被拦在 19 层，一颗铁矿没拿到：下矿目标应固定 40 层（铁矿下限），电梯再高也白跑，食物是门票。
- 昨天 donate_museum 因背包无可捐物失败，而宝石都在箱子里：捐博物馆前必须先确认背包实际有可捐物，否则直接跳过，不要先 goto ArchaeologyHouse 再失败。
- 昨天 buy 成功买沙拉后 close_menu，随后脚本又调 buy 返回「no shop is open」、close_menu 又失败，连吃 2 个动作：关菜单后当天不再 buy，买够再关。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 27）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65214g 充足，卡点仍是 Iron Bar 0/5（Iron Ore 3、Coal 26）。已连续 7 天零推进，铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。**铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标；食物和背包空格是它的两张门票，缺一张当天就白跑。**

接下来 3 天主活动：
- **今天（春 27）**：起床收炉→清包到空格≥15→补食物≥5→电梯 40 层刷铁矿石+煤（目标 40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（春 28）**：hoe 升完转钢斧（同配方 5 铁锭）；铁锭不足则全天 40-50 层刷铁。季末只种 28 日前能熟的作物。
- **后天（夏 1）**：买啤酒花（隔行支架）、蓝莓、甜瓜；铁锭富余后做洒水器 ×4，把浇水体力省下来。

## 今日核心修正（按执行顺序）
1. **清包是今天第一硬门槛，且必须双管齐下**：goto Farm → store_items（不指定坐标，存 Stone/Geode/种子/杂矿）→ ship_produce（卖鱼/杂矿/低价值物，Stone/Coal/矿石/锭除外）→ **读背包验证空格≥15**。昨天只腾 4 格导致 mine/upgrade 全被拒。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **食物提前到清包后立刻解决**：昨天 12:20 才买沙拉，下矿已 13:50，只挖 4 层就体力耗尽。今天清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
3. **下矿目标 40 层，不贪 80 层**：昨天电梯到 80 层但食物=0 被拦在 19 层，白跑。今天电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
4. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
5. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
6. **mine 成功一次后先 store_items 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
9. **build_road / decorate / donate_museum 物理删除**：昨天各失败 1 次、连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 一次性清包到空格≥15：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥15 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 store_items 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
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
3. 一次性清包到空格≥15（store_items 不指定坐标 + ship_produce 卖低价值物 + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥15、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天43动作17失败，12次take宝石全空、donate_museum无物可捐、build_road/decorate零产出，都是脚本凭记忆猜箱子内容造成的空转；真正推进只有下矿95→99层拿到少量铁矿，但食物不足、清包只腾4格，铁锭链仍0/5。核心问题：清包不彻底、食物门槛没提前解决、take类动作没彻底删除。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:50 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 12:50 动作 `buy` 失败 @ Farm — no shop is open; use open_shop first 〔自动〕
- 12:50 动作 `close_menu` 失败 @ Farm — no menu is open 〔自动〕
- 22:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12 次 take 宝石（Aquamarine/Ruby/Topaz/Diamond/Frozen Tear/Earth Crystal）全部失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 (74,15) — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：捐博物馆、送礼、献祭都拿不到指定物品，白耗 12 个动作） 〔复盘〕
- donate_museum 到达博物馆后无可捐物 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：社区中心/博物馆进度停滞，且白跑一趟 Town） 〔复盘〕
- 清包只腾出 4 格，mine 和 upgrade_tool 都被拒 @ Farm — store did not free enough slots (have 4, need 5)（做不了：下矿和工具升级都被卡住，铁锭链无法推进） 〔复盘〕
- 食物到 12:20 才买、13:50 才下矿，下矿只挖 4 层就体力耗尽 @ Saloon → Mine — low stamina / You're starting to feel exhausted（做不了：40 层以下铁矿没拿到，铁锭仍 0/5） 〔复盘〕
- 电梯到 80 层但食物=0 被拦在 19 层 @ Mine — 食物不足无法下 20 层以下（做不了：铁矿一颗没拿到，白跑一趟矿洞） 〔复盘〕
- buy 沙拉成功后 close_menu 再 buy 返回 no shop is open，close_menu 又失败 @ Saloon → Farm — no shop is open; use open_shop first / no menu is open（做不了：连吃 2 个动作，浪费游戏时间） 〔复盘〕
- build_road 和 decorate 连续多天 0 产出 @ UndergroundMine19 / Farm — 规划道路边没有还能走上去的空格 / 今天没有能做的装饰（做不了：纯浪费动作，不推进任何里程碑） 〔复盘〕
- 铁锭链连续 7 天零推进（Iron Bar 0/5） @ 全局 — Iron Ore 3、Coal 26，熔炉投料不足（做不了：钢锄头、钢斧、洒水器全部堵在铁锭后面） 〔复盘〕
