using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReturned : MonoBehaviour
{
    // Target location where the player will be placed upon return
    private Vector3 playerReturnPosition = new Vector3(24.67f, 1f, 104.6f);

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