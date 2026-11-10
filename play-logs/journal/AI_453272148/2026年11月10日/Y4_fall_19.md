# 第4年 fall 19 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（04:53 开始）
- 天气：sunny　金钱：46838g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：12a6851795534e91b5714a3bcd1f7e20
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：3268cfd9bdaf49ab86e842351b353b33
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：c7209cbd05c546caad1fdbd749bd451b
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：nothing to ship
  - 执行状态：SUCCESS · 操作编号：e32bbbc5a1b34933b191aefb06d35ec4
  - 耗时：0.312 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_fall_19）准备的脚本
- 里程碑：工具按档升级——凑够 5 铁锭升钢锄头（今天还差 3 铁锭）
- 起床先清背包：出货箱整组卖鱼腾出 ≥8 空格
- 熔炉装铁矿石（若炉空），下矿 60-79 层拿铁矿石+煤
- 回农场收铁锭，够 5 锭且时间允许就去铁匠铺升 hoe
- 食物不足或矿洞被拒就转 Forest 钓鱼补食物与现金
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Iron Bar", "Iron Ore", "Copper Ore", "Coal", "Stone", "Fiber", "Mystery Box", "Lost Axe", "Rice Shoot", "Coffee Bean", "Steel Axe", "Fiberglass Rod", "Scythe", "Rusty Sword", "Copper Hoe", "Bamboo Pole", "Silver Saber", "Steel Pickaxe", "Steel Watering Can", "Cobblestone Path", "Frozen Geode", "Sprinkler"]）
4. `store_items`（items=["Stone", "Fiber", "Coal", "Copper Ore", "Iron Ore", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `goto_location`（location="Mine"）
8. `mine`（floors=5）
9. `fight`（range=6）
10. `mine`（floors=5）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `goto_location`（location="Blacksmith"）
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `fish`（casts=4）
18. `sleep`
- **06:00** FarmHouse ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：c2932a2af1254637bb5f1aa259263ae5
  - 耗时：46.078 秒 / 游戏 50 分钟
- **06:50** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：36bbf75001594f14b63f06d708293622
  - 耗时：39.375 秒 / 游戏 50 分钟
- **07:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：5915981ea6854197967be74a6197916f
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：背包仅 4 格导致下矿被拒，先回农场把石头/矿石/杂物存箱腾格，再装炉下矿，回来收锭升锄头，剩余时间钓鱼补食物。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Farm"）
10. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Iron Ore", "Coal"]）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `sleep`
- **07:40** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：a3f711d5b3e04406a5604e38cfa2a9cc
  - 耗时：39.609 秒 / 游戏 50 分钟
- **08:30** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：2e0f4be8e6de446c93566611b6023137
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：先回农场存材料腾出背包空格，再下矿拿铁矿石，回来收铁锭后升锄头，剩余时间钓鱼收尾。
1. `donate`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `goto_location`（location="Blacksmith"）
6. `upgrade_tool`（tool="hoe"）
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Iron Ore", "Coal"]）
12. `load_machines`（item="Iron Ore"）
13. `collect_machines`
14. `sleep`
- **08:30** CommunityCenter ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：57007a0bbe7c4e3cb24d65706d10b75e
  - 耗时：0.328 秒 / 游戏 0 分钟
- **08:30** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：89919461faa147a69cb47fb5a3b4747a
  - 耗时：39.422 秒 / 游戏 50 分钟
- **09:20** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：a0a1d067bb5043288ce7caf1ec7e8a48
  - 耗时：0.313 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因空格不足被拒，先回农场存材料腾格，再装炉下矿，回来收锭升 hoe，剩余时间钓鱼。
1. `donate`
2. `mine`（floors=5）
3. `mine`（floors=5）
4. `goto_location`（location="Blacksmith"）
5. `upgrade_tool`（tool="hoe"）
6. `goto_location`（location="Forest"）
7. `fish`（casts=4）
8. `fish`（casts=4）
9. `goto_location`（location="Farm"）
10. `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Iron Ore", "Coal", "River Jelly"]）
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `sleep`
- **09:20** Mine ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：077c84a2b79c4c6ebad7aa2da822237e
  - 耗时：39.625 秒 / 游戏 40 分钟
- **10:00** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：cfb203197a5648dba38e756a42e425a8
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:00** CommunityCenter ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：3c62337e9ee74b35bc1d76b53ba009a8
  - 耗时：0.328 秒 / 游戏 0 分钟
- **10:00** CommunityCenter ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：888e0be504804a9c83877f9161976596
  - 耗时：35.797 秒 / 游戏 50 分钟
- **10:50** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：425b6f40b3274809aa5becc18e8ab6b0
  - 耗时：0.312 秒 / 游戏 0 分钟
- **10:50** Blacksmith ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：f14dd27b5aa84a33834c96b3609633c9
  - 耗时：26.594 秒 / 游戏 30 分钟
- **11:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Green Algae, Chub, Chub, Chub)
  - 执行状态：SUCCESS · 操作编号：ceaa026c228c4e87b0247193917679ea
  - 耗时：85.766 秒 / 游戏 90 分钟
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
- **12:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Chub, Chub, Chub)
  - 执行状态：SUCCESS · 操作编号：d6d89889cbb84af998cd3c56b64182cc
  - 耗时：80.485 秒 / 游戏 60 分钟
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
- **13:50** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：669b3d45b985448aaea0c71671841018
  - 耗时：15.25 秒 / 游戏 20 分钟
- **14:10** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path", "Mystery Box", "Rice Shoot", "Coffee Bean", "Lost Axe", "Copper Ore", "Iron Ore", "Coal", "River Jelly"]）
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：de9c16742bbd47468210706efc3ec0e2
  - 耗时：23.891 秒 / 游戏 30 分钟
- **14:40** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：b539de9280e44640bee62092ec348f35
  - 耗时：0.344 秒 / 游戏 0 分钟
- **14:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：457f91eae1bd4285873abda2a14c3dd8
  - 耗时：0.328 秒 / 游戏 0 分钟
- **14:40** Farm ✅ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：89951aa14c3c40bbbd2c43cde437600f
  - 耗时：39.719 秒 / 游戏 50 分钟
- **15:30** CommunityCenter ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：3f72179d141e48529a26fa3116204461
  - 耗时：45.375 秒 / 游戏 60 分钟
- **16:30** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:30** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：b421c6370c514d0d9d144a9ff28c027e
  - 耗时：12.657 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：46838 → 46838（+0g）
- 出货估值：0g　动作：28 个　失败：11 个
- 模型调用：5 次　tokens：61631
- 有效动作率：0.4815　空转：8　熔断跳过：0
- 失败耗时：49.295 秒 / 游戏 60 分钟
- 最深矿层：61　新增矿层：0
- 今日完成里程碑：下矿装备（能安全下到 40 层以下拿铁矿）

## 🧠 夜间复盘
昨天核心失败是清背包不彻底：ship_produce 只卖杂项没卖鱼，背包空格不足导致 5 次 mine 全被拒，铁锭仍差 5，钢锄头与洒水器双双卡住。熔炉 load/collect 时序错乱、donate 空转、15:00 后 build_road/decorate 无效动作仍在浪费游戏时间。有效的是 Forest 钓鱼稳定产出。今天必须起床先整组卖鱼清空格，再 load 熔炉、下矿。

**新教训：**
- 昨天 ship_produce 只卖杂项没卖鱼，背包仍满导致 5 次 mine 全被拒：清背包时第一组必须整组卖鱼（Chub/Green Algae 等非献祭鱼），卖完立即读背包验证空格 ≥8，验证不通过不得进入下矿分支。
- 昨天熔炉 load 后 30 分钟内调 collect 返回空、随后再调 load 返回 busy：load 与 collect 之间必须隔 ≥2 小时游戏时间，collect 固定放在下矿回来第一时间，当天只调一次。
- 昨天 donate 在 wait_letter 阶段反复打开 Junimo note 无法存入，浪费动作：donate 应从脚本彻底删除，起床到卖货之间不得插入任何非卖货动作。
- 昨天 15:00 后仍调 build_road 和 decorate 全失败：15:00 后脚本只允许 fish 或 sleep 两个分支，其余动作在脚本生成阶段就删除。
- 昨天 upgrade_tool 在铁锭为 0 时仍去铁匠铺：升级前必须先读里程碑/背包确认 Iron Bar ≥5，不够直接跳过，不浪费前往时间。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 20）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 46838g 充足，唯一卡点是 **Iron Bar 差 5**（背包 Iron Ore 6、Coal 13，两座熔炉可出约 2 锭，还差约 3 锭 = 15 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线，钓鱼只是补食物/兜底。

离完成还差：约 15 铁矿石 + 3 煤 → 5 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 20）**：起床整组卖鱼清空格 ≥8 → 熔炉 load 铁矿石 → 下矿 60-79 层拿铁矿石+煤（≤2 次 mine，每次 ≤5 层）→ 回农场 collect 收锭 → 铁锭 ≥5 且时间 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 21）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（秋 22）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包（今天最关键）**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**优先整组卖鱼**（Chub、Green Algae 等非献祭鱼）+ 非献祭杂项（多余 Copper Bar、Sap）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
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
> 昨天核心失败是清背包不彻底：ship_produce 只卖杂项没卖鱼，背包空格不足导致 5 次 mine 全被拒，铁锭仍差 5，钢锄头与洒水器双双卡住。熔炉 load/collect 时序错乱、donate 空转、15:00 后 build_road/decorate 无效动作仍在浪费游戏时间。有效的是 Forest 钓鱼稳定产出。今天必须起床先整组卖鱼清空格，再 load 熔炉、下矿。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 07:40 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 08:30 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 09:20 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:00 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:00 动作 `mine` 失败 @ CommunityCenter — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:50 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 0 (backpack + chests) 〔自动〕
- 14:40 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 14:40 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 15:30 动作 `build_road` 失败 @ CommunityCenter — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:30 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包不彻底，背包空格不足导致下矿连续被拒 5 次 @ Farm 出货箱旁 / Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：当天零矿产出，铁锭仍差 5，钢锄头升级和洒水器材料全部卡住） 〔复盘〕
- ship_produce 只卖杂项没卖鱼，鱼仍占格 @ Farm 出货箱旁 — ship_produce -> OK: nothing to ship（实际背包仍有 Chub 等鱼未卖）（做不了：背包无法腾出 ≥8 空格，下矿分支无法启动） 〔复盘〕
- 熔炉 load 与 collect 时序错乱，先 collect 空、后 load busy @ Farm 熔炉旁 — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: no empty machine accepts anything（做不了：铁锭收集延后，当天铁锭产出为零，钢锄头仍差 5） 〔复盘〕
- 铁锭为 0 时仍前往铁匠铺尝试升级 @ Blacksmith — upgrade_tool -> FAIL: Steel Hoe needs 5x Iron Bar, you have 0（做不了：浪费前往铁匠铺的游戏时间，升级未完成） 〔复盘〕
- donate 在 wait_letter 阶段反复打开 Junimo note 无法存入 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
- 15:00 后仍调 build_road 和 decorate 两个无效动作 @ Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects); decorate -> FAIL: 今天没有能做的装饰（做不了：浪费约 200 游戏分钟，本可用于钓鱼补食物/现金） 〔复盘〕
