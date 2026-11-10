# 第4年 fall 18 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌅 早上的计划（04:43 开始）
- 天气：windy　金钱：46322g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `load_machines`
3. `harvest_crops`
4. `water_crops`
5. `ship_produce`

## 🌙 为明天（Y4_fall_18）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升钢锄头
- 起床先清背包卖鱼腾出 ≥8 空格
- craft 洒水器 ×4 并放置
- 下矿拿铁矿石+煤（空格够才下）
- 回农场收铁锭，够 5 锭就去铁匠铺升 hoe
- 不够就 Forest 钓鱼补食物/现金
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Green Algae", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Iron Bar", "River Jelly"]）
4. `craft`（item="Sprinkler", count=1）
5. `craft`（item="Sprinkler", count=1）
6. `place`（item="Sprinkler"）
7. `place`（item="Sprinkler"）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `goto_location`（location="Blacksmith"）
15. `upgrade_tool`（tool="hoe"）
16. `goto_location`（location="Forest"）
17. `fish`（casts=4）
18. `fish`（casts=4）
19. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Blackberry Jelly from Preserves Jar, Blackberry Jelly from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：1d31cae9940446ca89f0918575833415
  - 耗时：17.563 秒 / 游戏 20 分钟
  - 🗨️ [hud] Blackberry Jelly
- **06:20** Farm ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：d41d7aad75484a519c34bf89f4048dc4
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：f867c7b7b50c49f7b7ffafe3f9831229
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：f30d6d8506484d1b843e99e6b17dd05b
  - 耗时：0.329 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~180g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：6514c73bf00d4b57a8eb03a6378b7a2d
  - 耗时：20.766 秒 / 游戏 30 分钟
- **06:50** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：4d2afea78c0746d6b3831d7ecfd6d072
  - 耗时：41.703 秒 / 游戏 50 分钟
- **07:40** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：bc2a2eb0817247ad80ff3594c668f3ba
  - 耗时：39.36 秒 / 游戏 40 分钟
- **08:20** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 15 to 17 (2 floors down, 29 stones broken); backpack nearly full: store items before mining again; left the mine to recover
  - 执行状态：SUCCESS · 操作编号：ee2442c67fbc4b788d1429d804d09641
  - 耗时：46.14 秒 / 游戏 60 分钟
  - 🗨️ [hud] Geode
  - 🗨️ [hud] Bug Meat
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Fiber
  - 🗨️ [hud] Bug Meat
  - 🗨️ [question] 
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：0c2f33997e9d4f928aa892ef36fd8d11
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包仅剩1格导致下矿被拒，先回农场存材料腾格，再做洒水器、收炉、升锄头，最后钓鱼收尾睡觉。
1. `donate`
2. `goto_location`（location="Blacksmith"）
3. `upgrade_tool`（tool="hoe"）
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Iron Ore", "Bug Meat", "Geode", "Cobblestone Path", "Rice Shoot", "Coffee Bean", "Lost Axe", "Mystery Box"]）
9. `collect_machines`
10. `craft`（item="Sprinkler", count=1）
11. `craft`（item="Sprinkler", count=1）
12. `place`（item="Sprinkler"）
13. `place`（item="Sprinkler"）
14. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "River Jelly"]）
15. `sleep`
- **09:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：c8feee678eee4b29b9b44c882877f8ca
  - 耗时：41.781 秒 / 游戏 50 分钟
- **10:10** CommunityCenter ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：615ea925632d4741b203df04a6cbaa43
  - 耗时：35.797 秒 / 游戏 50 分钟
- **11:00** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：175abf0e3bce466aaab05d2e8b346d82
  - 耗时：0.328 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：铁锭不足升锄头，回农场存材料腾格、收炉装矿炼锭并做洒水器，剩余时间钓鱼后睡觉。
1. `donate`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Farm"）
6. `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Iron Ore", "Bug Meat", "Geode", "Mystery Box", "Cobblestone Path", "Rice Shoot", "Coffee Bean", "Lost Axe", "River Jelly"]）
7. `collect_machines`
8. `load_machines`（item="Iron Ore"）
9. `craft`（item="Sprinkler", count=1）
10. `craft`（item="Sprinkler", count=1）
11. `place`（item="Sprinkler"）
12. `place`（item="Sprinkler"）
13. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode"]）
14. `sleep`
- **11:00** Blacksmith ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：a617d796926e4d5392436b8465423452
  - 耗时：36.156 秒 / 游戏 40 分钟
- **11:40** CommunityCenter ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：402c3b2f87934943acd2cde8694c37d7
  - 耗时：38.782 秒 / 游戏 50 分钟
- **12:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Salmon, Chub, Chub, Salmon)
  - 执行状态：SUCCESS · 操作编号：e3b54c686f034c33be10d760ee8cb5d6
  - 耗时：120.016 秒 / 游戏 120 分钟
  - 🗨️ [hud] Salmon
- **14:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Salmon, Chub, Chub, Chub)
  - 执行状态：SUCCESS · 操作编号：b43bc2786cec46739e564210d5ea1f69
  - 耗时：106.5 秒 / 游戏 110 分钟
  - 🗨️ [hud] Salmon
- **16:20** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：25d40b3d51554884b4bfa245970623f9
  - 耗时：15.25 秒 / 游戏 10 分钟
- **16:30** Farm ✅ `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Iron Ore", "Bug Meat", "Geode", "Mystery Box", "Cobblestone Path", "Rice Shoot", "Coffee Bean", "Lost Axe", "River Jelly"]）
  - 结果：stored in chest at (74,15): 2x Coal, 2x Geode, 5x Bug Meat, 3x Fiber
  - 执行状态：SUCCESS · 操作编号：567ad47cbf604e4bb3d7de3e5aa131d7
  - 耗时：23.875 秒 / 游戏 40 分钟
- **17:10** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：72074ac0a20346af92804eb127d1e4a5
  - 耗时：0.297 秒 / 游戏 0 分钟
- **17:10** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：393550605c414ba2a164ee4be8073232
  - 耗时：0.313 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：079fcc886c8846839cfc4fb40252a829
  - 耗时：0.313 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
  - 执行状态：SUCCESS · 操作编号：c3846489cbbe4df0b7320cf1f8a91541
  - 耗时：0.297 秒 / 游戏 0 分钟
- **17:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 在规划的分区里没有空位了（不在分区外乱放）
  - 执行状态：ACTION_FAILED
- **17:10** Farm ❌ `place`（item="Sprinkler"）
  - 结果：Sprinkler 今天已确认分区无空位
  - 执行状态：ACTION_FAILED
- **17:10** Farm ✅ `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode"]）
  - 结果：shipped 1 stacks worth ~336g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：4c7d63b70b004c93886e66e526d50914
  - 耗时：0.688 秒 / 游戏 0 分钟
- **17:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：fe4819f57f214e5eb04fe31434f2362a
  - 耗时：10.797 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：46322 → 46838（+516g）
- 出货估值：516g　动作：26 个　失败：7 个
- 模型调用：4 次　tokens：50751
- 有效动作率：0.64　空转：5　熔断跳过：0
- 失败耗时：2.204 秒 / 游戏 0 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天清背包不彻底导致mine被拒，洒水器craft了但place失败（分区无空位），铁锭仍差3。有效做法：钓鱼4条、卖货516g、craft洒水器2个。核心问题：背包管理、洒水器放置规划、熔炉load/collect时机。

**新教训：**
- 昨天 craft 了 2 个洒水器但 place 返回「分区无空位」：place 前必须先确认目标分区有空位，否则 craft 的洒水器只能存箱子，浪费铁锭。
- 昨天 load_machines 在熔炉刚 load 完 30 分钟内返回 no empty machine：load 前必须确认炉内为空且背包有对应矿石，炉忙当天永久跳过 load，不要为确认再调一次。
- 昨天 collect_machines 在 17:10 返回空（load 后不足 2 小时）：collect 应放在下矿回来第一时间（load 后已过 ≥2 小时游戏时间），当天只调一次。
- 昨天 15:00 后仍调 place 两次失败：15:00 后只保留钓鱼或 sleep 两个合法动作，place/craft 等分支应从脚本中删除。
- 昨天清背包后仍有鱼在背包导致 mine 被拒：ship_produce 必须优先整组卖鱼（Salmon/Chub），鱼是最大占格来源，卖完立即读背包验证空格 ≥8。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 19）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 46322g 充足，卡点是 **Iron Bar 差 3**（Iron Ore 6、Coal 13，两座熔炉 2 轮可出 4 锭）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线。

离完成还差：约 6 铁矿石 + 3 煤 → 3 铁锭 → 铁匠铺升锄头（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 19）**：起床清背包到空格 ≥8（优先卖鱼）→ 熔炉 load 铁矿石（若炉空）→ 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）→ 回农场 collect 收铁锭 → 铁锭 ≥5 且时间 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 20）**：铁锭不够继续下矿；够了升 hoe，余锭给洒水器。
- **后天（秋 21）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包（今天最关键）**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**优先整组卖鱼**（昨天钓的 Salmon/Chub 等非献祭鱼）+ 非献祭杂项。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖 Green Algae/Sap/Refined Quartz/多余 Copper Bar 小堆，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **熔炉 load（若炉空且背包有 Iron Ore）**：`collect_machines` 1 次（收已完成的锭）；若返回空且背包有 Iron Ore → `load_machines` 1 次装铁矿石。load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
3. **下矿（主活动）**：空格 ≥8 且食物 ≥5 才 `goto_location` Mine → `mine` 目标 60-79 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
4. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
5. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。一次只升一件。
6. **洒水器放置（若背包有洒水器）**：`place` 到作物地块（≤6 次 place）。**place 前先确认目标分区有空位**；若返回「分区无空位」即当天永久跳过 place，不重试。
7. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
8. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
9. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
10. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（优先鱼），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天 ≤1 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤1 次；返回空后当天永久跳过。**collect 应在 load 后至少 2 小时游戏时间再调，或放在下矿回来第一时间。**
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **place 硬熔断**：`place` 返回「分区无空位」即当天永久跳过 place，不重试。place 前先确认目标分区有空位。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **build_road / decorate 禁用**：连续多天 100% 失败，从脚本中彻底删除。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=参加集市/下矿/钓鱼。**节日锁门后 goto 同一地点失败一次即永久跳过，不重试。**
- **每日动作上限**：`load_machines`≤1、`collect_machines`≤1、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组（优先鱼）+ 读背包验证空格 ≥8
2. 熔炉 load（若炉空且背包有 Iron Ore，≤1 次）
3. 下矿 60-79 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
4. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
5. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe
6. 洒水器放置（若背包有洒水器，≤6 次 place，分区无空位即跳过）
7. 补食物到 ≥5（Forest 河边钓鱼吃鱼）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天清背包不彻底导致mine被拒，洒水器craft了但place失败（分区无空位），铁锭仍差3。有效做法：钓鱼4条、卖货516g、craft洒水器2个。核心问题：背包管理、洒水器放置规划、熔炉load/collect时机。
- 06:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:00 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 2 (backpack + chests) 〔自动〕
- 17:10 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 17:10 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 17:10 动作 `place` 失败 @ Farm — Sprinkler 在规划的分区里没有空位了（不在分区外乱放） 〔自动〕
- 17:10 动作 `place` 失败 @ Farm — Sprinkler 今天已确认分区无空位 〔自动〕
- 清背包不彻底，mine 因空格不足被拒 @ Farm 出货箱旁 / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：当天零矿产出，铁锭仍差 3，钢锄头升级和洒水器材料都卡住） 〔复盘〕
- 洒水器 craft 了但 place 失败（分区无空位） @ Farm 作物地块 — place -> FAIL: Sprinkler 在规划的分区里没有空位了（不在分区外乱放）（做不了：洒水器无法放置，继续手动浇水浪费体力，洒水器 ×4 进度为零） 〔复盘〕
- 熔炉 load 后 30 分钟内调 collect 返回空，之后又调 load 返回 busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: no empty machine accepts anything（做不了：铁锭收集延后，当天只收到 2 铁锭，仍差 3） 〔复盘〕
- upgrade_tool 铁锭不足仍尝试升级 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 2（做不了：钢锄头升级失败，浪费前往铁匠铺的时间） 〔复盘〕
- donate 打开 Junimo note 无法存入，仍反复调用 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
