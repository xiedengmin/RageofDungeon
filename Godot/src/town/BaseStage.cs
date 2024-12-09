using Godot;
using System;
using System.Collections.Generic;

public partial class BaseStage: Node2D
{
    [Export] public string Bgm = "";
    [Export] public string Env = "";

    private Node2D doors;
    private Marker2D topLeft;
    private Marker2D bottomRight;
    private Node2D stage;
    public Character player;

    public override void _Ready()
    {
        doors = GetNode<Node2D>("doors");
        topLeft = GetNode<Marker2D>("TopLeft");
        bottomRight = GetNode<Marker2D>("BottomRight");
        stage = GetNode<Node2D>("stage");

       
    }

    // 添加玩家
    public void AddPlayer(Character p, Vector2 pPos, bool isBorn = false) 
    {
        player = p;

        if (isBorn)
        {
            player.Position = GetNode<Node2D>("Born").Position;
        }
        else
        {
            player.Position = pPos;
        }

        stage.AddChild(player);
        player.SetCameraLimit(
           topLeft.GlobalPosition.Y, topLeft.GlobalPosition.X,
           bottomRight.GlobalPosition.Y, bottomRight.GlobalPosition.X
      );
        GlobalManager.Instance.main.ChangeBGM(Bgm);
        GlobalManager.Instance.main.ChangeENV(Env);
    }

    // 重置玩家位置
    public void ReSetPlayerPosition()
    {
        player.Position = GetEntrancePosition();
    }

    // 删除玩家
    public void RemovePlayer()
    {
        /* if (stage.HasNode("Character"))
         {
             stage.RemoveChild(stage.GetNode("Character"));
         }

         var monster = GetTree().Root.GetNode("Monster");
         if (monster != null)
         {
             monster.GetParent().RemoveChild(monster);
         }
 */
        // 遍历并删除 Stage 下的所有子节点
        foreach (Node child in stage.GetChildren())
        {
            // 先从树中移除子节点
            RemoveChild(child);
            child.QueueFree(); // 删除子节点
        }
        CleanUpFreeNodes();
        PrintOrphanNodes();
    }
   


private void CleanUpFreeNodes()
{
    // 获取当前节点的所有子节点
    List<Node> nodesToRemove = new List<Node>();

    foreach (Node child in GetChildren())
    {
        // 检查该子节点是否在场景树中
        if (!child.IsInsideTree())
        {
            nodesToRemove.Add(child);
        }
    }

    // 移除所有不在场景树中的子节点
    foreach (Node node in nodesToRemove)
    {
        node.QueueFree();
    }
}
// 切换门状态
public void ChangeDoorState(bool value)
    {
        foreach (var door in doors.GetChildren())
        {
            if (door is Area2D area2D)
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
        var door = doors.GetNode<Area2D>("to_" + GlobalManager.Instance.state.current);
        var dPos = door.GetNode<Marker2D>("pos");
        return door.Position + dPos.Position;
    }

    // 获取当前踩的门
    public Vector2 GetEntrancePosition()
    {
        GD.Print("正在找的门，to_Entrance");
        var door = doors.GetNode<Node2D>("to_Entrance");
        var dPos = door.GetNode<Node2D>("pos");
        return door.Position + dPos.Position;
    }
}