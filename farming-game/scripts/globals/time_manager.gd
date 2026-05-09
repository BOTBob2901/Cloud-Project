extends Node

signal time_changed(day: int, hour: int, minute: int)

# Day starts at 1 (matches your UI "Day 1")
var current_day: int = 1

# Minute of day: 0..1439
var current_minute: int = 0

# Total minutes since day 1, 00:00 (useful for saving)
var total_minutes: int = 0

# Kept for compatibility with your JSON (optional)
var time_accumulator: float = 0.0


func advance_minutes(delta_minutes: int) -> void:
	if delta_minutes <= 0:
		return

	total_minutes += delta_minutes
	current_minute += delta_minutes

	while current_minute >= 1440:
		current_minute -= 1440
		current_day += 1

	_emit_time_changed()


func set_time(day: int, hour: int, minute: int) -> void:
	current_day = max(day, 1)
	current_minute = clamp(hour * 60 + minute, 0, 1439)
	total_minutes = (current_day - 1) * 1440 + current_minute
	time_accumulator = 0.0
	_emit_time_changed()


func apply_loaded_time(day: int, minute_of_day: int, total: int, acc: float) -> void:
	current_day = max(day, 1)
	current_minute = clamp(minute_of_day, 0, 1439)
	total_minutes = max(total, 0)
	time_accumulator = acc
	_emit_time_changed()


func _emit_time_changed() -> void:
	@warning_ignore("integer_division")
	var hour := current_minute / 60
	var minute := current_minute % 60
	time_changed.emit(current_day, hour, minute)
