using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCupManager : MonoBehaviour
{

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
    //脑子不转了，先随便写个存储数据的用来测试一下
    public GameObject Canvas;
    //脑子不转了

    public GameObject WaterCupPre;
    public GameObject reservesPre;


    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            initialPos.Add(gameObject.transform.GetChild(i).transform.position);
        }



        for (int i = 0; i < initialPos.Count; i++)
        {
            cupPos.Add(Instantiate(WaterCupPre));
            cupPos[i].transform.position = initialPos[i];
            cupPos[i].GetComponent<WaterCup>().maxReserves = maxReservesS[i];
            cupPos[i].GetComponent<WaterCup>().reserves = reservesS[i];
            //脑子不转了，先随便写个存储数据的用来测试一下
            reservesPos.Add(Instantiate(reservesPre));
            reservesPos[i].gameObject.GetComponent<ReservesCount>().WaterCupInfo = cupPos[i].GetComponent<WaterCup>();
            reservesPos[i].gameObject.GetComponent<ReservesCount>().resrvesPos = cupPos[i].transform.GetChild(0).gameObject;
        }
    }

    private void Start()
    {
        WaterCupGameEvent.instance.onTextInitial += addToCanvas;
    }

    void Update()
    {
        
    }

    private void addToCanvas(GameObject itself)
    {
        itself.transform.parent = Canvas.transform;
        itself.transform.localScale = new Vector3(1, 1, 1);
    }

}
