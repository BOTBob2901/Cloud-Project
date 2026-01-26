class_name CropCurserComponent
extends Node

@export var tilled_soil_tilemap_layer: TileMapLayer
@export var plant_distance: float = 20.0

var player: Player

var corn_plant_scene: PackedScene = preload("res://scenes/objects/plants/corn.tscn")
var tomato_plant_scene: PackedScene = preload("res://scenes/objects/plants/tomato.tscn")

var mouse_position: Vector2
var cell_position: Vector2i
var cell_source_id: int
var cell_global_position: Vector2
var distance: float

var _crop_fields: Node = null


func _ready() -> void:
	await get_tree().process_frame
	_refresh_refs()


func _refresh_refs() -> void:
	player = get_tree().get_first_node_in_group("player") as Player
	_crop_fields = get_parent().find_child("CropFields")


func _get_player() -> Player:
	if player == null or not is_instance_valid(player):
		player = get_tree().get_first_node_in_group("player") as Player
	return player


func _get_crop_fields() -> Node:
	if _crop_fields == null or not is_instance_valid(_crop_fields):
		_crop_fields = get_parent().find_child("CropFields")
	return _crop_fields


func _unhandled_input(event: InputEvent) -> void:
	if event.is_action_pressed("remove_dirt"):
		if ToolManager.selected_tool == DataTypes.Tools.TillGround:
			get_cell_under_mouse()
			remove_crop()

	elif event.is_action_pressed("hit"):
		if ToolManager.selected_tool == DataTypes.Tools.PlantCorn or ToolManager.selected_tool == DataTypes.Tools.PlantTomato:
			get_cell_under_mouse()
			add_crop()


func get_cell_under_mouse() -> void:
	var p := _get_player()
	if p == null or tilled_soil_tilemap_layer == null:
		return

	mouse_position = tilled_soil_tilemap_layer.get_local_mouse_position()
	cell_position = tilled_soil_tilemap_layer.local_to_map(mouse_position)
	cell_source_id = tilled_soil_tilemap_layer.get_cell_source_id(cell_position)

	# Convert tile cell position to GLOBAL (distance compare must be in the same space)
	var cell_local := tilled_soil_tilemap_layer.map_to_local(cell_position)
	cell_global_position = tilled_soil_tilemap_layer.to_global(cell_local)

	distance = p.global_position.distance_to(cell_global_position)


func _cell_has_crop(cell: Vector2i) -> bool:
	var crop_fields := _get_crop_fields()
	if crop_fields == null:
		return false

	# Compare by CELL, not by global position (prevents stacking due to float differences)
	for n in crop_fields.get_children():
		if n is Node2D:
			var crop_global := (n as Node2D).global_position
			var crop_local := tilled_soil_tilemap_layer.to_local(crop_global)
			var crop_cell := tilled_soil_tilemap_layer.local_to_map(crop_local)
			if crop_cell == cell:
				return true

	return false


func add_crop() -> void:
	# Must be close enough AND only on tilled soil (source_id != -1)
	if distance >= plant_distance:
		return
	if cell_source_id == -1:
		return

	# ✅ Prevent planting multiple crops in the same cell
	if _cell_has_crop(cell_position):
		return

	var crop_instance: Node2D = null
	if ToolManager.selected_tool == DataTypes.Tools.PlantCorn:
		crop_instance = corn_plant_scene.instantiate() as Node2D
	elif ToolManager.selected_tool == DataTypes.Tools.PlantTomato:
		crop_instance = tomato_plant_scene.instantiate() as Node2D

	if crop_instance == null:
		return

	crop_instance.global_position = cell_global_position

	var crop_fields := _get_crop_fields()
	if crop_fields != null:
		crop_fields.add_child(crop_instance)


func remove_crop() -> void:
	if distance >= plant_distance:
		return

	var crop_fields := _get_crop_fields()
	if crop_fields == null:
		return

	# Remove by CELL (not by exact global pos)
	for node in crop_fields.get_children():
		if node is Node2D:
			var crop_global := (node as Node2D).global_position
			var crop_local := tilled_soil_tilemap_layer.to_local(crop_global)
			var crop_cell := tilled_soil_tilemap_layer.local_to_map(crop_local)
			if crop_cell == cell_position:
				node.queue_free()
				return
