using Godot;

public partial class Move : OnGround // 确保继承自正确的节点类
{
    // Y方向移动速度
    [Export] public float MaxYSpeed = 180f;
    [Export] public float MaxWalkSpeed = 150f;
    [Export] public float MaxRunSpeed = 300f;

    public bool isRun = false;
    public float speed = 0f;
    public Vector2 velocity = Vector2.Zero;
    //  [Signal]
    // public delegate void FinishedEventHandler(string nextStateName);
    public override void _Ready()
    {
        // 初始化或其他准备逻辑
    }

    public override void Enter()
    {
        if (GlobalManager.Instance.mapType == "town")
        {
            MaxWalkSpeed = 300f;
        }
        else
        {
            MaxWalkSpeed = 150f;
        }

        speed = 0f;
        velocity = Vector2.Zero;

        Vector2 inputDirection = InputManager.Instance.GetInputDirection();
        UpdateLookDirection(inputDirection);
        Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("move");
    }

    public override void HandleInput(InputEvent @event)
    {
        base.HandleInput(@event); // 调用父类的输入处理
    }

    public override void Update(float delta)
    {
        Vector2 inputDirection = InputManager.Instance.GetInputDirection();

        if (inputDirection == Vector2.Zero)
        {
            isRun = false;
            EmitSignal(SignalName.Finished, "idle");
        }

        if (Owner.GetNode<StateMachine>("StateMachine").currentState == Owner.GetNode<StateMachine>("StateMachine").GetNode("Move"))
        {
            UpdateLookDirection(inputDirection);
            if (InputManager.Instance.activatedSkill == "LeftDash" || InputManager.Instance.activatedSkill == "RightDash")
            //     if (Input.IsActionJustPressed("run") && GlobalManager.Instance.mapType != "town")
            {
                isRun = true;
            }

            if (isRun)
            {
                Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("dash");
                speed = MaxRunSpeed;
            }
            else
            {
                Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("move");
                speed = MaxWalkSpeed;
            }

            var collisionInfo = _Move(speed, inputDirection);
            if (collisionInfo == null)
            {
                return;
            }

        }
    }

    public KinematicCollision2D _Move(float speed, Vector2 direction)
    {
        velocity.X = direction.Normalized().X * speed;
        velocity.Y = direction.Normalized().Y * MaxYSpeed;
        ((CharacterBody2D)Owner).SetVelocity(velocity);
        ((CharacterBody2D)Owner).SetFloorStopOnSlopeEnabled(true);
        ((CharacterBody2D)Owner).SetMaxSlides(2);
        ((CharacterBody2D)Owner).MoveAndSlide();
        if (((CharacterBody2D)Owner).GetSlideCollisionCount() == 0)
        {
            return null;
        }

        return ((CharacterBody2D)Owner).GetSlideCollision(0);
    }

}
