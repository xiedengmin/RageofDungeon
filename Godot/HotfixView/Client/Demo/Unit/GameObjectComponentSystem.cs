using System;

namespace ET.Client
{
    public static class NodeObjectComponentSystem
    {
        [ObjectSystem]
        public class DestroySystem : DestroySystem<NodeObjectComponent>
        {
            protected override void Destroy(NodeObjectComponent self)
            {
                self.NodeObject.Free();
                self.NodeObject.Dispose();
                //self.NodeObject.QueueFree();
            }
        }
    }
}