using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization

    Camera cam;
    GameObject player;
    GameObject carriedObject;
    Image im;
    public static GameObject frozenObject;
    public static GameObject theObject;
    public Texture2D crosshairImage;
    public Sprite[] sprites;
    int currentPower = 0;
    private int layerMask = ~(1 << 8);
    Vector3 movement;
    Rigidbody rb;
    Animator anim;
    float m_OrigGroundCheckDistance;
    float m_GroundCheckDistance = 0.1f;
    public float movementSpeed = 5.0f;
    public float playerJumpHeight = .1f;
    SoundsHolder holder;
    AudioSource audio;

    public enum powerSwitch
    {
        Freeze,
        Magnesis,
        Push
    };


    public powerSwitch power;
    void Start()
    {
        holder = GameObject.Find("Sounds").GetComponent<SoundsHolder>();
        audio = holder.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        power = powerSwitch.Freeze;
        cam = GameObject.Find("vThirdPersonController").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        im = GameObject.Find("PowerSprite").GetComponent<Image>();
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
        //Movement();
        Powers();
        /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push") || anim.GetCurrentAnimatorStateInfo(0).IsName("Pull")
            || anim.GetCurrentAnimatorStateInfo(0).IsName("Freeze"))
        {
            anim.applyRootMotion = false;
            // Avoid any reload.
        }
        else
        {
            anim.applyRootMotion = true;
        }*/

        if (this.transform.position.y < -21) {
        	CanvasGroup canvasGroup = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        	Cursor.lockState = CursorLockMode.None;
	        canvasGroup.interactable = true;
	        canvasGroup.blocksRaycasts = true;
	        canvasGroup.alpha = 1f;
	        Time.timeScale = 0f;
        }

    }

    public void Powers()
    {
        if (carriedObject == null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                currentPower++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                currentPower--;

            }
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
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            ObjectFreeze freeze = hit.collider.gameObject.GetComponent<ObjectFreeze>();
            if (freeze != null)
            {
                theObject = hit.collider.gameObject;
                theObject.GetComponent<Renderer>().material.color = Color.yellow;
                Transform[] list = theObject.GetComponentsInChildren<Transform>();
                foreach (Transform child in list)
                {
                    child.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (frozenObject == null)
                {                   
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        audio.clip = holder.sources[2];
                        audio.Play();
                        anim.SetTrigger("freeze");
                        freeze.StopObject();
                    }
                }
            }
            else
            {
                if (theObject != null)
                {
                    theObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                    theObject.GetComponent<Renderer>().material.color = Color.yellow;
                    Transform[] list = theObject.GetComponentsInChildren<Transform>();
                    foreach (Transform child in list)
                    {
                        child.gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                    }
                    theObject = null;
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
        if (carriedObject == null) {
            if (Physics.Raycast(ray, out hit, 100f, ~(1 << 8)))
            {
                if (Physics.Raycast(ray, out hit, 100f, ~(1 << 8)))
                {
                    //Debug.Log(hit.collider.gameObject);
                    Magnet magnet = hit.collider.gameObject.GetComponent<Magnet>();
                    if (magnet != null)
                    {
                        theObject = hit.collider.gameObject;
                        theObject.GetComponent<Renderer>().material.color = Color.yellow;
                        if (Input.GetKeyDown(KeyCode.E) && carriedObject == null)
                        {
                            if (!magnet.isHolding)
                            {
                                audio.clip = holder.sources[1];
                                audio.Play();
                                anim.SetTrigger("pull");
                                magnet.isHolding = true;
                                carriedObject = hit.collider.gameObject;
                            }
                        }

                    }
                    else
                    {
                        if (theObject != null)
                        {
                            theObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                            theObject = null;
                        }
                    }
                }
            }
        /*if (Input.GetKeyDown(KeyCode.E) && carriedObject == null)
        {
            Debug.Log("shit");
            if (Physics.Raycast(ray, out hit, 100f, ~(1 << 8)))
            {
                Debug.Log(hit.collider.gameObject);
                Magnet magnet = hit.collider.gameObject.GetComponent<Magnet>();
                if (magnet != null)
                {
                    theObject = hit.collider.gameObject;
                    theObject.GetComponent<Renderer>().material.color = Color.yellow;
                    if (!magnet.isHolding)
                    {
                        magnet.isHolding = true;
                        carriedObject = hit.collider.gameObject;
                    }

                }
                else
                {
                    if (theObject != null)
                    {
                        theObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                        theObject = null;
                    }
                }
            }
            else
            {
                Debug.Log("hit nothing?");
            }*/

        }
        else if (Input.GetKeyDown(KeyCode.E) && carriedObject != null)
        {
            carriedObject.GetComponent<Magnet>().isHolding = false;
            carriedObject = null;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && carriedObject != null)
        {
            float distance = Vector3.Distance(carriedObject.transform.position, player.transform.position);
            if (distance <= 15f)
            {
                carriedObject.transform.position = Vector3.MoveTowards(carriedObject.transform.position, player.transform.position, -Time.deltaTime * 10f);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && carriedObject != null)
        {
            float distance = Vector3.Distance(carriedObject.transform.position, player.transform.position);
            if (distance >= 3f)
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
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Debug.Log("boo");
            Rigidbody otherRb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                theObject = otherRb.gameObject;
                theObject.GetComponent<Renderer>().material.color = Color.yellow;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mouseDir = mousePos - gameObject.transform.position;
                mouseDir.z = 0.0f;
                mouseDir = mouseDir.normalized;

                if (Input.GetMouseButtonDown(0))
                {
                    //otherRb.AddForce(-mouseDir * 100000);
                    audio.clip = holder.sources[0];
                    audio.Play();
                    anim.SetTrigger("push");
                    otherRb.AddForce(transform.forward * 1000000);
                }
            }
            else if (hit.collider.gameObject.name == "Red Press Button 1" && GameObject.Find("Cylinder 1").GetComponent<Animator>().GetBool("Out") == false) {
                theObject = hit.collider.gameObject;
                theObject.GetComponent<Renderer>().material.color = Color.yellow;
                if (Input.GetMouseButtonDown(0)) {
            		GameObject.Find("Cylinder 1").GetComponent<Animator>().SetBool("Out", true);
            		StartCoroutine(BringPistonIn());
            	}
            }
            else if (hit.collider.gameObject.name == "Red Press Button 2" && GameObject.Find("Cylinder 1").GetComponent<Animator>().GetBool("Out") == false) {
                theObject = hit.collider.gameObject;
                theObject.GetComponent<Renderer>().material.color = Color.yellow;
                if (Input.GetMouseButtonDown(0)) {
            		GameObject.Find("Cylinder 2").GetComponent<Animator>().SetBool("Out", true);
            		StartCoroutine(BringPistonIn());
            	}
            }
            else
            {
                if (theObject != null)
                {
                    theObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                    theObject = null;
                }
            }
        }
    }
    IEnumerator BringPistonIn()
    {
        yield return new WaitForSeconds(.1f);
        GameObject.Find("Cylinder 1").GetComponent<Animator>().SetBool("Out", false);
        GameObject.Find("Cylinder 2").GetComponent<Animator>().SetBool("Out", false);
    }

}



