namespace GodotHFSM;

/// <summary>
/// A ReverseTransition wraps another transition, but reverses it. The "from"
/// and "to" states are swapped. Only when the condition of the wrapped transition
/// is false does it transition.
/// The BeforeTransition and AfterTransition callbacks of the wrapped transition
/// are also swapped.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
public class ReverseTransition<TStateId> : TransitionBase<TStateId> {
    private readonly TransitionBase<TStateId> _wrappedTransition;
    private readonly bool _shouldInitWrappedTransition;

    public ReverseTransition(
            TransitionBase<TStateId> wrappedTransition,
            bool shouldInitWrappedTransition = true)
        : base(
            from: wrappedTransition.To,
            to: wrappedTransition.From,
            forceInstantly: wrappedTransition.ForceInstantly) {
        _wrappedTransition = wrappedTransition;
        _shouldInitWrappedTransition = shouldInitWrappedTransition;
    }

    public override void Init() {
        if (_shouldInitWrappedTransition) {
            _wrappedTransition.Fsm = Fsm;
            _wrappedTransition.Init();
        }
    }

    public override void OnEnter() {
        _wrappedTransition.OnEnter();
    }

    public override bool ShouldTransition() {
        return !_wrappedTransition.ShouldTransition();
    }

    public override void BeforeTransition() {
        _wrappedTransition.AfterTransition();
    }

    public override void AfterTransition() {
        _wrappedTransition.BeforeTransition();
    }
}

/// <inheritdoc />
public class ReverseTransition : ReverseTransition<string> {
    /// <inheritdoc />
    public ReverseTransition(
        TransitionBase<string> wrappedTransition,
        bool shouldInitWrappedTransition = true)
        : base(wrappedTransition, shouldInitWrappedTransition) {
    }
}
