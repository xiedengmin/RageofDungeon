using Godot;

namespace ET
{
    public enum UILayer
    {
        Hidden = 0,
        Normal = 10,
        PopUp = 20,
        Loading = 30,

        // Low = 10,
        // Mid = 20,
        // High = 30,
    }

    public class UILayerScript //: MonoBehaviour
    {
        public UILayer UILayer;
    }
}