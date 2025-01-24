using Godot;

namespace ET {
public partial class StormPass:LevelBase 
{
    [Export]
    private NodePath gatePath;

    private Node gate;
    public Character player;

    public override void _Ready()
    {
        gate = GetNode(gatePath);
    }

    // 设置玩家
    public void SetPlayer(Character _p, bool isInit = true)
    {
        player = _p;
        Node current;
        if (isInit)
        {
          
                ((BaseStage)gate).AddPlayer(player, Vector2.Zero, isInit);
                ((BaseStage)gate).ChangeDoorState(false);
           
        }
        else
        {
            current = GetStage();
            Vector2 pPos = (Vector2)current.Call("get_door_position");
            current.Call("add_player", player, pPos);
            current.Call("change_door_state", false);
        }
    }

    // 切换stage
    public void ChangeStage()
    {
        var curr = GetNode(GlobalManager.Instance.state.current) as Node;
        curr.Call("remove_player");
        curr.Call("change_door_state", true);

        var tar = GetNode(GlobalManager.Instance.state.target) as Node;
        Vector2 pPos = (Vector2)tar.Call("get_door_position");
        tar.Call("add_player", player, pPos);
        tar.Call("change_door_state", false);
    }

    public Node GetStage()
    {
        return GetNode(GlobalManager.Instance.state.stage) as Node;
    }
}

}