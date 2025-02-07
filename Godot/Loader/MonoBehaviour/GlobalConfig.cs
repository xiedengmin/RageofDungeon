using Godot;

namespace ET
{
    public enum CodeMode
    {
        Client = 1,
        Server = 2,
        ClientServer = 3,
    }
    
    /// <summary>
    /// [CreateAssetMenu(menuName = "ET/CreateGlobalConfig", fileName = "GlobalConfig", order = 0)]
    /// </summary>
    public class GlobalConfig
    {
        public CodeMode CodeMode;
    }
}