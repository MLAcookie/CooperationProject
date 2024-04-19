using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToShow : MonoBehaviour
{
    public GameObject ShowObject;
    public bool IsNeedParameter = false;
    public List<string> Parameter;

    ICanvasAnimation canvasAnimation;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        ShowObject.SetActive(true);
        canvasAnimation = ShowObject.GetComponent<ICanvasAnimation>();
        if (IsNeedParameter)
        {
            canvasAnimation.SetParameter(Parameter);
        }
    }

    private void OnClick()
    {
        if (ShowObject.activeSelf)
        {
            ShowObject.GetComponent<ICanvasAnimation>().HideAnimation();
        }
        else
        {
            ShowObject.GetComponent<ICanvasAnimation>().ShowAnimation();
        }
    }
}
