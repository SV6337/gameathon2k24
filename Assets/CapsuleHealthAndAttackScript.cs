using UnityEngine;

public class CapsuleHealthAndAttackScript : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // Disable the player or end the game
        Destroy(gameObject);
    }
}
