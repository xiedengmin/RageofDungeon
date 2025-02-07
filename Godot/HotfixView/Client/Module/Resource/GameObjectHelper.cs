using System;
using Godot;
#if !GODOT
namespace ET.Client
{
	public static class GameObjectHelper
	{
		public static T Get<T>(this Node gameObject, string key) where T : class
		{
			try
			{
				return gameObject.GetComponent<ReferenceCollector>().Get<T>(key);
			}
			catch (Exception e)
			{
				throw new Exception($"获取{gameObject.name}的ReferenceCollector key失败, key: {key}", e);
			}
		}
	}
}
#endif