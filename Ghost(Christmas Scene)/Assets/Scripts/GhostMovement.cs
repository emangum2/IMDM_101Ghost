using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Movement speed
    public float rotationSpeed = 700f;  // Speed at which the player rotates

    private Rigidbody rb;               // Rigidbody component for physics-based movement

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD keys or arrow keys
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

        // Create a movement vector based on input
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player if there's any input
        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player
            MovePlayer(moveDirection);

            // Rotate the player to face the direction of movement
            RotatePlayer(moveDirection);
        }
    }

    // Method to move the player using Rigidbody
    void MovePlayer(Vector3 direction)
    {
        // Apply movement to the Rigidbody (in world space)
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    // Method to rotate the player smoothly
    void RotatePlayer(Vector3 direction)
    {
        // Create a target rotation based on the movement direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the player towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
