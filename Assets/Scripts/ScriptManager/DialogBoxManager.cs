using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialogBoxManager : MonoBehaviour
{
    public static DialogBoxManager instance;
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI TalkText;
    public GameObject Img_Background; //background image
    public GameObject LeftChara,
        CenterChara,
        RightChara; //characters
    public GameObject DialogueBoxPanel;
    public Dictionary<string, GameObject> CharaPosition; //match character position

    public bool ShowTalkText; //judge if display complete
    public string TempText;
    public string CorText;
    public float TextSpeed = 10.0f;

    public Dictionary<string, string> speakers;

    private void Awake()
    {
        instance = this;
        speakers = new Dictionary<string, string>();
        CharaPosition = new Dictionary<string, GameObject>
        {
            { "left", LeftChara },
            { "mid", CenterChara },
            { "right", RightChara }
        };
    }

    public void AddSpeaker(string pos, string name, string fgPath)
    {
        //speakers = new Dictionary<string, string>();
        speakers[pos] = name;
        //speakers.Add(pos, name);
        Sprite TempSprite = (Sprite)Resources.Load("FG/" + fgPath, typeof(Sprite));
        GameObject character = CharaPosition[pos];
        character.GetComponent<Image>().sprite = TempSprite;
        character.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void DelSpeaker(string pos)
    {
        GameObject character = CharaPosition[pos];
        character.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        speakers.Remove(pos);
    }

    public void SwitchSpeaker(string name)
    {
        GameObject character;
        foreach (KeyValuePair<string, string> pair in speakers)
        {
            if (pair.Value != name)
            {
                character = CharaPosition[pair.Key];
                character.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 1);
            }
            else
            {
                character = CharaPosition[pair.Key];
                character.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void LoadCharacter(string pos, string path)
    {
        Sprite TempSprite = (Sprite)
            Resources.Load("FG/" + speakers[pos] + '/' + path, typeof(Sprite));
        GameObject character = CharaPosition[pos];
        //initialize sprite
        character.GetComponent<Image>().sprite = TempSprite;
        character.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void CharacterDisplay(string pos, string type)
    {
        if (pos == "all") //process all positions
        {
            if (type == "on")
            {
                CharaPosition["left"].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                CharaPosition["mid"].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                CharaPosition["right"].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else if (type == "off")
            {
                CharaPosition["left"].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                CharaPosition["mid"].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                CharaPosition["right"].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            if (type == "on")
            {
                CharaPosition[pos].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else if (type == "off")
            {
                CharaPosition[pos].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void UpdateSpeakerName(string name)
    {
        this.SpeakerName.text = name;
    }

    IEnumerator ShowDialogueCoroutine()
    {
        yield return new WaitForEndOfFrame();
        ShowTalkText = true;
        TempText = "";

        for (int i = 0; i < CorText.Length; i++)
        {
            TempText += CorText[i];
            //update temptext
            this.TalkText.text = TempText;
            yield return new WaitForSeconds(1 / TextSpeed);
        }
        ShowTalkText = false;
    }

    public void DisplayDialogue(string text)
    {
        StopCoroutine("ShowDialogueCoroutine");
        this.CorText = text;
        StartCoroutine("ShowDialogueCoroutine");
    }

    public void OpenDiglogBox(string filename, int index)
    {
        DialogueBoxPanel.SetActive(true);
        TextParser.instance.GetText(filename, index);
    }

    public void CloseDiglogBox()
    {
        DialogueBoxPanel.SetActive(false);
    }
}
