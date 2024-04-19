using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WhenVideoEnd : MonoBehaviour
{
    VideoPlayer localPlayer;

    private void Awake()
    {
        localPlayer = GetComponent<VideoPlayer>();
        localPlayer.loopPointReached += (s) => OnVideoEnd();
    }

    private void OnVideoEnd()
    {
        DialogBoxManager.instance.OpenDiglogBox("开场");
        gameObject.SetActive(false);
    }
}
