using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectVisibilityController : MonoBehaviour
{
    private GameObject targetObject; 

    void Start()
    {
        targetObject = gameObject; 
        SceneManager.sceneLoaded += OnSceneLoaded;
        HideObject();
    }

    void HideObject()
    {
        targetObject.SetActive(false);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ShowObject();
    }

    void ShowObject()
    {
        targetObject.SetActive(true);
    }

    void OnDestroy()
    {
  
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}