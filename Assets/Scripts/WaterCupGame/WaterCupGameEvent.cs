using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCupGameEvent : MonoBehaviour
{

    public static WaterCupGameEvent instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action onFinishPouring;
    public void FinishPouring()
    {
        if(onFinishPouring != null) 
        {
            onFinishPouring();
        }
    }

    public event Action<GameObject> onTextInitial;
    public void textInitial(GameObject itself)
    {
        if (onTextInitial != null)
        {
            onTextInitial(itself);
        }
    }

    public event Action<int, int, bool> onCupAction;
    public void CupAction(int ID, int goal, bool action)
    {
        if (onCupAction != null)
        {
            onCupAction(ID, goal, action);
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
