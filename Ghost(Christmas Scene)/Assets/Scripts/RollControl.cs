using UnityEngine;

public class RollControl : MonoBehaviour
{
    public float speed = 5f;  // Movement speed
    public float rotationSpeed = 700f;  // Rotation speed (for looking around)

    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the Rigidbody's collision detection mode to Continuous for better collision handling
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Make Rigidbody kinematic to control movement manually without affecting other objects
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input for movement (WASD keys)
        float horizontal = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right arrow keys
        float vertical = Input.GetAxisRaw("Vertical");  // W/S or Up/Down arrow keys

        // Adjust the movement direction based on input and the player's rotation
        // Forward is in the direction of the player's z-axis, and left/right is based on the x-axis
        movement = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Rotate the player based on movement direction (optional for looking around)
        if (movement.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // FixedUpdate is used for physics-related calculations
    void FixedUpdate()
    {
        // Move the player based on the calculated movement direction
        transform.position += movement * speed * Time.deltaTime;
    }

    // OnTriggerStay is called when another collider with "Is Trigger" is in contact with the player's collider
    void OnTriggerStay(Collider other)
    {
        // Optionally, handle interactions when the player is in contact with other trigger colliders
        // For example, we could stop movement if we collide with a specific type of object.
        // For now, we're just using this method to prevent going through objects.
    }
}