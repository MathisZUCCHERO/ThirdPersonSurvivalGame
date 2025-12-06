using UnityEngine;
using UnityEngine.AI;

public class EnemyRagdoll : MonoBehaviour
{
    public float fallForce = 5f;
    public float destroyDelay = 5f;

    private Rigidbody rb;
    private CapsuleCollider col;
    private NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ActivateRagdoll()
    {
        // Stop AI navigation
        if (agent) agent.enabled = false;

        // Enable physics
        rb.isKinematic = false;
        rb.useGravity = true;

        // Add some fall force so it collapses
        rb.AddForce(Vector3.back * fallForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 5f, ForceMode.Impulse);

        // Destroy after delay
        Destroy(gameObject, destroyDelay);
    }
}