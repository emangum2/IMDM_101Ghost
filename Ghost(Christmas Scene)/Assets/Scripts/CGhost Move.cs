using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    private Rigidbody rb;  // Reference to the player's Rigidbody
    private float rotationSpeed = 700f;  // Speed at which the player rotates

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
        // Make sure the Rigidbody is kinematic
        rb.isKinematic = true; // This makes the Rigidbody kinematic (not affected by forces)
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player for horizontal (A/D or Left/Right Arrow keys) and vertical (W/S or Up/Down Arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow keys
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow keys

        // Create a movement vector relative to the player's facing direction (using transform.forward and transform.right)
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Apply movement to the player by directly modifying its position
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the player to face the direction of movement (when moving forward or sideways)
        if (moveDirection.magnitude > 0)
        {
            // Calculate the target rotation based on the movement direction
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}