using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCircleGameEvent : MonoBehaviour
{

    public static CutCircleGameEvent instance;
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

    public event Action<int> onSpaceButtonDown;
    public void SpaceButtonDown(int dl)
    {
        if (onSpaceButtonDown != null)
        {
            onSpaceButtonDown(dl);
        }
    }

    public event Action onNumberOff;
    public void NumberOff()
    {
        if (onNumberOff != null)
        {
            //��Բ������ʾ���
            Debug.Log("end");
            onNumberOff();
        }
    }

}
