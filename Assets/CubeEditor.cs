using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] int gridSize = 10;
    [Range(1, 20)] [SerializeField] int cellSize = 10;
    TextMesh textMesh;
    
    void Update()
    {
        Vector3 snapPosition;
        snapPosition.y = 0;
        var worldSize = gridSize * cellSize;
        snapPosition.x = Mathf.RoundToInt(Mathf.Clamp(transform.position.x, -worldSize, worldSize) / cellSize) * cellSize;
        snapPosition.z = Mathf.RoundToInt(Mathf.Clamp(transform.position.z, -worldSize, worldSize) / cellSize) * cellSize;
        transform.position = snapPosition;

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (snapPosition.x / cellSize).ToString() + "," + (snapPosition.z / cellSize).ToString();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
