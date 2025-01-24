using Godot;
using System;

namespace ET {
public partial class Alfhlyra:LevelBase
{
    [Export] private NodePath gatePath;
    private Node gate;
    private Character player;

    public override void _Ready()
    {
        gate = GetNode(gatePath);
    }

    // 设置玩家
    public void SetPlayer(Character _p, bool isInit = true)
    {
        player = _p;
        if (isInit)
        {
            ((dynamic)gate).AddPlayer(player, Vector2.Zero, isInit);
            ((dynamic)gate).ChangeDoorState(false);
        }
        else
        {
            var current = GetStage();
            Vector2 pPos = ((dynamic)current).GetDoorPosition();
            ((dynamic)current).AddPlayer(player, pPos);
            ((dynamic)current).ChangeDoorState(false);
        }
    }

    // 切换stage
    public void ChangeStage()
    {
        var curr = GetNode(GlobalManager.Instance.state.current);
        ((dynamic)curr).RemovePlayer();
        ((dynamic)curr).ChangeDoorState(true);

        var tar = GetNode(GlobalManager.Instance.state.target);
        Vector2 pPos = ((dynamic)tar).GetDoorPosition();
        ((dynamic)tar).AddPlayer(player, pPos);
        ((dynamic)tar).ChangeDoorState(false);
    }

    // 获取当前stage
    public Node GetStage()
    {
        return GetNode(GlobalManager.Instance.state.stage);
    }
}
}