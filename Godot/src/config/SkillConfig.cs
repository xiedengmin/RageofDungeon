using Godot;
using System;
using System.Collections.Generic;

public partial class SkillConfig : Node
{
    public int ID { get; set; } = 0;

    public string name { get; set; } = "";
    // 英文名字
    public string name2 { get; set; } = "";
    // 描述
    public string explain { get; set; } = "";
    // SP 消耗
    public int purchaseCost { get; set; } = 0;
    // 可偷学
    public int steelLearningSkill { get; set; } = 0;
    // 学习等级
    public int requiredLevel { get; set; } = 1;
    // 跳级需求，技能提升等级需要的人物等级
    public int requiredLevelRange { get; set; } = 1;
    // 前置技能
    public  Godot.Collections.Array<Variant> preRequiredSkill { get; set; } = new ();
    // 技能类型 被动 主动
    public string type { get; set; } = "";
    // 技能栏位置
    public int skillClass { get; set; } = 0;
    // 等级上限
    public int maximumLevel { get; set; } = 0;
    // 职业对应的等级上限
    public  Godot.Collections.Array<Variant> growtypeMaximumLevel { get; set; } = new ();
    // 职业分类
    public int skillFitnessGrowtype { get; set; } = 0;
    // 是否是觉醒技能
    public int skillFitnessSecondGrowtype { get; set; } = 0;
    // 耐久度下降率
    public int durabilityDecreaseRate { get; set; } = 0;
    // 武器效果类型
    public string weaponEffectType { get; set; } = "";
    // 屏幕震动
    public string shakeScreen { get; set; } = "";

    // 图标
    public string icon { get; set; } = "";
    // 指令
    public string command { get; set; } = "";
    // 技能指挥优势
    public  Godot.Collections.Array<Variant> skillCommandAdvantage { get; set; } = new ();
    // 消耗 MP
    public  Godot.Collections.Array<Variant> consumeMP { get; set; } = new ();
    // 施法时间
    public  Godot.Collections.Array<Variant> castingTime { get; set; } = new();
    // 冷却时间
    public  Godot.Collections.Array<Variant> coolTime { get; set; } = new ();
    // 静态数据
    public  Godot.Collections.Array<Variant> staticData { get; set; } = new ();
    // 等级信息
    public  Godot.Collections.Array<Godot.Collections.Array<Variant>> levelInfo { get; set; } = new();
    // 指令说明
    public string commandKeyExplain { get; set; } = "";
    // 技能伤害描述
    public string levelProperty { get; set; } = "";
    // 技能伤害描述参数
    public Godot.Collections.Array<Godot.Collections.Array<float>> levelPropertyValue { get; set; } = new ();
    // 消耗无色小晶块
    public int consumeItem { get; set; } = 0;
    // 技能预加载图像
    public string skillPreloadingImage { get; set; } = "";
    // 特殊升级
    public string specialLevelUp { get; set; } = "";
}