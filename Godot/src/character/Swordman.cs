using Godot;
//using static CounterAppController;

namespace ET
{
    public partial class Swordman : Character//, IController
    {
        public override void _Ready()
        {
            //   _tileMap = GetParent().GetNode<Test>("DynamicTileMap");

            base._Ready();
        }
        public override void _PhysicsProcess(double delta)
        {

            // 更新玩家位置到 TileMap 中
            // _tileMap.PlayerPosition = Position;
        }
        private void OnHitBoxAreaEntered(Area2D body)
        {
            GD.Print("player hit!");
            // CounterAppController.SendCommand<IncreaseCountCommand>();
        }
        private void OnHurtBoxAreaEntered(Area2D body)
        {
            if (body.Name != "HitBox")
            {
                GD.Print("player hurt!");
            }
        }
        public void IsMyunit(bool isMyunit)
        {
            base.IsMyunit();

        }

    }
}