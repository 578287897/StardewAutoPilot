# 第2年 spring 7 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（20:42 开始）
- 天气：rain　金钱：1684g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:00** FarmHouse ✅ `water_crops`
  - 结果：it's raining here, crops are watered automatically
- **06:00** FarmHouse ✅ `ship_produce`
  - 结果：nothing to ship

## 🌙 为明天（Y2_spring_07）准备的脚本
- 里程碑：工具按档升级——先炼出铁锭（熔炉只装铁矿），再攒钱冲钢斧头
- 早上先 collect 熔炉确认空炉，再显式装 Iron Ore 炼铁
- 下雨天不用浇水，水壶在升级中跳过浇水
- 洒水器已 craft 4 个但分区无空位，先不重试 place
- 主活动：Mountain 湖边钓鱼 4 轮攒钱（目标现金≥2000g）
- 傍晚回农场白名单出货，留锭/矿/种子/洒水器
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `goto_location`（location="Mountain"）
5. `fish`（casts=6）
6. `fish`（casts=6）
7. `fish`（casts=6）
8. `fish`（casts=6）
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone", "Sprinkler", "Garlic Seeds", "Potato Seeds", "Kale Seeds", "Rice Shoot", "Mixed Seeds", "Bait", "Fiberglass Rod"]）
12. `sleep`
- **06:00** FarmHouse ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 在 wait_letter 阶段必失败，跳过献祭分支，保留原路线：先炼铁再全天钓鱼攒钱，傍晚回农场出货睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `goto_location`（location="Mountain"）
4. `fish`（casts=6）
5. `fish`（casts=6）
6. `fish`（casts=6）
7. `fish`（casts=6）
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone", "Sprinkler", "Garlic Seeds", "Potato Seeds", "Kale Seeds", "Rice Shoot", "Mixed Seeds", "Bait", "Fiberglass Rod"]）
11. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：no machine has finished output
- **06:00** FarmHouse ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **06:00** FarmHouse ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
- **06:30** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Carp, Largemouth Bass, Bullhead, Chub, Carp, Green Algae)
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Bullhead
  - 🗨️ [hud] Carp
- **09:00** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 7 (Chub, Largemouth Bass, treasure: Rice Shoot, Trash, Carp, Chub, Largemouth Bass)
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Carp
- **11:00** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Carp, Broken Glasses, Bullhead, Chub, Chub, Bullhead)
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Broken Glasses
  - 🗨️ [hud] Bullhead
- **13:20** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (River Jelly, Carp, Green Algae, Largemouth Bass, Carp, Carp)
  - 🗨️ [hud] River Jelly
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Carp
- **15:20** Mountain ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **15:50** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **15:50** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone", "Sprinkler", "Garlic Seeds", "Potato Seeds", "Kale Seeds", "Rice Shoot", "Mixed Seeds", "Bait", "Fiberglass Rod"]）
  - 结果：shipped 3 stacks worth ~1038g (paid overnight)
- **16:00** Farm ✅ `craft`（item="Cobblestone Path", count=24）
  - 💭 (做 24 块 Cobblestone Path 用来铺路)
  - 结果：crafted 24x Cobblestone Path
- **16:00** Farm ❌ `build_road`
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
- **16:10** Farm ❌ `decorate`
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
- **16:10** Farm ✅ `wait`（minutes=50, filler=true）
  - 结果：waited until 5:00 pm
- **17:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：1684 → 2722（+1038g）
- 出货估值：1038g　动作：20 个　失败：5 个
- 模型调用：3 次　tokens：33712

## 🧠 夜间复盘
昨日钓鱼4轮约25条、出货1038g是有效收入；但熔炉装料连续失败（未先collect/铜矿占炉）、洒水器craft后无空位、FishShop未确认营业就open_shop、donate提前调用、build_road/decorate/wait空转，都是可避免的浪费。核心卡点：铁锭停在2、洒水器放不下、现金仅1684g。今日应先解决熔炉与洒水器分区，再钓鱼攒钱。

**新教训：**
- build_road 在农场被树木/作物/物体阻挡时返回 'laid 0 tiles (24 skipped)'：铺路前必须先清出连续空地，否则整批材料白做；当前阶段直接禁用 build_road。
- decorate 在缺树种子/木头/花种或没有畜舍时必失败：装饰不是里程碑动作，前期不应排进每日流程，脚本层直接禁用。
- wait(filler) 只是把时间推到17:00，不产生任何金钱或材料：脚本做完主活动后应直接 sleep 或转钓鱼，禁止用 wait 填充时间。
- 洒水器已 craft 4 个但分区无空位时，继续 craft 只会积压：craft 前必须确认分区有空位，否则先 chop_tree/清杂物腾位，今天不再 craft。
- 现金1684g 时买饵20个只花100g，但买种子会拖慢钢斧头：现金<2200g 前不买种子，主活动锁定钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春8）

## 长期目标
当前里程碑：**工具按档升级**——下一档钢斧头（5000g+5铁锭），现铁锭0/5（背包只有Iron Ore 2、Copper Bar 57），现金1684g，还差约3316g+5铁锭。并行推进 **洒水器×4**（已craft 4个但分区无空位，放下即停止手动浇水）与 **钓鱼攒钱**（钓鱼7级，是当前最稳收入）。
- 钢斧头：铁锭≥5且现金≥5000g才去Blacksmith；今天先让熔炉真正炼出铁，再钓鱼攒钱。
- 洒水器×4：已craft，今天唯一任务是**清出分区空位并place**，不再craft。
- 玻璃纤维竿已买，鱼饵用完去威利店买Bait（5g/个，现金≥150g时买20个）。

接下来3天主活动：
- **今天（春8）**：① collect熔炉确认空→显式装Iron Ore（≤2次，失败熔断）→ ② 水壶仍在升级，跳过浇水 → ③ 清出洒水器分区空位（chop_tree/清杂物或换锚点）后place已craft的4个 → ④ 全天Mountain湖边钓鱼4轮 → ⑤ 傍晚白名单出货（留铁锭/铜锭/煤/铁矿/种子/洒水器，其余鱼、垃圾、多余Copper Bar全出）。
- **明天（春9）**：取水壶；铁锭够就确认洒水器全部落地；现金≥2000g去Blacksmith升斧头。
- **后天（春10）**：下矿40-44层补铁矿/煤；现金够买春季种子补种。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. `collect_machines`（≤2次）→ 确认熔炉空且背包有Iron Ore时`load_machines`显式item=Iron Ore装1次；返回"no empty machine"或"all machines are busy"立即熔断，当天不再调用。**熔炉只装铁矿，铜矿全部存箱子**。
2. **浇水**：水壶在背包则`water_crops`1次；返回"no watering can"说明水壶仍在升级，跳过。
3. **洒水器落地**：先检查规划分区是否有空位；无空位先`chop_tree`/清杂物或换锚点，再`place`已craft的洒水器（≤2次）。**place失败即换锚点，不在同一位置重试**。
4. **清背包**：空格<5时先`ship_produce`白名单清出≥5格，再进商店或钓鱼。
5. **买鱼饵（仅当现金≥150g且时间<16:30）**：`goto_location` FishShop → 确认返回arrived且时间≥9:00 → `open_shop`确认OK → `buy` Bait 20个 → `close_menu`。现金<150g跳过。**FishShop 9:00-17:00，16:30后不去**。
6. **主活动=钓鱼攒钱**：`goto_location` Mountain湖边 → `fish casts=6`，最多4轮（≤4次fish调用）。**fish必须放流程最后单独执行**；fish返回后先确认状态再发下一个动作。
7. **买种子（仅当现金≥2200g且空格≥5）**：只买已解锁春季作物（土豆/花椰菜/大蒜/Kale），单次buy≤2次，现金留≥1800g。现金<2200g当天不买种子。
8. 回农场`plant_seeds`（≤2次，**失败换锚点或先清杂物，不在同一锚点重试**）。
9. 体力<15或时间≥22:00 `sleep`；**22:00强制sleep**。

## 规则
- **钓鱼并发熔断**：任何动作返回"busy with 'fish'"时，脚本层立即停止发新动作，等fish返回；`close_menu`不能中断钓鱼，禁止用它。**禁止在fish未结束时连发collect/load/ship/goto**。
- **熔炉优先**：每天第一步先`collect_machines`确认熔炉空，再显式装Iron Ore。load_machines每天≤2次，返回"no empty machine"或"all machines are busy"即熔断。**熔炉只炼铁，铜矿全部存箱子**。
- **现金目标**：每天结束现金≥当天开始+100g，否则第二天主活动强制改为钓鱼。
- **空转硬熔断**：任何动作返回"no empty machine accepts anything"、"all machines are busy"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"none of the ... is reachable"、"inventory full"、"no free soil near the anchor"、"Sprinkler 在规划的分区里没有空位"等，脚本层立即永久跳过该分支，当天不再调用，转去钓鱼或砍树。**禁止wait**。
- **18层永久拉黑**；**45层以上不追**：mine目标锁定40-44层，到45层无产出立即leave_mine；体力<30不调mine。
- **工具升级**：一次只升一件；升级期间（2天）不调mine（无镐）也不调water_crops（无水壶）。**升级中不重复交付**；升级前显式检查现金≥费用且锭够，不足直接跳过。
- **clear_debris / build_road / decorate 禁用**。
- **节日锁门**：日期=节日时脚本层直接禁用所有goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不wait。节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅9:10-15:30）、`interact`同一NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会14:00-22:00；皮埃尔9-17（周三休）；Saloon12:00-24:00；Blacksmith9:00-16:00；**FishShop 9:00-17:00，16:30后不去**。营业时间前不调用goto/open_shop/buy。**16:00后不再去Blacksmith**。
- **路径固定**：去Blacksmith/Mountain/FishShop一律走Farm→Town→Mountain；**Backwoods不作为中转**。
- **下矿入口固定**：`mine`前必须先`goto_location`到Mine入口。
- **下矿安全**：生命<50%或食物=0立即leave_mine；食物≥5才下。
- **季末规划**：春季作物在夏季第1天枯死；季末只种能在28日前成熟的作物。
- **社交**：顺路2-4人，不专门跑图。
- **每20动作自检**：若今天金钱或材料增量为0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. collect熔炉+装Iron Ore炼铁锭（≤2次，只炼铁）
2. 浇水（水壶在背包时）
3. 洒水器落地（先清空位/换锚点）
4. 清背包+白名单出货
5. 买鱼饵（现金≥150g，<16:30）
6. 钓鱼攒钱（Mountain湖边，放最后单独执行，4轮）
7. 现金≥2200g且空格≥5买已解锁春季种子
8. 种下（失败换锚点）
9. 砍树攒木头到150
10. 社交（仅顺路）

</details>

## ⚠️ 今日问题
> 昨日钓鱼4轮约25条、出货1038g是有效收入；但熔炉装料连续失败（未先collect/铜矿占炉）、洒水器craft后无空位、FishShop未确认营业就open_shop、donate提前调用、build_road/decorate/wait空转，都是可避免的浪费。核心卡点：铁锭停在2、洒水器放不下、现金仅1684g。今日应先解决熔炉与洒水器分区，再钓鱼攒钱。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:00 动作 `donate` 失败 @ FarmHouse — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 16:00 动作 `build_road` 失败 @ Farm — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 16:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 熔炉装料连续失败，铁矿没炼成铁锭 @ Farm 熔炉 — load_machines 返回 'no empty machine accepts anything in the backpack or the farm chests'，熔炉被铜矿占满或仍在工作（做不了：铁锭停在0，钢斧头升级和洒水器补做都卡住） 〔复盘〕
- 洒水器 craft 成功但 place 失败 @ Farm 田地分区 — place 返回「Sprinkler 在规划的分区里没有空位了（不在分区外乱放）」（做不了：洒水器放不下，无法自动化浇水，体力继续被浇水占用） 〔复盘〕
- 去 FishShop 买饵时商店未开 @ FishShop — open_shop 返回 'can't open shop FishShop here (wrong location, closed, or shopkeeper absent)'，10:40 到达但脚本未确认营业状态（做不了：鱼饵没买成，钓鱼轮次受限） 〔复盘〕
- 社区中心献祭无法捐赠 @ Community Center — donate 返回 'can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon'（做不了：社区中心收集包进度卡住，温室解锁延后） 〔复盘〕
- 现金仅1684g，买饵和下一件工具都受限 @ 全局 — 现金1684g < 钢斧头5000g，也低于种子和买饵的舒适线（做不了：钢斧头升级延后，买饵需精打细算） 〔复盘〕
- 铺路与装饰动作空转 @ Farm — build_road 返回 'laid 0 Cobblestone Path tiles (24 skipped: blocked by trees/crops/objects)'；decorate 返回 '今天没有能做的装饰'（做不了：浪费了 24 块铺路石和 20 分钟游戏时间，没有推进任何里程碑） 〔复盘〕
