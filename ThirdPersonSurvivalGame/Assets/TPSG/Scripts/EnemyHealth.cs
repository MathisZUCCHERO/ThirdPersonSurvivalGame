using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 60f;
    private EnemyRagdoll ragdoll;

    public bool isAlive = true;
    
    void Start()
    {
        ragdoll = GetComponent<EnemyRagdoll>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            isAlive = false;
            Die();
        }
    }

    void Die()
    {
        ragdoll.ActivateRagdoll();
    }
}