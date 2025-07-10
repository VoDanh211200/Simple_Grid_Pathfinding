using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    [Header("Grid Size Range (inclusive)")]
    public int minWidth = 5;
    public int maxWidth = 20;
    public int minHeight = 5;
    public int maxHeight = 20;

    private int width;
    private int height;
    private Vector2Int startPos;
    private Vector2Int goalPos;

    [Header("Obstacle Probability")]
    [Range(0f, 1f)] public float obstacleProbability = 0.2f;

    [Header("UI Elements")]
    public Button generateButton;

    [HideInInspector] public int[,] map;

    void Start() {
        generateButton.onClick.AddListener(GenerateMap);
    }

    public void GenerateMap() {
        width = Random.Range(minWidth, maxWidth + 1);
        height = Random.Range(minHeight, maxHeight + 1);
        startPos = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        do
        {
            goalPos = new Vector2Int(Random.Range(0, width),Random.Range(0, height)
            );
        } while (goalPos == startPos);


        map = new int[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                map[x, y] = (Random.value < obstacleProbability) ? 1 : 0;
            }
        }

        map[startPos.x, startPos.y] = 0;
        map[goalPos.x, goalPos.y]   = 0;

        MapRenderer.Instance.RenderMap(map, width, height, startPos, goalPos);

        var path = Pathfinding.FindPath(map, startPos, goalPos);
        MapRenderer.Instance.PaintPath(path);
    }
}
