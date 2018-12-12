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

<<<<<<< HEAD
=======
        if (this.transform.position.y < -21) {
        	CanvasGroup canvasGroup = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        	Cursor.lockState = CursorLockMode.None;
	        canvasGroup.interactable = true;
	        canvasGroup.blocksRaycasts = true;
	        canvasGroup.alpha = 1f;
	        Time.timeScale = 0f;
        }
>>>>>>> 2caca16cfe8e4ab735d43399b54c16a078c47103
    }

    //public void Movement() {
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        anim.SetBool("walk", true);
    //        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
    //    }
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        anim.SetBool("walk", true);
    //        transform.position += Vector3.back * Time.deltaTime * movementSpeed;
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        anim.SetBool("walk", true);
    //        transform.position += Vector3.left * Time.deltaTime * movementSpeed;
    //    }
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        anim.SetBool("walk", true);
    //        transform.position += Vector3.right * Time.deltaTime * movementSpeed;
    //    } else {
    //        anim.SetBool("walk", false);
    //    }

    //    if (Input.GetKey(KeyCode.Space)) {
    //        anim.SetBool("jump", true);
    //        //transform.position = new Vector3(transform.position.x, playerJumpHeight, transform.position.z);
    //        transform.position += new Vector3(0, playerJumpHeight, 0);
    //    } else {
    //        anim.SetBool("jump", false);
    //    }
    //}
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
                if (frozenObject == null)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        freeze.StopObject();
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
        if (Input.GetKeyDown(KeyCode.E) && carriedObject == null)
        {
            Debug.Log("shit");
            if (Physics.Raycast(ray, out hit, 100f, ~(1 << 8)))
            {
                Debug.Log(hit.collider.gameObject);
                Magnet magnet = hit.collider.gameObject.GetComponent<Magnet>();
                if (magnet != null)
                {

                    if (!magnet.isHolding)
                    {
                        magnet.isHolding = true;
                        carriedObject = hit.collider.gameObject;
                    }

                }
            }
            else
            {
                Debug.Log("hit nothing?");
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && carriedObject != null)
        {
            carriedObject.GetComponent<Magnet>().isHolding = false;
            carriedObject = null;
        }
        //carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, new Vector3(player.transform.position.x, carriedObject.transform.position.y, 
        //   carriedObject.transform.position.z - Input.GetAxis("Mouse ScrollWheel")), Time.deltaTime * 5f);
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
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mouseDir = mousePos - gameObject.transform.position;
                mouseDir.z = 0.0f;
                mouseDir = mouseDir.normalized;

                if (Input.GetMouseButtonDown(0))
                {
                    //otherRb.AddForce(-mouseDir * 100000);
                    otherRb.AddForce(transform.forward * 1000000);
                }
            }
            else if (hit.collider.gameObject.name == "Red Press Button 1" && GameObject.Find("Cylinder 1").GetComponent<Animator>().GetBool("Out") == false) {
            	if (Input.GetMouseButtonDown(0)) {
            		GameObject.Find("Cylinder 1").GetComponent<Animator>().SetBool("Out", true);
            		StartCoroutine(BringPistonIn());
            	}
            }
            else if (hit.collider.gameObject.name == "Red Press Button 2" && GameObject.Find("Cylinder 1").GetComponent<Animator>().GetBool("Out") == false) {
            	if (Input.GetMouseButtonDown(0)) {
            		GameObject.Find("Cylinder 2").GetComponent<Animator>().SetBool("Out", true);
            		StartCoroutine(BringPistonIn());
            	}
            }
        }
    }
<<<<<<< HEAD
}
=======

    IEnumerator BringPistonIn() {
    	yield return new WaitForSeconds(.1f);
    	GameObject.Find("Cylinder 1").GetComponent<Animator>().SetBool("Out", false);
    	GameObject.Find("Cylinder 2").GetComponent<Animator>().SetBool("Out", false);
    }
}
>>>>>>> 2caca16cfe8e4ab735d43399b54c16a078c47103
