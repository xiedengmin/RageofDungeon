using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Godot;

namespace ET
{
	public class CodeLoader : Singleton<CodeLoader>
	{
		private Assembly model;

		public void Start()
		{
			if (Define.EnableCodes)
			{
				GlobalConfig globalConfig = new GlobalConfig();
				globalConfig.CodeMode = CodeMode.ClientServer;

				if (globalConfig.CodeMode != CodeMode.ClientServer)
				{
					throw new Exception("ENABLE_CODES mode must use ClientServer code mode!");
				}

				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); //这是.netframework的方法 netcore似乎不能用
				Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(assemblies);
				EventSystem.Instance.Add(types);
				foreach (Assembly ass in assemblies)
				{
					string name = ass.GetName().Name;
					if (name == "Godot.Model.Codes")
					{
						this.model = ass;
					}
				}
				/*if (OS.HasFeature("windows"))
				{
					System.Reflection.Assembly.LoadFile(exepath + "/Godot/app_userdata/joystick_cs/joy/.godot/mono/publish/x86_64/joystick_cs.dll");
				}
				else if (OS.HasFeature("android"))
				{
					if (OS.HasFeature("arm64"))
					{
						if (Godot.FileAccess.FileExists(exepath + "/joy/.godot/mono/publish/arm64/joystick_cs.dll"))
						{
							System.Reflection.Assembly.LoadFile(exepath + "/joy/.godot/mono/publish/arm64/joystick_cs.dll");
						}

					}
					else
					{
						System.Reflection.Assembly.LoadFile(exepath + "/joy/.godot/mono/publish/x86_64/joystick_cs.dll");
					}
				}
				*/
			}
			else
			{
				byte[] assBytes;
				byte[] pdbBytes;
				if (!Define.IsEditor)
				{
					//Dictionary<string, Node> dictionary = AssetsBundleHelper.LoadBundle("code.unity3d");
					//	assBytes = ((TextAsset)dictionary["Model.dll"]).bytes;
					//	pdbBytes = ((TextAsset)dictionary["Model.pdb"]).bytes;

				}
				else
				{
					assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.dll"));
					pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, "Model.pdb"));
				}

				//this.model = Assembly.Load(assBytes, pdbBytes);
				this.LoadHotfix();
			}

			//IStaticMethod start = new StaticMethod(this.model, "ET.Entry", "Start");
			//start.Run();
			Entry.Init();

			Entry.Start();
		}

		// 热重载调用该方法
		public void LoadHotfix()
		{
			byte[] assBytes;
			byte[] pdbBytes;
			if (!Define.IsEditor)
			{
				//	Dictionary<string, Node> dictionary = AssetsBundleHelper.LoadBundle("code.unity3d");
				//assBytes = ((TextAsset)dictionary["Hotfix.dll"]).bytes;
				//pdbBytes = ((TextAsset)dictionary["Hotfix.pdb"]).bytes;
			}
			else
			{
				// 认为同一个路径的dll，返回的程序集就一样。所以这里每次编译都要随机名字
				string[] logicFiles = Directory.GetFiles(Define.BuildOutputDir, "Hotfix_*.dll");
				if (logicFiles.Length != 1)
				{
					throw new Exception("Logic dll count != 1");
				}
				string logicName = Path.GetFileNameWithoutExtension(logicFiles[0]);
				assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.dll"));
				pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.pdb"));
			}

			//Assembly hotfixAssembly = Assembly.Load(assBytes, pdbBytes);

			//Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(typeof (Game).Assembly, typeof(Init).Assembly, this.model, hotfixAssembly);

			//EventSystem.Instance.Add(types);
		}
	}
}