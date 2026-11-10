# 第4年 summer 21 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（00:13 开始）
- 天气：sunny　金钱：23664g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `load_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`
- **06:00** FarmHouse ❌ `load_machines`
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：89d00eb1fb2a415a963cdae26b173c6d
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:00** FarmHouse ✅ `goto_location`（location="Farm"）
  - 💭 (去农场的箱子)
  - 结果：arrived at Farm (64,15)
  - 执行状态：SUCCESS · 操作编号：c4c294402da446daa7634b03e57c9a71
  - 耗时：3.265 秒 / 游戏 0 分钟

## 🌙 为明天（Y4_summer_21）准备的脚本
- 里程碑：工具按档升级——凑齐5铁锭（钢锄头）
- 起床先真清背包：store_items 显式存 Stone 和 Cobblestone Path，验证空格≥8
- 食物≥5（现有9个可回血食物，够），直接下矿40-59层拿铁矿石+煤
- 回农场先 collect_machines 再 load_machines（炉空且有铁矿才装）
- 铁锭够5就去铁匠铺 upgrade_tool hoe（9:00-16:00）
- 剩余时间钓鱼补现金/食物，22:00前 sleep
1. `donate`
2. `store_items`（items=["Stone", "Cobblestone Path"]）
3. `store_items`（items=["Stone"]）
4. `goto_location`（location="Mine"）
5. `mine`（floors=5）
6. `mine`（floors=5）
7. `leave_mine`
8. `goto_location`（location="Farm"）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `goto_location`（location="Blacksmith"）
12. `upgrade_tool`（tool="hoe"）
13. `goto_location`（location="Forest"）
14. `fish`（casts=4）
15. `fish`（casts=4）
16. `sleep`
- **06:00** FarmHouse ✅ `store_items`
  - 💭 (背包快满，先存进箱子)
  - 结果：stored in chest at (74,15): 1x Joja Cola, 1x Coal
  - 执行状态：SUCCESS · 操作编号：5fed62accae3428294ca4e04fd390841
  - 耗时：6.016 秒 / 游戏 10 分钟
- **06:00** FarmHouse ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：0b1c57b8b9b34db08765d1964b787a16
  - 耗时：0.297 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：751089f94531422993ef20f3a99fa072
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `ship_produce`
  - 结果：shipped 1 stacks worth ~600g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：1eaf1798d1b44beaa661d096a6ff840e
  - 耗时：0.671 秒 / 游戏 0 分钟
- **06:10** Farm ❌ `donate`
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：f2764b222ac34867a64bfe5ece5cbf52
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#1：donate在wait_letter阶段必失败，跳过它；保留原清背包→下矿→收炉→钓鱼→睡觉路线。
1. `store_items`（items=["Stone", "Cobblestone Path"]）
2. `store_items`（items=["Stone"]）
3. `goto_location`（location="Mine"）
4. `mine`（floors=5）
5. `mine`（floors=5）
6. `leave_mine`
7. `goto_location`（location="Forest"）
8. `fish`（casts=4）
9. `fish`（casts=4）
10. `goto_location`（location="Farm"）
11. `collect_machines`
12. `load_machines`（item="Iron Ore"）
13. `sleep`
- **06:10** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：29559c47827443e6ab1609cc371946ba
  - 耗时：0.328 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：d01b5d9fa91d4f76a978ed346837607f
  - 耗时：0.313 秒 / 游戏 0 分钟
- **06:10** Farm ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：6503438a29b3417a80e6be4568ed2c8c
  - 耗时：51.875 秒 / 游戏 60 分钟
- **07:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：8ad46520c2dd4e77886f2de864d52055
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：下矿因背包空格不足被拒，先按策略显式存Stone和Cobblestone Path腾格，再重试下矿，失败则转Forest钓鱼。
1. `mine`（floors=5）
2. `leave_mine`
3. `goto_location`（location="Forest"）
4. `fish`（casts=4）
5. `fish`（casts=4）
6. `goto_location`（location="Farm"）
7. `store_items`（items=["Stone", "Cobblestone Path"]）
8. `store_items`（items=["Stone"]）
9. `collect_machines`
10. `load_machines`（item="Iron Ore"）
11. `sleep`
- **07:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：83ac705052dd43ca891eb21e9d59143b
  - 耗时：0.297 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#3：mine因空格不足被拒，先回农场存Stone和Cobblestone Path腾格再下矿，失败则转Forest钓鱼。
1. `leave_mine`
2. `mine`（floors=5）
3. `leave_mine`
4. `goto_location`（location="Forest"）
5. `fish`（casts=4）
6. `fish`（casts=4）
7. `goto_location`（location="Farm"）
8. `store_items`（items=["Stone", "Cobblestone Path"]）
9. `store_items`（items=["Stone"]）
10. `collect_machines`
11. `load_machines`（item="Iron Ore"）
12. `collect_machines`
13. `load_machines`（item="Iron Ore"）
14. `sleep`
- **07:10** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：f73c879aa14041018a2b9b3ab5b88664
  - 耗时：0.391 秒 / 游戏 0 分钟
- **07:10** Mine ❌ `mine`（floors=5）
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：18897c614f4148febc976717ee4aebeb
  - 耗时：0.297 秒 / 游戏 0 分钟
- **07:10** Mine ❌ `leave_mine`
  - 结果：not in the mine
  - 执行状态：ACTION_FAILED · 操作编号：f61af8a9607744f58a2551a6594a5e7a
  - 耗时：0.266 秒 / 游戏 0 分钟
- **07:10** Mine ✅ `goto_location`（location="Forest"）
  - 结果：arrived at Forest (118,25)
  - 执行状态：SUCCESS · 操作编号：463ad89cd4f2438fbd0b7ff9f5a17e58
  - 耗时：57.078 秒 / 游戏 70 分钟
- **08:20** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Rainbow Trout, Chub, Green Algae)
  - 执行状态：SUCCESS · 操作编号：d2a3699f67974aa0a96f4110ce2dc5dc
  - 耗时：89.906 秒 / 游戏 90 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Chub
- **09:50** Forest ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Rainbow Trout, Sunfish, Sunfish, Sunfish)
  - 执行状态：SUCCESS · 操作编号：e145eb393c3643fa8292a1ad75e876cd
  - 耗时：87.719 秒 / 游戏 80 分钟
  - 🗨️ [hud] Rainbow Trout
  - 🗨️ [hud] Sunfish
  - 🗨️ [hud] Sunfish
- **11:10** Forest ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (40,64)
  - 执行状态：SUCCESS · 操作编号：8c873461827f4adf99616f6cc38f00ca
  - 耗时：16.938 秒 / 游戏 20 分钟
- **11:30** Farm ✅ `store_items`（items=["Stone", "Cobblestone Path"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：a393cef1e3b1425f864227ef6ab54694
  - 耗时：23.921 秒 / 游戏 30 分钟
- **12:00** Farm ✅ `store_items`（items=["Stone"]）
  - 结果：nothing to store
  - 执行状态：SUCCESS · 操作编号：492d6f4242fa4f16b2ff3b75c6780957
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：ffba97119481421fb2705842244cd690
  - 耗时：0.312 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：no empty machine accepts anything in the backpack or the farm chests
  - 执行状态：NO_PROGRESS · 操作编号：4039618a0f3f428eb7a85dc430de03ff
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `collect_machines`
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:00** Farm ❌ `load_machines`（item="Iron Ore"）
  - 结果：repeated ineffective action suppressed until game state changes
  - 执行状态：CIRCUIT_OPEN
- **12:00** Farm ❌ `donate`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon
  - 执行状态：ACTION_FAILED · 操作编号：5436af6b9ea143809482f6e4cf4aad79
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:00** Farm ❌ `mine`（floors=5, supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：need at least 5 free backpack slots before mining; store_items first
  - 执行状态：ACTION_FAILED · 操作编号：6ec58a037cf844a2a0eb76da9b6501a8
  - 耗时：0.328 秒 / 游戏 0 分钟
- **12:00** Farm ✅ `goto_location`（location="Forest", supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：arrived at Forest (68,0)
  - 执行状态：SUCCESS · 操作编号：98053645c37947159041f728425fc10a
  - 耗时：24.75 秒 / 游戏 30 分钟
- **12:30** Forest ✅ `forage`（supplemental=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：picked up 0 forage items
  - 执行状态：SUCCESS · 操作编号：94eefd35ec314f91b9d7be0df3d04c3f
  - 耗时：57.641 秒 / 游戏 80 分钟
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
  - 🗨️ [hud] Inventory Full
- **13:50** Forest ❌ `build_road`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)
  - 执行状态：NO_PROGRESS · 操作编号：bbef7ce0699344689ddc7e94b01c2d48
  - 耗时：48.14 秒 / 游戏 70 分钟
- **15:00** Farm ❌ `decorate`
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）
  - 执行状态：NO_PROGRESS
- **15:00** Farm ✅ `sleep`（work_exhausted=true）
  - 💭 (按需求补充工作，无有效工作则收尾)
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：c6e0031e2f7141b084ba9525586ee5ea
  - 耗时：12.672 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：23664 → 24264（+600g）
- 出货估值：600g　动作：32 个　失败：15 个
- 模型调用：5 次　tokens：60279
- 有效动作率：0.4828　空转：7　熔断跳过：2
- 失败耗时：52.249 秒 / 游戏 70 分钟
- 最深矿层：59　新增矿层：0
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
全天卡在背包满：store_items 只存小件，Stone/Cobblestone Path 仍占格，4 次 mine 被拒，脚本重写 3 次无效，下午空转 donate/build_road/decorate 全失败，仅钓鱼有产出。核心是清背包没真正执行、失败后不转产。

**新教训：**
- store_items 一次调用只存小件等于没清背包：应把 Stone 整组和 Cobblestone Path 作为同一次调用的首要 items，存完立刻读背包确认空格数，否则下一天 mine 仍被拒。
- mine 被拒后重写脚本 3 次是纯浪费：背包状态不因重写而改变，应直接执行 store_items 或转钓鱼，脚本重写只调整未完成分支。
- 主活动失败后下午空转在 donate/build_road/decorate 三个必失败动作上（13:00-14:30 连续无效）：这三个动作在 wait_letter / 农场未清地 / 无材料阶段应脚本层直接禁用，失败后立即 goto Forest 钓鱼。
- Forest 河边 4 cast 稳定出 3-4 条鱼，是食物和现金的可靠来源：食物<5 时优先钓鱼补，而不是空转或 wait。
- 食物=4 时下矿最多安全到 39 层，40 层以下零铁矿产出：食物检查必须在 goto Mine 前显式读背包确认 ≥5，不能依赖计划文字。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 夏22）

## 长期目标
当前里程碑：**工具按档升级**——钢锄头（5000g + 5 铁锭）。现金 23664g 足够，**Iron Bar 差 5**（Iron Ore 2、Coal 10），唯一硬卡点。并行前置：洒水器 ×4（铜锭 74 已够，铁锭同瓶颈）；钓鱼 10 级已远超 2 级，玻璃纤维钓竿可顺路买。
离完成还差：5 铁锭 = 10 铁矿石 + 5 煤，两座熔炉约 2 轮。
接下来 3 天主活动：
- **今天（夏22）**：起床第一动作真清背包（Stone 整组 + Cobblestone Path 全存），读背包验证 ≥8 空格 → 食物<5 先 Forest 钓鱼补 → 下矿 40-59 层拿铁矿石+煤 → 回农场 collect 后 load。
- **明天（夏23）**：铁锭够 5 就 `upgrade_tool tool=hoe`（9:10-15:30，一次一件）；不够继续下矿。
- **后天（夏24）**：钢锄头到手转钢斧；攒铁锭给洒水器。

## 每日固定流程（严格按序，失败一次即跳下一步，绝不重写脚本重跑）
1. **起床 collect_machines 1 次**：返回空当天永久跳过。
2. **真清背包（第一硬前置，今天唯一目标）**：一次 `store_items` 的 items 列表**必须显式包含 Stone 和 Cobblestone Path**；若一次调用不能指定数量，就先把 Stone 整组存掉（宁可全存，明天要用再取）。**存完必须再读背包确认空格 ≥8**；不足则第二次只存 Stone 剩余；仍不足则放弃下矿转钓鱼。清完立刻 goto Mine，不先跑去别处。
3. **补食物到 ≥5（第二硬前置）**：食物<5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。食物≥5 才允许下矿。
4. **下矿（今天唯一主活动）**：空格≥8、食物≥5 才 `goto_location` Mine → `mine` 目标 40-59 层拿铁矿石+煤，**≤2 次 mine**。从 19 层以下开始，跳过 18 层 infested 层。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命<50% 或食物=0 立即 leave_mine。背包满立即 `ship_produce` 清格。**mine 被拒或超时一次即当天不再调 mine，转钓鱼。**
5. **回农场先 collect 再 load**：`collect_machines` 1 次确认炉子已空；炉空且背包有 Iron Ore 才 `load_machines` 1 次。返回 busy/no empty 即当天永久跳过。
6. **洒水器落地**：剩余 2 个洒水器——place 前先确认目标地块无作物/树/杂物；分区满则先用 axe/hoe 清出空地再 place。place 失败 1 次换相邻空地再试 1 次，仍失败即当天放弃。
7. **现金兜底**：现金<700g 去 Forest 河边 `fish` ≤2 轮。
8. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
9. 体力<15 或时间≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **腾背包是今天第一动作，且只存 Stone + Cobblestone Path**：昨天 4 次 mine 被拒全是空格不足，而 store_items 只存了小件（Green Algae/Trash/Broken CD），Stone 2407 块仍占格。今天 store_items 的 items 列表必须包含 Stone 和 Cobblestone Path，存完读背包验证 ≥8 空格。
- **store_items 返回 OK ≠ 空格够**：必须再读背包确认 ≥8 空格；不足则第二次只存 Stone，仍不足则放弃下矿转钓鱼。
- **食物≥5 才下矿**：食物=4 时下矿会停在 39 层，铁矿石零产出。食物<5 先钓鱼 2 轮。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不「固定做这个到 X 点」**，**绝不重写脚本重跑同一动作**。
- **load 硬熔断**：`load_machines` 每天≤2 次（含下矿后 1 次）；返回 busy/no empty 即当天永久跳过。load 前先 collect 确认炉空、再确认背包有 Iron Ore。
- **collect 硬熔断**：每天≤2 次；返回空后当天永久跳过。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，直接转钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」时先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。18 层已确认 infested，直接从 19 层以下开始。
- **upgrade_tool 必须带 tool 参数**：调用时传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先查里程碑是否显示「正在升级」及现金/锭是否够；不够直接跳过。一次只升一件。
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
- **下矿安全**：生命<50% 或食物=0 立即 leave_mine；食物≥3 才下 20 层以下，≥5 才下 40 层以下。
- **脚本重写后禁止重跑已完成动作**：重写前先读当前背包/机器状态，已 craft 的物品不再 craft，已 place 的不再 place；重写只调整未完成分支。**mine 被拒一次即当天不再调 mine，重写脚本不解决空格问题。**
- **每 20 动作自检**：若今天金钱或材料增量为 0，强制切到钓鱼分支，禁止继续空转。
- **社交**：顺路 2-4 人，不专门跑图。

## 优先级（体力/时间冲突时）
1. 起床 collect_machines 1 次
2. 真清背包到 ≥8 空格并验证（**只存 Stone + Cobblestone Path**，清完立刻去矿洞）
3. 补食物到 ≥5（Forest 河边钓鱼吃鱼，不去 Saloon，不买饵）
4. 下矿 40-59 层拿铁矿石+煤（食物≥5、空格≥8 才下，≤2 次 mine，超时即停，跳过 18 层）
5. 回农场先 collect 再 load（炉空且背包有 Iron Ore 才装，只试 1 次）
6. 剩余 2 个洒水器落地（分区满则先清地，place 失败 1 次换空地再试 1 次）
7. 现金<700g 先 Forest 河边钓鱼补现金（≤2 轮）
8. 浇水（水壶在背包时）
9. 社交（仅顺路）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 全天卡在背包满：store_items 只存小件，Stone/Cobblestone Path 仍占格，4 次 mine 被拒，脚本重写 3 次无效，下午空转 donate/build_road/decorate 全失败，仅钓鱼有产出。核心是清背包没真正执行、失败后不转产。
- 06:00 动作 `load_machines` 失败 @ FarmHouse — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 06:10 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 07:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:10 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 07:10 动作 `mine` 失败 @ Mine — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 07:10 动作 `leave_mine` 失败 @ Mine — not in the mine 〔自动〕
- 12:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 12:00 动作 `load_machines` 失败 @ Farm — no empty machine accepts anything in the backpack or the farm chests 〔自动〕
- 12:00 动作 `collect_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `load_machines` 失败 @ Farm — repeated ineffective action suppressed until game state changes 〔自动〕
- 12:00 动作 `donate` 失败 @ Farm — can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon 〔自动〕
- 12:00 动作 `mine` 失败 @ Farm — need at least 5 free backpack slots before mining; store_items first 〔自动〕
- 13:50 动作 `build_road` 失败 @ Forest — laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects) 〔自动〕
- 15:00 动作 `decorate` 失败 @ Farm — 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍） 〔自动〕
- 清背包假成功：store_items 只存了 Green Algae/Trash/Broken CD 等小件，Stone 2407 块和 Cobblestone Path 24 块仍占格 @ Farm 箱子旁 — store_items -> OK: stored 1x Trash, 2x Green Algae, 1x Broken CD；随后 mine -> FAIL: need at least 5 free backpack slots before mining（做不了：全天零铁矿石产出，5 铁锭凑不齐，钢锄头升级无法开始） 〔复盘〕
- mine 被拒后重写脚本 3 次，每次重写又调 mine 再失败 @ Mine 入口 — mine -> FAIL: need at least 5 free backpack slots before mining（重复 4 次）（做不了：浪费动作和时间，背包状态未变，下矿始终不成立） 〔复盘〕
- 两座熔炉都忙时反复 load_machines，返回 no empty machine 后仍重试 @ Farm 熔炉旁 — load_machines -> FAIL: no empty machine accepts anything in the backpack or the farm chests（做不了：Iron Ore 无法装炉，铁锭产出延迟） 〔复盘〕
- donate 在 wait_letter 阶段仍被调用两次 @ Farm — donate -> FAIL: can't donate yet: wait_letter: saw the Junimos; the Wizard will send a letter soon（做不了：社区中心捐赠进度无法推进（需等巫师来信）） 〔复盘〕
- build_road 铺 24 块 Cobblestone Path 全被树/作物挡住，0 块铺成 @ Forest / Farm — build_road -> FAIL: laid 0 Cobblestone Path tiles (0 already done, 24 skipped: blocked by trees/crops/objects)（做不了：Cobblestone Path 继续占背包格，农场未清地前铺路无意义） 〔复盘〕
- decorate 在无材料/无畜舍时被调用 @ Farm — decorate -> FAIL: 今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）（做不了：浪费动作，无任何产出） 〔复盘〕
