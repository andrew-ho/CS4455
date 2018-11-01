using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_Room2_Trigger : MonoBehaviour {

    GameObject block_plane;
    Collider player;


	// Use this for initialization
	void Start () {
        block_plane = GameObject.Find("block_plane");
        player = GameObject.Find("vThirdPersonCamera").GetComponent<Collider>();
    }
	
	// Update is called once per frame
    //void Update () 
    //{
    //}

    private void OnTriggerEnter(Collider obj)
    {
        //Debug.Log("triggered!!!!!!!!!!!!!!!!");
        //Debug.Log(obj);
        //Debug.Log(player);
        //if (obj == player) {
        block_plane.SetActive(false);
        //Debug.Log("triggered.............");
        //}
    }
}
