"""Compare uploaded Markdown play journals using the same no-progress metric as the agent."""
import argparse
from pathlib import Path
import re

from storage import atomic_write
from telemetry import summarize

ACTION = re.compile(r'^- \*\*(\d\d):(\d\d)\*\* (.*?) (✅|❌) `([^`]+)`')


def read_steps(text):
    steps = []
    for line in text.splitlines():
        match = ACTION.match(line)
        if match:
            hour, minute, location, mark, kind = match.groups()
            steps.append({'time': int(hour) * 100 + int(minute), 'location': location,
                          'ok': mark == '✅', 'action': {'type': kind}})
        elif steps and line.startswith('  - 结果：'):
            steps[-1]['message'] = line.split('结果：', 1)[1]
        elif steps and line.startswith('  - 执行状态：'):
            steps[-1]['status'] = line.split('执行状态：', 1)[1].split(' · ')[0]
            if '操作编号：' in line:
                steps[-1]['request_id'] = line.split('操作编号：', 1)[1]
        elif steps and line.startswith('  - 耗时：'):
            numbers = re.findall(r'[\d.]+', line)
            if len(numbers) == 2:
                steps[-1].update(elapsed_seconds=float(numbers[0]), game_minutes=int(numbers[1]))
    return steps


def report(root):
    rows = []
    all_steps = []
    for path in sorted(Path(root).rglob('Y*.md')):
        steps = read_steps(path.read_text(encoding='utf-8'))
        if steps:
            all_steps.extend(steps)
            rows.append((path.relative_to(root).as_posix(), summarize(steps)))
    total = summarize(all_steps)
    rate = lambda value: f'{value:.1%}' if value is not None else '—'
    lines = ['# 执行可靠性报告', '',
             f'日志文件：{len(rows)}；工作尝试：{total["work_attempts"]}；有效动作率：{rate(total["effective_rate"])}；空转：{total["no_progress"]}。', '',
             '口径：排除等待、睡觉、熔断跳过及连接异常；明确无产出的成功反馈计为空转。操作编号去重。旧日志没有耗时和操作编号时不推算这些数据。', '',
             '| 日志 | 工作尝试 | 有效动作率 | 空转 | 熔断跳过 | 失败耗时（秒） |',
             '| --- | ---: | ---: | ---: | ---: | ---: |']
    for name, stats in rows:
        lines.append(f'| {name} | {stats["work_attempts"]} | {rate(stats["effective_rate"])} | {stats["no_progress"]} | {stats["circuit_skips"]} | {stats["failure_seconds"]} |')
    lines += ['', '有效动作率表示执行结果的粗粒度指标，不等价于经济最优或策略因果效果。对比时还需控制季节、游戏进度、装备与模型设置。', '']
    return '\n'.join(lines)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('root', type=Path)
    parser.add_argument('--output', type=Path)
    args = parser.parse_args()
    if not args.root.is_dir():
        parser.error('journal directory does not exist')
    text = report(args.root)
    if args.output:
        atomic_write(args.output, text)
    else:
        print(text)


if __name__ == '__main__':
    main()
