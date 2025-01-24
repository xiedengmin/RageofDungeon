using Godot;
using System.Collections.Generic;
using System.Linq;

namespace ET {
public partial class PlayerStateMachine : StateMachine // Change "YourStateMachine" to the actual name of your class
{
    // Declare nodes
    [Export] private NodePath idlePath = "Idle";
    [Export] private NodePath movePath = "Move";
    [Export] private NodePath punchPath = "Punch";
    [Export] private NodePath jumpPath = "Jump";
    [Export] private NodePath damagePath = "Damage";
    [Export] private NodePath attackPath = "Attack";

    private Node idle;
    public Node move;
    public Node punch;
    public Node jump;
    private Node damage;
    private Node attack;


    public override void _Ready()
    {
        base._Ready();
        // Initialize nodes
        idle = (Idle)GetNode(idlePath);
        move = (Move)GetNode(movePath);
        punch = (Punch)GetNode(punchPath);
        jump = (Jump)GetNode(jumpPath);
        damage = (Damage)GetNode(damagePath);
        attack = (Attack)GetNode(attackPath);

        // Initialize states map
        statesMap = new Dictionary<string, Node>
        {
            { "idle", idle },
            { "move", move },
            { "punch", punch },
            { "jump", jump },
            { "damage", damage },
            { "attack", attack }
        };
    }

    public override void _ChangeState(string stateName)
    {
        if (!_active)
            return;

        if (new[] { "damage", "jump", "attack" }.Contains(stateName))
            base.statesStack.Insert(0, statesMap[stateName]);

        if (stateName == "jump" && currentState == move)
        {
            // Assuming move has speed and velocity properties you want to pass to jump
            ((Jump)jump).Initialize(((Move)move).speed, ((Move)move).velocity);
        }
        if (stateName == "attack" && currentState == jump) //如果在跳的状态下，还是先将伪z轴置0
        {

            ((Jump)jump).height = 0;
            ((Jump)jump).Update(0);
        }
        base._ChangeState(stateName); // Call base method (replace 'base' with the actual base class if needed)
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("attack"))
        {
            if (currentState == attack || currentState == damage)
                return;

            _ChangeState("attack");
            return;
        }

        if (currentState != null)
            currentState.Call("HandleInput", @event); // Call 'handle_input' method on current state
    }

    public void AttackCanCombo()
    {
        currentState.Set("canCombo", true);
    }

    public void AttackSound()
    {
        currentState.Call("AttackSound");
    }

}
}