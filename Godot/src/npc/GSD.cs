using Godot;

namespace ET {
public partial class GSD : NPC  // Assuming NPCBase is the base class for NPC
{
    [Export] private Popup menu;
    GlobalManager GlobalManager;
    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        ambCount = 1;
        fwCount = 3;
        tkCount = 3;
        menu = GetNode<Popup>("Menu_GSD");
    }

    // 显示menu
    public override void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    private void _on_TalkBtn_pressed()
    {
        // Replace with function body
    }

    private void _on_ShopBtn_pressed()
    {
        // Replace with function body
    }

    private void _on_SkillBtn_pressed()
    {
        GlobalManager.Instance.main.OnOpenWindow("Skillbuy", "res://scenes/UI/Skillbuy.tscn");
        menu.Hide();
    }

    private void _on_TaskBtn_pressed()
    {
        // Replace with function body
    }
}
/*
主要翻译思路：

@onready 被转换为 C# 的 GetNode，因为 @onready 是 GDScript 中用于在 _ready 中初始化节点的装饰器，C# 中则通过 GetNode<T>() 函数来获取节点。
函数名保持不变，按照 C# 命名规则，事件绑定方法一般保持为 private。
Godot 的事件机制可以使用 _on_TalkBtn_pressed() 等方法作为信号连接的事件处理函数。

你可以根据具体的项目需求对基类和信号的连接进一步调整。
*/
}