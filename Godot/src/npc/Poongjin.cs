using Godot;

public partial class Poongjin : NPC
{
    private Popup menu;
    private TextureButton skillBtn;
    private TextureButton taskBtn;

    public override void _Ready()
    {
        menu = GetNode<Popup>("Menu_Type3");
        skillBtn = GetNode<TextureButton>("Menu_Type3/MarginContainer/VBoxContainer/skillBtn");
        taskBtn = GetNode<TextureButton>("Menu_Type3/MarginContainer/VBoxContainer/taskBtn");

        int ambCount = 1;
        int fwCount = 2;
        int tkCount = 2;
    }

    // 显示menu
    private void ShowMenu()
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

    private void OnSkillBtnPressed()
    {
        // Replace with function body.
    }

    private void OnTaskBtnPressed()
    {
        // Replace with function body.
    }
}