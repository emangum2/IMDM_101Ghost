using UnityEngine;

public class HoverandSpin : MonoBehaviour
{
    public float hoverHeight = 1f; // The height the object will hover
    public float hoverSpeed = 2f;  // Speed of the hover up and down movement
    public float rotationSpeed = 50f; // Speed of the rotation around the Y-axis

    private Vector3 startPosition; // To store the initial position of the object

    private void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;
    }

    private void Update()
    {
        Hover();
        Spin();
    }

    // Hover function to make the object move up and down
    private void Hover()
    {
        // Apply a sine wave-based vertical movement (smooth up and down)
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Spin function to rotate the object around the Y-axis
    private void Spin()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}