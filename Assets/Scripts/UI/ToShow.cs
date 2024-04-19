using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToShow : MonoBehaviour
{
    public GameObject ShowObject;
    public bool IsNeedParameter = false;
    public List<string> Parameter;

    public void Show()
    {
        ShowObject.SetActive(true);
        if (IsNeedParameter)
        {
            ShowObject.GetComponent<ICanvasAnimation>().SetParameter(Parameter);
        }

        ShowObject.GetComponent<ICanvasAnimation>().ShowAnimation();
    }
}
