using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CInputButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonId;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        CInputController.instance.ButtonPressed(buttonId);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CInputController.instance.ButtonReleased(buttonId);
    }
}
