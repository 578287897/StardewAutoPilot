"""Crash-safe UTF-8 files; one shared lock for in-process read/modify/write cycles."""
import functools
import json
import os
from pathlib import Path
import tempfile
import threading
import warnings

LOCK = threading.RLock()


def synchronized(fn):
    @functools.wraps(fn)
    def wrapped(*args, **kwargs):
        with LOCK:
            return fn(*args, **kwargs)
    return wrapped


def _replace(path, text):
    path = Path(path)
    path.parent.mkdir(parents=True, exist_ok=True)
    fd, temporary = tempfile.mkstemp(prefix=path.name + '.', suffix='.tmp', dir=path.parent)
    try:
        with os.fdopen(fd, 'w', encoding='utf-8', newline='') as stream:
            stream.write(text)
            stream.flush()
            os.fsync(stream.fileno())
        os.replace(temporary, path)
    finally:
        if os.path.exists(temporary):
            os.unlink(temporary)


@synchronized
def atomic_write(path, text, backup=True):
    path = Path(path)
    if backup and path.exists():
        _replace(Path(str(path) + '.bak'), path.read_text(encoding='utf-8'))
    _replace(path, text)


@synchronized
def read_json(path, default=None):
    path = Path(path)
    if not path.exists():
        return default
    try:
        return json.loads(path.read_text(encoding='utf-8'))
    except (ValueError, UnicodeError):
        backup = Path(str(path) + '.bak')
        data = json.loads(backup.read_text(encoding='utf-8'))  # fail visibly if both copies are damaged
        warnings.warn(f'Recovered {path.name} from its previous version', RuntimeWarning)
        _replace(path, json.dumps(data, ensure_ascii=False))
        return data
