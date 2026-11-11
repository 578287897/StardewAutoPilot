# 第6年 spring 2 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（17:42 开始）
- 天气：sunny　金钱：84981g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：570c63682bb746fb87f191eb9492f23c
  - 耗时：3.359 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：0827c9285db742d69b61ff983703c232
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `clear_debris`（x=57, y=16, max=4）
  - 💭 (规划道路上的杂物 (57,16))
  - 结果：cleared 3 debris within 8 tiles of (57,16)
  - 执行状态：SUCCESS · 操作编号：962b9bc3f54e4459b328a80db854def3
  - 耗时：3.156 秒 / 游戏 0 分钟
  - 🗨️ [hud] Inventory Full
- **06:00** Farm ❌ `craft`（item="Cobblestone Path", count=1）
  - 💭 (做 1 块 Cobblestone Path 用来铺路)
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：311f155d4fd144abada441c677c21d7c
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** Farm ❌ `build_road`
  - 结果：can't craft Cobblestone Path: inventory full
  - 执行状态：ACTION_FAILED · 操作编号：311f155d4fd144abada441c677c21d7c
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Trash, 1x Coal, 1x Joja Cola
  - 执行状态：SUCCESS · 操作编号：6b0cab266b354ea8b686487a25e4da65
  - 耗时：7.75 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：3f81524f034c4de5addba2a2d3422e61
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：d32e5cd092554874957db93d81c705c6
  - 耗时：0.532 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~900g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：5a1c96666dfb470280ca2ed7bdf6b1c3
  - 耗时：0.781 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_02）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须突破铁锭瓶颈
- 起床收熔炉→装铁矿石→农场出货箱卖 Copper Bar 留 20 清出≥5 空格
- 电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场炼铁，铁锭≥5 且 12:00 前就去铁匠铺升 hoe
- 清包验证失败或下矿被拒就转 Forest 钓鱼兜底
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
11. `ship`（item="Copper Bar", count=66）
12. `ship`（item="Stone", count=22）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `load_machines`（item="Iron Ore"）
19. `goto_location`（location="Mine"）
20. `mine`（floors=5）
21. `leave_mine`
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `goto_location`（location="Blacksmith"）
25. `upgrade_tool`（tool="hoe"）
26. `goto_location`（location="Forest"）
27. `fish`（casts=5）
28. `fish`（casts=5）
29. `fish`（casts=5）
30. `goto_location`（location="Farm"）
31. `ship_produce`
32. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fd913a639bfb44f28e950eb6b14f5059
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败因箱子无该物品，删除 take/donate 分支；改为出货箱卖 Copper Bar 清包→40 层刷铁→升 hoe→钓鱼兜底。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=22）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Forest"）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `fish`（casts=5）
22. `fish`（casts=5）
23. `goto_location`（location="Farm"）
24. `collect_machines`
25. `load_machines`（item="Iron Ore"）
26. `collect_machines`
27. `ship_produce`
28. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：52d2e7c1e0bf41d7bb389b8ca1054ba5
  - 耗时：0.563 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 箱子坐标记忆已失效，改为出货箱卖 Copper Bar 腾格后下矿刷铁，失败即转 Forest 钓鱼。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=22）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `ship_produce`
26. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：eb2b6db230c34f5e8117d3eeb4af1ff6
  - 耗时：0.532 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 箱子物品连续失败已物理删除，改为出货箱卖 Copper Bar 清包后下矿刷铁，兜底 Forest 钓鱼，收尾 sleep。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=22）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `leave_mine`
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `collect_machines`
24. `load_machines`（item="Iron Ore"）
25. `ship_produce`
26. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ab8a9d36e9d04948863a405828e9047e
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：4041437c95604201844c7350af6dcc70
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c0aa676b70c34ba1a26ea1b8c372fc25
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：d94cc22f24d04955b34fe5f194ac171d
  - 耗时：75.578 秒 / 游戏 110 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：52d087b4123b4df1a7f4ef49e5c80e16
  - 耗时：44.14 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：407cfe3e928c4fada5edd49fbf6467e1
  - 耗时：0.578 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=66）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：f2db5fce419949d48187d39a67beaf7f
  - 耗时：0.516 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=22）
  - 结果：shipped 22x Stone (~44g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：4fe0c242a3f04fd48cbaada61c414826
  - 耗时：48.516 秒 / 游戏 60 分钟
- **09:50** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：fcce98eedf794819935a5a35f2c5b3f0
  - 耗时：49.078 秒 / 游戏 60 分钟
  - 🗨️ [hud] Fiber
- **10:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：8ae03c35d28846ab88c01daa3f7ae272
  - 耗时：33.688 秒 / 游戏 40 分钟
- **10:50** Mine ✅ `store_items`（items=["Fiber", "Green Algae", "Pumpkin Seeds", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Fiber, 5x Green Algae
  - 执行状态：SUCCESS · 操作编号：20bb09f6dd6e4b4db08de4430ec57240
  - 耗时：15.11 秒 / 游戏 20 分钟
- **10:50** Mine ❌ `mine`（floors=5）
  - 结果：cancelled: HTTP timeout
  - 执行状态：ACTION_FAILED · 操作编号：19e701143efc4cdebb652cbb1008fc39
  - 耗时：300.563 秒 / 游戏 410 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Stone
- **18:40** UndergroundMine16 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：18687efead9f4e84a17597f0e3e42ce7
  - 耗时：3.985 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **18:40** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：50a5ee9ab9e1405a96901cb9c59941be
  - 耗时：35.844 秒 / 游戏 40 分钟
- **18:40** Mine ✅ `store_items`（items=["Stone", "Bug Meat", "Pumpkin Seeds", "Fiber", "Rubber Boots"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Bug Meat, 1x Fiber
  - 执行状态：SUCCESS · 操作编号：047da89ba8fa47b087a09d04b7192981
  - 耗时：15.141 秒 / 游戏 20 分钟
- **18:40** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 16 (1 floors down, 72 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：1c889cf502ee4f5b964a8cff9ecfd3de
  - 耗时：115.063 秒 / 游戏 150 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] White Overalls
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Copper Ore
  - 🗨️ [question] 
- **22:10** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：55ef5c317e784141b4a36f7e9b70f917
  - 耗时：0.593 秒 / 游戏 0 分钟
- **22:10** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：d5a87c56e2bc4e6a88c04431b899c62d
  - 耗时：59.344 秒 / 游戏 80 分钟
- **23:30** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Bream, Green Algae, Chub, Bream, Bream)
  - 执行状态：SUCCESS · 操作编号：ea03c60c45f54846bd39edda4116024b
  - 耗时：120.453 秒 / 游戏 120 分钟
  - 🗨️ [hud] It's getting late... 
- **25:30** Forest ✅ `sleep`
  - 💭 规则：已过午夜，立即睡觉
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：2a127a4feda24bc785134e91c6b76103
  - 耗时：33.062 秒 / 游戏 0 分钟

## 📊 当天结算（第二天早上统计）
- 金钱：84981 → 84925（-56g）
- 出货估值：900g　动作：38 个　失败：20 个
- 模型调用：7 次　tokens：87284
- 有效动作率：0.5　空转：4　熔断跳过：6
- 失败耗时：311.065 秒 / 游戏 410 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
全天 38 动作 20 失败，核心卡点仍是背包空格<5：Copper Bar 86 个一个没卖，mine 被 'have 4, need 5' 拒绝，铁锭停在 1/5。take/store_items/donate/build_road 空跑 11 次，脚本重写 3 次仍重试同一批箱子 ID。唯一有效产出是 Forest 钓鱼 5 条。今天必须把清包做成硬前置：先读背包→农场出货箱卖 Copper Bar 留 20→验证空格≥5，验证不过直接转钓鱼，不生成任何 mine/upgrade 分支。

**新教训：**
- 昨天 ship Copper Bar 在 ArchaeologyHouse 报 'not found'，而材料显示背包有 86 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包完整清单，地点不对直接不生成 ship。
- 昨天 mine 在 Mine 报 'store did not free enough slots (have 4, need 5)'，说明 mine 动作本身会先尝试 store 再下矿：脚本生成阶段若背包空格<5 就物理删除 mine 分支，而不是等运行时被拒。
- 昨天 12 次 take 空跑后脚本重写 3 次仍重试同一批箱子 ID，说明重写逻辑没有先读背包：任何脚本重写前必须先读一次背包完整清单，只对清单里实际存在的物品生成动作。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 空转；而 Forest 钓鱼 5 条贡献约 900g：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支填满剩余时间。
- 昨天 22:20 才 sleep，全天 38 动作 20 失败：收尾应硬性 21:30，21:30 后只允许 sleep，任何情况下不用 wait 填充时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 03）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 84981g 远超 5000，唯一卡点 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 4 空格，86 个 Copper Bar 一个没卖，mine 两次被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 03）**：起床 collect→读背包→**农场出货箱 ship Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（春 04）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 05）**：继续刷铁备钢斧，给作物地块补洒水器，开始春季作物（草莓前先种土豆/花椰菜保底）。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后显式 ship Copper Bar count=背包数-20（约 66 个，约 4k，腾 3-4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 6 次、store_items 空跑 3 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 03 不买种子**：只做清包+下矿+钓鱼；种子等 13 日复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 03 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
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
9. 春 03 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 全天 38 动作 20 失败，核心卡点仍是背包空格<5：Copper Bar 86 个一个没卖，mine 被 'have 4, need 5' 拒绝，铁锭停在 1/5。take/store_items/donate/build_road 空跑 11 次，脚本重写 3 次仍重试同一批箱子 ID。唯一有效产出是 Forest 钓鱼 5 条。今天必须把清包做成硬前置：先读背包→农场出货箱卖 Copper Bar 留 20→验证空格≥5，验证不过直接转钓鱼，不生成任何 mine/upgrade 分支。
- 06:00 动作 `collect_machines` 失败 @ FarmHouse — no machine has finished output 〔自动〕
- 06:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:00 动作 `craft` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 06:00 动作 `build_road` 失败 @ Farm — can't craft Cobblestone Path: inventory full 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 10:50 动作 `mine` 失败 @ Mine — cancelled: HTTP timeout | 游戏消息: [hud] Stone / [hud] Bug Meat / [hud] Copper Ore / [hud] Stone / [hud] Copper Ore / [hud] Fiber / [hud] Stone 〔自动〕
- 22:10 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 背包空格始终只有 4 格，86 个 Copper Bar 一个没卖，清包动作全部空转 @ Farm（出货箱旁） — mine 返回 'store did not free enough slots (have 4, need 5)'；ship Copper Bar 在 ArchaeologyHouse 报 'not found'，在农场也没执行（做不了：下矿拿铁矿石、升级 Steel Hoe、做洒水器全部卡住） 〔复盘〕
- 脚本重写 3 次仍反复 take 同一批箱子 ID（62/64/68/72/84/86），全部不在农场箱子 @ Farm — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费 12 个动作和 3 次脚本重写，挤掉了下矿和钓鱼时间） 〔复盘〕
- 去 ArchaeologyHouse 捐博物馆，背包里没有可捐物 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：白跑一趟 Town，浪费上午时间） 〔复盘〕
- 在农场调 leave_mine 报不在矿洞 @ Farm — not in the mine（做不了：无实际阻塞，但浪费一个动作） 〔复盘〕
- craft Cobblestone Path 和 build_road 因背包满失败 @ Farm — can't craft Cobblestone Path: inventory full / 规划道路边没有还能走上去的空格（做不了：铺路计划完全落空，且 build_road 本身已无空位） 〔复盘〕
- mine 第一次 HTTP timeout 取消，第二次只下 1 层（15→16）就因背包近满退出 @ Mine — cancelled: HTTP timeout；backpack nearly full: store items before mining again（做不了：没拿到铁矿石，铁锭停在 1/5） 〔复盘〕
- 全天 20 个失败动作，有效动作仅 18 个，12:40 后基本空转 @ Farm / Town / Mine — 失败率 20/38≈53%，take/store_items/donate/build_road 合计空跑 11 次（做不了：铁锭、洒水器、升级三项里程碑全天零推进） 〔复盘〕
