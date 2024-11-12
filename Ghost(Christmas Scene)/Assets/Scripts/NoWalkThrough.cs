using UnityEngine;

public class PreventPlayerThrough : MonoBehaviour
{
    // Reference to the collider of the object
    private Collider objectCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Get the collider attached to this object
        objectCollider = GetComponent<Collider>();

        if (objectCollider == null)
        {
            Debug.LogError("No Collider found on the object!");
        }

        // Ensure the object has a Rigidbody (optional, if you need physics-based interaction)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            // Optionally, add a Rigidbody if the object needs physics-based collision
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Set it to kinematic if you don't want it to be affected by physics directly.
        }
    }

    // You could also use OnCollisionEnter or OnTriggerEnter if you want to perform specific actions
    // when a collision occurs with the player or another object.

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Prevent the player from moving through the object (default physics behavior)
            Debug.Log("Player collided with an object and cannot move through it.");
        }
    }

    // Optional: Use this method if you want to prevent trigger-based movement
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // You can handle additional logic here if needed when the player enters a trigger zone.
            Debug.Log("Player entered a trigger area of the object.");
        }
    }
}
