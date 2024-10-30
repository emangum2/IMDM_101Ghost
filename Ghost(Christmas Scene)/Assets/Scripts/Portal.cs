using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Specify the name of the scene to load
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}