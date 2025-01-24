using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar
{
    public class AStarPathfinder
    {
        private readonly float _gridSize; // 网格大小（例如 10 单位）
        private readonly Polygon _obstacle;

        public AStarPathfinder(Polygon obstacle, float gridSize = 10f)
        {
            _obstacle = obstacle;
            _gridSize = gridSize;
        }

        public List<Vector2> FindPath(Vector2 start, Vector2 end)
        {
            var openSet = new HashSet<Vector2> { start };
            var cameFrom = new Dictionary<Vector2, Vector2>();
            var gScore = new Dictionary<Vector2, float> { { start, 0 } };
            var fScore = new Dictionary<Vector2, float> { { start, Heuristic(start, end) } };

            while (openSet.Count > 0)
            {
                Vector2 current = openSet.OrderBy(p => fScore.GetValueOrDefault(p, float.MaxValue)).First();

                if (IsCloseEnough(current, end))
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (_obstacle.Contains(neighbor) || _obstacle.Intersects(current, neighbor))
                        continue;

                    float tentativeGScore = gScore[current] + current.DistanceTo(neighbor);
                    if (tentativeGScore < gScore.GetValueOrDefault(neighbor, float.MaxValue))
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + Heuristic(neighbor, end);
                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }

            return null; // 未找到路径
        }

        // 获取邻居节点（四方向）
        private IEnumerable<Vector2> GetNeighbors(Vector2 point)
        {
            return new[]
            {
            new Vector2(point.X - _gridSize, point.Y),
            new Vector2(point.X + _gridSize, point.Y),
            new Vector2(point.X, point.Y - _gridSize),
            new Vector2(point.X, point.Y + _gridSize),
        };
        }

        // 启发式函数（曼哈顿距离）
        private float Heuristic(Vector2 a, Vector2 b) =>
            Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        // 重建路径
        private List<Vector2> ReconstructPath(Dictionary<Vector2, Vector2> cameFrom, Vector2 current)
        {
            var path = new List<Vector2> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Add(current);
            }
            path.Reverse();
            return SimplifyPath(path);
        }

        // 路径简化（移除冗余点）
        private List<Vector2> SimplifyPath(List<Vector2> path)
        {
            if (path.Count < 3) return path;
            var simplified = new List<Vector2> { path[0] };
            for (int i = 1; i < path.Count - 1; i++)
            {
                if (_obstacle.Intersects(simplified.Last(), path[i + 1]))
                    simplified.Add(path[i]);
            }
            simplified.Add(path.Last());
            return simplified;
        }

        // 判断是否足够接近终点
        private bool IsCloseEnough(Vector2 a, Vector2 b) =>
            a.DistanceTo(b) < _gridSize;
    }
}
