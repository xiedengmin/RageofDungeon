using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

namespace ET {
public partial class RoleData : Node
{
    // Signals
    // [Signal]
    // public delegate void HpChange();
    // [Signal]
    // public delegate void MpChange();

    // Fields
    public string name = "";
    public string jobBase = "";
    public string job = "";
    public int aweek = 0;
    public int gold = 0;
    public int lv = 1;
    public int expe = 0;
    public int maxExpe = 0;
    public int sp = 0;
    public int maxHp = 0;
    private int _hp;
    public int Hp
    {
        get => _hp;
        set => SetHp(value);
    }
    public int maxMp = 0;
    public int mp = 0;
    public int inventoryLimit = 0;
    public int weight = 0;
    public int STR = 0;
    public int WIS = 0;
    public int VIT = 0;
    public int MND = 0;
    public int physicalAttack = 0;
    public int magicalAttack = 0;
    public int physicalDefense = 0;
    public int magicalDefense = 0;
    public float physicalCritical = 0f;
    public float magicalCritical = 0f;
    public float attackSpeed = 0f;
    public float castSpeed = 0f;
    public float moveSpeed = 0f;
    public float stuck = 0f;
    public float stuckResistance = 0f;
    public int hpRegenSpeed = 0;
    public int mpRegenSpeed = 0;
    public int immobility = 0;
    public int hitRecovery = 0;
    public int attackType = 0;
    public int fireAttack = 0;
    public int waterAttack = 0;
    public int lightAttack = 0;
    public int darkAttack = 0;
    public int fireResistance = 0;
    public int waterResistance = 0;
    public int lightResistance = 0;
    public int darkResistance = 0;
    public int blindResistance = 0;
    public int lightningResistance = 0;
    public int freezeResistance = 0;
    public int holdResistance = 0;
    public int sleepResistance = 0;
    public int bleedingResistance = 0;
    public int confuseResistance = 0;
    public int curseResistance = 0;
    public int stoneResistance = 0;

    public override void _Ready()
    {
        // Initialization logic
    }

    public void InitData()
    {
        lv = 10;
        sp = 100;
        maxExpe = ConfigManager.Instance.exptableConfig.GetExp(lv);

        // Load base data
        Godot.Collections.Dictionary<string, Variant> baseData = ConfigManager.Instance.jobBaseConfig.GetData(jobBase);
        maxHp = (int)baseData["HP_MAX"];
        Hp = maxHp;
        maxMp = (int)baseData["MP_MAX"];
        mp = maxMp;
        STR = (int)baseData["physical_attack"];
        VIT = (int)baseData["physical_defense"];
        WIS = (int)baseData["magical_attack"];
        MND = (int)baseData["magical_defense"];
        lightResistance = (int)baseData["light_resistance"];
        darkResistance = (int)baseData["dark_resistance"];
        inventoryLimit = (int)baseData["inventory_limit"];
        mpRegenSpeed = (int)baseData["mp_regen_speed"];
        hitRecovery = (int)baseData["hit_recovery"];
        weight = (int)baseData["weight"];

        // Load job data
         Godot.Collections.Dictionary<string, Variant>  up = ConfigManager.Instance.jobUpConfig.GetJobData(job);
        maxHp += (int)up["HP_MAX"] * lv;
        Hp = maxHp;
        maxMp += (int)up["MP_MAX"] * lv;
        mp = maxMp;
        STR += (int)Math.Round((float)up["physical_attack"] * lv);
        VIT += (int)Math.Round((float)up["physical_defense"] * lv);
        WIS += (int)Math.Round((float)up["magical_attack"] * lv);
        MND += (int)Math.Round((float)up["magical_defense"] * lv);
        inventoryLimit += (int)up["inventory_limit"] * lv;
        mpRegenSpeed += (int)up["mp_regen_speed"] * lv;
        hitRecovery += (int)up["hit_recovery"] * lv;
    }

    private void SetHp(int value)
    {
        _hp = value;
    }
}

}