# growth_cycle_component.gd
class_name GrowthCycleComponent
extends Node

@export var current_growth_state: DataTypes.GrowthStates = DataTypes.GrowthStates.Germination
@export_range(1, 7) var days_until_harvest: int = 5
@export_range(1, 100000) var minutes_per_growth_stage: int = 1440

signal crop_maturity
signal crop_harvesting
signal growth_state_changed(new_state: int)

var is_watered: bool = false

# Saved/loaded fields (absolute minutes since day 0)
var starting_total_minutes: int = -1
var last_watered_day: int = -1

var _maturity_emitted := false
var _harvest_emitted := false


func _ready() -> void:
	# If not watered, crop stays in Germination
	if not is_watered:
		_set_growth_state(DataTypes.GrowthStates.Germination)

	# Apply immediately after load (no waiting for ticks)
	call_deferred("_apply_growth_from_time")


func water() -> void:
	# Water only once
	if is_watered:
		return

	is_watered = true
	last_watered_day = int(TimeManager.current_day)

	# Store absolute minutes so growth continues across days
	starting_total_minutes = _get_absolute_minutes()

	_maturity_emitted = false
	_harvest_emitted = false

	_set_growth_state(DataTypes.GrowthStates.Germination)
	_apply_growth_from_time()


func _process(_delta: float) -> void:
	if not is_watered:
		return

	# If save didn't contain this field, bootstrap it once
	if starting_total_minutes < 0:
		starting_total_minutes = _get_absolute_minutes()

	_apply_growth_from_time()


func _get_absolute_minutes() -> int:
	return int(TimeManager.current_day) * 1440 + int(TimeManager.current_minute)


func _apply_growth_from_time() -> void:
	if not is_watered:
		_set_growth_state(DataTypes.GrowthStates.Germination)
		return

	# If already harvested, stop updating
	if current_growth_state == DataTypes.GrowthStates.Harvesting:
		return

	var now_abs := _get_absolute_minutes()
	if starting_total_minutes < 0:
		starting_total_minutes = now_abs

	var minutes_passed = max(0, now_abs - starting_total_minutes)

	# ----- Growth stages (minute-based) -----
	# Germination -> Vegetative -> Reproduction -> Maturity
	var stage_index := int(floor(float(minutes_passed) / float(minutes_per_growth_stage)))
	stage_index = clamp(stage_index, 0, 3)

	var new_state := int(DataTypes.GrowthStates.Germination) + stage_index # 1..4
	_set_growth_state(new_state)

	if current_growth_state == DataTypes.GrowthStates.Maturity and not _maturity_emitted:
		_maturity_emitted = true
		crop_maturity.emit()

	# ----- Harvest threshold (minute-based) -----
	var harvest_minutes := int(days_until_harvest) * 1440
	if minutes_passed >= harvest_minutes and not _harvest_emitted:
		_harvest_emitted = true
		_set_growth_state(DataTypes.GrowthStates.Harvesting)
		crop_harvesting.emit()


func _set_growth_state(state: int) -> void:
	state = int(state)
	if int(current_growth_state) == state:
		return
	current_growth_state = state
	growth_state_changed.emit(state)


func get_current_growth_state() -> DataTypes.GrowthStates:
	return current_growth_state
