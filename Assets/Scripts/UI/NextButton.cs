using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
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
            }
            else
            {
                TextParser.instance.ParsingText(TextParser.instance.LineIndex);

            }
        }
    }
}