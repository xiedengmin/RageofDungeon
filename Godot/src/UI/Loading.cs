using Godot;
using System;

namespace ET {
public partial class Loading : Control
{
    private AnimationPlayer aplayer;

    public override void _Ready()
    {
        aplayer = GetNode<AnimationPlayer>("AnimationPlayer");
        Visible = false;
    }

    // 切换城镇
    public void ChangeTown()
    {
        Visible = true;
        var texture = (Texture2D)GD.Load(Utils.GetTownCutscene());
        GetNode<TextureRect>("cutscene").Texture = texture;
        var titText = (Texture2D)GD.Load(Utils.GetTownTitle());
        GetNode<TextureRect>("title").Texture = titText;
        aplayer.Play("town_cutscene");
    }

    public void CompleteAnimation()
    {
        Visible = false;
    }

    // 进入地下城
    public void EnterDungeon()
    {
        Visible = true;
        var texture = (Texture2D)GD.Load(Utils.GetDungeonCutscene());
        GetNode<TextureRect>("cutscene").Texture = texture;
       GetNode<AnimatedSprite2D>("dungeon_title").SpriteFrames = (SpriteFrames)GD.Load(Utils.GetDungeonTitle());
        aplayer.Play("enter_dungeon");
    }

    // 进入地下城的动画播放到一半的时候
    public void DungeonAtMid()
    {
        GlobalManager.Instance.main.EnterDungeon2();
    }

    // 地下城切换stage时的loading
    public void ChangeStage()
    {
        Visible = true;
        aplayer.Play("change_stage");
    }
}
}