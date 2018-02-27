using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyAttack : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered enemy attack detection box.");
            CGameController.instance.RespawnPlayerFast();
        }
    }
}
