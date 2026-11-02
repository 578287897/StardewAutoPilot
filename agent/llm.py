"""Minimal OpenAI-compatible chat client (works with DeepSeek, Qwen, OpenAI, Ollama, most relays)."""
import json
import re
import time
import urllib.error
import urllib.request


class LLMError(Exception):
    pass


class LLM:
    def __init__(self, base_url, api_key, model, temperature=0.4, max_tokens=800, timeout=120, options=None):
        self.base = base_url.rstrip("/")
        self.api_key = api_key
        self.model = model
        self.temperature = temperature
        self.max_tokens = max_tokens
        self.timeout = timeout
        self.options = options or {}  # merged into every request body
        self.json_mode = True  # turned off automatically if the provider rejects response_format
        self.calls = 0
        self.tokens = 0

    def _post(self, payload):
        req = urllib.request.Request(
            self.base + "/chat/completions",
            data=json.dumps(payload, ensure_ascii=False).encode("utf-8"),
            method="POST",
            headers={"Content-Type": "application/json", "Authorization": f"Bearer {self.api_key}"},
        )
        with urllib.request.urlopen(req, timeout=self.timeout) as resp:
            return json.loads(resp.read().decode("utf-8"))

    def chat(self, messages, max_tokens=None):
        payload = {
            "model": self.model,
            "messages": messages,
            "temperature": self.temperature,
            "max_tokens": max_tokens or self.max_tokens,
            **self.options,
        }
        last_err = None
        for attempt in range(4):
            if self.json_mode:
                payload["response_format"] = {"type": "json_object"}
            else:
                payload.pop("response_format", None)
            try:
                data = self._post(payload)
                self.calls += 1
                self.tokens += (data.get("usage") or {}).get("total_tokens", 0)
                content = data["choices"][0]["message"].get("content") or ""
                if content.strip():
                    return content
                # empty reply: usually a reasoning model that ran out of tokens, or json mode misbehaving
                last_err = "empty reply"
                payload["max_tokens"] = min(payload["max_tokens"] * 2, 8000)
                if attempt >= 1:
                    self.json_mode = False
                continue
            except urllib.error.HTTPError as e:
                body = e.read().decode("utf-8", "replace")[:500]
                if e.code == 400 and self.json_mode and "response_format" in body:
                    self.json_mode = False
                    continue
                if e.code in (401, 403):
                    raise LLMError(f"auth failed ({e.code}): {body}")
                last_err = f"HTTP {e.code}: {body}"
            except Exception as e:  # network hiccup
                last_err = str(e)
            time.sleep(2 * (attempt + 1))
        raise LLMError(f"LLM request failed: {last_err}")

    def chat_json(self, messages, max_tokens=None):
        """Ask for a JSON object; retry once with a reminder if the reply can't be parsed."""
        text = self.chat(messages, max_tokens)
        obj = parse_json(text)
        if obj is not None:
            return obj
        retry = messages + [{"role": "assistant", "content": text},
                            {"role": "user", "content": "只输出一个合法的 JSON 对象，不要任何其他文字。"}]
        obj = parse_json(self.chat(retry, max_tokens))
        if obj is None:
            raise LLMError("model did not return valid JSON: " + text[:300])
        return obj


def parse_json(text):
    text = text.strip()
    text = re.sub(r"^```(?:json)?\s*|\s*```$", "", text)
    try:
        return json.loads(text)
    except json.JSONDecodeError:
        pass
    # fall back to the first complete {...} (tolerates trailing junk such as an extra "}")
    start = text.find("{")
    if start >= 0:
        try:
            obj, _ = json.JSONDecoder().raw_decode(text[start:])
            return obj
        except json.JSONDecodeError:
            return None
    return None
