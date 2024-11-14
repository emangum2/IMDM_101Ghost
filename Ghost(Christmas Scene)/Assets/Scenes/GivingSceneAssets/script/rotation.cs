using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
 public Transform target; 
 public float rotationSpeed = 5f;

 void Update()
 {
    RotateTowardsTarget();
 }

void RotateTowardsTarget()
{
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion targetRotation = Quaternion.LookRotation(direction);
    transform.rotation = Quaternion.Slerp(
        transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    
}

}