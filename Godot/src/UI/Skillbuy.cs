using Godot;
using System;

public partial class SkillBuy : Panel
{
    private PackedScene itemTemp = (PackedScene)ResourceLoader.Load("res://scenes/UI/slot/Skillbuy_Item.tscn");
    private Resource group = ResourceLoader.Load("res://scenes/UI/btn_group/skillbuy_buttongroup.tres");

    private Button tab1;
    private Button tab2;
    private Button tab3;
    private Button tab4;
    private Button tab5;
    private GridContainer grid1;
    private GridContainer grid2;
    private GridContainer grid3;
    private GridContainer grid4;
    private GridContainer grid5;
    private ScrollContainer skillContainer;

    private Button learnBtn;
    private AnimationPlayer animation;

    public int selectIndex = 0;
    public int selectItemIndex = 0;
    public int selectItemId = -1;

    public override void _Ready()
    {
        tab1 = GetNode<Button>("Tab_Button1");
        tab2 = GetNode<Button>("Tab_Button2");
        tab3 = GetNode<Button>("Tab_Button3");
        tab4 = GetNode<Button>("Tab_Button4");
        tab5 = GetNode<Button>("Tab_Button5");
        grid1 = GetNode<GridContainer>("skillContainer/grid1");
        grid2 = GetNode<GridContainer>("skillContainer/grid2");
        grid3 = GetNode<GridContainer>("skillContainer/grid3");
        grid4 = GetNode<GridContainer>("skillContainer/grid4");
        grid5 = GetNode<GridContainer>("skillContainer/grid5");
        skillContainer = GetNode<ScrollContainer>("skillContainer");
        learnBtn = GetNode<Button>("learnBtn");
        animation = GetNode<AnimationPlayer>("AnimationPlayer");

        tab1.ButtonPressed = true;
        learnBtn.Disabled = true;
        InitData();
        GetNode<AudioStreamPlayer>("windowSound").Play();
    }

    private void InitData()
    {
        var list = ConfigManager.Instance.skillConfigProxy.GetSlkList(DataManager.Instance.roleData.jobBase, DataManager.Instance.roleData.job);
        GridContainer grid = null;

        foreach (var skl in list)
        {
            int sklLv = DataManager.Instance.GetSkillLv(skl.ID);
            int maxLv = Utils.GetSkillMaxLv(skl.growtypeMaximumLevel);

            if (sklLv < maxLv)
            {
                var item = (Skillbuy_Item)itemTemp.Instantiate();
                item.Set("lv", sklLv + 1);
                item.Set("skl", skl);
                item.Set("group", group);

                switch (skl.skillClass)
                {
                    case 0: grid = grid1; break;
                    case 1: grid = grid2; break;
                    case 2: grid = grid3; break;
                    case 3: grid = grid4; break;
                    case 4: grid = grid5; break;
                }

                // item.Connect("toggled", new Callable(this, nameof(OnItemSelect)), (new Godot.Collections.Array { grid.GetChildCount(), skl.ID }));
                //    grid.AddChild(item);
            }
        }
    }

    private void OnItemSelect(bool pressed, int index, int itemId)
    {
        var grid = skillContainer.GetNode<GridContainer>("grid" + (selectIndex + 1).ToString());
        var item = (TextureButton)grid.GetChild(index);

        if (pressed)
        {
            item.GetNode<Sprite2D>("select").Visible = true;
            selectItemIndex = index;
            selectItemId = itemId;
            learnBtn.Disabled = !((bool)item.Get("can_learn"));
        }
        else
        {
            item.GetNode<Sprite2D>("select").Visible = false;
        }

        animation.Play("select");
    }

    private void OnTabButtonToggled(Button button, int gridIndex)
    {
        if (button.ButtonPressed)
        {
            ShowGrid(gridIndex == 0, gridIndex == 1, gridIndex == 2, gridIndex == 3, gridIndex == 4);
            selectIndex = gridIndex;
        }
    }

    private void ShowGrid(bool v1, bool v2, bool v3, bool v4, bool v5)
    {
        grid1.Visible = v1;
        grid2.Visible = v2;
        grid3.Visible = v3;
        grid4.Visible = v4;
        grid5.Visible = v5;
    }

    private void OnLearnBtnPressed()
    {
        bool done = false;
        var sklConfig = ConfigManager.Instance.skillConfigProxy.GetSklByID(DataManager.Instance.roleData.jobBase, selectItemId);
        bool isActive = sklConfig.type != "passive";

        if (isActive)
        {
            var skillShort = DataManager.Instance.skillShortcutData.data;

            for (int i = 0; i < skillShort.Count; i++)
            {
                var sklData = skillShort[i];

                if (sklData != null && (int)sklData["id"] == selectItemId)
                {
                    sklData["lv"] = (int)sklData["lv"] + 1;
                    sklData["show_lv"] = (int)sklData["show_lv"] + 1;
                    done = true;
                    GlobalManager.Instance.main.hud.Refresh(i);
                    break;
                }
            }

            if (!done)
            {
                for (int i = 0; i < skillShort.Count; i++)
                {
                    if (skillShort[i] == null)
                    {
                        skillShort[i] = new Godot.Collections.Dictionary<string, Variant> { { "id", selectItemId }, { "lv", 1 }, { "show_lv", 1 } };
                        done = true;
                        GlobalManager.Instance.main.hud.Refresh(i);
                        break;
                    }
                }
            }
        }

        var skillList = DataManager.Instance.skillData.data[sklConfig.skillClass];

        if (!done)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                var sklData = skillList[i];

                if (sklData != null && (int)sklData["id"] == selectItemId)
                {
                    sklData["lv"] = (int)sklData["lv"] + 1;
                    sklData["show_lv"] = (int)sklData["show_lv"] + 1;
                    done = true;
                    GlobalManager.Instance.main.skill.Refresh(sklConfig.skillClass, i);
                    break;
                }
            }

            if (!done)
            {
                for (int i = 0; i < skillList.Count; i++)
                {
                    if (skillList[i] == null)
                    {
                        skillList[i] = new Godot.Collections.Dictionary<string, Variant> { { "id", selectItemId }, { "lv", 1 }, { "show_lv", 1 } };
                        done = true;
                        //  GlobalManager.Instance.main.skill.Refresh(sklConfig.skillClass, i);
                        break;
                    }
                }
            }
        }

        RefreshList();
        animation.Stop();
        animation.Play("learn");
    }

    private void RefreshList()
    {
        var list = ConfigManager.Instance.skillConfigProxy.GetSlkList(DataManager.Instance.roleData.jobBase, DataManager.Instance.roleData.job);
        GridContainer grid = null;

        switch (selectIndex)
        {
            case 0: grid = grid1; break;
            case 1: grid = grid2; break;
            case 2: grid = grid3; break;
            case 3: grid = grid4; break;
            case 4: grid = grid5; break;
        }

        int count = grid.GetChildCount();
        for (int i = 0; i < count; i++)
        {
            TextureButton item = (TextureButton)grid.GetChild(0);
            //err   item.Disconnect("toggled",Callable.From(OnItemSelect));
            grid.RemoveChild(item);
        }

        bool isClear = true;

        foreach (var skl in list)
        {
            int sklLv = DataManager.Instance.GetSkillLv(skl.ID);
            int maxLv = Utils.GetSkillMaxLv(skl.growtypeMaximumLevel);

            if (skl.skillClass == selectIndex && sklLv < maxLv)
            {
                var item = (TextureButton)itemTemp.Instantiate();
                item.Set("lv", sklLv + 1);
                item.Set("skl", skl);
                item.Set("group", group);
                //item.Connect(SignalName.Toggled, this, nameof(OnItemSelect), new Godot.Collections.Array { grid.GetChildCount(), skl.ID });
                grid.AddChild(item);
                item.GetNode<Sprite2D>("select").Visible = false;

                if (skl.ID == selectItemId)
                {
                    item.GetNode<Sprite2D>("select").Visible = true;
                    isClear = !(bool)item.Get("can_learn");
                }
            }
        }

        learnBtn.Disabled = isClear;
    }

    private void OnCloseBtnPressed()
    {
        QueueFree();
        GetNode<AudioStreamPlayer>("windowSound").Play();
    }
}