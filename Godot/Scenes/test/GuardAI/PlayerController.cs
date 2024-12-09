namespace GodotHFSM.Samples.GuardAI;

using Godot;

public partial class PlayerController : CharacterBody2D {
    /// <summary>
    /// Declare the finite state machine
    /// </summary>
    /*
    enum PlayerStates {
    IDLE, MOVE, JUMP
}

enum MoveStates {
    WALK, DASH
}

enum Events {
    ON_DAMAGE, ON_WIN
}
    */

    private StateMachine _fsm;

    [Export] public float Speed { get; set; } = 200;

    public override void _Ready() {
    
      /*  var fsm = new StateMachine<PlayerStates, Events>();
        var moveFsm = new StateMachine<PlayerStates, MoveStates, Events>();
        var idleFsm = new StateMachine<PlayerStates, string, Events>();

        fsm.AddState(PlayerStates.IDLE, idleFsm);
        fsm.AddState(PlayerStates.MOVE, moveFsm);
        fsm.AddState(PlayerStates.JUMP, new State<PlayerStates, Events>());
        // Or simply using shortcut methods: fsm.AddState(PlayerStates.JUMP);

        moveFsm.AddState(MoveStates.WALK);
        moveFsm.AddState(MoveStates.DASH);
        moveFsm.AddTransition(new Transition<MoveStates>(MoveStates.WALK, MoveStates.DASH));
        // Or simply: fsm.AddTransition(MoveStates.WALK, MoveStates.DASH);

        idleFsm.AddState("Animation 1", new State<string, Events>());
        idleFsm.AddState("Animation 2");
      */
        _fsm = new();
        _fsm.AddState("Idle", isGhostState: true);
        _fsm.SetStartState("Idle");

        _fsm.AddState("Moving",
            onLogic: (_, delta) => {
                Velocity = GetInputDirection() * Speed * (float)delta * 100f;
                MoveAndSlide();
            },
            canExit: _ => GetInputDirection().IsZeroApprox(),
            needsExitTime: true
        );
        _fsm.AddTransition("Idle", "Moving", _ => !GetInputDirection().IsZeroApprox());
        _fsm.AddTransition("Moving", "Idle");

        _fsm.Init();
    }

    public override void _PhysicsProcess(double delta) {
        _fsm.OnLogic(delta);
    }

    private static Vector2 GetInputDirection() {
       
            float x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
            float y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
            return new Vector2(x, y);
      
        // return Input.GetVector("left", "right", "up", "down");
    }
}
