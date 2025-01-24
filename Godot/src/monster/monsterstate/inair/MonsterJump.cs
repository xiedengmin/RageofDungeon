using Godot;
namespace ET {
public partial class MonsterJump : MonsterMotion
{

    public double speed = 0.0;
    private Vector2 velocity = new Vector2();
    //func handle_input(event):
    /*#	if event.is_action_pressed("jump"):
    #		emit_signal("finished", "jump")
    #	return super.handle_input(event) */
}
}