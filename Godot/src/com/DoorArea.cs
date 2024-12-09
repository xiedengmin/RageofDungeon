using Godot;
using System;

public partial class DoorArea : Area2D
{
    public enum TYPE
    {
        TOSTAGE,
        TOLEVEL,
        TOENTRANCE
    }

    // 当前
    [Export]
    public string current { get; set; }
    // 目标
    [Export]
    public string target { get; set; }
    // 过门之后的stage
    [Export]
    public string stage { get; set; }
    // 门类型
    [Export]
    public TYPE Type { get; set; }

    public override void _Ready()
    {
        // 这里可以执行一些初始化代码
    }

    // 玩家进入区域
    public  void _OnDoorAreaBodyEntered(Node body)
    {
       //  SetState(true);
        GD.Print("触发过门");
        if (target == "stage_06")
            return;

        switch (Type)
        {
            case TYPE.TOSTAGE:
                GlobalManager.Instance.state.current = current;
                GlobalManager.Instance.state.target = target;
                GlobalManager.Instance.ChangeStage();
                break;

            case TYPE.TOLEVEL:
                GlobalManager.Instance.state.current = current;
                GlobalManager.Instance.state.target = target;
                GlobalManager.Instance.state.stage = stage;
                GlobalManager.Instance.ChangeLevel();
                break;

            case TYPE.TOENTRANCE:
                GlobalManager.Instance.state.current = "stage_02";
                GlobalManager.Instance.state.worldMapName = "Lorien"; 
                //GlobalManager.Instance.state.current = current;
                //GlobalManager.Instance.state.worldMapName = target;
                GlobalManager.Instance.OpenWorldMap();
                break;
        }

        var err = Connect("body_entered", new Callable(this, nameof(_OnDoorAreaBodyEntered)), (int)ConnectFlags.Deferred | (int)ConnectFlags.OneShot);
    }

    // 玩家离开区域
    private void _OnDoorAreaBodyExited(Node body)
    {
        var err = Connect("body_entered", new Callable(this, nameof(_OnDoorAreaBodyExited)), (int)ConnectFlags.Deferred | (int)ConnectFlags.OneShot);
        // SetState(false);
        // GD.Print("离开门区域");
        // GlobalManager.SetDoorToUse();
    }

    // 启用门碰撞区域
    public void SetState(bool value)
    {
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", value);
    }

    // 开启碰撞连接
    public void SetConnect()
    {
        if (!IsConnected("body_entered", new Callable(this, nameof(_OnDoorAreaBodyEntered))))
        {
            var err = Connect("body_entered", new Callable(this, nameof(_OnDoorAreaBodyEntered)), (int)ConnectFlags.Deferred | (int)ConnectFlags.OneShot);
            err = Connect("body_exited", new Callable(this, nameof(_OnDoorAreaBodyExited)), (int)ConnectFlags.Deferred | (int)ConnectFlags.OneShot);
        }
    }

    // 关闭碰撞连接
    public void SetDisconnect()
    {
        if (IsConnected("body_entered", new Callable(this, nameof(_OnDoorAreaBodyEntered))))
        {
            Disconnect("body_entered", new Callable(this, nameof(_OnDoorAreaBodyEntered)));
            Disconnect("body_exited", new Callable(this, nameof(_OnDoorAreaBodyExited)));
        }
    }
}
