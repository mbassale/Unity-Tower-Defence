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
        transform.position = new Vector3(gridPos.x, 0, gridPos.y);
    }

    void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (transform.position.x / waypoint.GridSize).ToString() + "," + (transform.position.z / waypoint.GridSize).ToString();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
