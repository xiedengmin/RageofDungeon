using Godot;

namespace ET.Client
{
    [ObjectSystem]
    public class GlobalComponentAwakeSystem : AwakeSystem<GlobalComponent>
    {
        protected override void Awake(GlobalComponent self)
        {
            GlobalComponent.Instance = self;
            self.Global = Init.Instance.node;
            self.UnitRoot = self.Global.GetNode<Node2D>("UnitRoot");
            self.UIRoot = self.Global.GetNode<Node2D>("UIRoot");
            //self.NormalLayer = self.Global.GetNode<CanvasLayer>("UIRoot/Normal");
            self.NormalLayer = self.UIRoot.GetNode<CanvasLayer>("Normal");
            self.PopUpLayer = self.Global.GetNode<CanvasLayer>("UIRoot/PopUp");
            self.LoadingLayer = self.Global.GetNode<CanvasLayer>("UIRoot/Loading");
        }
    }
}