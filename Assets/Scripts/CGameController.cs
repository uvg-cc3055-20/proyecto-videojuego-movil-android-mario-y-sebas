using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class CGameController : MonoBehaviour
{
    public static CGameController instance;
    public GameObject player;
    public Transform spawnPosition;

    private int deaths = 0;
    
    #region Unity Callbacks
    private void Awake()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CSceneUtilities.instance.StartSceneFadeIn();
    }
    #endregion
    
    #region Public Methods
    public void RespawnPlayerSlow()
    {
        Debug.Log("Player died...respawning."); // TODO: remove for release
        StartCoroutine(DeathCoroutine());
    }

    public void RespawnPlayerFast()
    {
        player.transform.position = spawnPosition.position;
        deaths++;
    }

    public void GameFinished()
    {
        Debug.Log("Player finished game with " + deaths + " deaths.");
    }
    #endregion
    
    #region Private Methods

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = spawnPosition.position;
        deaths++;
    }
    #endregion
}
