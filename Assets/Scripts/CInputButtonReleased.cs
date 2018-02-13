using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CInputButtonReleased : MonoBehaviour, IPointerUpHandler
{
    public int buttonId;
    
    public void OnPointerUp(PointerEventData eventData)
    {
        CInputController.instance.ButtonReleased(buttonId);
    }
}
