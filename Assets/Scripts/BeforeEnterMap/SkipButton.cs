using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipButton : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RawImage RawImage;
    public GameObject Animation;
    Button localButton;

    private void Awake()
    {
        
        localButton = GetComponent<Button>();
        localButton.onClick.AddListener(OnClick);
        NextButton.OnDialogClose += () => Animation.GetComponent<CloudAnimation>().ShowAnimation();
    }

    void OnClick()
    {
        VideoPlayer.Stop();
        RawImage.texture = null;
        DialogBoxManager.instance.OpenDiglogBox("开场");
        NextButton.OnDialogClose += () => Debug.Log("test");
        RawImage.color = new Color(0, 0, 0, 0);
        gameObject.SetActive(false);
    }
}
