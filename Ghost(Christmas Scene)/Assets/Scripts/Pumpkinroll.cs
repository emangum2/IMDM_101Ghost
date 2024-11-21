using UnityEngine;

public class PumpkinRoller : MonoBehaviour
{
    public float rollForce = 10f; // Force to make the pumpkin roll
    public float torqueStrength = 5f; // Strength of the torque to make the pumpkin spin

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the pumpkin
        rb = GetComponent<Rigidbody>();

        // Apply initial rolling force to the pumpkin
        ApplyRollingForce();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, trigger rolling based on user input, such as pressing the space bar
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to apply a rolling force
        {
            ApplyRollingForce();
        }
    }

    // Method to apply horizontal rolling force
    void ApplyRollingForce()
    {
        // Choose a random direction for the horizontal rolling (X or Z axis)
        // To roll along the X-axis, you could use Vector3.right (X-axis)
        // To roll along the Z-axis, use Vector3.forward (Z-axis)

        // Example: random horizontal rolling direction along X or Z axis
        int directionChoice = Random.Range(0, 2); // Randomly pick either 0 (X-axis) or 1 (Z-axis)

        Vector3 rollDirection = Vector3.zero;

        if (directionChoice == 0)
        {
            rollDirection = Vector3.right; // Apply force along the X-axis
        }
        else
        {
            rollDirection = Vector3.forward; // Apply force along the Z-axis
        }

        // Apply force to make the pumpkin roll horizontally
        rb.AddForce(rollDirection * rollForce, ForceMode.Impulse);

        // Apply torque to make the pumpkin spin and roll more realistically
        Vector3 randomTorque = new Vector3(
            Random.Range(-torqueStrength, torqueStrength), // Random torque on X-axis
            Random.Range(-torqueStrength, torqueStrength), // Random torque on Y-axis
            Random.Range(-torqueStrength, torqueStrength)  // Random torque on Z-axis
        );

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}