# Stardew AutoPilot

让大模型自己玩《星露谷物语》——**不用截图、不用图像识别**。一个 SMAPI mod 直接从游戏内存读出状态、调用游戏 API 执行动作；一个 Python 代理用任意 OpenAI 兼容的大模型做计划，每晚复盘、改写自己的策略，一天天变强。

*An LLM plays Stardew Valley with no screen reading: a SMAPI mod exposes game state and actions over a local HTTP API, and a Python agent plans each day with any OpenAI-compatible model, reviews the day at night, and rewrites its own strategy.*

```
星露谷 + SMAPI + mod/ (C#)  ⇄  http://localhost:8765  ⇄  agent/ (Python)  ⇄  OpenAI 兼容 API
                                                              └─ 状态页 http://<电脑局域网IP>:8790/
```

## 它怎么玩

- **前一晚写好明天的脚本**：睡觉后在后台复盘今天、生成明天 10–25 步的执行脚本；白天照脚本执行，只有关键动作失败才重新叫模型（每天最多 3 次）。模型思考时游戏时钟暂停。
- **代码强制的规则**，不只靠提示词：
  - 路线整理：一天里每张地图只去一次（农场早晚各一次），不在地图之间来回跑。
  - 里程碑路线图：箱子 → 背包升级 → 熔炉 → 铜斧头/铜镐 → 下矿装备 → 洒水器 → 钓鱼 → 加工机器 → 鸡舍 → 大木屋 → 房屋升级。进度从游戏数据实时计算；脚本里没有推进当前里程碑的动作时，自动插入一个。
  - 矿洞安全：生命低于 40% 自动吃东西，没吃的自动出矿；按武器伤害和食物数量限制能下到的层数；被打倒后 3 天内限制深度。
  - 夜间结算/存档/升级界面绝不手动关闭，避免丢存档；每天早上自动备份存档（保留 7 天）。
- **好看的农场**：第一次运行时根据真实地图画出总体规划——门前广场、2 格宽主干道和路灯位、离家最近的菜地、带栅栏的畜牧区、藏在屋后并用树遮挡的作坊角、按 3×3 坑位排列的果园。之后所有摆放/建造/种地都由代码按分区决定；空闲时间自动铺路、种遮挡树、围栅栏、种花。
- **从游戏数据读知识**：种子每格每天净收益表（含换季提醒）、村民当天行程/锁门时间/最爱礼物、物品用途、配方、社区中心收集包、可建造建筑和可买动物。
- **还会**：钓鱼小游戏（按游戏物理自动控制）、下矿打怪、克林特升级工具、马洛买武器、照顾动物（含挤奶剪毛）、加工机器、做菜、社区中心献祭、节日活动（夏威夷宴会放汤、展览会摆摊、花舞节邀请舞伴）。
- **给人看的**：游戏目录下 `AI游玩日志/<存档>/` 每天一个 Markdown 游玩日志和一张农场规划图；手机连同一 Wi-Fi 打开状态页看今日计划、里程碑、金钱曲线和农场地图。

把游戏日志推到 GitHub 不需要开代理。在仓库根目录运行 `powershell -File sync_logs.ps1` 会立刻同步一次。`powershell -File sync_logs.ps1 -Watch` 会一直看着日志，大约每分钟把新内容推到 `main`。它只复制 SMAPI 的 `ErrorLogs` 和游戏目录里的 `AI游玩日志` 到 `play-logs/`。不会读取代理配置，也不会启动代理。

## 安装

需要：正版《星露谷物语》1.6、[SMAPI](https://smapi.io/) 4.x、[.NET 6 SDK](https://dotnet.microsoft.com/download)、Python 3.10+（只用标准库），以及一个 OpenAI 兼容的大模型 API。

1. **构建 mod**（会自动装到游戏的 `Mods/` 目录）：
   ```bash
   cd mod
   dotnet build -c Release
   ```
   游戏不在 Steam 默认位置时，按 [ModBuildConfig 说明](https://smapi.io/package/custom-game-path) 设置 `GamePath`。
2. **你先手动选档进入游戏**（代理默认**不会**自动新建或读取存档）。
3. **进档后按 F8** 打开「LLM 设置」：选网关预设 → 填 API Key → 保存。  
   （标题画面不能打开；也可装 Generic Mod Config Menu 在模组选项里改。）
4. **再运行代理**（也可先开着代理等你进档并保存 Key）：
   ```bash
   cd agent
   python autopilot.py             # 等你进档 + 填好 Key 后自动开始
   python autopilot.py --days 1    # 只玩一天
   python autopilot.py --mock-llm  # 不调用模型，测试 mod
   ```
   `agent/config.json` 至少填 `game_path`。若确需标题界面自动进档，设 `"auto_enter_save": true` 并配置 `save_name` 或 `new_game`。

> 建议用新存档。代理会自动推进时间和存档，请不要拿重要存档直接试。

## 目录

| 路径 | 内容 |
|---|---|
| `mod/` | SMAPI mod：HTTP 接口、动作执行（寻路、工具、钓鱼、下矿、商店、建造……）、菜单自动处理 |
| `agent/autopilot.py` | 主循环：每日脚本、路线整理、规则、复盘、记忆 |
| `agent/prompts.py` | 动作说明、长期路线图、提示词 |
| `agent/milestones.py` | 里程碑检查（基于游戏数据） |
| `agent/farmplan.py` | 农场分区、道路、装饰规划 |
| `agent/cropplan.py` | 种子收益表 |
| `agent/status.py` | 手机状态页 |
| `agent/journal.py` | 人能读的每日游玩日志 |
| `agent/memory/strategy.md` | 初始策略；每次游玩会在 `memory/<profile>/` 里自己改写 |
| `agent/mcp_game.py` | MCP：实时状态、日志、本地资料库、单步接管 |
| `agent/wikitext.py` | 读取 `mod/wiki.txt` |
| `redeploy_at_night.ps1` | 改了 mod 之后：等今晚存档完成再重启游戏并接着玩 |

更新内容见 [CHANGELOG.md](CHANGELOG.md)。

## mod 接口（localhost:8765）

`GET /state` `/map` `/crops` `/farm_grid` `/progress` `/crop_data` `/social` `/recipes` `/bundles` `/ranch` `/items` `/wiki?q=` `/messages` …，`POST /act {"type": ...}` 执行动作（完整列表见 `agent/prompts.py` 的 `ACTIONS_DOC`）。`/wiki` 只查随模组发布的 `wiki.txt`。

实时监控用 MCP（stdio，不另开端口）：

```bash
python agent/mcp_game.py
```

工具：`status`、`problems`、`journal`、`wiki`、`act`、`cancel`。`autopilot.py` 正在跑时，`act` 会和它抢同一个动作队列，只在它卡住时用。

副作用接口只用 POST：`POST /new_game`、`POST /load_save`（JSON body）。可选在 mod 的 `config.json` 里设 `ApiToken`，代理侧对应填 `mod_api_token`。状态页默认只绑局域网地址（`status_bind`: `lan` / `localhost` / `0.0.0.0`）。

## 说明

本项目与 ConcernedApe 无关，不包含任何游戏文件或素材；需要自行购买游戏。

## 许可证

[Apache-2.0](LICENSE)
