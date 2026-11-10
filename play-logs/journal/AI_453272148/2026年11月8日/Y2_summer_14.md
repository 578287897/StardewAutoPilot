# 第2年 summer 14 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（03:58 开始）
- 天气：sunny　金钱：5401g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a0940dee33ab4117a0557414b7fce74c
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：149d79d792bf4073a33554af7d67d86e
  - 耗时：3.204 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：0a80a9c33c0e410a91b85ebccaefccb4
  - 耗时：2.969 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_14）准备的脚本
- 里程碑：工具按档升级——钢水壶（5000g+5铁锭）
- 收熔炉铁锭、装铁矿，凑铁锭
- 清背包到≥7空格，补食物到≥3
- 下矿40层以下拿铁矿石+煤（≤2次mine）
- 回农场装铁矿、浇水
- 现金够就升钢水壶，否则钓鱼补钱
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Cobblestone Path"]）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `load_machines`（item="Iron Ore"）
11. `water_crops`
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="watering can"）
14. `goto_location`（location="Mountain"）
15. `open_shop`（shop_id="FishShop"）
16. `buy`（item="Bait", count=20）
17. `close_menu`
18. `goto_location`（location="Forest"）
19. `fish`（casts=4）
20. `fish`（casts=4）
21. `sleep`
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：inventory full after harvesting 5
  - 执行状态：SUCCESS · 操作编号：860506fc8e844efb9a63525a7f6a95b9
  - 耗时：11.719 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Inventory Full
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 11 crops
  - 执行状态：SUCCESS · 操作编号：505196bf8cd24417854b9ac7a9eb054d
  - 耗时：7.515 秒 / 游戏 10 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 6 stacks worth ~792g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：bb2a97ce25f349e7bfab470d47a0e0cf
  - 耗时：6.266 秒 / 游戏 10 分钟
- **06:30** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：9e642fee19024f949df63c5fc93c382c
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 未解锁跳过；按原路线收炉装矿、清背包下矿、买鱼饵、回农场装铁浇水后睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Silver Saber"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Mountain"）
9. `open_shop`（shop_id="FishShop"）
10. `buy`（item="Bait", count=20）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `water_crops`
15. `sleep`
- **06:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c6603a4fc8404993abc8ccd3f6279622
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：5590b3e6b93d4c16bf4dd57219e0bb41
  - 耗时：0.157 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `store_items`（items=["Geode", "Trash", "Broken CD", "Broken Glasses", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Silver Saber"]）
  - 结果：stored in chest at (74,15): 16x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：2d7b9a9bdfbe41f79b6289e1220ba7bf
  - 耗时：1.016 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：75d7bbfa73d1450fb0c74d4fafe1b92e
  - 耗时：46.125 秒 / 游戏 60 分钟
- **07:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 19 (4 floors down, 81 stones broken); stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：54bb34416f544734bca4205047231547
  - 耗时：81.172 秒 / 游戏 110 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
- **09:20** UndergroundMine19 ✅ `mine`（floors=5）
  - 结果：mined from floor 19 to 19 (0 floors down, 0 stones broken); stopped at floor 19: only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 执行状态：SUCCESS · 操作编号：57d9f70ed1364ed79ee6f52a54f432e0
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:20** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：43f7cca610d64b488ef9c6665b496da3
  - 耗时：1.859 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **09:20** Mine ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (54,5)
  - 执行状态：SUCCESS · 操作编号：f101c863a6284d92848b122a8fa6501c
  - 耗时：3.609 秒 / 游戏 0 分钟
- **09:20** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：9d877beeb8574364acba9c2366673f6a
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：鱼店在Mountain但柜台未开（周六无销售），改用Bug Meat自制鱼饵，直接下矿补铁锭，回农场装炉浇水后睡觉。
1. `craft`（item="Bait", count=20）
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `leave_mine`
6. `goto_location`（location="Farm"）
7. `load_machines`（item="Iron Ore"）
8. `water_crops`
9. `sleep`
- **09:20** Mountain ✅ `craft`（item="Bait", count=20）
  - 结果：crafted 20x Bait
  - 执行状态：SUCCESS · 操作编号：685f6477c2434dfd9e15e73d528b26c5
  - 耗时：0.157 秒 / 游戏 0 分钟
- **09:20** Mountain ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：dee0de229d0a49f3be378929c9351054
  - 耗时：1.437 秒 / 游戏 0 分钟
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：a883cf2985194620ac21b8137c16a38e
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因背包空格不足失败，先 store_items 清格再下矿，其余路线不变。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Geode", "Amethyst", "Dwarf Scroll I", "Stone", "Copper Ore"]）
5. `load_machines`（item="Iron Ore"）
6. `water_crops`
7. `sleep`
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：941db8c462f14c79aa4833e070964d27
  - 耗时：0.125 秒 / 游戏 0 分钟
- **09:20** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：ec22b655ee704bdc8abf1617639ca22f
  - 耗时：0.141 秒 / 游戏 0 分钟
- **09:20** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：ef8a0d536a8844d588837ef7e3e04ed7
  - 耗时：33.515 秒 / 游戏 40 分钟
- **10:00** Farm ✅ `store_items`（items=["Geode", "Amethyst", "Dwarf Scroll I", "Stone", "Copper Ore"]）
  - 结果：stored in chest at (74,15): 1x Amethyst, 1x Geode
  - 执行状态：SUCCESS · 操作编号：1df536e03dda4fbca2052e2952fb0b87
  - 耗时：12.36 秒 / 游戏 20 分钟
- **10:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：03bdb3db118c49cfab0963cbc8fd47cd
  - 耗时：0.14 秒 / 游戏 0 分钟
- **10:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：4c0cf905ed9e4611817cee70463928be
  - 耗时：0.172 秒 / 游戏 0 分钟
- **10:20** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
  - 执行状态：SUCCESS · 操作编号：a8cc465ecc8f40a98b97e5d173cae863
  - 耗时：18.406 秒 / 游戏 20 分钟
- **10:40** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：2370751228b34928ad68b2cf57eb4081
  - 耗时：0.188 秒 / 游戏 0 分钟
- **10:40** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：6117a099ba754446a57d0db1f86ab50f
  - 耗时：0.172 秒 / 游戏 0 分钟
- **10:40** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：357ff5ceb33044c5820c79ef29aa8d1a
  - 耗时：7.781 秒 / 游戏 10 分钟
- **10:50** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a3243bff81134747ac7596840455ec6d
  - 耗时：0.125 秒 / 游戏 0 分钟
- **10:50** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：af9a6b876a004780a3f3cf53610a2a12
  - 耗时：12.641 秒 / 游戏 20 分钟
- **11:10** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace, Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：a05f25b3f44f4726bf13cea1fccc132f
  - 耗时：16.797 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **11:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：565a5b2726d6405eba0b380cfa632699
  - 耗时：0.172 秒 / 游戏 0 分钟
- **11:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：8bd982dbb76d4ae49f8817951b3092b2
  - 耗时：29.422 秒 / 游戏 40 分钟
- **12:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **12:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Trash, Broken Glasses, Trash)
  - 执行状态：SUCCESS · 操作编号：17dbc6a0733248dc890e0b0fa750b610
  - 耗时：21.344 秒 / 游戏 30 分钟
  - 🗨️ [hud] Trash
  - 🗨️ [hud] Broken Glasses
- **12:40** Farm ✅ `ship`（item="Trash", count=2）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 2x Trash (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：1ff1d66453c64f00937580a3997c5f7d
  - 耗时：15.157 秒 / 游戏 20 分钟
- **12:40** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：efad09f1187148c5966aa91e77a8b9dc
  - 耗时：0.172 秒 / 游戏 0 分钟
- **13:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fde0430ea56f4928ba9bb073866f85fb
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:00** Farm ✅ `build_road`
  - 结果：laid 8 Cobblestone Path tiles (0 already done, 16 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：db9a855a0fd141438828bb8fa8010135
  - 耗时：39.671 秒 / 游戏 60 分钟
- **14:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：a7bea99236f5458cb17cdddc64af6eb8
  - 耗时：0.172 秒 / 游戏 0 分钟
- **14:00** Farm ✅ `craft`（item="Cobblestone Path", count=8）
  - 💭 (做 8 块 Cobblestone Path 用来铺路)
  - 结果：crafted 8x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：d10b6ae7906240f5a0a7b020770fd5e8
  - 耗时：0.203 秒 / 游戏 0 分钟
- **14:00** Farm ✅ `build_road`
  - 结果：laid 8 Cobblestone Path tiles (0 already done, 16 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：465ce4bdd91449b3a2e5d37da8e846cc
  - 耗时：9.688 秒 / 游戏 10 分钟
- **14:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ee034197724444e08d380d8dbae37193
  - 耗时：0.109 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `craft`（item="Cobblestone Path", count=8）
  - 💭 (做 8 块 Cobblestone Path 用来铺路)
  - 结果：crafted 8x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：04aca919f27f454ba96624ffc0195e9e
  - 耗时：0.235 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `build_road`
  - 结果：laid 2 Cobblestone Path tiles (0 already done, 22 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：0a3633e2af3d4a6bad085884987cbd93
  - 耗时：7.75 秒 / 游戏 10 分钟
- **14:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：d0747cb7afe34c0eb8774de4664bdb29
  - 耗时：0.093 秒 / 游戏 0 分钟
- **14:20** Farm ✅ `craft`（item="Cobblestone Path", count=2）
  - 💭 (做 2 块 Cobblestone Path 用来铺路)
  - 结果：crafted 2x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：140190259d4847fb88c9e62a9a620aad
  - 耗时：0.11 秒 / 游戏 0 分钟
- **14:20** Farm ✅ `build_road`
  - 结果：laid 3 Cobblestone Path tiles (0 already done, 21 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：06ac881aaee94e89a393f2f57a2c7e70
  - 耗时：30.797 秒 / 游戏 40 分钟
- **15:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：104d6ace60de4509b9ad3fba90e387db
  - 耗时：0.125 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `craft`（item="Cobblestone Path", count=3）
  - 💭 (做 3 块 Cobblestone Path 用来铺路)
  - 结果：crafted 3x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：35a30d0f85e240e5a1b271048da44d57
  - 耗时：0.157 秒 / 游戏 0 分钟
- **15:00** Farm ✅ `build_road`
  - 结果：laid 2 Cobblestone Path tiles (0 already done, 22 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：de46d50eb9c442f98948d776fea70126
  - 耗时：8.703 秒 / 游戏 10 分钟
- **15:10** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ca9a399141eb49e49ae8c0db89a78028
  - 耗时：0.188 秒 / 游戏 0 分钟
- **15:10** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 7 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：b51f71444a4e41db8681f99d4de1ade3
  - 耗时：0.515 秒 / 游戏 0 分钟
- **15:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **15:10** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Soggy Newspaper, Driftwood, Joja Cola)
  - 执行状态：SUCCESS · 操作编号：7f24147d41c0470d863f3a38957667a1
  - 耗时：45.203 秒 / 游戏 60 分钟
  - 🗨️ [hud] Soggy Newspaper
  - 🗨️ [hud] Driftwood
- **16:10** Farm ✅ `ship`（item="Soggy Newspaper", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Soggy Newspaper (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：b131b982be864511a824f1478d48a812
  - 耗时：16.672 秒 / 游戏 30 分钟
- **16:10** Farm ✅ `ship`（item="Driftwood", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Driftwood (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：0aa2566adf364265acb87ac4922011b5
  - 耗时：0.172 秒 / 游戏 0 分钟
- **16:10** Farm ✅ `ship`（item="Joja Cola", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Joja Cola (~25g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：cd0cfaa2a5804659860b068a70a605be
  - 耗时：0.156 秒 / 游戏 0 分钟
- **16:40** Farm ✅ `wait`（minutes=20, filler=true）
  - 结果：waited until 5:00 pm
  - 执行状态：SUCCESS · 操作编号：16f5b67d458d4edfb8ef2ff0dc9ad7fb
  - 耗时：12.828 秒 / 游戏 20 分钟
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c0b5bdd4264949a08b17068258e6fae9
  - 耗时：6.922 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：5401 → 6218（+817g）
- 出货估值：792g　动作：63 个　失败：26 个
- 模型调用：5 次　tokens：62815
- 有效动作率：0.5574　空转：18　熔断跳过：0
- 失败耗时：53.188 秒 / 游戏 70 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵

## 🧠 夜间复盘
昨天63动作26失败，主因是熔炉load空转10次、铺路/装饰11次无效、洒水器仍未落地；真正推进为零：铁锭仍1、钢水壶差4铁锭、现金5401g差升级费。钓鱼只钓到垃圾，说明地点/时段选错。今天必须把洒水器落地+下矿拿铁作为唯一主线，砍掉所有装饰/铺路/轮询分支。

**新教训：**
- 钓鱼在 Farm 池塘/河边连续两轮只出 Trash、Broken Glasses、Soggy Newspaper，说明该点位垃圾率高：现金兜底应直接去 Forest 河边或 Mountain 湖，Farm 池塘当天不再钓。
- 昨天 10 次 load_machines 失败中有 8 次是「no empty machine accepts anything」——背包和箱子都没有可装矿石时调用 load 必然失败：load 前必须先确认背包有 Iron Ore/Copper Ore，没有就跳过。
- 铺路 craft 出的 Cobblestone Path 在树木/作物未清的地块上 24 格全部 skipped：农场未整理前 craft 铺路材料本身就是浪费，craft 前先确认目标地块已清空。
- 洒水器连续三天 craft 成功却 place 失败，根因是 hoe 清格坐标不在规划分区内：place 前必须先读分区坐标，hoe 只清分区内格子，否则清多少都无效。
- 现金 5401g 已够钢水壶，唯一卡点是铁锭：今天所有非下矿动作（钓鱼、装饰、铺路）都应让位于下矿拿铁，铁锭不到 5 不碰其他分支。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏15）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 5401g（够钱），铁锭 1、Iron Ore 3、Coal 16，**差 4 铁锭**，这是唯一卡点。
并行里程碑：**洒水器×4 落地**——已 craft 但连续三天没放下，体力被手动浇水吃掉，直接拖慢下矿。
之后：**下矿装备**（食物≥5、武器升级）→ 安全下 40 层以下稳定拿铁；再往后 **洒水器铺满 + 加工品（保存罐）**。
接下来 3 天主活动：
- **今天（夏15）**：① 洒水器落地（hoe 清格 + place，最多 6 次）；② 清背包≥7 空格；③ 补食物到 ≥5（Saloon 沙拉或钓鱼吃鱼）；④ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，目标 5+ 铁矿石）；⑤ 回农场 load 铁矿 1 次；⑥ 现金<700g 才钓鱼；⑦ 22:00 前 sleep。
- **明天（夏16）**：收铁锭；铁锭≥5 且现金≥5000g 立刻升钢水壶；不够继续下矿补铁。
- **后天（夏17）**：洒水器铺满耕地，下矿补铁/煤，准备夏末作物。

## 每日固定流程（按顺序，失败一次即跳下一步，绝不重写脚本重跑已完成动作）
1. **洒水器 place（第一优先，最多 6 次）**：先读背包确认有 Sprinkler；`place` 到耕地。返回「分区无空位」→ `use_tool` hoe 清**规划分区坐标内**一格耕地 → 重新 place 同一格。连续 3 次仍失败则记坐标，当天不再 place，转第 2 步。**hoe 前先读分区坐标，不在地图外乱清。**
2. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 3 步。
3. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore（不足则 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
4. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；空格<7 禁止下矿。
5. **补食物到 ≥5**：背包回血食物<5 且现金≥400g 时，**12:10 后**去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃，改钓鱼吃鱼补食物。
6. **下矿（主活动）**：食物≥5、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。**不在 Farm 池塘连钓。**
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
10. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
11. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格**规划分区内**的耕地再 place 同一格，最多 6 次；hoe 后 place 仍失败说明坐标不在分区内，先读分区坐标再清。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥7**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<7 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图，不在 Beach；去 Beach 会因节日锁门或位置错误失败。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续三天铺路/装饰浪费 20+ 动作，全部失败或低效；农场未整理前完全禁用。
- **buy 只在 open_shop 后**：close_menu 后不再 buy；一次 open_shop 只对应一轮 buy。
- **升级前先查状态**：`upgrade_tool` 前先看里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。
- **工具升级期间禁下矿**：镐/水壶在升级中（2 天）时，`mine` 与 `water_crops` 脚本层直接禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **禁止「固定做这个到 X 点」分支**：任何分支做完后若下一步失败，立即转钓鱼或提前 sleep，绝不固定时段空转。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **下矿背包管理**：下矿前空格≥7；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. hoe 清格并 place 4 个洒水器（今天第一件事，最多 6 次 place）
2. collect 熔炉取锭（仅 1 次，空即跳第 3 步）
3. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
4. 清背包到 ≥7 空格
5. 补食物到 ≥5（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
6. 下矿 40 层以下拿铁矿石+煤（食物≥5、空格≥7 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
11. 社交（仅顺路）
12. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天63动作26失败，主因是熔炉load空转10次、铺路/装饰11次无效、洒水器仍未落地；真正推进为零：铁锭仍1、钢水壶差4铁锭、现金5401g差升级费。钓鱼只钓到垃圾，说明地点/时段选错。今天必须把洒水器落地+下矿拿铁作为唯一主线，砍掉所有装饰/铺路/轮询分支。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:30 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:20 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:20 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 10:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 10:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 10:40 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 10:50 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 10:50 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 11:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 11:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 13:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 15:10 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 7 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 熔炉 load 反复失败，全天 10 次「no empty machine accepts anything」，铁锭零产出 @ Farm 熔炉 — no empty machine accepts anything in the backpack or the farm chests（做不了：钢水壶差 4 铁锭，里程碑原地踏步） 〔复盘〕
- 洒水器已 craft 但连续三天没放下，体力仍被手动浇水吃掉 @ Farm 耕地 — place 返回「分区无空位」，hoe 清格后仍失败（做不了：无法解放体力去下矿，洒水器里程碑停滞） 〔复盘〕
- 铺路/装饰分支空转 11 次，全部失败或低效 @ Farm — laid 0 Cobblestone Path tiles (blocked by trees/crops/objects)；今天没有能做的装饰（做不了：浪费 14:00-16:40 黄金时段，本可用于下矿） 〔复盘〕
- 钓鱼两轮只钓到垃圾，现金兜底无效 @ Farm 池塘/河边 — caught 3 (Trash, Broken Glasses, Trash)；caught 3 (Soggy Newspaper, Driftwood, Joja Cola)（做不了：没补到现金，也没补到食物） 〔复盘〕
- 计划下矿拿铁但全天 mine 只调 4 次且 2 次因空格不足失败 @ Mine — need at least 5 free backpack slots before mining; store_items first（做不了：没拿到铁矿石，铁锭无法增加） 〔复盘〕
- 食物只有 2 个，无法安全下 20 层以下 @ 背包 — only 2 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)（做不了：下矿深度受限，拿不到 40 层以下的铁矿） 〔复盘〕
