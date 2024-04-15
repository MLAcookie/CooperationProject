using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToShow : MonoBehaviour
{
    public GameObject ShowObject;

    bool isOpenedPanel = false;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
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
