using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCircleControl : MonoBehaviour
{
    public GameObject graph;


    private float CD = 0;
    private float maxCD = 1;

    private int dl = 1;


    private bool inRot = false; 
    private bool inRotEnd = false;
    private float acc = 0f;

    private float rightRot = 30;

    void Start()
    {
        dlNext();
    }

    void Update()
    {
        if (inRot == true)
        {
            //Debug.Log(acc);
            if (inRotEnd == false)
            {
                acc += Time.deltaTime * 1f;
                rightRot += acc;
                graph.transform.eulerAngles = new Vector3(0, 0, rightRot);
                if(acc > 8f)
                {
                    dlNext();
                    inRotEnd = true;
                }
            }
            else
            {
                acc -= Time.deltaTime * 2f;
                rightRot += acc;
                graph.transform.eulerAngles = new Vector3(0, 0, rightRot);
                if (acc <= 0f)
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
                if (Input.GetKeyDown(KeyCode.Space))
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
