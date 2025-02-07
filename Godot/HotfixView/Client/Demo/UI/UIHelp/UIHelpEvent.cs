using System;
using Godot;

namespace ET.Client
{
	[UIEvent(UIType.UIHelp)]
    public class UIHelpEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
	        try
	        {//有大问题
		      //  await uiComponent.DomainScene().GetComponent<ResourcesLoaderComponent>().LoadAsync(UIType.UIHelp.StringToAB());
             //   Node bundleGameObject = (Node) ResourcesComponent.Instance.GetAsset(UIType.UIHelp.StringToAB(), UIType.UIHelp);
		       // Node gameObject = Node.Instantiate(bundleGameObject, UIEventComponent.Instance.GetLayer((int)uiLayer));
		     //   UI ui = uiComponent.AddChild<UI, string, Node>(UIType.UIHelp, bundleGameObject);

				//ui.AddComponent<UIHelpComponent>();
				return null;
	        }
	        catch (Exception e)
	        {
				Log.Error(e);
		        return null;
	        }
		}

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}