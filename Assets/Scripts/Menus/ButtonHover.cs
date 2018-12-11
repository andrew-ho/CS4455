 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 
 public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color newColor = new Color(255, 159, 0);
    public Text text;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        print("hover");
        text.color = newColor; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white; //Or however you do your color
    }

}