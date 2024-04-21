using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBook : MonoBehaviour
{
    public Sprite Lock;
    public Sprite Unlock;

    private void Awake()
    {
        if (
            StageCount.IsStageAComplete
            && StageCount.IsStageBComplete
            && StageCount.IsStageCComplete
        )
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().sprite = Unlock;
        }
        else
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().sprite = Lock;
        }
    }
}
