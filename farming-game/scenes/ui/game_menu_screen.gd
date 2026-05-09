extends CanvasLayer

@onready var save_game_button: Button = $MarginContainer/VBoxContainer/SaveGameButton

func _ready() -> void:
	_refresh()
	await get_tree().process_frame
	_refresh()

func _refresh() -> void:
	var can := SaveGameManager.can_save()
	save_game_button.disabled = not can
	save_game_button.focus_mode = Control.FOCUS_ALL if can else Control.FOCUS_NONE

func _on_start_game_button_pressed() -> void:
	await GameManager.start_game()
	_refresh()
	queue_free()

func _on_save_game_button_pressed() -> void:
	SaveGameManager.save_game()
	_refresh() # optional: keep UI consistent if save changes state later

func _on_exit_game_button_pressed() -> void:
	GameManager.exit_game()
