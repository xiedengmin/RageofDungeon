using Godot;

namespace ET {
public partial class HitBox : Area2D
{
    // 伤害信息
    private AttackData attackData;

    public override void _Ready()
    {
        attackData = new AttackData();
        attackData.Damage = 20;
        attackData.XOffset = 50;
    }

    // 初始化数据
    public void InitData()
    {
        // 实现初始化逻辑
    }
}


}