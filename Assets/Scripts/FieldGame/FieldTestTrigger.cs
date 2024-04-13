using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTestTrigger : MonoBehaviour
{
    public int level;
    public bool GamsStartActive = false;
    public bool GamsFinishActive = false;
    public bool GamsClearActive = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (GamsStartActive == true)
        {
            FieldGameEvent.instance.gameStart(level);
            GamsStartActive = false;
        }
        if (GamsFinishActive == true)
        {
            FieldGameEvent.instance.gameFinish(level);
            GamsFinishActive = false;
        }
        if (GamsClearActive == true)
        {
            FieldGameEvent.instance.levelClear(level);
            GamsClearActive = false;
        }
    }
}
