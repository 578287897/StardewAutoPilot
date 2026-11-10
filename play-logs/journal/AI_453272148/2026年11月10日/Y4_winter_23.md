# 第4年 winter 23 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（11:04 开始）
- 天气：snow　金钱：59098g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ccb51af5a7974e7084c5b7f766831225
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：496ed62d33584192bdf7a0200c88ce7b
  - 耗时：3.297 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing, 1x Coal
  - 执行状态：SUCCESS · 操作编号：d119e5a11d794e2093cc0c76a6319e78
  - 耗时：6.063 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：f605382df0c24809978b846188a01c77
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：eb5edd45a82e48f09368a93b0f8a4cd0
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e10e6bc18fcf48549b705e111c5c4f8b
  - 耗时：0.375 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_winter_23）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），瓶颈是铁矿石→铁锭转化链
- 起床先一次性清包到空格≥10（store_items不指定坐标+ship_produce，全天禁止take）
- 读炉状态：铁矿石仅4<5，物理删除load分支，直接下矿拿矿
- 电梯直达75层下矿75→79层拿铁矿石+煤（≤2次mine）
- 回农场collect收铁锭，铁锭≥5且<15:30则去Blacksmith升hoe
- 铁锭不足则把剩余时间给Forest钓鱼补食物/收入
- 21:30前收尾sleep
1. `goto_location`（location="ArchaeologyHouse"）
2. `donate`
3. `store_items`
4. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
5. `collect_machines`
6. `goto_location`（location="Mine"）
7. `mine`（floors=5）
8. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber"]）
9. `mine`（floors=4）
10. `leave_mine`
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `store_items`
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
18. `goto_location`（location="Farm"）
19. `sleep`
- **06:10** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: Coal | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：48ec0624230247819f557d5e4b198e9b
  - 耗时：47.359 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#1：ArchaeologyHouse 锁门且 donate 在 wait_letter 阶段 0 产出，删除该分支；按策略清包→下矿75层拿铁→收炉→15
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=4）
8. `leave_mine`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
14. `store_items`（items=["Stone", "Copper Ore", "Gold Ore", "Geode", "Magma Geode", "Omni Geode", "Frozen Geode", "Clay", "Fiber", "Cobblestone Path"]）
15. `collect_machines`
16. `store_items`
17. `collect_machines`
18. `upgrade_tool`（tool="hoe"）
19. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
20. `sleep`
- **07:00** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：b6e4b94565b44dc989994c5c233bf136
  - 耗时：5.234 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#2：ArchaeologyHouse 锁门，删除 donate 分支，按清包→下矿75层拿铁→收炉→升hoe→钓鱼收尾执行。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=4）
8. `leave_mine`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
14. `collect_machines`
15. `store_items`
16. `collect_machines`
17. `upgrade_tool`（tool="hoe"）
18. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
19. `sleep`
- **07:10** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... (Open 8:00am - 6:00pm) | It's locked... (Open 8:00am - 6:00pm)
  - 执行状态：ACTION_FAILED · 操作编号：0bae58cc3dff49d7a9df9e00d897a7c1
  - 耗时：5.266 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked... (Open 8:00am - 6:00pm)

### 🔁 脚本重写：重写#3：博物馆锁门且wait_letter阶段0产出，改回清包→电梯75层下矿拿铁矿石→收铁锭→升hoe的主线。
1. `goto_location`（location="ArchaeologyHouse"）
2. `take`（item="Copper Bar", count=1）
3. `take`（item="Bat Wing", count=1）
4. `donate`
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=4）
8. `leave_mine`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Gold Ore", "Iron Ore", "Copper Bar", "Iron Bar", "Green Algae", "River Jelly", "Strange Bun", "Claymore", "Silver Saber", "Rusty Sword", "Bamboo Pole"]）
14. `collect_machines`
15. `store_items`
16. `collect_machines`
17. `upgrade_tool`（tool="hoe"）
18. `sleep`
- **07:20** Town ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **07:20** Town ✅ `take`（item="Copper Bar", count=1）
  - 结果：took 1x Copper Bar from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：d86f17eaff3e4b92bbc6617ea50a4212
  - 耗时：42.062 秒 / 游戏 50 分钟
- **08:10** Farm ✅ `take`（item="Bat Wing", count=1）
  - 结果：took 1x Bat Wing from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：e59d2565a752470681767b3465bbf841
  - 耗时：0.391 秒 / 游戏 0 分钟
- **08:10** Farm ✅ `donate`
  - 结果：nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first
  - 执行状态：SUCCESS · 操作编号：744a84dbc4ff426c8d854285204c645d
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：铁矿石仅4跳过load，先清包腾格再电梯下矿拿铁矿炼锭，凑够5铁锭15:30前升钢锄头，否则收尾睡觉。
1. `take`（item="Ancient Seed", count=1）
2. `take`（item="Prehistoric Tool", count=1）
3. `take`（item="Aquamarine", count=1）
4. `take`（item="Ruby", count=1）
5. `take`（item="Amethyst", count=1）
6. `take`（item="Topaz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Mountain"）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Ore"]）
19. `collect_machines`
20. `store_items`
21. `collect_machines`
22. `store_items`
23. `sleep`

## 🌅 早上的计划（11:08 开始）
- 天气：snow　金钱：59098g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——先一次性清包到空格≥10
- 熔炉投料（铁矿石仅4，跳过load）
- 下矿75→79层拿铁矿石+煤
- 回农场收炉、凑5铁锭后15:30前升hoe
- 收尾21:30前sleep

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="Ancient Seed", count=1）
4. `take`（item="Prehistoric Tool", count=1）
5. `take`（item="Aquamarine", count=1）
6. `take`（item="Ruby", count=1）
7. `take`（item="Amethyst", count=1）
8. `take`（item="Topaz", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Mountain"）
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `store_items`
20. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Ore"]）
21. `collect_machines`
22. `store_items`
23. `collect_machines`
24. `store_items`
25. `sleep`

### 🔁 脚本重写：重写#1：背包仅2空格，先清包腾格再电梯下75层拿铁矿，回农场炼铁后15:30前升钢锄头，收尾睡觉。
1. `take`（item="Ancient Seed", count=1）
2. `take`（item="Prehistoric Tool", count=1）
3. `take`（item="Aquamarine", count=1）
4. `take`（item="Ruby", count=1）
5. `take`（item="Amethyst", count=1）
6. `take`（item="Topaz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Magma Geode", "Frozen Geode", "Dwarf Scroll I"]）
19. `collect_machines`
20. `store_items`
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `sleep`

## 🌅 早上的计划（11:12 开始）
- 天气：snow　金钱：59098g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——先一次性清包腾出空格
- 起床读炉状态，铁矿石不足5则跳过投料
- 清包后去矿洞电梯直达75层拿铁矿石+煤
- 回农场收炉炼铁，铁锭≥5且15:30前升hoe
- 收尾21:30前睡觉

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="Ancient Seed", count=1）
4. `take`（item="Prehistoric Tool", count=1）
5. `take`（item="Aquamarine", count=1）
6. `take`（item="Ruby", count=1）
7. `take`（item="Amethyst", count=1）
8. `take`（item="Topaz", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `fight`（range=6）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `store_items`
20. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Magma Geode", "Frozen Geode", "Dwarf Scroll I"]）
21. `collect_machines`
22. `store_items`
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7ebe3e6feafe451e91e389f37b02dbe2
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：05fec45818b04e96b687f470902002d3
  - 耗时：3.281 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `take`（item="Ancient Seed", count=1）
  - 结果：took 1x Ancient Seed from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：375900d9ecfb4351b4600083afb1bed7
  - 耗时：6.078 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：c3da1ecbd115423d839951203eb56693
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包0空格导致take失败，改为先清包腾格再下矿拿铁矿，回农场收炉后15:30前升hoe。
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Magma Geode", "Frozen Geode", "Dwarf Scroll I", "Ancient Seed"]）
19. `collect_machines`
20. `store_items`
21. `collect_machines`
22. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：ad379e609b5d4423a364fe48e190c89b
  - 耗时：0.407 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0空格导致take失败，改为先store_items+ship_produce清包，再下矿75层拿铁矿，回农场收炉后15:30前升hoe，失败即转
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Iron Ore", "Coal", "Stone", "Magma Geode", "Frozen Geode", "Dwarf Scroll I", "Ancient Seed"]）
19. `collect_machines`
20. `store_items`
21. `collect_machines`
22. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：ac2c3b7dfdb5422da7a1b1558a952a5b
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Aquamarine", count=1）
  - 结果：'Aquamarine' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f69044b64b3b413883350421d8b606b5
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Ruby", count=1）
  - 结果：'Ruby' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：65a8f055d9f4402d84dd32ff09feea4e
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Amethyst", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：259a054212d549dda983d33911f73e5e
  - 耗时：0.36 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Topaz", count=1）
  - 结果：'Topaz' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c551e9952281468d8b2660a63793be9f
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Diamond", count=1）
  - 结果：'Diamond' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f7d65a92b58942c99855fd19f928ca61
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：ef37e89f3c49487a9ee86902eefb4fda
  - 耗时：80.234 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：2b7c976d5d6c421fbb6c334bc0e53db8
  - 耗时：43.703 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：16bc118081224a4b90f6727393f16cca
  - 耗时：39.953 秒 / 游戏 50 分钟
- **09:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：0d142f8044ac4d518ee434d143fed890
  - 耗时：39.422 秒 / 游戏 50 分钟
- **10:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：5cd38bffc78f4ce48e9846a5ba9542d9
  - 耗时：38.172 秒 / 游戏 40 分钟

### 🔁 脚本重写：重写#1：背包仅2空格，先清包腾格再下矿75层拿铁矿，回农场收锭后15:30前升钢锄头，收尾睡觉。
1. `take`（item="Ancient Seed", count=1）
2. `take`（item="Prehistoric Tool", count=1）
3. `take`（item="Aquamarine", count=1）
4. `take`（item="Ruby", count=1）
5. `take`（item="Amethyst", count=1）
6. `take`（item="Topaz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Gold Ore", "Magma Geode", "Frozen Geode", "Strange Bun", "River Jelly"]）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `store_items`
22. `collect_machines`
23. `sleep`

## 🌅 早上的计划（11:18 开始）
- 天气：snow　金钱：59098g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——先一次性清包腾出空格
- 清包后下矿75→79层拿铁矿石+煤
- 回农场收熔炉铁锭，铁锭≥5且15:30前升hoe
- 不够则钓鱼补食物/收入，21:30前睡觉

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="Ancient Seed", count=1）
4. `take`（item="Prehistoric Tool", count=1）
5. `take`（item="Aquamarine", count=1）
6. `take`（item="Ruby", count=1）
7. `take`（item="Amethyst", count=1）
8. `take`（item="Topaz", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `fight`（range=6）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `store_items`
20. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Gold Ore", "Magma Geode", "Frozen Geode", "Strange Bun", "River Jelly"]）
21. `collect_machines`
22. `load_machines`（item="Iron Ore"）
23. `store_items`
24. `collect_machines`
25. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：31aa51122dc24b428915db69e01757ea
  - 耗时：0.922 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：86d553de4a784560b416ca1ac5991167
  - 耗时：3.265 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `take`（item="Ancient Seed", count=1）
  - 结果：took 1x Ancient Seed from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：67cbb4e8d03c4f66a0597d8e985f3185
  - 耗时：6.14 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：82511d703f454161aaf250ce7022bd37
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包0空格导致take失败，改为不指定坐标清包→卖低价值物腾格，再下矿75层拿铁矿并回炉收锭，铁锭够则15:30前升hoe，否则收尾睡觉。
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Gold Ore", "Magma Geode", "Frozen Geode", "Strange Bun", "River Jelly", "Ancient Seed"]）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `store_items`
22. `collect_machines`
23. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：d95fa8cf6ce647b78b12e1ceeea99788
  - 耗时：0.407 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0空格导致take失败，改为先不指定坐标清包+卖低价值物腾格，再按原路线下矿75→79拿铁矿、回农场收锭、15:30前升hoe，失败即睡。
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `leave_mine`
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `store_items`
18. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Gold Ore", "Magma Geode", "Frozen Geode", "Strange Bun", "River Jelly", "Ancient Seed"]）
19. `collect_machines`
20. `store_items`
21. `collect_machines`
22. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：fb46c0656f5c4b35b9f6d10537bf706a
  - 耗时：0.39 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Aquamarine", count=1）
  - 结果：'Aquamarine' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：aaa2c4a3c35b4f87a9d2a0daf77ca924
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Ruby", count=1）
  - 结果：'Ruby' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f9abac55be4c496e97b09ab2f875d82e
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Amethyst", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：8737766f8c4d4b4d8fb511826e64895d
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Topaz", count=1）
  - 结果：'Topaz' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f29cf913b7ef464ab337bba245035600
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Diamond", count=1）
  - 结果：'Diamond' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：948fc801ebd049b09a050ac9c6fe454d
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：28a7fb2dc4d8482d9f0568af77cc90bf
  - 耗时：80.203 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：0d71a0a6cfe04446a71ea4561fa09046
  - 耗时：43.703 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：54e382ae5e584ebf8cfabdf2b418e2b7
  - 耗时：39.938 秒 / 游戏 50 分钟
- **09:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5557d523deb34bd583263a7af69caf81
  - 耗时：39.421 秒 / 游戏 50 分钟

### 🔁 脚本重写：重写#1：背包仅2空格，先清包腾格再电梯下矿拿铁矿石，回炉收锭后15:30前升钢锄头。
1. `take`（item="Ancient Seed", count=1）
2. `take`（item="Prehistoric Tool", count=1）
3. `take`（item="Aquamarine", count=1）
4. `take`（item="Ruby", count=1）
5. `take`（item="Amethyst", count=1）
6. `take`（item="Topaz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Copper Bar", "Coal", "Iron Ore", "Gold Ore", "Iron Bar"]）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `store_items`（items=["Stone", "Copper Ore", "Gold Ore"]）
19. `collect_machines`
20. `upgrade_tool`（tool="hoe"）
21. `sleep`

## 🌅 早上的计划（11:23 开始）
- 天气：snow　金钱：59098g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——先一次性清包腾出空格
- 清包后下矿75→79层拿铁矿石+煤
- 回农场收熔炉铁锭，铁锭≥5且15:30前升hoe
- 收尾21:30前sleep

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="Ancient Seed", count=1）
4. `take`（item="Prehistoric Tool", count=1）
5. `take`（item="Aquamarine", count=1）
6. `take`（item="Ruby", count=1）
7. `take`（item="Amethyst", count=1）
8. `take`（item="Topaz", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate`
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `store_items`
17. `ship_produce`（except=["Copper Bar", "Coal", "Iron Ore", "Gold Ore", "Iron Bar"]）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`（items=["Stone", "Copper Ore", "Gold Ore"]）
21. `collect_machines`
22. `upgrade_tool`（tool="hoe"）
23. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4cb0f584899349c482529a938cd61c4a
  - 耗时：0.859 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：b10a3cb986294f25ac0a59906034fdb2
  - 耗时：3.281 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `take`（item="Ancient Seed", count=1）
  - 结果：took 1x Ancient Seed from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：6a9d66d1ee3b4db5acd6d985c8f27cd2
  - 耗时：6.109 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：2b5050aeba47461a98fe7447f01752b2
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包0空格，先不指定坐标清包卖低价值物腾格，再下矿75→79拿铁矿，回农场收锭并赶在15:30前升hoe，删掉take/博物馆等无效分支。
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Copper Bar", "Coal", "Iron Ore", "Gold Ore", "Iron Bar", "Stone"]）
16. `collect_machines`
17. `store_items`（items=["Stone", "Copper Ore", "Gold Ore"]）
18. `collect_machines`
19. `upgrade_tool`（tool="hoe"）
20. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：ecdab746a2e14d0bbf9644429f57af6b
  - 耗时：0.406 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：上一步 take 因背包满失败，改为先不指定坐标 store_items 清包再 ship_produce，随后按原路线下矿75→79层、回农场收锭并
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Farm"）
14. `store_items`
15. `ship_produce`（except=["Copper Bar", "Coal", "Iron Ore", "Gold Ore", "Iron Bar", "Stone"]）
16. `collect_machines`
17. `store_items`（items=["Stone", "Copper Ore", "Gold Ore"]）
18. `collect_machines`
19. `upgrade_tool`（tool="hoe"）
20. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：ff6a7d9c5cf74855bf7e9cb94739a3ad
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Aquamarine", count=1）
  - 结果：'Aquamarine' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f27f70de210f4f5fbf2435a72702fa2b
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Ruby", count=1）
  - 结果：'Ruby' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：03f3e55723a14e09af126f165bb6f921
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Amethyst", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：8dd771d30b04427d96f066d9152fb9d9
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Topaz", count=1）
  - 结果：'Topaz' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ca8378fd9c5a48efaa82f6095edd072d
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Diamond", count=1）
  - 结果：'Diamond' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d1e1220261d847d5a21373766abae847
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：0267294f6d2044e3aa04d484c59a7c1a
  - 耗时：80.187 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：ac37d23f588b4073a9d64900a064bd8c
  - 耗时：43.703 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：0f2ece3f9fe541aab18a93e698a37b94
  - 耗时：39.922 秒 / 游戏 50 分钟
- **09:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a10019c49e264b34a621c8bd5087c374
  - 耗时：39.453 秒 / 游戏 50 分钟
- **10:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：dd6855d81a244902ab18f0eebff3f9c8
  - 耗时：38.063 秒 / 游戏 40 分钟
- **10:30** Mine ❌ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：cd28a80ad5db460a80621a27c74fd4d2
  - 耗时：12.937 秒 / 游戏 20 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：cd28a80ad5db460a80621a27c74fd4d2
  - 耗时：12.937 秒 / 游戏 20 分钟
- **11:30** Farm ❌ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：fb0f85ddc28d40b8a344233ecf4b556c
  - 耗时：7.594 秒 / 游戏 10 分钟
- **11:30** Farm ❌ `mine`（floors=5）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：fb0f85ddc28d40b8a344233ecf4b556c
  - 耗时：7.594 秒 / 游戏 10 分钟
- **11:40** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：daf8248799464f2d8e856d618385a551
  - 耗时：0.375 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (53,8)
  - 执行状态：SUCCESS · 操作编号：cd603c401ea3470ab81405f82f8c283d
  - 耗时：0.375 秒 / 游戏 0 分钟
- **11:40** Farm ❌ `store_items`
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：b4b8c607c11f40c58056805018fb3b4b
  - 耗时：7.578 秒 / 游戏 10 分钟
- **11:50** Farm ❌ `ship_produce`（except=["Copper Bar", "Coal", "Iron Ore", "Gold Ore", "Iron Bar", "Stone"]）
  - 结果：could not reach (70,15); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：f5c50f5192c4482d879d2d0c2576e5c6
  - 耗时：7.594 秒 / 游戏 10 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：7e221b74a500484d8363e1290282033c
  - 耗时：0.391 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `store_items`（items=["Stone", "Copper Ore", "Gold Ore"]）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：ca3cc74cd19e4cd09ddb2af77d18f85d
  - 耗时：7.797 秒 / 游戏 10 分钟
- **12:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:10** Farm ❌ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：bae45e41cf6e4cd6a62825df6ebb1ae3
  - 耗时：7.578 秒 / 游戏 10 分钟
- **12:10** Farm ❌ `upgrade_tool`（tool="hoe"）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：bae45e41cf6e4cd6a62825df6ebb1ae3
  - 耗时：7.578 秒 / 游戏 10 分钟

### 🔁 脚本重写：重写#1：铁矿石4<5删除load分支；先清包腾格再电梯下75层拿铁矿，回农场收锭后15:30前升hoe，不足则钓鱼收尾。
1. `take`（item="Ancient Seed", count=1）
2. `take`（item="Prehistoric Tool", count=1）
3. `take`（item="Aquamarine", count=1）
4. `take`（item="Ruby", count=1）
5. `take`（item="Amethyst", count=1）
6. `take`（item="Topaz", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `donate`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Stone"]）
22. `collect_machines`
23. `store_items`
24. `collect_machines`
25. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar"]）
26. `sleep`

## 🌅 早上的计划（11:31 开始）
- 天气：snow　金钱：59098g　体力：270/270
- 里程碑：钢锄头（5000g+5铁锭）——先一次性清包到空格≥10
- 起床读炉状态，铁矿石仅4<5，物理删除 load 分支
- 清包后去矿洞电梯直达75层拿铁矿石+煤（≤2次mine）
- 回农场collect收铁锭，铁锭≥5且<15:30则升hoe
- 不够则转钓鱼，21:30前收尾睡觉

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `take`（item="Ancient Seed", count=1）
4. `take`（item="Prehistoric Tool", count=1）
5. `take`（item="Aquamarine", count=1）
6. `take`（item="Ruby", count=1）
7. `take`（item="Amethyst", count=1）
8. `take`（item="Topaz", count=1）
9. `goto_location`（location="ArchaeologyHouse"）
10. `donate_museum`
11. `donate`
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `fight`（range=6）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Forest"）
20. `fish`（casts=4）
21. `goto_location`（location="Farm"）
22. `store_items`
23. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Stone"]）
24. `collect_machines`
25. `store_items`
26. `collect_machines`
27. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar"]）
28. `sleep`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：69f0bc51420d4b47823c9b5ccaf31fcd
  - 耗时：0.797 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：b16d6bbddd7f4b1cb283f7e38c431df5
  - 耗时：3.282 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `take`（item="Ancient Seed", count=1）
  - 结果：took 1x Ancient Seed from chest at (74,15)
  - 执行状态：SUCCESS · 操作编号：64485d0549c24e508b76c1d8aedd015c
  - 耗时：6.109 秒 / 游戏 10 分钟
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：509bfc0417b64f9fab175cfc4b0472fa
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：背包0空格导致take失败，先store_items+ship_produce清包，再按原路线下矿拿铁矿石炼锭升hoe，最后钓鱼收尾睡觉。
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `donate`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Ancient Seed"]）
22. `collect_machines`
23. `store_items`
24. `collect_machines`
25. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal"]）
26. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：90c4654c478547518b03d94aaa4ad0f0
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：背包0空格导致取物失败，改为先store_items+ship_produce清包，再按原路线下矿75层、回农场收锭、15:30前升hoe，不够则钓鱼
1. `take`（item="Prehistoric Tool", count=1）
2. `take`（item="Aquamarine", count=1）
3. `take`（item="Ruby", count=1）
4. `take`（item="Amethyst", count=1）
5. `take`（item="Topaz", count=1）
6. `take`（item="Diamond", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `donate`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `fight`（range=6）
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Blacksmith"）
16. `upgrade_tool`（tool="hoe"）
17. `goto_location`（location="Forest"）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `store_items`
21. `ship_produce`（except=["Copper Bar", "Iron Bar", "Gold Bar", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Stone", "Ancient Seed", "Frozen Geode", "Magma Geode"]）
22. `collect_machines`
23. `store_items`
24. `collect_machines`
25. `ship_produce`（except=["Iron Bar", "Copper Bar", "Gold Bar", "Iron Ore", "Coal"]）
26. `sleep`
- **06:10** Farm ❌ `take`（item="Prehistoric Tool", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：8989aa222ad24271b5c0556c18b65c98
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Aquamarine", count=1）
  - 结果：'Aquamarine' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：56a9e11c558a4a49876b67513703cf22
  - 耗时：0.375 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Ruby", count=1）
  - 结果：'Ruby' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：76614ca3e5a74216b1630882f9d82e3a
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Amethyst", count=1）
  - 结果：inventory full
  - 执行状态：ACTION_FAILED · 操作编号：57ec6e83253b47029470ff9a604c58e9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Topaz", count=1）
  - 结果：'Topaz' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1a67976eb57e43ea8718eff77f8c6169
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="Diamond", count=1）
  - 结果：'Diamond' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1b3630806b434ce980b1d2a601ec4017
  - 耗时：0.359 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：d7b23e8b29b8491082ad120e92bc754e
  - 耗时：80.203 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：19475922947a47da83f50e09e29a48e4
  - 耗时：43.656 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ✅ `donate_museum`
  - 结果：donated Dwarf Scroll I (96) to the museum at (26,5)
  - 执行状态：SUCCESS · 操作编号：f0dbee2e78174413b080be3152154e0d
  - 耗时：0.422 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：f11bdf1dd1524de2aa0c5c08e015d292
  - 耗时：39.922 秒 / 游戏 50 分钟
- **09:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：6c3e02aa563b4fc9b0d6877997ad6965
  - 耗时：39.515 秒 / 游戏 50 分钟
- **10:30** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：e01ec1933d4d46628f0d5abcc917d0c5
  - 耗时：38.062 秒 / 游戏 40 分钟
- **10:30** Mine ❌ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：ea40ce458553466081cb760b3080b6ac
  - 耗时：12.547 秒 / 游戏 20 分钟
- **10:30** Mine ❌ `mine`（floors=5）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：ea40ce458553466081cb760b3080b6ac
  - 耗时：12.547 秒 / 游戏 20 分钟
- **11:30** Farm ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：79206e2551a74feaafb053e51b105399
  - 耗时：0.438 秒 / 游戏 0 分钟
- **11:30** Farm ❌ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：ae7a9f2cc08c461388aa391f7c4599a5
  - 耗时：7.562 秒 / 游戏 10 分钟
- **11:30** Farm ❌ `mine`（floors=5）
  - 结果：could not reach (74,16); stopped at (53,8)
  - 执行状态：ACTION_FAILED · 操作编号：ae7a9f2cc08c461388aa391f7c4599a5
  - 耗时：7.562 秒 / 游戏 10 分钟
- **11:40** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：ba55de3d3ec24a158e46110b883ac137
  - 耗时：0.375 秒 / 游戏 0 分钟
- **11:40** Farm ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：19e99c82b6af4f6bb0b7b1bcd00c500a
  - 耗时：73.781 秒 / 游戏 90 分钟
- **13:10** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：d4a74110ba6c4e0bb73740315c1d5d2a
  - 耗时：38.938 秒 / 游戏 50 分钟
- **13:10** Blacksmith ✅ `store_items`（items=["Cobblestone Path", "Green Algae", "Copper Ore", "Stone", "River Jelly", "Gold Ore", "Magma Geode", "Strange Bun", "Coal"]）
  - 💭 (背包不够 5 格，先把不急用的存箱再下矿)
  - 结果：stored in chest at (75,15): 24x Cobblestone Path, 20x Green Algae, 4x Copper Ore, 49x Stone, 3x River Jelly, 3x Gold Ore, 2x Magma Geode
  - 执行状态：SUCCESS · 操作编号：a44bacc41193427a827376cdccdcd612
  - 耗时：1.125 秒 / 游戏 0 分钟
- **13:10** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：71d4f3d23c3e44878c89f5cf0a6d34b2
  - 耗时：300.391 秒 / 游戏 410 分钟
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Bug Meat
- **20:50** UndergroundMine16 ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：beb2b3750a54482da252fbe5ca604d94
  - 耗时：63.078 秒 / 游戏 80 分钟
  - 🗨️ [question] 
- **22:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Perch, Chub, Pike, Chub)
  - 执行状态：SUCCESS · 操作编号：4419a1799767491a810afea7e79a92d4
  - 耗时：80.078 秒 / 游戏 60 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Pike
- **23:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：852beea906ef4dfd963e5a3cf7da811d
  - 耗时：15.296 秒 / 游戏 20 分钟
- **23:30** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 1x Copper Bar, 1x Bat Wing, 11x Bug Meat, 1x Coal
  - 执行状态：SUCCESS · 操作编号：dea5d3a22a154d3994a1701974a38dfb
  - 耗时：23.922 秒 / 游戏 30 分钟
  - 🗨️ [hud] It's getting late... 
- **24:00** Farm ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：509f7e98112f495c959df4c9911c6da0
  - 耗时：10.375 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：59098 → 59098（+0g）
- 出货估值：0g　动作：33 个　失败：16 个
- 模型调用：4 次　tokens：38906
- 有效动作率：0.5333　空转：2　熔断跳过：0
- 失败耗时：324.499 秒 / 游戏 440 分钟
- 最深矿层：86　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败是清包链条断裂：store_items 指定旧坐标失败→take 又把物品取回→背包 0 空格→mine/upgrade 全被拒，钢锄头连续三天零推进。钓鱼 4 cast 全成功是唯一稳定产出。今天必须把清包做成不可回退的一次性动作链，清包后全天禁止 take；铁矿石<5 时物理删除 load 分支；下矿目标明确写 75→79 层。

**新教训：**
- 昨天 upgrade_tool 因 HTTP timeout 被取消（游戏内已到铁匠铺），说明升级动作可能因网络/超时中断：升级前先确认时间窗，超时后当天不再重试同一 upgrade，改为次日优先执行。
- 昨天 take 了 Ancient Seed 后背包立刻满，导致后续 4 次 take 全失败：清包后若必须取物，先 ship_produce 卖低价值物腾出至少 3 格再 take，且一次只取 1 件。
- 昨天 store_items 到 (74,16) 两次 could not reach，而不指定坐标的 store_items 成功存入：箱子路径被挡时应立即改不指定坐标，不要重试同一坐标。
- 昨天 16:50 到 Blacksmith 被锁门，而 upgrade_tool 在 13:10 已因超时失败：升级动作应在 9:10-13:00 窗口内发起，留足重试余量，13:00 后不再安排升级。
- 昨天钓鱼 4 cast 全成功（Perch/Chub/Pike），是唯一稳定产出：背包满或铁矿石不足时，应在 1 个动作内转 Forest 钓鱼，不要在同一天反复尝试下矿。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 冬 24）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 59098g 充足，铁锭 0、铁矿石 4、煤 23，瓶颈是**铁矿石→铁锭转化链**，已连续三天因背包空格不足零推进。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。

接下来 3 天主活动：
- **今天（冬 24）**：起床读炉状态（铁矿石<5 则删除 load 分支）→ **一次性清包到空格≥10**（store_items 不指定坐标 + ship_produce，禁止任何 take）→ 电梯直达 75 层下矿 75→79 拿铁矿石+煤（≤2 次 mine）→ 回农场 collect 收铁锭 → 铁锭≥5 且 <15:30 升 hoe。
- **明天（冬 25）**：hoe 已升则转钢斧（5000g+5 铁锭）；否则继续下矿炼铁；铁锭富余则 craft 洒水器落地。
- **后天（冬 26）**：冬季种子/茶苗 + 为春 1 备料，铁锭富余升第二件工具。

## 今日核心修正
1. **清包是一次性、不可回退的动作链**：起床第一件事 goto Farm → store_items（**不指定坐标**）→ ship_produce 卖低价值物（Stone/Coal/矿石/锭除外）→ 读背包验证空格≥10。**清包成功后全天禁止任何 take 动作**（过去三天 take 把刚存的东西取回，直接导致 0 空格）。空格 <10 且两次清包无效 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **熔炉投料双条件**：起床读炉状态，任一炉为空**且铁矿石≥5** → load_machines item=Iron Ore 1 次；铁矿石<5 则脚本生成阶段物理删除 load 分支，先去下矿拿矿。返回 busy/no empty 即当天永久跳过 load。load 每天 ≤1 次，12:00 前完成。
3. **下矿食物门槛 ≥5**：不够先在 Forest 河边钓 1 轮（≤4 cast）补鱼当食物，杂鱼立即 ship_produce。
4. **下矿用电梯直达 75 层**：goto Mine 后电梯直达 75 层，mine 目标 75→79 层，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。**禁止从当前最深 86 层往下爬**。
5. **升级窗口硬约束**：铁锭凑齐后必须在 **15:30 前**到 Blacksmith，16:00 后锁门。15:00 还没凑齐 5 铁锭，当天放弃升级，把时间给钓鱼/下矿。升级前读背包确认 Iron Bar ≥5、现金 ≥5000、**背包空格 ≥5**（upgrade_tool 内部也校验空格）。
6. **动作预算清理**：build_road、decorate、wait、donate、water_crops、ArchaeologyHouse、Saloon 连续多天 0 产出，**从脚本彻底删除**；省下的动作给钓鱼和下矿。
7. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床读炉状态**：任一炉为空且铁矿石 ≥5 且时间 <12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过；铁矿石<5 跳过。
2. **一次性清包到空格 ≥10**：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足则再 ship_produce 一次 → 再验证；两次仍不足则当天定性钓鱼日，删除 mine/upgrade 分支。**清包后全天禁止 take**。
3. **collect_machines 1 次**（有成品收走；返回空即当天跳过，下矿回来再试一次）。
4. **补食物到 ≥5**：goto Forest 河边 fish ≤1 轮（≤4 cast），只留高回复鱼，杂鱼立即 ship_produce。
5. **下矿（仅当空格 ≥10 且食物 ≥5 且武器 avg≥14）**：goto Mine 前显式读背包确认三项。**电梯直达 75 层**，mine 目标 75→79 层拿铁矿石+煤，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命 <50% 或食物=0 立即 leave_mine。
6. **mine 成功一次后先 store_items 腾格**：回农场存 Stone/Copper Ore/多余矿石，再决定是否第二次下矿，不连续调 mine。
7. **回农场 collect 收炉**：下矿回来第一时间 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. **升级工具**：铁锭 ≥5 且现金 ≥5000 且空格 ≥5 且时间 9:10-15:30 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar ≥5。一次只升一件。goto 或 upgrade 返回 could not reach/locked 即当天永久跳过。
9. **craft 洒水器并落地**：条件（Copper Bar ≥1 且 Iron Bar ≥1）满足才 craft；craft 后 place 必须带 x、y 参数。place 返回「分区无空位」或「missing arguments」即当天永久跳过 place。
10. **21:30 后只允许 sleep**；体力 <15 或时间 ≥21:30 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格 ≥10，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不要重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格 <10 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **食物 ≥5 且空格 ≥10 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **craft 洒水器前读背包**：Copper Bar ≥1 且 Iron Bar ≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」即当天不再 goto；节日期间商店锁门，禁止安排升级/购物；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5、现金 ≥5000、空格 ≥5；不够直接跳过。一次只升一件。**could not reach/locked 即当天永久跳过升级。**
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-15:30）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take≤0（清包后）**。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：mine 前必须先 goto_location 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. **一次性清包到空格 ≥10**（store_items 不指定坐标 + ship_produce + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
2. **起床读炉状态 → 空炉且铁矿石≥5 立即 load 铁矿石**（≤1 次，12:00 前完成，busy 即跳过；铁矿石<5 物理删除 load）
3. collect_machines 1 次（收熔炉成品）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）
5. 下矿：**电梯直达 75 层**拿铁矿石+煤（空格 ≥10、食物 ≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭 ≥5 且空格 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked 即跳过）
9. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包链条断裂：store_items 指定旧坐标失败→take 又把物品取回→背包 0 空格→mine/upgrade 全被拒，钢锄头连续三天零推进。钓鱼 4 cast 全成功是唯一稳定产出。今天必须把清包做成不可回退的一次性动作链，清包后全天禁止 take；铁矿石<5 时物理删除 load 分支；下矿目标明确写 75→79 层。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — 'Aquamarine' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — 'Ruby' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — inventory full 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — 'Topaz' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — 'Diamond' is not in any farm chest 〔自动〕
- 10:30 动作 `store_items` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 10:30 动作 `mine` 失败 @ Mine — could not reach (74,16); stopped at (53,8) 〔自动〕
- 11:30 动作 `store_items` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 11:30 动作 `mine` 失败 @ Farm — could not reach (74,16); stopped at (53,8) 〔自动〕
- 11:40 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 13:10 动作 `upgrade_tool` 失败 @ Blacksmith — cancelled: HTTP timeout | 游戏消息: [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat / [hud] Bug Meat 〔自动〕
- 清包链条反复断裂，背包始终 0 空格，下矿和升级全被拒 @ Farm 箱子/出货箱 (74,15)/(74,16) — store_items 指定旧坐标返回 could not reach；随后 take 又把刚存的东西取回；mine 返回 need at least 5 free backpack slots（做不了：钢锄头主线连续三天零推进，铁矿石没拿到，铁锭产出为零） 〔复盘〕
- 熔炉因铁矿石仅 4 无法投料，全天没炼出铁锭 @ Farm 熔炉 — load_machines -> no empty machine accepts anything（铁矿石<5 空转）（做不了：钢锄头（差 5 铁锭）和洒水器（差铁锭）都卡住） 〔复盘〕
- upgrade_tool 在铁匠铺因 HTTP timeout 被取消，当天升级窗口浪费 @ Blacksmith — upgrade_tool -> cancelled: HTTP timeout（做不了：钢锄头升级当天未完成，且 16:00 后锁门无法补救） 〔复盘〕
- 下午 18:00 去博物馆被锁门，白跑一趟 @ ArchaeologyHouse — goto_location -> exit did not open (Open 8:00am - 6:00pm)（做不了：浪费 1 个动作预算，博物馆捐赠/任务无法推进） 〔复盘〕
- donate 时背包里没有收集包需要的物品，空捐 0 产出 @ Community Center — donate -> nothing in the backpack is needed by an open bundle（做不了：社区中心收集包无法推进） 〔复盘〕
- 22:00 后仍安排 3 个收尾动作到 23:10 才睡 @ Farm — store_items/ship_produce/collect_machines 在 22:00-23:10 执行（做不了：压缩次日体力，且收尾动作本可提前到 21:30 前） 〔复盘〕
- build_road 两次共 laid 0 格，decorate 也 0 产出 @ Farm — 规划道路边没有还能走上去的空格；今天没有能做的装饰（做不了：浪费 3 个动作预算，本可给钓鱼或下矿） 〔复盘〕
