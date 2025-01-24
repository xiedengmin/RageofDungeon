using Godot;

namespace ET {
public partial class Simona : NPC
{
    [Export] private Popup menu;

    public override void _Ready()
    {
        menu = GetNode<Popup>("Menu_Simona");

        ambCount = 3;
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
}