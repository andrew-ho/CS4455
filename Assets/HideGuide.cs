using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class HideGuide : MonoBehaviour
{
    bool isHidden;
    CanvasGroup canvasGroup;

    void Awake()
    {
        //GameObject camera = GameObject.Find("PauseCamera");
        //camera.SetActive(true);
        canvasGroup = GetComponent<CanvasGroup>();
        isHidden = false;

    }
    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {

            hide();
        }
    }

    public void hide() {

        if (isHidden == false)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false; 
                canvasGroup.alpha = 0f;
                isHidden = true;
            }   
            else if (isHidden == true)
            {
                canvasGroup.interactable = true; 
                canvasGroup.blocksRaycasts = true; 
                canvasGroup.alpha = 1f;
                 isHidden = false;
            }
        

    }

}