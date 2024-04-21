using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompleteFlag : MonoBehaviour
{
    public int index = 0;

    private void Awake()
    {
        switch (index)
        {
            case 0:
                if (!StageCount.IsStageAComplete)
                {
                    gameObject.SetActive(false);
                }
                break;
            case 1:
                if (!StageCount.IsStageBComplete)
                {
                    gameObject.SetActive(false);
                }
                break;
            case 2:
                if (!StageCount.IsStageCComplete)
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
