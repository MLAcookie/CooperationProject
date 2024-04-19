using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image localImage;

    private void Awake()
    {
        localImage = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(nameof(FadeAnimation));
    }

    IEnumerator FadeAnimation()
    {
        for (float i = 0; i < 1; i += .002f)
        {
            localImage.color = new Color(1, 1, 1, 1 - i);
            yield return null;
        }
    }
}
