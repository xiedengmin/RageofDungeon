using Godot;

namespace ET {
public partial class Breeze:NPC
{
    // Reference to the Popup menu
    private Popup menu;

    // Variables for counts
    private int ambCount;
    private int fwCount;
    private int tkCount;

    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        menu = GetNode<Popup>("Menu_Breeze");

        // Initialize counts
        ambCount = 3;
        fwCount = 4;
        tkCount = 4;
    }

    // Method to show the menu
    public override void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    // Placeholder for talk button pressed
    private void OnTalkBtnPressed()
    {
        // Replace with function body.
    }

    // Placeholder for shop button pressed
    private void OnShopBtnPressed()
    {
        // Replace with function body.
    }

    // Placeholder for task button pressed
    private void OnTaskBtnPressed()
    {
        // Replace with function body.
    }
}
}