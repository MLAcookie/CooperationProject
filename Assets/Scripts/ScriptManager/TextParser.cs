using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextParser : MonoBehaviour
{
    public static TextParser instance;
    public string[] TextLines;
    public string[] TempScript;
    public string TextFileName;
    public int LineIndex;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetText("01", 0);
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
        if(LineIndex >= TextLines.Length)
        {
            return;
        }
        TempScript = TextLines[index].Split('|');
        // *| 注释指令
        if (TempScript[0] == "*")
        {
            LineIndex++;
            ParsingText(LineIndex);
        }
        // C| 命令指令
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
                    {                                              //角色名          //立绘名           //位置
                        Debug.Log("setfg");
                        DialogBoxManager.instance.LoadCharacter(TempScript[3] + "/" + TempScript[4] ,TempScript[2]);
                        DialogBoxManager.instance.CharacterDisplay(TempScript[2], "on");
                    }
                }
            }
            else if (TempScript[1] == "deletefg")
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
            LineIndex++;
            ParsingText(LineIndex);
        }
        else if(TempScript[0] == "S")
        {
            DialogBoxManager.instance.UpdateSpeakerName(TempScript[1]);
            DialogBoxManager.instance.DisplayDialogue(TempScript[2]);
            LineIndex++;
            return;
        }
    }
}
