using Godot;

public partial class Roger:NPC 
{
    // 菜单和任务按钮的引用
    [Export] private Popup menu;
    [Export] private TextureButton taskBtn;

    private int fwCount;
    private int tkCount;

    public override void _Ready()
    {
        fwCount = 5;
        tkCount = 4;
    }

    // 显示菜单
    private void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        // 在此添加函数主体
    }

    private void OnTaskBtnPressed()
    {
        // 在此添加函数主体
    }

    private void OnProBtnPressed()
    {
        // 在此添加函数主体
    }
}