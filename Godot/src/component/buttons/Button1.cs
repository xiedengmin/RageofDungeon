using Godot;

namespace ET {
public partial class Button1 : Button
{
    [Export] private AudioStreamPlayer _clickSound;
    [Export] private AudioStreamPlayer _enteredSound;

    public override void _Ready()
    {
        _clickSound = GetNode<AudioStreamPlayer>("ClickSound");
        _enteredSound = GetNode<AudioStreamPlayer>("EnteredSound");
    }

    private void _on_Button1_pressed()
    {
        _clickSound.Play();
    }

    private void _on_Button1_mouse_entered()
    {
        // Uncomment to enable the sound on mouse enter
       _enteredSound.Play();
    }
}
}