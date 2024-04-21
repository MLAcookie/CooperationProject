using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCupManager : MonoBehaviour
{
    public List<bool> levelGoal = new List<bool>();
    public GameObject Animation;
    public int level = 0;

    public struct waterInfoS
    {
        int max;
        int pres;
    }

    private List<Vector2> initialPos = new List<Vector2>();
    private List<GameObject> cupPos = new List<GameObject>();
    private List<GameObject> reservesPos = new List<GameObject>();

    public List<int> maxReservesS = new List<int>();
    public List<int> reservesS = new List<int>();
    public List<int> CupID = new List<int>();
    public List<int> goalReserves = new List<int>();

    //���Ӳ�ת�ˣ������д���洢���ݵ���������һ��
    public GameObject Canvas;

    //���Ӳ�ת��

    public GameObject WaterCupPre;
    public GameObject reservesPre;

    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            initialPos.Add(gameObject.transform.GetChild(i).transform.position);
        }
    }

    private void Start()
    {
        WaterCupGameEvent.instance.onGameStart += levelStart;
        WaterCupGameEvent.instance.onCupAction += setGoal;
        WaterCupGameEvent.instance.onGameFinish += levelEnd;
        WaterCupGameEvent.instance.onLevelClear += Clear;
        WaterCupGameEvent.instance.onTextInitial += addToCanvas;
        if (Canvas == null)
        {
            var search = GameObject.Find("Canvas");
            if (search != null)
            {
                Canvas = search;
            }
            else
            {
                Debug.Log("error");
            }
        }
    }

    void Update() { }

    private void addToCanvas(GameObject itself)
    {
        itself.transform.SetParent(Canvas.transform, true);
        itself.transform.localScale = new Vector3(1, 1, 1);
    }

    void levelStart(int _level)
    {
        if (level == _level)
        {
            for (int i = 0; i < initialPos.Count; i++)
            {
                cupPos.Add(Instantiate(WaterCupPre));
                cupPos[i].transform.position = initialPos[i];

                cupPos[i].GetComponent<WaterCup>().maxReserves = maxReservesS[i];
                cupPos[i].GetComponent<WaterCup>().reserves = reservesS[i];
                cupPos[i].GetComponent<WaterCup>().ID = CupID[i];
                cupPos[i].GetComponent<WaterCup>().goalReserves = goalReserves[i];
                cupPos[i].GetComponent<WaterCup>().level = level;
                //���Ӳ�ת�ˣ������д���洢���ݵ���������һ��


                reservesPos.Add(Instantiate(reservesPre));
                reservesPos[i].gameObject.GetComponent<ReservesCount>().WaterCupInfo = cupPos[i]
                    .GetComponent<WaterCup>();
                reservesPos[i].gameObject.GetComponent<ReservesCount>().resrvesPos = cupPos[i]
                    .transform.GetChild(0)
                    .gameObject;
            }
        }
    }

    void setGoal(int _level, int goal, bool action)
    {
        if (level == _level)
        {
            levelGoal[goal] = action;
            if (levelGoal.TrueForAll(value => value == true))
            {
                WaterCupGameEvent.instance.gameFinish(level);
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
            for (int i = 0; i < cupPos.Count; i++)
            {
                cupPos[i].SetActive(false);
                reservesPos[i].SetActive(false);
            }
            gameObject.SetActive(false);
            WaterCupGameEvent.instance.onGameStart -= levelStart;
            WaterCupGameEvent.instance.onCupAction -= setGoal;
            WaterCupGameEvent.instance.onGameFinish -= levelEnd;
            WaterCupGameEvent.instance.onLevelClear -= Clear;
            WaterCupGameEvent.instance.onTextInitial -= addToCanvas;
        }
    }
}
