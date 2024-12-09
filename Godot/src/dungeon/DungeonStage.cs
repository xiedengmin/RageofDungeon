using Godot;
using System;

public partial class DungeonStage : Node2D
{
    [Export] public string bgm = "";
    [Export] public string env = "";
    [Export] public string stageType = "normal";

    private ParallaxBackground panel;
    private Node2D doors;
    private Marker2D topLeft;
    private Marker2D bottomRight;
    private Node2D stage;
    private Character player;
    private CharacterBody2D monster = (CharacterBody2D)GD.Load<PackedScene>("res://scenes/monster/goblin/Goblin.tscn").Instantiate();

    public override void _Ready()
    {
        panel = GetNode<ParallaxBackground>("environment/background");
        doors = GetNode<Node2D>("doors");
        topLeft = GetNode<Marker2D>("TopLeft");
        bottomRight = GetNode<Marker2D>("BottomRight");
        stage = GetNode<Node2D>("stage");
        //  panel.Transform = new Transform2D(((float)panel.Transform.X.X), GlobalPosition); //翻转背景的，原来参数panel.Transform.X
        SetMonster(monster);
    }

    // 设置怪物
    public void SetMonster(CharacterBody2D _m, bool isinit = true)
    {
        stage.AddChild(_m);
        PrintOrphanNodes();
        _m.Position = GetNode<Marker2D>("BornMonster").Position;
    }

    // 添加玩家
    public void AddPlayer(Character p, Vector2 p_pos, bool _isBorn = false)
    {
        player = p;
        if (_isBorn)
        {
            player.Position = GetNode<Marker2D>("Born").Position;
        }
        else
        {
            player.Position = p_pos;
        }

        stage.AddChild(player);
        player.SetCameraLimit(
            topLeft.GlobalPosition.Y, topLeft.GlobalPosition.X,
            bottomRight.GlobalPosition.Y, bottomRight.GlobalPosition.X
        );

        GlobalManager.Instance.main.ChangeBGM(bgm);
        GlobalManager.Instance.main.ChangeENV(env);
    }

    // 删除玩家
    public void RemovePlayer()
    {
        if (stage.HasNode("Character"))
        {
            stage.RemoveChild(stage.GetNode("Character"));
        }
    }

    // 切换门状态
    public void ChangeDoorState(bool value)
    {
        var doorArr = doors.GetChildren();
        foreach (var door in doorArr)
        {
            if (door is Area2D)
            {
                ((dynamic)door).SetState(value);
                if (!value)
                {
                    ((dynamic)door).SetConnect();
                }
                else
                {
                    ((dynamic)door).SetDisconnect();
                }
            }
        }
    }

    // 获取相对门的位置
    public Vector2 GetDoorPosition()
    {
        GD.Print("正在找的门，to_" + GlobalManager.Instance.state.current);

        var door = (Node2D)doors.GetNode("to_" + GlobalManager.Instance.state.current);
        var dpos = door.GetNode("pos");
        return door.Position + ((Node2D)dpos).Position;
    }
}