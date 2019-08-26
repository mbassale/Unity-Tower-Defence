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
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> Path
    {
        get
        {
            if (path.Count == 0)
            {
                LoadBlocks();
                ColorStartAndEnd();
                PathFind();
            }
            return path;
        }
    }
    
    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.IsExplored = true;
            // Halt if search is the endWaypoint
            if (searchCenter.GridPos == endWaypoint.GridPos)
            {
                break;
            }

            ExploreNeighbours(searchCenter);
        }

        // build path
        var waypoint = endWaypoint;
        path.Add(waypoint);
        while (waypoint.ExploredFrom)
        {
            path.Add(waypoint.ExploredFrom);
            waypoint = waypoint.ExploredFrom;
        }
        path.Reverse();
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = from.GridPos + direction;
            if (grid.ContainsKey(explorationCoordinates))
            {
                var neighbour = grid[explorationCoordinates];
                if (!neighbour.IsExplored && !queue.Contains(neighbour))
                {
                    neighbour.ExploredFrom = from;
                    queue.Enqueue(neighbour);
                }
            }
        }
    }

    private void LoadBlocks()
    {
        path = new List<Waypoint>();
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
}
