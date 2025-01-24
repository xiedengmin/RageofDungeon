using Godot;

namespace ET {
public partial class Birden2 : NPC  // Assuming NPC.cs extends a base NPC class
{
    [Export] private PopupMenu menu;

    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        ambCount = 1;
        fwCount = 5;
        tkCount = 5;
    }

    // 显示菜单
    public override void ShowMenu()
    {
        menu.Position = (Vector2I)GetGlobalMousePosition();
        menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        // Replace with function body
    }

    private void OnShopBtnPressed()
    {
        // Replace with function body
    }

    private void OnTaskBtnPressed()
    {
        // Replace with function body
    }
}
}