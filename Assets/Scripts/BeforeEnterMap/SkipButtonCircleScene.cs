using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipButtonCircleScene : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RawImage RawImage;
    public GameObject CircleTrigger;
    Button localButton;

    private void Awake()
    {
        localButton = GetComponent<Button>();
        localButton.onClick.AddListener(OnClick);
        VideoPlayer.loopPointReached += (s) => OnClick();
    }

    void OnClick()
    {
        VideoPlayer.Stop();
        VideoPlayer.targetTexture.Release();
        RawImage.texture = null;
        RawImage.color = new Color(0, 0, 0, 0);
        gameObject.SetActive(false);
        CircleTrigger.GetComponent<CircleTestTrigger>().GamsStartActive = true;
    }
}
