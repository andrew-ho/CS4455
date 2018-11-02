using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject belt;
    public Transform endPoint;
    public float speed;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay(Collision collision)
    {
        collision.transform.position = Vector3.MoveTowards(collision.transform.position, 
            endPoint.position, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }

}
