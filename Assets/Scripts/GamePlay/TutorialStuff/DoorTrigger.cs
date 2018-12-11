using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public Animator anim;
    public Animator anim2;
    public GameObject obj;

    public bool needsCube;

    private void OnCollisionEnter(Collision collision)
    {
    	if (!needsCube || collision.collider.tag == "Cube") {
    		print("APPLEEEEEEEE");
			if (anim != null) {
				anim.SetBool("Up", true);
			}
			if (anim2 != null) {
				anim2.SetBool("Up", true);
			}
			if (obj != null) {
				obj.SetActive(false);
			}
    	}
    }

    private void OnCollisionExit(Collision collision)
    {
    	if (!needsCube || collision.collider.tag == "Cube") {
    		if (anim != null) {
    			anim.SetBool("Up", false);
    		}
    		if (anim2 != null) {
    			anim2.SetBool("Up", false);
    		}
    	}
    }
}
