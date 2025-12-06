using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collected = true;
            PlayerInventory.hasKey = true;
            Destroy(gameObject);
        }
    }
}