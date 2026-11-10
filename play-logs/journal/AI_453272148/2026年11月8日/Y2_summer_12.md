# 第2年 summer 12 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（03:36 开始）
- 天气：sunny　金钱：4587g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y2_summer_12）准备的脚本
- 里程碑：钢水壶（差4铁锭+413g）——先收熔炉铁锭、装铁矿，再下矿拿铁矿石
- 洒水器×4 落地：先 hoe 清耕地格再 place
- 补食物到≥3（Saloon 12:10 后买沙拉）后下矿 20 层以下
- 现金兜底：Forest 河边钓鱼
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `use_tool`（tool="hoe", x=54, y=16, times=1）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `place`（item="Sprinkler"）
9. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber"]）
10. `goto_location`（location="Town"）
11. `open_shop`（shop_id="Saloon"）
12. `buy`（item="Salad", count=5）
13. `close_menu`
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `load_machines`（item="Iron Ore"）
20. `water_crops`
21. `goto_location`（location="Forest"）
22. `fish`（casts=4）
23. `fish`（casts=4）
24. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：f9b91a23a9114a919779e16a20323c68
  - 耗时：17.265 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：ab8aa01edfb54606bd563faef44f4563
  - 耗时：0.141 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 4x Sprinkler, 1x Coal, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：b55b20af026f4303900e9d8a42ca0ed4
  - 耗时：16.688 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 4 crops
  - 执行状态：SUCCESS · 操作编号：03d143d280fb4a04b2b04dd4e37f0bc0
  - 耗时：7.859 秒 / 游戏 10 分钟
  - 🗨️ [hud] Hops
- **06:50** Farm ✅ `water_crops`
  - 结果：watered 16 crops
  - 执行状态：SUCCESS · 操作编号：d8858b452e034588b1eb8c165fb72984
  - 耗时：30.563 秒 / 游戏 40 分钟
- **07:30** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~233g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：1942e1fdee3842d48ac245d8df6637bf
  - 耗时：10.453 秒 / 游戏 10 分钟
- **07:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：52d33981d33a41268a56c533481dab1b
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：捐不了（等巫师来信），跳过 donate，按原路线先装矿、清格放洒水器、买沙拉补食物后下矿，傍晚回农场装铁浇水睡觉。
1. `load_machines`（item="Iron Ore"）
2. `use_tool`（tool="hoe", x=54, y=16, times=1）
3. `place`（item="Sprinkler"）
4. `place`（item="Sprinkler"）
5. `place`（item="Sprinkler"）
6. `place`（item="Sprinkler"）
7. `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber"]）
8. `goto_location`（location="Town"）
9. `open_shop`（shop_id="Saloon"）
10. `buy`（item="Salad", count=5）
11. `close_menu`
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `fish`（casts=4）
19. `goto_location`（location="Farm"）
20. `load_machines`（item="Iron Ore"）
21. `water_crops`
22. `sleep`
- **07:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：806b2213f594443b8f3663112f385144
  - 耗时：0.141 秒 / 游戏 0 分钟
- **07:40** Farm ✅ `use_tool`（tool="hoe", x=54, y=16, times=1）
  - 结果：used hoe 1x at (54,16)
  - 执行状态：SUCCESS · 操作编号：0795251c74cc415ab39a77d3e5f6eb05
  - 耗时：6.735 秒 / 游戏 10 分钟
- **07:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **07:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **07:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **07:50** Farm ❌ `place`（item="Sprinkler"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **07:50** Farm ✅ `store_items`（items=["Geode", "Trash", "Broken CD", "Soggy Newspaper", "Joja Cola", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1bd75e2905a147d49ef867b968638931
  - 耗时：7.438 秒 / 游戏 10 分钟
- **08:00** Farm ✅ `goto_location`（location="Town"）
  - 结果：arrived at Town (0,54)
  - 执行状态：SUCCESS · 操作编号：50e98aadcddc4a959f97b3c0d5d116a9
  - 耗时：11.156 秒 / 游戏 10 分钟
- **08:10** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 10:10 am (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：ac878340640f47939b17c5dfd6492286
  - 耗时：80.781 秒 / 游戏 120 分钟
- **10:10** Town ✅ `open_shop`（shop_id="Saloon"）
  - 结果：waited until 12:00 pm (waiting for Saloon to open at 12:00)
  - 执行状态：SUCCESS · 操作编号：c51ef751dfd641f7b2c20b22613147f5
  - 耗时：80.422 秒 / 游戏 110 分钟
- **12:00** Town ❌ `open_shop`（shop_id="Saloon"）
  - 结果：can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：819c6845714a4b77abc69b2505eda65c
  - 耗时：0.141 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：Saloon 12:00 未就位打不开，放弃买沙拉，直接下矿拿铁矿再回农场装炉，剩余时间 Forest 钓鱼补现金。
1. `goto_location`（location="Mine"）
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `water_crops`
11. `sleep`
- **12:00** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：a04e04aa35a0421a9de2caa89cb9dec3
  - 耗时：47.797 秒 / 游戏 60 分钟
- **13:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：deef1eb00d1445aa8ef8497d9e8c9ce7
  - 耗时：0.187 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：矿洞因背包空格不足失败，先回农场存杂物清格、收装熔炉，再下矿两次拿铁矿石，傍晚钓鱼补现金后睡觉。
1. `leave_mine`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Farm"）
9. `store_items`（items=["Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Silver Saber", "Copper Ore", "Stone", "Coal", "River Jelly"]）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `load_machines`（item="Iron Ore"）
13. `water_crops`
14. `sleep`
- **13:00** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：84553fef2319478081eebd03d1bb9c95
  - 耗时：0.203 秒 / 游戏 0 分钟
- **13:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：8dd61223725d42a5afa19a1fee300736
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:00** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：549dbd0d2caf4d53a49ea9b520c83139
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:00** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：c2482b7118bc4b4493e09870aa231612
  - 耗时：0.141 秒 / 游戏 0 分钟
- **13:00** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：17372a6a6a4540eb8c2b26fe05b16257
  - 耗时：58.563 秒 / 游戏 70 分钟
- **14:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Dorado, Rainbow Trout, Pike)
  - 执行状态：SUCCESS · 操作编号：3f0292e9858f43c8868de8b1c7d8008d
  - 耗时：110.265 秒 / 游戏 110 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Dorado
  - 🗨️ [hud] Rainbow Trout
- **16:00** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, River Jelly, Rainbow Trout, Green Algae)
  - 执行状态：SUCCESS · 操作编号：c476c8cdbb9e417c9fb8e7f93ab75a29
  - 耗时：96.656 秒 / 游戏 110 分钟
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Rainbow Trout
- **17:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：73f26eaee23f4fd1a2c16031eabdf899
  - 耗时：15.157 秒 / 游戏 20 分钟
- **18:10** Farm ✅ `store_items`（items=["Dwarf Scroll I", "Cobblestone Path", "Bamboo Pole", "Silver Saber", "Copper Ore", "Stone", "Coal", "River Jelly"]）
  - 结果：stored in chest at (74,15): 1x Coal, 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：271dc71404bb475fb22e2f49b058e716
  - 耗时：21.078 秒 / 游戏 30 分钟
- **18:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：aca6ca7d6991428ab2822d61a586949f
  - 耗时：0.156 秒 / 游戏 0 分钟
- **18:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：682136efb9f34c53bf462ae3c95dfb30
  - 耗时：0.14 秒 / 游戏 0 分钟
- **18:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **18:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：7db4c53f482e45c593a595b230a50f19
  - 耗时：0.172 秒 / 游戏 0 分钟
- **18:40** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：08b19bf0bfb247b2a47c89089022974b
  - 耗时：7.25 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4587 → 4820（+233g）
- 出货估值：233g　动作：34 个　失败：16 个
- 模型调用：5 次　tokens：62881
- 有效动作率：0.5333　空转：5　熔断跳过：3
- 失败耗时：1.86 秒 / 游戏 0 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
洒水器连续两天craft成功却place失败，根因是分区无空位且未先hoe清格；熔炉load反复失败因炉未空；下矿因背包空格不足白跑。钓鱼稳定但现金仍不足钢水壶。今天先清格放洒水器，再清背包下矿，熔炉只collect不load。

**新教训：**
- 洒水器 place 返回「分区无空位」时，hoe 清一格后必须重新 place 同一格；昨天 hoe 了 (54,16) 但 place 仍报无空位，说明清格位置不在规划分区内，应先确认分区坐标再清。
- 熔炉 load 返回「no empty machine accepts anything」时，若背包和箱子都没有可装矿石，说明炉子还在炼或已满，当天不再 load，直接转下矿或钓鱼。
- 下矿前 store_items 只清到 5 空格仍可能因矿洞内拾取过快再满：下矿前清到 ≥7 空格更稳，矿石优先拾取。
- Saloon 12:00 整 open_shop 仍失败，说明店主就位有延迟；12:10 后去，且失败一次即放弃，改钓鱼吃鱼补食物。
- 现金 4587g 距钢水壶 5000g 只差 413g，今天钓鱼 2 轮即可补足；不要为省时间跳过钓鱼直接下矿，否则明天仍不够升级。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏13）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 4587g，铁锭 1，Iron Ore 3，Coal 16，Copper Bar 57，Stone 2387，Wood 1。差约 413g + 4 铁锭。
并行里程碑：**洒水器×4 落地**——已 craft 4 个，连续两天 place 失败（分区无空位），今天第一件事必须 hoe 清格后放下。
之后：**钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵**——鱼饵已用完，需去威利店买 Bait。
接下来 3 天主活动：
- **今天（夏13）**：① hoe 清 4 格并 place 4 个洒水器（最多 6 次 place，失败即停）；② collect 熔炉 1 次，炉空立刻 load Iron Ore 5 块（只 1 次）；③ 清背包到 ≥5 空格；④ 补食物到 ≥3（Saloon 沙拉或钓鱼吃鱼）；⑤ 下矿 20 层以下拿铁矿石+煤（≤2 次 mine，超时即停）；⑥ 回农场 load 铁矿 1 次（仅炉空）；⑦ 现金<700g 去 Forest 河边钓鱼 ≤2 轮；⑧ 22:00 前 sleep。
- **明天（夏14）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤，钓鱼补现金。
- **后天（夏15）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先）**：背包有 Sprinkler 就 `place` 到耕地；返回「分区无空位」则 `use_tool` hoe 清一格耕地再 place，最多试 6 次（4 个洒水器各需一格），失败即跳过。**place 前先读背包确认有 Sprinkler。**
2. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 3 步。
3. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
4. **清背包到 ≥5 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<5 时禁止下矿。**买鱼饵前也先清到 ≥3 空格。**
5. **补食物到 ≥3**：背包回血食物<3 且现金≥400g 时，**12:10 后**去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃，改钓鱼吃鱼补食物。
6. **下矿（主活动）**：食物≥3、空格≥5 才 `goto_location` Mine → `mine` 目标 20 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
9. **买鱼饵**：先清背包到 ≥3 空格，再去 **Mountain 的 FishShop**（威利店在 Mountain 地图，不是 Beach）`open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。open_shop 失败一次即放弃。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
11. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
12. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格再 place，最多 6 次，不在地图外乱放。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥5**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<5 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **Saloon 只试 1 次**：`open_shop` Saloon 失败一次即当天放弃，不重试、不在门口等；12:10 前不靠近 Town/Saloon。
- **FishShop 在 Mountain**：威利店入口在 Mountain 地图（15,40 附近），不在 Beach；去 Beach 会因节日锁门或位置错误失败。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y；返回「tile cleared」立即换格。
- **build_road / decorate / clear_debris 禁用**：连续两天铺路/装饰浪费 10+ 动作，全部失败或低效。
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
- **下矿背包管理**：下矿前空格≥5；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. hoe 清格并 place 4 个洒水器（今天第一件事，最多 6 次 place）
2. collect 熔炉取锭（仅 1 次，空即跳第 3 步）
3. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
4. 清背包到 ≥5 空格
5. 补食物到 ≥3（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
6. 下矿 20 层以下拿铁矿石+煤（食物≥3、空格≥5 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 买鱼饵（先清背包 ≥3 空格，Mountain 的 FishShop ≤20 个）
10. 浇水（水壶在背包时）
11. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
12. 社交（仅顺路）
13. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 洒水器连续两天craft成功却place失败，根因是分区无空位且未先hoe清格；熔炉load反复失败因炉未空；下矿因背包空格不足白跑。钓鱼稳定但现金仍不足钢水壶。今天先清格放洒水器，再清背包下矿，熔炉只collect不load。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 07:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:50 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 07:50 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 07:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 07:50 动作 `place` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `open_shop` 失败 @ Town — can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 13:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 13:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:00 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 18:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 18:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 18:40 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 洒水器 craft 成功但连续两天 place 失败，4 个洒水器一直放不下去 @ Farm 耕地 — place 返回「Sprinkler 在规划的分区里没有空位了」和「今天已确认分区无空位」；昨天 hoe 了 (54,16) 但 place 仍失败（做不了：无法停止手动浇水，体力无法全部用于下矿/钓鱼） 〔复盘〕
- 熔炉 load 反复失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything in the backpack or the farm chests」和「repeated ineffective action suppressed」（做不了：钢水壶里程碑差 4 铁锭，无法推进） 〔复盘〕
- 下矿因背包空格不足白跑一趟 @ Mine 入口 — mine 返回「need at least 5 free backpack slots before mining; store_items first」，连续 3 次失败（做不了：拿不到铁矿石和煤，铁锭无法增加） 〔复盘〕
- Saloon 12:00 整 open_shop 失败，买不到沙拉补食物 @ Town Saloon — open_shop 返回「can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)」，脚本在门口等到 12:00 仍失败（做不了：食物不足，无法安全下 20 层以下矿） 〔复盘〕
- donate 在 wait_letter 阶段必失败，浪费动作 @ Community Center — donate 返回「can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon」（做不了：社区中心献祭无法推进，等巫师来信） 〔复盘〕
- collect_machines 返回空后当天没有有效 load，熔炉空转 @ Farm 熔炉 — collect_machines 返回「no machine has finished output」，之后 load 全失败（做不了：铁锭当天零产出） 〔复盘〕
