using Godot;

namespace ET {
public partial class Motion : IState
{
    // Signal for state change
    //[Signal]
    //public delegate void FinishedEventHandler(Node currentState);
    // 处理输入
    public override void HandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("simulate_damage"))
        {
            EmitSignal(SignalName.Finished, "damage");
        }
        base.HandleInput(@event);
    }



    // 更新方向
    public void UpdateLookDirection(Vector2 direction)

    {
        Vector2 lookDirection = (Vector2)Owner.Get("lookDirection");
        if (direction != Vector2.Zero && lookDirection.X != direction.X && direction.X != 0)
        {
            // GetParent().GetParent().Call("FlipH", (direction.X == -1));
        }
        if (direction != Vector2.Zero && lookDirection != direction)
        {
            Owner.Set("lookDirection", direction);
        }
    }
}

}