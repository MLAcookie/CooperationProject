using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{

    public float ID = -1;
    void Start()
    {
        FieldGameEvent.instance.onFindPoint += ReturnPoint;
    }

    void Update()
    {

    }


    void ReturnPoint(int id)
    {
        if (id == ID)
        {
            FieldGameEvent.instance.returningPoint(id, gameObject);
        }
    }

    private void OnDestroy()
    {
        FieldGameEvent.instance.onFindPoint -= ReturnPoint;
    }

}
