using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform openTarget;
    public float speed = 3f;

    private bool shouldOpen = false;

    private void Update()
    {
        if (shouldOpen)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openTarget.position,
                speed * Time.deltaTime
            );
        }
    }

    public void OpenDoor()
    {
        shouldOpen = true;
    }
}