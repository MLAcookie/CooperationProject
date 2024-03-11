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
    public void GetText(string name)
    {
        Debug.Log("Start reading FileText");
        this.TextFileName = name;
        this.LineIndex = 0;
        TextLines = FileHandler.instance.ReadTxtFile(TextFileName + ".txt");
    }
    public void ParsingText(int num)
    {
        TempScript = TextLines[num].Split('|');
        // *| ◊¢ Õ÷∏¡Ó
        if (TempScript[0] == "*")
        {
            LineIndex++;
            return;
        }
        // C| √¸¡Ó÷∏¡Ó
        if (TempScript[0] == "C")
        {
            if (TempScript[1] == "setBG")
            {
                Debug.Log("setbackground");
                //Background switch process
                // (Set Background Method)
            }
            else if (TempScript[1] == "setbgm")
            {
                Debug.Log("setbgm");
                //Set current BGM
                //(set BGM Method)
            }
            else if (TempScript[1] == "setcharacter")
            {
                if (TempScript[2] != "null")
                {
                    //(Set Character Method)
                }
            }
            else if (TempScript[1] == "erasecharacter")
            {
                //(erase Character Method)
            }
            else if (TempScript[1] == "stopbgm")
            {
                //(stop BGM Method)
            }
            ParsingText(num + 1);
            LineIndex++;
            return;
        }
    }
}
