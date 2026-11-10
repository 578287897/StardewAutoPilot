# 第5年 spring 14 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（16:06 开始）
- 天气：sunny　金钱：63525g　体力：270/270
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
  - 执行状态：SUCCESS · 操作编号：76641cf88f514beabca055502079df5a
  - 耗时：15.36 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Bar
- **06:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：9e7f8f725d2945cfaaddaed1d8071d8c
  - 耗时：4.969 秒 / 游戏 10 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 2 crops
  - 执行状态：SUCCESS · 操作编号：b94e4a5bfcef43519d2aa743c53f3d4f
  - 耗时：13.656 秒 / 游戏 20 分钟
  - 🗨️ [hud] Kale
  - 🗨️ [hud] Potato

## 🌙 为明天（Y5_spring_14）准备的脚本
- 里程碑：凑齐 5 铁锭升级钢锄头（5000g+5 Iron Bar）
- 起床收熔炉→空炉投铁矿石
- 清包到空格≥15（store+ship）
- Forest 钓鱼补食物到≥6
- 电梯直达 80 层下矿 80→84 挖铁矿石+煤
- 回农场收铁锭，13:00 前到 Blacksmith 升 hoe
- 买春季种子（Potato/Cauliflower）并当天种下
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
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar"]）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `store_items`
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="SeedShop"）
24. `open_shop`（shop_id="SeedShop"）
25. `buy`（item="Potato Seeds", count=20）
26. `buy`（item="Cauliflower Seeds", count=10）
27. `close_menu`
28. `goto_location`（location="Farm"）
29. `plant_seeds`（item="Potato Seeds", count=20）
30. `sleep`
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 4 crops
  - 执行状态：SUCCESS · 操作编号：cefa5cc526434d3dbe2b2858821cd1b2
  - 耗时：9.766 秒 / 游戏 10 分钟
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~385g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：7def0bf3f4c840069b04aa2e79bb9964
  - 耗时：9.891 秒 / 游戏 10 分钟
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9fd18e48dc464131ae8e148651d65343
  - 耗时：0.343 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部take与博物馆行程，改为清包→钓鱼补食物→80层挖铁→回农场收锭→升hoe→买种即种，按原路线收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar"]）
23. `store_items`
24. `collect_machines`
25. `store_items`
26. `plant_seeds`（item="Potato Seeds", count=20）
27. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：7a77c911bfe74301b8464d51de664adc
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删除全部take分支（箱子内容与记忆不符），改为store+ship清包→Forest钓鱼补食物→电梯80层挖铁→回农场收锭→Blacksmith升h
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `store_items`
22. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar"]）
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `store_items`
26. `collect_machines`
27. `plant_seeds`（item="Potato Seeds", count=20）
28. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：48224d980ab040f0bc5f5d0a59b3fb6e
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部take（宝石不在箱中），改为收炉→投铁矿→清包→Forest钓鱼补食物→80层下矿挖铁→回农场收锭→13点前升hoe→买种当天种下。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="SeedShop"）
16. `open_shop`（shop_id="SeedShop"）
17. `buy`（item="Potato Seeds", count=20）
18. `buy`（item="Cauliflower Seeds", count=10）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `store_items`
24. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar"]）
25. `store_items`
26. `collect_machines`
27. `plant_seeds`（item="Potato Seeds", count=20）
28. `sleep`
- **07:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3e791c0e21cb48639375017f74cdfbe1
  - 耗时：0.359 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9b18bfd3ebf84db19752947e793c606c
  - 耗时：0.359 秒 / 游戏 0 分钟
- **07:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b4f8e567f7d34f8f8acdfbc21b915c25
  - 耗时：0.359 秒 / 游戏 0 分钟
- **07:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：ca62c04029764d70ac10ba20caa5177a
  - 耗时：36.906 秒 / 游戏 60 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：52342386ca924af6a52f1a858e8c4d0c
  - 耗时：45.672 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：4525a5fb7e924cbb83f3fb63416018a5
  - 耗时：0.375 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：5ff89efdd7de4fb4895ea9c13684e3ce
  - 耗时：26.453 秒 / 游戏 30 分钟
- **09:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Green Algae, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：f7b508a9847d4a8ba3b1690543738e6d
  - 耗时：105.14 秒 / 游戏 110 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Sunfish
- **11:10** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：f3a34adc523a4b799007609c272378d2
  - 耗时：63.579 秒 / 游戏 90 分钟
- **12:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：a1ba3ab961ec4f6280aa026083af940a
  - 耗时：33.594 秒 / 游戏 40 分钟
- **12:40** Mine ✅ `store_items`（items=["Moss", "Green Algae", "Magma Geode", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Moss, 1x Green Algae
  - 执行状态：SUCCESS · 操作编号：eddc9035e1c34349b6932e625e3374a3
  - 耗时：15.875 秒 / 游戏 20 分钟
- **12:40** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **13:40** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：could not reach (94,82); stopped at (40,57)
  - 执行状态：ACTION_FAILED · 操作编号：2044cc13a3bc44e59ffeaa1eeaf61857
  - 耗时：29.047 秒 / 游戏 30 分钟
- **14:10** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：d924942451494ff6933c6e8a6a5998a2
  - 耗时：18.859 秒 / 游戏 30 分钟
- **14:10** Town ✅ `store_items`（items=["Magma Geode", "Strange Bun"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 1x Magma Geode
  - 执行状态：SUCCESS · 操作编号：8e4e63766ccf42779e6097c52d7a7afd
  - 耗时：1.109 秒 / 游戏 0 分钟
- **14:10** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：b721beedffcb4fb99db29878944596c6
  - 耗时：300.391 秒 / 游戏 400 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Bat Wing
  - 🗨️ [hud] Copper Ore
- **21:20** UndergroundMine39 ❌ `goto_location`（location="SeedShop"）
  - 结果：exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 9:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：204cdcd524c143f6a8a4d8c0271e0004
  - 耗时：48.015 秒 / 游戏 60 分钟
  - 🗨️ [question] 
  - 🗨️ [dialogue] It's locked... (Open 9:00am - 9:00pm)
- **22:20** Town ❌ `open_shop`（shop_id="SeedShop"）
  - 结果：can't open shop 'SeedShop' at Town; the counter is in SeedShop
  - 执行状态：ACTION_FAILED · 操作编号：52cccf32cf6140248f72d2b103fccd98
  - 耗时：0.391 秒 / 游戏 0 分钟
- **22:20** Town ❌ `buy`（item="Potato Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：093622e7a28c4cbb832e4231cc0bb6eb
  - 耗时：0.375 秒 / 游戏 0 分钟
- **22:20** Town ❌ `buy`（item="Cauliflower Seeds", count=10）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：bf6219d7c93940d4ba72995f9dacc8ff
  - 耗时：0.375 秒 / 游戏 0 分钟
- **22:20** Town ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：24b53c56698b49be9beec640c24f463a
  - 耗时：0.391 秒 / 游戏 0 分钟
- **22:20** Town ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：3c6e13a0494c4904be655670dd1de482
  - 耗时：19.703 秒 / 游戏 20 分钟
- **22:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：4b26e778399143a08a074ffc76cc3303
  - 耗时：17.532 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **23:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：9e4708c569bf43aeb890ca3801a553db
  - 耗时：0.375 秒 / 游戏 0 分钟
- **23:00** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 5x Coal, 2x Copper Bar, 3x Bug Meat, 1x Bat Wing
  - 执行状态：SUCCESS · 操作编号：fc487578b1424518b30132987313e3ad
  - 耗时：18.25 秒 / 游戏 30 分钟
- **23:30** Farm ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar"]）
  - 结果：shipped 2 stacks worth ~165g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：3e04b417e11d4c4e8e618e6c8309c2ce
  - 耗时：0.687 秒 / 游戏 0 分钟
- **23:30** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1be114b54c09451181bb89a057b975ce
  - 耗时：0.391 秒 / 游戏 0 分钟
- **23:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：3bb5f1aa44bc49b3acd2231b723caed2
  - 耗时：0.375 秒 / 游戏 0 分钟
- **23:30** Farm ❌ `plant_seeds`（item="Potato Seeds", count=20）
  - 结果：'Potato Seeds' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：26640ed3a14144aeb3c95c06ec3ef661
  - 耗时：0.391 秒 / 游戏 0 分钟
- **23:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：6f5c260ce1024811ab13ac1491708767
  - 耗时：10.797 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：63525 → 64075（+550g）
- 出货估值：550g　动作：45 个　失败：25 个
- 模型调用：7 次　tokens：87745
- 有效动作率：0.5　空转：3　熔断跳过：6
- 失败耗时：382.641 秒 / 游戏 490 分钟
- 最深矿层：90　新增矿层：0
- 今日完成里程碑：无新增或未统计

## ⚠️ 今日问题
> 复盘失败：model did not return valid JSON: {
  "analysis": "昨日核心失败是清包只存不卖导致空格仍为4，mine被拒；随后脚本反复重写，take宝石7次全失败、商店时间外goto、upgrade被路由成挖矿/超时。有效动作是Forest钓鱼4条、熔炉收铜锭、ship两次共550g。今日必须一次清包到≥15格（store+ship），铁矿石不足5就放弃炼铁，改为钓鱼攒食物+下矿80层挖铁，商店动作严格卡营业时间。",
  "strategy": "# 星露谷策略（Y5 春 15）\n\n## 长期目标\n当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 63525g 充足，但铁锭 0、铁矿石仅 
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 12:40 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 13:40 动作 `goto_location` 失败 @ Farm — could not reach (94,82); stopped at (40,57) 〔自动〕
- 14:10 动作 `upgrade_tool` 失败 @ Town — cancelled: HTTP timeout | 游戏消息: [hud] Bug Meat / [hud] Stone / [hud] Bug Meat / [hud] Iron Ore / [hud] Copper Ore / [hud] Coal / [hud] Bat Wing / [hud] Copper Ore 〔自动〕
- 21:20 动作 `goto_location` 失败 @ UndergroundMine39 — exit to SeedShop did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... (Open 9:00am - 9:00pm) | 游戏消息: [question]  / [dialogue] It's locked... (Open 9:00am - 9:00pm) 〔自动〕
- 22:20 动作 `open_shop` 失败 @ Town — can't open shop 'SeedShop' at Town; the counter is in SeedShop 〔自动〕
- 22:20 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 22:20 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 22:20 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 23:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 23:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 23:30 动作 `plant_seeds` 失败 @ Farm — 'Potato Seeds' not found in inventory 〔自动〕
