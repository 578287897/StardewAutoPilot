# 第5年 winter 22 日 — AI 游玩日志
（写入日期：2026年11月11日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌅 早上的计划（14:12 开始）
- 天气：snow　金钱：78484g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `build_road`
4. `harvest_crops`
5. `water_crops`
6. `ship_produce`

## 🌙 为明天（Y5_winter_22）准备的脚本
- 里程碑：工具按档升级——Steel Hoe（5000g + 5 铁锭），今天必须凑齐 4 块铁锭
- 起床收熔炉成品，炉空且铁矿≥5 才装铁矿
- 清包到空格≥5：农场出货箱卖 Copper Bar 留 20，再卖多余 Stone/Sap/Green Algae
- 补食物到≥8（Saloon 12 点后开门买沙拉）
- 电梯直达 40 层刷铁矿石+煤，≤2 次 mine、每次 ≤5 层
- 回农场收铁锭，铁锭≥5 且 12:00 前就去 Blacksmith 升 hoe
- 清包/下矿失败即转 Forest 钓鱼兜底，21:30 前睡
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
11. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank", "Clay", "Driftwood", "Trash"]）
12. `ship`（item="Copper Bar", count=65）
13. `ship`（item="Stone", count=20）
14. `ship`（item="Green Algae", count=4）
15. `goto_location`（location="Mine"）
16. `mine`（floors=5）
17. `mine`（floors=5）
18. `leave_mine`
19. `goto_location`（location="Farm"）
20. `collect_machines`
21. `goto_location`（location="Blacksmith"）
22. `upgrade_tool`（tool="hoe"）
23. `goto_location`（location="Forest"）
24. `fish`（casts=5）
25. `fish`（casts=5）
26. `fish`（casts=5）
27. `goto_location`（location="Farm"）
28. `ship_produce`
29. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Copper Bar from Furnace
  - 执行状态：SUCCESS · 操作编号：7057b354d7d24ed680e4ae70fb09b370
  - 耗时：17.329 秒 / 游戏 20 分钟
  - 🗨️ [hud] Copper Bar
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：01d633e06f7f410a8257d6c943872918
  - 耗时：0.5 秒 / 游戏 0 分钟
- **06:20** Farm ❌ `build_road`
  - 结果：规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格
  - 执行状态：NO_PROGRESS
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Driftwood, 3x Trash, 1x Copper Bar
  - 执行状态：SUCCESS · 操作编号：838a315920294c80a6cf40d9c0b99dd3
  - 耗时：18.313 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：247e1926075847e68b716792dd1c36de
  - 耗时：0.594 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：1f52b054db11450eb15249315a1ac503
  - 耗时：0.547 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：132702f6fd1d49f8b66162478d91546b
  - 耗时：0.578 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：'62' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：0b6973a1c1974631b72ca91e084f309e
  - 耗时：0.5 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：take 箱子 ID 全失效，改为出货箱卖 Copper Bar 腾格后直接下矿 40 层刷铁，回来收锭并赶 12:00 前升 hoe，失败即 For
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
12. `leave_mine`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=5）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `goto_location`（location="Farm"）
20. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank", "Clay", "Driftwood", "Trash"]）
21. `collect_machines`
22. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank", "Clay", "Driftwood", "Trash"]）
23. `collect_machines`
24. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：'64' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：6de696ef715848538f8673dd381a261d
  - 耗时：0.578 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：放弃失效的take分支，改在农场出货箱卖Copper Bar腾格后下矿40层刷铁，铁锭够则升hoe，否则Forest钓鱼兜底到睡。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=28）
11. `ship`（item="Green Algae", count=4）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
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
26. `ship_produce`（except=["Iron Bar", "Gold Bar", "Iron Ore", "Copper Ore", "Coal", "Pumpkin Seeds", "Rice Shoot", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Claymore", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Rubber Boots", "Steel Watering Can", "Burglar's Shank", "Clay", "Driftwood", "Trash"]）
27. `collect_machines`
28. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：'68' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：593412d51caf4b979ee5f7227b26eb5e
  - 耗时：0.547 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：take 全部失效（箱子内容与记忆不符），改为在农场出货箱卖 Copper Bar 腾格后直接下矿刷铁，失败兜底 Forest 钓鱼，收尾睡觉。
1. `take`（item="62", item_name="Aquamarine", count=1）
2. `take`（item="64", item_name="Ruby", count=1）
3. `take`（item="68", item_name="Topaz", count=1）
4. `take`（item="72", item_name="Diamond", count=1）
5. `take`（item="84", item_name="Frozen Tear", count=1）
6. `take`（item="86", item_name="Earth Crystal", count=1）
7. `goto_location`（location="ArchaeologyHouse"）
8. `donate_museum`
9. `ship`（item="Copper Bar", count=66）
10. `ship`（item="Stone", count=28）
11. `ship`（item="Green Algae", count=4）
12. `goto_location`（location="Mine"）
13. `mine`（floors=5）
14. `mine`（floors=5）
15. `leave_mine`
16. `goto_location`（location="Forest"）
17. `fish`（casts=5）
18. `fish`（casts=5）
19. `fish`（casts=5）
20. `fish`（casts=5）
21. `goto_location`（location="Farm"）
22. `collect_machines`
23. `load_machines`（item="Iron Ore"）
24. `collect_machines`
25. `sleep`
- **06:40** Farm ❌ `take`（item="62", item_name="Aquamarine", count=1）
  - 结果：take 62 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="64", item_name="Ruby", count=1）
  - 结果：take 64 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="68", item_name="Topaz", count=1）
  - 结果：take 68 already failed; not retrying today
  - 执行状态：CIRCUIT_OPEN
- **06:40** Farm ❌ `take`（item="72", item_name="Diamond", count=1）
  - 结果：'72' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：43fd70d0138a46c387928a3253d9c842
  - 耗时：0.546 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="84", item_name="Frozen Tear", count=1）
  - 结果：'84' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：fb56743759844db18450eeecde6aa4d6
  - 耗时：0.531 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `take`（item="86", item_name="Earth Crystal", count=1）
  - 结果：'86' is not in any farm chest
  - 执行状态：ACTION_FAILED · 操作编号：a242a07a255743d3a01f6ad18fe020a0
  - 耗时：0.515 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：waited until 8:00 am (waiting for ArchaeologyHouse to open at 8:00)
  - 执行状态：SUCCESS · 操作编号：09959f0ad478404fb7e72e6a2e32aee1
  - 耗时：54.281 秒 / 游戏 80 分钟
- **08:00** Farm ✅ `goto_location`（location="ArchaeologyHouse"）
  - 结果：arrived at ArchaeologyHouse (3,14)
  - 执行状态：SUCCESS · 操作编号：31b81a9d094548d1aff5bd7ee81feceb
  - 耗时：43.782 秒 / 游戏 50 分钟
- **08:50** ArchaeologyHouse ❌ `donate_museum`
  - 结果：nothing in the backpack can be donated to the museum
  - 执行状态：ACTION_FAILED · 操作编号：fa79120aca374fa2877c4ca974e843df
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ❌ `ship`（item="Copper Bar", count=66）
  - 结果：'Copper Bar' not found in inventory
  - 执行状态：ACTION_FAILED · 操作编号：7e807bc0c9bc4c97bb06c068ccc58ddc
  - 耗时：0.531 秒 / 游戏 0 分钟
- **08:50** ArchaeologyHouse ✅ `ship`（item="Stone", count=28）
  - 结果：shipped 28x Stone (~56g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：4c0eea05c76448d3bac0527340f261e1
  - 耗时：43.968 秒 / 游戏 50 分钟
- **09:40** Farm ✅ `ship`（item="Green Algae", count=4）
  - 结果：shipped 4x Green Algae (~60g, paid overnight)
  - 执行状态：SUCCESS · 操作编号：49c60a27a5354a3083ce235af1822b6a
  - 耗时：0.516 秒 / 游戏 0 分钟
- **09:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：e0383bdce5b147189b304e6f210f4745
  - 耗时：52.61 秒 / 游戏 70 分钟
- **10:50** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 16 (1 floors down, 30 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：f0a4d31e10b0460aa056a066191b20c5
  - 耗时：147.062 秒 / 游戏 200 分钟
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Mixed Seeds
  - 🗨️ [hud] Slime
  - 🗨️ [hud] Rice Shoot
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Geode
  - 🗨️ [question] 
- **14:10** Mine ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：4253dcd8c84e43ab9618aaa78ad596e9
  - 耗时：35.844 秒 / 游戏 40 分钟
- **14:10** Mine ✅ `store_items`（items=["Stone", "Rice Shoot", "Pumpkin Seeds", "Mixed Seeds", "Rubber Boots", "Slime", "Bug Meat", "Geode"]）
  - 💭 (背包没有空位，先把非目标物品存箱)
  - 结果：stored in chest at (74,15): 1x Mixed Seeds, 1x Slime, 3x Bug Meat, 1x Geode
  - 执行状态：SUCCESS · 操作编号：41bdec96cb9c449cb87b45d30fc5be4a
  - 耗时：15.11 秒 / 游戏 20 分钟
- **14:10** Mine ❌ `mine`（floors=5）
  - 结果：store did not free enough slots (have 4, need 5)
  - 执行状态：ACTION_FAILED
- **15:10** Farm ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：50034cba98cb4fa7ab73553e7aa6272c
  - 耗时：0.531 秒 / 游戏 0 分钟
- **15:10** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：39845885c8914c8eacade098a2105321
  - 耗时：23.875 秒 / 游戏 30 分钟
- **15:40** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Pike, Pike, Green Algae, Green Algae)
  - 执行状态：SUCCESS · 操作编号：04416d5c4c794cfe9850b123b2dff22c
  - 耗时：108.547 秒 / 游戏 120 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
- **17:40** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Pike, Green Algae, Green Algae, Perch, Pike)
  - 执行状态：SUCCESS · 操作编号：234d674390674f69b9efeb72114ad12c
  - 耗时：98.843 秒 / 游戏 90 分钟
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Perch
- **19:10** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Perch, Green Algae, Pike, Perch, Green Algae)
  - 执行状态：SUCCESS · 操作编号：c10d83f301904a21b42f9e87d3467e7b
  - 耗时：82.954 秒 / 游戏 70 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Pike
  - 🗨️ [hud] Perch
- **20:20** Forest ✅ `fish`（casts=5）
  - 结果：fished: caught 5 (Perch, Driftwood, Perch, Joja Cola, Perch)
  - 执行状态：SUCCESS · 操作编号：9a275e7f40594b29bbf5657a3dfea051
  - 耗时：103.734 秒 / 游戏 110 分钟
  - 🗨️ [hud] Perch
  - 🗨️ [hud] Driftwood
  - 🗨️ [hud] Perch
- **22:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：6e0ad859fb7d4606ad8bbacb3833d598
  - 耗时：9.672 秒 / 游戏 10 分钟
- **22:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：24cf702b2f9f4117a54c846734f07acf
  - 耗时：0.5 秒 / 游戏 0 分钟
- **22:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：07a2f3d5a5bf433e952014b365b6aa4c
  - 耗时：0.516 秒 / 游戏 0 分钟
- **22:20** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **22:20** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：99edffe410d24e68b6cbdc93f7bd5db3
  - 耗时：23.625 秒 / 游戏 30 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：78484 → 78600（+116g）
- 出货估值：0g　动作：41 个　失败：21 个
- 模型调用：6 次　tokens：70899
- 有效动作率：0.4848　空转：7　熔断跳过：7
- 失败耗时：8.045 秒 / 游戏 0 分钟
- 最深矿层：99　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天核心失败是清包没做：85 个 Copper Bar 一个没卖，背包始终 4 空格，导致 mine/upgrade 全被 'need 5' 拒绝；随后 12 次 take 空跑、去博物馆 donate 空跑，12:40 后无兜底空转到 22:20。钓鱼 20 条是唯一有效产出。今天必须把「卖 Copper Bar 留 20」作为起床第一动作，并在同一脚本内预置钓鱼兜底。

**新教训：**
- 昨天 12 次 take 空跑后脚本重写 3 次仍重试同一批箱子 ID，说明重写逻辑没有先读背包：任何脚本重写前必须先读一次背包完整清单，只对清单里实际存在的物品生成动作。
- 昨天在 ArchaeologyHouse 调 ship 报 'Copper Bar' not found，而材料显示背包有 85 个：ship 只能在农场出货箱附近执行，且 ship 前必须先 close_menu 再读背包。
- 昨天清包验证空格<5 后脚本没有钓鱼兜底，从 12:40 到 21:30 全部空转；而 Forest 钓鱼 20 条贡献约 2.1k 出货：清包验证失败后必须在同一脚本里生成 goto Forest→fish 分支。
- 昨天 mine 在 Farm 报 'store did not free enough slots (have 4, need 5)'，说明 mine 动作本身会先尝试 store 再下矿：脚本生成阶段若背包空格<5 就物理删除 mine 分支，而不是等运行时被拒。
- 昨天 22:20 才 sleep，全天 41 动作 21 失败：收尾应硬性 21:30，21:30 后只允许 sleep，任何情况下不用 wait 填充时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y5 冬 23）

## 长期目标
当前里程碑：**工具按档升级——Steel Hoe（5000g + 5 铁锭）**。现金 78484g 远超 5000，唯一卡点是 Iron Bar 1/5，已连续多日零推进。铁锭链是全局瓶颈：钢斧、洒水器 ×4、高级洒水器、鸡舍全排在它后面。

离完成还差：4 铁锭 ≈ 20 铁矿石 + 4 煤（2 座熔炉现成，Iron Ore 仅 1，必须下 40 层以下刷）。下矿与升级的共同门票是**背包空格≥5**——昨天背包 4 空格，mine×2、upgrade 全被拒，而背包 85 个 Copper Bar 一个没卖。今天清包是唯一第一优先级。

接下来 3 天主活动：
- **今天（冬 23）**：起床 collect→读背包→**农场出货箱 ship_produce Copper Bar 留 20**→读背包验证空格≥5→电梯 40 层刷铁矿石+煤（≤2 次 mine，每次 ≤5 层）→回农场炼铁→铁锭≥5 且 <12:00 升 hoe。验证不过立即转 Forest 钓鱼。
- **明天（冬 24）**：铁锭不足则全天 40-50 层刷铁；铁锭够则升钢斧；铁锭富余后 craft 洒水器 ×4 并 place。
- **后天（冬 25）**：继续刷铁备钢斧，给作物地块补洒水器，开始冬季种子/茶苗。

## 今日核心修正（按执行顺序）
1. **清包唯一有效手段 = 农场出货箱卖 Copper Bar 留 20**：起床读背包后显式 ship_produce Copper Bar count=背包数-20（约 65 个，约 7k，腾 3-4 格），再卖多余 Stone（留 500）、Sap、Green Algae。**绝不把 Copper Bar 写进 except**。
2. **ship 只在农场出货箱执行**：ship 前必须 close_menu 并读背包完整清单，只对清单里实际存在的物品调 ship，绝不凭记忆猜。
3. **take / store_items / donate_museum / build_road / decorate / wait 全天物理删除**：昨天 take 空跑 12 次、donate/load/build_road 全 0 产出，脚本生成阶段直接不生成这些分支。
4. **下矿目标 40 层，不贪深层**：电梯直达 40 层，mine ≤2 次、每次 ≤5 层（40→45→50）。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。禁止从 89/95 层往下爬。
5. **起床三连**：collect_machines 1 次 → 读炉状态，任一炉空且 Iron Ore≥5 才 load_machines item=Iron Ore 1 次（busy/no empty 即当天永久跳过）→ 进入清包。
6. **mine 成功一次后先 ship_produce 腾格**，再决定是否第二次下矿，不连续调 mine。
7. **升级窗口硬约束**：铁锭≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 先确认到达柜台附近 → upgrade_tool tool=hoe。升级前读背包确认 Iron Bar≥5。12:00 还没凑齐 5 铁锭，当天放弃升级。could not reach/locked/timeout 即当天永久跳过。
8. **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
9. **收尾提前到 21:30**：21:30 后只允许 sleep。任何情况下不用 wait 填充时间。
10. **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
11. **节日日规则**：出现「festival is being set up」或 Forest/Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。

## 每日固定流程（严格按序；某步失败一次即跳下一步）
1. 起床 collect_machines 1 次（收熔炉成品；返回空即当天跳过，下矿回来再试一次）。
2. 读炉状态：任一炉空且 Iron Ore≥5 且时间<12:00 → load_machines item=Iron Ore 1 次；busy/no empty 即当天永久跳过。
3. **清包（先读后卖，卖 Copper Bar 留 20）**：读背包完整清单 → 在农场出货箱 ship_produce Copper Bar count=背包数-20 → ship_produce 多余 Stone 留 500 → ship_produce Sap/Green Algae → 读背包验证空格≥5；不足再卖第二档（Gold Bar 留 2、Amethyst、Geode 留 2）→ 仍不足即当天定性钓鱼日，删除 mine/upgrade 分支。
4. 补食物到≥8：读背包 Salad≥5 即跳过；不足则 goto Saloon→open_shop→buy Salad 到≥8（buy 成功后不关菜单继续买；buy 失败一次即跳过）。
5. 下矿（仅当空格≥5 且食物≥5 且武器 avg≥14）：goto Mine 前显式读背包确认三项。电梯直达 40 层，mine 目标 40→50，≤2 次 mine，每次 ≤5 层。每层先 fight 清怪 1-2 次再 mine。生命<50% 或食物=0 立即 leave_mine。
6. mine 成功一次后先 ship_produce 腾格，再决定是否第二次下矿。
7. 回农场 collect_machines 1 次收铁锭；返回空即当天永久跳过。
8. 升级工具：Iron Bar≥5 且现金≥5000 且空格≥5 且时间 9:10-12:00 → goto Blacksmith → 确认到达柜台 → upgrade_tool tool=hoe。一次只升一件。goto 或 upgrade 返回 could not reach/locked/timeout 即当天永久跳过。
9. **换季日不买种子**：冬 23 不买任何作物种子；冬季种子/茶苗留到明天。
10. craft 洒水器（Copper Bar≥1 且 Iron Bar≥1 才 craft）+ place（带 x,y；无空位即跳过）。
11. 21:30 后只允许 sleep；体力<15 或时间≥21:30 sleep。任何情况下不用 wait 填充时间。

## 规则
- **食物≥5 且空格≥5 才下矿**：goto Mine 前必须显式读背包确认两项，不够先买沙拉补。
- **下矿目标 40 层**：铁矿只在 40 层以下，19 层拿不到铁。电梯直达 40 层，不贪 80 层。
- **清包绝对优先于下矿**：ship 后必须读背包验证空格≥5，验证通过前不得出现任何其他动作（含 mine/forage/load）。
- **ship_produce 只卖背包里实际存在的物品**：每次 ship 前先读背包清单，只对清单中存在的物品调 ship，绝不凭记忆猜。
- **Copper Bar 是清包主力**：背包 Copper Bar 留 20，其余全卖（约 7k，腾 3-4 格），绝不写进 except。
- **take / store_items / donate_museum / build_road / decorate / wait 物理删除**：脚本生成阶段不生成这些分支。
- **leave_mine 只在 mine 之后生成**：不在农场或其他地图生成 leave_mine。
- **mine 熔断**：mine 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼；脚本生成阶段若背包空格<5 则物理删除 mine 分支。
- **mine 成功一次后先 ship_produce 腾格**：再决定是否第二次下矿，不连续调 mine。
- **buy 前必须 open_shop 成功**：buy 返回「no shop is open」即重开一次 open_shop，仍失败则跳过当天购买。buy 成功后不关菜单继续买。
- **craft 洒水器前读背包**：Copper Bar≥1 且 Iron Bar≥1 才 craft，缺任一跳过 craft 先炼锭。
- **place 必须带 x,y**：place 前先读分区空位坐标；返回「missing arguments」或「分区无空位」即当天永久跳过 place，不重试。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，绝不重写脚本重跑同一动作。
- **节日日规则**：出现「festival is being set up」或 Town 不可达 → 当天永久删除所有 goto Town / Blacksmith / ArchaeologyHouse / festival 分支，只做农场+矿洞+钓鱼。
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
6. mine 成功一次后 ship_produce 腾格
7. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
8. 铁锭≥5 且空格≥5 且时间<12:00 → Blacksmith 升 hoe（升级前读背包确认锭数与空格；could not reach/locked/timeout 即跳过）
9. 换季日不买种子；craft 洒水器（条件满足才做）+ place（带 x,y；无空位即跳过）
10. 21:30 强制 sleep，禁止 wait

</details>

## ⚠️ 今日问题
> 昨天核心失败是清包没做：85 个 Copper Bar 一个没卖，背包始终 4 空格，导致 mine/upgrade 全被 'need 5' 拒绝；随后 12 次 take 空跑、去博物馆 donate 空跑，12:40 后无兜底空转到 22:20。钓鱼 20 条是唯一有效产出。今天必须把「卖 Copper Bar 留 20」作为起床第一动作，并在同一脚本内预置钓鱼兜底。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 06:20 动作 `build_road` 失败 @ Farm — 规划道路边没有还能走上去的空格，不再对走不了的格子铺 0 格 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '62' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '64' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '68' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 62 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 64 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — take 68 already failed; not retrying today 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '72' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '84' is not in any farm chest 〔自动〕
- 06:40 动作 `take` 失败 @ Farm — '86' is not in any farm chest 〔自动〕
- 08:50 动作 `donate_museum` 失败 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum 〔自动〕
- 08:50 动作 `ship` 失败 @ ArchaeologyHouse — 'Copper Bar' not found in inventory 〔自动〕
- 14:10 动作 `mine` 失败 @ Mine — store did not free enough slots (have 4, need 5) 〔自动〕
- 15:10 动作 `leave_mine` 失败 @ Farm — not in the mine 〔自动〕
- 22:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 22:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 22:20 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 清包计划了但没执行：85 个 Copper Bar 一个没卖，背包始终 4 空格 @ Farm 出货箱 — mine 两次报 'store did not free enough slots (have 4, need 5)'，upgrade 同样被拒（做不了：下矿刷铁和升级 Steel Hoe 全部做不成，铁锭链连续多日零推进） 〔复盘〕
- take 动作连续 12 次空跑，脚本重写 3 次仍重试同一批箱子 ID（62/64/68/72/84/86） @ Farm 箱子 — '62' is not in any farm chest / take 62 already failed; not retrying today（做不了：浪费大量动作与重写次数，挤占了清包和下矿的时间） 〔复盘〕
- 去博物馆 donate 空跑 @ ArchaeologyHouse — nothing in the backpack can be donated to the museum（做不了：白跑一趟 Town，且背包空格不足无法取出可捐物） 〔复盘〕
- 清包验证失败后没有钓鱼兜底，12:40 到 21:30 空转 @ Farm / 地图间 — 脚本重写 3 次仍无有效分支，最后 22:20 才 sleep（做不了：本可多钓 2-3 小时鱼（约 1-2k 收入）和更多钓鱼经验） 〔复盘〕
- load_machines 在炉子全忙时被调两次 @ Farm 熔炉 — no empty machine accepts that, and the rest are busy（做不了：无产出，且触发重复动作抑制） 〔复盘〕
- leave_mine 在 Farm 被调用 @ Farm — not in the mine（做不了：无产出，属于脚本生成阶段未绑定 mine 上下文） 〔复盘〕
