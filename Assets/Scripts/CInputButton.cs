using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CInputButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler
{
    public int buttonId;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
            CInputController.instance.ButtonPressed(buttonId);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        CInputController.instance.ButtonPressed(buttonId);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CInputController.instance.ButtonReleased(buttonId);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        CInputController.instance.ButtonReleased(buttonId);
    }
}
