using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToShow : MonoBehaviour
{
    public GameObject ShowObject;
    public bool IsNeedParameter = false;
    public string Parameter;

    bool isOpenedPanel = false;
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
        if (isOpenedPanel)
        {
            ShowObject.GetComponent<ICanvasAnimation>().HideAnimation();
        }
        else
        {
            ShowObject.GetComponent<ICanvasAnimation>().ShowAnimation();
        }
        isOpenedPanel = !isOpenedPanel;
    }
}
