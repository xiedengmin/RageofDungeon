using Godot;

namespace ET.Client
{
	public class CameraComponent : Entity, IAwake, ILateUpdate
	{
		// 战斗摄像机
		public Camera2D mainCamera;

		public Unit Unit;

		public Camera2D MainCamera
		{
			get
			{
				return this.mainCamera;
			}
		}
	}
}
