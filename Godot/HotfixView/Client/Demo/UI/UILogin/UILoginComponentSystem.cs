using ET.Client;
using Godot;


namespace ET
{
	[ObjectSystem]
	public class UILoginComponentAwakeSystem : AwakeSystem<UILoginComponent>
	{
		protected override void Awake(UILoginComponent self)
		{
			Node login = self.GetParent<UI>().NodeObject;
			self.loginBtn = login.GetNode<Button>("LoginButton");
			self.account = login.GetNode<TextEdit>("Account");
			self.password = login.GetNode<TextEdit>("Password");

			self.loginBtn.ButtonDown += async () =>
			{
				await LoginHelper.Login(self.DomainScene(), self.account.Text, self.password.Text);
			};
		}
	}

	[FriendOf(typeof(UILoginComponent))]
	public static class UILoginComponentSystem
	{

	}
}
