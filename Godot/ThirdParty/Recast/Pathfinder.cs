using Godot;
using System;
using System.Collections.Generic;

public class Pathfinder
{
    private List<List<Vector2>> _obstacles;

    public Pathfinder(List<List<Vector2>> obstacles)
    {
        _obstacles = obstacles;
    }

    public List<Vector2> FindPath(Vector2 start, Vector2 end)
    {
        // 定义网格大小
        float gridSize = 10.0f; // 每个网格的大小

        // 将起点和终点对齐到网格
        Vector2 gridStart = new Vector2((int)(start.X / gridSize), (int)(start.Y / gridSize));
        Vector2 gridEnd = new Vector2((int)(end.X / gridSize), (int)(end.Y / gridSize));

        // 定义开放列表和关闭列表
        var openList = new PriorityQueue<Node>();
        var closedList = new HashSet<Vector2>();

        // 添加起点到开放列表
        openList.Enqueue(new Node(gridStart, 0, Heuristic(gridStart, gridEnd), null));

        while (openList.Count > 0)
        {
            // 取出当前节点
            var currentNode = openList.Dequeue();

            // 如果到达终点，返回路径
            if (currentNode.Position.Equals(gridEnd))
            {
                return ReconstructPath(currentNode);
            }

            // 将当前节点添加到关闭列表
            closedList.Add(currentNode.Position);

            // 遍历邻居节点
            foreach (var neighbor in GetNeighbors(currentNode.Position))
            {
                if (closedList.Contains(neighbor))
                {
                    continue; // 跳过已处理的节点
                }

                // 计算新的G值
                float newG = currentNode.G + 1;

                // 如果邻居节点不在开放列表中，或者新的G值更小
                if (!openList.Contains(new Node(neighbor, 0, 0, null)) || newG < openList.GetNode(new Node(neighbor, 0, 0, null)).G)
                //     if (!openList.Contains(neighbor) || newG < openList.GetNode(neighbor).G)
                {
                    // 更新邻居节点
                    openList.Enqueue(new Node(neighbor, newG, Heuristic(neighbor, gridEnd), currentNode));
                }
            }
        }

        // 如果没有找到路径，返回空列表
        return new List<Vector2>();
    }

    private float Heuristic(Vector2 a, Vector2 b)
    {
        // 使用曼哈顿距离作为启发式函数
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private List<Vector2> GetNeighbors(Vector2 position)
    {
        // 返回当前节点的邻居节点
        return new List<Vector2>
        {
            new Vector2(position.X - 1, position.Y),
            new Vector2(position.X + 1, position.Y),
            new Vector2(position.X, position.Y - 1),
            new Vector2(position.X, position.Y + 1)
        };
    }

    private List<Vector2> ReconstructPath(Node node)
    {
        // 从终点回溯到起点，构建路径
        var path = new List<Vector2>();
        while (node != null)
        {
            path.Add(node.Position);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }

    private class Node : IComparable<Node>
    {
        public Vector2 Position { get; }
        public float G { get; } // 从起点到当前节点的代价
        public float H { get; } // 启发式估计值
        public float F => G + H; // 总代价
        public Node Parent { get; }

        public Node(Vector2 position, float g, float h, Node parent)
        {
            Position = position;
            G = g;
            H = h;
            Parent = parent;
        }

        public int CompareTo(Node other)
        {
            return F.CompareTo(other.F);
        }
    }
}

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> _elements = new List<T>();

    public int Count => _elements.Count;

    public void Enqueue(T item)
    {
        _elements.Add(item);
        _elements.Sort();
    }

    public T Dequeue()
    {
        var item = _elements[0];
        _elements.RemoveAt(0);
        return item;
    }

    public bool Contains(T item)
    {
        return _elements.Contains(item);
    }

    public T GetNode(T item)
    {
        return _elements.Find(x => x.Equals(item));
    }
}