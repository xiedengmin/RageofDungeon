using Godot;
using System.Collections.Generic;
using System.IO;
#if !GODOT
namespace ET
{
    public static class AssetsBundleHelper
    {
        public static Dictionary<string, Node> LoadBundle(string assetBundleName)
        {
            assetBundleName = assetBundleName.ToLower();

            Dictionary<string, Node> objects = new Dictionary<string, Node>();
            if (!Define.IsAsync)
            {
                if (Define.IsEditor)
                {
                    string[] realPath = null;
                    realPath = Define.GetAssetPathsFromAssetBundle(assetBundleName);
                    foreach (string s in realPath)
                    {
                        //string assetName = Path.GetFileNameWithoutExtension(s);
                        Node resource = Define.LoadAssetAtPath(s);
                        objects.Add(resource.name, resource);
                    }
                }
                return objects;
            }

            string p = Path.Combine(PathHelper.AppHotfixResPath, assetBundleName);
            GodotEngine.AssetBundle assetBundle = null;
            if (File.Exists(p))
            {
                assetBundle = GodotEngine.AssetBundle.LoadFromFile(p);
            }
            else
            {
                p = Path.Combine(PathHelper.AppResPath, assetBundleName);
                assetBundle = GodotEngine.AssetBundle.LoadFromFile(p);
            }

            if (assetBundle == null)
            {
                // 获取资源的时候会抛异常，这个地方不直接抛异常，因为有些地方需要Load之后判断是否Load成功
                GodotEngine.Debug.LogWarning($"assets bundle not found: {assetBundleName}");
                return objects;
            }

            Node[] assets = assetBundle.LoadAllAssets();
            foreach (Node asset in assets)
            {
                objects.Add(asset.name, asset);
            }
            assetBundle.Unload(false);
            return objects;
        }
    }
}
#endif