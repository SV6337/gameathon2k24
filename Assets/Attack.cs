using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;

    private float lastAttackTime;

    private void Update()
    {
        // Find the player or villain to attack
        GameObject target = GameObject.FindWithTag("Player"); // Use "Villain" tag for the player attacking
        if (target == null) return;

        // Check distance
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            // Attack the target
            HealthBar targetHealth = target.GetComponent<HealthBar>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(attackDamage);
                Debug.Log($"{gameObject.name} attacked {target.name} for {attackDamage} damage.");
            }
            lastAttackTime = Time.time;
        }
    }
}
