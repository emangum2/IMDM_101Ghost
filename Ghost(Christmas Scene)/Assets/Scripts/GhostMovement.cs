using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    void Update()
    {
        // Get input from WASD keys
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow keys

        // Create a movement vector based on player's local space
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Check if there is any movement input
        if (move.magnitude > 0)
        {
            // Normalize the movement vector to ensure consistent speed
            move.Normalize();

            // Move the player
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            // Make the ghost face the direction of movement
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Smooth rotation
        }
    }
}