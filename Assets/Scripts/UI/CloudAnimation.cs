using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CloudAnimation : MonoBehaviour, ICanvasAnimation
{
    public GameObject L;
    public GameObject R;
    public int UntilFrames = 480;
    public float DeltaX = 1500f;
    public AnimationCurve Curve;
    public bool EnterTrigger = false;
    public bool LeaveTriggrt = false;

    Vector3 lTransform;
    Vector3 rTransform;

    private void Awake()
    {
        lTransform = L.transform.localPosition;
        rTransform = R.transform.localPosition;
    }

    private void Start()
    {
        HideAnimation();
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

    public IEnumerator Hide()
    {
        for (float i = 0; i < UntilFrames; i++)
        {
            L.transform.localPosition = new Vector3(
                lTransform.x - Curve.Evaluate(i / UntilFrames) * DeltaX,
                L.transform.localPosition.y,
                L.transform.localPosition.z
            );
            R.transform.localPosition = new Vector3(
                rTransform.x + Curve.Evaluate(i / UntilFrames) * DeltaX,
                R.transform.localPosition.y,
                R.transform.localPosition.z
            );
            yield return null;
        }
    }

    public void HideAnimation()
    {
        L.transform.localPosition = lTransform;
        R.transform.localPosition = rTransform;
        StartCoroutine(Hide());
    }

    public void SetParameter<T>(T value)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Show()
    {
        throw new System.NotImplementedException();
    }

    public void ShowAnimation()
    {
        StartCoroutine(Show());
    }
}
