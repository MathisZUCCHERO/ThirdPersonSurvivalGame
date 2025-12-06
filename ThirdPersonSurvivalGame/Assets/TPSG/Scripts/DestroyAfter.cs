using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float delay = 2f;
    void Start()
    {
        Destroy(gameObject, delay);
    }
}