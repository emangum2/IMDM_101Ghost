using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReturned : MonoBehaviour
{
    // Target location where the player will be placed upon return
    public Vector3 playerReturnPosition = new Vector3(30.5f, 6.7f, 0f);

    // Array of objects to make visible when the player returns
    public GameObject[] objectsToShow;

    void Start()
    {
        // Place the player at the specified location
        transform.position = playerReturnPosition;

        // Make all specified objects visible
        MakeObjectsVisible();
    }

    // Function to activate all objects in the array
    void MakeObjectsVisible()
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }
}