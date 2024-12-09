using Godot;
using System;
using System.Collections.Generic;
public partial class InputManager : Node
{
    // 定义技能的按键组合和优先等级
    private Dictionary<string, (List<string> KeyCombo, int Priority)> skills = new Dictionary<string, (List<string>, int)>
    {
         { "LeftDash", (new List<string> { "ui_left", "ui_left" }, 1) },
         { "RightDash", (new List<string> { "ui_right", "ui_right" }, 1) },
        { "Skill_A", (new List<string> { "ui_left", "ui_right" }, 1) },
        { "Skill_B", (new List<string> { "ui_left", "ui_right", "attack" }, 2) },
        { "Skill_C", (new List<string> { "ui_up", "ui_down" }, 1) },
        { "Skill_D", (new List<string> { "ui_up", "ui_down", "run" }, 3) }
    };

    // 最近的按键记录队列
    private Queue<string> recentKeys = new Queue<string>();
    private const int MaxKeyHistory = 3;  // 记录最近按键数量的限制
    public string activatedSkill = null;
    // 定义信号
    [Signal] public delegate void OpenStatusEventHandler();
    [Signal] public delegate void OpenBagEventHandler();
    [Signal] public delegate void OpenSkillEventHandler();
    [Signal] public delegate void UiCancelEventHandler();
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InputManager();
            }
            return _instance;
        }
    }
    public override void _Ready()
    {
        // 初始化代码
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_left"))
        {
            // 处理左键按下
        }
        if (@event.IsActionPressed("ui_right"))
        {
            // 处理右键按下
        }
        if (@event.IsActionPressed("ui_up"))
        {
            // 处理上键按下
        }
        if (@event.IsActionPressed("ui_down"))
        {
            // 处理下键按下
        }
        if (@event.IsActionPressed("status"))
        {
            EmitSignal("OpenStatus");
        }
        if (@event.IsActionPressed("bag"))
        {
            EmitSignal("OpenBag");
        }
        if (@event.IsActionPressed("skill"))
        {
            EmitSignal("OpenSkill");
        }
        if (@event.IsActionPressed("ui_cancel"))
        {
            EmitSignal("UiCancel");
        }
    }
    // 获取输入方向
    public Vector2 GetInputDirection()
    {
        float x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        float y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
        return new Vector2(x, y);
    }

    public override void _Process(double delta)
    {
        // 检测按键
        foreach (string key in new[] { "ui_left", "ui_right", "ui_up", "ui_down", "attack", "run" })
        {
            if (Input.IsActionJustPressed(key))
            {
                AddKeyToHistory(key);
                CheckSkills();
            }
        }
    }

    // 将按键添加到最近按键记录中
    private void AddKeyToHistory(string key)
    {
        if (recentKeys.Count >= MaxKeyHistory)
            recentKeys.Dequeue(); // 超出限制时，移除最早的按键

        recentKeys.Enqueue(key);
    }

    // 检查当前的按键组合是否匹配技能
    private void CheckSkills()
    {

        int highestPriority = -1;

        foreach (var skill in skills)
        {
            var (keyCombo, priority) = skill.Value;

            // 检查当前按键记录是否匹配技能组合
            if (IsKeyComboMatch(keyCombo) && priority > highestPriority)
            {
                Instance.activatedSkill = skill.Key;
                highestPriority = priority;
            }
        }

        if (activatedSkill != null)
        {
            GD.Print($"技能触发: {activatedSkill} (优先级: {highestPriority})");
        }
    }

    // 判断当前按键记录是否匹配技能组合
    private bool IsKeyComboMatch(List<string> keyCombo)
    {
        if (recentKeys.Count < keyCombo.Count)
            return false;

        string[] keysArray = recentKeys.ToArray();
        for (int i = 0; i < keyCombo.Count; i++)
        {
            if (keysArray[keysArray.Length - keyCombo.Count + i] != keyCombo[i])
                return false;
        }

        return true;
    }
}