using Godot;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class EquipConfigProxy : BaseConfig
{
    // 装备列表
    private List<EquipConfig> list = new List<EquipConfig>();

    public EquipConfigProxy()
    {
        LoadJson("res://assets/configs/Equipment.json");
        InitData();
    }

    private void InitData()
    {
        foreach (var dic in data)
        {
            EquipConfig equ = new EquipConfig();
            equ.ID =(int) dic["ID"];
            equ.Name = dic["name"].ToString();
            equ.Name2 = dic["name2"].ToString();
            equ.ItemType =(int)dic["item_type"];
            equ.EquipmentSlot = dic["equipment_slot"].ToString();
            equ.EquipmentPhysicalAttack = (int)dic["equipment_physical_attack"];
            equ.EquipmentMagicalAttack = (int)dic["equipment_magical_attack"];
            equ.EquipmentPhysicalDefense = (int)dic["equipment_physical_defense"];
            equ.EquipmentMagicalDefense = (int)dic["equipment_magical_defense"];
            equ.SubType = (int)dic["sub_type"];
            equ.Icon = dic["icon"].ToString();
            equ.MoveWav = dic["move_wav"].ToString();
            list.Add(equ);
        }
    }

    // 获取装备图标
    public string GetItemIcon(int id)
    {
        string icon = "";
        foreach (var item in list)
        {
            if (item.ID == id)
            {
                icon = item.Icon;
                break;
            }
        }
        return icon;
    }

    // 获取装备插槽
    public string GetItemEquipmentSlot(int id)
    {
        string slot = "";
        foreach (var item in list)
        {
            if (item.ID == id)
            {
                slot = item.EquipmentSlot;
                break;
            }
        }
        return slot;
    }

    // 获取装备栏类型
    public int GetItemType(int id)
    {
        int item_type = 0;
        foreach (var item in list)
        {
            if (item.ID == id)
            {
                item_type = item.ItemType;
                break;
            }
        }
        return item_type;
    }
}
