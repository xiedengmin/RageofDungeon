using Godot;

namespace ET {
public partial class Idle : OnGround
{
    //  [Signal]
    //  public delegate void FinishedEventHandler(string nextStateName);
    public override void _Ready()
    {
        base._Ready();
        // 其他初始化代码（如果需要）
    }

    public override void Enter()
    {
        var animationPlayer = Owner.GetNode<AnimationPlayer>("AnimationPlayer");
        animationPlayer.Play("rest");
    }

    public override void HandleInput(InputEvent @event)
    {

        base.HandleInput(@event);
    }


    public override void Update(float delta)
    {
        var inputDirection = InputManager.Instance.GetInputDirection();
        if (inputDirection != Vector2.Zero)
        {
            EmitSignal(SignalName.Finished, "move");
        }
    }

}

}