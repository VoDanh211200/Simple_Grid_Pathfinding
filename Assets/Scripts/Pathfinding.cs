using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private class Node
    {
        public Vector2Int coord;
        public int gCost, hCost;
        public int FCost => gCost + hCost;
        public Node parent;
        public Node(Vector2Int c) => coord = c;
    }

    public static List<Vector2Int> FindPath(int[,] map, Vector2Int start, Vector2Int goal)
    {
        int w = map.GetLength(0), h = map.GetLength(1);
        var open = new List<Node>();
        var closed = new HashSet<Vector2Int>();

        Node startNode = new Node(start) { gCost = 0, hCost = Heuristic(start, goal) };
        open.Add(startNode);

        while (open.Count > 0)
        {
            open.Sort((a, b) => a.FCost.CompareTo(b.FCost));
            Node current = open[0];
            open.RemoveAt(0);
            closed.Add(current.coord);

            if (current.coord == goal)
                return RetracePath(current);

            foreach (var neighborCoord in GetNeighbors(current.coord, w, h))
            {
                if (closed.Contains(neighborCoord) || map[neighborCoord.x, neighborCoord.y] == 1)
                    continue;

                int tentativeG = current.gCost + 1;
                Node neighbor = open.Find(n => n.coord == neighborCoord);
                if (neighbor == null)
                {
                    neighbor = new Node(neighborCoord)
                    {
                        gCost = tentativeG,
                        hCost = Heuristic(neighborCoord, goal),
                        parent = current
                    };
                    open.Add(neighbor);
                }
                else if (tentativeG < neighbor.gCost)
                {
                    neighbor.gCost = tentativeG;
                    neighbor.parent = current;
                }
            }
        }

        return new List<Vector2Int>();
    }

    private static List<Vector2Int> RetracePath(Node endNode)
    {
        var path = new List<Vector2Int>();
        Node cur = endNode;
        while (cur != null)
        {
            path.Add(cur.coord);
            cur = cur.parent;
        }
        path.Reverse();
        return path;
    }

    private static int Heuristic(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private static IEnumerable<Vector2Int> GetNeighbors(Vector2Int c, int w, int h)
    {
        var dirs = new[]
        {
            new Vector2Int( 1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int( 0, 1),
            new Vector2Int( 0,-1)
        };
        foreach (var d in dirs)
        {
            var n = c + d;
            if (n.x >= 0 && n.x < w && n.y >= 0 && n.y < h)
                yield return n;
        }
    }
}
