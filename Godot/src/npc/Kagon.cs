using Godot;

namespace ET {
public partial class Kagon : NPC
{
    // 定义 Popup 类型的菜单
    private Popup menu;

    // 准备好节点时调用
    public override void _Ready()
    {
        body = GetNode<AnimatedSprite2D>("body");
        talkPlayer = GetNode<AnimationPlayer>("talkPlayer");
        range_check = GetNode<Area2D>("range_check");
        range_timer = GetNode<Timer>("range_timer");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        menu = GetNode<Popup>("Menu_type2");

        // 初始化计数
        ambCount = 2;
        fwCount = 3;
        tkCount = 3;
    }



    // 显示菜单
    public void ShowMenu()
    {
        menu.SetPosition((Vector2I)GetGlobalMousePosition());
        menu.Popup();
    }

    // 点击 "talk" 按钮的处理函数
    private void OnTalkBtnPressed()
    {
        // 实现函数逻辑
    }

    // 点击 "shop" 按钮的处理函数
    private void OnShopBtnPressed()
    {
        // 实现函数逻辑
    }

    // 点击 "task" 按钮的处理函数
    private void OnTaskBtnPressed()
    {
        // 实现函数逻辑
    }
}

}