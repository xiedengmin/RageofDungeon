using Godot;

namespace ET {
public partial class Rino : NPC
{
    // 使用 [Node] 属性代替 @onready
    [Export] private Popup menu;
    [Export] private TextureButton taskBtn;

    public override void _Ready()
    {
        // 初始化变量
        ambCount = 3;
        fwCount = 4;
        tkCount = 3;

        // 通过路径获取节点
        menu = GetNode<Popup>("Menu_Type2");
        taskBtn = GetNode<TextureButton>("Menu_Type2/MarginContainer/VBoxContainer/taskBtn");
    }

    // 显示menu
    public void ShowMenu()
    {
        menu.Position =(Vector2I) GetGlobalMousePosition();
        menu.Popup();
    }

    private void OnTalkBtnPressed()
    {
        // 在这里添加函数体
    }

    private void OnShopBtnPressed()
    {
        // 在这里添加函数体
    }

    private void OnTaskBtnPressed()
    {
        // 在这里添加函数体
    }
}
}