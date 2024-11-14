using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float turnSpeed = 90f; // Speed of rotation (degrees per second)
    public float changeDirectionTime = 2f; // Time before the object changes direction
    public Vector3 areaMin = new Vector3(-10f, 0f, -10f); // Minimum bounds of the area
    public Vector3 areaMax = new Vector3(10f, 0f, 10f); // Maximum bounds of the area

    private float timeSinceLastChange = 0f;
    private Vector3 currentDirection;

    void Start()
    {
        // Start with a random direction
        SetRandomDirection();
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        // Move the object forward in the current direction
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // Check if it's time to change direction
        if (timeSinceLastChange >= changeDirectionTime)
        {
            SetRandomDirection();
            timeSinceLastChange = 0f;
        }

        // Keep the object within the specified area
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, areaMin.x, areaMax.x);
        position.z = Mathf.Clamp(position.z, areaMin.z, areaMax.z);
        transform.position = position;
    }

    // Set a random direction and turn towards it
    void SetRandomDirection()
    {
        float randomY = Random.Range(0f, 360f);
        currentDirection = new Vector3(Mathf.Sin(randomY * Mathf.Deg2Rad), 0f, Mathf.Cos(randomY * Mathf.Deg2Rad));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(currentDirection), turnSpeed * Time.deltaTime);
    }
}