using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public SlidingDoor door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerInventory.hasKey)
            {
                door.OpenDoor();
            }
            else
            {
                Debug.Log("You need the key!");
            }
        }
    }
}