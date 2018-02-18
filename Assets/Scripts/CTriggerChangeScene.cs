using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTriggerChangeScene : MonoBehaviour
{
    public int newSceneIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        CSceneUtilities.instance.LoadSceneWithFadingTransition(newSceneIndex);
    }
}
