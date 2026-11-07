# 第1年 winter 28 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（18:58 开始）
- 天气：sunny　金钱：2352g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)

## 🌙 为明天（Y1_winter_28）准备的脚本
- 里程碑：凑够 2000g 把水壶升成铜水壶（差 88g）
- 收熔炉铁锭→显式装 Iron Ore 炼铁→白名单出货把现金推过 2000g
- 去 Blacksmith 升铜水壶
- 铁锭够 5 就 craft 洒水器×4
- 剩余时间 Mountain 湖边钓鱼攒钱
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar", "Stone", "Wood", "Fiber"]）
6. `goto_location`（location="Town"）
7. `move_to`（x=40, y=64）
8. `upgrade_tool`（tool="watering_can"）
9. `craft`（item="Sprinkler", count=4）
10. `goto_location`（location="Mountain"）
11. `fish`（casts=6）
12. `fish`（casts=6）
13. `sleep`
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Iron Bar
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:00** Farm ✅ `ship_produce`
  - 结果：shipped 6 stacks worth ~1033g (paid overnight)
- **06:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:00** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **06:20** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar", "Stone", "Wood", "Fiber"]）
  - 结果：nothing to ship

### 🔁 脚本重写：重写#1：现金2352g已够升铜水壶，先收熔炉炼铁、出货，9点后去铁匠铺升级水壶，再去Mountain湖边钓鱼到傍晚回家睡觉。
1. `goto_location`（location="Town"）
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="watering_can"）
4. `close_menu`
5. `goto_location`（location="Mountain"）
6. `fish`（casts=6）
7. `fish`（casts=6）
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `harvest_crops`
12. `water_crops`
13. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Copper Bar"]）
14. `wait`（minutes=30）
15. `sleep`

## 🌅 早上的计划（18:59 开始）
- 天气：sunny　金钱：2352g　体力：270/270
- 里程碑：工具按档升级（铜水壶，现金已够2352g）
- 收熔炉铁锭→显式装Iron Ore炼铁→出货推现金→9点后升铜水壶→铁锭够5就craft洒水器×4→Mountain湖边钓鱼

**执行脚本：**
1. `goto_location`（location="Town"）
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="watering_can"）
4. `close_menu`
5. `goto_location`（location="Mountain"）
6. `fish`（casts=6）
7. `fish`（casts=6）
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `harvest_crops`
12. `water_crops`
13. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Copper Bar"]）
14. `wait`（minutes=30）
15. `sleep`
- **06:40** BusStop ❌ `goto_location`（location="Town"）
  - 结果：busy with 'goto_location'

### 🔁 脚本重写：重写#2：上一个 goto Town 因并发 busy 失败，重发同一路线：先去铁匠铺升铜水壶，再去Mountain钓鱼，傍晚回农场收熔炉出货后睡觉。
1. `goto_location`（location="Town"）
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="watering_can"）
4. `goto_location`（location="Mountain"）
5. `fish`（casts=6）
6. `fish`（casts=6）
7. `goto_location`（location="Farm"）
8. `collect_machines`
9. `load_machines`（item="Iron Ore"）
10. `harvest_crops`
11. `water_crops`
12. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Copper Bar"]）
13. `sleep`
- **06:40** Town ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)

### 🔁 脚本重写：重写#1：现金 2352g 已够，先炼铁锭、白名单出货腾格，再去铁匠铺升铜水壶，最后 Mountain 湖边钓鱼攒钱。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar", "Stone", "Frozen Geode", "Omni Geode", "Mixed Seeds", "Rice Shoot", "Cobblestone Path"]）
4. `goto_location`（location="Town"）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="watering_can"）
7. `goto_location`（location="Mountain"）
8. `fish`（casts=6）
9. `fish`（casts=6）
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `sleep`

## 🌅 早上的计划（19:00 开始）
- 天气：sunny　金钱：2352g　体力：270/270
- 里程碑：工具按档升级（铜水壶，现金已够 2352g）
- 收熔炉→显式装 Iron Ore 炼铁锭
- 白名单出货把现金推过 2000g 并腾背包格
- 去 Blacksmith 升铜水壶（现金≥2000g 且铜锭≥5）
- 铁锭够 5 就 craft 洒水器×4
- 剩余时间 Mountain 湖边钓鱼攒钱

**执行脚本：**
1. `load_machines`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar", "Stone", "Frozen Geode", "Omni Geode", "Mixed Seeds", "Rice Shoot", "Cobblestone Path"]）
5. `goto_location`（location="Town"）
6. `goto_location`（location="Blacksmith"）
7. `upgrade_tool`（tool="watering_can"）
8. `goto_location`（location="Mountain"）
9. `fish`（casts=6）
10. `fish`（casts=6）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:00** FarmHouse ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** FarmHouse ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Copper Bar", "Iron Bar", "Stone", "Frozen Geode", "Omni Geode", "Mixed Seeds", "Rice Shoot", "Cobblestone Path"]）
  - 结果：shipped 6 stacks worth ~1033g (paid overnight)
- **06:00** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
- **06:10** Town ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 8:10 am (waiting for Blacksmith to open at 9:00)
- **08:10** Town ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
