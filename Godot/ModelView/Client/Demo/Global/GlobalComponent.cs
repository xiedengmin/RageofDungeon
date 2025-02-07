using Godot;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent : Entity, IAwake
    {
        [StaticField]
        public static GlobalComponent Instance;

        public Node Global { get; set; }
        public Node2D Unit { get; set; }
        public Node2D UI { get; set; }

        public CanvasLayer Hidden { get; set; }
        public CanvasLayer NormalLayer { get; set; }
        public CanvasLayer PopUpLayer { get; set; }
        public CanvasLayer LoadingLayer { get; set; }
    }
}