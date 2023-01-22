# Leviathan Galaxy Simulator

A galaxy simulator for my ttrpg Leviathan's Drift.

Commands:
- `init [dest]`, initialize a new galaxy at filename `dest`.
- `get [source] location [guid] [dest] --deep?`, get a location from a galaxy file by its id `guid` from `source` filename and serialize it to `dest` filename. Fails if `guid` does not exist or location is not initialized. If `--deep` flag is set it fully initializes the requested subtree.
