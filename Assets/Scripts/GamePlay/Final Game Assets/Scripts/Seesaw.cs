using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (transform.localEulerAngles.z < 180) {
			transform.localEulerAngles = new Vector3(0, 0, Mathf.Min(transform.localEulerAngles.z, 20.5f));
		} else {
			transform.localEulerAngles = new Vector3(0, 0, Mathf.Max(transform.localEulerAngles.z, 339.5f));
		}
		
		transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -0.086f, 0.086f), Mathf.Clamp(transform.localPosition.y, 1.36f, 1.39f), 0);
	}
}
