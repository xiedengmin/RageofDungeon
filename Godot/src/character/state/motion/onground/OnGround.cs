using Godot;

namespace ET {
public partial class OnGround : Motion
{
    //[Signal]
    // public delegate void FinishedEventHandler(string nextStateName);
    private float speed = 0.0f;
    private Vector2 velocity = new Vector2();

    public override void HandleInput(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed && Input.IsActionPressed("jump"))
        {
            EmitSignal(SignalName.Finished, "jump");
        }
        base.HandleInput(@event);
    }
}
}