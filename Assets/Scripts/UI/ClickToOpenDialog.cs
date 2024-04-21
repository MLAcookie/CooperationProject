using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToOpenDialog : MonoBehaviour
{
    public string DialogName;
    public int StageIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (DialogName != "")
        {
            DialogBoxManager.instance.OpenDiglogBox(DialogName);
        }
        NextButton.OnDialogClose += () => GetComponent<ToShow>().Show();
        switch (StageIndex)
        {
            case 0:
                StageCount.IsStageAComplete = true;
                break;
            case 1:
                StageCount.IsStageBComplete = true;
                break;
            case 2:
                StageCount.IsStageCComplete = true;
                break;
        }
    }
}
