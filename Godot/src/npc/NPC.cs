using Godot;
using System;

namespace ET {
public partial class NPC : Control
{
    // 是否播放菜单音效
    [Export] public bool play_menu_sound = true;

    public AnimatedSprite2D body;
    public AnimationPlayer talkPlayer;
    public Area2D range_check;
    public Timer range_timer;
    public AudioStreamPlayer clickSound;

    // 环境声音的数量
    public int ambCount = 1;
    // 关闭窗口的声音数量
    public int fwCount = 1;
    // talk的声音数量
    public int tkCount = 1;
    // 范围语音是否可播放
    public bool rangePlay = true;

    public override void _Ready()
    {
       // body =GetNode<AnimatedSprite2D>("body");


     //   var _err = range_check.Connect("body_entered", new Callable(this, nameof(OnArea2DBodyEntered)), (uint)ConnectFlags.Deferred | (uint)ConnectFlags.OneShot);
    }

    // 鼠标移入
    public void OnMouseCheckMouseEntered()
    {
        // 假设 body 的材质是 ShaderMaterial 类型
        var shaderMaterial = (ShaderMaterial)body.Material;
        shaderMaterial.SetShaderParameter("show_outline", true);
       
    }

    // 鼠标移出
    public void OnMouseCheckMouseExited()
    {
        var shaderMaterial = (ShaderMaterial)body.Material;
        shaderMaterial.SetShaderParameter("show_outline", false);
    }

    public void OnArea2DBodyEntered(Node2D coll_body)
    {
        var _err = range_check.Connect("body_entered", new Callable(this, nameof(OnArea2DBodyEntered)), (uint)ConnectFlags.Deferred | (uint)ConnectFlags.OneShot);

        if (coll_body.Name == "Character" && rangePlay)
        {
            if (ambCount == 1)
            {
                talkPlayer.Play("amb_01");
            }
            else
            {
                var random = Mathf.CeilToInt(GD.RandRange(0, ambCount));
                talkPlayer.Play($"amb_0{random}");
            }

            rangePlay = false;
            range_timer.Start();
        }
    }

    // 点击事件
    public void OnMouseCheckPressed()
    {
        ClickNpcTk();
        ShowMenu();
    }

    public void OnRangeTimerTimeout()
    {
        rangePlay = true;
    }

    // 点击NPC的语音
    public void ClickNpcTk()
    {
        if (play_menu_sound)
        {
            var random = Mathf.CeilToInt(GD.RandRange(0, tkCount));
            talkPlayer.Play($"tk_0{random}");
            clickSound.Play();
        }
    }

    // 显示菜单
    public virtual void ShowMenu()
    {
        // 未实现
    }
}

}