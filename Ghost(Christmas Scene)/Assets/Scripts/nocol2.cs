using UnityEngine;

public class nocol2 : MonoBehaviour
{
    public float speed = 5f;           // Movement speed
    public float rotationSpeed = 700f; // Rotation speed
    public float smoothFactor = 0.1f;  // Smooth movement factor
    public float groundCheckDistance = 1.0f; // Distance to check for ground
    public float fallSpeed = 10f;     // Gravity-like fall speed when in mid-air

    private Rigidbody rb;
    private Vector3 movement;
    private float horizontal;
    private float vertical;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set collision detection mode to continuous to avoid tunneling
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Use interpolation for smoother visual movement
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        // Ensure Rigidbody is not kinematic, so it responds to collisions
        rb.isKinematic = false;
    }

    private void Update()
    {
        // Get movement input (WASD or arrow keys)
        horizontal = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right arrow keys
        vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrow keys

        // Calculate movement vector based on input
        movement = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Rotate the player based on movement
        if (movement.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Perform ground check to see if the player is grounded (not hovering)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    private void FixedUpdate()
    {
        // If the player is grounded, move the player normally
        if (isGrounded)
        {
            // Reset any vertical speed to zero if grounded
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            Vector3 targetPosition = transform.position + movement * speed * Time.deltaTime;

            // Smoothly move the player towards the target position using Lerp
            rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, smoothFactor));
        }
        else
        {
            // If the player is not grounded, apply a downward force to simulate gravity/fall
            rb.AddForce(Vector3.down * fallSpeed, ForceMode.Acceleration);  // Adjust fallSpeed to control the fall rate

            // Optionally, apply horizontal drag for smoother control in mid-air
            rb.drag = 3f; // Adjust this value based on how you want the player to behave in the air
        }
    }
}