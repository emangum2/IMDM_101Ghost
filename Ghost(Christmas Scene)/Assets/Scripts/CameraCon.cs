using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public GameObject Ghost;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Ghost.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Ghost.transform.position + offset;
    }
}