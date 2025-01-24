using Godot;
using System;
using System.Text.Json; // 使用C#的JSON库
using System.Collections.Generic; // 用于存储数据

namespace ET {
public partial class BaseConfig : Node
{

    // 数据列表
    public Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>> data = new();

    // 加载 JSON 数据
    public void LoadJson(string filePath)
    {
        // 打开文件进行读取
        using (var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read))
        {
            // 将文件内容读取为文本
            var jsonText = file.GetAsText();
            //  data = (Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>)jsonText;
            // 解析JSON并存储数据
            //  data = JsonSerializer.Deserialize<Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>>(jsonText);
            var jsonObject = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonText);
            // 转换为 Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>
            var godotArray = new Godot.Collections.Array<Godot.Collections.Dictionary<string, Variant>>();

            foreach (var entry in jsonObject)
            {
                var godotDict = new Godot.Collections.Dictionary<string, Variant>();
                foreach (var kvp in entry)
                {
                    // 将数字类型转换为具体的 Variant 类型，避免解析出错误的数字类型
                    if (kvp.Value is JsonElement jsonElement)
                    {
                        if (jsonElement.ValueKind == JsonValueKind.Number)
                        {
                            // 尝试将数字转换为 int 或 float
                            if (jsonElement.TryGetInt32(out int intValue))
                            {
                                godotDict[kvp.Key] = intValue;
                            }
                            else if (jsonElement.TryGetDouble(out double doubleValue))
                            {
                                godotDict[kvp.Key] = (float)doubleValue; // Godot 使用 float 而不是 double
                            }
                        }
                        else if (jsonElement.ValueKind == JsonValueKind.String)
                        {
                            godotDict[kvp.Key] = jsonElement.GetString();
                        }
                    }
                    else
                    {
                        // 非 JsonElement 直接赋值
                        godotDict[kvp.Key] = Variant.From(kvp.Value);
                    }
                }
                godotArray.Add(godotDict);
            }
            data = godotArray;
            // 文件自动关闭，因为使用了using
        }
    }

}
}