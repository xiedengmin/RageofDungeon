namespace GodotHFSM;

using System;

/// <summary>
/// A class used to determine whether the state machine should transition to another state
/// depending on a delay and an optional condition.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
public class TransitionAfter<TStateId> : TransitionBase<TStateId> {
    private readonly float _delay;
    private readonly Func<TransitionAfter<TStateId>, bool> _condition;

    private readonly Action<TransitionAfter<TStateId>> _beforeTransition;
    private readonly Action<TransitionAfter<TStateId>> _afterTransition;

    public ITimer Timer { get; } = new Timer();

    /// <summary>
    /// Initializes a new instance of the TransitionAfter class.
    /// </summary>
    /// <param name="delay">The delay that must elapse before the transition can occur</param>
    /// <param name="condition">A function that returns true if the state machine
    /// 	should transition to the <c>to</c> state.
    /// 	It is only called after the delay has elapsed and is optional.</param>
    /// <inheritdoc cref="Transition{TStateId}(TStateId, TStateId, Func{Transition{TStateId}, bool},
    /// 	Action{Transition{TStateId}}, Action{Transition{TStateId}}, bool)" />
    public TransitionAfter(
            TStateId from,
            TStateId to,
            float delay,
            Func<TransitionAfter<TStateId>, bool> condition = null,
            Action<TransitionAfter<TStateId>> onTransition = null,
            Action<TransitionAfter<TStateId>> afterTransition = null,
            bool forceInstantly = false) : base(from, to, forceInstantly) {
        _delay = delay;
        _condition = condition;
        _beforeTransition = onTransition;
        _afterTransition = afterTransition;
    }

    public override void OnEnter() {
        Timer.Reset();
    }

    public override bool ShouldTransition() {
        return Timer.Elapsed >= _delay && (_condition == null || _condition(this));
    }

    public override void BeforeTransition() {
        _beforeTransition?.Invoke(this);
    }

    public override void AfterTransition() {
        _afterTransition?.Invoke(this);
    }
}

/// <inheritdoc />
public class TransitionAfter : TransitionAfter<string> {
    /// <inheritdoc />
    public TransitionAfter(
        string @from,
        string to,
        float delay,
        Func<TransitionAfter<string>, bool> condition = null,
        Action<TransitionAfter<string>> onTransition = null,
        Action<TransitionAfter<string>> afterTransition = null,
        bool forceInstantly = false) : base(
            @from,
            to,
            delay,
            condition,
            onTransition: onTransition,
            afterTransition: afterTransition,
            forceInstantly: forceInstantly) {
    }
}
