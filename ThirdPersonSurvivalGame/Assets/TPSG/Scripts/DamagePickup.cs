using UnityEngine;

public class DamagePickup : MonoBehaviour
{
    public float damageAmount = 20f;
    public AudioClip pickupSound;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerGrenadeThrow grenade = other.GetComponent<PlayerGrenadeThrow>();
        if (grenade != null)
        {
            grenade.grenadePrefab.GetComponent<Grenade>().damage += damageAmount;
        }

        if (pickupEffect)
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject);
    }
}