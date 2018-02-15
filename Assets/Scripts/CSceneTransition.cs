using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSceneTransition : MonoBehaviour
{
    public GameObject fadingImgPrefab;
    public Canvas mainCanvas;
    [Range(0.1f, 1f)]
    public float fadingSpeed = 0.01f;

    private Material imgMat;
    private Image fadingImg;

    private void Start()
    {
        GameObject img = Instantiate(fadingImgPrefab, mainCanvas.transform.position,
            fadingImgPrefab.transform.rotation);
        img.transform.SetParent(mainCanvas.transform);
        fadingImg = img.GetComponent<Image>();
        fadingImg.rectTransform.offsetMin = Vector2.zero;
        fadingImg.rectTransform.offsetMax = Vector2.zero;
        StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        Color newColor = fadingImg.color;
        while (newColor.a > 0f)
        {
            newColor.a -= (Time.deltaTime * fadingSpeed);
            fadingImg.color = newColor;
            yield return null;
        }
    }
}
