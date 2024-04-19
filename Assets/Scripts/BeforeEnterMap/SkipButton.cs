using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipButton : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RawImage RawImage;
    Button localButton;

    private void Awake()
    {
        localButton = GetComponent<Button>();
        localButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        VideoPlayer.Stop();
        RawImage.texture = null;
        DialogBoxManager.instance.OpenDiglogBox("开场");
        NextButton.OnDialogClose += () => ChangeScene();
        gameObject.SetActive(false);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scenes/MapScene");
    }
}
