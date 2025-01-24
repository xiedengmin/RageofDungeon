using Godot;
namespace ET {
public partial class LorienInside : DungeonLevel
{
    private string bornStage = "";
    public override void _Ready()
    {
        bornStage = "stage_01";
    }

}
}