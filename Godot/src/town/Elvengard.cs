using Godot;
using System;

namespace ET {
public partial class Elvengard : LevelBase
{
    // 通过 [Node] 特性获取节点
    [Export] public Node gate;

    public override void _Ready()
    {
        gate = GetNode("Gate");
    }

    // 设置玩家
    public void SetPlayer(Character _p, bool isinit = true)
    {
        var player = _p;
        Node current;

        if (isinit)
        {
            ((dynamic)gate).AddPlayer(player, Vector2.Zero, true);
            ((dynamic)gate).ChangeDoorState(false);
        }
        else
        {
            current = GetStage();
            Vector2 pPos = ((dynamic)current).GetDoorPosition();
            ((dynamic)current).AddPlayer(player, pPos);
            ((dynamic)current).ChangeDoorState(false);
        }
    }

    // 切换 stage
    public void ChangeStage()
    {
        var curr = GetNode(GlobalManager.Instance.state.current);
        ((BaseStage)curr).RemovePlayer();
        ((BaseStage)curr).ChangeDoorState(true);

        var tar = GetNode(GlobalManager.Instance.state.target);
        Vector2 pPos = ((dynamic)tar).GetDoorPosition();
        GlobalManager.Instance.main.player = (Swordman)GD.Load<PackedScene>("res://Prefabs/role/character/Swordman.tscn").Instantiate();
        ((dynamic)tar).AddPlayer(GlobalManager.Instance.main.player, pPos);
        ((dynamic)tar).ChangeDoorState(false);
    }

    public void ReSetPlayerPosition()
    {
        var stage = GetNode(GlobalManager.Instance.state.current);
        ((dynamic)stage).ReSetPlayerPosition();
    }

    public Node GetStage()
    {
        return GetNode(GlobalManager.Instance.state.stage);
    }
}
}