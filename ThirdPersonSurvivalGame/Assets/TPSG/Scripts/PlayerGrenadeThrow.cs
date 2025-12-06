using UnityEngine;

public class PlayerGrenadeThrow : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public float throwForce = 10f;
    public AudioClip throwSound;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        if (throwSound && audioSource)
            audioSource.PlayOneShot(throwSound);
        
        GameObject g = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = g.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
    }
}