using Godot;
using System;
using System.Collections.Generic;

namespace ET {
public partial class ExptableConfig : BaseConfig
{
    private static Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>> data;

    public ExptableConfig()
    {
        LoadJson("res://assets/configs/Exptable.json");
        data = base.data;
    }

    // 根据等级获取经验值
    public int GetExp(int lv)
    {
        int expe = 0;

        for (int i = 0; i < data.Count; i++)
        {
            var temp = data[i];
            var comp=(int)temp["lv"];
            if (comp == lv)
            {
                expe =(int) temp["expe"];
                break;
            }
        }

        return expe;
    }

    
}
}