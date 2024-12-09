namespace GodotHFSM;

using System;

/// <summary>
/// A class used to determine whether the state machine should transition to another state.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
public class Transition<TStateId> : TransitionBase<TStateId> {
    private readonly Func<Transition<TStateId>, bool> _condition;
    private readonly Action<Transition<TStateId>> _beforeTransition;
    private readonly Action<Transition<TStateId>> _afterTransition;

    /// <summary>
    /// Initializes a new instance of the Transition class.
    /// </summary>
    /// <param name="condition">A function that returns true if the state machine
    /// 	should transition to the <c>to</c> state.</param>
    /// <param name="onTransition">Callback function that is called just before the transition happens.</param>
    /// <param name="afterTransition">Callback function that is called just after the transition happens.</param>
    /// <inheritdoc cref="TransitionBase{TStateId}(TStateId, TStateId, bool)" />
    public Transition(
            TStateId from,
            TStateId to,
            Func<Transition<TStateId>, bool> condition = null,
            Action<Transition<TStateId>> onTransition = null,
            Action<Transition<TStateId>> afterTransition = null,
            bool forceInstantly = false) : base(from, to, forceInstantly) {
        _condition = condition;
        _beforeTransition = onTransition;
        _afterTransition = afterTransition;
    }

    public override bool ShouldTransition() {
        return _condition == null || _condition(this);
    }

    public override void BeforeTransition() {
        _beforeTransition?.Invoke(this);
    }

    public override void AfterTransition() {
        _afterTransition?.Invoke(this);
    }
}

/// <inheritdoc />
public class Transition : Transition<string> {
    /// <inheritdoc />
    public Transition(
        string @from,
        string to,
        Func<Transition<string>, bool> condition = null,
        Action<Transition<string>> onTransition = null,
        Action<Transition<string>> afterTransition = null,
        bool forceInstantly = false) : base(
            @from,
            to,
            condition,
            onTransition: onTransition,
            afterTransition: afterTransition,
            forceInstantly: forceInstantly) {
    }
}
