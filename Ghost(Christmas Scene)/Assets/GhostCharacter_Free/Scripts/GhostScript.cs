using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GhostScript : MonoBehaviour
{
    public float moveSpeed = 3.8f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
   