using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour {
    CanvasGroup canvasGroup;
    public void Start()
    {
        canvasGroup = GameObject.Find("NextLevelPanel").GetComponent<CanvasGroup>();
    }

	public void OnCollisionEnter(Collision col)
    {
        GameObject.Find("vThirdPersonCamera").SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }
}
