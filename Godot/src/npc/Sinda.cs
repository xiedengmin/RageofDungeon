using Godot;

public partial class Sinda : NPC
{
    [Export] private Popup menu;

    public override void _Ready()
    {
        menu = GetNode<Popup>("Menu_Sinda");

        ambCount = 1;
        fwCount = 2;
        tkCount = 3;
    }

    private void _on_talkBtn_pressed()
    {
        // Replace with function body
    }

    private void _on_shopBtn_pressed()
    {
        // Replace with function body
    }

    private void _on_skillBtn_pressed()
    {
        // Replace with function body
    }

    private void _on_taskBtn_pressed()
    {
        // Replace with function body
    }
}