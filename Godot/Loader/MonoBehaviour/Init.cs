using System;
using System.Threading;
using CommandLine;
using Godot;

namespace ET
{
    public partial class Init : Node
    {
        public Node node { get; set; }
        public static Init Instance;
        public InputEvent InputEvent;

        public override void _Ready()
        {
            this.node = this;
            Instance = this;
#if ENABLE_IL2CPP
			this.CodeMode = CodeMode.ILRuntime;
#endif
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error(e.ExceptionObject.ToString());
            };

            Game.AddSingleton<MainThreadSynchronizationContext>();

            // 命令行参数
            string[] args = "".Split(" ");
            Parser.Default.ParseArguments<Options>(args)
                .WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
                .WithParsed(Game.AddSingleton);

            Game.AddSingleton<TimeInfo>();
            Game.AddSingleton<Logger>().ILog = new GodotLogger();
            Game.AddSingleton<ObjectPool>();
            Game.AddSingleton<IdGenerater>();
            Game.AddSingleton<EventSystem>();
            Game.AddSingleton<TimerComponent>();
            Game.AddSingleton<CoroutineLockComponent>();

            ETTask.ExceptionHandler += Log.Error;
            Game.AddSingleton<CodeLoader>().Start();
            //  Game.EventSystem.Publish(new ET.EventType.AppStart());
        }

        public override void _Process(double delta)
        {

            Game.Update();
            Game.LateUpdate();

        }
        public override void _PhysicsProcess(double delta)

        {
            Game.FrameFinishUpdate();
        }
        private void OnApplicationQuit()
        {
            Game.Close();
        }


        public override void _Input(InputEvent inputEvent)
        {
            InputEvent = inputEvent;
            //Vector2 pos = GetViewport().GetMousePosition();
            //GetViewport().GetScreenTransform().
            //Camera3D camera = GetViewport().GetCamera3D();

            //Vector3 worldPos = camera.ProjectRayOrigin(pos) + camera.ProjectRayNormal(pos) * camera.GetZfar();
            //Vector3 ray = camera.ProjectRayNormal(pos) * (worldPos - camera.ProjectRayOrigin(pos)).Length();
            //var intersection = camera.GlobalTransform.IntersectsRay(camera.GlobalPosition, ray);

            //if (intersection != null)
            //{
            //	Vector3 intersectionPoint = intersection.Value.Position;
            //	GD.Print(intersectionPoint);
            //}
        }


    }
}