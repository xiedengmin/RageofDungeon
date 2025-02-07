using System;
using ET.Client;
using Godot;


namespace ET
{
    [ObjectSystem]
    public class OperaComponentAwakeSystem : AwakeSystem<OperaComponent>
    {
        protected override void Awake(OperaComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class OperaComponentUpdateSystem : UpdateSystem<OperaComponent>
    {
        protected override void Update(OperaComponent self)
        {
            self.Update();
        }
    }

    [FriendOf(typeof(OperaComponent))]
    public static class OperaComponentSystem
    {
        public static void Awake(this OperaComponent self)
        {

        }
        private static void PrintNodePaths(Node node)
        {
            GD.Print(node.GetPath());
            foreach (Node child in node.GetChildren())
            {
                PrintNodePaths(child);
            }
        }
        public static async ETTask SendEquipRequest(Session session)
        {
            /*  if (Input.IsKeyPressed(Key.T))
              {

                  Equipment equipment = new Equipment
                  {
                      Id = 1,
                      Name = "小试牛刀",
                      Attack = 10,
                      Defense = 5,
                      Dodge = 2
                  };

                  // ����������Ϣ
                  C2G_EquipRequest request = new C2G_EquipRequest
                  {
                      PlayerId = 1,
                      Equip = equipment
                  };

                  // �������󵽷�����

                  G2C_EquipResponse response = await session.Call(request) as G2C_EquipResponse;

                  // ������������Ӧ
                  if (response.RpcId == 90)
                  {
                      Log.Info($"装备名: {response.Equip.Name}");
                  }
                  else
                  {
                      Log.Error($"装备名: {response.Message}");
                  }
              } */
            await ETTask.CompletedTask;
        }
        public static void Update(this OperaComponent self)
        {
            Session session = self.ClientScene().GetComponent<SessionComponent>().Session; // 会话
            //    if (Input.IsMouseButtonPressed(MouseButton.Left))
            //    {
            //        InputEventMouse inputEventMouse = Input.mou
            //        inputEventMouse
            //        Vector2 mouseInput = new Vector2(..X, motion.Relative.Y);

            //        Vector3 cameraTarget += new Vector3(-motion.Relative.Y * mouseSensitivity, -motion.Relative.X * mouseSensitivity, 0);
            //        if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
            //        {
            //            self.ClickPoint = hit.point;
            //            self.frameClickMap.X = self.ClickPoint.X;
            //            self.frameClickMap.Y = self.ClickPoint.Y;
            //            self.frameClickMap.Z = self.ClickPoint.Z;
            //            self.ZoneScene().GetComponent<SessionComponent>().Session.Send(self.frameClickMap);
            //        }
            //    }

            //    // KeyCode.R
            //    if (InputHelper.GetKeyDown(114))
            //    {
            //        CodeLoader.Instance.LoadLogic();
            //        Game.EventSystem.Add(CodeLoader.Instance.GetHotfixTypes());
            //        Game.EventSystem.Load();
            //        Log.Debug("hot reload success!");
            //    }

            ETTask eTTask = SendEquipRequest(session);
            if (Input.IsKeyPressed(Key.T))
            {
                C2M_TransferMap c2MTransferMap = new C2M_TransferMap();
                self.ClientScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
            }
            //if (Init.Instance.InputEvent is InputEventMouse mouseEvent && Input.IsMouseButtonPressed(MouseButton.Left))
            if (Init.Instance.InputEvent is InputEventMouseButton mouseEvent && (MouseButton)mouseEvent.ButtonIndex == MouseButton.Left)
            //if (Init.Instance.InputEvent is InputEventMouseMotion mouseEvent)// && (MouseButton)mouseEvent.ButtonIndex == MouseButton.Left)
            {
                if (mouseEvent == null)
                {
                    return;
                }

                if (mouseEvent.IsReleased())
                {
                    //mouseEvent.Position;
                    //PrintNodePaths(GlobalComponent.Instance.Unit);
                    Camera2D camera2D = GlobalComponent.Instance.Unit.GetNode<Camera2D>("CameraRoot/Camera2D");

                    if (camera2D == null)
                    {
                        return;
                    }

                    float RayLength = 1;

                    // var from = camera3D.ProjectRayOrigin(mouseEvent.Position);
                    //  var to = from + camera3D.ProjectRayNormal(mouseEvent.Position) * RayLength;
                    var from = camera2D.Position = (mouseEvent.Position);
                    var to = from + camera2D.Position + (mouseEvent.Position) * RayLength;
                    Unit unit = self.Parent.GetComponent<UnitComponent>().MyUnit;
                    if (unit == null)
                    {
                        return;
                    }

                    var gameObject = unit.GetComponent<GameObjectComponent>().GameObject;

                    var spaceState = GlobalComponent.Instance.Unit.GetWorld2D().DirectSpaceState;
                    var query = PhysicsRayQueryParameters2D.Create(from, to);
                    query.Exclude = new Godot.Collections.Array<Rid> { new Rid(gameObject) };
                    query.CollideWithAreas = true;
                    var result = spaceState.IntersectRay(query);
                    if (!result.TryGetValue("position", out var position))
                    {
                        return;
                    }
                    Vector3 vector3 = (Vector3)position;


                    //Log.Debug($"click pos 2d:{mouseEvent.Position} 3d:{vector3}");
                    self.ClickPoint = vector3;
                    self.ClickPoint.Z = 0;
                    self.frameClickMap.Position = new Vector3(self.ClickPoint.X, self.ClickPoint.Y, self.ClickPoint.Z);
                    self.ClientScene().GetComponent<SessionComponent>().Session.Send(self.frameClickMap);

                    //Log.Debug($"click pos 2d:{mouseEvent.Position} 3d:{vector3}");

                }
            }

        }
    }
}