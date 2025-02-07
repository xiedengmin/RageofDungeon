using Godot;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterUnitCreate args)
        {
            Unit unit = args.Unit;
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            PackedScene res = GD.Load<PackedScene>("res://Prefabs/role/character/Swordman.tscn");
            Node2D skin = res.Instantiate() as Node2D;
            GlobalComponent.Instance.Unit.AddChild(skin);
            args.Unit.AddComponent<GameObjectComponent>().GameObject = skin;
            skin.Position = new Vector2(args.Unit.Position.X, args.Unit.Position.Y);
    

            //Camera3D camera3D = GlobalComponent.Instance.Unit.GetNode<Camera3D>("Map1/CameraRoot/Camera3D");
            //camera3D.Position += skin.Position;
            //args.Unit.AddComponent<GameObjectComponent>().GameObject = skin;
            //args.Unit.AddComponent<AnimatorComponent>();
           
            unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}