using UnityEngine;

public class GhostPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    void Update()
    {
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Create movement vector
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed;
        
        // Move the player using Rigidbody
        rb.MovePosition(transform.position + move * Time.deltaTime);
        
        // Jump (optional, if your ghost has jumping)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}