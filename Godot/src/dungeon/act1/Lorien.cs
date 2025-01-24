using Godot;
using System;

namespace ET {
public partial class Lorien:DungeonLevel
{


    public override void _Ready()
    {
        bornStage = "stage_02";
        SetPlayer(GlobalManager.Instance.main.player, true);
    }

    // 设置玩家
    // public void SetPlayer(Node _p, bool isInit = true)
    // {
    //     Node player = _p;
    //     Node current;
    //     if (isInit)
    //     {
    //         GD.Print("AAAAA");
    //         current = GetNode(bornStage);
    //         ((YourStageClass)current).AddPlayer(player, Vector2.Zero, true);
    //         ((YourStageClass)current).ChangeDoorState(false);
    //     }
    //     else
    //     {
    //         current = GetStage();
    //         Vector2 pPos = ((YourStageClass)current).GetDoorPosition();
    //         ((YourStageClass)current).AddPlayer(player, pPos);
    //         ((YourStageClass)current).ChangeDoorState(false);
    //     }
    // }

    // 切换stage
    // public void ChangeStage()
    // {
    //     var curr = GetNode(GlobalManager.state.current);
    //     ((YourStageClass)curr).RemovePlayer();
    //     ((YourStageClass)curr).ChangeDoorState(true);
    //
    //     var tar = GetNode(GlobalManager.state.target);
    //     Vector2 pPos = ((YourStageClass)tar).GetDoorPosition();
    //     ((YourStageClass)tar).AddPlayer(player, pPos);
    //     ((YourStageClass)tar).ChangeDoorState(false);
    // }

    // public Node GetStage()
    // {
    //     return GetNode(GlobalManager.state.stage);
    // }
}
}