using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnter : MonoBehaviour
{
    public int UntilFrames = 480;

    void Start()
    {
        StartCoroutine(nameof(EnterAnimation));
    }

    IEnumerator EnterAnimation()
    {
        float t = .0093f;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(t, t, t);
        for (float i = 0; i <= UntilFrames; i++)
        {
            t = .0093f + i / UntilFrames * .0037f;
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(t, t, t);
            yield return null;
        }
    }
}
