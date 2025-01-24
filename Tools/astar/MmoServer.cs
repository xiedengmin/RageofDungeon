using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar
{
    public class MmoServer
    {
        private readonly AStarPathfinder _pathfinder;

        public MmoServer()
        {
            // 定义障碍物（多边形）
            var obstacle = new Polygon(new[]
            {
            new Vector2(-790.562f, 53.7334f),
            new Vector2(-70.7271f, 53.7334f),
            new Vector2(-44.5641f, 16.2567f),
            new Vector2(43.1172f, 16.2567f),
            new Vector2(63.6233f, 54.4405f),
            new Vector2(779.215f, 53.7334f),
            new Vector2(778.149f, -323.461f),
            new Vector2(-731.283f, -323.461f),
            new Vector2(-790.916f, -323.461f)
        });

            // 初始化路径规划器（网格大小 10 单位）
            _pathfinder = new AStarPathfinder(obstacle, gridSize: 10f);
        }

        // 处理客户端路径请求
        public List<Vector2> HandlePathRequest(Vector2 start, Vector2 end)
        {
            return _pathfinder.FindPath(start, end);
        }
    }

 
}
