using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipButtonToMap : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RawImage RawImage;
    public GameObject Animation;
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
        gameObject.SetActive(false);
        Animation.GetComponent<CloudAnimation>().ShowAnimation();
    }
}
