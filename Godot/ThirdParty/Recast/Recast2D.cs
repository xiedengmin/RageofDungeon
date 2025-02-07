using Godot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

public class Recast2D
{
   public static void RecastFind(string filePath, Vector3 start3, Vector3 end3, List<Vector3> path)
    {

        //filePath = filePath.Replace("_", "/");
        filePath = "town_Elvengard_stage01";
        string fileContent = File.ReadAllText(Path.Combine("../Config/Recast/", filePath));

        // 使用正则表达式提取轮廓数据
        string pattern = @"PackedVector2Array\(([^)]+)\)";
        MatchCollection matches = Regex.Matches(fileContent, pattern);

        List<List<Vector2>> outlines = new List<List<Vector2>>();

        foreach (Match match in matches)
        {
            string[] values = match.Groups[1].Value.Split(',');
            List<Vector2> points = new List<Vector2>();

            for (int i = 0; i < values.Length; i += 2)
            {
                float x = float.Parse(values[i].Trim());
                float y = float.Parse(values[i + 1].Trim());
                points.Add(new Vector2(x, y));
            }

            outlines.Add(points);
        }

        // 打印提取的轮廓数据
        foreach (var outline in outlines)
        {
         //   Console.WriteLine("Outline:");
            foreach (var point in outline)
            {
         //       Console.WriteLine($"({point.X}, {point.Y})");
            }
        }

        // 创建路径规划器
        Pathfinder pathfinder = new Pathfinder(outlines);

        // 设置起点和终点
        Vector2 start = new Vector2(start3.X, start3.Y);
        Vector2 end = new Vector2(end3.X, end3.Y);

        // 查找路径
        List<Vector2> result = pathfinder.FindPath(start, end);

        // 打印路径
        Console.WriteLine($"Path start :{start.X},{start.Y} end ({end.X}, {end.Y})");
        foreach (var point in result)
        {

            Console.WriteLine($"({point.X}, {point.Y})");
            path.Add(new Vector3(point.X*10,point.Y*10,0));
        }
    }
}
