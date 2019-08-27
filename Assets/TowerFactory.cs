using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
            newTower.Waypoint = baseWaypoint;
            towerQueue.Enqueue(newTower);
            baseWaypoint.IsPlaceable = false;
        }
        else
        {
            Tower oldTower = towerQueue.Dequeue();
            oldTower.transform.position = baseWaypoint.transform.position;
            oldTower.Waypoint.IsPlaceable = true;
            oldTower.Waypoint = baseWaypoint;
            towerQueue.Enqueue(oldTower);
            baseWaypoint.IsPlaceable = false;
        }
    }
}
