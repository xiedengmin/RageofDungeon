using System;
using System.Collections.Generic;
using Godot;

namespace ET.Client
{
	/// <summary>
	/// 管理所有UI NodeObject
	/// </summary>
	[ComponentOf(typeof(Scene))]
	public class UIEventComponent : Entity, IAwake
	{
		[StaticField]
		public static UIEventComponent Instance;

		public Dictionary<string, AUIEvent> UIEvents = new Dictionary<string, AUIEvent>();

		public Dictionary<int, Node> UILayers { get; set; } = new Dictionary<int, Node>();
	}
}