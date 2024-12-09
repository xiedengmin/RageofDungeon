#if TOOLS
using Godot;
using System;

[Tool]
public partial class VirtualJoyStickPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		var script = GD.Load<Script>("res://addons/VirtualJoyStick/VirtualJoyStickInstantiator.cs");
		var texture = GD.Load<Texture2D>("res://addons/VirtualJoyStick/VirtualJoystickIcon.png");
		// Initialization of the plugin goes here.
		AddCustomType("Virtual Joystick", "Control", script, texture);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("Virtual Joystick");
	}
}
#endif
