using UnityEngine;

public class LandMine : MonoBehaviour
{
    public float damage = 80f;
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        triggered = true;

        // Play sound
        if (explosionSound)
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        
        // Spawn VFX
        if (explosionEffect)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Damage Player
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph) ph.TakeDamage(damage);
        }

        // Damage Enemy
        EnemyHealth eh = other.GetComponent<EnemyHealth>();
        if (eh) eh.TakeDamage(damage);

        // Destroy mine
        Destroy(gameObject);
    }
}