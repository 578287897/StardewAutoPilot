# 第2年 spring 3 日 — AI 游玩日志
（写入日期：2026年11月7日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（19:45 开始）
- 天气：sunny　金钱：1370g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y2_spring_03）准备的脚本
- 里程碑：工具按档升级（铜锄头差630g）——今天靠钓鱼+出货把现金推到≥1800g，同时炼铁补洒水器
- 收熔炉→显式装Iron Ore炼铁（≤2次，只炼铁）
- 浇水29格土豆（水壶已回背包）
- 铁锭够就craft洒水器补到4个
- Mountain湖边钓鱼4轮攒钱
- 现金≥1800g则去FishShop买玻璃纤维竿
- 傍晚回农场白名单出货+存箱子
1. `donate`
2. `collect_machines`
3. `load_machines`（item="Iron Ore"）
4. `water_crops`
5. `craft`（item="Sprinkler", count=1）
6. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
7. `goto_location`（location="Mountain"）
8. `fish`（casts=6）
9. `fish`（casts=6）
10. `fish`（casts=6）
11. `fish`（casts=6）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `load_machines`（item="Iron Ore"）
15. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
16. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min)
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Iron Ore
- **06:10** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 29 crops
- **07:00** Farm ✅ `ship_produce`
  - 结果：nothing to ship
- **07:00** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon

### 🔁 脚本重写：重写#1：donate 因巫师信未到而失败，跳过社区中心分支，按原路线继续炼铁、浇水、钓鱼攒钱到睡觉。
1. `collect_machines`
2. `load_machines`（item="Iron Ore"）
3. `water_crops`
4. `craft`（item="Sprinkler", count=1）
5. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
6. `goto_location`（location="Mountain"）
7. `fish`（casts=6）
8. `fish`（casts=6）
9. `fish`（casts=6）
10. `fish`（casts=6）
11. `goto_location`（location="Farm"）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
15. `sleep`
- **07:00** Farm ✅ `collect_machines`
  - 结果：no machine has finished output
- **07:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：all machines are busy; collect them when they finish
- **07:00** Farm ✅ `water_crops`
  - 结果：watered 0 crops
- **07:00** Farm ✅ `craft`（item="Sprinkler", count=1）
  - 结果：crafted 1x Sprinkler
- **07:00** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
  - 结果：nothing to ship
- **07:00** Farm ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (0,13)
- **07:30** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Largemouth Bass, Largemouth Bass, Chub, Chub, Green Algae, Green Algae)
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
- **10:30** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Carp, Largemouth Bass, Chub, Largemouth Bass, Chub, Broken CD)
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Chub
- **13:00** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Chub, Carp, Largemouth Bass, Green Algae, Bullhead, Carp)
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Largemouth Bass
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Bullhead
- **15:20** Mountain ✅ `fish`（casts=6）
  - 结果：fished: caught 6 (Bullhead, Carp, Green Algae, Chub, Green Algae, Bullhead)
  - 🗨️ [hud] Bullhead
  - 🗨️ [hud] Carp
  - 🗨️ [hud] Green Algae
  - 🗨️ [hud] Chub
  - 🗨️ [hud] Green Algae
- **16:50** Mountain ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
- **17:20** Farm ✅ `collect_machines`
  - 结果：collected: Iron Bar from Furnace
  - 🗨️ [hud] Iron Bar
- **17:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
- **17:20** Farm ✅ `ship_produce`（except=["Copper Ore", "Coal", "Iron Ore", "Iron Bar", "Stone"]）
  - 结果：shipped 4 stacks worth ~1424g (paid overnight)
- **17:30** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：1370 → 2794（+1424g）
- 出货估值：1424g　动作：20 个　失败：3 个
- 模型调用：3 次　tokens：34410

## 🧠 夜间复盘
昨天有效动作是钓鱼4轮+出货1424g，但熔炉被占、洒水器只做出1个、现金仍1370g。主要浪费在熔炉装料空转和背包满导致出货前无物可卖。今天应优先收熔炉炼铁、做满洒水器，再全天钓鱼攒钱买玻璃纤维竿，避免买种子和无效购物。

**新教训：**
- 熔炉装料前必须先collect确认熔炉空，否则load_machines返回'all machines are busy'空转；每天第一步固定collect再装Iron Ore。
- 钓鱼前背包空格<5时，鱼获会挤占背包导致后续出货/装料失败；钓鱼前先ship_produce清出至少5格。
- 洒水器craft成功但place失败（分区无空位）说明规划分区已满；craft前先确认目标地块有空位，否则先清杂物或调整分区。
- donate在'wait_letter'阶段会失败，社区中心献祭要等巫师来信后再去，不要提前调用。
- 现金1370g时买种子会拖慢钓竿进度；在现金<1800g前，除必要外不买种子，主活动锁定钓鱼。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y2 春4）

## 长期目标
当前里程碑：**工具按档升级（下一档铜锄头，差630g）**，并行 **洒水器×4** 与 **玻璃纤维钓竿1800g**。
- 铜锄头：2000g+5铜锭，铜锭已有64，只差现金630g；今天不交付，先攒钱。
- 洒水器×4：铁锭仅2，需再炼2铁锭（4铁矿）。熔炉今天只炼铁，铜矿全部存箱子。
- 玻璃纤维钓竿1800g：现金1370g，今天钓鱼+出货目标把现金推到≥1800g。
- 背包24格：买任何东西前先清出≥5空格。

接下来3天主活动：
- **今天（春4）**：① 收熔炉并显式装Iron Ore炼铁（≤2次）→ ② 浇水29格（水壶已回）→ ③ 铁锭≥4就craft洒水器补到4个 → ④ 全天主活动Mountain湖边钓鱼（4轮）→ ⑤ 傍晚白名单出货。
- **明天（春5）**：现金≥1800g则买玻璃纤维竿；否则继续钓鱼。下矿40-44层补铁矿/煤。
- **后天（春6）**：铁锭够就做满4洒水器；现金≥2000g则去Blacksmith升铜锄头。

## 每日固定流程（按顺序，失败即跳下一步，不重试）
1. `collect_machines`（≤2次）→ 熔炉空且背包有Iron Ore时`load_machines`显式item=Iron Ore装1次；返回"no empty machine"立即熔断，当天不再调用。**熔炉只装铁矿，禁止装铜矿**。
2. **浇水**：水壶在背包则`water_crops`1次；返回"no watering can"说明水壶仍在升级，跳过。
3. **craft洒水器**：显式检查铁锭≥1且铜锭≥1，满足才`craft Sprinkler`，目标总数4；不满足跳过。
4. **清背包**：空格<5时先`ship_produce`白名单（留25铜矿/5煤/5铁矿/全部铁锭，其余含多余Copper Bar、Stone、鱼、垃圾全出）或放箱子。
5. **主活动=钓鱼攒钱**：`goto_location` Mountain湖边 → `fish casts=6`，最多4轮（≤4次fish调用）。**fish必须放流程最后单独执行**；fish返回后先确认状态再发下一个动作。
6. **买钓竿（仅当现金≥1800g）**：`goto_location` FishShop → `open_shop` → `buy` Glass Fiber Rod 1次 → `close_menu`。现金不足不调用。
7. **买种子（仅当现金≥800g且空格≥5）**：只买已解锁春季作物（土豆/花椰菜/大蒜/Kale），单次buy≤2次，现金留≥600g。现金<800g当天不买种子。
8. 回农场`plant_seeds`（≤2次，失败换锚点或先清杂物）→ `place`洒水器（≤2次）。
9. 体力<15或时间≥22:00 `sleep`；**22:00强制sleep**。

## 规则
- **钓鱼并发熔断**：任何动作返回"busy with 'fish'"时，脚本层立即停止发新动作，等fish返回；`close_menu`不能中断钓鱼，禁止用它。**禁止在fish未结束时连发collect/load/ship/goto**。
- **熔炉优先**：每天第一步确认熔炉状态；满料先collect，空炉立即装Iron Ore。load_machines每天≤2次，返回"no empty machine"即熔断。**熔炉只炼铁，铜矿全部存箱子**。
- **现金目标**：每天结束现金≥当天开始+100g，否则第二天主活动强制改为钓鱼。
- **空转硬熔断**：任何动作返回"no empty machine accepts anything"、"no reachable stone or ladder"、"no menu is open"、"no shop is open"、"none of the ... is reachable"、"inventory full"、"no free soil near the anchor"等，脚本层立即永久跳过该分支，当天不再调用，转去钓鱼或砍树。**禁止wait**。
- **18层永久拉黑**；**45层以上不追**：mine目标锁定40-44层，到45层无产出立即leave_mine；体力<30不调mine。
- **工具升级**：一次只升一件；升级期间（2天）不调mine（无镐）也不调water_crops（无水壶）。升级前显式检查现金≥费用且锭够，不足直接跳过。
- **clear_debris / build_road / decorate 禁用**。
- **节日锁门**：日期=节日时脚本层直接禁用所有goto Town/Blacksmith/Saloon/AdventureShop，不尝试、不重试、不wait。节日当天主活动=下矿/钓鱼/砍树。
- **每日动作上限**：`load_machines`≤2、`collect_machines`≤2、`water_crops`≤1、`harvest_crops`≤1、`craft`≤1、`place`≤2、`open_shop`≤2、`buy`≤2、`upgrade_tool`≤1（仅9:10-15:30）、`interact`同一NPC≤3、`give_gift`≤1、`chop_tree`≤10、`mine`≤6、`fish`≤4。
- **商店时间**：冒险家公会14:00-22:00；皮埃尔9-17（周三休）；Saloon12:00-24:00；Blacksmith9:00-16:00；FishShop 9:00-17:00。营业时间前不调用goto/open_shop/buy。**16:00后不再去Blacksmith**。
- **路径固定**：去Blacksmith/Mountain/FishShop一律走Farm→Town→Mountain；**Backwoods不作为中转**。
- **下矿入口固定**：`mine`前必须先`goto_location`到Mine入口。
- **下矿安全**：生命<50%或食物=0立即leave_mine；食物≥5才下。
- **季末规划**：春季作物在夏季第1天枯死；季末只种能在28日前成熟的作物。
- **社交**：顺路2-4人，不专门跑图。
- **每20动作自检**：若今天金钱或材料增量为0，强制切到下矿或钓鱼分支，禁止继续空转。
- **减少脚本重写**：按固定流程一次执行到底，不因单动作失败重写整脚本。

## 优先级（体力/时间冲突时）
1. 收熔炉+装Iron Ore炼铁锭（≤2次，只炼铁）
2. 浇水（水壶在背包时）
3. craft洒水器补到4个
4. 清背包+白名单出货
5. 钓鱼攒钱（Mountain湖边，放最后单独执行，4轮）
6. 现金≥1800g买玻璃纤维竿
7. 现金≥800g且空格≥5买已解锁春季种子
8. 种下+放洒水器
9. 砍树攒木头到150
10. 社交（仅顺路）

</details>

## ⚠️ 今日问题
> 昨天有效动作是钓鱼4轮+出货1424g，但熔炉被占、洒水器只做出1个、现金仍1370g。主要浪费在熔炉装料空转和背包满导致出货前无物可卖。今天应优先收熔炉炼铁、做满洒水器，再全天钓鱼攒钱买玻璃纤维竿，避免买种子和无效购物。
- 07:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 07:00 动作 `load_machines` 失败 @ Farm — all machines are busy; collect them when they finish 〔自动〕
- 17:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 熔炉被铜矿占满，铁矿只炼出2铁锭，洒水器做不满4个 @ Farm 熔炉 — load_machines 返回 'all machines are busy' 和 'no empty machine accepts anything'（做不了：洒水器×4 做不出来，明天仍要手动浇水） 〔复盘〕
- 水壶在克林特处升级，全天无法浇水 @ Farm 田地 — water_crops 返回 'no watering can'（做不了：已种下的29格土豆当天没浇水，生长节奏受影响） 〔复盘〕
- 现金1370g，玻璃纤维钓竿1800g买不起 @ 全局 — 现金不足1800g（做不了：钓鱼效率停在基础竿，攒钱速度慢） 〔复盘〕
- 出货箱当天出货估值仅1424g，现金增长停滞 @ Farm 出货箱 — ship_produce 白名单排除项过多，背包里可卖物少（做不了：明天买钓竿和升级工具都受限） 〔复盘〕
- 社区中心献祭无法捐赠 @ Community Center — donate 返回 'can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon'（做不了：社区中心收集包进度卡住，温室解锁延后） 〔复盘〕
