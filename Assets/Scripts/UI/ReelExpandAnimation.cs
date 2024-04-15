using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReelExpandAnimation : MonoBehaviour, ICanvasAnimation
{
    public GameObject Background;
    public GameObject L;
    public GameObject R;
    public AnimationCurve Curve;
    public int UntilFrames = 240;
    public bool EnterTrigger = false;
    public bool LeaveTriggrt = false;

    RectMask2D rectMask2D;
    Rect backgroundSize;
    Vector3 lTransform;
    Vector3 rTransform;
    float dis;
    CanvasGroup localCanvasGroup;

    public void ShowAnimation()
    {
        gameObject.SetActive(true);
        localCanvasGroup.alpha = 0f;
        L.transform.localPosition = lTransform;
        R.transform.localPosition = rTransform;
        StartCoroutine(Show());
    }

    public void HideAnimation()
    {
        localCanvasGroup.alpha = 1f;
        L.transform.localPosition = lTransform;
        R.transform.localPosition = rTransform;
        StartCoroutine(Hide());
    }

    private void Awake()
    {
        rectMask2D = Background.GetComponent<RectMask2D>();
        backgroundSize = Background.GetComponent<RectTransform>().rect;
        lTransform = L.transform.localPosition;
        rTransform = R.transform.localPosition;
        dis = backgroundSize.width / 2;
        localCanvasGroup = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (EnterTrigger)
        {
            ShowAnimation();
            EnterTrigger = false;
        }
        if (LeaveTriggrt)
        {
            HideAnimation();
            LeaveTriggrt = false;
        }
    }

    public IEnumerator Show()
    {
        rectMask2D.padding = new Vector4(dis, 0, dis, 0);
        for (float i = 0; i <= UntilFrames; i++)
        {
            localCanvasGroup.alpha += 1f / UntilFrames;
            L.transform.localPosition = new Vector3(
                lTransform.x + dis * Curve.Evaluate(1.0f - i / UntilFrames),
                lTransform.y,
                lTransform.z
            );
            R.transform.localPosition = new Vector3(
                rTransform.x - dis * Curve.Evaluate(1.0f - i / UntilFrames),
                rTransform.y,
                rTransform.z
            );
            rectMask2D.padding = new Vector4(
                dis * Curve.Evaluate(1.0f - i / UntilFrames),
                0,
                dis * Curve.Evaluate(1.0f - i / UntilFrames),
                0
            );
            yield return null;
        }
    }

    public IEnumerator Hide()
    {
        rectMask2D.padding = new Vector4(0, 0, 0, 0);
        for (float i = 0; i <= UntilFrames; i++)
        {
            localCanvasGroup.alpha = 1f - Curve.Evaluate(i / UntilFrames);
            L.transform.localPosition = new Vector3(
                lTransform.x + dis * Curve.Evaluate(i / UntilFrames),
                lTransform.y,
                lTransform.z
            );
            R.transform.localPosition = new Vector3(
                rTransform.x - dis * Curve.Evaluate(i / UntilFrames),
                rTransform.y,
                rTransform.z
            );
            rectMask2D.padding = new Vector4(
                dis * Curve.Evaluate(i / UntilFrames),
                0,
                dis * Curve.Evaluate(i / UntilFrames),
                0
            );
            yield return null;
        }
        gameObject.SetActive(false);
        yield return null;
    }
}