using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer borderRenderer;
    public SpriteRenderer fillRenderer;

    private Vector2Int coord;

    public void Initialize(Vector2Int coord, bool isWall)
    {
        this.coord = coord;
        borderRenderer.color = Color.white;
        fillRenderer.color = isWall ? Color.gray : Color.white;
    }

    public void SetStart() => fillRenderer.color = Color.green;
    public void SetGoal() => fillRenderer.color = Color.red;
    public void SetPath() => fillRenderer.color = Color.cyan;
}
