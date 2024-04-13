using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGameEvent : MonoBehaviour
{
    public static FieldGameEvent instance;


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



    public event Action onStartCut;
    public void startCutting()
    {
        if (onStartCut != null)
        {
            onStartCut();
        }
    }

    public event Action onEndCut;
    public void endCutting()
    {
        if (onEndCut != null)
        {
            onEndCut();
        }
    }

    public event Action<int> onFindPoint;
    public void findingPoint(int ID)
    {
        if (onFindPoint != null)
        {
            onFindPoint(ID);
        }
    }


    public event Action<int, GameObject> onReturnPoint;
    public void returningPoint(int ID, GameObject point)
    {
        if (onReturnPoint != null)
        {
            onReturnPoint(ID, point);
        }
    }

    public event Action<int, int, bool> onFieldAction;
    public void FieldAction(int ID,int goal,bool action)
    {
        if (onFieldAction != null)
        {
            onFieldAction(ID, goal, action);
        }
    }

    //��ʼ�ڼ��ص���Ϸ
    public event Action<int> onGameStart;
    public void gameStart(int level)
    {
        if (onGameStart != null)
        {
            onGameStart(level);
        }
    }

    //�����ڼ��ص���Ϸ��������ֹ��Ҷ�����Ĳٿأ�������ջ��棩��
    public event Action<int> onGameFinish;
    public void gameFinish(int level)
    {
        if (onGameFinish != null)
        {
            onGameFinish(level);
        }
    }

    //ȡ���ڼ��ص���Ϸ������ȡ���ڼ��ص��������ʾ��
    public event Action<int> onLevelClear;
    public void levelClear(int level)
    {
        if (onLevelClear != null)
        {
            onLevelClear(level);
        }
    }

    //���������ã�����Ի�ִ�в������Ի�����Ҫ��ʾִ�е�һ����ִ�еڶ��ִ�жԻ����Ի�������ִ�е�����
}
