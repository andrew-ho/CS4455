using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    Rigidbody rb;
    Camera cam;
    GameObject player;
    private Vector3 moveDirection = Vector3.zero;
    void Start () {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("vThirdPersonController").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * 5f;

        rb.MovePosition(transform.position + moveDirection * Time.deltaTime);
        //Camera mycam = GetComponent<Camera>();
        cam.transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane)), Vector3.up);
    }
}
