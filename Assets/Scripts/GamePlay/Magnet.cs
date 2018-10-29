using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    public Camera cam;
    public bool carry;
    public float dis;
    public float smooth;
    public GameObject carriedObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
            //item.transform.position = Vector3.Lerp(item.transform.position,
            //tempParent.transform.position + tempParent.transform.forward * dis, Time.deltaTime * smooth);
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
        }
	}
    void carrying(GameObject o)
    {
        //Debug.Log("Boo");
        if (o != null)
        {
            Rigidbody rb = o.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.transform.position = Vector3.Lerp(o.transform.position,
            cam.transform.position + cam.transform.forward * dis, Time.deltaTime * smooth);
        }
        else
        {
            carry = false;
            carriedObject = null;
        }
    }

    private void OnMouseDown()
    {
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
    }
    private void OnMouseUp()
    {
        isHolding = false;
    }
    /*void pickup()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
            Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable o = hit.collider.GetComponent<Pickupable>();
                if (o != null)
                {
                    carry = true;
                    carriedObject = o.gameObject;
                    Rigidbody rb = o.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.freezeRotation = true;
                }
                if (hit.collider != null && hit.collider.gameObject.GetComponent<IUsable>() != null)
                {
                    hit.collider.gameObject.GetComponent<IUsable>().Use();
                }
            }
        }
    }

    void checkDrop(GameObject o)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject(o);
        }
    }

    void dropObject(GameObject o)
    {
        if (o == null)
        {
            carry = false;
        }
        else
        {
            carry = false;
            Rigidbody rb = o.GetComponent<Rigidbody>();
            rb.useGravity = true;
            //rb.isKinematic = false;
            carriedObject = null;
        }
    }*/
}
