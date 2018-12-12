using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static string prev = null;
    public void StartGame()
    {
        Scene curr_Scene = SceneManager.GetActiveScene();
        if (curr_Scene.name == "Final_Level_0")
        {
            //GameObject camera = GameObject.Find("PauseCamera");
            //camera.SetActive(false);
            SceneManager.LoadScene("Final_Level_1");
        }
        else if (curr_Scene.name == "Final_Level_1")
        {
            SceneManager.LoadScene("CongratScene");
        }

    }
}
