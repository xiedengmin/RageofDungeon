using Godot;
using System.IO;
using System.Threading.Tasks;

namespace ET {
public partial class BulletSpawner : Node
{
    private Timer _cooldownTimer;

    public override void _Ready()
    {
        _cooldownTimer = GetNode<Timer>("CooldownTimer");
    }

    public void Fire()
    {
        if (!_cooldownTimer.IsStopped())
        {
            return;
        }
        _cooldownTimer.Start();
        GD.Print("START THREAD!");
        CallDeferred("_BgLoad", "res://Prefabs/bullet/paowu/paowu.tscn");
    }



    private void _BgLoad(string path)
    {
        var rockInstance = (paowu)GD.Load<PackedScene>(path).Instantiate();
        AddChild(rockInstance);
        // 设置石头的初始位置和方向
        rockInstance.GlobalPosition = ((dynamic)Owner).GlobalPosition;
        var playerPosition = GlobalManager.Instance.main.player.GlobalPosition;
        var dir = new Vector2(playerPosition.X - rockInstance.GlobalPosition.X, playerPosition.Y - rockInstance.GlobalPosition.Y);

        rockInstance.SetDirection(new Vector2(dir.X > 0 ? 1 : -1, dir.Y > 0 ? -0.5f : -0.5f));
    }

    public override void _ExitTree()
    {
        _cooldownTimer.Stop();

    }
}
}