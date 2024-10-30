using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class SceneChanger : MonoBehaviour
{
    // Specify the name of the scene to load
    public string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with this GameObject has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
