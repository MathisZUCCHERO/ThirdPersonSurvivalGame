using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float detectionRadius = 10f;
    public float stopChaseRadius = 14f;

    public bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // find player automatically
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!agent.enabled) return;
        if (!agent.isOnNavMesh) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Start chase
        if (!isChasing && distance <= detectionRadius)
            isChasing = true;

        // Stop chase
        if (isChasing && distance >= stopChaseRadius)
        {
            isChasing = false;
            agent.ResetPath();
        }

        // Chasing logic
        if (isChasing)
        {
            NavMeshHit hit;

            // Try to find valid NavMesh point around player
            if (NavMesh.SamplePosition(player.position, out hit, 2.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
            else
            {
                // Prevent errors by stopping movement
                agent.ResetPath();
            }
        }
    }
}