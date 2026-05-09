extends Node

const PATH_PLAYER := "GameRoot/Player"
const PATH_LEVEL1 := "GameRoot/LevelRoot/Level1"
const PATH_TILLEDSOIL := PATH_LEVEL1 + "/GameTilemap/TilledSoil"
const PATH_CROPFIELDS := PATH_LEVEL1 + "/CropFields"
const PATH_TOOLSPANEL := "GameScreen/MarginContainer/VBoxContainer/ToolsPanel"

const SAVE_DIR := "user://game_data/"
const SAVE_VERSION := 1

const TILLED_TERRAIN_SET := 0
const TILLED_TERRAIN := 3

# Used by GameMenuScreen + set to true in GameManager.start_game()
var allow_save_game: bool = false
var _pending_save: Dictionary = {}


# ---------- Public helpers ----------

func can_save() -> bool:
	if not allow_save_game:
		return false

	var main := _get_main_scene()
	if main == null:
		return false

	# We only allow saving when MainScene is active and Level1 exists
	return main.get_node_or_null(PATH_LEVEL1) != null


# ---------- Save / Load ----------

func save_game():
	if not can_save():
		push_warning("Save blocked: can_save() == false (probably still in menu / level not loaded).")
		return

	var root := _get_main_scene()
	if root == null:
		push_warning("MainScene not loaded yet.")
		return
	var data := _build_save_dictionary(root)

	_ensure_save_dir()
	var path := SAVE_DIR + "save_game.json"
	var file := FileAccess.open(path, FileAccess.WRITE)
	file.store_string(JSON.stringify(data, "\t"))
	file.close()

	print("Saved JSON:", path)
	print("User data dir:", OS.get_user_data_dir())
	print("Save file full path:", OS.get_user_data_dir() + "/game_data/save_game.json")


func load_game():
	var path := SAVE_DIR + "save_game.json"
	if not FileAccess.file_exists(path):
		print("No JSON save file:", path)
		return

	var file := FileAccess.open(path, FileAccess.READ)
	var content := file.get_as_text()
	file.close()

	var result = JSON.parse_string(content)
	if typeof(result) != TYPE_DICTIONARY:
		push_error("Invalid JSON save file (not a Dictionary).")
		return

	_pending_save = result
	print("Loaded JSON (pending apply):", path)

	# Try apply immediately if world is already ready
	apply_pending_save()
	print("User data dir:", OS.get_user_data_dir())
	print("Save file full path:", OS.get_user_data_dir() + "/game_data/save_game.json")

# ---------- Build save data ----------

func _build_save_dictionary(root: Node) -> Dictionary:
	return {
		"version": SAVE_VERSION,
		"player": _save_player(root),
		"inventory": _save_inventory(),
		"time": _save_time(),
		"tools": ToolManager.enabled_tools.duplicate(true),
		"tilled_soil": _save_tilled_soil(root),
		"crops": _save_crops(root),
	}


func _save_player(root: Node) -> Dictionary:
	var player := root.get_node_or_null(PATH_PLAYER)
	if player == null:
		push_warning("Save: Player not found at path.", PATH_PLAYER)
		return {"pos": {"x": 0.0, "y": 0.0}}

	return {"pos": _vec2_to_dict(player.global_position)}



func _save_inventory() -> Dictionary:
	# Your InventoryManager.Inventory is a Dictionary but can contain nulls,
	# so we normalize to int.
	var out := {}
	for k in InventoryManager.Inventory.keys():
		var v = InventoryManager.Inventory[k]
		out[k] = int(v) if v != null else 0
	return out


func _save_time() -> Dictionary:
	var tm := get_node_or_null("/root/TimeManager")
	if tm == null:
		push_warning("Save: TimeManager autoload not found")
		return {"day": 1, "minute": 0, "total_minutes": 0, "time_acc": 0.0}

	return {
		"day": tm.current_day,
		"minute": tm.current_minute,
		"total_minutes": tm.total_minutes,
		"time_acc": tm.time_accumulator,
	}


func _save_tools(root: Node) -> Dictionary:
	# ✅ Your real ToolsPanel path
	var panel := root.get_node_or_null(PATH_TOOLSPANEL)
	if panel == null:
		push_warning("Save: ToolsPanel not found at GameScreen/MarginContainer/VBoxContainer/ToolsPanel")
		return {}

	var data := {}
	for child in panel.get_children():
		if child is Button:
			data[child.name] = not child.disabled

	return data


func _save_tilled_soil(root: Node) -> Dictionary:
	var tilemap := root.get_node_or_null("GameRoot/LevelRoot/Level1/GameTilemap/TilledSoil")
	if tilemap == null:
		push_warning("Save: TilledSoil not found under Level1/GameTilemap/TilledSoil")
		return {"cells": []}

	var cells := []
	for c in tilemap.get_used_cells():
		cells.append(_vec2i_to_dict(c))

	return {
		"cells": cells
	}


func _save_crops(root: Node) -> Array:
	# Saves all crops under CropFields:
	# - scene path (corn/tomato)
	# - global position
	# - growth state + timing fields

	var crops_root := root.get_node_or_null("GameRoot/LevelRoot/Level1/CropFields")
	if crops_root == null:
		push_warning("Save crops skipped: CropFields not found.")
		return []

	var arr: Array = []

	for crop in crops_root.get_children():
		if not (crop is Node2D):
			continue

		var crop2d := crop as Node2D
		var g := crop2d.get_node_or_null("GrowthCycleComponent") as GrowthCycleComponent
		if g == null:
			continue

		arr.append({
			"scene": crop2d.scene_file_path,
			"pos": _vec2_to_dict(crop2d.global_position),
			"growth": {
				"state": int(g.current_growth_state),
				"is_watered": bool(g.is_watered),
				"starting_total_minutes": int(g.starting_total_minutes),
				"last_watered_day": int(g.last_watered_day),
				"days_until_harvest": int(g.days_until_harvest),
				"minutes_per_growth_stage": int(g.minutes_per_growth_stage)
			}
		})

	print("Saved crops:", arr.size(), " CropFields:", crops_root.get_path())
	return arr


# ---------- Apply load data ----------

func _apply_save_dictionary(d: Dictionary) -> void:
	var root := _get_main_scene()
	if root == null:
		push_warning("Load skipped: /root/MainScene not found yet.")
		return

	# ───────── Player ─────────
	var player := root.get_node_or_null(PATH_PLAYER)
	if player != null and d.has("player") and d.player.has("pos"):
		player.global_position = _dict_to_vec2(d.player.pos)

	# ───────── Inventory ─────────
	if d.has("inventory"):
		InventoryManager.set_inventory(d.inventory)
		InventoryManager.inventory_changed.emit()
		print("Loaded inventory:", InventoryManager.Inventory)

	# ───────── Time (SET FIRST) ─────────
	if d.has("time"):
		TimeManager.apply_loaded_time(
			int(d.time.day),
			int(d.time.minute),
			int(d.time.total_minutes),
			float(d.time.time_acc)
		)
		print("Loaded time:", TimeManager.current_day, TimeManager.current_minute)

	# ───────── Tools ─────────
	if d.has("tools"):
		ToolManager.enabled_tools = d.tools.duplicate(true)
		# Re-emit tool enables so UI updates correctly
		for k in ToolManager.enabled_tools.keys():
			if ToolManager.enabled_tools[k]:
				ToolManager.enable_tool.emit(int(k))

	# ───────── Tilled soil ─────────
	if d.has("tilled_soil"):
		_load_tilled_soil(root, d.tilled_soil)

	# ───────── Crops ─────────
	if d.has("crops"):
		_load_crops(root, d.crops)

	# ───────── FORCE TIME SYNC (MUST BE LAST) ─────────
	TimeManager.time_changed.emit(
		TimeManager.current_day,
		int(TimeManager.current_minute / 60),
		int(TimeManager.current_minute % 60)
	)

	print(
		"APPLY root:", root,
		" level1:", root.get_node_or_null("GameRoot/LevelRoot/Level1"),
		" crops:", d.get("crops", []).size(),
		" tilled cells:", d.get("tilled_soil", {}).get("cells", []).size()
	)


func apply_pending_save():
	if _pending_save.is_empty():
		return

	if not _world_ready():
		print("apply_pending_save: world not ready yet (MainScene/Level1 missing)")
		return

	print("apply_pending_save: applying now")
	_apply_save_dictionary(_pending_save)
	_pending_save.clear()


func _load_tools(root: Node, data: Dictionary):
	var panel := root.get_node_or_null(PATH_TOOLSPANEL)
	if panel == null:
		return

	for child in panel.get_children():
		if child is Button and data.has(child.name):
			child.disabled = not bool(data[child.name])


func _load_tilled_soil(root: Node, data: Dictionary):
	var tilemap := root.get_node_or_null("GameRoot/LevelRoot/Level1/GameTilemap/TilledSoil")
	if tilemap == null:
		return

	tilemap.clear()

	var cells := []
	for c in data.get("cells", []):
		cells.append(_dict_to_vec2i(c))

	if cells.size() > 0:
		tilemap.set_cells_terrain_connect(cells, TILLED_TERRAIN_SET, TILLED_TERRAIN, true)
	print("After load tilled, used cells:", tilemap.get_used_cells().size())


func _load_crops(root: Node, arr: Array) -> void:
	# Loads crops from JSON (new format only).
	# Expects each entry:
	# {
	#   "scene": "res://...",
	#   "pos": {"x":..., "y":...},
	#   "growth": {...}
	# }

	var parent := root.get_node_or_null("GameRoot/LevelRoot/Level1/CropFields") as Node
	if parent == null:
		push_warning("Load crops skipped: CropFields not found.")
		return

	# Remove existing crops first
	for c in parent.get_children():
		c.queue_free()

	# Spawn all crops from save
	for e in arr:
		if typeof(e) != TYPE_DICTIONARY:
			continue

		var scene_path := str(e.get("scene", ""))
		if scene_path.is_empty():
			continue

		var packed := load(scene_path) as PackedScene
		if packed == null:
			push_warning("Load crops: failed to load scene: %s" % scene_path)
			continue

		var crop := packed.instantiate() as Node2D
		if crop == null:
			continue

		parent.add_child(crop)

		# Set position AFTER adding to tree (global transform becomes correct)
		crop.global_position = _dict_to_vec2(e.get("pos", {}))

		# Restore growth state/timers
		var g := crop.get_node_or_null("GrowthCycleComponent") as GrowthCycleComponent
		if g == null:
			continue

		var growth = e.get("growth", {})
		if typeof(growth) != TYPE_DICTIONARY:
			continue

		g.current_growth_state = int(growth.get("state", int(g.current_growth_state)))
		g.is_watered = bool(growth.get("is_watered", g.is_watered))

		g.starting_total_minutes = int(growth.get("starting_total_minutes", g.starting_total_minutes))
		g.last_watered_day = int(growth.get("last_watered_day", g.last_watered_day))

		g.days_until_harvest = int(growth.get("days_until_harvest", g.days_until_harvest))
		g.minutes_per_growth_stage = int(growth.get("minutes_per_growth_stage", g.minutes_per_growth_stage))

	print("Loaded crops:", parent.get_child_count(), " CropFields:", parent.get_path())

# ---------- Helpers ----------

func _ensure_save_dir():
	if not DirAccess.dir_exists_absolute(SAVE_DIR):
		DirAccess.make_dir_absolute(SAVE_DIR)


func _vec2_to_dict(v: Vector2) -> Dictionary:
	return {"x": v.x, "y": v.y}

func _dict_to_vec2(d: Dictionary) -> Vector2:
	return Vector2(float(d.get("x", 0.0)), float(d.get("y", 0.0)))

func _vec2i_to_dict(v: Vector2i) -> Dictionary:
	return {"x": v.x, "y": v.y}

func _dict_to_vec2i(d: Dictionary) -> Vector2i:
	return Vector2i(int(d.get("x", 0)), int(d.get("y", 0)))


func _get_scene_root() -> Node:
	var cs := get_tree().current_scene
	if cs != null:
		return cs

	var r := get_tree().root
	if r.get_child_count() > 0:
		return r.get_child(r.get_child_count() - 1)

	return null

func _get_main_scene() -> Node:
	return get_node_or_null("/root/MainScene")

func _world_ready() -> bool:
	var main := _get_main_scene()
	return main != null and main.get_node_or_null("GameRoot/LevelRoot/Level1") != null
