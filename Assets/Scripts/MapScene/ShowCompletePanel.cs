using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCompletePanel : MonoBehaviour
{
    public GameObject Complete;
    bool flag = false;

    private void Update()
    {
        if (StageCount.IsStageCComplete && flag == false)
        {
            Complete.SetActive(true);
            Complete.GetComponent<ICanvasAnimation>().ShowAnimation();
            flag = true;
        }
    }
}
