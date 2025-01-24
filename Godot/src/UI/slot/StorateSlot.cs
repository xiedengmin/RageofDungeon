using Godot;
using System;
namespace ET
{
    public partial class StorateSlot : TextureRect
    {
        private TextureRect icon;
        [Export] private TextureRect select;
        [Export] private Label amount;

        public override void _Ready()
        {
            icon = GetNode<TextureRect>("Icon");
            select = GetNode<TextureRect>("select");
            amount = GetNode<Label>("amount");
        }

        public override Variant _GetDragData(Vector2 _pos)
        {
            var index = GetIndex();
            if (DataManager.Instance.storateData.data[index].ToString() != null)
            {
                var data = new Godot.Collections.Dictionary();
                data["origin_node"] = icon;
                data["origin_panel"] = "Storate";
                var item = DataManager.Instance.storateData.data[index];
                data["origin_item_id"] = item;
                //   data["origin_equipment_slot"] = ConfigManager.Instance.equipConfigProxy.GetItemEquipmentSlot((int)(item["id"]));
                data["origin_texture"] = icon.Texture;

                var dragTexture = new TextureRect
                {
                    //  Expand = true,
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
            var dictData = (Godot.Collections.Dictionary<string, Variant>)dataObj;
            string originPanel = dictData["origin_panel"].ToString();
            if (originPanel == "CharacterSheet" || originPanel == "SkillShortcut" || originPanel == "SkillInventory")
                return false;

            var targetInvIndex = GetIndex();
            if (DataManager.Instance.storateData.data[targetInvIndex].ToString() == null)
            {
                dictData["target_item_id"] = 0;
                dictData["target_texture"] = 0;
            }
            else
            {
                var item = DataManager.Instance.storateData.data[targetInvIndex];
                dictData["target_item_id"] = item;
                dictData["target_texture"] = icon.Texture;
            }
            return true;
        }

        public override void _DropData(Vector2 _pos, Variant data)
        {
            var dictData = (Godot.Collections.Dictionary<string, Variant>)data;
            var targetInvIndex = GetIndex();
            var originIndex = ((TextureRect)dictData["origin_node"]).GetParent().GetIndex();

            // 更新原 slot 的数据
            switch (dictData["origin_panel"].ToString())
            {
                case "Inventory":
                    //  DataManager.Instance.invData.data[GlobalManager.Instance.main.bag.selectIndex][originIndex] = dictData["target_item_id"];
                    break;
                case "Storate":
                    DataManager.Instance.storateData.data[originIndex] = dictData["target_item_id"];
                    break;
                case "InvShortcut":
                    DataManager.Instance.invShortcutData.data[originIndex] = (Godot.Collections.Dictionary<string, Variant>)dictData["target_item_id"];
                    break;
            }

            // 更新原 slot 的纹理
            if (dictData["origin_panel"].ToString() == "CharacterSheet" && (Godot.Collections.Dictionary<string, Variant>)dictData["target_item_id"] == null)
                ((TextureRect)dictData["origin_node"]).Texture = null;
            else
                ((TextureRect)dictData["origin_node"]).Texture = (Texture2D)dictData["target_texture"];

            // 更新目标的纹理和数据
            DataManager.Instance.storateData.data[targetInvIndex] = dictData["origin_item_id"];
            icon.Texture = (Texture2D)dictData["origin_texture"];
        }

        private void _on_ItemSlot_mouse_entered()
        {
            select.Visible = true;
            var index = GetIndex();
            if (DataManager.Instance.storateData.data[index].ToString() != null)
            {
                GlobalManager.Instance.main.OnShowToolTipEquip("Storate", "", index, GetLocalMousePosition());
            }
        }

        private void _on_ItemSlot_mouse_exited()
        {
            select.Visible = false;
            GlobalManager.Instance.main.OnHideToolTipEquip();
        }
    }
}