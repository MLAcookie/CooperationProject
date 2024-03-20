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
    public event Action onCut;
    public void Cutting()
    {
        if (onCut != null)
        {
            onCut();
        }
    }

    public event Action onGameFinish;
    public void gameFinish()
    {
        if (onGameFinish != null)
        {
            onGameFinish();
        }
    }

}
