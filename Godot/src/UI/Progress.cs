using Godot;
using System;

public partial class Progress: ColorRect
{
    public int singleLayerHP = 0;  // 一层的血量值
    public int totalHP = 700;                 // 总血量
    public int currentHP = 0;               // 当前血量
    public Label hp_layer_num;
    // 血量颜色数组
    private readonly Color[] hpColors = {
        new Color(222 / 255.0f, 0, 0),
        new Color(255 / 255.0f, 131 / 255.0f, 0),
        new Color(148 / 255.0f, 205 / 255.0f, 0),
        new Color(0, 123 / 255.0f, 205 / 255.0f),
        new Color(139 / 255.0f, 131 / 255.0f, 255 / 255.0f)
    };

    // 第一层
    private Rect2 foregroundRect;
    // 第一层颜色
    private Color foregroundColor;
    // 第二层
    private Rect2 backgroundRect;
    // 第二层颜色
    private Color backgroundColor;

    public override void _Ready()
    {
      
    }

    public void ShowHPLayer()
    {
    

        if (currentHP == 0)
        {
            foregroundRect = new Rect2(0, 0, 0, Size.Y);
            backgroundRect = new Rect2(foregroundRect.Size.X, 0, Size.X - foregroundRect.Size.X, Size.Y);
            hp_layer_num.Visible = false;
        }
        else
        {
            // 计算当前是第几层血
            int layerNum = currentHP / singleLayerHP;

            if (currentHP % singleLayerHP != 0)
            {
                layerNum += 1;
            }

            hp_layer_num.Text = "x " + layerNum.ToString();
            hp_layer_num.Visible = layerNum > 1;

            // 获取前景颜色
            int foregroundColorIndex = (layerNum % hpColors.Length) - 1;
            if (foregroundColorIndex == -1)
            {
                foregroundColorIndex = hpColors.Length - 1;
            }
            foregroundColor = hpColors[foregroundColorIndex];

            // 获取背景颜色
            if (layerNum == 1)
            {
                backgroundColor = Colors.Black;
            }
            else
            {
                int backgroundColorIndex = foregroundColorIndex != 0 ? foregroundColorIndex - 1 : hpColors.Length - 1;
                backgroundColor = hpColors[backgroundColorIndex];
            }

            float length = 1.0f * (currentHP % singleLayerHP) / singleLayerHP;
            if (length == 0)
            {
                length = 1;
            }

            foregroundRect = new Rect2(0, 0, Size.X * length, Size.Y);
            backgroundRect = new Rect2(foregroundRect.Size.X, 0, Size.X - foregroundRect.Size.X, Size.Y);
        }

        QueueRedraw();
    }

    public override void _Draw()
    {
      DrawRect(foregroundRect, foregroundColor);
      DrawRect(backgroundRect, backgroundColor);
   }
}