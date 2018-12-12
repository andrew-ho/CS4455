using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room2GuideTextTrigger : MonoBehaviour {
    public Text guideText;
    public GameObject box;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider obj)
    {
        if (box.name == "roomGuideBox1")
        {
            guideText.text = "First, you have the ability to push objects that are directly in front of you." +
                "\n Walk up to an object and Left Click. Start by pushing this barrel out of the way.";
        }
        else if (box.name == "roomGuideBox2" && obj.name != "Big Barrel")
        {
            guideText.text = "Some objects, such as this boulder, can be used to knock over other objects.";
        }
        else if (box.name == "roomGuideBox3")
        {
            guideText.text = "Next, you can move objects even if you are far away from them, like telekinesis." +
                "\n Use the Mouse Wheel to change your current ability from Push to Move." +
                "\n Face an object, press E to pick it up, and use the Mouse and Mouse Wheel to move it around." +
                "\n Press E again to drop it. Try moving this cube onto the button.";
        }
        else if (box.name == "roomGuideBox4")
        {
            guideText.text = "Use your environment to your advantage."; 
        }
        else if (box.name == "roomGuideBox5")
        {
            guideText.text = "That platform is moving too fast to walk across. " +
                "\n Swap to your Pause ability and press F while facing it to temporarily pause it." +
                "\n You can freeze moving objects for five seconds before they start moving again.";
        }
        else if (box.name == "roomGuideBox6")
        {
            guideText.text = "If you pause something at the wrong time, don’t worry. Wait for it to resume moving and try again";
        }
        else if (box.name == "roomGuideBox7")
        {
            guideText.text = "Well done! One more thing: there may be enemy guards that chase you if you enter their line of sight," +
                "\n so try to hide if you get caught. " +
                "\n Walk forward to complete the tutorial. Good luck!";
        }

    }
}
