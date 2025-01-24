using Godot;
namespace ET {
public partial class HurtBox : Area2D
{
    private PackedScene HitEffect = (PackedScene)GD.Load("res://scenes/areabox/HitEffect.tscn");

    public override void _Ready()
    {
        // 初始化时执行的代码
    }

    private void OnHurtBoxAreaEntered(Area2D area2d)
    {
        var effect = (Node2D)HitEffect.Instantiate();
        var parent = GetParent();
        effect.Position = new Vector2(26, 0);
        parent.AddChild(effect);
    }
}
}