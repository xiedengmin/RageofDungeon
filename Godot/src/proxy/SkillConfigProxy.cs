using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using static Godot.HttpRequest;
public partial class SkillConfigProxy : BaseConfig
{
    // 鬼剑士技能
    private List<SkillConfig> sm_skl = new List<SkillConfig>();

    public SkillConfigProxy()
    {
        LoadJson("res://assets/configs/SwordmanSkill.json");
        InitSkl(GLOBALS_TYPE.SWORDMAN);
    }

    // 初始化技能
    private void InitSkl(string job)
    {
        List<SkillConfig> arr = new List<SkillConfig>();

        for (int i = 0; i < data.Count; i++)
        {
             Godot.Collections.Dictionary<string,Variant> dic = data[i];
            SkillConfig skl = new SkillConfig();
            skl.ID = (int)dic["ID"];
            skl.name = (string)dic["name"];
            skl.name2 = (string)dic["name2"];
            skl.explain = (string)dic["explain"];
            skl.purchaseCost = (int)dic["purchase_cost"];
            skl.steelLearningSkill = (int)dic["steel_learning_skill"];
            skl.requiredLevel = (int)dic["required_level"];
            skl.requiredLevelRange =(int)dic["required_level_range"];
           var  preReqSkill = dic["pre_required_skill"];
            if (preReqSkill.Obj is string)
            {
                var preRequiredSkill = preReqSkill.Obj.ToString().Split("<A>");
              foreach (string s in preRequiredSkill)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.preRequiredSkill.Add(s);
                    }
                }
        
            }
          

            skl.type = (string)dic["type"];
            skl.skillClass = (int)dic["skill_class"];
            skl.maximumLevel = (int)dic["maximum_level"];
             skl.growtypeMaximumLevel.Add((dic["growtype_maximum_level"]).ToString().Split("<A>"));
            skl.skillFitnessGrowtype = (int)dic["skill_fitness_growtype"];
            skl.skillFitnessSecondGrowtype = (int)dic["skill_fitness_second_growtype"];
            skl.durabilityDecreaseRate = (int)dic["durability_decrease_rate"];

            if (dic["weapon_effect_type"].Obj is string) //weaponEffectType
                skl.weaponEffectType = dic["weapon_effect_type"].Obj.ToString();

            if (dic["shake_screen"].Obj is string )
                skl.shakeScreen = dic["shake_screen"].Obj.ToString();

            skl.icon = (string)dic["icon"];
            skl.command = (string)dic["command"];

           if (dic["skill_command_advantage"].Obj is string )
            {
            var skill_command_advantage = (dic["skill_command_advantage"].Obj.ToString().Split("<A>"));
                foreach (string s in skill_command_advantage)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.skillCommandAdvantage.Add(s);
                    }
                }
            }


            if (dic["consume_MP"].Obj is string)
            {
               var consume_MP = (dic["consume_MP"].Obj.ToString().Split("<A>"));
                foreach (string s in consume_MP)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.consumeMP.Add(s);
                    }
                }
            }
         

           if (dic["casting_time"].Obj is string)
            {
                var casting_time = (dic["casting_time"].Obj.ToString().Split("<A>"));
                foreach (string s in casting_time)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.castingTime.Add(s);
                    }
                }
            }
            

            if (dic["cool_time"].Obj is string)
            {
                var cool_time = (dic["cool_time"].Obj.ToString().Split("<A>"));
                foreach (string s in cool_time)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.coolTime.Add(s);
                    }
                }
            }
    

            if (dic["static_data"].Obj is string)
            {
                var static_data = (dic["static_data"].Obj.ToString().Split("<A>"));
                foreach (string s in static_data)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        skl.staticData.Add(s);
                    }
                }
            }
       
            if (dic["level_info"].Obj is string )
            {

                List<string> templist = new List<string>(dic["level_info"].Obj.ToString().Split("<A>"));
                int length = int.Parse(templist[0]);
                templist.RemoveAt(0);
                Array< Godot.Collections.Array<Variant>> list = new();

                for (int j = 0; j < templist.Count; j += length)
                {
                     Godot.Collections.Array<Variant> item = new  ();
                    for (int k = 0; k < length; k++)
                    {
                        item.Add((templist[j + k]));
                    }
                    list.Add(item);
                } 
                  skl.levelInfo = list;
            }

            if (dic["command_key_explain"].Obj is string )
                skl.commandKeyExplain = dic["command_key_explain"].Obj.ToString();

            if (dic["level_property"].Obj is string )
            {
                try
                {
                    List<string> p_temp = new List<string>(dic["level_property"].Obj.ToString().Split("<A>"));
                    skl.levelProperty = p_temp[0].Replace("<N>", "\n");
                    p_temp.RemoveAt(0);
                    Array<Array<float>> list = new();

                    for (int j = 0; j < p_temp.Count; j += 3)
                    {
                        Array<float> item = new();
                        for (int k = 0; k < 3; k++)
                        {
                            float result;
                            if (float.TryParse(p_temp[j + k], out result))
                            {
                                // 转换成功，可以使用result变量
                                item.Add(result);
                            }
                            else
                            {
                                item.Add(0); // 转换失败
                            }
                         
                        }
                        list.Add(item);
                    }
                    skl.levelPropertyValue = list;
                }
                catch (Exception ex)
                {
                    GD.Print(ex);
                }
            }

            skl.consumeItem = (int)dic["consume_item"];

            if (dic["skill_preloading_image"].Obj is string )
                skl.skillPreloadingImage = dic["skill_preloading_image"].Obj.ToString();

            arr.Add(skl); 
        }
         
        switch (job)
        {
            case GLOBALS_TYPE.SWORDMAN:
                sm_skl = arr;
                break;
            case GLOBALS_TYPE.FIGHTER:
            case GLOBALS_TYPE.GUNNER:
            case GLOBALS_TYPE.MAGE:
            case GLOBALS_TYPE.PRIEST:
                break;
         
        } 
    }

    // 获取技能列表
    public List<SkillConfig> GetSlkList(string jobBase, string job)
    {
        List<SkillConfig> list = GetListByJob(jobBase);
        List<SkillConfig> arr = new List<SkillConfig>();

        foreach (var skl in list)
        {
            if (skl.skillFitnessGrowtype == 1234)
                arr.Add(skl);
        }

        int jobIndex = GetJobIndex(job);
        if (jobIndex > -1)
        {
            foreach (var skl in list)
            {
                if (skl.skillFitnessGrowtype == jobIndex)
                    arr.Add(skl);
            }
        }
         
        return arr;
    }

    // 根据类型获取技能列表
    public void GetSklByType() { }

    // 根据ID获取技能数据
    public SkillConfig GetSklByID(string job, int id)
    {
        SkillConfig skl = null;
        List<SkillConfig> arr = GetListByJob(job);
        foreach (var sk in arr)
        {
            if (sk.ID == id)
            {
                skl = sk;
                break;
            }
        }
        return skl;
    }

    // 技能的class分类
    public int GetClassByID(string job, int id)
    {
        int c = 0;
        List<SkillConfig> arr = GetListByJob(job);
        foreach (var sk in arr)
        {
            if (sk.ID == id)
            {
                c = sk.skillClass;
                break;
            }
        }
        return c;
    }

    // 技能的图标资源
    public string GetIconByID(string job, int id)
    {
        string icon = "";
        List<SkillConfig> arr = GetListByJob(job);
        foreach (var sk in arr)
        {
            if (sk.ID == id)
            {
                icon = sk.icon;
                break;
            }
        }
        return icon;
    }

    // 根据职业获取技能列表
    private List<SkillConfig> GetListByJob(string job)
    {
        List<SkillConfig> arr = null;
        switch (job)
        {
            case GLOBALS_TYPE.SWORDMAN:
                arr = sm_skl;
                break;
            case GLOBALS_TYPE.FIGHTER:
            case GLOBALS_TYPE.GUNNER:
            case GLOBALS_TYPE.MAGE:
            case GLOBALS_TYPE.PRIEST:
                break;
        }
        return arr;
    }

    // 返回职业index
    private int GetJobIndex(string job)
    {
        int index = -1;
        switch (job)
        {
            case GLOBALS_TYPE.BLADEMASTER:
                index = 1;
                break;
            case GLOBALS_TYPE.SOULBENDER:
                index = 2;
                break;
            case GLOBALS_TYPE.BERSERKER:
                index = 3;
                break;
            case GLOBALS_TYPE.ASURA:
                index = 4;
                break;
        }
        return index;
    }
}
