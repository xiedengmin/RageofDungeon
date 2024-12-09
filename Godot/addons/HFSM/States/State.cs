namespace GodotHFSM;

using System;

/// <summary>
/// The "normal" state class that can run code on Enter, on Logic and on Exit,
/// while also handling the timing of the next state transition.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
/// <typeparam name="TEvent"></typeparam>
public class State<TStateId, TEvent> : ActionState<TStateId, TEvent> {
    private readonly Action<State<TStateId, TEvent>> _onEnter;
    private readonly Action<State<TStateId, TEvent>, double> _onLogic;
    private readonly Action<State<TStateId, TEvent>> _onExit;
    private readonly Func<State<TStateId, TEvent>, bool> _canExit;

    public ITimer Timer { get; } = new Timer();

    /// <summary>
    /// Initializes a new instance of the State class.
    /// </summary>
    /// <param name="onEnter">A function that is called when the state machine enters this state.</param>
    /// <param name="onLogic">A function that is called by the logic function of the state machine if this
    /// 	state is active.</param>
    /// <param name="onExit">A function that is called when the state machine exits this state.</param>
    /// <param name="canExit">(Only if needsExitTime is true):
    /// 	Function that determines if the state is ready to exit (true) or not (false).
    /// 	It is called OnExitRequest and on each logic step when a transition is pending.</param>
    /// <param name="needsExitTime">Determines if the state is allowed to instantly
    /// 	exit on a transition (false), or if the state machine should wait until the state is ready for a
    /// 	state change (true).</param>
    /// <param name="isGhostState"></param>
    public State(
            Action<State<TStateId, TEvent>> onEnter = null,
            Action<State<TStateId, TEvent>, double> onLogic = null,
            Action<State<TStateId, TEvent>> onExit = null,
            Func<State<TStateId, TEvent>, bool> canExit = null,
            bool needsExitTime = false,
            bool isGhostState = false) : base(needsExitTime, isGhostState) {
        _onEnter = onEnter;
        _onLogic = onLogic;
        _onExit = onExit;
        _canExit = canExit;
    }

    public override void OnEnter() {
        Timer.Reset();

        _onEnter?.Invoke(this);
    }

    public override void OnLogic(double delta) {
        if (NeedsExitTime && _canExit != null && Fsm.HasPendingTransition && _canExit(this)) {
            Fsm.StateCanExit();
        }

        _onLogic?.Invoke(this, delta);
    }

    public override void OnExit() {
        _onExit?.Invoke(this);
    }

    public override void OnExitRequest() {
        if (_canExit != null && _canExit(this)) {
            Fsm.StateCanExit();
        }
    }
}

/// <inheritdoc />
public class State<TStateId> : State<TStateId, string> {
    /// <inheritdoc />
    public State(
        Action<State<TStateId, string>> onEnter = null,
        Action<State<TStateId, string>, double> onLogic = null,
        Action<State<TStateId, string>> onExit = null,
        Func<State<TStateId, string>, bool> canExit = null,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            onEnter,
            onLogic,
            onExit,
            canExit,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }
}

/// <inheritdoc />
public class State : State<string, string> {
    /// <inheritdoc />
    public State(
        Action<State<string, string>> onEnter = null,
        Action<State<string, string>, double> onLogic = null,
        Action<State<string, string>> onExit = null,
        Func<State<string, string>, bool> canExit = null,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            onEnter,
            onLogic,
            onExit,
            canExit,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }
}
