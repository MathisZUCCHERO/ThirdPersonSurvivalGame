using UnityEngine;

public class EnemyGrenadeThrow : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public float throwForce = 10f;
    public float throwCooldown = 3f;

    private float timer = 0f;
    private Transform player;
    private EnemyAI ai;  // reference to the chasing state

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ai = GetComponent<EnemyAI>(); // get reference
    }

    void Update()
    {
        timer += Time.deltaTime;

        // ONLY THROW IF CHASING
        if (ai.isChasing && timer >= throwCooldown && ai.GetComponent<EnemyHealth>().isAlive)
        {
            timer = 0f;
            ThrowGrenadeAtPlayer();
        }
    }

    void ThrowGrenadeAtPlayer()
    {
        Vector3 dir = (player.position - throwPoint.position).normalized;

        GameObject g = Instantiate(grenadePrefab, throwPoint.position, Quaternion.LookRotation(dir));
        Rigidbody rb = g.GetComponent<Rigidbody>();
        rb.AddForce(dir * throwForce, ForceMode.VelocityChange);
    }
}