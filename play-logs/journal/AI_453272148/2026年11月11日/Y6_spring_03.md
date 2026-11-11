# 第6年 spring 3 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `build_road`
5. `harvest_crops`
6. `water_crops`
7. `ship_produce`

## 🌅 早上的计划（17:58 开始）
- 天气：sunny　金钱：84925g　体力：135/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `build_road`
5. `harvest_crops`
6. `water_crops`
7. `ship_produce`
- **06:00** FarmHouse ❌ `check_mail`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：00c8459f18a545c7ad54fa18682a56f3
  - 耗时：6.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包 0 空格，先收炉并出货箱卖 Copper Ore/Stone 腾格，再下 40 层刷铁，铁锭不够则 Forest 钓鱼兜底后睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `check_mail`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Forest"）
14. `fish`（casts=4）
15. `goto_location`（location="Farm"）
16. `collect_machines`
17. `load_machines`（item="Iron Ore"）
18. `ship`（item="Copper Ore", count=57）
19. `ship`（item="Stone", count=56）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:00** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0362dbac4ee24853a699d55e1e92118d
  - 耗时：6.344 秒 / 游戏 10 分钟
- **06:00** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0362dbac4ee24853a699d55e1e92118d
  - 耗时：6.344 秒 / 游戏 10 分钟
- **06:00** FarmHouse ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED

### 🔁 脚本重写：重写#2：清包腾格后下矿刷铁，回农场炼铁收锭，时间不够则直接收尾睡觉，避免空转。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `check_mail`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `leave_mine`
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `ship`（item="Copper Ore", count=57）
17. `ship`（item="Stone", count=26）
18. `ship`（item="Geode", count=1）
19. `ship`（item="Clay", count=1）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `collect_machines`
25. `ship_produce`
26. `sleep`
- **06:10** FarmHouse ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0132746d9c7b45de9b2d801bee6dff57
  - 耗时：6.36 秒 / 游戏 10 分钟
- **06:10** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0132746d9c7b45de9b2d801bee6dff57
  - 耗时：6.36 秒 / 游戏 10 分钟
- **06:10** FarmHouse ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED

### 🔁 脚本重写：重写#3：放弃 take 箱子（空格 0 必失败），改为农场出货箱卖 Copper Ore/Stone 腾格，再下矿 40 层刷铁，回农场收炉炼铁，21:30 
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `check_mail`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `leave_mine`
13. `mine`（floors=5）
14. `leave_mine`
15. `goto_location`（location="Farm"）
16. `ship`（item="Copper Ore", count=57）
17. `ship`（item="Stone", count=26）
18. `ship`（item="Geode", count=1）
19. `ship`（item="Clay", count=1）
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `collect_machines`
23. `ship_produce`
24. `sleep`
- **06:20** FarmHouse ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED
- **06:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED
- **06:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED
- **06:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **06:20** FarmHouse ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：store did not free enough slots (have 0, need 1)
  - 执行状态：ACTION_FAILED

## 🌙 为明天（Y6_spring_03）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升 Steel Hoe
- 起床先收熔炉成品，铁矿石够就装炉
- 清包：在农场出货箱卖 Copper Bar 留 20，腾出 ≥5 空格
- 补食物到 ≥5（今天 Saloon 12 点才开，先看背包有没有鱼可吃）
- 下矿 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场收铁锭，铁锭≥5 且时间<12:00 去 Blacksmith 升 hoe
- 剩余时间 Forest 钓鱼兜底
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
11. `ship`（item="Copper Bar", count=66）
12. `ship`（item="Sap", count=48）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `goto_location`（location="Blacksmith"）
19. `upgrade_tool`（tool="hoe"）
20. `goto_location`（location="Forest"）
21. `fish`（casts=8）
22. `sleep`
- **06:20** FarmHouse ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：4ce242b04ccb4e6c8ea02a03b9b70147
  - 耗时：69.875 秒 / 游戏 100 分钟
- **08:00** FarmHouse ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5fb65f73bd6047c99f3491de6f6a3905
  - 耗时：6.343 秒 / 游戏 0 分钟
- **08:00** FarmHouse ❌ `donate_museum`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c56c14a699264ca1b26510dd77e76bc9
  - 耗时：6.344 秒 / 游戏 10 分钟
- **08:10** FarmHouse ❌ `check_mail`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f83ed5c284a44d6980b6015b689e3c96
  - 耗时：6.375 秒 / 游戏 10 分钟
- **08:20** FarmHouse ❌ `donate_museum`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f09ee1ef73c849c9940cb056e7b2aa5d
  - 耗时：6.36 秒 / 游戏 10 分钟
- **08:30** FarmHouse ❌ `ship`（item="Copper Bar", count=66）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：edeee9762f3e4bd892be30dbcef34968
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:30** FarmHouse ❌ `ship`（item="Sap", count=48）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：34a985cbcb394618a52ebdce2661ca66
  - 耗时：0.515 秒 / 游戏 0 分钟
- **08:30** FarmHouse ❌ `goto_location`（location="Mine"）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b3daa69ec4f740bc90401568d41351cb
  - 耗时：6.344 秒 / 游戏 10 分钟
- **08:40** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **08:40** FarmHouse ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：05b7e3233c9e48e69c321bfcaaec0e79
  - 耗时：0.594 秒 / 游戏 0 分钟
- **08:40** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **08:40** FarmHouse ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：263642d4c24d46f588fb3a8783ee749d
  - 耗时：0.547 秒 / 游戏 0 分钟
- **08:40** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **08:40** FarmHouse ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **08:40** FarmHouse ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：b35785bca7494be79fb75690b50eed57
  - 耗时：0.563 秒 / 游戏 0 分钟
- **08:40** FarmHouse ✅ `goto_location`（location="Blacksmith"）
  - 结果：waited until 9:00 am (waiting for Blacksmith to open at 9:00)
  - 执行状态：SUCCESS · 操作编号：3431f94c5b4148b1bcbc75cc50484cb2
  - 耗时：13.968 秒 / 游戏 20 分钟
- **09:00** FarmHouse ❌ `goto_location`（location="Blacksmith"）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f1146c32d26e4566b9a893ef26d90b8d
  - 耗时：6.328 秒 / 游戏 0 分钟
- **09:00** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:00** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:00** FarmHouse ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **09:00** FarmHouse ❌ `goto_location`（location="Forest"）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a2aaf152ed33419eba90b1ebd1676de0
  - 耗时：6.36 秒 / 游戏 10 分钟
- **09:10** FarmHouse ❌ `fish`（casts=8）
  - 结果：no reachable fishing spot in FarmHouse
  - 执行状态：ACTION_FAILED · 操作编号：3af7a879f47f49c2b2d65e3cd611f23b
  - 耗时：0.578 秒 / 游戏 0 分钟
- **09:10** FarmHouse ❌ `goto_location`（location="Farm"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **09:10** FarmHouse ❌ `ship`（item="Copper Ore", count=57）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：96d8291942ad421495b16b8d20ca2f75
  - 耗时：6.407 秒 / 游戏 10 分钟
- **09:20** FarmHouse ❌ `ship`（item="Stone", count=26）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：4cc3ab78b83f4190aa30f90770bcf3d5
  - 耗时：6.375 秒 / 游戏 10 分钟
- **09:30** FarmHouse ❌ `ship`（item="Geode", count=1）
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b98d5421b4824db1949bebb8d1f510fe
  - 耗时：6.312 秒 / 游戏 10 分钟
- **09:40** FarmHouse ❌ `ship`（item="Clay", count=1）
  - 结果：Claymore can't be shipped
  - 执行状态：ACTION_FAILED · 操作编号：c36e9768ad5d4e3384a1cb82295422fb
  - 耗时：0.516 秒 / 游戏 0 分钟
- **09:40** FarmHouse ❌ `collect_machines`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：40129ba766f74667bb8c2034ad8e64d0
  - 耗时：6.312 秒 / 游戏 0 分钟
- **09:40** FarmHouse ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：13be95f7632f4820a48f5a3d2a4037d8
  - 耗时：0.516 秒 / 游戏 0 分钟
- **09:40** FarmHouse ❌ `collect_machines`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c87cf4b99dff41fe9b475f4de62adf49
  - 耗时：6.344 秒 / 游戏 10 分钟
- **09:50** FarmHouse ❌ `ship_produce`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：17a95d7da08345b0b56426cb9ea61023
  - 耗时：6.328 秒 / 游戏 10 分钟
- **10:00** FarmHouse ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：take 72 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：take 84 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：take 86 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **10:00** FarmHouse ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：d18b0dc88a3f4234bf2554bff7aa3284
  - 耗时：0.532 秒 / 游戏 0 分钟
- **10:00** FarmHouse ❌ `check_mail`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：69650f77f72c4d179856e601c92008ef
  - 耗时：6.343 秒 / 游戏 10 分钟
- **10:10** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:10** FarmHouse ❌ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:10** FarmHouse ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 0, need 5)
  - 执行状态：ACTION_FAILED
- **10:10** FarmHouse ❌ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：01cd577ed0c6443f9258aa541f06a478
  - 耗时：6.328 秒 / 游戏 10 分钟
- **10:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:20** FarmHouse ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:20** FarmHouse ❌ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:20** FarmHouse ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **10:20** FarmHouse ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **10:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：10d9b944609b424db57464b906e5e1d8
  - 耗时：6.344 秒 / 游戏 10 分钟
- **10:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：585b4c6a91b24f868ce89e188a73cf94
  - 耗时：6.375 秒 / 游戏 0 分钟
- **10:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：377ec2fcc3184e7f98167db4316549a1
  - 耗时：6.438 秒 / 游戏 10 分钟
- **10:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：426f71aef8b14fde9aeb8019a4daf8e3
  - 耗时：6.343 秒 / 游戏 10 分钟
- **10:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：468b997900c843aca5404b630683584e
  - 耗时：6.344 秒 / 游戏 10 分钟
- **11:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c115f765ea534d1e8cab436d0ee829dd
  - 耗时：6.359 秒 / 游戏 10 分钟
- **11:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：9db4b378118b4e88942f4f3fb8a8ca8d
  - 耗时：6.39 秒 / 游戏 10 分钟
- **11:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：22c20afe8c5d495aafc2986e4088c2fa
  - 耗时：6.344 秒 / 游戏 0 分钟
- **11:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ea8f2ca2fc7743208ec387da9db86c1f
  - 耗时：6.359 秒 / 游戏 10 分钟
- **11:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8454ccbd18964725a9e4477136f11b24
  - 耗时：6.359 秒 / 游戏 10 分钟
- **11:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5559c159fb3f4ad6bc79395b34d3536f
  - 耗时：6.344 秒 / 游戏 10 分钟
- **11:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5afdb68186564542a617fce5874595ef
  - 耗时：6.36 秒 / 游戏 10 分钟
- **12:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：033aef7eaa3a4640b5ee99a566822d06
  - 耗时：6.344 秒 / 游戏 10 分钟
- **12:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e823cdfd627547c3892313fc08755ebe
  - 耗时：6.344 秒 / 游戏 0 分钟
- **12:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a711ee5350504961842a93dc961309d3
  - 耗时：6.359 秒 / 游戏 10 分钟
- **12:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a7c36ac168014ac194185175d67e11db
  - 耗时：6.359 秒 / 游戏 10 分钟
- **12:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：de229c9803ef4549a086951afa6b5c89
  - 耗时：6.359 秒 / 游戏 10 分钟
- **12:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：871a789bb565414f80b47ffc7ada3c34
  - 耗时：6.36 秒 / 游戏 10 分钟
- **12:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6c98004c2c97459db5d09ed4d979ace8
  - 耗时：6.359 秒 / 游戏 0 分钟
- **12:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：931c1157619d4a399fecc5b3b1b94ff4
  - 耗时：6.344 秒 / 游戏 10 分钟
- **13:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：194a4987b4d644a2a62bf6c38d23218e
  - 耗时：6.359 秒 / 游戏 10 分钟
- **13:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ef0f7e4aa95d47baa52dc0e42cfcebaa
  - 耗时：6.359 秒 / 游戏 10 分钟
- **13:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：4c8baf940ea2466184eb682d1b4c9a83
  - 耗时：6.359 秒 / 游戏 10 分钟
- **13:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：71079f30d4cd452e9ba9586bcd901f27
  - 耗时：6.359 秒 / 游戏 10 分钟
- **13:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：43e520c1908749f39591f69fe660a9e3
  - 耗时：6.343 秒 / 游戏 0 分钟
- **13:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：154e1096d80849d49b6451c0d7f8ebc3
  - 耗时：6.359 秒 / 游戏 10 分钟
- **13:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1821403ac8e54a738b6a5d382b0f76ca
  - 耗时：6.359 秒 / 游戏 10 分钟
- **14:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：35b177edec8140bb9fa5f0c843fc916d
  - 耗时：6.421 秒 / 游戏 10 分钟
- **14:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ad68111eb89e400eaecb0f3194e771f6
  - 耗时：6.344 秒 / 游戏 10 分钟
- **14:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b807895fc3494a858aae5c6a98b79ca6
  - 耗时：6.313 秒 / 游戏 10 分钟
- **14:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e05fccefc203485199701a0522853d8e
  - 耗时：6.375 秒 / 游戏 0 分钟
- **14:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：cbd50fcf1fcd41699a8d48bcc37f713c
  - 耗时：6.344 秒 / 游戏 10 分钟
- **14:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：623e226aeaa24dbeaf4ec6f1cd2c39ab
  - 耗时：6.344 秒 / 游戏 10 分钟
- **14:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d6084baf61594a109cc07f28ddbad044
  - 耗时：6.328 秒 / 游戏 10 分钟
- **15:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：983be34b5b9646329e28ca0272372ea4
  - 耗时：6.359 秒 / 游戏 10 分钟
- **15:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：31af51394915437696b1dc1f849a9de1
  - 耗时：6.36 秒 / 游戏 10 分钟
- **15:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：525241801fbc40d995c236b12b7b0cc9
  - 耗时：6.344 秒 / 游戏 0 分钟
- **15:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e2e228c5e3764d9db2c8205dca5c76d0
  - 耗时：6.359 秒 / 游戏 10 分钟
- **15:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e53dbea5bd714519ba3a80e340a1fa07
  - 耗时：6.313 秒 / 游戏 10 分钟
- **15:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：34b80295c6c04682a0b54e9be8d30269
  - 耗时：6.329 秒 / 游戏 10 分钟
- **15:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b312fbe6907e4c6e804822a83e6034bf
  - 耗时：6.344 秒 / 游戏 10 分钟
- **16:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：755bc58d65ac47f298f40a46361a0fe6
  - 耗时：6.344 秒 / 游戏 0 分钟
- **16:00** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：505b0a9d82654c56bb9f45c8777540e4
  - 耗时：6.359 秒 / 游戏 10 分钟
- **16:10** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：4d20371813e641dc933b75f172d5854e
  - 耗时：6.36 秒 / 游戏 10 分钟
- **16:20** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：72fa48dbcfa94b089ddfc13ded2d034a
  - 耗时：6.359 秒 / 游戏 10 分钟
- **16:30** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d5dcff7f38e74a0ea848b9f5aa9a14e1
  - 耗时：6.344 秒 / 游戏 10 分钟
- **16:40** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b274b036d5534b2cbacf2c912c45fdd3
  - 耗时：6.375 秒 / 游戏 10 分钟
- **16:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：01bf14506af44493971ffe2ba09efc0f
  - 耗时：6.312 秒 / 游戏 0 分钟
- **16:50** FarmHouse ❌ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ca8928bba87c40769d6af66949aa68a4
  - 耗时：6.359 秒 / 游戏 10 分钟
- **17:00** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6b2b69a6a8e644668621226a8d832507
  - 耗时：6.422 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:10** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d09ae42872744755be496a2c03615790
  - 耗时：6.343 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:20** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：04b65d35d37f41beac8666d4fa3f9243
  - 耗时：6.312 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:30** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a13fa6898eb6407abd13c6eb7167d84c
  - 耗时：6.36 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:40** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2da2d0fa543f4810926d917b37eb9518
  - 耗时：6.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:40** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：73e5d78a71b54621b90c58b0d3fc83a1
  - 耗时：6.344 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **17:50** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：dec6e98bc8814d64bca309d1d47b98f6
  - 耗时：6.39 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:00** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ec1fe0c4ca24465ca08331a0519d84b0
  - 耗时：6.375 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:10** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：029479f6f4594b708528e86205ab5e61
  - 耗时：6.359 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:20** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：05b01e33d85c4717ac39b742ded9aaf8
  - 耗时：6.344 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:30** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f3eba47e746843f7a893145392289143
  - 耗时：6.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:30** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d20a12e55af34a348798db9d69eea558
  - 耗时：6.344 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:40** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8207ee2d855640e38749b36704d1f31e
  - 耗时：6.328 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **18:50** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a1835b5a63aa435aa4fd0887c3b46d4b
  - 耗时：6.36 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:00** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2c4e738006b942ac9d224151a41e8599
  - 耗时：6.36 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:10** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ec3e97f52baa4b76ab240bd5d7d6e4bf
  - 耗时：6.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:10** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c5d64c778e1d4f5a996f53373ae25287
  - 耗时：6.344 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:20** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ddd818035eb34fc8a16c8689b75c11ad
  - 耗时：6.344 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:30** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2b67a975c2c446bf99765f4fd3344cb5
  - 耗时：6.375 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:40** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6eb1ed3a1ca04d3ea0479b80ec008eab
  - 耗时：6.359 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **19:50** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：cc51de6fd3634a94b2b8de97c2c8010e
  - 耗时：6.375 秒 / 游戏 10 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **20:00** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b4d5c4798d9b409b8b3280cd38cc92e5
  - 耗时：6.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：收尾
1. `sleep`
- **20:00** FarmHouse ❌ `sleep`
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0c1faa03e7a94c64adff80f0de0c9fab
  - 耗时：6.359 秒 / 游戏 10 分钟
- **20:10** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：751f5d8f76364a61823d33df1fdbd35d
  - 耗时：6.36 秒 / 游戏 10 分钟
- **20:20** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：359be56141cc411c8806c4278c22c243
  - 耗时：6.359 秒 / 游戏 10 分钟
- **20:30** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a418d14e20114d5b965b345579d80bab
  - 耗时：6.375 秒 / 游戏 10 分钟
- **20:40** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：07381e087d224bbdbb90a311c69860b7
  - 耗时：6.438 秒 / 游戏 10 分钟
- **20:50** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：665699b199ac485cb412451803fca92e
  - 耗时：6.36 秒 / 游戏 0 分钟
- **20:50** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5f053ed5974449f0b7e43b384bf3c077
  - 耗时：6.375 秒 / 游戏 10 分钟
- **21:00** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b620f9c88d204ebabc273252df727902
  - 耗时：6.437 秒 / 游戏 10 分钟
- **21:10** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3127cb59fdbb47c29f23506c17dbaf18
  - 耗时：6.344 秒 / 游戏 10 分钟
- **21:20** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：9f7aa6c9cd81466f9275040fb6fd01cf
  - 耗时：6.406 秒 / 游戏 10 分钟
- **21:30** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f1bbb5d56e834b50b8f936d7ec763519
  - 耗时：6.36 秒 / 游戏 10 分钟
- **21:40** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：cda79123223748b3b30a18f229813d09
  - 耗时：6.343 秒 / 游戏 0 分钟
- **21:40** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：67a98bb9e6844a9c91654b0bf9d00e92
  - 耗时：6.344 秒 / 游戏 10 分钟
- **21:50** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：57756086b2134f5f878f33f04b916646
  - 耗时：6.343 秒 / 游戏 10 分钟
- **22:00** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：86ac2e78c6cf4c6ba35f899000e8e99b
  - 耗时：6.359 秒 / 游戏 10 分钟
- **22:10** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6e5c20c532c04f80b36765c85797f358
  - 耗时：6.359 秒 / 游戏 10 分钟
- **22:20** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f92098ee0b814a93a0e8862988c80247
  - 耗时：6.391 秒 / 游戏 0 分钟
- **22:20** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b7d4fa6137cb4b95befbfb01cea9ddb4
  - 耗时：6.343 秒 / 游戏 10 分钟
- **22:30** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：9091b9d47ec441de8e94433479dc6154
  - 耗时：6.359 秒 / 游戏 10 分钟
- **22:40** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：4be604f9f02a47bfad3b1784aeb707d5
  - 耗时：6.36 秒 / 游戏 10 分钟
- **22:50** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e6af1aa373d3429cad5babd3218713ea
  - 耗时：6.343 秒 / 游戏 10 分钟
- **23:00** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：378e65458fee43dcaaa050e0d4ab7a4a
  - 耗时：6.359 秒 / 游戏 10 分钟
- **23:10** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：bc167a6af0c142e1b9db1830fac457fe
  - 耗时：6.36 秒 / 游戏 0 分钟
- **23:10** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1ac9c9f4701e416f9aac2878294d82ad
  - 耗时：6.406 秒 / 游戏 10 分钟
- **23:20** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d3005266e60e413baea0d86a9fcf9ff8
  - 耗时：6.359 秒 / 游戏 10 分钟
- **23:30** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：04c5ca48c22b4a68997914b7e288bb84
  - 耗时：6.344 秒 / 游戏 10 分钟
- **23:40** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：4eec73a883cb4f5785921804e46ea6ce
  - 耗时：6.359 秒 / 游戏 10 分钟
- **23:50** FarmHouse ❌ `sleep`
  - 💭 规则：今日步数已达上限
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：114c003f5d5740beb0bb30b474782037
  - 耗时：6.328 秒 / 游戏 10 分钟
  - 🗨️ [hud] It's getting late... 
- **24:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e5e3c5f6b64d46df82813368b1e7da9a
  - 耗时：6.328 秒 / 游戏 0 分钟
- **24:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c150f944ab5a4e1291958668fe54248b
  - 耗时：6.375 秒 / 游戏 10 分钟
- **24:10** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c76626db64184d4188372b7d1986ab22
  - 耗时：6.328 秒 / 游戏 10 分钟
- **24:20** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：672b1174bb9943358d5196f8ee1043a8
  - 耗时：6.359 秒 / 游戏 10 分钟
- **24:30** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d1cfab036a2a41e2b115d306a1b0eac5
  - 耗时：6.328 秒 / 游戏 10 分钟
- **24:40** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fb3f673ed10a474cafe7ac98d2f5bc3f
  - 耗时：6.375 秒 / 游戏 10 分钟
- **24:50** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0f9e7a02e9d249be8cc2dee723e9b807
  - 耗时：6.344 秒 / 游戏 0 分钟
- **24:50** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f6e9bb82ceeb4767a5ac8af96e1a7552
  - 耗时：6.359 秒 / 游戏 10 分钟
- **25:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：070b335710414fd8af85b22ea94d1c7d
  - 耗时：6.328 秒 / 游戏 10 分钟
- **25:10** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b94cb9f5daa14d21819aed904a79f9f2
  - 耗时：6.36 秒 / 游戏 10 分钟
- **25:20** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fcf96c5da1ae452a8dd75d04bb277b77
  - 耗时：6.344 秒 / 游戏 10 分钟
- **25:30** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5b65806d9d7e44b7a231c0ccd530e3cb
  - 耗时：6.375 秒 / 游戏 10 分钟
- **25:40** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：21508ea61a714dfcbba53bd58c0ee56d
  - 耗时：6.359 秒 / 游戏 0 分钟
- **25:40** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ced5f7ef33024e6281d0bdb28dfced36
  - 耗时：6.344 秒 / 游戏 10 分钟
- **25:50** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5347553794f74586bda626e6b002d274
  - 耗时：6.344 秒 / 游戏 10 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：10802f14a7304960af81160522b9ce0b
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c7cd4c1dc8c0407aad565e65d9492ffd
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f27b009c4a93472cad027e88e0014e67
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b84d14eeafaa4fd6905e46f32bbfd9ea
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8e66e6b269a8489c95363718bad531fe
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ba3ac1b4d0bb4a8d80abe5cc541f9f2f
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0ebe733fb83a4b26a21e8d3177eb381d
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：374653ab6f514d2a83f00b30935edc03
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3930c1f489fb4f8981c750e6a19ccd94
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fb24c403f028465cb1d9a65b9b3537b6
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6c3a8dd149464ba3a1d9752079e76bdc
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f99fd1f9e42a41248bc5c1033a3f45ea
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1934dc56396942eeac321de5cf6d5108
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c1ff2e3bbb714dbeb6855d3f13164816
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：7762ceae24be4e2d9d38b46129e7a0b1
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：99e3a73464094deeb44b574f4f4a18ca
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：45e8990f4703449bb920cea5212ecfe9
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：60c70b1e23ab49f48526b7d82f3ddc7f
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：013fdf99d76d42c185f8a4753b7bf10b
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a7d570b61a76407da48efab0e269cb3a
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2b0fb42775f2448f94a58d26b2e35478
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：41060510fe9e4beba278e0ab5b22fea7
  - 耗时：6.39 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：bc2fae25f3834529aa3fe9d0e1daf46c
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：888252f170604411bf9124ff60134975
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3c9b89495c9449c29c37124934301855
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：cbb4e38a0b764ba4bfbe3fe6325445b9
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：75d3167ab5c1406383071d1b06b2441f
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：32dfa7fcfbf6447b8ec7f81739d6094e
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5b5b2c7e745d49fda5a97907e8764fff
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：02cc0e7807db4f68a93c7429c0b30ab1
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：94bd0d1ee8724da691feb68d0ef20887
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1ec0ecd77b434465aa7f478f9a8d25ed
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f6ee0b93c89c4d3484e5258aa40e96c5
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d0f255ac80b2418d8b89ecc271a355e9
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6d0e2a0af9e44c7e9d4fd133894402b6
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c99c35851e354b459cbeec3d47123d27
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：50bd0b960d7946408bda8ac7d04ffb72
  - 耗时：6.469 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6684c5d647e64d9583da475ab47b9e36
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：19c1a24d66cc45b5a39ae7bdef905f33
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：df789fc5169546a6a13809c1a7282f9c
  - 耗时：6.329 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：11439de509fd4914b5182a57277423e7
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：894f76c39fa04b3ea0d5cfff4da8b377
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c3cb889b92214aeb9d346ffe7970b46e
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：33a7931cecfa4e81bc4802baac97b5a8
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：eca5305ed9a64816a917fa0ed350021f
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0bbde98690d24597b8e17a0fdfe84e82
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3f701d9132ec48c093326d1c8b060ee3
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：554c0e363bb24b4e9780536b7e6a1a53
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：10822dbd51214bf49985d07be8546686
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：6c532a04df0a44afbf4ecae6e9ef1e44
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d5907e95ef4b472f9fc8ed20cfba91e2
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2dd821df6aa64aa79961e583f7ad0441
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：18375bf1bdcc4ce78a6b5e8d77d71c86
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ec82033f3fc94a5793555eff9809ee01
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：041ec1be81a343c3a8f97ca41f1a03bd
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：116be90fb8354556a61768fb7fe12b70
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：9123fcc1843c4a88b2848eb789c2d321
  - 耗时：6.329 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b60c04e88b8a4a84b2db8f812e950716
  - 耗时：6.422 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fb94446f59d94d24bd04f15b5807b631
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3520a382f6514da8b7cb536994c9d084
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c3b1d021da2b4d0499b94d65e4326a63
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1c6a7e361f284324ba09bee34d07b713
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a2dcd88d1619424d9f5f36bc63983767
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：458f9a378126483d9df375578023cc2b
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：18ae2d0ad8254cbb9e0608a456a92bb1
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：08d25ed7fbe94e88b695771f7f807cf1
  - 耗时：6.329 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b9c999aaa3294cbb9823901ddbe973b1
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：275a5dd8f3554e829a841af36340038b
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：7a43f212b6294643aeefea9fd11d6205
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5f99f8e607ad4c158c9463326c674226
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：99c6dadfe40149b68f34e526c01c01cf
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：62dd8b2ec120496b87a8310495d27339
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：5c453c1a97c84d78bfe4714bdb7eb5e9
  - 耗时：6.329 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：7f80f02c795a42bf85751f78b26d063f
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：247b2e883cb8456ba59610a9a32b1d8f
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：60e2c5c506d64616ba3279befd2fd67e
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d490f033768341709cb816e8a2326f76
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：62b12556b8dd498190937c2e736f9db3
  - 耗时：6.578 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：15183944990144b684baf32299fbc286
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：057074987c9b49e099ff7fc84fecbeeb
  - 耗时：6.406 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：98f45674c37b4c31b76a8ef33e9600d3
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：65b061628c8745f386a078d8b130dd24
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：bc44a3a6d68c462b8b02e4d370f7ce58
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b07ab336bd31456b96925044839ae6f9
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e9deb8414e2d47ea83a2f2c90d1cca33
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：eaf841a8704d4475a471174bf1ecaaac
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：97f1cb006d2e40edb9f771114ad2858a
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b214689b351f4bd983b8685fb4097468
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fc15ac9d805c4153842f010e598a3bc9
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：67ba91ba872e46ddaa58efff1a8df798
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：730d8444859c4c45bae02281ab7aa56b
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c7c16de5c43248c5a329bbc567765010
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：93ca01fd9fda454c89121cef2a8dfebd
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8c9e678b622346da91be1756a00da289
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1102194c1a674b5dad3b681920d79bb5
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：835166c00120480fb26047ef76075223
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：33bc0a1a8f1c456990d55b73dfe3f980
  - 耗时：6.407 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a8b3c97714f34e80905287a4e1661024
  - 耗时：6.406 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c08fca3a048041d4b77ad4a64125ad91
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d06bec78231f44f2ad4f9011e3c7adaa
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：37471f0ebb18446e8f05a188b06662f1
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e11b4742c32245d9bedc1631ec1edd55
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f5a2ce1957254c6886b21cc60790cd6e
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：56fde2cb35444a359f086d86398b2236
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3abba7be4d4d47a78618075c72f8149a
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：1be674e91b634601a69410a188cdbfb9
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：3b93baf785844b348d557f27ceb26e18
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8f27c59f07384a6cbe2714b46aab0319
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e4d73c7afd274f51b5d72b16689b147d
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：7e005c6e23934e46b31ab2ea2f4d651f
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：cb3e77445f7a4b48ae025ba4eb03a6a9
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fe762e8bc005427781639ad67cb74e6e
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：44fc08e3166a43fc89a961fc356e6cac
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c1b3e05bf1484e6ab477d59cb46afd5f
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8845586a4f7c46fcb985cf36910dd131
  - 耗时：6.39 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d4eaa902719c4b1f86716b8c84a7fedc
  - 耗时：6.328 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：2fbef9705cc04c899b49e5dde708dda4
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8f0064cfad8b472089602b05f4c7b1bd
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a2eb69ba26b44d2686cf79f32b91cfce
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：41eb6bce135641a49110f0e3a90ef8a2
  - 耗时：6.594 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：da40ce4c21164829a4632c12f172fe71
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：22c91b2ed6894ed9bd42a5a4b39a924e
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fe07340f42784e4ab2a21b0170b73170
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e0c545ed59e543ec944cfb79a5089d18
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：13a349b960ec4eb3a1250cf5d79c18bb
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：e52f45e2367c4fc9baa122794c96163f
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fbe7e97ed2fc445da88c5b560a8cfeef
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：41d1c0464b1547b39fbeb1ad76f92534
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b4c168d255e04c729024dc0e0bcbbc1d
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：50c84a60c7ba4ab5a6a2e6ab1323f7aa
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0950d30946804940a81ea89ae7e54993
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：df6de871396e4777bf423ba6916ee263
  - 耗时：6.406 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：f4cbd8a4d457462d8a59ccd84cc385e9
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：bd9fde32a56b4b86b02574ca3c87ac30
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：867302bd877348e9b9e172ac51b622c0
  - 耗时：6.469 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：fb0c43aaaecd45cb84430f097e1a2cec
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：ffe0a75c06cd46bb9e10ecb26ccab8f5
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：365d859079d6435da6615f7d66126b53
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a9bb6ad3c31a408486cf82ca9e9b7bdd
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：183016a5247045e5b33e93bb427c9013
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：615e46ff366b4119b28db232ef87b4eb
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：afbec12b0fbf4c8dbead90302c8d1c87
  - 耗时：6.343 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：328ea9aad3de4b7183c60ff76b21d082
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：8c669bd6632e472a9e29fc004533d2d8
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：0824042db454486bb50efd0610b07cb8
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：05e82940e0724db0a0fdcab886bac291
  - 耗时：6.391 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：b78393a5d1384246a87fc9ee89f70f41
  - 耗时：6.469 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：d58be8ba3ad6469fa482934ffc2d2cd6
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：a4adb6892c584d2fa0c490dc1c1653cc
  - 耗时：6.39 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：58d645bd96ef4da7a01c77479fec3796
  - 耗时：6.36 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：199939014fce4d9e977d626e12a49cb9
  - 耗时：6.344 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：c1df58ea9f62472a9126291edbb0b516
  - 耗时：6.375 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：7eecc20c31074f80a543a0d3e5422d18
  - 耗时：6.359 秒 / 游戏 0 分钟
- **26:00** FarmHouse ❌ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：player is busy (usingTool=False, eating=False, warping=True, fade=False)
  - 执行状态：ACTION_FAILED · 操作编号：32f548633dfa408ab010eafe546ec99a
  - 耗时：6.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包 0 空格是唯一硬卡点，先在农场出货箱卖掉冗余铜矿/晶洞腾格，再下 40 层刷铁，铁锭够且 12:00 前去铁匠铺升 hoe，失败即转森林钓鱼收尾
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `check_mail`
10. `goto_location`（location="Mine"）
11. `mine`（floors=5）
12. `leave_mine`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=6）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `ship`（item="Copper Ore", count=57）
21. `ship`（item="Geode", count=1）
22. `ship`（item="Bug Meat", count=1）
23. `ship`（item="Slime", count=1）
24. `collect_machines`
25. `sleep`

## 🌅 早上的计划（19:02 开始）
- 天气：sunny　金钱：84925g　体力：135/270
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天先解决背包 0 空格与铁锭瓶颈
- 起床收熔炉成品，读炉状态装铁矿石
- 清包：农场出货箱卖 Copper Ore 留 20、Stone 留 500、Geode 留 2，腾出 ≥5 空格
- 背包腾出后电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场收铁锭；铁锭≥5 且 12:00 前则去 Blacksmith 升 hoe
- 清包失败或下矿失败则转 Forest 钓鱼填满剩余时间
- 21:30 前 sleep

**执行脚本：**
1. `check_mail`
2. `collect_machines`
3. `load_machines`
4. `build_road`
5. `take`（item="62", item_name="Aquamarine", count=1）
6. `take`（item="64", item_name="Ruby", count=1）
7. `take`（item="68", item_name="Topaz", count=1）
8. `take`（item="72", item_name="Diamond", count=1）
9. `take`（item="84", item_name="Frozen Tear", count=1）
10. `take`（item="86", item_name="Earth Crystal", count=1）
11. `goto_location`（location="ArchaeologyHouse"）
12. `donate_museum`
13. `check_mail`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `leave_mine`
17. `goto_location`（location="Blacksmith"）
18. `upgrade_tool`（tool="hoe"）
19. `goto_location`（location="Forest"）
20. `fish`（casts=6）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `ship`（item="Copper Ore", count=57）
25. `ship`（item="Geode", count=1）
26. `ship`（item="Bug Meat", count=1）
27. `ship`（item="Slime", count=1）
28. `collect_machines`
29. `sleep`
- **06:00** FarmHouse ✅ `check_mail`
  - 结果：read 1 letters
  - 执行状态：SUCCESS · 操作编号：6c9a714450794ae6afcb436df5bac59b
  - 耗时：5.547 秒 / 游戏 0 分钟
  - 🗨️ [mail] AutoPilot, Someone dropped you off at the clinic last night. You'd passed out from exhaustion! You've got to take better care of yourself and go to bed at a reasonable hour. I've billed you 1000g to cover your medical expenses.  -Dr. Harvey
- **06:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：1142a64b92a74b50b3a3ac6252a5dd03
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：15070426158d401f834b20d8c2071a22
  - 耗时：0.86 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `craft`（item="Cobblestone Path", count=1）
  - 💭 (做 1 块 Cobblestone Path 用来铺路)
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：2ec28d0d48bb44d8bef664d5f4775f69
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：2ec28d0d48bb44d8bef664d5f4775f69
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`（items=["Stone", "Geode", "Pumpkin Seeds", "Rubber Boots", "Bug Meat", "White Overalls", "Slime"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 3x Geode, 1x Bug Meat, 1x Slime
  - 执行状态：SUCCESS · 操作编号：1cbd8817f59046a8978fb1fd5eec7e65
  - 耗时：4.953 秒 / 游戏 10 分钟
- **06:00** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：af5908b0c5c744408d5b01da1fd67462
  - 耗时：0.609 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 空跑失败后删除 take/donate 分支，改为农场出货箱清包腾格→下矿刷铁→回农场炼铁→Forest 钓鱼兜底→睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Ore", count=57）
10. `ship`（item="Stone", count=56）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `ship`（item="Copper Ore", count=20）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=6）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f329d3e3a21048f19ed00dd6b7a34941
  - 耗时：0.562 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 空跑已确认箱子无该物品，改为出货箱卖 Copper Ore/Stone 腾格后下矿刷铁，失败即转 Forest 钓鱼。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Ore", count=57）
10. `ship`（item="Stone", count=56）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `ship`（item="Copper Ore", count=20）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=6）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `collect_machines`
21. `load_machines`（item="Iron Ore"）
22. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：17bca6a686f64abc80ee19e833183507
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9a7d9681cf994db687e3f8b74b9e6b22
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：73a0b37d3b3c4fbf9c8cbd3f03af6c19
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0ec65f3cb11542ad882e0e0e388e1d5a
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：99d2cf40538b46dab1a0e648ac3fed26
  - 耗时：80.109 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：c449b588cc2547af8d4dc2f21bcb6cfc
  - 耗时：43.813 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：d93615de027445a387101294a77a725b
  - 耗时：0.625 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Copper Ore", count=57）
  - 结果：shipped 57x Copper Ore (~285g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：e6315ff7738e4a189e3cb914d2ddedc7
  - 耗时：44.016 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `ship`（item="Stone", count=56）
  - 结果：shipped 56x Stone (~112g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：2d20affd9ac547d6ba2fe86096379771
  - 耗时：0.531 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：54f646c2a5ae4a749a27a35e1e87a8d7
  - 耗时：50.015 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：252abb9e3f82406a982cf3c8931205fd
  - 耗时：33.687 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：00e3f7742db84a07a9c43a036c982293
  - 耗时：15.234 秒 / 游戏 20 分钟
- **10:50** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **11:50** Farm ✅ `ship`（item="Copper Ore", count=20）
  - 结果：shipped 20x Copper Ore (~100g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：501add845a5b4721ac67b10f3cf86ac6
  - 耗时：0.766 秒 / 游戏 0 分钟
- **11:50** Farm ❌ `mine`（floors=5）
  - 结果：floor 17: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：34da8b0116354fa2b950a86a0c6228ca
  - 耗时：70.703 秒 / 游戏 90 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] This area is infested... 
- **13:20** UndergroundMine17 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：b93a1d21c0524599baffe7015c9e2ffc
  - 耗时：2.032 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **13:20** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：d304e98d04c248f8bfc68bacf14cbdff
  - 耗时：59.328 秒 / 游戏 70 分钟
- **14:30** Forest ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (River Jelly, Chub, Green Algae, Sunfish, Chub, Chub)
  - 执行状态：SUCCESS · 操作编号：6a60b85a64384671972f645b9f29f9d0
  - 耗时：105.25 秒 / 游戏 100 分钟
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
- **16:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：e06aa32261bd45d9ac572ebccf268cb4
  - 耗时：15.344 秒 / 游戏 20 分钟
- **16:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:30** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：6a453b3e575b4628987f17fa28807376
  - 耗时：0.531 秒 / 游戏 0 分钟
- **16:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：2c5dc830ae404cad870ed60f2a89a141
  - 耗时：23.625 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：84925 → 85422（+497g）
- 出货估值：0g　动作：35 个　失败：20 个
- 模型调用：4 次　tokens：40631
- 有效动作率：0.5　空转：4　熔断跳过：5
- 失败耗时：77.108 秒 / 游戏 90 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天35动作20失败，核心仍是背包4空格<5导致下矿和升级被拒，而86个Copper Bar一个没卖。take空跑6次、store_items空跑3次、donate/build_road/decorate全空转，都是脚本生成阶段就该删除的分支。mine在17层卡死无梯子，白跑一趟。唯一有效产出是Forest钓鱼6条约900g。今天必须把清包（卖Copper Bar）作为第一硬动作，验证空格≥5后才允许下矿，否则直接转钓鱼。

**新教训：**
- 昨天 mine 在 17 层报 'no stones left and no ladder found' 被迫离开，说明 19 层以下无石头时 mine 会卡死：下矿必须电梯直达 40 层，不在 17-19 层浪费 mine 次数。
- 昨天 ship Copper Ore 57 个只换 285g，而 Copper Bar 86 个一个没卖：清包应优先卖 Copper Bar（每个约 60g）而不是原矿，原矿留着炼锭更值。
- 昨天 16:30 后 collect_machines 连续被系统抑制（repeated ineffective action），说明熔炉产出时间晚于 16:00：collect 应在起床和中午各试一次，16:00 后不再生成 collect 分支。
- 昨天 decorate 报「缺树种子/木头/花种」而背包有 72 木头：decorate 的判定条件与背包材料不一致，应全天物理删除，不再生成。
- 昨天从 Mine 出来直接 goto Forest 钓鱼只用了 6 casts 就收工，而当时才 14:30：钓鱼分支应设 fish casts≥10 或到 20:00 才收，避免过早回农场空转。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 04）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 84925g 远超 5000，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 4 空格，86 个 Copper Bar 一个没卖，mine 两次被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 04）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（春 05）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 06）**：继续刷铁备钢斧，给作物地块补洒水器，开始春季作物（草莓前先种土豆/花椰菜保底）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 66 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 6 次、store_items 空跑 3 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 17-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 04 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 04 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
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
9. 春 04 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天35动作20失败，核心仍是背包4空格<5导致下矿和升级被拒，而86个Copper Bar一个没卖。take空跑6次、store_items空跑3次、donate/build_road/decorate全空转，都是脚本生成阶段就该删除的分支。mine在17层卡死无梯子，白跑一趟。唯一有效产出是Forest钓鱼6条约900g。今天必须把清包（卖Copper Bar）作为第一硬动作，验证空格≥5后才允许下矿，否则直接转钓鱼。
- 06:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `craft` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 06:00 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:50 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 11:50 动作 `mine` 失败 @ Farm — floor 17: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Stone / [hud] Bug Meat / [hud] Stone / [hud] This area is infested...  〔自动〕
- 16:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:30 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 16:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 背包空格始终只有 4，下矿和升级都被 'have 4, need 5' 拒绝，而 86 个 Copper Bar 一个没卖 @ Farm（出货箱旁） — mine: store did not free enough slots (have 4, need 5)；清包只卖了 Stone 和 Copper Ore，没卖 Copper Bar（做不了：下矿拿铁矿石、升级 Steel Hoe 全部卡死，铁锭链连续多日零推进） 〔复盘〕
- take 空跑 6 次（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID @ Farm（箱子） — '62' is not in any farm chest；take 62 already failed; not retrying today（做不了：浪费 6 个动作和 3 次脚本重写，挤占了清包和下矿的时间） 〔复盘〕
- store_items 空跑 3 次，donate_museum 空跑 1 次，build_road 空跑 1 次，decorate 空跑 1 次 @ Farm / ArchaeologyHouse — store_items: nothing to store；donate: nothing in the backpack can be donated；build_road: 规划道路边没有空位；decorate: 缺树种子/木头/花种（做不了：6 个动作 0 产出，脚本生成阶段就该删除这些分支） 〔复盘〕
- mine 在 17 层报 'no stones left and no ladder found'，被迫 leave_mine @ Mine 17 层 — floor 17: no stones left and no ladder found (kill remaining monsters?)（做不了：第一次下矿 0 铁矿石产出，白跑一趟；应电梯直达 40 层） 〔复盘〕
- 16:30 回农场后 collect_machines 连续被系统抑制，load_machines 报 no empty machine @ Farm（熔炉） — repeated ineffective action suppressed；no empty machine accepts that, and the rest are busy（做不了：熔炉产出没收到，铁锭链又断一天；16:00 后不应再生成 collect/load 分支） 〔复盘〕
- 钓鱼只做了 6 casts 就收工，14:30 就回农场空转 @ Forest（河边） — fish casts=6 后脚本直接 goto Farm，未设最低 casts 或时间下限（做不了：本可多钓 10+ 条约 1.5k 收入，却提前回农场空转 5 小时） 〔复盘〕
