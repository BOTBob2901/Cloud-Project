# corn.gd
extends Node2D

var corn_harvest_scene := preload("res://scenes/objects/plants/corn_harvest.tscn")

@onready var sprite_2d: Sprite2D = $Sprite2D
@onready var watering_particles: GPUParticles2D = $WateringParticles
@onready var flowering_particles: GPUParticles2D = $FloweringParticles
@onready var growth_cycle_component: GrowthCycleComponent = $GrowthCycleComponent
@onready var hurt_component: HurtComponent = $HurtComponent

var growth_state: DataTypes.GrowthStates = DataTypes.GrowthStates.Germination

func _ready() -> void:
	watering_particles.emitting = false
	flowering_particles.emitting = false

	hurt_component.hurt.connect(on_hurt)
	growth_cycle_component.crop_maturity.connect(on_crop_maturity)
	growth_cycle_component.crop_harvesting.connect(on_crop_harvesting)

	# If loaded already in Harvesting, transform immediately
	if growth_cycle_component.current_growth_state == DataTypes.GrowthStates.Harvesting:
		call_deferred("on_crop_harvesting")

func _process(_delta: float) -> void:
	growth_state = growth_cycle_component.get_current_growth_state()

	# Corn spritesheet frames:
	# 0..5 => Seed..Harvesting
	sprite_2d.frame = int(growth_state)

	flowering_particles.emitting = (growth_state == DataTypes.GrowthStates.Maturity)

func on_hurt(_hit_damage: int) -> void:
	# Water only once
	if growth_cycle_component.is_watered:
		return

	watering_particles.emitting = true
	await get_tree().create_timer(5.0).timeout
	watering_particles.emitting = false

	# Start growth logic
	growth_cycle_component.water()

func on_crop_maturity() -> void:
	flowering_particles.emitting = true

func on_crop_harvesting() -> void:
	_disable_collisions_recursive(self)

	var harvest := corn_harvest_scene.instantiate() as Node2D
	harvest.global_position = global_position
	get_parent().add_child(harvest)

	call_deferred("queue_free")

func _disable_collisions_recursive(node: Node) -> void:
	for child in node.get_children():
		if child is CollisionShape2D:
			(child as CollisionShape2D).set_deferred("disabled", true)
		_disable_collisions_recursive(child)
