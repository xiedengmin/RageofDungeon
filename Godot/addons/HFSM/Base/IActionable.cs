namespace GodotHFSM;

/// <summary>
/// Interface for states that support custom actions. Actions are like the
/// builtin events OnEnter / OnLogic / ... but are defined by the user.
/// </summary>
/// <typeparam name="TEvent"></typeparam>
public interface IActionable<TEvent> {
    void OnAction(TEvent trigger);
    void OnAction<TData>(TEvent trigger, TData data);
}

/// <inheritdoc />
public interface IActionable : IActionable<string> {
}
