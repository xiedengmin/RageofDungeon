using Godot;

public partial class Damage : IState
{
    //   [Signal]
    //  public delegate void FinishedEventHandler(string nextStateName);
    public override void Enter()
    {
        // 播放“damage1”动画
        Owner.Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("damage1");
    }

    public override void OnAnimationFinished(string animName)
    {
        // assert(animName == "damage1");
        EmitSignal(SignalName.Finished, "idle");
    }
}
