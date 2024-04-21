using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToShare : MonoBehaviour
{
    public RenderTexture RenderTexture;
    public GameObject ShareInterface;
    public Image Image;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ShareInterface.SetActive(true);
        Texture2D texture2D = new Texture2D(1920, 1080, TextureFormat.ARGB4444, false);
        RenderTexture.active = RenderTexture;
        texture2D.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
        texture2D.Apply();
        Sprite temp = Sprite.Create(texture2D, new Rect(0, 0, 1920, 1080), new Vector2(.5f, .5f));
        Image.sprite = temp;
        ShareInterface.GetComponent<ICanvasAnimation>().ShowAnimation();
    }
}
