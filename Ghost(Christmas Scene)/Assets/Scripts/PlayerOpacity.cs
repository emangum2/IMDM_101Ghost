using UnityEngine;

public class PlayerOpacity : MonoBehaviour
{
    private Renderer playerRenderer;
    private Color playerColor;
    public float opacityIncreaseAmount = 0.1f; // Amount to increase opacity
    private int collectiblesCollected = 0; // Count of collected collectibles

    void Start()
    {
        // Get the Renderer component
        playerRenderer = GetComponent<Renderer>();
        playerColor = playerRenderer.material.color;
    }

    public void IncreaseOpacity()
    {
        // Increase the count of collectibles collected
        collectiblesCollected++;

        // Calculate new opacity
        float newOpacity = Mathf.Clamp01(playerColor.a + opacityIncreaseAmount * collectiblesCollected);

        // Set the new color with updated opacity
        playerColor.a = newOpacity;
        playerRenderer.material.color = playerColor;
    }
}