using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target; // The target to rotate towards
    public float rotationSpeed = 5f; // The speed at which to rotate

    // Start is called before the first frame update
    void Start()
    {
        // Automatically assign the target to the Ghost object using its tag
        if (target == null)
        {
            target = GameObject.FindWithTag("Ghost").transform;  // Find object by tag "Ghost"
            
            if (target == null)
            {
                Debug.LogError("Ghost with tag 'Ghost' not found! Please assign the Ghost object.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            RotateTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        // Calculate the direction to the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate the target rotation based on the direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the object towards the target rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}