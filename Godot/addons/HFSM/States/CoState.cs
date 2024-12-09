namespace GodotHFSM;

using System;
using System.Collections;
using HCoroutines;

/// <summary>
/// A state that can run a Unity coroutine as its OnLogic method.
/// </summary>
/// <inheritdoc />
public class CoState<TStateId, TEvent> : ActionState<TStateId, TEvent> {
    private readonly Func<IEnumerator> _coroutineCreator;
    private readonly Action<CoState<TStateId, TEvent>> _onEnter;
    private readonly Action<CoState<TStateId, TEvent>> _onExit;
    private readonly Func<CoState<TStateId, TEvent>, bool> _canExit;

    private readonly bool _shouldLoopCoroutine;
    private Coroutine _activeCoroutine;

    public ITimer Timer { get; } = new Timer();

    // The CoState class allows you to use either a function without any parameters or a
    // function that takes the state as a parameter to create the coroutine.
    // To allow for this and ease of use, the class has two nearly identical constructors.

    /// <summary>
    /// Initializes a new instance of the CoState class.
    /// </summary>
    /// <param name="onEnter">A function that is called when the state machine enters this state.</param>
    /// <param name="coroutine">A coroutine that is run while this state is active.
    /// 	It runs independently from the parent state machine's OnLogic(), because it is handled by Unity.
    /// 	It is started once the state enters and is terminated when the state exits.</param>
    /// <param name="onExit">A function that is called when the state machine exits this state.</param>
    /// <param name="canExit">(Only if needsExitTime is true):
    /// 	Function that determines if the state is ready to exit (true) or not (false).
    /// 	It is called OnExitRequest and on each logic step when a transition is pending.</param>
    /// <param name="loop">If true, it will loop the coroutine, running it again once it has completed.</param>
    /// <inheritdoc cref="StateBase{T}(bool, bool)"/>
    public CoState(
            Func<CoState<TStateId, TEvent>, IEnumerator> coroutine,
            Action<CoState<TStateId, TEvent>> onEnter = null,
            Action<CoState<TStateId, TEvent>> onExit = null,
            Func<CoState<TStateId, TEvent>, bool> canExit = null,
            bool loop = true,
            bool needsExitTime = false,
            bool isGhostState = false) : base(needsExitTime, isGhostState) {
        _coroutineCreator = () => coroutine(this);
        _onEnter = onEnter;
        _onExit = onExit;
        _canExit = canExit;
        _shouldLoopCoroutine = loop;
    }

    /// <inheritdoc cref="CoState{TStateId, TEvent}(
    /// 	Func{CoState{TStateId, TEvent}, IEnumerator},
    /// 	Action{CoState{TStateId, TEvent}},
    /// 	Action{CoState{TStateId, TEvent}},
    /// 	Func{CoState{TStateId, TEvent}, bool},
    /// 	bool,
    /// 	bool,
    /// 	bool
    /// )"/>
    public CoState(
            Func<IEnumerator> coroutine,
            Action<CoState<TStateId, TEvent>> onEnter = null,
            Action<CoState<TStateId, TEvent>> onExit = null,
            Func<CoState<TStateId, TEvent>, bool> canExit = null,
            bool loop = true,
            bool needsExitTime = false,
            bool isGhostState = false) : base(needsExitTime, isGhostState) {
        _coroutineCreator = coroutine;
        _onEnter = onEnter;
        _onExit = onExit;
        _canExit = canExit;
        _shouldLoopCoroutine = loop;
    }

    public override void OnEnter() {
        Timer.Reset();

        _onEnter?.Invoke(this);

        if (_coroutineCreator != null) {
            _activeCoroutine = Co.Run(
                _shouldLoopCoroutine
                ? LoopCoroutine()
                : _coroutineCreator()
            );
        }
    }

    private IEnumerator LoopCoroutine() {
        IEnumerator routine = _coroutineCreator();
        while (true) {
            // This checks if the routine needs at least one frame to execute.
            // If not, LoopCoroutine will wait 1 frame to avoid an infinite
            // loop which will crash Unity.
            yield return routine.MoveNext() ? routine.Current : null;

            // Iterate from the onLogic coroutine until it is depleted.
            while (routine.MoveNext()) {
                yield return routine.Current;
            }

            // Restart the coroutine.
            routine = _coroutineCreator();
        }
    }

    public override void OnLogic(double delta) {
        if (NeedsExitTime && _canExit != null && Fsm.HasPendingTransition && _canExit(this)) {
            Fsm.StateCanExit();
        }
    }

    public override void OnExit() {
        if (_activeCoroutine != null) {
         //   if (_activeCoroutine.IsPlaying) {
                _activeCoroutine.Kill();
           // }
            _activeCoroutine = null;
        }

        _onExit?.Invoke(this);
    }

    public override void OnExitRequest() {
        if (_canExit != null && _canExit(this)) {
            Fsm.StateCanExit();
        }
    }
}

/// <inheritdoc />
public class CoState<TStateId> : CoState<TStateId, string> {
    /// <inheritdoc />
    public CoState(
        Func<CoState<TStateId, string>, IEnumerator> coroutine,
        Action<CoState<TStateId, string>> onEnter = null,
        Action<CoState<TStateId, string>> onExit = null,
        Func<CoState<TStateId, string>, bool> canExit = null,
        bool loop = true,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            coroutine: coroutine,
            onEnter: onEnter,
            onExit: onExit,
            canExit: canExit,
            loop: loop,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }

    /// <inheritdoc />
    public CoState(
        Func<IEnumerator> coroutine,
        Action<CoState<TStateId, string>> onEnter = null,
        Action<CoState<TStateId, string>> onExit = null,
        Func<CoState<TStateId, string>, bool> canExit = null,
        bool loop = true,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            coroutine: coroutine,
            onEnter: onEnter,
            onExit: onExit,
            canExit: canExit,
            loop: loop,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }
}

/// <inheritdoc />
public class CoState : CoState<string, string> {
    /// <inheritdoc />
    public CoState(
        Func<CoState<string, string>, IEnumerator> coroutine,
        Action<CoState<string, string>> onEnter = null,
        Action<CoState<string, string>> onExit = null,
        Func<CoState<string, string>, bool> canExit = null,
        bool loop = true,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            coroutine: coroutine,
            onEnter: onEnter,
            onExit: onExit,
            canExit: canExit,
            loop: loop,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }

    /// <inheritdoc />
    public CoState(
        Func<IEnumerator> coroutine,
        Action<CoState<string, string>> onEnter = null,
        Action<CoState<string, string>> onExit = null,
        Func<CoState<string, string>, bool> canExit = null,
        bool loop = true,
        bool needsExitTime = false,
        bool isGhostState = false)
        : base(
            coroutine: coroutine,
            onEnter: onEnter,
            onExit: onExit,
            canExit: canExit,
            loop: loop,
            needsExitTime: needsExitTime,
            isGhostState: isGhostState) {
    }
}