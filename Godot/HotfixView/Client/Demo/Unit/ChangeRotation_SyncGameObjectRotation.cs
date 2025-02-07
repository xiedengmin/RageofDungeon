using Godot;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ChangeRotation_SyncGameObjectRotation : AEvent<EventType.ChangeRotation>
    {
        protected override async ETTask Run(Scene scene, EventType.ChangeRotation args)
        {
            Unit unit = args.Unit;
            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            // Node3D transform = gameObjectComponent.GameObject;
            // transform.Quaternion = args.Unit.Rotation;

            await ETTask.CompletedTask;
        }
    }
}
