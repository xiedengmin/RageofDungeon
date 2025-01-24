using Godot;

namespace ET {
public partial class Shran : NPC
{
    [Export] private Popup menu;

    public override void _Ready()
    {
        menu = GetNode<Popup>("Menu_Type3");

        ambCount = 2;
        fwCount = 3;
        tkCount = 2;
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
}