using UnityEngine;

public class CapsuleHealthScript : MonoBehaviour
{
    public float health = 100f; // Capsule health

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Capsule Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Capsule has died!");
        // Here you can add death logic, such as disabling the capsule or triggering an animation
    }
}
