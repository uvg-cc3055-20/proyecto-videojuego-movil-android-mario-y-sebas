﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnderworld : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) CGameController.instance.RespawnPlayerFast();
    }
}
