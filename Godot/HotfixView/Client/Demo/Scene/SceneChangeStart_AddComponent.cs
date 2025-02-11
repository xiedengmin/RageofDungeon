using Godot;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_AddComponent : AEvent<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene1, EventType.SceneChangeStart args)
        {
            Scene currentScene = scene1.CurrentScene();
            string SceneName = currentScene.Name;
            if (SceneName.Contains("_"))
            {
                SceneName = SceneName.Replace("_", "/");
            }
            PackedScene res = GD.Load<PackedScene>($"res://Scenes/{SceneName}.tscn");
            //Node3D scene = res.Instantiate() as Node3D;
            Node2D scene = res.Instantiate() as Node2D;
            GlobalComponent.Instance.UnitRoot.AddChild(scene);
        }
    }
}
