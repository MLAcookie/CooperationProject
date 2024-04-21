using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLevelManager : MonoBehaviour
{
    public List<bool> levelGoal = new List<bool>();
    public int level = 0;

    public GameObject startObject;
    public GameObject Animation;

    void Start()
    {
        FieldGameEvent.instance.onGameStart += levelStart;
        FieldGameEvent.instance.onFieldAction += setGoal;
        FieldGameEvent.instance.onGameFinish += levelEnd;
        FieldGameEvent.instance.onLevelClear += Clear;
    }

    void Update() { }

    void levelStart(int _level)
    {
        if (level == _level)
        {
            startObject.SetActive(true);
        }
    }

    void setGoal(int _level, int goal, bool action)
    {
        if (level == _level)
        {
            levelGoal[goal] = action;
            if (levelGoal.TrueForAll(value => value == true))
            {
                FieldGameEvent.instance.gameFinish(level);
                DialogBoxManager.instance.OpenDiglogBox("分田结束");
                NextButton.OnDialogClose += () =>
                    Animation.GetComponent<CloudAnimation>().ShowAnimation();
                Debug.Log(level + "gameFinshed");
            }
        }
    }

    void levelEnd(int _level)
    {
        if (level == _level) { }
    }

    void Clear(int _level)
    {
        if (level == _level)
        {
            gameObject.SetActive(false);
        }
    }
}
