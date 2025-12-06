using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float fuseTime = 2f;
    public float explosionRadius = 5f;
    public float damage = 50f;
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    private void Start()
    {
        Invoke(nameof(Explode), fuseTime);
    }

    void Explode()
    {
        // Spawn VFX
        if (explosionEffect)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        if (explosionSound)
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        // Damage everything in radius
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider c in hits)
        {
            // Player
            if (c.CompareTag("Player"))
            {
                PlayerHealth ph = c.GetComponent<PlayerHealth>();
                if (ph) ph.TakeDamage(damage);
            }

            // Enemy
            EnemyHealth eh = c.GetComponent<EnemyHealth>();
            if (eh) eh.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}