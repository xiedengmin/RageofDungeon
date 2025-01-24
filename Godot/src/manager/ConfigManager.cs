using Godot;

namespace ET {
public partial class ConfigManager : Node
{
    // 经验配置
    public ExptableConfig exptableConfig;
    // 职业基础数据
    public JobBaseConfig jobBaseConfig;
    // 职业升级加成数据
    public JobUpConfig jobUpConfig;
    // 技能配置
    public SkillConfigProxy skillConfigProxy;
    // 装备配置
    public EquipConfigProxy equipConfigProxy;
    // 怪物配置
    public MonsterConfig monsterConfig;
    public static ConfigManager _instance;
    public static ConfigManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigManager();
            }
            return _instance;
        }
    }
    public override void _Ready()
    {
        if (_instance == null)
        {
            _instance = new ConfigManager();
        }
        _instance.exptableConfig = new ExptableConfig();
        _instance.jobBaseConfig = new JobBaseConfig();
        _instance.jobUpConfig = new JobUpConfig();
        _instance.skillConfigProxy = new SkillConfigProxy();
        _instance.equipConfigProxy = new EquipConfigProxy();
        _instance.monsterConfig = new MonsterConfig();

    }
}
}