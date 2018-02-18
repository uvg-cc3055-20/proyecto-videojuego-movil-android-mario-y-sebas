using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Net.NetworkInformation;

public class CSceneUtilities : MonoBehaviour
{
    public static CSceneUtilities instance;
    
    public GameObject pnlFadingTransition;
    [Range(0.1f, 2f)]
    public float fadingSpeed = 1f;

    private Image fadingImg;
    
    #region Unity Callbacks
    private void Awake()
    {
        if (instance == null) instance = this;
        fadingImg = pnlFadingTransition.GetComponent<Image>();
    }
    #endregion
    
    #region Private Methods
    private IEnumerator FadeIn()
    {
        Color newColor = fadingImg.color;
        while (newColor.a > 0f)
        {
            newColor.a -= (Time.deltaTime * fadingSpeed);
            fadingImg.color = newColor;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        Color newColor = fadingImg.color;
        while (newColor.a < 1f)
        {
            newColor.a += (Time.deltaTime * fadingSpeed);
            fadingImg.color = newColor;
            yield return null;
        }
    }

    private IEnumerator LoadSceneWithFadingTransitionCoroutine(int index)
    {
        yield return StartCoroutine(FadeOut());
        LoadScene(index);
    }
    #endregion
    
    #region Public Methods
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSceneWithFadingTransition(int index)
    {
        StartCoroutine(LoadSceneWithFadingTransitionCoroutine(index));
    }

    public void StartSceneFadeIn()
    {
        StartCoroutine(FadeIn());
    }
    #endregion
}
