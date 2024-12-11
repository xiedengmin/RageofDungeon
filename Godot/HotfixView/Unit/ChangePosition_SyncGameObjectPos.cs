using System;
using Godot;

namespace ET
{
    public class ChangePosition_SyncGameObjectPos : AEventClass<EventType.ChangePosition>
    {
        protected override void Run(object changePosition)
        {
            EventType.ChangePosition args = changePosition as EventType.ChangePosition; ;
            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            gameObjectComponent.GameObject.Position = new Vector2(args.Unit.Position.X, args.Unit.Position.Y);
        }
    }
}