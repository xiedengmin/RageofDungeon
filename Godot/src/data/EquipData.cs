using Godot;
using System.Collections.Generic;

namespace ET {
public partial class EquipData : Node
{
    // 装备列表
    public  Godot.Collections.Dictionary<string, Variant> equipmentData { get; set; } = new  Godot.Collections.Dictionary<string, Variant>();

    public override void _Ready()
    {
        base._Ready();
    }
}
}