using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour, TimeStop {
    public bool stopped = false;
    public float timer = 0f;

    public void Stop()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0f;
            stopped = false;
        }
    }
	// Use this for initialization
	void Start () {
		
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

        }
	}
}
