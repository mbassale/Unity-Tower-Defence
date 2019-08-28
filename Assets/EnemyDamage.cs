using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip pewSFX;
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
            GetComponent<AudioSource>().PlayOneShot(pewSFX);
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
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            Destroy(vfx.gameObject, destroyDelay);
        }
        Destroy(gameObject);
    }
}
