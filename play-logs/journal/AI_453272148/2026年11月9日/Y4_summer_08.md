# 第4年 summer 8 日 — AI 游玩日志
（写入日期：2026年11月9日）

## 🌅 早上的计划（20:01 开始）
- 天气：sunny　金钱：17772g　体力：270/270

**执行脚本：**
1. `load_machines`
2. `load_machines`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：a menu is open (LlmSettingsMenu); handle it first (dialog_answer / dialog_advance / menu_click / close_menu)
  - 执行状态：NO_PROGRESS · 操作编号：d18094fd011f46768b340cd910c471b7
  - 耗时：10.188 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN

### 🔁 脚本重写：收尾
1. `sleep`
- **06:00** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：78ce2a888db9460b98b64c3ec1b0ced7
  - 耗时：0.266 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f3835a710f0a4ef0a974569a485bdee5
  - 耗时：0.25 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：366d0ecc0f2b410db2020636b1531d10
  - 耗时：18.984 秒 / 游戏 20 分钟
- **06:20** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 1 forage items
  - 执行状态：SUCCESS · 操作编号：155c98f3adcc4b63a2e26d24a94fbdeb
  - 耗时：21.547 秒 / 游戏 30 分钟
  - 🗨️ [hud] Spice Berry

### 🔁 脚本重写：重写#1：先收机器清背包，买饵后在Forest钓鱼补食物到5，再下矿拿铁矿，回农场炼铁浇水睡觉。
1. `fish`（casts=4）
2. `fish`（casts=4）
3. `goto_location`（location="Mountain"）
4. `open_shop`（shop_id="FishShop"）
5. `buy`（item="Bait", count=30）
6. `close_menu`
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `mine`（floors=5）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `store_items`
14. `ship_produce`
15. `load_machines`（item="Iron Ore"）
16. `water_crops`
17. `sleep`

## 🌅 早上的计划（20:03 开始）
- 天气：sunny　金钱：17772g　体力：270/270
- 里程碑：取回钢水壶并推进铁锭/下矿备料
- 清背包到≥8空格（存杂物、卖农产品）
- 补食物到≥5（Forest钓鱼，先买饵）
- 下矿40层以下拿铁矿石+煤（≤2次mine）
- 回农场装熔炉炼铁
- 浇水

**执行脚本：**
1. `load_machines`
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mountain"）
5. `open_shop`（shop_id="FishShop"）
6. `buy`（item="Bait", count=30）
7. `close_menu`
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `leave_mine`
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `store_items`
15. `ship_produce`
16. `load_machines`（item="Iron Ore"）
17. `water_crops`
18. `sleep`
- **07:50** Farm ❌ `lay_path`（tiles=[[58, 9], [58, 8], [58, 7], [58, 6], [59, 6], [60, 6], [61, 6], [62, 6], [63, 6], [64, 6], [65, 6], [66, 6], [67, 6], [68, 6], [69, 6], [70, 6], [71, 6], [72, 6], [73, 6], [74, 6], [75, 6], [76, 6], [77, 6], [78, 6]], item="Cobblestone Path", request_id="06b9a3a5a22a4a689e2a14cac431962f"）
  - 💭 (查询先前动作的实际结果，不重放)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：ACTION_FAILED · 操作编号：06b9a3a5a22a4a689e2a14cac431962f

### 🔁 脚本重写：重写#2：先取钢水壶并清背包，买饵后Forest钓鱼补食物到≥5，再下矿拿铁矿，回农场装熔炉炼铁并浇水后睡觉。
1. `collect_machines`
2. `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Geode", "Coffee Bean", "Maple Seed", "Rice Shoot", "Acorn", "Lost Axe", "Coal", "Stone"]）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`
5. `goto_location`（location="Mountain"）
6. `open_shop`（shop_id="FishShop"）
7. `buy`（item="Bait", count=40）
8. `close_menu`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `fish`（casts=4）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `load_machines`（item="Iron Ore"）
18. `water_crops`
19. `sleep`
- **07:50** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：b703e58f55c547dcbcefc60bec48ef06
  - 耗时：0.328 秒 / 游戏 0 分钟
- **07:50** Farm ✅ `store_items`（items=["Cobblestone Path", "Bamboo Pole", "Geode", "Coffee Bean", "Maple Seed", "Rice Shoot", "Acorn", "Lost Axe", "Coal", "Stone"]）
  - 结果：stored in chest at (74,15): 25x Cobblestone Path, 5x Geode, 1x Coal, 2x Maple Seed, 1x Acorn
  - 执行状态：SUCCESS · 操作编号：9ba21551d175468886d2810298b0c59f
  - 耗时：8.375 秒 / 游戏 10 分钟
- **08:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：8ff911d5e7d5406b9a8f6b44c9c0d710
  - 耗时：42.813 秒 / 游戏 60 分钟
- **09:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：60a67d6bae8e4bf9beb51bbb7f1908a6
  - 耗时：40.218 秒 / 游戏 40 分钟
- **09:40** Blacksmith ❌ `upgrade_tool`
  - 结果：nothing to collect; give 'tool' (axe/pickaxe/hoe/watering can) to start an upgrade
  - 执行状态：ACTION_FAILED · 操作编号：91a200d6ae9d4f68985544d14a1bf34d
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：钢水壶已在背包无需再取，按原路线买饵→Forest补食物→下矿→回农场炼铁浇水后睡觉。
1. `goto_location`（location="Mountain"）
2. `open_shop`（shop_id="FishShop"）
3. `buy`（item="Bait", count=40）
4. `close_menu`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `leave_mine`
12. `goto_location`（location="Farm"）
13. `store_items`（items=["Bamboo Pole", "Coffee Bean", "Rice Shoot", "Lost Axe", "Stone"]）
14. `load_machines`（item="Iron Ore"）
15. `water_crops`
16. `sleep`
- **09:40** Blacksmith ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：c9d60fb2a375438c97e45ba2b5f4ae1f
  - 耗时：29.422 秒 / 游戏 40 分钟
- **10:20** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：d5b78b6c8726409e9c58150906b29552
  - 耗时：0.297 秒 / 游戏 0 分钟
- **10:20** Mountain ❌ `buy`（item="Bait", count=40）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：e74710ee943d4b92be7a10851aafe7c5
  - 耗时：0.282 秒 / 游戏 0 分钟
- **10:20** Mountain ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：903876ff2da14508a23e73f33ab0fb5f
  - 耗时：0.266 秒 / 游戏 0 分钟
- **10:20** Mountain ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：a039e7adef944fd1a8c46ba54594af3d
  - 耗时：40.047 秒 / 游戏 50 分钟
  - 🗨️ [hud] A Chub frenzy has 
begun in the 
mountains. 
- **11:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Sunfish, Green Algae, Pike, Sunfish)
  - 执行状态：SUCCESS · 操作编号：58755036eb29409ca17a80a9cbe76523
  - 耗时：87.0 秒 / 游戏 90 分钟
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike

### 🔁 脚本重写：重写#1：先收机器、清背包、取钢水壶，再钓鱼补食物到5后下矿拿铁矿，回农场炼铁并落地洒水器，最后睡觉。
1. `collect_machines`
2. `store_items`
3. `craft`（item="Sprinkler", count=3）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Mine"）
10. `mine`（floors=3）
11. `mine`（floors=3）
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `place`（item="Sprinkler"）
15. `water_crops`
16. `sleep`

## 🌅 早上的计划（20:16 开始）
- 天气：sunny　金钱：17772g　体力：270/270
- 里程碑：工具按档升级——取回钢水壶，评估钢斧/钢镐
- 清背包到≥8空格（存Cobblestone Path/Geode/Bamboo Pole等杂物）
- 补食物到≥5（Forest钓鱼）
- 下矿40层以下拿铁矿石+煤
- 回农场炼铁、洒水器落地

**执行脚本：**
1. `load_machines`
2. `collect_machines`
3. `store_items`
4. `craft`（item="Sprinkler", count=3）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Mine"）
11. `mine`（floors=3）
12. `mine`（floors=3）
13. `goto_location`（location="Farm"）
14. `load_machines`（item="Iron Ore"）
15. `place`（item="Sprinkler"）
16. `water_crops`
17. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Spice Berry -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：e92b85b6bede49e58a8c784a0dfcb280
  - 耗时：16.796 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：87a606a81d414808bf7a7d0f99cd5305
  - 耗时：0.265 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：2bcc7dfa69e84dc1aaea0859b8d9f747
  - 耗时：17.703 秒 / 游戏 20 分钟
- **06:40** Farm ✅ `craft`（item="Sprinkler", count=3）
  - 结果：crafted 3x Sprinkler
  - 执行状态：SUCCESS · 操作编号：36bcd9fcd63c47029c23555fb7160cd6
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 8:40 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：377d5c9e43544a09b4596d5b4b9f979d
  - 耗时：84.406 秒 / 游戏 120 分钟
- **08:40** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：3091ffdcafe94130bbcbbdc9245cc225
  - 耗时：14.797 秒 / 游戏 20 分钟
- **09:00** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：520c5925412c4a3da9d1c2bb14079bba
  - 耗时：40.344 秒 / 游戏 40 分钟
- **09:40** Blacksmith ❌ `upgrade_tool`
  - 结果：nothing to collect; give 'tool' (axe/pickaxe/hoe/watering can) to start an upgrade
  - 执行状态：ACTION_FAILED · 操作编号：c00a6d4295e2452c93c95cefddb52555
  - 耗时：0.281 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：钢水壶已在背包无需取回，改为清背包→钓鱼补食物→下矿炼铁，保留原路线顺序
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Mine"）
5. `mine`（floors=3）
6. `mine`（floors=3）
7. `goto_location`（location="Farm"）
8. `store_items`（items=["Cobblestone Path", "Geode", "Bamboo Pole", "Lost Axe", "Maple Seed", "Acorn", "Rice Shoot", "Coffee Bean"]）
9. `load_machines`（item="Iron Ore"）
10. `place`（item="Sprinkler"）
11. `water_crops`
12. `sleep`
- **09:40** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：c3c9affdd2a940a08c91195da45d0abb
  - 耗时：26.562 秒 / 游戏 40 分钟
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Broken CD, Chub, Pike)
  - 执行状态：SUCCESS · 操作编号：48abd00ac60140a596e3ce255a94d141
  - 耗时：84.5 秒 / 游戏 80 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Broken CD
  - 🗨️ [hud] Chub
- **11:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Chub, River Jelly, Pike)
  - 执行状态：SUCCESS · 操作编号：7633c6129e8d4e7baa4a97930c736317
  - 耗时：105.219 秒 / 游戏 110 分钟
  - 🗨️ [hud] Chub
- **13:30** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：81d90eb72a9d43dc890cd5c3fc1fc695
  - 耗时：64.672 秒 / 游戏 80 分钟
- **14:50** Mine ❌ `mine`（floors=3）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：09cdb8dced874b04befba35d4275046f
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0空格导致下矿被拒，先出矿回农场存杂物清到≥8格，装炉炼铁后重新下矿，回来再装炉并放洒水器。
1. `leave_mine`
2. `mine`（floors=3）
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Cobblestone Path", "Geode", "Bamboo Pole", "Lost Axe", "Maple Seed", "Acorn", "Rice Shoot", "Coffee Bean", "Broken CD"]）
5. `load_machines`（item="Iron Ore"）
6. `load_machines`（item="Iron Ore"）
7. `place`（item="Sprinkler"）
8. `water_crops`
9. `sleep`
- **14:50** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：09ffc8a1558344a1b6edd1f0b27cf4c5
  - 耗时：0.265 秒 / 游戏 0 分钟
- **14:50** Mine ❌ `mine`（floors=3）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：acd415265f7a477abe08ea3694707321
  - 耗时：0.266 秒 / 游戏 0 分钟
- **14:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：d80bcaa89b4040e48275928cdb3b0159
  - 耗时：33.609 秒 / 游戏 40 分钟
- **15:30** Farm ✅ `store_items`（items=["Cobblestone Path", "Geode", "Bamboo Pole", "Lost Axe", "Maple Seed", "Acorn", "Rice Shoot", "Coffee Bean", "Broken CD"]）
  - 结果：stored in chest at (74,15): 25x Cobblestone Path, 5x Geode, 2x Maple Seed, 1x Broken CD, 1x Acorn
  - 执行状态：SUCCESS · 操作编号：b44a6da9a60a4c3ea37cfad5f6143ce2
  - 耗时：14.968 秒 / 游戏 20 分钟
- **15:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：8245e4941289480da56c7139a510b26a
  - 耗时：0.297 秒 / 游戏 0 分钟
- **15:50** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **15:50** Farm ✅ `place`（item="Sprinkler"）
  - 结果：placed Sprinkler at (52,15)
  - 执行状态：SUCCESS · 操作编号：bec44457266349a0a69ad4dc2e86544c
  - 耗时：10.375 秒 / 游戏 20 分钟
- **16:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：9f916045b4ec4dd6973c611a3b2df47e
  - 耗时：0.281 秒 / 游戏 0 分钟
- **16:10** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：9d250b3559cd4560a784b9033de99e05
  - 耗时：0.282 秒 / 游戏 0 分钟
- **16:10** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：623ca469edf74806a39d29000650b793
  - 耗时：0.266 秒 / 游戏 0 分钟
- **16:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：9b371b9c932446ff9c8eaa817b2b9840
  - 耗时：3.687 秒 / 游戏 0 分钟
- **16:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5fb8d94dc1ac4a4d8ccb2cbe362d2264
  - 耗时：15.5 秒 / 游戏 20 分钟
- **16:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:30 pm
  - 执行状态：SUCCESS · 操作编号：fc3cffdb36654aafa663fb5ec33ccd20
  - 耗时：82.656 秒 / 游戏 120 分钟
- **18:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：b16ba451f91e419e9c52d4b08ba5a48d
  - 耗时：12.797 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：17772 → 17772（+0g）
- 出货估值：0g　动作：28 个　失败：11 个
- 模型调用：3 次　tokens：35787
- 有效动作率：0.56　空转：7　熔断跳过：1
- 失败耗时：21.437 秒 / 游戏 20 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天3座洒水器已造好并放下1个，但升级工具时没带工具（upgrade_tool 需传 tool 参数），下矿因背包空格不足被拒两次，随后又用 build_road/decorate/wait 空转约3小时。核心问题：升级动作参数缺失、清背包不彻底、失败后没有立即转产。

**新教训：**
- upgrade_tool 不带 tool 参数必返回「nothing to collect; give 'tool'」——调用时必须传 tool=axe/pickaxe/hoe/watering can，否则永远无法开始升级。
- 昨天清背包只清到 5 空格仍被 mine 拒（need at least 5 free slots 实际要留余量）：store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- build_road 返回「24 skipped: blocked by trees/crops/objects」——农场未清障前铺路必然失败，脚本层应完全禁用 build_road，直到农场清出空地。
- wait(filler) 昨天浪费 2 小时游戏时间：主活动做完应立即 sleep 或转钓鱼，禁止用 wait 填充到固定时间点。
- 洒水器已 craft 3 个但只 place 1 个，说明 place 分支没有循环处理剩余数量：craft 后应逐个 place 直到全部落地或失败 2 次。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏09）

## 长期目标
当前里程碑：**工具按档升级**——钢水壶已取回，下一档是钢斧（5000g+5铁锭）或钢镐。材料现状：Iron Bar 0、Iron Ore 2、Coal 12、Copper Bar 71、Stone 2424；现金 17772g（升级费够）。**差 5 铁锭**，即需再拿 25 铁矿石 + 煤。
并行里程碑：**洒水器×4 落地**（已 craft 3 个、已 place 1 个，还剩 2 个待放）；**下矿装备**——Silver Saber 最多安全下到 79 层，40 层以下出铁矿石。
接下来 3 天主活动：
- **今天（夏09）**：清背包到 ≥8 空格 → 补食物到 ≥5 → 下矿 40-79 层拿铁矿石+煤（≤2 次 mine）→ 回农场装炉炼铁 → 剩余洒水器落地。
- **明天（夏10）**：铁锭够 5 就升级钢斧（一次一件，upgrade_tool 必须带 tool=axe）；不够继续下矿。
- **后天（夏11）**：钢斧到手后转钢镐；洒水器全部落地后停止手动浇水。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **起床收机器（1 次）**：`collect_machines` 1 次；返回空当天永久跳过。
2. **清背包到 ≥8 空格（硬门槛）**：`store_items` 一次把 Cobblestone Path、Bamboo Pole、Broken CD、Geode、Maple Seed、Acorn、Rice Shoot、Coffee Bean、多余矿石全部存箱；**必须清到 ≥8 空格**。空格<8 禁止下矿。
3. **补食物到 ≥5（硬门槛）**：背包回血食物<5 时，去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到的鱼留着吃；**不去 Saloon，不在 Farm 池塘钓**。Bait=0 时先顺路去 Mountain 的 FishShop 买 20-40 个 Bait（5g 一个，16:30 前）。食物≥5 才允许下矿。
4. **下矿（主活动）**：食物≥5、空格≥8 才 `goto_location` Mine → `mine` 目标 40-79 层拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时；**load 前先确认背包有 Iron Ore**，没有就跳过）。返回 busy/no empty 即当天永久跳过。
6. **洒水器落地**：剩余 2 个洒水器在农场已清空的地块 `place`。**place 前先确认目标地块无作物/树/杂物**；若 place 返回 blocked，换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金<700g 去 Forest 河边 `fish` ≤2 轮，钓到 ≥700g 或连续 2 轮垃圾即停。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **今天铁锭优先于一切**：铁锭不到 5，钓鱼（补食物除外）、装饰、铺路、社交全部让位；下矿是今天唯一主活动。
- **upgrade_tool 必须带 tool 参数**：昨天 `upgrade_tool` 返回「nothing to collect; give 'tool'」——调用时必须传 `tool=axe`（或 pickaxe/hoe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **下矿前空格≥8 是硬门槛**：store_items 必须清到 ≥8 空格再 goto Mine，清完立刻去矿洞，不要先跑去别处。
- **下矿前食物≥5 是硬门槛**：食物<5 时 mine 会停在 39 层，铁矿石零产出，等于白跑。**今天必须先钓鱼补到 ≥5 再下矿。**
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。**load 前先确认背包有 Iron Ore/Copper Ore。**
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **mine 超时/被拒熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 禁用**：补食物一律钓鱼吃鱼，不去 Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **洒水器 place 今天允许**：剩余 2 个，place 前必须确认目标地块无作物/树/杂物；失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **工具升级期间禁下矿**：镐在升级中时 `mine` 脚本层直接禁用；水壶升级不影响下矿。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥8；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 清背包到 ≥8 空格
3. 补食物到 ≥5（钓鱼吃鱼，不去 Saloon；Bait=0 先买饵）
4. 下矿 40-79 层拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停）
5. 熔炉装铁（下矿后只试 1 次，炉空才装，load 前确认背包有矿石）
6. 剩余 2 个洒水器落地（place 失败 1 次换空地再试 1 次）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天3座洒水器已造好并放下1个，但升级工具时没带工具（upgrade_tool 需传 tool 参数），下矿因背包空格不足被拒两次，随后又用 build_road/decorate/wait 空转约3小时。核心问题：升级动作参数缺失、清背包不彻底、失败后没有立即转产。
- 06:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 09:40 动作 `upgrade_tool` 失败 @ Blacksmith — nothing to collect; give 'tool' (axe/pickaxe/hoe/watering can) to start an upgrade 〔自动〕
- 14:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 14:50 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 14:50 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:50 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 升级工具时没带工具参数，动作直接失败 @ Blacksmith — upgrade_tool -> FAIL: nothing to collect; give 'tool' (axe/pickaxe/hoe/watering can) to start an upgrade（做不了：钢斧/钢镐升级无法开始，里程碑停滞） 〔复盘〕
- 下矿前背包空格不足，两次 mine 被拒 @ Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：当天零铁矿石产出，铁锭凑不够 5） 〔复盘〕
- 清背包只清到 5 空格，仍不够下矿门槛 @ Farm 箱子旁 — store_items 后 mine 仍报 need at least 5 free slots（做不了：下矿被拒，浪费两次动作） 〔复盘〕
- 铺路连续失败，24 块 Cobblestone Path 全部被挡 @ Farm — build_road -> laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)（做不了：铺路目标无法推进，且浪费动作） 〔复盘〕
- 装饰动作无材料可做 @ Farm — decorate -> 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：装饰分支空转） 〔复盘〕
- 熔炉忙时反复 load 无效 @ Farm — load_machines -> no empty machine accepts that, and the rest are busy; repeated ineffective action suppressed（做不了：铁矿石无法装炉，铁锭产出延迟） 〔复盘〕
- 用 wait 填充时间，浪费约 2 小时游戏时间 @ Farm — wait -> OK: waited until 6:30 pm (filler: true)（做不了：本可用于钓鱼或下矿的时间被浪费） 〔复盘〕
- 洒水器 craft 3 个只 place 1 个，剩余 2 个未落地 @ Farm — place 只执行 1 次，未循环处理剩余数量（做不了：手动浇水负担未完全解除） 〔复盘〕
