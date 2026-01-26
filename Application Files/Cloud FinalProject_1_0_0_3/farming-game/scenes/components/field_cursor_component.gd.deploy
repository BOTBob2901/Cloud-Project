class_name FieldCurserComponent
extends Node

@export var grass_tilemap_layer: TileMapLayer
@export var tilled_soil_tilemap_layer: TileMapLayer
@export var terrain_set: int = 0
@export var terrain: int = 3

var player: Player
var cell_position: Vector2i
var cell_source_id: int
var cell_global_position: Vector2
var distance: float

func _ready() -> void:
	await get_tree().process_frame
	_refresh_player()

func _refresh_player() -> void:
	player = get_tree().get_first_node_in_group("player") as Player

func _get_player() -> Player:
	if player == null or not is_instance_valid(player):
		_refresh_player()
	return player

func _unhandled_input(event: InputEvent) -> void:
	if event.is_action_pressed("remove_dirt"):
		if ToolManager.selected_tool == DataTypes.Tools.TillGround:
			_get_cell_under_mouse()
			_remove_tilled_soil_cell()

	elif event.is_action_pressed("hit"):
		if ToolManager.selected_tool == DataTypes.Tools.TillGround:
			_get_cell_under_mouse()
			_add_tilled_soil_cell()

func _get_cell_under_mouse() -> void:
	var p := _get_player()
	if p == null or grass_tilemap_layer == null:
		return

	var mouse_local := grass_tilemap_layer.get_local_mouse_position()
	cell_position = grass_tilemap_layer.local_to_map(mouse_local)
	cell_source_id = grass_tilemap_layer.get_cell_source_id(cell_position)

	# convert cell -> global so we compare correctly to player.global_position
	var cell_local := grass_tilemap_layer.map_to_local(cell_position)
	cell_global_position = grass_tilemap_layer.to_global(cell_local)

	distance = p.global_position.distance_to(cell_global_position)

func _add_tilled_soil_cell() -> void:
	if distance < 20.0 and cell_source_id != -1:
		tilled_soil_tilemap_layer.set_cells_terrain_connect([cell_position], terrain_set, terrain, true)

func _remove_tilled_soil_cell() -> void:
	if distance < 20.0:
		tilled_soil_tilemap_layer.set_cells_terrain_connect([cell_position], 0, -1, true)
