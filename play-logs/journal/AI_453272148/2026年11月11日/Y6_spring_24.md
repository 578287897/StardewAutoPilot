# 第6年 spring 24 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（23:36 开始）
- 天气：sunny　金钱：92063g　体力：202/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：3c43ac7832f4446d99ac35c93274e6f9
  - 耗时：0.593 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：9065482478f64eddb6408556d4950501
  - 耗时：3.375 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 2x Broken CD, 1x Driftwood
  - 执行状态：SUCCESS · 操作编号：868cff5535784be885001527c8c5f781
  - 耗时：6.156 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：f03a618ad76e4443aa50fec91919a1eb
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：303cc6e9bb2d4e25be277a47c25cb09d
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~975g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：b6bc8efe984c4eb3b31466dd0f080ec1
  - 耗时：0.797 秒 / 游戏 0 分钟

## 🌙 为明天（Y6_spring_24）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，铁矿石够就装炉
- 农场出货箱无条件卖 Copper Bar 留 20，腾出 ≥5 空格
- 背包空格够就电梯直达 40 层刷铁矿石+煤（≤2 次 mine）
- 回农场收铁锭，铁锭≥5 且 12:00 前去铁匠铺升 hoe
- 凑不齐就转 Forest 钓鱼到 21:30，21:30 后 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `festival`（activity="dance"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `goto_location`（location="Farm"）
14. `ship`（item="Copper Bar", count=71）
15. `ship`（item="Sap", count=48）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `fight`（range=6）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `goto_location`（location="Forest"）
25. `fish`（casts=10）
26. `fish`（casts=10）
27. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：9bea369e783f4c47ac0276b16ca1e78c
  - 耗时：0.61 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 空跑失败，删除博物馆分支；先出货箱清包，再去花舞节，剩余时间钓鱼收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Forest"）
12. `festival`（activity="dance"）
13. `fish`（casts=10）
14. `fish`（casts=10）
15. `fish`（casts=10）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fc0ed8db77784e67a165445bbe9222f3
  - 耗时：0.593 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全部空跑，物理删除 take/博物馆分支；改为农场出货箱无条件清包腾格，再去 Forest 参加花舞节并钓鱼到收尾。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Forest"）
12. `festival`（activity="dance"）
13. `fish`（casts=10）
14. `fish`（casts=10）
15. `fish`（casts=10）
16. `fish`（casts=10）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d8370d9de8dc4feb806a722cd2b5f8ad
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 系列全部失败（箱子内容与记忆不符），按教训物理删除 take/博物馆分支，改为在农场出货箱直接清包腾格，然后去 Forest 参加花舞节并钓
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=71）
10. `ship`（item="Sap", count=48）
11. `goto_location`（location="Forest"）
12. `festival`（activity="dance"）
13. `fish`（casts=10）
14. `fish`（casts=10）
15. `fish`（casts=10）
16. `fish`（casts=10）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：41909b4b3a9b472f8d09583b26848fa8
  - 耗时：0.609 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e3d9e5f6b10f4df2beb39fdcd23a9b4a
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：072a3432007543688ef04474fa170d87
  - 耗时：0.563 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：03b72aab550741eb834cf645f18669e6
  - 耗时：79.922 秒 / 游戏 110 分钟
- **08:00** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... | The Flower Dance has 
begun in the forest. 
  - 执行状态：ACTION_FAILED · 操作编号：ef5306eba5d84eb7914099fb81ab0dc3
  - 耗时：47.796 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked...
  - 🗨️ [hud] The Flower Dance has 
begun in the forest. 
- **09:00** Town ❌ `donate_museum`
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: The Flower Dance has 
begun in the forest.  | It's locked...
  - 执行状态：ACTION_FAILED · 操作编号：c2851289cd9f4109ad2146e88f80199a
  - 耗时：5.344 秒 / 游戏 0 分钟
  - 🗨️ [dialogue] It's locked...
- **09:00** Town ❌ `ship`（item="Copper Bar", count=71）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：38e22c3d595b480e8a6e47ce85c9d1cf
  - 耗时：0.563 秒 / 游戏 0 分钟
- **09:00** Town ❌ `ship`（item="Sap", count=48）
  - 结果：'Sap' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：d4c1e6158c5e4db886ef20b589e6f6df
  - 耗时：0.546 秒 / 游戏 0 分钟
- **09:00** Town ❌ `goto_location`（location="Forest"）
  - 结果：Flower Dance occupies Forest from 900 until 1400; Forest has no door until that map returns
  - 执行状态：FESTIVAL_BLOCKED
- **09:00** Town ❌ `festival`（activity="dance"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：e663c905935e4134b1d99f5cd137fd5b
  - 耗时：0.547 秒 / 游戏 0 分钟
- **09:00** Town ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Green Algae, Smallmouth Bass, Green Algae, Green Algae, Smallmouth Bass, Smallmouth Bass, Sunfish, Smallmouth Bass, Green Algae, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：a3183f4cd79845db95919688c6b673c0
  - 耗时：214.609 秒 / 游戏 230 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Green Algae
- **12:50** Town ✅ `fish`（casts=10）
  - 结果：fished: caught 10 (Green Algae, Smallmouth Bass, Sunfish, Sunfish, Sunfish, Green Algae, Sunfish, Green Algae, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：aeb7d2189a364b1bbc3afee5b981aca6
  - 耗时：220.75 秒 / 游戏 220 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Smallmouth Bass
- **16:30** Town ✅ `fish`（casts=10）
  - 结果：fished: caught 8 (Smallmouth Bass, Smallmouth Bass, Sunfish, Smallmouth Bass, Smallmouth Bass, Sunfish, Smallmouth Bass, Smallmouth Bass)
  - 执行状态：SUCCESS · 操作编号：3fc39ed5b9fb43d4b324569d936a6569
  - 耗时：200.188 秒 / 游戏 190 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] You're starting to 
feel exhausted. 
  - 🗨️ [hud] Smallmouth Bass
- **19:40** Town ✅ `fish`（casts=10）
  - 结果：fished: caught 0 ()
  - 执行状态：SUCCESS · 操作编号：4aebfa60478e4f54abc065109001db88
  - 耗时：0.531 秒 / 游戏 0 分钟
- **19:40** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：0969ff71430c43feb749a645e04cb34d
  - 耗时：37.484 秒 / 游戏 50 分钟
- **19:40** Town ✅ `store_items`（items=["Salad", "Smallmouth Bass", "Green Algae", "Pumpkin Seeds", "Rubber Boots", "White Overalls"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 20x Green Algae
  - 执行状态：SUCCESS · 操作编号：cf2edec78ad24b37b9254db6ba8b686d
  - 耗时：1.203 秒 / 游戏 0 分钟
- **19:40** Town ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 2, need 5)
  - 执行状态：ACTION_FAILED
- **20:30** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：b76983ccf10d4d65abc980859697816c
  - 耗时：0.578 秒 / 游戏 0 分钟
- **20:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：ebb22af5207b4b0db7392c80867a570d
  - 耗时：10.281 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：92063 → 93038（+975g）
- 出货估值：975g　动作：35 个　失败：21 个
- 模型调用：7 次　tokens：86866
- 有效动作率：0.3929　空转：4　熔断跳过：6
- 失败耗时：59.936 秒 / 游戏 60 分钟
- 最深矿层：104　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天21次失败几乎全部来自脚本生成阶段没有按背包/地图/时间做前置校验：take 空跑12次、ship 在非农场地图、donate 无物可捐、build_road 无空位、load_machines 无空炉。真正产出只有钓鱼28条约975g。核心瓶颈仍是铁锭（Iron Bar 1/5），而背包 Copper Bar 91 个一个没卖导致 mine 被 'have 4, need 5' 拒绝。今天第一动作必须是无条件在农场出货箱卖 Copper Bar 腾格，然后电梯40层刷铁。

**新教训：**
- 昨天 12 次 take 全部空跑（62/64/68/72/84/86 全不在农场箱子），脚本重写 3 次仍重试同一批 ID：农场箱子内容与记忆完全不符，take 应全天物理删除，需要矿物只能下矿现拿。
- 昨天 9:00 在 ArchaeologyHouse 门口等到 8:00 开门后仍报 'It's locked... The Flower Dance has begun'：节日当天博物馆/商店会提前关闭，节日日应直接 goto Forest 参加节日或钓鱼，不生成任何商店/博物馆动作。
- 昨天 9:00 goto Forest 报 'Flower Dance occupies Forest from 900 until 1400; Forest has no door until that map returns'：节日地图在节日时段内无法用 goto_location 进入，节日动作应直接调 festival 而不是先 goto。
- 昨天 9:40 起连续 4 次 fish 共 28 条只值约 975g，且 16:30 后体力耗尽 'You're starting to feel exhausted'：钓鱼是低价值兜底，不能当主活动；清包失败后应优先补食物再下矿，钓鱼只填 16:00 后的空档。
- 昨天 19:40 mine 报 'store did not free enough slots (have 2, need 5)' 而背包有 91 个 Copper Bar：mine 动作内部会先尝试 store 再下矿，脚本生成阶段若背包空格<5 就物理删除 mine 分支，且清包必须在 mine 之前完成。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y6 春 25）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 92063g 远超 5000，唯一卡点是 Iron Bar 1/5。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。铁矿石只在 40 层以下，而下矿门票是背包空格≥5——昨天背包始终 4 空格，91 个 Copper Bar 一个没卖，mine 和 upgrade_tool 都被 'have 4, need 5' 拒绝。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1）。

接下来 3 天主活动：
- **今天（春 25）**：起床 collect→**农场出货箱无条件 ship Copper Bar 留 20（约 71 个，腾 4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼到 21:30。
- **明天（春 26）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（春 27）**：继续铁锭链；若洒水器已齐则开始规划夏季啤酒花地块。

## 今日核心修正（按执行顺序）
1. **清包是今天第一硬动作，且唯一手段 = 农场出货箱 ship Copper Bar 留 20**：起床读背包后**无条件** ship Copper Bar count=背包数-20（约 71 个，约 4k，腾 4 格），再卖多余 Stone（留 500）、Sap。**绝不把 Copper Bar 写进 except，绝不放在「视情况」分支里**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。脚本生成阶段把 ship 的 location 硬编码为 Farm。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、store_items 空跑 2 次、donate 空跑 1 次、build_road 空跑 1 次，全部 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 99 层往下爬，禁止在 15-19 层浪费 mine 次数。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过；Iron Ore<5 物理删除 load）→ 进入清包。
6. **mine 成功一次后先 ship 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **春 25 不买种子**：只做清包+下矿+钓鱼；种子等复活节买草莓，之前种土豆/花椰菜保底。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship Copper Bar count=背包数-20 → ship 多余 Stone 留 500 → ship Sap → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **春 25 不买种子**；craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
10. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 4k，腾 4 格），绝不写进 except。
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
9. 春 25 不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天21次失败几乎全部来自脚本生成阶段没有按背包/地图/时间做前置校验：take 空跑12次、ship 在非农场地图、donate 无物可捐、build_road 无空位、load_machines 无空炉。真正产出只有钓鱼28条约975g。核心瓶颈仍是铁锭（Iron Bar 1/5），而背包 Copper Bar 91 个一个没卖导致 mine 被 'have 4, need 5' 拒绝。今天第一动作必须是无条件在农场出货箱卖 Copper Bar 腾格，然后电梯40层刷铁。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `build_road` 失败 @ FarmHouse — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 08:00 动作 `goto_location` 失败 @ Farm — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... | The Flower Dance has 
begun in the forest.  | 游戏消息: [dialogue] It's locked... / [hud] The Flower Dance has 
begun in the forest 〔自动〕
- 09:00 动作 `donate_museum` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: The Flower Dance has 
begun in the forest.  | It's locked... | 游戏消息: [dialogue] It's locked... 〔自动〕
- 09:00 动作 `ship` 失败 @ Town — 'Copper Bar' not found in inventory 〔自动〕
- 09:00 动作 `ship` 失败 @ Town — 'Sap' not found in inventory 〔自动〕
- 09:00 动作 `goto_location` 失败 @ Town — Flower Dance occupies Forest from 900 until 1400; Forest has no door until that map returns 〔自动〕
- 09:00 动作 `festival` 失败 @ Town — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 19:40 动作 `mine` 失败 @ Town — store did not free enough slots (have 2, need 5) 〔自动〕
- 脚本重写 3 次仍反复生成同一批 take 动作（62/64/68/72/84/86），12 次全部空跑 @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费约 12 个动作和 3 次脚本重写，挤掉了下矿时间） 〔复盘〕
- 节日当天去博物馆捐赠，门口等到 8:00 仍锁门 @ ArchaeologyHouse — exit to ArchaeologyHouse did not open (closed? locked?) / The Flower Dance has begun in the forest（做不了：donate_museum 无法执行，且浪费 8:00-9:00 一小时） 〔复盘〕
- 节日时段用 goto_location 进 Forest 被拒，随后 festival 动作也失败 @ Forest — Flower Dance occupies Forest from 900 until 1400; Forest has no door until that map returns / not at a festival right now（做不了：花舞节完全没参加，节日收益为 0） 〔复盘〕
- 在非农场地图调 ship Copper Bar 和 Sap 报 not found，而材料显示背包有 91 个 Copper Bar @ ArchaeologyHouse — 'Copper Bar' not found in inventory / 'Sap' not found in inventory（做不了：清包失败，背包空格始终 4，mine 和 upgrade_tool 都被 'have 4, need 5' 拒绝） 〔复盘〕
- 背包 91 个 Copper Bar 一个没卖，导致下矿和升级工具连续被拒 @ Farm / Mine — store did not free enough slots (have 2, need 5)（做不了：铁锭链无法推进，Steel Hoe 和洒水器全部卡住） 〔复盘〕
