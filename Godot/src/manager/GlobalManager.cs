using Godot;
namespace ET
{
    public partial class State : Node
    {
        public NodePath current;
        public NodePath target;
        public NodePath stage;
        public NodePath worldMapName;
    }
    public partial class GlobalManager : Node
    {
        [Signal]
        public delegate void ChangeDungeon1EventHandler();
        private static GlobalManager _instance;
        public static GlobalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalManager();
                }
                return _instance;
            }
        }
        public State state = new();
        // 拿到主关卡的引用
        public Main main;
        // 当前背景音乐名字
        public string currentBgmName = "";
        // 当前环境音效名字
        public string currentEnvName = "";
        // 当前选择的地下城的名字
        public string selectDungeon = "";
        // 当前选择的地下城的场景
        public PackedScene selectDungeonScene = null;
        // 当前在城镇还是地下城 town dungeon
        public string mapType = "";

        // 门的类型
        public enum TYPE
        {
            TOMAP,
            TOLEVEL,
            TOENTRANCE
        }

        // 装备插槽类型
        public enum SLOTTYPE
        {
            Shoulder = 0,
            JACKET,
            PANTS,
            SHOES,
            BELT,
            WRIST,
            AMULET,
            RING,
            WEAPON,
            TITLE
        }

        public override void _Ready()
        {
            // 准备函数，当前没有任何逻辑
        }

        // 切换地图
        public void ChangeLevel()
        {
            _instance.main.ChangeLevel();
        }

        // 切换关卡
        public void ChangeStage()
        {
            ((dynamic)_instance.main.currentLevel).ChangeStage();
        }

        public void OpenWorldMap()
        {
            _instance.main.OpenWorldMap();
        }

        // 使关卡的门可用
        private void SetDoorToUse()
        {
            EmitSignal(nameof(SetDoorToUse), true);
        }

        // 切换副本
        public void ChangeDungeon()
        {
            EmitSignal(nameof(ChangeDungeon1));
        }
    }
}