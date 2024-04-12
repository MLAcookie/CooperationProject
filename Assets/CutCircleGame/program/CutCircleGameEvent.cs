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

    public event Action onGameStart;
    public void gameStart()
    {   
        show(0);
        if (onGameStart != null)
        {
            onGameStart();
        }
    }

    public event Action<int> onShow;
    public void show(int nu)
    {
        if (onShow != null)
        {
            Debug.Log(nu);
            onShow(nu);
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

    //������Ϸ��������ֹ��Ҷ�����Ĳٿأ�������ջ��棩��
    public event Action onGameFinish;
    public void gameFinish()
    {
        if (onGameFinish != null)
        {
            onGameFinish();
        }
    }

    public event Action onLevelClear;
    public void levelClear()
    {
        if (onLevelClear != null)
        {
            endShow(0);
            onLevelClear();
        }
    }

    //��������������Ч������ûʵװ
    public event Action<int> onEndShow;
    public void endShow(int nu)
    {
        if (onEndShow != null)
        {
            onEndShow(nu);
        }
    }
}
