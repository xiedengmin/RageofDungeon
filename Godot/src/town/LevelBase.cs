using Godot;

public partial class LevelBase : Node2D
{
    // Dungeon
    [Export] public string Type { get; set; } = "town";

    private int loadState = 0;
    public Character player;

    public override void _Ready()
    {
        base._Ready();
    }

    // 设置玩家
     public void SetPlayer(Character p)
     {
         player = p;
     }
}