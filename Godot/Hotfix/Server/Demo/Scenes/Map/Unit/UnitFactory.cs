using System;
using Godot;

namespace ET.Server
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                    {
                        Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                        unit.AddComponent<MoveComponent>();
                        unit.Position = new Vector3(50, 410, -10);

                        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                        numericComponent.Set(NumericType.Speed, 120f); // 速度是6米每秒
                        numericComponent.Set(NumericType.AOI, 15000); // 视野15米

                        unitComponent.Add(unit);
                        // 加入aoi
                        unit.AddComponent<AOIEntity, int, Vector3>(59 * 10000, unit.Position);
                        return unit;
                    }
                case UnitType.Monster:
                    {
                        Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1002);
                        //ChildType测试代码 取消注释 编译Server.hotfix 可发现报错
                        //unitComponent.AddChild<Player, string>("Player");
                        unit.AddComponent<MoveComponent>();
                        unit.Position = new Vector3(-10, 0, -10);

                        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                        numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                        numericComponent.Set(NumericType.AOI, 15000); // 视野15米

                        unitComponent.Add(unit);
                        // 加入aoi
                        unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);
                        return unit;
                    }
                case UnitType.NPC:
                    {
                        Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                        //ChildType测试代码 取消注释 编译Server.hotfix 可发现报错
                        //unitComponent.AddChild<Player, string>("Player");
                        unit.AddComponent<MoveComponent>();
                        unit.Position = new Vector3(-10, 0, -10);

                        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                        numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                        numericComponent.Set(NumericType.AOI, 15000); // 视野15米

                        unitComponent.Add(unit);
                        // 加入aoi
                        unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);
                        return unit;
                    }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}