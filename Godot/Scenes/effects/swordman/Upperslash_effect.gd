extends Node2D


func _ready():
	pass
	$AnimationPlayer.play("default");


func _on_AnimationPlayer_animation_finished(anim_name):
	pass # Replace with function body.
	queue_free();
