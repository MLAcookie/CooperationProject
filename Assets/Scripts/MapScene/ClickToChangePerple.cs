using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickToChangePerple : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    public GameObject Root;
    public Image Image;
    public int index;
    public string Text;

    List<Sprite> Sprites;

    private void Awake()
    {
        Sprites = Root.GetComponent<ChoosePeople>().Sprites;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (!Root.activeSelf)
        {
            Root.SetActive(true);
        }
        Image.sprite = Sprites[index];
        TextMeshProUGUI.text = Text;
    }
}
