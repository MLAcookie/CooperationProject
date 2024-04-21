using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStageManager : MonoBehaviour
{
    public GameObject Trigger;

    private void Awake()
    {
        Trigger.GetComponent<CupTestTrigger>().level = SceneParaHelper.StageIndex;
    }
}
