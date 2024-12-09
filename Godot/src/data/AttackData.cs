using Godot;

public partial class AttackData : Node
{
    // 伤害
    public int Damage { get; set; } = 0;

    // x轴变化量
    public int XOffset { get; set; } = 0;

    // z轴变化量
    public int ZOffset { get; set; } = 0;
}
