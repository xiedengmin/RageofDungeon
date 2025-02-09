using Godot;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ChangeRotation_SyncNodeObjectRotation : AEvent<EventType.ChangeRotation>
    {
        protected override async ETTask Run(Scene scene, EventType.ChangeRotation args)
        {
            Unit unit = args.Unit;
            NodeObjectComponent NodeObjectComponent = unit.GetComponent<NodeObjectComponent>();
            if (NodeObjectComponent == null)
            {
                return;
            }
            // Node3D transform = NodeObjectComponent.NodeObject;
            // transform.Quaternion = args.Unit.Rotation;

            await ETTask.CompletedTask;
        }
    }
}
