using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class GoalScript : MonoBehaviour {

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GameObject.Find("LevelFinishCanvas").GetComponent<CanvasGroup>();
        HideGameOverMenu();
        //GameOverMenu = GameObject.Find("GameOverMenu");
        //GameOverMenu.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            //SceneManager.LoadScene("Final_Level_1");
            StartCoroutine(ShowGameOverMenu());
        }
    }

    IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(0f);

        //GameOverMenu.SetActive(true);

        //GameStart.prev = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene("GameOverScene");
        //SceneManager.LoadScene("GameOverScene");

        Cursor.lockState = CursorLockMode.None;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void HideGameOverMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
    }

}
