extends Node

var game_menu_screen := preload("res://scenes/ui/game_menu_screen.tscn")

func _unhandled_input(event: InputEvent) -> void:
	if event.is_action_pressed("game_menu"):
		toggle_game_menu_screen()

func start_game() -> void:
	SceneManager.load_main_scene_container()
	await SceneManager.load_level("Level1")
	await get_tree().process_frame

	SaveGameManager.load_game()          # loads into pending
	SaveGameManager.apply_pending_save() # applies now that world exists

	SaveGameManager.allow_save_game = true


func exit_game() -> void:
	get_tree().quit()

func toggle_game_menu_screen() -> void:
	# Don't open the in-game menu before the game actually started
	if not SaveGameManager.allow_save_game:
		return

	var existing := get_tree().root.get_node_or_null("GameMenuScreen")
	if existing != null:
		existing.queue_free()
		return

	var inst := game_menu_screen.instantiate()
	inst.name = "GameMenuScreen"
	get_tree().root.add_child(inst)
