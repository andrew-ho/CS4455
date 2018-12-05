using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFreeze : MonoBehaviour {
    public bool stopped = false;
    public float timer = 0f;
    Animator anim;
    Rigidbody rb;

    private RigidbodyConstraints initRbConstraints;

    public void Stop() {
        timer += Time.deltaTime;
        if (timer > 5) {
            timer = 0f;
            rb.constraints = initRbConstraints;
            stopped = false;
            PlayerController.frozenObject = null;
            if (anim != null) {
                anim.enabled = true;
            }
            foreach (Transform child in transform) {
                ResumeChildObject(child);
            }

            if (gameObject.name == "Safety Collider") {
                GetComponent<Collider>().enabled = true;
            }
        }
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        initRbConstraints = rb.constraints;
	}
	
	// Update is called once per frame
	void Update () {
        if (stopped) {
            Stop();
            return;
        }
        
    }

    public void StopObject() {
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        if (anim != null) {
            anim.enabled = false;
        }
        stopped = true;
        PlayerController.frozenObject = rb.gameObject;
        foreach (Transform child in transform) {
            StopChildObject(child);
        }

        if (gameObject.name == "Safety Collider") {
            GetComponent<Collider>().enabled = false;
        }
    }

    public void StopChildObject(Transform obj) {
        if (obj.gameObject.GetComponent<Animator>() != null) {
            obj.gameObject.GetComponent<Animator>().enabled = false;
        }
        foreach (Transform child in obj) {
            StopChildObject(child);
        }
    }

    public void ResumeChildObject(Transform obj) {
        if (obj.gameObject.GetComponent<Animator>() != null) {
            obj.gameObject.GetComponent<Animator>().enabled = true;
        }
        foreach (Transform child in obj) {
            ResumeChildObject(child);
        }
    }
}
