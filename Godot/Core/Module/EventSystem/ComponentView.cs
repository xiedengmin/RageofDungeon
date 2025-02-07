#if ENABLE_VIEW && UNITY_EDITOR
using Godot;

namespace ET
{
    public class ComponentView: MonoBehaviour
    {
        public Entity Component
        {
            get;
            set;
        }
    }
}
#endif