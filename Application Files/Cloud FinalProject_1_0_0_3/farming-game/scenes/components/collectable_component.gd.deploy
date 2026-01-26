# collectable_component.gd
class_name CollectableComponent
extends Area2D

@export var collectable_name: String

func _ready() -> void:
	# Safety: ensure the signal is connected even if the editor connection got lost
	if not body_entered.is_connected(_on_body_entered):
		body_entered.connect(_on_body_entered)

func _on_body_entered(body: Node2D) -> void:
	if body is Player:
		InventoryManager.add_collectable(collectable_name)
		print("Collected: ", collectable_name)
		get_parent().queue_free()
