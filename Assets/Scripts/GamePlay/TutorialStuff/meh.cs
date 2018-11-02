using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Colliding");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0 ,0, -500000), ForceMode.Force);
        }
    }
}
