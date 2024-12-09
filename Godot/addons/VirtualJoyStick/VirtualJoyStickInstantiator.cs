
using Godot;

[Tool]
public partial class VirtualJoyStickInstantiator : Control
{
    private Control _scene;

    public override void _EnterTree()
    {
        _scene = ResourceLoader.Load<PackedScene>("res://addons/VirtualJoyStick/VirtualJoyStick.tscn").Instantiate<Control>();
	    AddChild(_scene);
	
        if(ProjectSettings.GetSetting("input_devices/pointing/emulate_mouse_from_touch").AsBool())
            GD.PrintErr("The Project Setting 'emulate_mouse_from_touch' should be set to False");
        if (!ProjectSettings.GetSetting("input_devices/pointing/emulate_touch_from_mouse").AsBool())
            GD.PrintErr("The Project Setting 'emulate_touch_from_mouse' should be set to True");
    }
    public override void _ExitTree()
    {
        _scene.Free();
    }
}