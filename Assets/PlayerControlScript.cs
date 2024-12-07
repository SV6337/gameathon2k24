using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float attackRange = 2f; // Attack range
    public float attackDamage = 15f; // Damage per attack
    public float attackCooldown = 1f; // Cooldown time between attacks

    private float lastAttackTime = 0f;

    public Transform target; // Reference to the villain
    private VillainHealthAndAttackScript villainHealth;

    private void Start()
    {
        if (target != null)
        {
            villainHealth = target.GetComponent<VillainHealthAndAttackScript>();
        }
    }

    private void Update()
    {
        HandleMovement();

        // Attack on pressing Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            Debug.Log("Player is attacking!");
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                if (villainHealth != null)
                {
                    villainHealth.TakeDamage(attackDamage);
                }
            }
            else
            {
                Debug.Log("Villain is out of range!");
            }
        }
    }
}
