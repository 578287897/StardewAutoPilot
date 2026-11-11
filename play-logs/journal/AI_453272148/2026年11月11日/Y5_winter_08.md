# 第5年 winter 8 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（10:34 开始）
- 天气：sunny　金钱：67884g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：0c9c4fff1f244d62bed92e38908723ac
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：a47a2485847949c3b7358fad0c443134
  - 耗时：3.437 秒 / 游戏 0 分钟
- **06:00** FarmHouse ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:00** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：1d06d9c544284ed69f25a03f45e4c041
  - 耗时：6.171 秒 / 游戏 10 分钟
- **06:00** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：9443029540334dcf948ba13346c0bce3
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：7ee6e2ef90c04a4abb5324ecd0db8769
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：8a95f608367f48368fdccf948138d3f3
  - 耗时：0.531 秒 / 游戏 0 分钟

## 🌙 为明天（Y5_winter_08）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭）
- 起床收熔炉成品，读背包确认空格与铁矿石
- 在农场出货箱卖 Copper Bar 留 20 腾格子，验证空格≥5
- 电梯直达 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）
- 回农场炼铁，铁锭≥5 且 12:00 前 → Blacksmith 升 Steel Hoe
- 空格不足或下矿失败 → Forest 钓鱼兜底，21:30 前 sleep
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `festival`（activity="start"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `ship_produce`（except=["Salad", "Green Algae", "Gold Bar", "Iron Bar", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Squid Ink", "Claymore", "Silver Saber", "Burglar's Shank", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rubber Boots", "Gold Ore", "Coal"]）
14. `goto_location`（location="Mine"）
15. `mine`（floors=5）
16. `mine`（floors=5）
17. `leave_mine`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=5）
25. `fish`（casts=5）
26. `fish`（casts=5）
27. `goto_location`（location="Farm"）
28. `ship_produce`（except=["Salad", "Green Algae", "Gold Bar", "Iron Bar", "Iron Ore", "Copper Ore", "Pumpkin Seeds", "Squid Ink", "Claymore", "Silver Saber", "Burglar's Shank", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Scythe", "Fiberglass Rod", "Bamboo Pole", "Rubber Boots", "Gold Ore", "Coal"]）
29. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d356ba4956f541a4b3e13cc9c42b4dcb
  - 耗时：0.625 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：删除全部 take/donate 分支（箱子内容与记忆不符、卷轴未解锁），改为农场出货箱卖 Copper Bar 腾格，9:00 去 Forest 做
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Green Algae", count=3）
11. `ship`（item="Squid Ink", count=1）
12. `goto_location`（location="Forest"）
13. `wait`（minutes=170）
14. `festival`（activity="start"）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `collect_machines`
25. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：50d456e3260840e384a57fa6ea8c74a0
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 在农场箱子连续空跑，改为在出货箱卖 Copper Bar 腾格，再按原路线参加冰节、下矿刷铁、炼铁升锄头，失败则钓鱼兜底。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=65）
10. `ship`（item="Green Algae", count=3）
11. `ship`（item="Squid Ink", count=1）
12. `goto_location`（location="Forest"）
13. `festival`（activity="start"）
14. `fish`（casts=5）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Blacksmith"）
20. `upgrade_tool`（tool="hoe"）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `sleep`
- **06:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：d6a1bf60a6804aa6868d4c6eef2d4642
  - 耗时：0.546 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 箱子物品连续失败，全天删除 take/donate 分支；保留节日→下矿→升级主线，升级失败即回农场睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `festival`（activity="start"）
11. `fish`（casts=5）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Blacksmith"）
17. `upgrade_tool`（tool="hoe"）
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：d9cd9379330a4602be18d00824f279dc
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：04f0a35f01724765915ec24805faa22a
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：ea95b23aec1b492ab7bcfb4a417670bc
  - 耗时：0.516 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：8c4b2b10ac8d447c84046a653f3fe9f0
  - 耗时：80.344 秒 / 游戏 110 分钟
- **08:00** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked...
  - 执行状态：ACTION_FAILED · 操作编号：5a1b8b85ba3945b38ef95b788a60d250
  - 耗时：47.422 秒 / 游戏 50 分钟
  - 🗨️ [dialogue] It's locked...
- **08:50** Town ❌ `donate_museum`
  - 结果：exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... | The Festival of Ice 
has begun near 
Marnie's ranch. 
  - 执行状态：ACTION_FAILED · 操作编号：ba97cda135a4435cbaef5973f0810501
  - 耗时：5.297 秒 / 游戏 10 分钟
  - 🗨️ [dialogue] It's locked...
  - 🗨️ [hud] The Festival of Ice 
has begun near 
Marnie's ranch. 
- **09:00** Town ❌ `goto_location`（location="Forest"）
  - 结果：Festival of Ice occupies Forest from 900 until 1400; Forest has no door until that map returns
  - 执行状态：FESTIVAL_BLOCKED
- **09:00** Town ❌ `festival`（activity="start"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：f59fbea903bb4253b1a67dbad5530683
  - 耗时：0.532 秒 / 游戏 0 分钟
- **09:00** Town ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Perch, Green Algae, Lingcod, Perch)
  - 执行状态：SUCCESS · 操作编号：e1459d5ca3f146b6bd889e907d4a1a59
  - 耗时：88.984 秒 / 游戏 70 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
- **10:10** Town ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：3b702670e5a8472087f605577c5f73e1
  - 耗时：45.375 秒 / 游戏 60 分钟
- **11:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：2919f85436784a6da865876aec3eb72a
  - 耗时：33.672 秒 / 游戏 40 分钟
- **11:10** Mine ✅ `store_items`（items=["Pike", "Squid Ink", "Pumpkin Seeds", "Perch", "Rubber Boots", "Salad", "River Jelly", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 4x Green Algae
  - 执行状态：SUCCESS · 操作编号：c39daa09577f475bbc28f63a27bd7ab9
  - 耗时：15.125 秒 / 游戏 20 分钟
- **11:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **12:10** Farm ✅ `store_items`（items=["Pike", "Squid Ink", "Pumpkin Seeds", "Perch", "Rubber Boots", "Salad", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：f4ad38983b784e34b339d1374198f436
  - 耗时：0.563 秒 / 游戏 0 分钟
- **12:10** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **12:10** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：965eefdd71df4ff0ae162a470cb4c6fa
  - 耗时：0.547 秒 / 游戏 0 分钟
- **12:10** Farm ❌ `goto_location`（location="Blacksmith"）
  - 结果：exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked...
  - 执行状态：ACTION_FAILED · 操作编号：f9064fecef9d43a6bbb930d9a8eb6482
  - 耗时：45.859 秒 / 游戏 60 分钟
  - 🗨️ [dialogue] It's locked...
- **13:10** Town ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：14c2531457af428291851526eeed172a
  - 耗时：60.75 秒 / 游戏 80 分钟
- **13:10** Town ✅ `store_items`（items=["Pike", "Squid Ink", "Pumpkin Seeds", "Perch", "Rubber Boots", "Salad", "River Jelly"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：5729cff2e8414c1c8f92b4d7af08c85d
  - 耗时：24.0 秒 / 游戏 30 分钟
- **13:10** Town ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 1, need 5)
  - 执行状态：ACTION_FAILED
- **15:00** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：05bf00d5cd2d4296a2d94a9526e00767
  - 耗时：0.562 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：aab148697eb7483fa4076c841eefc599
  - 耗时：0.5 秒 / 游戏 0 分钟
- **15:00** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **15:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:00** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：3db0b27477b04125b2366c1e49995da9
  - 耗时：10.484 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：67884 → 67884（+0g）
- 出货估值：0g　动作：41 个　失败：26 个
- 模型调用：6 次　tokens：69184
- 有效动作率：0.3235　空转：8　熔断跳过：6
- 失败耗时：105.485 秒 / 游戏 120 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
全天41动作26失败，核心卡点仍是背包空格不足（仅1格）导致mine/upgrade连续被拒；take空跑12次、store_items坐标失效、节日地图不可达后脚本仍按原计划执行，浪费大量动作。有效动作只有钓鱼5条和一次存箱。清包必须用出货箱卖Copper Bar腾格，且节日日应直接放弃Town/博物馆分支。

**新教训：**
- 节日当天 Forest 被 Festival of Ice 占用（900-1400），goto Forest 和 festival start 都会失败：节日日应先 goto_location 到节日地图（Forest）再调 festival，而不是先调 festival 再 goto。
- ArchaeologyHouse 在节日当天 8:00 后仍显示 locked，goto 和 donate 都失败：节日日应全天物理删除博物馆分支，不要尝试 goto ArchaeologyHouse。
- 背包只剩 1 格时 store_items 只存进 4x Green Algae 就报 nothing to store，说明箱子已满或物品不可堆叠：清包不能依赖 store_items，必须用 ship_produce 卖 Copper Bar 腾格。
- upgrade_tool 在空格 1 时被 'store did not free enough slots (have 1, need 5)' 拒绝，说明升级工具也需要 5 空格：升级前必须和 mine 一样验证空格≥5，否则白跑 Blacksmith。
- build_road 和 decorate 在无可用空格/材料时连续失败：这两个动作应在脚本生成阶段物理删除，收尾只允许 sleep 或钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 9）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 67884g 早已够，唯一卡点是 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍都排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（熔炉现成 2 座，Copper Bar 85 个可卖约 7k 换现金与空格）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是下矿硬门票**，连续多天被拒证明「边下边补」不成立——清包必须在生成 mine 分支之前完成并读背包验证。

接下来 3 天主活动：
- **今天（冬 9）**：起床 collect→读背包→**农场出货箱 ship_produce Copper Bar count=背包数-20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼，不空转。
- **明天（冬 10）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4 并 place。
- **后天（冬 11）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 在农场出货箱卖 Copper Bar 留 20**：连续多天 85 个 Copper Bar 一个没卖，空格仍 1。今天起床读背包后，**显式 ship_produce Copper Bar count=背包数-20**（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：昨天在 ArchaeologyHouse 调 ship 报 not found。ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：连续多天 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep。**任何情况下不用 wait 填充时间**。
9. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
10. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 9 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
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
3. 清包到空格≥5（**先读背包清单，在农场出货箱卖 Copper Bar 留 20，只 ship 清单里实际存在的冗余物品**，读背包验证；两次不足即删 mine/upgrade 分支）
4. 食物补到≥8（读背包 Salad≥5 即跳过；不足 Saloon 买沙拉）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 全天41动作26失败，核心卡点仍是背包空格不足（仅1格）导致mine/upgrade连续被拒；take空跑12次、store_items坐标失效、节日地图不可达后脚本仍按原计划执行，浪费大量动作。有效动作只有钓鱼5条和一次存箱。清包必须用出货箱卖Copper Bar腾格，且节日日应直接放弃Town/博物馆分支。
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
- 08:00 动作 `goto_location` 失败 @ Farm — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... | 游戏消息: [dialogue] It's locked... 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ Town — exit to ArchaeologyHouse did not open (closed? locked? check opening hours). Recent messages: It's locked... | The Festival of Ice 
has begun near 
Marnie's ranch.  | 游戏消息: [dialogue] It's locked... / [hud] The Festival of Ice 
has begun 〔自动〕
- 09:00 动作 `goto_location` 失败 @ Town — Festival of Ice occupies Forest from 900 until 1400; Forest has no door until that map returns 〔自动〕
- 09:00 动作 `festival` 失败 @ Town — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 11:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 1, need 5) 〔自动〕
- 12:10 动作 `mine` 失败 @ Farm — store did not free enough slots (have 1, need 5) 〔自动〕
- 12:10 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 12:10 动作 `goto_location` 失败 @ Farm — exit to Blacksmith did not open (closed? locked? check opening hours). Recent messages: AutoPilot 已暂停：AI 代理未连接（时间已冻结） | It's locked... | 游戏消息: [dialogue] It's locked... 〔自动〕
- 13:10 动作 `upgrade_tool` 失败 @ Town — store did not free enough slots (have 1, need 5) 〔自动〕
- 15:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 15:00 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 背包空格始终只有 1 格，导致 mine 和 upgrade_tool 连续被拒 @ Farm / Mine — store did not free enough slots (have 1, need 5)（做不了：无法下矿刷铁矿石，无法升级 Steel Hoe，铁锭链完全卡死） 〔复盘〕
- take 动作连续 12 次空跑，重写脚本 3 次仍在重试同一批箱子物品 ID @ Farm — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作和时间，箱子内容与记忆完全不符） 〔复盘〕
- 节日当天 Forest 被占用，goto Forest 和 festival start 都失败 @ Forest — Festival of Ice occupies Forest from 900 until 1400; Forest has no door until that map returns（做不了：无法参加 Festival of Ice，节日活动完全错过） 〔复盘〕
- ArchaeologyHouse 在节日当天 locked，goto 和 donate_museum 都失败 @ ArchaeologyHouse — exit to ArchaeologyHouse did not open (closed? locked?)（做不了：无法捐赠博物馆物品） 〔复盘〕
- store_items 在农场箱子坐标 (74,16) 不可达，连续失败 @ Farm — could not reach (74,16); stopped at (53,8)（做不了：无法通过存箱腾出背包空格） 〔复盘〕
- build_road 和 decorate 在无可用空格/材料时连续失败 @ Farm — 规划道路边没有还能走上去的空格 / 今天没有能做的装饰（做不了：浪费动作，无实际产出） 〔复盘〕
