using Godot;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class NodeObjectComponent : Entity, IAwake, IDestroy
    {
        public Node2D NodeObject { get; set; }
    }
}