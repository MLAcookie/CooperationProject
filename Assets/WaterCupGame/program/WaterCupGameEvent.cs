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


    void Update()
    {
        
    }
}
