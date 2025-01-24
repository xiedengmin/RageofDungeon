using Godot;
namespace ET
{
    public partial class paowu : CharacterBody2D
    {
        [Export] public float speed = 500.0f;
        private Vector2 direction = new Vector2(1.0f, -0.5f);
        private Vector2 velocity;
        private float g = 2.2f;
        [Export]
        public float BulletSpeed = 400.0f;    // 子弹速度
        [Export]
        public float MaxLifetime = 5.0f;      // 子弹的最大生存时间

        private float _lifespan = 0.0f;       // 子弹已生存时间
        private AttackData attackData;

        public override void _Ready()
        {
            attackData = new AttackData();
            attackData.Damage = 10;
            attackData.XOffset = 30;
            //  SetPhysicsProcess(true);           // 启用物理帧更新
            // SetAsTopLevel(true);
            velocity = direction * speed; // Initial velocity vector
            SetUpDirection(Vector2.Up);
            // PrintOrphanNodes();

        }


        public override void _PhysicsProcess(double delta)
        {
            velocity.Y += g * g;
            SetVelocity(velocity);
            SetFloorStopOnSlopeEnabled(false);
            //  player.SetMaxSlides(1);
            MoveAndSlide();
            // var collisionInfo = stone.MoveAndCollide(velocity);
            // if (collisionInfo != null)
            //  {
            //     QueueFree();
            // }

            // 更新子弹的生存时间
            _lifespan += (float)delta;

            // 检查子弹是否超出玩家视线或超出生存时间
            if (_lifespan > MaxLifetime)
            {
                QueueFree();  // 删除子弹以释放资源
            }
        }

        public void SetDirection(Vector2 Dir)
        {
            //   SetAsTopLevel(true);
            velocity = Dir * speed; // Initial velocity vector

        }
    }
}