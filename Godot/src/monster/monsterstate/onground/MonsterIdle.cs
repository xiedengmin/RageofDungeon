using Godot;

public partial class MonsterIdle:MonsterOnGround 
{
    public override void _EnterTree()
    {
        base._EnterTree();
        var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        animationPlayer.Play("stay");
    }

    // Uncomment if you need to handle input
    // public override void _Input(InputEvent @event)
    // {
    //     base._Input(@event);
    // }

    public override void _Process(double delta)
    {
        // Uncomment if you want to handle input direction
        // var inputDirection = GetInputDirection();
        // if (inputDirection != null)
        // {
        //     EmitSignal("finished", "move");
        // }
    }

    // Uncomment and implement if you need the input direction logic
    // private Vector2 GetInputDirection()
    // {
    //     // Implement your input direction logic here
    //     return Vector2.Zero;
    // }
}