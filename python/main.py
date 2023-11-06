from importlib import import_module
from pathlib import Path


path = Path(".")
for f in list(path.glob("*")):
    if f.is_dir and f.name.startswith("day"):
        import_module(f"{f.name}.program")
