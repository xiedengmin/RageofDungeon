using Godot;
using System;
using System.Collections.Generic;

public partial class Utils : Node
{
    public override void _Ready()
    {
    }

    // 双击判断
    public static bool DoubleClick(InputEvent _event, float _delta)
    {
        bool value = false;
        return value;
    }

    // 获取城镇的cutscene
    public static string GetTownCutscene()
    {
        string cut = "";
        cut = "res://assets/images/map/cutscene/" + GlobalManager.Instance.state.target + ".png";
        return cut;
    }

    // 获取地下城的cutscene
    public static string GetDungeonCutscene()
    {
        string cut = "";
        switch (GlobalManager.Instance.selectDungeon)
        {
            case "Lorien":
                cut = "res://assets/images/map/cutscene/lorien.png";
                break;
            case "LorienInside":
                cut = "res://assets/images/map/cutscene/lorien.png";
                break;
        }
        return cut;
    }

    // 获取城镇的title
    public static string GetTownTitle()
    {
        string title = "";
        title = "res://assets/images/map/title/" + GlobalManager.Instance.state.target + ".png";
        return title;
    }

    // 获取地下城标题资源
    public static string GetDungeonTitle()
    {
        string sname = "";
        switch (GlobalManager.Instance.selectDungeon)
        {
            case "Lorien":
                sname = "res://assets/tres/dungeon_title/lorien.tres";
                break;
            case "LorienInside":
                sname = "res://assets/tres/dungeon_title/lorieninside.tres";
                break;
        }
        return sname;
    }

    // 获取字符串的字符长度
    public static int GetStringLength(string nameStr)
    {
        int length = 0;
        for (int i = 0; i < nameStr.Length; i++)
        {
            int charLen = nameStr[i];
            if (charLen > 127)
            {
                length += 2;
            }
            else
            {
                length += 1;
            }
        }
        return length;
    }

    // 根据职业获取职业中文名
    public static string GetExByJob(string job)
    {
        string jobZh = "";
        switch (job)
        {
            case GLOBALS_TYPE.SWORDMAN:
                jobZh = "鬼剑士";
                break;
            case GLOBALS_TYPE.FIGHTER:
                jobZh = "格斗家";
                break;
            case GLOBALS_TYPE.GUNNER:
                jobZh = "神枪手";
                break;
            case GLOBALS_TYPE.MAGE:
                jobZh = "魔法师";
                break;
            case GLOBALS_TYPE.PRIEST:
                jobZh = "圣职者";
                break;
            case GLOBALS_TYPE.BLADEMASTER:
                jobZh = "剑魂";
                break;
            case GLOBALS_TYPE.SOULBENDER:
                jobZh = "鬼泣";
                break;
            case GLOBALS_TYPE.BERSERKER:
                jobZh = "狂战士";
                break;
            case GLOBALS_TYPE.ASURA:
                jobZh = "阿修罗";
                break;
        }
        return jobZh;
    }

    // 返回职业类型 int
    public static int GetIndexByJob(string job)
    {
        int index = 0;
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

    // 如果小于标准则返回标准
    public static float LessCheck(float value, float standard)
    {
        float back;
        if (value < standard)
        {
            back = standard;
        }
        else
        {
            back = value;
        }
        return back;
    }

    // 返回这个技能该职业的等级学习上限
    public static int GetSkillMaxLv( Godot.Collections.Array<Variant> gml)
    {
        int jobIndex = GetIndexByJob(DataManager.Instance.roleData.job);
        return (int)gml[jobIndex];
    }
}