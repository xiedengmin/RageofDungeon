using Godot;
using System;

public partial class Skillbuy_Item : TextureButton
{
    // 名字
    [Export] private Label _nameLabel;
    // 图标
    [Export] private TextureRect _icon;
    // 前置技能提示
    [Export] private TextureRect _notip;
    // 人物等级需求提示
    [Export] private TextureRect _lvtip;
    // 等级需求文本
    [Export] private Label _lvTip;
    // SP需求
    [Export] private Label _spLabel;
    [Export] private NinePatchRect _select;
    // 技能不能学时显示红色图片
    [Export] private ColorRect _redColor;

    // 技能配置表
    private SkillConfig _skl;
    // 技能当前要学习的等级
    private int _lv;
    // 是否可以学习
    private bool _canLearn = true;

    public override void _Ready()
    {
        _select.Visible = false;
        InitData();
    }

    private void InitData()
    {
        _nameLabel.Text = _skl.Name;
        var iconTexture = (Texture2D)GD.Load(GLOBALS_TYPE.SKILL_ICON_PATH + _skl.icon);
        _icon.Texture = iconTexture;
        _spLabel.Text = _skl.purchaseCost.ToString();

        _notip.Visible = false;
        // 学习1级技能的等级需求
        int cLv = _skl.requiredLevel;
        // 学习当前等级的需求
        int nLv = cLv + (_lv - 1) * _skl.requiredLevelRange;

        // 检查SP
        if (_skl.purchaseCost > DataManager.Instance.roleData.sp)
        {
            _spLabel.Set("custom_colors/font_color", new Color("ff3232"));
            _canLearn = false;
        }
        else
        {
            _spLabel.Set("custom_colors/font_color", new Color("ffffff"));
        }

        // 人物等级
        int roleLv = DataManager.Instance.roleData.lv;
        if (nLv > roleLv)
        {
            _canLearn = false;
            _lvTip.Text = nLv.ToString();
            _lvtip.Visible = true;
            _lvTip.Visible = true;
        }
        else
        {
            _lvtip.Visible = false;
            _lvTip.Visible = false;
        }

        // 检查前置技能
        bool preCheck = true;
        var preSkillArr = _skl.preRequiredSkill;
        int length = preSkillArr.Count / 2;
        for (int i = 0; i < length; i++)
        {
            int preSklLv = DataManager.Instance.GetSkillLv(preSkillArr[i * 2]);
            if (preSklLv <(int) preSkillArr[i * 2 + 1])
            {
                preCheck = false;
                break;
            }
        }

        if (preCheck)
        {
            _notip.Visible = false;
        }
        else
        {
            _notip.Visible = true;
            _canLearn = false;
        }

        if (!_canLearn)
        {
            _nameLabel.Set("custom_colors/font_color", new Color("ff3232"));
            _redColor.Visible = true;
        }
        else
        {
            _nameLabel.Set("custom_colors/font_color", new Color("ffffff"));
            _redColor.Visible = false;
        }
    }

    private void OnIconMouseEntered()
    {
        GlobalManager.Instance.main.OnShowToolTipSkill(_skl.ID, _lv, GetLocalMousePosition());
    }

    private void OnIconMouseExited()
    {
        GlobalManager.Instance.main.OnHideToolTipSkill();
    }
}