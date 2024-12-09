using Godot;

public partial class Jump : Motion
{

    [Export] public float baseMaxHorizontalSpeed = 400.0f;
    [Export] public float airAcceleration = 1000.0f;
    [Export] public float airDeceleration = 2000.0f;
    [Export] public float airSteeringPower = 50.0f;
    [Export] public float gravity = 1600.0f;

    private Vector2 enterVelocity = new Vector2();
    private float maxHorizontalSpeed = 0.0f;
    private float horizontalSpeed = 0.0f;
    private Vector2 horizontalVelocity = new Vector2();

    private float verticalSpeed = 0.0f;
    public float height = 0.0f;

    public void Initialize(float speed, Vector2 velocity)
    {
        horizontalSpeed = speed;
        maxHorizontalSpeed = speed > 0.0f ? speed : baseMaxHorizontalSpeed;
        enterVelocity = velocity;
    }

    public override void Enter()
    {
        Vector2 inputDirection = InputManager.Instance.GetInputDirection();
        UpdateLookDirection(inputDirection);

        horizontalVelocity = inputDirection != Vector2.Zero ? enterVelocity : new Vector2();
        verticalSpeed = 600.0f;

        Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("jump");

    }

    public override void Update(float delta)
    {
        Vector2 inputDirection = InputManager.Instance.GetInputDirection();
        UpdateLookDirection(inputDirection);

        MoveHorizontally(delta, inputDirection);
        AnimateJumpHeight(delta);
        if (height <= 0.0f)
        {
            EmitSignal(SignalName.Finished, "idle");
        }
    }

    public void MoveHorizontally(float delta, Vector2 direction)
    {
        if (direction != Vector2.Zero)
        {
            horizontalSpeed += airAcceleration * delta;
        }
        else
        {
            horizontalSpeed -= airDeceleration * delta;
        }
        horizontalSpeed = Mathf.Clamp(horizontalSpeed, 0, maxHorizontalSpeed);

        Vector2 targetVelocity = horizontalSpeed * direction.Normalized();
        Vector2 steeringVelocity = (targetVelocity - horizontalVelocity).Normalized() * airSteeringPower;
        horizontalVelocity += steeringVelocity;
        ((CharacterBody2D)Owner).SetVelocity(horizontalVelocity);
        ((CharacterBody2D)Owner).MoveAndSlide();
    }

    public void AnimateJumpHeight(float delta)
    {
        verticalSpeed -= gravity * delta;
        height += verticalSpeed * delta;
        height = Mathf.Max(0.0f, height);

        Owner.GetNode<Node2D>("BodyPivot").Position = new Vector2(Owner.GetNode<Node2D>("BodyPivot").Position.X, -height);
    }
}
