using UnityEngine;

public class VillainScript : MonoBehaviour
{
    public Transform target; // Reference to the player capsule
    public float speed = 5f; // Movement speed of the villain

    private void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        // Calculate direction from villain to player
        Vector3 direction = (target.position - transform.position).normalized;

        // Move the villain in the direction of the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
