
using Godot;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMainComponent : Entity, IAwake
    {
        public Button startButton;
        public TextEdit text;
    }
}
