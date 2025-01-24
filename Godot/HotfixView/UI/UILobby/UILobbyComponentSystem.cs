using Godot;

namespace ET
{
    [ObjectSystem]
    public class UILobbyComponentAwakeSystem : AwakeSystem<UILobbyComponent>
    {
        public override void Awake(UILobbyComponent self)
        {
            Node login = self.GetParent<UI>().GameObject;

            // self.startButton = login.GetNode<Button>("StartButton");
            self.startButton = login.GetNode<Button>("StartBtn");
            self.startButton.ButtonDown += () =>
            {
                login.Call("OnStartBtnPressed");
                self.EnterMap().Coroutine();
            };
        }
    }

    public static class UILobbyComponentSystem
    {
        public static async ETTask EnterMap(this UILobbyComponent self)
        {

            await EnterMapHelper.EnterMapAsync(self.ZoneScene());
            await UIHelper.Remove(self.ZoneScene(), UIType.UILobby);
            PackedScene mainui = GD.Load<PackedScene>($"res://Scenes/Main.tscn");
            //Node3D scene = res.Instantiate() as Node3D;
            Node2D Mainui = mainui.Instantiate() as Node2D;
            GlobalComponent.Instance.UI.AddChild(Mainui);
            Node2D vjs = ResourceLoader.Load<PackedScene>("res://addons/VirtualJoyStick/test/Test.tscn").Instantiate<Node2D>();
            GlobalComponent.Instance.UI.AddChild(vjs);
            //    UIHelper.Create(self.ZoneScene(), UIType.UIMain, UILayer.Normal).Coroutine();


        }
    }
}