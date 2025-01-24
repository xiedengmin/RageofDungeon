using Godot;

namespace ET {
public partial class Seria:NPC
{
    [Export] private Popup Menu { get; set; }


    public override void _Ready()
    {
        body =GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        Menu = GetNode<Popup>("Menu_Seria");
        ambCount = 1;
        fwCount = 2;
        tkCount = 3;
    }

    // 显示menu
    public override  void ShowMenu()
    {
        Menu.SetPosition((Vector2I)GetGlobalMousePosition());
        Menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        Menu.SetPosition((Vector2I)GetGlobalMousePosition());
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