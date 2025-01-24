using Godot;
using System;

namespace ET {
public partial class DataManager : Node
{
    // 人物数据
    public  RoleData roleData;
    // 技能数据
    public  SkillData skillData;
    // 装备数据
    public EquipData equipData;
    // 背包数据
    public InventoryData invData;
    // 仓库数据
    public StorateData storateData;
    // 快捷栏道具
    public InvShortcutData invShortcutData;
    // 快捷栏技能数据
    public SkillShortcutData skillShortcutData;
    public static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
    }
    public override void _Ready()
    {
        if (_instance == null)
        {
            _instance = new DataManager();
        }
        _instance.roleData = new RoleData();
        _instance.skillData = new SkillData();
        _instance.equipData = new EquipData();
        _instance.invData = new InventoryData();
        _instance.storateData = new StorateData();
        _instance.invShortcutData = new InvShortcutData();
        _instance.skillShortcutData = new SkillShortcutData();
    }

    public void InitData()
    {
        _instance.roleData.InitData();
        _instance.skillData.InitData();
        _instance.skillShortcutData.InitData();
    }

    // 获取技能等级
    public int GetSkillLv(Variant id)
    {
        int lv = 0;
        int sklLv = skillData.GetSkillLv((int)id);
        int shortLv = skillShortcutData.GetSkillLv((int)id);

        if (sklLv != 0 || shortLv != 0)
        {
            lv = Math.Max(sklLv, shortLv);
        }

        return lv;
    }
}
}