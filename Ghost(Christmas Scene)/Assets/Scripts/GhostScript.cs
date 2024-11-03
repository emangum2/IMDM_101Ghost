using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostScript : MonoBehaviour
{
    public float movespeed = 1.5f;
    private int count = 0;
    public TextMeshProUGUI countText;

    void Start()
    {
        
        
        count = 0;
        SetCountText();
        
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
           
        }



    }

    void SetCountText()
    {
        countText.text = "Pumpkins Collected:" + count.ToString();

    }

}

