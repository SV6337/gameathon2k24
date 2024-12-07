using UnityEngine;

public class VillainHealthAndAttackScript : MonoBehaviour
{
    public float health = 100f; // Villain's health
    public float attackDamage = 10f; // Damage per attack
    public float attackRange = 2f; // Attack range
    public float attackCooldown = 1f; // Cooldown time between attacks

    private float lastAttackTime = 0f;

    public Transform target; // Reference to the player
    private CapsuleHealthAndAttackScript playerHealth;

    private void Start()
    {
        if (target != null)
        {
            playerHealth = target.GetComponent<CapsuleHealthAndAttackScript>();
        }
    }

    private void Update()
    {
        MoveTowardsPlayer();

        // Check if the player is in attack range and attack
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            Attack();
        }
    }

    void MoveTowardsPlayer()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * 3f; // Adjust speed
        transform.LookAt(target.position);
    }

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            if (playerHealth != null)
            {
                Debug.Log("Villain is attacking the player!");
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Villain Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Villain has died!");
        Destroy(gameObject);
    }
}
