using Godot;

namespace ET {
public partial class Storage : NPC
{
    [Export] public Popup menu;

    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        //   menu = GetNode<Popup>("Menu_Type3");

        ambCount = 2;
        fwCount = 3;
        tkCount = 2;
    }

    private void OnTalkBtnPressed()
    {
        //   menu.SetPosition((Vector2I)GetGlobalMousePosition());
    }

    private void OnShopBtnPressed()
    {
        // Replace with function body.
    }

    private void OnTaskBtnPressed()
    {
        // Replace with function body.
    }
    public void OnMouseCheckPressed()
    {
        GlobalManager.Instance.main.OnOpenStorate();
    }


}


}