# 第4年 fall 24 日 — AI 游玩日志
（写入日期：2026年11月10日）

### 🔁 脚本重写：固定早晨工作，等昨晚的脚本生成完
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌅 早上的计划（05:43 开始）
- 天气：sunny　金钱：49127g　体力：270/270
- （脚本生成中）先做固定的早晨工作

**执行脚本：**
1. `collect_machines`
2. `harvest_crops`
3. `water_crops`
4. `ship_produce`

## 🌙 为明天（Y4_fall_24）准备的脚本
- 里程碑：工具按档升级——凑齐 5 铁锭升 Steel Hoe
- 起床先卖鱼腾格（空格≥8）
- craft 洒水器 1 个（材料已够）
- 熔炉先 collect 再 load 铁矿石
- 食物≥5、空格≥8 后下矿 40-61 层拿铁矿石+煤
- 回农场收铁锭，铁锭≥5 且 <15:30 去 Blacksmith 升 hoe
- 不够则转 Forest 钓鱼补食物/现金，22:00 前 sleep
1. `donate`
2. `goto_location`（location="Farm"）
3. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar", "Stone", "Copper Ore"]）
4. `ship`（item="Green Algae", count=5）
5. `craft`（item="Sprinkler", count=1）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `goto_location`（location="Mine"）
9. `mine`（floors=5）
10. `fight`（range=6）
11. `mine`（floors=5）
12. `goto_location`（location="Farm"）
13. `collect_machines`
14. `upgrade_tool`（tool="hoe"）
15. `goto_location`（location="Forest"）
16. `fish`（casts=4）
17. `fish`（casts=4）
18. `sleep`
- **06:00** FarmHouse ✅ `collect_machines`
  - 结果：collected: Blackberry Jelly from Preserves Jar, Copper Bar from Furnace, Copper Bar from Furnace, Blackberry Jelly from Preserves Jar
  - 执行状态：SUCCESS · 操作编号：8250ceee102d42d787eade68e4f88bfe
  - 耗时：24.437 秒 / 游戏 30 分钟
  - 🗨️ [hud] Blackberry Jelly
  - 🗨️ [hud] Copper Bar
  - 🗨️ [hud] Blackberry Jelly
- **06:30** Farm ✅ `harvest_crops`
  - 结果：harvested 0 crops
  - 执行状态：SUCCESS · 操作编号：a1ac692983fd4d92b86a650ccb861746
  - 耗时：0.343 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：4b5d55dea01d472da51de4aa095a235f
  - 耗时：0.344 秒 / 游戏 0 分钟
- **06:30** Farm ✅ `ship_produce`
  - 结果：shipped 3 stacks worth ~1079g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：598f1fafbc8b494cae25fd4c498cc514
  - 耗时：20.844 秒 / 游戏 20 分钟
- **06:50** Farm ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：50be1909ba944b92aac06f6b769420a2
  - 耗时：41.703 秒 / 游戏 60 分钟
- **07:50** CommunityCenter ✅ `goto_location`（location="Mine"）
  - 结果：arrived at Mine (18,13)
  - 执行状态：SUCCESS · 操作编号：5ffaced4fbd342a3bbca305d8acc2c8d
  - 耗时：39.422 秒 / 游戏 40 分钟
- **08:30** Mine ✅ `mine`（floors=5）
  - 结果：mined from floor 60 to 65 (5 floors down, 2 stones broken)
  - 执行状态：SUCCESS · 操作编号：2878e2c5baab43a7bcd7a37c5d3d3b52
  - 耗时：40.25 秒 / 游戏 50 分钟
  - 🗨️ [hud] Coal
- **09:20** UndergroundMine65 ✅ `fight`（range=6）
  - 结果：done
  - 执行状态：SUCCESS · 操作编号：37bb6d0e3d3b4483ad69de5b32f790ce
  - 耗时：0.312 秒 / 游戏 0 分钟
- **09:20** UndergroundMine65 ✅ `mine`（floors=5）
  - 结果：mined from floor 65 to 70 (5 floors down, 82 stones broken)
  - 执行状态：SUCCESS · 操作编号：f6861b8cb0844d3da6af3638d2285640
  - 耗时：90.469 秒 / 游戏 120 分钟
  - 🗨️ [hud] Copper Ore
  - 🗨️ [hud] Coal
  - 🗨️ [hud] Omni Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Iron Ore
  - 🗨️ [hud] Frozen Geode
  - 🗨️ [hud] Stone
  - 🗨️ [hud] Bat Wing
- **11:20** UndergroundMine70 ❌ `goto_location`（location="Forest"）
  - 结果：could not reach (1,90); stopped at (22,90)
  - 执行状态：ACTION_FAILED · 操作编号：13ff83c167de4492b93e207985649636
  - 耗时：65.609 秒 / 游戏 90 分钟
  - 🗨️ [question] 

### 🔁 脚本重写：重写#1：Forest 寻路失败，改回农场收炉装矿并升级 hoe，避免再跑 Forest。
1. `donate`
2. `goto_location`（location="Mountain"）
3. `goto_location`（location="Blacksmith"）
4. `upgrade_tool`（tool="hoe"）
5. `goto_location`（location="Farm"）
6. `collect_machines`
7. `load_machines`（item="Iron Ore"）
8. `craft`（item="Sprinkler", count=1）
9. `place`（item="Sprinkler"）
10. `water_crops`
11. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar", "Iron Ore", "Coal", "Stone", "Copper Ore", "Copper Bar"]）
12. `sleep`
- **12:50** Town ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：f4ed1640cb334887ad1a43f383013382
  - 耗时：32.25 秒 / 游戏 40 分钟
- **13:30** CommunityCenter ✅ `goto_location`（location="Mountain"）
  - 结果：arrived at Mountain (15,40)
  - 执行状态：SUCCESS · 操作编号：44f53ef123cb4442b53d61d160091e3b
  - 耗时：21.891 秒 / 游戏 20 分钟
- **13:50** Mountain ✅ `goto_location`（location="Blacksmith"）
  - 结果：arrived at Blacksmith (5,19)
  - 执行状态：SUCCESS · 操作编号：76c545735e264154b29c2b0d30f44f03
  - 耗时：30.094 秒 / 游戏 40 分钟
- **14:30** Blacksmith ❌ `upgrade_tool`（tool="hoe"）
  - 结果：Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests)
  - 执行状态：ACTION_FAILED · 操作编号：86c7e7ee1106498ba52fc3079239b7c4
  - 耗时：0.312 秒 / 游戏 0 分钟

### 🔁 脚本重写：重写#2：铁锭只有 1 不够升 hoe，先回农场装炉炼铁矿石，再钓鱼补食物，傍晚收锭，明天再升级。
1. `donate`
2. `goto_location`（location="Farm"）
3. `collect_machines`
4. `load_machines`（item="Iron Ore"）
5. `water_crops`
6. `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar", "Iron Ore", "Coal", "Stone", "Copper Ore", "Copper Bar", "Omni Geode", "Frozen Geode", "Geode"]）
7. `fish`（casts=4）
8. `collect_machines`
9. `sleep`
- **14:30** Blacksmith ✅ `donate`
  - 结果：opened the bundles but nothing could be deposited
  - 执行状态：SUCCESS · 操作编号：f4bccd1afb1e4d89b6ba9c6c75390008
  - 耗时：36.11 秒 / 游戏 50 分钟
- **15:20** CommunityCenter ✅ `goto_location`（location="Farm"）
  - 结果：arrived at Farm (78,17)
  - 执行状态：SUCCESS · 操作编号：ad9b804a079b4e24af7f92c42aa91324
  - 耗时：38.093 秒 / 游戏 40 分钟
- **16:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：4ec2f418f65f44ae854323c37107f4c5
  - 耗时：0.281 秒 / 游戏 0 分钟
- **16:00** Farm ✅ `load_machines`（item="Iron Ore"）
  - 结果：loaded: Iron Ore -> Furnace (ready in 120 min), Iron Ore -> Furnace (ready in 120 min)
  - 执行状态：SUCCESS · 操作编号：1feebfb97d2e4399811d13b3fbd2334c
  - 耗时：16.687 秒 / 游戏 30 分钟
- **16:30** Farm ✅ `water_crops`
  - 结果：watered 0 crops
  - 执行状态：SUCCESS · 操作编号：9afa800099a64695875231bdabb889dc
  - 耗时：0.297 秒 / 游戏 0 分钟
- **16:30** Farm ✅ `ship_produce`（except=["Tiger Trout", "Salmon", "River Jelly", "Iron Bar", "Iron Ore", "Coal", "Stone", "Copper Ore", "Copper Bar", "Omni Geode", "Frozen Geode", "Geode"]）
  - 结果：shipped 1 stacks worth ~30g (paid overnight)
  - 执行状态：SUCCESS · 操作编号：0ac57ca5929e4c23affdee30dbae8378
  - 耗时：13.875 秒 / 游戏 20 分钟
- **16:50** Farm ✅ `fish`（casts=4）
  - 结果：fished: caught 4 (Joja Cola, Soggy Newspaper, Broken CD, Driftwood)
  - 执行状态：SUCCESS · 操作编号：e5c098c0a8a64978ada487f5ea672aa6
  - 耗时：52.578 秒 / 游戏 70 分钟
  - 🗨️ [hud] Joja Cola
  - 🗨️ [hud] Soggy Newspaper
- **18:00** Farm ❌ `collect_machines`
  - 结果：no machine has finished output
  - 执行状态：NO_PROGRESS · 操作编号：f18c9eeeeba347e994e43c583e2ac866
  - 耗时：0.297 秒 / 游戏 0 分钟
- **18:00** Farm ✅ `sleep`
  - 结果：went to sleep; poll /state until the new day is ready
  - 执行状态：SUCCESS · 操作编号：44cc52f56a12438b858df4b585fc7783
  - 耗时：8.406 秒 / 游戏 10 分钟
  - 🗨️ [question] Go to sleep for the night?

## 📊 当天结算（第二天早上统计）
- 金钱：49127 → 50236（+1109g）
- 出货估值：1109g　动作：23 个　失败：4 个
- 模型调用：4 次　tokens：50825
- 有效动作率：0.6818　空转：5　熔断跳过：0
- 失败耗时：67.483 秒 / 游戏 90 分钟
- 最深矿层：70　新增矿层：9
- 今日完成里程碑：无新增或未统计

## 🧠 夜间复盘
昨天主活动被背包格卡死：钓鱼把包塞满，mine 被拒后还重写脚本重跑，浪费约200游戏分钟；熔炉 collect/load 时序又错，铁锭仍为1；洒水器条件满足却始终没 craft。今天必须把「卖鱼腾格→craft 洒水器→起床即 load 铁矿→下矿」写死成顺序，mine 被拒一次即转钓鱼，不再重写脚本。

**新教训：**
- 昨天 1600 才 load 铁矿石、1800 collect 返回空：load 必须在起床 collect 之后立即做且 12:00 前完成，傍晚 load 的矿石当天收不到，铁锭产出归零。
- 昨天 mine 被拒 3 次后仍重写脚本再调 mine，耗约 200 游戏分钟：mine 第一次返回空格不足即应在脚本里物理删除 mine 分支并 goto Forest 钓鱼，重写脚本不改变背包空格数。
- 昨天洒水器条件满足（农业 2 级、Copper Bar 34）却全天无 craft：craft 应固定在清背包后第 2 个动作，与下矿成败无关，不能排在「下矿回来」分支里。
- 昨天钓鱼 4 轮只出 Green Algae/Chub/Soggy Newspaper 等杂鱼，反而把包塞满：补食物钓鱼时只留 Salmon/Tiger Trout 等高回复鱼，杂鱼和垃圾立即 ship_produce 卖掉，别占格。
- 昨天 goto Forest 在 (22,90) 被卡住到不了 (1,90)：Forest 河边钓鱼点应改用已验证可达的坐标，或改去 Mine 前先确认路径，不要反复重试同一坐标。

<details><summary>改写后的策略</summary>

# 星露谷策略（Y4 秋 25）

## 长期目标
当前里程碑：**工具按档升级——钢锄头（5000g + 5 铁锭）**。现金 49127g 充足，唯一卡点是 Iron Bar（现有 1，铁矿石 6、煤 22，两座炉约出 2 锭，还差约 2-3 锭 ≈ 10-15 铁矿石 + 3 煤）。铁锭同时是洒水器材料，所以「下矿拿铁矿石+煤」是主线，钓鱼只作补食物/现金副线。

离完成还差：约 10-15 铁矿石 + 3 煤 → 5 铁锭 → 铁匠铺升 hoe（9:10-15:30，一次一件）。

接下来 3 天主活动：
- **今天（秋 25）**：起床卖鱼腾格（空格≥8）→ craft 洒水器 1 个 → 熔炉 collect 收锭 → 立即 load 铁矿石（让白天炼完）→ 食物≥5、空格≥8 下矿 40-70 层拿铁矿石+煤（≤2 次 mine）→ 回农场 collect → 铁锭≥5 且 <15:30 去 Blacksmith 升 hoe。
- **明天（秋 26）**：铁锭不够继续下矿；够了升 hoe，余锭留洒水器。
- **后天（秋 27）**：钢锄头到手转钢斧；秋季只种能在季末前成熟的作物（南瓜、蔓越莓），季末不再新种。

## 每日固定流程（严格按序；某步失败一次即跳下一步，绝不重写脚本重跑同一动作）
1. **起床第一动作：清背包**
   - `goto_location` Farm 到出货箱旁。
   - `ship_produce` 一次卖 ≥3 组：**第一组必须整组卖鱼**（Chub、Green Algae、Salmon、Tiger Trout 等非献祭鱼）+ 非献祭杂项（多余 Copper Bar、Sap、Soggy Newspaper、Trash）。
   - **读背包验证空格 ≥8**：通过 → 进第 2 步；不足 → 再 `ship_produce` 卖小堆杂项，再验证一次；仍不足 → 当天定性钓鱼日，goto Forest，**不再试 mine**。
   - 清背包验证通过前，脚本里不得出现 collect/load/donate/water/mine 任何其他动作。
2. **craft 洒水器（条件已满足，必须今天做）**：清背包后立即 `craft` 洒水器 1 个（1 铜锭 + 1 铁锭/个，现有 Copper Bar 36、Iron Bar 1，先做 1 个）。craft 后 `place` 到空地块；place 返回「分区无空位」即当天永久跳过 place，洒水器存箱子。
3. **熔炉：起床 collect 后立即 load（顺序不可颠倒，load 必须在上午完成）**
   - `collect_machines` 1 次收已完成锭（昨天 1600 前 load 的 Iron Ore 应已好）。
   - 若背包有 Iron Ore 且炉空 → `load_machines` 1 次装铁矿石，**必须在 12:00 前完成**，让它在白天炼完。
   - load 返回 busy/no empty 即当天永久跳过 load。**load 后至少等 2 小时游戏时间再调 collect。**
4. **下矿前双检查**：goto Mine 前必须显式读背包确认 **空格 ≥8 且食物 ≥5**。食物 <5 时先 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），**只留 Salmon/Tiger Trout 等高回复鱼，Green Algae/Soggy Newspaper 直接卖**，补到 ≥5 再进 Mine。**食物 <5 或空格 <8 时脚本里不得出现 goto Mine。**
5. **下矿（主活动）**：`goto_location` Mine → `mine` 目标 40-70 层拿铁矿石+煤，**≤2 次 mine，每次目标 ≤5 层**。每层先 `fight` 清怪 1-2 次再 mine；返回「no stones left and no ladder found」先 fight 再 mine，清怪 2 次仍无梯子才 leave_mine 换层。生命 <50% 或食物=0 立即 leave_mine。**mine 被拒或超时一次即当天不再调 mine，1 个动作内 goto Forest 钓鱼。**
6. **回农场收炉**：下矿回来第一时间 `collect_machines` 1 次收铁锭；返回空即当天永久跳过 collect。
7. **升级工具**：铁锭 ≥5 且现金 ≥5000 且时间 9:10-15:30 → goto Blacksmith → `upgrade_tool tool=hoe`。**升级前必须先读背包确认 Iron Bar ≥5，不够直接跳过，不白跑铁匠铺。** 一次只升一件。
8. **补食物到 ≥5**：食物 <5 时 goto Forest 河边 `fish` ≤2 轮（每轮 ≤4 cast），鱼留着吃。不去 Saloon、不买饵。
9. **现金兜底**：现金 <700g 去 Forest 河边 `fish` ≤2 轮。
10. **浇水**：水壶在背包则 `water_crops` 1 次；返回「no watering can」或 0 crops 跳过。
11. 体力 <15 或时间 ≥22:00 `sleep`；22:00 强制 sleep。**任何情况下不用 wait 填充时间。**

## 规则
- **清背包绝对第一**：起床后第一个动作必须是 goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**），卖完立即读背包验证空格 ≥8。验证通过前不得出现任何其他动作。
- **ship_produce 返回 OK ≠ 空格够**：必须再读背包确认；两次手段仍不足则放弃下矿转钓鱼。
- **craft 洒水器排第 2**：条件已满足（农业 2 级、Copper Bar 36、Iron Bar 1），清背包后立即 craft，不能等「有空再做」。
- **食物 ≥5 且空格 ≥8 才下矿**：goto Mine 前必须显式读背包确认两项，不够先钓鱼补。
- **失败一次即转产**：任何动作返回失败，立即切到钓鱼或 sleep，**绝不重写脚本重跑同一动作**。
- **熔炉顺序硬规则**：起床先 collect 再 load；load 每天 ≤1 次且必须在 12:00 前完成；返回 busy/no empty 即当天永久跳过；collect 每天 ≤1 次，返回空后当天永久跳过；load 与 collect 之间必须隔 ≥2 小时游戏时间。
- **mine 熔断**：`mine` 返回超时或空格不足后当天不再调 mine，1 个动作内 goto Forest 钓鱼。
- **infested 层**：mine 返回「no stones left and no ladder found」先 fight 清怪 2 次再 mine；仍无梯子即 leave_mine 换层。
- **leave_mine 只在 Mine 内调用**：返回「not in the mine」说明已在地面，直接跳过，不要重试。
- **upgrade_tool 必须带 tool 参数**：传 `tool=hoe`（或 axe/pickaxe/watering can），否则必失败。升级前先读背包确认 Iron Bar ≥5 及现金 ≥5000；不够直接跳过。一次只升一件。
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
1. 起床第一动作：goto Farm + ship_produce 卖 ≥3 组（**优先整组卖鱼**）+ 读背包验证空格 ≥8
2. craft 洒水器（条件已满足，必须今天做）
3. 熔炉：起床先 collect 收锭，再 load 铁矿石（≤1 次，12:00 前完成，busy 即跳过）
4. **食物补到 ≥5**（Forest 河边钓鱼吃鱼）——下矿前置条件
5. 下矿 40-70 层拿铁矿石+煤（空格 ≥8、食物 ≥5 才下，≤2 次 mine，每次 ≤5 层，超时即停）
6. 回农场 collect 收铁锭（≤1 次，下矿回来第一时间）
7. 铁锭 ≥5 且时间 <15:30 → Blacksmith 升 hoe（升级前读背包确认锭数）
8. 现金 <700g 先 Forest 河边钓鱼补现金（≤2 轮）
9. 浇水（水壶在背包时）
10. 22:00 强制 sleep，**禁止 wait**

</details>

## ⚠️ 今日问题
> 昨天主活动被背包格卡死：钓鱼把包塞满，mine 被拒后还重写脚本重跑，浪费约200游戏分钟；熔炉 collect/load 时序又错，铁锭仍为1；洒水器条件满足却始终没 craft。今天必须把「卖鱼腾格→craft 洒水器→起床即 load 铁矿→下矿」写死成顺序，mine 被拒一次即转钓鱼，不再重写脚本。
- 11:20 动作 `goto_location` 失败 @ UndergroundMine70 — could not reach (1,90); stopped at (22,90) | 游戏消息: [question]  〔自动〕
- 14:30 动作 `upgrade_tool` 失败 @ Blacksmith — Steel Hoe needs 5x Iron Bar, you have 1 (backpack + chests) 〔自动〕
- 16:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 18:00 动作 `collect_machines` 失败 @ Farm — no machine has finished output 〔自动〕
- 背包被鱼塞满，连续 3 次下矿被拒，脚本重写 3 次仍调 mine @ Mine 入口 (18,13) — mine -> FAIL: need at least 5 free backpack slots before mining; store_items first（做不了：铁矿石和煤没拿到，铁锭仍为 1，钢锄头和洒水器材料全部卡住） 〔复盘〕
- 熔炉 load 后不足 2 小时又 collect 返回空，再 load 返回 busy @ Farm 熔炉旁 (40,9) — collect_machines -> FAIL: no machine has finished output; load_machines -> FAIL: all machines are busy（做不了：当天铁锭产出为零，钢锄头仍差 4 锭） 〔复盘〕
- 洒水器条件早已满足（农业 2 级、Copper Bar 34）却一直没 craft @ Farm — 全天动作日志无 craft 记录（做不了：继续手动浇水，体力无法全部用于下矿） 〔复盘〕
- 钓鱼 4 轮只出 Green Algae/Chub/Soggy Newspaper 等杂鱼，没补到可吃食物 @ Forest 河边 — fish -> OK: caught 4 (Joja Cola, Soggy Newspaper, Broken CD, Driftwood)（做不了：食物没补到 5，下矿仍被拦） 〔复盘〕
- goto Forest 在 (22,90) 被卡住，到不了 (1,90) @ Forest — goto_location -> FAIL: could not reach (1,90); stopped at (22,90)（做不了：Forest 河边钓鱼补食物/现金的分支走不通） 〔复盘〕
- donate 反复打开 Junimo note 无法存入，浪费动作 @ 社区中心 — donate -> OK: opened the bundles but nothing could be deposited（wizardJunimoNote pending）（做不了：浪费动作次数，起床到卖货之间被插入无效动作） 〔复盘〕
