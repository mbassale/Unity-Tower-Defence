﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip deathSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        if (hitParticlePrefab)
        {
            hitParticlePrefab.Play();
        }
        hitPoints = hitPoints - 1;
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        if (deathParticlePrefab)
        {
            var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();
            float destroyDelay = vfx.main.duration;
            GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Destroy(vfx.gameObject, destroyDelay);
        }
        Destroy(gameObject);
    }
}
