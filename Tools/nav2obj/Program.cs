using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Godot 的 NavigationRegion2D 轮廓数据
        var outlines = new List<List<(float, float)>>
        {
            new List<(float, float)> { (215, 492), (193, 504), (181, 500), (118, 415), (118, 236), (171, 114), (283, 80), (280, 97), (297, 93), (481, 69), (508, 121), (505, 125), (505, 185), (447, 218), (417, 211), (408, 183), (385, 192), (400, 263), (442, 269), (558, 192), (546, 169), (543, 153), (551, 153), (576, 162), (586, 169), (614, 175), (621, 171), (613, 155), (572, 127), (543, 99), (552, 68), (578, 70), (614, 83), (630, 93), (641, 104), (653, 125), (671, 191), (672, 213), (668, 286), (653, 297), (665, 316), (672, 521), (638, 538), (579, 535), (545, 517), (503, 530), (361, 530), (273, 515), (292, 466), (154, 393), (172, 458) },
            new List<(float, float)> { (188, 184), (257, 243), (215, 264), (206, 300), (212, 336), (244, 350), (284, 356), (293, 349), (336, 360), (325, 459), (232, 423), (147, 366), (140, 341), (162, 240) },
            new List<(float, float)> { (239, 169), (274, 127), (277, 109), (454, 96), (479, 110), (465, 181), (436, 193), (421, 177), (448, 165), (431, 143), (284, 207) },
            new List<(float, float)> { (312, 225), (371, 198), (390, 283), (408, 283), (482, 295), (451, 453), (346, 431), (356, 366), (388, 375), (394, 348), (316, 336), (318, 333), (263, 302), (268, 272), (333, 241) },
            new List<(float, float)> { (341, 450), (337, 479), (315, 478), (304, 472), (295, 502), (361, 516), (506, 512), (574, 473), (589, 405), (494, 375), (485, 476), (447, 482) },
            new List<(float, float)> { (565, 202), (603, 230), (621, 268), (619, 331), (643, 309), (654, 512), (587, 527), (568, 510), (584, 505), (615, 418), (615, 396), (584, 375), (495, 358), (499, 305), (495, 301), (500, 297), (509, 299), (559, 285), (465, 272) }
        };

        // 生成 OBJ 文件
        CreateObjWithDynamicThicknessAndColor(outlines, "navigation_region_with_thickness.obj");
    }

    static void CreateObjWithDynamicThicknessAndColor(List<List<(float, float)>> outlines, string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            int vertexIndex = 1; // OBJ 文件顶点索引从 1 开始
            var faceIndices = new List<List<int>>(); // 存储每个多边形的面索引

            // 计算每个多边形的面积并确定厚度
            var polygonAreas = outlines.Select(polygon => CalculatePolygonArea(polygon)).ToList();
            float maxArea = polygonAreas.Max();
            float minArea = polygonAreas.Min();

            // 生成随机颜色
            var random = new Random();
            var colors = outlines.Select(_ => (random.NextFloat(), random.NextFloat(), random.NextFloat())).ToList();

            // 写入材质文件 (MTL)
            string mtlFilename = Path.ChangeExtension(filename, ".mtl");
            using (var mtlWriter = new StreamWriter(mtlFilename))
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    mtlWriter.WriteLine($"newmtl material_{i}");
                    mtlWriter.WriteLine($"Kd {colors[i].Item1} {colors[i].Item2} {colors[i].Item3}");
                }
            }

            // 在 OBJ 文件中引用 MTL 文件
            writer.WriteLine($"mtllib {Path.GetFileName(mtlFilename)}");

            // 遍历每个多边形
            for (int i = 0; i < outlines.Count; i++)
            {
                var polygon = outlines[i];
                float area = polygonAreas[i];
                // 根据面积计算厚度（面积越大，厚度越小）
                float thickness = MapValue(area, minArea, maxArea, 50, 2);

                // 写入顶部顶点
                foreach (var point in polygon)
                {
                    writer.WriteLine($"v {point.Item1}  {thickness} {point.Item2}");
                }

                // 写入底部顶点
                foreach (var point in polygon)
                {
                    writer.WriteLine($"v {point.Item1} 0  {point.Item2}");
                }

                // 生成侧面
                int n = polygon.Count;
                for (int j = 0; j < n; j++)
                {
                    int currentTop = vertexIndex + j;
                    int nextTop = vertexIndex + (j + 1) % n;
                    int currentBottom = vertexIndex + n + j;
                    int nextBottom = vertexIndex + n + (j + 1) % n;

                    writer.WriteLine($"f {currentTop} {nextTop} {nextBottom} {currentBottom}");
                }

                // 生成顶部和底部面
                var topFace = Enumerable.Range(vertexIndex, n).Reverse();
                var bottomFace = Enumerable.Range(vertexIndex + n, n);
                writer.WriteLine("f " + string.Join(" ", topFace));
                writer.WriteLine("f " + string.Join(" ", bottomFace));

                // 更新顶点索引
                vertexIndex += 2 * n;
            }

            // 写入面数据并应用材质
            for (int i = 0; i < outlines.Count; i++)
            {
                writer.WriteLine($"usemtl material_{i}");
            }
        }
    }

    // 计算多边形的面积
    static float CalculatePolygonArea(List<(float, float)> polygon)
    {
        float area = 0;
        int n = polygon.Count;
        for (int i = 0; i < n; i++)
        {
            var current = polygon[i];
            var next = polygon[(i + 1) % n];
            area += current.Item1 * next.Item2 - next.Item1 * current.Item2;
        }
        return Math.Abs(area / 2);
    }

    // 将值从一个范围映射到另一个范围
    static float MapValue(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
    }
}

// 扩展方法：生成随机浮点数
public static class RandomExtensions
{
    public static float NextFloat(this Random random)
    {
        return (float)random.NextDouble();
    }
}