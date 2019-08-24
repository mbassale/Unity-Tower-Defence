using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
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
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x.ToString() + "," + gridPos.y.ToString();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
