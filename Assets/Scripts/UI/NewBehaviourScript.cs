using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
            TextParser.instance.ParsingText(TextParser.instance.LineIndex);
        }
    }
}
