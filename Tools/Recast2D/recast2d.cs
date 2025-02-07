using DotRecast.Core;
using DotRecast.Recast;
using DotRecast.Detour;
using System.Collections.Generic;

public class NavMeshBuilder
{
    public NavMesh BuildNavMesh(List<List<Vector2>> outlines)
    {
        // 创建 Recast 配置
        RcConfig config = new RcConfig(
            partitionType: RcPartitionType.WATERSHED,
            cellSize: 1.0f,
            cellHeight: 1.0f,
            walkableSlopeAngle: 45.0f,
            walkableHeight: 10,
            walkableClimb: 1,
            walkableRadius: 5,
            maxEdgeLen: 12,
            maxSimplificationError: 1.3f,
            minRegionArea: 8,
            mergeRegionArea: 20,
            maxVertsPerPoly: 6,
            detailSampleDist: 6.0f,
            detailSampleMaxError: 1.0f
        );

        // 创建 Recast 构建器
        RcBuilder builder = new RcBuilder();

        // 将障碍物轮廓数据转换为 Recast 输入
        List<RcVec3f> vertices = new List<RcVec3f>();
        List<int> indices = new List<int>();

        foreach (var outline in outlines)
        {
            int startIndex = vertices.Count;
            foreach (var point in outline)
            {
                vertices.Add(new RcVec3f(point.X, 0, point.Y)); // 2D 数据转换为 3D
            }

            for (int i = 0; i < outline.Count - 1; i++)
            {
                indices.Add(startIndex + i);
                indices.Add(startIndex + i + 1);
            }
            indices.Add(startIndex + outline.Count - 1);
            indices.Add(startIndex);
        }

        // 构建导航网格
        RcBuilderResult result = builder.Build(vertices, indices, config);
        DtNavMesh navMesh = result.GetNavMesh();

        return new NavMesh(navMesh);
    }
}

public class NavMesh
{
    private DtNavMesh _navMesh;

    public NavMesh(DtNavMesh navMesh)
    {
        _navMesh = navMesh;
    }

    public List<Vector2> FindPath(Vector2 start, Vector2 end)
    {
        DtNavMeshQuery query = new DtNavMeshQuery(_navMesh);
        RcVec3f startPos = new RcVec3f(start.X, 0, start.Y);
        RcVec3f endPos = new RcVec3f(end.X, 0, end.Y);

        // 查找路径
        query.FindPath(startPos, endPos, out List<RcVec3f> path);

        // 将路径转换为 2D
        List<Vector2> result = new List<Vector2>();
        foreach (var point in path)
        {
            result.Add(new Vector2(point.X, point.Z));
        }

        return result;
    }
}