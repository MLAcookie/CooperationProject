using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToOpenDialog : MonoBehaviour
{
    public string DialogName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        DialogBoxManager.instance.OpenDiglogBox(DialogName);
        NextButton.OnDialogClose += () => GetComponent<ToShow>().Show();
    }
}
