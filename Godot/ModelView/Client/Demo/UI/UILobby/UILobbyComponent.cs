
using Godot;

namespace ET.Client
{
	[ComponentOf(typeof(UI))]
	public class UILobbyComponent : Entity, IAwake
	{
        public Button startButton;
        public TextEdit text;
    }
}
