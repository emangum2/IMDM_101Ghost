using UnityEngine;

public class Bob : MonoBehaviour
{
    public float amplitude = 0.5f; // The height of the bob
    public float frequency = 1f;    // Speed of the bobbing

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}