using Godot;

public partial class O1obj107: StaticBody2D
{  // 定义 Sprite2D 变量
    private Sprite2D pic;

    public override void _Ready()
    {
        // 初始化 pic 变量
        pic = GetNode<Sprite2D>("pic");

        // 连接 Area2D 的 body_entered 和 body_exited 信号
        GetNode<Area2D>("Area2D").BodyEntered += OnArea2DBodyEntered;
        GetNode<Area2D>("Area2D").BodyExited += OnArea2DBodyExited;
    }

    // body_entered 信号处理函数
    private void OnArea2DBodyEntered(Node2D body)
    {
        if (body.Name == "Character")
        {
            var modulate = pic.Modulate;
            modulate.A = 0.4f;
            pic.Modulate = modulate;
        }
    }

    // body_exited 信号处理函数
    private void OnArea2DBodyExited(Node2D body)
    {
        var modulate = pic.Modulate;
        modulate.A = 1.0f;
        pic.Modulate = modulate;
    }
}