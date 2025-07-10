using UnityEngine;
using System.Collections.Generic;

public class MapRenderer : MonoBehaviour
{
    public static MapRenderer Instance { get; private set; }

    [Header("Tile Prefab")]
    public GameObject tilePrefab;
    private Vector2 tileSize;

    private List<GameObject> spawned = new();
    private Dictionary<Vector2Int, Tile> tileMap = new();

    private Vector2Int startCoord;
    private Vector2Int goalCoord;

    void Awake()
    {
        Instance = this;      
    }

    public void RenderMap(int[,] map, int width, int height, Vector2Int start, Vector2Int goal)
    {
        startCoord = start;
        goalCoord = goal;

        var sr = tilePrefab.GetComponentInChildren<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
            tileSize = sr.sprite.bounds.size;

        foreach (var go in spawned) Destroy(go);
        spawned.Clear();
        tileMap.Clear();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var pos = new Vector3(x * tileSize.x, y * tileSize.y, 0f);
                var go = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                spawned.Add(go);

                var tile = go.GetComponent<Tile>();
                var coord = new Vector2Int(x, y);
                tile.Initialize(coord, map[x, y] == 1);
                tileMap[coord] = tile;

                if (coord == start) tile.SetStart();
                else if (coord == goal) tile.SetGoal();
            }
        }
    }

    public void PaintPath(List<Vector2Int> path)
    {
        foreach (var coord in path)
        {
            if (coord == startCoord || coord == goalCoord)
                continue;

            if (tileMap.TryGetValue(coord, out var tile))
                tile.SetPath();
        }
    }
}
