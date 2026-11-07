"""Comparable daily execution metrics; macro/child receipt duplicates count once."""


def no_progress(message):
    text = str(message or "").lower()
    return any(s in text for s in ("no empty machine accepts", "no machine has finished output",
               "harvested 0 crops", "watered 0 crops", "nothing to ship", "laid 0 "))


def summarize(steps):
    seen = {}
    rows = []
    for step in steps:
        request = step.get("request_id")
        if request and request in seen:
            previous = rows[seen[request]]
            uncertain = ("AGENT_UNAVAILABLE", "ACTION_UNCERTAIN")
            merged = ({**step, **previous} if step.get("status") in uncertain
                      and previous.get("status") not in uncertain else {**previous, **step})
            for key in ("elapsed_seconds", "game_minutes"):
                merged[key] = max(previous.get(key, 0), step.get(key, 0))
            rows[seen[request]] = merged
            continue
        if request:
            seen[request] = len(rows)
        rows.append(step)
    skipped = sum(s.get("status") == "CIRCUIT_OPEN" for s in rows)
    unavailable = sum(s.get("status") in ("AGENT_UNAVAILABLE", "ACTION_UNCERTAIN") for s in rows)
    work = [s for s in rows if s.get("status") not in
            ("CIRCUIT_OPEN", "AGENT_UNAVAILABLE", "ACTION_UNCERTAIN")
            and s.get("action", {}).get("type") not in ("wait", "sleep", "invalid")]
    empty = sum(s.get("status") == "NO_PROGRESS" or no_progress(s.get("message")) for s in work)
    useful = sum(bool(s.get("ok")) and s.get("status") != "NO_PROGRESS"
                 and not no_progress(s.get("message")) for s in work)
    return {"work_attempts": len(work), "useful_actions": useful, "no_progress": empty,
            "effective_rate": round(useful / len(work), 4) if work else None,
            "circuit_skips": skipped, "unavailable": unavailable,
            "failure_seconds": round(sum(s.get("elapsed_seconds", 0) for s in rows
                                         if not s.get("ok") or no_progress(s.get("message"))), 3),
            "failed_game_minutes": sum(s.get("game_minutes", 0) for s in rows
                                       if not s.get("ok") or no_progress(s.get("message")))}
