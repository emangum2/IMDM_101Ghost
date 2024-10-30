using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the PlayerOpacity component
        PlayerOpacity playerOpacity = other.GetComponent<PlayerOpacity>();

        if (playerOpacity != null)
        {
            // Increase the player's opacity
            playerOpacity.IncreaseOpacity();

            // Optionally, destroy the collectible after collection
            Destroy(gameObject);
        }
    }
}