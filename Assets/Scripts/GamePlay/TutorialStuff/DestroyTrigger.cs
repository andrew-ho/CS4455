using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Destroy(otherObject);
    }
}
