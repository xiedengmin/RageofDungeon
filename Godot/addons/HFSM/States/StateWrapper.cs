namespace GodotHFSM;

using System;

/// <summary>
/// A class that allows you to run additional functions (companion code)
/// before and after the wrapped state's code.
/// It does not interfere with the wrapped state's timing / needsExitTime / ... behavior.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
/// <typeparam name="TEvent"></typeparam>
public class StateWrapper<TStateId, TEvent> {
    public class WrappedState : StateBase<TStateId>, ITriggerable<TEvent>, IActionable<TEvent> {
        private readonly Action<StateBase<TStateId>>
            _beforeOnEnter,
            _afterOnEnter,

            _beforeOnExit,
            _afterOnExit;

        private readonly Action<StateBase<TStateId>, double>
            _beforeOnLogic,
            _afterOnLogic;

        private readonly StateBase<TStateId> _state;

        public WrappedState(
                StateBase<TStateId> state,

                Action<StateBase<TStateId>> beforeOnEnter = null,
                Action<StateBase<TStateId>> afterOnEnter = null,

                Action<StateBase<TStateId>, double> beforeOnLogic = null,
                Action<StateBase<TStateId>, double> afterOnLogic = null,

                Action<StateBase<TStateId>> beforeOnExit = null,
                Action<StateBase<TStateId>> afterOnExit = null) : base(state.NeedsExitTime, state.IsGhostState) {
            _state = state;

            _beforeOnEnter = beforeOnEnter;
            _afterOnEnter = afterOnEnter;

            _beforeOnLogic = beforeOnLogic;
            _afterOnLogic = afterOnLogic;

            _beforeOnExit = beforeOnExit;
            _afterOnExit = afterOnExit;
        }

        public override void Init() {
            _state.Name = Name;
            _state.Fsm = Fsm;

            _state.Init();
        }

        public override void OnEnter() {
            _beforeOnEnter?.Invoke(this);
            _state.OnEnter();
            _afterOnEnter?.Invoke(this);
        }

        public override void OnLogic(double delta) {
            _beforeOnLogic?.Invoke(this, delta);
            _state.OnLogic(delta);
            _afterOnLogic?.Invoke(this, delta);
        }

        public override void OnExit() {
            _beforeOnExit?.Invoke(this);
            _state.OnExit();
            _afterOnExit?.Invoke(this);
        }

        public override void OnExitRequest() {
            _state.OnExitRequest();
        }

        public void Trigger(TEvent trigger) {
            (_state as ITriggerable<TEvent>)?.Trigger(trigger);
        }

        public void OnAction(TEvent trigger) {
            (_state as IActionable<TEvent>)?.OnAction(trigger);
        }

        public void OnAction<TData>(TEvent trigger, TData data) {
            (_state as IActionable<TEvent>)?.OnAction(trigger, data);
        }
    }

    private readonly Action<StateBase<TStateId>>
        _beforeOnEnter,
        _afterOnEnter,

        _beforeOnExit,
        _afterOnExit;

    private readonly Action<StateBase<TStateId>, double>
        _beforeOnLogic,
        _afterOnLogic;

    /// <summary>
    /// Initializes a new instance of the StateWrapper class
    /// </summary>
    /// <param name="beforeOnEnter"></param>
    /// <param name="afterOnEnter"></param>
    /// <param name="beforeOnLogic"></param>
    /// <param name="afterOnLogic"></param>
    /// <param name="beforeOnExit"></param>
    /// <param name="afterOnExit"></param>
    public StateWrapper(
            Action<StateBase<TStateId>> beforeOnEnter = null,
            Action<StateBase<TStateId>> afterOnEnter = null,

            Action<StateBase<TStateId>, double> beforeOnLogic = null,
            Action<StateBase<TStateId>, double> afterOnLogic = null,

            Action<StateBase<TStateId>> beforeOnExit = null,
            Action<StateBase<TStateId>> afterOnExit = null) {
        _beforeOnEnter = beforeOnEnter;
        _afterOnEnter = afterOnEnter;

        _beforeOnLogic = beforeOnLogic;
        _afterOnLogic = afterOnLogic;

        _beforeOnExit = beforeOnExit;
        _afterOnExit = afterOnExit;
    }

    public WrappedState Wrap(StateBase<TStateId> state) {
        return new WrappedState(
            state,
            _beforeOnEnter,
            _afterOnEnter,
            _beforeOnLogic,
            _afterOnLogic,
            _beforeOnExit,
            _afterOnExit
        );
    }
}

/// <inheritdoc />
public class StateWrapper : StateWrapper<string, string> {
    public StateWrapper(
        Action<StateBase<string>> beforeOnEnter = null,
        Action<StateBase<string>> afterOnEnter = null,

        Action<StateBase<string>, double> beforeOnLogic = null,
        Action<StateBase<string>, double> afterOnLogic = null,

        Action<StateBase<string>> beforeOnExit = null,
        Action<StateBase<string>> afterOnExit = null) : base(
        beforeOnEnter, afterOnEnter,
        beforeOnLogic, afterOnLogic,
        beforeOnExit, afterOnExit) {
    }
}
