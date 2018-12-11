﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PauseMenu : MonoBehaviour
{

    CanvasGroup canvasGroup;

    void Awake()
    {
        //GameObject camera = GameObject.Find("PauseCamera");
        //camera.SetActive(true);
        canvasGroup = GetComponent<CanvasGroup>();

    }
    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {

            ShowPauseMenu();
        }
    }

    public void ShowPauseMenu() {

            if (canvasGroup.interactable)
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false; 
                canvasGroup.alpha = 0f;
                Time.timeScale = 1f;
            }   
            else
            {
                Cursor.lockState = CursorLockMode.None;
                canvasGroup.interactable = true; 
                canvasGroup.blocksRaycasts = true; 
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
            }
        

    }

}