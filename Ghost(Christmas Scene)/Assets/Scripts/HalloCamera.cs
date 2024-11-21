using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;            // The player's transform
    public float height = 5f;           // Height of the camera relative to the player
    public float horizontalOffset = 10f; // Horizontal distance between the camera and the player
    public float smoothSpeed = 0.125f;  // Speed at which the camera follows the player

    private Vector3 offset;             // The initial offset between camera and player

    // Start is called before the first frame update
    void Start()
    {
        // Set initial offset, you can adjust this to suit your game
        offset = new Vector3(horizontalOffset, height, 0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Follow the player's position horizontally
        FollowPlayer();
    }

    // Follow the player's position horizontally without bobbing
    void FollowPlayer()
    {
        // Get the target position of the camera
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}