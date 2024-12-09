using Godot;
using Godot.Collections;


public partial class EquipmentSlot : TextureRect
{
    // 定义变量
    [Export] private TextureRect icon;
    [Export] private TextureRect select;

    // 载入时获取节点
    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
        select = GetNode<TextureRect>("select");
    }

    public override Variant _GetDragData(Vector2 _pos)
    {
        string equipment_slot = Name;
        if (DataManager.Instance.equipData.equipmentData.ContainsKey(equipment_slot) && DataManager.Instance.equipData.equipmentData[equipment_slot].ToString() != null)
        {
            var data = new Dictionary<string, Variant>();
            data["origin_node"] = icon;
            data["origin_panel"] = "CharacterSheet";
            data["origin_item_id"] = DataManager.Instance.equipData.equipmentData[equipment_slot];
            data["origin_equipment_slot"] = equipment_slot;
            data["origin_texture"] = icon.Texture;

            var drag_texture = new TextureRect();
            drag_texture.Texture = icon.Texture;
            drag_texture.Size = new Vector2(28, 28);

            var control = new Control();
            control.AddChild(drag_texture);
            drag_texture.Position = -0.5f * drag_texture.Size;
            SetDragPreview(control);
            var originItemID = ((Dictionary<string, Variant>)data["origin_item_id"])["id"];
            // 切换背包的类别
            var item_type = ConfigManager.Instance.equipConfigProxy.GetItemType((int)originItemID);
            GetParent().GetParent().Call("ChangeType", item_type);
            return data;
        }

        return 0;
    }

    public override bool _CanDropData(Vector2 _pos, Variant dataObj)
    {
        var data = (Dictionary<string,Variant>)dataObj;
        if (data["origin_panel"].ToString() == "SkillShortcut" || data["origin_panel"].ToString() == "SkillInventory")
        {
            return false;
        }

        string target_equipment_slot = Name;
        if (target_equipment_slot == data["origin_equipment_slot"].ToString())
        {
            if (DataManager.Instance.equipData.equipmentData[target_equipment_slot].ToString() == null)
            {
                data["target_item_id"] = 0;
                data["target_texture"] = 0;
            }
            else
            {
                data["target_item_id"] = DataManager.Instance.equipData.equipmentData[target_equipment_slot];
                data["target_texture"] = icon.Texture;
            }
            return true;
        }
        return false;
    }

    public override void _DropData(Vector2 _pos, Variant dataObj)
    {
        var data = (Dictionary<string, Variant>)dataObj;
        string target_equipment_slot = Name;
        string origin_slot = ((TextureRect)data["origin_node"]).GetParent().Name;
        int origin_index = ((TextureRect)data["origin_node"]).GetParent().GetIndex();

        // 更新原 slot 的数据
        if (data["origin_panel"].ToString() == "Inventory")
        {
            DataManager.Instance.invData.data[((dynamic)GetParent().GetParent()).selectIndex][origin_index] = data["target_item_id"];
        }
        else // CharacterSheet
        {
            DataManager.Instance.equipData.equipmentData[origin_slot] = data["target_item_id"];
        }

        // 更新原 slot 的纹理
        if (data["origin_panel"].ToString() == "CharacterSheet" && data["target_item_id"].ToString() == null)
        {
            ((TextureRect)data["origin_node"]).Texture = null;
        }
        else
        {
            ((TextureRect)data["origin_node"]).Texture = (Texture2D)data["target_texture"];
        }

        // 更新目标的纹理和数据
        DataManager.Instance.equipData.equipmentData[target_equipment_slot] = data["origin_item_id"];
        icon.Texture = (Texture2D)data["origin_texture"];
    }

    private void _on_EquipSlot_mouse_entered()
    {
        select.Visible = true;
       Variant temp= DataManager.Instance.equipData.equipmentData[Name];
        if (temp.Obj!=null )
        {
            GlobalManager.Instance.main.Call("OnShowToolTipEquip", "InvShortcut", Name, 0, GetLocalMousePosition());
        }
    }

    private void _on_EquipSlot_mouse_exited()
    {
        select.Visible = false;
        GlobalManager.Instance.main.Call("OnHideToolTipEquip");
    }
}