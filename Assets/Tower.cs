using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] AudioClip pewSFX;

    Transform targetEnemy;
    Waypoint waypoint;

    public Waypoint Waypoint
    {
        get
        {
            return waypoint;
        }
        set
        {
            waypoint = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FindTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        float closestDistance = float.MaxValue;
        Transform closestEnemy = null;
        foreach (EnemyDamage enemy in enemies)
        {
            float distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        targetEnemy = closestEnemy;
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
        var audioSource = GetComponent<AudioSource>();
        if (audioSource && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(pewSFX);
        }
    }
}
