using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumText : MonoBehaviour
{

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        CutCircleGameEvent.instance.onSpaceButtonDown += turn;
        
    }

    void Update()
    {

    }

    private void turn(int dl)
    {
        if (dl == 5 || dl == 10)
        {
            text.text = Resourses.instance.serPai(dl).ToString() + "0";
        }
        else
        {
            text.text = Resourses.instance.serPai(dl).ToString();
        }
    }

}
