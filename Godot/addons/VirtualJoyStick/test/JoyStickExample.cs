using Godot;
using System;

public partial class JoyStickExample : Sprite2D
{
    [Export] private VirtualJoyStick _leftJoyStick;
    [Export] private VirtualJoyStick _rightJoyStick;
    private Vector2 _moveVector;
    private float _speed = 100;

    public override void _Process(double delta)
    {
        _moveVector = Vector2.Zero;
        _moveVector = Input.GetVector("ui_left","ui_right","ui_up","ui_down");
        Position += _moveVector * _speed * (float)delta;

        if(_rightJoyStick != null && _rightJoyStick.Pressed){
            Rotation = _rightJoyStick.Output.Angle();
        }
    }

}
