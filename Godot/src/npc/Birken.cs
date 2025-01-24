using Godot;

namespace ET {
public partial class Birken: NPC
{
    [Export]
    private PackedScene npcScene;

    private Popup menu;

    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        menu = GetNode<Popup>("Menu_Birken");
         fwCount = 5;
         tkCount = 5;
    }

    // 显示menu
    public override void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        // Replace with function body.
    }

    private void OnShopBtnPressed()
    {
        // Replace with function body.
    }

    private void OnTaskBtnPressed()
    {
        // Replace with function body.
    }
}
}