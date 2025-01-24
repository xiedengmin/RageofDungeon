using Godot;

namespace ET {
public partial class GLOBALS_TYPE //: Object
{
    // Enumeration for monster types
    public enum MONSTERTYPE
    {
        NORMAL,
        ELITE,
        BOSS
    }

    // Character classes
    public const string SWORDMAN = "swordman";   // 鬼剑士
    public const string FIGHTER = "fighter";     // 格斗家
    public const string GUNNER = "gunner";       // 神枪手
    public const string MAGE = "mage";           // 魔法师
    public const string PRIEST = "priest";       // 圣职者

    // Subclasses
    public const string BLADEMASTER = "bladeMaster"; // 剑魂
    public const string SOULBENDER = "soulBender";   // 鬼泣
    public const string BERSERKER = "berserker";     // 狂战士
    public const string ASURA = "asura";             // 阿修罗

    // Icon resource directory prefixes
    public const string ICON_PATH = "res://assets/images/icon/";
    public const string SKILL_ICON_PATH = "res://assets/images/icon/skill/";

    // Slot types
    public const string SLOT_TYPE_BAG = "Bag";            // 格子类型-背包
    public const string SLOT_TYPE_SHORT = "Short";        // 格子类型-快捷栏
    public const string SLOT_TYPE_SHOULDER = "Shoulder";  // 格子类型-肩膀
    public const string SLOT_TYPE_JACKET = "Jacket";      // 格子类型-上衣
    public const string SLOT_TYPE_PANTS = "Pants";        // 格子类型-裤子
    public const string SLOT_TYPE_SHOES = "Shoes";        // 格子类型-鞋
    public const string SLOT_TYPE_BELT = "Belt";          // 格子类型-腰带
    public const string SLOT_TYPE_WRIST = "Wrist";        // 格子类型-手镯
    public const string SLOT_TYPE_AMULET = "Amulet";      // 格子类型-项链
    public const string SLOT_TYPE_RING = "Ring";          // 格子类型-戒指
    public const string SLOT_TYPE_WEAPON = "Weapon";      // 格子类型-武器
    public const string SLOT_TYPE_TITLE = "Title";        // 格子类型-称号
}
}