using System;
using Godot;

namespace ET.Client
{
    [UIEvent(UIType.UIMain)]
    public class UIMainEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            PackedScene mainui = GD.Load<PackedScene>($"res://Scenes/UIMain.tscn");
            //Node3D scene = res.Instantiate() as Node3D;
            Node2D UIMain = mainui.Instantiate() as Node2D;
            //  GlobalComponent.Instance.UIRoot.AddChild(UIMain);
            // Node2D vjs = ResourceLoader.Load<PackedScene>("res://addons/VirtualJoyStick/test/Test.tscn").Instantiate<Node2D>();
            // GlobalComponent.Instance.UIRoot.AddChild(vjs);
            //var res = GD.Load<PackedScene>("res://Scenes/UIMain.tscn");
            //Control lobby = res.Instantiate() as Control;
            UIEventComponent.Instance.UILayers[(int)uiLayer].AddChild(UIMain);
            UI ui = uiComponent.AddChild<UI, string, Node>(UIType.UIMain, UIMain);
            ui.AddComponent<UIMainComponent>();
            await ETTask.CompletedTask;
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            uiComponent.Remove(UIType.UIMain);
        }
    }
}