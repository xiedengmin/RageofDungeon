using Godot;
using System.Collections.Generic;

namespace ET {
public partial class StateMachine : Node
{
    // Signal for state change
    [Signal]
    public delegate void StateChangedEventHandler(Node currentState);

    // Start state path can be set in the inspector
    [Export]
    public NodePath StartState { get; set; }

    public Dictionary<string, Node> statesMap = new Dictionary<string, Node>();
    public List<Node> statesStack = new List<Node>();
    public Node currentState = null;
    public static bool _active = false;

    // Property for setting the active state
    public bool Active
    {
        get => _active;
        set => SetActive(value);
    }

    public override void _Ready()
    {
        if (StartState == null)
        {
            StartState = GetChild(0).GetPath();
        }

        foreach (Node child in GetChildren())
        {
            var err = child.Connect("Finished", new Callable(this, "_ChangeState"));
            if (err != Error.Ok)
            {
                GD.PrintErr(err);
            }
        }

        Initialize(StartState);
    }

    public void Initialize(NodePath initialState)
    {
        SetActive(true);
        statesStack.Insert(0, GetNode(initialState));
        currentState = statesStack[0];
        (currentState as IState)?.Enter();
    }

    private void SetActive(bool value)
    {
        _active = value;
        SetPhysicsProcess(value);
        SetProcessInput(value);

        if (!_active)
        {
            statesStack.Clear();
            currentState = null;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (currentState != null)
        {
            (currentState as IState)?.HandleInput(@event);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (currentState != null)
        {
            (currentState as IState)?.Update((float)delta);
        }
    }

    public void OnAnimationFinished(string animName)
    {
        if (!_active) return;
        (currentState as IState)?.OnAnimationFinished(animName);
    }


    public virtual void _ChangeState(string stateName)
    {
        if (!_active) return;

        (currentState as IState)?.Exit();

        if (stateName == "previous")
        {
            statesStack.RemoveAt(0);
        }
        else
        {
            statesStack[0] = statesMap[stateName];
        }

        currentState = statesStack[0];
        EmitSignal(SignalName.StateChanged, currentState);

        if (stateName != "previous")
        {
            (currentState as IState)?.Enter();
        }
    }
}
}