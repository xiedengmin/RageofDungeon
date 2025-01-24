using Godot;

namespace ET {
public partial class Worldmap_Button : Control
{
    private const int MinHard = 0;
    private const int MaxHard = 3;

    [Export] public PackedScene Dungeon;

    private TextureRect normalbg;
    private TextureButton normalbtn;
    private TextureRect selectbg;
    private TextureButton selectBtn;
    private TextureRect maoxian;
    private TextureRect yongshi;
    private TextureRect king;
    private TextureButton leftbtn;
    private TextureButton rightbtn;

    private int index = 0;

    public override void _Ready()
    {
        normalbg = GetNode<TextureRect>("normalbg");
        normalbtn = GetNode<TextureButton>("normalBtn");
        selectbg = GetNode<TextureRect>("selectbg");
        selectBtn = GetNode<TextureButton>("selectBtn");
        maoxian = GetNode<TextureRect>("maoxian");
        yongshi = GetNode<TextureRect>("yongshi");
        king = GetNode<TextureRect>("king");
        leftbtn = GetNode<TextureButton>("leftBtn");
        rightbtn = GetNode<TextureButton>("rightBtn");

        Reset2Normal();
    }

    public void OnNormalBtnPressed()
    {
        normalbg.Visible = false;
        normalbtn.Visible = false;
        selectBtn.Visible = true;
        selectbg.Visible = true;
        rightbtn.Visible = true;
        index = 0;
        GlobalManager.Instance.selectDungeon = Name;
        GlobalManager.Instance.selectDungeonScene = Dungeon;
        GlobalManager.Instance.ChangeDungeon();
    }

    public void OnNormalBtnMouseEntered()
    {
        normalbg.Visible = true;
    }

    public void OnNormalBtnMouseExited()
    {
        normalbg.Visible = false;
    }

    public void OnLeftBtnPressed()
    {
        index -= 1;
        if (index <= MinHard)
            leftbtn.Visible = false;
        if (index != MaxHard)
            rightbtn.Visible = true;
        ChangeHard();
    }

    public void OnRightBtnPressed()
    {
        index += 1;
        if (index >= MaxHard)
            rightbtn.Visible = false;
        if (index != MinHard)
            leftbtn.Visible = true;
        ChangeHard();
    }

    public void OnEnterMap()
    {
        // Replace with function body.
    }

    public void ChangeHard()
    {
        switch (index)
        {
            case 0:
                SetHardImage(false, false, false);
                break;
            case 1:
                SetHardImage(true, false, false);
                break;
            case 2:
                SetHardImage(false, true, false);
                break;
            case 3:
                SetHardImage(false, false, true);
                break;
        }
    }

    public void SetHardImage(bool value1, bool value2, bool value3)
    {
        maoxian.Visible = value1;
        yongshi.Visible = value2;
        king.Visible = value3;
    }

    public void Reset2Normal()
    {
        normalbg.Visible = false;
        normalbtn.Visible = true;
        selectbg.Visible = false;
        selectBtn.Visible = false;
        maoxian.Visible = false;
        yongshi.Visible = false;
        king.Visible = false;
        leftbtn.Visible = false;
        rightbtn.Visible = false;
    }
}
}