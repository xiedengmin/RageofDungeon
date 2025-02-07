using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "stage_01.txt";
        string fileContent = File.ReadAllText(filePath);

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
            Console.WriteLine("Outline:");
            foreach (var point in outline)
            {
                Console.WriteLine($"({point.X}, {point.Y})");
            }
        }

        // 使用 DotRecast 进行路径规划
        NavMeshBuilder builder = new NavMeshBuilder();
        NavMesh navMesh = builder.BuildNavMesh(outlines);

        Vector2 start = new Vector2(100, 100);
        Vector2 end = new Vector2(1500, 500);

        List<Vector2> path = navMesh.FindPath(start, end);

        Console.WriteLine("Path:");
        foreach (var point in path)
        {
            Console.WriteLine($"({point.X}, {point.Y})");
        }
    }
}

public struct Vector2
{
    public float X { get; }
    public float Y { get; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
}