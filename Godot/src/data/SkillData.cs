using Godot;
using System.Collections.Generic;

namespace ET {
public partial class SkillData : Node
{
    public  Godot.Collections.Array<Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>> data=new() ;

    public override void _Ready()
    {
        // 初始化数据
    }

    // 初始化show_lv
    public void InitData()
    {
        for (int i = 0; i < 5; i++)
        {
            Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>> list = data[i];
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] != null && list[j].ContainsKey("lv"))
                {
                    list[j]["show_lv"] = list[j]["lv"];
                }
            }
        }
    }

    // 获取技能信息
    public void GetSkill()
    {
        // 具体实现待补充
    }

    // 获取技能已学习等级
    public int GetSkillLv(int id)
    {
        int lv = 0;
        for (int i = 0; i < 5; i++)
        {
            Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>  list = data[i];
            foreach (var skl in list)
            {
                if (skl != null && skl.ContainsKey("id") && (int)skl["id"] == id)
                {
                    lv = (int)skl["lv"];
                    break;
                }
            }
        }
        return lv;
    }
}
}