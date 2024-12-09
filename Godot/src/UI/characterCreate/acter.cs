using Godot;
using System;

public partial class acter : TextureButton
{
    private readonly Vector2 swordmanPosition = new Vector2(52, 96);
    private readonly Vector2 fighterPosition = new Vector2(62, 153);

    [Export] private TextureRect focus;
    [Export] private TextureRect select;
    [Export] private Label nameLabel;
    [Export] private Label jobLabel;
    [Export] private AnimatedSprite2D bottom;

    private Godot.Collections.Dictionary<string, Variant> data;
    private Sprite2D character;

    public override void _Ready()
    {
        focus = GetNode<TextureRect>(nameof(focus));
        select = GetNode<TextureRect>(nameof(select));
        nameLabel = GetNode<Label>(nameof(nameLabel));
        jobLabel = GetNode<Label>(nameof(jobLabel));
        focus.Visible = false;
        select.Visible = false;
        if (data == null)
        {
            nameLabel.Visible = false;
            jobLabel.Visible = false;
        }
    }

    private void OnActerMouseEntered()
    {
        if (data == null)
            return;

        focus.Visible = true;
    }

    private void OnActerMouseExited()
    {
        focus.Visible = false;
    }

    private void CreateRole()
    {
        var _role = (Godot.Collections.Dictionary<string, Variant>)data["role"];
        var _job = _role["job"].ToString();
        switch (_job)
        {
            case GLOBALS_TYPE.SWORDMAN:
                character = (Sprite2D)GD.Load<PackedScene>("res://Prefabs/role/character/Swordman_show.tscn").Instantiate();
                character.Position = swordmanPosition;
                break;
            case GLOBALS_TYPE.FIGHTER:
                character = (Sprite2D)GD.Load<PackedScene>("res://Prefabs/role/character/Fighter_show.tscn").Instantiate();
                character.Position = fighterPosition;
                break;
        }
        AddChild(character);
        var lv = _role["lv"].ToString();
        var name = _role["name"].ToString();
        nameLabel.Text = "Lv." + lv + " " + name;
        nameLabel.Visible = true;
        jobLabel.Text = Utils.GetExByJob(_job);
        jobLabel.Visible = true;
    }
}