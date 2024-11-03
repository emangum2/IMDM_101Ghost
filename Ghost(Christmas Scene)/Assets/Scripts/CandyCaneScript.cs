using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation

    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}