using Godot;

public partial class Rothon : NPC // 假设NPC是一个自定义的父类
{
    // 定义菜单和按钮
    [Export] private Popup Menu;
    [Export] private TextureButton TaskBtn;

    // 类构造函数
    public override void _Ready()
    {
        // 初始化按钮引用
        Menu = GetNode<Popup>("Menu_Rothon");
        TaskBtn = GetNode<TextureButton>("Menu_Rothon/MarginContainer/VBoxContainer/talkBtn");

        // 初始化计数
        int fwCount = 3;
        int tkCount = 3;
    }

    // 显示菜单函数
    public void ShowMenu()
    {
        Menu.Position = (Vector2I)GetGlobalMousePosition();
        Menu.Popup();
    }

    // 按钮按下事件函数
    private void _OnTalkBtnPressed()
    {
        // 这里添加具体的函数体
    }

    private void _OnShopBtnPressed()
    {
        // 这里添加具体的函数体
    }

    private void _OnTaskBtnPressed()
    {
        // 这里添加具体的函数体
    }

    private void _OnDecBtnPressed()
    {
        // 这里添加具体的函数体
    }
}
