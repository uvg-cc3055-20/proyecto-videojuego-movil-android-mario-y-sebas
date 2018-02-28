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
    private const string DEATHS_KEY = "deaths";
    
    #region Unity Callbacks
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        LoadDeaths();
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
        CSceneUtilities.instance.LoadScene(3);
    }

    public void SaveDeaths()
    {
        PlayerPrefs.SetInt(DEATHS_KEY, deaths);
    }
    #endregion
    
    #region Private Methods
    private void LoadDeaths()
    {
        deaths = PlayerPrefs.GetInt(DEATHS_KEY);
        txtDeaths.text = string.Concat("Muertes: ", deaths);
    }
    #endregion
}
