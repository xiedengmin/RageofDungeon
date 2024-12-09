namespace GodotHFSM;

using System;

/// <summary>
/// A class used to determine whether the state machine should transition to another state
/// depending on a dynamically computed delay and an optional condition.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
public class TransitionAfterDynamic<TStateId> : TransitionBase<TStateId> {
    private float _delay;
    private readonly bool _onlyEvaluateDelayOnEnter;
    private readonly Func<TransitionAfterDynamic<TStateId>, float> _delayCalculator;

    private readonly Func<TransitionAfterDynamic<TStateId>, bool> _condition;

    private readonly Action<TransitionAfterDynamic<TStateId>> _beforeTransition;
    private readonly Action<TransitionAfterDynamic<TStateId>> _afterTransition;

    public ITimer Timer { get; } = new Timer();

    /// <summary>
    /// Initializes a new instance of the TransitionAfterDynamic class.
    /// </summary>
    /// <param name="delay">A function that dynamically computes the delay time.</param>
    /// <param name="condition">A function that returns true if the state machine
    /// 	should transition to the <c>to</c> state.
    /// 	It is only called after the delay has elapsed and is optional.</param>
    /// <param name="onlyEvaluateDelayOnEnter">If true, the dynamic delay is only recalculated
    /// 	when the <c>from</c> enters. If false, the delay is evaluated in each logic step.</param>
    /// <inheritdoc cref="Transition{TStateId}(TStateId, TStateId, Func{Transition{TStateId}, bool},
    /// 	Action{Transition{TStateId}}, Action{Transition{TStateId}}, bool)" />
    public TransitionAfterDynamic(
            TStateId from,
            TStateId to,
            Func<TransitionAfterDynamic<TStateId>, float> delay,
            Func<TransitionAfterDynamic<TStateId>, bool> condition = null,
            bool onlyEvaluateDelayOnEnter = false,
            Action<TransitionAfterDynamic<TStateId>> onTransition = null,
            Action<TransitionAfterDynamic<TStateId>> afterTransition = null,
            bool forceInstantly = false) : base(from, to, forceInstantly) {
        _delayCalculator = delay;
        _condition = condition;
        _onlyEvaluateDelayOnEnter = onlyEvaluateDelayOnEnter;
        _beforeTransition = onTransition;
        _afterTransition = afterTransition;
    }

    public override void OnEnter() {
        Timer.Reset();
        if (_onlyEvaluateDelayOnEnter) {
            _delay = _delayCalculator(this);
        }
    }

    public override bool ShouldTransition() {
        if (!_onlyEvaluateDelayOnEnter) {
            _delay = _delayCalculator(this);
        }

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
public class TransitionAfterDynamic : TransitionAfterDynamic<string> {
    /// <inheritdoc />
    public TransitionAfterDynamic(
        string @from,
        string to,
        Func<TransitionAfterDynamic<string>, float> delay,
        Func<TransitionAfterDynamic<string>, bool> condition = null,
        bool onlyEvaluateDelayOnEnter = false,
        Action<TransitionAfterDynamic<string>> onTransition = null,
        Action<TransitionAfterDynamic<string>> afterTransition = null,
        bool forceInstantly = false) : base(
            @from,
            to,
            delay,
            condition,
            onlyEvaluateDelayOnEnter: onlyEvaluateDelayOnEnter,
            onTransition: onTransition,
            afterTransition: afterTransition,
            forceInstantly: forceInstantly) {
    }
}
