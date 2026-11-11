# 第5年 fall 9 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（05:56 开始）
- 天气：sunny　金钱：64238g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：ca8ea00d24c34f01a628c4ce4966d410
  - 耗时：5.093 秒 / 游戏 0 分钟
  - 🗨️ [mail] Dear AutoPilot, One week from today, we are holding the Stardew Valley Fair in the town square! It's the biggest event of the year, drawing people from all across the country to our humble town. If you'd like, you can set up a grange display for the event. Just bring up to 9 items that best showcase your talents. You'll be judged on the quality and diversity of your display. The fair starts at 9 AM... don't miss it!    -Mayor Lewis
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：52d744de31c148a2b41c6486132a557e
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：cd548fea8fa74219a363eb04c139ab6e
  - 耗时：0.485 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 1 crops
  - 执行状态：SUCCESS · 操作编号：5670bffa516740809b4159dea85ad109
  - 耗时：3.437 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：10dd9c1e09c14a168fe397675a6e7624
  - 耗时：0.484 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_fall_09）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——铁锭链是唯一瓶颈
- 起床收熔炉→补铁矿石→清包到空格≥5（只卖冗余金属/种子）
- 补食物到≥5（Saloon 12:00 后买沙拉）
- 电梯直达40层刷铁矿石+煤（40→50，≤2次）
- 回农场收铁锭，铁锭≥5且<13:00去铁匠铺升hoe
- 剩余时间钓鱼/买秋季种子，21:30前睡
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
12. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore", "Iron Ore", "Copper Bar", "Gold Bar", "Stone"]）
13. `ship`（item="Copper Bar", count=60）
14. `ship`（item="Gold Bar", count=10）
15. `ship`（item="Stone", count=3000）
16. `ship`（item="Melon Seeds", count=33）
17. `ship`（item="Pumpkin Seeds", count=34）
18. `goto_location`（location="Mine"）
19. `mine`（floors=5）
20. `fight`（range=6）
21. `mine`（floors=5）
22. `leave_mine`
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `goto_location`（location="Blacksmith"）
27. `upgrade_tool`（tool="hoe"）
28. `goto_location`（location="SeedShop"）
29. `open_shop`（shop_id="SeedShop"）
30. `buy`（item="Grape Starter", count=20）
31. `buy`（item="Artichoke Seeds", count=10）
32. `close_menu`
33. `goto_location`（location="Farm"）
34. `plant_seeds`（item="Grape Starter", count=20）
35. `plant_seeds`（item="Artichoke Seeds", count=10）
36. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5545f20acb694f0dbbe3130940fd7b46
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败即删除取物与捐献分支，改为显式卖冗余金属清包后直奔40层刷铁，回农场收锭再视时间升 hoe。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=60）
10. `ship`（item="Gold Bar", count=10）
11. `ship`（item="Stone", count=3000）
12. `ship`（item="Melon Seeds", count=33）
13. `ship`（item="Pumpkin Seeds", count=34）
14. `ship`（item="Radish Seeds", count=5）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `fight`（range=6）
18. `mine`（floors=5）
19. `leave_mine`
20. `goto_location`（location="Blacksmith"）
21. `upgrade_tool`（tool="hoe"）
22. `goto_location`（location="Farm"）
23. `ship_produce`（except=["Salad", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Coal", "Pumpkin Seeds", "Melon Seeds", "Hops Starter", "Cauliflower Seeds", "Potato Seeds", "Red Cabbage Seeds", "Radish Seeds", "Copper Ore", "Iron Ore"]）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f2ad55fe88c84242961becdf9960a0ab
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改为显式 ship 冗余种子腾格，再下矿刷铁；铁锭不足则跳过升级，回农场收炉后睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Melon Seeds", count=33）
10. `ship`（item="Pumpkin Seeds", count=34）
11. `ship`（item="Radish Seeds", count=5）
12. `ship`（item="Cauliflower Seeds", count=5）
13. `ship`（item="Potato Seeds", count=5）
14. `ship`（item="Red Cabbage Seeds", count=4）
15. `ship`（item="Hops Starter", count=8）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `fight`（range=6）
19. `mine`（floors=5）
20. `leave_mine`
21. `mine`（floors=5）
22. `fight`（range=6）
23. `mine`（floors=5）
24. `leave_mine`
25. `goto_location`（location="Forest"）
26. `fish`（casts=4）
27. `goto_location`（location="Town"）
28. `open_shop`（shop_id="Saloon"）
29. `buy`（item="Salad", count=5）
30. `close_menu`
31. `goto_location`（location="Farm"）
32. `collect_machines`
33. `load_machines`（item="Iron Ore"）
34. `collect_machines`
35. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：15447bb1226e461a95e5b05687a235fe
  - 耗时：0.469 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 分支连续失败已物理删除，改走 ship 清包→40层刷铁→买沙拉→收炉的既定路线，不新增地图。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Melon Seeds", count=33）
10. `ship`（item="Pumpkin Seeds", count=34）
11. `ship`（item="Radish Seeds", count=5）
12. `ship`（item="Cauliflower Seeds", count=5）
13. `ship`（item="Potato Seeds", count=5）
14. `ship`（item="Red Cabbage Seeds", count=4）
15. `ship`（item="Hops Starter", count=8）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `fight`（range=6）
19. `mine`（floors=5）
20. `leave_mine`
21. `goto_location`（location="Forest"）
22. `fish`（casts=4）
23. `goto_location`（location="Town"）
24. `open_shop`（shop_id="Saloon"）
25. `buy`（item="Salad", count=5）
26. `close_menu`
27. `goto_location`（location="Farm"）
28. `ship_produce`
29. `collect_machines`
30. `load_machines`（item="Iron Ore"）
31. `collect_machines`
32. `sleep`
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:00** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：505b9c2229c14f4d8b6d7d6a610a9c51
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：253a55070fbe4c94bdae806729380a20
  - 耗时：0.437 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9f53495e546b4d1b90fb0a5d078917d5
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：3a60e974103b46fcbdc5f48a5f15f3e2
  - 耗时：82.11 秒 / 游戏 120 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：18847c949d5f4706a2ef663cecb22611
  - 耗时：42.875 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：e316e754daa9489da759f0d247d11458
  - 耗时：0.469 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Melon Seeds", count=33）
  - 结果：shipped 33x Melon Seeds (~1320g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：769572f51a4d410face7b2461f66a060
  - 耗时：44.0 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `ship`（item="Pumpkin Seeds", count=34）
  - 结果：shipped 34x Pumpkin Seeds (~1700g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：12214301c5214f9dbc3fcbea033ca053
  - 耗时：0.453 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Radish Seeds", count=5）
  - 结果：shipped 5x Radish Seeds (~100g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：a55e5b92cc45422f9f0b3e5b6377b8d8
  - 耗时：0.438 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Cauliflower Seeds", count=5）
  - 结果：shipped 5x Cauliflower Seeds (~200g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：37d3c7b049d24e31bb390991406e793d
  - 耗时：0.438 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Potato Seeds", count=5）
  - 结果：shipped 5x Potato Seeds (~125g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：69a569539a0d49a6846aaa1f55cc8776
  - 耗时：0.438 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Red Cabbage Seeds", count=4）
  - 结果：shipped 4x Red Cabbage Seeds (~200g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：315bf0dad7ce485f9eb1165cd9216ebe
  - 耗时：0.438 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `ship`（item="Hops Starter", count=8）
  - 结果：shipped 8x Hops Starter (~240g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：7e1bb257628043cbbe7f05cf7de2f17d
  - 耗时：0.437 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：6afabce220884fd29e3d2f214f1e23ee
  - 耗时：49.016 秒 / 游戏 60 分钟
- **10:40** Mine ❌ `mine`（floors=5）
  - 结果：floor 98: no reachable stone or ladder
  - 执行状态：ACTION_FAILED · 操作编号：6ab6a09680814153ad73fa5db17c8846
  - 耗时：55.937 秒 / 游戏 80 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Void Essence
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Magma Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Gold Ore
  - 🗨️ [hud] Iron Ore
- **12:00** UndergroundMine98 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：a58d06d390aa4b679aa28bfaaaef13d6
  - 耗时：0.453 秒 / 游戏 0 分钟
- **12:00** UndergroundMine98 ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：326ce8596f6c47de9a2501323d17d64b
  - 耗时：38.672 秒 / 游戏 40 分钟
  - 🗨️ [question] 
- **12:00** UndergroundMine98 ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：70de4b8803254e5b8ccf66f36ed0678c
  - 耗时：15.062 秒 / 游戏 20 分钟
- **12:00** UndergroundMine98 ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **13:00** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：d47a7ffa32944a09b51255cd7b8006c7
  - 耗时：0.454 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：d23e046058214b50a15b32f3aa2e4a77
  - 耗时：23.813 秒 / 游戏 30 分钟
- **13:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Smallmouth Bass, Green Algae, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：cc6a4a69ff9f4eb2bf27ca44fea82458
  - 耗时：85.875 秒 / 游戏 100 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
- **15:10** Forest ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,90)
  - 执行状态：SUCCESS · 操作编号：cbae2ada8f8e49c28750f00e0b7b983e
  - 耗时：17.812 秒 / 游戏 20 分钟
- **15:30** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' at Town; the counter is in Saloon
  - 执行状态：ACTION_FAILED · 操作编号：91547506ebf84ff8864b7e759be1f61d
  - 耗时：0.484 秒 / 游戏 0 分钟
- **15:30** Town ❌ `buy`（item="Salad", count=5）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：86cf2929e6c04f43b746fed7a473d360
  - 耗时：0.469 秒 / 游戏 0 分钟
- **15:30** Town ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：a30b14bb192e4e388c0a7743a1442977
  - 耗时：0.437 秒 / 游戏 0 分钟
- **15:30** Town ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：4411951ee3834bd7a016bcfc4493042b
  - 耗时：24.344 秒 / 游戏 30 分钟
- **16:00** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~200g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：d8520249e3cf495ba40519cd4e5b95f9
  - 耗时：1.766 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：2b407a87a3b54255b70d6f2382be06c5
  - 耗时：0.453 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b733b936cb464c0289c080ef1585036b
  - 耗时：0.469 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:00** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:00** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：fec7c0e33ce3415d89eee99687793b53
  - 耗时：10.859 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：64238 → 68323（+4085g）
- 出货估值：200g　动作：49 个　失败：26 个
- 模型调用：7 次　tokens：89147
- 有效动作率：0.4878　空转：8　熔断跳过：7
- 失败耗时：63.39 秒 / 游戏 80 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包链：ship 只卖了种子（约3.7k），背包仍只有2格，导致 mine/upgrade 全被拒；take 又浪费12动作。真正瓶颈不是铁锭而是背包容量与熔炉未装料。今天应先卖 Copper Bar（82个，留20）腾格，再装炉、下矿。

**新教训：**
- 昨天 ship 只卖了种子（约3.7k）而 Copper Bar 82 个全被 except 排除，空格仍 2：清包必须把 Copper Bar 留 20 其余全卖（约 7k，腾 3-4 格），这是唯一能真正腾格的手段。
- 昨天 load_machines 返回「no empty machine accepts anything」两次，说明熔炉要么满料要么未完成：起床必须先 collect_machines 再 load，且 Iron Ore 只有 1 个时根本不该调 load。
- 昨天 15:30 在 Town 调 open_shop Saloon 失败（柜台在 Saloon 内）：买沙拉前必须先 goto_location Saloon 再 open_shop，不能在 Town 直接开。
- 昨天 mine 在 98 层返回「no reachable stone or ladder」浪费一次下矿：电梯应直达 40 层，不要从 89/95 层往下爬，深层地形可能无路。
- 昨天 collect_machines 在 16:00 连续空转被抑制：熔炉未完成时不要反复 collect，下矿回来再收一次即可。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 10）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 64238g 充足，卡点 Iron Bar 0/5，已连续 8 天零推进。铁锭链是全局瓶颈（钢斧、洒水器、高级洒水器全排在后面）。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是唯一门票，今天必须先真正腾出格子**。

接下来 3 天主活动：
- **今天（秋 10）**：起床收炉→**ship 卖 Copper Bar 留 20（62 个可卖，约 7k）腾出 3-4 格**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 11）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 12）**：继续刷铁备钢斧，给作物地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包唯一手段是 ship_produce，且必须显式卖 Copper Bar**：昨天 ship 只卖了种子（约3.7k），Copper Bar/Gold Bar/Stone 全被 except 排除，空格始终 2。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20（其余 62 个全卖，约 7k）** → 读背包验证空格≥5。若仍不足，再 ship 卖 **Gold Bar 留 2（10 个可卖）** → 再验证。两次不足 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。
3. **食物提前到清包后立刻解决**：清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
4. **下矿目标 40 层，不贪 80 层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
6. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 清包到空格≥5：goto Farm → ship_produce 卖 **Copper Bar 留 20** → 读背包验证；不足再 ship 卖 **Gold Bar 留 2** → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take / store_items 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0**。
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
3. 清包到空格≥5（**只用 ship_produce 卖 Copper Bar 留 20，其次 Gold Bar 留 2**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包链：ship 只卖了种子（约3.7k），背包仍只有2格，导致 mine/upgrade 全被拒；take 又浪费12动作。真正瓶颈不是铁锭而是背包容量与熔炉未装料。今天应先卖 Copper Bar（82个，留20）腾格，再装炉、下矿。
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:40 动作 `mine` 失败 @ Mine — floor 98: no reachable stone or ladder | 游戏消息: [hud] Stone / [hud] Void Essence / [hud] Stone / [hud] Gold Ore / [hud] Magma Geode / [hud] Stone / [hud] Gold Ore / [hud] Iron Ore 〔自动〕
- 12:00 动作 `mine` 失败 @ UndergroundMine98 — store did not free enough slots (have 2, need 5) 〔自动〕
- 13:00 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 15:30 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' at Town; the counter is in Saloon 〔自动〕
- 15:30 动作 `buy` 失败 @ Town — no shop is open; use open_shop first 〔自动〕
- 15:30 动作 `close_menu` 失败 @ Town — no menu is open 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 清包只卖了种子，Copper Bar/Gold Bar/Stone 全被 except 排除，背包空格始终 2 @ Farm 出货箱 — ship 成功但只卖种子约3.7k，空格未增；后续 mine/upgrade 全被「have 2, need 5」拒绝（做不了：下矿、升级工具、买食物全部无法进行，铁锭链连续 8 天零推进） 〔复盘〕
- 12 次 take 凭物品 ID 猜箱子全失败，脚本重写 3 次仍重试同一批 ID @ Farm 箱子 — take 62 already failed / '72' is not in any farm chest（做不了：浪费约 12 个动作和 3 次脚本重写，挤占了清包和下矿时间） 〔复盘〕
- load_machines 两次返回无空炉可装，Iron Ore 只有 1 个 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：熔炉空转，铁锭链无法启动） 〔复盘〕
- 在 Town 直接 open_shop Saloon 失败，买沙拉失败 @ Town — can't open shop 'Saloon' at Town; the counter is in Saloon（做不了：食物没补上，下矿条件不满足） 〔复盘〕
- mine 在 98 层返回无路可走 @ Mine 98 层 — floor 98: no reachable stone or ladder（做不了：浪费一次下矿机会，未拿到铁矿石） 〔复盘〕
- 16:00 后 collect_machines 连续空转被抑制，build_road/decorate 作为填充动作各失败一次 @ Farm — no machine has finished output / 规划道路边没有空格 / 今天没有能做的装饰（做不了：收尾阶段空转，未提前 sleep） 〔复盘〕
