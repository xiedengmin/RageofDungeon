using Godot;

namespace ET {
public partial class Monster : CharacterBody2D
{
    [Export] public string type { get; set; } = "normal";

    private Sprite2D _body;
    private Sprite2D _shadow;
    public Vector2 _knockback = Vector2.Zero;
    // 属性
    private MonsterStatus _status;

    public override void _Ready()
    {
        _body = GetNode<Sprite2D>("BodyPivot/Offset/Body");
        _shadow = GetNode<Sprite2D>("Shadow");
    }

    public override void _PhysicsProcess(double delta)
    {
        bool direction = GetDirection();
        FlipH(direction);

        _knockback = _knockback.MoveToward(Vector2.Zero, (float)(delta * 200));
        Velocity = _knockback;
        MoveAndSlide();

    }

    public void FlipH(bool value)
    {
        _body.FlipH = value;
        _shadow.FlipH = value;
    }

    // 受到伤害
    public virtual void OnHurtBoxAreaEntered(Area2D area)
    {
        bool direction = GetDirection();
        int dir = direction ? 1 : -1;
        _knockback = Vector2.Right * 50 * dir;
        GD.Print("monster受到伤害");
    }

    // 判断方向
    public bool GetDirection()
    {
        bool value = false;
        //Vector2 playerPosition = GlobalManager.Instance.main.player.GlobalPosition;
     //   if (playerPosition.X < GlobalPosition.X)
        {
            value = true;
        }
       // else
        {
            value = false;
        }
        return value;
    }
}
}