using Godot;

public partial class MonsterHP : CanvasLayer
{
    // 获取控件引用
    [Export] private MonsterHPNormal normalHp;
    [Export] private Control eliteHp;
    [Export] private Control bossHp;

    public override void _Ready()
    {
        // 在 _Ready 中初始化控件（类似于 GDScript 中的 @onready）
        normalHp =(MonsterHPNormal) GetNode<Control>("Monster_HP_Normal");
        eliteHp = GetNode<Control>("Monster_HP_Elite");
        bossHp = GetNode<Control>("Monster_HP_BOSS");
    }

    public void ShowHp(string type, MonsterStatus status)
    {
        if (type == "normal")
        {
            ChangeHp(true, false, false);
            normalHp.InitData(status); // 调用 GDScript 中的 init_data 方法
        }
        else if (type == "elite")
        {
            ChangeHp(false, true, false);
        }
        else if (type == "boss")
        {
            ChangeHp(false, false, true);
        }
    }

    private void ChangeHp(bool value1, bool value2, bool value3)
    {
        if (normalHp.Visible != value1)
        {
            normalHp.Visible = value1;
        }
        if (eliteHp.Visible != value2)
        {
            eliteHp.Visible = value2;
        }
        if (bossHp.Visible != value3)
        {
            bossHp.Visible = value3;
        }
    }
}