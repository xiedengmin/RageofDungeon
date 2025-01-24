using Godot;
using System.Collections.Generic;

namespace ET {
public partial class SkillShortcutSlot : TextureRect
{
    [Export] private TextureRect icon;
    [Export] private TextureRect select;
    [Export] private Label lv;
    [Export] private TextureRect static_lv;

    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
        select = GetNode<TextureRect>("select");
        lv = GetNode<Label>("lv");
        static_lv = GetNode<TextureRect>("static_lv");
    }

    public override  Variant _GetDragData(Vector2 position)
    {
        var skillData = DataManager.Instance.skillShortcutData.data[GetIndex()];
        if (skillData != null)
        {
            var data = new  Godot.Collections.Dictionary<string, Variant>
            {
                { "origin_node", icon },
                { "origin_panel", "SkillShortcut" },
                { "origin_item_id", skillData },
                { "origin_skill_class", ConfigManager.Instance.skillConfigProxy.GetClassByID(DataManager.Instance.roleData.job, (int) skillData["id"]) },
                { "origin_texture", icon.Texture }
            };

            var dragTexture = new TextureRect
            {
             //err   Expand = true,
                Texture = icon.Texture,
                Size = new Vector2(28, 28)
            };

            var control = new Control();
            control.AddChild(dragTexture);
            dragTexture.Position = -0.5f * dragTexture.Size;
            SetDragPreview(control);

            return data;
        }
        return 0;
    }

    public override bool _CanDropData(Vector2 pos, Variant dataObj)
    {
        var data = (Godot.Collections.Dictionary<string, Variant>)dataObj;
        if (!data["origin_panel"].ToString().Equals("SkillInventory") && !data["origin_panel"].ToString().Equals("SkillShortcut"))
        {
            return false;
        }

        var targetInvIndex = GetIndex();
        if (DataManager.Instance.skillShortcutData.data[targetInvIndex] == null)
        {
            data["target_item_id"] = 0;
            data["target_texture"] = 0;
            return true;
        }
        else
        {
            var skl = DataManager.Instance.skillShortcutData.data[targetInvIndex];
            data["target_item_id"] = skl;
            data["target_texture"] = icon.Texture;

            if (data["origin_panel"].ToString().Equals("SkillInventory"))
            {
               var targetSkillClass = ConfigManager.Instance.skillConfigProxy.GetClassByID(DataManager.Instance.roleData.job, (int)skl["id"]);
               if (targetSkillClass ==(int) data["origin_skill_class"])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    public override void _DropData(Vector2 position, Variant dataObj)
    {
        var data = ( Godot.Collections.Dictionary<string, Variant>)dataObj;
        var targetInvIndex = GetIndex();
        var originIndex = ((TextureRect)data["origin_node"]).GetParent().GetIndex();

        if (data["origin_panel"].ToString().Equals("SkillInventory"))
        {
           DataManager.Instance.skillData.data[GlobalManager.Instance.main.skill.selectIndex][originIndex] = (Godot.Collections.Dictionary<string, Variant>) data["target_item_id"];
        }
        else
        {
            DataManager.Instance.skillShortcutData.data[originIndex] =( Godot.Collections.Dictionary<string, Variant>) data["target_item_id"];
        }

        if (data["target_item_id"].ToString() == null)
        {
            ((TextureRect)data["origin_node"]).Texture = null;
        }
        else
        {
            ((TextureRect)data["origin_node"]).Texture = (Texture2D)data["target_texture"];
        }

        if (DataManager.Instance.skillShortcutData.data[targetInvIndex] == null)
        {
            DataManager.Instance.skillShortcutData.data[targetInvIndex] = new  ();
        }
       DataManager.Instance.skillShortcutData.data[targetInvIndex] =(Godot.Collections.Dictionary<string, Variant>) data["origin_item_id"];
        icon.Texture = (Texture2D)data["origin_texture"];

        if (data["origin_texture"].ToString() != null)
        {
            var showLV = (Godot.Collections.Dictionary<string, Variant>) data["origin_item_id"];
       lv.Text = showLV["show_lv"].ToString();
            lv.Visible = true;
            static_lv.Visible = true;
        }

        var originVisible = data["target_item_id"].ToString != null;
        var test =((dynamic) data["origin_node"]).GetParent().GetParent();
      // var slot = (Control)data["origin_node"].GetParent().GetParent().GetChild(originIndex);
     // slot.GetNode<Label>("lv").Text = data["target_item_id"]["show_lv"].ToString();
      //  slot.GetNode<Label>("lv").Visible = originVisible;
     //  slot.GetNode<TextureRect>("static_lv").Visible = originVisible;
    }

    private void _on_SkillShortcutSlot_mouse_entered()
    {
        select.Visible = true;
        var skl = DataManager.Instance.skillShortcutData.data[GetIndex()];
        if (skl != null)
        {
           GlobalManager.Instance.main.OnShowToolTipSkill((int)skl["id"],(int) skl["show_lv"], GetLocalMousePosition());
        }
    }

    private void _on_SkillShortcutSlot_mouse_exited()
    {
        select.Visible = false;
        GlobalManager.Instance.main.OnHideToolTipSkill();
    }
}

}