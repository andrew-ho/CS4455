using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideMenuPanel : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject InstructionPanel;

	public void showMenu() {
		MenuPanel.gameObject.SetActive(true);
	}

	public void hideMenu() {
		MenuPanel.gameObject.SetActive(false);
	}


	public void showInstruction() {
		InstructionPanel.gameObject.SetActive(true);
	}

	public void hideInstruction() {
		InstructionPanel.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
        InstructionPanel.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
