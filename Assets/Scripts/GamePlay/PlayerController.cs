using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization

    public Camera cam;
    public GameObject player;
    GameObject carriedObject;
    public Texture2D crosshairImage;
    void Start () {

	}
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
    // Update is called once per frame
    void Update () {
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
}
