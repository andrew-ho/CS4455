using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {
    public float timer = 5f;
    public float seconds = 0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        seconds += Time.deltaTime;
        if (seconds >= timer)
        {
            Destroy(this.gameObject);
        }
	}
}
