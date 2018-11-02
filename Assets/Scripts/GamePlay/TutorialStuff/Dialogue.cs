using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    public CanvasGroup canvasGroup;
    public string message;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            if (canvasGroup.interactable)
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                Destroy(this.gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            text.text = message;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            Destroy(this.gameObject);
        }
    }
}
