using Godot;
using System;

public partial class SkillInventory : Control
{
    Button tab1;
    Button tab2;
    Button tab3;
    Button tab4;
    Button tab5;
    GridContainer grid1;
    GridContainer grid2;
    GridContainer grid3;
    GridContainer grid4;
    GridContainer grid5;
    Label sp;
    public int selectIndex = 0;

    public override void _Ready()
    {
        tab1 = GetNode<Button>("Tab_Button1");
        tab2 = GetNode<Button>("Tab_Button2");
        tab3 = GetNode<Button>("Tab_Button3");
        tab4 = GetNode<Button>("Tab_Button4");
        tab5 = GetNode<Button>("Tab_Button5");
        grid1 = GetNode<GridContainer>("grid1");
        grid2 = GetNode<GridContainer>("grid2");
        grid3 = GetNode<GridContainer>("grid3");
        grid4 = GetNode<GridContainer>("grid4");
        grid5 = GetNode<GridContainer>("grid5");
        sp = GetNode<Label>("SP");

        tab1.ButtonPressed = true;
        InitData();
    }

    // 初始化数据
    private void InitData()
    {
        for (int index = 0; index < 5; index++)
        {
            var list = DataManager.Instance.skillData.data[index];
            var grid = GetNode<GridContainer>("grid" + (index + 1));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count > 0)
                {
                    var node = grid.GetChild<TextureRect>(i);
                    var iconPath = GLOBALS_TYPE.SKILL_ICON_PATH + ConfigManager.Instance.skillConfigProxy.GetIconByID(DataManager.Instance.roleData.job, (int)list[i]["id"]);
                    var iconTexture = GD.Load<Texture2D>(iconPath);
                    node.GetNode<TextureRect>("Icon").Texture = iconTexture;
                }
            }
        }
        sp.Text = DataManager.Instance.roleData.sp.ToString();
    }

    // 刷新数据
    public void Refresh(int classIndex, int slotIndex)
    {
        var list = DataManager.Instance.skillData.data[classIndex];
        var grid = GetNode<GridContainer>("grid" + (classIndex + 1));
        var node = grid.GetChild<TextureRect>(slotIndex);
        var iconPath = GLOBALS_TYPE.SKILL_ICON_PATH + ConfigManager.Instance.skillConfigProxy.GetIconByID(DataManager.Instance.roleData.job, (int)list[slotIndex]["id"]);
        var iconTexture = GD.Load<Texture2D>(iconPath);
        node.GetNode<TextureRect>("Icon").Texture = iconTexture;
        node.GetNode<Label>("lv").Text = list[slotIndex]["show_lv"].ToString();
        node.GetNode<Label>("lv").Visible = true;
        node.GetNode<Label>("static_lv").Visible = true;
        sp.Text = DataManager.Instance.roleData.sp.ToString();
    }

    // 锁定按钮
    private void _OnLockBtnPressed()
    {
        // Replace with function body.
    }

    // 解锁按钮
    private void _OnUnlockBtnPressed()
    {
        // Replace with function body.
    }

    public override bool _CanDropData(Vector2 position, Variant dataobj)
    {
        var data = (Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, Variant>>)dataobj;
        if (data["origin_panel"].ToString() == "SkillShortcut")
        {
            int skillClass = ConfigManager.Instance.skillConfigProxy.GetClassByID(DataManager.Instance.roleData.jobBase, (int)data["origin_item_id"]["id"]);
            if (selectIndex != skillClass)
            {
                switch (skillClass)
                {
                    case 0:
                        tab1.ButtonPressed = true;
                        break;
                    case 1:
                        tab2.ButtonPressed = true;
                        break;
                    case 2:
                        tab3.ButtonPressed = true;
                        break;
                    case 3:
                        tab4.ButtonPressed = true;
                        break;
                    case 4:
                        tab5.ButtonPressed = true;
                        break;
                }
            }
            return true;
        }
        return false;
    }

    // 控制grid的显示
    private void ShowGrid(bool v1, bool v2, bool v3, bool v4, bool v5)
    {
        grid1.Visible = v1;
        grid2.Visible = v2;
        grid3.Visible = v3;
        grid4.Visible = v4;
        grid5.Visible = v5;
    }

    // Tab 按钮事件
    private void _OnTabButton1Toggled(bool buttonPressed)
    {
        if (buttonPressed)
        {
            ShowGrid(true, false, false, false, false);
            selectIndex = 0;
        }
    }

    private void _OnTabButton2Toggled(bool buttonPressed)
    {
        if (buttonPressed)
        {
            ShowGrid(false, true, false, false, false);
            selectIndex = 1;
        }
    }

    private void _OnTabButton3Toggled(bool buttonPressed)
    {
        if (buttonPressed)
        {
            ShowGrid(false, false, true, false, false);
            selectIndex = 2;
        }
    }

    private void _OnTabButton4Toggled(bool buttonPressed)
    {
        if (buttonPressed)
        {
            ShowGrid(false, false, false, true, false);
            selectIndex = 3;
        }
    }

    private void _OnTabButton5Toggled(bool buttonPressed)
    {
        if (buttonPressed)
        {
            ShowGrid(false, false, false, false, true);
            selectIndex = 4;
        }
    }

    // 关闭
    private void _OnCloseBtnPressed()
    {
        GlobalManager.Instance.main.OnOpenSkill();
    }

    private void _OnSkillInventoryVisibilityChanged()
    {
        GetNode<AudioStreamPlayer>("windowSound").Play();
    }
}
