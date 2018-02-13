using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CInputButtonPressed : MonoBehaviour, IPointerDownHandler
{
    public int buttonId;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        CInputController.instance.ButtonPressed(buttonId);
    }
}
