using Godot;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ChangePosition_SyncNodeObjectPos : AEvent<EventType.ChangePosition>
    {
        protected override async ETTask Run(Scene scene, EventType.ChangePosition args)
        {
            Unit unit = args.Unit;
            NodeObjectComponent NodeObjectComponent = unit.GetComponent<NodeObjectComponent>();
            if (NodeObjectComponent == null)
            {
                return;
            }
            NodeObjectComponent.NodeObject.Position = new Vector2(args.Unit.Position.X, args.Unit.Position.Y);
            await ETTask.CompletedTask;
        }
    }
}