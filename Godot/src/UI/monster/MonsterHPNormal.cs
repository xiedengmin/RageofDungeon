using Godot;

public partial class MonsterHPNormal : Control
{
    [Export] public int singleLayerHP = 100;  // 一层的血量值
    public int totalHP = 700;                 // 总血量
    public int currentHP = 650;               // 当前血量
    public Label hp_layer_num;
    private TextureRect face;
    private TextureRect type;
    private Label nameLabel;
    private Progress progress;

    private MonsterStatus status;

    public override void _Ready()
    {
        face = GetNode<TextureRect>("face");
        type = GetNode<TextureRect>("type");
        nameLabel = GetNode<Label>("nameLabel");
        hp_layer_num = GetNode<Label>("hp_layer_num");
        progress = (Progress)GD.Load<PackedScene>("res://scenes/UI/Progress.tscn").Instantiate();
        progress.hp_layer_num = hp_layer_num;
    }

    public void InitData(MonsterStatus st)
    {
        status = st;
        nameLabel.Text = $"Lv.{status.LV} {status.Name}";
        face.Texture = GD.Load<Texture2D>($"res://assets/images/face/monster/{status.Face}");

        if (status.Category == "human")
        {
            // 如有其他逻辑可以在这里填充
        }

        totalHP = status.MaxHp;
        SetCurrentHP(status.HP);
    }

    public void SetCurrentHP(int value)
    {
        currentHP = value > 0 ? value : 0;
        progress.currentHP = currentHP;
        progress.totalHP = totalHP;
        progress.singleLayerHP = singleLayerHP;
        progress.ShowHPLayer();
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public int CurrentHP
    {
        get => GetCurrentHP();
        set => SetCurrentHP(value);
    }
}
