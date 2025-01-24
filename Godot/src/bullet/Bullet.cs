using Godot;

namespace ET {
public partial class Bullet : Node2D
{
    // 自动获取节点zd
    [Export]
    public float speed = 500.0f;

    private CharacterBody2D zd;
    private Node root;

    private float g = 2.2f;
    private Vector2 direction = new Vector2(1.0f, -0.5f);

    public override void _Ready()
    {
        // 将自身设为顶层节点
        TopLevel=(true);

        // 自动获取节点zd和根节点
        zd =(CharacterBody2D) GetNode("zd");
        root = GetTree().Root;

        PrintOrphanNodes();
    }

    public void Force()
    {
        GD.Print("ok");
    }

    public override void _PhysicsProcess(double delta)
    {
        // 检查是否超出可见区域，超出则删除节点
        if (!((Viewport)root).GetVisibleRect().HasPoint(Position))
        {
            QueueFree();
        }

        // 设置zd的velocity
        ((CharacterBody2D)zd).SetVelocity( (direction * speed * (float)delta));
        var velocityY = (float)((CharacterBody2D)zd).Get("velocity:y");
        ((CharacterBody2D)zd).Set("velocity:y", velocityY + g * g);

        ((CharacterBody2D)zd).Call("set_up_direction", Vector2.Up);

        // 检测碰撞
       var collisionInfo = ((CharacterBody2D)zd).MoveAndCollide( ((CharacterBody2D)zd).GetVelocity());
      if (collisionInfo != null)
        {
            QueueFree();
        }
    }

    // 如果需要绘制功能，可以启用以下代码
    /*
    public override void _Draw()
    {
        var collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        DrawCircle(Vector2.Zero, ((CircleShape2D)collisionShape.Shape).Radius, Colors.Red);
    }
    */
}
}