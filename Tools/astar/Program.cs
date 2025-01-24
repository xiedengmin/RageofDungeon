using System;
using System.Collections.Generic;
using System.Linq;

public class Vector2
{
    public float X { get; }
    public float Y { get; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X:F2}, {Y:F2})";
    }
}

public class AStarNode : IComparable<AStarNode>
{
    public int X { get; }
    public int Y { get; }
    public float G { get; set; } // Cost from start to this node
    public float H { get; set; } // Heuristic cost to goal
    public float F => G + H;     // Total cost
    public AStarNode Parent { get; set; }

    public AStarNode(int x, int y)
    {
        X = x;
        Y = y;
        G = float.MaxValue;
        H = 0;
        Parent = null;
    }

    public int CompareTo(AStarNode other)
    {
        return F.CompareTo(other.F);
    }
}

public class AStar
{
    private float gridSize;
    private bool[,] blockedGrid;
    private int gridOffsetX;
    private int gridOffsetY;
    private int gridWidth;
    private int gridHeight;

    public AStar(List<Vector2> polygon, float gridSize)
    {
        this.gridSize = gridSize;

        // Calculate grid bounds
        float minX = polygon.Min(p => p.X);
        float maxX = polygon.Max(p => p.X);
        float minY = polygon.Min(p => p.Y);
        float maxY = polygon.Max(p => p.Y);

        gridOffsetX = (int)Math.Floor(minX / gridSize);
        gridOffsetY = (int)Math.Floor(minY / gridSize);
        gridWidth = (int)Math.Ceiling((maxX - minX) / gridSize) + 1;
        gridHeight = (int)Math.Ceiling((maxY - minY) / gridSize) + 1;

        blockedGrid = new bool[gridWidth, gridHeight];

        // Mark blocked cells based on polygon
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float worldX = (gridOffsetX + x) * gridSize + gridSize / 2;
                float worldY = (gridOffsetY + y) * gridSize + gridSize / 2;
                blockedGrid[x, y] = IsPointInPolygon(new Vector2(worldX, worldY), polygon);
            }
        }
    }

    private bool IsPointInPolygon(Vector2 point, List<Vector2> polygon)
    {
        bool inside = false;
        int count = polygon.Count;
        for (int i = 0, j = count - 1; i < count; j = i++)
        {
            Vector2 pi = polygon[i];
            Vector2 pj = polygon[j];
            if (((pi.Y > point.Y) != (pj.Y > point.Y)) &&
                (point.X < (pj.X - pi.X) * (point.Y - pi.Y) / (pj.Y - pi.Y) + pi.X))
            {
                inside = !inside;
            }
        }
        return inside;
    }

    public List<Vector2> FindPath(Vector2 start, Vector2 end)
    {
        int startX = (int)(Math.Floor(start.X / gridSize) - gridOffsetX);
        int startY = (int)(Math.Floor(start.Y / gridSize) - gridOffsetY);
        int endX = (int)(Math.Floor(end.X / gridSize) - gridOffsetX);
        int endY = (int)(Math.Floor(end.Y / gridSize) - gridOffsetY);

        if (startX < 0 || startX >= gridWidth || startY < 0 || startY >= gridHeight ||
            endX < 0 || endX >= gridWidth || endY < 0 || endY >= gridHeight)
            return null;

        if (blockedGrid[startX, startY] || blockedGrid[endX, endY])
            return null;

        AStarNode[,] nodes = new AStarNode[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
            for (int y = 0; y < gridHeight; y++)
                nodes[x, y] = new AStarNode(x, y);

        var openList = new SortedSet<AStarNode>(Comparer<AStarNode>.Create((a, b) => a.F.CompareTo(b.F)));
        var closedList = new HashSet<AStarNode>();

        AStarNode startNode = nodes[startX, startY];
        AStarNode endNode = nodes[endX, endY];
        startNode.G = 0;
        startNode.H = Math.Abs(startX - endX) + Math.Abs(startY - endY);
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            AStarNode current = openList.Min;
            openList.Remove(current);

            if (current == endNode)
                return ReconstructPath(current);

            closedList.Add(current);

            foreach (var neighbor in GetNeighbors(current, nodes))
            {
                if (closedList.Contains(neighbor) || blockedGrid[neighbor.X, neighbor.Y])
                    continue;

                float tentativeG = current.G + 1;

                if (tentativeG < neighbor.G)
                {
                    neighbor.G = tentativeG;
                    neighbor.H = Math.Abs(neighbor.X - endX) + Math.Abs(neighbor.Y - endY);
                    neighbor.Parent = current;

                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }

        return null;
    }

    private List<Vector2> ReconstructPath(AStarNode endNode)
    {
        List<Vector2> path = new List<Vector2>();
        AStarNode current = endNode;

        while (current != null)
        {
            float worldX = (gridOffsetX + current.X) * gridSize + gridSize / 2;
            float worldY = (gridOffsetY + current.Y) * gridSize + gridSize / 2;
            path.Add(new Vector2(worldX, worldY));
            current = current.Parent;
        }

        path.Reverse();
        return path;
    }

    private IEnumerable<AStarNode> GetNeighbors(AStarNode node, AStarNode[,] nodes)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int x = node.X + dx[i];
            int y = node.Y + dy[i];

            if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
                yield return nodes[x, y];
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Polygon data from Godot's PackedVector2Array
        float[] rawData = {
            -790.562f, 53.7334f, -70.7271f, 53.7334f, -44.5641f, 16.2567f,
            43.1172f, 16.2567f, 63.6233f, 54.4405f, 779.215f, 53.7334f,
            778.149f, -323.461f, -731.283f, -323.461f, -790.916f, -323.461f
        };

        // Convert raw data to List<Vector2>
        List<Vector2> polygon = new List<Vector2>();
        for (int i = 0; i < rawData.Length; i += 2)
            polygon.Add(new Vector2(rawData[i], rawData[i + 1]));

        // Initialize A* with polygon and grid size
        AStar astar = new AStar(polygon, 10f);

        // Define start and end points
        Vector2 start = new Vector2(-600f, 250f);
        Vector2 end = new Vector2(600f, 250f);

        // Find path
        List<Vector2> path = astar.FindPath(start, end);

        // Print path
        if (path != null)
        {
            Console.WriteLine("Path found:");
            foreach (var point in path)
                Console.WriteLine(point);
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}