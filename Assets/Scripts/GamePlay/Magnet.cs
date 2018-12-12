using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
    //Vector3 objectPos;
    float distance;

    public bool canHold = true;
    GameObject item;
    GameObject tempParent;
    public bool isHolding = false;
    private bool wasHolding = false;
    Camera cam;
    public bool carry;
    public float dis;
    public float smooth;
    public GameObject carriedObject;

    private bool startingGravity;
    private Transform startingParent;
    private Rigidbody rb;
    private Vector3 pos;
    private Vector3 rot;

    // Use this for initialization
    void Start () {
        item = this.gameObject;
        cam = GameObject.Find("vThirdPersonController").GetComponent<Camera>();
        tempParent = GameObject.Find("Guide");

        rb = item.GetComponent<Rigidbody>();
        startingGravity = item.GetComponent<Rigidbody>().useGravity;
        startingParent = item.transform.parent;
    }
	
	// Update is called once per frame
	void Update () {
        if (isHolding)
        {
            if (!wasHolding) {
                pos = item.transform.position;
                rot = transform.eulerAngles;

                if (item.name == "Bottom Support Rod") {
                    rb.constraints = rb.constraints & ~RigidbodyConstraints.FreezePositionX;
                }
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
            rb.useGravity = false;
            if ((rb.constraints & RigidbodyConstraints.FreezePositionX) != RigidbodyConstraints.None) {
                transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
            }
            if ((rb.constraints & RigidbodyConstraints.FreezePositionY) != RigidbodyConstraints.None) {
                transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
            }
            if ((rb.constraints & RigidbodyConstraints.FreezePositionZ) != RigidbodyConstraints.None) {
                transform.position = new Vector3(transform.position.x, transform.position.y, pos.z);
            }
            if ((rb.constraints & RigidbodyConstraints.FreezeRotation) != RigidbodyConstraints.None) {
                transform.eulerAngles = rot;
            }
        }
        else
        {
            //objectPos = item.transform.position;
            item.transform.SetParent(startingParent);
            rb.useGravity = startingGravity;

            if (item.name == "Bottom Support Rod") {
                rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX;
            }
        }

        if (item.name == "Top Support Rod") {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, 28.4f, 37.6f));
        }
        if (item.name == "Bottom Support Rod") {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 74.55f, 83.95f), transform.position.y, transform.position.z);
        }
        if (item.name == "Piston 2") {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -15.55f, -11.15f));
        }
        wasHolding = isHolding;
	}
    void carrying(GameObject o)
    {
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
    /*private void OnMouseUp()
    {
        isHolding = false;
    }*/
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
