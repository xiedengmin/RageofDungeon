using System;
using Godot;
//using Godot.Networking;

namespace ET
{
    public static class CoroutineHelper
    {
        // 有了这个方法，就可以直接await Godot的AsyncOperation了
      //  public static async ETTask GetAwaiter(this AsyncOperation asyncOperation)
     //  {
     //       ETTask task = ETTask.Create(true);
     //       asyncOperation.completed += _ => { task.SetResult(); };
    //        await task;
    //    }
        
      //  public static async ETTask<string> HttpGet(string link)
     //   {
         //   try
         //   {
                //GodotWebRequest req = GodotWebRequest.Get(link);
           //     await req.SendWebRequest();
           //     return req.downloadHandler.text;
        //    }
         //   catch (Exception e)
         //   {
         //       throw new Exception($"http request fail: {link.Substring(0,link.IndexOf('?'))}\n{e}");
       //     }
       // }
    }
}