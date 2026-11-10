# 第5年 spring 13 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（15:56 开始）
- 天气：sunny　金钱：63045g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Kale -> Preserves Jar (ready in 4000 min), Copper Ore -> Furnace (ready in 30 min), Kale -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：1973c9591fd1487a981a5f987837aa6a
  - 耗时：23.015 秒 / 游戏 20 分钟
  - 🗨️ [hud] Coal
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_spring_13）准备的脚本
- 里程碑：钢锄头（5000g+5铁锭）——今天先炼铁锭，凑齐后13:00前到铁匠铺升级
- 复活节：9:00-14:00 到 Town 参加 Egg Festival，节日结束后买草莓种子并当天种下
- 起床收炉→投铁矿石→清包到空格≥15→补食物→下矿80→84挖铁矿石
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
11. `goto_location`（location="Farm"）
12. `store_items`
13. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Strange Bun", "Kale"]）
14. `goto_location`（location="Town"）
15. `festival`（activity="start"）
16. `goto_location`（location="SeedShop"）
17. `open_shop`（shop_id="SeedShop"）
18. `buy`（item="Strawberry Seeds", count=20）
19. `close_menu`
20. `goto_location`（location="Farm"）
21. `plant_seeds`（item="Strawberry Seeds", count=20）
22. `goto_location`（location="Mine"）
23. `mine`（floors=5）
24. `goto_location`（location="Farm"）
25. `store_items`
26. `collect_machines`
27. `sleep`
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 3 crops
  - 执行状态：SUCCESS · 操作编号：35dd94144f2d4dbd8a07d00937b76113
  - 耗时：11.25 秒 / 游戏 20 分钟
  - 🗨️ [hud] Kale
  - 🗨️ [hud] Potato
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 6 crops
  - 执行状态：SUCCESS · 操作编号：b3a2725e91724ebab9c66ed288dbb520
  - 耗时：11.5 秒 / 游戏 10 分钟
  - 🗨️ [hud] Moss
  - 🗨️ [hud] Moss
- **06:50** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~480g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：8e2ec7a40a854913a383ece95311a2af
  - 耗时：10.391 秒 / 游戏 20 分钟
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：3afc0eb303df4f3dbcd0543dfde3ecfe
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败后删除所有 take 与 donate 分支，保留复活节→买草莓种子→下矿→收炉的路线
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Town"）
10. `festival`（activity="start"）
11. `goto_location`（location="SeedShop"）
12. `open_shop`（shop_id="SeedShop"）
13. `buy`（item="Strawberry Seeds", count=20）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Strange Bun", "Kale"]）
22. `plant_seeds`（item="Strawberry Seeds", count=20）
23. `collect_machines`
24. `store_items`
25. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：49c5f94c8c7b49a4a05e70e84a784aa7
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 全失败已删除，改走复活节+买草莓种子+下矿80层路线，收炉炼铁推进钢锄头。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Town"）
10. `festival`（activity="start"）
11. `goto_location`（location="SeedShop"）
12. `open_shop`（shop_id="SeedShop"）
13. `buy`（item="Strawberry Seeds", count=20）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Strange Bun"]）
22. `plant_seeds`（item="Strawberry Seeds", count=20）
23. `collect_machines`
24. `store_items`
25. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：78b616e7f3544b549644a144abbf80e2
  - 耗时：0.375 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：删除全部 take 分支（箱子无宝石），保留复活节→买草莓→种下→下矿80层挖铁矿石的主线，收尾收炉存包后睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Town"）
10. `festival`（activity="start"）
11. `goto_location`（location="SeedShop"）
12. `open_shop`（shop_id="SeedShop"）
13. `buy`（item="Strawberry Seeds", count=20）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `goto_location`（location="Farm"）
18. `collect_machines`
19. `load_machines`（item="Iron Ore"）
20. `store_items`
21. `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Strange Bun"]）
22. `plant_seeds`（item="Strawberry Seeds", count=20）
23. `collect_machines`
24. `store_items`
25. `sleep`
- **07:10** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **07:10** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：e799d3bbd45b40c392d505358e918aed
  - 耗时：0.375 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：5a49ff226309482bb62feead56a50de3
  - 耗时：0.391 秒 / 游戏 0 分钟
- **07:10** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：b6d02f0b4eee44f3b569f0babdba26ad
  - 耗时：0.36 秒 / 游戏 0 分钟
- **07:10** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：f5532a0fc02f493c9c28cf4b9f9cbb06
  - 耗时：34.359 秒 / 游戏 50 分钟
- **08:00** Farm ❌ `goto_location`（location="ArchaeologyHouse"）
  - 结果：no reachable route from Forest to ArchaeologyHouse (unreachable exits: busstop->town, temp->archaeologyhouse, temp->mountain, forest->town, forest->farm)
  - 执行状态：ACTION_FAILED · 操作编号：751e08277fdb43199037918a02a9038b
  - 耗时：79.578 秒 / 游戏 70 分钟
  - 🗨️ [dialogue] Today's festival is being set up. Come back later.
  - 🗨️ [hud] The Egg Festival has 
begun in the town 
square. 
- **09:10** Forest ❌ `donate_museum`
  - 结果：Egg Festival occupies Town from 900 until 1400; ArchaeologyHouse has no door until that map returns
  - 执行状态：ACTION_FAILED · 操作编号：503f96ac61ee44048a1fb4ffaefc4db9
  - 耗时：0.422 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Town"）
  - 结果：Egg Festival occupies Town from 900 until 1400; Town has no door until that map returns
  - 执行状态：FESTIVAL_BLOCKED
- **09:10** Forest ❌ `festival`（activity="start"）
  - 结果：not at a festival right now (goto_location the festival map during its hours first)
  - 执行状态：ACTION_FAILED · 操作编号：870d48ab840d49aab8b6f75652f0c0cc
  - 耗时：0.406 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="SeedShop"）
  - 结果：Egg Festival occupies Town from 900 until 1400; SeedShop has no door until that map returns
  - 执行状态：FESTIVAL_BLOCKED
- **09:10** Forest ❌ `open_shop`（shop_id="SeedShop"）
  - 结果：can't open shop 'SeedShop' at Forest; the counter is in SeedShop
  - 执行状态：ACTION_FAILED · 操作编号：44e40e1d4ec143dda20b6d1868e9e443
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `buy`（item="Strawberry Seeds", count=20）
  - 结果：no shop is open; use open_shop first
  - 执行状态：ACTION_FAILED · 操作编号：dc8b1102201445438f666371357d8163
  - 耗时：0.407 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `close_menu`
  - 结果：no menu is open
  - 执行状态：ACTION_FAILED · 操作编号：2a8d5bd9c73e4d78a72812d42dedc904
  - 耗时：0.36 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Mine"）
  - 结果：no reachable route from Forest to Mine (unreachable exits: forest->town, forest->farm)
  - 执行状态：ACTION_FAILED · 操作编号：3c2824264a0747c4939d194c89fe8f58
  - 耗时：0.406 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `mine`（floors=5）
  - 结果：no reachable route from Forest to Mine (unreachable exits: forest->town, forest->farm)
  - 执行状态：ACTION_FAILED · 操作编号：810f2b8fb567495989e44b940f6c129d
  - 耗时：0.422 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Farm"）
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：b6de001dec7445c8882ba0a98af29f6e
  - 耗时：0.453 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `collect_machines`
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：a4df413e06b641e8a53bb133852a3173
  - 耗时：0.594 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：5de3bb93082f47feba8ef32487c2a500
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：e6ecfa92b22045599d93704e6a372cc9
  - 耗时：0.422 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `store_items`
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：e6ecfa92b22045599d93704e6a372cc9
  - 耗时：0.422 秒 / 游戏 0 分钟
- **09:10** Forest ✅ `ship_produce`（except=["Stone", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Copper Bar", "Gold Bar", "Strange Bun"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：4995dc971f24496c901ae1998347f359
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `plant_seeds`（item="Strawberry Seeds", count=20）
  - 结果：'Strawberry Seeds' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：53310f0e011b4e1687f868f5ce96cbe1
  - 耗时：0.391 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `collect_machines`
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：ACTION_FAILED · 操作编号：be25ad88846a401989fb963915a95ecb
  - 耗时：0.469 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `store_items`
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town)
  - 执行状态：NO_PROGRESS · 操作编号：64733368409b4b1690d41f8d504ecbbb
  - 耗时：0.406 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Town", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：Egg Festival occupies Town from 900 until 1400; Town has no door until that map returns
  - 执行状态：FESTIVAL_BLOCKED
- **09:10** Forest ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no reachable route from Forest to Mine (unreachable exits: forest->town, forest->farm)
  - 执行状态：ACTION_FAILED · 操作编号：356fc11af0d74e8cbe2f5a2d5929f6b1
  - 耗时：0.437 秒 / 游戏 0 分钟
- **09:10** Forest ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (1,90)
  - 执行状态：SUCCESS · 操作编号：6a0549cc00f44ebab54cdf57d79d29c6
  - 耗时：0.375 秒 / 游戏 0 分钟
- **09:10** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：07c717d9164f4b7a93b094f711ab076b
  - 耗时：0.406 秒 / 游戏 0 分钟
- **09:10** Forest ❌ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：unchanged failed action suppressed
  - 执行状态：CIRCUIT_OPEN
- **09:10** Forest ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **09:10** Forest ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 11:10 am
  - 执行状态：SUCCESS · 操作编号：cb4f7e1ab183447082cd774f7a534a60
  - 耗时：81.141 秒 / 游戏 120 分钟
- **11:10** Forest ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 1:10 pm
  - 执行状态：SUCCESS · 操作编号：d4338727849f41e79c812a032ece29b7
  - 耗时：87.828 秒 / 游戏 120 分钟
- **13:10** Forest ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 3:10 pm
  - 执行状态：SUCCESS · 操作编号：02fc7a818a9c44bebd4d8184ec862a59
  - 耗时：87.89 秒 / 游戏 120 分钟
- **15:10** Forest ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 5:10 pm
  - 执行状态：SUCCESS · 操作编号：48873247be9c422285afab537b28aaec
  - 耗时：87.828 秒 / 游戏 120 分钟
- **17:10** Forest ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：2de2b94636bd437d959ad1a4986e238c
  - 耗时：4.594 秒 / 游戏 0 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：63045 → 63525（+480g）
- 出货估值：480g　动作：53 个　失败：40 个
- 模型调用：8 次　tokens：88309
- 有效动作率：0.2　空转：5　熔断跳过：12
- 失败耗时：88.533 秒 / 游戏 70 分钟
- 最深矿层：90　新增矿层：0
- 今日完成里程碑：无新增或未统计

## ⚠️ 今日问题
> 复盘失败：model did not return valid JSON: {"analysis":"昨天核心失败是节日日路径封锁：9:00 后 Town 被复活节占用，从 Forest 出发所有出口不可达，脚本却继续尝试 goto Town/SeedShop/Mine/Farm 等 20+ 次，40 个失败中约 25 个源于此，最后 4 次 wait 空转到 17:10。教训是节日日必须在 9:00 前完成关键动作（买种子/下矿/升级），9:00-14:00 只能留在农场或 Forest 做可达的事。另外 take 宝石仍全失败，说明箱子内容与记忆不符。","strategy":"# 星露谷策略（Y5 春 14）\n\n## 长期目标\n当前里程碑：**工具按档升级
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 07:10 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:00 动作 `goto_location` 失败 @ Farm — no reachable route from Forest to ArchaeologyHouse (unreachable exits: busstop->town, temp->archaeologyhouse, temp->mountain, forest->town, forest->farm) | 游戏消息: [dialogue] Today's festival is being set up. Come back later. / [hud] The Egg  〔自动〕
- 09:10 动作 `donate_museum` 失败 @ Forest — Egg Festival occupies Town from 900 until 1400; ArchaeologyHouse has no door until that map returns 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Forest — Egg Festival occupies Town from 900 until 1400; Town has no door until that map returns 〔自动〕
- 09:10 动作 `festival` 失败 @ Forest — not at a festival right now (goto_location the festival map during its hours first) 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Forest — Egg Festival occupies Town from 900 until 1400; SeedShop has no door until that map returns 〔自动〕
- 09:10 动作 `open_shop` 失败 @ Forest — can't open shop 'SeedShop' at Forest; the counter is in SeedShop 〔自动〕
- 09:10 动作 `buy` 失败 @ Forest — no shop is open; use open_shop first 〔自动〕
- 09:10 动作 `close_menu` 失败 @ Forest — no menu is open 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Forest — no reachable route from Forest to Mine (unreachable exits: forest->town, forest->farm) 〔自动〕
- 09:10 动作 `mine` 失败 @ Forest — no reachable route from Forest to Mine (unreachable exits: forest->town, forest->farm) 〔自动〕
- 09:10 动作 `goto_location` 失败 @ Forest — no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town) 〔自动〕
- 09:10 动作 `collect_machines` 失败 @ Forest — no reachable route from Forest to Farm (unreachable exits: forest->farm, forest->town) 〔自动〕
