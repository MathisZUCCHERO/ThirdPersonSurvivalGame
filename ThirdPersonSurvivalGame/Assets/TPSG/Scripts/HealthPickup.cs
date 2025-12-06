using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public float healAmount = 30f;
    public AudioClip pickupSound;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.currentHealth += healAmount;
            health.currentHealth = Mathf.Min(health.currentHealth, health.maxHealth);
        }

        if (pickupEffect)
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject);
    }
}