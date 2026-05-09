extends Node

# Stores counts as ints: { "log": 3, "corn": 12, ... }
var Inventory: Dictionary = {}

signal inventory_changed

func set_inventory(new_inventory: Dictionary) -> void:
	Inventory.clear()
	for k in new_inventory.keys():
		Inventory[str(k)] = int(new_inventory[k])
	inventory_changed.emit()

func get_count(item: String) -> int:
	return int(Inventory.get(item, 0))

func add_collectable(collectable_name: String) -> void:
	var key := str(collectable_name)
	Inventory[key] = int(Inventory.get(key, 0)) + 1
	inventory_changed.emit()

func remove_collectable(collectable_name: String) -> void:
	var key := str(collectable_name)
	var v := int(Inventory.get(key, 0))
	if v > 0:
		Inventory[key] = v - 1
	inventory_changed.emit()

func remove_many(collectable_name: String, amount: int) -> void:
	if amount <= 0:
		return
	var key := str(collectable_name)
	var v := int(Inventory.get(key, 0))
	Inventory[key] = max(0, v - amount)
	inventory_changed.emit()

func clear_inventory() -> void:
	Inventory.clear()
	inventory_changed.emit()
