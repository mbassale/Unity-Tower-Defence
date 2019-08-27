using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;

    // Start is called before the first frame update
    void Start()
    {
        var pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(PrintAllWaypoints(pathfinder.Path));
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private IEnumerator PrintAllWaypoints(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
    }
}
