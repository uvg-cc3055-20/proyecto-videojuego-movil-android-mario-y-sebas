using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CInputController : MonoBehaviour 
{
    public static CInputController instance; // singleton
    public Image imgDPad; // elemento del UI que representa el DPAD
    public Sprite dpadIdle; // sprite para cuando no hay nada presionado
    public Sprite leftPressed; // sprite para cuando el pad izquierdo este presionado
    public Sprite rightPressed; // sprite para cuando el pad derecho este presionado

    public bool IsLeftPressed
    {
        get { return isLeftPressed; }
    }
    public bool IsRightPressed
    {
        get { return isRightPressed; }
    }
    public bool IsABtnPressed
    {
        get { return isABtnPressed; }
    }
    public bool IsBBtnPressed
    {
        get { return isABtnPressed; }
    }
    public bool IsABtnFirstPress
    {
        get { return isABtnFirstPress; }
    }
    public bool IsBBtnFirstPress
    {
        get { return isBBtnFirstPress; }
    }

    private bool isLeftPressed;
    private bool isRightPressed;
    private bool isABtnPressed;
    private bool isABtnFirstPress;
    private bool isBBtnPressed;
    private bool isBBtnFirstPress;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Esta funcion es llamada cuando un boton es presionado y se encarga de asignar el estado correcto al boton en
    /// cuestion.
    /// </summary>
    /// <param name="buttonId"></param>
    public void ButtonPressed(int buttonId)
    {
        switch (buttonId)
        {
            case 0: // left d pad
                imgDPad.sprite = leftPressed;
                isLeftPressed = true;
                break;
            case 1: // right d pad
                imgDPad.sprite = rightPressed;
                isRightPressed = true;
                break;
            default:
                StartCoroutine(ButtonFirstPress(buttonId));
                break;
        }
    }
    
    /// <summary>
    /// Esta funcion es llamada cuando un boton es liberado y se encarga de asignar el estado correcto al boton en
    /// cuestion. 
    /// </summary>
    /// <param name="buttonId"></param>
    public void ButtonReleased(int buttonId)
    {
        switch (buttonId)
        {
                case 0: // left d pad
                    isLeftPressed = false;
                    imgDPad.sprite = dpadIdle;
                    break;
                case 1: // right d pad
                    isRightPressed = false;
                    imgDPad.sprite = dpadIdle;
                    break;
                case 2: // a btn
                    isABtnPressed = false;
                    break;
                case 3: // b btn
                    isBBtnPressed = false;
                    break;
        }
    }
    
    /// <summary>
    /// Detecta cuando uno de los botones es presionado por primera vez. Espera a que termine el frame actual, y
    /// reinicia el estado de los botones para poder detectar cuando sean presionados de nuevo.
    /// </summary>
    /// <param name="buttonId"></param>
    /// <returns></returns>
    private IEnumerator ButtonFirstPress(int buttonId)
    {
        switch (buttonId)
        {
            case 2:
                isABtnFirstPress = true;
                break;
            case 3:
                isBBtnFirstPress = true;
                break;
        }
        yield return new WaitForEndOfFrame();
        isABtnFirstPress = false;
        isBBtnFirstPress = false;
        switch (buttonId)
        {
            case 2:
                isABtnPressed = true;
                break;
            case 3:
                isBBtnPressed = true;
                break;
        }
    }
}
