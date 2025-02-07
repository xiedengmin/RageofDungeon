namespace ET
{
    // mono层调用一下，让Godot引用相应的dll，否则热更层无法使用
    public static class AssemblyReference
    {
        public static void Run()
        {
            using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        }
    }
}
