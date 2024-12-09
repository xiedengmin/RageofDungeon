using Godot;
using System.Collections.Generic;

public partial class SkillShortcutData : Node
{
    public  Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>> data = new ();

    public SkillShortcutData()
    {
        // 初始化数据，可以根据需要调整大小
        // data.Capacity = 12;
    }

    // 根据数据计算 show_lv
    public void InitData()
    {
        // 根据数据计算 show_lv
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].Count>0)
            {
               data[i]["show_lv"] = data[i]["lv"];
            }
        }
    }

    // 获取技能已学习等级
    public int GetSkillLv(int id)
    {
        int lv = 0;
        foreach (var skl in data)
        {
            if (skl != null && (int)skl["id"] == id)
            {
                lv =(int) skl["lv"];
                break;
            }
        }
        return lv;
    }
}