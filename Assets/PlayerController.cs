using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 2f;
    public float attackDamage = 15f;
    private AudioSource audioSource;  // Reference to AudioSource

    void Start()
    {
        // Get the AudioSource component from this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Movement code (optional)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        transform.position += movement * speed * Time.deltaTime;

        // Attack with sword (trigger sound on attack)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySwordSound();  // Play sword sound

            // Example: If the player is within range of the enemy
            GameObject target = GameObject.FindWithTag("Villain");
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= attackRange)
                {
                    HealthBar targetHealth = target.GetComponent<HealthBar>();
                    if (targetHealth != null)
                    {
                        targetHealth.TakeDamage(attackDamage);
                        Debug.Log($"Player attacked {target.name} for {attackDamage} damage.");
                    }
                }
            }
        }
    }

    // Function to play the sword sound
    void PlaySwordSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();  // Play the sound
        }
    }
}
