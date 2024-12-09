using Godot;
using System.Collections.Generic;

public partial class Start : Control
{
    // Declare onready variables
    private TextureRect loading;
    private ScrollContainer scrollContainer;
    private GridContainer acterList;
    private Panel create;
    private AudioStreamPlayer clickSound;
    private AudioStreamPlayer selectSound;

    // Declare select_data dictionary
    private Godot.Collections.Dictionary<string, Variant> selectData = new ();
    public override void _Ready()
    {
        loading = GetNode<TextureRect>("Loading");
        scrollContainer = GetNode<ScrollContainer>("SelectCharacter/ScrollContainer");
        acterList = GetNode<GridContainer>("SelectCharacter/ScrollContainer/GridContainer");
        create = GetNode<Panel>("CharacterCreate");
        clickSound = GetNode<AudioStreamPlayer>("clickSound");
        selectSound = GetNode<AudioStreamPlayer>("selectSound");

      // loading.Visible = true;
        create.Visible = false;
        scrollContainer.GetVScrollBar().Step = scrollContainer.Size.Y / 2;
        GetRoleList();
    }

    // Start Game
    private void OnStartBtnPressed()
    {
        clickSound.Play();
        if (selectData.Count == 0)
        {
            return;
        }

        ArchiveManager.Instance.data = selectData;
        ArchiveManager.Instance.InitData();
        foreach (Node child in GetChildren())
        {
                child.QueueFree();
        }
        GetTree().ChangeSceneToFile("res://Main.tscn");
    }
    // Close Loading
    private void OnCloseLoading()
    {
        loading.Visible = false;
    }

    // Quit Game
    private void OnQuitGame()
    {
        GetTree().Quit();
    }

    // Create Character
    private void OnCreateBtnPressed()
    {
        create.Visible = true;
    }

    // Toggle character selection
    public void OnActerToggled(bool buttonPressed, int index)
    {
        var btn = GetActer(index);
        selectData.Clear();

        if (btn.Get("data").ToString() == null)
        {
           return;
        }

        btn.GetNode<TextureRect>("select").Visible = buttonPressed;

        if (buttonPressed)
        {
            btn.GetNode<AnimatedSprite2D>("bottom").Set("frame", 1);
            selectSound.Play();
           selectData = (Godot.Collections.Dictionary<string, Variant>)btn.Get("data");
        }
        else
        {
            btn.GetNode<TextureRect>("bottom").Set("frame", 0);
        }
    }

    // Get acter button
    private TextureButton GetActer(int index)
    {
        var btn = acterList.GetNode<TextureButton>("acter" + index.ToString());
        return btn;
    }

    // Get the role list from ArchiveManager
    private void GetRoleList()
    {
       var list = ArchiveManager.Instance.GetRoleList();

        for (int i = 0; i < list.Count; i++)
        {
            var btn = GetActer(i + 1);
            
            btn.Set("data", list[i]);
            btn.Call("CreateRole");
        }
    }
}