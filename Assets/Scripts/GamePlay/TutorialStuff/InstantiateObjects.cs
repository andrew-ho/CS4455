using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour {
    public GameObject obj;
    public int size;
    public static List<GameObject> objLimit;
    float timer = 0f;
    public float waitTime;
    public bool addForce = false;
	// Use this for initialization
	void Start () {
        objLimit = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            GameObject o = Instantiate(obj, transform.position, Quaternion.identity);
            if (addForce)
            {
                o.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -2000000), ForceMode.Force);
            }
            timer = 0;
        }
	}
}
