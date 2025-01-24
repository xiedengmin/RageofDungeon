using Godot;

namespace ET {
public partial class Balena:NPC 
{
    // 通过Path引用Popup控件
    [Export] private Popup menu;


    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        // 初始化计数器
        ambCount = 2;
        fwCount = 4;
        tkCount = 3;

        // 绑定按钮事件
        GetNode<Button>("TalkBtn").Pressed += OnTalkBtnPressed;
        GetNode<Button>("ShopBtn").Pressed += OnShopBtnPressed;
        GetNode<Button>("TaskBtn").Pressed += OnTaskBtnPressed;
    }

    // 显示menu
    public void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    // 按钮回调函数（尚未定义功能体）
    private void OnTalkBtnPressed()
    {
        // 替换为功能实现
    }

    private void OnShopBtnPressed()
    {
        // 替换为功能实现
    }

    private void OnTaskBtnPressed()
    {
        // 替换为功能实现
    }
}
}