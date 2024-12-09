namespace GodotHFSM;

using System;

/// <summary>
/// A class that allows you to run additional functions (companion code)
/// before and after the wrapped state's code.
/// </summary>
/// <typeparam name="TStateId"></typeparam>
public class TransitionWrapper<TStateId> {
    public class WrappedTransition : TransitionBase<TStateId> {
        private readonly Action<TransitionBase<TStateId>>
            _beforeOnEnter,
            _afterOnEnter,

            _beforeShouldTransition,
            _afterShouldTransition;

        private readonly TransitionBase<TStateId> _transition;

        public WrappedTransition(
                TransitionBase<TStateId> transition,

                Action<TransitionBase<TStateId>> beforeOnEnter = null,
                Action<TransitionBase<TStateId>> afterOnEnter = null,

                Action<TransitionBase<TStateId>> beforeShouldTransition = null,
                Action<TransitionBase<TStateId>> afterShouldTransition = null) : base(
                transition.From, transition.To, forceInstantly: transition.ForceInstantly) {
            _transition = transition;

            _beforeOnEnter = beforeOnEnter;
            _afterOnEnter = afterOnEnter;

            _beforeShouldTransition = beforeShouldTransition;
            _afterShouldTransition = afterShouldTransition;
        }

        public override void Init() {
            _transition.Fsm = Fsm;
        }

        public override void OnEnter() {
            _beforeOnEnter?.Invoke(_transition);
            _transition.OnEnter();
            _afterOnEnter?.Invoke(_transition);
        }

        public override bool ShouldTransition() {
            _beforeShouldTransition?.Invoke(_transition);
            bool shouldTransition = _transition.ShouldTransition();
            _afterShouldTransition?.Invoke(_transition);
            return shouldTransition;
        }

        public override void BeforeTransition() {
            _transition.BeforeTransition();
        }

        public override void AfterTransition() {
            _transition.AfterTransition();
        }
    }

    private readonly Action<TransitionBase<TStateId>>
        _beforeOnEnter,
        _afterOnEnter,

        _beforeShouldTransition,
        _afterShouldTransition;

    public TransitionWrapper(
            Action<TransitionBase<TStateId>> beforeOnEnter = null,
            Action<TransitionBase<TStateId>> afterOnEnter = null,

            Action<TransitionBase<TStateId>> beforeShouldTransition = null,
            Action<TransitionBase<TStateId>> afterShouldTransition = null) {
        _beforeOnEnter = beforeOnEnter;
        _afterOnEnter = afterOnEnter;

        _beforeShouldTransition = beforeShouldTransition;
        _afterShouldTransition = afterShouldTransition;
    }

    public WrappedTransition Wrap(TransitionBase<TStateId> transition) {
        return new WrappedTransition(
            transition,
            _beforeOnEnter,
            _afterOnEnter,
            _beforeShouldTransition,
            _afterShouldTransition
        );
    }
}

/// <inheritdoc />
public class TransitionWrapper : TransitionWrapper<string> {
    public TransitionWrapper(
        Action<TransitionBase<string>> beforeOnEnter = null,
        Action<TransitionBase<string>> afterOnEnter = null,

        Action<TransitionBase<string>> beforeShouldTransition = null,
        Action<TransitionBase<string>> afterShouldTransition = null) : base(
        beforeOnEnter, afterOnEnter,
        beforeShouldTransition, afterShouldTransition) {
    }
}
