using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player; // Player object to follow

    // Offset values to position the camera relative to the player
    public Vector3 positionOffset = new Vector3(0f, 5f, -10f); 

    public float rotationSpeed = 5f; // Speed at which the camera rotates with the player

    void LateUpdate()
    {
        // Calculate the camera's new position relative to the player
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(positionOffset);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, rotationSpeed * Time.deltaTime);

        // Rotate the camera to align with the player's forward direction
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}