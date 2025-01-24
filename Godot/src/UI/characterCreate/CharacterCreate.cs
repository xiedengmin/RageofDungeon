using Godot;
using System;
namespace ET {
public partial class CharacterCreate : Panel
{
    private Sprite2D cutSwordman;
    private Sprite2D cutFighter;
    private Sprite2D cutGunner;
    private Sprite2D cutMage;
    private Sprite2D cutPriest;

    private TextureButton swordmanBtn;
    private TextureButton fighterBtn;
    private TextureButton gunnerBtn;
    private TextureButton mageBtn;
    private TextureButton priestBtn;

    private Sprite2D jobTitle;
    private Sprite2D jobHard;
    private Sprite2D jobDes;

    public Tween tween;
    private AudioStreamPlayer clickSound;

    private Panel createWindow;
    private TextEdit nameText;
    private Label tipLabel;

    private bool isInt = true;
    private string selectJob = "";

    public override void _Ready()
    {
        cutSwordman = GetNode<Sprite2D>("cutscene_swordman");
        cutFighter = GetNode<Sprite2D>("cutscene_fighter");
        cutGunner = GetNode<Sprite2D>("cutscene_gunner");
        cutMage = GetNode<Sprite2D>("cutscene_mage");
        cutPriest = GetNode<Sprite2D>("cutscene_priest");

        swordmanBtn = GetNode<TextureButton>("swordmanBtn");
        fighterBtn = GetNode<TextureButton>("fighterBtn");
        gunnerBtn = GetNode<TextureButton>("gunnerBtn");
        mageBtn = GetNode<TextureButton>("mageBtn");
        priestBtn = GetNode<TextureButton>("priestBtn");

        jobTitle = GetNode<Sprite2D>("job_title");
        jobHard = GetNode<Sprite2D>("job_hard");
        jobDes = GetNode<Sprite2D>("job_des");

        tween = GetTree().CreateTween();
        clickSound = GetNode<AudioStreamPlayer>("clickSound");

        createWindow = GetNode<Panel>("createWindow");
        nameText = GetNode<TextEdit>("createWindow/nameText");
        tipLabel = GetNode<Label>("createWindow/tipLabel");

        swordmanBtn.ButtonPressed = true;
        createWindow.Visible = false;

        ArchiveManager.Instance.Connect("RoleCreateOk", new Callable(this, nameof(OnRoleCreateOk)));
    }

    private void OnCreateBtnPressed()
    {
        createWindow.Visible = true;
    }

    private void OnBackBtnPressed()
    {
        Visible = false;
    }

    private void OnSwordmanBtnToggled(bool buttonPressed)
    {
        swordmanBtn.Disabled = buttonPressed;
        ChangeCutscene(true, false, false, false, false);
        jobTitle.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/46.png");
        jobHard.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/52.png");
        jobDes.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/60.png");

        if (!isInt)
            PlayBtnSound(buttonPressed);
        else
            isInt = false;

        selectJob = GLOBALS_TYPE.SWORDMAN;
    }

    private void OnFighterBtnToggled(bool buttonPressed)
    {
        fighterBtn.Disabled = buttonPressed;
        ChangeCutscene(false, true, false, false, false);
        jobTitle.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/47.png");
        jobHard.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/53.png");
        jobDes.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/61.png");
        PlayBtnSound(buttonPressed);
        selectJob = GLOBALS_TYPE.FIGHTER;
    }

    private void OnGunnerBtnToggled(bool buttonPressed)
    {
        gunnerBtn.Disabled = buttonPressed;
        ChangeCutscene(false, false, true, false, false);
        jobTitle.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/48.png");
        jobHard.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/55.png");
        jobDes.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/62.png");
        PlayBtnSound(buttonPressed);
        selectJob = GLOBALS_TYPE.GUNNER;
    }

    private void OnMageBtnToggled(bool buttonPressed)
    {
        mageBtn.Disabled = buttonPressed;
        ChangeCutscene(false, false, false, true, false);
        jobTitle.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/49.png");
        jobHard.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/56.png");
        jobDes.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/63.png");
        PlayBtnSound(buttonPressed);
        selectJob = GLOBALS_TYPE.MAGE;
    }

    private void OnPriestBtnToggled(bool buttonPressed)
    {
        priestBtn.Disabled = buttonPressed;
        ChangeCutscene(false, false, false, false, true);
        jobTitle.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/50.png");
        jobHard.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/57.png");
        jobDes.Texture = (Texture2D)ResourceLoader.Load("res://assets/images/charactercreate/64.png");
        PlayBtnSound(buttonPressed);
        selectJob = GLOBALS_TYPE.PRIEST;
    }

    private void ChangeCutscene(bool value1, bool value2, bool value3, bool value4, bool value5)
    {
        cutSwordman.Visible = value1;
        cutFighter.Visible = value2;
        cutGunner.Visible = value3;
        cutMage.Visible = value4;
        cutPriest.Visible = value5;

        if (tween != null)
        {
            tween.Kill();
            tween = null;
        }

        tween = GetTree().CreateTween();

        if (value1)
            tween.TweenProperty(cutSwordman, "position", new Vector2(257, 241), 1);
        else if (value2)
            tween.TweenProperty(cutFighter, "position", new Vector2(-200, 299), 1);
        else if (value3)
            tween.TweenProperty(cutGunner, "position", new Vector2(257, 241), 1);
        else if (value4)
            tween.TweenProperty(cutMage, "position", new Vector2(257, 241), 1);
        else if (value5)
            tween.TweenProperty(cutPriest, "position", new Vector2(257, 241), 1);

        tween.Play();
    }

    private void PlayBtnSound(bool value)
    {
        if (value)
            clickSound.Play();
    }

    private void OnOkBtnPressed()
    {
        int length = Utils.GetStringLength(nameText.Text);

        if (length > 13)
        {
            tipLabel.Text = "超过角色名最大长度";
            tipLabel.Visible = true;
            return;
        }

        if (ArchiveManager.Instance.CheckName(nameText.Text))
        {
            ArchiveManager.Instance.CreateRole(nameText.Text, selectJob);
        }
        else
        {
            tipLabel.Visible = true;
            tipLabel.Text = "角色名重复";
        }
    }

    private void OnCancelBtnPressed()
    {
        createWindow.Visible = false;
    }

    private void OnRoleCreateOk()
    {
        GD.Print("角色创建成功");
        nameText.Text = "";
        tipLabel.Text = "";
        createWindow.Visible = false;
        Visible = false;
        GetParent().Call("get_role_list");
    }
}
}