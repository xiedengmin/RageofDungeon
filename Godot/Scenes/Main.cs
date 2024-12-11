using Godot;
using System;
public partial class Main : Node2D
{
    [Export] private Node2D levels;
    [Export] private AudioStreamPlayer bgm;
    [Export] private AudioStreamPlayer env;
    [Export] public Loading loading;
    [Export] private CanvasLayer ui;

    // 状态栏
    [Export] public Control status;
    // 背包
    [Export] public Bag bag;
    // 仓库
    [Export] public Control storate;
    // HUD
    [Export] public Mainhud hud;
    // 技能面板
    [Export] public SkillInventory skill;
    // 技能tooltip
    [Export] public ToolTipSkill toolTipSkill;
    // 装备tooltip
    [Export] public ToolTipEquip toolTipEquip;
    // optionmenu
    [Export] public OptionMenu optionMenu;
    // myinfomenu
    [Export] public MyinfoMenu infoMenu;
    // 血条容器
    [Export] public MonsterHP monsterHP;

    // 玩家
    public Swordman player;

    // 当前地图
    public Node currentLevel;
    public InputManager inputManager;
    public override void _Ready()
    {
        levels = GetNode<Node2D>("levels");
        bgm = GetNode<AudioStreamPlayer>("BGMPlayer");
        env = GetNode<AudioStreamPlayer>("ENVPlayer");
        loading = GetNode<Control>("LoadingLayer/Loading") as Loading;
        ui = GetNode<CanvasLayer>("UI");
        status = GetNode<Control>("UI/Status");
        bag = (Bag)GetNode<Control>("Main/Panel/Bag");
        storate = GetNode<Control>("Main/Panel/StorateUI");
        hud = (Mainhud)GetNode<Control>("Main/Panel/Mainhud");
        skill = (SkillInventory)GetNode<Control>("Main/Panel/Skillinventory");
        toolTipSkill = (ToolTipSkill)GetNode<Control>("ToolTip/ToolTipSkill");
        toolTipEquip = (ToolTipEquip)GetNode<Control>("ToolTip/ToolTipEquip");
        optionMenu = (OptionMenu)GetNode<Popup>("Popup/OptionMenu");
        infoMenu = (MyinfoMenu)GetNode<Popup>("Popup/MyinfoMenu");
        monsterHP = (MonsterHP)GetNode<CanvasLayer>("MonsterHP");
        GlobalManager.Instance.main = this;

        InputManager.Instance.Connect("OpenStatus", new Callable(this, nameof(OnOpenStatus)));
        InputManager.Instance.Connect("OpenBag", new Callable(this, nameof(OnOpenBag)));
        InputManager.Instance.Connect("OpenSkill", new Callable(this, nameof(OnOpenSkill)));
        InputManager.Instance.Connect("UiCancel", new Callable(this, nameof(OnUiCancel)));

        //InitPlayer();
        // InitMap();
    }

    // 初始化玩家
    private void InitPlayer()
    {
        switch (DataManager.Instance.roleData.job)
        {
            case GLOBALS_TYPE.SWORDMAN:
                GlobalManager.Instance.main.player = (Swordman)GD.Load<PackedScene>("res://Prefabs/role/character/Swordman.tscn").Instantiate();
                break;
            case GLOBALS_TYPE.FIGHTER:
                GlobalManager.Instance.main.player = (Swordman)GD.Load<PackedScene>("res://Prefabs/role/character/Fighter.tscn").Instantiate();
                break;
        }
    }

    // 初始化地图
    private void InitMap()
    {
        GlobalManager.Instance.mapType = "town";
        var elv = GD.Load<PackedScene>("res://scenes/town/Elvengard/Elvengard.tscn");
        currentLevel = ((dynamic)elv).Instantiate();
        levels.AddChild((Node)currentLevel);
        currentLevel.Call("SetPlayer", GlobalManager.Instance.main.player, true);
    }

    // 切换地图
    public void ChangeLevel()
    {
        player.GetParent().RemoveChild(GlobalManager.Instance.main.player);

        var children = levels.GetChildren();
        if (children.Count > 0)
        {
            ((Node)children[0]).QueueFree();
        }

        string fileAddr = "";
        switch (GlobalManager.Instance.state.target)
        {
            case "Elvengard":
                fileAddr = "res://scenes/town/Elvengard/Elvengard.tscn";
                break;
            case "HendonMyre":
                fileAddr = "res://scenes/town/HendonMyre/HendonMyre.tscn";
                break;
            case "WestCoast":
                fileAddr = "res://scenes/town/WestCoast/WestCoast.tscn";
                break;
            case "StormPass":
                fileAddr = "res://scenes/town/StormPass/StormPass.tscn";
                break;
            case "Alfhlyra":
                fileAddr = "res://scenes/town/Alfhlyra/Alfhlyra.tscn";
                break;
        }

        GlobalManager.Instance.mapType = "town";
        var level = GD.Load<PackedScene>(fileAddr);
        currentLevel = level.Instantiate();
        levels.AddChild(currentLevel);
        currentLevel.Call("SetPlayer", GlobalManager.Instance.main.player, false);
        loading.Call("ChangeTown");
    }

    // 切换BGM
    public void ChangeBGM(string value)
    {
        if (value == GlobalManager.Instance.currentBgmName) return;

        bgm.Stop();
        var audioFile = $"res://assets/music/{value}.ogg";
        var bgmusic = (AudioStream)GD.Load(audioFile);
        //bgmusic.Set(true);
        bgm.Stream = bgmusic;
        bgm.Play();
        GlobalManager.Instance.currentBgmName = value;
    }

    // 切换环境音效
    public void ChangeENV(string value)
    {
        if (value == GlobalManager.Instance.currentEnvName && env.Playing) return;

        env.Stop();
        if (value == "") return;

        var audioFile = $"res://assets/sounds/amb/{value}.ogg";
        var envmusic = (AudioStream)GD.Load(audioFile);
        // envmusic.SetLoop(true);
        env.Stream = envmusic;
        env.Play();
        GlobalManager.Instance.currentEnvName = value;
    }

    // 获得当前地图的类型
    private string GetLevelType()
    {
        return currentLevel.Get("type").ToString();
    }

    // 打开副本进入UI
    public void OpenWorldMap()
    {
        switch (GlobalManager.Instance.state.worldMapName)
        {
            case "Lorien":
                var w = GD.Load<PackedScene>("res://scenes/worldmap/Lorien.tscn").Instantiate();
                ui.AddChild(w);
                break;
        }

        currentLevel.Call("ResetPlayerPosition");
    }

    // 进入地下城1 - 加载loading
    public void EnterDungeon1()
    {
        loading.EnterDungeon();
    }

    // 进入地下城2 - loading显示一半开始加载场景
    public void EnterDungeon2()
    {
        GlobalManager.Instance.main.player.GetParent().RemoveChild(player);
        var children = levels.GetChildren();
        if (children.Count > 0)
        {
            (children[0]).QueueFree();
        }

        GlobalManager.Instance.mapType = "dungeon";
        currentLevel = GlobalManager.Instance.selectDungeonScene.Instantiate();
        levels.AddChild(currentLevel);
    }

    // 打开状态栏
    public void OnOpenStatus()
    {
        status.Visible = !status.Visible;
    }

    // 打开背包
    public void OnOpenBag()
    {
        bag.Visible = !bag.Visible;
    }

    // 打开仓库
    public void OnOpenStorate()
    {
        storate.Visible = !storate.Visible;
    }

    // 打开技能面板
    public void OnOpenSkill()
    {
        skill.Visible = !skill.Visible;
    }

    // 显示技能tip
    public void OnShowToolTipSkill(int id, int lv, Vector2 offsetPos)
    {
        toolTipSkill.Set("id", id);
        toolTipSkill.Set("lv", lv);
        toolTipSkill.Set("offsetPos", offsetPos);
        toolTipSkill.Call("InitData");
        toolTipSkill.Visible = true;
    }

    // 隐藏技能tip
    public void OnHideToolTipSkill()
    {
        toolTipSkill.Visible = false;
    }

    // 显示装备tip
    public void OnShowToolTipEquip(string origin, string slot, int index, Vector2 offsetPos)
    {
        toolTipEquip.Set("origin", origin);
        toolTipEquip.Set("slot", slot);
        toolTipEquip.Set("slotIndex", index);
        toolTipEquip.Set("offsetPos", offsetPos);
        toolTipEquip.Call("InitData");
        toolTipEquip.Visible = true;
    }

    // 隐藏装备tip
    public void OnHideToolTipEquip()
    {
        toolTipEquip.Visible = false;
    }

    // ESC按键行为
    public void OnUiCancel()
    {
        if (!optionMenu.Visible)
        {
            optionMenu.Popup();
        }
        else
        {
            optionMenu.Hide();
        }
    }

    // 打开或关闭面板
    public void OnOpenWindow(string wName, string path)
    {
        if (CloseWindow(wName)) return;

        var window = GD.Load<PackedScene>(path).Instantiate<Control>();
        ui.AddChild(window);
    }

    // 关闭窗口
    public bool CloseWindow(string uiName)
    {
        bool has = false;
        foreach (Node child in ui.GetChildren())
        {
            if (child.Name == uiName)
            {
                child.QueueFree();
                has = true;
            }
        }
        return has;
    }
}