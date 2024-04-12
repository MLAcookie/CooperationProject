using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TextParser : MonoBehaviour
{
    public static TextParser instance;
    public string[] TextLines;
    public string[] TempScript;
    public string TextFileName;
    public int LineIndex;

    private bool SwitchMode = false;
    private void Awake()
    {
        instance = this;
    }

    public void GetText(string name, int index)
    {
        Debug.Log("Start reading FileText");
        this.TextFileName = name;
        this.LineIndex = index;
        TextLines = FileHandler.instance.ReadTxtFile(TextFileName + ".txt");
        //Get the Text
        ParsingText(LineIndex);//start parsing the first line
    }

    public void ParsingText(int index)
    {
        if (LineIndex >= TextLines.Length)
        {
            return;
        }
        TempScript = TextLines[index].Split('|');
        // *| ◊¢ Õ÷∏¡Ó
        if (TempScript[0] == "*")
        {
            LineIndex++;
            ParsingText(LineIndex);
        }
        // C| √¸¡Ó÷∏¡Ó
        else if (TempScript[0] == "C")
        {
            if (TempScript[1] == "setbg")
            {
                Debug.Log("setbackground");
                //Background switch process
                // (Set Background Method)
            }
            else if (TempScript[1] == "setfg")
            {
                {
                    if (TempScript[2] != "null")
                    {                                          
                        Debug.Log("setfg");
                        DialogBoxManager.instance.LoadCharacter(TempScript[2] , TempScript[3]);
                        DialogBoxManager.instance.CharacterDisplay(TempScript[2], "on");
                    }
                }
            }
            else if (TempScript[1] == "delfg")
            {
                DialogBoxManager.instance.CharacterDisplay(TempScript[2], "off");
            }
            else if (TempScript[1] == "setbgm")
            {
                Debug.Log("setbgm");
            }
            else if (TempScript[1] == "stopbgm")
            {
                //(stop BGM Method)
            }
            else if (TempScript[1] == "openswitch") 
            {
                SwitchMode = true;
            }
            else if (TempScript[1] == "closeswitch")
            {
                SwitchMode = false;
            }
            else if (TempScript[1] == "add")
            {
                DialogBoxManager.instance.AddSpeaker(TempScript[2], TempScript[3], TempScript[3] + "/" + TempScript[4]);
            }
            LineIndex++;
            ParsingText(LineIndex);
        }
        else if(TempScript[0] == "S")
        {
            DialogBoxManager.instance.UpdateSpeakerName(TempScript[1]);
            if(SwitchMode) DialogBoxManager.instance.SwitchSpeaker(TempScript[1]);
            DialogBoxManager.instance.DisplayDialogue(TempScript[2]);
            LineIndex++;
            return;
        }
        else
        {
            DialogBoxManager.instance.DisplayDialogue(TempScript[0]);
            LineIndex++;
            return;
        }
    }
}
