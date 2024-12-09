using Godot;
using System.Collections.Generic;


public partial class MonsterConfig : BaseConfig
{
    public MonsterConfig()
    {
        LoadJson("res://assets/configs/Monster.json");
    }

    // 获取配置表
    public  Godot.Collections.Dictionary<string, Variant> GetConfig(int id)
    {
        Godot.Collections.Dictionary<string, Variant> config = new ();

        foreach (var c in data)
        {
            if ((int)c["ID"] == id)
           {
                config = c;
               break;
            }
        }

        return config;
    }
}