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
    }

    private void Start()
    {
        CSceneUtilities.instance.StartSceneFadeIn();
    }
    #endregion
    
    #region Public Methods
    public void RespawnPlayer()
    {
        player.transform.position = spawnPosition.position;
        deaths++;
        Debug.Log("Player died...respawning."); // TODO: remove for release
    }
    #endregion
}
