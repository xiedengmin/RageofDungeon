using Godot;
using System;
using System.Collections.Generic;

namespace ET
{
    public partial class Bag : Control
    {
        // Button and GridContainer nodes
        private Button equipBtn;
        private Button stackableBtn;
        private Button materialBtn;
        private Button exBtn;
        private Button questBtn;
        private GridContainer equipGrid;
        private GridContainer stackableGrid;
        private GridContainer materialsGrid;
        private GridContainer experjobGrid;
        private GridContainer questGrid;

        // Equipment slot nodes
        private Control leftEquip;
        private Control rightEquip;

        public int selectIndex = 0;

        public override void _Ready()
        {
            equipBtn = GetNode<Button>("equipBtn");
            stackableBtn = GetNode<Button>("stackableBtn");
            materialBtn = GetNode<Button>("materialBtn");
            exBtn = GetNode<Button>("exBtn");
            questBtn = GetNode<Button>("questBtn");

            equipGrid = GetNode<GridContainer>("EquipGrid");
            stackableGrid = GetNode<GridContainer>("Stackable");
            materialsGrid = GetNode<GridContainer>("Materials");
            experjobGrid = GetNode<GridContainer>("Experjob");
            questGrid = GetNode<GridContainer>("Quest");

            leftEquip = GetNode<Control>("leftEquip");
            rightEquip = GetNode<Control>("rightEquip");

            equipBtn.ButtonPressed = true;
            InitInvData();
            InitEquipData();
        }

        // Initialize inventory data
        private void InitInvData()
        {
            for (int j = 0; j < 5; j++)
            {
                Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>> data = DataManager.Instance.invData.data[j];
                GridContainer grid;

                switch (j)
                {
                    case 0:
                        grid = equipGrid;
                        break;
                    case 1:
                        grid = stackableGrid;
                        break;
                    case 2:
                        grid = materialsGrid;
                        break;
                    case 3:
                        grid = experjobGrid;
                        break;
                    case 4:
                        grid = questGrid;
                        break;
                    default:
                        continue;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Count > 0)
                    {
                        var slot = (TextureRect)grid.GetChild(i);
                        var iconPath = GLOBALS_TYPE.ICON_PATH + ConfigManager.Instance.equipConfigProxy.GetItemIcon((int)data[i]["id"]);
                        var iconTexture = (Texture2D)GD.Load(iconPath);
                        slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
                    }
                }
            }
        }

        // Initialize equipment data
        private void InitEquipData()
        {
            foreach (var key in DataManager.Instance.equipData.equipmentData.Keys)
            {
                TextureRect slot;

                if (leftEquip.HasNode(key))
                {
                    slot = leftEquip.GetNode<TextureRect>(key);
                }
                else
                {
                    slot = rightEquip.GetNode<TextureRect>(key);
                }

                var equipData = (Godot.Collections.Dictionary<string, Variant>)DataManager.Instance.equipData.equipmentData[key];
                if (equipData.Count > 0)
                {
                    var iconPath = GLOBALS_TYPE.ICON_PATH + ConfigManager.Instance.equipConfigProxy.GetItemIcon((int)equipData["id"]);
                    var iconTexture = (Texture2D)GD.Load(iconPath);
                    slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
                }
                else
                {
                    slot.GetNode<TextureRect>("Icon").Texture = null;
                }
            }
        }

        public override bool _CanDropData(Vector2 pos, Variant dataObj)
        {
            var data = (Godot.Collections.Dictionary<string, Variant>)dataObj;
            if (data["origin_panel"].ToString() != "SkillShortcut" && data["origin_panel"].ToString() != "SkillInventory")
            {
                int id = (int)((Godot.Collections.Dictionary<string, Variant>)data["origin_item_id"])["id"];
                int itemType = ConfigManager.Instance.equipConfigProxy.GetItemType(id);

                if (selectIndex != itemType)
                {
                    ChangeType(itemType);
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        private void OnCloseBtnPressed()
        {
            GlobalManager.Instance.main.OnOpenBag();
        }

        private void OnEquipBtnToggled(bool buttonPressed)
        {
            if (buttonPressed)
            {
                ShowGrid(true, false, false, false, false);
                selectIndex = 0;
            }
        }

        private void OnStackableBtnToggled(bool buttonPressed)
        {
            if (buttonPressed)
            {
                ShowGrid(false, true, false, false, false);
                selectIndex = 1;
            }
        }

        private void OnMaterialBtnToggled(bool buttonPressed)
        {
            if (buttonPressed)
            {
                ShowGrid(false, false, true, false, false);
                selectIndex = 2;
            }
        }

        private void OnExBtnToggled(bool buttonPressed)
        {
            if (buttonPressed)
            {
                ShowGrid(false, false, false, true, false);
                selectIndex = 3;
            }
        }

        private void OnQuestBtnToggled(bool buttonPressed)
        {
            if (buttonPressed)
            {
                ShowGrid(false, false, false, false, true);
                selectIndex = 4;
            }
        }

        // Show grid control
        private void ShowGrid(bool v1, bool v2, bool v3, bool v4, bool v5)
        {
            equipGrid.Visible = v1;
            stackableGrid.Visible = v2;
            materialsGrid.Visible = v3;
            experjobGrid.Visible = v4;
            questGrid.Visible = v5;
        }

        // Change type based on item type
        private void ChangeType(int itemType)
        {
            switch (itemType)
            {
                case 0:
                    equipBtn.ButtonPressed = true;
                    break;
                case 1:
                    stackableBtn.ButtonPressed = true;
                    break;
                case 2:
                    materialBtn.ButtonPressed = true;
                    break;
                case 3:
                    exBtn.ButtonPressed = true;
                    break;
                case 4:
                    questBtn.ButtonPressed = true;
                    break;
            }
        }

        private void OnBagVisibilityChanged()
        {
            GetNode<AudioStreamPlayer>("windowSound").Play();
        }
    }
}