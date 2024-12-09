using Godot;
using System;

public partial class Character : CharacterBody2D
{
    // The Player is a CharacterBody2D, in other words a physics-driven object.
    // It can move, collide with the world, etc...
    // The player has a state machine, but the body and the state machine are separate.

    //[Signal] public delegate void DirectionChangedEventHandler(Vector2 newDirection);

    private Camera2D camera;
    private Sprite2D body;
    private Sprite2D shadow;
    private Sprite2D weapon;
    private AnimationPlayer animationPlayer;

    private Marker2D CombatPivot;
    private Area2D hitbox;
    private Area2D hurtbox;
    private Vector2 lookDirection = Vector2.Right;

    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Camera2D");
        body = GetNode<Sprite2D>("BodyPivot/Offset/Body");
        shadow = GetNode<Sprite2D>("Shadow");
        weapon = GetNode<Sprite2D>("BodyPivot/Offset/Weapon");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        CombatPivot = GetNode<Marker2D>("BodyPivot/CombatPivot");
        hitbox = GetNode<Area2D>("BodyPivot/CombatPivot/HitBox");
        hurtbox = GetNode<Area2D>("BodyPivot/CombatPivot/HurtBox");
    }

    public void TakeDamage(Node2D attacker, float amount, Variant effect)
    {

        if (IsAncestorOf(attacker))
            return;

        GetNode<Node>("States/Stagger").Set("knockback_direction",
            (attacker.GlobalPosition - GlobalPosition).Normalized());
        GetNode<Node>("Health").Call("takeDamage", amount, effect);
    }

    public void SetDead(bool value)
    {
        SetProcessInput(!value);
        SetPhysicsProcess(!value);
        GetNode<CollisionPolygon2D>("CollisionPolygon2D").Disabled = value;
    }

    public void SetLookDirection(Vector2 value)
    {
        lookDirection = value;
        // EmitSignal(SignalName.DirectionChanged, value);
    }

    // Set camera boundaries
    public void SetCameraLimit(float top, float left, float bottom, float right)
    {
        camera.LimitTop = Mathf.RoundToInt(top);
        camera.LimitLeft = Mathf.RoundToInt(left);
        camera.LimitBottom = Mathf.RoundToInt(bottom);
        camera.LimitRight = Mathf.RoundToInt(right);
    }

    // Flip the sprite horizontally
    public void FlipH(bool value)
    {

        body.FlipH = value;
        shadow.FlipH = value;
        weapon.FlipH = value;
        CombatPivot.Scale = new Vector2(value ? -1 : 1, CombatPivot.Scale.Y);
        //effect.FlipH = value;
    }
}