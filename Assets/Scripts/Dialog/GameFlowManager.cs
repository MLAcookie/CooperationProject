using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager instance;

    public event Action<int[]> onAddPlayerList;
    public void AddPlayerList(int[] ID)
    {
        if (onAddPlayerList != null)
        {
            onAddPlayerList(ID);
        }
    }
    public event Action onStepNext;
    public void stepNext()
    {
        if (onStepNext != null)
        {
            onStepNext();
        }
    }

    public int step = 0;
    public bool stepEnd = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameFlowManager.instance.onStepNext += next;
    }

    void Update()
    {
        if (stepEnd == true)
        {
            switch (step)
            {
                case 0:
                    AddPlayerList(new int[] { 0, 1 });
                    break;
                case 1:
                    DialogBoxManager.instance.OpenDiglogBox("01", 0);
                    break;

            }
            stepEnd = false;
        }

    }

    void next()
    {
        step++;
        stepEnd = true;
    }

}
