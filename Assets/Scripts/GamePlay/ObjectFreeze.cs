using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFreeze : MonoBehaviour {
    public bool stopped = false;
    public float timer = 0f;
    public Rigidbody rb;
    public void Stop()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0f;
            rb.constraints = RigidbodyConstraints.None;
            stopped = false;
        }
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (stopped)
        {
            Stop();
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                stopped = true;
            }
        }
    }
}
