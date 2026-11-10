# 第2年 spring 26 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（23:55 开始）
- 天气：storm　金钱：2506g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min)
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically

## 🌙 为明天（Y2_spring_26）准备的脚本
- 里程碑：第二座熔炉 + 工具按档升级（先炼铁、赚钱，明天再升钢水壶）
- 早上：craft 第二座熔炉并放下，两座炉同时开工
- 砍 1 棵树补 Wood≥50 → craft 保存罐
- 9:00/15:00 各 collect 一次熔炉，炉空后 load 铁/铜
- 主活动：下矿 20-30 层拿铁/煤（体力≥30、食物≥3 才下）
- 现金够就补鱼饵，体力耗尽转钓鱼补钱
- 22:00 前 sleep
1. `donate`
2. `craft`（item="Furnace", count=1）
3. `place`（item="Furnace"）
4. `use_tool`（tool="axe", x=40, y=60, times=1, until_cleared=true）
5. `craft`（item="Preserves Jar", count=1）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `goto_location`（location="Mine"）
9. `mine`（floors=3）
10. `fight`（range=6）
11. `mine`（floors=3）
12. `fight`（range=6）
13. `mine`（floors=3）
14. `leave_mine`
15. `goto_location`（location="FishShop"）
16. `open_shop`（shop_id="FishShop"）
17. `buy`（item="Bait", count=20）
18. `close_menu`
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Copper Ore"）
24. `ship_produce`
25. `sleep`
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~131g (paid overnight)
- **06:20** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 因巫师信未到失败，跳过社区中心分支，按原路线先做熔炉/保存罐再下矿，最后回农场收炉出货睡觉。
1. `craft`（item="Furnace", count=1）
2. `place`（item="Furnace"）
3. `use_tool`（tool="axe", x=40, y=60, times=1, until_cleared=true）
4. `craft`（item="Preserves Jar", count=1）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `goto_location`（location="Mine"）
8. `mine`（floors=3）
9. `fight`（range=6）
10. `mine`（floors=3）
11. `fight`（range=6）
12. `mine`（floors=3）
13. `leave_mine`
14. `goto_location`（location="Farm"）
15. `collect_machines`
16. `load_machines`（item="Copper Ore"）
17. `ship_produce`
18. `sleep`
- **06:20** Farm ✅ `craft`（item="Furnace", count=1）
  - 结果：crafted 1x Furnace
- **06:20** Farm ✅ `place`（item="Furnace"）
  - 结果：placed Furnace at (25,8)
- **06:40** Farm ✅ `use_tool`（tool="axe", x=40, y=60, times=1, until_cleared=true）
  - 结果：used axe 0x at (40,60), tile cleared
- **06:40** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：can't craft Preserves Jar: not enough ingredients: Wood x50, Stone x40, Coal x8

### 🔁 脚本重写：重写#2：保存罐材料不足，先砍树补 Wood 再 craft，其余按原路线炼矿下矿。
1. `use_tool`（tool="axe", x=26, y=9, times=1, until_cleared=true）
2. `use_tool`（tool="axe", x=27, y=9, times=1, until_cleared=true）
3. `use_tool`（tool="axe", x=28, y=9, times=1, until_cleared=true）
4. `use_tool`（tool="axe", x=29, y=9, times=1, until_cleared=true）
5. `craft`（item="Preserves Jar", count=1）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `goto_location`（location="Mine"）
9. `mine`（floors=3）
10. `fight`（range=6）
11. `mine`（floors=3）
12. `fight`（range=6）
13. `mine`（floors=3）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Copper Ore"）
18. `ship_produce`
19. `sleep`
- **06:40** Farm ✅ `use_tool`（tool="axe", x=26, y=9, times=1, until_cleared=true）
  - 结果：used axe 0x at (26,9), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=27, y=9, times=1, until_cleared=true）
  - 结果：used axe 0x at (27,9), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=28, y=9, times=1, until_cleared=true）
  - 结果：used axe 0x at (28,9), tile cleared
- **06:40** Farm ✅ `use_tool`（tool="axe", x=29, y=9, times=1, until_cleared=true）
  - 结果：used axe 0x at (29,9), tile cleared
- **06:40** Farm ❌ `craft`（item="Preserves Jar", count=1）
  - 结果：already failed crafting Preserves Jar today (not enough ingredients); gather materials first (clear_debris / mine)

### 🔁 脚本重写：重写#3：保存罐材料不足当天熔断，改砍树补木后下矿拿铁煤，傍晚回农场收炉出货睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `clear_debris`（radius=10, max=20, kinds=["twig", "weed", "stone"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=3）
6. `fight`（range=6）
7. `mine`（floors=3）
8. `fight`（range=6）
9. `mine`（floors=3）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `load_machines`（item="Copper Ore"）
14. `ship_produce`
15. `sleep`
- **06:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 🗨️ [hud] Copper Bar
- **06:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:40** Farm ✅ `clear_debris`（radius=10, max=20, kinds=["twig", "weed", "stone"]）
  - 结果：cleared 5 debris within 10 tiles of (35,9)
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Wood
- **06:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
- **07:30** Mine ✅ `mine`（floors=3）
  - 结果：mined from floor 15 to 18 (3 floors down, 65 stones broken)
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Monster Compendium
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
- **08:50** UndergroundMine18 ✅ `fight`（range=6）
  - 结果：done
- **08:50** UndergroundMine18 ✅ `mine`（floors=3）
  - 结果：mined from floor 18 to 19 (1 floors down, 57 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Geode
- **09:50** UndergroundMine19 ✅ `fight`（range=6）
  - 结果：done
- **09:50** UndergroundMine19 ✅ `mine`（floors=3）
  - 结果：mined from floor 19 to 19 (0 floors down, 0 stones broken); stopped at floor 19: only 0 healing food (need 3+ for floor 20 and below, 5+ for 40 and below)
- **09:50** UndergroundMine19 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 🗨️ [question] 
- **09:50** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **10:30** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **10:30** Farm ✅ `load_machines`（item="Copper Ore"）
  - 结果：loaded: Copper Ore -> Furnace (ready in 30 min), Copper Ore -> Furnace (ready in 30 min)
