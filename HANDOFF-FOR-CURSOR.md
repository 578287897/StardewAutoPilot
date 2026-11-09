# 交给 Cursor 的说明

你接手的是 StardewAutoPilot。仓库：https://github.com/578287897/StardewAutoPilot

本地路径：`C:\Users\Administrator\.zcode\workspace\draft-404e0e77-25fe-4126-be5f-d9da193941fe\StardewAutoPilot-main`

游戏目录：`F:\steam\steamapps\common\Stardew Valley`

当前分支：`deliver-0.2.13`，跟踪 `origin/main`。本地还有夜间日志同步产生的提交，不要 force-push，不要覆盖玩家存档。

## 这是什么

星露谷物语 1.6 的 SMAPI 模组加一个 Python 代理。模组把游戏状态做成 `http://localhost:8765/` 的 JSON，并执行走路、钓鱼、下矿、升级工具这类动作。代理里的模型写每天的脚本。不做图像识别。

正在玩的存档名是 `AI_453272148`。决定怎么玩的模型是游戏里按 F8 保存的配置（`Mods/StardewAutoPilot/config.json` 的 `Model`，目前是 deepseek-flash）。Grok 只负责看日志、改代码、必要时重启，不负责每一步点击。

## 现在游戏里的情况

2026-11-09 晚些时候已经用 0.2.13 重新打开过。接手时进程是：

- `StardewModdingAPI` pid 39260，18:00 启动
- `python autopilot.py` pid 21004
- 读到的状态：第 4 年夏 5 日 7:00，人在森林，16512 金

以你打开时的 `/state` 为准，上面这个时间会继续往前走。

## 版本

模组版本 **0.2.13**，提交 `84d833e`。说明在 `CHANGELOG.md`。

0.2.13 修的是：睡觉时昏倒会留下 `ACTION_UNCERTAIN` 回执，代理一直等这个回执，最后进程停住。已经翻到第二天的 `sleep` 算睡过了，可以接着玩。买东西和升级工具的未确认回执仍然不能重放，也不能自动删掉。

更早的可靠机制在 `RELIABILITY.md` 和 `DELIVERY.md`：

- `load_machines`、铺路、装饰零进展会熔断
- 铜镐升级不会因为字符串里有 `axe` 去买斧头
- 节日锁小镇时，去山区改走农场到后山
- 冒险家公会不到点不开门
- 下矿按武器伤害和治疗食物限制层数
- 模型思考时每 15 秒 ping 一次，避免 60 秒无请求就把时间暂停
- 卡住时由 F8 里的模型决定是否重启，默认开。重启会读回上一夜的存档
- 每天晚上复盘写完后，`sync_logs.ps1` 把日志推到 `main` 的 `play-logs/`。不要改回每分钟推送

## 还没做完

- 春 2 日到春 7 日，`ship_produce` 报过到不了出货箱。
- 夜里复盘请求返回过 401。先查 F8 里的网关和 Key，不要把 Key 写进提交。
- C# 改动必须重启游戏才进当前进程。Python 改动必须重启 `autopilot.py`。
- 不要提交 `agent/config.json`、`Mods/StardewAutoPilot/config.json`、`agent/memory/` 里的密钥，也不要删 `pending_action.json` 来硬重试一笔未确认的购买或升级。

## 怎么跑

游戏用 SMAPI 启动。代理在 `agent/` 里执行 `python autopilot.py`。它默认不在标题界面自动读档。进档后按 F8 保存网关和 Key。

编译：

```powershell
cd mod
dotnet build -c Release -p:GamePath="F:\steam\steamapps\common\Stardew Valley"
```

测试：

```powershell
cd agent
python -m unittest discover -s . -p "test_*.py"
```

日志：

- SMAPI：`%APPDATA%\StardewValley\ErrorLogs\SMAPI-latest.txt`
- 游玩记录：游戏目录下的 `AI游玩日志`
- 已同步副本：仓库 `play-logs/`

## 请你接着做

先看实时 `/state`、SMAPI 最新日志和当天游玩记录，确认人还在动。若出货箱或复盘 401 还在重复出现，按源码修，补测试，升小版本，写进 `CHANGELOG.md`。游戏正在跑时不要覆盖 DLL。不要 force-push。
