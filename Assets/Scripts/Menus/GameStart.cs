using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public static string prev = null;
    public void StartGame()
    {
        Scene curr_Scene = SceneManager.GetActiveScene();
        if (curr_Scene.name == "Final_Level_0") {
            //GameObject camera = GameObject.Find("PauseCamera");
            //camera.SetActive(false);
            SceneManager.LoadScene("Final_Level_0");
        }
        else if (curr_Scene.name == "Final_Level_1") {
            SceneManager.LoadScene("Final_Level_1");
        } 
        else if (curr_Scene.name == "GameMenu") {
            SceneManager.LoadScene("Final_Level_0");
        }
        else if (curr_Scene.name == "GameOverScene") {
            SceneManager.LoadScene("GameMenu");
            //if (prev == "Final_Level_0") {
            //    SceneManager.LoadScene("Final_Level_0");
            //} else {
            //    SceneManager.LoadScene("Final_Level_1");
            //}
        }
        else {
            SceneManager.LoadScene("GameMenu");
        }

    }
}
