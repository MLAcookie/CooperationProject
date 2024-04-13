using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTestTrigger : MonoBehaviour
{
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
            CutCircleGameEvent.instance.gameStart();
            GamsStartActive = false;
        }
        if (GamsFinishActive == true)
        {
            CutCircleGameEvent.instance.gameFinish();
            GamsFinishActive = false;
        }
        if (GamsClearActive == true)
        {
            CutCircleGameEvent.instance.levelClear();
            GamsClearActive = false;
        }
    }
}
