extends Node

var selected_tool: DataTypes.Tools = DataTypes.Tools.None

# tool -> bool
var enabled_tools: Dictionary = {}

signal tool_selected(tool: DataTypes.Tools)
signal enable_tool(tool: DataTypes.Tools)


func _ready() -> void:
	GameDialogueManager.give_crop_seeds.connect(_on_give_crop_seeds)


func select_tool(tool: DataTypes.Tools) -> void:
	selected_tool = tool
	tool_selected.emit(tool)


func is_tool_enabled(tool: DataTypes.Tools) -> bool:
	return enabled_tools.get(tool, false)


func enable_tool_button(tool: DataTypes.Tools) -> void:
	# Persist state so UI can sync even if created later
	if not enabled_tools.get(tool, false):
		enabled_tools[tool] = true
		enable_tool.emit(tool)


func enable_tools(list: Array) -> void:
	for t in list:
		enable_tool_button(t)


func _on_give_crop_seeds() -> void:
	enable_tools([
		DataTypes.Tools.TillGround,
		DataTypes.Tools.WaterCrops,
		DataTypes.Tools.PlantCorn,
		DataTypes.Tools.PlantTomato
	])
