extends PanelContainer

@onready var tool_axe: Button = $MarginContainer/HBoxContainer/ToolAxe
@onready var tool_tilling: Button = $MarginContainer/HBoxContainer/ToolTilling
@onready var tool_watering_can: Button = $MarginContainer/HBoxContainer/ToolWateringCan
@onready var tool_corn: Button = $MarginContainer/HBoxContainer/ToolCorn
@onready var tool_tomato: Button = $MarginContainer/HBoxContainer/ToolTomato


func _ready() -> void:
	ToolManager.enable_tool.connect(on_enable_tool_button)

	# Default: disabled (except axe)
	_set_enabled(tool_tilling, false)
	_set_enabled(tool_watering_can, false)
	_set_enabled(tool_corn, false)
	_set_enabled(tool_tomato, false)

	# Sync from ToolManager stored state (important after load / recreated UI)
	if ToolManager.is_tool_enabled(DataTypes.Tools.TillGround):
		on_enable_tool_button(DataTypes.Tools.TillGround)
	if ToolManager.is_tool_enabled(DataTypes.Tools.WaterCrops):
		on_enable_tool_button(DataTypes.Tools.WaterCrops)
	if ToolManager.is_tool_enabled(DataTypes.Tools.PlantCorn):
		on_enable_tool_button(DataTypes.Tools.PlantCorn)
	if ToolManager.is_tool_enabled(DataTypes.Tools.PlantTomato):
		on_enable_tool_button(DataTypes.Tools.PlantTomato)


func _set_enabled(btn: Button, enabled: bool) -> void:
	btn.disabled = not enabled
	btn.focus_mode = Control.FOCUS_ALL if enabled else Control.FOCUS_NONE


func _on_tool_axe_pressed() -> void:
	ToolManager.select_tool(DataTypes.Tools.AxeWood)

func _on_tool_tilling_pressed() -> void:
	ToolManager.select_tool(DataTypes.Tools.TillGround)

func _on_tool_watering_can_pressed() -> void:
	ToolManager.select_tool(DataTypes.Tools.WaterCrops)

func _on_tool_corn_pressed() -> void:
	ToolManager.select_tool(DataTypes.Tools.PlantCorn)

func _on_tool_tomato_pressed() -> void:
	ToolManager.select_tool(DataTypes.Tools.PlantTomato)


func _unhandled_input(event: InputEvent) -> void:
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_RIGHT:
		ToolManager.select_tool(DataTypes.Tools.None)
		tool_axe.release_focus()
		tool_tilling.release_focus()
		tool_watering_can.release_focus()
		tool_corn.release_focus()
		tool_tomato.release_focus()


func on_enable_tool_button(tool: DataTypes.Tools) -> void:
	match tool:
		DataTypes.Tools.TillGround:
			_set_enabled(tool_tilling, true)
		DataTypes.Tools.WaterCrops:
			_set_enabled(tool_watering_can, true)
		DataTypes.Tools.PlantCorn:
			_set_enabled(tool_corn, true)
		DataTypes.Tools.PlantTomato:
			_set_enabled(tool_tomato, true)
