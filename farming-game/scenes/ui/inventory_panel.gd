extends PanelContainer

@onready var log_label: Label = $MarginContainer/VBoxContainer/Logs/LogLabel
@onready var stone_label: Label = $MarginContainer/VBoxContainer/Stones/StoneLabel
@onready var corn_label: Label = $MarginContainer/VBoxContainer/Corns/CornLabel
@onready var tomato_label: Label = $MarginContainer/VBoxContainer/Tomatos/TomatoLabel
@onready var milk_label: Label = $MarginContainer/VBoxContainer/Milk/MilkLabel
@onready var egg_label: Label = $MarginContainer/VBoxContainer/Eggs/EggLabel

func _ready() -> void:
	if not InventoryManager.inventory_changed.is_connected(on_inventory_changed):
		InventoryManager.inventory_changed.connect(on_inventory_changed)

	# ✅ Important: update immediately (covers load-game case)
	on_inventory_changed()

func on_inventory_changed() -> void:
	var inv: Dictionary = InventoryManager.Inventory

	log_label.text = str(int(inv.get("log", 0)))
	stone_label.text = str(int(inv.get("stone", 0)))
	corn_label.text = str(int(inv.get("corn", 0)))
	tomato_label.text = str(int(inv.get("tomato", 0)))
	egg_label.text = str(int(inv.get("egg", 0)))
	milk_label.text = str(int(inv.get("milk", 0)))
