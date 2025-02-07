using Godot;

namespace ET.Client
{
	[ComponentOf(typeof(UI))]
	public class UIHelpComponent : Entity, IAwake
	{
		public TextMesh text;
	}
}
