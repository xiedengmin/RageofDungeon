﻿using System;
using Godot;

namespace ET
{
	[ComponentOf(typeof(Scene))]
	public class OperaComponent : Entity, IAwake, IUpdate
	{
		public Vector2 ClickPoint;

		public int mapMask;

		public readonly C2M_PathfindingResult frameClickMap = new C2M_PathfindingResult();
	}
}
