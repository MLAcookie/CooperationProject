using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour, ICanvasAnimation
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
        gameObject.SetActive(false);
    }

    public void ShowAnimation()
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = new Vector3(
            saveLocate.x - StartDeltaX,
            saveLocate.y - StartDeltaY,
            saveLocate.z
        );
        localCanvasGroup.alpha = 0;
        StartCoroutine(Show());
    }

    public void HideAnimation()
    {
        rectTransform.localPosition = saveLocate;
        localCanvasGroup.alpha = 1;
        StartCoroutine(Hide());
    }

    private void Update()
    {
        if (EnableShowTriger)
        {
            ShowAnimation();
            EnableShowTriger = false;
        }
        if (EnableFadeTriger)
        {
            HideAnimation();
            EnableFadeTriger = false;
        }
    }

    public IEnumerator Show()
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
    }

    public IEnumerator Hide()
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
        gameObject.SetActive(false);
        yield return null;
    }

    public void SetParameter<T>(T value)
    {
        throw new System.NotImplementedException();
    }
}
