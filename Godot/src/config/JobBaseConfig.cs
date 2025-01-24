using Godot;
using System.Collections.Generic;


namespace ET {
public partial class JobBaseConfig : BaseConfig
{
    // 鬼剑士基础属性
    public JobBaseConfig()
    {
        LoadJson("res://assets/configs/JobBase.json");
    }

    public  Godot.Collections.Dictionary<string, Variant> GetData(string job)
    {
         Godot.Collections.Dictionary<string, Variant> jobData = null;

        for (int i = 0; i < data.Count; i++)
        {
            var entry = data[i] ;
            if (entry != null && entry["job"].ToString() == job)
            {
                jobData = entry;
                break;
            }
        }

        return jobData;
    }
}
}