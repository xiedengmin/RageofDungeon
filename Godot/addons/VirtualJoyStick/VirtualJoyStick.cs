using Godot;

public partial class VirtualJoyStick : Control
{
	[Export] private Color pressedColor = Colors.Gray;
	[Export(PropertyHint.Range, "0,200,1")] private float deadZoneSize = 5;
	[Export(PropertyHint.Range, "0,500,1")] private float clampZoneSize = 30;
	enum JoyStickMode{
		FIXED, // The joystick doesn't move.
		DYNAMIC, // Every time the joystick area is pressed, the joystick position is set on the touched position.
		FOLLOWING // When the finger moves outside the joystick area, the joystick will follow it.
	}
	[Export] private JoyStickMode joyStickMode = JoyStickMode.FIXED;
	enum VisibilityMode {
		ALWAYS, // Always visible
		TOUCHSCREEN_ONLY, // Visible on touch screens only
		WHEN_TOUCHED // Visible only when touched
	}

	// If the joystick is always visible, or is shown only if there is a touchscreen
	[Export] VisibilityMode visibilityMode = VisibilityMode.ALWAYS;

	// If true, the joystick uses Input Actions (Project -> Project Settings -> Input Map)
	[Export] private bool useInputActions = true;
	[Export] private string actionLeft = "ui_left";
	[Export] private string actionRight = "ui_right";
	[Export] private string actionUp = "ui_up";
	[Export] private string actionDown = "ui_down";

	//PUBLIC VARIABLES

	// If the joystick is receiving inputs.
	public bool Pressed = false;

	// The joystick output.
	public Vector2 Output = Vector2.Zero;

	//PRIVATE VARIABLES

	private int _touchIndex = -1;

	private TextureRect _base;
	private TextureRect _tip;
	private Vector2 _baseDefaultPosition;
	private Vector2 _tipDefaultPosition;

	private Color _defaultColor;
	public override void _Ready()
	{
		_base = GetNode<TextureRect>("Base");
		_tip = GetNode<TextureRect>("Base/Tip");
		_baseDefaultPosition = _base.Position;
		_tipDefaultPosition = _tip.Position;
		_defaultColor = _tip.Modulate;

		if (ProjectSettings.GetSetting("input_devices/pointing/emulate_mouse_from_touch").AsBool())
			GD.PrintErr("The Project Setting 'emulate_mouse_from_touch' should be set to False");
		if (!ProjectSettings.GetSetting("input_devices/pointing/emulate_touch_from_mouse").AsBool())
			GD.PrintErr("The Project Setting 'emulate_touch_from_mouse' should be set to True");
		
		if (!DisplayServer.IsTouchscreenAvailable() && visibilityMode == VisibilityMode.TOUCHSCREEN_ONLY)
			Hide();
		
		if (visibilityMode == VisibilityMode.WHEN_TOUCHED)
			Hide();
	}

	private bool IsPointInsideJoystickArea(Vector2 point){
		bool x = point.X >= GlobalPosition.X && point.X <= GlobalPosition.X + (Size.X * GetGlobalTransformWithCanvas().Scale.X);
		bool y = point.Y >= GlobalPosition.Y && point.Y <= GlobalPosition.Y + (Size.Y * GetGlobalTransformWithCanvas().Scale.Y);
		return x && y;
	}

	private Vector2 GetBaseRadius()
		=> _base.Size * _base.GetGlobalTransformWithCanvas().Scale / 2;
	private bool IsPointInsideBase(Vector2 point){
		var _baseRadius = GetBaseRadius();
		Vector2 center  = _base.GlobalPosition + _baseRadius;
		Vector2 vector = point - center;
		if (vector.LengthSquared() <= _baseRadius.X * _baseRadius.X)
			return true;
		else
			return false;
	}

	private void MoveBase(Vector2 newPosition)
		=> _base.GlobalPosition = newPosition - _base.PivotOffset * GetGlobalTransformWithCanvas().Scale;
	private void MoveTip(Vector2 newPosition)
		=> _tip.GlobalPosition = newPosition - _tip.PivotOffset * _base.GetGlobalTransformWithCanvas().Scale;
	private void UpdateJoyStick(Vector2 touchPosition){
		var baseRadius = GetBaseRadius();
		Vector2 center = _base.GlobalPosition + baseRadius;
		Vector2 vector = touchPosition - center;
		vector = vector.LimitLength(clampZoneSize);
		
		if (joyStickMode == JoyStickMode.FOLLOWING && touchPosition.DistanceTo(center) > clampZoneSize)
			MoveBase(touchPosition - vector);
		
		MoveTip(center + vector);
		
		if (vector.LengthSquared() > deadZoneSize * deadZoneSize){
			Pressed = true;
			Output = (vector - (vector.Normalized() * deadZoneSize)) / (clampZoneSize - deadZoneSize);
		}
		else{
			Pressed = false;
			Output = Vector2.Zero;
		}
		
		if (useInputActions){
			if (Output.X > 0){
				Input.ActionRelease(actionLeft);
				Input.ActionPress(actionRight, Output.X);
			}
			else{

				Input.ActionRelease(actionRight);
				Input.ActionPress(actionLeft, -Output.X);
			}
			if (Output.Y > 0){
				
				Input.ActionRelease(actionUp);
				Input.ActionPress(actionDown, Output.Y);
			}
			else{
				Input.ActionRelease(actionDown);
				Input.ActionPress(actionUp, -Output.Y);
			}
		}
	}
	private void Reset(){
		Pressed = false;
		Output = Vector2.Zero;
		_touchIndex = -1;
		_tip.Modulate = _defaultColor;
		_base.Position = _baseDefaultPosition;
		_tip.Position = _tipDefaultPosition;
		if (useInputActions)
			foreach (var action in new string[]{actionLeft, actionRight, actionDown, actionUp})
				Input.ActionRelease(action);
	}
    public override void _Input(InputEvent e)
    {
		if (e is InputEventScreenTouch touchEvent){
			if (touchEvent.Pressed){
				if (IsPointInsideJoystickArea(touchEvent.Position) && _touchIndex == -1){
					if (joyStickMode == JoyStickMode.DYNAMIC || joyStickMode == JoyStickMode.FOLLOWING 
					|| (joyStickMode == JoyStickMode.FIXED && IsPointInsideBase(touchEvent.Position))){
						if (joyStickMode == JoyStickMode.DYNAMIC || joyStickMode == JoyStickMode.FOLLOWING)
							MoveBase(touchEvent.Position);
						if (visibilityMode == VisibilityMode.WHEN_TOUCHED)
							Show();
						_touchIndex = touchEvent.Index;
						_tip.Modulate = pressedColor;
						UpdateJoyStick(touchEvent.Position);
						GetViewport().SetInputAsHandled();
					}
				}
			}
			else if(touchEvent.Index == _touchIndex){
				Reset();
				if (visibilityMode == VisibilityMode.WHEN_TOUCHED)
					Hide();
				GetViewport().SetInputAsHandled();
			}
		}
		else if(e is InputEventScreenDrag dragEvent){
			if (dragEvent.Index == _touchIndex){
				UpdateJoyStick(dragEvent.Position);
				GetViewport().SetInputAsHandled();
			}
		}
    }
}
