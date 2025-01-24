using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 设置要遍历的文件夹路径
        //string directoryPath = @"E:\gamedev\monoprj\ET-Godot\Godot\src";  // 请替换为实际路径
        string directoryPath = @"E:\gamedev\monoprj\ET-Godot\Godot\Prefabs";
        // 遍历文件夹中的所有.cs文件
        foreach (var filePath in Directory.GetFiles(directoryPath, " *.cs", SearchOption.AllDirectories))
        {
            // 读取文件内容
            string fileContent = File.ReadAllText(filePath);

            // 检查文件是否包含"namespace ET"
            if (!fileContent.Contains("namespace ET"))
            {
                // 找到第一个"public partial class"的位置
                int classPosition = fileContent.IndexOf("public partial class");

                if (classPosition != -1)
                {
                    // 在"public partial class"之前插入"namespace ET"
                    string newFileContent = fileContent.Insert(classPosition, "namespace ET {\n");

                    // 在文件末尾添加一个"}"
                    newFileContent += "\n}";

                    // 将修改后的内容写回文件
                    File.WriteAllText(filePath, newFileContent);

                    Console.WriteLine($"File modified: {filePath}");
                }
            }
            else
            {
                Console.WriteLine($"Namespace ET already present: {filePath}");
            }
        }
    }
}