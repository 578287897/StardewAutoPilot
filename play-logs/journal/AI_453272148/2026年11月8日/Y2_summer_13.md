# 第2年 summer 13 日 — AI 游玩日志
（写入日期：2026年11月8日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（03:47 开始）
- 天气：storm　金钱：4820g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：fe44492f949f4050a45a022ac3cac59c
  - 耗时：0.203 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：0bde7ff09a4a4fdda9b3577229442e94
  - 耗时：3.14 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：8688e911a77746ddb227e13c65c871ab
  - 耗时：2.969 秒 / 游戏 0 分钟

## 🌙 为明天（Y2_summer_13）准备的脚本
- 里程碑：钢水壶（凑 5 铁锭 + 5000g）
- 先清背包到 ≥7 空格，再下矿拿铁矿石和煤
- 回农场装熔炉炼铁，凑够 5 铁锭且现金 ≥5000g 就升钢水壶
- 现金不足则去 Forest 河边钓鱼补钱
- 顺路去 Mountain 鱼店买 Bait
1. `donate`
2. `store_items`（items=["Green Algae", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Copper Ore", "Stone", "Coal", "River Jelly", "Rainbow Trout", "Pike", "Dorado", "Rice Shoot", "Garlic Seeds"]）
3. `collect_machines`
4. `load_machines`（item="Iron Ore"）
5. `goto_location`（location="Mine"）
6. `mine`（floors=10）
7. `mine`（floors=10）
8. `goto_location`（location="Farm"）
9. `load_machines`（item="Iron Ore"）
10. `collect_machines`
11. `goto_location`（location="Forest"）
12. `fish`（casts=4）
13. `fish`（casts=4）
14. `goto_location`（location="Mountain"）
15. `open_shop`（shop_id="FishShop"）
16. `buy`（item="Bait", count=20）
17. `close_menu`
18. `goto_location`（location="Farm"）
19. `water_crops`
20. `sleep`
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 6 crops
  - 执行状态：SUCCESS · 操作编号：2e613dd9a2f84d99a25603a37517e43d
  - 耗时：14.516 秒 / 游戏 20 分钟
  - 🗨️ [hud] Hops
  - 🗨️ [hud] Hops
- **06:20** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：45ebac8550af44ab965bd5cb2a165e24
  - 耗时：0.14 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 5 stacks worth ~581g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：7d7d2be4ed094c2aaceb857216a8b77b
  - 耗时：9.719 秒 / 游戏 10 分钟
- **06:30** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：33759fd81bc143fda3c2dbd78ee00926
  - 耗时：0.157 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：捐不了就跳过，先清背包下矿拿铁矿石，回农场装炉，再去Forest钓鱼补现金和Mountain买鱼饵，最后睡觉。
1. `store_items`（items=["Green Algae", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Stone", "River Jelly"]）
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Mine"）
5. `mine`（floors=10）
6. `mine`（floors=10）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Mountain"）
11. `open_shop`（shop_id="FishShop"）
12. `buy`（item="Bait", count=20）
13. `close_menu`
14. `goto_location`（location="Farm"）
15. `load_machines`（item="Iron Ore"）
16. `sleep`
- **06:30** Farm ✅ `store_items`（items=["Green Algae", "Dwarf Scroll I", "Bamboo Pole", "Silver Saber", "Stone", "River Jelly"]）
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：c245aa2ad8564fd184839d4b77be55e3
  - 耗时：1.109 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：03a3a64cd6c344a9924af1ce54966833
  - 耗时：0.188 秒 / 游戏 0 分钟
- **06:30** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：23358041a37c499196361f0d7db5f5a8
  - 耗时：0.187 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：490560f35c9447c78a07bf4767a26c16
  - 耗时：45.188 秒 / 游戏 60 分钟
- **07:30** Mine ❌ `mine`（floors=10）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：c9458acf81404ba18a56d25bf902fc2a
  - 耗时：8.125 秒 / 游戏 10 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Stone
  - 🗨️ [hud] This area is infested... 

### 🔁 脚本重写：重写#2：16层无石无梯，先清怪找梯子继续下矿拿铁，回农场装炉后钓鱼补现金并顺路买鱼饵。
1. `fight`（range=6）
2. `fight`（range=6）
3. `mine`（floors=6）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Mountain"）
8. `open_shop`（shop_id="FishShop"）
9. `buy`（item="Bait", count=20）
10. `close_menu`
11. `goto_location`（location="Farm"）
12. `load_machines`（item="Iron Ore"）
13. `sleep`
- **07:40** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：b6406e0ea32e433cadeb58cd7af1d126
  - 耗时：0.14 秒 / 游戏 0 分钟
- **07:40** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：11c227779f1d47d2b755d5fdd8254a6a
  - 耗时：0.125 秒 / 游戏 0 分钟
- **07:40** UndergroundMine16 ❌ `mine`（floors=6）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：c6ee2652d4e54cb9920def05c3135c10
  - 耗时：0.156 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：16层无石无梯，先清怪两次再试下矿，之后按原路线钓鱼买饵回农场装炉睡觉。
1. `fight`（range=6）
2. `fight`（range=6）
3. `mine`（floors=4）
4. `leave_mine`
5. `goto_location`（location="Forest"）
6. `fish`（casts=4）
7. `fish`（casts=4）
8. `goto_location`（location="Mountain"）
9. `open_shop`（shop_id="FishShop"）
10. `buy`（item="Bait", count=20）
11. `close_menu`
12. `goto_location`（location="Farm"）
13. `load_machines`（item="Iron Ore"）
14. `sleep`
- **07:40** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：32519e7c9cfa4a83ab07f2146d23d2d0
  - 耗时：0.14 秒 / 游戏 0 分钟
- **07:40** UndergroundMine16 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：f3342393317d4e4bb102ce1c9562507d
  - 耗时：0.156 秒 / 游戏 0 分钟
- **07:40** UndergroundMine16 ❌ `mine`（floors=4）
  - 结果：floor 16: no stones left and no ladder found (kill remaining monsters?)
  - 执行状态：ACTION_FAILED · 操作编号：8545169f87064f2bb134ef91110ce504
  - 耗时：0.172 秒 / 游戏 0 分钟
- **07:40** UndergroundMine16 ✅ `leave_mine`
  - 结果：left the mine, now in Mine
  - 执行状态：SUCCESS · 操作编号：51da5ddd5fbb4c5fb6c060016c977fa0
  - 耗时：1.829 秒 / 游戏 0 分钟
  - 🗨️ [question] 
- **07:40** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：5c689cd1c19948c99fabbef759f5233f
  - 耗时：59.125 秒 / 游戏 70 分钟
- **08:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Chub, treasure: Copper Ore), 1 got away
  - 执行状态：SUCCESS · 操作编号：1bcac7be24af463a9971619fb2fca301
  - 耗时：102.781 秒 / 游戏 90 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Chub
- **10:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Pike, Pike, Broken Glasses, Shad)
  - 执行状态：SUCCESS · 操作编号：a0399b80c0224ebbb4e4ca3432a3c837
  - 耗时：77.219 秒 / 游戏 80 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Broken Glasses
- **11:40** Forest ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：e3c36b1505c740b28486b3dbadc8000f
  - 耗时：45.953 秒 / 游戏 60 分钟
- **12:40** Mountain ❌ `open_shop`（shop_id="FishShop"）
  - 结果：can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent)
  - 执行状态：ACTION_FAILED · 操作编号：9ec151213fdb46808a3d1e6d68b05b80
  - 耗时：0.14 秒 / 游戏 0 分钟
- **12:40** Mountain ❌ `buy`（item="Bait", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：bd1364c3347b4d559bde7113bcf6b5a0
  - 耗时：0.14 秒 / 游戏 0 分钟
- **12:40** Mountain ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：5910d313df6248a69668b5ca1eaa7bc6
  - 耗时：0.125 秒 / 游戏 0 分钟
- **12:40** Mountain ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：7491f30c94864c0083bcea0abb075ed1
  - 耗时：24.156 秒 / 游戏 30 分钟
- **13:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：117c76d6fa7a45a7969167f5804a13bf
  - 耗时：0.156 秒 / 游戏 0 分钟
- **13:10** Farm ✅ `load_machines`
  - 结果：loaded: Copper Ore -> Furnace (ready in 20 min)
  - 执行状态：SUCCESS · 操作编号：f0b7a2f38f2e4587b95ccc7fbb5e81fe
  - 耗时：7.391 秒 / 游戏 10 分钟
- **13:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：de6b8923cc394a08b5ab79095cb6347e
  - 耗时：0.203 秒 / 游戏 0 分钟
- **13:20** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
  - 执行状态：SUCCESS · 操作编号：a0e1e04d04824d20a210e8a7627235d1
  - 耗时：0.125 秒 / 游戏 0 分钟
- **13:20** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：4c236772c505491b9ea9cc472c0d28d1
  - 耗时：9.968 秒 / 游戏 10 分钟
- **13:30** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a5b3e04112324a27b646f1ee807a0eb2
  - 耗时：0.125 秒 / 游戏 0 分钟
- **13:30** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：5ad48e0e1eef4459bb46b872061b927f
  - 耗时：12.703 秒 / 游戏 10 分钟
- **13:40** Farm ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：e7cfcd1ecbd44d6a948d0e5ac5b5bd40
  - 耗时：12.515 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **14:00** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：c350ab6382944c0283a8e36ee7eb29ea
  - 耗时：0.156 秒 / 游戏 0 分钟
- **14:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：ca2ceb1aea04469f86a2516e006383f0
  - 耗时：31.844 秒 / 游戏 50 分钟
- **14:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:50** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：ACTION_FAILED
- **14:50** Farm ✅ `fish`（casts=3）
  - 结果：fished: caught 3 (Broken CD, Joja Cola, Broken CD)
  - 执行状态：SUCCESS · 操作编号：1018ca57aabb4050a524b4d15dc75687
  - 耗时：51.125 秒 / 游戏 60 分钟
- **15:50** Farm ✅ `ship`（item="Broken Glasses", count=1）
  - 💭 (背包快满：钓到的垃圾扔进出货箱)
  - 结果：shipped 1x Broken Glasses (~0g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：5862cd40e53c4da7bae04d29ff296cd4
  - 耗时：15.14 秒 / 游戏 30 分钟
- **16:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：7690ba6e270b42b8aae2ab71e011a0bf
  - 耗时：0.14 秒 / 游戏 0 分钟
- **16:20** Farm ✅ `build_road`
  - 结果：laid 8 Cobblestone Path tiles (0 already done, 16 skipped: blocked by trees/crops/objects)
  - 执行状态：SUCCESS · 操作编号：f1a04850bf37491788103403f8fe4983
  - 耗时：41.329 秒 / 游戏 50 分钟
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c7b6432e70d541c8b45dea4646b94c8e
  - 耗时：16.938 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：4820 → 5401（+581g）
- 出货估值：581g　动作：44 个　失败：20 个
- 模型调用：5 次　tokens：61927
- 有效动作率：0.5349　空转：11　熔断跳过：0
- 失败耗时：64.888 秒 / 游戏 80 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天44动作失败20，核心卡点：4个洒水器craft成功却因分区无空位全天没放下；熔炉load反复失败铁锭零产出；矿洞16层infested层连调mine无果；14:00-16:40在load/build_road/decorate上空转。有效：Forest钓鱼稳定出Pike补现金，出货581g。今天必须把洒水器落地和铁锭产出作为硬目标，失败即熔断转钓鱼。

**新教训：**
- 洒水器 place 返回「分区无空位」时，hoe 清格必须清在规划分区坐标内；昨天 hoe 了 (54,16) 但 place 仍失败，说明清格位置不在分区内，应先读分区坐标再清。
- 矿洞 16 层是 infested 层，fight 4 次后仍无梯子说明该层需要清完所有怪才出梯；清怪 2 次无果即 leave_mine 换层，不要在同一层连调 mine。
- 熔炉 load 返回「no empty machine accepts anything」时，若背包和箱子都没有可装矿石，说明炉子还在炼或已满，当天不再 load，直接转下矿或钓鱼。
- 下矿前 store_items 只清到 5 空格仍可能因矿洞内拾取过快再满：下矿前清到 ≥7 空格更稳，矿石优先拾取。
- 现金 4820g 距钢水壶 5000g 只差 180g，今天出货到账后基本够；不要为省时间跳过钓鱼直接下矿，否则明天仍不够升级。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 夏14）

## 长期目标
当前里程碑：**工具按档升级——钢水壶**（5000g + 5 铁锭）。现状：现金 4820g（出货后约 5400g），铁锭 1，Iron Ore 3，Coal 16，Copper Bar 58，Stone 2369，Wood 1。差约 4 铁锭；钱今天出货到账后基本够。
并行里程碑：**洒水器×4 落地**——已 craft 4 个，连续两天 place 失败。今天必须用 hoe 清格后放下，否则体力永远被浇水吃掉。
之后：**钓鱼 2 级 + 玻璃纤维钓竿 + 鱼饵**——鱼饵已用完，去 Mountain 的 FishShop 买 Bait。
接下来 3 天主活动：
- **今天（夏14）**：① 先确认洒水器在背包，去耕地用 hoe 清格并 place（最多 6 次，失败即停，改下矿前再试一次）；② collect 熔炉 1 次，炉空立刻 load Iron Ore（只 1 次）；③ 清背包到 ≥7 空格；④ 补食物到 ≥3；⑤ 下矿 40 层以下拿铁矿石+煤（≤2 次 mine，infested 层 fight 2 次无梯即换层）；⑥ 回农场 load 铁矿 1 次；⑦ 现金<700g 去 Forest 钓鱼 ≤2 轮；⑧ 22:00 前 sleep。
- **明天（夏15）**：收铁锭；铁锭≥5 且现金≥5000g 升钢水壶；否则继续下矿补铁/煤。
- **后天（夏16）**：洒水器铺满耕地，下矿补铁，钓鱼补现金。

## 每日固定流程（按顺序，失败一次即跳下一步，不重写脚本重跑已完成动作）
1. **洒水器 place（今天第一优先，最多 6 次）**：先读背包确认有 Sprinkler；`place` 到耕地，返回「分区无空位」则 `use_tool` hoe 清一格**规划分区内**的耕地再 place 同一格；连续 3 次仍失败则记下坐标，当天不再 place，转第 2 步。
2. **熔炉 collect（仅 1 次）**：`collect_machines` 1 次。返回空当天永久跳过 collect，立即进第 3 步。
3. **熔炉 load（collect 后立刻做，只试 1 次）**：collect 后 `load_machines` 装 Iron Ore 5 块（不足 5 块装 Copper Ore 保炉不空）。返回 busy/no empty 立即熔断，当天不再 load（下矿回农场那 1 次除外）。**今天 load 总次数≤2。**
4. **清背包到 ≥7 空格**：`store_items` 把 Geode/Trash/Algae/多余工具存箱子；背包空格<7 时禁止下矿。买鱼饵前也先清到 ≥3 空格。
5. **补食物到 ≥3**：背包回血食物<3 且现金≥400g 时，**12:10 后**去 Saloon：`goto_location` Town → `open_shop` Saloon **只试 1 次** → 成功则 `buy` Salad×5 → `close_menu`。失败一次即放弃，改钓鱼吃鱼补食物。
6. **下矿（主活动）**：食物≥3、空格≥7 才 `goto_location` Mine → `mine` 目标 40 层以下拿铁矿石+煤，**≤2 次 mine**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 超时一次即当天不再调 mine，转钓鱼。**
7. **熔炉装铁（下矿后必做，只试 1 次）**：回农场 `load_machines` 装 Iron Ore 1 次（仅炉空时）。
8. **现金兜底**：现金<700g 去 **Forest 河边** `fish` ≤2 轮（每轮 ≤4 cast），钓到 ≥700g 或连续 2 轮垃圾即停。不在 Farm 池塘连钓。
9. **买鱼饵**：先清背包到 ≥3 空格，再去 **Mountain 的 FishShop**（威利店在 Mountain 地图，不是 Beach）`open_shop` FishShop → `buy` Bait×20 → `close_menu`，16:30 前完成。open_shop 失败一次即放弃。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」跳过。
11. **工具升级**：仅当现金≥5000g 且铁锭≥5，9:10-15:30 去 Blacksmith `upgrade_tool` 钢水壶 1 次；不够直接跳过。
12. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **place 前先确认背包有该物品**；**craft 前先实时读材料**，返回「not enough ingredients」后当天不再 craft 同一物品。
- **place 失败先清耕地**：返回「分区无空位」时用 hoe 清一格**规划分区内**的耕地再 place 同一格，最多 6 次；hoe 后 place 仍失败说明坐标不在分区内，先读分区坐标再清，不在地图外乱放。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过，绝不重试、绝不轮询。
- **collect 硬熔断**：每天≤1 次；返回空后当天永久跳过。
- **下矿前空格≥7**：`mine` 返回「need at least 5 free backpack slots」后当天不再调 mine，先 `store_items` 清格，清完仍<7 则转钓鱼。
- **mine 超时熔断**：`mine` 返回超时后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；清怪 2 次仍无梯子即 leave_mine 换层，不在同一层连调 mine。
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
- **下矿背包管理**：下矿前空格≥7；矿洞内背包满立即 `ship_produce` 清格再继续。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. hoe 清格并 place 4 个洒水器（今天第一件事，最多 6 次 place）
2. collect 熔炉取锭（仅 1 次，空即跳第 3 步）
3. 熔炉装矿（collect 后立刻做，只试 1 次，失败即熔断）
4. 清背包到 ≥7 空格
5. 补食物到 ≥3（12:10 后 Saloon 沙拉一次买 5 份，open_shop 只试 1 次）
6. 下矿 40 层以下拿铁矿石+煤（食物≥3、空格≥7 才下，≤2 次 mine，超时即停）
7. 熔炉装铁（下矿后只试 1 次，炉空才装）
8. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 买鱼饵（先清背包 ≥3 空格，Mountain 的 FishShop ≤20 个）
10. 浇水（水壶在背包时）
11. 工具升级（仅现金≥5000g 且铁锭≥5，9:10-15:30）
12. 社交（仅顺路）
13. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天44动作失败20，核心卡点：4个洒水器craft成功却因分区无空位全天没放下；熔炉load反复失败铁锭零产出；矿洞16层infested层连调mine无果；14:00-16:40在load/build_road/decorate上空转。有效：Forest钓鱼稳定出Pike补现金，出货581g。今天必须把洒水器落地和铁锭产出作为硬目标，失败即熔断转钓鱼。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:30 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 06:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:30 动作 `mine` 失败 @ Mine — floor 16: no stones left and no ladder found (kill remaining monsters?) | 游戏消息: [hud] Copper Ore / [hud] Coal / [hud] Stone / [hud] This area is infested...  〔自动〕
- 07:40 动作 `mine` 失败 @ UndergroundMine16 — floor 16: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 07:40 动作 `mine` 失败 @ UndergroundMine16 — floor 16: no stones left and no ladder found (kill remaining monsters?) 〔自动〕
- 12:40 动作 `open_shop` 失败 @ Mountain — can't open shop 'FishShop' here (wrong location, closed, or shopkeeper absent) 〔自动〕
- 12:40 动作 `buy` 失败 @ Mountain — no shop is open; use open_shop first 〔自动〕
- 12:40 动作 `close_menu` 失败 @ Mountain — no menu is open 〔自动〕
- 13:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 13:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 13:20 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 13:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 13:30 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 14:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 14:50 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 16:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 4 个洒水器 craft 成功但连续两天 place 失败，一直放不下去 @ Farm 耕地 — place 返回「Sprinkler 在规划的分区里没有空位了」和「今天已确认分区无空位」；昨天 hoe 了 (54,16) 但 place 仍失败（做不了：无法停止手动浇水，体力无法全部用于下矿/钓鱼） 〔复盘〕
- 熔炉 load 反复失败，铁锭零产出 @ Farm 熔炉 — load_machines 返回「no empty machine accepts anything in the backpack or the farm chests」和「repeated ineffective action suppressed」（做不了：钢水壶里程碑差 4 铁锭，无法推进） 〔复盘〕
- 下矿因背包空格不足白跑一趟 @ Mine 入口 — mine 返回「need at least 5 free backpack slots before mining; store_items first」，连续 3 次失败（做不了：拿不到铁矿石和煤，铁锭无法增加） 〔复盘〕
- 矿洞 16 层 infested 层连调 mine 无果 @ Mine 16 层 — mine 返回「floor 16: no stones left and no ladder found (kill remaining monsters?)」，fight 4 次后仍无梯子（做不了：卡在 16 层无法下到 40 层以下拿铁矿） 〔复盘〕
- 14:00-16:40 在 load/build_road/decorate 上空转 @ Farm — 脚本分支「固定做这个到 17:00」反复调 load_machines/build_road/decorate，全部失败或低效，浪费 10+ 动作（做不了：本可用于钓鱼补现金或下矿的时间被浪费） 〔复盘〕
- Saloon 12:00 整 open_shop 失败，买不到沙拉补食物 @ Town Saloon — open_shop 返回「can't open shop 'Saloon' here (wrong location, closed, or shopkeeper absent)」，脚本在门口等到 12:00 仍失败（做不了：食物不足，无法安全下 20 层以下矿） 〔复盘〕
- 买鱼饵前背包满导致 buy 失败，之后 close_menu 再 buy 又报 no shop is open @ Mountain FishShop — buy Bait 返回「no shop is open; use open_shop first」，close_menu 返回「no menu is open」（做不了：鱼饵没买到，钓鱼效率低） 〔复盘〕
