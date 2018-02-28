using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameFinishedScene : MonoBehaviour
{
    public Text txtInfo;

    private void Start()
    {
        txtInfo.text = string.Concat("¡Ganaste el juego con ", CGameController.instance.deaths,
            " muertes!");
    }
}
