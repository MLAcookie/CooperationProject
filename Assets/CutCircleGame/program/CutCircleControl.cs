using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCircleControl : MonoBehaviour
{
    public GameObject graph;


    private int dl = 1;


    private bool inRot = false; 
    private bool inRotEnd = false;
    private float acc = 0f;

    private float rightRot = 30;

    private bool canC = false;

    void Start()
    {
        dlNext();
        CutCircleGameEvent.instance.onShow += onC;
        CutCircleGameEvent.instance.onGameFinish += endC;
    }

    private void onC(int nu)
    {
        if(nu == -1)
        {
            canC = true;
        }
    }
    private void endC()
    {
        canC = false;
    }


    void Update()
    {
        if (inRot == true)
        {
            //Debug.Log(acc);
            if (inRotEnd == false)
            {
                acc -= Time.deltaTime * 1f;
                rightRot += acc;
                graph.transform.eulerAngles = new Vector3(0, 0, rightRot);
                if(acc < -4f)
                {
                    dlNext();
                    inRotEnd = true;
                }
            }
            else
            {
                acc += Time.deltaTime * 2f;
                rightRot += acc;
                graph.transform.eulerAngles = new Vector3(0, 0, rightRot);
                if (acc >= 0f)
                {   
                    inRot = false;
                    inRotEnd = false;
                }
            }

        }
        else
        {
            if (dl >= 12)
            {
                CutCircleGameEvent.instance.NumberOff();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && canC == true)
                {
                    inRot = true;
                }
            }
        }
    }

    void dlNext()
    {
        CutCircleGameEvent.instance.SpaceButtonDown(dl);

        Debug.Log(dl + "轮次" + Resourses.instance.serEdge(dl)
            + "边数" + Resourses.instance.serPai(dl) + "精度");

        dl++;
    }
}
