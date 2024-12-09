@tool
extends EditorPlugin
func _enter_tree():
	add_custom_type("CutBitmapFont","FontFile",preload("cutter.cs"),preload("icon.png"))
	
func _exit_tree():
	remove_custom_type("CutBitmapFont")
