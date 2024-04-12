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

    //开始第几关的游戏
    public event Action<int> onGameStart;
    public void gameStart(int level)
    {
        if (onGameStart != null)
        {
            onGameStart(level);
        }
    }

    //结束第几关的游戏（用于终止玩家对物体的操控（但不清空画面））
    public event Action<int> onGameFinish;
    public void gameFinish(int level)
    {
        if (onGameFinish != null)
        {
            onGameFinish(level);
        }
    }

    //取消第几关的游戏（用于取消第几关的物体的显示）
    public event Action<int> onLevelClear;
    public void levelClear(int level)
    {
        if (onLevelClear != null)
        {
            onLevelClear(level);
        }
    }

    //上述的作用：适配对话执行操作，对话中需要显示执行第一项，完成执行第二项并执行对话，对话结束后执行第三项
}
