using Godot;
using System;
using System.Collections.Generic;

using ET;
namespace ET {
public partial class Test1 : Node2D
{
    // 角色节点
    private TileMapLayer tileMapLayer;
    // TileSet资源
    private TileSet _tileSet;
    private Swordman player;
    private Vector2 lastPlayerCell;


    // 已加载的地砖位置
    private HashSet<Vector2I> loadedTiles = new HashSet<Vector2I>();
    // 加载范围（以地砖为单位）
    private int loadRange = 5;
    // 地砖大小（像素）
    private int tileSize = 128;
    public override void _Ready()
    {
        // 获取玩家节点
        player = (Swordman)GD.Load<PackedScene>("res://Prefabs/role/character/Swordman.tscn").Instantiate();
        player.Position = new Vector2(600, 350);
        AddChild(player);
        // 获取TileMapLayer
        tileMapLayer = GetNode<TileMapLayer>("TileMapLayer");

        // 加载TileSet资源
        _tileSet = ResourceLoader.Load<TileSet>("res://scenes/test/Test.tres");

        // 设置TileMapLayer的TileSet
        tileMapLayer.TileSet = _tileSet;
        // 启动协程
        LoadTilesAsync().Coroutine();
    }
    // 角色节点


    private async ETTask LoadTilesAsync()
    {
        while (true)
        {
            // 获取角色在地图中的位置
            Vector2 playerPosition = player.GlobalPosition;
            Vector2I playerTile = tileMapLayer.LocalToMap(playerPosition);

            // 加载范围内的地砖
            for (int x = -loadRange; x <= loadRange; x++)
            {
                for (int y = -loadRange; y <= loadRange; y++)
                {
                    Vector2I tilePos = playerTile + new Vector2I(x, y);

                    if (!loadedTiles.Contains(tilePos))
                    {
                        LoadTile(tilePos);
                        loadedTiles.Add(tilePos);
                    }
                }
            }

            // 卸载超出范围的地砖
            List<Vector2I> tilesToUnload = new List<Vector2I>();

            foreach (var tilePos in loadedTiles)
            {
                if (tilePos.DistanceTo(playerTile) > loadRange)
                {
                    UnloadTile(tilePos);
                    tilesToUnload.Add(tilePos);
                }
            }

            foreach (var tilePos in tilesToUnload)
            {
                loadedTiles.Remove(tilePos);
            }

            // 等待一段时间再检测（避免过于频繁）
            await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
        }
    }

    private void LoadTile(Vector2I tilePos)
    {
        // 获取地砖 ID（根据实际情况调整）
        int tileId = GetTileIdForPosition(tilePos);

        // 设置地砖
        tileMapLayer.SetCell(tilePos, tileId);
    }

    private void UnloadTile(Vector2I tilePos)
    {
        // 移除地砖
        tileMapLayer.SetCell(tilePos, -1);
    }

    private int GetTileIdForPosition(Vector2I tilePos)
    {
        // 根据位置返回对应的地砖 ID
        // 这里简化为返回 0，实际应用中应根据地图数据返回正确的 ID
        return 0;
    }
}

}