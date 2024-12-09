using Godot;
using System;

public partial class InvShortcutSlot : TextureRect // 使用你的类名
{
    [Export] private TextureRect icon;
    [Export] private TextureRect select;

    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
        select = GetNode<TextureRect>("select");
    }

    public override  Variant _GetDragData(Vector2 pos)
    {
        if (DataManager.Instance.invShortcutData.data[GetIndex()].ToString() != null)
        {
            var data = new  Godot.Collections.Dictionary<string, Variant>
            {
                { "origin_node", icon },
                { "origin_panel", "InvShortcut" }
            };

            var item = DataManager.Instance.invShortcutData.data[GetIndex()];
            data["origin_item_id"] = item;
          data["origin_equipment_slot"] = ConfigManager.Instance.equipConfigProxy.GetItemEquipmentSlot((int)item["id"]);
            data["origin_texture"] = icon.Texture;

            var dragTexture = new TextureRect();
          //err  dragTexture.Expand = true;
            dragTexture.Texture = icon.Texture;
            dragTexture.Size = new Vector2(28, 28);

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
        var dictData = ( Godot.Collections.Dictionary<string, Variant>)data;
        if (dictData["origin_panel"].ToString() == "SkillShortcut" || dictData["origin_panel"].ToString() == "SkillInventory")
        {
            return false;
        }

        int targetInvIndex = GetIndex();
        var shortData = DataManager.Instance.invShortcutData.data;

        if (shortData[targetInvIndex].ToString() == null)
        {
            dictData["target_item_id"] = 0;
            dictData["target_texture"] = 0;
            return true;
        }
        else
        {
            var item = shortData[targetInvIndex];
            dictData["target_item_id"] = item;
            dictData["target_texture"] = icon.Texture;

            if (dictData["origin_panel"].ToString() == "CharacterSheet")
            {
               var targetEquipmentSlot = ConfigManager.Instance.equipConfigProxy.GetItemEquipmentSlot((int)item["id"]);
                if (targetEquipmentSlot.Equals(dictData["origin_equipment_slot"]))
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

    public override  void _DropData(Vector2 pos, Variant data)
    {
        var dictData = ( Godot.Collections.Dictionary<string, Variant>)data;

        string originSlot = ((TextureRect)dictData["origin_node"]).GetParent().Name;
        int targetInvIndex = GetIndex();
        int originIndex = ((TextureRect)dictData["origin_node"]).GetParent().GetIndex();

        if (dictData["origin_panel"].ToString() == "Inventory")
        {
        //  DataManager.Instance.invData.data[GlobalManager.Instance.main.bag.selectIndex][originIndex] = dictData["target_item_id"];
        }
        else if (dictData["origin_panel"].ToString() == "Storate")
        {
            DataManager.Instance.storateData.data[originIndex] = dictData["target_item_id"];
        }
        else if (dictData["origin_panel"].ToString() == "InvShortcut")
        {
            DataManager.Instance.invShortcutData.data[originIndex] = (Godot.Collections.Dictionary<string, Variant>)dictData["target_item_id"];
        }
        else
        {
            DataManager.Instance.equipData.equipmentData[originSlot] = dictData["target_item_id"];
        }

        if (dictData["origin_panel"].ToString() == "CharacterSheet" && dictData["target_item_id"].ToString() == null)
        {
            ((TextureRect)dictData["origin_node"]).Texture = null;
        }
        else
        {
            ((TextureRect)dictData["origin_node"]).Texture = (Texture2D)dictData["target_texture"];
        }

        DataManager.Instance.invShortcutData.data[targetInvIndex] = (Godot.Collections.Dictionary<string, Variant>)dictData["origin_item_id"];
        icon.Texture = (Texture2D)dictData["origin_texture"];
    }

    private void _on_InvShortcutSlot_mouse_entered()
    {
        select.Visible = true;
        if (DataManager.Instance.invShortcutData.data[GetIndex()].ToString() != null)
        {
            GlobalManager.Instance.main.OnShowToolTipEquip("InvShortcut", "", GetIndex(), GetLocalMousePosition());
        }
    }

    private void _on_InvShortcutSlot_mouse_exited()
    {
        select.Visible = false;
        GlobalManager.Instance.main.OnHideToolTipEquip();
    }
}