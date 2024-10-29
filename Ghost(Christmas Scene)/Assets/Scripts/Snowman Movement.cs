using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMovement : MonoBehaviour
{
    public float moveSpeed = 2f;       // Speed at which the snowman moves
    public float moveInterval = 2f;     // Time between direction changes
    public float moveDistance = 3f;     // Distance to move each time
    public float rotationSpeed = 50f;    // Speed of rotation

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        // Set the initial target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Rotate towards the target position for a more dynamic look
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the snowman towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the snowman has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            timer += Time.deltaTime;

            // Change direction after the specified interval
            if (timer >= moveInterval)
            {
                SetRandomTargetPosition();
                timer = 0f; // Reset the timer
            }
        }
    }

    void SetRandomTargetPosition()
    {
        // Choose a random direction and set a new target position
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        targetPosition = transform.position + randomDirection * moveDistance;

        // Optional: Add a slight vertical movement to simulate bouncing
        targetPosition.y += Mathf.Sin(Time.time) * 0.2f; // Adjust the amplitude as needed
    }
}