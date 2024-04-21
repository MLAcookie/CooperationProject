using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficaulty : MonoBehaviour
{
    public int StageIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneParaHelper.StageIndex = StageIndex);
    }
}
