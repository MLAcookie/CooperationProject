using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableTheFinalStage : MonoBehaviour
{
    public GameObject Lock;

    private void Awake()
    {
        if (!StageCount.IsStageAComplete || !StageCount.IsStageBComplete)
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = new Color(.7f, .7f, .7f);
            Lock.SetActive(true);
        }
        else
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().color = new Color(1, 1, 1);
            Lock.SetActive(false);
        }
    }
}
