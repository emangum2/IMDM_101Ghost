using UnityEngine;

public class RevisedScript : MonoBehaviour
{
    // Player movement variables
    public float moveSpeed = 5f; // Player movement speed
    public float mouseSensitivity = 2f; // Mouse sensitivity for camera panning
    public Transform cameraTransform; // Reference to the camera's Transform (pivot object)

    private float pitch = 0f; // Vertical angle for camera
    private float yaw = 0f; // Horizontal angle for camera
    private float roll = 0f; // Optional roll for camera rotation (set to 0 if no roll needed)
    private Vector3 moveDirection; // To store current movement direction
    private Quaternion targetRotation; // To store the target rotation based on movement direction

    private void Update()
    {
        // Handle player movement with WASD keys
        HandleMovement();

        // Handle camera panning with mouse movement
        HandleCameraPanning();
    }

    private void HandleMovement()
    {
        // Get input from WASD keys (horizontal and vertical)
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right (Raw for immediate input)
        float vertical = Input.GetAxisRaw("Vertical"); // W/S or Up/Down (Raw for immediate input)

        // Calculate the movement direction based on the camera's forward and right direction
        moveDirection = (transform.right * horizontal + transform.forward * vertical).normalized;

        // If there's a valid movement direction (i.e., the player is pressing a key), move
        if (moveDirection != Vector3.zero)
        {
            // Update the player's rotation to face the movement direction
            targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f); // Smooth rotation

            // Move the player in the direction they are facing
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void HandleCameraPanning()
    {
        // Get mouse input for camera rotation (X and Y axes)
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update the yaw and pitch based on mouse input
        yaw += mouseX * mouseSensitivity;
        pitch -= mouseY * mouseSensitivity;

        // Limit the pitch (vertical rotation) to avoid flipping the camera
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Apply the camera rotation around the player
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, roll);
    }
}