using Godot;
using System;
using System.Collections.Generic;

namespace ET {
public partial class Worldmap : Control // 修改为你的脚本名称
{
    [Export] public Control buttons;
    [Export] private TextureButton openhell;
    [Export] private TextureButton closehell;

    public override void _Ready()
    {
        GlobalManager.Instance.ChangeDungeon1 += ChangeDungeon;
        buttons = GetNode<Control>("buttons");
        openhell = GetNode<TextureButton>("openHellBtn");
        closehell = GetNode<TextureButton>("closeHellBtn");
        InitSelect();
        closehell.Visible = false;
    }

    private void _on_enterBtn_pressed()
    {
        this.Visible = false;
        QueueFree();
        GlobalManager.Instance.main.EnterDungeon1();
     
    }

    private void _on_backBtn_pressed()
    {
        QueueFree();
    }

    private void _on_openHellBtn_pressed()
    {
        openhell.Visible = false;
        closehell.Visible = true;
    }

    private void _on_closeHellBtn_pressed()
    {
        openhell.Visible = true;
        closehell.Visible = false;
    }

    private void InitSelect()
    {
        var children = buttons.GetChildren();
        int lens = buttons.GetChildCount();
        for (int i = 0; i < lens; i++)
        {
            if (i == 0)
            {
              (children[i] as Worldmap_Button).OnNormalBtnPressed(); 
            }
        }
    }

    private void ChangeDungeon()
    {
        var children = buttons.GetChildren();
        foreach (Worldmap_Button btn in children)
        {
            if (btn.Name != GlobalManager.Instance.selectDungeon)
            {
                btn.Reset2Normal();
            }
        }
    }
}

}