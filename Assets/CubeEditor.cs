using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridPos = waypoint.GridPos;
        transform.position = new Vector3(gridPos.x * waypoint.GridSize, 0, gridPos.y * waypoint.GridSize);
    }

    void UpdateLabel()
    {
        var gridPos = waypoint.GridPos;
        gameObject.name = gridPos.x.ToString() + "," + gridPos.y.ToString();
    }
}
