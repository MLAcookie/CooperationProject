using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGroup : MonoBehaviour
{
    public int ID;
    public int nextID;
    private CanvasGroup cg;
    private bool alphaFlag = false;

    private bool flag = false;
    void Start()
    {
        cg = gameObject.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        CutCircleGameEvent.instance.onShow += show;
        CutCircleGameEvent.instance.onLevelClear += endShow;
    }

    void Update()
    {
        if (alphaFlag == true)
        {
            if (cg.alpha < 1)
            {
                cg.alpha += 0.2f * Time.deltaTime;
            }
            else
            {
                cg.alpha = 1;
                if (flag == false)
                {
                    CutCircleGameEvent.instance.show(nextID);
                    flag = true;
                }
            }
        }
        else
        {
            cg.alpha = 0;
        }
    }

    public void show(int nu)
    {
        if (nu == ID)
        {
            alphaFlag = true;
        }
    }
    public void endShow()
    {
        alphaFlag = false;
    }

}
