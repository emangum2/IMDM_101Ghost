using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PumpkinRoll : MonoBehaviour

{

    public float speed = 2.0f; // Speed of the rolling

    public float distance = 5.0f; // Distance to roll back and forth

    private Vector3 startingPosition;

    private bool movingForward = true;

    public float spinSpeed = 100.0f; // Missing semicolon fixed

void Start()

{

    startingPosition = transform.position;

}

void Update()

{

    // Calculate the target position based on the direction and distance

    Vector3 targetPosition = startingPosition + (movingForward ? Vector3.right : Vector3.left) * distance;

// Move the pumpkin towards the target position

transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

// Rotate the pumpkin based on spinSpeed

float rotationAmount = spinSpeed * Time.deltaTime;

transform.Rotate(0, rotationAmount, 0);

// Check if the pumpkin has reached the target position

if (Vector3.Distance(transform.position, targetPosition) < 0.01f)

{

    movingForward = !movingForward;

}

    }

// Coroutine to spin back and forth (optional)

private IEnumerator SpinBackAndForth()

{

    while (true)

    {

        // Spin in one direction

        for (float i = 0; i < 180; i += 1)

        {

            transform.Rotate(0, 1, 0);

            yield return null; // Wait for the next frame

        }

// Spin in the opposite direction

for (float i = 180; i > 0; i -= 1)

{

    transform.Rotate(0, -1, 0);

    yield return null; // Wait for the next frame

}

        }

    }

}