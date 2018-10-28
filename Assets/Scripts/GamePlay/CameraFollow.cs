using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float cameraMoveSpeed = 120f;
    public GameObject cameraFollowObject;
    Vector3 followPOS;
    public float clampAngle = 80f;
    public float inputSensitivity = 150f;
    public GameObject cameraObj;
    public GameObject playerObj;
    public float camDistanceX;
    public float camDistanceY;
    public float camDistanceZ;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputY;
    public float smoothX;
    public float smoothY;
    private float rotY = 0f;
    public float rotX = 0f;
    // Use this for initialization
    void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
