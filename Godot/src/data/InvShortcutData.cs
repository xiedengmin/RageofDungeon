using Godot;
using System;

namespace ET {
public partial class InvShortcutData : Node
{
    public Godot.Collections.Array<Godot.Collections.Dictionary<string,Variant>> data { get; set; } = new ();

    public override void _Ready()
    {
        // Data.Resize(6); // Uncomment this if you need to resize the list to 6 elements
    }
}
}