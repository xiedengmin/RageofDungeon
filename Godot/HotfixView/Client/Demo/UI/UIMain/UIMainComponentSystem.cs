using Godot;

namespace ET.Client
{
    [ObjectSystem]
    public class UIMainComponentAwakeSystem : AwakeSystem<UIMainComponent>
    {
        protected override void Awake(UIMainComponent self)
        {

        }
    }

    public static class UIMainComponentSystem
    {
        public static async ETTask EnterMapFinish(this UIMainComponent self)
        {
            // await EnterMapHelper.EnterMapAsync(self.ClientScene());
            //   await UIHelper.Remove(self.ClientScene(), UIType.UILobby);

        }
    }
}