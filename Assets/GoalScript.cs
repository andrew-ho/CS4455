using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    private GameObject player;
    Scene curr_Scene; 

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        //GameObject button = GameObject.Find("Goal");
        curr_Scene = SceneManager.GetActiveScene();
        //if (curr_Scene.name == "Final_Level_0")
        //{
        //    //GameObject button = GameObject.Find("Goal");
        //    if(button.activeInHierarchy == true) {
        //        SceneManager.LoadScene("Final_Level_1");

        //    }
        //    //button.SetActive(true);
        //}
        //else if (curr_Scene.name == "Final_Level_1")
        //{
        //    if (button.activeInHierarchy == true)
        //    {
        //        SceneManager.LoadScene("CongratScene");

        //    }
        //}
        //else
        //{
        //    SceneManager.LoadScene("Final_Level_0");
        //}




		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Goal") {

                if (curr_Scene.name == "Final_Level_0") {
                    SceneManager.LoadScene("Final_Level_1");
                }

            //SceneManager.LoadScene("Final_Level_1");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
