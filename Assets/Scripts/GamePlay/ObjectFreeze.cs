using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFreeze : MonoBehaviour {
    public bool stopped = false;
    public float timer = 0f;
    Animator anim;
    Rigidbody rb;
    public void Stop()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0f;
            rb.constraints = RigidbodyConstraints.None;
            stopped = false;
            PlayerController.frozenObject = null;
            anim.enabled = true;
        }
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (stopped)
        {
            Stop();
            return;
        }
        
    }

    public void StopObject()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        anim.enabled = false;
        stopped = true;
        PlayerController.frozenObject = rb.gameObject;
    }
}
