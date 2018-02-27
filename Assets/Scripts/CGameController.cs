using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CGameController : MonoBehaviour
{
    public static CGameController instance;
    public Transform spawnPosition;
    public Text txtDeaths;
    public int deaths = 0;

    private GameObject player;
    
    #region Unity Callbacks
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        CSceneUtilities.instance.StartSceneFadeIn();
        player = FindObjectOfType<CPlayerMovementDblJump>().gameObject;
    }
    #endregion
    
    #region Public Methods
    public void RespawnPlayerFast()
    {
        player.transform.position = spawnPosition.position;
        deaths++;
        txtDeaths.text = string.Concat("Muertes: ", deaths);
    }

    public void GameFinished()
    {
        Debug.Log("Player finished game with " + deaths + " deaths."); //TODO: remove for release
        CSceneUtilities.instance.LoadScene(3);
    }
    #endregion
}
