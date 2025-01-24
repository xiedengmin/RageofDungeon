using Godot;

namespace ET {
public partial class DungeonLevel : Node2D
{
    // dungeon
    [Export]
    public string type = "dungeon";

    public int load_state = 0;
    public Character player;
    public string bornStage = "";

    public override void _Ready()
    {
        // do nothing in _ready for now
    }

    // 设置玩家
    public void SetPlayer(Character _p, bool isInit = true)
    {
        player = _p;
        Node current;

        if (isInit)
        {
            current = GetNode(bornStage);
            ((dynamic)current).AddPlayer(player, Vector2.Zero, true); // Assuming AddPlayer is dynamic
            ((dynamic)current).ChangeDoorState(false); // Assuming ChangeDoorState is dynamic
        }
        else
        {
            current = GetStage();
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

        GlobalManager.Instance.main.loading.ChangeStage();

        var tar = GetNode(GlobalManager.Instance.state.target);
        Vector2 pPos = ((dynamic)tar).GetDoorPosition();
        ((dynamic)tar).AddPlayer(player, pPos);
        ((dynamic)tar).ChangeDoorState(false);
    }

    public Node GetStage()
    {
        return GetNode(GlobalManager.Instance.state.stage);
    }
}
}