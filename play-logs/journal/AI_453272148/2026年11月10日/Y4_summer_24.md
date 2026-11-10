# 第4年 summer 24 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（00:34 开始）
- 天气：sunny　金钱：25215g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y4_summer_24）准备的脚本
- 里程碑：工具按档升级——钢锄头（5000g+5铁锭），今天先凑铁锭
- 起床先真清背包：store_items 显式存 Stone 和 Cobblestone Path，验证空格≥8
- 食物≥5 才下矿；不够先在 Forest 河边钓鱼补
- 下矿 40-59 层拿铁矿石+煤，≤2 次 mine
- 回农场先 collect 再 load（炉空才装）
- 铁锭够 5 就去铁匠铺升级锄头（9:10-15:30）
1. `donate`
2. `collect_machines`
3. `store_items`（items=["Stone", "Cobblestone Path"]）
4. `store_items`（items=["Stone"]）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `goto_location`（location="Blacksmith"）
13. `upgrade_tool`（tool="hoe"）
14. `goto_location`（location="Farm"）
15. `water_crops`
16. `sleep`
- **06:00** FarmHouse ✅ `load_machines`
  - 结果：loaded: Spice Berry -> Preserves Jar (ready in 4000 min), Spice Berry -> Preserves Jar (ready in 4000 min)
  - 执行状态：SUCCESS · 操作编号：1662b385d02542e8b21130453d0f461e
  - 耗时：17.547 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Coal
  - 执行状态：SUCCESS · 操作编号：0274544b03b446138dd6178b3ec68f39
  - 耗时：18.25 秒 / 游戏 20 分钟
- **06:20** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：91f37d1b93374c3ea85d50c019614590
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：70e5f97f922f4c7cb4f787b9a4b1f6cb
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~362g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：ebc345f3d9a9431d9cb1ec7b6f7beccb
  - 耗时：0.719 秒 / 游戏 0 分钟
- **06:40** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：12b3072cc3cf4edd8694d1055b2a626b
  - 耗时：0.329 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate 在 wait_letter 阶段必失败，直接丢弃该动作；保留原路线：先清背包（显式存 Stone/Cobblestone Path）→F
1. `store_items`（items=["Stone", "Cobblestone Path"]）
2. `store_items`（items=["Stone"]）
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `goto_location`（location="Mine"）
6. `mine`（floors=5）
7. `mine`（floors=5）
8. `leave_mine`
9. `goto_location`（location="Farm"）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `water_crops`
13. `sleep`
- **06:40** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：3995fb04457d482db5fd3dba1d78c020
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：aae6cf6e88ba4b318f1a8d599c1e7038
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:40** Farm ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：d6bef16d8a9e415bb5bc142ae71b366b
  - 耗时：25.235 秒 / 游戏 30 分钟
- **07:10** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Soggy Newspaper, Joja Cola, Trash, Pike)
  - 执行状态：SUCCESS · 操作编号：a03161164d464147b53e5934cdccae13
  - 耗时：69.218 秒 / 游戏 90 分钟
  - 🗨️ [hud] Soggy Newspaper
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Trash
- **08:40** Forest ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：76dfa85650cc49eaa0d08b1d1849b550
  - 耗时：74.141 秒 / 游戏 90 分钟
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：c7c1b9de4b6e48a4a34fcaff61275b50
  - 耗时：0.344 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：mine 因背包0空格被拒，先按策略显式存 Stone 与 Cobblestone Path 腾格，再回矿洞继续，其余路线不变。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Farm"）
4. `store_items`（items=["Stone", "Cobblestone Path"]）
5. `store_items`（items=["Stone"]）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `water_crops`
9. `sleep`
- **10:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：46b031aa1ea7458eb4ce1c660c1927c7
  - 耗时：0.359 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine 因背包0空格被拒，先回农场把 Stone 整组和 Cobblestone Path 存掉腾格，再收炉装炉浇水睡觉，明天带够空格下矿。
1. `leave_mine`
2. `goto_location`（location="Farm"）
3. `store_items`（items=["Stone", "Cobblestone Path"]）
4. `store_items`（items=["Stone"]）
5. `collect_machines`
6. `load_machines`（item="Iron Ore"）
7. `water_crops`
8. `sleep`
- **10:10** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：12746b901d494fcf8581a3f146ac444a
  - 耗时：0.297 秒 / 游戏 0 分钟
- **10:10** Mine ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,0)
  - 执行状态：SUCCESS · 操作编号：9e69160b90124239bccdbca6043f2979
  - 耗时：33.578 秒 / 游戏 40 分钟
  - 🗨️ [hud] A Bullhead frenzy has 
begun in the 
mountains. 
- **10:50** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：7e909d9ea8314b8dba13fc2aaba7d991
  - 耗时：16.031 秒 / 游戏 30 分钟
- **11:20** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：4ace32e6fa7c44d4b107a3e975d53099
  - 耗时：0.297 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：d4de550ff55840b4b71a24adaec27141
  - 耗时：0.312 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：14271728a94a42a08896f34e27ef60ae
  - 耗时：0.344 秒 / 游戏 0 分钟
- **11:20** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：c1d7fcc78feb485496921c5411efc6d9
  - 耗时：0.297 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `load_machines`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：no empty machine accepts that, and the rest are busy; try again after they finish
  - 执行状态：NO_PROGRESS · 操作编号：3d7343f232bc4870ad147d6c6499a05b
  - 耗时：0.329 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：7abca957475743e4b389685da0538258
  - 耗时：0.297 秒 / 游戏 0 分钟
- **11:20** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：ba55b89065484e47ac90f318afc9dc06
  - 耗时：0.265 秒 / 游戏 0 分钟
- **11:20** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：75576bc05ec24dfb84bf4e9eb58e1196
  - 耗时：24.75 秒 / 游戏 30 分钟
- **11:50** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：2c22171105e24c52b205030e9d305591
  - 耗时：0.313 秒 / 游戏 0 分钟
- **11:50** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：a1212d6926c0456e85bafc7dda07a07b
  - 耗时：20.797 秒 / 游戏 20 分钟
- **12:10** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **12:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 2:10 pm
  - 执行状态：SUCCESS · 操作编号：e8a08b3ade674cdbaba60dd03edbb0df
  - 耗时：81.625 秒 / 游戏 120 分钟
- **14:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 4:10 pm
  - 执行状态：SUCCESS · 操作编号：030f095a6a224483b874fe17412a3488
  - 耗时：87.781 秒 / 游戏 120 分钟
- **16:10** Farm ✅ `wait`（minutes=120, filler=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：waited until 6:10 pm
  - 执行状态：SUCCESS · 操作编号：9a30ab2ce72d45449cdf631a15e88f59
  - 耗时：87.797 秒 / 游戏 120 分钟
- **18:10** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：7e6ac6c95eab4b178f2f70fc8a77f523
  - 耗时：12.657 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：25215 → 25577（+362g）
- 出货估值：362g　动作：31 个　失败：11 个
- 模型调用：5 次　tokens：60321
- 有效动作率：0.4815　空转：8　熔断跳过：0
- 失败耗时：24.58 秒 / 游戏 20 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
连续多天卡在同一处：store_items 只存小件，Stone 2407 块仍占背包，mine 被拒 3 次；被拒后重写脚本 3 次再撞同一堵墙；下午空转在 donate/build_road/decorate 三个必失败动作上，还 wait 4 小时。铁锭 0 产出，钢锄头原地踏步。核心修正：清背包必须显式点名 Stone 整组，失败即转钓鱼，禁用 wait 与三个无效动作。

**新教训：**
- store_items 的 items 列表第一项不写 Stone 就等于没清背包：连续三天只存 Coal/Green Algae 等小件，Stone 2407 块仍占格，mine 每次被拒——明天必须把 Stone 整组作为 items 第一项，存完读背包验证空格数。
- mine 被拒后重写脚本 3 次是纯浪费：背包状态不因重写而改变，昨天 4 次 mine 全撞同一堵墙——被拒一次即当天不再调 mine，直接 goto Forest 钓鱼。
- 主活动失败后下午空转在 donate/build_road/decorate 三个必失败动作上（13:00-14:30 连续 FAIL），当天有效动作仅 12/25、收入 450g——这三个动作在 wait_letter / 农场未清地 / 无材料阶段应脚本层直接禁用，失败后立即转 Forest 钓鱼。
- Forest 河边 4 cast 稳定出 3-4 条鱼（Pike 等），是食物和现金的可靠来源：食物 <5 时优先钓鱼补到 ≥5 再下矿，而不是空转或 wait。
- wait(filler) 昨天又浪费 4 小时（14:10-18:10 三次 120 分钟）：主活动失败后应立即 goto Forest 钓鱼或 sleep，脚本层永久禁用 wait。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏25）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 25215g 早已够，唯一卡点是 **Iron Bar 差 5**（Iron Ore 2、Coal 10）。铁锭同时是洒水器 ×4 的材料，所以「下矿拿铁」是唯一主线，其他都是支线。

离完成还差：10 铁矿石 + 5 煤 → 两座熔炉约 2 轮 → 5 铁锭 → 铁匠铺升锄头。

接下来 3 天主活动：
- **今天（夏25）**：第一动作真清背包（Stone 整组 + Cobblestone Path 全存），读背包确认 ≥8 空格；食物 <5 先去 Forest 钓鱼补；两项达标才下矿 40-59 层拿铁矿石+煤；回农场先 collect 再 load。
- **明天（夏26）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（夏27）**：钢锄头到手转钢斧；铁锭余量给洒水器。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床 collect_machines 1 次**：返回空则当天永久跳过 collect。
2. **真清背包（第一硬前置）**：`store_items` 的 items 列表**第一项必须是 Stone**（整组存，宁可全存），第二项 Cobblestone Path。存完**必须再读背包确认空格 ≥8**；不足则第二次只存 Stone 剩余；仍不足则放弃下矿，直接转钓鱼。清完立刻 goto Mine，不先绕路。
3. **补食物到 ≥5（第二硬前置）**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物 ≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格 ≥8、食物 ≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过 load。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包只认 Stone + Cobblestone Path**：昨天 3 次 mine 被拒全是空格不足，而 store_items 只存了 Coal 等小件。今天 items 列表第一项写 Stone，存完读背包验证 ≥8 空格。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认；不足则第二次只存 Stone，仍不足则放弃下矿转钓鱼。
- **食物 ≥5 才下矿**：食物=4 时下矿停在 39 层，铁矿石零产出。食物检查必须在 goto Mine 前显式读背包。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**（昨天重写 3 次全撞同一堵墙）。
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
2. 真清背包到 ≥8 空格并验证（**只存 Stone + Cobblestone Path**，清完立刻去矿洞）
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
> 连续多天卡在同一处：store_items 只存小件，Stone 2407 块仍占背包，mine 被拒 3 次；被拒后重写脚本 3 次再撞同一堵墙；下午空转在 donate/build_road/decorate 三个必失败动作上，还 wait 4 小时。铁锭 0 产出，钢锄头原地踏步。核心修正：清背包必须显式点名 Stone 整组，失败即转钓鱼，禁用 wait 与三个无效动作。
- 06:40 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 10:10 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 11:20 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 11:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:20 动作 `load_machines` 失败 @ Farm — no empty machine accepts that, and the rest are busy; try again after they finish 〔自动〕
- 11:20 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 11:20 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 11:50 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 12:10 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功：store_items 只存了 1x Coal 等小件，Stone 2407 块和 Cobblestone Path 24 块仍占格 @ Farm 箱子旁 — store_items -> OK: stored 1x Coal；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 3 次，每次重写又调 mine 再失败（共 4 次） @ Mine 入口 / Farm — mine -> FAIL: need at least 5 free backpack slots before mining（重复 4 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- donate 在 wait_letter 阶段仍被调用两次 @ Farm — donate -> FAIL: can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心捐赠进度无法推进（需等巫师来信）） 〔复盘〕
- build_road 铺 24 块 Cobblestone Path 全被树/作物挡住，0 块铺成 @ Forest / Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)（做不了：Cobblestone Path 继续占背包格，农场未清地前铺路无意义） 〔复盘〕
- 主活动失败后下午空转在 donate/build_road/decorate 三个必失败动作上，还 wait 三次共 4 小时 @ Farm / Forest — 三个动作连续 FAIL；wait -> OK 但无产出；当天有效动作仅 12/25，收入 450g（做不了：没有转钓鱼，浪费下午时段，铁锭进度原地踏步） 〔复盘〕
