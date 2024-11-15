using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public Transform target; // The target (ghost) to follow
    public Vector3 offset;   // Offset from the target position
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    // starting location for ghost 
    void Start()
    {
        // Set a default offset directly behind the player if not set
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 2, -5); // Position the camera behind and slightly above

        }

    }

    void LateUpdate()
    {
        // Calculate the desired position directly behind the target
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        
        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Update camera position
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target.position + Vector3.up * -0.1f); // Look slightly above the target for a better view
    }
}
