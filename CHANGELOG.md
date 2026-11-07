# 更新记录

## 2026-11-07 · 0.2.0 本地资料库、游玩监控、镐斧升级

- 从 pixelharvestwiki 下载 3333 条资料，整理成 `mod/wiki.txt`（中文名 / 英文名 / slug / 费用与获取方式）。代理规划时读本地文件，游戏内 `GET /wiki?q=` 同样只查这个文件，不访问网站。
- 新增 MCP 服务 `agent/mcp_game.py`（stdio）：`status`、`problems`、`journal`、`wiki`、`act`、`cancel`。用来看实时状态并在代理卡住时代为执行一步。
- 修复 `upgrade_tool pickaxe` 误买钢斧：查询里的 `pickaxe` 含有 `axe`，以前会命中斧头。现在先按工具种类匹配。此修复要重启游戏后才进入正在运行的进程。

## 2026-11-07 · 日志复盘五项硬修复

对照 `AI游玩日志`（夏10–秋26）里反复出现的卡点：

1. **`load_machines` 空转**：空装改为失败；当天 `load_failed` 熔断；脚本连续调用合并为 1 次并清掉后续重复。
2. **商店营业时间**：`SHOP_HOURS` 补冒险家公会(14–22)等；未开门的 `goto`/`open_shop`/`buy_weapon`/`upgrade_tool` 先 wait 再执行；禁止 12 点前去 Saloon、14 点前买剑。
3. **稻草人**：材料不够不注入 craft；扩大放置候选格；`place` 失败回滚占位，避免「幽灵占用」导致分区无空位。
4. **箱子坐标**：`take` 忽略错误 x,y，模组在指定箱没有目标时扫全部农场/农舍箱子。
5. **克林特升级 / 买剑**：`interact Clint/Marlon` 改写为 `upgrade_tool`/`buy_weapon`；铁匠铺 `dialog_answer` 不再当成功；二者失败会触发重写（不再当 minor 静默跳过）。

## 2026-11-07 · 每日问题日志

- 每晚复盘把「失败动作 + 模型归纳的问题」**直接写入当天游玩日志**同一文件的「⚠️ 今日问题」小节
  - 路径：`AI游玩日志/<存档>/2026年11月7日/Y1_spring_xx.md`（按现实日期分文件夹）
  - `memory/<profile>/problems.md` 仅作滚动摘要，供明天规划引用（不是给人单独看的副本）
- 问题字段：做了什么、在哪里、错误原因、因此卡住什么。

## 2026-11-07 · 游戏内 LLM 设置界面

- **进档后**按 **F8**（`OpenSettingsKey` 可改）打开内置设置：网关 / 模型 / API Key / 复盘模型，带 DeepSeek、OpenAI、通义、Ollama 预设。标题画面不可开（避免代理抢配置/自动选档）。
- 界面改为简易白底输入框 + 独立分行布局（标签 / 输入框 / Presets / 提示 / Save·Cancel），避免文字与按钮重叠。
- 若安装了 Generic Mod Config Menu，也可在模组选项里改同一组字段。
- Python 代理默认优先读取模组 `config.json` 里的 `ApiBaseUrl` / `Model` / `ApiKey`（可用 `llm.prefer_agent_config` 改回以 agent 文件为准）。
- 代理默认 `auto_enter_save: false`：由用户手动选档进入后再填 Key；需要旧行为时可显式打开。

## 2026-11-07 · 审查跟进

### 房屋升级里程碑可执行
- 新增 mod 动作 `upgrade_house`（罗宾：10000g + 450 木头，3 天）。
- `milestones.house` 补上真实 `step` / `advances`；升级进行中时改推进日常产出，不再空转。
- 铜工具「升级等待中」同样注入可推进动作，避免白天脚本被掏空。

### 白天重写脚本也强制里程碑
- `replan` 与夜间脚本一样调用 `enforce_milestone`。

### HTTP 安全收紧
- `/new_game`、`/load_save` 仅接受 **POST**（JSON body）；GET 返回 405。
- `ModConfig.ApiToken` 可选：配置后需 `Authorization: Bearer …` 或 `X-Api-Token`。
- agent 侧 `mod_api_token` 对应传递；`/tile` 坏参数返回 400。

### 状态页默认不绑全网卡
- `status_bind`：`lan`（默认）/ `localhost` / `0.0.0.0`。

### 动作名单一来源（agent）
- 新增 `agent/actions.py`；`KNOWN_ACTIONS` 从该处引用，并注明宏 vs mod 原语。
- `agent/test_review_fixes.py`：clean_script / 里程碑注入 / JSON 解析冒烟测试。

## 2026-11-02 · 修复

### 冶金：AI 一直炼不出铜锭
- **现象**：熔炉放好以后，AI 每天都去 `interact` 点熔炉，每次都 “nothing to interact with”，然后反复猜是不是站错了位置；铜矿和煤一直躺在箱子里。
- **原因**：装料要用 `load_machines`，模型从没用过；而且 `load_machines` 以前只拿背包里的东西，矿和煤都存在箱子里。
- **修复**：
  - `load_machines` 背包里没有时，自动从农场箱子里取燃料（熔炉的煤）和机器接受的原料（5 块铜矿）。
  - 模型对机器格子用 `interact` 时，执行器自动改成装料（空机器）或收货（已完成）。
  - 每天早上和脚本提前做完的空闲时间，自动收取产品并重新装料（铜锭 30 分钟一块，一天只装一次太慢）。
  - 动作说明写明：炼锭、加工用 `load_machines` / `collect_machines`。

### 稻草人每天都放不下
- **原因**：预定位置在地块正上方一格，那里常常是规划好的主干道。
- **修复**：改放在菜地分区内、地块之间的走道上。

### 夜里没存完档就被重启（丢了一天）
- **原因**：游戏在夜里先把日期换成明天、之后才存档；mod 在这中间就报告“新的一天已就绪”，重启脚本又用了一个过期的时间戳判断“存档已更新”。
- **修复**：
  - mod 只在 SMAPI 的 `DayStarted`（存档完成之后）才报告就绪。
  - `redeploy_at_night.ps1` 必须等存档文件在本次等待期间被真正重写过，再多等 10 秒才重启。

### 铺路：一格走不到就整段放弃
- **修复**：先检查能不能走到，走不到的格子跳过、留到以后，其余照常铺。

### 农场钓鱼：抛竿落在岸上就整个动作失败
- **修复**：落空后标记这个站位，换别的钓点重试（最多 3 次，落空不计次数）；失败信息里写明站位、朝向、力度和瞄准的格子。

### 矿洞里人物卡死（“player is busy”）
- **原因**：挖矿后工具动画没有结束，之后所有动作都在等它。
- **修复**：卡住约 4 秒后，按游戏取消动作的方式重置一次；仍不行时报告具体卡在哪个状态。
