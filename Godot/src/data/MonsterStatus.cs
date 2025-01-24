using Godot;
using System.Collections.Generic;

namespace ET {
public partial class MonsterStatus : Node
{
    // 配置表ID
    public int ID { get; set; } = 1;

    // 头像
    public string Face { get; set; } = "";

    // 最大生命值
    public int MaxHp { get; set; } = 1;

    // 生命值
    public int HP { get; set; } = 0;

    // 等级
    public int LV { get; set; } = 1;

    // 物理攻击
    public int PhysicalAttack { get; set; } = 0;

    // 物理防御
    public int PhysicalDefense { get; set; } = 0;

    // 魔法攻击
    public int MagicalAttack { get; set; } = 0;

    // 魔法防御
    public int MagicalDefense { get; set; } = 0;

    // 类别
    public string Category { get; set; } = "";

    // 火炕
    public int FireResistance { get; set; } = 0;

    // 冰抗
    public int WaterResistance { get; set; } = 0;

    // 光抗
    public int LightResistance { get; set; } = 0;

    // 暗抗
    public int DarkResistance { get; set; } = 0;

    // 攻击速度
    public int AttackSpeed { get; set; } = 0;

    // 移动速度
    public int MoveSpeed { get; set; } = 0;

    // 施法速度
    public int CastSpeed { get; set; } = 0;

    // 硬直
    public int HitRecovery { get; set; } = 0;

    // 重量
    public int Weight { get; set; } = 0;

    // 视野范围
    public int Sight { get; set; } = 0;

    // 好战度
    public int Warlike { get; set; } = 0;

    // 攻击延迟
    public int AttackDelay { get; set; } = 0;

    // 掉落
    public Dictionary<string, string> Items { get; set; } = new Dictionary<string, string>();

    public override void _Ready()
    {
        HP = MaxHp;
    }

    public void InitData()
    {
        var config = ConfigManager.Instance.monsterConfig.GetConfig(ID);
        Face = config["face"].ToString();
        LV = (int)config["lvMin"];
        MaxHp = (int)config["hpMax"];
        HP = MaxHp;
        PhysicalAttack =(int) config["physicalAttack"];
        PhysicalDefense = (int)config["physicalDefense"];
        MagicalAttack = (int)config["magicalAttack"];
        MagicalDefense = (int)config["magicalDefense"];
        Category = config["category"].ToString();
        FireResistance = (int)config["fireResistance"];
        WaterResistance = (int)config["waterResistance"];
        LightResistance = (int)config["lightResistance"];
        DarkResistance = (int)config["darkResistance"];
        AttackSpeed = (int)config["attackSpeed"];
        MoveSpeed = (int)config["moveSpeed"];
        CastSpeed = (int)config["castSpeed"];
        HitRecovery = (int)config["hitRecovery"];
        Weight = (int)config["weight"];
        Sight = (int)config["sight"];
        Warlike = (int)config["warlike"];
        AttackDelay = (int)config["attackDelay"];

        Items.Clear();
        var temp1 = config["item"].ToString().Split('#');
        foreach (var t in temp1)
        {
            var temp2 = t.Split(':');
            Items[temp2[0]] = temp2[1];
        }
    }
}
}