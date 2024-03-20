using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxManager : MonoBehaviour
{
    public static DialogBoxManager instance;
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI TalkText;
    public GameObject Img_Background;//background image
    public GameObject LeftChara, CenterChara, RightChara;//characters
    public GameObject DialogueBoxPanel;
    public Dictionary<string, GameObject> CharaPosition;//match character position

    public bool ShowTalkText;//judge if display complete
    public string TempText;
    public string CorText;
    public float TextSpeed = 10.0f;

    private void Awake()
    {
        instance = this;
        CharaPosition = new Dictionary<string, GameObject> { { "left", LeftChara }, { "mid", CenterChara }, { "right", RightChara } };
    }

    public void LoadCharacter(string path, string pos)
    {
        Sprite TempSprite = (Sprite)Resources.Load("FG/" + path, typeof(Sprite));
        GameObject character = CharaPosition[pos];
        //initialize sprite
        character.GetComponent<Image>().sprite = TempSprite;
        character.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    //method to control character display( on ->display off->erase)
    public void CharacterDisplay(string pos, string type)
    {
        if (pos == "all")//process all positions
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
        else//process single position
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
}
