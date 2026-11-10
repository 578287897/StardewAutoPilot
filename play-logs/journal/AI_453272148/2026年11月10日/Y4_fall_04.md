# 第4年 fall 4 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（02:00 开始）
- 天气：rain　金钱：29025g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Common Mushroom -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：49aa8bd8700f4f779efbb65c4fa26e96
  - 耗时：17.813 秒 / 游戏 20 分钟

## 🌙 为明天（Y4_fall_04）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g+5 铁锭），今天下矿拿铁矿石和煤
- 起床 collect_machines 1 次（熔炉有货就收）
- 清背包：先 ship_produce 卖 Stone 整组，再单物品 store Stone，验证空格 ≥8
- 食物 ≥5 已满足（16 个可回血），直接下矿 40-59 层拿铁矿石+煤（≤2 次 mine）
- 回农场 collect 再 load 熔炉（炉空且背包有 Iron Ore 才装，只试 1 次）
- 剩余洒水器落地（分区满则先清地）
- 水壶在背包则 water_crops 1 次（明天下雨可跳过）
- 22:00 前 sleep
1. `donate`
2. `collect_machines`
3. `goto_location`（location="Farm"）
4. `ship_produce`（except=["Green Algae", "Common Mushroom", "Blackberry", "River Jelly", "Coffee Bean", "Cherry Bomb", "Mystery Box"]）
5. `store_items`（items=["Stone"]）
6. `goto_location`（location="Mine"）
7. `mine`（floors=5）
8. `mine`（floors=5）
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `load_machines`
12. `water_crops`
13. `sleep`
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal, 1x Trash
  - 执行状态：SUCCESS · 操作编号：0ebab24ec0e446da88a91a7f1dc0206f
  - 耗时：18.11 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：9788302a8e974500ba4a3dd444948b99
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：94762d41e4a545dfaf80e2e0a551e2ff
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~30g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：01cfff4ce13e4cdfbab1838deba92056
  - 耗时：0.64 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：cd21baf297364fc087235c9e5d1f3fc7
  - 耗时：0.281 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 在 wait_letter 阶段必失败，已从脚本移除；其余按原路线：收炉→卖石头清背包→下矿拿铁→回农场收/装炉→浇水→睡。
1. `collect_machines`
2. `goto_location`（location="Mine"）
3. `mine`（floors=5）
4. `mine`（floors=5）
5. `goto_location`（location="Farm"）
6. `ship_produce`（except=["Green Algae", "Common Mushroom", "Blackberry", "River Jelly", "Coffee Bean", "Cherry Bomb", "Mystery Box"]）
7. `store_items`（items=["Stone"]）
8. `collect_machines`
9. `load_machines`
10. `water_crops`
11. `sleep`
- **06:40** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：030ee87bd2ba459186243388797b6a85
  - 耗时：0.296 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：dfd849a8404649d6b3d3456023562c83
  - 耗时：48.969 秒 / 游戏 60 分钟
- **07:40** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：f4f9e1a6358d4274ade58bc4c3dacf2d
  - 耗时：0.36 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因空格不足被拒一次，按策略当天不再调 mine，先卖石头清背包再转 Forest 钓鱼，回农场收炉后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Farm"）
5. `ship_produce`（except=["Green Algae", "Common Mushroom", "Blackberry", "River Jelly", "Coffee Bean", "Cherry Bomb", "Mystery Box", "Iron Ore", "Copper Ore"]）
6. `store_items`（items=["Stone"]）
7. `collect_machines`
8. `load_machines`
9. `water_crops`
10. `sleep`

### 🔁 脚本重写：重写#1：背包0空格，先卖石头腾格并钓鱼补食物，再下矿拿铁矿石推进钢锄头，回农场收炉装炉后睡觉。
1. `collect_machines`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Mine"）
6. `mine`（floors=3）
7. `mine`（floors=3）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `ship_produce`（except=["Green Algae", "Common Mushroom", "River Jelly", "Blackberry", "Iron Ore", "Copper Ore", "Coal"]）
11. `store_items`（items=["Stone"]）
12. `collect_machines`
13. `load_machines`
14. `water_crops`
15. `sleep`

## 🌅 早上的计划（02:03 开始）
- 天气：rain　金钱：29025g　体力：270/270
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），今天下矿拿铁矿石和煤
- 起床收熔炉产物
- 清背包：先卖石头腾格子，验证≥8空格
- 补食物到≥5（Forest钓鱼）
- 下矿40-59层拿铁矿石+煤
- 回农场收炉再装炉
- 浇水
- 睡觉

**执行脚本：**
1. `load_machines`
2. `collect_machines`
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `goto_location`（location="Mine"）
7. `mine`（floors=3）
8. `mine`（floors=3）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `ship_produce`（except=["Green Algae", "Common Mushroom", "River Jelly", "Blackberry", "Iron Ore", "Copper Ore", "Coal"]）
12. `store_items`（items=["Stone"]）
13. `collect_machines`
14. `load_machines`
15. `water_crops`
16. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Common Mushroom -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：8ae65cf0fa024532b00f3df91b18a71d
  - 耗时：17.047 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：352db37adfcb4a5ebb183216251be21c
  - 耗时：0.312 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：91fb77a7a72a4bc8ad120e6c76901ce1
  - 耗时：19.547 秒 / 游戏 20 分钟

### 🔁 脚本重写：重写#1：起床收炉→卖石头清背包→Forest 钓鱼补食物→下矿拿铁矿石和煤推进钢锄头→回农场收炉装炉→睡觉。
1. `collect_machines`
2. `goto_location`（location="Forest"）
3. `fish`（casts=4）
4. `fish`（casts=4）
5. `goto_location`（location="Mine"）
6. `mine`（floors=3）
7. `mine`（floors=3）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore", "Mystery Box", "Lost Axe", "Cherry Bomb", "Coffee Bean", "Rice Shoot"]）
11. `store_items`（items=["Stone"]）
12. `collect_machines`
13. `load_machines`
14. `water_crops`
15. `sleep`

## 🌅 早上的计划（02:05 开始）
- 天气：rain　金钱：29025g　体力：270/270
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），今天下矿拿铁矿石+煤
- 起床 collect_machines 收熔炉
- 清背包：先 ship_produce 卖 Stone 腾空格到 ≥8
- 补食物到 ≥5（Forest 钓鱼）
- 下矿 40-59 层拿铁矿石+煤
- 回农场 collect 再 load 熔炉
- 浇水（下雨可跳过）
- 睡觉

**执行脚本：**
1. `load_machines`
2. `collect_machines`
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `goto_location`（location="Mine"）
7. `mine`（floors=3）
8. `mine`（floors=3）
9. `leave_mine`
10. `goto_location`（location="Farm"）
11. `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore", "Mystery Box", "Lost Axe", "Cherry Bomb", "Coffee Bean", "Rice Shoot"]）
12. `store_items`（items=["Stone"]）
13. `collect_machines`
14. `load_machines`
15. `water_crops`
16. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Common Mushroom -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：71cb933f0e0043fa93a30c81c9b4dfcd
  - 耗时：16.984 秒 / 游戏 20 分钟
- **06:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：c471ab3649ef435e9c561c0111cacca9
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:20** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：3782f3a1b9c249b1b6685c4a7c92be2a
  - 耗时：19.563 秒 / 游戏 20 分钟
- **06:40** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Smallmouth Bass, Smallmouth Bass, Smallmouth Bass, Green Algae)
  - 执行状态：SUCCESS · 操作编号：3f344f99183b4bdfa16a5549cff18e5e
  - 耗时：87.734 秒 / 游戏 90 分钟
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass
  - 🗨️ [hud] Smallmouth Bass

### 🔁 脚本重写：重写#1：先收炉、卖石头腾格、下矿拿铁矿石和煤推进钢锄头，回农场收炉装料后浇水睡觉。
1. `goto_location`（location="CommunityCenter"）
2. `donate`
3. `goto_location`（location="Mine"）
4. `mine`（floors=3）
5. `mine`（floors=3）
6. `leave_mine`
7. `goto_location`（location="Farm"）
8. `collect_machines`
9. `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore"]）
10. `store_items`（items=["Stone"]）
11. `collect_machines`
12. `load_machines`
13. `water_crops`
14. `sleep`

## 🌅 早上的计划（02:09 开始）
- 天气：rain　金钱：29025g　体力：214/270
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），今天下矿拿铁矿石和煤
- 起床收熔炉产物
- 清背包腾空格（卖石头）
- 补食物到≥5
- 下矿40-59层拿铁矿石+煤
- 回农场收炉再装料
- 浇水
- 睡觉

**执行脚本：**
1. `load_machines`
2. `goto_location`（location="CommunityCenter"）
3. `donate`
4. `goto_location`（location="Mine"）
5. `mine`（floors=3）
6. `mine`（floors=3）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore"]）
11. `store_items`（items=["Stone"]）
12. `collect_machines`
13. `load_machines`
14. `water_crops`
15. `sleep`
- **09:10** Forest ❌ `load_machines`
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：69189a377b804414a5786223e6779fbd
  - 耗时：0.281 秒 / 游戏 0 分钟
- **09:10** Forest ✅ `goto_location`（location="CommunityCenter"）
  - 结果：arrived at CommunityCenter (32,23)
  - 执行状态：SUCCESS · 操作编号：478e2fb3432b4027809fc4be36345f12
  - 耗时：46.625 秒 / 游戏 60 分钟
- **10:10** CommunityCenter ✅ `donate`
  - 结果：opened the Junimo note; wizardJunimoNote is now pending. Read it, then go to WizardHouse. Donating stays locked until canReadJunimoText.
  - 执行状态：SUCCESS · 操作编号：55dd1df9cec146f5b5a4e32ad6da4c91
  - 耗时：9.266 秒 / 游戏 10 分钟
- **10:20** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：b864bd637a9749c1b39e3e97b65b6b5a
  - 耗时：39.375 秒 / 游戏 50 分钟
- **11:10** Mine ❌ `mine`（floors=3）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：36a0e300f42747e586248225cff77a05
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包满被拒一次，按策略当天不再下矿，回农场收炉卖石头后转 Forest 钓鱼补食物与现金，浇水后睡觉。
1. `goto_location`（location="Forest"）
2. `fish`（casts=4）
3. `fish`（casts=4）
4. `goto_location`（location="Farm"）
5. `collect_machines`
6. `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore"]）
7. `store_items`（items=["Stone"]）
8. `collect_machines`
9. `water_crops`
10. `sleep`
- **11:10** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：2bef4a8768474a77b487b3da6be61176
  - 耗时：57.046 秒 / 游戏 70 分钟
- **12:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Walleye, Tiger Trout, Walleye, Salmon)
  - 执行状态：SUCCESS · 操作编号：d45a5f8121ba4d5dad7dce8e7e6e6dc4
  - 耗时：82.797 秒 / 游戏 70 分钟
- **13:30** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Chub, Chub, Shad, Chub)
  - 执行状态：SUCCESS · 操作编号：88d78e0fb3424c2893ec36eca84f083c
  - 耗时：105.219 秒 / 游戏 100 分钟
- **15:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：a2891dbb32a14223920cbda7a57aa325
  - 耗时：15.094 秒 / 游戏 20 分钟
- **15:30** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：75494642972246669f2871ba4fd93e2f
  - 耗时：0.281 秒 / 游戏 0 分钟
- **15:30** Farm ✅ `ship_produce`（except=["Iron Ore", "Coal", "Copper Ore"]）
  - 结果：shipped 2 stacks worth ~405g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：7fd9bc9134d449888c4beb2e5a71464e
  - 耗时：20.437 秒 / 游戏 30 分钟
- **16:00** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：1776f46caa1a498bbd9ba00476cc04ed
  - 耗时：4.703 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **16:00** Farm ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
  - 执行状态：SUCCESS · 操作编号：21fe99b11572499e90e4f16bb1cf44ed
  - 耗时：0.313 秒 / 游戏 0 分钟
- **16:00** Farm ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：35d2ae7837a2454cb2e0b64924c5190f
  - 耗时：8.922 秒 / 游戏 10 分钟
- **16:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **16:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:10 pm
  - 执行状态：SUCCESS · 操作编号：99357204d8e044a6942c1a4eff008dfc
  - 耗时：80.937 秒 / 游戏 120 分钟
- **18:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：f3314076ac9b4407bd4439bebdb05b3d
  - 耗时：12.656 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：29025 → 29430（+405g）
- 出货估值：405g　动作：18 个　失败：6 个
- 模型调用：2 次　tokens：23374
- 有效动作率：0.6667　空转：4　熔断跳过：1
- 失败耗时：9.828 秒 / 游戏 10 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天核心失败仍是清背包：ship_produce 卖 Stone 也未真正腾格，导致 mine 被拒、全天零铁矿。下午又空转在 collect/load/build_road/decorate/wait 上，18 动作仅 5 有效。有效的是 Forest 钓鱼 8 条鱼。今天必须换清背包手段（卖铜锭/精炼石英等小堆、或直接卖 Copper Bar 74 个），并在下矿前读背包验证空格，否则直接定性钓鱼日。

**新教训：**
- ship_produce 卖 Stone 整组昨天返回 OK 但 2407 块仍在背包，说明出货动作对超大堆也可能假成功：应改为先卖 Copper Bar 整组（74 个，非献祭必需，卖一半即腾格），卖完读背包确认数量下降再进下一步。
- 昨天 18 个动作里 6 个失败、有效仅 5 个，其中 4 个是 collect/load 在炉忙或空炉时反复调用：collect 返回空后当天再调必触发「repeated ineffective action suppressed」，应 collect 上限 2 次、收完即停。
- 昨天下午 16:00-18:10 全在 build_road/decorate/wait 上，零产出：主活动（mine）失败后应在 1 个动作内 goto Forest 钓鱼，而不是进入补充工作分支。
- Forest 河边 4 cast 昨天稳定出 4 条鱼（Walleye/Tiger Trout/Salmon），是食物和现金的可靠来源：mine 被拒后应立即转 Forest，把当天定性为钓鱼日，铁锭进度留到明天。
- 昨天 mine 被拒后重写脚本 2 次仍调 mine，说明重写逻辑没读背包空格：重写前必须先读背包空格数，<8 时脚本里不得出现 mine 动作。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 5）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 29025g 已够，卡点仍是 **Iron Bar 差 5**（Iron Ore 2、Coal 10）。铁锭同时是洒水器 ×4 的材料，「下矿拿铁」是主线。

离完成还差：10 铁矿石 + 5 煤 → 两座熔炉约 2 轮 → 5 铁锭 → 铁匠铺升锄头。

接下来 3 天主活动：
- **今天（秋 5）**：起床 collect 1 次；**清背包改用卖 Copper Bar 整组（74 个，非献祭必需，卖一半即腾 1-2 格）+ 卖 Refined Quartz/Sap**，卖完读背包验证 ≥8 空格；食物 <5 去 Forest 钓鱼补；两项达标才下矿 40-59 层拿铁矿石+煤；回农场先 collect 再 load。若清背包两次仍不足 → 当天定性钓鱼日，不再调 mine。
- **明天（秋 6）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（秋 7）**：钢锄头到手转钢斧；铁锭余量给洒水器。秋季只种能在季末前成熟的作物（南瓜、蔓越莓）。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**：返回空则当天永久跳过 collect。
2. **清背包（唯一重点，换手段）**：
   - 先 `goto_location` Farm 到出货箱旁。
   - **第一步：`ship_produce` 卖 Copper Bar 整组**（74 个铜锭非献祭必需，卖 30-40 个即腾格换现金）。
   - **第二步：读背包验证**：Copper Bar 数量下降且空格 ≥8 → 直接进第 3 步。
   - **第三步：若 Copper Bar 未动**，`ship_produce` 卖 Refined Quartz + Sap 小堆；再读背包验证。
   - **第四步：仍不足 8 空格**，`ship_produce` 卖 Stone 整组（昨天假成功，今天只作最后手段）；两次手段后仍不足 → **放弃下矿，直接转 Forest 钓鱼**，当天定性为钓鱼日。
   - 清完立刻 goto Mine，不先绕路。
3. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物 ≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格 ≥8、食物 ≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过 load。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包换手段（今天核心修正）**：ship_produce 对 Stone 大堆昨天假成功（返回 OK 但 2407 块仍在）。今天改为**先卖 Copper Bar 整组**（74 个，非献祭必需，卖一半即腾格），再卖 Refined Quartz/Sap 小堆，Stone 只作最后手段。每次卖完必须读背包验证数量下降。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物=4 时下矿停在 39 层，铁矿石零产出。食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**（连续两天重写全撞同一堵墙）。
- **load 硬熔断**：`load_machines` 每天 ≤2 次；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天 ≤2 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。18 层已确认 infested，从 19 层以下开始。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
- **Saloon 禁用**：补食物一律钓鱼吃鱼。
- **FishShop 买饵暂缓**：入口坐标未确认，连续失败，今天不买饵，直接裸钓。
- **禁止 wait**：脚本层永久禁用 wait(filler)；主活动做完直接 sleep 或转钓鱼。
- **禁止不存在的动作**：`chop_tree` 不存在，砍树用 `use_tool` tool=axe 带 x,y。
- **build_road / decorate 禁用**：连续多天铺路/装饰浪费 20+ 动作，全部失败；农场未整理前完全禁用。
- **donate 禁用**：wait_letter 阶段必失败，等巫师来信后再去。
- **节日锁门**：日期=节日时脚本层直接禁用所有 goto Town/Blacksmith/Saloon/AdventureShop/Beach；节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤4、`place`≤6、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅 9:10-15:30）、`interact` 同一 NPC≤3、`give_gift`≤1、`use_tool` axe≤10、`mine`≤2、`fight`≤3、`fish`≤4。
- **商店时间**：冒险家公会 14:00-22:00；皮埃尔 9-17（周三休）；Saloon 12:00-24:00；Blacksmith 9:00-16:00；FishShop 9:00-17:00，16:30 后不去。营业时间前不调用 goto/open_shop/buy。16:00 后不再去 Blacksmith。
- **路径固定**：去 Blacksmith/Mountain/FishShop 一律走 Farm→Town→Mountain；Backwoods 不作为中转。
- **下矿入口固定**：`mine` 前必须先 `goto_location` 到 Mine 入口。
- **下矿安全**：生命 <50% 或食物=0 立即 leave_mine；食物 ≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 真清背包到 ≥8 空格并验证（**先卖 Copper Bar 整组，再卖 Refined Quartz/Sap，Stone 最后**，两次不足则放弃下矿）
3. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
4. 下矿 40-59 层拿铁矿石+煤（食物 ≥5、空格 ≥8 才下，≤2 次 mine，超时即停，跳过 18 层）
5. 回农场先 collect 再 load（炉空且背包有 Iron Ore 才装，只试 1 次）
6. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
7. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天核心失败仍是清背包：ship_produce 卖 Stone 也未真正腾格，导致 mine 被拒、全天零铁矿。下午又空转在 collect/load/build_road/decorate/wait 上，18 动作仅 5 有效。有效的是 Forest 钓鱼 8 条鱼。今天必须换清背包手段（卖铜锭/精炼石英等小堆、或直接卖 Copper Bar 74 个），并在下矿前读背包验证空格，否则直接定性钓鱼日。
- 09:10 动作 `load_machines` 失败 @ Forest — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 15:30 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包连续多天假成功，Stone 2407 块始终占格，背包空格不足 8 @ Farm 出货箱旁 — store_items -> OK: nothing to store；ship_produce 卖 Stone -> OK 但背包 Stone 仍在；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 2 次，每次重写又调 mine 再失败 @ Mine 入口 / Farm — mine -> FAIL: need at least 5 free backpack slots before mining（重复 3 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 主活动失败后下午空转在 collect/load/build_road/decorate/wait 上 @ Farm / Forest — collect_machines -> no machine has finished output；load_machines -> no empty machine；build_road -> laid 0 tiles (24 skipped)；decorate -> 今天没有能做的装饰；wait -> 浪费 2 小时（做不了：没有把下午时段用于钓鱼补食物/现金，铁锭进度原地踏步） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试并被抑制 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts that, and the rest are busy（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- donate 在 wait_letter 阶段再次尝试并失败 @ Community Center — donate -> OK 打开 Junimo note，但 wizardJunimoNote is now pending，Donating stays locked until canReadJunimoText（做不了：无，但浪费 2 个动作） 〔复盘〕
