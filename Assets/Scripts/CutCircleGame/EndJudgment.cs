using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndJudgment : MonoBehaviour
{
    public GameObject Polygon;
    public VideoPlayer Player;
    public GameObject RawImage;
    public Button Button;
    public RenderTexture Texture;
    Graphic Graphic;
    bool flag = false;

    private void Awake()
    {
        Graphic = Polygon.GetComponent<Graphic>();
    }

    private void Start()
    {
        Player.Pause();
    }

    private void Update()
    {
        if (Graphic.segment >= 180)
        {
            flag = true;
        }
        if (flag)
        {
            Button.gameObject.SetActive(true);
            Player.Play();
            RawImage.GetComponent<RawImage>().color = Color.white;
            RawImage.GetComponent<RawImage>().texture = Texture;
            gameObject.SetActive(false);
            flag = false;
        }
    }
}
