using Godot;
namespace ET
{
    public partial class InventorySlot : TextureRect
    {
        private TextureRect icon;
        private TextureRect select;
        private Label amount;

        public override void _Ready()
        {
            icon = GetNode<TextureRect>("Icon");
            select = GetNode<TextureRect>("select");
            amount = GetNode<Label>("amount");
        }

        public override Variant _GetDragData(Vector2 _pos)
        {
            var dataManager = DataManager.Instance.invData.data;
            if (dataManager[((Bag)GetParent().GetParent()).selectIndex][GetIndex()] != null)
            {
                var data = new Godot.Collections.Dictionary<string, Variant>();
                data["origin_node"] = icon;
                data["origin_panel"] = "Inventory";

                var item = dataManager[((Bag)GetParent().GetParent()).selectIndex][GetIndex()];
                data["origin_item_id"] = item;
                data["origin_equipment_slot"] = ConfigManager.Instance.equipConfigProxy.GetItemEquipmentSlot((int)item["id"]);
                data["origin_texture"] = icon.Texture;

                var dragTexture = new TextureRect();
                // dragTexture.Expand = true;
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
            if ((string)data["origin_panel"] == "SkillShortcut" || (string)data["origin_panel"] == "SkillInventory")
            {
                return false;
            }

            int targetInvIndex = GetIndex();
            var dataManager = DataManager.Instance.invData.data;
            var pnode = (Bag)GetParent().GetParent();
            if (dataManager[pnode.selectIndex][targetInvIndex] == null)
            {
                data["target_item_id"] = 0;
                data["target_texture"] = 0;
                return true;
            }
            else
            {
                var item = dataManager[pnode.selectIndex][targetInvIndex];
                data["target_item_id"] = item;
                data["target_texture"] = icon.Texture;

                if ((string)data["origin_panel"] == "CharacterSheet" && item.Count > 0)
                {
                    var targetEquipmentSlot = ConfigManager.Instance.equipConfigProxy.GetItemEquipmentSlot((int)item["id"]);
                    return targetEquipmentSlot == data["origin_equipment_slot"].ToString();
                }
                else
                {
                    return true;
                }

            }
        }

        public override void _DropData(Vector2 _pos, Variant dataObj)
        {
            var data = (Godot.Collections.Dictionary<string, Variant>)dataObj;
            string originSlot = ((Node)data["origin_node"]).GetParent().Name;
            int targetInvIndex = GetIndex();
            int originIndex = ((Node)data["origin_node"]).GetParent().GetIndex();

            if ((string)data["origin_panel"] == "Inventory")
            {
                DataManager.Instance.invData.data[((dynamic)GetParent().GetParent()).selectIndex][originIndex] = data["target_item_id"];
            }
            else if ((string)data["origin_panel"] == "Storage")
            {
                DataManager.Instance.storateData.data[originIndex] = data["target_item_id"];
            }
            else if ((string)data["origin_panel"] == "InvShortcut")
            {
                DataManager.Instance.invShortcutData.data[originIndex] = (Godot.Collections.Dictionary<string, Variant>)data["target_item_id"];
            }
            else
            {
                DataManager.Instance.equipData.equipmentData[originSlot] = data["target_item_id"];
            }

            if ((string)data["origin_panel"] == "CharacterSheet" && data["target_item_id"].ToString() == null)
            {
                ((TextureRect)data["origin_node"]).Texture = null;
            }
            else
            {
                ((TextureRect)data["origin_node"]).Texture = (Texture2D)data["target_texture"];
            }

            DataManager.Instance.invData.data[((dynamic)GetParent().GetParent()).selectIndex][targetInvIndex] = (Godot.Collections.Dictionary<string, Variant>)data["origin_item_id"];
            icon.Texture = (Texture2D)data["origin_texture"];
        }

        private void _OnItemSlotMouseEntered()
        {
            select.Visible = true;

            if (DataManager.Instance.invData.data[((dynamic)GetParent().GetParent()).selectIndex][GetIndex()] != null)
            {
                GlobalManager.Instance.main.OnShowToolTipEquip("Inventory", "", GetIndex(), GetLocalMousePosition());
            }
        }

        private void _OnItemSlotMouseExited()
        {
            select.Visible = false;
            GlobalManager.Instance.main.OnHideToolTipEquip();
        }
    }
}