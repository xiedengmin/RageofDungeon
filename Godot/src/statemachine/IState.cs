using Godot;

public partial class IState : Node
{
    [Signal]
    public delegate void FinishedEventHandler(string nextStateName);
    // Initialize the state. E.g. change the animation.
    public virtual void Enter()
    {
        // Add your state initialization code here
    }

    // Clean up the state. Reinitialize values like a timer.
    public virtual void Exit()
    {
        // Add your cleanup code here
    }

    public virtual void HandleInput(InputEvent @event)
    {
        // Add your input handling code here
    }

    public virtual void Update(float delta)
    {
        // Add your update logic here
    }

    public virtual void OnAnimationFinished(string animName)
    {
        // Add your animation finished handling code here
    }
}