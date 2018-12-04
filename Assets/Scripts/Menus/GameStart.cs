using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        Scene curr_Scene = SceneManager.GetActiveScene();
        if (curr_Scene.name == "Level_01") {
            SceneManager.LoadScene("Level_01");
        } else if (curr_Scene.name == "Level_02") {
            SceneManager.LoadScene("Level_02");
        } else if (curr_Scene.name == "Level_03") {
            SceneManager.LoadScene("Level_03");
        } else if (curr_Scene.name == "Level_04") {
            SceneManager.LoadScene("Level_04");
        } else {
            SceneManager.LoadScene("Tutorial");
        } 
    }
}
