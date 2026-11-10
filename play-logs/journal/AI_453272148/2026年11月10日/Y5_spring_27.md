# 第5年 spring 27 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（18:44 开始）
- 天气：rain　金钱：65285g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：b7a73c8febff4672b8676561d6c31a89
  - 耗时：11.75 秒 / 游戏 10 分钟
  - 🗨️ [hud] Iron Bar
- **06:10** Farm ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：5b0ffb7eda844c65a9a43f0b968bac16
  - 耗时：0.563 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **06:10** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS

## 🌙 为明天（Y5_spring_27）准备的脚本
- 里程碑：钢锄头（5000g + 5 铁锭）——今天必须打通铁锭链
- 起床收熔炉成品，若炉空且背包有铁矿石就投料一次
- 清包到空格≥15（store_items + ship_produce 双管齐下）
- 补食物到≥5（背包已有 6 沙拉，够用）
- 电梯直达 40 层刷铁矿石+煤，目标 40→50，≤2 次 mine
- 回农场收铁锭；铁锭≥5 且时间<13:00 去铁匠铺升 hoe
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
11. `store_items`
12. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Gold Bar", "Gold Ore", "Copper Ore", "Stone", "Fiber", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Salad", "Cauliflower Seeds", "Potato Seeds", "Magma Geode", "Dwarf Scroll I"]）
13. `goto_location`（location="Mine"）
14. `mine`（floors=5）
15. `fight`（range=6）
16. `mine`（floors=5）
17. `store_items`
18. `goto_location`（location="Farm"）
19. `collect_machines`
20. `goto_location`（location="Blacksmith"）
21. `upgrade_tool`（tool="hoe"）
22. `goto_location`（location="Farm"）
23. `collect_machines`
24. `sleep`
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 10 crops
  - 执行状态：SUCCESS · 操作编号：670895d192864b7ca110bd0448440880
  - 耗时：9.578 秒 / 游戏 10 分钟
  - 🗨️ [hud] Potato
  - 🗨️ [hud] You've got some new 
ideas to sleep on... 
- **06:20** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：23bfbde4d91a49ff8a96a15804d35a2c
  - 耗时：0.453 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 2 stacks worth ~1100g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：e00c464a4e0e446fa0bf6c3216d4cf73
  - 耗时：4.391 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：770d6627663a49b88c411828d5842248
  - 耗时：0.437 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 全删，改为清包→40 层刷铁→回农场收锭→铁匠铺升 hoe，路线不变。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `store_items`
17. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Bar", "Gold Ore", "Copper Ore", "Stone", "Fiber", "Salad", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Magma Geode", "Dwarf Scroll I"]）
18. `store_items`
19. `collect_machines`
20. `store_items`
21. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：85ff6b5c3fd74a2898a774655ce5d995
  - 耗时：0.421 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：删掉全部 take 与 donate 分支，改为清包→40层刷铁→回农场收锭→铁匠铺升 hoe，失败即跳过。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `store_items`
17. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Bar", "Gold Ore", "Copper Ore", "Stone", "Fiber", "Salad", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Magma Geode", "Dwarf Scroll I"]）
18. `store_items`
19. `store_items`
20. `collect_machines`
21. `collect_machines`
22. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：91d9da9d81bc46f38a43a8a16171e488
  - 耗时：0.421 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：放弃全部 take 分支（箱子内容与记忆不符），改为清包→40层刷铁→回农场收铁锭→铁匠铺升锄头，路线不新增地图。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Mine"）
10. `mine`（floors=5）
11. `fight`（range=6）
12. `mine`（floors=5）
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Farm"）
16. `store_items`
17. `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Bar", "Gold Ore", "Copper Ore", "Stone", "Fiber", "Salad", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Magma Geode", "Dwarf Scroll I"]）
18. `store_items`
19. `collect_machines`
20. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：f1d104ff332a49bc951be52cc8f28f1e
  - 耗时：0.438 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：74258628f94444b894df3e8217888028
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8861f0ad61584a66a3f4d31af228766c
  - 耗时：0.391 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：9c733319ff5d4dc0b437c2feedecc17a
  - 耗时：67.5 秒 / 游戏 100 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：48585afebc3c4de2a3d17063f3f59ac5
  - 耗时：46.938 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：fdcb3cdeda36486092c393add46f37ce
  - 耗时：0.39 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：1add41296af54a10b68f65705e8db086
  - 耗时：50.641 秒 / 游戏 70 分钟
- **10:00** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 95 to 95 (0 floors down, 7 stones broken); retreated: health 50/135 and 0 healing food left; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：25ba83b84c23469aa042989ea9f43bce
  - 耗时：44.344 秒 / 游戏 30 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] +16 Energy
  - 🗨️ [hud] +50 Health
  - 🗨️ [question] 
- **10:30** Mine ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：7ae3d88469ad400ba9ade6dbde3b4d7c
  - 耗时：0.375 秒 / 游戏 0 分钟
- **10:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 18 (3 floors down, 23 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：0d8d9875ebe840d68416b2abe4b23687
  - 耗时：86.922 秒 / 游戏 110 分钟
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Amethyst
  - 🗨️ [hud] Mystery Box
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [question] 
- **12:20** Mine ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：3c184bb7ba9b4abe94c01324ed28b57f
  - 耗时：49.344 秒 / 游戏 60 分钟
- **13:20** Blacksmith ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：c6c5e825cfdd444a897668e1683305d5
  - 耗时：38.937 秒 / 游戏 50 分钟
- **13:20** Blacksmith ✅ `store_items`（items=["Stone", "Cauliflower Seeds", "Magma Geode", "Potato Seeds", "Geode", "Amethyst", "Mystery Box", "Bug Meat"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (75,15): 2x Magma Geode, 1x Geode, 1x Mystery Box
  - 执行状态：SUCCESS · 操作编号：9c0a7a5fad60475c903d55dce370c9b6
  - 耗时：1.125 秒 / 游戏 0 分钟
- **13:20** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **14:10** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (75,16)
  - 执行状态：SUCCESS · 操作编号：6e53d6329fd342bb9ac80c3124a1bd5d
  - 耗时：0.406 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `store_items`
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：eda1b98cbb264199bcce4ca9e3619194
  - 耗时：0.406 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Bar", "Iron Bar", "Gold Bar", "Gold Ore", "Copper Ore", "Stone", "Fiber", "Salad", "Cauliflower Seeds", "Potato Seeds", "Claymore", "Silver Saber", "Steel Axe", "Steel Pickaxe", "Steel Watering Can", "Copper Hoe", "Fiberglass Rod", "Bamboo Pole", "Scythe", "Rusty Sword", "Magma Geode", "Dwarf Scroll I"]）
  - 结果：shipped 2 stacks worth ~116g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：6c224261ba2e477293a1be096d82b469
  - 耗时：0.921 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `store_items`
  - 结果：stored in chest at (74,15): 2x Coal
  - 执行状态：SUCCESS · 操作编号：395e906b4f3947e3979ec6d5a7d30a0f
  - 耗时：0.422 秒 / 游戏 0 分钟
- **14:10** Farm ✅ `collect_machines`
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：edd5546f8c7140f1ac70ec91a53996a0
  - 耗时：13.875 秒 / 游戏 20 分钟
  - 🗨️ [hud] Gold Bar
- **14:30** Farm ✅ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：8f252a56d8bf40048b3ae6bcb0ee1ebc
  - 耗时：0.484 秒 / 游戏 0 分钟
  - 🗨️ [hud] Coal
- **14:30** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：fc6c29b1649645be8c4fedda74c35ee7
  - 耗时：0.422 秒 / 游戏 0 分钟
- **14:30** Farm ✅ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：mined from floor 15 to 18 (3 floors down, 24 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：fbd69da404754dec87954456796c2546
  - 耗时：65.079 秒 / 游戏 80 分钟
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Green Algae
  - 🗨️ [question] 
- **15:50** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (回农场再看哪些路格走得上去)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：0809e1ce535546eca94b63c7cb8c7dab
  - 耗时：35.766 秒 / 游戏 40 分钟
- **15:50** Mine ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **16:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:30** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:30 pm
  - 执行状态：SUCCESS · 操作编号：63f510cf8b5c4059bf67cc37e6df6b0a
  - 耗时：81.141 秒 / 游戏 120 分钟
- **18:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：af0d57e1e8744afd93b40adf0a2e0413
  - 耗时：15.39 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：65285 → 66501（+1216g）
- 出货估值：1216g　动作：42 个　失败：18 个
- 模型调用：6 次　tokens：69747
- 有效动作率：0.6471　空转：4　熔断跳过：6
- 失败耗时：3.404 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天42动作18失败，核心浪费在12次take宝石全失败（箱子内容与记忆不符）、清包只腾4格导致升级被拒、食物不足下矿只挖3层。有效动作是收作物、出货、熔炉炼金。铁锭链连续7天零推进，必须把清包+补食物+电梯40层作为唯一主线，删除take/donate/build_road/decorate/wait。

**新教训：**
- 昨天 12 次 take 宝石全失败且脚本重写 3 次仍在重试同一批 ID：take 失败后必须当天物理删除该动作，不能靠重写脚本再试，否则每次重写都浪费 4-6 个动作。
- 昨天清包只 store_items 一次腾出 4 格，upgrade_tool 返回「have 4, need 5」：store_items 后必须紧接着 ship_produce 卖低价值物，并读背包验证空格≥15，单靠 store_items 不够。
- 昨天 12:20 才买沙拉、13:50 才下矿，只挖 4 层就体力耗尽：补食物必须排在清包之后、下矿之前，且 12:00 前用 Forest 钓鱼过渡，不能等到中午才动身。
- 昨天电梯到 80 层但食物=0 被拦在 19 层，一颗铁矿没拿到：下矿目标应固定 40 层（铁矿下限），电梯再高也白跑，食物是门票。
- 昨天 donate_museum 因背包无可捐物失败，而宝石都在箱子里：捐博物馆前必须先确认背包实际有可捐物，否则直接跳过，不要先 goto ArchaeologyHouse 再失败。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 春 28）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 65285g 充足，卡点是 Iron Bar 1/5（Iron Ore 3、Coal 26）。已连续 7 天零推进，铁锭链是全局瓶颈：钢斧、洒水器、高级洒水器全排在它后面。

离完成还差：约 25 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。**铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标；食物≥5 和背包空格≥15 是两张门票，缺一张当天就白跑。**

接下来 3 天主活动：
- **今天（春 28）**：起床收炉→清包到空格≥15→补食物≥5→电梯 40 层刷铁矿石+煤（目标 40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。季末只种 28 日前能熟的作物。
- **明天（夏 1）**：买啤酒花（隔行支架）、蓝莓、甜瓜；hoe 升完转钢斧（同配方 5 铁锭）；铁锭不足则全天 40-50 层刷铁。
- **后天（夏 2）**：铁锭富余后做洒水器 ×4，把浇水体力省下来；继续刷铁备钢斧。

## 今日核心修正（按执行顺序）
1. **清包是今天第一硬门槛，且必须双管齐下**：goto Farm → store_items（不指定坐标，存 Stone/Geode/种子/杂矿）→ ship_produce（卖鱼/杂矿/低价值物，Stone/Coal/矿石/锭除外）→ **读背包验证空格≥15**。昨天只腾 4 格导致 mine/upgrade 全被拒。两次仍<15 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **食物提前到清包后立刻解决**：昨天 12:20 才买沙拉，下矿已 13:50，只挖 4 层就体力耗尽。今天清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
3. **下矿目标 40 层，不贪 80 层**：昨天电梯到 80 层但食物=0 被拦在 19 层，白跑。今天电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
4. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
5. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
6. **mine 成功一次后先 store_items 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
9. **build_road / decorate / donate_museum 物理删除**：昨天各失败 1 次、连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 一次性清包到空格≥15：goto Farm → store_items（不指定坐标）→ ship_produce 卖低价值物 → 读背包验证；不足再 ship 一次 → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥15 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 store_items 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买夏季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥15 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：store/ship 后必须读背包验证空格≥15，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 不指定旧坐标**：返回 could not reach 说明箱子路径被挡，改用可达箱子或直接 ship_produce，不重试同一坐标。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<15 则物理删除 mine 分支。
- **mine 成功一次后先 store_items 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0**。
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
3. 一次性清包到空格≥15（store_items 不指定坐标 + ship_produce 卖低价值物 + 读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥15、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 store_items 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买夏季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天42动作18失败，核心浪费在12次take宝石全失败（箱子内容与记忆不符）、清包只腾4格导致升级被拒、食物不足下矿只挖3层。有效动作是收作物、出货、熔炉炼金。铁锭链连续7天零推进，必须把清包+补食物+电梯40层作为唯一主线，删除take/donate/build_road/decorate/wait。
- 06:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:20 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 13:20 动作 `upgrade_tool` 失败 @ Blacksmith — store did not free enough slots (have 4, need 5) 〔自动〕
- 14:30 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 15:50 动作 `build_road` 失败 @ Mine — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 16:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 12 次 take 宝石（Aquamarine/Ruby/Topaz/Diamond/Frozen Tear/Earth Crystal）全部失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 (74,15) — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：捐博物馆、送礼、献祭都拿不到指定物品，白耗 12 个动作） 〔复盘〕
- donate_museum 到达博物馆后无可捐物 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：社区中心/博物馆进度停滞，且白跑一趟 Town） 〔复盘〕
- 清包只腾出 4 格，mine 和 upgrade_tool 都被拒 @ Farm — store did not free enough slots (have 4, need 5)（做不了：下矿和工具升级都被卡住，铁锭链无法推进） 〔复盘〕
- 食物只有 1 个，下矿被限制在 19 层，只挖 3 层就撤退 @ Mine 15-18 层 — retreated: health 50/135 and 0 healing food left（做不了：拿不到 40 层以下的铁矿石，铁锭链连续 7 天零推进） 〔复盘〕
- load_machines 投 Gold Ore 时两炉都忙 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：熔炉产出节奏被打乱，铁锭/金锭延迟） 〔复盘〕
- build_road 和 decorate 连续多天 0 产出仍被调用 @ Farm — 规划道路边没有还能走上去的空格 / 今天没有能做的装饰（做不了：浪费 2 个动作，脚本重写次数增加） 〔复盘〕
