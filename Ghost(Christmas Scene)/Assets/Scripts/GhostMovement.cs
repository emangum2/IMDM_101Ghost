using UnityEngine;
public class ArrowKeyMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float rotationSpeed = 200f; // Rotation speed (degrees per second)
    // Rigidbody of the player.
    private Rigidbody rb;
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Handle player input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move forward without rotating
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // Turn around and move backwards
            TurnAround();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Turn left and move forward
            TurnLeft();
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Turn right and move forward
            TurnRight();
            MoveForward();
        }
    }
    private void MoveForward()
    {
        // Apply force to move forward along the object's local z-axis
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
    private void TurnAround()
    {
        // Rotate the object 180 degrees and move backward
        rb.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
        rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
    }
    private void TurnLeft()
    {
        // Rotate the object left (counter-clockwise)
        rb.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - rotationSpeed * Time.deltaTime, 0);
    }
    private void TurnRight()
    {
        // Rotate the object right (clockwise)
        rb.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, 0);
    }
}

