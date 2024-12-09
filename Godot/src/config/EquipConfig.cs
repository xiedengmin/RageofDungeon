using Godot;

public partial class EquipConfig : Node
{
    // ID
    public int ID { get; set; } = 0;

    // 名字
    public string Name { get; set; } = "";

    // 英文名字
    public string Name2 { get; set; } = "";

    // 道具栏类型
    public int ItemType { get; set; } = 0;

    // 装备插槽
    public string EquipmentSlot { get; set; } = "";

    public int EquipmentPhysicalAttack { get; set; } = 0;

    public int EquipmentMagicalAttack { get; set; } = 0;

    public int EquipmentPhysicalDefense { get; set; } = 0;

    public int EquipmentMagicalDefense { get; set; } = 0;

    public int SubType { get; set; } = 0;

    public string Icon { get; set; } = "";

    public string MoveWav { get; set; } = "";

    public override void _Ready()
    {
        // Do nothing
    }
}