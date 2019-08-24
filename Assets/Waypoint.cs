using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;
    Color topColor;
    bool isExplored = false;
    Waypoint exploredFrom = null;

    public int GridSize
    {
        get {
            return gridSize;
        }
    }

    public Vector2Int GridPos
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
        }
    }

    public bool IsExplored
    {
        get
        {
            return isExplored;
        }
        set
        {
            isExplored = value;
            if (isExplored)
            {
                TopColor = Color.yellow;
            }
        }
    }

    public Waypoint ExploredFrom
    {
        get
        {
            return exploredFrom;
        }
        set
        {
            exploredFrom = value;
        }
    }

    public Color TopColor
    {
        get
        {
            return topColor;
        }
        set
        {
            topColor = value;
            var top = transform.Find("Top");
            if (top)
            {
                var meshRenderer = top.GetComponent<MeshRenderer>();
                if (meshRenderer)
                {
                    meshRenderer.material.color = topColor;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
