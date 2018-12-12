using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -21) {
			Destroy(gameObject);
		}
	}
}
