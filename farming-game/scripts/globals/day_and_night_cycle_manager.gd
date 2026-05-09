extends Node

signal time_tick(day: int, hour: int, minute: int)
signal game_time(value: float) # 0..1 fraction of day

@export var minutes_per_second: float = 1.0
var game_speed: int = 5

var _acc: float = 0.0

# ---------------- Compatibility (legacy scripts expect these) ----------------
var was_forced_time: bool = false

# Some scripts assign these at startup
var initial_day: int = 1
var initial_hour: int = 6
var initial_minute: int = 0

# Some scripts read these continuously
var time_tick_day: int = 1
var time_tick_hour: int = 0
var time_tick_minute: int = 0
# ---------------------------------------------------------------------------


func _ready() -> void:
	process_mode = Node.PROCESS_MODE_ALWAYS
	TimeManager.time_changed.connect(_on_time_changed)

	# If TimeManager hasn't been set yet, initialize it from "initial_*"
	# (This keeps old "set initial time" logic working)
	if TimeManager.total_minutes == 0 and TimeManager.current_day == 1 and TimeManager.current_minute == 0:
		TimeManager.set_time(initial_day, initial_hour, initial_minute)

	# Emit initial tick/visuals
	_on_time_changed(
		TimeManager.current_day,
		TimeManager.current_minute / 60,
		TimeManager.current_minute % 60
	)


func _process(delta: float) -> void:
	_acc += delta * minutes_per_second * float(game_speed)
	var minutes := int(_acc)
	if minutes > 0:
		_acc -= float(minutes)
		TimeManager.advance_minutes(minutes)


func _on_time_changed(day: int, hour: int, minute: int) -> void:
	time_tick_day = day
	time_tick_hour = hour
	time_tick_minute = minute

	time_tick.emit(day, hour, minute)

	var frac := float(hour * 60 + minute) / 1440.0
	game_time.emit(frac)


# New preferred API
func force_set_time(day: int, hour: int, minute: int) -> void:
	was_forced_time = true
	_acc = 0.0
	TimeManager.set_time(day, hour, minute)


# Legacy-friendly API (optional)
func set_initial_time(day: int, hour: int, minute: int) -> void:
	initial_day = day
	initial_hour = hour
	initial_minute = minute
