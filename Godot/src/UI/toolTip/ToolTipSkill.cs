using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ET {
public partial class ToolTipSkill : Control
{
    [Export] private Label nameLabel;
    [Export] private Label name2Label;
    [Export] private Label mpLabel;
    [Export] private Label castTime;
    [Export] private Label coolTime;
    [Export] private Label consume;
    [Export] private Label operate;
    [Export] private Label levelProperty;
    [Export] private Label explain;
    [Export] private Label lockTip;

    private Vector2 offsetPos = Vector2.Zero;
    private int id;
    private int lv;

    public override void _Ready()
    {
        // Initialize references to UI elements
        nameLabel = GetNode<Label>("panel/MarginContainer/VBoxContainer/NameLabel");
        name2Label = GetNode<Label>("panel/MarginContainer/VBoxContainer/Name2Label");
        mpLabel = GetNode<Label>("panel/MarginContainer/VBoxContainer/MPLabel");
        castTime = GetNode<Label>("panel/MarginContainer/VBoxContainer/HBoxContainer/CastTime");
        coolTime = GetNode<Label>("panel/MarginContainer/VBoxContainer/HBoxContainer/CoolTime");
        consume = GetNode<Label>("panel/MarginContainer/VBoxContainer/Consume");
        operate = GetNode<Label>("panel/MarginContainer/VBoxContainer/Operate");
        levelProperty = GetNode<Label>("panel/MarginContainer/VBoxContainer/LevelProperty");
        explain = GetNode<Label>("panel/MarginContainer/VBoxContainer/Explain");
        lockTip = GetNode<Label>("panel/MarginContainer/VBoxContainer/LockTip");
    }

    public void InitData()
    {
        var skl = ConfigManager.Instance.skillConfigProxy.GetSklByID(DataManager.Instance.roleData.jobBase, id);
        nameLabel.Text = skl.name + " Lv " + lv.ToString();
        name2Label.Text = skl.name2;

        if (!string.IsNullOrEmpty(skl.consumeMP.ToString()))
        {
            int mp = (int)CalDiff(skl.consumeMP, skl.maximumLevel);
            mpLabel.Text = $"MP {mp}";
        }
        else
        {
            mpLabel.Text = "";
        }

        if (skl.type == "passive")
        {
            castTime.Text = "施放方式：被动";
            coolTime.Text = "";
        }
        else
        {
            if (!string.IsNullOrEmpty(skl.castingTime.ToString()))
            {
                float cast = CalDiff(skl.castingTime, skl.maximumLevel) / 1000;
                castTime.Text = $"施放时间：{cast:F1}秒";
            }
            else
            {
                castTime.Text = "瞬发";
            }

            if (!string.IsNullOrEmpty(skl.coolTime.ToString()))
            {
                float cool = CalDiff(skl.coolTime, skl.maximumLevel) / 1000;
                coolTime.Text = $"冷却时间:{cool:F1}秒";
            }
            else
            {
                coolTime.Text = "";
            }
        }

        if (skl.consumeItem < 0)
        {
            consume.Text = $"[无色小晶块]{skl.consumeItem}个";
            consume.Visible = true;
        }
        else
        {
            consume.Visible = false;
        }

        if (skl.commandKeyExplain.Length > 0)
        {
            operate.Text = skl.commandKeyExplain;
            operate.Visible = true;
        }
        else
        {
            operate.Visible = false;
        }
       //技能伤害属性
        if (skl.levelProperty.Length > 0)
        {
           Godot.Collections.Array values = new ();
            foreach (var arr in skl.levelPropertyValue)
            {
               if (arr[0] < 0)
                {
                    var info = skl.levelInfo[lv - 1];
                    values.Add((float)info[(int)arr[1]] * arr[2]);
                }
               else
                {
                    if (skl.ID == 1001)
                    {
                        values.Add(skl.staticData[1]);
                    }
                }
            }
            levelProperty.Text = string.Format(skl.levelProperty, values.ToArray());
            levelProperty.Visible = true;
           GetNode<HSeparator>("panel/MarginContainer/VBoxContainer/HSeparator2").Visible = true;
        }
        else
        {
            levelProperty.Visible = false;
            GetNode<HSeparator>("panel/MarginContainer/VBoxContainer/HSeparator2").Visible = false;
        }

        explain.Text = skl.explain;
        
    }

     float CalDiff( Godot.Collections.Array<Variant> data, int max_lv)
    {
        int baseValue =(int) data[0];
        float lv_use = 0;

        if ((int)data[0] !=(int) data[1])
        {
            int diff =(int) data[1] - (int)data[0];
            lv_use = Mathf.Round((diff / (float)max_lv) * lv);
        }

        return baseValue + lv_use;
    }

     void _on_LockTip_draw()
    {
        // Replace with function body
        Size = new Vector2(Size.X, lockTip.Position.Y + lockTip.Size.Y + 12);

        Vector2 mouse_pos = GetGlobalMousePosition();
        Vector2 pos = new Vector2(Utils.LessCheck(mouse_pos.X - Size.X - offsetPos.X, 0),
                                  Utils.LessCheck(mouse_pos.Y - Size.Y - offsetPos.Y, 0));
        Position = pos;
    }
}

}