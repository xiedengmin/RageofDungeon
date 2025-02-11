namespace ET.Client
{
	[Event(SceneType.Client)]
	public class EnterMapFinish_CreateUIMain : AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(Scene scene, EventType.EnterMapFinish args)
		{
			await UIHelper.Create(scene, UIType.UIMain, UILayer.Normal);
		}
	}
}
