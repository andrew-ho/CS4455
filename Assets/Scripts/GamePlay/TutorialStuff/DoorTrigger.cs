using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public Animator anim;
    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("Up", true);
        obj.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("Up", false);
    }
}
