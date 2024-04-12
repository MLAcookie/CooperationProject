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
            //割圆动画演示完毕
            Debug.Log("end");
            onNumberOff();
        }
    }

    //结束游戏（用于终止玩家对物体的操控（但不清空画面））
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

    //可以做个淡出的效果，但没实装
    public event Action<int> onEndShow;
    public void endShow(int nu)
    {
        if (onEndShow != null)
        {
            onEndShow(nu);
        }
    }
}
