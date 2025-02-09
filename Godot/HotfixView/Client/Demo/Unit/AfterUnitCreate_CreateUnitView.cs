using Godot;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView : AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterUnitCreate args)
        {
            Unit unit = args.Unit;
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            PackedScene res = GD.Load<PackedScene>("res://Prefabs/role/character/Swordman.tscn");
            Node2D role = res.Instantiate() as Node2D;
            GlobalComponent.Instance.UnitRoot.AddChild(role);
            role.Position = new Vector2(unit.Position.X, unit.Position.Y);
            unit.AddComponent<NodeObjectComponent>().NodeObject = role;

            //Camera3D camera3D = GlobalComponent.Instance.Unit.GetNode<Camera3D>("Map1/CameraRoot/Camera3D");
            //camera3D.Position += skin.Position;
            //args.Unit.AddComponent<NodeObjectComponent>().NodeObject = skin;
            //args.Unit.AddComponent<AnimatorComponent>();

            unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}