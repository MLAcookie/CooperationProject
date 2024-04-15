using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelExpandAnimation : MonoBehaviour
{
    public GameObject Background;
    public GameObject L;
    public GameObject R;
    public AnimationCurve Curve;
    public int UntilFrames = 240;
    public bool EnableTrigger = false;

    RectMask2D rectMask2D;
    Rect backgroundSize;
    Vector3 lTransform;
    Vector3 rTransform;
    float dis;

    public void ShowReel()
    {
        L.transform.localPosition = lTransform;
        R.transform.localPosition = rTransform;
        rectMask2D.padding = new Vector4(dis, 0, dis, 0);
        StartCoroutine(ExpandAnimation());
    }

    private void Awake()
    {
        rectMask2D = Background.GetComponent<RectMask2D>();
        backgroundSize = Background.GetComponent<RectTransform>().rect;
        lTransform = L.transform.localPosition;
        rTransform = R.transform.localPosition;
        dis = backgroundSize.width / 2;
    }

    private void Update()
    {
        if (EnableTrigger)
        {
            ShowReel();
            EnableTrigger = false;
        }
    }

    IEnumerator ExpandAnimation()
    {
        L.transform.localPosition = new Vector3(lTransform.x + dis, lTransform.y, lTransform.z);
        R.transform.localPosition = new Vector3(rTransform.x - dis, rTransform.y, rTransform.z);
        for (int i = 0; i < UntilFrames; i++)
        {
            L.transform.localPosition = new Vector3(
                L.transform.localPosition.x - dis / UntilFrames,
                L.transform.localPosition.y,
                L.transform.localPosition.z
            );
            R.transform.localPosition = new Vector3(
                R.transform.localPosition.x + dis / UntilFrames,
                R.transform.localPosition.y,
                R.transform.localPosition.z
            );
            rectMask2D.padding = new Vector4(
                rectMask2D.padding.x - dis / UntilFrames,
                0,
                rectMask2D.padding.z - dis / UntilFrames,
                0
            );
            yield return null;
        }
    }
}
