extends CanvasModulate

@export var initial_day: int = 1
@export var initial_hour: int = 6
@export var initial_minute: int = 0
@export var day_night_gradient_texture: GradientTexture1D

func _ready() -> void:
	# Only apply inspector "initial_*" values if a save-load didn't already force time
	if not DayAndNightCycleManager.was_forced_time:
		DayAndNightCycleManager.initial_day = initial_day
		DayAndNightCycleManager.initial_hour = initial_hour
		DayAndNightCycleManager.initial_minute = initial_minute
		DayAndNightCycleManager.set_initial_time(initial_day, initial_hour, initial_minute)
	DayAndNightCycleManager.game_time.connect(on_game_time)

func on_game_time(time: float) -> void:
	# Sample the gradient using the normalized time value
	color = day_night_gradient_texture.gradient.sample(time)
