using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public static event Action OnDialogClose;
    public Sprite trans;

    public void OnButtonClick()
    {
        if (DialogBoxManager.instance.ShowTalkText == true)
        {
            DialogBoxManager.instance.StopCoroutine("ShowDialogueCoroutine");
            DialogBoxManager.instance.ShowTalkText = false;
            DialogBoxManager.instance.TalkText.text = DialogBoxManager.instance.CorText;
        }
        else
        {
            if (TextParser.instance.LineIndex >= TextParser.instance.TextLines.Length)
            {
                DialogBoxManager.instance.CloseDiglogBox();
                DialogBoxManager.instance.LeftChara.GetComponent<Image>().sprite = trans;
                DialogBoxManager.instance.RightChara.GetComponent<Image>().sprite = trans;
                OnDialogClose?.Invoke();
                OnDialogClose = null;
            }
            else
            {
                TextParser.instance.ParsingText(TextParser.instance.LineIndex);
            }
        }
    }
}
