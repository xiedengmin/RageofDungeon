using Godot;


namespace ET.Server
{
    [Event(SceneType.Map)]
    public class ChangePosition_NotifyAOI: AEvent<ET.EventType.ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.ChangePosition args)
        {
            Unit unit = args.Unit;
            Vector3 oldPos = args.OldPos;
            int oldCellX = (int) (oldPos.X * 1000) / AOIManagerComponent.CellSize;
            int oldCellY = (int) (oldPos.Y * 1000) / AOIManagerComponent.CellSize;
            int newCellX = (int) (unit.Position.X * 1000) / AOIManagerComponent.CellSize;
            int newCellY = (int) (unit.Position.Y * 1000) / AOIManagerComponent.CellSize;
            if (oldCellX == newCellX && oldCellY == newCellY)
            {
                return;
            }

            AOIEntity aoiEntity = unit.GetComponent<AOIEntity>();
            if (aoiEntity == null)
            {
                return;
            }

            unit.DomainScene().GetComponent<AOIManagerComponent>().Move(aoiEntity, newCellX, newCellY);
            await ETTask.CompletedTask;
        }
    }
}