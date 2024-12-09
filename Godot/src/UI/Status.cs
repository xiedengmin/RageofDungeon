using Godot;

public partial class Status : Control
{
    // UI elements
    Button roleBtn;
    Label hp;
    Label mp;
    Label STR;
    Label WIS;
    Label VIT;
    Label MND;
    Label physical_attack;
    Label magical_attack;
    Label physical_defense;
    Label magical_defense;
    Label physical_critical;
    Label magical_critical;
    Label attack_speed;
    Label cast_speed;
    Label move_speed;
    Label stuck;
    Label stuck_resistance;
    Label hp_regen_speed;
    Label mp_regen_speed;
    Label immobility;
    Label hit_recovery;
    Label fire_attack;
    Label fire_resistance;
    Label water_attack;
    Label water_resistance;
    Label light_attack;
    Label light_resistance;
    Label dark_attack;
    Label dark_resistance;

    public override void _Ready()
    {
        // Initialize UI elements
        roleBtn = GetNode<Button>("roleBtn");
        hp = GetNode<Label>("ScrollContainer/Control/hpItem/valueLabel");
        mp = GetNode<Label>("ScrollContainer/Control/mpItem/valueLabel");
        STR = GetNode<Label>("ScrollContainer/Control/STRItem/valueLabel");
        WIS = GetNode<Label>("ScrollContainer/Control/WISItem/valueLabel");
        VIT = GetNode<Label>("ScrollContainer/Control/VITItem/valueLabel");
        MND = GetNode<Label>("ScrollContainer/Control/MNDItem/valueLabel");
        physical_attack = GetNode<Label>("ScrollContainer/Control/physical_attackItem/valueLabel");
        magical_attack = GetNode<Label>("ScrollContainer/Control/magical_attackItem/valueLabel");
        physical_defense = GetNode<Label>("ScrollContainer/Control/physical_defenseItem/valueLabel");
        magical_defense = GetNode<Label>("ScrollContainer/Control/magical_defenseItem/valueLabel");
        physical_critical = GetNode<Label>("ScrollContainer/Control/physical_criticalItem/valueLabel");
        magical_critical = GetNode<Label>("ScrollContainer/Control/magical_criticalItem/valueLabel");
        attack_speed = GetNode<Label>("ScrollContainer/Control/attack_speedItem/valueLabel");
        cast_speed = GetNode<Label>("ScrollContainer/Control/cast_speedItem/valueLabel");
        move_speed = GetNode<Label>("ScrollContainer/Control/move_speedItem/valueLabel");
        stuck = GetNode<Label>("ScrollContainer/Control/stuckItem/valueLabel");
        stuck_resistance = GetNode<Label>("ScrollContainer/Control/stuck_resistanceItem/valueLabel");
        hp_regen_speed = GetNode<Label>("ScrollContainer/Control/hp_regen_speedItem/valueLabel");
        mp_regen_speed = GetNode<Label>("ScrollContainer/Control/mp_regen_speedItem/valueLabel");
        immobility = GetNode<Label>("ScrollContainer/Control/immobilityItem/valueLabel");
        hit_recovery = GetNode<Label>("ScrollContainer/Control/hit_recoveryItem/valueLabel");
        fire_attack = GetNode<Label>("ScrollContainer/Control/fire_attackItem/valueLabel");
        fire_resistance = GetNode<Label>("ScrollContainer/Control/fire_resistanceItem/valueLabel");
        water_attack = GetNode<Label>("ScrollContainer/Control/water_attackItem/valueLabel");
        water_resistance = GetNode<Label>("ScrollContainer/Control/water_resistanceItem/valueLabel");
        light_attack = GetNode<Label>("ScrollContainer/Control/light_attackItem/valueLabel");
        light_resistance = GetNode<Label>("ScrollContainer/Control/light_resistanceItem/valueLabel");
        dark_attack = GetNode<Label>("ScrollContainer/Control/dark_attackItem/valueLabel");
        dark_resistance = GetNode<Label>("ScrollContainer/Control/dark_resistanceItem/valueLabel");

        roleBtn.ButtonPressed = true;
        InitStatus();
    }

    private void InitStatus()
    {
        var role = DataManager.Instance.roleData;

        hp.Text = $"{role.Hp}/{role.maxHp}";
        mp.Text = $"{role.mp}/{role.maxMp}";
        STR.Text = "▲▼ ↑↓😀😀😀" + role.STR.ToString();
        WIS.Text = "△" + role.WIS.ToString();
        VIT.Text = role.VIT.ToString();
        MND.Text = role.MND.ToString();
        physical_attack.Text = role.physicalAttack.ToString();
        magical_attack.Text = role.magicalAttack.ToString();
        physical_defense.Text = role.physicalDefense.ToString();
        magical_defense.Text = role.magicalDefense.ToString();
        physical_critical.Text = $"{role.physicalCritical:F1}%";
        magical_critical.Text = $"{role.magicalCritical:F1}%";
        attack_speed.Text = $"{role.attackSpeed:F1}%";
        cast_speed.Text = $"{role.castSpeed:F1}%";
        move_speed.Text = $"{role.moveSpeed:F1}%";
        stuck.Text = $"{role.stuck:F1}%";
        stuck_resistance.Text = $"{role.stuckResistance:F1}%";
        hp_regen_speed.Text = role.hpRegenSpeed.ToString();
        mp_regen_speed.Text = role.mpRegenSpeed.ToString();
        immobility.Text = role.immobility.ToString();
        hit_recovery.Text = role.hitRecovery.ToString();
        fire_attack.Text = role.fireAttack.ToString();
        fire_resistance.Text = role.fireResistance.ToString();
        water_attack.Text = role.waterAttack.ToString();
        water_resistance.Text = role.waterResistance.ToString();
        light_attack.Text = role.lightAttack.ToString();
        light_resistance.Text = role.lightningResistance.ToString();
        dark_attack.Text = role.darkAttack.ToString();
        dark_resistance.Text = role.darkResistance.ToString();
    }

    private void OnCloseBtnPressed()
    {
        GlobalManager.Instance.main.OnOpenStatus();
    }

    private void OnStatusVisibilityChanged()
    {
        GetNode<AudioStreamPlayer>("windowSound").Play();
    }
}