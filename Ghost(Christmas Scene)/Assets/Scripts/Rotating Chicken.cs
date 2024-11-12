//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RotatingChicken : MonoBehaviour
//{

//    // Update is called once per frame
//    void Update()
//    {
//        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRotatingChicken : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the chicken moves
    public float changeDirectionTime = 3f; // Time interval to change direction
    public float stopDuration = 4f; // Duration to stop moving

    private Vector3 moveDirection;
    private bool isMoving = true;

    void Start()
    {
        // Set an initial random direction
        ChangeDirection();
        StartCoroutine(ChangeDirectionCoroutine());
        StartCoroutine(MoveStopCoroutine());
    }

    void Update()
    {
        // Move the chicken if it's moving
        if (isMoving)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            // Face the direction of movement
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }

    private void ChangeDirection()
    {
        // Set a new random direction
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized; // Normalize to ensure consistent speed
    }

    private IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionTime);
            ChangeDirection();
        }
    }

    private IEnumerator MoveStopCoroutine()
    {
        while (true)
        {
            // Move for a while
            isMoving = true;
            yield return new WaitForSeconds(changeDirectionTime); // Duration before stopping

            // Stop moving
            isMoving = false;
            yield return new WaitForSeconds(stopDuration); // Duration to stop
        }
    }
}
