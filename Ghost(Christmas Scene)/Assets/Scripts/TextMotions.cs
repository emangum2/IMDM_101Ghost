using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject IntroTextObject; 
    public GameObject InstructionTextObject; 
    public GameObject SummTextObject;


    private float timer = 0f;    


    void Start()
    {
        IntroTextObject.SetActive(true);
        InstructionTextObject.SetActive(false);
        SummTextObject.SetActive(false);

 
    }

    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= 0f && timer <= 5f) 
        {
            IntroTextObject.SetActive(true);
            InstructionTextObject.SetActive(false);
            SummTextObject.SetActive(false);
        }
        else if (timer > 5f && timer <= 10f)
        {
            IntroTextObject.SetActive(false);
            InstructionTextObject.SetActive(true);
            SummTextObject.SetActive(false);
        }
        else if (timer > 10f && timer <= 15f) 
        {
            IntroTextObject.SetActive(false);
            InstructionTextObject.SetActive(false);
            SummTextObject.SetActive(true);
        }
        else if (timer > 15f)
        {
            IntroTextObject.SetActive(false);
            InstructionTextObject.SetActive(false);
            SummTextObject.SetActive(false);
        }

    }
}