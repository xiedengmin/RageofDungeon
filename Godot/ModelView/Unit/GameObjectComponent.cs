using Godot;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent : Entity, IAwake, IDestroy
    {
        public Node2D GameObject { get; set; }
    }
}