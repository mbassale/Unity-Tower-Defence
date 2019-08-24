using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.IsExplored = true;
            print("SearchCenter: " + searchCenter);
            // Halt if search is the endWaypoint
            if (searchCenter.GridPos == endWaypoint.GridPos)
            {
                print("End node found.");
                break;
            }

            ExploreNeighbours(searchCenter);
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = from.GridPos + direction;
            if (grid.ContainsKey(explorationCoordinates))
            {
                var neighbour = grid[explorationCoordinates];
                neighbour.TopColor = Color.yellow;
                if (!neighbour.IsExplored)
                {
                    queue.Enqueue(neighbour);
                }
            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GridPos);
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping Block: " + waypoint.GridPos);
            }
            else
            {
                waypoint.IsExplored = false;
                grid.Add(waypoint.GridPos, waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.TopColor = Color.green;
        endWaypoint.TopColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
