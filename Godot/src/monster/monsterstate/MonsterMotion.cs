using Godot;
using System;

namespace ET {
public partial class MonsterMotion : IState
{
    // Signal for when the action finishes
    //[Signal]
    //public delegate void FinishedEventHandler(string state);

    // Handle input for simulating damage (Commented out as in original script)
    // public void HandleInput(InputEvent @event)
    // {
    //     if (@event.IsActionPressed("simulate_damage"))
    //     {
    //         EmitSignal("Finished", "stagger");
    //     }
    // }

    // Get the input direction based on player movement
    public Vector2 GetInputDirection()
    {
        float horizontal = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        float vertical = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

        return new Vector2(horizontal, vertical);
    }

    // Update the look direction of the character
    public void UpdateLookDirection(Vector2 direction)
    {
        if (direction != Vector2.Zero && (Vector2)Owner.Get("lookDirection") != direction)
        {
            Owner.Set("lookDirection", direction);
        }
    }

    // Determine the direction (left or right) based on player position
    public bool GetDirection()
    {
        bool value = false;
        Vector2 playerPosition = (Vector2)Owner.GetNode("Character").Get("global_position");
        Vector2 ownerPosition = (Vector2)Owner.Get("global_position");

        if (playerPosition.X < ownerPosition.X)
        {
            value = true;
        }
        else
        {
            value = false;
        }

        return value;
    }
}
}