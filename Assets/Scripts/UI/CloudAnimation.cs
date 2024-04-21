using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloudAnimation : MonoBehaviour, ICanvasAnimation
{
    public GameObject L;
    public GameObject R;
    public Image WhiteMask;
    public int UntilFrames = 480;
    public float DeltaX = 1500f;
    public AnimationCurve Curve;
    public bool EnterTrigger = false;
    public bool LeaveTriggrt = false;
    public string SceneName;

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
        WhiteMask.color = Color.white;
        for (float i = 0; i < UntilFrames; i++)
        {
            WhiteMask.color = new Color(1, 1, 1, 1 - Curve.Evaluate(i / UntilFrames));
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
            yield return new WaitForSeconds(.01f);
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
        Debug.Log("change");
        float tempx = L.transform.localPosition.x;
        float tempy = R.transform.localPosition.x;
        WhiteMask.color = new Color(0, 0, 0, 0);
        for (float i = 0; i < UntilFrames; i++)
        {
            WhiteMask.color = new Color(1, 1, 1, Curve.Evaluate(i / UntilFrames));
            L.transform.localPosition = new Vector3(
                tempx + Curve.Evaluate(i / UntilFrames) * DeltaX,
                L.transform.localPosition.y,
                L.transform.localPosition.z
            );
            R.transform.localPosition = new Vector3(
                tempy - Curve.Evaluate(i / UntilFrames) * DeltaX,
                R.transform.localPosition.y,
                R.transform.localPosition.z
            );
            yield return new WaitForSeconds(.01f);
        }
        if (SceneName != "")
        {
            Debug.Log("123123");
            ChangeScene();
        }
        yield return new WaitForSeconds(.01f);
    }

    public void ShowAnimation()
    {
        L.transform.localPosition = new Vector3(lTransform.x - DeltaX, lTransform.y, lTransform.z);
        R.transform.localPosition = new Vector3(rTransform.x + DeltaX, rTransform.y, rTransform.z);
        StartCoroutine(Show());
    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
