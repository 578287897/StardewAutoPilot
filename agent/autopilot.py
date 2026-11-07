"""\nStardew Valley autopilot agent.

Loop:  /state + /map + /crops  ->  LLM picks one action  ->  POST /act  ->  log result
Day start: LLM writes a plan from strategy + lessons.
Day end (detected next morning): LLM reviews the day's log + income, rewrites memory/strategy.md
and appends memory/lessons.md, so each day is played with an improved strategy.

Usage:
  python autopilot.py                  # run until stopped
  python autopilot.py --days 3         # play 3 in-game days
  python autopilot.py --mock-llm       # no API calls, scripted policy (for testing the mod)
"""
import argparse
import collections
import csv
import json
import os
import shutil
import re
import subprocess
import sys
import threading
import time
from datetime import datetime
from pathlib import Path

import actions
from execution_guard import ExecutionGuard
import cropplan
import farmplan
import journal
import milestones
import problems
import status
import needs
import prompts
import restart_decision
import wikitext
from game import Game, GameError
from llm import LLM, LLMError

ROOT = Path(__file__).resolve().parent
MEM = ROOT / "memory"
RUNS = ROOT / "runs"


def log(msg):
    print(f"[{datetime.now():%H:%M:%S}] {msg}", flush=True)


# ---------------------------------------------------------------------------
# config
# ---------------------------------------------------------------------------

def _mod_config_candidates(game_path):
    """SMAPI writes Mods/<folder>/config.json next to the installed mod."""
    mods = Path(game_path) / "Mods"
    names = ("StardewAutoPilot", "Stardew AutoPilot", "578287897.StardewAutoPilot")
    for name in names:
        yield mods / name / "config.json"
    if mods.is_dir():
        for folder in mods.iterdir():
            if folder.is_dir() and (folder / "manifest.json").exists():
                try:
                    man = json.loads((folder / "manifest.json").read_text(encoding="utf-8-sig"))
                except (OSError, json.JSONDecodeError):
                    continue
                if man.get("UniqueID") == "578287897.StardewAutoPilot":
                    yield folder / "config.json"


def _read_json(path):
    try:
        return json.loads(Path(path).read_text(encoding="utf-8-sig"))
    except (OSError, json.JSONDecodeError, UnicodeError):
        try:
            return json.loads(Path(path).read_text(encoding="utf-8"))
        except (OSError, json.JSONDecodeError):
            return None


def load_config(path):
    """Load agent config. LLM gateway/key prefer the in-game mod UI (Mods/.../config.json)."""
    cfg = _read_json(path) or {}
    cfg["game_path"] = cfg.get("game_path") or os.environ.get("STARDEW_GAME_PATH") or str(journal.default_game_path())
    agent_llm = dict(cfg.get("llm") or {})
    llm = cfg.setdefault("llm", {})

    mod_cfg = None
    mod_path = None
    reuse = agent_llm.get("reuse_config_from")
    if reuse:
        mod_path = reuse if Path(reuse).is_absolute() else str(Path(cfg["game_path"]) / reuse)
        mod_cfg = _read_json(mod_path)
    else:
        for candidate in _mod_config_candidates(cfg["game_path"]):
            if candidate.exists():
                mod_cfg = _read_json(candidate)
                if mod_cfg is not None:
                    mod_path = str(candidate)
                    break

    # Priority: non-empty in-game mod fields → agent/config.json → env
    prefer_agent = bool(agent_llm.get("prefer_agent_config"))
    mod_vals = {
        "base_url": (mod_cfg or {}).get("ApiBaseUrl") or "",
        "model": (mod_cfg or {}).get("Model") or "",
        "api_key": (mod_cfg or {}).get("ApiKey") or "",
        "review_model": (mod_cfg or {}).get("ReviewModel") or "",
    }
    for key in ("base_url", "model", "api_key", "review_model"):
        agent_val = agent_llm.get(key) or ""
        mod_val = mod_vals.get(key) or ""
        if prefer_agent:
            llm[key] = agent_val or mod_val
        else:
            llm[key] = mod_val or agent_val
    llm["api_key"] = llm.get("api_key") or os.environ.get("STARDEW_LLM_API_KEY", "")
    if mod_cfg and "LlmDecidesGameRestart" in mod_cfg:
        cfg["llm_decides_restart"] = bool(mod_cfg.get("LlmDecidesGameRestart"))
    else:
        cfg["llm_decides_restart"] = True
    if mod_path and (mod_vals["base_url"] or mod_vals["api_key"] or mod_vals["model"]):
        log(f"LLM 配置来自游戏内设置：{mod_path}")

    if not cfg.get("mod_api_token") and mod_cfg and mod_cfg.get("ApiToken"):
        cfg["mod_api_token"] = mod_cfg["ApiToken"]
    if mod_cfg and mod_cfg.get("Port") and cfg.get("mod_url") in (None, "", "http://localhost:8765"):
        cfg["mod_url"] = f"http://localhost:{int(mod_cfg['Port'])}"

    cfg.setdefault("mod_url", "http://localhost:8765")
    cfg.setdefault("profile", "default")
    cfg.setdefault("max_steps_per_day", 120)
    cfg.setdefault("map_radius", 9)
    cfg.setdefault("history_len", 8)
    return cfg


# ---------------------------------------------------------------------------
# long-term memory (the part that iterates)
# ---------------------------------------------------------------------------

class Memory:
    """Long-term memory of one playthrough (profile). New profiles start from memory/strategy.md."""

    def __init__(self, profile):
        self.dir = MEM / profile
        (self.dir / "history").mkdir(parents=True, exist_ok=True)
        self.strategy_path = self.dir / "strategy.md"
        self.lessons_path = self.dir / "lessons.md"
        self.problems_path = self.dir / "problems.md"
        self.metrics_path = self.dir / "metrics.csv"
        self.save_name_path = self.dir / "save_name.txt"
        self.layout_path = self.dir / "layout.json"
        self.mine_limit_path = self.dir / "mine_limit.json"
        if not self.strategy_path.exists() and (MEM / "strategy.md").exists():
            self.strategy_path.write_text((MEM / "strategy.md").read_text(encoding="utf-8"), encoding="utf-8")

    def layout(self):
        if self.layout_path.exists():
            return json.loads(self.layout_path.read_text(encoding="utf-8"))
        return {"plots": [], "plot_size": [6, 4], "anchor": None}

    def save_layout(self, layout):
        self.layout_path.write_text(json.dumps(layout, ensure_ascii=False, indent=2), encoding="utf-8")

    def mine_limit(self, today):
        """{"floor": n, "until": abs_day} while a knock-out cap is active, else None."""
        if not self.mine_limit_path.exists():
            return None
        lim = json.loads(self.mine_limit_path.read_text(encoding="utf-8"))
        return lim if lim.get("until", 0) >= today else None

    def set_mine_limit(self, floor, until):
        self.mine_limit_path.write_text(json.dumps({"floor": floor, "until": until}), encoding="utf-8")

    def save_name(self):
        return self.save_name_path.read_text(encoding="utf-8").strip() if self.save_name_path.exists() else None

    def set_save_name(self, name):
        if name and name != self.save_name():
            self.save_name_path.write_text(name, encoding="utf-8")

    def strategy(self):
        return self.strategy_path.read_text(encoding="utf-8") if self.strategy_path.exists() else "（暂无）"

    def lessons(self):
        return self.lessons_path.read_text(encoding="utf-8") if self.lessons_path.exists() else "（暂无）"

    def save_strategy(self, text, tag):
        if self.strategy_path.exists():
            (self.dir / "history" / f"strategy_{tag}.md").write_text(self.strategy(), encoding="utf-8")
        self.strategy_path.write_text(text.strip() + "\n", encoding="utf-8")

    def add_lessons(self, new, keep=30):
        old = [l[2:].strip() for l in self.lessons().splitlines() if l.startswith("- ")]
        for l in new:
            l = str(l).strip()
            if l and l not in old:
                old.append(l)
        self.lessons_path.write_text("\n".join("- " + l for l in old[-keep:]) + "\n", encoding="utf-8")

    FIELDS = ["date", "money_start", "money_next_morning", "income", "shipped_value", "steps", "failures", "llm_calls", "tokens"]

    def add_metrics(self, row):
        new = not self.metrics_path.exists()
        with self.metrics_path.open("a", newline="", encoding="utf-8") as f:
            w = csv.DictWriter(f, fieldnames=self.FIELDS)
            if new:
                w.writeheader()
            w.writerow(row)

    def recent_metrics(self, n=7):
        if not self.metrics_path.exists():
            return "（暂无）"
        lines = self.metrics_path.read_text(encoding="utf-8").strip().splitlines()
        return "\n".join([lines[0]] + lines[1:][-n:])


class DayLog:
    def __init__(self, key, state, usage):
        self.key = key
        self.tag = f"Y{key[0]}_{key[1]}_{key[2]:02d}"
        self.money_start = state["player"]["money"]
        self.steps = []
        self.notes = []
        self.plan = []
        self.ended = False
        self.shipped_value = 0
        self.script = []        # remaining scripted actions
        self.script_total = 0
        self.replans = 0
        self.reflected = False  # reviewed in the background right after going to sleep
        self.early_sleep_refused = False
        self.fish_failed = False   # time filler: no fishable water here, wait instead
        self.road_skip = set()     # road tiles blocked today (trees, crops)
        self.junk_fishing = 0      # time-filler fishing rounds that caught only junk
        self.awaiting_script = False
        self.empty_debris_spots = set()
        self.craft_blocked = set()  # items that already failed craft today (don't spam)
        self.place_blocked = set()  # items with no tidy spot left today
        self.execution_guard = ExecutionGuard()
        self.llm_calls_start, self.tokens_start = usage


SEASONS = ["spring", "summer", "fall", "winter"]
WEEKDAYS = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"]


def abs_day(st):
    """Days since the start of year 1 (for "until" dates)."""
    season = SEASONS.index(st["season"]) if st.get("season") in SEASONS else 0
    return (st.get("year", 1) - 1) * 112 + season * 28 + st.get("day", 1)


def next_date(year, season, day):
    day += 1
    if day > 28:
        day = 1
        i = (SEASONS.index(season) + 1) % 4 if season in SEASONS else 0
        year += 1 if i == 0 else 0
        season = SEASONS[i]
    return year, season, day, WEEKDAYS[(day - 1) % 7]


# ---------------------------------------------------------------------------
# scripted policy for --mock-llm (exercises the mod without API cost)
# ---------------------------------------------------------------------------

class MockLLM:
    calls = 0
    tokens = 0

    def __init__(self):
        self.i = 0

    def chat_json(self, messages, max_tokens=None):
        system = messages[0]["content"]
        if "执行脚本" in system:
            return {"plan": ["收获", "浇水", "出货", "睡觉"], "reason": "mock",
                    "script": [{"type": t} for t in ("harvest_crops", "water_crops", "forage", "ship_produce", "sleep")]}
        if "规划师" in system:
            return {"plan": ["收获", "浇水", "出货", "睡觉"], "reason": "mock"}
        if "复盘教练" in system:
            return {"analysis": "mock", "strategy": prompts_strategy_passthrough(messages), "lessons": [], "problems": []}
        user = messages[-1]["content"]
        if '"is_question": true' in user:
            return {"thought": "回答问题", "action": {"type": "dialog_answer", "index": 0}}
        seq = ["harvest_crops", "water_crops", "forage", "ship_produce", "sleep"]
        a = seq[min(self.i, len(seq) - 1)]
        self.i += 1
        return {"thought": f"mock step {self.i}", "action": {"type": a}}


def prompts_strategy_passthrough(messages):
    text = messages[-1]["content"]
    start = text.find("## 当前策略")
    end = text.find("## 已有教训")
    return text[start + len("## 当前策略"):end].strip() if start >= 0 else "（mock）"


# ---------------------------------------------------------------------------
# agent
# ---------------------------------------------------------------------------

class Agent:
    def __init__(self, cfg, mock=False, no_save=False, config_path=None):
        self.cfg = cfg
        self.config_path = config_path or str(ROOT / "config.json")
        self.no_save = no_save
        self.mock = mock
        self.game = Game(cfg["mod_url"], api_token=cfg.get("mod_api_token") or "")
        self.mem = Memory(cfg.get("profile", "default"))
        self.status = None
        if cfg.get("status_port"):
            try:
                self.status = status.StatusPage(int(cfg["status_port"]), bind=cfg.get("status_bind", "lan"))
                log(f"状态页：{self.status.url}（手机连同一个 Wi-Fi 打开）")
            except OSError as e:
                log(f"状态页启动失败：{e}")
        self.llm = self.review_llm = None
        if mock:
            self.llm = self.review_llm = MockLLM()
        else:
            self.try_init_llm()  # may stay None until the player saves key in-game (F8)
        self.restart_declined = False
        self.day = None
        self.day_key = None
        self.mode = cfg.get("mode", "script")  # "script": plan the day ahead; "step": ask the model every step
        self.prepared = None                    # tomorrow's script, generated in the background after sleeping
        self.prep_thread = None
        self.auto_menu_waits = 0                # polls spent waiting for the mod to close a plain dialogue / reward pop-up
        self.journal = None  # readable per-day Markdown log in the game folder (created once the save is known)
        self.msg_seq = 0
        self.item_cache = {}
        self.run_dir = RUNS / datetime.now().strftime("%Y%m%d_%H%M%S")
        self.run_dir.mkdir(parents=True, exist_ok=True)

    def try_init_llm(self):
        """(Re)load LLM settings from agent config + in-game mod config. Returns True when ready."""
        if self.mock:
            self.llm = self.review_llm = MockLLM()
            return True
        self.cfg = load_config(self.config_path)
        self.game = Game(self.cfg["mod_url"], api_token=self.cfg.get("mod_api_token") or "")
        c = self.cfg.get("llm") or {}
        if not (c.get("base_url") and c.get("model") and c.get("api_key")):
            self.llm = self.review_llm = None
            return False
        self.llm = LLM(c["base_url"], c["api_key"], c["model"], c.get("temperature", 0.4), c.get("max_tokens", 800),
                       options=c.get("step_options"))
        self.review_llm = LLM(c["base_url"], c["api_key"], c.get("review_model") or c["model"], c.get("temperature", 0.4),
                              4000, timeout=300, options=c.get("review_options"))
        return True

    # ---------------- main loop ----------------

    def run(self, max_days=None, max_steps=None):
        days, steps = 0, 0
        waiting_logged = None
        while True:
            try:
                st = self.game.state()
            except GameError as e:
                if waiting_logged != "conn":
                    log(f"等待游戏… {e}")
                    waiting_logged = "conn"
                time.sleep(5)
                continue

            if not st.get("ready"):
                reason = st.get("reason")
                if reason == "title_screen":
                    self.leave_title_screen()
                    time.sleep(5)
                    continue
                if waiting_logged != reason:
                    log("请在游戏里手动选择存档进入" if reason == "title_screen" else "游戏加载/保存中…")
                    waiting_logged = reason
                time.sleep(2)
                continue

            # World is loaded: wait until the player has saved gateway/key in-game (F8)
            if not self.mock and self.llm is None:
                if self.try_init_llm():
                    log(f"已读到 LLM 配置，模型 {self.cfg['llm']['model']}，开始游玩")
                    waiting_logged = None
                else:
                    if waiting_logged != "llm":
                        log("已进入存档。请在游戏内按 F8 填写网关与 API Key 并保存——保存后我会自动继续（不会自动选档）")
                        waiting_logged = "llm"
                    time.sleep(3)
                    continue
            waiting_logged = None

            self.mem.set_save_name(st.get("save_name"))
            if self.journal is None and st.get("save_name"):
                self.journal = journal.Journal(self.cfg.get("journal_dir") or Path(self.cfg["game_path"]) / "AI游玩日志", st["save_name"])
                log(f"游玩日志：{self.journal.dir}/<{problems.calendar_folder_name()}>/")
            key = (st["year"], st["season"], st["day"])
            if key != self.day_key:
                if self.day is not None:
                    days += 1
                    self.end_day(st)
                    if max_days and days >= max_days:
                        log(f"已完成 {days} 天，停止。")
                        return
                self.start_day(key, st)

            if self.day.ended:
                time.sleep(2)  # asleep, waiting for the next morning
                continue

            self.step(st)
            steps += 1
            if max_steps and steps >= max_steps:
                log(f"已执行 {steps} 步，停止。")
                return

    def leave_title_screen(self):
        """By default do nothing: the player must pick the save. Opt in with auto_enter_save=true."""
        if not self.cfg.get("auto_enter_save"):
            if not getattr(self, "_title_wait_logged", False):
                log("在标题界面：请你手动选择存档进入游戏。代理不会自动新建或读取存档。"
                    "（若确需自动进档，在 config.json 设 \"auto_enter_save\": true 并配置 save_name 或 new_game）")
                self._title_wait_logged = True
            return
        save = self.cfg.get("save_name") or self.mem.save_name()
        saves = self.safe(lambda: self.game.saves(), {}).get("saves", [])
        if save and save in saves:
            res = self.safe(lambda: self.game.load_save(save), {})
            log(f"自动载入存档 {save}：{res.get('message')}")
        elif self.cfg.get("new_game"):
            ng = self.cfg["new_game"]
            res = self.safe(lambda: self.game.new_game(ng.get("name", "AutoPilot"), ng.get("farm", "AI"),
                                                       ng.get("favorite", "Parsnips"), ng.get("farm_type", 0)), {})
            log(f"自动创建新游戏：{res.get('message')}")
        else:
            log("auto_enter_save 已开启，但没有 save_name / new_game，仍请手动载入存档")

    # ---------------- day lifecycle ----------------

    def usage(self):
        return self.llm.calls + self.review_llm.calls, self.llm.tokens + self.review_llm.tokens

    def start_day(self, key, st):
        self.day_key = key
        self.day = DayLog(key, st, self.usage())
        log(f"===== 新的一天：第{key[0]}年 {key[1]} {key[2]} 日，{st['weather']}，金钱 {st['player']['money']}g =====")
        self.backup_save(st)
        self.ensure_farm_plan()

        # cheap morning routine, no model needed
        morning = []
        # gift boxes first: they are inside the house, and reading mail walks out to the farm
        for p in st.get("points_of_interest", []):
            if p.get("kind") == "gift_box":
                morning.append({"type": "interact", "x": p["x"], "y": p["y"]})
        if st.get("unread_mail"):
            morning.append({"type": "check_mail"})
        machines = st.get("machines") or []
        if any(m.get("ready") for m in machines):
            morning.append({"type": "collect_machines"})
        # Try loading in the morning; the execution guard suppresses empty repeats.
        if any(not m.get("contains") for m in machines):
            morning.append({"type": "load_machines"})

        prepared = self.prepared
        self.prepared = None
        if self.mode != "script":
            self.make_step_plan(st)
            self.day.script = morning
        elif prepared and prepared.get("for") == self.day.tag:
            self.day.plan = prepared["plan"]
            self.set_script(morning + prepared["script"], "昨晚准备好的脚本", st.get("location"))
        elif self.prep_thread is not None and self.prep_thread.is_alive():
            # last night's review is still running: don't stand around, do the obvious chores first
            self.day.plan = ["（脚本生成中）先做固定的早晨工作"]
            self.day.awaiting_script = True
            self.set_script(morning + [{"type": "harvest_crops"}, {"type": "water_crops"}, {"type": "ship_produce"}],
                            "固定早晨工作，等昨晚的脚本生成完", st.get("location"))
        else:
            self.day.script = morning
            self.replan(st, "新的一天开始了（没有昨晚准备的脚本）。", None)
            self.day.script = self.enforce_milestone(morning + self.day.script, self.safe(self.game.progress, {}))
            self.day.script_total = len(self.day.script)
        log("今日计划：" + " / ".join(self.day.plan))
        self.write_run("plan", {"day": self.day.tag, "plan": self.day.plan, "script": self.day.script,
                                "weather": st.get("weather"), "money": st["player"]["money"],
                                "stamina": f"{st['player']['stamina']}/{st['player']['max_stamina']}"})

    BACKUP_DIR = ROOT.parent / "save-backups"
    BACKUPS_KEPT = 7

    def backup_save(self, st):
        """Each morning the save on disk is last night's: copy it, keep the newest 7 for this save."""
        name = st.get("save_name") or self.mem.save_name()
        src = Path(os.environ.get("APPDATA", "")) / "StardewValley" / "Saves" / str(name)
        if not name or not src.is_dir():
            return
        dest = self.BACKUP_DIR / f"{name}_{self.day.tag}"
        if dest.exists():
            return
        try:
            shutil.copytree(src, dest)
            old = sorted((d for d in self.BACKUP_DIR.glob(f"{name}_Y*") if d.is_dir()), key=lambda d: d.stat().st_mtime)
            for d in old[:-self.BACKUPS_KEPT]:
                shutil.rmtree(d, ignore_errors=True)
            log(f"存档已备份：{dest.name}（保留最近 {self.BACKUPS_KEPT} 天）")
        except OSError as e:
            log(f"存档备份失败：{e}")

    def make_step_plan(self, st):
        crops = self.safe(lambda: self.game.crops("Farm"), {})
        try:
            resp = self.review_llm.chat_json([
                {"role": "system", "content": prompts.SYSTEM_PLAN},
                {"role": "user", "content": prompts.USER_PLAN.format(
                    strategy=self.mem.strategy(), lessons=self.mem.lessons(),
                    year=st["year"], season=st["season"], day=st["day"], weekday=st["weekday"],
                    weather=st["weather"], tomorrow=st.get("weather_tomorrow"), luck=st.get("luck"),
                    money=st["player"]["money"], stamina=st["player"]["stamina"], max_stamina=st["player"]["max_stamina"],
                    inventory=self.fmt_inventory(st), crops=self.fmt_crops(crops)) + "\n" + self.fmt_quests_mail(st)},
            ])
            self.day.plan = [str(p) for p in resp.get("plan", [])][:8]
        except LLMError as e:
            log(f"计划生成失败：{e}")
            self.day.plan = ["收获并浇水", "出货", "睡觉"]

    def end_day(self, st):
        d = self.day
        reviewing = self.prep_thread is not None and self.prep_thread.is_alive()
        money_now = st["player"]["money"]
        fails = [s for s in d.steps if not s["ok"]]
        calls, tokens = self.usage()
        row = {
            "date": d.tag, "money_start": d.money_start, "money_next_morning": money_now,
            "income": money_now - d.money_start, "shipped_value": d.shipped_value,
            "steps": len(d.steps), "failures": len(fails),
            "llm_calls": calls - d.llm_calls_start, "tokens": tokens - d.tokens_start,
        }
        self.mem.add_metrics(row)
        self.write_run("day_summary", {"day": d.tag, **row})
        log(f"昨日结算：收入 {row['income']:+}g，出货估值 {d.shipped_value}g，{len(d.steps)} 步，失败 {len(fails)}，"
            f"模型调用 {row['llm_calls']} 次 / {row['tokens']} tokens")
        if not d.reflected and not reviewing:  # e.g. passed out instead of going to bed
            self.reflect(d, f"金钱 {d.money_start} -> {money_now}（{row['income']:+}g，含出货收入）")
            self.sync_play_logs()

    def reflect(self, d, money_text):
        fails = [s for s in d.steps if not s["ok"]]
        types = collections.Counter(s["action"].get("type") for s in d.steps)
        last = d.steps[-1] if d.steps else None
        summary = (f"日期 {d.tag}；{money_text}；出货估值 {d.shipped_value}g；动作 {len(d.steps)} 个，失败 {len(fails)} 个；"
                   f"动作分布 {dict(types)}；最后动作时间 {last['time'] if last else '-'}；脚本重写 {d.replans} 次；"
                   f"今日计划 {d.plan}；笔记 {d.notes[-10:]}\n\n"
                   + milestones.describe(self.safe(self.game.progress, {})))
        log_lines = [self.fmt_step(s, with_thought=True) for s in d.steps[-40:]]
        fail_counts = collections.Counter(f"{s['action'].get('type')}: {s['message']}" for s in fails)
        failures = "\n".join(f"{n}x {m}" for m, n in fail_counts.most_common(15)) or "无"
        auto_problems = problems.from_failed_steps(fails)
        try:
            resp = self.review_llm.chat_json([
                {"role": "system", "content": prompts.SYSTEM_REFLECT},
                {"role": "user", "content": prompts.USER_REFLECT.format(
                    summary=summary, log="\n".join(log_lines) or "（无）", failures=failures,
                    metrics=self.mem.recent_metrics(), strategy=self.mem.strategy(), lessons=self.mem.lessons(),
                    recent_problems=problems.recent_for_prompt(self.mem.problems_path))},
            ])
            if resp.get("strategy") and len(resp["strategy"]) > 50:
                self.mem.save_strategy(resp["strategy"], d.tag)
            self.mem.add_lessons(resp.get("lessons") or [])
            day_problems = problems.merge_llm_problems(auto_problems, resp.get("problems") or [])
            d.reflected = True
            log("复盘：" + str(resp.get("analysis", ""))[:200]
                + (f"；问题 {len(day_problems)} 条" if day_problems else ""))
            # reflection first, then problems section in the same 游玩日志 file
            self.write_run("reflection", {"day": d.tag, "analysis": resp.get("analysis"),
                                          "strategy": resp.get("strategy"), "lessons": resp.get("lessons")})
            self.write_day_problems(d.tag, day_problems, analysis=str(resp.get("analysis") or ""))
        except LLMError as e:
            # still keep auto-captured failures even if the model review fails
            if auto_problems:
                self.write_day_problems(d.tag, auto_problems, analysis=f"复盘失败：{e}")
            log(f"复盘失败（策略未更新）：{e}")

    def write_day_problems(self, day_tag, entries, analysis=""):
        """Merge today's problems into the play journal (same calendar-day Markdown file)."""
        if not entries and not analysis:
            return
        # rolling file is only for tomorrow's planning prompts; human-readable copy lives in 游玩日志
        problems.append_rolling(self.mem.problems_path, day_tag, entries, analysis=analysis)
        self.write_run("problems", {
            "day": day_tag, "calendar": problems.calendar_folder_name(),
            "analysis": analysis, "problems": entries,
        })
        where = "游玩日志" if self.journal is not None else str(self.mem.problems_path)
        log(f"问题已写入{where}（{day_tag}，{len(entries)} 条）")

    # ---------------- tonight: review today + script for tomorrow (background) ----------------

    def on_went_to_sleep(self, st, crops):
        self.prep_thread = threading.Thread(target=self.prepare_next_day, args=(self.day, st, crops), daemon=True)
        self.prep_thread.start()
        log("已睡觉：后台开始复盘今天并生成明天的脚本…")

    def wiki_notes(self, progress):
        """Facts from the downloaded wiki text for the current milestone. No network."""
        cur = milestones.current(progress) if isinstance(progress, dict) else None
        return wikitext.consult([cur[0]] if cur else [])

    def sync_play_logs(self):
        """Push SMAPI and play journals after the night review. Does not start another agent."""
        script = ROOT.parent / "sync_logs.ps1"
        if not script.is_file():
            log("没有 sync_logs.ps1，跳过日志上传")
            return
        try:
            proc = subprocess.run(
                ["powershell", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(script)],
                cwd=str(ROOT.parent), capture_output=True, timeout=180)
            text = ((proc.stdout or b"") + b"\n" + (proc.stderr or b"")).decode("utf-8", "replace").strip()
            last = text.splitlines()[-1] if text else ""
            if proc.returncode == 0:
                log("今晚复盘的日志已上传" + (f"：{last}" if last else ""))
            else:
                log(f"日志上传失败：{last or proc.returncode}")
        except Exception as e:
            log(f"日志上传失败：{e}")

    def prepare_next_day(self, d, st, crops):
        try:
            self._prepare_next_day(d, st, crops)
        finally:
            self.sync_play_logs()

    def _prepare_next_day(self, d, st, crops):
        self.write_farm_map()
        self.reflect(d, f"金钱 {d.money_start} -> {st['player']['money']}（出货收入明早才到账）")
        if self.mode != "script":
            return
        year, season, day, weekday = next_date(st["year"], st["season"], st["day"])
        tag = f"Y{year}_{season}_{day:02d}"
        poi = [f"{p['kind']}@({p['x']},{p['y']}) {p['note']}" for p in st.get("points_of_interest", [])]
        progress = self.safe(self.game.progress, {})
        user = prompts.USER_SCRIPT_NEXT_DAY.format(
            strategy=self.mem.strategy(), lessons=self.mem.lessons(),
            year=year, season=season, day=day, weekday=weekday, weather=st.get("weather_tomorrow"), days_left=28 - day,
            shops=prompts.shop_status(900, weekday) + "（9:00 时）",
            max_stamina=st["player"]["max_stamina"], money=st["player"]["money"], shipped=d.shipped_value,
            inventory=self.fmt_inventory(st), crops=self.fmt_crops(crops), poi=poi or "（不在农场，未知）",
            quests=(milestones.describe(progress) + "\n\n" + cropplan.describe(self.safe(self.game.crop_data, []), season, day)
                    + "\n\n" + self.fmt_quests_mail(st) + "\n" + self.fmt_recipes() + "\n" + self.fmt_social(st, include_all=True)
                    + "\n" + self.fmt_bundles(st, detail=True) + "\n" + self.fmt_ranch()),
            today="\n".join(self.fmt_step(s) for s in d.steps[-15:]) or "（无）",
            recent_problems=problems.recent_for_prompt(self.mem.problems_path),
            wiki=self.wiki_notes(progress))
        try:
            resp = self.review_llm.chat_json([
                {"role": "system", "content": prompts.SYSTEM_SCRIPT.format(actions=prompts.ACTIONS_DOC, roadmap=prompts.ROADMAP)},
                {"role": "user", "content": user}])
            bundles = self.safe(self.game.bundles, {})
            need = needs.immediate(progress, st, bundles, festival_in_days=1)
            script = self.enforce_milestone(self.clean_script(resp.get("script")), progress, need)
            if script:
                self.prepared = {"for": tag, "plan": [str(p) for p in resp.get("plan", [])][:8], "script": script}
                log(f"明天（{tag}）的脚本已准备好：{len(script)} 个动作")
                self.write_run("prepared_script", {"day": tag, **self.prepared})
        except LLMError as e:
            log(f"明日脚本生成失败（明早再生成）：{e}")

    # ---------------- scripts ----------------

    @staticmethod
    def enforce_milestone(script, progress, need=None):
        """Do what the game is asking for, then the current milestone if the script ignored it."""
        if not script:
            return script
        script = Agent._inject(script, need)
        cur = milestones.current(progress)
        if not cur:
            return script
        name, info = cur
        script = Agent._inject(script, {"name": name, "step": info.get("step") or [], "advances": info.get("advances") or set(), "at": "before_sleep"})
        return script

    @staticmethod
    def _inject(script, need):
        if not need or not need.get("step") or any(a.get("type") in need.get("advances", ()) for a in script):
            return script
        steps = [dict(a) for a in need["step"]]
        log(f"游戏要求「{need.get('name')}」：脚本里没有，加入 " + " → ".join(a["type"] for a in steps))
        if need.get("at") == "start":
            return steps + script
        idx = len(script)
        for i in range(len(script) - 1, -1, -1):
            if script[i].get("type") == "sleep" or (script[i].get("type") == "goto_location" and script[i].get("location") in ("Farm", "FarmHouse")):
                idx = i
            else:
                break
        return script[:idx] + steps + script[idx:]

    KNOWN_ACTIONS = actions.KNOWN_ACTIONS

    def clean_script(self, script):
        if not isinstance(script, list):
            return []
        # dialog_advance is dropped: the mod advances plain dialogue itself, so a scripted one only ever fails
        out = [a for a in script if isinstance(a, dict) and a.get("type") in self.KNOWN_ACTIONS and a.get("type") != "dialog_advance"]
        # Collapse consecutive load_machines (models love to spam them) to a single call.
        cleaned = []
        for a in out:
            if a.get("type") == "load_machines" and cleaned and cleaned[-1].get("type") == "load_machines":
                continue
            cleaned.append(a)
        return cleaned[:30]

    def drop_pending(self, action_type, item=None):
        """Remove remaining same-type spam from today's script (e.g. empty load_machines loops)."""
        if not self.day or not self.day.script:
            return
        before = len(self.day.script)

        def keep(a):
            if a.get("type") != action_type:
                return True
            if item and str(a.get("item", "")).lower() != item.lower():
                return True
            return False

        self.day.script = [a for a in self.day.script if keep(a)]
        dropped = before - len(self.day.script)
        if dropped:
            log(f"去掉脚本里后续 {dropped} 个空转的 {action_type}")

    HOME = ("Farm", "FarmHouse")
    # actions that only make sense on the farm: done on the evening return instead of walking back mid-day
    FARM_ONLY = {"water_crops", "harvest_crops", "plant_seeds", "store_items", "ship_produce", "clear_area", "build",
                 "care_animals", "load_machines", "collect_machines", "cook"}

    def normalize_route(self, script, start):
        """Enforce the day's route: every map is visited once, in first-visit order (home in the morning and once
        more in the evening). Removes the Farm <-> Town back-and-forth the model tends to write."""
        home = lambda loc: "Farm" if loc in self.HOME else loc
        segments = [[home(start or "Farm"), []]]
        sleep = None
        for a in script:
            t = a.get("type")
            if t == "sleep":
                sleep = a
            elif t == "goto_location":
                segments.append([home(a.get("location")), [a]])
            elif t == "mine":
                segments.append(["Mine", [a]])
            else:
                segments[-1][1].append(a)
        morning, evening, order, visits = [], [], {}, {}
        for i, (loc, acts) in enumerate(segments):
            visits[loc] = visits.get(loc, 0) + 1
            if loc != "Farm":
                evening += [a for a in acts if a.get("type") in self.FARM_ONLY]
                acts = [a for a in acts if a.get("type") not in self.FARM_ONLY]
            if loc == "Farm":
                (morning if i == 0 else evening).extend(a for a in acts if a.get("type") != "goto_location")
            elif loc in order:
                order[loc].extend(a for a in acts if a.get("type") != "goto_location")
            else:
                order[loc] = acts
        route = list(morning)
        for acts in order.values():
            route += acts
        if evening or sleep:
            if order:
                route.append({"type": "goto_location", "location": "Farm"})
            route += evening + ([sleep] if sleep else [])
        repeats = sum(n - 1 for loc, n in visits.items() if loc != "Farm") + max(0, visits.get("Farm", 0) - 2)
        if repeats:
            log(f"路线整理：删掉 {repeats} 次重复往返（每个地图一天只去一次，农场早晚各一次）")
        return route

    def set_script(self, script, source, start=None):
        self.day.script = self.normalize_route(list(script), start)
        self.day.script_total = len(self.day.script)
        log(f"脚本（{source}）：" + " → ".join(a["type"] for a in self.day.script))
        if not source.startswith("昨晚"):
            self.write_run("script", {"day": self.day.tag, "source": source, "script": self.day.script})

    def replan(self, st, reason, failed):
        """Ask the model to (re)write the rest of today's script. Returns True if a script was produced."""
        if self.day.replans >= self.cfg.get("max_replans_per_day", 3):
            log(f"今天已重写 {self.day.replans} 次（上限）：跳过失败的动作，继续执行原脚本")
            return False
        self.day.replans += 1
        failed_txt = "（无）"
        if failed:
            action, res = failed
            failed_txt = f"{json.dumps(action, ensure_ascii=False)} -> {res.get('message')}"
            if res.get("game_messages"):
                failed_txt += " | 游戏消息: " + " / ".join(res["game_messages"])
        remaining = json.dumps(self.day.script, ensure_ascii=False) if self.day.script else "（无）"
        try:
            resp = self.llm.chat_json([
                {"role": "system", "content": prompts.SYSTEM_SCRIPT.format(actions=prompts.ACTIONS_DOC, roadmap=prompts.ROADMAP)},
                {"role": "user", "content": prompts.USER_SCRIPT_REPAIR.format(
                    reason=reason, strategy=self.mem.strategy(), lessons=self.mem.lessons(),
                    failed=failed_txt, remaining=remaining, observation=self.observation(st),
                    wiki=wikitext.consult([failed_txt, reason]))},
            ], max_tokens=2500)
        except LLMError as e:
            log(f"重写脚本失败：{e}")
            return False
        progress = self.safe(self.game.progress, {})
        script = self.enforce_milestone(self.clean_script(resp.get("script")), progress)
        if resp.get("plan"):
            self.day.plan = [str(p) for p in resp["plan"]][:8]
        self.set_script(script, f"重写#{self.day.replans}：{resp.get('reason', '')}"[:80], st.get("location"))
        return bool(script)

    # ---------------- one step ----------------

    def guardrail(self, st):
        t = st["time"]
        menu = st.get("menu")
        if menu:
            return None  # let the model handle open menus/questions
        if t >= 2400:
            return {"type": "sleep"}, "规则：已过午夜，立即睡觉"
        if len(self.day.steps) >= self.cfg["max_steps_per_day"]:
            return {"type": "sleep"}, "规则：今日步数已达上限"
        return None

    MAX_ACTIONS_PER_CALL = 3

    NIGHT_MENUS = ("ShippingMenu", "SaveGameMenu", "LevelUpMenu")

    def step(self, st):
        if st.get("busy_action"):
            time.sleep(1)  # a timed-out HTTP call may still be executing in the mod
            return
        menu = (st.get("menu") or {}).get("type")
        if menu in self.NIGHT_MENUS and not (st.get("menu") or {}).get("is_profession_chooser"):
            time.sleep(2)  # end-of-night screens save the game; the mod confirms them, never close them
            return
        if self.day.awaiting_script and self.prepared and self.prepared.get("for") == self.day.tag:
            self.day.awaiting_script = False
            self.day.plan = self.prepared["plan"]
            self.set_script(self.day.script + self.prepared["script"], "昨晚准备好的脚本（刚生成完）", st.get("location"))
            self.prepared = None
            self.prep_thread = None
        elif self.day.awaiting_script and self.prep_thread is not None and not self.prep_thread.is_alive():
            self.day.awaiting_script = False  # generation failed; the normal re-plan path takes over
        forced = self.guardrail(st)
        if forced:
            action, thought = forced
            self.record(st, thought, action, self.execute(st, action, forced=True))
            if not self.day.ended:
                time.sleep(5)  # forced sleep failed (e.g. can't reach the bed): don't spin
            return
        recent = self.day.steps[-20:]
        if len(recent) == 20 and not any(s["ok"] for s in recent):
            log("连续 20 个动作失败，暂停 10 秒再试")
            time.sleep(10)
        if self.mod_handles(st.get("menu")) and self.auto_menu_waits < 20:
            self.auto_menu_waits += 1
            time.sleep(0.5)  # the mod advances plain dialogue and collects reward pop-ups on its own
            return
        self.auto_menu_waits = 0
        if st.get("menu"):
            self.llm_step(st)  # menus/questions need a decision
            return
        if not self.day.script and self.day.awaiting_script and self.prep_thread is not None:
            self.prep_thread.join(timeout=30)
            return
        if not self.day.script and self.mode == "script" and not self.day.awaiting_script:
            log("脚本执行完：回农场，按固定规则填满时间再睡觉（不叫模型、不乱跑）")
            self.set_script([{"type": "sleep"}], "收尾", st.get("location"))
        if not self.day.script:
            self.llm_step(st)
            return

        action = self.day.script.pop(0)
        if action.get("type") == "sleep" and self.mode == "script" and self.too_early_to_sleep(st):
            self.day.script.insert(0, action)
            action = self.time_filler(st)
            res = self.execute(st, action)
            self.record(st, "(脚本做完了，到 17:00 前固定做这个，不换地图)", action, res)
            if not res.get("ok") and action["type"] == "fish":
                self.day.fish_failed = True
            if action["type"] == "fish":
                caught = res.get("caught") or []
                if caught and all(c in self.JUNK for c in caught):
                    self.day.junk_fishing += 1
                    if self.day.junk_fishing >= 2:
                        log("这里钓上来的全是垃圾：今天不再在这里钓鱼")
                        self.day.fish_failed = True
                self.dump_junk(self.safe(self.game.state, st))
            return
        n = self.day.script_total - len(self.day.script)
        res = self.execute(st, action)
        self.record(st, f"(脚本 {n}/{self.day.script_total})", action, res)
        if res.get("status") in ("AGENT_UNAVAILABLE", "CIRCUIT_OPEN"):
            return  # transport failures and suppressed work must not trigger a repair loop
        if action["type"] == "craft" and not res.get("ok"):
            item = str(action.get("item") or "")
            msg = str(res.get("message", "")).lower()
            if item and ("ingredient" in msg or "not enough" in msg):
                self.day.craft_blocked.add(item.lower())
                self.drop_pending("craft", item=item)
        if not res.get("ok") and self.is_minor_failure(action):
            return  # chatting/foraging/clearing that didn't pan out: just move on to the next scripted action
        if not res.get("ok") and not self.day.ended and self.mode == "script":
            fresh = self.safe(self.game.state, st)
            if fresh.get("ready") and not fresh.get("menu"):
                self.replan(fresh, "脚本里的上一个动作失败了。", (action, res))

    JUNK = ("Trash", "Driftwood", "Soggy Newspaper", "Broken CD", "Broken Glasses", "Joja Cola", "Rotten Plant")

    def dump_junk(self, st):
        """Fishing junk fills the backpack: when it's nearly full, put the junk in the shipping bin (0g, but frees slots)."""
        if st.get("inventory_free_slots", 99) > 2:
            return
        for it in st.get("inventory", []):
            if it and it.get("name") in self.JUNK:
                self.act_and_record(st, {"type": "ship", "item": it["name"], "count": it.get("stack", 1)}, "(背包快满：钓到的垃圾扔进出货箱)")

    @staticmethod
    def mod_handles(menu):
        if not menu:
            return False
        return (menu.get("type") == "DialogueBox" and not menu.get("is_question")) or menu.get("type") == "ItemGrabMenu" and not menu.get("chest")

    @staticmethod
    def too_early_to_sleep(st):
        p = st.get("player", {})
        tired = p.get("stamina", 0) < 0.2 * p.get("max_stamina", 270) or p.get("health", 100) <= 10
        return st.get("time", 0) < 1700 and not tired

    def time_filler(self, st):
        """Fixed, model-free way to use the rest of the afternoon where the player already is."""
        p = st.get("player", {})
        machines = st.get("machines") or []
        eligible = lambda kind: not self.day.execution_guard.blocked(st, {"type": kind})
        if any(m.get("ready") for m in machines) and eligible("collect_machines"):
            return {"type": "collect_machines"}
        if eligible("load_machines") and any(not m.get("contains") for m in machines):
            return {"type": "load_machines"}
        if eligible("build_road") and self.farm_plan() and p.get("stamina", 0) >= 0.3 * p.get("max_stamina", 270):
            return {"type": "build_road"}
        if eligible("decorate") and self.farm_plan():
            return {"type": "decorate"}
        if not self.day.fish_failed and p.get("stamina", 0) >= 0.35 * p.get("max_stamina", 270):
            return {"type": "fish", "casts": 3}
        t = st.get("time", 0)
        minutes = (17 * 60) - (t // 100 * 60 + t % 100)
        return {"type": "wait", "minutes": max(10, min(minutes, 120)), "filler": True}

    @staticmethod
    def is_minor_failure(action):
        """Failures that don't invalidate the rest of the day's plan.

        upgrade_tool / buy_weapon are NOT minor: a soft skip left copper tools and Silver Saber stuck for days.
        load_machines empty-fail IS minor; the execution guard prevents empty repeats.
        """
        t = action.get("type")
        return (t == "interact" and "npc" in action) or t in (
            "forage", "clear_debris", "fight", "collect_machines", "care_animals",
            "buy_backpack", "place", "load_machines", "build_road", "decorate", "festival",
        )

    def llm_step(self, st):
        try:
            resp = self.llm.chat_json([
                {"role": "system", "content": self.system_prompt()},
                {"role": "user", "content": self.observation(st)},
            ])
        except LLMError as e:
            log(f"LLM 错误：{e}")
            time.sleep(10)
            return
        raw = resp.get("actions")
        if not isinstance(raw, list):
            raw = [resp.get("action")]
        actions = [a for a in raw if isinstance(a, dict) and a.get("type")][:self.MAX_ACTIONS_PER_CALL]
        thought = str(resp.get("thought", ""))
        note = resp.get("note")
        if not actions:
            self.record(st, thought, {"type": "invalid"}, {"ok": False, "message": f"模型输出无效: {str(resp)[:200]}"})
            return
        if note:
            self.day.notes.append(str(note)[:200])

        # run the batch in order; stop at the first failure or when the situation changes (menu/day end)
        for i, action in enumerate(actions):
            if i > 0:
                st = self.safe(self.game.state, {})
                if not st.get("ready") or st.get("menu") or self.guardrail(st):
                    break
            res = self.execute(st, action)
            self.record(st, thought if i == 0 else f"(续{i + 1})", action, res)
            if not res.get("ok") or self.day.ended:
                break

    def execute(self, st, action, forced=False):
        guard = self.day.execution_guard
        if guard.blocked(st, action):
            return {"ok": False, "status": "CIRCUIT_OPEN",
                    "message": "repeated ineffective action suppressed until game state changes"}
        try:
            res = self._execute(st, action, forced)
        except GameError as e:
            res = {"ok": False, "status": "AGENT_UNAVAILABLE", "message": str(e)}
        res.setdefault("status", "SUCCESS" if res.get("ok") else "ACTION_FAILED")
        if guard.observe(st, action, res):
            res = {**res, "ok": False, "status": "NO_PROGRESS"}
        if res.get("ok") and action.get("type") in ("craft", "take", "store", "store_items", "place", "build"):
            guard.invalidate()  # these can change chest contents or the farm layout
        return res

    def _execute(self, st, action, forced=False):
        t = action.get("type")
        if t == "sleep":
            if self.no_save:
                return {"ok": False, "message": "测试模式(--no-save)：禁止睡觉，以免保存存档。请做别的事。"}
            p = st.get("player", {})
            # refuse an early bedtime once per day (nudges toward useful work); if the model insists after re-planning, allow it
            tired = p.get("stamina", 0) < 0.2 * p.get("max_stamina", 270) or p.get("health", 100) <= 10
            early = st.get("time", 0) < 1500 or (st.get("time", 0) < 1700 and not self.day.early_sleep_refused)
            if early and not tired and not forced:
                self.day.early_sleep_refused = True
                return {"ok": False, "message": "规则：体力还多，15:00 前不能睡觉（15-17 点只提醒一次）。可以用 clear_debris（不填 x,y 自动找最近杂物）、或做不耗体力的事："
                                                "和村民打招呼(interact npc)推进任务、forage 采集、check_mail、去别的地图探索、去商店看看货。"}
        if t == "wait" and action.get("filler"):
            action = {"type": "wait", "minutes": action["minutes"]}
        elif t == "wait":
            action = self.rewrite_wait(st, action)
            t = action.get("type")

        # Shop / guild / blacksmith: wait until open instead of cascading locked-door failures.
        gated = self.defer_until_open(st, action)
        if gated is not None:
            return gated

        if t == "mine":
            lim = self.mem.mine_limit(abs_day(st))
            if lim:
                action = {**action, "max_floor": min(lim["floor"], int(action.get("max_floor", 120)))}
        if t == "store_items":
            return self.store_items(st, action)
        if t in ("harvest_crops", "forage") and st.get("inventory_free_slots", 99) <= 1 and st.get("location") in self.HOME:
            res = self.store_items(st, {"type": "store_items"})
            self.record(st, "(背包快满，先存进箱子)", {"type": "store_items"}, res)
            st = self.safe(self.game.state, st)
        on_farm = st.get("location") in self.HOME
        planted = any(k in str(action.get("item", "")).lower() for k in self.HAND_PLACED)
        if self.farm_plan() and on_farm and t in ("place", "build") and "x" in action and not planted:
            log(f"{t}：忽略模型给的坐标，按农场分区放置")
            action = {k: v for k, v in action.items() if k not in ("x", "y")}

        # take: never trust model chest coords (journals kept hitting empty (74,15)); mod scans all farm chests.
        if t == "take" and ("x" in action or "y" in action):
            log(f"take：去掉错误箱子坐标 ({action.get('x')},{action.get('y')})，改扫全部农场箱子")
            action = {k: v for k, v in action.items() if k not in ("x", "y")}

        # craft: don't spam items that already failed for lack of materials today
        if t == "craft":
            item = str(action.get("item") or "")
            if item.lower() in self.day.craft_blocked:
                return {"ok": False, "message": f"already failed crafting {item} today (not enough ingredients); gather materials first (clear_debris / mine)"}
            if "scarecrow" in item.lower() or item == "Scarecrow":
                prog = self.safe(self.game.progress, {})
                mats = prog.get("materials") or {}
                need = {"Wood": 50, "Coal": 1, "Fiber": 20}
                short = [f"{k} need {v}, have {mats.get(k, 0)}" for k, v in need.items() if mats.get(k, 0) < v]
                if short:
                    self.day.craft_blocked.add(item.lower())
                    return {"ok": False, "message": "can't craft Scarecrow yet: " + "; ".join(short)}

        if t == "craft" and "x" in action and self.farm_plan() and on_farm and "chest" not in str(action.get("item", "")).lower():
            res = self.act_and_record(st, {k: v for k, v in action.items() if k not in ("x", "y")}, "(先做出来，再按分区摆放)")
            if not res.get("ok"):
                return res
            st = self.safe(self.game.state, st)
            action, t = {"type": "place", "item": action.get("item", "")}, "place"

        # NPC interact: shopkeepers must use dedicated actions (chatting never upgrades tools / buys weapons).
        if t == "interact" and action.get("npc"):
            npc = str(action["npc"])
            key = npc.lower()
            if key in ("clint",):
                prog = self.safe(self.game.progress, {})
                up = prog.get("upgrading") or {}
                tools = prog.get("tools") or {}
                if up and up.get("days_left", 1) <= 0:
                    action, t = {"type": "upgrade_tool"}, "upgrade_tool"  # collect finished tool
                else:
                    tool = action.get("tool") or ("axe" if tools.get("axe", 0) < 1 else "pickaxe")
                    action, t = {"type": "upgrade_tool", "tool": tool}, "upgrade_tool"
                log(f"interact Clint → {action}（闲聊不能升级工具）")
                return self.execute(st, action, forced)
            elif key in ("marlon",):
                log("interact Marlon → buy_weapon")
                action, t = {"type": "buy_weapon"}, "buy_weapon"
                return self.execute(st, action, forced)
            elif key in ("pierre",) and action.get("intent") == "backpack":
                action, t = {"type": "buy_backpack"}, "buy_backpack"

        if t == "dialog_answer" and st.get("location") == "Blacksmith":
            log("铁匠铺对话不能升级工具：关掉菜单，改用 upgrade_tool")
            try:
                self.game.act({"type": "close_menu"})
            except GameError:
                pass
            return {"ok": False, "message": "chatting with Clint does not upgrade tools; use upgrade_tool (axe/pickaxe) after 9:00"}

        if t == "interact" and "x" in action and "npc" not in action:
            m = next((m for m in st.get("machines") or [] if (m["x"], m["y"]) == (action["x"], action["y"])), None)
            if m:
                action = {"type": "collect_machines"} if m.get("ready") else {"type": "load_machines"}
                t = action["type"]
                log(f"interact {m['name']} → 改成 {t}（机器要用 load_machines / collect_machines）")
                return self.execute(st, action, forced)
        if t == "build_road":
            return self.build_road(st)
        if t == "decorate":
            return self.decorate(st)
        if t == "build" and "x" not in action:
            site = self.building_site(st, action.get("building", ""))
            if not site:
                return {"ok": False, "message": "规划的分区里找不到整齐的建筑位置（分区里的树/大石头要先用升级过的工具清掉）"}
            x, y, w, h, debris = site
            if debris:
                res = self.act_and_record(st, {"type": "clear_area", "area": {"x": x, "y": y, "w": w, "h": h + 1}},
                                          f"(先清理建筑地基上的 {debris} 个杂物)")
                if not res.get("ok"):
                    return res
                st = self.safe(self.game.state, st)
            action = {**action, "x": x, "y": y}
        if t == "place" and "x" not in action and st.get("location") == "Farm" and not planted:
            item_name = str(action.get("item") or "")
            if item_name.lower() in self.day.place_blocked:
                return {"ok": False, "message": f"{item_name} 今天已确认分区无空位"}
            spot = self.tidy_spot(st, item_name)
            if spot:
                action = {**action, "x": spot[0], "y": spot[1]}
            elif self.farm_plan():
                self.day.place_blocked.add(item_name.lower())
                return {"ok": False, "message": f"{item_name} 在规划的分区里没有空位了（不在分区外乱放）"}
        if t == "clear_debris" and "x" in action and (action.get("x"), action.get("y")) in self.day.empty_debris_spots:
            action = {k: v for k, v in action.items() if k not in ("x", "y")}
        if t == "plant_seeds" and self.farm_plan() and on_farm:
            action = {k: v for k, v in action.items() if k not in ("x", "y", "plot")}
        if t == "plant_seeds" and not action.get("plot") and st.get("location") == "Farm":
            plot = self.ensure_plot(st)
            if plot:
                action = {k: v for k, v in action.items() if k not in ("x", "y")}
                action["plot"] = {k: plot[k] for k in ("x", "y", "w", "h")}
        crops = self.safe(lambda: self.game.crops("Farm"), {}) if t == "sleep" else None
        claimed = (action.get("x"), action.get("y")) if t == "place" and "x" in action else None
        try:
            res = self.game.act(action)
        except GameError as e:
            res = {"ok": False, "status": "AGENT_UNAVAILABLE", "message": str(e)}
        # Roll back ghost occupancy so tomorrow (and later today) can reuse the tile.
        if t == "place" and not res.get("ok") and claimed and claimed[0] is not None:
            self.unclaim_spot(claimed)
            if "没有空位" in str(res.get("message", "")) or "occupied" in str(res.get("message", "")).lower():
                self.day.place_blocked.add(str(action.get("item") or "").lower())
        if t == "sleep" and res.get("ok"):
            self.day.ended = True
            self.on_went_to_sleep(st, crops)
        if t == "clear_debris" and res.get("ok") and not res.get("cleared") and "x" in action:
            self.day.empty_debris_spots.add((action.get("x"), action.get("y")))
        if t == "build" and res.get("ok"):
            layout = self.mem.layout()
            layout.setdefault("buildings", []).append({"type": action.get("building"), "x": action["x"], "y": action["y"]})
            self.mem.save_layout(layout)
        if t in ("mine", "fight") and not res.get("ok"):
            self.check_knocked_out(st, res)
        if t in ("ship_produce", "ship") and res.get("ok"):
            self.day.shipped_value += int(res.get("value", 0) or 0)
        return res

    @staticmethod
    def load_failure_blocks_filler(message):
        """True only when nothing on the farm can be processed, not when a furnace is still busy.

        A busy furnace used to latch the whole day, so Iron Ore never went in after the copper bar finished.
        """
        msg = str(message or "").lower()
        if "busy" in msg or "when they finish" in msg:
            return False
        return "no empty machine accepts anything" in msg or "no machines" in msg

    # Locations the agent commonly visits for shopping; values are open time in military hours.
    SHOP_OPEN = {loc: start for _, loc, start, _, _ in prompts.SHOP_HOURS}
    SHOP_OPEN.update({"AdventureGuild": 1400, "Saloon": 1200, "Blacksmith": 900, "SeedShop": 900})

    def defer_until_open(self, st, action):
        """If the next shop trip is before opening time, wait (and re-queue the action) instead of failing the chain."""
        t = action.get("type")
        target = None
        if t == "goto_location":
            target = action.get("location")
        elif t == "open_shop":
            sid = action.get("shop_id")
            target = next((loc for shop_id, loc, *_ in prompts.SHOP_HOURS if shop_id == sid), st.get("location"))
        elif t == "buy_weapon":
            target = "AdventureGuild"
        elif t == "upgrade_tool" or t == "buy_backpack":
            target = "Blacksmith" if t == "upgrade_tool" else "SeedShop"
        elif t == "buy":
            # buy with no open menu usually means we jumped the gun; if we're standing at a known shop before open, wait
            target = st.get("location") if st.get("location") in self.SHOP_OPEN else None
        if not target or target not in self.SHOP_OPEN:
            return None
        opens = self.SHOP_OPEN[target]
        now = st.get("time", 0)
        if now >= opens:
            return None
        minutes = (opens // 100 * 60 + opens % 100) - (now // 100 * 60 + now % 100)
        minutes = max(10, min(minutes, 120))
        log(f"{target} {opens // 100}:00 才开门（现在 {now // 100}:{now % 100:02d}）：先等 {minutes} 分钟，再执行 {t}")
        if self.day and self.day.script is not None:
            self.day.script.insert(0, action)
        wait = {"type": "wait", "minutes": minutes}
        try:
            res = self.game.act(wait)
        except GameError as e:
            res = {"ok": False, "status": "AGENT_UNAVAILABLE", "message": str(e)}
        if res.get("ok"):
            res = {**res, "message": (res.get("message") or "") + f" (waiting for {target} to open at {opens // 100}:00)"}
        return res

    def check_knocked_out(self, st, res):
        """Passing out in the mine costs money and items: cap the depth 10 floors shallower for 3 days."""
        msg = str(res.get("message", ""))
        after = self.safe(self.game.state, {})
        if "knocked out" not in msg and after.get("location") != "Hospital":
            return
        m = re.search(r"floor (\d+)", msg)
        floor = int(m.group(1)) if m else 40
        cap = max(5, (floor - 10) // 5 * 5)
        self.mem.set_mine_limit(cap, abs_day(st) + 3)
        note = f"在矿洞第 {floor} 层被打倒（损失金钱和物品）：之后 3 天最多只下到第 {cap} 层，先准备更好的武器和食物"
        self.day.notes.append(note)
        log(note)

    def record(self, st, thought, action, res):
        msg = str(res.get("message", ""))
        if res.get("game_messages"):
            msg += " | 游戏消息: " + " / ".join(res["game_messages"])
        entry = {"time": st.get("time"), "location": st.get("location"), "thought": thought, "action": action,
                 "ok": bool(res.get("ok")), "message": msg[:400],
                 "status": res.get("status", "SUCCESS" if res.get("ok") else "ACTION_FAILED")}
        self.day.steps.append(entry)
        self.write_run("step", {"day": self.day.tag, **entry, "result": res})
        log(("✓ " if entry["ok"] else "✗ ") + self.fmt_step(entry, with_thought=True))
        if entry["ok"]:
            self.restart_declined = False
        elif self.day is not None and res.get("status") not in ("AGENT_UNAVAILABLE", "CIRCUIT_OPEN"):
            self.consider_restart(st)
        if self.status:
            self.status.refresh(self, self.safe(self.game.state, st))

    def consider_restart(self, st):
        """The model configured in-game decides. A no is remembered until something succeeds."""
        if self.mock or self.llm is None or self.restart_declined:
            return
        self.cfg = load_config(self.config_path)
        if not self.cfg.get("llm_decides_restart", True):
            return
        stamp = Path(os.environ.get("TEMP", ".")) / "stardew-restart-at.txt"
        try:
            if restart_decision.cooldown_active(stamp.read_text(encoding="utf-8")):
                return
        except OSError:
            pass
        steps = self.day.steps
        if not restart_decision.wedged(steps):
            return
        try:
            reply = self.llm.chat_json([
                {"role": "system", "content": restart_decision.DECIDE_SYSTEM},
                {"role": "user", "content": restart_decision.decision_prompt(steps)},
            ])
        except LLMError as e:
            log(f"重启判断失败：{e}")
            return
        if not restart_decision.wants_restart(reply):
            self.restart_declined = True
            log("模型决定不重启：" + str(reply.get("reason", ""))[:120])
            return
        save = st.get("save_name") or "AI_453272148"
        log("模型决定重启游戏：" + str(reply.get("reason", ""))[:120] + f"（读回存档 {save}）")
        self.launch_restart(save)

    def launch_restart(self, save_name):
        script = str(ROOT.parent / "restart_game.ps1")
        command = (
            "powershell.exe -NoProfile -ExecutionPolicy Bypass -File "
            f"\"{script}\" -SaveName {save_name} -AgentPid {os.getpid()}"
        )
        subprocess.run(
            ["powershell", "-NoProfile", "-Command",
             "Invoke-CimMethod -ClassName Win32_Process -MethodName Create -Arguments "
             f"@{{ CommandLine = '{command}'; CurrentDirectory = '{ROOT.parent}' }} | Out-Null"],
            timeout=30,
        )
        os._exit(0)

    SHOP_LOCATIONS = {loc: (shop_id, start) for shop_id, loc, start, _, _ in prompts.SHOP_HOURS}

    def rewrite_wait(self, st, action):
        """Standing still looks like the AI is stuck. Only wait for a shop that opens soon; otherwise do useful work."""
        nxt = self.day.script[0] if self.day and self.day.script else {}
        target = nxt.get("location") if nxt.get("type") == "goto_location" else None
        if nxt.get("type") in ("open_shop", "buy"):
            target = st.get("location")
        if target in self.SHOP_LOCATIONS:
            opens = self.SHOP_LOCATIONS[target][1]
            if st["time"] < opens:
                minutes = (opens // 100 * 60 + opens % 100) - (st["time"] // 100 * 60 + st["time"] % 100)
                return {"type": "wait", "minutes": max(10, min(minutes, 120))}
        if st["player"]["stamina"] >= 40:
            log("把 wait 改成清理最近的杂物（不原地发呆）")
            return {"type": "clear_debris", "max": 10}
        log("体力不足：把 wait 改成采集")
        return {"type": "forage"}

    # ---------------- storage & tidy placement ----------------

    def act_and_record(self, st, action, thought):
        try:
            res = self.game.act(action)
        except GameError as e:
            res = {"ok": False, "status": "AGENT_UNAVAILABLE", "message": str(e)}
        self.record(st, thought, action, res)
        return res

    def store_items(self, st, action):
        """Put materials into a chest; craft and place a chest in the storage row first if the farm has none."""
        items = action.get("items") or []
        if st.get("location") != "Farm":
            res = self.act_and_record(st, {"type": "goto_location", "location": "Farm"}, "(去农场的箱子)")
            if not res.get("ok"):
                return res
            st = self.safe(self.game.state, st)
        chests = [p for p in st.get("points_of_interest", []) if p.get("kind") == "chest"]
        if not chests:
            spot = self.tidy_spot(st, "Chest")
            if not spot:
                return {"ok": False, "message": "找不到放箱子的整齐位置"}
            has_chest = any(it["id"] == "(BC)130" for it in st.get("inventory", []))
            if has_chest:
                res = self.act_and_record(st, {"type": "place", "item": "Chest", "x": spot[0], "y": spot[1]}, "(把箱子放进整齐的存储排)")
            else:
                # craft straight onto the ground: works even when the backpack is full
                res = self.act_and_record(st, {"type": "craft", "item": "Chest", "x": spot[0], "y": spot[1]},
                                          "(农场还没有箱子：直接做一个放进存储排)")
            if not res.get("ok"):
                layout = self.mem.layout()
                layout["placed"] = [p for p in layout.get("placed", []) if tuple(p) != tuple(spot)]
                self.mem.save_layout(layout)
                return {"ok": False, "message": "没有箱子，也做不了（需要 50 木材）：" + str(res.get("message"))}
            target = spot
        else:
            target = None
        store = {"type": "store", "items": items}
        if target:
            store.update({"x": target[0], "y": target[1]})
        return self.game.act(store)

    def tidy_spot(self, st, item_name):
        """Where a placeable goes so the farm stays tidy: chests etc. in one row by the shipping bin,
        scarecrows centered in the walkway above a crop plot."""
        layout = self.mem.layout()
        taken = {tuple(p) for p in layout.get("placed", [])}
        name = item_name.lower()
        plan = layout.get("plan")
        if plan and not ("chest" in name or "箱" in name or "scarecrow" in name or "sprinkler" in name):
            zones = plan.get("zones", {})
            if "lamp" in name or "torch" in name:
                candidates = [tuple(t) for t in plan.get("lamps", [])]
            elif "sapling" in name or "树苗" in name:
                candidates = farmplan.orchard_slots(zones["orchard"]) if "orchard" in zones else []
            else:  # machines, bee houses, kegs...: the hidden workshop corner
                candidates = farmplan.workshop_slots(zones["workshop"])[1] if "workshop" in zones else []
            for spot in candidates:
                if spot not in taken and self.placeable(spot):
                    return self.claim_spot(layout, spot)
            return None
        if "sprinkler" in name or "洒水器" in name:
            for plot in layout.get("plots", []):
                for dx, dy in ((1, 1), (4, 1), (2, 3), (5, 3)):
                    spot = (plot["x"] + dx, plot["y"] + dy)
                    if dx < plot["w"] and dy < plot["h"] and spot not in taken and self.placeable(spot):
                        return self.claim_spot(layout, spot)
            return None
        if "scarecrow" in name or "稻草人" in name:
            zone = (layout.get("plan") or {}).get("zones", {}).get("crops")
            candidates = []
            for plot in layout.get("plots", []):
                mid_x, mid_y = plot["x"] + plot["w"] // 2, plot["y"] + plot["h"] // 2
                # Prefer walkways beside/between plots (not inside crop tiles). More candidates than before —
                # journals showed "分区没有空位" after a few ghost claims ate the 4 edge spots.
                candidates.extend([
                    (plot["x"] + plot["w"], mid_y), (plot["x"] - 1, mid_y),
                    (mid_x, plot["y"] + plot["h"]), (mid_x, plot["y"] - 1),
                    (plot["x"] + plot["w"], plot["y"]), (plot["x"] + plot["w"], plot["y"] + plot["h"] - 1),
                    (plot["x"] - 1, plot["y"]), (plot["x"] - 1, plot["y"] + plot["h"] - 1),
                    (plot["x"] + plot["w"] + 1, mid_y), (plot["x"] - 2, mid_y),
                ])
            for spot in candidates:
                inside = not zone or (zone[0] <= spot[0] < zone[0] + zone[2] and zone[1] <= spot[1] < zone[1] + zone[3])
                if inside and spot not in taken and self.placeable(spot):
                    return self.claim_spot(layout, spot)
            return None
        bin_xy = st.get("shipping_bin")
        if not bin_xy:
            return None
        start = layout.get("storage_row") or [bin_xy[0] + 3, bin_xy[1] + 1]
        layout["storage_row"] = start
        for i in range(12):
            spot = (start[0] + i, start[1])
            if spot in taken or self.in_plot(layout, spot):
                continue
            if self.placeable(spot):
                return self.claim_spot(layout, spot)
        # the row by the bin is blocked: start a new row one tile further down
        layout["storage_row"] = [start[0], start[1] + 2]
        self.mem.save_layout(layout)
        return None

    def placeable(self, spot):
        """Empty walkable ground ('.' plain, ':' tillable) with nothing on it."""
        info = self.safe(lambda: self.game.tile(spot[0], spot[1]), {})
        return info.get("char") in (".", ":") and not info.get("colliding")

    @staticmethod
    def in_plot(layout, spot):
        return any(p["x"] - 1 <= spot[0] <= p["x"] + p["w"] and p["y"] - 1 <= spot[1] <= p["y"] + p["h"]
                   for p in layout.get("plots", []))

    def claim_spot(self, layout, spot):
        layout.setdefault("placed", []).append(list(spot))
        self.mem.save_layout(layout)
        return spot

    def unclaim_spot(self, spot):
        """Undo a tidy_spot reservation when place/craft failed (prevents ghost occupancy)."""
        layout = self.mem.layout()
        placed = layout.get("placed") or []
        spot_t = (spot[0], spot[1])
        new = [p for p in placed if tuple(p) != spot_t]
        if len(new) != len(placed):
            layout["placed"] = new
            self.mem.save_layout(layout)
            log(f"放置失败：释放占位 ({spot[0]},{spot[1]})")

    @staticmethod
    def fmt_villager(v):
        s = f"{v['name']}({v['hearts']}心"
        if v.get("birthday_today"):
            s += ",今天生日!"
        s += ",今天聊过" if v.get("talked_today") else ",今天没聊"
        s += f",本周礼物{v.get('gifts_this_week', 0)}/2"
        if v.get("good_gifts_in_backpack"):
            s += ",背包里的好礼物:" + "/".join(v["good_gifts_in_backpack"])
        if v.get("location"):
            s += f",现在在{v['location']}" + (f"(锁门到{v['locked_until']},别去)" if v.get("locked_until") else "")
        if v.get("schedule_today"):
            s += ",今天行程:" + "→".join(v["schedule_today"][:6])
        if v.get("loves"):
            s += ",最爱:" + "/".join(v["loves"][:5])
        return s + ")"

    def fmt_social(self, st, include_all=False):
        lines = []
        fest = st.get("festivals") or []
        for f in fest:
            when = "今天！" if f["in_days"] == 0 else f"{f['in_days']}天后"
            where = f"，地点 {f.get('location')} {f.get('start', 0) // 100}:00-{f.get('end', 0) // 100}:00" if f.get("location") else ""
            lines.append(f"🎉 节日 {f['name']}（{f['season']} {f['day']}，{when}{where}）")
        if st.get("birthdays_today"):
            lines.append("🎂 今天生日：" + "、".join(st["birthdays_today"]) + "（生日礼物好感 x8）")
        here = st.get("villagers_here") or []
        if here:
            lines.append("这里的村民：" + "；".join(self.fmt_villager(v) for v in here))
        if include_all:
            social = self.safe(self.game.social, {})
            met = social.get("met") if isinstance(social, dict) else None
            if met:
                lines.append("认识的村民（好感从高到低）：" + "；".join(
                    f"{v['name']} {v['hearts']}心 生日{v.get('birthday')}" for v in met[:15]))
        return "\n".join(lines) or "社交：（无）"

    def building_site(self, st, building):
        """Buildings go in one tidy row west of the house, away from crop plots and the storage row."""
        layout = self.mem.layout()
        zones = (layout.get("plan") or {}).get("zones", {})
        if zones:
            return self.zone_building_site(building, zones)
        anchor = layout.get("anchor") or [64, 18]
        placed = layout.get("buildings", [])
        ranch = self.safe(self.game.ranch, {})
        sizes = {b["type"]: b for b in ranch.get("buildings", [])} if isinstance(ranch, dict) else {}
        if placed:
            last = placed[-1]
            w = sizes.get(last["type"], {}).get("w", 7)
            near = (last["x"] + w + 3, last["y"])
        else:
            near = (anchor[0] - 14, anchor[1] - 2)
        sites = self.safe(lambda: self.game.building_sites(building, near[0], near[1]), [])
        if not isinstance(sites, list):
            return None

        def clashes(x, y, w, h):
            for p in layout.get("plots", []):
                if x - 2 < p["x"] + p["w"] and p["x"] < x + w + 2 and y - 2 < p["y"] + p["h"] and p["y"] < y + h + 3:
                    return True
            row = layout.get("storage_row")
            return bool(row) and x - 2 <= row[0] + 12 and row[0] <= x + w + 2 and y - 2 <= row[1] <= y + h + 2

        free = [s for s in sites if not clashes(s[0], s[1], s[2], s[3])]
        aligned = [s for s in free if placed and s[1] == placed[-1]["y"]]
        pick = (aligned or free or [None])[0]
        return (pick[0], pick[1], pick[2], pick[3], pick[4] if len(pick) > 4 else 0) if pick else None

    def zone_building_site(self, building, zones):
        """Sheds and hutches in the workshop corner (the Shed's reserved footprint); everything else in the animal zone, in a row."""
        if building.lower() in ("shed", "big shed", "slime hutch") and "workshop" in zones:
            zone = zones["workshop"]
            shed = farmplan.workshop_slots(zone)[0]
            near = (shed[0] + 3, shed[1] + 1)
        elif "animals" in zones:
            zone = zones["animals"]
            near = (zone[0] + 3, zone[1] + 2)  # fill from the left, in a row along the top of the zone
        else:
            return None
        sites = self.safe(lambda: self.game.building_sites(building, near[0], near[1]), [])
        inside = [s for s in (sites if isinstance(sites, list) else [])
                  if zone[0] <= s[0] and s[0] + s[2] <= zone[0] + zone[2] and zone[1] <= s[1] and s[1] + s[3] <= zone[1] + zone[3]]
        inside.sort(key=lambda s: (s[1], s[0]))
        pick = inside[0] if inside else None
        return (pick[0], pick[1], pick[2], pick[3], pick[4] if len(pick) > 4 else 0) if pick else None

    # ---------------- farm master plan: zones and roads ----------------

    def farm_plan(self):
        return self.mem.layout().get("plan")

    def ensure_farm_plan(self):
        """Draw the farm's zones and roads once, from the real map."""
        layout = self.mem.layout()
        if layout.get("plan"):
            return layout["plan"]
        g = self.safe(self.game.farm_grid, {})
        if not isinstance(g, dict) or "rows" not in g:
            return None
        plan = farmplan.make_plan(g, layout.get("storage_row"))
        layout["plan"] = plan
        self.mem.save_layout(layout)
        log(farmplan.describe(plan))
        self.write_farm_map(g, plan)
        return plan

    def write_farm_map(self, g=None, plan=None):
        plan = plan or self.farm_plan()
        g = g or self.safe(self.game.farm_grid, {})
        if not plan or not isinstance(g, dict) or "rows" not in g or not getattr(self, "journal", None):
            return
        try:
            done = sum(1 for r in plan["roads"] for x, y in r["tiles"] if g["rows"][y][x] == "p")
            total = sum(len(r["tiles"]) for r in plan["roads"])
            text = (f"# 农场规划图\n\n{farmplan.describe(plan)}\n\n道路进度：已铺 {done}/{total} 格\n\n"
                    f"{farmplan.LEGEND}\n\n```\n{farmplan.render(g, plan)}\n```\n")
            (self.journal.dir / "农场规划图.md").write_text(text, encoding="utf-8")
        except Exception as e:  # the map is a nice-to-have
            log(f"写农场规划图失败：{e}")

    # placed by hand where the model says (seeds, fertilizer, paths, fences): not routed through the zones
    HAND_PLACED = ("seed", "starter", "bulb", "tuber", "fertilizer", "gro", "soil", "path", "floor", "fence", "gate", "acorn", "cone")

    TREE_SEEDS = ("Acorn", "Maple Seed", "Pine Cone", "Mahogany Seed")
    FLOWER_SEEDS = {"spring": ("Tulip Bulb", "Jazz Seeds"), "summer": ("Spangle Seeds", "Poppy Seeds", "Sunflower Seeds"),
                    "fall": ("Fairy Seeds", "Sunflower Seeds")}

    def decorate(self, st):
        """One decoration job from the plan: screen trees around the workshop, the paddock fence, flowerbeds by the plaza."""
        plan = self.ensure_farm_plan()
        if not plan or "screen" not in plan:
            return {"ok": False, "message": "农场规划里还没有装饰位置"}
        g = self.safe(self.game.farm_grid, {})
        if not isinstance(g, dict) or "rows" not in g:
            return {"ok": False, "message": "读不到农场地图"}
        free = lambda t: g["rows"][t[1]][t[0]] in ".d"
        inv = {i["name"]: i.get("stack", 1) for i in st.get("inventory", []) if i}
        done = []
        # 1. trees screening the workshop corner (wild tree seeds from chopping trees)
        seed = next((s for s in self.TREE_SEEDS if inv.get(s)), None)
        spots = [t for t in plan["screen"] if free(t)]
        if seed and spots:
            for t in spots[:min(6, inv[seed])]:
                if self.act_and_record(st, {"type": "place", "item": seed, "x": t[0], "y": t[1]}, "(种一棵遮挡作坊的树)").get("ok"):
                    done.append("遮挡树")
            if done:
                return {"ok": True, "message": f"在作坊角外种了 {len(done)} 棵遮挡树"}
        # 2. fence around the animal zone, once a coop/barn stands there
        ranch = self.safe(self.game.ranch, {})
        zone = plan["zones"].get("animals")
        has_building = zone and any(zone[0] <= b["x"] < zone[0] + zone[2] and zone[1] <= b["y"] < zone[1] + zone[3]
                                    for b in (ranch.get("buildings", []) if isinstance(ranch, dict) else []))
        fence = [t for t in plan["fence"] if free(t)]
        if has_building and fence:
            recipes = {r["name"]: r for r in (self.safe(self.game.recipes, []) or [])}
            n = min(len(fence), 20, recipes.get("Wood Fence", {}).get("can_make", 0))
            if n > 0 and self.act_and_record(st, {"type": "craft", "item": "Wood Fence", "count": n}, f"(做 {n} 段木栅栏)").get("ok"):
                placed = 0
                for t in fence[:n]:
                    placed += bool(self.act_and_record(st, {"type": "place", "item": "Wood Fence", "x": t[0], "y": t[1]}, "(围牧场栅栏)").get("ok"))
                gate = plan.get("gate")
                if gate and free(gate) and recipes.get("Gate", {}).get("can_make", 0) > 0 \
                        and self.act_and_record(st, {"type": "craft", "item": "Gate", "count": 1}, "(做栅栏门)").get("ok"):
                    self.act_and_record(st, {"type": "place", "item": "Gate", "x": gate[0], "y": gate[1]}, "(装栅栏门，对着主干道)")
                return {"ok": placed > 0, "message": f"牧场栅栏装了 {placed} 段"}
        # 3. flowerbeds on both sides of the plaza (seasonal flowers)
        flower = next((s for s in self.FLOWER_SEEDS.get(st.get("season"), ()) if inv.get(s)), None)
        if flower and plan.get("flowers"):
            ok = 0
            for x, y, bw, bh in plan["flowers"]:
                res = self.act_and_record(st, {"type": "plant_seeds", "item": flower, "count": bw * bh,
                                               "plot": {"x": x, "y": y, "w": bw, "h": bh}}, "(门前花坛种花)")
                ok += bool(res.get("ok"))
            return {"ok": ok > 0, "message": f"门前花坛种了 {flower}"}
        return {"ok": False, "message": "今天没有能做的装饰（缺树种子/木头/花种，或还没有畜舍）"}

    PATH_ITEMS = ("Cobblestone Path", "Wood Path", "Stone Floor", "Gravel Path")

    def build_road(self, st, max_tiles=24):
        """Pave the next stretch of planned road (crafting path tiles first), then put up a lamp post if possible."""
        plan = self.ensure_farm_plan()
        if not plan:
            return {"ok": False, "message": "还没有农场规划（读不到农场地图）"}
        g = self.safe(self.game.farm_grid, {})
        if not isinstance(g, dict) or "rows" not in g:
            return {"ok": False, "message": "读不到农场地图"}
        rows = g["rows"]
        todo = [tuple(t) for t in plan.get("plaza", [])] + [tuple(t) for r in plan["roads"] for t in r["tiles"]]
        todo = [t for t in todo if rows[t[1]][t[0]] in ".d" and t not in self.day.road_skip][:max_tiles]
        if not todo:
            return {"ok": False, "message": "规划的路都铺好了，或剩下的路段被树/作物挡住（升级斧头后再清）"}
        recipes = self.safe(self.game.recipes, [])
        recipes = {r["name"]: r for r in recipes} if isinstance(recipes, list) else {}
        item = next((n for n in self.PATH_ITEMS if recipes.get(n, {}).get("can_make", 0) > 0), None)
        have = next((i.get("stack", 0) for i in st.get("inventory", []) if i and i.get("name") == item), 0) if item else 0
        if not item:
            return {"ok": False, "message": "做不了铺路材料（Cobblestone Path 要 1 块石头）"}
        need = min(len(todo) - have, recipes[item]["can_make"])
        if need > 0:
            res = self.act_and_record(st, {"type": "craft", "item": item, "count": need}, f"(做 {need} 块 {item} 用来铺路)")
            if not res.get("ok"):
                return res
        try:
            res = self.game.act({"type": "lay_path", "tiles": [list(t) for t in todo], "item": item})
        except GameError as e:
            res = {"ok": False, "status": "AGENT_UNAVAILABLE", "message": str(e)}
        after = self.safe(self.game.farm_grid, {})
        if isinstance(after, dict) and "rows" in after:
            self.day.road_skip |= {t for t in todo if after["rows"][t[1]][t[0]] != "p"}
        lamp = next((n for n, r in recipes.items() if "Lamp" in n and r.get("can_make", 0) > 0), None)
        if res.get("ok") and lamp:
            fresh = self.safe(self.game.state, st)
            if self.act_and_record(fresh, {"type": "craft", "item": lamp, "count": 1}, "(做一盏路灯)").get("ok"):
                spot = self.tidy_spot(fresh, lamp)
                if spot:
                    self.act_and_record(fresh, {"type": "place", "item": lamp, "x": spot[0], "y": spot[1]}, "(路灯立在路边)")
        return res

    def fmt_ranch(self):
        r = self.safe(self.game.ranch, {})
        if not isinstance(r, dict) or not r:
            return "牧场：（无数据）"
        parts = []
        if r.get("buildings"):
            parts.append("建筑：" + "；".join(
                f"{b['type']}@({b['x']},{b['y']})" + (f" 还要{b['days_until_built']}天建好" if b.get("days_until_built") else "")
                + (f" 动物{b['animals']}" if b.get("animals") else "") for b in r["buildings"]))
        if r.get("animals"):
            parts.append("动物：" + "；".join(
                f"{a['name']}({'今天摸过' if a['pet_today'] else '今天没摸'},好感{a['friendship']})" for a in r["animals"]))
        if r.get("can_build"):
            parts.append("罗宾能建：" + "；".join(
                f"{b['type']} {b['cost']}g+{'+'.join(b['materials'])} {b['size']}" for b in r["can_build"] if not b.get("upgrade_from")))
        if r.get("animals_for_sale"):
            parts.append("玛妮卖：" + "、".join(f"{a['name']}{a['price']}g" for a in r["animals_for_sale"]))
        if r.get("robin_busy"):
            parts.append("罗宾正在施工")
        return "牧场：" + ("\n".join(parts) or "还没有建筑和动物")

    def fmt_bundles(self, st, detail=False):
        stage = st.get("community_center") or ""
        if not stage.startswith("donate") and not detail:
            return "社区中心：" + stage
        data = self.safe(self.game.bundles, {})
        lines = ["社区中心：" + (data.get("stage") or stage)]
        ready, wanted = [], []
        for area in data.get("areas", []) if isinstance(data, dict) else []:
            for b in area.get("bundles", []):
                if b.get("complete"):
                    continue
                for need in b.get("still_needed", []):
                    tag = f"{need['item']}x{need['count']}" + (f"(品质{need['quality']}+)" if need.get("quality") else "")
                    if need.get("owned", 0) >= need["count"]:
                        ready.append(f"{tag}→{b['name']}")
                    else:
                        wanted.append(f"{tag}[{area['area']}/{b['name']}]")
        if ready:
            lines.append("✅ 现在就能捐（背包或箱子里已有）：" + "；".join(ready[:15]) + "（箱子里的先 take 到背包，再 donate）")
        if wanted and detail:
            lines.append("还缺：" + "；".join(wanted[:30]))
        return "\n".join(lines)

    def fmt_recipes(self):
        recipes = self.safe(lambda: self.game.recipes(), [])
        if not isinstance(recipes, list) or not recipes:
            return "已知配方：（无）"
        can = [f"{r['display']}(可做{r['can_make']}个: {'+'.join(r['ingredients'])})" for r in recipes if r.get("can_make", 0) > 0]
        cannot = [r["display"] for r in recipes if r.get("can_make", 0) == 0]
        return "现在能做的配方：" + ("；".join(can) or "无") + "\n其它已知配方：" + "、".join(cannot)

    # ---------------- farm layout ----------------

    def ensure_plot(self, st):
        """Return a planned plot with free tiles, creating the next tidy plot (aligned, 1-tile path) if all are full."""
        layout = self.mem.layout()
        if not layout.get("anchor"):
            house = next((e for e in st.get("exits", []) if e.get("to") == "FarmHouse"), None)
            layout["anchor"] = [house["x"], house["y"] + 4] if house else [st["player"]["x"], st["player"]["y"]]
        zone = (layout.get("plan") or {}).get("zones", {}).get("crops")

        def in_zone(p):
            return not zone or (zone[0] <= p["x"] and p["x"] + p["w"] <= zone[0] + zone[2]
                                and zone[1] <= p["y"] and p["y"] + p["h"] <= zone[1] + zone[3])

        for plot in layout["plots"]:
            if not in_zone(plot):
                continue  # plots from before the farm plan: not planted again (they stay as they are)
            info = self.safe(lambda: self.game.plot_check(plot["x"], plot["y"], plot["w"], plot["h"]), {})
            if info.get("free", 0) > 0:
                return plot

        w, h = layout.get("plot_size", [6, 4])
        if zone:
            for x, y in farmplan.plot_slots(zone, w, h):
                if any(p["x"] == x and p["y"] == y for p in layout["plots"]):
                    continue
                info = self.safe(lambda: self.game.plot_check(x, y, w, h), {})
                if info.get("ok") and info.get("planted", 0) == 0:
                    return self.add_plot(layout, x, y, w, h)
            log("菜地分区已经种满（或被树/石头挡住）：不在分区外开新地块")
            return None
        candidates = []
        if layout["plots"]:
            last, first = layout["plots"][-1], layout["plots"][0]
            bottom = max(p["y"] + p["h"] for p in layout["plots"])
            candidates = [(last["x"] + last["w"] + 1, last["y"]),      # next to the last plot, same row
                          (first["x"], bottom + 1),                    # start a new row under the first plot
                          (last["x"] - w - 1, last["y"])]              # or to the left
        def overlaps(x, y):
            return any(x < p["x"] + p["w"] + 1 and p["x"] < x + w + 1 and y < p["y"] + p["h"] + 1 and p["y"] < y + h + 1
                       for p in layout["plots"])

        for x, y in candidates:
            info = self.safe(lambda: self.game.plot_check(x, y, w, h), {})
            if info.get("ok") and not overlaps(x, y) and info.get("planted", 0) == 0:
                return self.add_plot(layout, x, y, w, h)
        near = layout["plots"][-1] if layout["plots"] else {"x": layout["anchor"][0], "y": layout["anchor"][1], "w": 0, "h": 0}
        found = self.safe(lambda: self.game.find_plot(w, h, near["x"] + near["w"] // 2, near["y"] + near["h"] // 2), [])
        for f in found if isinstance(found, list) else []:
            if not overlaps(f["x"], f["y"]) and f.get("planted", 0) == 0:
                return self.add_plot(layout, f["x"], f["y"], w, h)
        log("找不到合适的整齐地块，plant_seeds 将按原方式就近种植")
        self.mem.save_layout(layout)
        return None

    def add_plot(self, layout, x, y, w, h):
        plot = {"name": chr(ord("A") + len(layout["plots"])), "x": x, "y": y, "w": w, "h": h}
        layout["plots"].append(plot)
        self.mem.save_layout(layout)
        log(f"规划了新地块 {plot['name']}：({x},{y}) {w}x{h}")
        return plot

    def fmt_layout(self):
        layout = self.mem.layout()
        if layout.get("plan"):
            plots = "；".join(f"{p['name']}=({p['x']},{p['y']})" for p in layout.get("plots", []))
            return (farmplan.describe(layout["plan"]) + f"；已开地块 {plots or '无'}。"
                    "农场上的摆放/建造/种地位置由执行器按分区决定，不要写 x,y。")
        if not layout.get("plots"):
            return "农场布局：还没有规划地块（第一次 plant_seeds 时会自动在农舍前规划一块 6x4 的整齐地块）"
        plots = "；".join(f"{p['name']}=({p['x']},{p['y']}) {p['w']}x{p['h']}" for p in layout["plots"])
        return f"农场布局（整齐的矩形地块，地块之间留 1 格走道）：{plots}"

    # ---------------- prompt building ----------------

    def system_prompt(self):
        return prompts.SYSTEM_STEP.format(actions=prompts.ACTIONS_DOC, map_help=prompts.MAP_HELP,
                                          strategy=self.mem.strategy(), lessons=self.mem.lessons())

    def observation(self, st):
        m = self.safe(lambda: self.game.map(self.cfg["map_radius"]), {})
        msgs = self.safe(lambda: self.game.messages(self.msg_seq), {"messages": [], "last_seq": self.msg_seq})
        self.msg_seq = msgs.get("last_seq", self.msg_seq)
        new_msgs = [f"[{x['kind']}] {x['text']}" for x in msgs.get("messages", []) if not x["kind"].startswith("action") and x["kind"] != "menu"]

        crops_txt = ""
        if st["location"] in ("Farm", "Greenhouse") or "Farm" in st["location"]:
            crops_txt = "## 作物概况\n" + self.fmt_crops(self.safe(lambda: self.game.crops(), {})) + "\n"

        player = st["player"]
        compact = {
            "时间": f"{st['time_str']} 第{st['year']}年 {st['season']} {st['day']}日 {st['weekday']}",
            "天气": f"{st['weather']}（明天 {st.get('weather_tomorrow')}）", "运气": st.get("luck"),
            "地点": st["location"], "位置": [player["x"], player["y"]],
            "体力": f"{player['stamina']}/{player['max_stamina']}", "生命": f"{player['health']}/{player['max_health']}",
            "金钱": player["money"], "技能": st.get("skills"),
            "出口": [f"{e['to']}@({e['x']},{e['y']})" for e in st.get("exits", [])],
            "出货箱": st.get("shipping_bin"),
            "兴趣点": [f"{p['kind']}@({p['x']},{p['y']}) {p['note']}" for p in st.get("points_of_interest", [])],
            "空背包格": st.get("inventory_free_slots"),
            "当前菜单": (st.get("menu") or {}).get("type") or "无（没有打开的菜单，不需要 close_menu）",
        }
        state_txt = (json.dumps(compact, ensure_ascii=False) + "\n背包：" + self.fmt_inventory(st)
                     + "\n物品说明：\n" + self.item_knowledge(st)
                     + "\n商店营业状态：" + prompts.shop_status(st["time"], st["weekday"]))
        state_txt += ("\n" + self.fmt_quests_mail(st) + "\n" + self.fmt_layout() + "\n" + self.fmt_recipes()
                      + "\n" + self.fmt_social(st) + "\n" + self.fmt_bundles(st))
        if st.get("machines"):
            state_txt += "\n🏭 机器：" + "；".join(
                f"{m['name']}@({m['x']},{m['y']})" + ("【完成，可收取】" if m.get("ready") else
                (f" 加工{m['contains']}还剩{m['minutes_left'] // 60}h" if m.get("contains") else " 空闲"))
                for m in st["machines"][:15])
        if st.get("mine"):
            state_txt += "\n⛏ 矿洞：" + json.dumps(st["mine"], ensure_ascii=False)
        if st.get("menu"):
            state_txt += "\n⚠ 当前打开的菜单：" + json.dumps(st["menu"], ensure_ascii=False)[:2500]

        ents = []
        if m.get("npcs"):
            ents.append("NPC: " + ", ".join(f"{n['name']}({n['x']},{n['y']})" for n in m["npcs"]))
        if m.get("monsters"):
            ents.append("怪物: " + ", ".join(f"{n['name']}({n['x']},{n['y']}) hp{n['hp']}" for n in m["monsters"]))
        ents.append("图例: " + m.get("legend", ""))

        hist = self.day.steps[-self.cfg["history_len"]:]
        warning = ""
        if len(hist) >= 3 and all(not s["ok"] for s in hist[-3:]):
            warning = "\n⚠ 最近 3 个动作都失败了，请换一种完全不同的做法。"

        origin = m.get("origin", [0, 0])
        return prompts.USER_STEP.format(
            plan="\n".join(f"{i + 1}. {p}" for i, p in enumerate(self.day.plan)) or "（无）",
            state=state_txt, location=m.get("location", st["location"]),
            ox=origin[0], oy=origin[1], px=player["x"], py=player["y"],
            rows="\n".join(m.get("rows", [])), entities="\n".join(ents),
            crops=crops_txt, messages="\n".join(new_msgs[-12:]) or "（无）",
            history="\n".join(self.fmt_step(s) for s in hist) or "（今天还没有动作）",
            warning=warning)

    def item_knowledge(self, st):
        """One compact line per backpack item, read from the game's data tables (cached)."""
        ids = [it["id"] for it in st.get("inventory", [])]
        missing = [i for i in dict.fromkeys(ids) if i not in self.item_cache]
        if missing:
            infos = self.safe(lambda: self.game.items(missing), [])
            for info in infos if isinstance(infos, list) else []:
                if isinstance(info, dict):
                    self.item_cache[info.get("id")] = info
        lines = []
        for i in dict.fromkeys(ids):
            info = self.item_cache.get(i)
            if not info or info.get("error"):
                continue
            parts = [info.get("category") or ""]
            if info.get("sell_price"):
                parts.append(f"售{info['sell_price']}g")
            if info.get("energy"):
                parts.append(f"吃+{info['energy']}体力/+{info.get('health', 0)}生命")
            crop = info.get("crop")
            if crop:
                parts.append(f"种子:{'/'.join(crop['seasons'])}季,{crop['days_to_grow']}天熟"
                             + (f",之后每{crop['regrow_days']}天再收" if crop.get("regrow_days") else "")
                             + f",收获{crop.get('harvest')}售{crop.get('harvest_sell_price')}g")
            desc = (info.get("description") or "")[:60]
            lines.append(f"- {info['name']}: {', '.join(p for p in parts if p)} | {desc}")
        return "\n".join(lines) or "（无）"

    @staticmethod
    def fmt_quests_mail(st):
        lines = []
        if st.get("unread_mail"):
            lines.append(f"📬 信箱里有 {st['unread_mail']} 封未读信件（check_mail 可读信、领取附带物品和任务）")
        quests = [q for q in st.get("quests", []) if not q.get("completed")]
        if quests:
            lines.append("任务日志：")
            for q in quests:
                obj = "；".join(q.get("objectives") or [])
                days = f"（剩{q['days_left']}天）" if q.get("days_left", 0) > 0 else ""
                lines.append(f"- {q['title']}{days}: {obj or q.get('description', '')}")
        return "\n".join(lines) or "任务日志：（空）"

    @staticmethod
    def fmt_inventory(st):
        parts = []
        for it in st.get("inventory", []):
            s = f"{it['slot']}:{it['name']}x{it['stack']}"
            if "water" in it:
                s += f"(水{it['water']})"
            elif "tool_level" in it:
                s += f"(Lv{it['tool_level']})"
            elif it.get("edible_energy"):
                s += f"(+{it['edible_energy']}体力)"
            parts.append(s)
        return ", ".join(parts)

    @staticmethod
    def fmt_crops(c):
        if not c or c.get("ready") is False:
            return "（无数据）"
        return (f"生长中 {c.get('growing')}；缺水 {len(c.get('needs_water', []))} 株 {c.get('needs_water', [])[:8]}；"
                f"可收获 {len(c.get('ready_to_harvest', []))} 株 {c.get('ready_to_harvest', [])[:8]}；"
                f"枯死 {len(c.get('dead', []))}；空的已耕地 {c.get('empty_tilled_soil')}；杂物 {c.get('debris')}；下雨 {c.get('raining')}")

    @staticmethod
    def fmt_step(s, with_thought=False):
        line = f"[{s['time']}] {json.dumps(s['action'], ensure_ascii=False)} -> {'OK' if s['ok'] else 'FAIL'}: {s['message']}"
        return (f"({s['thought']}) " if with_thought and s.get("thought") else "") + line

    # ---------------- utils ----------------

    @staticmethod
    def safe(fn, default):
        try:
            return fn()
        except GameError:
            return default

    def write_run(self, kind, data):
        event = {"kind": kind, "ts": datetime.now().isoformat(timespec="seconds"), **data}
        with (self.run_dir / "log.jsonl").open("a", encoding="utf-8") as f:
            f.write(json.dumps(event, ensure_ascii=False) + "\n")
        if self.journal is not None:
            # night-time script for tomorrow is filed under the day that just ended
            tag = self.day.tag if kind == "prepared_script" and self.day else data.get("day")
            try:
                self.journal.append(tag, event)
            except OSError as e:
                log(f"写游玩日志失败：{e}")


def ensure_single_instance():
    """Two agents driving the same game fight over every action; refuse to start a second one."""
    import subprocess
    lock = RUNS / "agent.pid"
    if lock.exists():
        pid = lock.read_text().strip()
        if pid.isdigit() and int(pid) != os.getpid():
            # tasklist speaks the console code page. Decoding it as text can fail and leave stdout None.
            out = subprocess.run(["tasklist", "/FI", f"PID eq {pid}", "/NH"], capture_output=True).stdout or b""
            if b"python" in out.lower():
                sys.exit(f"另一个 AutoPilot 代理正在运行（PID {pid}）。请先停止它（或删除 {lock}）。")
    RUNS.mkdir(exist_ok=True)
    lock.write_text(str(os.getpid()))


def main():
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    ap = argparse.ArgumentParser(description="Stardew Valley LLM autopilot")
    ap.add_argument("--config", default=str(ROOT / "config.json"))
    ap.add_argument("--days", type=int, default=None, help="stop after N in-game days")
    ap.add_argument("--steps", type=int, default=None, help="stop after N actions")
    ap.add_argument("--mock-llm", action="store_true", help="scripted policy, no API calls")
    ap.add_argument("--no-save", action="store_true", help="test mode: never sleep, so the save file is not written")
    args = ap.parse_args()

    if not args.mock_llm:
        ensure_single_instance()
    agent = Agent(load_config(args.config), mock=args.mock_llm, no_save=args.no_save, config_path=args.config)
    model = "mock" if args.mock_llm else ((agent.cfg.get("llm") or {}).get("model") or "（进档后按 F8 配置）")
    log(f"AutoPilot 启动，模型 {model}，日志 {agent.run_dir}")
    log("流程：你先手动选档进游戏 → 按 F8 填网关/Key → 代理检测到后自动开始（默认不自动选档）")
    try:
        agent.run(max_days=args.days, max_steps=args.steps)
    except KeyboardInterrupt:
        log("收到 Ctrl+C，取消当前动作并退出")
        try:
            agent.game.cancel()
        except GameError:
            pass


if __name__ == "__main__":
    main()
