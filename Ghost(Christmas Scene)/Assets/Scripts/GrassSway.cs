using UnityEngine;

public class GrassSway : MonoBehaviour
{
    public float swayAmount = 0.1f; // How much the grass sways
    public float swaySpeed = 2f; // Speed of the swaying motion

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the grass
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate the sway effect using a sine wave
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Apply the sway to the initial position
        transform.localPosition = initialPosition + new Vector3(sway, 0, 0);
    }
}