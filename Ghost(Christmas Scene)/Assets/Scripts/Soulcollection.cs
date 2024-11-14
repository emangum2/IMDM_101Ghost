using UnityEngine;

public class SoulCollectible : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the pumpkin
        if (other.CompareTag("Player"))
        {
            // Increment the score or collectible count
            ScoreManager.Instance.AddScore(1);
            // Optionally, you can play a sound effect or animation here

            // Destroy the pumpkin object
            Destroy(gameObject);
        }
    }
}
