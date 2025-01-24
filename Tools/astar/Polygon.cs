using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar
{
    public struct Vector2
    {
        public float X { get; }
        public float Y { get; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float DistanceTo(Vector2 other)
        {
            float dx = X - other.X;
            float dy = Y - other.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString() => $"({X:F2}, {Y:F2})";
    }

    public class Polygon
    {
        public List<Vector2> Points { get; }

        public Polygon(IEnumerable<Vector2> points)
        {
            Points = new List<Vector2>(points);
        }

        // 检查点是否在多边形内（射线法）
        public bool Contains(Vector2 point)
        {
            bool inside = false;
            int count = Points.Count;
            for (int i = 0, j = count - 1; i < count; j = i++)
            {
                Vector2 a = Points[i];
                Vector2 b = Points[j];
                if (((a.Y > point.Y) != (b.Y > point.Y)) &&
                    (point.X < (b.X - a.X) * (point.Y - a.Y) / (b.Y - a.Y) + a.X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }

        // 检查线段是否与多边形相交
        public bool Intersects(Vector2 start, Vector2 end)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Vector2 a = Points[i];
                Vector2 b = Points[(i + 1) % Points.Count];
                if (LineSegmentsIntersect(start, end, a, b))
                    return true;
            }
            return false;
        }

        // 检查两线段是否相交
        private static bool LineSegmentsIntersect(Vector2 p1, Vector2 p2, Vector2 q1, Vector2 q2)
        {
            float cross1 = (p2.X - p1.X) * (q1.Y - p1.Y) - (p2.Y - p1.Y) * (q1.X - p1.X);
            float cross2 = (p2.X - p1.X) * (q2.Y - p1.Y) - (p2.Y - p1.Y) * (q2.X - p1.X);
            if (cross1 * cross2 >= 0) return false;

            float cross3 = (q2.X - q1.X) * (p1.Y - q1.Y) - (q2.Y - q1.Y) * (p1.X - q1.X);
            float cross4 = (q2.X - q1.X) * (p2.Y - q1.Y) - (q2.Y - q1.Y) * (p2.X - q1.X);
            return cross3 * cross4 < 0;
        }
    }
}
