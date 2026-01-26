extends Node2D

var balloon_scene = preload("res://dialogue/game_dialogue_balloon.tscn")

var corn_harvest_scene = preload("res://scenes/objects/plants/corn_harvest.tscn")
var tomato_harvest_scene = preload("res://scenes/objects/plants/tomato_harvest.tscn")

@export var dialogue_start_command: String
@export var food_drop_height: int = 40
@export var reward_output_radius: int = 20
@export var output_reward_scenes: Array[PackedScene] = []

@onready var interactable_component: InteractableComponent = $InteractableComponent
@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D
@onready var feed_component: FeedComponent = $FeedComponent
@onready var reward_marker: Marker2D = $RewardMarker
@onready var interactable_label_component: Control = $InteractableLabelComponent

var in_range := false
var is_chest_open := false

func _ready() -> void:
	interactable_component.interactable_activated.connect(on_interactable_activated)
	interactable_component.interactable_deactivated.connect(on_interactable_deactivated)
	interactable_label_component.hide()

	GameDialogueManager.feed_the_animals.connect(on_feed_the_animals)
	feed_component.food_received.connect(on_food_received)

func on_interactable_activated() -> void:
	interactable_label_component.show()
	in_range = true

func on_interactable_deactivated() -> void:
	if is_chest_open:
		animated_sprite_2d.play("chest_close")
	is_chest_open = false
	interactable_label_component.hide()
	in_range = false

func _unhandled_input(event: InputEvent) -> void:
	if in_range and event.is_action_pressed("show_dialogue"):
		interactable_label_component.hide()
		animated_sprite_2d.play("chest_open")
		is_chest_open = true

		var balloon := balloon_scene.instantiate()
		get_tree().root.add_child(balloon)
		balloon.start(load("res://dialogue/conversations/chest.dialogue"), dialogue_start_command)

# 5 corn + 5 tomato = 1 reward
func on_feed_the_animals() -> void:
	if not in_range:
		return

	var inv := InventoryManager.Inventory
	var corn := int(inv.get("corn", 0))
	var tomato := int(inv.get("tomato", 0))

	var reward_count = min(corn / 5, tomato / 5)
	if reward_count <= 0:
		return

	for i in range(reward_count):
		for j in range(5):
			await _feed_single("corn", corn_harvest_scene)
			await _feed_single("tomato", tomato_harvest_scene)

		add_reward_scene()

func _feed_single(item_name: String, scene: PackedScene) -> void:
	var inv := InventoryManager.Inventory
	if int(inv.get(item_name, 0)) <= 0:
		return

	var harvest := scene.instantiate() as Node2D
	harvest.global_position = Vector2(global_position.x, global_position.y - food_drop_height)
	get_tree().root.add_child(harvest)

	var target := feed_component.global_position

	var delay := randf_range(0.5, 2.0)
	await get_tree().create_timer(delay).timeout

	var tween := get_tree().create_tween()
	tween.tween_property(harvest, "global_position", target, 1.0)
	tween.tween_property(harvest, "scale", Vector2(0.5, 0.5), 1.0)
	tween.tween_callback(harvest.queue_free)

	InventoryManager.remove_collectable(item_name)

func on_food_received(_area: Area2D) -> void:
	pass

func add_reward_scene() -> void:
	for packed in output_reward_scenes:
		var reward := packed.instantiate() as Node2D
		reward.global_position = get_random_position_in_circle(reward_marker.global_position, reward_output_radius)
		get_tree().root.add_child(reward)

func get_random_position_in_circle(center: Vector2, radius: int) -> Vector2:
	var angle := randf() * TAU
	var distance := sqrt(randf()) * radius
	return Vector2(
		center.x + cos(angle) * distance,
		center.y + sin(angle) * distance
	)
