using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    Animator anim;
    Camera cam;
    GameObject player;
    GameObject carriedObject;
    Image im;
    public static GameObject frozenObject;
    public Texture2D crosshairImage;
    public Sprite[] sprites;
    int currentPower = 0;
    public enum powerSwitch
    {
        Freeze,
        Magnesis,
        Push
    };
    public powerSwitch power;
    void Start()
    {
        power = powerSwitch.Freeze;
        cam = GameObject.Find("vThirdPersonController").GetComponent<Camera>();
        player = GameObject.Find("vThirdPersonCamera");
        im = GameObject.Find("PowerSprite").GetComponent<Image>();
        anim = GameObject.Find("vThirdPersonCamera").GetComponent<Animator>();
    }
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.speed = .5f;
        } else if (Input.GetKey(KeyCode.Alpha2)) {
            anim.speed = 1f;
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            anim.speed = 2f;
        } else {
            anim.speed = 1f;
        }

        if (Input.GetKey(KeyCode.F)) {
            anim.SetBool("isFreezing", true);
        } else {
            anim.SetBool("isFreezing", false);
        }

        if (Input.GetKey(KeyCode.P)) {
            anim.SetBool("isPushing", true);
        } else {
            anim.SetBool("isPushing", false);
        }

        if (Input.GetKey(KeyCode.E)) {
            anim.SetBool("isPulling", true);
        } else {
            anim.SetBool("isPulling", false);
        }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentPower++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentPower--;

        }
        if (Mathf.Abs(currentPower) % 3 == 0)
        {
            power = powerSwitch.Freeze;
            im.sprite = sprites[0];
        }
        else if (Mathf.Abs(currentPower) % 2 == 1)
        {
            power = powerSwitch.Magnesis;
            im.sprite = sprites[1];
        }
        else if (Mathf.Abs(currentPower) % 3 == 2)
        {
            power = powerSwitch.Push;
            im.sprite = sprites[2];
        }
        if (power == powerSwitch.Freeze)
        {
            FreezeObject();
        }
        else if (power == powerSwitch.Magnesis)
        {
            PushPull();
        }
        else if (power == powerSwitch.Push)
        {
            PushObject();
        }
    }

    public void FreezeObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            ObjectFreeze freeze = hit.collider.gameObject.GetComponent<ObjectFreeze>();
            if (freeze != null)
            {
                if (frozenObject == null)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        freeze.StopObject();
                        //anim.SetBool("isFreezing", true);
                    }
                }
            }
        }
    }

    public void PushPull()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (carriedObject == null)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Magnet magnet = hit.collider.gameObject.GetComponent<Magnet>();
                if (magnet != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!magnet.isHolding)
                        {
                            magnet.isHolding = true;
                            carriedObject = hit.collider.gameObject;
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                carriedObject.GetComponent<Magnet>().isHolding = false;
                carriedObject = null;
            }
            //carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, new Vector3(player.transform.position.x, carriedObject.transform.position.y, 
            //   carriedObject.transform.position.z - Input.GetAxis("Mouse ScrollWheel")), Time.deltaTime * 5f);
            float distance = Vector3.Distance(carriedObject.transform.position, player.transform.position);
            if (distance <= 15f)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    carriedObject.transform.position = Vector3.MoveTowards(carriedObject.transform.position, player.transform.position, -Time.deltaTime * 10f);
                }
            }
            if (distance >= 3f)
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    carriedObject.transform.position = Vector3.MoveTowards(carriedObject.transform.position, player.transform.position, Time.deltaTime * 10f);
                }
        }
    }

    public void PushObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Rigidbody otherRb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mouseDir = mousePos - gameObject.transform.position;
                mouseDir.z = 0.0f;
                mouseDir = mouseDir.normalized;

                //if (Input.GetMouseButtonDown(0))
                if (Input.GetKeyDown(KeyCode.P))
                {
                    //otherRb.AddForce(-mouseDir * 100000);
                    otherRb.AddForce(transform.forward * 1000000);
                    //anim.SetBool("isPushing", true);
                } else {
                    //anim.SetBool("isPushing", false);
                }
            }
        }
    }
}
