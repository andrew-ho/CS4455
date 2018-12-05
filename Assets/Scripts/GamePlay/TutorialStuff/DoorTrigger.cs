using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public Animator anim;
    public GameObject obj;

    public bool needsCube;

    private void OnCollisionEnter(Collision collision)
    {
    	if (!needsCube || collision.collider.tag == "Cube") {
			anim.SetBool("Up", true);
			if (obj != null) {
				obj.SetActive(false);
			}
    	}
    }

    private void OnCollisionExit(Collision collision)
    {
    	if (!needsCube || collision.collider.tag == "Cube") {
    		anim.SetBool("Up", false);
    	}
    }
}
