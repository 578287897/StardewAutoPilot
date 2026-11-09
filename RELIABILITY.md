# 0.2.10 执行可靠性与验收

本轮改动在 0.2.9 的基础上统一了复合任务的子动作调度，增加跨进程重启保留的操作凭据、按原因恢复的熔断、可恢复的记忆写入和执行效果指标。

## 更新与兼容性

Python 代理和 Mod 必须一起更新，再重启游戏及代理。新版代理在 `/ping` 未返回 `action_receipts: true` 时拒绝派发动作，避免旧 Mod 不识别操作编号而产生重复副作用。没有自动部署或重启你的游戏。

构建时显式关闭自动部署：

```powershell
dotnet build mod -c Release -p:EnableModDeploy=false -p:EnableModZip=false
```

退出游戏后，用新版 `StardewAutoPilot.dll` 和 `manifest.json` 更新对应 Mod 文件，保留本地配置及 `data/`。0.2.16-pre 起不再读取 `wiki.txt`，Mods 目录里的旧文件可以删掉。进入你的测试存档后，先执行只读检查：

```powershell
python agent/check_mod.py
```

此检查只读取版本能力和状态，不执行动作。它不能代替下表的游戏内验收。

## 动作从发送到确认

1. 所有 Python 游戏动作，包括存储、道路、装饰内部的子动作，都经过 `Agent.dispatch`。每次先读取最新状态，检查 Mod 是否忙碌及对应熔断，再派发。
2. 客户端生成唯一 `request_id`，将待确认请求原子保存到 `agent/memory/<profile>/pending_action.json`，再发送 `POST /act`。
3. Mod 在执行副作用前，将编号、存档名和请求内容写入 `Mods/StardewAutoPilot/data/action-receipts.json`。重复编号不会开始新动作；内容或存档不符也会拒绝。
4. 执行结束后保存结果，再响应客户端。`GET /action_status?request_id=...` 可查询结果。HTTP 超时只取消该请求对应的任务，避免误取消后来开始的另一个动作。
5. 响应丢失时，代理保留待确认编号，暂停新动作并查询结果。重启 Python 后仍会继续查询，不自动重发购买或升级。
6. 工具升级付款后、确认升级状态前发生失败，或动作失败且金钱已减少时，记作 `ACTION_UNCERTAIN`。完成记录本身无法保存、进程中断、操作不存在或切换存档时，也不能推定为“没有执行”。

该机制防止同一编号重复执行，但不承诺任意游戏操作可事务回滚。游戏或整机在付款后崩溃时，存档和凭据可能处于不同阶段，需要核对真实状态；不能盲目退款或自动重放。凭据文件保留历史编号；不要在待确认操作存在时删除或覆盖它。

### 手动核对无法自动确认的操作

先停止代理，让游戏保持运行并确认载入了正确存档。以下命令读取待确认操作、当前状态、升级状态与资源：

```powershell
python agent/reconcile_action.py
```

只有在实际检查了游戏后，才能明确记录操作结果。例如，确认铁匠已接收目标工具：

```powershell
python agent/reconcile_action.py --resolve <操作编号> --decision confirmed-success --note "已在游戏确认铜镐升级中，钱和铜锭扣除正确"
```

若确认操作没有完成，使用 `--decision confirmed-failure` 并写明依据。工具会拒绝在 Mod 仍忙碌或存档/服务不匹配时解除。决定写入 `reconciliation.jsonl`，不修改游戏、不退款、不重放动作；之后重启代理继续。

## 熔断与记忆

- 装料依赖资源与机器内容/就绪状态；机器倒计时和无关金钱变化不解除限制。只有熔炉时还会排除鱼等无关物品。收集输出只依赖机器状态。
- 路线失败依赖当前位置、出口与通路变更；不是“每过一小时就忘记路径失败”。锁门、营业时间或节日限制则允许跨小时再检查。
- 取放资源、制作或建设不会再一律清空所有熔断。箱子资源包含在状态中；资源数量没变就不会因“执行过一次存储”而解封。
- 文件先写同目录临时文件并刷盘，再替换正式文件，保留 `.bak`。布局等 JSON 损坏时可恢复上一版；两份都损坏则显式报错。
- 复盘先写待提交记录，再更新策略与教训；中途失败后，下次读取快照或启动时会完成该提交。共享锁保护主线程、后台复盘的读改写。历史策略不因同一天恢复而被覆盖。

## 指标与日志对照

每天的 `metrics.csv`、游玩日志与手机状态页展示执行质量；旧 CSV 会迁移字段并保留历史行。记录有效动作率、明确空转、熔断跳过、连接/待确认状态、失败的真实耗时与游戏分钟、矿层进展和当天新完成的里程碑。操作编号用于去除复合任务父子记录重复；查询得到的最终结果覆盖同编号的早期连接异常。

“有效动作率”的分母排除等待、睡觉、熔断跳过和连接异常。收获 0、浇水 0、空装料等明确无产出的成功反馈不计有效动作。它只是执行结果的粗粒度指标，不代表经济最优，也无法单独证明策略因果效果。

你上传新日志后，可用同一工具分析：

```powershell
python agent/analyze_logs.py play-logs/journal --output reliability-report.md
```

历史对照见 [75 份日志的基线报告](tests/reliability-baseline.md)：5054 次工作尝试，3139 次明确空转，粗粒度有效动作率 25.4%。历史文件缺少耗时和操作编号时不推算；对比新版时还要考虑季节、装备、进度及模型配置。

## 已完成的验证

```powershell
python -m unittest discover -s agent -p 'test*.py'
python -m compileall -q agent
dotnet run --project tests/ModProtocol -c Release
dotnet build mod -c Release -p:EnableModDeploy=false -p:EnableModZip=false
```

本地：56 项 Python 测试通过，11 项 C# 凭据检查通过，完整 Mod Release 构建通过（0 警告、0 错误）。[GitHub Actions 模板](ci/checks.yml) 包含 Windows/Linux 与 Python 3.10/3.12 的测试矩阵，以及不依赖正版游戏文件的 C# 凭据测试；它不声称覆盖游戏运行时。当前 CLI OAuth 登录缺少 `workflow` 权限，GitHub 拒绝创建 `.github/workflows/checks.yml`，因此模板已上传但尚未启用。

授权后，在克隆仓库中启用：

```powershell
gh auth refresh -h github.com -s workflow
New-Item -ItemType Directory -Force .github/workflows
Copy-Item ci/checks.yml .github/workflows/checks.yml
git add .github/workflows/checks.yml
git commit -m "Enable reliability checks"
git push origin main
```

## 尚需游戏内验收

| 场景 | 应观察到的结果 |
| --- | --- |
| 空熔炉与显式重复脚本 | 相同资源下不反复执行，出现 NO_PROGRESS / CIRCUIT_OPEN |
| 炼铜结束、收集、补铁矿与煤 | 机器或资源变化后可以继续工作，不被全天封禁 |
| 装饰或存储的子动作发生连接异常 | 停止后续子动作，保留待确认编号 |
| 升级普通镐 | 只扣一次正确费用，目标工具进入升级中；完成后能取回 |
| 购买响应丢失、重启 Python | 查询原编号，不再次购买；最终结果写入日志 |
| 工具付款后进程中断 | 状态为待核对，不凭异常消息自动退款或重试 |
| 下矿前少于 5 个空格 | 拒绝入矿并提示存储 |
| 矿中剩余不超过 1 格 | 撤离，不继续挖矿 |
| 夜间复盘生成到一半退出 | 重启后文件完整，策略与教训配套恢复 |

这部分需要更新 Mod 后的真实游戏及新日志确认，尚未标记通过。


## Recovery and end-of-day work (2026-11-08)

- Persist the parent script action with the operation intent before POST. Unsent
  operations stay in the script; ambiguous mutations wait for a durable receipt.
  Confirmed purchases are not replayed. Interrupted macros and confirmed failures
  replan from current facts, and confirmed sleep closes the day.
- End-of-day work tries immediate requirements, the current milestone and one
  seasonal outing, with at most three supplemental jobs per day. Health, stamina
  and time bound outings. Wait only for pending machine production; otherwise
  permit early sleep. `--no-save` continues to prohibit saving.
- Machine dependency snapshots read IDs and tags from live machine rules, including
  fuel. Query and negated-tag rules conservatively track all resources. Farm work
  uses current recipe ingredient/category IDs, output stock and seasonal seeds.
  Older Mods without dependency metadata conservatively track all resources.
- Machine, road and decoration results report `progress_count` and `reason_code`.
  Zero progress suppresses repeats immediately; message matching remains for older
  Mods. Deploy the Python agent and rebuilt Mod together to use the new metadata.
