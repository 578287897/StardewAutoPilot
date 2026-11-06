"""A small status page for phones on the same Wi-Fi: today's plan, milestones, money over time, farm map, recent failures.

Served by a background thread (stdlib http.server) at http://<this PC's LAN IP>:<port>/ and rebuilt from the agent's
state at most every few seconds. Read-only: it only shows what the agent already logs.
"""
import csv
import html
import socket
import threading
import time
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer

import farmplan
import milestones

REFRESH_SECONDS = 20


def lan_ip():
    """A private address phones on the Wi-Fi can reach: skips VPN/TUN ranges (198.18.x) and virtual adapters' .1 hosts."""
    try:
        ips = socket.gethostbyname_ex(socket.gethostname())[2]
    except OSError:
        ips = []
    private = [ip for ip in ips if ip.startswith(("192.168.", "10.")) or ip.startswith("172.") and 16 <= int(ip.split(".")[1]) <= 31]
    for ip in sorted(private, key=lambda ip: ip.endswith(".1")):
        return ip
    return "127.0.0.1"


def money_chart(rows):
    """Inline SVG line of money at the start of each day."""
    pts = [(r["date"], int(r["money_start"] or 0)) for r in rows if r.get("money_start", "").lstrip("-").isdigit()]
    if len(pts) < 2:
        return "<p class=muted>收益曲线：至少要两天的数据</p>"
    w, h, pad = 640, 180, 28
    lo, hi = min(v for _, v in pts), max(v for _, v in pts)
    span = max(hi - lo, 1)
    xy = [(pad + i * (w - 2 * pad) / (len(pts) - 1), h - pad - (v - lo) * (h - 2 * pad) / span) for i, (_, v) in enumerate(pts)]
    line = " ".join(f"{x:.1f},{y:.1f}" for x, y in xy)
    dots = "".join(f'<circle cx="{x:.1f}" cy="{y:.1f}" r="3"><title>{html.escape(d)}: {v}g</title></circle>'
                   for (x, y), (d, v) in zip(xy, pts))
    return (f'<svg viewBox="0 0 {w} {h}" class=chart role=img aria-label="每天早上的金钱">'
            f'<text x="{pad}" y="16" class=axis>{hi}g</text><text x="{pad}" y="{h - 6}" class=axis>{lo}g</text>'
            f'<polyline points="{line}" class=line />{dots}'
            f'<text x="{w - pad}" y="{h - 6}" text-anchor=end class=axis>{html.escape(pts[-1][0])}</text></svg>')


class StatusPage:
    def __init__(self, port, bind="lan"):
        """bind: 'lan' (default, only the Wi-Fi/LAN address), 'localhost', or '0.0.0.0' (all interfaces)."""
        self.port = port
        self.html = "<p>AutoPilot 正在启动…</p>"
        self.last_build = 0.0
        self.progress = {}
        self.progress_at = 0.0
        self.farm_map = ""
        self.map_at = 0.0
        page = self

        class Handler(BaseHTTPRequestHandler):
            def do_GET(self):
                body = page.document().encode("utf-8")
                self.send_response(200)
                self.send_header("Content-Type", "text/html; charset=utf-8")
                self.send_header("Content-Length", str(len(body)))
                self.end_headers()
                self.wfile.write(body)

            def log_message(self, *args):
                pass

        if bind in ("localhost", "127.0.0.1"):
            host = "127.0.0.1"
        elif bind in ("0.0.0.0", "all"):
            host = "0.0.0.0"
        else:
            host = lan_ip()
        self.server = ThreadingHTTPServer((host, port), Handler)
        threading.Thread(target=self.server.serve_forever, daemon=True).start()
        display = lan_ip() if host == "0.0.0.0" else host
        self.url = f"http://{display}:{port}/"

    def document(self):
        return f"""<!doctype html><html lang=zh><head><meta charset=utf-8>
<meta name=viewport content="width=device-width,initial-scale=1"><meta http-equiv=refresh content="{REFRESH_SECONDS}">
<title>星露谷 AutoPilot</title><style>
:root{{--bg:#f7f5ef;--card:#fff;--fg:#2b2a27;--muted:#77736a;--accent:#3f7d4e;--bad:#b4442f;--line:#e4e0d6}}
@media (prefers-color-scheme:dark){{:root{{--bg:#1b1c1a;--card:#252723;--fg:#ecebe6;--muted:#a19d93;--accent:#7cc08e;--bad:#e6826d;--line:#3a3c37}}}}
body{{margin:0;background:var(--bg);color:var(--fg);font:15px/1.5 system-ui,-apple-system,"PingFang SC","Microsoft YaHei",sans-serif}}
main{{max-width:900px;margin:0 auto;padding:16px}}h1{{font-size:20px;margin:4px 0 12px}}h2{{font-size:15px;margin:0 0 8px;color:var(--accent)}}
section{{background:var(--card);border:1px solid var(--line);border-radius:10px;padding:12px 14px;margin:0 0 12px}}
.kpis{{display:grid;grid-template-columns:repeat(auto-fit,minmax(130px,1fr));gap:8px}}.kpi b{{display:block;font-size:18px}}
.muted{{color:var(--muted)}}.bad{{color:var(--bad)}}ul{{margin:0;padding-left:18px}}li{{margin:2px 0}}
pre{{overflow-x:auto;font:11px/1.15 "Cascadia Mono",Consolas,monospace;margin:0}}
.chart,.farm{{width:100%;height:auto}}.farm{{border-radius:6px}}.legend{{font-size:12px;margin:8px 0 0}}
.key{{display:inline-block;margin:0 10px 4px 0}}.key i{{display:inline-block;width:10px;height:10px;border-radius:2px;margin-right:4px;vertical-align:-1px}}.line{{fill:none;stroke:var(--accent);stroke-width:2}}circle{{fill:var(--accent)}}.axis{{fill:var(--muted);font-size:11px}}
</style></head><body><main>{self.html}<p class=muted>每 {REFRESH_SECONDS} 秒自动刷新 · 只读页面</p></main></body></html>"""

    def refresh(self, agent, st, force=False):
        now = time.time()
        if not force and now - self.last_build < 5:
            return
        self.last_build = now
        try:
            self.html = self.build(agent, st, now)
        except Exception as e:  # the page must never break the agent
            self.html = f"<p class=bad>状态页生成失败：{html.escape(str(e))}</p>"

    def build(self, agent, st, now):
        e = html.escape
        d = agent.day
        p = st.get("player", {}) if isinstance(st, dict) else {}
        if now - self.progress_at > 60:
            self.progress = agent.safe(agent.game.progress, {}) or {}
            self.progress_at = now
        if now - self.map_at > 600 and agent.farm_plan():
            g = agent.safe(agent.game.farm_grid, {})
            if isinstance(g, dict) and "rows" in g:
                self.farm_map = farmplan.render_svg(g, agent.farm_plan())
            self.map_at = now

        out = [f"<h1>星露谷 AutoPilot · {e(d.tag if d else '')}</h1>"]
        kpis = [("时间", st.get("time_str", "-")), ("天气", st.get("weather", "-")), ("金钱", f"{p.get('money', '-')}g"),
                ("体力", f"{p.get('stamina', '-')}/{p.get('max_stamina', '-')}"), ("位置", st.get("location", "-")),
                ("今日动作", f"{len(d.steps) if d else 0}（失败 {sum(1 for s in d.steps if not s['ok']) if d else 0}）")]
        out.append("<section class=kpis>" + "".join(f"<div class=kpi><span class=muted>{e(k)}</span><b>{e(str(v))}</b></div>" for k, v in kpis) + "</section>")

        if d:
            plan = "".join(f"<li>{e(str(x))}</li>" for x in d.plan) or "<li class=muted>（还没有）</li>"
            left = "".join(f"<li>{e(a.get('type', ''))} {e(str({k: v for k, v in a.items() if k != 'type'}) if len(a) > 1 else '')}</li>"
                           for a in d.script[:8])
            out.append(f"<section><h2>今日计划</h2><ul>{plan}</ul>"
                       f"<p class=muted>脚本还剩 {len(d.script)}/{d.script_total} 步，重写 {d.replans} 次</p><ul>{left}</ul></section>")

        if self.progress:
            done, todo = milestones.evaluate(self.progress)
            items = "".join(f"<li>{'<b>▶ ' if i == 0 else ''}{e(n)}{'</b>' if i == 0 else ''} — {e('；'.join(info['missing']) or '条件满足')}</li>"
                            for i, (n, info) in enumerate(todo[:4]))
            out.append(f"<section><h2>里程碑</h2><p class=muted>已完成：{e('、'.join(done) or '无')}</p><ul>{items}</ul></section>")

        try:
            with agent.mem.metrics_path.open(encoding="utf-8") as f:
                rows = list(csv.DictReader(f))[-30:]
        except OSError:
            rows = []
        out.append(f"<section><h2>金钱（每天早上）</h2>{money_chart(rows)}</section>")

        if d:
            fails = [s for s in d.steps if not s["ok"]][-8:]
            items = "".join(f"<li><span class=muted>{s['time']}</span> {e(s['action'].get('type', ''))}：{e(s['message'][:140])}</li>" for s in reversed(fails))
            out.append(f"<section><h2>最近失败</h2><ul class=bad>{items or '<li class=muted>今天还没有失败</li>'}</ul></section>")
            recent = "".join(f"<li>{'✓' if s['ok'] else '✗'} <span class=muted>{s['time']}</span> {e(s['action'].get('type', ''))}：{e(s['message'][:100])}</li>"
                             for s in reversed(d.steps[-10:]))
            out.append(f"<section><h2>最近动作</h2><ul>{recent}</ul></section>")

        if self.farm_map:
            legend = "".join(f'<span class=key><i style="background:{farmplan.COLORS[k]}"></i>{e(v)}</span>' for k, v in farmplan.NAMES.items())
            out.append(f"<section><h2>农场规划图</h2>{self.farm_map}<p class=legend>{legend}</p></section>")
        return "".join(out)
