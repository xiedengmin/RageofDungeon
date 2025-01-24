using Godot;

namespace ET {
public partial class Albert:NPC
{
    [Export] public Popup Menu;


    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        ambCount = 5;
        fwCount = 4;
        tkCount = 5;
    }

    // 显示menu
    public override void ShowMenu()
    {
        Menu.SetPosition((Vector2I)GetGlobalMousePosition());
        Menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        // Replace with function body.
    }

    private void OnSkillBtnPressed()
    {
        // Replace with function body.
    }

    private void OnTaskBtnPressed()
    {
        // Replace with function body.
    }
}

}