using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    CanvasGroup localCanvasGroup;
    RectTransform rectTransform;

    Vector3 saveLocate;

    public GameObject TransformPivot;
    public int UntilFrames = 240;
    public float StartDeltaX = 0;
    public float StartDeltaY = 0;
    public bool EnableShowTriger = false;
    public bool EnableFadeTriger = false;

    private void Awake()
    {
        localCanvasGroup = GetComponent<CanvasGroup>();
        rectTransform = TransformPivot.GetComponent<RectTransform>();
        saveLocate = rectTransform.localPosition;
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = new Vector3(
            saveLocate.x - StartDeltaX,
            saveLocate.y - StartDeltaY,
            saveLocate.z
        );
        localCanvasGroup.alpha = 0;
        StartCoroutine(ShowAnimate());
    }

    public void FadePanel()
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = saveLocate;
        localCanvasGroup.alpha = 1;
        StartCoroutine(FadeAnimate());
    }

    private void Update()
    {
        if (EnableShowTriger)
        {
            ShowPanel();
            EnableShowTriger = false;
        }
        if (EnableFadeTriger)
        {
            FadePanel();
            EnableFadeTriger = false;
        }
    }

    IEnumerator ShowAnimate()
    {
        for (int i = 0; i < UntilFrames; i++)
        {
            localCanvasGroup.alpha += 1.0f / UntilFrames;
            rectTransform.localPosition = new Vector3(
                rectTransform.localPosition.x + StartDeltaX / UntilFrames,
                rectTransform.localPosition.y + StartDeltaY / UntilFrames,
                rectTransform.localPosition.z
            );
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeAnimate()
    {
        for (int i = 0; i < UntilFrames; i++)
        {
            localCanvasGroup.alpha -= 1.0f / UntilFrames;
            rectTransform.localPosition = new Vector3(
                rectTransform.localPosition.x - StartDeltaX / UntilFrames,
                rectTransform.localPosition.y - StartDeltaY / UntilFrames,
                rectTransform.localPosition.z
            );
            yield return null;
        }
        yield return null;
    }
}
