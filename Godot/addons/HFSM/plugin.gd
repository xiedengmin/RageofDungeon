@tool
extends EditorPlugin


const AUTOLOAD_NAME = "HFSM"


#func _enter_tree() -> void:
	#add_autoload_singleton(AUTOLOAD_NAME, "res://addons/HFSM/coroutine_manager.tscn")


func _exit_tree() -> void:
	remove_autoload_singleton(AUTOLOAD_NAME)
