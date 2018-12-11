using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Push_Script : MonoBehaviour {

    public Animator anim;
    public float inputX;
    public float inputY;

	// Use this for initialization
	void Start () {
        anim = GameObject.Find("Player").GetComponent<Animator>();
        //anim = this.GameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //inputY = Input.GetAxis("Vertical");
        /*if (inputY > 0)
        {
            anim.SetBool("pushbool", true);
        }
        else {
            anim.SetBool("pushbool", false);
        }*/
        //if (Input.GetKey(KeyCode.P)) {
        //    anim.SetBool("pushbool", true);
        //}
        //if (Input.GetKey(KeyCode.U)) {
        //    anim.SetBool("pushbool", false);
        //}

	}
}
