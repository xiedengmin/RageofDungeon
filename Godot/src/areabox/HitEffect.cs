using Godot;

public partial class HitEffect : Node2D
{
    [Export]
    private AnimatedSprite2D effect;

    public override void _Ready()
    {
        effect = GetNode<AnimatedSprite2D>("Effect");
        effect.Play("default");
    }

    private void _OnEffectAnimationFinished()
    {
        QueueFree();
    }
}