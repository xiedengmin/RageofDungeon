using Godot;
using System.Collections.Generic;

public partial class MonsterStateMachine: StateMachine
{
    [Export] private NodePath idlePath;
    [Export] private NodePath movePath;
    [Export] private NodePath jumpPath;
    [Export] private NodePath damagePath;
    [Export] private NodePath attackPath;
    [Export] private NodePath downPath;

    private Node idle;
    private Node move;
    private Node jump;
    private Node damage;
    private Node attack;
    private Node down;

    private Dictionary<string, Node> statesMap;
    private List<Node> statesStack = new List<Node>();

    private Node currentState;
    private bool _active;

    public override void _Ready()
    {
        idle = GetNode(idlePath);
        move = GetNode(movePath);
        jump = GetNode(jumpPath);
        damage = GetNode(damagePath);
        attack = GetNode(attackPath);
        down = GetNode(downPath);

        statesMap = new Dictionary<string, Node>
        {
            { "idle", idle },
            { "move", move },
            { "jump", jump },
            { "damage", damage },
            { "attack", attack },
            { "down", down }
        };

        base._Ready();
    }

    private void ChangeState(string stateName)
    {
        if (!_active)
            return;

        if (stateName == "damage" || stateName == "jump" || stateName == "attack")
        {
            statesStack.Insert(0, statesMap[stateName]);
        }

        if (stateName == "jump" && currentState == move)
        {
           //不好搞 ((JumpState)jump).Initialize(((MoveState)move).Speed, ((MoveState)move).Velocity);
        }

        base._ChangeState(stateName);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("attack"))
        {
            if (currentState == attack || currentState == damage)
                return;

            ChangeState("attack");
            return;
        }

        // Let the current state handle the input
        // currentState.HandleInput(@event);
    }
}