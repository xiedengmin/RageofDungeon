using Godot;

namespace ET {
public partial class DraggableBar : NinePatchRect
{
    private Node parent = null;
    private bool drag = false;
    private Vector2 offset = Vector2.Zero;

    public override void _Ready()
    {
        parent = GetParent();
    }

    public override void _Input(InputEvent @event)
    {
        if (parent != null && drag && @event is InputEventMouseMotion mouseEvent)
        {
            if (parent is Node2D parentNode2D)
            {
                parentNode2D.GlobalPosition = mouseEvent.GlobalPosition - offset;
            }
        }
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            drag = mouseEvent.Pressed;
            if (parent is Node2D parentNode2D)
            {
                offset = mouseEvent.GlobalPosition - parentNode2D.GlobalPosition;
            }
        }
    }
}

}