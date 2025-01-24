using Godot;
using System;

namespace ET {
public partial class HendonMyre:LevelBase
{
    // 获取门的节点
    [Export]
    private Node gate;

    public override void _Ready()
    {
        // 初始化时执行的代码
    }

    // 设置玩家
    public void SetPlayer(Node player, bool isInit = true)
    {
        Node current;
        if (isInit)
        {
            // 添加玩家到门
            gate.Call("AddPlayer", player, Vector2.Zero, isInit);
            gate.Call("change_door_state", false);
        }
        else
        {
            current = GetStage();
            Vector2 playerPosition = (Vector2)current.Call("get_door_position");
            current.Call("AddPlayer", player, playerPosition);
            current.Call("change_door_state", false);
        }
    }

    // 切换stage
    public void ChangeStage()
    {
        Node curr = GetNode(GlobalManager.Instance.state.current);
        curr.Call("removePlayer");
        curr.Call("change_door_state", true);

        GD.Print(GlobalManager.Instance.state.target);

        Node target = GetNode(GlobalManager.Instance.state.target);
        Vector2 playerPosition = (Vector2)target.Call("get_door_position");
        target.Call("AddPlayer", player, playerPosition);
        target.Call("change_door_state", false);
    }

    // 获取当前stage
    public Node GetStage()
    {
        return GetNode(GlobalManager.Instance.state.stage);
    }
}
}