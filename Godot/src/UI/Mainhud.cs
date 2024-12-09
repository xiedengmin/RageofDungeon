using Godot;
using System;

public partial class Mainhud : Control
{
    // Define controls
    [Export] private TextureProgressBar expBar;
    [Export] private TextureProgressBar fatigueBar;
    [Export] private TextureProgressBar hpBar;
    [Export] private TextureProgressBar mpBar;
    [Export] private Label SP;
    [Export] private Label lv;
    [Export] private Control invShort;
    [Export] private Control skillShort;

    // Called when the node enters the scene tree for the first time
    public override void _Ready()
    {
        expBar = (TextureProgressBar)GetNode("expBar");
         fatigueBar=(TextureProgressBar)GetNode("fatigueBar");
         hpBar= (TextureProgressBar)GetNode("hpBar"); 
        mpBar=(TextureProgressBar)GetNode("mpBar"); 
        SP= (Label)GetNode("SP");
        lv = (Label)GetNode("lv");
        invShort= (Control)GetNode("InvShortcut");
        skillShort =(Control)GetNode("SkillShortcutGrid");
        InitData();
    }

    // Initialize data
    private void InitData()
    {
        lv.Text = DataManager.Instance.roleData.lv.ToString();
        expBar.Value = (DataManager.Instance.roleData.expe / DataManager.Instance.roleData.maxExpe) * 100.0;
        hpBar.Value = (DataManager.Instance.roleData.Hp / DataManager.Instance.roleData.maxHp) * 100.0;
        mpBar.Value = (DataManager.Instance.roleData.mp / DataManager.Instance.roleData.maxMp) * 100.0;
        SP.Text = DataManager.Instance.roleData.sp.ToString();

        // Initialize inventory shortcut data
        var data = DataManager.Instance.invShortcutData.data;
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].Count>0)
            {
                TextureRect slot = invShort.GetChild<TextureRect>(i);
               string iconPath = GLOBALS_TYPE.ICON_PATH + ConfigManager.Instance.equipConfigProxy.GetItemIcon((int)data[i]["ID"]);
               var iconTexture = ResourceLoader.Load<Texture2D>(iconPath);
            slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
            }
        }

        // Initialize skill shortcut data
        var skillData = DataManager.Instance.skillShortcutData.data;
        for (int i = 0; i < skillData.Count; i++)
        {
            if (skillData[i] != null)
            {
                TextureRect slot = skillShort.GetChild<TextureRect>(i);
                int id =(int) skillData[i]["id"];
                string iconName = ConfigManager.Instance.skillConfigProxy.GetIconByID(DataManager.Instance.roleData.jobBase, id);
                string iconPath = GLOBALS_TYPE.SKILL_ICON_PATH + iconName;
                var iconTexture = ResourceLoader.Load<Texture2D>(iconPath);
                slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
                slot.GetNode<Label>("lv").Text = skillData[i]["show_lv"].ToString();
                slot.GetNode<Label>("lv").Visible = true;
                slot.GetNode<Label>("static_lv").Visible = true;
            }
        }
    }

    // Update data
    public void Refresh(int index)
    {
        TextureRect slot = skillShort.GetChild<TextureRect>(index);
        int id = (int)DataManager.Instance.skillShortcutData.data[index]["id"];
        string iconName = ConfigManager.Instance.skillConfigProxy.GetIconByID(DataManager.Instance.roleData.jobBase, id);
        string iconPath = GLOBALS_TYPE.SKILL_ICON_PATH + iconName;
        var iconTexture = ResourceLoader.Load<Texture2D>(iconPath);
        slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
        slot.GetNode<Label>("lv").Text = DataManager.Instance.skillShortcutData.data[index]["show_lv"].ToString();
        slot.GetNode<Label>("lv").Visible = true;
        slot.GetNode<Label>("static_lv").Visible = true;
        SP.Text = DataManager.Instance.roleData.sp.ToString();
    }

    // Open the bag
    public void OnBag()
    {
        GlobalManager.Instance.main.OnOpenBag();
    }

    // Open the status panel
    public void OnState()
    {
        GlobalManager.Instance.main.OnOpenStatus();
    }

    // Handle fight action
    public void OnFight()
    {
        ((dynamic)GetOwner()).infoMenu.Popup();
    }

    // Open skill menu
    public void OnTutBtnPressed()
    {
        GetOwner().Call("OnOpenSkill");
    }

    // Open settings
    public void OnSetBtnPressed()
    {
        ((dynamic)GetOwner()).optionMenu.Popup();
    }
}