using UnityEngine;
using System.Collections;

public class RandomMovementWithFloor : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float range = 10f;    // The range within which the object can move
    public float changeInterval = 2f; // Time interval between random position changes
    public float groundHeight = 0f;  // Y position for the floor (assuming it's at y = 0)

    private Vector3 targetPosition;

    void Start()
    {
        // Set the initial target position to a random point on the plane
        SetNewRandomTarget();
        
        // Start the random movement coroutine
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            // Move the object towards the target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null; // Wait until next frame
            }

            // Wait for the specified interval before changing the target position again
            yield return new WaitForSeconds(changeInterval);
            
            // Set a new random target position
            SetNewRandomTarget();
        }
    }

    void SetNewRandomTarget()
    {
        // Generate a random target position with Y fixed to the ground height (floor level)
        targetPosition = new Vector3(
            Random.Range(-range, range),   // Random X position
            groundHeight,                  // Fixed Y position (e.g., ground level)
            Random.Range(-range, range)    // Random Z position
        );
    }
}