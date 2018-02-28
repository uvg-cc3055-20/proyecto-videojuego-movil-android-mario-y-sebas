using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenuManager : MonoBehaviour
{
    private const string DEATHS_KEY = "deaths";
    private void Start()
    {
        PlayerPrefs.SetInt(DEATHS_KEY, 0);
    }
}
