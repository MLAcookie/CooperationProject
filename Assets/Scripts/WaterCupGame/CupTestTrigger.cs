using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTestTrigger : MonoBehaviour
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
            WaterCupGameEvent.instance.gameStart(level);
            GamsStartActive = false;
        }
        if (GamsFinishActive == true)
        {
            WaterCupGameEvent.instance.gameFinish(level);
            GamsFinishActive = false;
        }
        if (GamsClearActive == true)
        {
            WaterCupGameEvent.instance.levelClear(level);
            GamsClearActive = false;
        }
    }
}
