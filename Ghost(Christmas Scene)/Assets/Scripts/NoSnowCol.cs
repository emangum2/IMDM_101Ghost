using UnityEngine;

public class NoSnowCol : MonoBehaviour
{
    public float speed = 5f;          // Movement speed
    public float rotationSpeed = 700f; // Rotation speed for looking around
    public float smoothFactor = 0.1f; // Smooth movement factor, adjust for smoother motion

    private Rigidbody rb;
    private Vector3 movement;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody's collision detection mode is Continuous for proper collision handling
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Enable Rigidbody interpolation for smoother movement visuals
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        // Make sure the Rigidbody is not kinematic to allow physical interaction with colliders
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input for movement (WASD keys)
        horizontal = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right arrow keys
        vertical = Input.GetAxisRaw("Vertical");  // W/S or Up/Down arrow keys

        // Calculate the movement vector
        movement = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Rotate the player based on movement direction
        if (movement.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // FixedUpdate is used for physics-related calculations
    void FixedUpdate()
    {
        // Smoothly move the player while respecting the terrain collider
        Vector3 targetPosition = transform.position + movement * speed * Time.deltaTime;

        // Move the player smoothly towards the target position
        rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, smoothFactor));
    }

    // OnCollisionEnter is called when the player collides with any collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with the specific terrain object
        if (collision.gameObject.name == "Snow_Medium_Terrain_1")
        {
            // Handle the collision if necessary (e.g., stop player movement, play sound, etc.)
            // For now, this just ensures that the player collides with it but doesn't go through it.
            Debug.Log("Player collided with Snow_Medium_Terrain_1!");
        }
    }
}