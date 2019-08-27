using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] ParticleSystem goalParticle;

    // Start is called before the first frame update
    void Start()
    {
        var pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(PrintAllWaypoints(pathfinder.Path));
    }

    private IEnumerator PrintAllWaypoints(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        if (goalParticle)
        {
            var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
            vfx.Play();
            float destroyDelay = vfx.main.duration;
            Destroy(vfx.gameObject, destroyDelay);
        }
        Destroy(gameObject);
    }
}
