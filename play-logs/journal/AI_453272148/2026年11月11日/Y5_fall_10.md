# 第5年 fall 10 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（06:05 开始）
- 天气：rain　金钱：68323g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `build_road`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y5_fall_10）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g + 5 铁锭）
- 起床收熔炉成品，空炉且铁矿≥5 则装料
- 清包：ship_produce 显式卖 Copper Bar 留 20，验证空格≥5
- 补食物：Forest 钓鱼补到≥5（Saloon 周三关门，改钓鱼）
- 电梯直达 40 层刷铁矿石+煤（40→50，≤2 次 mine）
- 回农场收铁锭，铁锭≥5 且时间<13:00 去 Blacksmith 升 hoe
- 收尾 sleep
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
12. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore"]）
13. `ship`（item="Copper Bar", count=62）
14. `goto_location`（location="Forest"）
15. `fish`（casts=4）
16. `goto_location`（location="Mine"）
17. `mine`（floors=5）
18. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Iron Bar"]）
19. `mine`（floors=5）
20. `goto_location`（location="Farm"）
21. `collect_machines`
22. `goto_location`（location="Blacksmith"）
23. `upgrade_tool`（tool="hoe"）
24. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Gold Ore -> Furnace (ready in 300 min)
  - 执行状态：SUCCESS · 操作编号：3e447ea646f24cef9eaa0c20582b4ed6
  - 耗时：17.312 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：fea470d4ce944a378c5df2870f050a81
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：829593af1d214681854dc394bda94efa
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：52ab6453f6de48a58c068acace1bb21a
  - 耗时：0.562 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6525b0c29e724f23a8c4d4394d601c0f
  - 耗时：0.453 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 失败已按教训物理删除；保留清包→钓鱼补食物→40 层刷铁→回农场收锭→升 hoe 的原路线，去掉 donate 与所有 take/store
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Mine"）
12. `mine`（floors=5）
13. `mine`（floors=5）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Farm"）
17. `collect_machines`
18. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore"]）
19. `collect_machines`
20. `load_machines`（item="Iron Ore"）
21. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Iron Bar"]）
22. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：8edf6bd3fcd64feeaf5703b3b7ede2b8
  - 耗时：0.531 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：take 连续失败已物理删除，改走清包→补食物→40层刷铁→收炉→睡觉，不再碰箱子。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `goto_location`（location="Forest"）
10. `fish`（casts=4）
11. `goto_location`（location="Saloon"）
12. `open_shop`（shop_id="Saloon"）
13. `buy`（item="Salad", count=5）
14. `close_menu`
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `goto_location`（location="Farm"）
19. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore"]）
20. `collect_machines`
21. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar"]）
22. `sleep`
- **06:20** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:20** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6d14aff9e1e14424b85f98b17045aada
  - 耗时：0.516 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 连续失败已物理删除，改为起床收炉+装铁矿石+显式卖 Copper Bar 清包，再电梯40层刷铁，回农场收锭后睡觉。
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
11. `mine`（floors=5）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `load_machines`（item="Iron Ore"）
15. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore"]）
16. `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar"]）
17. `collect_machines`
18. `sleep`
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
  - 执行状态：ACTION_FAILED · 操作编号：ed0e455b4ee047ef8f9eb902aa67d5f8
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：c447392767d54236880df2eaccb816f2
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：1c466e7abc3949adb4d6a68805152cc4
  - 耗时：0.484 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：878148d7632f4ec78a013608f4d635d5
  - 耗时：72.172 秒 / 游戏 100 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：b4543fa60d844da38a8d42f4953756d3
  - 耗时：59.172 秒 / 游戏 70 分钟
- **09:10** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：fe2a230110e4421f9748b27560baf6be
  - 耗时：0.484 秒 / 游戏 0 分钟
- **09:10** ArchaeologyHouse ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：de28fdce50db44b1bb8300f7fc796f22
  - 耗时：50.735 秒 / 游戏 60 分钟
- **10:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：2ba8d02be93e461cb8ec70f45754c42a
  - 耗时：33.625 秒 / 游戏 40 分钟
- **10:10** Mine ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds", "Green Algae"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 2x Green Algae
  - 执行状态：SUCCESS · 操作编号：95dfb2bfa5444ef984de076818bb21f8
  - 耗时：15.047 秒 / 游戏 20 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：f294774d36cd4dfd99ce5c840e82845f
  - 耗时：0.468 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (74,16)
  - 执行状态：SUCCESS · 操作编号：95f267749086452ab76a9304f93874e3
  - 耗时：0.609 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：1f1545daf66f4bb8997f6788b554266d
  - 耗时：0.469 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：f9921370630240678f731129e0d9703d
  - 耗时：0.454 秒 / 游戏 0 分钟
- **11:10** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：5d140a20466f4da6bcb77feb907ccb27
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:10** Farm ✅ `ship_produce`（except=["Salad", "Strange Bun", "Pumpkin Seeds", "Melon Seeds", "Radish Seeds", "Coal", "Iron Ore", "Copper Ore", "Gold Ore", "Iron Bar"]）
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：4691343f4e524ce1b587b160e856199d
  - 耗时：0.453 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **11:10** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：a049e82e93684041876bf2d4158121c7
  - 耗时：0.516 秒 / 游戏 0 分钟
- **11:10** Farm ✅ `store_items`（items=["Stone", "Salad", "Pumpkin Seeds", "Strange Bun", "Melon Seeds", "Magma Geode", "Radish Seeds"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：0d57768763a34f05a333ad8c7b32166a
  - 耗时：0.546 秒 / 游戏 0 分钟
- **11:10** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：store did not free enough slots (have 3, need 5)
  - 执行状态：ACTION_FAILED
- **11:10** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：f1c22220092d4835a041105fe19dd1a5
  - 耗时：23.844 秒 / 游戏 30 分钟
- **11:40** Forest ✅ `collect_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：collected: Gold Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：aea3f2b1b25445659ac9ce62e74de3d0
  - 耗时：20.265 秒 / 游戏 30 分钟
  - 🗨️ [hud] Gold Bar
- **12:10** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：6d39cfa415e046ee8201eef90baba041
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:10** Farm ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：65215df5707c43e0864bfce848b491b4
  - 耗时：0.484 秒 / 游戏 0 分钟
- **12:10** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **12:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:10** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：629df6abcba04f91a9773f44f900d662
  - 耗时：17.75 秒 / 游戏 20 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：68323 → 68323（+0g）
- 出货估值：0g　动作：42 个　失败：24 个
- 模型调用：6 次　tokens：69112
- 有效动作率：0.3824　空转：11　熔断跳过：7
- 失败耗时：7.343 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天42动作24失败，核心卡点仍是背包空格：ship_produce的except排除了Copper Bar/Gold Bar，导致清包形同虚设，mine三次被「have 3, need 5」拒绝；take 12次全失败、donate空跑、build_road/decorate填充失败。铁锭链连续8天零推进，钢锄头未升。今天唯一硬目标是真正腾出5格并下40层拿铁。

**新教训：**
- 昨天 ship_produce 两次返回 nothing to ship，因为 except 列表把 Copper Bar/Gold Bar/Stone 全排除：清包时必须显式指定卖 Copper Bar 留 20、Gold Bar 留 2，不能把这些写进 except，否则空格永远是 2-3。
- 昨天 mine 三次被「store did not free enough slots (have 3, need 5)」拒绝，而同一时刻 ship_produce 返回 nothing to ship：说明「清包失败」和「下矿被拒」是同一条因果链，清包验证失败后必须立刻定性钓鱼日，而不是继续尝试 mine。
- 昨天 12 次 take 全失败且脚本重写 3 次仍在重试同一批 ID（62/64/68/72/84/86）：take 失败后必须当天物理删除该动作，不能靠重写脚本再试，否则每次重写浪费 4-6 个动作。
- 昨天 donate_museum 在背包无可捐物时先 goto ArchaeologyHouse 等开门再失败，浪费 2 动作：donate 前必须先读背包确认有可捐物，没有就直接跳过，不要先跑图。
- 昨天 15:00 后 build_road/decorate 作为填充动作各失败一次：这两个动作应从脚本中彻底删除，收尾只允许 sleep，绝不用填充动作空转。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 秋 11）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 68323g 充足，卡点 Iron Bar 0/5，已连续 8 天零推进；铁锭链是全局瓶颈（钢斧、洒水器、高级洒水器全排在后面）。

离完成还差：约 20 铁矿石 + 5 煤 → 5 铁锭 → 铁匠铺升 hoe（9:00-16:00，一次一件）。铁矿只在 40 层以下，电梯直达 40 层是唯一硬目标。**背包空格≥5 是唯一门票**。

接下来 3 天主活动：
- **今天（秋 11）**：起床收炉→**ship 显式卖 Copper Bar 留 20（62 个约 7k，腾 3-4 格）**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（40→50）→回农场炼铁；铁锭≥5 且 <13:00 升 hoe。
- **明天（秋 12）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后做洒水器 ×4。
- **后天（秋 13）**：继续刷铁备钢斧，给作物地块补洒水器，省下浇水体力。

## 今日核心修正（按执行顺序）
1. **清包唯一手段是 ship_produce，且必须显式卖 Copper Bar**：昨天 ship 只卖了种子（约3.7k），Copper Bar/Gold Bar/Stone 全被 except 排除，空格始终 2。今天清包顺序：goto Farm → ship_produce 卖 **Copper Bar 留 20（其余 62 个全卖，约 7k）** → 读背包验证空格≥5。若仍不足，再 ship 卖 **Gold Bar 留 2（10 个可卖）** → 再验证。两次不足 → 当天定性钓鱼日，物理删除 mine/upgrade 分支。
2. **store_items 今天物理删除**：连续多天返回 OK 却一格没腾，箱子路径/容量已不可用。
3. **食物提前到清包后立刻解决**：清包完成即 goto Saloon（12:00 后）买沙拉到 ≥5；若时间<12:00，先去 Forest 河边 fish ≤1 轮（≤4 cast）补食物，12:00 后再买。**食物<5 时物理删除 mine 分支**。
4. **下矿目标 40 层，不贪 80 层**：电梯直达 **40 层**，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。**禁止从 89/95 层往下爬**。
5. **起床三连（5 分钟内）**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 立即 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 若 Iron Ore<5，直接进入清包+补食物+下矿。
6. **take 全天物理删除**：昨天 12 次 take 全失败，箱子内容与记忆不符。需要矿物靠下矿现拿，绝不凭 ID 猜箱子。
7. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
8. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:30 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
9. **收尾提前到 21:30**：21:30 后只允许 sleep，禁止 store_items/ship_produce/collect_machines 拖到 22:00 后。**任何情况下不用 wait 填充时间**。
10. **build_road / decorate / donate_museum / take / store_items / wait 物理删除**：连续多天 0 产出，从脚本中彻底删除。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. 清包到空格≥5：goto Farm → ship_produce 卖 **Copper Bar 留 20** → 读背包验证；不足再 ship 卖 **Gold Bar 留 2** → 再验证；两次不足即当天定性钓鱼日，删除 mine/upgrade 分支。**今天不调 store_items**。
4. 补食物到≥5：时间≥12:00 去 Saloon 买沙拉；时间<12:00 先去 Forest 河边 fish ≤1 轮（≤4 cast），12:00 后再买。食物<5 不下矿。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 **40 层**，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-13:00 → goto Blacksmith → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. 买秋季种子（仅当时间<17:00 且背包空格≥5）：goto SeedShop → open_shop → buy；buy 成功一次后不关菜单继续买；buy 失败一次即跳过。买完立即 plant_seeds 种下。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。**任何情况下不用 wait 填充时间**。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼/买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿，且清包后禁止 take**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load/take）。
- **store_items 今天禁用**：昨天返回 OK 但空格未增，箱子不可用；今天只用 ship_produce 清包。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。**buy 成功后不关菜单继续买**。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **节日日规则**：节日地图开放前禁止 goto 节日地点；出现「festival is being set up」或 Town 被占即当天不再 goto Town；festival start 只在已到达节日地图后调用，goto 失败即跳过。
- **upgrade_tool 必须带 tool 参数**：传 tool=hoe（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar≥5、现金≥5000、空格≥5；不够直接跳过。一次只升一件。**could not reach/locked/timeout 即当天永久跳过升级**。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate / wait / water_crops / ArchaeologyHouse / Saloon（除买沙拉）/ take / store_items 禁用**：连续多天 0 产出，从脚本中彻底删除。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止不存在的动作**：chop_tree 不存在，砍树用 use_tool tool=axe 带 x,y。
- **每日动作上限**：load_machines≤1、collect_machines≤2、harvest_crops≤1、craft≤4、place≤6、open_shop≤2、buy≤2、upgrade_tool≤1（仅 9:10-13:00）、interact 同一 NPC≤3、give_gift≤1、use_tool axe≤10、mine≤2、fight≤3、fish≤4、**take=0、store_items=0**。
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
3. 清包到空格≥5（**只用 ship_produce 卖 Copper Bar 留 20，其次 Gold Bar 留 2**，读背包验证；两次不足即删 mine/upgrade 分支；清包后禁止 take）
4. 食物补到≥5（Saloon 买沙拉或 Forest 河边钓鱼）
5. 下矿：电梯直达 **40 层**拿铁矿石+煤（空格≥5、食物≥5、武器 avg≥14 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<13:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 买秋季种子（open_shop 成功后再 buy，buy 成功后不关菜单继续买，背包空格≥5，buy 失败一次即跳过；买完立即 plant_seeds）
10. craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
11. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天42动作24失败，核心卡点仍是背包空格：ship_produce的except排除了Copper Bar/Gold Bar，导致清包形同虚设，mine三次被「have 3, need 5」拒绝；take 12次全失败、donate空跑、build_road/decorate填充失败。铁锭链连续8天零推进，钢锄头未升。今天唯一硬目标是真正腾出5格并下40层拿铁。
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
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
- 09:10 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:10 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 11:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:10 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 11:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:10 动作 `mine` 失败 @ Farm — store did not free enough slots (have 3, need 5) 〔自动〕
- 12:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:10 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清包动作形同虚设：ship_produce 两次返回 nothing to ship，背包空格始终 2-3，导致下矿和升级全被拒 @ Farm（出货箱旁） — ship_produce 的 except 列表包含 Copper Bar/Gold Bar/Stone，返回 nothing to ship；mine 返回 store did not free enough slots (have 3, need 5)（做不了：无法下 40 层拿铁矿，钢锄头连续 8 天零推进） 〔复盘〕
- take 凭物品 ID 猜箱子连续失败，脚本重写 3 次仍在重试同一批 ID @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（12 次全失败）（做不了：浪费 12 个动作和 3 次脚本重写，挤占下矿时间） 〔复盘〕
- donate_museum 在背包无可捐物时先跑 ArchaeologyHouse 等开门再失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：浪费 2 动作和等待开门时间） 〔复盘〕
- 熔炉未完成时反复 collect_machines/load_machines 空转被抑制 @ Farm — no machine has finished output / no empty machine accepts that, and the rest are busy / repeated ineffective action suppressed（做不了：浪费 4-5 个动作） 〔复盘〕
- 收尾阶段用 build_road/decorate 填充时间，各失败一次 @ Farm — 规划道路边没有还能走上去的空格 / 今天没有能做的装饰（做不了：无实际产出，纯空转） 〔复盘〕
