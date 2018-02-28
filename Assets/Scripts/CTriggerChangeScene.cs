using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTriggerChangeScene : MonoBehaviour
{
    public int newSceneIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CGameController.instance.SaveDeaths();
            CSceneUtilities.instance.LoadSceneWithFadingTransition(newSceneIndex);   
        }
    }
}
