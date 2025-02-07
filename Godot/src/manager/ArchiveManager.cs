using Godot;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ET
{
    public partial class ArchiveManager : Node
    {
        [Signal]
        public delegate void RoleCreateOkEventHandler();

        private const string SAVE_DIR = "user://saves/";
        private string savePath = $"{SAVE_DIR}%s.dat";
        private static ArchiveManager _instance;
        public static ArchiveManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ArchiveManager();
                }
                return _instance;
            }
        }
        // 角色数据
        public Godot.Collections.Dictionary<string, Variant> roleData = new Godot.Collections.Dictionary<string, Variant> {
        { "name", "阿拉德" },
        { "job", "swordman" },
        { "lv", 12 }
    };
        // 技能数据
        private Godot.Collections.Array skill = new();
        // 装备数据
        private Godot.Collections.Dictionary<string, Variant> equipData = new Godot.Collections.Dictionary<string, Variant>();

        public Godot.Collections.Dictionary<string, Variant> data = new();

        public override void _Ready()
        {
        }

        // 数据保存到本地
        public void SaveData()
        {
            var dir = DirAccess.Open(SAVE_DIR);
            if (dir == null)
            {
                DirAccess.MakeDirAbsolute(SAVE_DIR);
            }

            var saveGame = FileAccess.OpenEncryptedWithPass(string.Format(savePath, roleData["name"]), FileAccess.ModeFlags.Write, "DNFyU9w18");
            if (saveGame != null)
            {
                saveGame.StoreVar(data);
                saveGame.Dispose();
            }
        }

        // 从本地加载数据
        public void LoadData()
        {
            string path = string.Format(savePath, roleData["name"]);
            var saveGame = FileAccess.Open(path, FileAccess.ModeFlags.Read);
            if (saveGame == null)
            {
                return;
            }

            var lddata = FileAccess.OpenEncryptedWithPass(path, FileAccess.ModeFlags.Read, "DNFyU9w18");
            if (lddata != null)
            {
                data = (Godot.Collections.Dictionary<string, Variant>)saveGame.GetVar();
            }
            saveGame.Dispose();
        }

        public void SetEquipData(string key, Variant value)
        {
            equipData[key] = value;
        }

        // 获取全部的角色数据
        public List<Godot.Collections.Dictionary<string, Variant>> GetRoleList()
        {
            List<Godot.Collections.Dictionary<string, Variant>> list = new();
            var nameList = new List<string>();

            var dir = DirAccess.Open(SAVE_DIR);
            if (dir != null)
            {
                dir.ListDirBegin();
                var fileName = dir.GetNext();
                while (fileName != "")
                {
                    if (!dir.CurrentIsDir())
                    {
                        nameList.Add(fileName);
                    }
                    fileName = dir.GetNext();
                }
                dir.ListDirEnd();
            }

            foreach (var name in nameList)
            {
                string path = SAVE_DIR + name;
                if (!FileAccess.FileExists(path))
                    continue;

                var saveGame = FileAccess.OpenEncryptedWithPass(path, FileAccess.ModeFlags.Read, "DNFyU9w18");
                if (saveGame != null)
                {
                    var fileData = saveGame.GetVar();
                    list.Add((Godot.Collections.Dictionary<string, Variant>)fileData);
                    saveGame.Dispose();
                }
            }

            return list;
        }

        // 检查名字
        public bool CheckName(string name)
        {
            bool result = true;
            var dir = DirAccess.Open(SAVE_DIR);
            if (dir != null)
            {
                dir.ListDirBegin();
                var fileName = dir.GetNext();
                while (fileName != "")
                {
                    if (!dir.CurrentIsDir() && fileName.Contains(name))
                    {
                        result = false;
                    }
                    fileName = dir.GetNext();
                }
                dir.ListDirEnd();
            }

            return result;
        }

        // 创建角色
        public void CreateRole(string name, string job)
        {
            roleData["name"] = name;
            roleData["job_base"] = job;
            roleData["job"] = job;
            roleData["lv"] = 1;
            roleData["expe"] = 0;
            roleData["sp"] = 0;
            roleData["gold"] = 0;
            roleData["aweek"] = 0;
            data["role"] = roleData;

            skill.Clear();
            for (int i = 0; i < 5; i++)
            {
                var temp = new Godot.Collections.Array<Variant>(new Variant[42]);
                skill.Add(temp);
            }
            data["skill"] = skill;

            var sklShort = new Godot.Collections.Array<Variant>(new Variant[12]);
            switch (job)
            {
                case "SWORDMAN":
                    sklShort[6] = new Godot.Collections.Dictionary<string, Variant> { { "id", 1003 }, { "lv", 1 } };
                    sklShort[7] = new Godot.Collections.Dictionary<string, Variant> { { "id", 1018 }, { "lv", 1 } };
                    break;
                    // 其他职业
            }
            data["skillShort"] = sklShort;

            Godot.Collections.Array<Variant> inventory = new();
            for (int i = 0; i < 5; i++)
            {
                var temp = new Godot.Collections.Array<Variant>(new Variant[60]);
                inventory.Add(temp);
            }
            data["inventory"] = inventory;

            var invShort = new Godot.Collections.Array<Variant>(new Variant[6]);
            data["invShort"] = invShort;

            Godot.Collections.Dictionary<string, Variant> equipmentData = new Godot.Collections.Dictionary<string, Variant>
        {
            { "Shoulder", "" },
            { "Jacket", new Godot.Collections.Dictionary<string, Variant> { { "id", 10004 } } },
            { "Pants", new Godot.Collections.Dictionary<string, Variant> { { "id", 10005 } } },
            { "Shoes", "" },
            { "Belt", "" },
            { "Wrist", "" },
            { "Amulet", "" },
            { "Ring", "" },
            { "Weapon", new Godot.Collections.Dictionary<string, Variant> { { "id", 10001 } } },
            { "Title", "" }
        };
            data["equip"] = equipmentData;

            var storate = new Godot.Collections.Array<Variant>(new Variant[10]);
            data["storate"] = storate;

            SaveData();
            EmitSignal("RoleCreateOk");
        }

        // 进游戏时初始化数据
        public void InitData()
        {
            var _role = (Godot.Collections.Dictionary<string, Variant>)data["role"];
            DataManager.Instance.InitData();
            DataManager.Instance.roleData.name = _role["name"].ToString();
            DataManager.Instance.roleData.jobBase = _role["job_base"].ToString();
            DataManager.Instance.roleData.job = (string)_role["job"];
            DataManager.Instance.roleData.lv = (int)(_role["lv"]);
            DataManager.Instance.roleData.expe = (int)(_role["expe"]);
            DataManager.Instance.roleData.sp = (int)(_role["sp"]);
            DataManager.Instance.roleData.gold = (int)(_role["gold"]);
            DataManager.Instance.roleData.aweek = (int)(_role["aweek"]);

            DataManager.Instance.skillData.data = (Godot.Collections.Array<Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>>)data["skill"];
            DataManager.Instance.skillShortcutData.data = (Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>)data["skillShort"];
            DataManager.Instance.invData.data = (Godot.Collections.Array<Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>>)data["inventory"];
            DataManager.Instance.invShortcutData.data = (Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>)data["invShort"];
            DataManager.Instance.equipData.equipmentData = (Godot.Collections.Dictionary<string, Variant>)data["equip"];
            DataManager.Instance.storateData.data = (Godot.Collections.Array<Variant>)data["storate"];


        }
    }

}