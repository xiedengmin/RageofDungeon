using Godot;

[Tool]
public partial class cutter: FontFile
{
    private int index = 0;
    
    [Export(PropertyHint.Range, "1, 255")]
    public int StartChar { get; set; } = 48;
    
    [Export]
    public Vector2 GlyphSize { get; set; } = new Vector2(8, 8);
    
    [Export]
    public Texture2D TextureToCut { get; set; } = null;
    
    [Export]
    public float Spacing { get; set; } = 1.0f;
    
    [Export]
    public bool Monospaced { get; set; } = true;

    private int height = 0;

    public  void _Ready()
    {
        height = (int)GlyphSize.Y;
        Update();
    }

    private void ChangeStartChar(int value)
    {
        StartChar = value;
        Update();
    }

    private void ChangeGlyphSize(Vector2 value)
    {
        GlyphSize = value;
        height = (int)GlyphSize.Y;
        Update();
    }

    private void ChangeTexture(Texture2D value)
    {
        TextureToCut = value;
        index = 0;
        if (TextureToCut != null)
        {
            Update();
        }
    }

    private void ChangeSpacing(float value)
    {
        Spacing = value;
        Update();
    }

    private void ChangeMonospaced(bool value)
    {
        Monospaced = value;
        Update();
    }

    private void Update()
    {
        if (TextureToCut != null && GlyphSize.X > 0 && GlyphSize.Y > 0)
        {
            int w = TextureToCut.GetWidth();
            int h = TextureToCut.GetHeight();
            int tx = (int)(w / GlyphSize.X);
            int ty = (int)(h / GlyphSize.Y);

            // Initialize font
            var font = this;
            font.height = (int)GlyphSize.Y;

            for (int i = 0; i < tx; i++)
            {
                var region = new Rect2(i * GlyphSize.X, 0, GlyphSize.X, GlyphSize.Y);
                // Example of adding characters to font (adjust depending on your font handling logic)
                //font.AddChar(StartChar + i, 0, region, Vector2.Zero, GlyphSize.X + Spacing);
            }

            // Add logic for cutting texture if needed
        }
    }
}
