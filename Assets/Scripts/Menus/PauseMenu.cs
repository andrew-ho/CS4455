using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PauseMenu : MonoBehaviour
{

    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }
    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (canvasGroup.interactable)
            {

                Debug.Log("s"); 
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false; 
                canvasGroup.alpha = 0f;
                Time.timeScale = 1f;
            }   
            else
            {
                Debug.Log("a");

                Cursor.lockState = CursorLockMode.None;
                canvasGroup.interactable = true; 
                canvasGroup.blocksRaycasts = true; 
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
            }
        }
    }

}